using CapaDatos;
using System;
using System.Data;

namespace CapaNegocios
{
    public class Equipos_Marcas
    {
        public Int32 Id { get; set; }
        public String Nombre { get; set; }
        public Int32 Borrado { get; set; }

        private Conexion oCon = new Conexion();

        public Boolean Guardar(Equipos_Marcas oEquipo_Marca)
        {
            try
            {
                oCon.Conectar();

                if (oEquipo_Marca.Id > 0)
                {
                    oCon.CrearComando("UPDATE equipos_marcas set Nombre = @nombre,id_personal=@personal WHERE Id = @id");
                    oCon.AsignarParametroEntero("@id", oEquipo_Marca.Id);
                }
                else
                    oCon.CrearComando("INSERT INTO equipos_marcas(Nombre,id_personal) VALUES(@nombre,@personal)");

                oCon.AsignarParametroCadena("@nombre", oEquipo_Marca.Nombre);
                oCon.AsignarParametroEntero("@personal", Personal.Id_Login);


                oCon.ComenzarTransaccion();
                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
                Tablas.LoadEquiposMarcas();
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
                oCon.CrearComando("SELECT * FROM equipos_marcas WHERE Borrado = 0 ORDER BY Nombre");
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
                oCon.CrearComando("UPDATE equipos_marcas SET Borrado = 1,id_personal=@personal WHERE Id = @id");
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

        public DataTable VerificaMarcaNula(int IdMarca)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT equipos.id,Id_equipos_marcas " +
                    "FROM equipos " +
                    "LEFT JOIN equipos_marcas ON equipos.Id_Equipos_Marcas = equipos_marcas.Id " +
                    "WHERE equipos.borrado = 0 and id_equipos_marcas= @IdEquipoMarca");
                oCon.AsignarParametroEntero("@IdEquipoMarca", IdMarca);
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

        public void EliminaidMarca(int id)
        {
            try
            {
                oCon.Conectar();
                oCon.ComenzarTransaccion();
                oCon.CrearComando("UPDATE equipos SET Id_Equipos_Marcas = 0,id_personal=@personal WHERE Id_Equipos_Marcas = @id");
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
