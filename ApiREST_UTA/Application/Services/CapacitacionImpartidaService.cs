using ApiREST_UTA.Application.DTOs;
using ApiREST_UTA.Domain.Interfaces;

namespace ApiREST_UTA.Application.Services
{
    public class CapacitacionImpartidaService
    {
        private readonly ICapacitacionImpartidaRepository _repo;

        public CapacitacionImpartidaService(ICapacitacionImpartidaRepository repo)
        {
            _repo = repo;
        }

        public async Task<CapacitacionImpartidaResponse> ObtenerHorasImpartidas(string cedula)
        {
            var horas = await _repo.ObtenerHorasImpartidasAsync(cedula);

            return new CapacitacionImpartidaResponse
            {
                Cedula = cedula,
                HorasImpartidas = horas
            };
        }
    }
}
