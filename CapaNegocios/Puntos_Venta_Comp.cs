using CapaDatos;
using System;
using System.Data;

namespace CapaNegocios
{
    public class Puntos_Venta_Comp
    {
        private Conexion oCon = new Conexion();

        public int Id { get; set; }
        public int Id_Comprobantes_Tipo { get; set; }
        public int Id_Punto_Venta { get; set; }
        public int Numero { get; set; }
        public int Borrado { get; set; }

        public DataTable ListarComprobantesAsignados(int id_pv)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("select comprobantes_tipo.id, comprobantes_tipo.Nombre, comprobantes_tipo.Letra, comprobantes_tipo.Codigo_Afip, (select puntos_venta_comp.Id from puntos_venta_comp where puntos_venta_comp.Id_Comprobantes_Tipo=comprobantes_tipo.id and puntos_venta_comp.Id_Punto_Venta=" + id_pv + " and borrado=0) as id_comp_venta, (select puntos_venta_comp.Numero from puntos_venta_comp where puntos_venta_comp.Id_Comprobantes_Tipo=comprobantes_tipo.id and puntos_venta_comp.Id_Punto_Venta=" + id_pv + " and Borrado=0) as numero from comprobantes_tipo ORDER BY comprobantes_tipo.Nombre");

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

        public void GuardarAsignacionTipoComp(Puntos_Venta_Comp oPuntos_Venta_Comp)
        {
            try
            {
                oCon.Conectar();
                if (oPuntos_Venta_Comp.Id > 0)
                {
                    oCon.CrearComando("UPDATE puntos_venta_comp SET numero=@numero, borrado=@borrado WHERE id=@id; SELECT @@IDENTITY");

                    oCon.AsignarParametroEntero("@numero", oPuntos_Venta_Comp.Numero);

                    oCon.AsignarParametroEntero("@borrado", oPuntos_Venta_Comp.Borrado);
                    oCon.AsignarParametroEntero("@id", oPuntos_Venta_Comp.Id);
                }
                else
                {
                    oCon.CrearComando("INSERT INTO puntos_venta_comp (id_comprobantes_tipo, id_punto_venta, numero) " +
                        "VALUES (@id_comprobantes_tipo, @id_punto_venta, @numero);SELECT @@IDENTITY");

                    oCon.AsignarParametroEntero("@id_comprobantes_tipo", oPuntos_Venta_Comp.Id_Comprobantes_Tipo);
                    oCon.AsignarParametroEntero("@id_punto_venta", oPuntos_Venta_Comp.Id_Punto_Venta);
                    oCon.AsignarParametroEntero("@numero", oPuntos_Venta_Comp.Numero);
                }

                oCon.ComenzarTransaccion();
                oPuntos_Venta_Comp.Id = oCon.EjecutarScalar();
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

        public void Eliminar(int id)
        {
            try
            {
                oCon.Conectar();
                oCon.ComenzarTransaccion();
                oCon.CrearComando("UPDATE puntos_venta_comp SET Borrado = 1 WHERE Id = @id");
                oCon.AsignarParametroEntero("@id", id);
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

        public DataTable ListarPorPtoCobro(int id_puntoCobro)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("select comprobantes_tipo.Nombre, comprobantes_tipo.Letra, puntos_venta.Numero as numPuntoVenta,datosPtos.* from" +
                                  "(select comprobantes_habilitados.Id_Punto_Cobro, (select puntos_venta_comp.Id_Comprobantes_Tipo from puntos_venta_comp where puntos_venta_comp.Id = comprobantes_habilitados.Id_Punto_Vta_Comp) as idTipoComprobante," +
                                   "(select puntos_venta_comp.Id_Punto_Venta from puntos_venta_comp where puntos_venta_comp.Id = comprobantes_habilitados.Id_Punto_Vta_Comp) as idPuntoVenta, (select puntos_venta_comp.Numero from puntos_venta_comp where puntos_venta_comp.Id = comprobantes_habilitados.Id_Punto_Vta_Comp) as numPtoVentaComp," +
                                    "if(comprobantes_habilitados.Predeterminado=1,'SI','NO') AS predeterminado, comprobantes_habilitados.Id_Punto_Vta_Comp from comprobantes_habilitados where comprobantes_habilitados.Id_Punto_Cobro = @idPuntoCobro and comprobantes_habilitados.Borrado = 0)datosPtos left join comprobantes_tipo on datosPtos.idTipoComprobante = comprobantes_tipo.Id left join puntos_venta on datosPtos.idPuntoVenta = puntos_venta.Id");
                oCon.AsignarParametroEntero("@idPuntoCobro", id_puntoCobro);

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

        public DataTable Listar()
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando("select puntos_venta_comp.id, descripcion, puntos_venta_comp.numero, id_punto_venta, id_comprobantes_tipo " +
                    "from puntos_venta_comp LEFT JOIN puntos_venta ON puntos_venta.id = puntos_venta_comp.id_punto_venta WHERE puntos_venta_comp.borrado = 0 ORDER BY id_comprobantes_tipo; ");

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

        public DataTable ListarPuntosVentaCompConPresentaVentas(int idPuntoCobro)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                string consulta = "SELECT puntos_venta_comp.id as id_puntos_venta_comp, comprobantes_tipo.id as id_tipo_comp, CONCAT(comprobantes_tipo.Nombre, ' ' , comprobantes_tipo.Letra) comprobante_tipo ,puntos_venta.Descripcion, comprobantes_habilitados.predeterminado, "
                                + " puntos_venta.Id_Modalidad_Fact FROM comprobantes_habilitados"
                                + " LEFT JOIN puntos_venta_comp ON puntos_venta_comp.Id = comprobantes_habilitados.Id_Punto_Vta_Comp"
                                + " LEFT JOIN puntos_venta ON puntos_venta.Id = puntos_venta_comp.Id_Punto_Venta"
                                + " LEFT JOIN puntos_cobros ON puntos_cobros.Id = comprobantes_habilitados.Id_Punto_Cobro"
                                + " LEFT JOIN comprobantes_tipo ON comprobantes_tipo.Id = puntos_venta_comp.id_comprobantes_tipo"
                                + " WHERE puntos_cobros.Borrado = 0 AND puntos_venta.borrado = 0 AND puntos_venta_comp.borrado = 0"
                                + " AND puntos_cobros.id = @puntoCobro AND comprobantes_tipo.Presenta_Ventas = 1 ORDER BY puntos_venta_comp.Id_Comprobantes_Tipo";

                oCon.CrearComando(consulta);
                oCon.AsignarParametroEntero("@puntoCobro", idPuntoCobro);
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
            }
            return dt;
        }
    }
}
