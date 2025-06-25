using ApiREST_UTA.Application.Services;
using ApiREST_UTA.Domain.Interfaces;
using ApiREST_UTA.Domain.Interfaces.ApiREST_UTA.Domain.Interfaces;
using ApiREST_UTA.Infrastructure.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ApiREST_UTA
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // JWT key desde appsettings.json
            var jwtKey = builder.Configuration["Jwt:Key"];
            if (string.IsNullOrWhiteSpace(jwtKey))
                throw new Exception("JWT Key no configurada correctamente en appsettings.json");

            var keyBytes = Encoding.UTF8.GetBytes(jwtKey);
            var signingKey = new SymmetricSecurityKey(keyBytes);

            // Inyección de dependencias de repositorios
            builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            builder.Services.AddScoped<IRRHHRepository, RRHHRepository>();
            builder.Services.AddScoped<IObraRepository, ObrasRepository>();
            builder.Services.AddScoped<ICursoRepository, CursoRepository>();
            builder.Services.AddScoped<IInvestigacionRepository, InvestigacionRepository>();
            builder.Services.AddScoped<IEvaluacionDocenteRepository, EvaluacionDocenteRepository>();
            builder.Services.AddScoped<IRolRepository, RolRepository>();
            builder.Services.AddScoped<ITesisRepository, TesisRepository>();
            builder.Services.AddScoped<IObraIdiomaRepository, ObraIdiomaRepository>();
            builder.Services.AddScoped<IProyectoPonderadoRepository, ProyectoPonderadoRepository>();
            builder.Services.AddScoped<ICapacitacionImpartidaRepository, CapacitacionImpartidaRepository>();

            // Inyección de servicios
            builder.Services.AddScoped<ObraService>();
            builder.Services.AddScoped<CursoService>();
            builder.Services.AddScoped<InvestigacionService>();
            builder.Services.AddScoped<PromocionService>();
            builder.Services.AddScoped<TesisService>();
            builder.Services.AddScoped<ObraIdiomaService>();
            builder.Services.AddScoped<ProyectoPonderadoService>();
            builder.Services.AddScoped<CapacitacionImpartidaService>();
            builder.Services.AddScoped<AuthService>(sp =>
                new AuthService(sp.GetRequiredService<IUsuarioRepository>(), jwtKey));

            builder.Services.AddControllers();

            // Configuración de JWT Authentication
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = "ApiREST_UTA",
                        ValidateAudience = true,
                        ValidAudience = "ApiREST_UTA",
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = signingKey
                    };
                });

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
