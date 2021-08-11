using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;

namespace CapaNegocios
{
	public class InformeCajasMensual
	{


		private Conexion oCon = new Conexion();

		public enum TipoInforme
        {
			CABLE = 1,
			INTERNET = 2,
			MMDS = 3,
			CODIFICADO = 4,
			PERIODO = 5,
			PLAN_VERANO = 6,
			SERVICIOS_NO_TIC = 7,
			PUBLICIDAD = 8,
			ALQUILER = 9,
			IBB = 10

		}

		public bool GuardarRelacion(int idInforme, int idServicio,out int idCreado)
        {
            try
            {
				oCon.Conectar();
				oCon.CrearComando("INSERT INTO informes_servicios_relacion (id_informe_servicio,id_servicio) values (@idinforme,@idservicio);select @@identity");
				oCon.AsignarParametroEntero("@idinforme", idInforme);
				oCon.AsignarParametroEntero("@idservicio", idServicio);
				idCreado = oCon.EjecutarScalar();
				oCon.DesConectar();
				return true;
            }
            catch (Exception)
            {
				idCreado = -1;
				return false;
                throw;
            }
        }

		public DataTable ListarInfomes()
		{
			DataTable dt = new DataTable();
			try
			{
				oCon.Conectar();
				oCon.CrearComando("SELECT * from informes_servicios");
				dt = oCon.Tabla();
				oCon.DesConectar();
			}
			catch (Exception c)
			{
				oCon.DesConectar();
				throw;
			}
			return dt;
		}

		public DataTable ListarServiciosPorInforme()
        {
			DataTable dt = new DataTable();
            try
            {
				oCon.Conectar();
				oCon.CrearComando("select informes_servicios_relacion.id, informes_servicios_relacion.id_informe_servicio, informes_servicios_relacion.id_servicio,servicios.descripcion as servicio" +
					" from informes_servicios_relacion" +
					" left join servicios on servicios.id=informes_servicios_relacion.id_servicio" +
					" where informes_servicios_relacion.id_informe_servicio > 0 ");
				dt = oCon.Tabla();
				oCon.DesConectar();
            }
            catch (Exception c)
            {
				oCon.DesConectar();
                throw;
            }
			return dt;
        }

		public DataTable GenerarEstructura(bool prepago,TipoInforme tipo)
		{
			Puntos_Cobros oPunto = new Puntos_Cobros();
			DataTable dt = new DataTable();
			dt = oPunto.Listar();
			int cantCol = dt.Columns.Count;
			int x = 2;
			while (dt.Columns.Count > 2)
				dt.Columns.RemoveAt(x);

			if (dt.Rows.Count > 0)
			{
				if(tipo == TipoInforme.CABLE || tipo == TipoInforme.INTERNET || tipo == TipoInforme.CODIFICADO || tipo == TipoInforme.MMDS)
                {
					dt.Columns.Add("Conexion", typeof(decimal));
					dt.Columns["conexion"].DefaultValue = 0;

					dt.Columns.Add("Atrasado", typeof(decimal));
					dt.Columns["Atrasado"].DefaultValue = 0;

					dt.Columns.Add("Mensual", typeof(decimal));
					dt.Columns["Mensual"].DefaultValue = 0;

					dt.Columns.Add("Adelantado", typeof(decimal));
					dt.Columns["Adelantado"].DefaultValue = 0;

					dt.Columns.Add("Punitorio", typeof(decimal));
					dt.Columns["Punitorio"].DefaultValue = 0;

					dt.Columns.Add("Plan_de_pago", typeof(decimal));
					dt.Columns["Plan_de_pago"].DefaultValue = 0;

					dt.Columns.Add("Especiales", typeof(decimal));
					dt.Columns["Especiales"].DefaultValue = 0;

					if (prepago)
					{
						dt.Columns.Add("Conexion_pre", typeof(decimal));
						dt.Columns["Conexion_pre"].DefaultValue = 0;

						dt.Columns.Add("Recarga_pre", typeof(decimal));
						dt.Columns["Recarga_pre"].DefaultValue = 0;
					}
                }
                else
                {
					dt.Columns.Add("Importe", typeof(decimal));
					dt.Columns["Importe"].DefaultValue = 0;
				}
			}
			return dt;
		}

		public List<int> ListarServiciosInforme(int idInforme)
		{
			List<int> lista = new List<int>();
			DataTable dt = new DataTable();
			try
			{
				oCon.Conectar();
				oCon.CrearComando("SELECT id_servicio from informes_servicios_relacion WHERE id_informe_servicio=@id");
				oCon.AsignarParametroEntero("@id", idInforme);
				dt = oCon.Tabla();
				oCon.DesConectar();
			}
			catch (Exception)
			{
				oCon.DesConectar();
				throw;
			}
			foreach (DataRow item in dt.Rows)
				lista.Add(Convert.ToInt32(item["id_servicio"]));
			return lista;

		}

		public bool EliminarRelacion(int id)
		{
			try
			{
				oCon.Conectar();
				oCon.CrearComando("delete from informes_Servicios_relacion where id=@id");
				oCon.AsignarParametroEntero("@id", id);
				oCon.EjecutarComando();
				oCon.DesConectar();
				return true;
			}
			catch (Exception c)
			{
				oCon.DesConectar();
				return false;
			}
		}


		public DataTable ListarConexiones(int idPuntoCobro, int idCajaGeneralDesde, int idCajaGeneralHasta, string listaIdServicios, int cuenta,bool detalle)
		{
			DataTable dt = new DataTable();
			try
			{
				string campos = "";
                if (detalle == false)
					campos = "SUM(usuarios_ctacte_relacion.Importe_imputa - usuarios_ctacte_relacion.Importe_Punitorio) AS importe_conexiones ";
				else
					campos = "usuarios.codigo,usuarios.apellido,usuarios.nombre,servicios.descripcion as servicio,caja_diaria.id as NumeroCajaDiaria,usuarios_ctacte_recibos.numero_muestra,if(usuarios_ctacte_det.Tipo = 'P',partes_fallas.nombre,'ASIGNACION EQUIPO') AS Detalle ,(usuarios_ctacte_relacion.Importe_imputa - usuarios_ctacte_relacion.Importe_Punitorio) AS importe_conexiones ";

				string consulta = "SELECT " + campos + " FROM usuarios_ctacte_recibos"
				+ " LEFT JOIN puntos_cobros ON puntos_cobros.id = usuarios_ctacte_recibos.Id_Puntos_Cobros"
				+ " LEFT JOIN usuarios_ctacte_relacion ON usuarios_ctacte_relacion.Id_Usuarios_ctacte_recibos = usuarios_ctacte_recibos.id"
				+ " LEFT JOIN usuarios_ctacte_det ON usuarios_ctacte_det.Id = usuarios_ctacte_relacion.Id_Usuarios_ctacte_det"
				+ " LEFT JOIN usuarios_ctacte ON usuarios_ctacte.id = usuarios_ctacte_det.Id_Usuarios_CtaCte"
				+ " LEFT JOIN usuarios_ctacte_recibos_det ON usuarios_ctacte_recibos_det.id_usuarios_ctacte_recibos = usuarios_ctacte_recibos.id"
				+ " LEFT JOIN servicios ON servicios.Id = usuarios_ctacte_det.Id_Servicios"
				+ " LEFT JOIN caja_diaria ON caja_diaria.Id = usuarios_ctacte_recibos.Id_Caja_Diaria"
				+ " LEFT JOIN caja_general ON caja_general.Id = caja_diaria.Id_Cierre_General"
				+ " LEFT JOIN usuarios ON usuarios.Id = usuarios_ctacte_recibos.Id_Usuarios"
				+ " LEFT JOIN comprobantes ON comprobantes.id = usuarios_ctacte.Id_comprobantes_ref"
				+ " LEFT JOIN partes ON partes.id = usuarios_ctacte_det.id_tipo"
				+ " LEFT JOIN partes_fallas ON partes_fallas.id = partes.id_partes_fallas"
				+ " WHERE usuarios_ctacte_det.Id_Servicios = servicios.Id"
				+ " AND servicios.Id in (?)"
				+ " AND usuarios_ctacte_recibos.borrado = 0"
				+ " AND usuarios_ctacte_relacion.Borrado = 0"
				+ " AND puntos_cobros.Borrado = 0"
				+ " AND caja_diaria.borrado = 0"
				+ " AND caja_general.borrado = 0"
				+ " AND caja_general.id BETWEEN @desde AND @hasta"
				+ " AND (usuarios_ctacte_det.Tipo = 'P' or usuarios_ctacte_det.Tipo = 'E')"
				+ " AND servicios.id_servicios_modalidad !=1"
				+ " AND comprobantes.Id_Comprobantes_Tipo != 10"
				+ " AND puntos_cobros.Id = @punto"
				+ " AND usuarios_ctacte_recibos.cuenta = @cuenta";
				if(detalle==false)
					consulta = consulta + " GROUP BY puntos_cobros.Id";
				else
					consulta = consulta + " GROUP BY puntos_cobros.Id,usuarios_ctacte_recibos_det.id";

				consulta = consulta.Replace("?", listaIdServicios);

				oCon.Conectar();
				oCon.CrearComando(consulta);
				oCon.AsignarParametroEntero("@desde", idCajaGeneralDesde);
				oCon.AsignarParametroEntero("@hasta", idCajaGeneralHasta);
				oCon.AsignarParametroEntero("@punto", idPuntoCobro);
				oCon.AsignarParametroEntero("@cuenta", cuenta);
				dt = oCon.Tabla();
				oCon.DesConectar();
			}
			catch (Exception x)
			{
				oCon.DesConectar();
				throw;
			}

			return dt;
		}


        public DataTable ListarMovimientos(int idPuntoCobro, int idCajaGeneralDesde, int idCajaGeneralHasta, string listaIdServicios, string tipo, int cuenta,bool detalle)
		{
			DataTable dt = new DataTable();
			try
			{
				oCon.Conectar();
				string aux = "";
				if (tipo == "mensual")
					aux = " AND DATE_FORMAT(usuarios_ctacte_recibos.Fecha_movimiento, '%Y%m') = DATE_FORMAT(usuarios_ctacte_det.Fecha_Desde, '%Y%m')";
				if (tipo == "atrasado")
					aux = " AND DATE_FORMAT(usuarios_ctacte_recibos.Fecha_movimiento, '%Y%m') > DATE_FORMAT(usuarios_ctacte_det.Fecha_Desde, '%Y%m')";
				if (tipo == "adelantado")
					aux = " AND DATE_FORMAT(usuarios_ctacte_recibos.Fecha_movimiento, '%Y%m') < DATE_FORMAT(usuarios_ctacte_det.Fecha_Desde, '%Y%m')";

				string campos = "";
				if (detalle == false)
					campos = "SUM(usuarios_ctacte_relacion.Importe_imputa - usuarios_ctacte_relacion.Importe_Punitorio) AS importe";
				else
					campos = "usuarios.codigo,usuarios.apellido,usuarios.nombre,servicios.descripcion as servicio,caja_diaria.id as id_caja_Diaria,usuarios_ctacte_recibos.numero_muestra,servicios_sub.descripcion as detalle, (usuarios_ctacte_relacion.Importe_imputa - usuarios_ctacte_relacion.Importe_Punitorio) AS importe";


				string consulta = "SELECT " + campos + " FROM usuarios_ctacte_recibos"
					+ " LEFT JOIN puntos_cobros ON puntos_cobros.id = usuarios_ctacte_recibos.Id_Puntos_Cobros"
					+ " LEFT JOIN usuarios_ctacte_relacion ON usuarios_ctacte_relacion.Id_Usuarios_ctacte_recibos = usuarios_ctacte_recibos.id"
					+ " LEFT JOIN usuarios_ctacte_det ON usuarios_ctacte_det.Id = usuarios_ctacte_relacion.Id_Usuarios_ctacte_det"
					+ " LEFT JOIN usuarios_ctacte ON usuarios_ctacte.id = usuarios_ctacte_det.Id_Usuarios_CtaCte"
					+ " LEFT JOIN usuarios_ctacte_recibos_det ON usuarios_ctacte_recibos_det.id_usuarios_ctacte_recibos = usuarios_ctacte_recibos.Id"
					+ " LEFT JOIN servicios ON servicios.Id = usuarios_ctacte_det.Id_Servicios"
					+ " LEFT JOIN usuarios_servicios ON usuarios_servicios.Id = usuarios_ctacte_det.id_usuarios_servicios"
					+ " LEFT JOIN usuarios_servicios_sub ON usuarios_servicios_sub.Id_usuarios_Servicios = usuarios_servicios.id"
					+ " LEFT JOIN servicios_sub ON servicios_sub.id = usuarios_servicios_sub.id_servicios_sub"
					+ " LEFT JOIN caja_diaria ON caja_diaria.Id = usuarios_ctacte_recibos.Id_Caja_Diaria"
					+ " LEFT JOIN caja_general ON caja_general.Id = caja_diaria.Id_Cierre_General"
					+ " LEFT JOIN usuarios ON usuarios.Id = usuarios_ctacte_recibos.Id_Usuarios"
					+ " LEFT JOIN comprobantes ON comprobantes.id = usuarios_ctacte.Id_comprobantes_ref"
					+ " WHERE usuarios_ctacte_det.Id_Servicios = servicios.Id"
					+ " AND servicios.Id in (?)"
					+ " AND usuarios_ctacte_recibos.borrado = 0"
					+ " AND usuarios_ctacte_relacion.Borrado = 0"
					+ " AND puntos_cobros.Borrado = 0"
					+ " AND caja_diaria.borrado = 0"
					+ " AND caja_general.borrado = 0"
					+ " AND caja_general.id BETWEEN @desde AND @hasta"
					+ " AND servicios.id_servicios_modalidad !=1"
					+ " AND usuarios_ctacte_det.Tipo = 'S'"
					+ " AND comprobantes.Id_Comprobantes_Tipo != 10"
					+ aux
					+ " AND puntos_cobros.Id = @punto"
					+ " AND usuarios_ctacte_recibos.cuenta = @cuenta";
				if (detalle == false)
					consulta = consulta + " GROUP BY puntos_cobros.Id";
				else
					consulta = consulta + " GROUP BY puntos_cobros.Id,usuarios.id";
				consulta = consulta.Replace("?", listaIdServicios);

				oCon.CrearComando(consulta);
				oCon.AsignarParametroEntero("@desde", idCajaGeneralDesde);
				oCon.AsignarParametroEntero("@hasta", idCajaGeneralHasta);
				oCon.AsignarParametroEntero("@punto", idPuntoCobro);
				oCon.AsignarParametroEntero("@cuenta", cuenta);
				dt = oCon.Tabla();
				oCon.DesConectar();
			}
			catch (Exception c)
			{
				oCon.DesConectar();
				throw;
			}
			return dt;
		}

		public DataTable ListarPunitorios(int idPuntoCobro, int idCajaGeneralDesde, int idCajaGeneralHasta, string listaIdServicios, int cuenta,bool detalle)
		{
			DataTable dt = new DataTable();
			try
			{
				oCon.Conectar();

				string campos = "";
				if (detalle == false)
					campos = "SUM(usuarios_ctacte_relacion.Importe_Punitorio) AS Importe_Punitorio";
				else
					campos = "usuarios.codigo,usuarios.apellido,usuarios.nombre,servicios.descripcion as servicio,caja_diaria.id as id_caja_Diaria,usuarios_ctacte_recibos.numero_muestra,servicios_sub.descripcion as detalle, (usuarios_ctacte_relacion.Importe_Punitorio) AS Importe_Punitorio";


				string consulta = "SELECT " + campos + " FROM usuarios_ctacte_recibos"
				+ " LEFT JOIN puntos_cobros ON puntos_cobros.id = usuarios_ctacte_recibos.Id_Puntos_Cobros"
				+ " LEFT JOIN usuarios_ctacte_relacion ON usuarios_ctacte_relacion.Id_Usuarios_ctacte_recibos = usuarios_ctacte_recibos.id"
				+ " LEFT JOIN usuarios_ctacte_det ON usuarios_ctacte_det.Id = usuarios_ctacte_relacion.Id_Usuarios_ctacte_det"
				+ " LEFT JOIN usuarios_ctacte ON usuarios_ctacte.id = usuarios_ctacte_det.Id_Usuarios_CtaCte"
				+ " LEFT JOIN servicios ON servicios.Id = usuarios_ctacte_det.Id_Servicios"
				+ " LEFT JOIN usuarios_servicios ON usuarios_servicios.Id = usuarios_ctacte_det.id_usuarios_servicios"
				+ " LEFT JOIN usuarios_servicios_sub ON usuarios_servicios_sub.Id_usuarios_Servicios = usuarios_servicios.id"
				+ " LEFT JOIN servicios_sub ON servicios_sub.id = usuarios_servicios_sub.id_servicios_sub"
				+ " LEFT JOIN caja_diaria ON caja_diaria.Id = usuarios_ctacte_recibos.Id_Caja_Diaria"
				+ " LEFT JOIN caja_general ON caja_general.Id = caja_diaria.Id_Cierre_General"
				+ " LEFT JOIN usuarios ON usuarios.Id = usuarios_ctacte_recibos.Id_Usuarios"
				+ " LEFT JOIN comprobantes ON comprobantes.id = usuarios_ctacte.Id_comprobantes_ref"
				+ " WHERE usuarios_ctacte_det.Id_Servicios = servicios.Id"
				+ "	AND servicios.Id in (?)"
				+ " AND usuarios_ctacte_recibos.borrado = 0"
				+ " AND usuarios_ctacte_relacion.Borrado = 0"
				+ " AND puntos_cobros.Borrado = 0"
				+ " AND caja_diaria.borrado = 0"
				+ " AND caja_general.borrado = 0"
				+ " AND caja_general.id BETWEEN @desde AND @hasta"
				+ "	AND puntos_cobros.Id = @punto"
				+ " AND usuarios_ctacte_recibos.cuenta = @cuenta";
				if (detalle == false)
					consulta = consulta + " GROUP BY puntos_cobros.Id";
				else
					consulta = consulta + " GROUP BY puntos_cobros.Id,usuarios.id";

				consulta = consulta.Replace("?", listaIdServicios);
				oCon.CrearComando(consulta);
				oCon.AsignarParametroEntero("@desde", idCajaGeneralDesde);
				oCon.AsignarParametroEntero("@hasta", idCajaGeneralHasta);
				oCon.AsignarParametroEntero("@punto", idPuntoCobro);
				oCon.AsignarParametroEntero("@cuenta", cuenta);

				dt = oCon.Tabla();
				oCon.DesConectar();
			}
			catch (Exception c)
			{
				oCon.DesConectar();
				throw;
			}
			return dt;
		}

		public DataTable ListarPlanesDePago(int idPuntoCobro, int idCajaGeneralDesde, int idCajaGeneralHasta, string listaIdServicios, int cuenta, bool detalle)
		{
			DataTable dt = new DataTable();
			try
			{
				string campos = "";
				if (detalle == false)
					campos = "SUM(usuarios_ctacte_relacion.Importe_imputa - usuarios_ctacte_relacion.Importe_Punitorio) AS Importe_planes";
				else
					campos = "usuarios.codigo,usuarios.apellido,usuarios.nombre,servicios.descripcion as servicio,caja_diaria.id as id_caja_Diaria,usuarios_ctacte_recibos.numero_muestra,servicios_sub.descripcion as detalle, (usuarios_ctacte_relacion.Importe_imputa - usuarios_ctacte_relacion.Importe_Punitorio) AS Importe_planes";

				string consulta = " SELECT " + campos + " FROM usuarios_ctacte_recibos"
					+ " LEFT JOIN puntos_cobros ON puntos_cobros.id = usuarios_ctacte_recibos.Id_Puntos_Cobros"
					+ " LEFT JOIN usuarios_ctacte_relacion ON usuarios_ctacte_relacion.Id_Usuarios_ctacte_recibos = usuarios_ctacte_recibos.id"
					+ " LEFT JOIN usuarios_ctacte_det ON usuarios_ctacte_det.Id = usuarios_ctacte_relacion.Id_Usuarios_ctacte_det"
					+ " LEFT JOIN usuarios_ctacte ON usuarios_ctacte.id = usuarios_ctacte_det.Id_Usuarios_CtaCte"
					+ " LEFT JOIN servicios ON servicios.Id = usuarios_ctacte_det.Id_Servicios"
					+ " LEFT JOIN usuarios_servicios ON usuarios_servicios.Id = usuarios_ctacte_det.id_usuarios_servicios"
					+ " LEFT JOIN usuarios_servicios_sub ON usuarios_servicios_sub.Id_usuarios_Servicios = usuarios_servicios.id"
					+ " LEFT JOIN servicios_sub ON servicios_sub.id = usuarios_servicios_sub.id_servicios_sub"
					+ " LEFT JOIN caja_diaria ON caja_diaria.Id = usuarios_ctacte_recibos.Id_Caja_Diaria"
					+ " LEFT JOIN caja_general ON caja_general.Id = caja_diaria.Id_Cierre_General"
					+ " LEFT JOIN usuarios ON usuarios.Id = usuarios_ctacte_recibos.Id_Usuarios"
					+ " LEFT JOIN comprobantes ON comprobantes.id = usuarios_ctacte.Id_comprobantes_ref"
					+ " WHERE usuarios_ctacte_det.Id_Servicios = servicios.Id"
					+ " AND servicios.Id in (?)"
					+ " AND usuarios_ctacte_recibos.borrado = 0"
					+ " AND usuarios_ctacte_relacion.Borrado = 0"
					+ " AND puntos_cobros.Borrado = 0"
					+ " AND caja_diaria.borrado = 0"
					+ " AND comprobantes.Id_Comprobantes_Tipo = 10"
					+ " AND caja_general.borrado = 0"
					+ " AND caja_general.id BETWEEN @desde AND @hasta"
					+ " AND puntos_cobros.Id = @punto"
					+ " AND usuarios_ctacte_recibos.cuenta = @cuenta";
				if (detalle == false)
					consulta = consulta + " GROUP BY puntos_cobros.Id";
				else
					consulta = consulta + " GROUP BY puntos_cobros.Id,usuarios.id";
				consulta = consulta.Replace("?", listaIdServicios);

				oCon.Conectar();
				oCon.CrearComando(consulta);
				oCon.AsignarParametroEntero("@desde", idCajaGeneralDesde);
				oCon.AsignarParametroEntero("@hasta", idCajaGeneralHasta);
				oCon.AsignarParametroEntero("@punto", idPuntoCobro);
				oCon.AsignarParametroEntero("@cuenta", cuenta);

				dt = oCon.Tabla();
				oCon.DesConectar();
			}
			catch (Exception c)
			{
				oCon.DesConectar();
				throw;
			}
			return dt;
		}

		public DataTable ListarMovimientosEspeciales(int idPuntoCobro, int idCajaGeneralDesde, int idCajaGeneralHasta, string listaIdServicios, int cuenta, bool detalle)
		{
			DataTable dt = new DataTable();
			try
			{
				oCon.Conectar();
				string campos = "";
				if (detalle == false)
					campos = "SUM(usuarios_ctacte_relacion.Importe_imputa - usuarios_ctacte_relacion.Importe_Punitorio) AS importe_especiales";
				else
					campos = "usuarios.codigo,usuarios.apellido,usuarios.nombre,servicios.descripcion as servicio,caja_diaria.id as id_caja_Diaria,usuarios_ctacte_recibos.numero_muestra,servicios_sub.descripcion as detalle, (usuarios_ctacte_relacion.Importe_imputa - usuarios_ctacte_relacion.Importe_Punitorio) AS importe_especiales";
				
				string consulta = "SELECT " + campos + " FROM usuarios_ctacte_recibos"
					+ " LEFT JOIN puntos_cobros ON puntos_cobros.id = usuarios_ctacte_recibos.Id_Puntos_Cobros"
					+ " LEFT JOIN usuarios_ctacte_relacion ON usuarios_ctacte_relacion.Id_Usuarios_ctacte_recibos = usuarios_ctacte_recibos.id"
					+ " LEFT JOIN usuarios_ctacte_det ON usuarios_ctacte_det.Id = usuarios_ctacte_relacion.Id_Usuarios_ctacte_det"
					+ " LEFT JOIN usuarios_ctacte ON usuarios_ctacte.id = usuarios_ctacte_det.Id_Usuarios_CtaCte"
					+ " LEFT JOIN servicios ON servicios.Id = usuarios_ctacte_det.Id_Servicios"
					+ " LEFT JOIN caja_diaria ON caja_diaria.Id = usuarios_ctacte_recibos.Id_Caja_Diaria"
					+ " LEFT JOIN caja_general ON caja_general.Id = caja_diaria.Id_Cierre_General"
					+ " LEFT JOIN usuarios ON usuarios.Id = usuarios_ctacte_recibos.Id_Usuarios"
					+ " LEFT JOIN usuarios_servicios ON usuarios_servicios.Id = usuarios_ctacte_det.id_usuarios_servicios"
					+ " LEFT JOIN usuarios_servicios_sub ON usuarios_servicios_sub.Id_usuarios_Servicios = usuarios_servicios.id"
					+ " LEFT JOIN servicios_sub ON servicios_sub.id = usuarios_servicios_sub.id_servicios_sub"
					+ " LEFT JOIN comprobantes ON comprobantes.id = usuarios_ctacte.Id_comprobantes_ref"
					+ " WHERE usuarios_ctacte_det.Id_Servicios = servicios.Id"
					+ " AND servicios.Id in (?)"
					+ " AND usuarios_ctacte_recibos.borrado = 0"
					+ " AND usuarios_ctacte_relacion.Borrado = 0"
					+ " AND puntos_cobros.Borrado = 0"
					+ " AND caja_diaria.borrado = 0"
					+ " AND caja_general.borrado = 0"
					+ " AND caja_general.id BETWEEN @desde AND @hasta"
					+ " AND usuarios_ctacte_det.Tipo = 'S'"
					+ " AND usuarios.presentacion = 0"
					+ " AND comprobantes.Id_Comprobantes_Tipo != 10"
					+ " AND puntos_cobros.Id = @punto"
					+ " AND usuarios_ctacte_recibos.cuenta = @cuenta";
				if (detalle == false)
					consulta = consulta + " GROUP BY puntos_cobros.Id";
				else
					consulta = consulta + " GROUP BY puntos_cobros.Id,usuarios.id";

				consulta = consulta.Replace("?", listaIdServicios);

				oCon.CrearComando(consulta);
				oCon.AsignarParametroEntero("@desde", idCajaGeneralDesde);
				oCon.AsignarParametroEntero("@hasta", idCajaGeneralHasta);
				oCon.AsignarParametroEntero("@punto", idPuntoCobro);
				oCon.AsignarParametroEntero("@cuenta", cuenta);

				dt = oCon.Tabla();
				oCon.DesConectar();
			}
			catch (Exception c)
			{
				oCon.DesConectar();
				throw;
			}
			return dt;
		}

		public DataTable ListarPrepagosConexiones(int idPuntoCobro, int idCajaGeneralDesde, int idCajaGeneralHasta, string listaIdServicios, int cuenta, bool detalle)
		{
			DataTable dt = new DataTable();
			try
			{
				oCon.Conectar();
				string[] split = listaIdServicios.Split(',');
				string campos = "";
				if (detalle == false)
					campos = "SUM(usuarios_ctacte_relacion.Importe_imputa - usuarios_ctacte_relacion.Importe_Punitorio) AS importe_prepago";
				else
					campos = "usuarios.codigo,usuarios.apellido,usuarios.nombre,servicios.descripcion as servicio,caja_diaria.id as id_caja_Diaria,usuarios_ctacte_recibos.numero_muestra,servicios_sub.descripcion as detalle, (usuarios_ctacte_relacion.Importe_imputa - usuarios_ctacte_relacion.Importe_Punitorio) AS importe_prepago";

				string consulta = "SELECT " + campos + " FROM usuarios_ctacte_recibos"
					+ " LEFT JOIN puntos_cobros ON puntos_cobros.id = usuarios_ctacte_recibos.Id_Puntos_Cobros"
					+ " LEFT JOIN usuarios_ctacte_relacion ON usuarios_ctacte_relacion.Id_Usuarios_ctacte_recibos = usuarios_ctacte_recibos.id"
					+ " LEFT JOIN usuarios_ctacte_det ON usuarios_ctacte_det.Id = usuarios_ctacte_relacion.Id_Usuarios_ctacte_det"
					+ " LEFT JOIN usuarios_ctacte ON usuarios_ctacte.id = usuarios_ctacte_det.Id_Usuarios_CtaCte"
					+ " LEFT JOIN servicios ON servicios.Id = usuarios_ctacte_det.Id_Servicios"
					+ " LEFT JOIN caja_diaria ON caja_diaria.Id = usuarios_ctacte_recibos.Id_Caja_Diaria"
					+ " LEFT JOIN caja_general ON caja_general.Id = caja_diaria.Id_Cierre_General"
					+ " LEFT JOIN usuarios ON usuarios.Id = usuarios_ctacte_recibos.Id_Usuarios"
					+ " LEFT JOIN usuarios_servicios ON usuarios_servicios.Id = usuarios_ctacte_det.id_usuarios_servicios"
					+ " LEFT JOIN usuarios_servicios_sub ON usuarios_servicios_sub.Id_usuarios_Servicios = usuarios_servicios.id"
					+ " LEFT JOIN servicios_sub ON servicios_sub.id = usuarios_servicios_sub.id_servicios_sub"
					+ " LEFT JOIN comprobantes ON comprobantes.id = usuarios_ctacte.Id_comprobantes_ref"
					+ " WHERE usuarios_ctacte_det.Id_Servicios = servicios.Id"
					+ " AND servicios.Id in (?) AND usuarios_ctacte_recibos.borrado = 0"
					+ " AND usuarios_ctacte_relacion.Borrado = 0"
					+ " AND puntos_cobros.Borrado = 0"
					+ " AND caja_diaria.borrado = 0"
					+ " AND caja_general.borrado = 0"
					+ " AND caja_general.id BETWEEN @desde AND @hasta"
					+ " AND (usuarios_ctacte_det.Tipo = 'P' or usuarios_ctacte_det.Tipo = 'E')"
					+ " AND servicios.id_servicios_modalidad =1"
					+ " AND comprobantes.Id_Comprobantes_Tipo != 10"
					+ " AND puntos_cobros.Id = @punto"
					+ " AND usuarios_ctacte_recibos.cuenta = @cuenta";
				if (detalle == false)
					consulta = consulta + " GROUP BY puntos_cobros.Id";
				else
					consulta = consulta + " GROUP BY puntos_cobros.Id,usuarios.id";
				consulta = consulta.Replace("?", listaIdServicios);
				oCon.CrearComando(consulta);
				oCon.AsignarParametroEntero("@desde", idCajaGeneralDesde);
				oCon.AsignarParametroEntero("@hasta", idCajaGeneralHasta);
				oCon.AsignarParametroEntero("@punto", idPuntoCobro);
				oCon.AsignarParametroEntero("@cuenta", cuenta);

				dt = oCon.Tabla();
				oCon.DesConectar();
			}
			catch (Exception c)
			{
				oCon.DesConectar();
				throw;
			}
			return dt;
		}

		public DataTable ListarPrepagosRecargas(int idPuntoCobro, int idCajaGeneralDesde, int idCajaGeneralHasta, string listaIdServicios, int cuenta, bool detalle)
		{
			DataTable dt = new DataTable();
			try
			{
				oCon.Conectar();
				string[] split = listaIdServicios.Split(',');
				string campos = "";
				if (detalle == false)
					campos = "SUM(usuarios_ctacte_relacion.Importe_imputa - usuarios_ctacte_relacion.Importe_Punitorio) AS importe_prepago_recarga";
				else
					campos = "usuarios.codigo,usuarios.apellido,usuarios.nombre,servicios.descripcion as servicio,caja_diaria.id as id_caja_Diaria,usuarios_ctacte_recibos.numero_muestra,servicios_sub.descripcion as detalle, (usuarios_ctacte_relacion.Importe_imputa - usuarios_ctacte_relacion.Importe_Punitorio) AS importe_prepago_recarga";

				string consulta = "SELECT " + campos + " FROM usuarios_ctacte_recibos"
					+ " LEFT JOIN puntos_cobros ON puntos_cobros.id = usuarios_ctacte_recibos.Id_Puntos_Cobros"
					+ " LEFT JOIN usuarios_ctacte_relacion ON usuarios_ctacte_relacion.Id_Usuarios_ctacte_recibos = usuarios_ctacte_recibos.id"
					+ " LEFT JOIN usuarios_ctacte_det ON usuarios_ctacte_det.Id = usuarios_ctacte_relacion.Id_Usuarios_ctacte_det"
					+ " LEFT JOIN usuarios_ctacte ON usuarios_ctacte.id = usuarios_ctacte_det.Id_Usuarios_CtaCte"
					+ " LEFT JOIN servicios ON servicios.Id = usuarios_ctacte_det.Id_Servicios"
					+ " LEFT JOIN caja_diaria ON caja_diaria.Id = usuarios_ctacte_recibos.Id_Caja_Diaria"
					+ " LEFT JOIN caja_general ON caja_general.Id = caja_diaria.Id_Cierre_General"
					+ " LEFT JOIN usuarios ON usuarios.Id = usuarios_ctacte_recibos.Id_Usuarios"
					+ " LEFT JOIN usuarios_servicios ON usuarios_servicios.Id = usuarios_ctacte_det.id_usuarios_servicios"
					+ " LEFT JOIN usuarios_servicios_sub ON usuarios_servicios_sub.Id_usuarios_Servicios = usuarios_servicios.id"
					+ " LEFT JOIN servicios_sub ON servicios_sub.id = usuarios_servicios_sub.id_servicios_sub"
					+ " LEFT JOIN comprobantes ON comprobantes.id = usuarios_ctacte.Id_comprobantes_ref"
					+ " WHERE usuarios_ctacte_det.Id_Servicios = servicios.Id"
					+ " AND servicios.Id in (?)"
					+ " AND usuarios_ctacte_recibos.borrado = 0"
					+ " AND usuarios_ctacte_relacion.Borrado = 0"
					+ " AND puntos_cobros.Borrado = 0"
					+ " AND caja_diaria.borrado = 0"
					+ " AND caja_general.borrado = 0"
					+ " AND caja_general.id BETWEEN @desde AND @hasta"
					+ " AND usuarios_ctacte_det.Tipo = 'S'"
					+ " AND servicios.id_servicios_modalidad =1"
					+ " AND comprobantes.Id_Comprobantes_Tipo != 10"
					+ " AND puntos_cobros.Id = @punto"
					+ " AND usuarios_ctacte_recibos.cuenta = @cuenta";
				if (detalle == false)
					consulta = consulta + " GROUP BY puntos_cobros.Id";
				else
					consulta = consulta + " GROUP BY puntos_cobros.Id,usuarios.id";
				consulta = consulta.Replace("?", listaIdServicios);

				oCon.CrearComando(consulta);

				oCon.AsignarParametroEntero("@desde", idCajaGeneralDesde);
				oCon.AsignarParametroEntero("@hasta", idCajaGeneralHasta);
				oCon.AsignarParametroEntero("@punto", idPuntoCobro);
				oCon.AsignarParametroEntero("@cuenta", cuenta);

				dt = oCon.Tabla();
				oCon.DesConectar();
			}
			catch (Exception c)
			{
				oCon.DesConectar();
				throw;
			}
			return dt;
		}

		public DataTable ListarEspecial(int idPuntoCobro, int idCajaGeneralDesde, int idCajaGeneralHasta, string listaIdServicios, int cuenta, bool detalle)
        {
			DataTable dt = new DataTable();
            try
            {
				string campos = "";

				if (detalle == false)
					campos = "SUM(usuarios_ctacte_relacion.Importe_imputa - usuarios_ctacte_relacion.Importe_Punitorio) AS importe";
				else
					campos = "usuarios.codigo,usuarios.apellido,usuarios.nombre,servicios.descripcion as servicio,caja_diaria.id as id_caja_Diaria,usuarios_ctacte_recibos.numero_muestra,servicios_sub.descripcion as detalle,(usuarios_ctacte_relacion.Importe_imputa - usuarios_ctacte_relacion.Importe_Punitorio) AS importe";

				string consulta = "SELECT " + campos + " FROM usuarios_ctacte_recibos"
				+ " LEFT JOIN puntos_cobros ON puntos_cobros.id = usuarios_ctacte_recibos.Id_Puntos_Cobros"
				+ " LEFT JOIN usuarios_ctacte_relacion ON usuarios_ctacte_relacion.Id_Usuarios_ctacte_recibos = usuarios_ctacte_recibos.id"
				+ " LEFT JOIN usuarios_ctacte_det ON usuarios_ctacte_det.Id = usuarios_ctacte_relacion.Id_Usuarios_ctacte_det"
				+ " LEFT JOIN usuarios_ctacte ON usuarios_ctacte.id = usuarios_ctacte_det.Id_Usuarios_CtaCte"
				+ " LEFT JOIN servicios ON servicios.Id = usuarios_ctacte_det.Id_Servicios"
				+ " LEFT JOIN caja_diaria ON caja_diaria.Id = usuarios_ctacte_recibos.Id_Caja_Diaria"
				+ " LEFT JOIN caja_general ON caja_general.Id = caja_diaria.Id_Cierre_General"
				+ " LEFT JOIN usuarios ON usuarios.Id = usuarios_ctacte_recibos.Id_Usuarios"
				+ " LEFT JOIN usuarios_servicios ON usuarios_servicios.Id = usuarios_ctacte_det.id_usuarios_servicios"
				+ " LEFT JOIN usuarios_servicios_sub ON usuarios_servicios_sub.Id_usuarios_Servicios = usuarios_servicios.id"
				+ " LEFT JOIN servicios_sub ON servicios_sub.id = usuarios_servicios_sub.id_servicios_sub"
				+ " LEFT JOIN comprobantes ON comprobantes.id = usuarios_ctacte.Id_comprobantes_ref"
				+ " WHERE usuarios_ctacte_det.Id_Servicios = servicios.Id"
				+ " AND servicios.Id in (?)"
				+ " AND usuarios_ctacte_recibos.borrado = 0"
				+ " AND usuarios_ctacte_relacion.Borrado = 0"
				+ " AND puntos_cobros.Borrado = 0"
				+ " AND caja_diaria.borrado = 0"
				+ " AND caja_general.borrado = 0"
				+ " AND caja_general.id BETWEEN @desde AND @hasta"
				+ " AND comprobantes.Id_Comprobantes_Tipo != 10"
				+ " AND puntos_cobros.Id = @punto"
				+ " AND usuarios_ctacte_recibos.cuenta = @cuenta";
				if (detalle == false)
					consulta = consulta + " GROUP BY puntos_cobros.Id";
				else
					consulta = consulta + " GROUP BY puntos_cobros.Id,usuarios.id";
				consulta = consulta.Replace("?", listaIdServicios);

				oCon.Conectar();
				oCon.CrearComando(consulta);
				oCon.AsignarParametroEntero("@desde", idCajaGeneralDesde);
				oCon.AsignarParametroEntero("@hasta", idCajaGeneralHasta);
				oCon.AsignarParametroEntero("@punto", idPuntoCobro);
				oCon.AsignarParametroEntero("@cuenta", cuenta);
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