using CapaDatos;
using System;
using System.Data;

namespace CapaNegocios
{
    public class Servicios_Ip_Fijas
    {
        public int Id { get; set; }
        public string Ip { get; set; }
        private Conexion oCon = new Conexion();


        public void Guardar(Servicios_Ip_Fijas oIps)
        {
            try
            {
                oCon.Conectar();
                if (oIps.Id > 0)
                {
                    oCon.CrearComando("UPDATE servicios_ip_fija set ip=@ip where id=@id");
                    oCon.AsignarParametroEntero("@id", oIps.Id);
                }
                else
                    oCon.CrearComando("INSERT INTO servicios_ip_fija (ip) VALUES (@ip)");
                oCon.AsignarParametroCadena("@ip", oIps.Ip);
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
        public void Eliminar(int id)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("UPDATE servicios_ip_fija set borrado=1 WHERE id=@id");
                oCon.AsignarParametroEntero("@id", id);
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
        public DataTable ListarIpFijas()
        {
            DataTable dt;
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT  servicios_ip_fija.Id,usuarios.Nombre,servicios.Descripcion AS Servicio, servicios_sub.Descripcion AS SubServicio,Ip,IF (servicios_ip_fija.Asignada=1,'SI','NO')AS Asignada " +
                    "FROM servicios_ip_fija " +
                    "LEFT JOIN usuarios_servicios_sub ON servicios_ip_fija.Id = usuarios_servicios_sub.Id_Ip_fija " +
                    "LEFT JOIN usuarios_servicios ON usuarios_servicios.Id = usuarios_servicios_sub.Id_Usuarios_Servicios " +
                    "LEFT JOIN usuarios ON usuarios.Id = usuarios_servicios.Id_Usuarios " +
                    "LEFT JOIN servicios ON usuarios_servicios.Id_Servicios = servicios.Id " +
                    "LEFT JOIN servicios_sub ON usuarios_servicios_sub.Id_Servicios_Sub = servicios_sub.Id " +
                    "WHERE servicios_ip_fija.borrado = 0");
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
        public int VerificarExistencia(string ip)
        {
            int existe = 0;
            DataTable dt;
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT * FROM servicios_ip_fija WHERE ip=@ip and borrado=0");
                oCon.AsignarParametroCadena("@ip", ip);
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }
            if (dt.Rows.Count > 0)
                existe = 1;
            else
                existe = 0;

            return existe;
        }
        public void ActualizarAsignacion(int id, int asignar)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("UPDATE servicios_ip_fija SET Asignada=@asiganada WHERE id=@id");
                oCon.AsignarParametroEntero("@asiganada", asignar);
                oCon.AsignarParametroEntero("@id", id);
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
        public int VerificarAsignacion(int id)
        {
            DataTable Dt = new DataTable();
            int Retorno = 0;
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT * FROM servicios_ip_fija WHERE id=@id");
                oCon.AsignarParametroEntero("@id", id);
                Dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                throw;
            }
            if ((Convert.ToInt32(Dt.Rows[0]["Asignada"])) == 1)
                Retorno = 1;
            else
                Retorno = 0;
            return Retorno;
        }
    }
}
