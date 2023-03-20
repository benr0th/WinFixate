using System.Diagnostics;
using System.Text;

namespace WinFocus
{
    partial class MainForm
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
            components = new System.ComponentModel.Container();
            comboBox1 = new ComboBox();
            focusText = new TextBox();
            menuStrip1 = new MenuStrip();
            helpMenu = new ToolStripMenuItem();
            aboutStrip = new ToolStripMenuItem();
            timer1 = new System.Windows.Forms.Timer(components);
            lbCounter = new Label();
            timeHours = new NumericUpDown();
            lbHowLong = new Label();
            timeMins = new NumericUpDown();
            timeSecs = new NumericUpDown();
            lbH = new Label();
            lbM = new Label();
            lbS = new Label();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)timeHours).BeginInit();
            ((System.ComponentModel.ISupportInitialize)timeMins).BeginInit();
            ((System.ComponentModel.ISupportInitialize)timeSecs).BeginInit();
            SuspendLayout();
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(12, 87);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(776, 23);
            comboBox1.TabIndex = 0;
            comboBox1.Text = "Choose a program to focus...";
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // focusText
            // 
            focusText.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            focusText.Location = new Point(12, 415);
            focusText.Name = "focusText";
            focusText.Size = new Size(776, 23);
            focusText.TabIndex = 1;
            focusText.Text = "Focusing: ";
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { helpMenu });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 24);
            menuStrip1.TabIndex = 2;
            menuStrip1.Text = "menuStrip1";
            // 
            // helpMenu
            // 
            helpMenu.DropDownItems.AddRange(new ToolStripItem[] { aboutStrip });
            helpMenu.Name = "helpMenu";
            helpMenu.Size = new Size(44, 20);
            helpMenu.Text = "Help";
            // 
            // aboutStrip
            // 
            aboutStrip.Name = "aboutStrip";
            aboutStrip.Size = new Size(107, 22);
            aboutStrip.Text = "About";
            aboutStrip.Click += aboutStrip_Click;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // lbCounter
            // 
            lbCounter.AutoSize = true;
            lbCounter.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbCounter.Location = new Point(12, 348);
            lbCounter.Name = "lbCounter";
            lbCounter.Size = new Size(269, 32);
            lbCounter.TabIndex = 3;
            lbCounter.Text = "Time remaining: 0:00:00";
            // 
            // timeHours
            // 
            timeHours.Location = new Point(12, 42);
            timeHours.Name = "timeHours";
            timeHours.Size = new Size(36, 23);
            timeHours.TabIndex = 4;
            // 
            // lbHowLong
            // 
            lbHowLong.AutoSize = true;
            lbHowLong.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            lbHowLong.Location = new Point(207, 45);
            lbHowLong.Name = "lbHowLong";
            lbHowLong.Size = new Size(238, 20);
            lbHowLong.TabIndex = 5;
            lbHowLong.Text = "How long would you like to focus?";
            // 
            // timeMins
            // 
            timeMins.Location = new Point(72, 42);
            timeMins.Name = "timeMins";
            timeMins.Size = new Size(36, 23);
            timeMins.TabIndex = 6;
            // 
            // timeSecs
            // 
            timeSecs.Location = new Point(135, 42);
            timeSecs.Name = "timeSecs";
            timeSecs.Size = new Size(36, 23);
            timeSecs.TabIndex = 7;
            // 
            // lbH
            // 
            lbH.AutoSize = true;
            lbH.Location = new Point(48, 46);
            lbH.Name = "lbH";
            lbH.Size = new Size(16, 15);
            lbH.TabIndex = 8;
            lbH.Text = "H";
            // 
            // lbM
            // 
            lbM.AutoSize = true;
            lbM.Location = new Point(107, 46);
            lbM.Name = "lbM";
            lbM.Size = new Size(18, 15);
            lbM.TabIndex = 9;
            lbM.Text = "M";
            // 
            // lbS
            // 
            lbS.AutoSize = true;
            lbS.Location = new Point(172, 46);
            lbS.Name = "lbS";
            lbS.Size = new Size(13, 15);
            lbS.TabIndex = 10;
            lbS.Text = "S";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lbS);
            Controls.Add(lbM);
            Controls.Add(lbH);
            Controls.Add(timeSecs);
            Controls.Add(timeMins);
            Controls.Add(lbHowLong);
            Controls.Add(timeHours);
            Controls.Add(lbCounter);
            Controls.Add(focusText);
            Controls.Add(comboBox1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "MainForm";
            Text = "WinFocus";
            Load += MainForm_Load;
            Resize += MainForm_Resize;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)timeHours).EndInit();
            ((System.ComponentModel.ISupportInitialize)timeMins).EndInit();
            ((System.ComponentModel.ISupportInitialize)timeSecs).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox comboBox1;
        private TextBox focusText;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem helpMenu;
        private ToolStripMenuItem aboutStrip;
        private System.Windows.Forms.Timer timer1;
        private Label lbCounter;
        private NumericUpDown timeHours;
        private Label lbHowLong;
        private NumericUpDown timeMins;
        private NumericUpDown timeSecs;
        private Label lbH;
        private Label lbM;
        private Label lbS;
    }
}