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
            public ATSEventArgs(int? id, string? address, int userCount, double price)
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
            public Queue<OOP_ATS_att4.Form1.ATS> Container { get; }
            public ATSContainer()
            {
                Container = new Queue<OOP_ATS_att4.Form1.ATS>();
            }
            public IEnumerator GetEnumerator() => Container.GetEnumerator();
            public void Add(int? id, string? address, int? userCount, double? price)
            {
                StartAdd?.Invoke(this, new ATSEventArgs());
                Container.Enqueue(new OOP_ATS_att4.Form1.ATS(id ?? -1, address ?? "", userCount ?? 0, price ?? 0.00));
                Added?.Invoke(this, new ATSEventArgs());
            }
            public void Remove()
            {
                StartRemove?.Invoke(this, new ATSEventArgs());
                Container.Dequeue();
                Removed?.Invoke(this, new ATSEventArgs());
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
            c.Added += (ATSContainer sender, ATSEventArgs e)=> {
                label2.Text = sender.Container.Count.ToString();
            };
            c.Removed += (ATSContainer sender, ATSEventArgs e) => { label2.Text = sender.Container.Count.ToString(); };
        }
    }
}
