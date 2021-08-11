using CapaDatos;
using System;
using System.Data;

namespace CapaNegocios
{
    public class Notificaciones_Destinatarios_Aut
    {
        private Conexion oCon = new Conexion();

        public DataTable GetModulos()
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT Id, Descripcion, Formulario FROM Notificaciones_Modulos");
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception)
            {

                throw;
            }


            return dt;
        }

        /// <summary>
        /// Retorna Los Destinatarios Automaticos
        /// </summary>
        /// <param name="IdModulo">Si viene 0 Devuelve Todos</param>
        /// <returns></returns>
        public DataTable GetDestinos(Int32 IdModulo)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();

                String Query = "SELECT (CASE " +
                    "WHEN(notificaciones_destinatarios_aut.Id_Tipo_Destinatario = 1) THEN 'ÁREA' " +
                    "WHEN(notificaciones_destinatarios_aut.Id_Tipo_Destinatario = 2) THEN 'PERSONAL' " +
                    "WHEN(notificaciones_destinatarios_aut.Id_Tipo_Destinatario = 3) THEN 'PUNTO DE GESTION' " +
                    "WHEN(notificaciones_destinatarios_aut.Id_Tipo_Destinatario = 4) THEN 'CAJA' END) AS 'tipo_destinatario', (CASE " +
                    "WHEN(notificaciones_destinatarios_aut.Id_Tipo_Destinatario = 1) THEN " +
                    "(SELECT personal_areas.Nombre FROM personal_areas WHERE(personal_areas.Id = notificaciones_destinatarios_aut.Id_Destinatario))  " +
                    "WHEN(notificaciones_destinatarios_aut.Id_Tipo_Destinatario = 2) THEN " +
                    "(SELECT personal.Nombre FROM personal WHERE(personal.Id = notificaciones_destinatarios_aut.Id_Destinatario)) " +
                    "ELSE(SELECT CONCAT(puntos_cobros.tipo_sucursal, ' ', puntos_cobros.Descripcion) FROM puntos_cobros WHERE " +
                    "(puntos_cobros.Id = notificaciones_destinatarios_aut.Id_Destinatario)) END) AS 'destinatario', Id, Id_Notificaciones_Modulos, Id_Tipo_Destinatario, Id_Destinatario " +
                    "FROM notificaciones_destinatarios_aut";

                if (IdModulo > 0)
                    Query = String.Format("{0} WHERE Id_Notificaciones_Modulos = {1}", Query, IdModulo);

                oCon.CrearComando(Query);
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception)
            {

                throw;
            }


            return dt;
        }

        public void Guardar(Int32 IdModulo, Int32 Id_Tipo_Destinatario, Int32 Id_Destinatario)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando(String.Format("INSERT INTO Notificaciones_Destinatarios_Aut(Id_Notificaciones_Modulos, Id_Tipo_Destinatario, Id_Destinatario) " +
                    "VALUES({0}, {1}, {2})", IdModulo, Id_Tipo_Destinatario, Id_Destinatario));
                oCon.EjecutarComando();
                oCon.DesConectar();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Eliminar(Int32 Id)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando(String.Format("DELETE FROM Notificaciones_Destinatarios_Aut WHERE Id = {0}", Id));
                oCon.EjecutarComando();
                oCon.DesConectar();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable GetModulosPorForm(string nombreForm)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando(String.Format("SELECT Id, Descripcion, Formulario FROM Notificaciones_Modulos where formulario='{0}'", nombreForm));
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
