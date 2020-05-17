namespace Dcarengine.UIForm.eol790
{
    partial class setting
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
            this.vinBox = new System.Windows.Forms.CheckBox();
            this.speedBox = new System.Windows.Forms.CheckBox();
            this.retarderBox = new System.Windows.Forms.CheckBox();
            this.arsBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // vinBox
            // 
            this.vinBox.AutoSize = true;
            this.vinBox.Font = new System.Drawing.Font("Consolas", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vinBox.Location = new System.Drawing.Point(210, 279);
            this.vinBox.Name = "vinBox";
            this.vinBox.Size = new System.Drawing.Size(77, 33);
            this.vinBox.TabIndex = 20;
            this.vinBox.Text = "vin";
            this.vinBox.UseVisualStyleBackColor = true;
            // 
            // speedBox
            // 
            this.speedBox.AutoSize = true;
            this.speedBox.Font = new System.Drawing.Font("Consolas", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.speedBox.Location = new System.Drawing.Point(210, 59);
            this.speedBox.Name = "speedBox";
            this.speedBox.Size = new System.Drawing.Size(105, 33);
            this.speedBox.TabIndex = 19;
            this.speedBox.Text = "speed";
            this.speedBox.UseVisualStyleBackColor = true;
            // 
            // retarderBox
            // 
            this.retarderBox.AutoSize = true;
            this.retarderBox.Font = new System.Drawing.Font("Consolas", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.retarderBox.Location = new System.Drawing.Point(210, 126);
            this.retarderBox.Name = "retarderBox";
            this.retarderBox.Size = new System.Drawing.Size(147, 33);
            this.retarderBox.TabIndex = 18;
            this.retarderBox.Text = "retarder";
            this.retarderBox.UseVisualStyleBackColor = true;
            // 
            // arsBox
            // 
            this.arsBox.AutoSize = true;
            this.arsBox.Font = new System.Drawing.Font("Consolas", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.arsBox.Location = new System.Drawing.Point(210, 204);
            this.arsBox.Name = "arsBox";
            this.arsBox.Size = new System.Drawing.Size(77, 33);
            this.arsBox.TabIndex = 17;
            this.arsBox.Text = "ARS";
            this.arsBox.UseVisualStyleBackColor = true;
            // 
            // setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(660, 460);
            this.Controls.Add(this.vinBox);
            this.Controls.Add(this.speedBox);
            this.Controls.Add(this.retarderBox);
            this.Controls.Add(this.arsBox);
            this.Name = "setting";
            this.Text = "setting";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Setting_FormClosing);
            this.Load += new System.EventHandler(this.setting_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox vinBox;
        private System.Windows.Forms.CheckBox speedBox;
        private System.Windows.Forms.CheckBox retarderBox;
        private System.Windows.Forms.CheckBox arsBox;
    }
}