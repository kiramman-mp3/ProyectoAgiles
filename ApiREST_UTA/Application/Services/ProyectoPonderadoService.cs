using ApiREST_UTA.Application.DTOs;
using ApiREST_UTA.Domain.Interfaces;

namespace ApiREST_UTA.Application.Services
{
    public class ProyectoPonderadoService
    {
        private readonly IProyectoPonderadoRepository _repo;

        public ProyectoPonderadoService(IProyectoPonderadoRepository repo)
        {
            _repo = repo;
        }

        public async Task<ProyectoPonderadoResponse> ObtenerParticipacionPonderada(string cedula)
        {
            var meses = await _repo.ObtenerMesesPonderadosAsync(cedula);

            return new ProyectoPonderadoResponse
            {
                Cedula = cedula,
                MesesPonderados = meses
            };
        }
    }
}
