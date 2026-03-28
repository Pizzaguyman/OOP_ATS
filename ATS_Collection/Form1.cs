using System.Collections;

namespace ATS_Collection
{
    public partial class Form1 : Form
    {
        public class ATSEventArgs
        {
            public int? Id { get; private set; }
            public string? Address { get; private set; }
            public int? UserCount { get; private set; }
            public double? Price { get; private set; }
            public ATSEventArgs() { }
            public ATSEventArgs(int? id, string? address, int? userCount, double? price)
            {
                Id = id;
                Address = address;
                UserCount = userCount;
                Price = price;
            }
        }
        public class ATSContainer
        {
            public delegate void ATSContainerHandler(ATSContainer sender, ATSEventArgs e);
            public event ATSContainerHandler? StartAdd;
            public event ATSContainerHandler? StartRemove;
            public event ATSContainerHandler? Added;
            public event ATSContainerHandler? Removed;
            public Queue<OOP_ATS_att4.ATS> Container { get; }
            public ATSContainer()
            {
                Container = new Queue<OOP_ATS_att4.ATS>();
            }
            public IEnumerator GetEnumerator() => Container.GetEnumerator();
            public void Add(int? id, string? address, int? userCount, double? price)
            {
                Container.Enqueue(new OOP_ATS_att4.ATS(id ?? -1, address ?? "", userCount ?? 0, price ?? 0.00));
                Added?.Invoke(this, new ATSEventArgs(id, address, userCount, price));
            }
            public void Remove()
            {
                if (Container.Count == 0) return;
                var delATS = Container.Dequeue();
                Removed?.Invoke(this, new ATSEventArgs(delATS.Id, delATS.Address, delATS.UserCount, delATS.Price));
                delATS.RemoveId();
            }
        }

        ATSContainer c = new();
        int Time;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label2.Text = "";
            label3.Text = "";
            c.Added += (ATSContainer sender, ATSEventArgs e) => { label3.Text = $"Последнее действие: в контейнер была добавлена новая АТС с ID {e.Id ?? OOP_ATS_att4.ATS.LatestId}"; };
            c.Removed += (ATSContainer sender, ATSEventArgs e) => { label3.Text = $"Последнее действие: из контейнера была удалена АТС с ID {e.Id}"; };
        }

        private void ShowQueueCount()
        {
            label2.Text = c.Container.Count.ToString();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            c.Add(null, null, null, null);
            ShowQueueCount();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            c.Remove();
            ShowQueueCount();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OOP_ATS_att4.ATS[] array = new OOP_ATS_att4.ATS[100000];
            int t1 = Environment.TickCount;
            for (int i = 0; i < 100000; i++)
                array[i] = new();
            listView1.Items[0].SubItems[1].Text = (Environment.TickCount - t1).ToString();
            int t2 = Environment.TickCount;
            for (int i = 0; i < 100000; i++)
                c.Add(null, null, null, null);
            listView1.Items[1].SubItems[1].Text = (Environment.TickCount - t2).ToString();
            OOP_ATS_att4.ATS temp;
            int t3 = Environment.TickCount;
            foreach (var item in array)
                temp = item;
            listView1.Items[0].SubItems[2].Text = (Environment.TickCount - t3).ToString();
            int t4 = Environment.TickCount;
            for (int i = 0; i < 100000; i++){
                c.Remove();
            }
            listView1.Items[1].SubItems[2].Text = (Environment.TickCount - t4).ToString();
            //int t5 = Environment.TickCount;

            //listView1.Items[0].SubItems[0].Text = (Environment.TickCount - t5).ToString();
            //int t6 = Environment.TickCount;

            //listView1.Items[0].SubItems[0].Text = (Environment.TickCount - t6).ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
