namespace ATS_Composite
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
            TreeNode treeNode1 = new TreeNode("Node0");
            TreeNode treeNode2 = new TreeNode("Node2");
            TreeNode treeNode3 = new TreeNode("Node5");
            TreeNode treeNode4 = new TreeNode("Node3", new TreeNode[] { treeNode3 });
            TreeNode treeNode5 = new TreeNode("Node4");
            TreeNode treeNode6 = new TreeNode("Node1", new TreeNode[] { treeNode2, treeNode4, treeNode5 });
            ComponentView = new TreeView();
            label1 = new Label();
            checkBox1 = new CheckBox();
            numericUpDown1 = new NumericUpDown();
            textBox1 = new TextBox();
            button1 = new Button();
            button2 = new Button();
            label2 = new Label();
            label3 = new Label();
            button3 = new Button();
            label4 = new Label();
            label5 = new Label();
            button4 = new Button();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // ComponentView
            // 
            ComponentView.Location = new Point(21, 28);
            ComponentView.Name = "ComponentView";
            treeNode1.Name = "Node0";
            treeNode1.Text = "Node0";
            treeNode2.Name = "Node2";
            treeNode2.Text = "Node2";
            treeNode3.Name = "Node5";
            treeNode3.Text = "Node5";
            treeNode4.Name = "Node3";
            treeNode4.Text = "Node3";
            treeNode5.Name = "Node4";
            treeNode5.Text = "Node4";
            treeNode6.Name = "Node1";
            treeNode6.Text = "Node1";
            ComponentView.Nodes.AddRange(new TreeNode[] { treeNode1, treeNode6 });
            ComponentView.Size = new Size(190, 252);
            ComponentView.TabIndex = 1;
            ComponentView.NodeMouseDoubleClick += ComponentView_NodeMouseDoubleClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(253, 37);
            label1.Name = "label1";
            label1.Size = new Size(122, 15);
            label1.TabIndex = 2;
            label1.Text = "Выбранный элемент";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Checked = true;
            checkBox1.CheckState = CheckState.Indeterminate;
            checkBox1.Location = new Point(551, 89);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(57, 19);
            checkBox1.TabIndex = 3;
            checkBox1.Text = "Занят";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(253, 87);
            numericUpDown1.Maximum = new decimal(new int[] { 1316134911, 2328, 0, 0 });
            numericUpDown1.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(120, 23);
            numericUpDown1.TabIndex = 4;
            numericUpDown1.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // textBox1
            // 
            textBox1.Location = new Point(415, 87);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 5;
            // 
            // button1
            // 
            button1.Location = new Point(429, 134);
            button1.Name = "button1";
            button1.Size = new Size(157, 23);
            button1.TabIndex = 6;
            button1.Text = "Добавить новую группу";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(250, 134);
            button2.Name = "button2";
            button2.Size = new Size(157, 23);
            button2.TabIndex = 7;
            button2.Text = "Добавить новый номер";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(253, 69);
            label2.Name = "label2";
            label2.Size = new Size(101, 15);
            label2.TabIndex = 8;
            label2.Text = "Номер телефона";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(415, 69);
            label3.Name = "label3";
            label3.Size = new Size(75, 15);
            label3.TabIndex = 9;
            label3.Text = "Имя группы";
            // 
            // button3
            // 
            button3.Location = new Point(607, 134);
            button3.Name = "button3";
            button3.Size = new Size(99, 23);
            button3.TabIndex = 10;
            button3.Text = "Изменить";
            button3.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(634, 90);
            label4.Name = "label4";
            label4.Size = new Size(146, 15);
            label4.TabIndex = 11;
            label4.Text = "Кол-во подкомпонентов:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(776, 90);
            label5.Name = "label5";
            label5.Size = new Size(38, 15);
            label5.TabIndex = 12;
            label5.Text = "label5";
            // 
            // button4
            // 
            button4.Location = new Point(729, 134);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 13;
            button4.Text = "Удалить";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(839, 450);
            Controls.Add(button4);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(button3);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(textBox1);
            Controls.Add(numericUpDown1);
            Controls.Add(checkBox1);
            Controls.Add(label1);
            Controls.Add(ComponentView);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TreeView ComponentView;
        private Label label1;
        private CheckBox checkBox1;
        private NumericUpDown numericUpDown1;
        private TextBox textBox1;
        private Button button1;
        private Button button2;
        private Label label2;
        private Label label3;
        private Button button3;
        private Label label4;
        private Label label5;
        private Button button4;
    }
}
