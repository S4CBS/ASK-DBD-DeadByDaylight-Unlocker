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
            tabControl1 = new TabControl();
            UnlockerTabPage = new TabPage();
            Logs = new ListView();
            button2 = new Button();
            button1 = new Button();
            tabPage2 = new TabPage();
            textBox2 = new TextBox();
            button3 = new Button();
            fileSystemWatcher1 = new FileSystemWatcher();
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
            // textBox2
            // 
            textBox2.Location = new Point(16, 23);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(119, 23);
            textBox2.TabIndex = 2;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // button3
            // 
            button3.Location = new Point(16, 52);
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
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(527, 359);
            Controls.Add(tabControl1);
            Name = "Form1";
            Text = "|ASK  - DBDUnlocker by S4CBS|";
            Load += Form1_Load;
            tabControl1.ResumeLayout(false);
            UnlockerTabPage.ResumeLayout(false);
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
        private ListView Logs;
    }
}
