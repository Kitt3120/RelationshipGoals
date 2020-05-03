namespace RelationshipGoals
{
    partial class FormHeart
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
            this.pictureBoxHeart = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHeart)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxHeart
            // 
            this.pictureBoxHeart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxHeart.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxHeart.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxHeart.Name = "pictureBoxHeart";
            this.pictureBoxHeart.Size = new System.Drawing.Size(150, 150);
            this.pictureBoxHeart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxHeart.TabIndex = 0;
            this.pictureBoxHeart.TabStop = false;
            // 
            // FormHeart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGreen;
            this.CausesValidation = false;
            this.ClientSize = new System.Drawing.Size(150, 150);
            this.ControlBox = false;
            this.Controls.Add(this.pictureBoxHeart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(150, 150);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(150, 150);
            this.Name = "FormHeart";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Heart";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.LightGreen;
            this.Load += new System.EventHandler(this.FormHeart_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHeart)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxHeart;
    }
}