using Newtonsoft.Json;
using System;

namespace PlataformasPagos.CaptarPagos
{
    public class ReporteRequest
    {
        [JsonProperty("idEntidad")]
        public int IdEntidad { get; set; }
        [JsonProperty("desde")]
        public DateTime Desde { get; set; }
        [JsonProperty("hasta")]
        public DateTime Hasta { get; set; }
        [JsonProperty("tipo")]
        public int Tipo { get; set; }

    }
}
