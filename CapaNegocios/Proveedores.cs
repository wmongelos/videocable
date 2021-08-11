using CapaDatos;
using System;
using System.Data;

namespace CapaNegocios
{
    public class Proveedores
    {
        #region [PROPIEDADES]
        public Int32 Id;
        public String Razon_Social;
        public Int32 Id_Comprobantes_Iva;
        public String Cuit;
        public String Domicilio;
        public String Email;
        public Decimal Prefijo_1;
        public Decimal Telefono_1;
        public Decimal Prefijo_2;
        public Decimal Telefono_2;
        public String Contacto;
        public String Web;
        public String Observacion;
        public Int32 Borrado;
        #endregion

        private Conexion oCon = new Conexion();

        public void Guardar(Proveedores oProveedor)
        {

            try
            {
                oCon.Conectar();

                if (oProveedor.Id > 0)
                {
                    oCon.CrearComando("UPDATE Proveedores SET Razon_Social = @rsoc, Id_Comprobantes_Iva = @iva, Cuit = @cuit, " +
                        "Domicilio = @dom, Email = @email, Prefijo_1 = @pre1, Telefono_1 = @tel1, Prefijo_2 = @pre2, Telefono_2 = @tel2, " +
                        "Contacto = @con, Web = @web, Observacion = @obs WHERE Id = @id");

                    oCon.AsignarParametroEntero("@id", oProveedor.Id);
                }
                else
                {
                    oCon.CrearComando("INSERT INTO Proveedores(Razon_social, Id_Comprobantes_Iva, Cuit, Domicilio, Email, Prefijo_1, Telefono_1, " +
                        "Prefijo_2, Telefono_2, Contacto, Web, Observacion) VALUES(@rsoc, @iva, @cuit, @dom, @email, @pre1, @tel1, @pre2, @tel2, " +
                        "@con, @web, @obs)");
                }

                oCon.AsignarParametroCadena("@rsoc", oProveedor.Razon_Social);
                oCon.AsignarParametroEntero("@iva", oProveedor.Id_Comprobantes_Iva);
                oCon.AsignarParametroCadena("@cuit", oProveedor.Cuit);
                oCon.AsignarParametroCadena("@dom", oProveedor.Domicilio);
                oCon.AsignarParametroCadena("@email", oProveedor.Email);
                oCon.AsignarParametroDecimal("@pre1", oProveedor.Prefijo_1);
                oCon.AsignarParametroDecimal("@tel1", oProveedor.Telefono_1);
                oCon.AsignarParametroDecimal("@pre2", oProveedor.Prefijo_2);
                oCon.AsignarParametroDecimal("@tel2", oProveedor.Telefono_2);
                oCon.AsignarParametroCadena("@con", oProveedor.Contacto);
                oCon.AsignarParametroCadena("@web", oProveedor.Web);
                oCon.AsignarParametroCadena("@obs", oProveedor.Observacion);

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
                oCon.CrearComando("SELECT * FROM Proveedores WHERE Borrado = 0 ORDER BY Razon_Social");
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
