using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testForOracle.dataFill
{
    class User
    {
        private oracleFactory _clsps;

        public User()
        {
            _clsps = new oracleFactory();
        }
        public Boolean Login(string name, string password)
        {
            string sql = @"select count(1) from com_employee where name = '{0}' and password = '{1}'";
            sql = string.Format(sql, name, password);
            if (!object.Equals(_clsps, null))
            {
                if (_clsps.ExcuteNoQuery(sql) == 1)
                {
                    return true;
                }
            }
            return false;
        } 
    }
}
