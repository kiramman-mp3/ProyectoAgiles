﻿using ApiREST_UTA.Application.DTOs;
using ApiREST_UTA.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiREST_UTA.API.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            var result = _authService.Autenticar(request);
            if (result == null)
                return Unauthorized(new { mensaje = "Credenciales inválidas" });

            return Ok(result);
        }
    }
}
