using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using testForOracle.model;

namespace testForOracle
{
   
    class XmlConfigController
    {
        //配置文件路径
        private string path = System.Windows.Forms.Application.StartupPath + @"\oracleConfig.xml";

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
            catch
            {
                conStr = string.Empty;
                throw new Exception("没有找到数据库连接节点！");
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

    }
}
