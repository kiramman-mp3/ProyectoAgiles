using ApiREST_UTA.Domain.Entities;

namespace ApiREST_UTA.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Usuario? GetByCorreo(string correo);
    }
}
