using System.Runtime.InteropServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace OOP_ATS_att4
{
    public partial class Form1 : Form
    {
        private List<ATS> _ATS_list = new List<ATS>();
        private int _chosen_ATS = 0;
        public Form1()
        {
            InitializeComponent();
        }

        [DllImport("user32.dll", CharSet = CharSet.Unicode)]

        public static extern int MessageBox(IntPtr hWnd, String text, String caption, uint type);

        private void Form1_Load(object sender, EventArgs e)
        {
            ChosenInfo.Text = "";
            _ATS_list = new List<ATS>();
            userGrid.ColumnCount = 2;
            userGrid.RowHeadersVisible = false;
            userGrid.Columns[0].HeaderCell.Value = "ID пользователей";
            userGrid.Columns[1].HeaderCell.Value = "ID в 16-ричной системе";
            userGrid.Columns[0].Width = (userGrid.Width - 4) / 2;
            userGrid.Columns[1].Width = (userGrid.Width - 4) / 2;
            userGrid.Columns[0].ReadOnly = true;
            userGrid.Columns[1].ReadOnly = true;
            callsGrid.ColumnCount = 3;
            callsGrid.RowHeadersVisible = false;
            callsGrid.Columns[0].HeaderCell.Value = "ID пользователя 1";
            callsGrid.Columns[1].HeaderCell.Value = "ID пользователя 2";
            callsGrid.Columns[2].HeaderCell.Value = "Продолжительность звонка";
            callsGrid.Columns[0].ReadOnly = true;
            callsGrid.Columns[1].ReadOnly = true;
            callsGrid.Columns[2].ReadOnly = true;
            callsGrid.Columns.Add(new DataGridViewCheckBoxColumn());
            callsGrid.Columns[3].HeaderCell.Value = "Платный звонок";
            callsGrid.Columns[0].Width = (callsGrid.Width - 4 - callsGrid.Columns[3].Width) / 3;
            callsGrid.Columns[1].Width = (callsGrid.Width - 4 - callsGrid.Columns[3].Width) / 3;
            callsGrid.Columns[2].Width = (callsGrid.Width - 4 - callsGrid.Columns[3].Width) / 3;
            ATSGrid.ColumnCount = 5;
            ATSGrid.RowHeadersVisible = false;
            ATSGrid.Columns[0].HeaderCell.Value = "ID";
            ATSGrid.Columns[1].HeaderCell.Value = "Адрес";
            ATSGrid.Columns[2].HeaderCell.Value = "Абонентская плата";
            ATSGrid.Columns[3].HeaderCell.Value = "Количество пользователей";
            ATSGrid.Columns[4].HeaderCell.Value = "Количество совершенных звонков";
            ATSGrid.Columns[0].ReadOnly = true;
            ATSGrid.Columns[1].ReadOnly = true;
            ATSGrid.Columns[2].ReadOnly = true;
            ATSGrid.Columns[3].ReadOnly = true;
            ATSGrid.Columns[4].ReadOnly = true;
            ATSGrid.Columns[0].Width = (callsGrid.Width - 4) / 10;
            ATSGrid.Columns[1].Width = (callsGrid.Width - 4) * 2 / 10;
            ATSGrid.Columns[2].Width = (callsGrid.Width - 4) * 2 / 10;
            ATSGrid.Columns[3].Width = (callsGrid.Width - 4) * 2 / 10;
            ATSGrid.Columns[4].Width = (callsGrid.Width - 4) * 3 / 10;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int _id;
                int _userCount;
                ATS newATS;

                if (inputId.Text == "" && inputAddress.Text == "" && inputUsers.Text == "")
                    newATS = new ATS((double)inputPrice.Value);

                else if (inputId.Text == "" && inputAddress.Text == "" && Int32.TryParse(inputUsers.Text, out _userCount))
                {
                    if (_userCount < 0) throw new ArgumentException("Отрицательное количество пользователей недопустимо");
                    newATS = new ATS(-1, _userCount, (double)inputPrice.Value);
                }

                else if (inputId.Text == "" && Int32.TryParse(inputUsers.Text, out _userCount))
                {
                    if (inputAddress.Text.Length > 200) throw new ArgumentException("Адрес слишком длинный (больше 200 знаков)");
                    if (_userCount < 0) throw new ArgumentException("Отрицательное количество пользователей недопустимо");
                    newATS = new ATS(-1, inputAddress.Text, _userCount, (double)inputPrice.Value);
                }

                else if (inputId.Text == "" && inputUsers.Text == "")
                {
                    if (inputAddress.Text.Length > 200) throw new ArgumentException("Адрес слишком длинный (больше 200 знаков)");
                    newATS = new ATS(-1, inputAddress.Text, 0, (double)inputPrice.Value);
                }

                else if (Int32.TryParse(inputId.Text, out _id) && inputAddress.Text == "" && inputUsers.Text == "")
                {
                    if (_id < 0) throw new ArgumentException("Отрицательный ID недопустим");
                    newATS = new ATS(_id, (double)inputPrice.Value);
                }

                else if (Int32.TryParse(inputId.Text, out _id) && inputAddress.Text == "" && Int32.TryParse(inputUsers.Text, out _userCount))
                {
                    if (_id < 0) throw new ArgumentException("Отрицательный ID недопустим");
                    if (_userCount < 0) throw new ArgumentException("Отрицательное количество пользователей недопустимо");
                    newATS = new ATS(_id, _userCount, (double)inputPrice.Value);
                }

                else if (Int32.TryParse(inputId.Text, out _id) && inputUsers.Text == "")
                {
                    if (_id < 0) throw new ArgumentException("Отрицательный ID недопустим");
                    if (inputAddress.Text.Length > 200) throw new ArgumentException("Адрес слишком длинный (больше 200 знаков)");
                    newATS = new ATS(_id, inputAddress.Text, 0, (double)inputPrice.Value);
                }

                else if (Int32.TryParse(inputId.Text, out _id) && Int32.TryParse(inputUsers.Text, out _userCount))
                {
                    if (_id < 0) throw new ArgumentException("Отрицательный ID недопустим");
                    if (_userCount < 0) throw new ArgumentException("Отрицательное количество пользователей недопустимо");
                    if (inputAddress.Text.Length > 200) throw new ArgumentException("Адрес слишком длинный (больше 200 знаков)");
                    newATS = new ATS(_id, inputAddress.Text, _userCount, (double)inputPrice.Value);
                }

                else
                {
                    if (!Int32.TryParse(inputId.Text, out _id) && inputId.Text != "")
                    {
                        throw new InvalidInputException("Введите ID корректно");
                    }
                    if (!Int32.TryParse(inputUsers.Text, out _userCount) && inputUsers.Text != "")
                    {
                        throw new InvalidInputException("Введите количество пользователей корректно");
                    }
                    throw new InvalidInputException("Неправильный ввод");
                }

                if (_ATS_list.Count == 0)
                {
                    button2.Enabled = true;
                    button3.Enabled = true;
                    button4.Enabled = true;
                    button5.Enabled = true;
                    button7.Enabled = true;
                }

                _ATS_list.Add(newATS);
                ChosenInfo.Text = newATS.ToString();
                _chosen_ATS = _ATS_list.Count - 1;
                UpdateGrid(userGrid);
                UpdateGrid(callsGrid);
                UpdateGrid(ATSGrid);
                ATSCountLabel.Text = ATS.ObjectCount.ToString();

            }
            catch (Exception ex)
            {
                MessageBox(IntPtr.Zero, ex.Message, "Ошибка", 0);
            }

        }

        private void UpdateGrid(DataGridView dataGridView)
        {
            dataGridView.Rows.Clear();
            switch (dataGridView.Name)
            {
                case "userGrid":
                    foreach (int id in _ATS_list[_chosen_ATS].UserIdArray)
                    {
                        dataGridView.Rows.Add(id, id.ToString("X"));
                    }
                    break;

                case "callsGrid":
                    foreach (ATS.Call call in _ATS_list[_chosen_ATS].Calls)
                    {
                        dataGridView.Rows.Add(call.user1, call.user2, call.time, call.isPaid);
                    }
                    break;

                case "ATSGrid":
                    foreach (ATS ats in _ATS_list)
                    {
                        dataGridView.Rows.Add(ats.Id, ats.Address, ats.Price, ats.UserCount, ats.CallCount);
                    }
                    break;

                default:
                    break;
            }
            dataGridView.Refresh();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddNewUserID(object sender, EventArgs e)
        {
            try
            {
                int id;
                if (Int32.TryParse(textBox2.Text, out id))
                {
                    if (id < 0) throw new ArgumentException("Отрицательный ID пользователя недопустим");
                    _ATS_list[_chosen_ATS].AddUser(id);
                }
                else
                {
                    _ATS_list[_chosen_ATS].AddUser(textBox2.Text);
                }
                ChosenInfo.Text = _ATS_list[_chosen_ATS].ToString();
                UpdateGrid(userGrid);
                UpdateGrid(ATSGrid);
            }
            catch (Exception ex)
            {
                MessageBox(IntPtr.Zero, ex.Message, "Ошибка", 0);
            }
        }

        private void AddNewCall(object sender, EventArgs e)
        {
            try
            {
                _ATS_list[_chosen_ATS].NewCall((int)inputUserID1.Value, (int)inputUserID2.Value, (int)inputCallTime.Value, inputIsPaid.Checked);
                ChosenInfo.Text = _ATS_list[_chosen_ATS].ToString();
                UpdateGrid(callsGrid);
                UpdateGrid(ATSGrid);
            }
            catch (Exception ex)
            {
                MessageBox(IntPtr.Zero, ex.Message, "Ошибка", 0);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (inputId.Text == "" || inputUsers.Text == "" || !Int32.TryParse(inputId.Text, out int _id) ||
                    !Int32.TryParse(inputUsers.Text, out int _userCount))
                    return;

                else if (ATS.IdList.Contains(_id) && _id != _ATS_list[_chosen_ATS].Id)
                    throw new ArgumentException("Этот ID уже занят");

                else
                    _ATS_list[_chosen_ATS].Change(_id, inputAddress.Text, _userCount, (double)inputPrice.Value);

                ChosenInfo.Text = _ATS_list[_chosen_ATS].ToString();
                UpdateGrid(userGrid);
                UpdateGrid(ATSGrid);
            }
            catch (Exception ex)
            {
                MessageBox(IntPtr.Zero, ex.Message, "Ошибка", 0);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (ATS.IdList.Contains((int)inputChosenATSID.Value))
                {
                    int chosenId = (int)inputChosenATSID.Value;
                    _chosen_ATS = _ATS_list.FindIndex(ATS => { return ATS.Id == chosenId; });
                    inputId.Text = _ATS_list[_chosen_ATS].Id.ToString();
                    inputAddress.Text = _ATS_list[_chosen_ATS].Address.ToString();
                    inputPrice.Value = (decimal)_ATS_list[_chosen_ATS].Price;
                    inputUsers.Text = _ATS_list[_chosen_ATS].UserCount.ToString();
                    UpdateGrid(userGrid);
                    UpdateGrid(callsGrid);
                    UpdateGrid(ATSGrid);
                    ChosenInfo.Text = _ATS_list[_chosen_ATS].ToString();
                }
                else
                {
                    throw new ArgumentException("АТС с таким ID не существует");
                }
            }
            catch (Exception ex)
            {
                MessageBox(IntPtr.Zero, ex.Message, "Ошибка", 0);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (ATS.IdList.Contains((int)inputChosenATSID.Value))
                {
                    int chosenId = (int)inputChosenATSID.Value;
                    _ATS_list.Find(ATS => { return ATS.Id == chosenId; }).RemoveId();
                    _ATS_list.Remove(_ATS_list.Find(ATS => { return ATS.Id == chosenId; }));
                    if (_ATS_list.Count > 0)
                    {
                        _chosen_ATS = _ATS_list.Count - 1;
                        inputId.Text = _ATS_list[_chosen_ATS].Id.ToString();
                        inputAddress.Text = _ATS_list[_chosen_ATS].Address.ToString();
                        inputPrice.Value = (decimal)_ATS_list[_chosen_ATS].Price;
                        inputUsers.Text = _ATS_list[_chosen_ATS].UserCount.ToString();
                        UpdateGrid(userGrid);
                        UpdateGrid(callsGrid);
                        UpdateGrid(ATSGrid);
                        ChosenInfo.Text = _ATS_list[_chosen_ATS].ToString();
                    }
                    else
                    {
                        inputId.Text = "";
                        inputAddress.Text = "";
                        inputPrice.Value = 0;
                        inputUsers.Text = "";
                        userGrid.Rows.Clear();
                        callsGrid.Rows.Clear();
                        ATSGrid.Rows.Clear();
                        button2.Enabled = false;
                        button3.Enabled = false;
                        button4.Enabled = false;
                        button5.Enabled = false;
                        button7.Enabled = false;
                        ChosenInfo.Text = "";
                    }
                    ATSCountLabel.Text = ATS.ObjectCount.ToString();
                }
                else
                {
                    throw new ArgumentException("АТС с таким ID не существует");
                }
            }
            catch (Exception ex)
            {
                MessageBox(IntPtr.Zero, ex.Message, "Ошибка", 0);
            }
        }

        private void userGrid_DoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                int val = (int)userGrid.Rows[e.RowIndex].Cells[0].Value;
                inputUserID2.Value = val;
            }
        }

        private void userGrid_Click(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex != -1)
            {
                int val = (int)userGrid.Rows[e.RowIndex].Cells[0].Value;
                inputUserID1.Value = val;
            }
        }
    }
}
