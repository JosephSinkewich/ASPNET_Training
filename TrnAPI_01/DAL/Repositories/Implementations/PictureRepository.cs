using Common.Model;
using DAL.Helpers;
using DAL.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAL.Repositories.Implementations
{
    public class PictureRepository : IPictureRepository
    {

        private ISQLHelper helper;

        public PictureRepository(ISQLHelper helper)
        {
            this.helper = helper;
        }

        public void Create(Picture item)
        {
            var parameters = new List<SqlParameter>
            {
                helper.CreateParameter("@Path", item.Path, DbType.String)
            };

            helper.Insert("CreatePicture", CommandType.StoredProcedure, parameters.ToArray());
        }

        public void Delete(int id)
        {
            var parameters = new List<SqlParameter>
            {
                helper.CreateParameter("@id", id, DbType.Int32)
            };

            helper.Delete("DeletePicture", CommandType.StoredProcedure, parameters.ToArray());
        }

        public IEnumerable<Picture> GetAll()
        {
            var pictureDataTable = helper.GetDataTable("GetPictures", CommandType.StoredProcedure);
            var pictures = new List<Picture>();

            foreach (DataRow row in pictureDataTable.Rows)
            {
                var picture = new Picture
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Path = row["Path"].ToString()
                };

                pictures.Add(picture);
            }

            return pictures;
        }

        public Picture GetById(int id)
        {
            var parameters = new List<SqlParameter>
            {
                helper.CreateParameter("@Id", id, DbType.Int32)
            };

            var picureDataTable = helper.GetDataTable("GetPicureById", CommandType.StoredProcedure, parameters.ToArray());
            var picures = new List<Picture>();

            //make 1 return point
            if (picureDataTable.Rows.Count == 0)
            {
                return null;
            }

            var picure = new Picture
            {
                Id = Convert.ToInt32(picureDataTable.Rows[0]["Id"]),
                Path = picureDataTable.Rows[0]["Path"].ToString()
            };

            return picure;
        }

        public void Update(Picture item)
        {
            var parameters = new List<SqlParameter>
            {
                helper.CreateParameter("@Id", item.Id, DbType.Int32),
                helper.CreateParameter("@Path", item.Path, DbType.String)
            };

            helper.Update("UpdatePicture", CommandType.StoredProcedure, parameters.ToArray());
        }
    }
}
