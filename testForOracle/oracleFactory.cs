using Oracle.DataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using testForOracle.Interface;
using testForOracle.model;

namespace testForOracle
{
    class oracleFactory : IConnection
    {
        OracleConnection conn = null;
        OracleTransaction tx = null;
        public oracleFactory()
        {
        }

        public void SetConnectionStr()
        {
            XmlConfigController xc = new XmlConfigController();
            string conStr = xc.GetConnStr();
            conn = new OracleConnection(conStr);
        }

        public int CreateUser()
        {
            return 1;
        }

        public DataSet ExcuteQuerySql(string sql)
        {
            using (OracleCommand cmd = new OracleCommand())
            {
                conn.Open();
                cmd.Connection = conn;
                tx = conn.BeginTransaction();
                DataSet dtS = new DataSet();
                try
                {
                    if (!String.IsNullOrEmpty(sql))
                    {
                        cmd.CommandText = sql;
                        OracleDataAdapter da = new OracleDataAdapter(cmd);
                        da.Fill(dtS);
                        da.Dispose();
                        //OracleDataReader reader = cmd.Excute();
                        //while (reader.Read())
                        //{
                        //    us.Name = reader.GetString(reader.GetOrdinal("MCQ_TITLE"));
                        //    us.Code = reader.GetString(reader.GetOrdinal("MCQ_TITLE"))
                        //    //Console.WriteLine(reader.GetInt32(0) + ", " + reader.GetInt32(1));
                        //}
                    }
                    tx.Commit();
                }
                catch (OracleException E)
                {
                    tx.Rollback();
                    throw new Exception(E.Message);
                }
                finally
                {
                    if (conn.State != ConnectionState.Closed)
                    {
                        conn.Close();
                    }
                }
                if (!object.Equals(dtS, null))
                {
                    return dtS;
                }
            }
            return null;
        }

         
        public int ExcuteNoQuery(string sql)
        {
            using (OracleCommand cmd = new OracleCommand())
            {
                cmd.Connection = conn;
                tx = conn.BeginTransaction();
                try
                {
                    if (!String.IsNullOrEmpty(sql))
                    {
                        cmd.CommandText = sql;
                        return cmd.ExecuteNonQuery();
                    }
                    tx.Commit();
                }
                catch (OracleException E)
                {
                    tx.Rollback();
                    throw new Exception(E.Message);
                }
                finally
                {
                    if (conn.State != ConnectionState.Closed)
                    {
                        conn.Close();
                    }
                }
            }
            return 0;
        }


        public void ExecuteSqlTran(string conStr, List<String> SQLStringList)
        {
            using (OracleConnection conn = new OracleConnection(conStr))
            {
                conn.Open();
                OracleCommand cmd = new OracleCommand();
                cmd.Connection = conn;
                tx = conn.BeginTransaction();
                //cmd.Transaction = tx;
                try
                {
                    foreach (string sql in SQLStringList)
                    {
                        if (!String.IsNullOrEmpty(sql))
                        {
                            cmd.CommandText = sql;
                            cmd.ExecuteNonQuery();
                        }
                    }
                    tx.Commit();
                }
                catch (OracleException E)
                {
                    tx.Rollback();
                    throw new Exception(E.Message);
                }
                finally
                {
                    if (conn.State != ConnectionState.Closed)
                    {
                        conn.Close();
                    }
                }
            }
        }
    }
}
