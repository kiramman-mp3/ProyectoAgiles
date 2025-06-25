namespace ApiREST_UTA.Domain.Interfaces
{
    public interface ITesisRepository
    {
        Task<int> ObtenerTesisPorCedulaAsync(string cedula);
    }

}
