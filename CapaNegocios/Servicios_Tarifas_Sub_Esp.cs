using CapaDatos;
using System;
using System.Data;

namespace CapaNegocios
{
    public class Servicios_Tarifas_Sub_Esp
    {
        private Conexion oCon = new Conexion();

        public void Guardar(DataTable dtServicios_Tarifas_Sub_Esp, int id_personal)
        {
            try
            {
                oCon.Conectar();
                foreach (DataRow dr in dtServicios_Tarifas_Sub_Esp.Rows)
                {

                    if (Convert.ToInt32(dr["id"]) > 0)
                    {
                        oCon.CrearComando(String.Format("DELETE FROM servicios_tarifas_sub_esp WHERE id = {0}", dr["id"]));
                        oCon.EjecutarComando();
                    }

                    oCon.CrearComando("INSERT INTO servicios_tarifas_sub_esp(Id_Servicios_Tarifas, Id_Servicios, Id_Servicios_Sub, Id_Servicios_Base, Id_Tipo_Facturacion, " +
                        "Id_Servicios_Velocidad, Id_Servicios_Velocidad_Tip, Dias_Desde, Dias_Hasta, Porcentaje, Mes_Facturacion, Meses_Servicio, Meses_Cobro, Mes_Inicio, " +
                        "Mes_Fin, Fecha_Desde, Fecha_Hasta, Importe, Id_Personal) VALUES(@tarifa_id, @servicios_id, @servicios_sub_id, @servicios_base_id, @tipo_fac_id, " +
                        "@servicios_vel_id, @servicios_vel_tip_id, @dias_desde, @dias_hasta, @porcentaje, @mes_fac, @mes_serv, @mes_cobro, @mes_inicio, " +
                        "@mes_fin, @fecha_desde, @fecha_hasta, @importe, @personal)");

                    oCon.AsignarParametroEntero("@tarifa_id", Convert.ToInt32(dr["id_servicios_tarifas"]));
                    oCon.AsignarParametroEntero("@servicios_id", Convert.ToInt32(dr["id_servicios"]));
                    oCon.AsignarParametroEntero("@servicios_sub_id", Convert.ToInt32(dr["id_servicios_sub"]));
                    oCon.AsignarParametroEntero("@servicios_base_id", dr["id_servicios_base"].ToString() == string.Empty ? 0 : Convert.ToInt32(dr["id_servicios_base"]));
                    oCon.AsignarParametroEntero("@tipo_fac_id", Convert.ToInt32(dr["id_tipo_facturacion"]));
                    oCon.AsignarParametroEntero("@servicios_vel_id", dr["id_servicios_velocidad"].ToString() == string.Empty ? 0 : Convert.ToInt32(dr["id_servicios_velocidad"]));
                    oCon.AsignarParametroEntero("@servicios_vel_tip_id", dr["id_servicios_velocidad_tip"].ToString() == string.Empty ? 0 : Convert.ToInt32(dr["id_servicios_velocidad_tip"]));
                    oCon.AsignarParametroEntero("@dias_desde", dr["dias_desde"].ToString() == string.Empty ? 0 : Convert.ToInt32(dr["dias_desde"]));
                    oCon.AsignarParametroEntero("@dias_hasta", dr["dias_hasta"].ToString() == string.Empty ? 0 : Convert.ToInt32(dr["dias_hasta"]));
                    oCon.AsignarParametroEntero("@porcentaje", dr["porcentaje"].ToString() == string.Empty ? 0 : Convert.ToInt32(dr["porcentaje"]));
                    oCon.AsignarParametroEntero("@mes_fac", dr["mes_facturacion"].ToString() == string.Empty ? 0 : Convert.ToInt32(dr["mes_facturacion"]));
                    oCon.AsignarParametroEntero("@mes_serv", dr["meses_servicio"].ToString() == string.Empty ? 0 : Convert.ToInt32(dr["meses_servicio"]));
                    oCon.AsignarParametroEntero("@mes_cobro", dr["meses_cobro"].ToString() == string.Empty ? 0 : Convert.ToInt32(dr["meses_cobro"]));
                    oCon.AsignarParametroEntero("@mes_inicio", dr["mes_inicio"].ToString() == string.Empty ? 0 : Convert.ToInt32(dr["mes_inicio"]));
                    oCon.AsignarParametroEntero("@mes_fin", dr["mes_fin"].ToString() == string.Empty ? 0 : Convert.ToInt32(dr["mes_fin"]));

                    if (dr["fecha_desde"].ToString() == string.Empty || dr["fecha_desde"].ToString().Substring(6, 4) == "0001")
                        oCon.AsignarParametroFecha("@fecha_desde", new DateTime(1, 1, 1));
                    else
                        oCon.AsignarParametroFecha("@fecha_desde", Convert.ToDateTime(dr["fecha_desde"]));

                    if (dr["fecha_hasta"].ToString() == string.Empty || dr["fecha_hasta"].ToString().Substring(6, 4) == "0001")
                        oCon.AsignarParametroFecha("@fecha_hasta", new DateTime(1, 1, 1));
                    else
                        oCon.AsignarParametroFecha("@fecha_hasta", Convert.ToDateTime(dr["fecha_hasta"]));

                    oCon.AsignarParametroDecimal("@importe", Convert.ToDecimal(dr["importe"]));
                    oCon.AsignarParametroEntero("@personal", Personal.Id_Login);
                    oCon.EjecutarComando();

                    int Meses = Convert.ToInt32(dr["origenmeses"]);
                    if (Meses == Convert.ToInt32(Servicios.Origen_Meses.FIJO))
                    {
                        //PARCHE PARA ATCCO 16072020 ALEJO. SI SE ROMPE ALGO HICE CAGADAS (si querias hacer cagadas te salio bien)
                        oCon.CrearComando(String.Format("UPDATE usuarios_servicios SET Meses_Cobro={0} , Meses_Servicio={1} WHERE id_servicios={2} and id_tipo_facturacion={3}", 
                            dtServicios_Tarifas_Sub_Esp.Rows[0]["meses_cobro"], dtServicios_Tarifas_Sub_Esp.Rows[0]["meses_servicio"], Convert.ToInt32(dr["id_servicios"]), Convert.ToInt32(dr["id_tipo_facturacion"])));
                        oCon.EjecutarComando();
                    }
                }

                oCon.DesConectar();

            }
            catch (Exception)
            {
                oCon.DesConectar();

                throw;
            }
            // return id_tarifa;
        }

        public void Eliminar(Int32 Servicios_Tarifas_Sub_Esp_Id)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando(String.Format("DELETE FROM servicios_tarifas_sub_esp WHERE id = {0}", Servicios_Tarifas_Sub_Esp_Id));
                oCon.EjecutarComando();
                oCon.DesConectar();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public DataTable GetServicios_Tarifas_Sub_Esp(Int32 idTarifa, Int32 idServicio, Int32 id_tipo_facturacion)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando(String.Format("SELECT vw_tarifas.velocidad, vw_tarifas.velocidad_tipo as velocidad_tip, vw_tarifas.dias_desde, vw_tarifas.dias_hasta, vw_tarifas.porcentaje, vw_tarifas.mes_facturacion,vw_tarifas.mes_inicio,vw_tarifas.mes_fin, " +
                    "vw_tarifas.meses_cobro, vw_tarifas.meses_servicio,vw_tarifas.fecha_desde,vw_tarifas.fecha_hasta, vw_tarifas.importe, vw_tarifas.id_servicios_tarifas, vw_tarifas.id_servicios, vw_tarifas.id_servicios_base, vw_tarifas.id_tipo_facturacion, vw_tarifas.id_servicios_velocidad, " +
                    "vw_tarifas.id_servicio_velocidad_tip,vw_tarifas.idtipodesub,vw_tarifas.tiposub FROM vw_tarifas " +
                    "WHERE vw_tarifas.Id_Servicios_Tarifas = {0} AND vw_tarifas.Id_Servicios = {1}  AND vw_tarifas.Id_Tipo_Facturacion = {2}", idTarifa, idServicio, id_tipo_facturacion));

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

        public DataTable GetServicios_Tarifas_Sub_Esp(Int32 idTarifa, Int32 idServicio, Int32 idServicioSub, Int32 id_tipo_facturacion)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando(String.Format("SELECT servicios_velocidades.velocidad, servicios_velocidades_tip.nombre as velocidad_tip, dias_desde, dias_hasta, porcentaje, mes_facturacion, mes_inicio, mes_fin, " +
                    "meses_cobro, meses_servicio, fecha_desde, fecha_hasta, importe, id_servicios_tarifas, id_servicios, id_servicios_sub, id_servicios_base, id_tipo_facturacion, id_servicios_velocidad, " +
                    "id_servicios_velocidad_tip, servicios_tarifas_sub_esp.id, servicios.OrigenMeses FROM servicios_tarifas_sub_esp " +
                    "LEFT JOIN servicios_velocidades ON servicios_velocidades.id = servicios_tarifas_sub_esp.id_servicios_velocidad " +
                    "LEFT JOIN servicios_velocidades_tip ON servicios_velocidades_tip.id = servicios_tarifas_sub_esp.id_servicios_velocidad_tip " +
                    "LEFT JOIN servicios ON servicios_tarifas_sub_esp.Id_Servicios=servicios.id " +
                    "WHERE Id_Servicios_Tarifas = {0} AND Id_Servicios = {1} AND Id_Servicios_Sub = {2} AND Id_Tipo_Facturacion = {3} order by dias_desde", idTarifa, idServicio, idServicioSub, id_tipo_facturacion));

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

        public bool CambiarVelocidades(Int32 Id_Tarifa, Int32 Id_Zona, Int32 Id_Servicios, Int32 Id_Servicios_Vel_Anterior, Int32 Id_Servicios_Vel_Nueva, Int32 Id_Servicios_Vel_Tip)
        {
            try
            {
                oCon.Conectar();

                oCon.CrearComando(String.Format("DELETE FROM servicios_tarifas_sub_esp where id_servicios_velocidad = {0} and " +
                    "id_servicios_tarifas = {1} and id_servicios = {2} and id_tipo_facturacion = {3} and id_servicios_velocidad_tip = {4}", Id_Servicios_Vel_Nueva, Id_Tarifa, Id_Servicios, Id_Zona, Id_Servicios_Vel_Tip));

                oCon.EjecutarComando();

                string query = String.Format("UPDATE servicios_tarifas_sub_esp SET id_servicios_velocidad = {0} WHERE id_servicios_velocidad = {1} and " +
                    "id_servicios_tarifas = {2} and id_servicios = {3} and id_tipo_facturacion = {4}", Id_Servicios_Vel_Nueva, Id_Servicios_Vel_Anterior, Id_Tarifa, Id_Servicios, Id_Zona);

                oCon.CrearComando(query);
                oCon.EjecutarComando();
                oCon.DesConectar();


                return true;
            }
            catch (Exception ex) { string mensaje = ex.Message; return false; }
        }




        public void ActualizarServiciosSubPorTarifa(int id_tarifa)
        {
            oCon.Conectar();
            oCon.CrearComando(String.Format("", id_tarifa));
        }



        public bool ActualizaEspeciales(int id_tarifa,int id_servicio)
        {
            try { 
            oCon.Conectar();
            if(id_servicio == 0)
            { 
                oCon.CrearComando(String.Format("UPDATE usuarios_servicios " +
                    "LEFT JOIN servicios ON usuarios_servicios.Id_Servicios = servicios.id " +
                    "LEFT JOIN servicios_tarifas_sub_esp ON usuarios_servicios.Id_Servicios = servicios_tarifas_sub_esp.id_servicios " +
                    "SET usuarios_servicios.Meses_Cobro = servicios_tarifas_sub_esp.Meses_Cobro, usuarios_servicios.Meses_Servicio = servicios_tarifas_sub_esp.Meses_Servicio " +
                    "WHERE usuarios_servicios.borrado = 0 AND servicios.borrado = 0  AND servicios_tarifas_sub_esp.Id_Servicios_Tarifas = {0} " +
                    "AND servicios.Id_Servicios_Modalidad = {1}; ", id_tarifa, (int)Servicios._Modalidad.PERIODO));
            }
            else
            {
                oCon.CrearComando(String.Format("UPDATE usuarios_servicios " +
                    "LEFT JOIN servicios ON usuarios_servicios.Id_Servicios = servicios.id " +
                    "LEFT JOIN servicios_tarifas_sub_esp ON usuarios_servicios.Id_Servicios = servicios_tarifas_sub_esp.id_servicios " +
                    "SET usuarios_servicios.Meses_Cobro = servicios_tarifas_sub_esp.Meses_Cobro, usuarios_servicios.Meses_Servicio = servicios_tarifas_sub_esp.Meses_Servicio " +
                    "WHERE usuarios_servicios.borrado = 0 AND servicios.borrado = 0  AND servicios_tarifas_sub_esp.Id_Servicios_Tarifas = {0} " +
                    "AND servicios.Id_Servicios_Modalidad = {1} and usuarios_servicios.id_servicios = {2}; ", id_tarifa, (int)Servicios._Modalidad.PERIODO, id_servicio));

            }
            oCon.EjecutarComando();
            oCon.DesConectar();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public bool ActualizaEspecialesRamiro(int id_tarifa, int id_servicio, int id_tipo_facturacion, int opcion=0)
        {
            try
            {
                oCon.Conectar();
                if (opcion==0)
                {
                    oCon.CrearComando(String.Format("UPDATE usuarios_servicios " +
                           "SET usuarios_servicios.Meses_Cobro = 1, usuarios_servicios.Meses_Servicio = 1 " +
                           "WHERE usuarios_servicios.borrado = 0 " +
                           "and usuarios_servicios.id_servicios = {0} " +
                           "AND usuarios_servicios.Id_Tipo_Facturacion={1}; ", id_servicio, id_tipo_facturacion));
                    oCon.EjecutarComando();
                    oCon.DesConectar();
                    return true;
                }
                else
                {
                    oCon.CrearComando(" select meses_cobro, meses_servicio, servicios.id_servicios_modalidad" +
                                  " from servicios_tarifas_sub_esp" +
                                  " INNER JOIN servicios on servicios.id=servicios_tarifas_sub_esp.id_Servicios" +
                                  " where `id_servicios_tarifas` = " + id_tarifa + " " +
                                  " AND `id_servicios` = " + id_servicio + " " +
                                  " AND `id_tipo_facturacion` = " + id_tipo_facturacion + " ;");
                    //" AND servicios.id_servicios_modalidad = "+(int)Servicios._Modalidad.PERIODO+" ;");

                    DataTable dt = new DataTable();
                    dt = oCon.Tabla();
                    int meses_cobro = Convert.ToInt32(dt.Rows[0]["meses_cobro"]);
                    int meses_servicio = Convert.ToInt32(dt.Rows[0]["meses_servicio"]);

                    oCon.CrearComando(String.Format("UPDATE usuarios_servicios " +
                            "SET usuarios_servicios.Meses_Cobro = " + meses_cobro + ", usuarios_servicios.Meses_Servicio = " + meses_servicio + " " +
                            "WHERE usuarios_servicios.borrado = 0 " +
                            "and usuarios_servicios.id_servicios = {0} " +
                            "AND usuarios_servicios.Id_Tipo_Facturacion={1}; ", id_servicio, id_tipo_facturacion));

                    oCon.EjecutarComando();
                    oCon.DesConectar();
                    return true;
                }

                
            }
            catch (Exception e)
            {
                oCon.DesConectar();
                return false;
            }

        }

        public DataTable GetTarifaSubEspGroupServicios(Int32 idTarifa)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                //oCon.CrearComando("SELECT servicios_tarifas_sub_esp.Id_Servicios AS id_serv, servicios.Descripcion AS Servicio, " +
                //    "servicios_tarifas_sub_esp.Meses_Cobro AS Mes_cobro, servicios_tarifas_sub_esp.Meses_Servicio AS Mes_servicio, " +
                //    "servicios_tarifas_sub_esp.Importe AS importe " +
                //    "FROM servicios_tarifas_sub_esp " +
                //    "LEFT JOIN servicios ON servicios_tarifas_sub_esp.Id_Servicios = servicios.id " +
                //    "WHERE servicios_tarifas_sub_esp.Id_Servicios_Tarifas = @tarifa AND servicios.Id_Servicios_Modalidad = @Modalidad AND servicios.borrado = 0 " +
                //    "GROUP BY servicios_tarifas_sub_esp.Id_Servicios; ");
                oCon.CrearComando(" select servicios_tarifas_sub_esp.id_servicios as id_serv," +
                                  " servicios.descripcion as servicio, servicios_tarifas_sub_esp.meses_cobro as mes_cobro," +
                                  " servicios_tarifas_sub_esp.meses_servicio as mes_servicio, servicios_tarifas_sub_esp.importe as importe, id_tipo_facturacion, " +
                                  " servicios_categorias.Nombre as CAT" +
                                  " from servicios_tarifas_sub_esp" +
                                  " left join servicios on servicios_tarifas_sub_esp.id_servicios = servicios.id" +
                                  " LEFT JOIN servicios_categorias ON servicios_categorias.id = servicios_tarifas_sub_esp.id_tipo_facturacion" +
                                  " where servicios_tarifas_sub_esp.id_servicios_tarifas = @tarifa and servicios.id_servicios_modalidad = @Modalidad and servicios.borrado = 0" +
                                  " ORDER BY id_serv");
                oCon.AsignarParametroEntero("@tarifa", idTarifa);
                oCon.AsignarParametroEntero("@Modalidad", (int)Servicios._Modalidad.PERIODO);

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

        public DataTable GetUsuServGroupServicios()
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECt usuarios_servicios.Id_Servicios as id_serv, " +
                    "servicios.Descripcion AS Servicio, usuarios_servicios.Meses_Cobro AS Mes_Cobro, usuarios_servicios.Meses_Servicio AS Mes_Servicio," +
                    "usuarios_servicios.id_tipo_facturacion AS id_tipo_facturacion " +
                    "FROM usuarios_servicios " +
                    "LEFT JOIN servicios ON usuarios_servicios.Id_Servicios = servicios.id " +
                    "WHERE usuarios_servicios.borrado = 0 AND servicios.Id_Servicios_Modalidad = @Modalidad " +
                    "GROUP BY id_servicios;");
                oCon.AsignarParametroEntero("@Modalidad", (int)Servicios._Modalidad.PERIODO);
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
