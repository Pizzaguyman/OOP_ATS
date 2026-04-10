namespace ATS_Composite
{
    public partial class Form1 : Form
    {
        PhoneGroup root = new PhoneGroup("АТС");
        ATSComponent chosen;
        public Form1()
        {
            InitializeComponent();
            root.Node = ComponentView.Nodes[0];
            chosen = root;
        }

        private void ComponentView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node == null) return;
            if (e.Node.Index == 0) return;
            chosen = root.FindChild(e.Node) ?? chosen;
            UpdateChosen();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            chosen.Add(new Phone((ulong)numericUpDown1.Value, checkBox1.Checked));
            UpdateChosen();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            chosen.Add(new PhoneGroup(textBox1.Text));
            UpdateChosen();
        }

        private void UpdateChosen()
        {
            if (chosen is PhoneGroup gr)
            {
                numericUpDown1.Value = numericUpDown1.Minimum;
                numericUpDown1.Enabled = false;
                textBox1.Enabled = true;
                textBox1.Text = gr.Name;
                int b = gr.GetBusiness();
                if (b == 0) checkBox1.CheckState = CheckState.Unchecked;
                if (b == 1) checkBox1.CheckState = CheckState.Indeterminate;
                if (b == 2) checkBox1.CheckState = CheckState.Checked;
                label5.Text = gr.ComponentCount.ToString();
            }
            if (chosen is Phone ph)
            {
                textBox1.Text = "";
                numericUpDown1.Enabled = true;
                textBox1.Enabled = false;
                numericUpDown1.Value = ph.Number;
                checkBox1.Checked = ph.Busy;
                label5.Text = "";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label5.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            chosen.Remove()
        }
    }
}
