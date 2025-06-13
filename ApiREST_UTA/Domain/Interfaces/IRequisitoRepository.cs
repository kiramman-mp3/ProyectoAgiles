using ApiREST_UTA.Domain.Entities;

namespace ApiREST_UTA.Domain.Interfaces
{
    public interface IRequisitoRepository
    {
        Task<RequisitoPromocion?> ObtenerRequisitosPorRolAsync(string rolActual);
    }
}
