using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testForOracle.Interface;
using testForOracle.model;

namespace testForOracle.Controller
{
    public class CdrManager
    {
        IConnection iconnection;

        public CdrManager()
        {
            XmlConfigController xc = new XmlConfigController();
            string databaseType = xc.GetDataBaseType();
            if (!string.IsNullOrEmpty(databaseType))
            {
                if ("oracle".Equals(databaseType))
                {
                    iconnection = new oracleFactory();
                    iconnection.SetConnectionStr();
                }
                else if ("sqlserver".Equals(databaseType))
                {
                    //未完待续
                    //iconnection = new sqlserverFactory();
                }
            }
        }
        //public List<Cdr> GetCdrInfo(string dataid)
        //{
        //    return null;
        //}

        public int TestPing()
        {
            return iconnection.TestPing();
        }

        private void GetRecordDataByEmpid(string empid)
        {
            if (object.Equals(iconnection, null))
            {
                //以后加入log功能
                throw new Exception("实例化接口失败！");
            }
            string sql = @"select t.id, t.name, t.create_tiem, t.data_id
  from rcd_inpatient_record t
 where t.inpatient_record_set_id =
       (select b.id
          from rcd_inpatient_record_set b
         where b.inpatient_id =
               (select a.id
                  from vhis_inpatientinfo a
                 where a.empi_id = '{0}'))";
            sql = string.Format(sql, empid);
            DataSet dtSet = new DataSet();
            DataTable dtTabel = new DataTable();
            dtSet = iconnection.ExcuteQuerySql(sql);
            if (object.Equals(dtSet, null) && dtSet.Tables.Count > 0)
            {
                dtTabel = dtSet.Tables[0] as DataTable;
                List<Cdr> cdrList = new List<Cdr>();
                for(int i = 0; i < dtTabel.Rows.Count; i ++)
                {
                    Cdr cdrinfo = new Cdr();

                    DataRow dtR = dtTabel.Rows[i];
                    cdrinfo.RecordId = dtR[0].ToString();
                    cdrinfo.RecordName = dtR[1].ToString();
                }
                //dtConfirmExec.PrimaryKey = new DataColumn[] { dtConfirmExec.Columns["EXEC_SQN"] };
            }
        }

    }
}
