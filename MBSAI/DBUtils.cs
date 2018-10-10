using System;
using System.Data.SqlServerCe;

namespace MBSAI
{
    class DBUtils
    {
        public static SqlCeConnection GetDBConnection()
        {
            string datasource = "C:\\Users\\Dell\\Documents\\Visual Studio 2017\\Projects\\MBSAI\\MBSAIDB.sdf";
            return DBSQLServerUtils.GetDBConnection(datasource);
        }
    }
}
