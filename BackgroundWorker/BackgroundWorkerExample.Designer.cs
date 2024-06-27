namespace BackgroundWorker
{
    partial class BackgroundWorkerExample
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
            this.BgWorkerCheckbox = new System.Windows.Forms.CheckBox();
            this.Go = new System.Windows.Forms.Button();
            this.Cancel = new System.Windows.Forms.Button();
            this.Progress = new System.Windows.Forms.ProgressBar();
            this.BgWorker = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // BgWorkerCheckbox
            // 
            this.BgWorkerCheckbox.AutoSize = true;
            this.BgWorkerCheckbox.Location = new System.Drawing.Point(12, 12);
            this.BgWorkerCheckbox.Name = "BgWorkerCheckbox";
            this.BgWorkerCheckbox.Size = new System.Drawing.Size(224, 29);
            this.BgWorkerCheckbox.TabIndex = 0;
            this.BgWorkerCheckbox.Text = "Use BackgroundWorker";
            this.BgWorkerCheckbox.UseVisualStyleBackColor = true;
            // 
            // Go
            // 
            this.Go.Location = new System.Drawing.Point(12, 47);
            this.Go.Name = "Go";
            this.Go.Size = new System.Drawing.Size(112, 34);
            this.Go.TabIndex = 1;
            this.Go.Text = "Go!";
            this.Go.UseVisualStyleBackColor = true;
            this.Go.Click += new System.EventHandler(this.Go_Click);
            // 
            // Cancel
            // 
            this.Cancel.Location = new System.Drawing.Point(130, 47);
            this.Cancel.Name = "Cancel";
            this.Cancel.Size = new System.Drawing.Size(112, 34);
            this.Cancel.TabIndex = 2;
            this.Cancel.Text = "Cancel.";
            this.Cancel.UseVisualStyleBackColor = true;
            this.Cancel.Click += new System.EventHandler(this.Cancel_Click);
            // 
            // Progress
            // 
            this.Progress.Location = new System.Drawing.Point(12, 87);
            this.Progress.Name = "Progress";
            this.Progress.Size = new System.Drawing.Size(397, 34);
            this.Progress.TabIndex = 3;
            // 
            // BgWorker
            // 
            this.BgWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BgWorker_DoWork);
            this.BgWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BgWorker_ProgressChanged);
            this.BgWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BgWorker_RunWorkerCompleted);
            // 
            // BackgroundWorkerExample
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 153);
            this.Controls.Add(this.Progress);
            this.Controls.Add(this.Cancel);
            this.Controls.Add(this.Go);
            this.Controls.Add(this.BgWorkerCheckbox);
            this.Name = "BackgroundWorkerExample";
            this.Text = "BackgroundWorkerExample";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CheckBox BgWorkerCheckbox;
        private Button Go;
        private Button Cancel;
        private ProgressBar Progress;
        private System.ComponentModel.BackgroundWorker BgWorker;
    }
}