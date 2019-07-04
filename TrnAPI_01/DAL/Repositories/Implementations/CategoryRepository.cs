using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Common.Model;
using DAL.Helpers;
using DAL.Repositories.Interfaces;

namespace DAL.Repositories.Implementations
{
    public class CategoryRepository : ICategoryRepository
    {
        private ISQLHelper helper;

        public CategoryRepository(ISQLHelper helper)
        {
            this.helper = helper;
        }

        public void Create(Category item)
        {
            var parameters = new List<SqlParameter>
            {
                helper.CreateParameter("@Name", item.Name, DbType.String)
            };

            helper.Insert("CreateCategory", CommandType.StoredProcedure, parameters.ToArray());
        }

        public void Delete(int id)
        {
            var parameters = new List<SqlParameter>
            {
                helper.CreateParameter("@Id", id, DbType.Int32)
            };

            helper.Delete("DeleteCategory", CommandType.StoredProcedure, parameters.ToArray());
        }

        public IEnumerable<Category> GetAll()
        {
            var categories = new List<Category>();
            using (var connection = new SqlConnection(helper.GetConnectionString()))
            {
                connection.Open();

                using (var command = new SqlCommand("GetCategories", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            var category = new Category
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Name = reader["Name"].ToString()
                            };

                            categories.Add(category);
                        }
                    }

                    reader.Close();
                }
            }

            return categories;
        }

        public Category GetById(int id)
        {
            Category category = null;

            var parameters = new List<SqlParameter>
            {
                helper.CreateParameter("@Id", id, DbType.Int32)
            };

            using (var connection = new SqlConnection(helper.GetConnectionString()))
            {
                connection.Open();

                using (var command = new SqlCommand("GetCategoryById", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddRange(parameters.ToArray());
                    SqlDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        reader.Read();
                        category = new Category
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            Name = reader["Name"].ToString()
                        };
                    }

                    reader.Close();
                }
            }

            return category;
        }

        public void Update(Category item)
        {
            var parameters = new List<SqlParameter>
            {
                helper.CreateParameter("@Id", item.Id, DbType.Int32),
                helper.CreateParameter("@Name", item.Name, DbType.String)
            };

            helper.Update("UpdateCategory", CommandType.StoredProcedure, parameters.ToArray());
        }
    }
}
