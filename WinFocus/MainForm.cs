using Microsoft.VisualBasic.Devices;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace WinFocus
{
    public partial class MainForm : Form
    {
        #region DLL imports
        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hWnd, System.Text.StringBuilder text, int count);

        [DllImport("user32.dll")]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.dll")]
        private static extern uint GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        [DllImport("user32.dll")]
        private static extern bool IsWindowVisible(IntPtr hwnd);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetForegroundWindow(IntPtr hWnd);

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool IsIconic(IntPtr hWnd);

        [DllImport("user32.dll")]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        static extern bool EnumWindows(EnumWindowsProc enumProc, IntPtr lParam);

        [DllImport("user32.dll")]
        static extern IntPtr FindWindow(string? lpClassName, string lpWindowName);
        #endregion

        double seconds;
        private DateTime focusStartTime;
        bool isPopFormDisplayed;
        PopOutForm? popOutForm;

        double totalSecondsRemaining;
        TimeSpan timeRemaining;
        string? timeRemainingString;

        private const int GWL_EXSTYLE = -20;
        private const int WS_EX_TOOLWINDOW = 0x00000080;

        delegate bool EnumWindowsProc(IntPtr hWnd, IntPtr lParam);

        public MainForm()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            EnumWindows(EnumWindowsCallback, IntPtr.Zero);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Start();

            // Calculate the chosen focus time into seconds
            seconds = ((double)timeHours.Value * Math.Pow(60, 2))
                    + ((double)timeMins.Value * 60) + (double)timeSecs.Value;

            // Get the selected item in the combo box
            string? selectedItem = comboBox1.SelectedItem.ToString();

            // Split the selected item into the process name and window title
            int processNameEndIndex = selectedItem.IndexOf(".exe") + 1;
            string processName = selectedItem.Substring(1, processNameEndIndex - 2);
            string windowTitle = selectedItem.Substring(processNameEndIndex + 5);

            // Get the process ID of the selected window
            Process[] processes = Process.GetProcessesByName(processName);
            int processId = processes.FirstOrDefault(p => p.MainWindowTitle == windowTitle)?.Id ?? 0;

            // Set the selected window as the foreground window
            if (processId != 0)
            {
                IntPtr hwnd = Process.GetProcessById(processId).MainWindowHandle;


                focusText.Text = $"Focusing: [{processName}.exe] {windowTitle}";

                focusStartTime = DateTime.Now; // Store the current time

                GetRemainingTime();

                while ((DateTime.Now - focusStartTime).TotalSeconds <= seconds)
                {
                    if (GetForegroundWindow() != hwnd)
                        SetForegroundWindow(hwnd);

                    // If window is minimized, bring it back
                    if (IsIconic(hwnd))
                        ShowWindow(hwnd, 9);

                    Application.DoEvents();

                    if (!isPopFormDisplayed && timer1.Enabled)
                    {
                        popOutForm = new(this);
                        popOutForm.Show();
                        isPopFormDisplayed = true;
                    }
                }
            }
            else { focusText.Text = $"ProcessID is 0, cannot focus! {processes[0].MainWindowTitle}"; }
        }

        // Callback function to get all open windows and add to ComboBox
        bool EnumWindowsCallback(IntPtr hWnd, IntPtr lParam)
        {
            const int nChars = 256;
            StringBuilder sb = new StringBuilder(nChars);

            // Get the window title text
            if (IsWindowVisible(hWnd) && GetWindowText(hWnd, sb, nChars) > 0)
            {
                GetWindowThreadProcessId(hWnd, out uint processId);
                var process = Process.GetProcessById((int)processId);

                // Some filtering
                int exStyle = GetWindowLong(process.MainWindowHandle, GWL_EXSTYLE);
                if ((exStyle & WS_EX_TOOLWINDOW) == 0)
                {
                    // Adds windows to combobox
                    comboBox1.Invoke((MethodInvoker)delegate
                    {
                        comboBox1.Items.Add($"[{process.ProcessName}.exe] {sb}");
                    });
                }
            }
            return true;
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            comboBox1.DropDownWidth = this.Width - 50;
            comboBox1.Width = this.Width - 50;
            focusText.Width = this.Width - 50;
        }

        private void aboutStrip_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Choose a window from the dropdown to stay focused on.", "About");
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            GetRemainingTime();

            if (timeRemaining <= TimeSpan.Zero)
            {
                StopTimer();
            }
            else
            {
                timeRemainingString = string.Format("{0:00}:{1:00}:{2:00}",
                    (int)timeRemaining.TotalHours,
                    timeRemaining.Minutes,
                    timeRemaining.Seconds);

                lbCounter.Text = "Time remaining: " + timeRemainingString;
            }
        }

        private void GetRemainingTime()
        {
            totalSecondsRemaining = seconds - (DateTime.Now - focusStartTime).TotalSeconds;
            timeRemaining = TimeSpan.FromSeconds(totalSecondsRemaining);

            timeRemainingString = string.Format("{0:00}:{1:00}:{2:00}",
                    (int)timeRemaining.TotalHours,
                    timeRemaining.Minutes,
                    timeRemaining.Seconds);

            lbCounter.Text = "Time remaining: " + timeRemainingString;

            if (popOutForm != null)
                popOutForm.PopTimeLabel.Text = lbCounter.Text;
        }

        public void StopTimer()
        {
            // Stop the timer
            timer1.Stop();
            timer1.Enabled = false;
            lbCounter.Text = "Time remaining: 0:00:00";
            seconds = ((double)timeHours.Value * Math.Pow(60, 2)) + ((double)timeMins.Value * 60) + (double)timeSecs.Value;

            // Bring forward the main application
            string windowTitle = "WinFocus";
            IntPtr hwnd = FindWindow(null, windowTitle);
            SetForegroundWindow(hwnd);

            // Remove Popout Timer
            popOutForm?.Close();
            isPopFormDisplayed = false;

            // Hooray!
            MessageBox.Show("Time's up!", "Good job!");
        }

        public double Seconds
        {
            get { return seconds; }
            set { seconds = value; }
        }
    }
}