namespace ATS_Interpreter
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
            dataGridView1 = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewButtonColumn();
            Column3 = new DataGridViewCheckBoxColumn();
            curRuleDisplay = new TextBox();
            dateTimePicker1 = new DateTimePicker();
            dateTimePicker2 = new DateTimePicker();
            areMinutesRequired = new CheckBox();
            andBtn = new Button();
            orBtn = new Button();
            dateTimeChosen = new DateTimePicker();
            callLengthChosen = new ComboBox();
            hasMinutes = new CheckBox();
            dateBtn = new Button();
            timeBtn = new Button();
            weekdayBtn = new Button();
            lengthBtn = new Button();
            payReqBtn = new Button();
            quit = new Button();
            lengthsListBox = new CheckedListBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            button10 = new Button();
            weekdayListBox = new CheckedListBox();
            backspace = new Button();
            button1 = new Button();
            dateTimePicker4 = new DateTimePicker();
            dateTimePicker5 = new DateTimePicker();
            label5 = new Label();
            label6 = new Label();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Column1, Column2, Column3 });
            dataGridView1.Location = new Point(13, 17);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Size = new Size(775, 218);
            dataGridView1.TabIndex = 0;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // Column1
            // 
            Column1.FillWeight = 80F;
            Column1.HeaderText = "Правило";
            Column1.Name = "Column1";
            // 
            // Column2
            // 
            Column2.FillWeight = 5F;
            Column2.HeaderText = "";
            Column2.Name = "Column2";
            Column2.Text = "X";
            Column2.UseColumnTextForButtonValue = true;
            // 
            // Column3
            // 
            Column3.FillWeight = 15F;
            Column3.HeaderText = "Использовать";
            Column3.Name = "Column3";
            // 
            // curRuleDisplay
            // 
            curRuleDisplay.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            curRuleDisplay.Location = new Point(13, 248);
            curRuleDisplay.Multiline = true;
            curRuleDisplay.Name = "curRuleDisplay";
            curRuleDisplay.ScrollBars = ScrollBars.Vertical;
            curRuleDisplay.Size = new Size(733, 45);
            curRuleDisplay.TabIndex = 1;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(13, 360);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(200, 23);
            dateTimePicker1.TabIndex = 2;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(13, 406);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(200, 23);
            dateTimePicker2.TabIndex = 3;
            // 
            // areMinutesRequired
            // 
            areMinutesRequired.AutoSize = true;
            areMinutesRequired.Location = new Point(645, 387);
            areMinutesRequired.Name = "areMinutesRequired";
            areMinutesRequired.Size = new Size(150, 19);
            areMinutesRequired.TabIndex = 7;
            areMinutesRequired.Text = "Звонок тратит минуты";
            areMinutesRequired.UseVisualStyleBackColor = true;
            // 
            // andBtn
            // 
            andBtn.Enabled = false;
            andBtn.Location = new Point(199, 307);
            andBtn.Name = "andBtn";
            andBtn.Size = new Size(99, 23);
            andBtn.TabIndex = 10;
            andBtn.Text = "И";
            andBtn.UseVisualStyleBackColor = true;
            andBtn.Click += andBtn_Click;
            // 
            // orBtn
            // 
            orBtn.Enabled = false;
            orBtn.Location = new Point(432, 307);
            orBtn.Name = "orBtn";
            orBtn.Size = new Size(99, 23);
            orBtn.TabIndex = 11;
            orBtn.Text = "ИЛИ";
            orBtn.UseVisualStyleBackColor = true;
            orBtn.Click += orBtn_Click;
            // 
            // dateTimeChosen
            // 
            dateTimeChosen.CustomFormat = "dd.MM.yyyy HH:mm ";
            dateTimeChosen.Format = DateTimePickerFormat.Custom;
            dateTimeChosen.Location = new Point(60, 16);
            dateTimeChosen.Name = "dateTimeChosen";
            dateTimeChosen.Size = new Size(200, 23);
            dateTimeChosen.TabIndex = 12;
            // 
            // callLengthChosen
            // 
            callLengthChosen.FormattingEnabled = true;
            callLengthChosen.Items.AddRange(new object[] { "Городской", "Региональный", "Межрегиональный", "Интернациональный" });
            callLengthChosen.Location = new Point(22, 56);
            callLengthChosen.Name = "callLengthChosen";
            callLengthChosen.Size = new Size(121, 23);
            callLengthChosen.TabIndex = 13;
            // 
            // hasMinutes
            // 
            hasMinutes.AutoSize = true;
            hasMinutes.Location = new Point(203, 58);
            hasMinutes.Name = "hasMinutes";
            hasMinutes.Size = new Size(95, 19);
            hasMinutes.TabIndex = 14;
            hasMinutes.Text = "Есть минуты";
            hasMinutes.UseVisualStyleBackColor = true;
            // 
            // dateBtn
            // 
            dateBtn.Location = new Point(56, 435);
            dateBtn.Name = "dateBtn";
            dateBtn.Size = new Size(119, 39);
            dateBtn.TabIndex = 20;
            dateBtn.Text = "Задать дни обслуживания";
            dateBtn.UseVisualStyleBackColor = true;
            dateBtn.Click += dateBtn_Click;
            // 
            // timeBtn
            // 
            timeBtn.Location = new Point(243, 433);
            timeBtn.Name = "timeBtn";
            timeBtn.Size = new Size(103, 41);
            timeBtn.TabIndex = 21;
            timeBtn.Text = "Задать время обслуживания";
            timeBtn.UseVisualStyleBackColor = true;
            timeBtn.Click += timeBtn_Click;
            // 
            // weekdayBtn
            // 
            weekdayBtn.Location = new Point(371, 433);
            weekdayBtn.Name = "weekdayBtn";
            weekdayBtn.Size = new Size(101, 41);
            weekdayBtn.TabIndex = 22;
            weekdayBtn.Text = "Задать дни обслуживания";
            weekdayBtn.UseVisualStyleBackColor = true;
            weekdayBtn.Click += weekdayBtn_Click;
            // 
            // lengthBtn
            // 
            lengthBtn.Location = new Point(509, 435);
            lengthBtn.Name = "lengthBtn";
            lengthBtn.Size = new Size(116, 39);
            lengthBtn.TabIndex = 23;
            lengthBtn.Text = "Задать дальность звонков";
            lengthBtn.UseVisualStyleBackColor = true;
            lengthBtn.Click += lengthBtn_Click;
            // 
            // payReqBtn
            // 
            payReqBtn.Location = new Point(681, 412);
            payReqBtn.Name = "payReqBtn";
            payReqBtn.Size = new Size(65, 43);
            payReqBtn.TabIndex = 24;
            payReqBtn.Text = "Задать условие";
            payReqBtn.UseVisualStyleBackColor = true;
            payReqBtn.Click += payReqBtn_Click;
            // 
            // quit
            // 
            quit.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 204);
            quit.Location = new Point(524, 496);
            quit.Name = "quit";
            quit.Size = new Size(264, 106);
            quit.TabIndex = 25;
            quit.Text = "Выйти";
            quit.UseVisualStyleBackColor = true;
            quit.Click += quit_Click;
            // 
            // lengthsListBox
            // 
            lengthsListBox.FormattingEnabled = true;
            lengthsListBox.Items.AddRange(new object[] { "Городской", "Региональный", "Межрегиональный", "Интернациональный" });
            lengthsListBox.Location = new Point(498, 354);
            lengthsListBox.Name = "lengthsListBox";
            lengthsListBox.Size = new Size(141, 76);
            lengthsListBox.TabIndex = 26;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 342);
            label1.Name = "label1";
            label1.Size = new Size(21, 15);
            label1.TabIndex = 27;
            label1.Text = "От";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 389);
            label2.Name = "label2";
            label2.Size = new Size(22, 15);
            label2.TabIndex = 28;
            label2.Text = "До";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(255, 342);
            label3.Name = "label3";
            label3.Size = new Size(21, 15);
            label3.TabIndex = 29;
            label3.Text = "От";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(254, 389);
            label4.Name = "label4";
            label4.Size = new Size(22, 15);
            label4.TabIndex = 30;
            label4.Text = "До";
            // 
            // button10
            // 
            button10.Location = new Point(347, 9);
            button10.Name = "button10";
            button10.Size = new Size(96, 40);
            button10.TabIndex = 31;
            button10.Text = "Проверить звонок";
            button10.UseVisualStyleBackColor = true;
            button10.Click += button10_Click;
            // 
            // weekdayListBox
            // 
            weekdayListBox.FormattingEnabled = true;
            weekdayListBox.Items.AddRange(new object[] { "Пн", "Вт", "Ср", "Чт", "Пт", "Сб", "Вс" });
            weekdayListBox.Location = new Point(381, 353);
            weekdayListBox.Name = "weekdayListBox";
            weekdayListBox.Size = new Size(75, 76);
            weekdayListBox.TabIndex = 32;
            // 
            // backspace
            // 
            backspace.BackColor = Color.Red;
            backspace.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 204);
            backspace.Location = new Point(747, 248);
            backspace.Name = "backspace";
            backspace.Size = new Size(41, 45);
            backspace.TabIndex = 33;
            backspace.Text = "<-";
            backspace.UseVisualStyleBackColor = false;
            backspace.Click += backspace_Click;
            // 
            // button1
            // 
            button1.Enabled = false;
            button1.Location = new Point(670, 299);
            button1.Name = "button1";
            button1.Size = new Size(118, 38);
            button1.TabIndex = 34;
            button1.Text = "Добавить правило в список";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // dateTimePicker4
            // 
            dateTimePicker4.CustomFormat = "HH:mm";
            dateTimePicker4.Format = DateTimePickerFormat.Custom;
            dateTimePicker4.Location = new Point(243, 360);
            dateTimePicker4.Name = "dateTimePicker4";
            dateTimePicker4.Size = new Size(104, 23);
            dateTimePicker4.TabIndex = 35;
            // 
            // dateTimePicker5
            // 
            dateTimePicker5.CustomFormat = "HH:mm";
            dateTimePicker5.Format = DateTimePickerFormat.Custom;
            dateTimePicker5.Location = new Point(243, 407);
            dateTimePicker5.Name = "dateTimePicker5";
            dateTimePicker5.Size = new Size(104, 23);
            dateTimePicker5.TabIndex = 36;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(376, 57);
            label5.Name = "label5";
            label5.Size = new Size(36, 15);
            label5.TabIndex = 37;
            label5.Text = "Итог:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(331, 80);
            label6.Name = "label6";
            label6.Size = new Size(38, 15);
            label6.TabIndex = 38;
            label6.Text = "label6";
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(button10);
            panel1.Controls.Add(hasMinutes);
            panel1.Controls.Add(callLengthChosen);
            panel1.Controls.Add(dateTimeChosen);
            panel1.Location = new Point(17, 493);
            panel1.Name = "panel1";
            panel1.Size = new Size(489, 109);
            panel1.TabIndex = 39;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 614);
            Controls.Add(panel1);
            Controls.Add(dateTimePicker5);
            Controls.Add(dateTimePicker4);
            Controls.Add(button1);
            Controls.Add(backspace);
            Controls.Add(weekdayListBox);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lengthsListBox);
            Controls.Add(quit);
            Controls.Add(payReqBtn);
            Controls.Add(lengthBtn);
            Controls.Add(weekdayBtn);
            Controls.Add(timeBtn);
            Controls.Add(dateBtn);
            Controls.Add(orBtn);
            Controls.Add(andBtn);
            Controls.Add(areMinutesRequired);
            Controls.Add(dateTimePicker2);
            Controls.Add(dateTimePicker1);
            Controls.Add(curRuleDisplay);
            Controls.Add(dataGridView1);
            Name = "Form1";
            Text = "Условия принятия звонков";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private TextBox curRuleDisplay;
        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePicker2;
        private CheckBox areMinutesRequired;
        private Button andBtn;
        private Button orBtn;
        private DateTimePicker dateTimeChosen;
        private ComboBox callLengthChosen;
        private CheckBox hasMinutes;
        private Button dateBtn;
        private Button timeBtn;
        private Button weekdayBtn;
        private Button lengthBtn;
        private Button payReqBtn;
        private Button quit;
        private CheckedListBox lengthsListBox;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Button button10;
        private CheckedListBox weekdayListBox;
        private Button backspace;
        private Button button1;
        private DateTimePicker dateTimePicker4;
        private DateTimePicker dateTimePicker5;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewButtonColumn Column2;
        private DataGridViewCheckBoxColumn Column3;
        private Label label5;
        private Label label6;
        private Panel panel1;
    }
}
