namespace PlataformasPagos.CaptarPagos
{
    public class Vencimiento
    {
        public string vencimiento1 { get; set; }
        public string vencimientoPorcentaje1 { get; set; }
        public string vencimiento2 { get; set; }
        public string vencimientoPorcentaje2 { get; set; }
        public string vencimiento3 { get; set; }
        public string vencimientoPorcentaje3 { get; set; }

        public Vencimiento()
        {
            this.vencimiento1 = "0";
            this.vencimientoPorcentaje1 = "0"; 
            this.vencimiento2 = "0";
            this.vencimientoPorcentaje2 = "0";
            this.vencimiento3 = "0";
            this.vencimientoPorcentaje3 = "0";
        }
        public Vencimiento(string cantDias, string porcentaje)
        {
            this.vencimiento1 = cantDias;
            this.vencimientoPorcentaje1 = porcentaje;
            this.vencimiento2 = "0";
            this.vencimientoPorcentaje2 = "0";
            this.vencimiento3 = "0";
            this.vencimientoPorcentaje3 = "0";
        }
    }
}
