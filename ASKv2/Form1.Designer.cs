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
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            button5 = new Button();
            label3 = new Label();
            Logs = new ListView();
            button2 = new Button();
            button1 = new Button();
            tabPage2 = new TabPage();
            button7 = new Button();
            textBox1 = new TextBox();
            checkBox3 = new CheckBox();
            button6 = new Button();
            comboBox2 = new ComboBox();
            checkBox2 = new CheckBox();
            checkBox1 = new CheckBox();
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
            tabControl1.Location = new Point(0, 0);
            tabControl1.Multiline = true;
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(683, 358);
            tabControl1.TabIndex = 0;
            // 
            // UnlockerTabPage
            // 
            UnlockerTabPage.Controls.Add(label6);
            UnlockerTabPage.Controls.Add(label5);
            UnlockerTabPage.Controls.Add(label4);
            UnlockerTabPage.Controls.Add(button5);
            UnlockerTabPage.Controls.Add(label3);
            UnlockerTabPage.Controls.Add(Logs);
            UnlockerTabPage.Controls.Add(button2);
            UnlockerTabPage.Controls.Add(button1);
            UnlockerTabPage.ImeMode = ImeMode.NoControl;
            UnlockerTabPage.Location = new Point(4, 24);
            UnlockerTabPage.Name = "UnlockerTabPage";
            UnlockerTabPage.Padding = new Padding(3);
            UnlockerTabPage.Size = new Size(675, 330);
            UnlockerTabPage.TabIndex = 0;
            UnlockerTabPage.Text = "Unlocker";
            UnlockerTabPage.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BorderStyle = BorderStyle.FixedSingle;
            label6.Location = new Point(181, 17);
            label6.Name = "label6";
            label6.Size = new Size(87, 17);
            label6.TabIndex = 7;
            label6.Text = "Очередь: xxx";
            label6.Click += label6_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BorderStyle = BorderStyle.FixedSingle;
            label5.Location = new Point(8, 236);
            label5.Name = "label5";
            label5.Size = new Size(42, 17);
            label5.TabIndex = 6;
            label5.Text = "label5";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BorderStyle = BorderStyle.FixedSingle;
            label4.Location = new Point(8, 266);
            label4.Name = "label4";
            label4.Size = new Size(42, 17);
            label4.TabIndex = 5;
            label4.Text = "label4";
            // 
            // button5
            // 
            button5.Location = new Point(6, 183);
            button5.Name = "button5";
            button5.Size = new Size(169, 39);
            button5.TabIndex = 4;
            button5.Text = "Автообновление\r\nФайла со скинами";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label3.AutoSize = true;
            label3.BorderStyle = BorderStyle.FixedSingle;
            label3.Location = new Point(6, 302);
            label3.Name = "label3";
            label3.Size = new Size(42, 17);
            label3.TabIndex = 3;
            label3.Text = "label3";
            label3.Click += label3_Click;
            // 
            // Logs
            // 
            Logs.Anchor = AnchorStyles.Right;
            Logs.Location = new Point(338, 6);
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
            tabPage2.Controls.Add(button7);
            tabPage2.Controls.Add(textBox1);
            tabPage2.Controls.Add(checkBox3);
            tabPage2.Controls.Add(button6);
            tabPage2.Controls.Add(comboBox2);
            tabPage2.Controls.Add(checkBox2);
            tabPage2.Controls.Add(checkBox1);
            tabPage2.Controls.Add(label2);
            tabPage2.Controls.Add(label1);
            tabPage2.Controls.Add(button4);
            tabPage2.Controls.Add(comboBox1);
            tabPage2.Controls.Add(textBox2);
            tabPage2.Controls.Add(button3);
            tabPage2.Location = new Point(4, 24);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(675, 330);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Config";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // button7
            // 
            button7.Location = new Point(21, 256);
            button7.Name = "button7";
            button7.Size = new Size(114, 23);
            button7.TabIndex = 13;
            button7.Text = "Подменить ник";
            button7.UseVisualStyleBackColor = true;
            button7.Click += button7_Click;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(16, 212);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(119, 23);
            textBox1.TabIndex = 12;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Location = new Point(141, 206);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(117, 34);
            checkBox3.TabIndex = 11;
            checkBox3.Text = "Подменить ник\r\nOn/Off";
            checkBox3.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.Location = new Point(16, 162);
            button6.Name = "button6";
            button6.Size = new Size(135, 29);
            button6.TabIndex = 10;
            button6.Text = "Выбрать платформу";
            button6.UseVisualStyleBackColor = true;
            button6.Click += button6_Click;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(16, 119);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(121, 23);
            comboBox2.TabIndex = 9;
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(370, 123);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(127, 19);
            checkBox2.TabIndex = 8;
            checkBox2.Text = "Подмена валюты";
            checkBox2.UseVisualStyleBackColor = true;
            checkBox2.CheckedChanged += checkBox2_CheckedChanged;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(217, 123);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(122, 19);
            checkBox1.TabIndex = 7;
            checkBox1.Text = "Подмена уровня";
            checkBox1.UseVisualStyleBackColor = true;
            checkBox1.CheckedChanged += checkBox1_CheckedChanged;
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
            tabPage1.Size = new Size(675, 330);
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
            ClientSize = new Size(684, 361);
            Controls.Add(tabControl1);
            Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximumSize = new Size(700, 400);
            MinimumSize = new Size(700, 400);
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
        private Button button5;
        private Button button6;
        private ComboBox comboBox2;
        private Label label4;
        private Button button7;
        private TextBox textBox1;
        private Label label5;

        public static Label label6;
        public static CheckBox checkBox3;
        public static CheckBox checkBox1;
        public static ListView Logs;
        public static CheckBox checkBox2;
    }
}
