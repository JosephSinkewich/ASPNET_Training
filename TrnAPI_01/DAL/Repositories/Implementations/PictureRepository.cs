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
            var pictures = new List<Picture>();
            using (var connection = new SqlConnection(helper.GetConnectionString()))
            {
                connection.Open();

                using (var command = new SqlCommand("GetPictures", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var picture = new Picture
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Path = reader["Path"].ToString()
                            };

                            pictures.Add(picture);
                        }
                    }

                    reader.Close();
                }
            }

            return pictures;
        }

        public Picture GetById(int id)
        {
            Picture picture = null;

            var parameters = new List<SqlParameter>
            {
                helper.CreateParameter("@Id", id, DbType.Int32)
            };

            using (var connection = new SqlConnection(helper.GetConnectionString()))
            {
                connection.Open();

                using (var command = new SqlCommand("GetPictureById", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        reader.Read();
                        picture = new Picture
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Path = reader["Path"].ToString()
                        };
                    }

                    reader.Close();
                }
            }

            return picture;
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
