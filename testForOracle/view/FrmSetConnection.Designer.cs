namespace testForOracle.view
{
    partial class FrmSetConnection
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
            this.label1 = new System.Windows.Forms.Label();
            this.user = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.cmbDataSource = new System.Windows.Forms.ComboBox();
            this.txtCurrentDataSource = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnTestPing = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "DataSource:";
            // 
            // user
            // 
            this.user.AutoSize = true;
            this.user.Location = new System.Drawing.Point(61, 154);
            this.user.Name = "user";
            this.user.Size = new System.Drawing.Size(35, 12);
            this.user.TabIndex = 1;
            this.user.Text = "user:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(42, 215);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "password:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(124, 277);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(95, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "保存";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(107, 150);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(178, 21);
            this.txtUser.TabIndex = 5;
            this.txtUser.TextChanged += new System.EventHandler(this.txtUser_TextChanged);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(107, 212);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(178, 21);
            this.txtPassword.TabIndex = 6;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            // 
            // cmbDataSource
            // 
            this.cmbDataSource.FormattingEnabled = true;
            this.cmbDataSource.Location = new System.Drawing.Point(107, 89);
            this.cmbDataSource.Name = "cmbDataSource";
            this.cmbDataSource.Size = new System.Drawing.Size(178, 20);
            this.cmbDataSource.TabIndex = 7;
            this.cmbDataSource.SelectedIndexChanged += new System.EventHandler(this.cmbDataSource_SelectedIndexChanged);
            this.cmbDataSource.TextUpdate += new System.EventHandler(this.cmbDataSource_TextUpdate);
            // 
            // txtCurrentDataSource
            // 
            this.txtCurrentDataSource.Location = new System.Drawing.Point(33, 41);
            this.txtCurrentDataSource.Name = "txtCurrentDataSource";
            this.txtCurrentDataSource.Size = new System.Drawing.Size(342, 21);
            this.txtCurrentDataSource.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "当前数据源：";
            // 
            // btnTestPing
            // 
            this.btnTestPing.Location = new System.Drawing.Point(332, 293);
            this.btnTestPing.Name = "btnTestPing";
            this.btnTestPing.Size = new System.Drawing.Size(75, 23);
            this.btnTestPing.TabIndex = 10;
            this.btnTestPing.Text = "测试连接";
            this.btnTestPing.UseVisualStyleBackColor = true;
            this.btnTestPing.Click += new System.EventHandler(this.btnTestPing_Click);
            // 
            // FrmSetConnection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 328);
            this.Controls.Add(this.btnTestPing);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCurrentDataSource);
            this.Controls.Add(this.cmbDataSource);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.user);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "FrmSetConnection";
            this.Text = "连接串设置";
            this.Load += new System.EventHandler(this.FrmSetConnection_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label user;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.ComboBox cmbDataSource;
        private System.Windows.Forms.TextBox txtCurrentDataSource;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnTestPing;
    }
}