using CapaDatos;
using System;
using System.Data;

namespace CapaNegocios
{
    public class Comprobantes_Habilitados
    {
        private Conexion oCon = new Conexion();

        public int Id { get; set; }
        public int Id_Punto_Cobro { get; set; }
        public int Id_Punto_Vta_Comp { get; set; }
        public int Predeterminado { get; set; }
        public int Borrado { get; set; }

        public void Guardar(Comprobantes_Habilitados oComprobante_Hab)
        {
            try
            {
                oCon.Conectar();
                if (oComprobante_Hab.Id > 0)
                {
                    oCon.CrearComando("UPDATE comprobantes_habilitados SET Id_Punto_Cobro=@id_punto_cobro, Id_Punto_Vta_Comp=@id_punto_vta_comp, Predeterminado=@predeterminado, Borrado=@borrado,id_personal=@personal WHERE id=@id; SELECT @@IDENTITY");

                    oCon.AsignarParametroEntero("@id_punto_cobro", oComprobante_Hab.Id_Punto_Cobro);
                    oCon.AsignarParametroEntero("@id_punto_vta_comp", oComprobante_Hab.Id_Punto_Vta_Comp);
                    oCon.AsignarParametroEntero("@predeterminado", oComprobante_Hab.Predeterminado);
                    oCon.AsignarParametroEntero("@borrado", oComprobante_Hab.Borrado);
                    oCon.AsignarParametroEntero("@personal", Personal.Id_Login);
                    oCon.AsignarParametroEntero("@id", oComprobante_Hab.Id);
                }
                else
                {
                    oCon.CrearComando("INSERT INTO comprobantes_habilitados(id_punto_cobro, id_punto_vta_comp, predeterminado, Borrado,id_personal) " +
                        "VALUES (@id_punto_cobro, @id_punto_vta_comp, @predeterminado, @borrado,@personal);SELECT @@IDENTITY");
                    oCon.AsignarParametroEntero("@id_punto_cobro", oComprobante_Hab.Id_Punto_Cobro);
                    oCon.AsignarParametroEntero("@id_punto_vta_comp", oComprobante_Hab.Id_Punto_Vta_Comp);
                    oCon.AsignarParametroEntero("@predeterminado", oComprobante_Hab.Predeterminado);
                    oCon.AsignarParametroEntero("@borrado", 0);
                    oCon.AsignarParametroEntero("@personal", Personal.Id_Login);

                }

                oCon.ComenzarTransaccion();
                oComprobante_Hab.Id = oCon.EjecutarScalar();
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

        public DataTable GetDatosPuntoVenta(int idComprobanteTipo, int IdPuntoCobro)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT comprobantes_habilitados.id_punto_cobro,comprobantes_habilitados.id_punto_vta_comp," +
                    " comprobantes_habilitados.borrado,puntos_venta_comp.id_punto_venta, puntos_venta_comp.id_comprobantes_tipo, " +
                    " comprobantes_habilitados.predeterminado, puntos_cobros.descripcion as punto_cobro_descripcion , " +
                    " puntos_venta_comp.numero as comprobante_habilitado_numero, puntos_venta.descripcion as punto_venta_descripcion, " +
                    " puntos_venta.Id_Modalidad_Fact AS punto_venta_id_modalidad_facturacion,modalidad_facturacion.descripcion as modalidad_facturacion_descripcion, " +
                    " puntos_venta.numero as num_afip FROM comprobantes_habilitados "
                    + "LEFT JOIN puntos_venta_comp ON comprobantes_habilitados.Id_Punto_Vta_Comp = puntos_venta_comp.Id"
                    + " LEFT JOIN puntos_cobros ON comprobantes_habilitados.Id_Punto_Cobro = puntos_cobros.Id"
                    + " LEFT JOIN puntos_venta ON puntos_venta_comp.Id_Punto_Venta = puntos_venta.Id"
                    + " LEFT JOIN modalidad_facturacion ON puntos_venta.Id_Modalidad_Fact = modalidad_facturacion.Id "
                    + " WHERE comprobantes_habilitados.id_punto_cobro=@idPunto and puntos_venta_comp.id_comprobantes_tipo=@idTipoComprobante  and comprobantes_habilitados.borrado=0 and puntos_venta_comp.borrado=0  order by comprobantes_habilitados.predeterminado desc");
                oCon.AsignarParametroEntero("@idPunto", IdPuntoCobro);
                oCon.AsignarParametroEntero("@idTipoComprobante", idComprobanteTipo);

                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }
            return dt;
        }

        public DataTable Listar(int idPuntoCobro, bool listarBorrados = false)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                if (!listarBorrados)
                    oCon.CrearComando("SELECT * from comprobantes_habilitados WHERE id_punto_cobro = @idPunto and Borrado = 0");
                else
                    oCon.CrearComando("SELECT * from comprobantes_habilitados WHERE id_punto_cobro = @idPunto");
                oCon.AsignarParametroEntero("@idPunto", idPuntoCobro);

                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }
            return dt;
        }

    }
}
