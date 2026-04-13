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
            label6 = new Label();
            button5 = new Button();
            label7 = new Label();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // ComponentView
            // 
            ComponentView.Location = new Point(11, 36);
            ComponentView.Name = "ComponentView";
            ComponentView.Size = new Size(303, 227);
            ComponentView.TabIndex = 1;
            ComponentView.NodeMouseClick += ComponentView_NodeMouseClick;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 204);
            label1.Location = new Point(426, 36);
            label1.Name = "label1";
            label1.Size = new Size(160, 20);
            label1.TabIndex = 2;
            label1.Text = "Выбранный элемент";
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Checked = true;
            checkBox1.CheckState = CheckState.Indeterminate;
            checkBox1.Location = new Point(623, 120);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(57, 19);
            checkBox1.TabIndex = 3;
            checkBox1.Text = "Занят";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // numericUpDown1
            // 
            numericUpDown1.Location = new Point(338, 118);
            numericUpDown1.Maximum = new decimal(new int[] { 1316134911, 2328, 0, 0 });
            numericUpDown1.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(120, 23);
            numericUpDown1.TabIndex = 4;
            numericUpDown1.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // textBox1
            // 
            textBox1.Location = new Point(500, 118);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(100, 23);
            textBox1.TabIndex = 5;
            // 
            // button1
            // 
            button1.Location = new Point(514, 165);
            button1.Name = "button1";
            button1.Size = new Size(157, 23);
            button1.TabIndex = 6;
            button1.Text = "Добавить новую группу";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(335, 165);
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
            label2.Location = new Point(338, 100);
            label2.Name = "label2";
            label2.Size = new Size(101, 15);
            label2.TabIndex = 8;
            label2.Text = "Номер телефона";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(500, 100);
            label3.Name = "label3";
            label3.Size = new Size(75, 15);
            label3.TabIndex = 9;
            label3.Text = "Имя группы";
            // 
            // button3
            // 
            button3.Location = new Point(335, 202);
            button3.Name = "button3";
            button3.Size = new Size(157, 23);
            button3.TabIndex = 10;
            button3.Text = "Изменить";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(429, 67);
            label4.Name = "label4";
            label4.Size = new Size(146, 15);
            label4.TabIndex = 11;
            label4.Text = "Кол-во подкомпонентов:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(571, 67);
            label5.Name = "label5";
            label5.Size = new Size(38, 15);
            label5.TabIndex = 12;
            label5.Text = "label5";
            // 
            // button4
            // 
            button4.Location = new Point(514, 202);
            button4.Name = "button4";
            button4.Size = new Size(157, 23);
            button4.TabIndex = 13;
            button4.Text = "Удалить";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(371, 9);
            label6.Name = "label6";
            label6.Size = new Size(268, 15);
            label6.TabIndex = 14;
            label6.Text = "Медведев М, Бакуткин А, лаба 4, компоновщик";
            // 
            // button5
            // 
            button5.Location = new Point(335, 240);
            button5.Name = "button5";
            button5.Size = new Size(338, 23);
            button5.TabIndex = 15;
            button5.Text = "Выход";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(28, 12);
            label7.Name = "label7";
            label7.Size = new Size(194, 15);
            label7.TabIndex = 16;
            label7.Text = "Нажмите чтобы выбрать элемент";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(686, 273);
            Controls.Add(label7);
            Controls.Add(button5);
            Controls.Add(label6);
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
            Text = "Работа с телефонами АТС";
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
        private Label label6;
        private Button button5;
        private Label label7;
    }
}
