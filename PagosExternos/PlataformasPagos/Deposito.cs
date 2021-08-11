namespace PlataformasPagos.CaptarPagos
{
    public class Deposito
    {
        public string Cbu { get; set; }
        public string Cuit { get; set; }
        public string Nombre { get; set; }
        public decimal Importe { get; set; }
        public bool IsComision { get; set; }

        public Deposito()
        {
            this.Cbu = "";
            this.Cuit = "";
            this.Nombre = "";
            this.Importe = 0;
            this.IsComision = false;
        }

        public Deposito(string Cbu, string Cuit, string Nombre, decimal Importe, bool IsComision)
        {
            this.Cbu = Cbu;
            this.Cuit = Cuit;
            this.Nombre = Nombre;
            this.Importe = Importe;
            this.IsComision = IsComision;
        }
    }
    
}
