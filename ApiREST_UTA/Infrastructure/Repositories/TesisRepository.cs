using ApiREST_UTA.Domain.Interfaces;
using Microsoft.Data.SqlClient;

namespace ApiREST_UTA.Infrastructure.Repositories
{
    public class TesisRepository : ITesisRepository
    {
        private readonly string _connectionString;

        public TesisRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DACConnection")!;
        }

        public async Task<int> ObtenerTesisPorCedulaAsync(string cedula)
        {
            using var connection = new SqlConnection(_connectionString);
            var command = new SqlCommand("SELECT COUNT(*) FROM TesisDoctorado WHERE Cedula = @cedula", connection);
            command.Parameters.AddWithValue("@cedula", cedula);

            await connection.OpenAsync();
            var result = await command.ExecuteScalarAsync();
            return Convert.ToInt32(result);
        }
    }
}
