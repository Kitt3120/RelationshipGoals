namespace RelationshipGoals
{
    partial class FormEditGoal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEditGoal));
            this.labelTitle = new System.Windows.Forms.Label();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.textBoxDescription = new System.Windows.Forms.TextBox();
            this.labelDescription = new System.Windows.Forms.Label();
            this.textBoxPointsToUnlock = new System.Windows.Forms.TextBox();
            this.labelPointsToUnlock = new System.Windows.Forms.Label();
            this.labelPoints = new System.Windows.Forms.Label();
            this.trackBarPoints = new System.Windows.Forms.TrackBar();
            this.textBoxPoints = new System.Windows.Forms.TextBox();
            this.checkBoxUnlocked = new System.Windows.Forms.CheckBox();
            this.buttonUpdate = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPoints)).BeginInit();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Location = new System.Drawing.Point(12, 9);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(27, 13);
            this.labelTitle.TabIndex = 0;
            this.labelTitle.Text = "Title";
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.BackColor = System.Drawing.Color.Plum;
            this.textBoxTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxTitle.Location = new System.Drawing.Point(12, 25);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(165, 20);
            this.textBoxTitle.TabIndex = 1;
            this.textBoxTitle.TextChanged += new System.EventHandler(this.textBoxTitle_TextChanged);
            // 
            // textBoxDescription
            // 
            this.textBoxDescription.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDescription.BackColor = System.Drawing.Color.Plum;
            this.textBoxDescription.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxDescription.Location = new System.Drawing.Point(233, 25);
            this.textBoxDescription.Name = "textBoxDescription";
            this.textBoxDescription.Size = new System.Drawing.Size(294, 20);
            this.textBoxDescription.TabIndex = 3;
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(233, 9);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(60, 13);
            this.labelDescription.TabIndex = 2;
            this.labelDescription.Text = "Description";
            // 
            // textBoxPointsToUnlock
            // 
            this.textBoxPointsToUnlock.BackColor = System.Drawing.Color.Plum;
            this.textBoxPointsToUnlock.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxPointsToUnlock.Location = new System.Drawing.Point(15, 75);
            this.textBoxPointsToUnlock.Name = "textBoxPointsToUnlock";
            this.textBoxPointsToUnlock.Size = new System.Drawing.Size(60, 20);
            this.textBoxPointsToUnlock.TabIndex = 5;
            this.textBoxPointsToUnlock.TextChanged += new System.EventHandler(this.textBoxPointsToUnlock_TextChanged);
            // 
            // labelPointsToUnlock
            // 
            this.labelPointsToUnlock.AutoSize = true;
            this.labelPointsToUnlock.Location = new System.Drawing.Point(12, 59);
            this.labelPointsToUnlock.Name = "labelPointsToUnlock";
            this.labelPointsToUnlock.Size = new System.Drawing.Size(83, 13);
            this.labelPointsToUnlock.TabIndex = 4;
            this.labelPointsToUnlock.Text = "Points to unlock";
            // 
            // labelPoints
            // 
            this.labelPoints.AutoSize = true;
            this.labelPoints.Location = new System.Drawing.Point(233, 59);
            this.labelPoints.Name = "labelPoints";
            this.labelPoints.Size = new System.Drawing.Size(36, 13);
            this.labelPoints.TabIndex = 6;
            this.labelPoints.Text = "Points";
            // 
            // trackBarPoints
            // 
            this.trackBarPoints.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBarPoints.BackColor = System.Drawing.Color.Thistle;
            this.trackBarPoints.Cursor = System.Windows.Forms.Cursors.Default;
            this.trackBarPoints.Location = new System.Drawing.Point(299, 75);
            this.trackBarPoints.Name = "trackBarPoints";
            this.trackBarPoints.Size = new System.Drawing.Size(150, 45);
            this.trackBarPoints.TabIndex = 7;
            this.trackBarPoints.Scroll += new System.EventHandler(this.trackBarPoints_Scroll);
            // 
            // textBoxPoints
            // 
            this.textBoxPoints.BackColor = System.Drawing.Color.Plum;
            this.textBoxPoints.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxPoints.Location = new System.Drawing.Point(233, 75);
            this.textBoxPoints.Name = "textBoxPoints";
            this.textBoxPoints.Size = new System.Drawing.Size(60, 20);
            this.textBoxPoints.TabIndex = 8;
            this.textBoxPoints.TextChanged += new System.EventHandler(this.textBoxPoints_TextChanged);
            // 
            // checkBoxUnlocked
            // 
            this.checkBoxUnlocked.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBoxUnlocked.AutoSize = true;
            this.checkBoxUnlocked.BackColor = System.Drawing.Color.Plum;
            this.checkBoxUnlocked.Location = new System.Drawing.Point(455, 77);
            this.checkBoxUnlocked.Name = "checkBoxUnlocked";
            this.checkBoxUnlocked.Size = new System.Drawing.Size(72, 17);
            this.checkBoxUnlocked.TabIndex = 9;
            this.checkBoxUnlocked.Text = "Unlocked";
            this.checkBoxUnlocked.UseVisualStyleBackColor = false;
            this.checkBoxUnlocked.CheckedChanged += new System.EventHandler(this.checkBoxUnlocked_CheckedChanged);
            // 
            // buttonUpdate
            // 
            this.buttonUpdate.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonUpdate.BackColor = System.Drawing.Color.Plum;
            this.buttonUpdate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUpdate.Location = new System.Drawing.Point(233, 132);
            this.buttonUpdate.Name = "buttonUpdate";
            this.buttonUpdate.Size = new System.Drawing.Size(75, 23);
            this.buttonUpdate.TabIndex = 10;
            this.buttonUpdate.Text = "Update Goal";
            this.buttonUpdate.UseVisualStyleBackColor = false;
            this.buttonUpdate.Click += new System.EventHandler(this.buttonUpdate_Click);
            // 
            // FormEditGoal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Thistle;
            this.ClientSize = new System.Drawing.Size(539, 167);
            this.Controls.Add(this.buttonUpdate);
            this.Controls.Add(this.checkBoxUnlocked);
            this.Controls.Add(this.textBoxPoints);
            this.Controls.Add(this.trackBarPoints);
            this.Controls.Add(this.labelPoints);
            this.Controls.Add(this.textBoxPointsToUnlock);
            this.Controls.Add(this.labelPointsToUnlock);
            this.Controls.Add(this.textBoxDescription);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.textBoxTitle);
            this.Controls.Add(this.labelTitle);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(555, 206);
            this.Name = "FormEditGoal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Edit Goal";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormEditGoal_FormClosing);
            this.Load += new System.EventHandler(this.FormEditGoal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarPoints)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.TextBox textBoxDescription;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.TextBox textBoxPointsToUnlock;
        private System.Windows.Forms.Label labelPointsToUnlock;
        private System.Windows.Forms.Label labelPoints;
        private System.Windows.Forms.TrackBar trackBarPoints;
        private System.Windows.Forms.TextBox textBoxPoints;
        private System.Windows.Forms.CheckBox checkBoxUnlocked;
        private System.Windows.Forms.Button buttonUpdate;
    }
}