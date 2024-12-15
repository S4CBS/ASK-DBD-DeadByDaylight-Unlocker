using System.Diagnostics;
using System.Security.Principal;

namespace ASKv2
{
    public partial class Form1 : Form
    {
        public static bool signal;
        public static string Profile = string.Empty;
        public static bool LevelHack;
        public static bool CurrencyHack;
        private static bool updSignal;
        public static string platform = string.Empty;
        public static string playerName = "xxx";
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
            // �������� ������� ������
            comboBox1.Items.Add("SkinsWithItems");
            comboBox1.Items.Add("DlcOnly");
            comboBox1.Items.Add("SkinsPerks");
            comboBox1.Items.Add("SkinsONLY");
            comboBox1.SelectedItem = comboBoxLoad;
            label3.Text = $"�������: {comboBoxLoad}";
            // �������� ��������� ������
            platform = Utils.ReturnPlatform();
            comboBox2.Items.Add("EGS");
            comboBox2.Items.Add("Steam");
            comboBox2.Items.Add("MS");
            comboBox2.SelectedItem = platform;
            label4.Text = $"���������: {platform}";
            // �������� Nickname �������
            playerName = Utils.ReturnName();
            label5.Text = $"���: {playerName}";
            textBox1.Text = playerName;
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
                    MessageBox.Show($"������� ���������� ������� ������� ��: {inputText}", "��������� ��������");
                    Logs.Items.Add($"������� ���������� ������� ������� ��: {inputText}", "��������� ��������");
                }
            }
            else
            {
                MessageBox.Show($"LVL ����� ���� ������ ������!", "��������� ��������", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Logs.Items.Add($"LVL ����� ���� ������ ������!");
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
                Logs.Items.Add($"������ �������: {selectedText}");
                label3.Text = $"�������: {Path.GetFileNameWithoutExtension(selectedText)}";
                Utils.SetProfile(selectedText);
                MessageBox.Show($"������� {selectedText} ����������.", "����� �������");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int selectedIndex = comboBox2.SelectedIndex;

            if (selectedIndex != -1)
            {
                string selectedText = comboBox2.Items[selectedIndex].ToString();
                platform = selectedText;
                Logs.Items.Add($"������ �������: {selectedText}");
                label4.Text = $"�������: {Path.GetFileNameWithoutExtension(selectedText)}";
                Utils.SetPlatform(selectedText);
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                // ���������� Process.Start � UseShellExecute = true ��� �������� ������ � ��������
                Process.Start(new ProcessStartInfo
                {
                    FileName = "https://github.com/S4CBS/ASK-DBD-DeadByDaylight-Unlocker",
                    UseShellExecute = true  // �������� �������� ��� �������� URL � ��������
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show($"������ ��� ������� ������� ������: {ex.Message}");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            updSignal = !updSignal;
            if (updSignal)
            {
                Program.StartUpdate(updSignal);
            }
            else
            {
                Program.StartUpdate(updSignal);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            string text = $"���: {textBox1.Text}";
            label5.Text = text;
            playerName = textBox1.Text;
            Utils.SetName_(playerName);
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
