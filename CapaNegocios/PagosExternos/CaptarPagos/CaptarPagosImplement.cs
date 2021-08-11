using CapaDatos;
using PlataformasPagos.CaptarPagos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace CapaNegocios.PagosExternos.CaptarPagos
{
    public class CaptarPagosImplement
    {
        private int IdEntidad;
        private string Hash;
        private Conexion oCon = new Conexion();
        private ConfiguracionPagos oConFig = new ConfiguracionPagos();

        public void SetEntidad()
        {
            this.IdEntidad =(int) oConFig.Get("idEntidad",(int)PagoExterno.Plataforma.CAPTARPAGOS, TypeCode.Int32);

        }

        public void SetHash()
        {
            this.Hash = (string)oConFig.Get("hash", (int)PagoExterno.Plataforma.CAPTARPAGOS, TypeCode.String);
        }

        public async Task<DataReport[]> ListarBotonesAsync (DateTime desde, DateTime hasta, global::PlataformasPagos.CaptarPagos.CaptarPagos.TipoBusqueda tipoBusquedad)
        {
            global::PlataformasPagos.CaptarPagos.CaptarPagos.BaseAdress = new Uri("https://backend.captarpagos.com/api/ws/");
            global::PlataformasPagos.CaptarPagos.CaptarPagos.Hash = this.Hash;
            global::PlataformasPagos.CaptarPagos.CaptarPagos.IdEntidad = this.IdEntidad;
            DataReport[] resultado = await global::PlataformasPagos.CaptarPagos.CaptarPagos.ListarBotones(desde, hasta, tipoBusquedad);
            return resultado;
        }

        public async Task<List<BotonResponse>> CrearBotonesAsync(Usuarios_CtaCte oUCC, string mail)
        {
            //UCC = usuario cuenta corriente
            global::PlataformasPagos.CaptarPagos.CaptarPagos.BaseAdress = new Uri("https://backend.captarpagos.com/api/ws/");
            global::PlataformasPagos.CaptarPagos.CaptarPagos.Hash = this.Hash;
            global::PlataformasPagos.CaptarPagos.CaptarPagos.IdEntidad = this.IdEntidad;

            CreateBotonRequest oReq = new CreateBotonRequest();
            Boton oBoton = new Boton(Usuarios.CurrentUsuario.Apellido + ", " + Usuarios.CurrentUsuario.Nombre,oUCC.Id_Usuarios.ToString(), oUCC.Importe_Saldo, oUCC.Descripcion,new Vencimiento(),new string[3],mail, "",new Deposito[0]);
            List<BotonResponse> resultado = await global::PlataformasPagos.CaptarPagos.CaptarPagos.GenerarBotonAsync(oBoton);
            return resultado;
        }


    }
}
