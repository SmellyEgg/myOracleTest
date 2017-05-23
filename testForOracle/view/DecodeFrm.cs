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
    public partial class DecodeFrm : Form
    {
        CryPassword cp = new CryPassword();
        public DecodeFrm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.textBox1.Text.Trim()))
            {
                this.textBox2.Text = cp.DeCodeStr(this.textBox1.Text.Trim());
            }
        }

        private void DecodeFrm_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.textBox1.Text.Trim()))
            {
                this.textBox2.Text = cp.EnCodeStr(this.textBox1.Text.Trim());
            }
        }
    }
}
