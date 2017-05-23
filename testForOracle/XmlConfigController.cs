using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using testForOracle.model;

namespace testForOracle
{
   
    public class XmlConfigController
    {

        /// <summary>
        /// 配置文件路径
        /// </summary>
        private string path = System.Windows.Forms.Application.StartupPath + @"\oracleConfig.xml";
        /// <summary>
        /// 错误信息
        /// </summary>
        public string _errCode = string.Empty;

        public XmlConfigController()
        {

        }

        /// <summary>
        /// 获取数据库连接串
        /// </summary>
        /// <returns></returns>
        public string GetConnStr()
        {
            string conStr = string.Empty;
            try
            {
                conStr = this.GetValueByXpath(DataBaseXpath.xpathOfConStr);
            }
            catch(Exception ex)
            {
                conStr = string.Empty;
                throw new Exception("没有找到数据库连接节点！" + ex.Message);
            }
            return conStr;
        }             

        /// <summary>
        /// 获取数据库类型
        /// </summary>
        /// <returns></returns>
        public string GetDataBaseType()
        {
            string basetype = string.Empty;
            try
            {
                basetype = this.GetValueByXpath(DataBaseXpath.xpathOfDataBaseType);
            }
            catch (Exception ex)
            {
                basetype = string.Empty;
                throw new Exception("没有找到数据库类型节点！");
            }
            return basetype;
        }

        /// <summary>
        /// 加密密钥
        /// </summary>
        /// <returns></returns>
        public string GetKeyOfCryPd()
        {
            string key = string.Empty;
            try
            {
                key = this.GetValueByXpath(DataBaseXpath.xpathOfKey);
            }
            catch (Exception ex)
            {
                key = string.Empty;
                this._errCode = ex.Message;
                throw new Exception("没有找到数据库类型节点！");
            }
            return key;
        }

        private string GetValueByXpath(string xpath)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(System.IO.File.ReadAllText(path, Encoding.UTF8));

            XmlNode node = doc.SelectSingleNode(xpath);
            if (node == null)
            {
                throw new Exception("没有找到配置的节点结点！");
            }
            string conStr = node.Attributes[0].Value;
            if (!string.IsNullOrEmpty(conStr)) return conStr;
            return string.Empty;
        }

        public void SetValueOfDataSource(string nodeValue)
        {
            this.SetValueByXpath(DataBaseXpath.xpathOfConStr, nodeValue);
        }

        private void SetValueByXpath(string xpath, string nodeValue)
        {
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(System.IO.File.ReadAllText(path, Encoding.UTF8));

            XmlNode node = doc.SelectSingleNode(xpath);
            node.Attributes[0].Value = nodeValue;

            doc.Save(path);
        }

    }
}
