namespace OOP_Lab3_ATS
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
            inputID = new NumericUpDown();
            inputUserCount = new NumericUpDown();
            inputAddress = new TextBox();
            inputPrice = new NumericUpDown();
            button1 = new Button();
            button2 = new Button();
            dataGridView1 = new DataGridView();
            IDS = new DataGridViewTextBoxColumn();
            Type = new DataGridViewTextBoxColumn();
            Column1 = new DataGridViewTextBoxColumn();
            Column2 = new DataGridViewTextBoxColumn();
            Column5 = new DataGridViewTextBoxColumn();
            Column3 = new DataGridViewTextBoxColumn();
            Column4 = new DataGridViewTextBoxColumn();
            Edit = new DataGridViewButtonColumn();
            Delete = new DataGridViewButtonColumn();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            label8 = new Label();
            changePrice = new NumericUpDown();
            changeAddress = new TextBox();
            changeUserCount = new NumericUpDown();
            changeId = new NumericUpDown();
            label10 = new Label();
            changeComputers = new NumericUpDown();
            dataGridView2 = new DataGridView();
            Column6 = new DataGridViewTextBoxColumn();
            Column7 = new DataGridViewTextBoxColumn();
            Column8 = new DataGridViewButtonColumn();
            button3 = new Button();
            label9 = new Label();
            inputName = new TextBox();
            confirmChange = new Button();
            button4 = new Button();
            label11 = new Label();
            label12 = new Label();
            ((System.ComponentModel.ISupportInitialize)inputID).BeginInit();
            ((System.ComponentModel.ISupportInitialize)inputUserCount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)inputPrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)changePrice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)changeUserCount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)changeId).BeginInit();
            ((System.ComponentModel.ISupportInitialize)changeComputers).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            SuspendLayout();
            // 
            // inputID
            // 
            inputID.Location = new Point(20, 54);
            inputID.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            inputID.Name = "inputID";
            inputID.Size = new Size(160, 23);
            inputID.TabIndex = 0;
            // 
            // inputUserCount
            // 
            inputUserCount.Location = new Point(20, 142);
            inputUserCount.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            inputUserCount.Name = "inputUserCount";
            inputUserCount.Size = new Size(160, 23);
            inputUserCount.TabIndex = 1;
            // 
            // inputAddress
            // 
            inputAddress.Location = new Point(20, 98);
            inputAddress.MaxLength = 300;
            inputAddress.Name = "inputAddress";
            inputAddress.Size = new Size(158, 23);
            inputAddress.TabIndex = 2;
            // 
            // inputPrice
            // 
            inputPrice.DecimalPlaces = 2;
            inputPrice.Location = new Point(23, 186);
            inputPrice.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            inputPrice.Name = "inputPrice";
            inputPrice.Size = new Size(160, 23);
            inputPrice.TabIndex = 3;
            // 
            // button1
            // 
            button1.Location = new Point(12, 225);
            button1.Name = "button1";
            button1.Size = new Size(184, 23);
            button1.TabIndex = 4;
            button1.Text = "Создать ручную ТС";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(12, 254);
            button2.Name = "button2";
            button2.Size = new Size(184, 23);
            button2.TabIndex = 5;
            button2.Text = "Создать автоматическую ТС";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { IDS, Type, Column1, Column2, Column5, Column3, Column4, Edit, Delete });
            dataGridView1.Location = new Point(219, 51);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.Size = new Size(634, 429);
            dataGridView1.TabIndex = 6;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // IDS
            // 
            IDS.FillWeight = 60F;
            IDS.HeaderText = "ID";
            IDS.Name = "IDS";
            IDS.ReadOnly = true;
            // 
            // Type
            // 
            Type.HeaderText = "Тип";
            Type.Name = "Type";
            Type.ReadOnly = true;
            // 
            // Column1
            // 
            Column1.HeaderText = "Адрес";
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            // 
            // Column2
            // 
            Column2.HeaderText = "Кол-во пользователей";
            Column2.Name = "Column2";
            Column2.ReadOnly = true;
            // 
            // Column5
            // 
            Column5.HeaderText = "Цена";
            Column5.Name = "Column5";
            // 
            // Column3
            // 
            Column3.HeaderText = "Кол-во рабочих";
            Column3.Name = "Column3";
            // 
            // Column4
            // 
            Column4.HeaderText = "Кол-во компьютеров";
            Column4.Name = "Column4";
            Column4.ReadOnly = true;
            // 
            // Edit
            // 
            Edit.HeaderText = "";
            Edit.Name = "Edit";
            Edit.Resizable = DataGridViewTriState.True;
            Edit.SortMode = DataGridViewColumnSortMode.Automatic;
            Edit.Text = "Изменить";
            Edit.UseColumnTextForButtonValue = true;
            // 
            // Delete
            // 
            Delete.HeaderText = "";
            Delete.Name = "Delete";
            Delete.Resizable = DataGridViewTriState.True;
            Delete.SortMode = DataGridViewColumnSortMode.Automatic;
            Delete.Text = "Удалить";
            Delete.UseColumnTextForButtonValue = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(40, 36);
            label1.Name = "label1";
            label1.Size = new Size(18, 15);
            label1.TabIndex = 7;
            label1.Text = "ID";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(40, 80);
            label2.Name = "label2";
            label2.Size = new Size(40, 15);
            label2.TabIndex = 8;
            label2.Text = "Адрес";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(23, 124);
            label3.Name = "label3";
            label3.Size = new Size(157, 15);
            label3.TabIndex = 9;
            label3.Text = "Количество пользователей";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(40, 168);
            label4.Name = "label4";
            label4.Size = new Size(35, 15);
            label4.TabIndex = 10;
            label4.Text = "Цена";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(920, 168);
            label5.Name = "label5";
            label5.Size = new Size(35, 15);
            label5.TabIndex = 18;
            label5.Text = "Цена";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(903, 124);
            label6.Name = "label6";
            label6.Size = new Size(157, 15);
            label6.TabIndex = 17;
            label6.Text = "Количество пользователей";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(920, 80);
            label7.Name = "label7";
            label7.Size = new Size(40, 15);
            label7.TabIndex = 16;
            label7.Text = "Адрес";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(920, 36);
            label8.Name = "label8";
            label8.Size = new Size(18, 15);
            label8.TabIndex = 15;
            label8.Text = "ID";
            // 
            // changePrice
            // 
            changePrice.DecimalPlaces = 2;
            changePrice.Location = new Point(903, 186);
            changePrice.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            changePrice.Name = "changePrice";
            changePrice.Size = new Size(160, 23);
            changePrice.TabIndex = 14;
            // 
            // changeAddress
            // 
            changeAddress.Location = new Point(900, 98);
            changeAddress.MaxLength = 300;
            changeAddress.Name = "changeAddress";
            changeAddress.Size = new Size(158, 23);
            changeAddress.TabIndex = 13;
            // 
            // changeUserCount
            // 
            changeUserCount.Location = new Point(900, 142);
            changeUserCount.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            changeUserCount.Name = "changeUserCount";
            changeUserCount.Size = new Size(160, 23);
            changeUserCount.TabIndex = 12;
            // 
            // changeId
            // 
            changeId.Location = new Point(900, 54);
            changeId.Maximum = new decimal(new int[] { 10000000, 0, 0, 0 });
            changeId.Name = "changeId";
            changeId.Size = new Size(160, 23);
            changeId.TabIndex = 11;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(903, 405);
            label10.Name = "label10";
            label10.Size = new Size(151, 15);
            label10.TabIndex = 20;
            label10.Text = "Количество компьютеров";
            // 
            // changeComputers
            // 
            changeComputers.Enabled = false;
            changeComputers.Location = new Point(900, 423);
            changeComputers.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            changeComputers.Name = "changeComputers";
            changeComputers.Size = new Size(163, 23);
            changeComputers.TabIndex = 22;
            // 
            // dataGridView2
            // 
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Columns.AddRange(new DataGridViewColumn[] { Column6, Column7, Column8 });
            dataGridView2.Enabled = false;
            dataGridView2.Location = new Point(881, 225);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersVisible = false;
            dataGridView2.Size = new Size(198, 128);
            dataGridView2.TabIndex = 23;
            dataGridView2.CellContentClick += dataGridView2_CellContentClick;
            // 
            // Column6
            // 
            Column6.FillWeight = 40F;
            Column6.HeaderText = "N";
            Column6.Name = "Column6";
            Column6.ReadOnly = true;
            Column6.Resizable = DataGridViewTriState.False;
            // 
            // Column7
            // 
            Column7.HeaderText = "Имя";
            Column7.Name = "Column7";
            Column7.ReadOnly = true;
            Column7.Resizable = DataGridViewTriState.False;
            // 
            // Column8
            // 
            Column8.FillWeight = 40F;
            Column8.HeaderText = "";
            Column8.Name = "Column8";
            Column8.Resizable = DataGridViewTriState.False;
            Column8.SortMode = DataGridViewColumnSortMode.Automatic;
            Column8.Text = "X";
            Column8.UseColumnTextForButtonValue = true;
            // 
            // button3
            // 
            button3.Enabled = false;
            button3.Location = new Point(1017, 359);
            button3.Name = "button3";
            button3.Size = new Size(75, 41);
            button3.TabIndex = 24;
            button3.Text = "Добавить";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(888, 359);
            label9.Name = "label9";
            label9.Size = new Size(67, 15);
            label9.TabIndex = 25;
            label9.Text = "Новое имя";
            // 
            // inputName
            // 
            inputName.Location = new Point(881, 377);
            inputName.MaxLength = 30;
            inputName.Name = "inputName";
            inputName.Size = new Size(117, 23);
            inputName.TabIndex = 26;
            // 
            // confirmChange
            // 
            confirmChange.AutoSize = true;
            confirmChange.Enabled = false;
            confirmChange.Location = new Point(920, 455);
            confirmChange.Name = "confirmChange";
            confirmChange.Size = new Size(122, 25);
            confirmChange.TabIndex = 27;
            confirmChange.Text = "Подтвердить";
            confirmChange.UseVisualStyleBackColor = true;
            confirmChange.Click += confirmChange_Click;
            // 
            // button4
            // 
            button4.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 204);
            button4.Location = new Point(12, 291);
            button4.Name = "button4";
            button4.Size = new Size(182, 196);
            button4.TabIndex = 28;
            button4.Text = "ВЫХОД";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(217, 15);
            label11.Name = "label11";
            label11.Size = new Size(606, 15);
            label11.TabIndex = 29;
            label11.Text = "Медведев М., Бакуткин А., 24ВП1, лаба 3. Ручные и автоматические телефонные станции. Фабричный метод";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(927, 13);
            label12.Name = "label12";
            label12.Size = new Size(106, 15);
            label12.TabIndex = 30;
            label12.Text = "Изменение полей";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1103, 492);
            Controls.Add(label12);
            Controls.Add(label11);
            Controls.Add(button4);
            Controls.Add(confirmChange);
            Controls.Add(inputName);
            Controls.Add(label9);
            Controls.Add(button3);
            Controls.Add(dataGridView2);
            Controls.Add(changeComputers);
            Controls.Add(label10);
            Controls.Add(label5);
            Controls.Add(label6);
            Controls.Add(label7);
            Controls.Add(label8);
            Controls.Add(changePrice);
            Controls.Add(changeAddress);
            Controls.Add(changeUserCount);
            Controls.Add(changeId);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(inputPrice);
            Controls.Add(inputAddress);
            Controls.Add(inputUserCount);
            Controls.Add(inputID);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "Form1";
            Text = "Фабрика АТС";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)inputID).EndInit();
            ((System.ComponentModel.ISupportInitialize)inputUserCount).EndInit();
            ((System.ComponentModel.ISupportInitialize)inputPrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)changePrice).EndInit();
            ((System.ComponentModel.ISupportInitialize)changeUserCount).EndInit();
            ((System.ComponentModel.ISupportInitialize)changeId).EndInit();
            ((System.ComponentModel.ISupportInitialize)changeComputers).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NumericUpDown inputID;
        private NumericUpDown inputUserCount;
        private TextBox inputAddress;
        private NumericUpDown inputPrice;
        private Button button1;
        private Button button2;
        private DataGridView dataGridView1;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label label8;
        private NumericUpDown changePrice;
        private TextBox changeAddress;
        private NumericUpDown changeUserCount;
        private NumericUpDown changeId;
        private Label label10;
        private NumericUpDown changeComputers;
        private DataGridView dataGridView2;
        private DataGridViewTextBoxColumn IDS;
        private DataGridViewTextBoxColumn Type;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewButtonColumn Edit;
        private DataGridViewButtonColumn Delete;
        private Button button3;
        private Label label9;
        private TextBox inputName;
        private Button confirmChange;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn Column7;
        private DataGridViewButtonColumn Column8;
        private Button button4;
        private Label label11;
        private Label label12;
    }
}
