namespace ATS_Composite
{
    public partial class Form1 : Form
    {
        PhoneGroup root = new PhoneGroup("АТС");
        ATSComponent chosen;
        public Form1()
        {
            InitializeComponent();
            ComponentView.Nodes.Add(root.Node);
            chosen = root;
        }

        private void ComponentView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node == null) return;
            if (e.Node == root.Node) chosen = root;
            chosen = root.FindChild(e.Node) ?? chosen;
            UpdateChosen();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Phone c = new Phone((ulong)numericUpDown1.Value, checkBox1.Checked);
                chosen.Add(c);
                UpdateChosen();
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                PhoneGroup c = new PhoneGroup(textBox1.Text);
                chosen.Add(c);
                UpdateChosen();
            }
            catch (NotImplementedException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void UpdateChosen()
        {
            if (chosen is PhoneGroup gr)
            {
                numericUpDown1.Value = numericUpDown1.Minimum;
                textBox1.Text = gr.Name;
                int b = gr.GetBusiness();
                if (b == 0) checkBox1.CheckState = CheckState.Unchecked;
                if (b == 1) checkBox1.CheckState = CheckState.Indeterminate;
                if (b == 2) checkBox1.CheckState = CheckState.Checked;
                label5.Text = gr.ComponentCount.ToString();
                button1.Enabled = true;
                button2.Enabled = true;
            }
            if (chosen is Phone ph)
            {
                textBox1.Text = "";
                numericUpDown1.Value = ph.Number;
                checkBox1.CheckState = ph.Busy?CheckState.Checked:CheckState.Unchecked;
                label5.Text = "";
                button1.Enabled = false;
                button2.Enabled = false;
            }
            if (chosen.Node == root.Node)
            {
                button3.Enabled = false;
                button4.Enabled = false;
            }
            else
            {
                button3.Enabled = true;
                button4.Enabled = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label5.Text = "";
            UpdateChosen();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            root.RemoveDeep(chosen);
            numericUpDown1.Value = numericUpDown1.Minimum;
            textBox1.Text = "";
            checkBox1.Checked = false;
            chosen = root;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (chosen is Phone ph)
            {
                ph.Busy = checkBox1.Checked;
                ph.Number = (ulong)numericUpDown1.Value;
            }
            if (chosen is PhoneGroup gr)
            {
                if (checkBox1.Checked) gr.Connect();
                else if (checkBox1.CheckState == CheckState.Unchecked) gr.Disconnect();
                gr.Name = textBox1.Text;
            }
            chosen.Node.Text = chosen.ToString();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
