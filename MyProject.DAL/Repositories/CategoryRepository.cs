﻿using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace MyProject.DAL.Repositories
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(SqlConnection sqlConnection, IDbTransaction dbtransaction) : base(sqlConnection, dbtransaction, "Category")
        {
        }

        public async Task<IEnumerable<Category>> TopFiveCategoryAsync()
        {
            string sql = @"SELECT TOP 5 * FROM Category";
            var results = await _sqlConnection.QueryAsync<Category>(sql,
                transaction: _dbTransaction);
            return results;
        }
    }
}
