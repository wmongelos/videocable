using CapaDatos;
using System;
using System.Data;

namespace CapaNegocios
{
    public class Articulos_Mov
    {
        public Int32 Id;
        public Int32 Id_Personal;
        public DateTime Fecha;
        public Int32 Id_Destinatario;
        public String Destinatario;

        private Conexion oCon = new Conexion();

        public void Guardar(Articulos_Mov oArtMov)
        {
            try
            {
                oCon.Conectar();

                oCon.CrearComando("INSERT INTO Articulos_Mov(Id_Personal, Fecha, Id_Destinatario, Destinatario)" +
                    "VALUES (@IdPersonal, @Fecha, @IdDestinatario, @Destinatario); SELECT @@identity");


                oCon.AsignarParametroEntero("@IdPersonal", oArtMov.Id_Personal);
                oCon.AsignarParametroFecha("@Fecha", oArtMov.Fecha);
                oCon.AsignarParametroEntero("@IdDestinatario", oArtMov.Id_Destinatario);
                oCon.AsignarParametroCadena("@Destinatario", oArtMov.Destinatario);

                oCon.ComenzarTransaccion();
                oArtMov.Id = oCon.EjecutarScalar();
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

        public DataRow TraerArticulosMovRow(int idArtMov)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();

                string consulta = string.Format("SELECT articulos_mov.Id, personal.nombre as nombre_personal ,articulos_mov.Id_personal, Fecha, id_destinatario, Destinatario,"
                           + " IF(destinatario = 'M', moviles.nombre,if (destinatario = 'A',personal_areas.nombre, if(destinatario = 'P',personal.nombre,'SIN DEFINIR'))) as nombre_destinatario"
                           + " FROM articulos_mov"
                           + " LEFT JOIN personal on personal.id = articulos_mov.id_personal"
                           + " LEFT JOIN moviles on(moviles.id = articulos_mov.id_destinatario AND articulos_mov.destinatario = 'M')"
                           + " LEFT JOIN personal_areas on(personal_areas.id = articulos_mov.id_destinatario AND articulos_mov.destinatario = 'A')"
                           + " WHERE articulos_mov.id = {0}", idArtMov);

                oCon.CrearComando(consulta);
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }
            if (dt.Rows.Count > 0)
                return dt.Rows[0];
            else
                return null;
        }

    }
}
