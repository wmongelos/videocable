using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace CapaNegocios
{
    public class Partes_Informes
    {
        public enum Partes_Filtros
        {
            CATEGORIA = 0,
            ZONA = 1,
            LOCALIDAD = 2,
            OPERACION = 3,
            GRUPO = 4,
            TIPO = 5,
            SERVICIO = 6,
            TECNICO = 7,
            TODOS = 8,
            ESTADO_LOCALIDAD_OPERACION = 9,
            PERSONAL_AREAS_TECNICO = 10
        }

        public enum Tipo_Fecha
        {
            RECLAMO = 0,
            PROGRAMADO = 1,
            RECIBIDO = 2,
            REALIZADO = 3,
            MOVIL = 4
        }

        private Conexion oCon = new Conexion();

        public DataTable Listar(DataTable dtFiltrosSeleccionados, DateTime fechaDesde, DateTime fechaHasta, int idTipoFecha)
        {
            DataTable dt = new DataTable();
            string consulta = String.Empty;
            int indice = 0;
            DataRow[] drFiltroGTS;
            try
            {
                oCon.Conectar();

                consulta = String.Empty;

                consulta = "SELECT partes.Id AS 'id', partes_fallas.Nombre AS 'solicitud',usuarios.Codigo AS 'codigo',usuarios.Nombre AS 'nombre',usuarios.Apellido AS 'apellido',"
                    + " localidades.nombre as localidad,localidades_calles.Nombre AS 'calle',usuarios_locaciones.Altura AS 'altura',usuarios_locaciones.Piso AS 'piso', usuarios_locaciones.Depto AS 'depto',"
                    + " partes.Fecha_Reclamo AS 'fecha_reclamo',(SELECT personal.Nombre FROM personal WHERE(personal.Id = partes.id_Operadores)) AS 'operador',"
                    + " partes_estados.Nombre AS 'estado',partes.Id_Usuarios AS 'id_usuarios',partes.Id_Servicios AS 'id_servicios',partes.Id_Usuarios_Locaciones AS 'id_usuarios_locaciones',"
                    + " partes.Id_Locacion_Anterior AS 'id_locacion_anterior',partes.Id_Zonas AS 'id_zonas', localidades.Id AS 'id_localidad',"
                    + " partes.Id_Partes_Fallas AS 'id_partes_fallas',partes.Id_Partes_Soluciones AS 'id_partes_soluciones',partes.Id_Tecnicos AS 'id_tecnicos', partes.Id_Moviles AS 'id_moviles',"
                    + " partes.Id_Partes_Estados AS 'id_partes_estados',partes.Id_Operadores AS 'id_operadores',partes.Id_Areas AS 'id_areas',partes.Id_Usuarios_Servicios AS 'id_usuarios_servicios',"
                    + " servicios.Id_Servicios_Tipos AS 'id_servicios_tipos', servicios_tipos.Id_Servicios_Grupos AS 'id_servicios_grupos', partes.Id_Tipo_Problema AS 'id_tipo_problema',"
                    + " partes_fallas.Id_Partes_Operaciones AS 'id_partes_operaciones'"
                    + " FROM partes_usuarios_servicios"
                    + " LEFT JOIN partes ON partes.Id = partes_usuarios_servicios.id_parte"
                    + " LEFT JOIN usuarios ON usuarios.Id = partes.Id_Usuarios"
                    + " LEFT JOIN servicios ON servicios.Id = partes.Id_Servicios"
                    + " LEFT JOIN servicios_tipos ON servicios.Id_Servicios_Tipos = servicios_tipos.Id"
                    + " LEFT JOIN servicios_grupos ON servicios_grupos.Id = servicios_tipos.Id_Servicios_Grupos"
                    + " LEFT JOIN usuarios_locaciones ON usuarios_locaciones.Id = partes.Id_Usuarios_Locaciones"
                    + " LEFT JOIN partes_fallas ON partes_fallas.Id = partes.Id_Partes_Fallas"
                    + " LEFT JOIN partes_estados ON partes_estados.Id = partes.Id_Partes_Estados"
                    + " LEFT JOIN localidades ON localidades.Id = usuarios_locaciones.Id_Localidades"
                    + " LEFT JOIN localidades_calles ON localidades_calles.Id = usuarios_locaciones.Id_Calle";


                if (dtFiltrosSeleccionados.Select(String.Format("idTipoConcepto={0}", Convert.ToInt32(Partes_Informes.Partes_Filtros.TODOS))).Length == 0)
                {

                    consulta = consulta + " WHERE ";
                    drFiltroGTS = dtFiltrosSeleccionados.Select(String.Format("idTipoConcepto={0} or idTipoConcepto={1} or idTipoConcepto={2}", Convert.ToInt32(Partes_Informes.Partes_Filtros.GRUPO), Convert.ToInt32(Partes_Informes.Partes_Filtros.TIPO), Convert.ToInt32(Partes_Informes.Partes_Filtros.SERVICIO)));
                    if (drFiltroGTS.Length > 0)
                    {

                        indice = 0;
                        foreach (DataRow fila in drFiltroGTS)
                        {
                            if (indice != (drFiltroGTS.Length - 1))
                            {
                                if (Convert.ToInt32(fila["idTipoConcepto"]) == Convert.ToInt32(Partes_Informes.Partes_Filtros.SERVICIO))
                                    consulta += String.Format(" partes_usuarios_servicios.id_servicio={0} or ", fila["idConcepto"].ToString());
                                else if (Convert.ToInt32(fila["idTipoConcepto"]) == Convert.ToInt32(Partes_Informes.Partes_Filtros.GRUPO))
                                    consulta += String.Format(" partes_usuarios_servicios.id_servicios_tipos={0} or ", fila["idConcepto"].ToString());
                                else if (Convert.ToInt32(fila["idTipoConcepto"]) == Convert.ToInt32(Partes_Informes.Partes_Filtros.TIPO))
                                    consulta += String.Format(" partes_usuarios_servicios.id_servicios_grupos={0} or ", fila["idConcepto"].ToString());
                            }
                            else
                            {
                                if (Convert.ToInt32(fila["idTipoConcepto"]) == Convert.ToInt32(Partes_Informes.Partes_Filtros.SERVICIO))
                                    consulta += String.Format(" partes_usuarios_servicios.id_servicio={0} ", fila["idConcepto"].ToString());
                                else if (Convert.ToInt32(fila["idTipoConcepto"]) == Convert.ToInt32(Partes_Informes.Partes_Filtros.GRUPO))
                                    consulta += String.Format(" partes_usuarios_servicios.id_servicios_tipos={0} ", fila["idConcepto"].ToString());
                                else if (Convert.ToInt32(fila["idTipoConcepto"]) == Convert.ToInt32(Partes_Informes.Partes_Filtros.TIPO))
                                    consulta += String.Format(" partes_usuarios_servicios.id_servicios_grupos={0} ", fila["idConcepto"].ToString());
                            }

                            indice++;
                        }

                    }

                    if (!consulta.EndsWith(" and ") && !consulta.EndsWith(" WHERE "))
                        consulta = consulta + " AND ";
                    foreach (DataRow fila in dtFiltrosSeleccionados.Rows)
                    {
                        if (Convert.ToInt32(fila["idTipoConcepto"]) == Convert.ToInt32(Partes_Informes.Partes_Filtros.CATEGORIA))
                            consulta += String.Format(" partes.id_zonas={0} and ", fila["idConcepto"].ToString());
                        else if (Convert.ToInt32(fila["idTipoConcepto"]) == Convert.ToInt32(Partes_Informes.Partes_Filtros.ZONA))
                            consulta += String.Format(" partes.id_zonas={0} and ", fila["idConcepto"].ToString());
                        else if (Convert.ToInt32(fila["idTipoConcepto"]) == Convert.ToInt32(Partes_Informes.Partes_Filtros.LOCALIDAD))
                            consulta += String.Format(" partes.id_localidad={0} and ", fila["idConcepto"].ToString());
                        else if (Convert.ToInt32(fila["idTipoConcepto"]) == Convert.ToInt32(Partes_Informes.Partes_Filtros.OPERACION))
                            consulta += String.Format(" partes.id_partes_operaciones={0} and ", fila["idConcepto"].ToString());
                        else if (Convert.ToInt32(fila["idTipoConcepto"]) == Convert.ToInt32(Partes_Informes.Partes_Filtros.TECNICO))
                            consulta += String.Format(" partes.id_tecnicos={0} and ", fila["idConcepto"].ToString());
                    }
                }

                if (consulta.Contains(" WHERE "))
                {
                    if (!consulta.EndsWith(" and ") && !consulta.EndsWith(" WHERE "))
                        consulta = consulta + " AND ";
                }
                else
                    consulta = consulta + " WHERE ";

                if (idTipoFecha == Convert.ToInt32(Tipo_Fecha.RECLAMO))
                    consulta += String.Format(" date(partes.fecha_reclamo)>=date(@fecha_desde) and date(partes.fecha_reclamo)<=date(@fecha_hasta)");
                else if (idTipoFecha == Convert.ToInt32(Tipo_Fecha.REALIZADO))
                    consulta += String.Format(" date(partes.fecha_realizado>=date(@fecha_desde) and date(partes.fecha_realizado)<=date(@fecha_hasta)");
                else if (idTipoFecha == Convert.ToInt32(Tipo_Fecha.PROGRAMADO))
                    consulta += String.Format(" date(partes.fecha_programado)>=date(@fecha_desde) and date(partes.fecha_programado)<=date(@fecha_hasta)");
                else if (idTipoFecha == Convert.ToInt32(Tipo_Fecha.RECIBIDO))
                    consulta += String.Format(" date(partes.fecha_recibido)>=date(@fecha_desde) and date(partes.fecha_recibido)<=date(@fecha_hasta)");
                else if (idTipoFecha == Convert.ToInt32(Tipo_Fecha.MOVIL))
                    consulta += String.Format(" date(partes.fecha_movil)>=date(@fecha_desde) and date(partes.fecha_movil)<=date(@fecha_hasta)");

                oCon.CrearComando(consulta);

                oCon.AsignarParametroFecha("@fecha_desde", fechaDesde);
                oCon.AsignarParametroFecha("@fecha_hasta", fechaHasta);

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

        public string ListaToString<T>(List<T> lista)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("(");
            for (int i = 0; i < lista.Count; i++)
            {
                sb.Append(lista[i].ToString());
                if (i < (lista.Count - 1))
                    sb.Append(", ");
                else
                    sb.Append(")");
            }
            return sb.ToString();
        }

        public DataTable Listar_historial(List<int> EstadosParte, List<int> zonas, List<int> Localidades, List<int> Operaciones, DateTime desde, DateTime hasta, int tipoFecha, List<int> Areas, List<int> Personal, List<int> servicios)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                string consulta = "SELECT partes_usuarios_servicios.id_parte, CAST(usuarios.codigo as char(8)) as codigo_usuario,CONCAT(usuarios.apellido,', ' ,usuarios.nombre) as usuario, " +
                    "partes_usuarios_servicios.id as id_parte_usuarios_servicio, partes_usuarios_servicios.id_usuarios_servicios, " +
                    "servicios.descripcion as servicio, partes_fallas.nombre AS parte_falla, " +
                    "partes_operaciones.nombre as partes_operaciones,partes.fecha_reclamo , " +
                    "partes.fecha_programado, " +
                    "partes.fecha_realizado, ifnull(partes_estados.nombre, 'SIN DEFINIR') as Estado," +
                    " ifnull(zonas.nombre, 'SIN DEFINIR') as Zona, " +
                    "ifnull(localidades.nombre, 'SIN DEFINIR') as localidad, " +
                    "ifnull(usuarios_locaciones.calle, 'SIN DEFINIR') as calle," +
                    "ifnull(usuarios_locaciones.altura, -1) as altura, " +
                    "ifnull(usuarios_locaciones.id, -1) as id_usuarios_locaciones," +
                    "ifnull(personal.nombre,'SIN DEFINIR') as personal, ifnull(personal_areas.nombre,'SIN DEFINIR') as area," +
                    "partes.id_partes_estados, usuarios.id as id_usuarios, servicios.requiere_equipo " +
                    "from partes_usuarios_servicios " +
                    "inner join partes ON partes_usuarios_servicios.id_parte = partes.id " +
                    "left join partes_fallas ON partes_fallas.id = partes_usuarios_servicios.id_parte_falla " +
                    "left join servicios ON servicios.id = partes_usuarios_servicios.id_servicio " +
                    "left join usuarios ON usuarios.id = partes.id_usuarios " +
                    "left join usuarios_locaciones on usuarios_locaciones.id = partes.id_usuarios_locaciones " +
                    "left join localidades on localidades.id = usuarios_locaciones.id_localidades " +
                    "left join partes_estados on partes_estados.id = partes.id_partes_estados " +
                    "left join partes_operaciones on partes_operaciones.id = partes_fallas.id_partes_operaciones " +
                    "left join zonas_localidades on zonas_localidades.id_localidad = localidades.id " +
                    "left join zonas on zonas.id = zonas_localidades.id_zona " +
                    "left join personal on partes.id_operadores = personal.id " +
                    "left join personal_areas on personal_areas.id = personal.id_personal_areas " +
                    "where partes_usuarios_servicios.borrado = 0 and ( partes_estados.id != 0 and partes_estados.id != 8)";

                string condicion = string.Empty;

                if (tipoFecha == Convert.ToInt32(Partes_Informes.Tipo_Fecha.RECLAMO))
                    condicion = "and DATE(partes.fecha_reclamo) between @desde and @hasta";
                else if (tipoFecha == Convert.ToInt32(Partes_Informes.Tipo_Fecha.PROGRAMADO))
                    condicion = "and partes.fecha_programado between @desde and @hasta";
                else if (tipoFecha == Convert.ToInt32(Partes_Informes.Tipo_Fecha.REALIZADO))
                    condicion = "and partes.fecha_realizado between @desde and @hasta";
                else
                    throw new Exception("Filtro de fechas invalido");

                if (EstadosParte.Count > 0)
                    condicion = string.Format("{0} and partes_estados.id in {1}", condicion, ListaToString<int>(EstadosParte));

                if (zonas.Count > 0)
                    condicion = string.Format("{0} and zonas.id in {1}", condicion, ListaToString<int>(zonas));                   

                if (Localidades.Count > 0)
                    condicion = string.Format("{0} and localidades.id in {1}", condicion, ListaToString<int>(Localidades));

                if (Operaciones.Count > 0)
                    condicion = string.Format("{0} and partes_operaciones.id in {1}", condicion, ListaToString<int>(Operaciones));

                if (Areas.Count > 0)
                    condicion = string.Format("{0} and personal_areas.id in {1}", condicion, ListaToString<int>(Areas));

                if (Personal.Count > 0)
                    condicion = string.Format("{0} and personal.id in {1}", condicion, ListaToString<int>(Personal));

                if (servicios.Count > 0)
                    condicion = string.Format("{0} and servicios.id in {1}", condicion, ListaToString<int>(servicios));

                consulta = string.Format("{0} {1}", consulta, condicion);

                oCon.CrearComando(consulta);
                oCon.AsignarParametroFecha("@desde", desde);
                oCon.AsignarParametroFecha("@hasta", hasta);

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

        public DataTable ListarPartesInfraestructura(DateTime desde, DateTime hasta, int tipoFecha)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                string consulta = " select servicios_grupos.nombre as servicio_grupo, servicios_tipos.nombre as servicio_tipo, partes_infraestructura.id_parte, "
                                + " partes_fallas.nombre as parte_falla, partes_infraestructura.Detalle as descripcion_falla,"
                                + " partes_operaciones.nombre as partes_operaciones,partes.fecha_reclamo , partes.fecha_programado, partes.fecha_realizado,"
                                + " ifnull(partes_estados.nombre, 'sin definir') as parte_estado,"
                                + " ifnull(personal.nombre, 'sin definir') as personal, ifnull(personal_areas.nombre, 'sin definir') as area,partes.id_partes_estados,"
                                + " localidades.nombre as localidad, localidades_calles.nombre as calle, partes_infraestructura.altura"
                                + " from partes"
                                + " inner join partes_infraestructura on partes_infraestructura.id_parte = partes.id"
                                + " left join partes_fallas on partes_fallas.id = partes.id_partes_fallas"
                                + " left join partes_estados on partes_estados.id = partes.id_partes_estados"
                                + " left join partes_operaciones on partes_operaciones.id = partes_fallas.id_partes_operaciones"
                                + " left join personal on partes.id_operadores = personal.id"
                                + " left join personal_areas on personal_areas.id = personal.id_personal_areas"
                                + " left join servicios_tipos on servicios_tipos.id = partes_infraestructura.id_tipo_servicio"
                                + " left join servicios_grupos on servicios_Grupos.id = partes_infraestructura.id_grupo_servicio"
                                + " left join localidades on localidades.id = partes_infraestructura.id_localidad"
                                + " left join localidades_calles on localidades_calles.id = partes_infraestructura.id_calle"
                                + " where partes.borrado = 0 and partes_infraestructura.borrado = 0 and(partes_estados.id != 0 and partes_estados.id != 8)"
                                + $" and partes_operaciones.id = {Convert.ToInt32(Partes.Partes_Operaciones.INFRAESTRUCTURA)}";

                string condicion = "";
                if (tipoFecha == Convert.ToInt32(Partes_Informes.Tipo_Fecha.RECLAMO))
                    condicion = "and DATE(partes.fecha_reclamo) between @desde and @hasta";
                else if (tipoFecha == Convert.ToInt32(Partes_Informes.Tipo_Fecha.PROGRAMADO))
                    condicion = "and partes.fecha_programado between @desde and @hasta";
                else if (tipoFecha == Convert.ToInt32(Partes_Informes.Tipo_Fecha.REALIZADO))
                    condicion = "and partes.fecha_realizado between @desde and @hasta";
                else
                    throw new Exception("Filtro de fechas invalido");

                consulta = $"{consulta} {condicion}";

                oCon.CrearComando(consulta);
                oCon.AsignarParametroFecha("@desde", desde);
                oCon.AsignarParametroFecha("@hasta", hasta);
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
            }
            return dt;
        }

    }
}
