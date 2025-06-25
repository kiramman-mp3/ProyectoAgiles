using ApiREST_UTA.Domain.Interfaces;
using Microsoft.Data.SqlClient;

namespace ApiREST_UTA.Infrastructure.Repositories
{
    public class ProyectoPonderadoRepository : IProyectoPonderadoRepository
    {
        private readonly string _connectionString;

        public ProyectoPonderadoRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DIDEConnection")!;
        }

        public async Task<int> ObtenerMesesPonderadosAsync(string cedula)
        {
            using var connection = new SqlConnection(_connectionString);
            var command = new SqlCommand(@"
                SELECT Rol, MesesParticipacion FROM ParticipacionProyecto
                WHERE Cedula = @cedula", connection);

            command.Parameters.AddWithValue("@cedula", cedula);

            await connection.OpenAsync();
            using var reader = await command.ExecuteReaderAsync();

            int totalMeses = 0;

            while (await reader.ReadAsync())
            {
                string rol = reader["Rol"].ToString()!;
                int meses = Convert.ToInt32(reader["MesesParticipacion"]);

                totalMeses += rol switch
                {
                    "CoordinadorPrincipal" => meses * 2,
                    "CoordinadorSubrogante" => (int)(meses * 1.5),
                    _ => meses // Investigador normal
                };
            }

            return totalMeses;
        }
    }
}
