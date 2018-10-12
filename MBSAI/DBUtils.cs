using System;
using System.Data.SqlServerCe;

namespace MBSAI
{
    class DBUtils
    {
        public static SqlCeConnection GetDBConnection()
        {
            string user = Environment.UserName;
            string datasource = @"C:\Users\" + user + @"\Desktop\MBSAI\MBSAIDB.sdf";
            return DBSQLServerUtils.GetDBConnection(datasource);
        }
    }
}
