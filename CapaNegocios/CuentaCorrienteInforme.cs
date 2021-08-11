using CapaDatos;
using System;
using System.Data;

namespace CapaNegocios
{
    public class CuentaCorrienteInforme
    {
        private Conexion oCon = new Conexion();
        private DataTable dtResultado = new DataTable();

        public DataTable TraerPorGrupoServicio(string Desde, string Hasta)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando("select vw_ctacte_det.id_servicios_grupos as idGrupo,0 as idTipo,0 as idServicio, (select servicios_grupos.Nombre from servicios_grupos where servicios_grupos.id=vw_ctacte_det.id_servicios_grupos) as nombreGrupo, sum(vw_ctacte_det.Importe_Original-vw_ctacte_det.importe_bonificacion+vw_ctacte_det.importe_punitorio) as importeFinal from vw_ctacte_det where FechaDesde BETWEEN @Desde and @Hasta and vw_ctacte_det.id_servicios_grupos IS NOT NULL GROUP by vw_ctacte_det.id_servicios_grupos");
                oCon.AsignarParametroCadena("@Desde", Desde);
                oCon.AsignarParametroCadena("@Hasta", Hasta);
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

        public DataTable TraerPorTipoServicio(string Desde, string Hasta)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando("select vw_ctacte_det.id_servicios_grupos as idGrupo, vw_ctacte_det.id_servicios_tipos as idTipo, (select servicios_tipos.Nombre from servicios_tipos where servicios_tipos.id=vw_ctacte_det.id_servicios_tipos) as nombreTipo, sum(vw_ctacte_det.Importe_Original-vw_ctacte_det.importe_bonificacion+vw_ctacte_det.importe_punitorio) as importeFinal from vw_ctacte_det where FechaDesde BETWEEN @Desde and @Hasta GROUP by vw_ctacte_det.id_servicios_tipos");
                oCon.AsignarParametroCadena("@Desde", Desde);
                oCon.AsignarParametroCadena("@Hasta", Hasta);
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

        public DataTable TraerPorServicio(string Desde, string Hasta)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando("select vw_ctacte_det.id_servicios_grupos as idGrupo, vw_ctacte_det.id_servicios_tipos as idTipo, vw_ctacte_det.Id_Servicios as idServicio, vw_ctacte_det.Servicio as nombreServicio, sum(vw_ctacte_det.Importe_Original-vw_ctacte_det.importe_bonificacion+vw_ctacte_det.importe_punitorio) as importeFinal from vw_ctacte_det where FechaDesde BETWEEN @Desde and @Hasta GROUP by vw_ctacte_det.Id_Servicios");
                oCon.AsignarParametroCadena("@Desde", Desde);
                oCon.AsignarParametroCadena("@Hasta", Hasta);
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

        public DataTable TraerCantPartes(string Desde, string Hasta, int idTipo, int id)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();

                if (idTipo == 0)
                    oCon.CrearComando("select vw_ctacte_det.id_servicios_grupos,'Partes' as Partes, COUNT(id) as cantPartes, SUM(vw_ctacte_det.Importe_Original-vw_ctacte_det.importe_bonificacion+vw_ctacte_det.importe_punitorio) as importeFinal from vw_ctacte_det where id_servicios_grupos=" + id + " and tipo='p' and FechaDesde BETWEEN '" + Desde + "' and '" + Hasta + "'");
                else if (idTipo == 1)
                    oCon.CrearComando("select vw_ctacte_det.id_servicios_tipos,'Partes' as Partes, COUNT(id) as cantPartes, SUM(vw_ctacte_det.Importe_Original-vw_ctacte_det.importe_bonificacion+vw_ctacte_det.importe_punitorio) as importeFinal from vw_ctacte_det where id_servicios_tipos=" + id + " and tipo='p' and FechaDesde BETWEEN '" + Desde + "' and '" + Hasta + "'");
                else if (idTipo == 2)
                    oCon.CrearComando("select vw_ctacte_det.id_servicios,'Partes' as Partes, COUNT(id) as cantPartes, SUM(vw_ctacte_det.Importe_Original-vw_ctacte_det.importe_bonificacion+vw_ctacte_det.importe_punitorio) as importeFinal from vw_ctacte_det where id_servicios=" + id + " and tipo='p' and FechaDesde BETWEEN '" + Desde + "' and '" + Hasta + "'");




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

        public DataTable TraerCantServicios(string Desde, string Hasta, int idTipo, int id)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();

                if (idTipo == 0)
                    oCon.CrearComando("select vw_ctacte_det.id_servicios_grupos,'Servicios' as Servicios, COUNT(id) as cantServicios, SUM(vw_ctacte_det.Importe_Original-vw_ctacte_det.importe_bonificacion+vw_ctacte_det.importe_punitorio) as importeFinal from vw_ctacte_det where id_servicios_grupos=" + id + " and tipo='s' and FechaDesde BETWEEN '" + Desde + "' and '" + Hasta + "'");
                else if (idTipo == 1)
                    oCon.CrearComando("select vw_ctacte_det.id_servicios_tipos,'Servicios' as Servicios, COUNT(id) as cantServicios, SUM(vw_ctacte_det.Importe_Original-vw_ctacte_det.importe_bonificacion+vw_ctacte_det.importe_punitorio) as importeFinal from vw_ctacte_det where id_servicios_tipos=" + id + " and tipo='s' and FechaDesde BETWEEN '" + Desde + "' and '" + Hasta + "'");
                else if (idTipo == 2)
                    oCon.CrearComando("select vw_ctacte_det.id_servicios,'Servicios' as Servicios, COUNT(id) as cantServicios, SUM(vw_ctacte_det.Importe_Original-vw_ctacte_det.importe_bonificacion+vw_ctacte_det.importe_punitorio) as importeFinal from vw_ctacte_det where id_servicios=" + id + " and tipo='s' and FechaDesde BETWEEN '" + Desde + "' and '" + Hasta + "'");

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

        public DataTable TraerCantEquipos(string Desde, string Hasta, int idTipo, int id)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();


                if (idTipo == 0)
                    oCon.CrearComando("select vw_ctacte_det.id_servicios_grupos,'Equipos' as Equipos, COUNT(id) as cantEquipos, SUM(vw_ctacte_det.Importe_Original-vw_ctacte_det.importe_bonificacion+vw_ctacte_det.importe_punitorio) as importeFinal from vw_ctacte_det where id_servicios_grupos=" + id + " and tipo='e' and FechaDesde BETWEEN '" + Desde + "' and '" + Hasta + "'");
                else if (idTipo == 1)
                    oCon.CrearComando("select vw_ctacte_det.id_servicios_tipos,'Equipos' as Equipos, COUNT(id) as cantEquipos, SUM(vw_ctacte_det.Importe_Original-vw_ctacte_det.importe_bonificacion+vw_ctacte_det.importe_punitorio) as importeFinal from vw_ctacte_det where id_servicios_tipos=" + id + " and tipo='e' and FechaDesde BETWEEN '" + Desde + "' and '" + Hasta + "'");
                else if (idTipo == 2)
                    oCon.CrearComando("select vw_ctacte_det.id_servicios,'Equipos' as Equipos, COUNT(id) as cantEquipos, SUM(vw_ctacte_det.Importe_Original-vw_ctacte_det.importe_bonificacion+vw_ctacte_det.importe_punitorio) as importeFinal from vw_ctacte_det where id_servicios=" + id + " and tipo='e' and FechaDesde BETWEEN '" + Desde + "' and '" + Hasta + "'");


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

        public DataTable TraerDetalles(string Desde, string Hasta, int idTipo, int id)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                if (idTipo == 0)
                    oCon.CrearComando("select vw_ctacte_det.id_servicios_grupos,sub_servicio,COUNT(id) as cant,SUM(vw_ctacte_det.Importe_Original-vw_ctacte_det.importe_bonificacion+vw_ctacte_det.importe_punitorio) as importeFinal,tipo from vw_ctacte_det where id_servicios_grupos=" + id + "  and FechaDesde BETWEEN '" + Desde + "' and '" + Hasta + "' GROUP by sub_servicio");
                else if (idTipo == 1)
                    oCon.CrearComando("select vw_ctacte_det.id_servicios_tipos,sub_servicio,COUNT(id) as cant,SUM(vw_ctacte_det.Importe_Original-vw_ctacte_det.importe_bonificacion+vw_ctacte_det.importe_punitorio) as importeFinal,tipo from vw_ctacte_det where id_servicios_tipos=" + id + "  and FechaDesde BETWEEN '" + Desde + "' and '" + Hasta + "' GROUP by sub_servicio");
                else if (idTipo == 2)
                    oCon.CrearComando("select vw_ctacte_det.id_servicios,sub_servicio,COUNT(id) as cant,SUM(vw_ctacte_det.Importe_Original-vw_ctacte_det.importe_bonificacion+vw_ctacte_det.importe_punitorio) as importeFinal,tipo from vw_ctacte_det where id_servicios=" + id + "  and FechaDesde BETWEEN '" + Desde + "' and '" + Hasta + "' GROUP by sub_servicio");

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
