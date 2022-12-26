namespace Task1
{
    partial class ProgressForm
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
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.minRangeText = new System.Windows.Forms.Label();
            this.maxRangeText = new System.Windows.Forms.Label();
            this.progressText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(47, 100);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(577, 54);
            this.progressBar1.TabIndex = 0;
            // 
            // minRangeText
            // 
            this.minRangeText.AutoSize = true;
            this.minRangeText.Location = new System.Drawing.Point(34, 162);
            this.minRangeText.Name = "minRangeText";
            this.minRangeText.Size = new System.Drawing.Size(14, 15);
            this.minRangeText.TabIndex = 1;
            this.minRangeText.Text = "0";
            // 
            // maxRangeText
            // 
            this.maxRangeText.AutoSize = true;
            this.maxRangeText.Location = new System.Drawing.Point(610, 162);
            this.maxRangeText.Name = "maxRangeText";
            this.maxRangeText.Size = new System.Drawing.Size(28, 15);
            this.maxRangeText.TabIndex = 1;
            this.maxRangeText.Text = "123";
            // 
            // progressText
            // 
            this.progressText.AutoSize = true;
            this.progressText.Location = new System.Drawing.Point(315, 162);
            this.progressText.Name = "progressText";
            this.progressText.Size = new System.Drawing.Size(40, 15);
            this.progressText.TabIndex = 1;
            this.progressText.Text = "label1";
            // 
            // ProgressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 253);
            this.Controls.Add(this.progressText);
            this.Controls.Add(this.maxRangeText);
            this.Controls.Add(this.minRangeText);
            this.Controls.Add(this.progressBar1);
            this.Name = "ProgressForm";
            this.Text = "ProgressForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ProgressBar progressBar1;
        private Label minRangeText;
        private Label maxRangeText;
        private Label progressText;
    }
}