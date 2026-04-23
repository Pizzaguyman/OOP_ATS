namespace ATS_Interpreter
{
    public partial class Form1 : Form
    {
        bool IsInputtingExpression
        {
            get; set
            {
                andBtn.Enabled = value;
                orBtn.Enabled = value;
                dateBtn.Enabled = !value;
                weekdayBtn.Enabled = !value;
                timeBtn.Enabled = !value;
                lengthBtn.Enabled = !value;
                payReqBtn.Enabled = !value;
                field = value;
            }
        } = false;
        private List<string> expressions = [];
        private List<IRuleElement> rules = [];
        private List<IRuleElement> complexRules = [];
        public Form1()
        {
            MessageBox.Show("Лабораторная №5 по ООП. Медведев М, Бакуткин А. Использование интерпретатора в ПО \"АТС\".",
                "Введение в приложение",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            InitializeComponent();
        }

        private IRuleElement InterpretToInterpretator()
        {
            IRuleElement compRule = rules[0];
            for (int i = 0; i < expressions.Count; i++)
            {
                if (expressions[i] == " И ")
                {
                    compRule = new AndExpression(compRule, rules[i + 1]);
                }
                if (expressions[i] == " ИЛИ ")
                {
                    if (i + 1 < expressions.Count && expressions[i + 1] == " И ")
                    {
                        int j = i + 1;
                        IRuleElement temp = new AndExpression(rules[j], rules[++j]);
                        while (j < expressions.Count && expressions[j] == " И ")
                        {
                            temp = new AndExpression(temp, rules[++j]);
                        }
                        compRule = new OrExpression(compRule, temp);
                        i = j;
                    }
                    else
                    {
                        compRule = new OrExpression(compRule, rules[i + 1]);
                    }
                }
            }
            return compRule;
        }

        private void andBtn_Click(object sender, EventArgs e)
        {
            expressions.Add(" И ");
            IsInputtingExpression = false;
            button1.Enabled = false;
            UpdateRuleDisplay();
        }

        private void orBtn_Click(object sender, EventArgs e)
        {
            expressions.Add(" ИЛИ ");
            IsInputtingExpression = false;
            button1.Enabled = false;
            UpdateRuleDisplay();
        }

        private void dateBtn_Click(object sender, EventArgs e)
        {
            rules.Add(new CheckDateRange(dateTimePicker1.Value, dateTimePicker2.Value));
            IsInputtingExpression = true;
            button1.Enabled = true;
            UpdateRuleDisplay();
        }

        private void timeBtn_Click(object sender, EventArgs e)
        {
            rules.Add(new CheckTimeRange(dateTimePicker4.Value.TimeOfDay, dateTimePicker5.Value.TimeOfDay));
            IsInputtingExpression = true;
            button1.Enabled = true;
            UpdateRuleDisplay();
        }

        private void weekdayBtn_Click(object sender, EventArgs e)
        {
            if (weekdayListBox.CheckedItems.Count == 0)
            {
                MessageBox.Show("Пожалуйста выберите день недели");
                return;
            }
            rules.Add(new CheckWeekdays(weekdayListBox.CheckedIndices));
            IsInputtingExpression = true;
            button1.Enabled = true;
            UpdateRuleDisplay();
        }

        private void lengthBtn_Click(object sender, EventArgs e)
        {
            if (lengthsListBox.CheckedItems.Count == 0)
            {
                MessageBox.Show("Пожалуйста задайте дальность звонка");
                return;
            }
            rules.Add(new CheckConnectionLength(lengthsListBox.CheckedIndices));
            IsInputtingExpression = true;
            button1.Enabled = true;
            UpdateRuleDisplay();
        }

        private void payReqBtn_Click(object sender, EventArgs e)
        {
            rules.Add(new CheckHasMinutes(areMinutesRequired.Checked));
            IsInputtingExpression = true;
            button1.Enabled = true;
            UpdateRuleDisplay();
        }

        private void UpdateRuleDisplay()
        {
            curRuleDisplay.Text = "";
            if (rules.Count == 0) return;
            for (int i = 0; i < expressions.Count; i++)
            {
                curRuleDisplay.Text += rules[i].ToString();
                curRuleDisplay.Text += expressions[i];
            }
            if (IsInputtingExpression) curRuleDisplay.Text += rules[expressions.Count];
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label6.Text = "";
            callLengthChosen.SelectedIndex = 0;
        }

        private void quit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void backspace_Click(object sender, EventArgs e)
        {
            if (rules.Count == 0) return;
            if (IsInputtingExpression) rules.RemoveAt(rules.Count - 1);
            else expressions.RemoveAt(expressions.Count - 1);
            IsInputtingExpression = !IsInputtingExpression;
            UpdateRuleDisplay();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            complexRules.Add(InterpretToInterpretator());
            rules = [];
            expressions = [];
            button1.Enabled = false;
            IsInputtingExpression = false;
            GridUpdate();
            UpdateRuleDisplay();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 1)
            {
                complexRules.RemoveAt(e.RowIndex);
                GridUpdate();
            }
        }

        private void GridUpdate()
        {
            dataGridView1.Rows.Clear();
            foreach (var rule in complexRules)
            {
                dataGridView1.RowCount++;
                dataGridView1.Rows[complexRules.IndexOf(rule)].Cells[0].Value = rule.ToString();
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            bool isValid = false;
            CallContext context = new CallContext(dateTimeChosen.Value, callLengthChosen.SelectedIndex, hasMinutes.Checked);
            for(int i = 0; i<complexRules.Count; i++)
            {
                if (Convert.ToBoolean(dataGridView1.Rows[i].Cells[2].Value))
                {
                    isValid = isValid || complexRules[i].Interpret(context);
                }
            }
            label6.Text = isValid ? "Звонок соединен успешно" : "Звонок был отклонен";
        }
    }
}
