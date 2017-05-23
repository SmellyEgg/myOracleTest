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
        /// <summary>
        /// 数据源格式
        /// </summary>
        private string strForFormat = "data source={0};password={2};persist security info=True;user id={1}";
        private List<string> listCombobox = new List<string>();
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
            this.cmbDataSource.Items.Clear();
            //this.cmbDataSource.DataSource = tnsNames;
            this.cmbDataSource.Items.AddRange(tnsNames.ToArray());
            this.listCombobox = getComboboxItems(this.cmbDataSource);//获取Item

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
            //CdrManager cm = new CdrManager();
            ////cm.ExcuteSql(@"insert into SUIFANG(ID) values ('1');select * from SUIFANG");
            ////if(cm.TestPing() == 1)
            ////{
            ////    MessageBox.Show("连接成功");
            ////}
            ////else
            ////{
            ////    MessageBox.Show("连接失败");
            ////}
            //if (!object.Equals(cm, null))
            //{
            //    cm = null;
            //}
            frmForData frm = new frmForData();
            frm.ShowDialog();
        }

        private void cmbDataSource_TextUpdate(object sender, EventArgs e)
        {
            selectCombobox(cmbDataSource, listCombobox);
        }

        public List<string> getComboboxItems(ComboBox cb)
        {
            //初始化绑定默认关键词  
            List<string> listOnit = new List<string>();
            //将数据项添加到listOnit中  
            for (int i = 0; i < cb.Items.Count; i++)
            {
                listOnit.Add(cb.Items[i].ToString());
            }
            return listOnit;
        }
        //模糊查询Combobox  
        public void selectCombobox(ComboBox cb, List<string> listOnit)
        {
            //输入key之后返回的关键词  
           List<string> listNew = new List<string>();
            //清空combobox  
            cb.Items.Clear();
            //cb.DataSource = null;
            //清空listNew  
            //listNew.Clear();
            //遍历全部备查数据  
            foreach (var item in listOnit)
            {
                if (item.ToLower().Contains(cb.Text.ToLower()))
                {
                    //符合，插入ListNew  
                    listNew.Add(item);
                }
            }
            //combobox添加已经查询到的关键字  
            cb.Items.AddRange(listNew.ToArray());
            //cb.DataSource = listNew;
            //设置光标位置，否则光标位置始终保持在第一列，造成输入关键词的倒序排列  
            cb.SelectionStart = cb.Text.Length;
            //保持鼠标指针原来状态，有时鼠标指针会被下拉框覆盖，所以要进行一次设置  
            Cursor = Cursors.Default;
            //自动弹出下拉框  
            cb.DroppedDown = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DecodeFrm df = new DecodeFrm();
            df.ShowDialog();
        }
    }
}
