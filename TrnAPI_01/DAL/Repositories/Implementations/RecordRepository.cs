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
            var pictureDataTable = helper.GetDataTable("GetRecords", CommandType.StoredProcedure);
            var records = new List<Record>();

            foreach (DataRow row in pictureDataTable.Rows)
            {
                var record = new Record
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Name = row["Name"].ToString(),
                    CreateDate = Convert.ToDateTime(row["CreateDate"]),
                    Description = row["Description"].ToString(),
                    CategoryId = Convert.ToInt32(row["CategoryId"]),
                    PictureId = Convert.ToInt32(row["PictureId"])
                };

                records.Add(record);
            }

            return records;
        }

        public Record GetById(int id)
        {
            var parameters = new List<SqlParameter>
            {
                helper.CreateParameter("@Id", id, DbType.Int32)
            };

            var recordDataTable = helper.GetDataTable("GetRecordById", CommandType.StoredProcedure, parameters.ToArray());
            var records = new List<Record>();

            //make 1 return point
            if (recordDataTable.Rows.Count == 0)
            {
                return null;
            }

            var record = new Record
            {
                Id = Convert.ToInt32(recordDataTable.Rows[0]["Id"]),
                Name = recordDataTable.Rows[0]["Name"].ToString(),
                CreateDate = Convert.ToDateTime(recordDataTable.Rows[0]["CreateDate"]),
                Description = recordDataTable.Rows[0]["Description"].ToString(),
                CategoryId = Convert.ToInt32(recordDataTable.Rows[0]["CategoryId"]),
                PictureId = Convert.ToInt32(recordDataTable.Rows[0]["PictureId"])
            };

            return record;
        }

        public IEnumerable<Record> GetRecordsByCategoryId(int categoryId)
        {
            var recordDataTable = helper.GetDataTable("GetRecords", CommandType.StoredProcedure);
            var records = new List<Record>();

            foreach (DataRow row in recordDataTable.Rows)
            {
                var record = new Record
                {
                    Id = Convert.ToInt32(recordDataTable.Rows[0]["Id"]),
                    Name = recordDataTable.Rows[0]["Name"].ToString(),
                    CreateDate = Convert.ToDateTime(recordDataTable.Rows[0]["CreateDate"]),
                    Description = recordDataTable.Rows[0]["Description"].ToString(),
                    CategoryId = Convert.ToInt32(recordDataTable.Rows[0]["CategoryId"]),
                    PictureId = Convert.ToInt32(recordDataTable.Rows[0]["PictureId"])
                };
                if (record.CategoryId == categoryId)
                {
                    records.Add(record);
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
