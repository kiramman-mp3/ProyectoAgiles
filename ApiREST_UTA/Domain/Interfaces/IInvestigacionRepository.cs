using ApiREST_UTA.Domain.Entities;

namespace ApiREST_UTA.Domain.Interfaces
{
    public interface IInvestigacionRepository
    {
        Task<List<Investigacion>> ObtenerInvestigacionesPorCedula(string cedula);
    }
}
