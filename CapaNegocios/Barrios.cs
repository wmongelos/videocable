using CapaDatos;
using System;
using System.Data;

namespace CapaNegocios
{
    public class Barrios
    {
        public Int32 Id_Barrio { get; set; }
        public String Nombre { get; set; }
        public Int32 Borrado { get; set; }

        private Conexion oCon = new Conexion();

        public DataTable Listar()
        {
            oCon.Conectar();
            oCon.CrearComando("SELECT Id_Barrio, Nombre,(select count(id_manzana) from manzanas where manzanas.Id_Barrio=barrios.id_barrio and borrado=0) as cant_manzanas from barrios where Borrado=0");

            DataTable dt = oCon.Tabla();

            oCon.DesConectar();

            return dt;
        }

        public void Guardar(Barrios oBarrio)
        {
            try
            {
                oCon.Conectar();

                if (oBarrio.Id_Barrio > 0)
                {
                    oCon.CrearComando("UPDATE barrios SET Nombre=@nombre WHERE Id_Barrio = @id");
                    oCon.AsignarParametroEntero("@id", oBarrio.Id_Barrio);
                }
                else
                    oCon.CrearComando("INSERT INTO barrios (Nombre,Borrado) VALUES (@nombre,0)");

                oCon.AsignarParametroCadena("@nombre", oBarrio.Nombre);


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

        public bool Eliminar(int id_barrio)
        {
            bool resultado = false;
            try
            {
                oCon.Conectar();


                oCon.CrearComando("UPDATE barrios SET Borrado=1 WHERE Id_Barrio = @id");
                oCon.AsignarParametroEntero("@id", id_barrio);


                oCon.ComenzarTransaccion();
                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();



                oCon.DesConectar();
                resultado = true;
            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();

                throw;
            }
            return resultado;
        }

        public DataTable Traer_Localidades(int Id_Barrio)
        {
            DataTable dt = new DataTable();

            oCon.Conectar();
            if (Id_Barrio == 0)
                oCon.CrearComando("SELECT Id_Localidad, (select Nombre from localidades where id=Id_Localidad) as Nombre_Localidad,Id_Barrio,Id_Barrio_Localidad,borrado FROM  barrios_localidades WHERE Borrado = 0");
            else
            {
                oCon.CrearComando("SELECT Id_Localidad, (select Nombre from localidades where id=Id_Localidad) as Nombre_Localidad,Id_Barrio,Id_Barrio_Localidad, borrado FROM  barrios_localidades WHERE Id_Barrio = @id AND Borrado = 0");
                oCon.AsignarParametroEntero("@id", Id_Barrio);
            }
            dt = oCon.Tabla();

            oCon.DesConectar();

            return dt;
        }

        public void Eliminar_Localidad_Barrio(int Id_Barrio_Localidad)
        {
            try
            {
                oCon.Conectar();


                oCon.CrearComando("UPDATE barrios_localidades SET Borrado =1 WHERE Id_Barrio_Localidad =@id");
                oCon.AsignarParametroEntero("@id", Id_Barrio_Localidad);


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

        public void Agregar_Localidad_Barrio(int Id_Barrio, int Id_Localidad)
        {
            try
            {
                oCon.Conectar();


                oCon.CrearComando("insert into barrios_localidades(Id_Barrio, Id_Localidad, Borrado) values(@Id_Barrio,@Id_Localidad,0)");


                oCon.AsignarParametroEntero("@Id_Barrio", Id_Barrio);
                oCon.AsignarParametroEntero("@Id_Localidad", Id_Localidad);

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

        public void Borrar_manzanas(int id_manzana)
        {
            try
            {
                oCon.Conectar();


                oCon.CrearComando("UPDATE manzanas SET Borrado =1 WHERE Id_Manzana =@id");
                oCon.AsignarParametroEntero("@id", id_manzana);


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

        public void Borrar_asignacion_localidades(int id_barrio)
        {
            try
            {
                oCon.Conectar();


                oCon.CrearComando("UPDATE barrios_localidades SET Borrado =1 WHERE Id_Barrio =@id");
                oCon.AsignarParametroEntero("@id", id_barrio);


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

        public DataTable GetDataBarrio(Int32 Id_Calle, Int32 Nro_Calle)
        {
            DataTable dataTable = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT Nro_Manzana, Barrios.Nombre as Barrio FROM manzanas_calles " +
                    "LEFT JOIN manzanas ON manzanas.id_manzana = manzanas_calles.id_manzana " +
                    "LEFT JOIN barrios ON barrios.id_barrio = manzanas.id_barrio " +
                    "WHERE Id_Calle = @calle AND @numero BETWEEN Altura_desde AND Altura_hasta " +
                    "AND manzanas.borrado = 0 and barrios.borrado = 0");

                oCon.AsignarParametroEntero("@calle", Id_Calle);
                oCon.AsignarParametroEntero("@numero", Nro_Calle);

                dataTable = oCon.Tabla();

                oCon.DesConectar();
            }
            catch { }

            return dataTable;
        }
    }
}
