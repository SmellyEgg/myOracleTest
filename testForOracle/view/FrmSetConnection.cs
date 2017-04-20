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
    public partial class FrmSetConnection : Form
    {
        private string strForFormat = "data source={0};password={2};persist security info=True;user id={1}";
        private CryPassword _cp;
        public FrmSetConnection()
        {
            InitializeComponent();
        }
        List<string> tnsNames;
        private void FrmSetConnection_Load(object sender, EventArgs e)
        {
            tnsNames = new List<string>();
            _cp = new CryPassword();
            //获取tns配置
            this.GetTnsConfig();
            //获取当前配置
            this.GetCurrentConfig();
        }

        private void GetCurrentConfig()
        {
            XmlConfigController xc = new XmlConfigController();
            string dataSource = xc.GetConnStr();
            this.txtCurrentDataSource.Text = dataSource;
            this.SetConfigByDataSource(dataSource);
            xc = null;
        }

        private void GetTnsConfig()
        {
            TNSNamesReader tns = new TNSNamesReader();
            List<string> oracleHomes = new List<string>();
            //List<string> tnsNames = new List<string>();
            oracleHomes = tns.GetOracleHomes();
            foreach(string oraclehome in oracleHomes)
            {
                tnsNames.AddRange(tns.LoadTNSNames(oraclehome));
            }
            this.cmbDataSource.DataSource = tnsNames;
            tns = null;
            if (!object.Equals(oracleHomes, null))
            {
                oracleHomes.Clear();
                oracleHomes = null;
            }
        }

        private void SetConfigByDataSource(string datasource)
        {
            System.Data.SqlClient.SqlConnectionStringBuilder builder = new System.Data.SqlClient.SqlConnectionStringBuilder(datasource);
            //string user = builder.UserID;
            //string pass = builder.Password;
            //string source = builder.DataSource;
            this.cmbDataSource.Text = builder.DataSource;
            this.txtUser.Text = builder.UserID;
            this.txtPassword.Text = _cp.EnCodeStr(builder.Password);
            //string datasource = builder.DataSource;
            builder = null;
        }

        private void cmbDataSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.SetDataSourceAfterSelected();   
        }

        private void SetDataSourceAfterSelected()
        {
            if (!string.IsNullOrEmpty(cmbDataSource.Text) && !string.IsNullOrEmpty(txtUser.Text) && !string.IsNullOrEmpty(txtPassword.Text))
            {
                string dataForShow = string.Format(strForFormat, this.cmbDataSource.Text, txtUser.Text, _cp.DeCodeStr(txtPassword.Text));
                this.txtCurrentDataSource.Text = dataForShow;
            }
        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {
            this.SetDataSourceAfterSelected();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            this.SetDataSourceAfterSelected();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Valid())
            {
                XmlConfigController xc = new XmlConfigController();
                xc.SetValueOfDataSource(this.txtCurrentDataSource.Text);
                MessageBox.Show("保存成功！");
            }
            else
            {
                MessageBox.Show("请检查你的输入！");
            }
        }

        private Boolean Valid()
        {
            if (string.IsNullOrEmpty(this.txtCurrentDataSource.Text) || string.IsNullOrEmpty(this.cmbDataSource.Text) || string.IsNullOrEmpty(this.txtUser.Text) || string.IsNullOrEmpty(this.txtPassword.Text))
            {
                return false;
            }
            return true;
        }

        private void btnTestPing_Click(object sender, EventArgs e)
        {
            CdrManager cm = new CdrManager();
            if(cm.TestPing() == 1)
            {
                MessageBox.Show("连接成功");
            }
            else
            {
                MessageBox.Show("连接失败");
            }
            cm = null;
        }
    }
}
