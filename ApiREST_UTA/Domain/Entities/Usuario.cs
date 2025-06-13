namespace ApiREST_UTA.Domain.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Correo { get; set; }
        public string Contrasena { get; set; } // Encriptada
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Rol { get; set; }
    }

}
