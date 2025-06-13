using ApiREST_UTA.Application.DTOs;
using ApiREST_UTA.Domain.Entities;
using ApiREST_UTA.Domain.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiREST_UTA.Application.Services
{
    public class AuthService
    {
        private readonly IUsuarioRepository _repo;
        private readonly string _jwtKey;

        public AuthService(IUsuarioRepository repo, string jwtKey)
        {
            _repo = repo;
            _jwtKey = jwtKey;
        }

        public LoginResponse? Autenticar(LoginRequest request)
        {
            var usuario = _repo.GetByCorreo(request.Correo);

            if (usuario == null || usuario.Contrasena != request.Contrasena)
                return null;

            var token = GenerarToken(usuario);
            return new LoginResponse
            {
                Token = token,
                NombreCompleto = $"{usuario.Nombre} {usuario.Apellido}",
                Correo = usuario.Correo,
                Rol = usuario.Rol
            };
        }

        private string GenerarToken(Usuario usuario)
        {
            var claveJwt = "a1b2c3d4e5f6g7h8i9j0k1l2m3n4o5p6q7r8s9t0u1v2w3x4y5z6a7b8";

            var claims = new[]
            {
               new Claim(ClaimTypes.NameIdentifier, usuario.Id.ToString()),
               new Claim(ClaimTypes.Name, usuario.Correo),
               new Claim(ClaimTypes.Role, usuario.Rol)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(claveJwt));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "ApiREST_UTA",
                audience: "ApiREST_UTA",
                claims: claims,
                expires: DateTime.UtcNow.AddHours(8),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}