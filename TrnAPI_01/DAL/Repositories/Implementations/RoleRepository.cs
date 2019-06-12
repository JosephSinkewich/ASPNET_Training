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

            helper.Insert("CreateCategory", CommandType.StoredProcedure, parameters.ToArray());
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
            var roleDataTable = helper.GetDataTable("GetRoles", CommandType.StoredProcedure);
            var roles = new List<Role>();

            foreach (DataRow row in roleDataTable.Rows)
            {
                var role = new Role
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Name = row["Name"].ToString()
                };

                roles.Add(role);
            }

            return roles;
        }

        public Role GetById(int id)
        {
            var parameters = new SqlParameter[]
            {
                helper.CreateParameter("@Id", id, DbType.Int32)
            };

            var roleDataTable = helper.GetDataTable("GetRoleById", CommandType.StoredProcedure, parameters);
            var roles = new List<Role>();

            //make 1 return point
            if (roleDataTable.Rows.Count == 0)
            {
                return null;
            }

            var role = new Role
            {
                Id = Convert.ToInt32(roleDataTable.Rows[0]["Id"]),
                Name = roleDataTable.Rows[0]["Name"].ToString()
            };

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
