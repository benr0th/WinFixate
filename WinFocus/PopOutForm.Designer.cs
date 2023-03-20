namespace WinFocus
{
    partial class PopOutForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lbTime = new Label();
            stopButton = new Button();
            SuspendLayout();
            // 
            // lbTime
            // 
            lbTime.AutoSize = true;
            lbTime.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            lbTime.ImageAlign = ContentAlignment.MiddleLeft;
            lbTime.Location = new Point(12, 18);
            lbTime.Name = "lbTime";
            lbTime.Size = new Size(78, 32);
            lbTime.TabIndex = 0;
            lbTime.Text = "label1";
            lbTime.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // stopButton
            // 
            stopButton.Location = new Point(112, 104);
            stopButton.Name = "stopButton";
            stopButton.Size = new Size(75, 23);
            stopButton.TabIndex = 1;
            stopButton.Text = "STOP";
            stopButton.UseVisualStyleBackColor = true;
            stopButton.Click += stopButton_Click;
            // 
            // PopOutForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(308, 139);
            ControlBox = false;
            Controls.Add(stopButton);
            Controls.Add(lbTime);
            MaximizeBox = false;
            Name = "PopOutForm";
            Text = "Timer";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lbTime;
        private Button stopButton;
    }
}