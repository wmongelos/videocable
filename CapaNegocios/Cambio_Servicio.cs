using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CapaNegocios
{
    public class Cambio_Servicio
    {
        private readonly bool cambiarVelocidad;
        private readonly int idUsuarioServicio;
        private readonly int idServicioNuevo;
        private readonly List<Tuple<int, int>> idsServiciosSubs_idsServiciosSubsTipos; //Item1: id_servicio_sub; Item2: id_servicio_sub_tipo
        private readonly int idVelocidad;
        private readonly int idVelocidadTipo;
        private DataTable dtUsuariosServSubs;
        private Usuarios_Servicios oUsuarioServicio;
        private bool actualizarTipoDeFacturacion = false;
        private int idTipoFacturacionNuevo;

        public Cambio_Servicio(int idUsuarioServicio, int idServicioNuevo, List<Tuple<int, int>> idsServiciosSubs_idsServiciosSubsTipos)
        {
            this.cambiarVelocidad = false;
            this.idUsuarioServicio = idUsuarioServicio;
            this.idServicioNuevo = idServicioNuevo;
            this.idsServiciosSubs_idsServiciosSubsTipos = idsServiciosSubs_idsServiciosSubsTipos;
        }

        public Cambio_Servicio(int idUsuarioServicio, int idServicioNuevo, List<Tuple<int, int>> idsServiciosSubs_idsServiciosSubsTipos, int idVel, int idVelTipo)
            : this(idUsuarioServicio, idServicioNuevo, idsServiciosSubs_idsServiciosSubsTipos)
        {
            this.cambiarVelocidad = true;
            this.idVelocidad = idVel;
            this.idVelocidadTipo = idVelTipo;
        }

        public void PisarServicioActual()
        {
            oUsuarioServicio = new Usuarios_Servicios().GetUsuarioServicio(idUsuarioServicio);

            if (oUsuarioServicio.Id_Servicios == idServicioNuevo)
            {
                throw new Exception("El servicio nuevo no puede ser igual al servicio actual");
            }

            dtUsuariosServSubs = new Usuarios_Servicios() 
                .ListarUsuariosServicios(oUsuarioServicio.Id_Usuarios)
                .AsEnumerable()
                .Where(col => col.Field<int>("id_usuarios_servicios") == idUsuarioServicio)
                .CopyToDataTable();

            if (!ValidarTiposDeSubservicios())
            {
                throw new Exception("Es necesario seleccionar al menos un sub servicio de tipo S");
            }

            if (new Configuracion().GetValor_N("Id_Tipo_Facturacion") == Convert.ToInt32(Tipo_Facturacion.Id_Tipo_Facturacion.POR_ZONAS))
            {
                VerificarSiHayCambioDeTipoDeFacturacion();
            }

            actualizarUsuariosServiciosSub();
            actualizarUsuariosServicios();
        }

        private void actualizarUsuariosServiciosSub()
        {
            //CAMBIO USUARIOS SERVICIOS ACTUALES
            List<int> idsServSubsYaGuardados = new List<int>();
            List<int> idsServSubsYaRemplazados = new List<int>();
            foreach (DataRow row in dtUsuariosServSubs.Rows)
            {
                foreach (Tuple<int, int> idSubNuevo in idsServiciosSubs_idsServiciosSubsTipos)
                {
                    if (Convert.ToInt32(row["Id_Servicios_Sub_Tipos"]) == idSubNuevo.Item2 &&
                        !idsServSubsYaGuardados.Contains(idSubNuevo.Item1) && 
                        !idsServSubsYaRemplazados.Contains(Convert.ToInt32(row["Id_Servicios_Sub"]))) 
                    {
                        int idUsuariosServicioSub = Convert.ToInt32(row["Id"]);
                        int idUsuarioServ = Convert.ToInt32(row["Id_Usuarios_Servicios"]);
                        int idServiciosSub = idSubNuevo.Item1;
                        int requiereIp = Convert.ToInt32(row["Requiere_Ip"]);
                        int IdBoniEsp = Convert.ToInt32(row["Id_Bonificacion_Esp"]);
                        int IdBoniAplicada = Convert.ToInt32(row["Id_Bonificacion_Aplicada"]);
                        DateTime fechaInicio = Convert.ToDateTime(row["fecha_inicio"]);
                        DateTime fechaFin = oUsuarioServicio.Fecha_Factura;
                        int idServiciosVelocidades;
                        int idServiciosVelocidadesTipo;
                        if ((Convert.ToInt32(row["Id_Servicios_Velocidades"]) > 0 || Convert.ToInt32(row["Id_Servicios_Velocidades_Tip"]) > 0) &&
                            cambiarVelocidad)
                        {
                            idServiciosVelocidades = this.idVelocidad;
                            idServiciosVelocidadesTipo = this.idVelocidadTipo;
                        }
                        else
                        {
                            idServiciosVelocidades = Convert.ToInt32(row["Id_Servicios_Velocidades"]);
                            idServiciosVelocidadesTipo = Convert.ToInt32(row["Id_Servicios_Velocidades_Tip"]);
                        }

                        new Usuarios_Servicios().Guardar_Subservicios(idUsuariosServicioSub, idUsuarioServ, idServiciosSub, idServiciosVelocidades, idServiciosVelocidadesTipo,
                            requiereIp, IdBoniEsp, IdBoniAplicada, 0, "", fechaInicio, fechaFin, (int)Borrados.Estado.Activo);

                        idsServSubsYaGuardados.Add(idSubNuevo.Item1);
                        idsServSubsYaRemplazados.Add(Convert.ToInt32(row["Id_Servicios_Sub"]));
                    }
                }
            }

            //AGREGAR o ACTIVAR NUEVOS USUARIOS SERVICIOS SUBS
            if (idsServiciosSubs_idsServiciosSubsTipos.Count > idsServSubsYaGuardados.Count)
            {
                DataTable dtUsuariosServiciosSubInactivos = new Usuarios_Servicios().ListarUsuariosServiciosSubInactivos(idUsuarioServicio);
                foreach (Tuple<int, int> idSubNuevo in idsServiciosSubs_idsServiciosSubsTipos)
                {
                    if (!idsServSubsYaGuardados.Contains(idSubNuevo.Item1))
                    {
                        dtUsuariosServiciosSubInactivos.DefaultView.RowFilter = $"id_servicios_sub = {idSubNuevo.Item1}";
                        if(dtUsuariosServiciosSubInactivos.DefaultView.ToTable().Rows.Count > 0)
                        {
                            int idUsuariosServicioSub = Convert.ToInt32(dtUsuariosServiciosSubInactivos.DefaultView.ToTable().Rows[0]["id"]);
                            int idUsuarioServ = this.idUsuarioServicio;
                            int idServiciosSub = idSubNuevo.Item1;
                            int idServiciosVelocidades = Convert.ToInt32(dtUsuariosServiciosSubInactivos.DefaultView.ToTable().Rows[0]["id_servicios_velocidades"]);
                            int idServiciosVelocidadesTipo = Convert.ToInt32(dtUsuariosServiciosSubInactivos.DefaultView.ToTable().Rows[0]["id_servicios_velocidades_tip"]); ;
                            int requiereIp = Convert.ToInt32(dtUsuariosServiciosSubInactivos.DefaultView.ToTable().Rows[0]["requiere_ip"]);
                            int IdBoniEsp = Convert.ToInt32(dtUsuariosServiciosSubInactivos.DefaultView.ToTable().Rows[0]["id_bonificacion_esp"]);
                            int IdBoniAplicada = Convert.ToInt32(dtUsuariosServiciosSubInactivos.DefaultView.ToTable().Rows[0]["id_bonificacion_aplicada"]);
                            DateTime fechaInicio = DateTime.Now;
                            DateTime fechaFin = oUsuarioServicio.Fecha_Factura;

                            new Usuarios_Servicios().Guardar_Subservicios(idUsuariosServicioSub, idUsuarioServ, idServiciosSub, idServiciosVelocidades, idServiciosVelocidadesTipo,
                                requiereIp, IdBoniEsp, IdBoniAplicada, 0, "", fechaInicio, fechaFin, (int)Borrados.Estado.Activo);

                            new Usuarios_Servicios().ActivarSubservicio(idUsuariosServicioSub);
                        }
                        else
                        {
                            int idUsuariosServicioSub = 0;
                            int idUsuarioServ = this.idUsuarioServicio;
                            int idServiciosSub = idSubNuevo.Item1;
                            int idServiciosVelocidades = 0;
                            int idServiciosVelocidadesTipo = 0;
                            int requiereIp = 0;
                            int IdBoniEsp = 0;
                            int IdBoniAplicada = 0;
                            DateTime fechaInicio = DateTime.Now;
                            DateTime fechaFin = oUsuarioServicio.Fecha_Factura;

                            new Usuarios_Servicios().Guardar_Subservicios(idUsuariosServicioSub, idUsuarioServ, idServiciosSub, idServiciosVelocidades, idServiciosVelocidadesTipo,
                                requiereIp, IdBoniEsp, IdBoniAplicada, 0, "", fechaInicio, fechaFin, (int)Borrados.Estado.Activo);
                        }

                        idsServSubsYaGuardados.Add(idSubNuevo.Item1);
                    }
                }
            }

            //BORRAR USUARIOS SERVICIOS SUBS NO GUARDADOS
            if (dtUsuariosServSubs.Rows.Count > idsServiciosSubs_idsServiciosSubsTipos.Count)
            {
                foreach (DataRow row in dtUsuariosServSubs.Rows)
                {
                    if (!idsServSubsYaRemplazados.Contains(Convert.ToInt32(row["Id_Servicios_Sub"])))
                    {
                        new Usuarios_Servicios().DesactivarSubservicio(Convert.ToInt32(row["id"]), Convert.ToInt32(Borrados.Estado.Inactivo));
                    }
                }
            }
        }

        private void VerificarSiHayCambioDeTipoDeFacturacion()
        {
            DataTable dtUsuarioServicioActual = new Usuarios_Servicios().Traer_datos_usuarios_servicios(idUsuarioServicio);

            int idTipoFacturacionActual = Convert.ToInt32(dtUsuarioServicioActual.Rows[0]["id_tipo_facturacion"]);
            int idUsuarioLocacion = Convert.ToInt32(dtUsuarioServicioActual.Rows[0]["id_usuarios_locaciones"]);
            int idLocalidad = new Usuarios_Locaciones().GetLocacion(idUsuarioLocacion).Id_Localidades;
            DataTable dtZonaLocalidad = new Localidades().ListarLocalidad_Zona(idLocalidad);
            if (dtZonaLocalidad.Rows.Count > 0)
                idTipoFacturacionNuevo = Convert.ToInt32(new Localidades().ListarLocalidad_Zona(idLocalidad).Rows[0]["Id_zona"]);
            else
                throw new Exception("La localidad no esta relacionada con ninguna zona");

            if(idTipoFacturacionActual != idTipoFacturacionNuevo)
            {
                actualizarTipoDeFacturacion = true;
            }
        }

        private void actualizarUsuariosServicios()
        {
            oUsuarioServicio.Id_Servicios = idServicioNuevo;
            DataTable dt = Tablas.DataServicios.Copy();
            oUsuarioServicio.Id_Servicios_Tipo = Tablas.DataServicios.AsEnumerable()
                .Where(dr => dr.Field<int>("id") == idServicioNuevo)
                .Select<DataRow, int>(dr => Convert.ToInt32(dr["id_servicios_tipos"])).First();
            if(actualizarTipoDeFacturacion)
                oUsuarioServicio.Id_Tipo_Facturacion = idTipoFacturacionNuevo;
            oUsuarioServicio.Guardar(oUsuarioServicio);
        }

        private bool ValidarTiposDeSubservicios()
        {
            foreach (Tuple<int, int> tuple in idsServiciosSubs_idsServiciosSubsTipos)
                if (tuple.Item2 == Convert.ToInt32(Servicios_Sub.SERVICIO_SUB_TIPOS.SUBSERVICIO))
                    return true;
            return false;
        }
    }
}
