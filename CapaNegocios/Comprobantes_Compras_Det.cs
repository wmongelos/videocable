using CapaDatos;
using System;
using System.Data;

namespace CapaNegocios
{
    public class Comprobantes_Compras_Det
    {
        public Int32 Id;
        public Int32 Id_Comprobantes_Compras;
        public Int32 Id_Tipo;
        public String Tipo;
        public Int32 Cantidad;
        public Decimal Importe;
        public Decimal Stock_Previo;

        private Conexion oCon = new Conexion();

        public DataTable Listar()
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT * FROM Comprobantes_Compras_Det WHERE borrado = 0");
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

        public void Guardar(Comprobantes_Compras_Det oCompDet)
        {
            try
            {
                oCon.Conectar();

                if (oCompDet.Id > 0)
                {
                    //Update
                }
                else
                {
                    oCon.CrearComando("INSERT INTO comprobantes_compras_det (id, id_comprobantes_compras, id_tipo, tipo, cantidad, importe, stock_previo, borrado)"
                                    + " VALUES(@Id, @IdComproCompras, @IdTipo, @Tipo, @Cantidad, @Importe, @StockPrevio, 0); SELECT @@IDENTITY");
                    oCon.AsignarParametroEntero("@Id", oCompDet.Id);
                    oCon.AsignarParametroEntero("@IdComproCompras", oCompDet.Id_Comprobantes_Compras);
                    oCon.AsignarParametroEntero("@IdTipo", oCompDet.Id_Tipo);
                    oCon.AsignarParametroCadena("@Tipo", oCompDet.Tipo);
                    oCon.AsignarParametroEntero("@Cantidad", oCompDet.Cantidad);
                    oCon.AsignarParametroDecimal("@Importe", oCompDet.Importe);
                    oCon.AsignarParametroDecimal("@StockPrevio", oCompDet.Stock_Previo);
                }
                oCon.ComenzarTransaccion();
                oCompDet.Id = oCon.EjecutarScalar();
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

        public DataTable ListarDetalleComprobanteCompra(DateTime desde, DateTime hasta, int proveedor, int numeroComprobante)
        {
            DataTable dt = new DataTable();

            try
            {
                string filtrarFecha = string.Empty;
                string consulta = string.Empty;
                string consultaTotal = string.Empty;

                oCon.Conectar();

                consulta = "SELECT  proveedores.id,comprobantes_compras.Fecha, comprobantes_compras_det.Id_Tipo , " +
                    "CASE comprobantes_compras_det.Tipo " +
                    "WHEN 'E' THEN(SELECT concat(equipos_tipos.Nombre,' - ', equipos.Serie) FROM equipos LEFT JOIN equipos_tipos ON equipos_tipos.Id = equipos.Id_Equipos_Tipos WHERE equipos.Id = comprobantes_compras_det.Id_tipo) " +
                    "WHEN 'A' THEN(SELECT Descripcion FROM Articulos WHERE Articulos.Id = comprobantes_compras_det.Id_tipo) " +
                    "END AS Producto,comprobantes_compras_det.cantidad, comprobantes_compras_det.importe, comprobantes_compras_det.cantidad*comprobantes_compras_det.importe AS Total " +
                    "FROM comprobantes_compras_det " +
                    "LEFT JOIN comprobantes_compras ON comprobantes_compras_det.Id_Comprobantes_Compras = comprobantes_compras.Id " +
                    "LEFT JOIN proveedores ON comprobantes_compras.Id_Proveedor = proveedores.Id";
                filtrarFecha = "WHERE comprobantes_compras.Fecha between @fechaDes and @fechaHas and proveedores.id=@idProveedor and comprobantes_compras.id=@idComp ORDER BY comprobantes_compras_det.id";
                consultaTotal = string.Format("{0} {1}", consulta, filtrarFecha);

                oCon.CrearComando(consultaTotal);
                oCon.AsignarParametroFecha("@fechaDes", desde);
                oCon.AsignarParametroFecha("@fechaHas", hasta);
                oCon.AsignarParametroEntero("@idProveedor", proveedor);
                oCon.AsignarParametroEntero("@idComp", numeroComprobante);
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch
            {

            }


            return dt;
        }

        public DataTable ComprobantesComprasDetalle(DateTime desde, DateTime hasta, int TipoProveedor)
        {
            DataTable dt = new DataTable();

            try
            {
                string filtrarFecha = string.Empty;
                string consulta = string.Empty;
                string consultaTotal = string.Empty;

                oCon.Conectar();

                consulta = "SELECT comprobantes_compras.id,comprobantes_compras.Fecha, comprobantes_tipo.Nombre,comprobantes_compras.Numero_Remito " +
                    "FROM comprobantes_compras " +
                    "LEFT JOIN comprobantes_tipo ON comprobantes_tipo.Id = comprobantes_compras.Id_Comprobantes_Tipo " +
                    "LEFT JOIN proveedores ON comprobantes_compras.Id_Proveedor = proveedores.Id";
                filtrarFecha = "WHERE comprobantes_compras.Fecha between @fechaDes and @fechaHas and proveedores.id=@idProveedor";
                consultaTotal = string.Format("{0} {1}", consulta, filtrarFecha);

                oCon.CrearComando(consultaTotal);
                oCon.AsignarParametroFecha("@fechaDes", desde);
                oCon.AsignarParametroFecha("@fechaHas", hasta);
                oCon.AsignarParametroEntero("@idProveedor", TipoProveedor);
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
