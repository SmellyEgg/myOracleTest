using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using testForOracle.Interface;

namespace testForOracle
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }


        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
            {
                XmlConfigController xc = new XmlConfigController();
                string databaseType = xc.GetDataBaseType();
                IConnection iconnection;
                if (!string.IsNullOrEmpty(databaseType))
                {
                    if ("oracle".Equals(databaseType))
                    {
                        iconnection = new oracleFactory();
                        iconnection.SetConnectionStr();
                        DataSet dt = iconnection.ExcuteQuerySql(this.textBox1.Text.Trim());
                        string test = dt.Tables[0].Rows[0][1].ToString();
                        if (!object.Equals(dt, null))
                        {
                            dt.Dispose();
                            dt = null;
                        }
                    }
                    else if ("sqlserver".Equals(databaseType))
                    {
                        //未完待续
                    }
                }

            }

        }

        private void testMethod()
        {
            List<AutoResetEvent> events = new List<AutoResetEvent>();

            AutoResetEvent loadTable1 = new AutoResetEvent(false);
            events.Add(loadTable1);
            ThreadPool.QueueUserWorkItem(delegate
            {
                //SqlCommand1.BeginExecuteReader;
                //SqlCommand1.EndExecuteReader;
                //DataTable1.Load(DataReader1);
                for(int i = 0; i < 4; i ++)
                {
                    Thread.Sleep(1000);
                    int j = i * 2;
                }
                loadTable1.Set();
            });

            AutoResetEvent loadTable2 = new AutoResetEvent(false);
            events.Add(loadTable2);
            ThreadPool.QueueUserWorkItem(delegate
            {
                for (int i = 0; i < 5; i++)
                {
                    Thread.Sleep(1000);
                    int j = i * 2;
                }
                loadTable2.Set();
            });

            // wait until both tables have loaded.
            foreach (var e in events)
            {
                e.WaitOne();
            }
            label1.Text = "完成了";
            //WaitHandle.WaitAll(events.ToArray());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.testMethod();
        }

        int index = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            label1.Text = index.ToString();
            index++;
        }
    }
}
