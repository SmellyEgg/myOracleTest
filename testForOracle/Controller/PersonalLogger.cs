using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testForOracle.Controller
{
    public class PersonalLogger
    {
        public PersonalLogger()
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
            newLog();
        }
        public PersonalLogger(string strFileName)
        {
            //
            // TODO: 在此处添加构造函数逻辑
            //
            this.strFileName = strFileName;
            newLog();
        }
        private void newLog() 
        {
            if (!File.Exists(this.strFileName))
            {
                System.IO.File.CreateText(this.strFileName);
            }
        }

        #region 变量
        private string strFileName = AppDomain.CurrentDomain.BaseDirectory + "\\log.txt";
        private System.IO.TextWriter output;
        #endregion

        #region 属性
        /// <summary>
		/// 设置/读取文件名
		/// </summary>
		public string FileName
        {
            get
            {
                return strFileName;
            }
            set
            {
                strFileName = value;
            }
        }
        #endregion

        #region 方法
        /// <summary>
		/// 写日志
		/// </summary>
		/// <param name="str"></param>
		public void WriteLog(string str)
        {
            try
            {
                output = File.AppendText(strFileName);
                output.WriteLine(System.DateTime.Now + "\n" + str);
                output.Close();
            }
            catch (Exception ex)
            {

            }
        }

        public void ClearLog()
        {
            try
            {
                FileStream fs = File.Create(strFileName, 1);
                fs.Close();
            }
            catch { }
        }

        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="str"></param>
        public void WriteException(Exception e)
        {
            try
            {
                output = File.AppendText(strFileName);
                if (e.InnerException != null)
                {
                    output.WriteLine(System.DateTime.Now + "\n" + e.InnerException.Message + "\n" + e.InnerException.StackTrace + "\n" + e.InnerException.Source);
                }
                else
                {
                    output.WriteLine(System.DateTime.Now + "\n" + e.Message + "\n" + e.StackTrace + "\n" + e.Source);
                }
            }
            catch { }
            finally
            {
                if (output != null)
                {
                    output.Close();
                }
            }
        }
        #endregion
    }
}
