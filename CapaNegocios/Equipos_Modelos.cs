using CapaDatos;
using System;
using System.Data;

namespace CapaNegocios
{
    public class Equipos_Modelos
    {
        public Int32 Id { get; set; }
        public Int32 Id_Equipos_Marcas { get; set; }
        public String Nombre { get; set; }
        public Int32 Borrado { get; set; }

        private Conexion oCon = new Conexion();

        public Boolean Guardar(Equipos_Modelos oEquipo_Model)
        {
            try
            {
                oCon.Conectar();

                if (oEquipo_Model.Id > 0)
                {
                    oCon.CrearComando("UPDATE equipos_modelos set Id_Equipos_Marcas = @marca, Nombre = @nombre,id_personal=@personal WHERE Id = @id");
                    oCon.AsignarParametroEntero("@id", oEquipo_Model.Id);
                }
                else
                    oCon.CrearComando("INSERT INTO equipos_modelos(Id_Equipos_Marcas, Nombre,id_personal) VALUES(@marca, @nombre,@personal)");

                oCon.AsignarParametroEntero("@marca", oEquipo_Model.Id_Equipos_Marcas);
                oCon.AsignarParametroCadena("@nombre", oEquipo_Model.Nombre);
                oCon.AsignarParametroEntero("@personal", Personal.Id_Login);

                oCon.ComenzarTransaccion();
                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
                Tablas.LoadEquiposModelos();

                return true;
            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                return false;
                throw;
            }
        }

        public DataTable Listar()
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT *, (SELECT Nombre FROM Equipos_Marcas WHERE Id = equipos_modelos.Id_Equipos_Marcas) AS Marca FROM equipos_modelos WHERE Borrado = 0 ORDER BY equipos_modelos.Nombre");
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

                oCon.CrearComando("UPDATE equipos_modelos SET Borrado = 1,id_personal=@personal WHERE Id = @id");
                oCon.AsignarParametroEntero("@personal", Personal.Id_Login);
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
    }
}
