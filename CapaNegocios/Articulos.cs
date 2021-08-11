using CapaDatos;
using System;
using System.Data;

namespace CapaNegocios
{
    public class Articulos
    {
        public Int32 Id;
        public String Descripcion;
        public Int32 Id_Productos_Rubros;
        public Int32 Stock;
        public Int32 Stock_Minimo;
        public Decimal Importe;

        private Conexion oCon = new Conexion();

        public void Guardar(Articulos oArticulo)
        {

            try
            {
                oCon.Conectar();

                if (oArticulo.Id > 0)
                {
                    oCon.CrearComando("UPDATE Articulos SET Descripcion = @des, Id_Articulos_Rubros = @rub, " +
                        "Stock = @sto, Stock_Minimo = @stomin, importe = @importe, id_personal=@personal WHERE Id = @id");

                    oCon.AsignarParametroEntero("@id", oArticulo.Id);
                }
                else
                {
                    oCon.CrearComando("INSERT INTO Articulos(Descripcion, Id_Articulos_Rubros, Stock, Stock_Minimo, Importe,id_personal) " +
                        "VALUES(@des, @rub, @sto, @stomin, @importe,@personal)");
                }

                oCon.AsignarParametroCadena("@des", oArticulo.Descripcion);
                oCon.AsignarParametroEntero("@rub", oArticulo.Id_Productos_Rubros);
                oCon.AsignarParametroEntero("@sto", oArticulo.Stock);
                oCon.AsignarParametroEntero("@stomin", oArticulo.Stock_Minimo);
                oCon.AsignarParametroDecimal("@importe", oArticulo.Importe);
                oCon.AsignarParametroEntero("@personal", Personal.Id_Login);


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

        public void Eliminar(Int32 Id)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando(String.Format("UPDATE Articulos SET Borrado = 1 WHERE Id = {0}", Id));
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

        public DataTable Listar()
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT Id, Descripcion, Stock, Stock_Minimo, Importe, (Importe*Stock) AS Importe_Total, Id_Articulos_Rubros FROM Articulos WHERE Borrado = 0 ORDER BY Descripcion");
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception)
            {

                throw;
            }


            return dt;

        }
    }
}
