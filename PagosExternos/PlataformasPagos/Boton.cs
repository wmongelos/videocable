using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlataformasPagos.CaptarPagos
{
    public class Boton
    {
        [JsonProperty("nombre")]
        public string Nombre { get; set; }

        [JsonProperty("clienteId")]
        public string ClienteId { get; set; }

        [JsonProperty("importe")]
        public decimal Importe { get; set; }

        [JsonProperty("detalle")]
        public string Detalle { get; set; }

        [JsonProperty("vencimientos")]
        public Vencimiento Vencimientos {get;set;}

        [JsonProperty("mediosDePago")]
        public string[] MediosDePago { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("whastApp")]
        public string WhastApp { get; set; }

        [JsonProperty("depositos")]
        public Deposito[] Depositos { get; set; }

        public Boton(string Nombre, string IdCliente, decimal Importe, string Detalle, Vencimiento Vencimientos, string[] Medios, string Email, string WhastApp, Deposito[] Depositos)
        {
            this.Nombre = Nombre;
            this.ClienteId = IdCliente;
            this.Importe = Importe;
            this.Detalle = Detalle;
            this.Vencimientos = Vencimientos;
            this.MediosDePago = Medios;
            this.Email = Email;
            this.WhastApp = WhastApp;
            this.Depositos = Depositos;
        }
        
    }
}
