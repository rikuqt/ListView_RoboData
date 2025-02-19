using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.Json;

namespace ListViewExample
{
    public partial class ListViewExample : Form
    {
        // Tarvittavat muuttujat listviewin päivittämiseen
        private delegate void MessageUpdate(int time, string ltime, string lvalue);
        private MessageUpdate deleq;

        private volatile bool bContinue = true;
        private Thread thread;

        // Gripperin url ja käyttäjätunnukset
        private static readonly string urlIosystemGripper = "http://127.0.0.1:8081/rw/iosystem/signals/DI_Gripper1_Closed";
        private static readonly string username = "Default User";
        private static readonly string password = "robotics";

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // jos listviewissä on valittu rivi, tulostetaan valitun rivin teksti
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];
                MessageBox.Show($"Selected item: {selectedItem.Text}");
            }
        }

        public ListViewExample()
        {
            InitializeComponent();
        }


        // kun button1 painetaan
        private void buttonStart_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            button1.Enabled = true;

            deleq = new MessageUpdate(UpdateListView);
            thread = new Thread(async () => await BackgroundThread()); // Start async method in a thread
            thread.Start();
        }

        // kun button2 painetaan (halutaan lopettaa ohjelma)
        private void buttonStop_Click(object sender, EventArgs e)
        {
            bContinue = false;
            thread?.Join();
            button2.Enabled = true;
            button1.Enabled = false;
        }


        // listviewin päivitys
        private void UpdateListView(int time, string ltime, string lvalue)
        {
            if (InvokeRequired)
            {
                BeginInvoke(new MessageUpdate(UpdateListView), time, ltime, lvalue);
            }
            else
            {
                int n = listView1.Items.Count;
                var item = new ListViewItem(time.ToString()); // Ensimmäinen sarake
                item.SubItems.Add(ltime); // Toinen sarake
                item.SubItems.Add(lvalue); // Kolmas sarake (lvalue)
                listView1.Items.Add(item);
            }
        }



        // taustalla pyörivä säie
        private async Task BackgroundThread()
        {
            var handler = new HttpClientHandler
            {
                Credentials = new System.Net.NetworkCredential(username, password)
            };

            using (var client = new HttpClient(handler))
            {
                int time = 0;

                while (bContinue)
                {
                    try
                    {
                        var response = await client.GetAsync($"{urlIosystemGripper}?json=1");
                        var content = await response.Content.ReadAsStringAsync();
                        Console.WriteLine("gripper: " + content);

                        string ltime = "N/A";
                        string lvalue = "N/A";

                        // kontetin parseeminen json dataksi
                        using (JsonDocument doc = JsonDocument.Parse(content))
                        {
                            var root = doc.RootElement;
                            var stateArray = root.GetProperty("_embedded").GetProperty("_state");

                            if (stateArray.GetArrayLength() > 0)
                            {
                                ltime = stateArray[0].GetProperty("ltime-sec").GetString();
                                lvalue = stateArray[0].GetProperty("lvalue").GetString();

                            }
                        }

                        time++;
                        Console.WriteLine($"Updating UI: time = {time}, ltime = {ltime}");

                        BeginInvoke(deleq, time, ltime, lvalue);

                        await Task.Delay(1000);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                }
            }
        }



    }
}
