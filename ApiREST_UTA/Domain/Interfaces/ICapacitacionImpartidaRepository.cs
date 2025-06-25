namespace ApiREST_UTA.Domain.Interfaces
{
    public interface ICapacitacionImpartidaRepository
    {
        Task<int> ObtenerHorasImpartidasAsync(string cedula);
    }
}
