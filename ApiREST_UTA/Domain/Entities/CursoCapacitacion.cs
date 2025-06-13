namespace ApiREST_UTA.Domain.Entities
{
    public class CursoCapacitacion
    {
        public string Cedula { get; set; }
        public string Universidad { get; set; }
        public string Facultad { get; set; }
        public DateTime FechaEvaluacion { get; set; }
        public decimal Puntaje { get; set; }
    }
}
