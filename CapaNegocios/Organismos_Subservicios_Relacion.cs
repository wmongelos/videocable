using CapaDatos;
using System;
using System.Data;

namespace CapaNegocios
{
    public class Organismos_Subservicios_Relacion
    {
        public Int32 Id;
        public Int32 Id_Organismo;
        public Int32 Id_SubServicio;

        private Conexion oCon = new Conexion();

        public DataTable ListarPorOrganismo(int Id_Organismo)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                string comando = "SELECT organismos_subservicios_relacion.Id as id_organismos_subservicios_relacion, organismos.Id as id_organismos, " +
                    "organismos.Descripcion as organismo, servicios.id as id_servicios,servicios.descripcion as servicios, " +
                    "servicios_sub.id as id_subservicio, servicios_sub.descripcion as subservicio, servicios_sub_tipos.Nombre " +
                    "FROM organismos_subservicios_relacion " +
                    "LEFT JOIN organismos ON organismos.id = organismos_subservicios_relacion.Id_organismo " +
                    "LEFT JOIN servicios_sub ON servicios_sub.id = organismos_subservicios_relacion.Id_SubServicio " +
                    "LEFT JOIN servicios ON servicios_sub.id_servicios = servicios.id " +
                    "LEFT JOIN servicios_sub_tipos ON servicios_sub.Id_Servicios_Sub_Tipos = servicios_sub_tipos.Id " +
                    "WHERE organismos_subservicios_relacion.Id_organismo = @idOrganismo and organismos_subservicios_relacion.borrado = 0; ";
                oCon.CrearComando(comando);
                oCon.AsignarParametroEntero("@idOrganismo", Id_Organismo);
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

        public void Guardar(Organismos_Subservicios_Relacion oOrgSubRel)
        {
            try
            {
                if (VerificarSiSubServicioEnOrganismoEstaBorrado(oOrgSubRel))
                {
                    oCon.Conectar();
                    string comando = "UPDATE organismos_subservicios_relacion SET borrado = 0 WHERE id_organismo = @organismo and id_subservicio = @subservicio";
                    oCon.CrearComando(comando);
                    oCon.AsignarParametroEntero("@organismo", oOrgSubRel.Id_Organismo);
                    oCon.AsignarParametroEntero("@subservicio", oOrgSubRel.Id_SubServicio);
                    oCon.ComenzarTransaccion();
                    oCon.EjecutarComando();
                    oCon.ConfirmarTransaccion();
                    oCon.DesConectar();
                }
                else
                {
                    oCon.Conectar();
                    string comando = "INSERT INTO organismos_subservicios_relacion (id_organismo, id_subservicio) VALUES (@organismo,@subservicio)";
                    oCon.CrearComando(comando);
                    oCon.AsignarParametroEntero("@organismo", oOrgSubRel.Id_Organismo);
                    oCon.AsignarParametroEntero("@subservicio", oOrgSubRel.Id_SubServicio);
                    oCon.ComenzarTransaccion();
                    oCon.EjecutarComando();
                    oCon.ConfirmarTransaccion();
                    oCon.DesConectar();
                }
            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                throw;
            }
        }

        public void Eliminar(Organismos_Subservicios_Relacion oOrgSubRel)
        {
            try
            {
                oCon.Conectar();
                string comando = "UPDATE organismos_subservicios_relacion SET borrado = 1 WHERE id_organismo = @organismo and id_subservicio = @subservicio";
                oCon.CrearComando(comando);
                oCon.AsignarParametroEntero("@organismo", oOrgSubRel.Id_Organismo);
                oCon.AsignarParametroEntero("@subservicio", oOrgSubRel.Id_SubServicio);
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

        public DataTable GetIdsSubserviciosDeOrganismo(int id_organismo)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                string comando = "SELECT id_subservicio FROM organismos_subservicios_relacion WHERE id_organismo = @organismo AND borrado = 0";
                oCon.CrearComando(comando);
                oCon.AsignarParametroEntero("@organismo", id_organismo);
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

        public bool VerificarSiSubServicioEnOrganismoEstaBorrado(Organismos_Subservicios_Relacion oOrgSubRel)
        {
            int result = 0;
            try
            {
                oCon.Conectar();
                string comando = "SELECT count(*) as cant FROM organismos_subservicios_relacion WHERE id_organismo = @organismo and id_subservicio = @subservicio and borrado = 1";
                oCon.CrearComando(comando);
                oCon.AsignarParametroEntero("@organismo", oOrgSubRel.Id_Organismo);
                oCon.AsignarParametroEntero("@subservicio", oOrgSubRel.Id_SubServicio);
                result = oCon.EjecutarScalar();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }
            return (result > 0);
        }
    }
}
