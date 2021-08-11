using CapaDatos;
using System;
using System.Data;
namespace CapaNegocios
{
    public class Manzanas_Calles
    {
        public Int32 Id_Manzana { get; set; }
        public Int32 Id_Calle { get; set; }
        public string Nombre_calle { get; set; }
        public Int32 Altura_desde { get; set; }
        public Int32 Altura_hasta { get; set; }
        public Int32 Paridad { get; set; }
        private Conexion oCon = new Conexion();

        public DataTable Traer_Calles(int Id_Manzana)
        {
            DataTable dt = new DataTable();

            oCon.Conectar();
            if (Id_Manzana == 0)
                oCon.CrearComando("select id_calle,id_manzana,(select nombre from localidades_calles where id=id_calle) as nombre_calle, altura_desde,altura_hasta, paridad as paridadsql from manzanas_calles where borrado=0");
            else
            {
                oCon.CrearComando("select id_calle,id_manzana,(select nombre from localidades_calles where id=id_calle) as nombre_calle, altura_desde,altura_hasta, paridad as paridadsql from manzanas_calles where id_manzana=@id and borrado=0");
                oCon.AsignarParametroEntero("@id", Id_Manzana);
            }

            dt = oCon.Tabla();
            dt.Columns.Add("Paridad");

            foreach (DataRow fila in dt.Rows)
            {
                if (fila["Paridadsql"].ToString() == "1")
                    fila["Paridad"] = "IMPAR";
                else
                    fila["Paridad"] = "PAR";
            }

            oCon.DesConectar();

            return dt;
        }

        public void Eliminar_Manzana_Calle(int id_manzana, int id_calle)
        {
            try
            {
                oCon.Conectar();

                if (id_calle == 0)
                {
                    oCon.CrearComando("UPDATE manzanas_calles SET Borrado =1 WHERE id_manzana=@id_manzana");
                    oCon.AsignarParametroEntero("@id_manzana", id_manzana);
                }
                else
                {
                    oCon.CrearComando("UPDATE manzanas_calles SET Borrado =1 WHERE id_manzana=@id_manzana and id_calle=@id_calle");
                    oCon.AsignarParametroEntero("@id_manzana", id_manzana);
                    oCon.AsignarParametroEntero("@id_calle", id_calle);
                }


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

        public void Agregar_Manzana_Calle(Manzanas_Calles oManzanas_calles)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("insert into manzanas_calles(Id_Manzana, Id_Calle, Altura_desde, Altura_hasta, Paridad, Borrado) values(@Id_Manzana,@Id_Calle,@Altura_desde,@Altura_hasta,@Paridad,0)");
                oCon.AsignarParametroEntero("@Id_Manzana", oManzanas_calles.Id_Manzana);
                oCon.AsignarParametroEntero("@Id_Calle", oManzanas_calles.Id_Calle);
                oCon.AsignarParametroEntero("@Altura_desde", oManzanas_calles.Altura_desde);
                oCon.AsignarParametroEntero("@Altura_hasta", oManzanas_calles.Altura_hasta);
                oCon.AsignarParametroEntero("@Paridad", oManzanas_calles.Paridad);

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

        public DataTable Buscar_Calle(int id_calle)
        {
            DataTable dt = new DataTable();

            oCon.Conectar();
            oCon.CrearComando("select Id, Nombre, Altura_Desde, Altura_Hasta from localidades_calles where Id=@id and Borrado=0");
            oCon.AsignarParametroEntero("@id", id_calle);
            dt = oCon.Tabla();

            oCon.DesConectar();

            return dt;
        }
    }
}
