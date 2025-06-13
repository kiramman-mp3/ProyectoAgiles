using ApiREST_UTA.Domain.Entities;

namespace ApiREST_UTA.Domain.Interfaces
{
    public interface IRolRepository
    {
        Task<Rol> ObtenerSiguienteRol(int rolActualId);
    }
}
