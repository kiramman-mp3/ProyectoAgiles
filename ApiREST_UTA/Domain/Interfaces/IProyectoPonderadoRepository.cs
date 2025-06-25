namespace ApiREST_UTA.Domain.Interfaces
{
    public interface IProyectoPonderadoRepository
    {
        Task<int> ObtenerMesesPonderadosAsync(string cedula);
    }

}
