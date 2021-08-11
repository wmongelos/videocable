using Newtonsoft.Json;

namespace PlataformasPagos.CaptarPagos
{
    public class CreateBotonRequest
    {
        [JsonProperty("idEntidad")]
        public int IdEntidad { get; set; }
        [JsonProperty("buttons")]
        public Boton[] Buttons { get; set; } 
    }
}
