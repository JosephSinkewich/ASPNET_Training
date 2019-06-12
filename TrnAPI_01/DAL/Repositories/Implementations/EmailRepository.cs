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
            var emailDataTable = helper.GetDataTable("GetEmails", CommandType.StoredProcedure);
            var emails = new List<Email>();

            foreach (DataRow row in emailDataTable.Rows)
            {
                var email = new Email
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Address = row["Address"].ToString()
                };

                emails.Add(email);
            }

            return emails;
        }

        public Email GetById(int id)
        {
            var parameters = new List<SqlParameter>
            {
                helper.CreateParameter("@Id", id, DbType.Int32)
            };

            var emailDataTable = helper.GetDataTable("GetEmailById", CommandType.StoredProcedure, parameters.ToArray());
            var emails = new List<Email>();

            //make 1 return point
            if (emailDataTable.Rows.Count == 0)
            {
                return null;
            }

            var email = new Email
            {
                Id = Convert.ToInt32(emailDataTable.Rows[0]["Id"]),
                Address = emailDataTable.Rows[0]["Address"].ToString()
            };

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
