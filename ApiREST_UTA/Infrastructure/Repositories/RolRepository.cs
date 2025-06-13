using ApiREST_UTA.Domain.Entities;
using ApiREST_UTA.Domain.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace ApiREST_UTA.Infrastructure.Repositories
{
    public class RolRepository : IRolRepository
    {
        private readonly string _connectionString;

        public RolRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("RRHHConnection")!;
        }

        public async Task<Rol> ObtenerSiguienteRol(int rolActualId)
        {
            using var connection = new SqlConnection(_connectionString);
            var command = new SqlCommand(@"
            SELECT TOP 1 Id, Nombre, RequiereAniosEnRol, RequiereObras, RequiereEvaluacion, 
                         RequiereCapacitacionHoras, RequiereInvestigacionMeses
            FROM Roles
            WHERE Id > @rolActualId
            ORDER BY Id ASC", connection);

            command.Parameters.AddWithValue("@rolActualId", rolActualId);

            await connection.OpenAsync();
            using var reader = await command.ExecuteReaderAsync();

            if (!reader.HasRows)
                throw new Exception("No hay rol siguiente disponible");

            await reader.ReadAsync();

            return new Rol
            {
                Id = Convert.ToInt32(reader["Id"]),
                Nombre = reader["Nombre"].ToString()!,
                RequiereAniosEnRol = Convert.ToInt32(reader["RequiereAniosEnRol"]),
                RequiereObras = Convert.ToInt32(reader["RequiereObras"]),
                RequiereEvaluacion = Convert.ToDecimal(reader["RequiereEvaluacion"]),
                RequiereCapacitacionHoras = Convert.ToInt32(reader["RequiereCapacitacionHoras"]),
                RequiereInvestigacionMeses = Convert.ToInt32(reader["RequiereInvestigacionMeses"])
            };
        }
    }
}