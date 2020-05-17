namespace Dcarengine.UIForm.eol790s
{
    partial class processForm
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.ami_Label1 = new EASkins.Ami_Label();
            this.ami_Label2 = new EASkins.Ami_Label();
            this.SuspendLayout();
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 91);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(564, 63);
            this.progressBar1.TabIndex = 0;
            // 
            // ami_Label1
            // 
            this.ami_Label1.AutoSize = true;
            this.ami_Label1.BackColor = System.Drawing.Color.Transparent;
            this.ami_Label1.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.ami_Label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.ami_Label1.Location = new System.Drawing.Point(236, 157);
            this.ami_Label1.Name = "ami_Label1";
            this.ami_Label1.Size = new System.Drawing.Size(22, 25);
            this.ami_Label1.TabIndex = 1;
            this.ami_Label1.Text = "0";
            // 
            // ami_Label2
            // 
            this.ami_Label2.AutoSize = true;
            this.ami_Label2.BackColor = System.Drawing.Color.Transparent;
            this.ami_Label2.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.ami_Label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(76)))), ((int)(((byte)(77)))));
            this.ami_Label2.Location = new System.Drawing.Point(264, 157);
            this.ami_Label2.Name = "ami_Label2";
            this.ami_Label2.Size = new System.Drawing.Size(28, 25);
            this.ami_Label2.TabIndex = 2;
            this.ami_Label2.Text = "%";
            // 
            // processForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 208);
            this.Controls.Add(this.ami_Label2);
            this.Controls.Add(this.ami_Label1);
            this.Controls.Add(this.progressBar1);
            this.MinimizeBox = false;
            this.Name = "processForm";
            this.Text = "processForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ProgressBar progressBar1;
        private EASkins.Ami_Label ami_Label1;
        private EASkins.Ami_Label ami_Label2;
    }
}