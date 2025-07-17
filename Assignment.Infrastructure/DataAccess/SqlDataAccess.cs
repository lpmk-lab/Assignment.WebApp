using Microsoft.Extensions.Configuration;
using Dapper;
using System.Data;
using Microsoft.Data.SqlClient;
using Assignment.Application.Common.Interface.Persistence;

namespace Assignment.Infrastructure.DataAccess
{
    public class SqlDataAccess: ISqlDataAccess
    {
        private readonly IConfiguration _config;

        public SqlDataAccess(IConfiguration config)
        {
            _config = config;
        }

        public async Task<IEnumerable<T>> GetData<T,P>(string spName,P parameters,string connectionId = "Connection")
        {
            using IDbConnection connection =new SqlConnection(_config.GetConnectionString(connectionId));
            return await connection.QueryAsync<T>(spName,parameters,commandType:CommandType.StoredProcedure);

        }

        public async Task SaveData<T>(string spName,T parameters, string connectionId = "Connection")
        {
            using IDbConnection connection = new SqlConnection(_config.GetConnectionString(connectionId));
            await  connection.ExecuteAsync(spName, parameters, commandType: CommandType.StoredProcedure);
        }

    }
}
