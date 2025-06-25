using ApiREST_UTA.Domain.Interfaces;
using Microsoft.Data.SqlClient;

namespace ApiREST_UTA.Infrastructure.Repositories
{
    public class ObraIdiomaRepository : IObraIdiomaRepository
    {
        private readonly string _connectionString;

        public ObraIdiomaRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DIDEConnection")!;
        }

        public async Task<bool> TieneObraEnIdiomaExtranjero(string cedula)
        {
            using var connection = new SqlConnection(_connectionString);
            var command = new SqlCommand(@"
                SELECT COUNT(*) FROM Obras
                WHERE Cedula = @cedula AND Idioma <> 'Español'", connection);

            command.Parameters.AddWithValue("@cedula", cedula);

            await connection.OpenAsync();
            var result = await command.ExecuteScalarAsync();
            return Convert.ToInt32(result) > 0;
        }
    }
}
