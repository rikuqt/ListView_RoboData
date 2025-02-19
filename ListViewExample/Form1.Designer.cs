namespace ListViewExample
{
    partial class ListViewExample
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            listView1 = new ListView();
            Time = new ColumnHeader();
            LtimeSec = new ColumnHeader();
            Lvalue = new ColumnHeader();
            button1 = new Button();
            button2 = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.AccessibleName = "ListView1";
            listView1.Columns.AddRange(new ColumnHeader[] { Time, LtimeSec, Lvalue });
            listView1.Location = new Point(75, 48);
            listView1.Margin = new Padding(2);
            listView1.Name = "listView1";
            listView1.Size = new Size(659, 265);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // Time
            // 
            Time.Text = "Time";
            Time.Width = 150;
            // 
            // LtimeSec
            // 
            LtimeSec.Text = "LtimeSec";
            LtimeSec.Width = 100;
            // 
            // Lvalue
            // 
            Lvalue.Text = "Lvalue";
            Lvalue.Width = 150;
            // 
            // button1
            // 
            button1.AccessibleName = "buttonStop";
            button1.Location = new Point(641, 385);
            button1.Margin = new Padding(2);
            button1.Name = "button1";
            button1.Size = new Size(71, 50);
            button1.TabIndex = 1;
            button1.Text = "Stop";
            button1.UseVisualStyleBackColor = true;
            button1.Click += buttonStop_Click;
            // 
            // button2
            // 
            button2.AccessibleName = "buttonStart";
            button2.Location = new Point(525, 385);
            button2.Margin = new Padding(2);
            button2.Name = "button2";
            button2.Size = new Size(71, 50);
            button2.TabIndex = 2;
            button2.Text = "Start";
            button2.UseVisualStyleBackColor = true;
            button2.Click += buttonStart_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(75, 408);
            textBox1.Margin = new Padding(2);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(93, 31);
            textBox1.TabIndex = 3;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(205, 408);
            textBox2.Margin = new Padding(2);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(93, 31);
            textBox2.TabIndex = 4;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(331, 408);
            textBox3.Margin = new Padding(2);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(93, 31);
            textBox3.TabIndex = 5;
            // 
            // ListViewExample
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(listView1);
            Margin = new Padding(2);
            Name = "ListViewExample";
            Text = "ListView esimerkki";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView listView1;
        private ColumnHeader Time;
        private ColumnHeader LtimeSec;
        private ColumnHeader Lvalue;
        private Button button1;
        private Button button2;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
    }
}
