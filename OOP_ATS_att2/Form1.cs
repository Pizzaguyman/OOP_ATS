using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace OOP_ATS_att2
{
    public partial class Form1 : Form
    {
        public class ATS
        {
            public struct Call
            {
                public int user1;
                public int user2;
                public int time;
                public bool isPaid;
                public Call(int user1, int user2, int time, bool isPaid)
                {
                    this.user1 = user1;
                    this.user2 = user2;
                    this.time = time;
                    this.isPaid = isPaid;
                }
            }
            static public int ObjectCount { get; private set; } = 0;
            static public HashSet<int> IdSet { get; private set; }
            public int Id { get; set; }
            public string Address { get; set; }
            public int UserCount { get; set; }
            public int[] UserIdArray { get; set; }
            public double Price { get; set; }
            public int CallCount { get; set; }
            public Call[] Calls { get; set; }
            public ATS(int id, string address, int[] userIdArray, double price, Call[] calls)
            {
                if (ObjectCount == 0)
                {
                    IdSet = new HashSet<int>();
                }
                if (id == -1)
                {
                    for (int i = 0; ; i++)
                    {
                        if (IdSet.Add(i))
                        {
                            id = i;
                            break;
                        }
                    }
                }
                else
                {
                    if (!IdSet.Add(id)) throw new ArgumentException("Id taken");
                }
                Id = id;
                Address = address;
                UserIdArray = userIdArray;
                UserCount = userIdArray.Length;
                Price = price;
                Calls = calls;
                CallCount = calls.Length;
            }
            public ATS(int id, string address, int userCount, double price)
            {
                //try
                //{
                //id, address
                if (ObjectCount == 0)
                {
                    IdSet = new HashSet<int>();
                }
                if (id == -1)
                {
                    for (int i = 0; ; i++)
                    {
                        if (IdSet.Add(i))
                        {
                            id = i;
                            break;
                        }
                    }
                }
                else
                {
                    if (!IdSet.Add(id)) throw new ArgumentException("Id taken");
                }
                Id = id;

                Address = address;
                //users
                UserCount = userCount;
                UserIdArray = new int[userCount];
                Random rand = new Random();
                for (int i = 0; i < userCount; i++)
                {
                    UserIdArray[i] = rand.Next(0x000000, 0xFFFFFF);
                }
                //calls, price
                Calls = new Call[CallCount];
                Price = price;
                ObjectCount = IdSet.Count;
                //}
                //catch (ArgumentException e)
                //{
                //    MessageBox.Show(null, e.Message, "Error", 0);
                //}
            }
            public ATS(int id, int userCount, double price) : this(id, "Г. Пенза, ул. Беляева, 41", userCount, price) { }
            public ATS(int id, double price) : this(id, "Г. Пенза, ул. Беляева, 41", 0, price) { }
            public ATS(double price) : this(-1, "Г. Пенза, ул. Беляева, 41", 0, price) { }
            public ATS() : this(0) { }

            public void AddUser(dynamic userId)
            {
                if (!(userId is int)) throw new UserIdArrayTypeMismatchException("Attempt to put string into an int array", userId);
                for (int i = 0; i < UserIdArray.Length; i++)
                {
                    if (UserIdArray[i] == userId) return;
                }
                UserCount++;
                int[] newArray = new int[UserCount];
                UserIdArray.CopyTo(newArray, 0);
                UserIdArray = newArray;
                UserIdArray[UserCount - 1] = userId;
            }
            public void NewCall(int user1, int user2, int time, bool isPaid)
            {
                if (user1 == user2)
                {
                    throw new SelfCallException("A user can not have a call with himself");
                }
                if (!Array.Exists(UserIdArray, id => id == user1) || !Array.Exists(UserIdArray, id => id == user2))
                {
                    throw new ArgumentException("A user with such ID does not exist");
                }
                CallCount++;
                Call[] newArray = new Call[CallCount];
                Calls.CopyTo(newArray, 0);
                Calls = newArray;
                Calls[CallCount - 1] = new Call(user1, user2, time, isPaid);
            }

            public override string ToString()
            {
                return $"ID АТС: {Id}. Адрес АТС: {Address}. Абонентская плата: {Price}. " +
                    $"Количество пользователей: {UserCount}. Количество совершенных звонков: {CallCount}.";
            }

            public void Change(int id, string address, int userCount, double price)
            {
                IdSet.Remove(Id);
                IdSet.Add(id);
                Id = id;
                Address = address;
                UserCount = userCount;
                Price = price;
            }

            public void Remove()
            {
                IdSet.Remove(Id);
                ObjectCount--;
            }

            ~ATS()
            {
                Remove();
            }
        }
        public class UserIdArrayTypeMismatchException : ArrayTypeMismatchException
        {
            private dynamic _id;
            public UserIdArrayTypeMismatchException(string message, int id) : base(message) { _id = id; }
        }
        public class InvalidInputException : Exception
        {
            public InvalidInputException(string message) : base(message) { }
        }
        public class SelfCallException : Exception
        {
            public SelfCallException(string message) : base(message) { }
        }


        private List<ATS> _ATS_list;
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
            ATSGrid.Columns[1].Width = (callsGrid.Width - 4) / 10;
            ATSGrid.Columns[2].Width = (callsGrid.Width - 4) * 2 / 10;
            ATSGrid.Columns[3].Width = (callsGrid.Width - 4) * 3 / 10;
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
                    newATS = new ATS(-1, _userCount, (double)inputPrice.Value);

                else if (inputId.Text == "" && Int32.TryParse(inputUsers.Text, out _userCount))
                {
                    if (inputAddress.Text.Length > 200) throw new ArgumentException("The address is too long. Please try again.");
                    newATS = new ATS(-1, inputAddress.Text, _userCount, (double)inputPrice.Value);
                }

                else if (inputId.Text == "")
                {
                    if (inputAddress.Text.Length > 200) throw new ArgumentException("The address is too long. Please try again.");
                    newATS = new ATS(-1, inputAddress.Text, 0, (double)inputPrice.Value);
                }

                else if (Int32.TryParse(inputId.Text, out _id) && inputAddress.Text == "" && inputUsers.Text == "")
                    newATS = new ATS(_id, (double)inputPrice.Value);

                else if (Int32.TryParse(inputId.Text, out _id) && inputAddress.Text == "" && Int32.TryParse(inputUsers.Text, out _userCount))
                    newATS = new ATS(_id, _userCount, (double)inputPrice.Value);

                else if (Int32.TryParse(inputId.Text, out _id) && inputUsers.Text == "")
                {
                    if (inputAddress.Text.Length > 200) throw new ArgumentException("The address is too long. Please try again.");
                    newATS = new ATS(_id, inputAddress.Text, 0, (double)inputPrice.Value);
                }

                else if (Int32.TryParse(inputId.Text, out _id) && Int32.TryParse(inputUsers.Text, out _userCount))
                {
                    if (inputAddress.Text.Length > 200) throw new ArgumentException("The address is too long. Please try again.");
                    newATS = new ATS(_id, inputAddress.Text, _userCount, (double)inputPrice.Value);
                }

                else
                    throw new InvalidInputException("Incorrect input data");

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
                MessageBox(IntPtr.Zero, ex.Message, "Error", 0);
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
                MessageBox(IntPtr.Zero, ex.Message, "Error", 0);
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
                MessageBox(IntPtr.Zero, ex.Message, "Error", 0);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int _id;
                int _userCount;

                if (inputId.Text == "" || inputAddress.Text == "" || inputUsers.Text == "" || !Int32.TryParse(inputId.Text, out _id) ||
                    !Int32.TryParse(inputUsers.Text, out _userCount))
                    return;

                else if (ATS.IdSet.Contains(_id) && _id != _ATS_list[_chosen_ATS].Id)
                    throw new ArgumentException("This ID is already taken");

                else
                    _ATS_list[_chosen_ATS].Change(_id, inputAddress.Text, _userCount, (double)inputPrice.Value);

                ChosenInfo.Text = _ATS_list[_chosen_ATS].ToString();
                UpdateGrid(userGrid);
                UpdateGrid(ATSGrid);
            }
            catch (Exception ex)
            {
                MessageBox(IntPtr.Zero, ex.Message, "Error", 0);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (ATS.IdSet.Contains((int)inputChosenATSID.Value))
                {
                    int chosenId = (int)inputChosenATSID.Value;
                    _chosen_ATS = _ATS_list.FindIndex(ATS => { return ATS.Id == _chosen_ATS; });
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
                    throw new ArgumentException("ATS with such ID does not exist");
                }
            }
            catch (Exception ex)
            {
                MessageBox(IntPtr.Zero, ex.Message, "Error", 0);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (ATS.IdSet.Contains((int)inputChosenATSID.Value))
                {
                    int chosenId = (int)inputChosenATSID.Value;
                    _ATS_list.Find(ATS => { return ATS.Id == chosenId; }).Remove();
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
                    throw new ArgumentException("ATS with such ID does not exist");
                }
            }
            catch (Exception ex)
            {
                MessageBox(IntPtr.Zero, ex.Message, "Error", 0);
            }
        }

        private void inputUserID1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void inputUserID2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void userGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void inputAddress_TextChanged(object sender, EventArgs e)
        {

        }

        private void inputChosenATSID_ValueChanged(object sender, EventArgs e)
        {

        }

        private void inputCallTime_ValueChanged(object sender, EventArgs e)
        {

        }

        private void inputId_TextChanged(object sender, EventArgs e)
        {

        }

        private void inputIsPaid_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void inputPrice_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void ATSGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void inputUsers_TextChanged(object sender, EventArgs e)
        {

        }

        private void ATSCountLabel_Click(object sender, EventArgs e)
        {

        }

        private void ChosenInfo_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
