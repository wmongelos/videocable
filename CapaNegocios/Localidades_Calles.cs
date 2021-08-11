using CapaDatos;
using System;
using System.Data;

namespace CapaNegocios
{
    public class Localidades_Calles
    {
        public Int32 Id { get; set; }
        public String Nombre { get; set; }
        public int Altura_Desde { get; set; }
        public int Altura_Hasta { get; set; }
        public Int32 Id_Localidades { get; set; }
        private Conexion oCon = new Conexion();
        public Int32 idLocalidad;

        public void Guardar(Localidades_Calles oCalle)
        {
            try
            {
                oCon.Conectar();

                if (oCalle.Id > 0)
                {
                    oCon.CrearComando("UPDATE localidades_calles SET Id_Localidades = @localidad, Nombre = @nombre, Altura_Desde = @altura_desde, Altura_Hasta = @altura_hasta WHERE Id = @id");
                    oCon.AsignarParametroEntero("@id", oCalle.Id);
                }
                else
                    oCon.CrearComando("INSERT INTO localidades_calles (Nombre, Id_Localidades, Altura_Desde, Altura_Hasta) VALUES (@nombre, @localidad, @altura_desde, @altura_hasta)");

                oCon.AsignarParametroCadena("@nombre", oCalle.Nombre);
                oCon.AsignarParametroEntero("@localidad", oCalle.Id_Localidades);
                oCon.AsignarParametroEntero("@altura_desde", oCalle.Altura_Desde);
                oCon.AsignarParametroEntero("@altura_hasta", oCalle.Altura_Hasta);

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

            if (oCalle.Id > 0)
            {
                try
                {
                    oCon.Conectar();
                    oCon.CrearComando("UPDATE usuarios_locaciones SET calle = @nombre  WHERE usuarios_locaciones.id_calle = @id");
                    oCon.AsignarParametroCadena("@nombre", oCalle.Nombre);
                    oCon.AsignarParametroEntero("@id", oCalle.Id);
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

        public void Eliminar(int id)
        {
            try
            {
                oCon.Conectar();
                oCon.ComenzarTransaccion();
                oCon.CrearComando("UPDATE localidades_calles SET Borrado = 1 WHERE Id = @id");
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

        public DataTable Listar()
        {
            oCon.Conectar();
            oCon.CrearComando("select Id, Nombre,Altura_Desde ,Altura_Hasta, Id_Localidades, (select Nombre from localidades where Id=Id_Localidades) as Nombre_Localidad from localidades_calles where Borrado=0 order by Id");

            DataTable dt = oCon.Tabla();

            oCon.DesConectar();

            return dt;
        }

        public DataTable ListarPorManzana(int id_manzana)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("select id_calle as id,(select nombre from localidades_calles where id = id_calle) as nombre,altura_desde,altura_hasta, (select id_localidades from localidades_calles where id = id_calle) as id_localidades, (select Nombre from localidades where Id = Id_Localidades) as Nombre_Localidad from manzanas_calles where id_manzana = @id_manzana and borrado = 0");

                oCon.AsignarParametroEntero("@id_manzana", id_manzana);
                DataTable dt = oCon.Tabla();

                oCon.DesConectar();

                return dt;
            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }
        }
    }
}