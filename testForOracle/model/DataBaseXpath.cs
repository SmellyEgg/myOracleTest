using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testForOracle.model
{
    public static class DataBaseXpath
    {
        /// <summary>
        /// 数据库连接串
        /// </summary>
        public static readonly string xpathOfConStr = "/Settings/DataBaseSetting";
        /// <summary>
        /// 数据库类型，主要是oracle或者sqlserver
        /// </summary>
        public static readonly string xpathOfDataBaseType = "/Settings/DataBaseType";
        /// <summary>
        /// 
        /// </summary>
        public static readonly string xpathOfKey = "/Settings/CryKey";

    }
}
