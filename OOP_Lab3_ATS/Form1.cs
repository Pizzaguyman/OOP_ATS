namespace OOP_Lab3_ATS
{
    public partial class Form1 : Form
    {
        TS? chosenTS;
        TSBuildingCompany builder = new MTSBuildingCompany();
        List<TS> stations = new List<TS>();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            builder = new MTSBuildingCompany();
            stations.Add(builder.BuildNew((int)inputID.Value, inputAddress.Text, (int)inputUserCount.Value, (double)inputPrice.Value));
            inputID.Value++;
            UpdateTSGrid();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateTSGrid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            builder = new ATSBuildingCompany();
            stations.Add(builder.BuildNew((int)inputID.Value, inputAddress.Text, (int)inputUserCount.Value, (double)inputPrice.Value));
            inputID.Value++;
            UpdateTSGrid();
        }

        private void UpdateTSGrid()
        {
            dataGridView1.RowCount = stations.Count + (stations.Count == 0 ? 1 : 0);
            for (int i = 0; i < stations.Count; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = stations[i].Id;
                dataGridView1.Rows[i].Cells[1].Value = stations[i] is ManualTS ? "Мануальная" : "Автоматическая";
                dataGridView1.Rows[i].Cells[2].Value = stations[i].Address;
                dataGridView1.Rows[i].Cells[3].Value = stations[i].UserCount;
                dataGridView1.Rows[i].Cells[4].Value = stations[i].Price;
                if (stations[i] is ManualTS mts)
                {
                    dataGridView1.Rows[i].Cells[5].Value = mts.Employees.Count;
                }
                else dataGridView1.Rows[i].Cells[5].Value = "-";
                if (stations[i] is AutomaticTS ats)
                {
                    dataGridView1.Rows[i].Cells[6].Value = ats.ComputerCount;
                }
                else dataGridView1.Rows[i].Cells[6].Value = "-";
                var btn = new DataGridViewButtonCell();
                btn.Value = "Изменить";
                dataGridView1.Rows[i].Cells[7] = btn;
                btn = new DataGridViewButtonCell();
                btn.Value = "Удалить";
                dataGridView1.Rows[i].Cells[8] = btn;
            }
            if (stations.Count == 0) dataGridView1.Rows.Clear();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || (string)(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value ?? "") == "") return;
            if (e.ColumnIndex == 7)
            {
                confirmChange.Enabled = true;
                chosenTS = stations[e.RowIndex];
                changeId.Value = chosenTS.Id;
                changeAddress.Text = chosenTS.Address;
                changeUserCount.Value = chosenTS.UserCount;
                changePrice.Value = (decimal)chosenTS.Price;
                if (chosenTS is AutomaticTS ats)
                {
                    changeComputers.Enabled = true;
                    changeComputers.Value = ats.ComputerCount;
                    dataGridView2.DataSource = null;
                    dataGridView2.Enabled = false;
                }
                else
                {
                    dataGridView2.Enabled = true;
                    UpdateEmpGrid();
                    button3.Enabled = true;
                    changeComputers.Enabled = false;
                }
            }
            if (e.ColumnIndex == 8)
            {
                var ts = stations[e.RowIndex];
                stations.RemoveAt(e.RowIndex);
                ts.RemoveId();
                UpdateTSGrid();
            }
        }

        private void UpdateEmpGrid()
        {
            if (chosenTS is ManualTS mts)
            {
                dataGridView2.RowCount = mts.Employees.Count + (mts.Employees.Count == 0 ? 1 : 0);
                for (int i = 0; i < mts.Employees.Count; i++)
                {
                    dataGridView2.Rows[i].Cells[0].Value = i + 1;
                    dataGridView2.Rows[i].Cells[1].Value = mts.Employees[i];
                    var btn = new DataGridViewButtonCell();
                    btn.Value = "X";
                    dataGridView2.Rows[i].Cells[2] = btn;
                }
            }
        }

        private void confirmChange_Click(object sender, EventArgs e)
        {
            chosenTS?.Change((int)changeId.Value, changeAddress.Text, (int)changeUserCount.Value, (double)changePrice.Value);
            if (chosenTS is AutomaticTS ats) ats.ComputerCount = (int)changeComputers.Value;
            confirmChange.Enabled = false;
            button3.Enabled = false;
            UpdateTSGrid();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (chosenTS is ManualTS mts)
            {
                if (inputName.Text != "") mts.AddEmployee(inputName.Text);
                else mts.AddEmployee();
            }
            UpdateEmpGrid();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (chosenTS is ManualTS mts)
            {
                if (e.ColumnIndex == 2)
                {
                    mts.RemoveEmployeeAt(e.RowIndex);
                    UpdateEmpGrid();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
