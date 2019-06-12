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
            var userDataTable = helper.GetDataTable("GetUsers", CommandType.StoredProcedure);
            var users = new List<User>();

            foreach (DataRow row in userDataTable.Rows)
            {
                var user = new User
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Name = row["Name"].ToString(),
                    Password = row["Password"].ToString(),
                    RoleId = Convert.ToInt32(row["RoleId"]),
                    EmailId = Convert.ToInt32(row["EmailId"]),
                };

                users.Add(user);
            }

            return users;
        }

        public User GetById(int id)
        {
            var parameters = new SqlParameter[]
            {
                helper.CreateParameter("@Id", id, DbType.Int32)
            };

            var userDataTable = helper.GetDataTable("GetUserById", CommandType.StoredProcedure, parameters);
            var users = new List<User>();

            //make 1 return point
            if (userDataTable.Rows.Count == 0)
            {
                return null;
            }

            var user = new User
            {
                Id = Convert.ToInt32(userDataTable.Rows[0]["Id"]),
                Name = userDataTable.Rows[0]["Name"].ToString(),
                Password = userDataTable.Rows[0]["Password"].ToString(),
                RoleId = Convert.ToInt32(userDataTable.Rows[0]["RoleId"]),
                EmailId = Convert.ToInt32(userDataTable.Rows[0]["EmailId"])
            };

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
