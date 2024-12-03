namespace ASKv2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            tabControl1 = new TabControl();
            UnlockerTabPage = new TabPage();
            label3 = new Label();
            Logs = new ListView();
            button2 = new Button();
            button1 = new Button();
            tabPage2 = new TabPage();
            label2 = new Label();
            label1 = new Label();
            button4 = new Button();
            comboBox1 = new ComboBox();
            textBox2 = new TextBox();
            button3 = new Button();
            tabPage1 = new TabPage();
            linkLabel1 = new LinkLabel();
            fileSystemWatcher1 = new FileSystemWatcher();
            tabControl1.SuspendLayout();
            UnlockerTabPage.SuspendLayout();
            tabPage2.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Right;
            tabControl1.Controls.Add(UnlockerTabPage);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Location = new Point(12, 12);
            tabControl1.Multiline = true;
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(560, 349);
            tabControl1.TabIndex = 0;
            // 
            // UnlockerTabPage
            // 
            UnlockerTabPage.Controls.Add(label3);
            UnlockerTabPage.Controls.Add(Logs);
            UnlockerTabPage.Controls.Add(button2);
            UnlockerTabPage.Controls.Add(button1);
            UnlockerTabPage.ImeMode = ImeMode.NoControl;
            UnlockerTabPage.Location = new Point(4, 24);
            UnlockerTabPage.Name = "UnlockerTabPage";
            UnlockerTabPage.Padding = new Padding(3);
            UnlockerTabPage.Size = new Size(552, 321);
            UnlockerTabPage.TabIndex = 0;
            UnlockerTabPage.Text = "Unlocker";
            UnlockerTabPage.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label3.AutoSize = true;
            label3.BorderStyle = BorderStyle.FixedSingle;
            label3.Location = new Point(6, 293);
            label3.Name = "label3";
            label3.Size = new Size(42, 17);
            label3.TabIndex = 3;
            label3.Text = "label3";
            label3.Click += label3_Click;
            // 
            // Logs
            // 
            Logs.Anchor = AnchorStyles.Right;
            Logs.Location = new Point(215, 1);
            Logs.Name = "Logs";
            Logs.Size = new Size(328, 307);
            Logs.TabIndex = 2;
            Logs.UseCompatibleStateImageBehavior = false;
            // 
            // button2
            // 
            button2.Location = new Point(6, 92);
            button2.Name = "button2";
            button2.Size = new Size(169, 85);
            button2.TabIndex = 1;
            button2.Text = "Stop Unlocker";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click_1;
            // 
            // button1
            // 
            button1.Location = new Point(6, 1);
            button1.Name = "button1";
            button1.Size = new Size(169, 85);
            button1.TabIndex = 0;
            button1.Text = "Start Unlocker";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(label2);
            tabPage2.Controls.Add(label1);
            tabPage2.Controls.Add(button4);
            tabPage2.Controls.Add(comboBox1);
            tabPage2.Controls.Add(textBox2);
            tabPage2.Controls.Add(button3);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(552, 321);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Config";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(377, 11);
            label2.Name = "label2";
            label2.Size = new Size(129, 15);
            label2.TabIndex = 6;
            label2.Text = "Изменение профиля";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 18);
            label1.Name = "label1";
            label1.Size = new Size(133, 15);
            label1.TabIndex = 5;
            label1.Text = "Изменение престижа";
            label1.Click += label1_Click;
            // 
            // button4
            // 
            button4.Location = new Point(376, 69);
            button4.Name = "button4";
            button4.Size = new Size(121, 23);
            button4.TabIndex = 4;
            button4.Text = "Сохранить";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(376, 36);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(121, 23);
            comboBox1.TabIndex = 3;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(16, 36);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(119, 23);
            textBox2.TabIndex = 2;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // button3
            // 
            button3.Location = new Point(16, 69);
            button3.Name = "button3";
            button3.Size = new Size(119, 23);
            button3.TabIndex = 0;
            button3.Text = "Сохранить левл престижа";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // tabPage1
            // 
            tabPage1.Controls.Add(linkLabel1);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(552, 321);
            tabPage1.TabIndex = 2;
            tabPage1.Text = "Info";
            tabPage1.UseVisualStyleBackColor = true;
            // 
            // linkLabel1
            // 
            linkLabel1.BorderStyle = BorderStyle.FixedSingle;
            linkLabel1.Location = new Point(205, 12);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(135, 70);
            linkLabel1.TabIndex = 0;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Github";
            linkLabel1.TextAlign = ContentAlignment.MiddleCenter;
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // fileSystemWatcher1
            // 
            fileSystemWatcher1.EnableRaisingEvents = true;
            fileSystemWatcher1.SynchronizingObject = this;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(584, 361);
            Controls.Add(tabControl1);
            Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximumSize = new Size(600, 400);
            MinimumSize = new Size(600, 400);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "|ASK  - DBDUnlocker by S4CBS|";
            Load += Form1_Load;
            tabControl1.ResumeLayout(false);
            UnlockerTabPage.ResumeLayout(false);
            UnlockerTabPage.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            tabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage UnlockerTabPage;
        private TabPage tabPage2;
        private Button button1;
        private Button button3;
        private FileSystemWatcher fileSystemWatcher1;
        private TextBox textBox2;
        private Button button2;
        private Button button4;
        private ComboBox comboBox1;
        private Label label1;
        private Label label2;
        private Label label3;
        private TabPage tabPage1;
        private LinkLabel linkLabel1;
        public static ListView Logs;
    }
}
