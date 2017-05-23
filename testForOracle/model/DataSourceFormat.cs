using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testForOracle.model
{
    public static class DataSourceFormat
    {
        /// <summary>
        /// 数据源格式
        /// </summary>
        public static readonly string dataSourceFormat = "data source={0};password={2};persist security info=True;user id={1}";
    }
}
