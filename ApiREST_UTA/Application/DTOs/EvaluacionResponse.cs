namespace ApiREST_UTA.Application.DTOs
{
    public class EvaluacionResponse
    {
        public string Cedula { get; set; }
        public DateTime Periodo { get; set; }
        public string Universidad { get; set; }
        public string Carrera { get; set; }
        public decimal Puntaje { get; set; }
        public string PdfBase64 { get; set; }
    }
}
