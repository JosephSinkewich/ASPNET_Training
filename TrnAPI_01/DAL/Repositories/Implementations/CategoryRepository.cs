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
            var categoryDataTable = helper.GetDataTable("GetCategories", CommandType.StoredProcedure);
            var categories = new List<Category>();

            foreach (DataRow row in categoryDataTable.Rows)
            {
                var category = new Category
                {
                    Id = Convert.ToInt32(row["Id"]),
                    Name = row["Name"].ToString()
                };

                categories.Add(category);
            }

            return categories;
        }

        public Category GetById(int id)
        {
            var parameters = new List<SqlParameter>
            {
                helper.CreateParameter("@Id", id, DbType.Int32)
            };

            var categoryDataTable = helper.GetDataTable("GetCategoryById", CommandType.StoredProcedure, parameters.ToArray());
            var categories = new List<Category>();

            //make 1 return point
            if (categoryDataTable.Rows.Count == 0)
            {
                return null;
            }

            var category = new Category
            {
                Id = Convert.ToInt32(categoryDataTable.Rows[0]["Id"]),
                Name = categoryDataTable.Rows[0]["Name"].ToString()
            };

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
