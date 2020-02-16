namespace RelationshipGoals
{
    partial class FormSettings
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
            this.groupBoxSettingsSQL = new System.Windows.Forms.GroupBox();
            this.labelSqlAddress = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.textBoxSqlAddress = new System.Windows.Forms.TextBox();
            this.labelSqlPort = new System.Windows.Forms.Label();
            this.textBoxSqlPort = new System.Windows.Forms.TextBox();
            this.labelSqlLogin = new System.Windows.Forms.Label();
            this.textBoxSqlLogin = new System.Windows.Forms.TextBox();
            this.labelSqlPassword = new System.Windows.Forms.Label();
            this.textBoxSqlPassword = new System.Windows.Forms.TextBox();
            this.buttonSqlCheck = new System.Windows.Forms.Button();
            this.labelSqlSchema = new System.Windows.Forms.Label();
            this.comboBoxSqlSchema = new System.Windows.Forms.ComboBox();
            this.groupBoxSettingsSQL.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxSettingsSQL
            // 
            this.groupBoxSettingsSQL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxSettingsSQL.Controls.Add(this.comboBoxSqlSchema);
            this.groupBoxSettingsSQL.Controls.Add(this.labelSqlSchema);
            this.groupBoxSettingsSQL.Controls.Add(this.buttonSqlCheck);
            this.groupBoxSettingsSQL.Controls.Add(this.textBoxSqlPassword);
            this.groupBoxSettingsSQL.Controls.Add(this.labelSqlPassword);
            this.groupBoxSettingsSQL.Controls.Add(this.textBoxSqlLogin);
            this.groupBoxSettingsSQL.Controls.Add(this.labelSqlLogin);
            this.groupBoxSettingsSQL.Controls.Add(this.textBoxSqlPort);
            this.groupBoxSettingsSQL.Controls.Add(this.labelSqlPort);
            this.groupBoxSettingsSQL.Controls.Add(this.textBoxSqlAddress);
            this.groupBoxSettingsSQL.Controls.Add(this.labelSqlAddress);
            this.groupBoxSettingsSQL.Location = new System.Drawing.Point(12, 12);
            this.groupBoxSettingsSQL.Name = "groupBoxSettingsSQL";
            this.groupBoxSettingsSQL.Size = new System.Drawing.Size(310, 283);
            this.groupBoxSettingsSQL.TabIndex = 0;
            this.groupBoxSettingsSQL.TabStop = false;
            this.groupBoxSettingsSQL.Text = "SQL Settings";
            // 
            // labelSqlAddress
            // 
            this.labelSqlAddress.AutoSize = true;
            this.labelSqlAddress.Location = new System.Drawing.Point(6, 16);
            this.labelSqlAddress.Name = "labelSqlAddress";
            this.labelSqlAddress.Size = new System.Drawing.Size(103, 13);
            this.labelSqlAddress.TabIndex = 0;
            this.labelSqlAddress.Text = "SQL Server Address";
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSave.Enabled = false;
            this.buttonSave.Location = new System.Drawing.Point(247, 301);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 1;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // textBoxSqlAddress
            // 
            this.textBoxSqlAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSqlAddress.Location = new System.Drawing.Point(6, 32);
            this.textBoxSqlAddress.Name = "textBoxSqlAddress";
            this.textBoxSqlAddress.Size = new System.Drawing.Size(241, 20);
            this.textBoxSqlAddress.TabIndex = 1;
            // 
            // labelSqlPort
            // 
            this.labelSqlPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSqlPort.AutoSize = true;
            this.labelSqlPort.Location = new System.Drawing.Point(269, 16);
            this.labelSqlPort.Name = "labelSqlPort";
            this.labelSqlPort.Size = new System.Drawing.Size(26, 13);
            this.labelSqlPort.TabIndex = 2;
            this.labelSqlPort.Text = "Port";
            // 
            // textBoxSqlPort
            // 
            this.textBoxSqlPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSqlPort.Location = new System.Drawing.Point(253, 32);
            this.textBoxSqlPort.Name = "textBoxSqlPort";
            this.textBoxSqlPort.Size = new System.Drawing.Size(42, 20);
            this.textBoxSqlPort.TabIndex = 3;
            // 
            // labelSqlLogin
            // 
            this.labelSqlLogin.AutoSize = true;
            this.labelSqlLogin.Location = new System.Drawing.Point(6, 55);
            this.labelSqlLogin.Name = "labelSqlLogin";
            this.labelSqlLogin.Size = new System.Drawing.Size(33, 13);
            this.labelSqlLogin.TabIndex = 4;
            this.labelSqlLogin.Text = "Login";
            // 
            // textBoxSqlLogin
            // 
            this.textBoxSqlLogin.Location = new System.Drawing.Point(6, 71);
            this.textBoxSqlLogin.Name = "textBoxSqlLogin";
            this.textBoxSqlLogin.Size = new System.Drawing.Size(141, 20);
            this.textBoxSqlLogin.TabIndex = 5;
            // 
            // labelSqlPassword
            // 
            this.labelSqlPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelSqlPassword.AutoSize = true;
            this.labelSqlPassword.Location = new System.Drawing.Point(242, 55);
            this.labelSqlPassword.Name = "labelSqlPassword";
            this.labelSqlPassword.Size = new System.Drawing.Size(53, 13);
            this.labelSqlPassword.TabIndex = 6;
            this.labelSqlPassword.Text = "Password";
            // 
            // textBoxSqlPassword
            // 
            this.textBoxSqlPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxSqlPassword.Location = new System.Drawing.Point(151, 71);
            this.textBoxSqlPassword.Name = "textBoxSqlPassword";
            this.textBoxSqlPassword.Size = new System.Drawing.Size(141, 20);
            this.textBoxSqlPassword.TabIndex = 7;
            // 
            // buttonSqlCheck
            // 
            this.buttonSqlCheck.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSqlCheck.Location = new System.Drawing.Point(111, 97);
            this.buttonSqlCheck.Name = "buttonSqlCheck";
            this.buttonSqlCheck.Size = new System.Drawing.Size(75, 23);
            this.buttonSqlCheck.TabIndex = 8;
            this.buttonSqlCheck.Text = "Check";
            this.buttonSqlCheck.UseVisualStyleBackColor = true;
            this.buttonSqlCheck.Click += new System.EventHandler(this.buttonSqlCheck_Click);
            // 
            // labelSqlSchema
            // 
            this.labelSqlSchema.AutoSize = true;
            this.labelSqlSchema.Enabled = false;
            this.labelSqlSchema.Location = new System.Drawing.Point(6, 118);
            this.labelSqlSchema.Name = "labelSqlSchema";
            this.labelSqlSchema.Size = new System.Drawing.Size(46, 13);
            this.labelSqlSchema.TabIndex = 9;
            this.labelSqlSchema.Text = "Schema";
            // 
            // comboBoxSqlSchema
            // 
            this.comboBoxSqlSchema.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBoxSqlSchema.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxSqlSchema.Enabled = false;
            this.comboBoxSqlSchema.FormattingEnabled = true;
            this.comboBoxSqlSchema.Location = new System.Drawing.Point(6, 134);
            this.comboBoxSqlSchema.Name = "comboBoxSqlSchema";
            this.comboBoxSqlSchema.Size = new System.Drawing.Size(298, 21);
            this.comboBoxSqlSchema.TabIndex = 10;
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 336);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.groupBoxSettingsSQL);
            this.MinimumSize = new System.Drawing.Size(350, 375);
            this.Name = "FormSettings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Settings";
            this.groupBoxSettingsSQL.ResumeLayout(false);
            this.groupBoxSettingsSQL.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxSettingsSQL;
        private System.Windows.Forms.Label labelSqlAddress;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label labelSqlPort;
        private System.Windows.Forms.TextBox textBoxSqlAddress;
        private System.Windows.Forms.TextBox textBoxSqlPort;
        private System.Windows.Forms.TextBox textBoxSqlPassword;
        private System.Windows.Forms.Label labelSqlPassword;
        private System.Windows.Forms.TextBox textBoxSqlLogin;
        private System.Windows.Forms.Label labelSqlLogin;
        private System.Windows.Forms.Button buttonSqlCheck;
        private System.Windows.Forms.ComboBox comboBoxSqlSchema;
        private System.Windows.Forms.Label labelSqlSchema;
    }
}