using ApiREST_UTA.Application.DTOs;
using ApiREST_UTA.Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiREST_UTA.API.Controllers
{
    [Route("api/promocion")]
    [ApiController]
    [Authorize]
    public class PromocionController : ControllerBase
    {
        private readonly PromocionService _promocionService;

        public PromocionController(PromocionService promocionService)
        {
            _promocionService = promocionService;
        }

        [HttpPost("requisitos")]
        public async Task<IActionResult> ObtenerRequisitos([FromBody] RequisitoRequest request)
        {
            var requisitos = await _promocionService.ObtenerRequisitosParaPromocion(request);
            return Ok(requisitos);
        }
    }
}
