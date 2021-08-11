using CapaDatos;
using System;
using System.Data;

namespace CapaNegocios
{
    public class Comprobante_impresion
    {

        private Conexion oCon = new Conexion();
        public Int32 id { get; set; }
        public Int32 id_puntos_cobros { get; set; }
        public Int32 id_comprobantes_tipo { get; set; }
        public Int32 id_personal { get; set; }
        public String impresora { get; set; }
        public Int32 impresora_bandeja { get; set; }
        public String camino_reporte { get; set; }

        public void EliminarPersonal(Int32 id_pers)
        {
            oCon.Conectar();

            oCon.CrearComando("DELETE FROM impresion WHERE id_personal= @idPers");
            oCon.AsignarParametroEntero("@idPers", id_pers);
            oCon.ComenzarTransaccion();
            oCon.EjecutarComando();
            oCon.ConfirmarTransaccion();
            oCon.DesConectar();
        }

        public void Guardar(Comprobante_impresion ocomprobante_Impresion)
        {

            try
            {

                oCon.Conectar();
                oCon.CrearComando("INSERT INTO impresion(id_puntos_cobros,id_comprobantes_tipo,id_personal,impresora,impresora_bandeja, camino_reporte) " +
                    "VALUES(@puntCobro, @comprobantes_tipo,@pers,@imp,@band,@camRep)");


                oCon.AsignarParametroEntero("@puntCobro", ocomprobante_Impresion.id_puntos_cobros);
                oCon.AsignarParametroEntero("@comprobantes_tipo", ocomprobante_Impresion.id_comprobantes_tipo);
                oCon.AsignarParametroEntero("@pers", ocomprobante_Impresion.id_personal);
                oCon.AsignarParametroCadena("@imp", ocomprobante_Impresion.impresora);
                oCon.AsignarParametroEntero("@band", ocomprobante_Impresion.impresora_bandeja);
                oCon.AsignarParametroCadena("@camRep", ocomprobante_Impresion.camino_reporte);



                oCon.ComenzarTransaccion();
                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();

            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();

                throw;
            }

        }

        public DataTable Listar_impresionComprobantes()
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT impresion.id,impresion.id_puntos_cobros, puntos_cobros.Descripcion AS PuntoDeCobro,  personal.Nombre as Nombre,comprobantes_tipo.Nombre AS Comprobante,comprobantes_tipo.Letra, impresora,  impresion.impresora_bandeja " +
                    "FROM impresion LEFT JOIN puntos_cobros ON impresion.id_puntos_cobros = puntos_cobros.id " +
                    "LEFT JOIN comprobantes_tipo ON impresion.id_comprobantes_tipo = comprobantes_tipo.id " +
                    "LEFT JOIN personal ON impresion.id_personal = personal.id ORDER BY personal.Nombre, comprobantes_tipo.Nombre ");
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                throw;
            }


            return dt;
        }

        public DataTable ListarPorPersonal(Int32 id_personal)
        {
            DataTable dt = new DataTable();
            try
            {

                oCon.Conectar();
                oCon.CrearComando("SELECT comprobantes_tipo.Nombre AS TipoFactura, comprobantes_tipo.Letra , " +
                    "if (isnull(impresora),'...',impresora) AS Impresora, if (isnull(impresora_bandeja),0,impresora_bandeja) AS Impresora_bandeja,comprobantes_tipo.id, impresion.camino_reporte AS camino " +
                    "FROM comprobantes_tipo " +
                    "LEFT JOIN impresion ON impresion.id_comprobantes_tipo = comprobantes_tipo.id AND id_personal = @idPers ORDER BY comprobantes_tipo.Nombre , comprobantes_tipo.Letra ");
                oCon.AsignarParametroEntero("@idPers", id_personal);
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }

        public void Eliminar(Int32 Id)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando(String.Format("DELETE FROM impresion WHERE id = {0}", Id));
                oCon.ComenzarTransaccion();
                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                throw;
            }
        }

    }
}
