using AddContact.Server.Infrastructure;
using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace AddContact.Server.Repository
{
    public abstract class RepositoryBase
    {
        readonly IConfig config;

        public RepositoryBase(IConfig config)
        {
            this.config = config;
        }

        protected async Task ExecProc(string procName, DynamicParameters parameters)
        {
            var cnn = GetConnection();
            await cnn.ExecuteAsync(procName, parameters, commandType: CommandType.StoredProcedure);
        }

        protected async Task<T> ExecProcWithFirstResult<T>(string procName, DynamicParameters parameters)
        {
            using (var cnn = GetConnection())
            {
                await cnn.OpenAsync();
                var result = await cnn.QueryFirstOrDefaultAsync<T>(procName, parameters, commandType: CommandType.StoredProcedure);
                return result;
            }
        }

        SqlConnection GetConnection()
        {
            var result = new SqlConnection(config.ConnectionString);
            return result;
        }
    }
}
