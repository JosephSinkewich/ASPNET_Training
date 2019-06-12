using System.Data;
using System.Data.SqlClient;

namespace DAL.Helpers
{
    public interface ISQLHelper
    {
        SqlParameter CreateParameter(string name, object value, DbType dbType);
        DataTable GetDataTable(string commandText, CommandType commandType, SqlParameter[] sqlParameters = null);
        DataSet GetDataSet(string commandText, CommandType commandType, SqlParameter[] sqlParameters = null);

        void Delete(string commandText, CommandType commandType, SqlParameter[] sqlParameters = null);
        void Insert(string commandText, CommandType commandType, SqlParameter[] sqlParameters = null);
        void Update(string commandText, CommandType commandType, SqlParameter[] sqlParameters);
    }
}
