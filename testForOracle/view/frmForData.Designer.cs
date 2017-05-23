namespace testForOracle.view
{
    partial class frmForData
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
            this.dgvtable = new System.Windows.Forms.DataGridView();
            this.rtxSql = new System.Windows.Forms.RichTextBox();
            this.btnExcute = new System.Windows.Forms.Button();
            this.txtTemplateName = new System.Windows.Forms.TextBox();
            this.lblresult = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvtable)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvtable
            // 
            this.dgvtable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvtable.Location = new System.Drawing.Point(23, 128);
            this.dgvtable.Name = "dgvtable";
            this.dgvtable.RowTemplate.Height = 23;
            this.dgvtable.Size = new System.Drawing.Size(745, 321);
            this.dgvtable.TabIndex = 0;
            // 
            // rtxSql
            // 
            this.rtxSql.Location = new System.Drawing.Point(23, 13);
            this.rtxSql.Name = "rtxSql";
            this.rtxSql.Size = new System.Drawing.Size(563, 48);
            this.rtxSql.TabIndex = 1;
            this.rtxSql.Text = "";
            // 
            // btnExcute
            // 
            this.btnExcute.Location = new System.Drawing.Point(633, 26);
            this.btnExcute.Name = "btnExcute";
            this.btnExcute.Size = new System.Drawing.Size(75, 23);
            this.btnExcute.TabIndex = 2;
            this.btnExcute.Text = "Excute";
            this.btnExcute.UseVisualStyleBackColor = true;
            this.btnExcute.Click += new System.EventHandler(this.btnExcute_Click);
            // 
            // txtTemplateName
            // 
            this.txtTemplateName.Location = new System.Drawing.Point(23, 90);
            this.txtTemplateName.Name = "txtTemplateName";
            this.txtTemplateName.Size = new System.Drawing.Size(350, 21);
            this.txtTemplateName.TabIndex = 3;
            // 
            // lblresult
            // 
            this.lblresult.AutoSize = true;
            this.lblresult.Location = new System.Drawing.Point(535, 90);
            this.lblresult.Name = "lblresult";
            this.lblresult.Size = new System.Drawing.Size(41, 12);
            this.lblresult.TabIndex = 4;
            this.lblresult.Text = "label1";
            // 
            // frmForData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(780, 484);
            this.Controls.Add(this.lblresult);
            this.Controls.Add(this.txtTemplateName);
            this.Controls.Add(this.btnExcute);
            this.Controls.Add(this.rtxSql);
            this.Controls.Add(this.dgvtable);
            this.Name = "frmForData";
            this.Text = "frmForData";
            ((System.ComponentModel.ISupportInitialize)(this.dgvtable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvtable;
        private System.Windows.Forms.RichTextBox rtxSql;
        private System.Windows.Forms.Button btnExcute;
        private System.Windows.Forms.TextBox txtTemplateName;
        private System.Windows.Forms.Label lblresult;
    }
}