using Common.Model;
using DAL.Helpers;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL.Repositories.Implementations
{
    public class EmailRepository : IEmailRepository
    {

        private ISQLHelper helper;

        public EmailRepository(ISQLHelper helper)
        {
            this.helper = helper;
        }

        public void Create(Email item)
        {
            var parameters = new List<SqlParameter>
            {
                helper.CreateParameter("@Adress", item.Address, DbType.String)
            };

            helper.Insert("CreateEmail", CommandType.StoredProcedure, parameters.ToArray());
        }

        public void Delete(int id)
        {
            var parameters = new List<SqlParameter>
            {
                helper.CreateParameter("@Id", id, DbType.Int32)
            };

            helper.Delete("DeleteEmail", CommandType.StoredProcedure, parameters.ToArray());
        }

        public IEnumerable<Email> GetAll()
        {
            var emails = new List<Email>();
            using (var connection = new SqlConnection(helper.GetConnectionString()))
            {
                connection.Open();

                using (var command = new SqlCommand("GetEmails", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var email = new Email
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Address = reader["Address"].ToString()
                            };

                            emails.Add(email);
                        }
                    }

                    reader.Close();
                }
            }

            return emails;
        }

        public Email GetById(int id)
        {
            Email email = null;

            var parameters = new List<SqlParameter>
            {
                helper.CreateParameter("@Id", id, DbType.Int32)
            };

            using (var connection = new SqlConnection(helper.GetConnectionString()))
            {
                connection.Open();

                using (var command = new SqlCommand("GetEmailById", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        reader.Read();
                        email = new Email
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Address = reader["Address"].ToString()
                        };
                    }

                    reader.Close();
                }
            }

            return email;
        }

        public void Update(Email item)
        {
            var parameters = new List<SqlParameter>
            {
                helper.CreateParameter("@Id", item.Id, DbType.Int32),
                helper.CreateParameter("@Address", item.Address, DbType.String)
            };

            helper.Update("UpdateEmail", CommandType.StoredProcedure, parameters.ToArray());
        }
    }
}
