namespace ApiREST_UTA.Application.DTOs
{
    public class RequisitoResponse
    {
        public string RolObjetivo { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        public int RequiereTiempo { get; set; }
        public int RequiereObras { get; set; }
        public decimal RequiereEvaluacion { get; set; }
        public int RequiereCapacitacionHoras { get; set; }
        public int RequiereInvestigacionMeses { get; set; }
    }
}