using Newtonsoft.Json;
using System;

namespace PlataformasPagos.CaptarPagos

{
    public class ReporteReposnse
    {
        [JsonProperty("code")]
        public int Code { get; set; }
        [JsonProperty("status")]
        public string Status { get; set; }
        [JsonProperty("data")]
        public DataReport[] Data { get; set; }
    }
    
    public class DataReport
    {
        [JsonProperty("idPago")]
        public double IdPago { get; set; }
        [JsonProperty("fecha")]
        public DateTime Fecha { get; set; }
        [JsonProperty("detalle")]
        public string Detalle { get; set; }
        [JsonProperty("monto")]
        public decimal Monto { get; set; }
        [JsonProperty("idCliente")]
        public string IdCliente { get; set; }
        [JsonProperty("nombre")]
        public string Nombre { get; set; }
        [JsonProperty("email")]
        public string Email { get; set; }
        [JsonProperty("dni")]
        public string Dni { get; set; }
        [JsonProperty("fecha_cobro")]
        public DateTime FechaCobro { get; set; }
        [JsonProperty("monto_cobrado")]
        public decimal MontoCobrado { get; set; }
        [JsonProperty("diferencia")]
        public int Diferencia { get; set; }
        [JsonProperty("cancelado")]
        public bool Cancelado { get; set; }
        [JsonProperty("link")]
        public string Link { get; set; }

        public DataReport(int idPago, string nombre)
        {
            this.IdPago = idPago;
            this.IdCliente = idPago.ToString();
            this.Nombre = nombre;
        }
    }

}
