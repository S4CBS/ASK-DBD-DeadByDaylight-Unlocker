﻿namespace ASKv2
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
            fileSystemWatcher1 = new FileSystemWatcher();
            label3 = new Label();
            tabControl1.SuspendLayout();
            UnlockerTabPage.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)fileSystemWatcher1).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(UnlockerTabPage);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(1, 0);
            tabControl1.Multiline = true;
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(526, 359);
            tabControl1.TabIndex = 0;
            // 
            // UnlockerTabPage
            // 
            UnlockerTabPage.Controls.Add(label3);
            UnlockerTabPage.Controls.Add(Logs);
            UnlockerTabPage.Controls.Add(button2);
            UnlockerTabPage.Controls.Add(button1);
            UnlockerTabPage.Location = new Point(4, 24);
            UnlockerTabPage.Name = "UnlockerTabPage";
            UnlockerTabPage.Padding = new Padding(3);
            UnlockerTabPage.Size = new Size(518, 331);
            UnlockerTabPage.TabIndex = 0;
            UnlockerTabPage.Text = "Unlocker";
            UnlockerTabPage.UseVisualStyleBackColor = true;
            // 
            // Logs
            // 
            Logs.Location = new Point(182, 6);
            Logs.Name = "Logs";
            Logs.Size = new Size(328, 307);
            Logs.TabIndex = 2;
            Logs.UseCompatibleStateImageBehavior = false;
            // 
            // button2
            // 
            button2.Location = new Point(7, 97);
            button2.Name = "button2";
            button2.Size = new Size(169, 85);
            button2.TabIndex = 1;
            button2.Text = "Stop Unlocker";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click_1;
            // 
            // button1
            // 
            button1.Location = new Point(7, 6);
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
            tabPage2.Size = new Size(518, 331);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Config";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(377, 11);
            label2.Name = "label2";
            label2.Size = new Size(122, 15);
            label2.TabIndex = 6;
            label2.Text = "Изменение профиля";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 18);
            label1.Name = "label1";
            label1.Size = new Size(125, 15);
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
            // fileSystemWatcher1
            // 
            fileSystemWatcher1.EnableRaisingEvents = true;
            fileSystemWatcher1.SynchronizingObject = this;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(16, 298);
            label3.Name = "label3";
            label3.Size = new Size(38, 15);
            label3.TabIndex = 3;
            label3.Text = "label3";
            label3.Click += label3_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(527, 359);
            Controls.Add(tabControl1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form1";
            Text = "|ASK  - DBDUnlocker by S4CBS|";
            Load += Form1_Load;
            tabControl1.ResumeLayout(false);
            UnlockerTabPage.ResumeLayout(false);
            UnlockerTabPage.PerformLayout();
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
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
        public static ListView Logs;
    }
}
