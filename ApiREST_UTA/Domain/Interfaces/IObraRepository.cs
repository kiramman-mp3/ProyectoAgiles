using ApiREST_UTA.Application.DTOs;
using ApiREST_UTA.Domain.Entities;

namespace ApiREST_UTA.Domain.Interfaces
{
    public interface IObraRepository
    {
        Task<IEnumerable<ObraResponse>> GetObrasPorCedulaAsync(string cedula, DateTime fechaInicio);
    }
}
