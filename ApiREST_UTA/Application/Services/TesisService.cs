using ApiREST_UTA.Application.DTOs;
using ApiREST_UTA.Domain.Interfaces;

namespace ApiREST_UTA.Application.Services
{
    public class TesisService
    {
        private readonly ITesisRepository _repo;

        public TesisService(ITesisRepository repo)
        {
            _repo = repo;
        }

        public async Task<TesisDoctoradoResponse> ObtenerTesisPorCedula(string cedula)
        {
            var cantidad = await _repo.ObtenerTesisPorCedulaAsync(cedula);

            return new TesisDoctoradoResponse
            {
                Cedula = cedula,
                Cantidad = cantidad
            };
        }
    }
}
