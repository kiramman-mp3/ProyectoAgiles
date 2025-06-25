namespace ApiREST_UTA.Domain.Entities
{
    public class ProyectoParticipacion
    {
        public string Cedula { get; set; }
        public string Rol { get; set; } // Investigador, Coordinador, Subrogante
        public int Meses { get; set; }
    }
}
