using Common.Model;
using DAL.Helpers;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL.Repositories.Implementations
{
    public class RoleRepository : IRoleRepository
    {
        private ISQLHelper helper;

        public RoleRepository(ISQLHelper helper)
        {
            this.helper = helper;
        }

        public void Create(Role item)
        {
            var parameters = new List<SqlParameter>
            {
                helper.CreateParameter("@Name", item.Name, DbType.String)
            };

            helper.Insert("CreateRole", CommandType.StoredProcedure, parameters.ToArray());
        }

        public void Delete(int id)
        {
            var parameters = new SqlParameter[]
            {
                helper.CreateParameter("@Id", id, DbType.Int32)
            };

            helper.Delete("DeleteRole", CommandType.StoredProcedure, parameters);
        }

        public IEnumerable<Role> GetAll()
        {
            var roles = new List<Role>();
            using (var connection = new SqlConnection(helper.GetConnectionString()))
            {
                connection.Open();

                using (var command = new SqlCommand("GetRoles", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var role = new Role
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Name = reader["Name"].ToString()
                            };

                            roles.Add(role);
                        }
                    }

                    reader.Close();
                }
            }

            return roles;
        }

        public Role GetById(int id)
        {
            Role role = null;

            var parameters = new List<SqlParameter>
            {
                helper.CreateParameter("@Id", id, DbType.Int32)
            };

            using (var connection = new SqlConnection(helper.GetConnectionString()))
            {
                connection.Open();

                using (var command = new SqlCommand("GetRoleById", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddRange(parameters.ToArray());
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        reader.Read();
                        role = new Role
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString(),
                        };
                    }

                    reader.Close();
                }
            }

            return role;
        }

        public void Update(Role item)
        {
            var parameters = new SqlParameter[]
            {
                helper.CreateParameter("@Id", item.Id, DbType.Int32),
                helper.CreateParameter("@Name", item.Name, DbType.String)
            };

            helper.Update("UpdateRole", CommandType.StoredProcedure, parameters);
        }
    }
}
