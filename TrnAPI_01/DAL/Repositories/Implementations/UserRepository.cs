using Common.Model;
using DAL.Helpers;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private ISQLHelper helper;

        public UserRepository(ISQLHelper helper)
        {
            this.helper = helper;
        }

        public void Create(User item)
        {
            var parameters = new SqlParameter[]
            {
                helper.CreateParameter("@Name", item.Name, DbType.String),
                helper.CreateParameter("@Password", item.Password, DbType.String),
                helper.CreateParameter("@RoleId", item.RoleId, DbType.Int32),
                helper.CreateParameter("@EmailId", item.EmailId, DbType.Int32)
            };

            helper.Insert("CreateUser", CommandType.StoredProcedure, parameters);
        }

        public void Delete(int id)
        {
            var parameters = new SqlParameter[]
            {
                helper.CreateParameter("@Id", id, DbType.Int32)
            };

            helper.Delete("DeleteUser", CommandType.StoredProcedure, parameters);
        }

        public IEnumerable<User> GetAll()
        {
            var users = new List<User>();
            using (var connection = new SqlConnection(helper.GetConnectionString()))
            {
                connection.Open();

                using (var command = new SqlCommand("GetUsers", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var user = new User
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Name = reader["Name"].ToString(),
                                Password = reader["Password"].ToString(),
                                RoleId = Convert.ToInt32(reader["RoleId"]),
                                EmailId = Convert.ToInt32(reader["EmailId"])
                            };

                            users.Add(user);
                        }
                    }

                    reader.Close();
                }
            }

            return users;
        }

        public User GetById(int id)
        {
            User user = null;

            var parameters = new List<SqlParameter>
            {
                helper.CreateParameter("@Id", id, DbType.Int32)
            };

            using (var connection = new SqlConnection(helper.GetConnectionString()))
            {
                connection.Open();

                using (var command = new SqlCommand("GetUserById", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        reader.Read();
                        user = new User
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString(),
                            Password = reader["Password"].ToString(),
                            RoleId = Convert.ToInt32(reader["RoleId"]),
                            EmailId = Convert.ToInt32(reader["EmailId"])
                        };
                    }

                    reader.Close();
                }
            }

            return user;
        }

        public void Update(User item)
        {
            var parameters = new SqlParameter[]
            {
                helper.CreateParameter("@Id", item.Id, DbType.Int32),
                helper.CreateParameter("@Name", item.Name, DbType.String),
                helper.CreateParameter("@Password", item.Password, DbType.String),
                helper.CreateParameter("@RoleId", item.RoleId, DbType.Int32),
                helper.CreateParameter("@EmailId", item.EmailId, DbType.Int32),
            };

            helper.Update("UpdateUser", CommandType.StoredProcedure, parameters);
        }
    }
}
