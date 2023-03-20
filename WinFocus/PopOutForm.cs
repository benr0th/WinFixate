using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFocus
{
    public partial class PopOutForm : Form
    {
        MainForm mainForm;

        public PopOutForm(MainForm mainForm)
        {
            this.mainForm = mainForm;
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
            TopMost = true;
            ShowInTaskbar = false;
        }

        public Label PopTimeLabel
        {
            get { return lbTime; }
        }

        private void stopButton_Click(object sender, EventArgs e)
        {
            mainForm.StopTimer();
            mainForm.Seconds = 0;
        }
    }
}
