using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CapaNegocios
{
    public class Comprobantes_Detalle_Impresion
    {
        public int IdComprobanteTipo { get; }
        public string Detalle1 { get; }
        public string Detalle2 { get; }

        private Conexion oCon = new Conexion();

        public void Guardar(int idComprobanteTipo, string detalle1, string detalle2)
        {
            bool modifica = ComprobanteYaCargado(idComprobanteTipo);
            try
            {
                oCon.Conectar();
                if (modifica)
                {
                    oCon.CrearComando($"UPDATE comprobantes_detalle_impresion SET detalle1=@unoDet, detalle2=@dosDet WHERE id_comprobante_tipo = @idCompTipo");
                    oCon.AsignarParametroEntero("@idCompTipo", idComprobanteTipo);
                    oCon.AsignarParametroCadena("@unoDet", detalle1);
                    oCon.AsignarParametroCadena("@dosDet", detalle2);
                    oCon.EjecutarComando();
                    oCon.ConfirmarTransaccion();
                    oCon.DesConectar();
                }
                else
                {
                    string comando = "INSERT INTO comprobantes_detalle_impresion(id_comprobante_tipo, detalle1, detalle2) VALUES (@idCompTipo, @unoDet, @dosDet)";
                    oCon.CrearComando(comando);
                    oCon.AsignarParametroEntero("@idCompTipo", idComprobanteTipo);
                    oCon.AsignarParametroCadena("@unoDet", detalle1);
                    oCon.AsignarParametroCadena("@dosDet", detalle2);
                    oCon.EjecutarComando();
                    oCon.ConfirmarTransaccion();
                    oCon.DesConectar();
                }
            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                throw;
            }
        }

        public DataTable Listar(int idComprobanteTipo = 0)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                if(idComprobanteTipo == 0)
                {
                    oCon.CrearComando("SELECT id_comprobante_tipo, detalle1, detalle2 FROM comprobantes_detalle_impresion");
                }
                else
                {
                    oCon.CrearComando("SELECT id_comprobante_tipo, detalle1, detalle2 FROM comprobantes_detalle_impresion WHERE id_comprobante_tipo = @idCompTipo");
                    oCon.AsignarParametroEntero("@idCompTipo", idComprobanteTipo);
                }
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
            }
            return dt;
        }

        public bool ComprobanteYaCargado(int idComprobanteTipo)
        {
            DataTable dt = new DataTable();
            bool retorno;
            try
            {
                oCon.Conectar();
                oCon.CrearComando("select * from comprobantes_detalle_impresion where id_comprobante_tipo = @idComp");
                oCon.AsignarParametroEntero("@idComp", idComprobanteTipo);
                dt = oCon.Tabla();  
                if(dt.Rows.Count > 0)
                    retorno = true;
                else
                    retorno = false;
                oCon.DesConectar();
                return retorno;
            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }
        }
    }
}
