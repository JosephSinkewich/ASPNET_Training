using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DAL.Helpers
{
    public class SQLHelper : ISQLHelper
    {
        public string ConnectionString { get; set; }

        public SQLHelper()
        {
            ConnectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
        }

        public SqlParameter CreateParameter(string name, object value, DbType dbType)
        {
            return new SqlParameter
            {
                ParameterName = name,
                Value = value,
                DbType = dbType,
                Size = 0,
                Direction = ParameterDirection.Input
            };
        }

        public void Delete(string commandText, CommandType commandType, SqlParameter[] sqlParameters = null)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(commandText, connection))
                {
                    command.CommandType = commandType;
                    if (sqlParameters != null)
                    {
                        foreach (var parameter in sqlParameters)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }

                    command.ExecuteNonQuery();
                }
            }
        }

        public DataSet GetDataSet(string commandText, CommandType commandType, SqlParameter[] sqlParameters = null)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(commandText, connection))
                {
                    command.CommandType = commandType;
                    if (sqlParameters != null)
                    {
                        foreach (var parameter in sqlParameters)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }

                    var dataset = new DataSet();
                    var dataAdapter = new SqlDataAdapter(command);
                    dataAdapter.Fill(dataset);
                    return dataset;
                }
            }
        }

        public DataTable GetDataTable(string commandText, CommandType commandType, SqlParameter[] sqlParameters = null)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(commandText, connection))
                {
                    command.CommandType = commandType;
                    if (sqlParameters != null)
                    {
                        foreach (var parameter in sqlParameters)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }

                    var dataset = new DataSet();
                    var dataAdapter = new SqlDataAdapter(command);
                    dataAdapter.Fill(dataset);
                    return dataset.Tables[0];
                }
            }
        }

        public void Insert(string commandText, CommandType commandType, SqlParameter[] sqlParameters = null)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(commandText, connection))
                {
                    command.CommandType = commandType;
                    if (sqlParameters != null)
                    {
                        foreach (var parameter in sqlParameters)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }

                    command.ExecuteNonQuery();
                }
            }
        }

        public void Update(string commandText, CommandType commandType, SqlParameter[] sqlParameters)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();

                using (var command = new SqlCommand(commandText, connection))
                {
                    command.CommandType = commandType;
                    if (sqlParameters != null)
                    {
                        foreach (var parameter in sqlParameters)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }

                    command.ExecuteNonQuery();
                }
            }
        }
    }
}
