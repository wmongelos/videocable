using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocios.Mapas
{
    public class Poligono_Personal_Area
    {


        private Conexion oCon = new Conexion();

        public void Guardar(int id_poligono, int id_personal_area)
        {
            try
            {
                int existe = Existe(id_poligono, id_personal_area);
                oCon.Conectar();
                if(existe==0)
                oCon.CrearComando("INSERT INTO poligono_personal_area (id_poligono, id_personal_area) VALUES(@id_poligono,@id_personal_area)");
                else
                oCon.CrearComando("UPDATE poligono_personal_area SET borrado=0 WHERE id_poligono=@id_poligono AND id_personal_area=@id_personal_area AND borrado=1");

                oCon.AsignarParametroEntero("@id_poligono", id_poligono);
                oCon.AsignarParametroEntero("@id_personal_area", id_personal_area);
                
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

        private int Existe(int id_poligono, int id_personal_area)
        {
            DataTable dt = new DataTable();
            int existe = 0;
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT (IF(EXISTS(SELECT * FROM poligono_personal_area WHERE id_poligono=@id_poligono AND id_personal_area=@id_personal_area AND borrado=1)>0,1, 0)) AS existe");
                oCon.AsignarParametroEntero("@id_poligono", id_poligono);
                oCon.AsignarParametroEntero("@id_personal_area", id_personal_area);
                dt = oCon.Tabla();
                oCon.DesConectar();

                existe = Convert.ToInt32(dt.Rows[0]["existe"]);
            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }

            return existe;
        }
        public void Eliminar(int id_poligono, int id_personal_area)
        {
            try
            {
                oCon.Conectar();
                oCon.ComenzarTransaccion();
                oCon.CrearComando("UPDATE poligono_personal_area SET borrado = 1 WHERE id_poligono = @id_poligono AND id_personal_area = @id_personal_area");
                oCon.AsignarParametroEntero("@id_poligono", id_poligono);
                oCon.AsignarParametroEntero("@id_personal_area", id_personal_area);
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
        public DataTable Listar(int id)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando(" SELECT poligono_personal_area.id_poligono, poligono_personal_area.id_personal_area ,personal_areas.Nombre " +
                                  " FROM poligono_personal_area" +
                                  " INNER JOIN personal_areas ON personal_areas.Id = poligono_personal_area.id_personal_area " +
                                  " WHERE poligono_personal_area.id_poligono =@id AND poligono_personal_area.borrado = 0 AND personal_areas.borrado = 0") ;
                oCon.AsignarParametroEntero("@id", id);
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
    }
}
