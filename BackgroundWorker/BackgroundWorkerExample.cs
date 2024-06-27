using System.ComponentModel;

namespace BackgroundWorker
{
    public partial class BackgroundWorkerExample : Form
    {
        public BackgroundWorkerExample()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Waste CPU cycles causing the program to slow down by doing calculations for 100ms
        /// </summary>
        private void WasteCPUCycles()
        {
            DateTime startTime = DateTime.Now;
            double value = Math.E;

            //wasted CPU Cycles() does a whole bunch of math calculations
            //to tie up the CPU for 100Ms and then it returns.
            while (DateTime.Now < startTime.AddMilliseconds(100))
            {
                value /= Math.PI;
                value *= Math.Sqrt(2);
            }
        }

        /// <summary>
        /// Clicking the Go button starts wasting CPU cycles for 10 seconds
        /// </summary>
        private void Go_Click(object sender, EventArgs e)
        {
            Go.Enabled = false;

            if (!BgWorkerCheckbox.Checked)
            {
                // If we're not using the background worker, just start wasting CPU cycles.
                for (int i = 1; i <= 100; i++)
                {
                    WasteCPUCycles();
                    Progress.Value = i;
                }
                Go.Enabled = true;
            }
            else
            {
                /* If the form’s using the background
                worker, it enables the Cancel button. */
                Cancel.Enabled = true;

                /* When the user clicks on the Go! button, the
                event handler checks to see if the “Use
                BackgroundWorker” check box is checked. If it
                isn’t, the form wastes CPU cycles for 10 seconds.
                If it is, the form calls the BackgroundWorker’s
                RunWorkerAsync() method to tell it to start doing
                its work in the background. */
                // If we are using the background worker, use its RunWorkerAsync()
                // to tell it to start its work.
                BgWorker.WorkerReportsProgress = true; 
                BgWorker.RunWorkerAsync(new Guy("Bob", 37, 146));
            }
        }

        /// <summary>
        /// Background Worker obj runs its DoWork event handler in the background.
        /// </summary>
        private void BgWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            // e.Argument returns the argument that was passed to RunWorkerAsync()
            MessageBox.Show("Background worker argument: " + (e.Argument ?? null));

            // Start wasting CPU cycles.
            for (int i = 1; i <= 100; i++) 
            {
                WasteCPUCycles();
                
                // using BgWorker.Progress method to report % that have been completed.
                BgWorker.ReportProgress(i);

                //if the BgWorker.CancellationPending prop is true, cancel.
                /* The CancellationPending method
                checks if the BackgroundWorker’s
                CancelAsync() method was called. */
                if (BgWorker.CancellationPending)
                {
                    MessageBox.Show("Cancelled");
                    break;
                }
            }
        }

        /* The BackgroundWorker only fires its ProgressChanged and RunWorkerCompleted events if
        its WorkerReportsProgress and WorkerSupportsCancellation properties are true. */
        /// <summary>
        /// BackgroundWorker fires its ProgressChanged event when the worker thread reports progress.
        /// </summary>
        private void BgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            /* When the DoWork event handler calls the ProgressChanged() method,
            it causes the BackgroundWorker to raise its ProgressChanged event.
            and set e.ProgressPercentage to the percent passed to it. */
            Progress.Value = e.ProgressPercentage;
        }

        /// <summary>
        /// BackgroundWorker fires its RunWorkerCompleted event when its work is done (or cancelled)
        /// </summary>
        private void BgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            /* When the work is complete, the RunWorkerCompleted event handler
            re-enables the Go! button and disables the Cancel button. */
            Go.Enabled = true;
            Cancel.Enabled = false;
        }

        /// <summary>
        /// When the user clicks Cancel, call BackgroundWorker.CancelAsync() to send it a cancel message
        /// </summary>
        private void Cancel_Click(object sender, EventArgs e)
        {
            BgWorker.WorkerSupportsCancellation = true;
            /* If the user clicks Cancel, it calls the
            BackgroundWorker’s CancelAsync()
            method to give it the message to cancel. */
            BgWorker.CancelAsync();
        }
    }
}