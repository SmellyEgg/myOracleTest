using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using testForOracle.Controller;

namespace testForOracle.view
{
    public partial class frmForData : Form
    {
        public frmForData()
        {
            InitializeComponent();
        }

        private void btnExcute_Click(object sender, EventArgs e)
        {
            string sql = this.rtxSql.Text.Trim();
            if (string.IsNullOrEmpty(sql)) return;
            CdrManager cdr = new CdrManager();
            DataTable dt = new DataTable();
            DataSet ds = new DataSet();
            ds = cdr.ExcuteSqlWithQuery(sql);
            if (!object.Equals(ds, null) && ds.Tables.Count > 0)
            {
                dt = ds.Tables[0];
                ds.Dispose();
                ds = null;
            }
            this.dgvtable.DataSource = dt;
            this.GetIndexOfText();
        }

        private void GetIndexOfText()
        {
            string text = this.txtTemplateName.Text.Trim();
            for (int i = 0; i < this.dgvtable.Rows.Count; i++)
            {
                if (text.Equals(dgvtable.Rows[i].Cells[1].Value.ToString()))
                {
                    this.lblresult.Text = (i + 1).ToString();
                    break;
                }
            }
        }
    }
}
