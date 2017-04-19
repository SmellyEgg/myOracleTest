using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testForOracle.Interface
{
    interface IConnection
    {
        /// <summary>
        /// 新增用户
        /// </summary>
        /// <returns></returns>
        int CreateUser();

        /// <summary>
        /// 执行非查询语句(包括了)
        /// </summary>
        /// <returns></returns>
        int ExcuteNoQuery(string sql);

        /// <summary>
        /// 执行查询语句
        /// </summary>
        /// <returns></returns>
        System.Data.DataSet ExcuteQuerySql(string sql);

        /// <summary>
        /// 设置连接串
        /// </summary>
        void SetConnectionStr();
    }
}
