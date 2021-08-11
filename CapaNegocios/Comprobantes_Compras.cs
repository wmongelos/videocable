using CapaDatos;
using System;
using System.Data;

namespace CapaNegocios
{
    public class Comprobantes_Compras
    {

        public Int32 Id;
        public Int32 Id_Comprobantes_Tipo;
        public DateTime Fecha;
        public Int32 Id_Proveedor;
        public Decimal Importe;
        public Double Numero_Remito;
        public Int32 Borrado;
        public Int32 Id_Personal;
        public String Observacion;

        private Conexion oCon = new Conexion();

        public DataTable Listar()
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT comprobantes_compras.id , comprobantes_compras.id_comprobantes_tipo , comprobantes_compras.Fecha, "
                                + " comprobantes_compras.id_proveedor, comprobantes_compras.importe, comprobantes_compras.numero_remito,"
                                + " comprobantes_compras.id_personal,proveedores.id as id_prov, proveedores.razon_social, personal.nombre as personal,"
                                + " comprobantes_tipo.nombre as tipo_comprobante FROM comprobantes_compras"
                                + " LEFT JOIN proveedores ON proveedores.id = comprobantes_compras.id_proveedor"
                                + " LEFT JOIN personal ON personal.id = comprobantes_compras.id_personal"
                                + " LEFT JOIN comprobantes_tipo ON comprobantes_tipo.id = comprobantes_compras.id_comprobantes_tipo"
                                + " WHERE comprobantes_compras.borrado = 0 ORDER BY comprobantes_compras.fecha ASC");
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

        public void Guardar(Comprobantes_Compras oCompCompras)
        {
            try
            {
                oCon.Conectar();
                if (oCompCompras.Id > 0)
                {
                    // Update
                }
                else
                {
                    oCon.CrearComando("INSERT INTO comprobantes_compras(Fecha,Id_Comprobantes_Tipo ,Id_Proveedor, Importe, Numero_Remito, Borrado, Id_Personal, Observacion) " +
                        "VALUES (@Fecha,@IdCompTipo ,@IdProveedor, @Importe, @NumeroRemito, 0, @IdPersonal, @Observacion); SELECT @@IDENTITY");
                    oCon.AsignarParametroFecha("@Fecha", oCompCompras.Fecha);
                    oCon.AsignarParametroEntero("@IdCompTipo", oCompCompras.Id_Comprobantes_Tipo);
                    oCon.AsignarParametroEntero("@IdProveedor", oCompCompras.Id_Proveedor);
                    oCon.AsignarParametroDecimal("@Importe", oCompCompras.Importe);
                    oCon.AsignarParametroDouble("@NumeroRemito", oCompCompras.Numero_Remito);
                    oCon.AsignarParametroDecimal("@IdPersonal", oCompCompras.Id_Personal);
                    oCon.AsignarParametroCadena("@Observacion", oCompCompras.Observacion);
                }
                oCon.ComenzarTransaccion();
                oCompCompras.Id = oCon.EjecutarScalar();
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
