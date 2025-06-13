using ApiREST_UTA.Application.DTOs;
using ApiREST_UTA.Domain.Interfaces;

namespace ApiREST_UTA.Application.Services
{
    public class PromocionService
    {
        private readonly IRolRepository _rolRepository;

        public PromocionService(IRolRepository rolRepository)
        {
            _rolRepository = rolRepository;
        }

        public async Task<RequisitoResponse> ObtenerRequisitosParaPromocion(RequisitoRequest request)
        {
            var siguienteRol = await _rolRepository.ObtenerSiguienteRol(request.RolActualId);

            return new RequisitoResponse
            {
                RolObjetivo = siguienteRol.Nombre,
                Descripcion = $"Para aplicar a {siguienteRol.Nombre} se requiere:",
                RequiereTiempo = siguienteRol.RequiereAniosEnRol,
                RequiereObras = siguienteRol.RequiereObras,
                RequiereEvaluacion = siguienteRol.RequiereEvaluacion,
                RequiereCapacitacionHoras = siguienteRol.RequiereCapacitacionHoras,
                RequiereInvestigacionMeses = siguienteRol.RequiereInvestigacionMeses
            };
        }
    }
}