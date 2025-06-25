using ApiREST_UTA.Application.DTOs;
using ApiREST_UTA.Domain.Interfaces;

namespace ApiREST_UTA.Application.Services
{
    public class ObraIdiomaService
    {
        private readonly IObraIdiomaRepository _repo;

        public ObraIdiomaService(IObraIdiomaRepository repo)
        {
            _repo = repo;
        }

        public async Task<ObraIdiomaResponse> VerificarObraIdiomaExtranjero(string cedula)
        {
            var tiene = await _repo.TieneObraEnIdiomaExtranjero(cedula);

            return new ObraIdiomaResponse
            {
                Cedula = cedula,
                TieneObraEnOtroIdioma = tiene
            };
        }
    }
}
