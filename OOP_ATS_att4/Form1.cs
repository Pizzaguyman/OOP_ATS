using System.Runtime.InteropServices;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace OOP_ATS_att4
{
    public partial class Form1 : Form
    {
        public class ATS
        {
            private const string DEFAULT_ADDRESS = "Г. Пенза, ул. Беляева, 41";
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
            static public int ObjectCount { get; private set; }
            static public HashSet<int> IdSet { get; private set; } = new HashSet<int>();
            public int Id { get; set; }
            public string Address { get; set; }
            public int UserCount { get; set; }
            public int[] UserIdArray { get; set; }
            public double Price { get; set; }
            public int CallCount { get; set; }
            public Call[] Calls { get; set; }
            public ATS(int id, string address, int[] userIdArray, double price, Call[] calls)
            {
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
                    if (!IdSet.Add(id)) throw new ArgumentException("Этот ID занят");
                }
                Id = id;
                Address = address;
                UserIdArray = userIdArray;
                UserCount = userIdArray.Length;
                Price = price;
                Calls = calls;
                CallCount = calls.Length;
                ObjectCount = IdSet.Count;
            }
            public ATS(int id, string address, int userCount, double price)
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
                    if (!IdSet.Add(id)) throw new ArgumentException("Этот ID занят");
                }
                Id = id;

                Address = address;
                //users
                UserCount = userCount;
                UserIdArray = new int[userCount];
                Random rand = new Random();
                for (int i = 0; i < userCount; i++)
                {
                    int random = rand.Next(0x000000, 0xFFFFFF);
                    while (UserIdArray.IndexOf(random) != -1) random = rand.Next(0x000000, 0xFFFFFF);
                    UserIdArray[i] = random;
                }
                //calls, price
                Calls = new Call[CallCount];
                Price = price;
                ObjectCount = IdSet.Count;
            }
            public ATS(int id, int userCount, double price) : this(id, DEFAULT_ADDRESS, userCount, price) { }
            public ATS(int id, double price) : this(id, DEFAULT_ADDRESS, 0, price) { }
            public ATS(double price) : this(-1, DEFAULT_ADDRESS, 0, price) { }
            public ATS() : this(0) { }

            public void AddUser(dynamic userId)
            {
                if (!(userId is int)) throw new UserIdArrayTypeMismatchException("Попытка добавить строку в массив чисел", userId);
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
                    throw new SelfCallException("Пользователь не может звонить самому себе");
                }
                if (!Array.Exists(UserIdArray, id => id == user1) || !Array.Exists(UserIdArray, id => id == user2))
                {
                    throw new ArgumentException("Пользователя с таким ID не существует");
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
                int[] new_users = new int[userCount];
                new_users = UserIdArray[(UserCount - Math.Min(UserCount, userCount))..];
                Random rand = new Random();
                for (int i = UserCount; i < userCount; i++)
                {
                    int random = rand.Next(0x000000, 0xFFFFFF);
                    while (UserIdArray.IndexOf(random) != -1) random = rand.Next(0x000000, 0xFFFFFF);
                    new_users[i] = random;
                }
                UserIdArray = new_users;
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

            public static void Test_ResetStatic()
            {
                ObjectCount = 0;
                IdSet = new HashSet<int>();
            }
        }
        public class UserIdArrayTypeMismatchException : ArrayTypeMismatchException
        {
            private dynamic _id;
            public UserIdArrayTypeMismatchException(string message, dynamic id) : base(message) { _id = id; }
        }
        public class InvalidInputException : Exception
        {
            public InvalidInputException(string message) : base(message) { }
        }
        public class SelfCallException : Exception
        {
            public SelfCallException(string message) : base(message) { }
        }


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
                int _id;
                int _userCount;

                if (inputId.Text == "" || inputAddress.Text == "" || inputUsers.Text == "" || !Int32.TryParse(inputId.Text, out _id) ||
                    !Int32.TryParse(inputUsers.Text, out _userCount))
                    return;

                else if (ATS.IdSet.Contains(_id) && _id != _ATS_list[_chosen_ATS].Id)
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
                if (ATS.IdSet.Contains((int)inputChosenATSID.Value))
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
