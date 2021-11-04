using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelerikBlazorGrid_Dapper.DataAccess
{
    public class SqlDataAccess : IDataAccess
    {
        private readonly string _connectionString;

        public SqlDataAccess(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<List<T>> LoadData<T, U>(string storedProcedure, U parameters)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                var rows = await connection.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);

                return rows.ToList();
            }
        }

        public async Task<List<T>> LoadDataQuery<T, U>(string query, U parameters)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                var rows = await connection.QueryAsync<T>(query, parameters, commandType: CommandType.Text);

                return rows.ToList();
            }
        }

        public async Task<T> LoadFirst<T, U>(string storedProcedure, U parameters)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                var result = await connection.ExecuteScalarAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);

                return result;
            }
        }

        public async Task<T> LoadFirstQuery<T, U>(string query, U parameters)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                var result = await connection.ExecuteScalarAsync<T>(query, parameters, commandType: CommandType.Text);

                return result;
            }
        }

        public async Task SaveData<T>(string storedProcedure, T parameters)
        {
            using (IDbConnection connection = new SqlConnection(_connectionString))
            {
                await connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
