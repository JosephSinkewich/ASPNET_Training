using Common.Model;
using DAL.Helpers;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL.Repositories.Implementations
{
    public class RecordRepository : IRecordRepository
    {

        private ISQLHelper helper;

        public RecordRepository(ISQLHelper helper)
        {
            this.helper = helper;
        }

        public void Create(Record item)
        {
            var parameters = new List<SqlParameter>
            {
                helper.CreateParameter("@Name", item.Name, DbType.String),
                helper.CreateParameter("@CreateDate", item.CreateDate, DbType.DateTime),
                helper.CreateParameter("@Description", item.Description, DbType.String),
                helper.CreateParameter("@CategoryId", item.CategoryId, DbType.Int32),
            };

            helper.Insert("CreateRecord", CommandType.StoredProcedure, parameters.ToArray());
        }

        public void Delete(int id)
        {
            var parameters = new List<SqlParameter>
            {
                helper.CreateParameter("@id", id, DbType.Int32)
            };

            helper.Delete("DeleteRecord", CommandType.StoredProcedure, parameters.ToArray());
        }

        public IEnumerable<Record> GetAll()
        {
            var records = new List<Record>();
            using (var connection = new SqlConnection(helper.GetConnectionString()))
            {
                connection.Open();

                using (var command = new SqlCommand("GetRecords", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var record = new Record
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Name = reader["Name"].ToString(),
                                CreateDate = Convert.ToDateTime(reader["CreateDate"]),
                                Description = reader["Description"].ToString(),
                                CategoryId = Convert.ToInt32(reader["CategoryId"]),
                                PictureId = Convert.ToInt32(reader["PictureId"])
                            };

                            records.Add(record);
                        }
                    }

                    reader.Close();
                }
            }

            return records;
        }

        public Record GetById(int id)
        {
            Record record = null;

            var parameters = new List<SqlParameter>
            {
                helper.CreateParameter("@Id", id, DbType.Int32)
            };

            using (var connection = new SqlConnection(helper.GetConnectionString()))
            {
                connection.Open();

                using (var command = new SqlCommand("GetRecordById", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        reader.Read();
                        record = new Record
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString(),
                            CreateDate = Convert.ToDateTime(reader["CreateDate"]),
                            Description = reader["Description"].ToString(),
                            CategoryId = Convert.ToInt32(reader["CategoryId"]),
                            PictureId = Convert.ToInt32(reader["PictureId"])
                        };
                    }

                    reader.Close();
                }
            }

            return record;
        }

        public IEnumerable<Record> GetRecordsByCategoryId(int categoryId)
        {
            var records = new List<Record>();
            using (var connection = new SqlConnection(helper.GetConnectionString()))
            {
                connection.Open();

                using (var command = new SqlCommand("GetRecordsByCategoryId", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var record = new Record
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Name = reader["Name"].ToString(),
                                CreateDate = Convert.ToDateTime(reader["CreateDate"]),
                                Description = reader["Description"].ToString(),
                                CategoryId = Convert.ToInt32(reader["CategoryId"]),
                                PictureId = Convert.ToInt32(reader["PictureId"])
                            };

                            records.Add(record);
                        }
                    }

                    reader.Close();
                }
            }

            return records;
        }

        public void Update(Record item)
        {
            var parameters = new List<SqlParameter>
            {
                helper.CreateParameter("@Id", item.Id, DbType.Int32),
                helper.CreateParameter("@Name", item.Name, DbType.String),
                helper.CreateParameter("@CreateDate", item.CreateDate, DbType.DateTime),
                helper.CreateParameter("@Description", item.Description, DbType.String),
                helper.CreateParameter("@CategoryId", item.CategoryId, DbType.Int32),
                helper.CreateParameter("@PictureId", item.PictureId, DbType.Int32)
            };

            helper.Update("UpdateRecord", CommandType.StoredProcedure, parameters.ToArray());
        }
    }
}
