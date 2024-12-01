namespace ASKv2
{
    public partial class Form1 : Form
    {
        public static bool signal;
        public Form1()
        {
            InitializeComponent();
            this.FormClosed += new FormClosedEventHandler(Form1_FormClosed);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Logs.View = View.Details;
            Logs.Columns.Add("                                               Logs", 350);
            try
            {
                string prestigeLevel = Utils.InitializeLvLPrestige();
                textBox2.Text = prestigeLevel;
            }
            catch
            {}
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.Start(false);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            string inputText = textBox2.Text;
            if (int.TryParse(inputText, out int text))
            {
                Utils.updatePrestigeLvL(inputText);
                if (!signal)
                {
                    MessageBox.Show($"ѕрестиж персонажей успешно изменен на: {inputText}", "»зменение престижа");
                    Logs.Items.Add($"ѕрестиж персонажей успешно изменен на: {inputText}", "»зменение престижа");
                }
            }
            else
            {
                MessageBox.Show($"LVL может быть только числом!", "»зменение престижа", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Logs.Items.Add($"LVL может быть только числом!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.Start(true);
            string StartStopLog = Program.ReturnStartSignal(true);
            Logs.Items.Add(StartStopLog);
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            Program.Start(false);
            string StartStopLog = Program.ReturnStartSignal(false);
            Logs.Items.Add(StartStopLog);
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
