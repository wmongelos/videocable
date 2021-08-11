using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;

namespace CapaNegocios
{
    public class Manzanas
    {
        public Int32 Id_Manzana { get; set; }
        public String Nro_Manzana { get; set; }
        public Int32 Borrado { get; set; }
        public Int32 Id_Barrio { get; set; }
        private Conexion oCon = new Conexion();
        public List<Manzanas_Calles> lista_manzanas_calles = new List<Manzanas_Calles>();

        public DataTable Listar(int Id_Barrio, int id_calle)
        {
            oCon.Conectar();
            if (Id_Barrio != 0)
            {
                oCon.CrearComando("SELECT Id_Manzana, Nro_Manzana, Borrado, Id_Barrio from manzanas where Id_Barrio=@id and Borrado=0");
                oCon.AsignarParametroEntero("@id", Id_Barrio);
            }
            else if (id_calle != 0)
            {
                oCon.CrearComando("select manzanas.id_manzana, nro_manzana from manzanas inner join (select id_manzana from manzanas_calles where id_calle = @id and borrado = 0 group by id_manzana)manzanas_calles on manzanas.id_manzana = manzanas_calles.id_manzana and manzanas.borrado=0");
                oCon.AsignarParametroEntero("@id", id_calle);
            }
            else
                oCon.CrearComando("SELECT Id_Manzana, Nro_Manzana, Borrado, Id_Barrio from manzanas where Borrado=0");

            DataTable dt = oCon.Tabla();

            oCon.DesConectar();

            return dt;
        }

        public void Guardar(Manzanas oManzana)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("INSERT INTO manzanas (Nro_Manzana,Id_Barrio,Borrado) VALUES (@nombre,@id_barrio,0)");
                oCon.AsignarParametroCadena("@nombre", oManzana.Nro_Manzana);
                oCon.AsignarParametroEntero("@id_barrio", oManzana.Id_Barrio);
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

        public void Editar(int id_manzana, string nombre)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("UPDATE manzanas SET Nro_Manzana=@nombre WHERE Id_Manzana = @id");
                oCon.AsignarParametroEntero("@id", id_manzana);
                oCon.AsignarParametroCadena("@nombre", nombre);
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

        public void Eliminar(int id_manzana)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("UPDATE manzanas SET Borrado=1 WHERE Id_Manzana = @id");
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
    }
}
