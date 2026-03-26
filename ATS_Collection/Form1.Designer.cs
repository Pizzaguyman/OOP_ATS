namespace ATS_Collection
{
    partial class Form1
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
            ListViewItem listViewItem1 = new ListViewItem(new string[] { "Array", "1", "", "", "" }, -1);
            ListViewItem listViewItem2 = new ListViewItem(new string[] { "Queue", "6", "", "", "" }, -1);
            listView1 = new ListView();
            columnHeader2 = new ColumnHeader();
            columnHeader3 = new ColumnHeader();
            columnHeader1 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.Columns.AddRange(new ColumnHeader[] { columnHeader2, columnHeader3, columnHeader1, columnHeader4 });
            listView1.Items.AddRange(new ListViewItem[] { listViewItem1, listViewItem2 });
            listView1.Location = new Point(71, 91);
            listView1.Name = "listView1";
            listView1.Size = new Size(424, 134);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.Details;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "";
            columnHeader2.Width = 45;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Генерирование";
            columnHeader3.Width = 97;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Выборка последовательно";
            columnHeader1.Width = 160;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Выборка случайно";
            columnHeader4.Width = 117;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(45, 242);
            label1.Name = "label1";
            label1.Size = new Size(117, 15);
            label1.TabIndex = 1;
            label1.Text = "Размер контейнера:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(168, 242);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 2;
            label2.Text = "label2";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(45, 274);
            label3.Name = "label3";
            label3.Size = new Size(38, 15);
            label3.TabIndex = 3;
            label3.Text = "label3";
            label3.Click += label3_Click;
            // 
            // button1
            // 
            button1.Location = new Point(45, 34);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 4;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(163, 31);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 5;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(663, 450);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(listView1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView listView1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader4;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button button1;
        private Button button2;
    }
}
