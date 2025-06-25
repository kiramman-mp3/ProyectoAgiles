using ApiREST_UTA.Domain.Interfaces;
using Microsoft.Data.SqlClient;

namespace ApiREST_UTA.Infrastructure.Repositories
{
    public class CapacitacionImpartidaRepository : ICapacitacionImpartidaRepository
    {
        private readonly string _connectionString;

        public CapacitacionImpartidaRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DEaDVConnection")!;
        }

        public async Task<int> ObtenerHorasImpartidasAsync(string cedula)
        {
            using var connection = new SqlConnection(_connectionString);
            var command = new SqlCommand("SELECT SUM(Horas) FROM CapacitacionImpartida WHERE Cedula = @cedula", connection);
            command.Parameters.AddWithValue("@cedula", cedula);

            await connection.OpenAsync();
            var result = await command.ExecuteScalarAsync();
            return result == DBNull.Value ? 0 : Convert.ToInt32(result);
        }
    }
}
