using Newtonsoft.Json;
namespace PlataformasPagos.CaptarPagos
{
    public class ReporteRequestById
    {
        [JsonProperty("idEntidad")]
        public int IdEntidad { get; set; }
        [JsonProperty("idCliente")]
        public int IdCliente { get; set; }
        [JsonProperty("idContrato")]
        public int IdContrato { get; set; }

    }
}
