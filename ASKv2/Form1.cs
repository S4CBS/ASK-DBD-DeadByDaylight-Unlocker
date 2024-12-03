namespace ASKv2
{
    public partial class Form1 : Form
    {
        public static bool signal;
        public static string Profile = string.Empty;
        public Form1()
        {
            InitializeComponent();
            this.FormClosed += new FormClosedEventHandler(Form1_FormClosed);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Program.CreateDirsAndFiles();
            string comboBoxLoad = Utils.ReturnProfile();
            comboBoxLoad = Path.GetFileNameWithoutExtension(comboBoxLoad);
            Logs.View = View.Details;
            Logs.Columns.Add("                                               Logs", 350);
            try
            {
                string prestigeLevel = Utils.InitializeLvLPrestige();
                textBox2.Text = prestigeLevel;
            }
            catch
            { }
            comboBox1.Items.Add("SkinsWithItems");
            comboBox1.Items.Add("DlcOnly");
            comboBox1.Items.Add("SkinsPerks");
            comboBox1.Items.Add("SkinsONLY");
            comboBox1.SelectedItem = comboBoxLoad;
            label3.Text = $"Профиль: {comboBoxLoad}";
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
                    MessageBox.Show($"Престиж персонажей успешно изменен на: {inputText}", "Изменение престижа");
                    Logs.Items.Add($"Престиж персонажей успешно изменен на: {inputText}", "Изменение престижа");
                }
            }
            else
            {
                MessageBox.Show($"LVL может быть только числом!", "Изменение престижа", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Logs.Items.Add($"LVL может быть только числом!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Profile = Utils.ReturnProfile();
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

        private void Logs_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            int selectedIndex = comboBox1.SelectedIndex;

            if (selectedIndex != -1)
            {
                string selectedText = comboBox1.Items[selectedIndex].ToString() + ".json";
                Logs.Items.Add($"Выбран профиль: {selectedText}");
                label3.Text = $"Профиль: {Path.GetFileNameWithoutExtension(selectedText)}";
                Utils.SetProfile(selectedText);
                MessageBox.Show($"Профиль {selectedText} установлен.", "Выбор профиля");
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
