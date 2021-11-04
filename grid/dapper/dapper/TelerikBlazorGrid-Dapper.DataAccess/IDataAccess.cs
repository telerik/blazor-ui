using System.Collections.Generic;
using System.Threading.Tasks;

namespace TelerikBlazorGrid_Dapper.DataAccess
{
    public interface IDataAccess
    {
        Task<List<T>> LoadData<T, U>(string storedProcedure, U parameters);
        Task<List<T>> LoadDataQuery<T, U>(string query, U parameters);
        Task<T> LoadFirst<T, U>(string storedProcedure, U parameters);
        Task<T> LoadFirstQuery<T, U>(string query, U parameters);
        Task SaveData<T>(string storedProcedure, T parameters);
    }
}