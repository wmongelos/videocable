using Newtonsoft.Json;

namespace PlataformasPagos.CaptarPagos
{

    public class BotonResponse
    {
        [JsonProperty("code")]
        public int Code { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("data")]
        public Data[] Data { get; set; }
    }

    public class Data
    {
        [JsonProperty("clientId")]
        public string ClientId { get; set; }
        [JsonProperty("record")]
        public Record Record { get; set; }
    }

    public class Record
    {
        [JsonProperty("idPago")]
        public int IdPago { get; set; }
        [JsonProperty("estadoEmail")]
        public string EstadoEmail { get; set; }
        [JsonProperty("estadoWhatsapp")]
        public string EstadoWhatsapp { get; set; }
        [JsonProperty("link")]
        public string Link { get; set; }
        [JsonProperty("codigoBarrasOpciones")]
        public Codigobarrasopciones[] CodigoBarrasOpciones { get; set; }
        [JsonProperty("code")]
        public int Code { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
    }

    public class Codigobarrasopciones
    {
        [JsonProperty("barcode")]
        public string Barcode { get; set; }
        [JsonProperty("factura")]
        public string Factura { get; set; }
    }
}