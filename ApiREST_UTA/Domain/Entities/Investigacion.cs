namespace ApiREST_UTA.Domain.Entities
{
    public class Investigacion
    {
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Encargado { get; set; }
        public int Horas { get; set; }
        public byte[] Pdf { get; set; }
    }
}