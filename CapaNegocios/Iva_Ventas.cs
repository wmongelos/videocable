using CapaDatos;
using System;
using System.Data;

namespace CapaNegocios
{
    public class Iva_Ventas
    {
        private Conexion ConMySql = new Conexion();

        public Boolean ActualizarNroCAI(DataTable DataComprobantes, String NroCai, DateTime Fecha_Vto) 
        {
            try
            {   
                ConMySql.Conectar();

                foreach (DataRow DrItem in DataComprobantes.Rows)
                {
                    ConMySql.CrearComando("UPDATE iva_ventas SET cae = @cai, cae = @cesp, vencimiento = @vto WHERE id = @id");

                    ConMySql.AsignarParametroCadena("@cai", NroCai);
                    ConMySql.AsignarParametroCadena("@cesp", NroCai);
                    ConMySql.AsignarParametroCadena("@vto", Fecha_Vto.Date.ToString("yyyy-MM-dd"));
                    ConMySql.AsignarParametroEntero("@id", Convert.ToInt32(DrItem["Id"]));
                    
                    ConMySql.EjecutarComando();
                }

                ConMySql.DesConectar();
            }
            catch (Exception ex)
            {
                ConMySql.DesConectar();

                return false;
            }

            return true;
        }
   
        public DataTable GetComprobantes(int NroPtoVta, int IdTipoComprobante, int NroDesde, int NroHasta)
        {
            DataTable dt = new DataTable();
            try
            {
                ConMySql.Conectar();
                ConMySql.CrearComando(String.Format("SELECT id, fecha, punto_venta, numero, letra, razon_social, importe_final, cae from iva_ventas where borrado = 0 and Punto_Venta = {0} " +
                    "and id_comprobantes_tipo = {1} and Numero BETWEEN {2} and {3} order by numero", NroPtoVta, IdTipoComprobante, NroDesde, NroHasta));
                dt = ConMySql.Tabla();
                ConMySql.DesConectar();
            }
            catch (Exception)
            {
                ConMySql.DesConectar();

                throw;
            }
            return dt;
        }
    }
}
