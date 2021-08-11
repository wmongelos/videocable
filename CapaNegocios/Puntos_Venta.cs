using CapaDatos;
using System;
using System.Data;

namespace CapaNegocios
{
    public class Puntos_Venta
    {
        private Conexion oCon = new Conexion();

        public int Id { get; set; }
        public string Descripcion { get; set; }
        public int Numero { get; set; }
        public int Id_Modalidad_Fact { get; set; }
        public int Borrado { get; set; }

        public void Guardar(Puntos_Venta oPuntos_Venta)
        {
            try
            {
                oCon.Conectar();
                if (oPuntos_Venta.Id > 0)
                {
                    oCon.CrearComando("UPDATE puntos_venta SET Descripcion=@descripcion, Numero=@numero, Id_Modalidad_Fact=@id_modalidad_fact, Borrado=@borrado,id_personal=@personal WHERE id=@id; SELECT @@IDENTITY");
                    oCon.AsignarParametroCadena("@descripcion", oPuntos_Venta.Descripcion);
                    oCon.AsignarParametroEntero("@numero", oPuntos_Venta.Numero);
                    oCon.AsignarParametroEntero("@id_modalidad_fact", oPuntos_Venta.Id_Modalidad_Fact);
                    oCon.AsignarParametroEntero("@borrado", 0);
                    oCon.AsignarParametroEntero("@personal", Personal.Id_Login);
                    oCon.AsignarParametroEntero("@id", oPuntos_Venta.Id);
                }
                else
                {
                    oCon.CrearComando("INSERT INTO puntos_venta (Descripcion, Numero, Id_Modalidad_Fact, Borrado,id_personal) " +
                        "VALUES (@descripcion, @numero, @id_modalidad_fact, @borrado,@personal);SELECT @@IDENTITY");
                    oCon.AsignarParametroCadena("@descripcion", oPuntos_Venta.Descripcion);
                    oCon.AsignarParametroEntero("@numero", oPuntos_Venta.Numero);
                    oCon.AsignarParametroEntero("@id_modalidad_fact", oPuntos_Venta.Id_Modalidad_Fact);
                    oCon.AsignarParametroEntero("@borrado", 0);
                    oCon.AsignarParametroEntero("@personal", Personal.Id_Login);

                }

                oCon.ComenzarTransaccion();
                oPuntos_Venta.Id = oCon.EjecutarScalar();
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
                oCon.CrearComando("SELECT id,numero, descripcion,id_modalidad_fact FROM puntos_venta WHERE Borrado=0 ORDER BY Descripcion");
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

        public void Eliminar(int id)
        {
            try
            {
                oCon.Conectar();
                oCon.ComenzarTransaccion();
                oCon.CrearComando("UPDATE puntos_venta SET Borrado = 1 WHERE Id = @id");
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
            try
            {

                oCon.Conectar();
                oCon.ComenzarTransaccion();
                oCon.CrearComando("UPDATE puntos_venta_comp SET Borrado = 1 WHERE Id_Punto_Venta = @idPunto");
                oCon.AsignarParametroEntero("@idPunto", id);
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
