using CapaDatos;
using System;
using System.Data;

namespace CapaNegocios
{
    public class Servicios_Tarifas_Sub
    {
        private Conexion oCon = new Conexion();

        public void Guardar(DataTable dtSubserviciosTarifas, int idTarifa, int id_tipo_facturacion, int id_personal)
        {
            try
            {
                oCon.Conectar();
                oCon.ComenzarTransaccion();

                oCon.CrearComando("DELETE FROM Servicios_Tarifas_Sub WHERE Id_Servicios_Tarifas = @id and Id_Tipo_Facturacion = @idtipo");
                oCon.AsignarParametroEntero("@id", idTarifa);
                oCon.AsignarParametroEntero("@idtipo", id_tipo_facturacion);
                oCon.EjecutarComando();
                foreach (DataRow dr in dtSubserviciosTarifas.Rows)
                {
                    oCon.CrearComando(String.Format("SELECT * FROM servicios_tarifas_sub_esp WHERE id_servicios_tarifas = {0} and id_servicios = {1} and id_Servicios_sub = {2} and id_tipo_facturacion = {3}",
                        idTarifa, Convert.ToInt32(dr["Id_Servicios"]), Convert.ToInt32(dr["Id_Tabla_Tipo"]), Convert.ToInt32(dr["Id_Tipo_Facturacion"])));

                    DataTable data = oCon.Tabla();
                    //si el servicio es especial (tiene velocidades o esta conpuesto por mas de un servicio_sub tipo 1, como internet o minetti) solo tiene que ingresar las tarifas de los partes y/o equipos no de los servicios en si
                    if (data.Rows.Count > 0)
                    {
                        if (Convert.ToInt32(dr["tipo_subservicio"]) != (int)Servicios_Sub.SERVICIO_SUB_TIPOS.SUBSERVICIO)
                        {
                            oCon.CrearComando("INSERT INTO Servicios_Tarifas_Sub(Id_Servicios_Tarifas, Id_Servicios, Id_Tipo_Facturacion, Id_Tabla_Tipo, Tipo, Importe, Fecha_Desde, Fecha_Hasta, Id_Personal)" +
                                      "VALUES(@tarifa, @servicio, @idtipo, @idtabla, @tipo, @importe, @desde, @hasta, @personal)");

                            oCon.AsignarParametroEntero("@tarifa", idTarifa);
                            oCon.AsignarParametroEntero("@servicio", Convert.ToInt32(dr["Id_Servicios"]));
                            oCon.AsignarParametroEntero("@idtipo", Convert.ToInt32(dr["Id_Tipo_Facturacion"]));
                            oCon.AsignarParametroEntero("@idtabla", Convert.ToInt32(dr["Id_Tabla_Tipo"]));
                            oCon.AsignarParametroCadena("@tipo", dr["Tipo"].ToString());
                            oCon.AsignarParametroDecimal("@importe", Convert.ToDecimal(dr["Importe"]));
                            oCon.AsignarParametroFecha("@desde", Convert.ToDateTime(dr["Fecha_Desde"]));
                            oCon.AsignarParametroFecha("@hasta", Convert.ToDateTime(dr["Fecha_Hasta"]));
                            oCon.AsignarParametroEntero("@personal", Personal.Id_Login);
                            oCon.EjecutarComando();
                        }
                    }
                    else
                    {
                        oCon.CrearComando("INSERT INTO Servicios_Tarifas_Sub(Id_Servicios_Tarifas, Id_Servicios, Id_Tipo_Facturacion, Id_Tabla_Tipo, Tipo, Importe, Fecha_Desde, Fecha_Hasta, Id_Personal)" +
                                      "VALUES(@tarifa, @servicio, @idtipo, @idtabla, @tipo, @importe, @desde, @hasta, @personal)");

                        oCon.AsignarParametroEntero("@tarifa", idTarifa);
                        oCon.AsignarParametroEntero("@servicio", Convert.ToInt32(dr["Id_Servicios"]));
                        oCon.AsignarParametroEntero("@idtipo", Convert.ToInt32(dr["Id_Tipo_Facturacion"]));
                        oCon.AsignarParametroEntero("@idtabla", Convert.ToInt32(dr["Id_Tabla_Tipo"]));
                        oCon.AsignarParametroCadena("@tipo", dr["Tipo"].ToString());
                        oCon.AsignarParametroDecimal("@importe", Convert.ToDecimal(dr["Importe"]));
                        oCon.AsignarParametroFecha("@desde", Convert.ToDateTime(dr["Fecha_Desde"]));
                        oCon.AsignarParametroFecha("@hasta", Convert.ToDateTime(dr["Fecha_Hasta"]));
                        oCon.AsignarParametroEntero("@personal", Personal.Id_Login);
                        oCon.EjecutarComando();
                    }
                }
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
        public void Guardar(DataTable dtSubserviciosTarifas, int idTarifa, int id_tipo_facturacion, int especial, int id_personal)
        {
            if (dtSubserviciosTarifas.Rows.Count > 0)
            {
                int idServicio = Convert.ToInt32(dtSubserviciosTarifas.Rows[0]["id_Servicios"]);

                oCon.Conectar();
                oCon.ComenzarTransaccion();
                switch (especial)
                {
                    case 0:
                        try
                        {
                            oCon.CrearComando("DELETE FROM Servicios_Tarifas_Sub WHERE Id_Servicios_Tarifas = @id and Id_Tipo_Facturacion = @idtipo and id_servicios=@idservicios");
                            oCon.AsignarParametroEntero("@id", idTarifa);
                            oCon.AsignarParametroEntero("@idtipo", id_tipo_facturacion);
                            oCon.AsignarParametroEntero("@idservicios", idServicio);
                            oCon.EjecutarComando();
                            foreach (DataRow dr in dtSubserviciosTarifas.Rows)
                            {
                                oCon.CrearComando("INSERT INTO Servicios_Tarifas_Sub(Id_Servicios_Tarifas, Id_Servicios, Id_Tipo_Facturacion, Id_Tabla_Tipo, Tipo, Importe, Fecha_Desde, Fecha_Hasta, Id_Personal_Create, Fecha_Create)" +
                                          "VALUES(@tarifa, @servicio, @idtipo, @idtabla, @tipo, @importe, @desde, @hasta, @personal, @fechaCreate)");
                                oCon.AsignarParametroEntero("@tarifa", idTarifa);
                                oCon.AsignarParametroEntero("@servicio", Convert.ToInt32(dr["Id_Servicios"]));
                                oCon.AsignarParametroEntero("@idtipo", Convert.ToInt32(dr["Id_Tipo_Facturacion"]));
                                oCon.AsignarParametroEntero("@idtabla", Convert.ToInt32(dr["Id_Tabla_Tipo"]));
                                oCon.AsignarParametroCadena("@tipo", dr["Tipo"].ToString());
                                oCon.AsignarParametroDecimal("@importe", Convert.ToDecimal(dr["Importe"]));
                                oCon.AsignarParametroFecha("@desde", Convert.ToDateTime(dr["Fecha_Desde"]));
                                oCon.AsignarParametroFecha("@hasta", Convert.ToDateTime(dr["Fecha_Hasta"]));
                                oCon.AsignarParametroEntero("@personal", id_personal);
                                oCon.AsignarParametroFecha("@fechaCreate", DateTime.Now);
                                oCon.EjecutarComando();
                            }
                            oCon.ConfirmarTransaccion();
                            oCon.DesConectar();
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                        break;
                    case 1:

                        oCon.CrearComando("DELETE FROM Servicios_Tarifas_Sub_esp WHERE Id_Servicios_Tarifas = @id and Id_Tipo_Facturacion = @idtipo and id_servicios=@idservicios");
                        oCon.AsignarParametroEntero("@id", idTarifa);
                        oCon.AsignarParametroEntero("@idtipo", id_tipo_facturacion);
                        oCon.AsignarParametroEntero("@idservicios", idServicio);
                        oCon.EjecutarComando();

                        foreach (DataRow dr in dtSubserviciosTarifas.Rows)
                        {
                            oCon.CrearComando("INSERT INTO Servicios_Tarifas_Sub_esp(Id_Servicios_Tarifas, Id_Servicios,Id_Servicios_Sub,Id_Servicios_Base,Id_Tipo_Facturacion,Id_Servicios_Velocidad,Id_Servicios_Velocidad_Tip,Dias_Desde,Dias_Hasta,Porcentaje,Mes_Facturacion,Meses_Servicio,Meses_Cobro,Mes_Inicio,Mes_Fin,Fecha_Desde,Fecha_Hasta,Importe,Id_Personal_Create, Fecha_Create)" +
                                      "VALUES(@tarifa, @servicio, @id_servicio_sub, @id_servicio_base ,@id_tipo, @id_velocidad, @id_velocidad_tipo, @dias_desde, @dias_hasta, @porcentaje, @mes_facturacion, @meses_servicio, @meses_cobro, @mes_inicio, @mes_fin, @fecha_desde, @fecha_hasta, @importe, @personal, @fechaCreate)");
                            oCon.AsignarParametroEntero("@tarifa", idTarifa);
                            oCon.AsignarParametroEntero("@servicio", Convert.ToInt32(dr["Id_Servicios"]));
                            oCon.AsignarParametroEntero("@id_servicio_sub", Convert.ToInt32(dr["id"]));
                            oCon.AsignarParametroEntero("@id_servicio_base", Convert.ToInt32(dr["Id_Servicio_base"]));
                            oCon.AsignarParametroEntero("@id_tipo", Convert.ToInt32(dr["Id_Tipo_Facturacion"]));
                            oCon.AsignarParametroEntero("@id_velocidad", Convert.ToInt32(dr["id_velocidad"]));
                            oCon.AsignarParametroEntero("@id_velocidad_tipo", Convert.ToInt32(dr["id_velocidad_tipo"]));
                            oCon.AsignarParametroEntero("@dias_desde", Convert.ToInt32(dr["dias_desde"]));
                            oCon.AsignarParametroEntero("@dias_hasta", Convert.ToInt32(dr["dias_hasta"]));
                            oCon.AsignarParametroDecimal("@porcentaje", Convert.ToDecimal(dr["porcentaje"]));
                            oCon.AsignarParametroEntero("@mes_facturacion", Convert.ToInt32(dr["mes_facturacion"]));
                            oCon.AsignarParametroEntero("@meses_servicio", Convert.ToInt32(dr["meses_servicio"]));
                            oCon.AsignarParametroEntero("@meses_cobro", Convert.ToInt32(dr["meses_cobro"]));
                            oCon.AsignarParametroEntero("@mes_inicio", Convert.ToInt32(dr["mes_inicio"]));
                            oCon.AsignarParametroEntero("@mes_fin", Convert.ToInt32(dr["mes_fin"]));
                            oCon.AsignarParametroFecha("@fecha_desde", Convert.ToDateTime(dr["fecha_desde"]));
                            oCon.AsignarParametroFecha("@fecha_hasta", Convert.ToDateTime(dr["fecha_hasta"]));
                            oCon.AsignarParametroDecimal("@importe", Convert.ToDecimal(dr["Importe"]));
                            oCon.AsignarParametroEntero("@personal", id_personal);
                            oCon.AsignarParametroFecha("@FechaCreate", DateTime.Now);

                            oCon.EjecutarComando();
                        }
                        oCon.ConfirmarTransaccion();
                        oCon.DesConectar();

                        break;
                    default:
                        oCon.DesConectar();
                        break;
                }
            }
        }
        public void GuardarAumentoTipoServicio(int idTarifa, int idTipoServicio, int tipoFacturacion, Decimal porcentaje, Decimal importe, Boolean subservicio, Boolean equipos, Boolean partes, int id_personal)
        {
            DataTable dt = new DataTable();
            Decimal importeViejo, importeNuevo;
            Int32 id;
            if (subservicio == true)
            {
                //SELECCIONO TODAS LAS TARIFAS QUE SEAN DEL TIPO DE SERVICIO DE LA TABLA servicios_servicios_sub
                try
                {
                    oCon.Conectar();
                    oCon.CrearComando("SELECT servicios_tarifas_sub.id,servicios_tarifas_sub.importe,servicios.id_servicios_tipos FROM servicios_tarifas_sub INNER JOIN servicios on servicios.id=servicios_tarifas_sub.id_Servicios WHERE servicios_tarifas_sub.id_servicios_tarifas=@idtarifa and servicios_tarifas_sub.id_tipo_facturacion=@tipofacturacion and servicios_tarifas_sub.tipo='S' and servicios.id_servicios_tipos=@idtipo");
                    oCon.AsignarParametroEntero("@idtarifa", idTarifa);
                    oCon.AsignarParametroEntero("@tipofacturacion", tipoFacturacion);
                    oCon.AsignarParametroEntero("@idtipo", idTipoServicio);


                    dt = oCon.Tabla();
                    oCon.DesConectar();
                }
                catch (Exception)
                {
                    oCon.DesConectar();
                    throw;
                }
                dt.Columns.Add("importeNuevo", typeof(decimal));
                dt.AcceptChanges();
                //RECORRO LOS RESULTADOS, OBTENGO LOS IMPORTES ACTUALES LOS MODIFICO Y ACTUALIZO LA TABLA
                foreach (DataRow item in dt.Rows)
                {
                    importeViejo = Convert.ToDecimal(item["importe"]);
                    id = Convert.ToInt32(item["id"]);
                    if (porcentaje != 0)
                        importeNuevo = importeViejo + ((porcentaje * importeViejo) / 100);
                    else
                        importeNuevo = importeViejo + importe;

                    item["importeNuevo"] = importeNuevo;
                    try
                    {
                        oCon.Conectar();
                        oCon.CrearComando("UPDATE servicios_tarifas_sub SET importe=@importeNuevo, Id_Personal_Update=@personal WHERE id=@id1");
                        oCon.AsignarParametroDecimal("@importeNuevo", importeNuevo);
                        oCon.AsignarParametroEntero("@personal", id_personal);
                        oCon.AsignarParametroEntero("@id1", id);
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
                //HAGO LO MISMO CON TARIFAS_SUB_esp

                //SELECCIONO TODAS LAS TARIFAS QUE SEAN DEL TIPO DE SERVICIO DE LA TABLA servicios_servicios_sub_esp
                try
                {
                    oCon.Conectar();
                    oCon.CrearComando("SELECT servicios_tarifas_sub_esp.id,servicios_tarifas_sub_esp.importe,servicios.id_servicios_tipos FROM servicios_tarifas_sub_esp INNER JOIN servicios on servicios.id=servicios_tarifas_sub_esp.id_Servicios WHERE servicios_tarifas_sub_esp.id_servicios_tarifas=@idtarifa and servicios_tarifas_sub_esp.id_tipo_facturacion=@tipofacturacion and servicios.id_servicios_tipos=@idtipo");
                    oCon.AsignarParametroEntero("@idtarifa", idTarifa);
                    oCon.AsignarParametroEntero("@tipofacturacion", tipoFacturacion);
                    oCon.AsignarParametroEntero("@idtipo", idTipoServicio);
                    dt = oCon.Tabla();
                    oCon.DesConectar();
                }
                catch (Exception)
                {
                    oCon.DesConectar();
                    throw;
                }
                dt.Columns.Add("importeNuevo", typeof(decimal));
                dt.AcceptChanges();
                //RECORRO LOS RESULTADOS, OBTENGO LOS IMPORTES ACTUALES LOS MODIFICO Y ACTUALIZO LA TABLA
                foreach (DataRow item in dt.Rows)
                {
                    importeViejo = Convert.ToDecimal(item["importe"]);
                    id = Convert.ToInt32(item["id"]);
                    if (porcentaje != 0)
                        importeNuevo = importeViejo + ((porcentaje * importeViejo) / 100);
                    else
                        importeNuevo = importeViejo + importe;

                    item["importeNuevo"] = importeNuevo;
                    try
                    {
                        oCon.Conectar();
                        oCon.CrearComando("UPDATE servicios_tarifas_sub_esp SET importe=@importeNuevo, Id_Personal_Update=@personal WHERE id=@id1");
                        oCon.AsignarParametroDecimal("@importeNuevo", importeNuevo);
                        oCon.AsignarParametroEntero("@personal", id_personal);
                        oCon.AsignarParametroEntero("@id1", id);
                        oCon.ComenzarTransaccion();
                        oCon.EjecutarComando();
                        oCon.ConfirmarTransaccion();
                        oCon.DesConectar();

                    }
                    catch (Exception)
                    {
                        oCon.DesConectar();
                        oCon.CancelarTransaccion();
                        throw;
                    }
                }
            }
            dt.Columns.Clear();
            dt.Rows.Clear();
            if (equipos == true)
            {
                //SELECCIONO TODAS LAS TARIFAS QUE SEAN DEL TIPO DE SERVICIO DE LA TABLA servicios_servicios_sub
                try
                {
                    oCon.Conectar();
                    oCon.CrearComando("SELECT servicios_tarifas_sub.id,servicios_tarifas_sub.importe,servicios.id_servicios_tipos FROM servicios_tarifas_sub INNER JOIN servicios on servicios.id=servicios_tarifas_sub.id_Servicios WHERE servicios_tarifas_sub.id_servicios_tarifas=@idtarifa and servicios_tarifas_sub.id_tipo_facturacion=@tipofacturacion and servicios_tarifas_sub.tipo='E' and servicios.id_servicios_tipos=@idtipo");
                    oCon.AsignarParametroEntero("@idtarifa", idTarifa);
                    oCon.AsignarParametroEntero("@tipofacturacion", tipoFacturacion);
                    oCon.AsignarParametroEntero("@idtipo", idTipoServicio);
                    dt = oCon.Tabla();
                    oCon.DesConectar();
                }
                catch (Exception)
                {
                    oCon.DesConectar();
                    throw;
                }
                dt.Columns.Add("importeNuevo", typeof(Int32));
                dt.AcceptChanges();
                //RECORRO LOS RESULTADOS, OBTENGO LOS IMPORTES ACTUALES LOS MODIFICO Y ACTUALIZO LA TABLA
                foreach (DataRow item in dt.Rows)
                {
                    importeViejo = Convert.ToDecimal(item["importe"]);
                    id = Convert.ToInt32(item["id"]);
                    if (porcentaje != 0)
                        importeNuevo = importeViejo + ((porcentaje * importeViejo) / 100);
                    else
                        importeNuevo = importeViejo + importe;

                    item["importeNuevo"] = importeNuevo;
                    try
                    {
                        oCon.Conectar();
                        oCon.CrearComando("UPDATE servicios_tarifas_sub SET importe=@importeNuevo, Id_Personal_Update=@personal WHERE id=@id1");
                        oCon.AsignarParametroEntero("@personal", id_personal);
                        oCon.AsignarParametroDecimal("@importeNuevo", importeNuevo);
                        oCon.AsignarParametroEntero("@id1", id);
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
            }
            dt.Columns.Clear();
            dt.Rows.Clear();
            if (partes == true)
            {
                //SELECCIONO TODAS LAS TARIFAS QUE SEAN DEL TIPO DE SERVICIO DE LA TABLA servicios_servicios_sub
                try
                {
                    oCon.Conectar();
                    oCon.CrearComando("SELECT servicios_tarifas_sub.id,servicios_tarifas_sub.importe,servicios.id_servicios_tipos FROM servicios_tarifas_sub INNER JOIN servicios on servicios.id=servicios_tarifas_sub.id_Servicios WHERE servicios_tarifas_sub.id_servicios_tarifas=@idtarifa and servicios_tarifas_sub.id_tipo_facturacion=@tipofacturacion and servicios_tarifas_sub.tipo='P' and servicios.id_servicios_tipos=@idtipo");
                    oCon.AsignarParametroEntero("@idtarifa", idTarifa);
                    oCon.AsignarParametroEntero("@tipofacturacion", tipoFacturacion);
                    oCon.AsignarParametroEntero("@idtipo", idTipoServicio);
                    dt = oCon.Tabla();
                    oCon.DesConectar();
                }
                catch (Exception)
                {
                    oCon.DesConectar();
                    throw;
                }
                dt.Columns.Add("importeNuevo", typeof(Int32));
                dt.AcceptChanges();
                //RECORRO LOS RESULTADOS, OBTENGO LOS IMPORTES ACTUALES LOS MODIFICO Y ACTUALIZO LA TABLA
                foreach (DataRow item in dt.Rows)
                {
                    importeViejo = Convert.ToDecimal(item["importe"]);
                    id = Convert.ToInt32(item["id"]);
                    if (porcentaje != 0)
                        importeNuevo = importeViejo + ((porcentaje * importeViejo) / 100);
                    else
                        importeNuevo = importeViejo + importe;

                    item["importeNuevo"] = importeNuevo;
                    try
                    {
                        oCon.Conectar();
                        oCon.CrearComando("UPDATE servicios_tarifas_sub SET importe=@importeNuevo, Id_Personal_Update=@personal WHERE id=@id1");
                        oCon.AsignarParametroEntero("@personal", id_personal);
                        oCon.AsignarParametroDecimal("@importeNuevo", importeNuevo);
                        oCon.AsignarParametroEntero("@id1", id);
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

            }
        }

        public DataTable Listar(int idservicios, int idtipofac, int idSub)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT grupo,tipo,servicio,tipofac,subservicio,tiposub,modalidad,velocidad,velocidad_tipo,servicio_base,mes_facturacion,meses_servicio,meses_cobro,mes_inicio,mes_fin,dias_desde,dias_hasta,porcentaje,nombre as nombreTarifa,fecha_desde,fecha_hasta,importe, " +
                    "id_servicios_grupos,id_servicios_tipos,id_servicios,factura_mensualmente,id_tipo_facturacion,id_servicios_sub,id_servicios_modalidad,id_servicios_velocidad,id_servicio_velocidad_tip,id_servicios_base,id_servicios_tarifas,idtipodesub,cobro_unico,requiere_ip,orden " +
                    "FROM vw_tarifas " +
                    "WHERE id_servicios=@idser and id_tipo_facturacion=@idtipofac and id_servicios_sub=@idsub " +
                    "AND(DATE(NOW()) BETWEEN Fecha_Desde AND Fecha_Hasta) order by dias_desde");

                oCon.AsignarParametroEntero("@idser", idservicios);
                oCon.AsignarParametroEntero("@idtipofac", idtipofac);
                oCon.AsignarParametroEntero("@idsub", idSub);

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

        public DataTable Listar(int idTarifa)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                //oCon.CrearComando("SELECT *,(SELECT Descripcion FROM Servicios_Sub WHERE Id = Id_Tabla_Tipo) AS SubServicio, (SELECT Descripcion FROM Servicios WHERE Id = Id_Servicios) AS Servicio, " +
                //    "(SELECT Id_Servicios_Sub_Tipos FROM Servicios_Sub WHERE Id = Id_Tabla_Tipo) AS Id_Servicios_Sub_Tipos  FROM Servicios_Tarifas_Sub WHERE Tipo = 'S';");
                oCon.CrearComando(String.Format("SELECT * FROM vw_tarifas where tiposub = 'S' and id_servicios_tarifas = {0} order by orden", idTarifa));
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

        public DataTable ListarTarifasEsp(int idTarifa, int idServicio, int idServicioSub, int id_tipo_facturacion)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando(String.Format("SELECT *, (SELECT Descripcion from Servicios WHERE Id = Id_Servicios) AS Servicio FROM Servicios_Tarifas_Sub_Esp WHERE Id_Servicios_Tarifas = {0} AND Id_Servicios = {1} AND Id_Servicios_Sub = {2} AND Id_Tipo_Facturacion = {3}", idTarifa, idServicio, idServicioSub, id_tipo_facturacion));
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

        public Decimal getImporte(int idtarifa, int idservicios, int id_tabla_tipo, String tipo, int id_tipo_facturacion)
        {
            Decimal importe = 0;

            try
            {
                oCon.Conectar();
                oCon.CrearComando(String.Format("SELECT Importe FROM servicios_tarifas_sub WHERE Id_Servicios_Tarifas = {0} AND Id_Servicios = {1} AND Id_Tabla_Tipo = {2} AND Tipo = '{3}' AND Id_Tipo_Facturacion = {4}", idtarifa, idservicios, id_tabla_tipo, tipo, id_tipo_facturacion));

                DataTable dt = oCon.Tabla();

                if (dt.Rows.Count > 0)
                {
                    importe = Convert.ToDecimal(dt.Rows[0]["Importe"]);
                }

                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }

            return importe;
        }

        public Int32 getMesesServicio(int idServicio, int idTipoFac, int idTarifa, int idVelocidad, int idVelocidadTipo)
        {
            Int32 meses = 0;

            try
            {
                oCon.Conectar();
                oCon.CrearComando(String.Format("SELECT Meses_Servicio FROM vw_tarifas WHERE Id_Servicios = {0} and id_tipo_facturacion={1} and id_servicios_tarifas={2} and id_servicios_velocidad={3} and id_servicio_velocidad_tip={4} and idtipodesub=1", idServicio, idTipoFac, idTarifa, idVelocidad, idVelocidadTipo));

                DataTable dt = oCon.Tabla();

                if (dt.Rows.Count > 0)
                    meses = Convert.ToInt32(dt.Rows[0]["Meses_Servicio"]);

                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }

            return meses;
        }

        public Int32 getMesesCobro(int idservicios, int idTipoFac, int idTarifa, int idVelocidad, int idVelocidadTipo)
        {
            Int32 meses = 0;

            try
            {
                oCon.Conectar();
                oCon.CrearComando(String.Format("SELECT Meses_Cobro FROM vw_tarifas WHERE Id_Servicios = {0} and id_tipo_facturacion={1} and id_servicios_tarifas={2} and id_servicios_velocidad={3} and id_servicio_velocidad_tip={4} and idtipodesub=1", idservicios, idTipoFac, idTarifa, idVelocidad, idVelocidadTipo));

                DataTable dt = oCon.Tabla();

                if (dt.Rows.Count > 0)
                    meses = Convert.ToInt32(dt.Rows[0]["Meses_Cobro"]);

                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }

            return meses;
        }

        public DataTable ListarCuadroTarifario(int idTarifa, int idTipoFacturacion)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando(String.Format("Select grupo, tipo, servicio, tipofac, subservicio, tiposub, modalidad, velocidad, velocidad_tipo, if(meses_servicio=0,1,meses_servicio) as meses_servicio, if(meses_cobro=0,1,meses_cobro) as meses_cobro, dias_desde, dias_hasta, importe, id_servicios_grupos, id_servicios_tipos, id_servicios, id_servicios_sub, id_servicios_modalidad, id_servicios_velocidad, id_servicio_velocidad_tip, id_servicios_tarifas, idtipodesub, requiere_ip  from vw_tarifas where id_servicios_tarifas={0} and id_tipo_facturacion={1}", idTarifa, idTipoFacturacion));
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

        public Decimal getPrecio(int idtarifa, int idservicios, int id_tabla_tipo, String tipo, int id_tipo_facturacion)
        {
            Decimal importe = 0;

            try
            {
                oCon.Conectar();
                oCon.CrearComando(String.Format("SELECT Importe FROM vw_tarifas WHERE Id_Servicios_Tarifas = {0} AND Id_Servicios ={1} AND Id_servicios_sub = {2} AND Tiposub = '{3}' AND Id_Tipo_Facturacion ={4}", idtarifa, idservicios, id_tabla_tipo, tipo, id_tipo_facturacion));

                DataTable dt = oCon.Tabla();

                if (dt.Rows.Count > 0)
                {
                    importe = Convert.ToDecimal(dt.Rows[0]["Importe"]);
                }

                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }

            return importe;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idtarifa">id tarifa actual</param>
        /// <param name="idtipofacturacion">1 zona 2 categoria</param>
        /// <param name="idserviciossub">id subservicio</param>
        /// <param name="idserviciosvel">id velocidad 0 si no posee</param>s
        /// <param name="idserviciosveltip">id velocidad tipo 0 si no posee </param>
        /// <param name="tipo">S SUBSERVICIO P SOLICITUD E EQUIPO</param>
        /// <returns></returns>
        public DataTable ObtienePrecio(Int32 idtarifa, Int32 idtipofacturacion, Int32 idservicios, Int32 idserviciossub, Int32 idserviciosvel, Int32 idserviciosveltip, String tipose, int idServiciosTarifasSubEsp = 0)
        {

            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();

                if (tipose == "P" || tipose == "E" || (tipose == "S" && idServiciosTarifasSubEsp == 0))
                {
                    oCon.CrearComando(String.Format("SELECT * FROM vw_tarifas where id_servicios_tarifas={0} " +
                        " and id_tipo_facturacion={1} and id_servicios = {2} and id_servicios_sub={3}" +
                        " and id_servicios_velocidad={4} and  id_servicio_velocidad_tip={5}" +
                        " and tiposub='{6}'", idtarifa, idtipofacturacion, idservicios, idserviciossub, idserviciosvel, idserviciosveltip, tipose));
                }
                else
                    oCon.CrearComando(String.Format("SELECT * FROM vw_tarifas where id_servicios_tarifas_sub_esp={0}", idServiciosTarifasSubEsp));
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

        public decimal ListarPrecioSub(int id_tipo_servicio, int id_servicio, int id_sub_servicio, int id_tarifa, int tipo_facturacion)
        {
            decimal Importe = 0;
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("select importe from vw_tarifas where tiposub='S' and id_servicios=@id_servicios and id_servicios_sub=@id_servicios_sub and id_servicios_tarifas=@id_tarifa and id_tipo_facturacion=@id_tipo_facturacion and id_servicios_tipos=@id_tipo_servicio");
                oCon.AsignarParametroEntero("@id_servicios", id_servicio);
                oCon.AsignarParametroEntero("@id_servicios_sub", id_sub_servicio);
                oCon.AsignarParametroEntero("@id_tarifa", id_tarifa);
                oCon.AsignarParametroEntero("@id_tipo_facturacion", tipo_facturacion);
                oCon.AsignarParametroEntero("@id_tipo_servicio", id_tipo_servicio);
                dt = oCon.Tabla();
                oCon.DesConectar();

            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }
            Importe = Convert.ToDecimal(dt.Rows[0][0]);
            return Importe;
        }

        public DataTable ListarTarifasVelocidades(int id_servicios_sub, int id_tarifa, int id_tipo_facturacion, int id_tipo_velocidad)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECt vw_tarifas.servicio,vw_tarifas.importe,servicios_velocidades.velocidad,vw_tarifas.id_servicios_velocidad,vw_tarifas.id_servicio_velocidad_tip FROM vw_tarifas " +
                " inner join servicios_velocidades on servicios_velocidades.id = vw_tarifas.id_Servicios_velocidad" +
                " where id_servicios_sub =@id_servicios_sub and tiposub = 'S' and id_Servicios_tarifas =@id_tarifa and id_tipo_facturacion = @tipo_facturacion and id_servicio_velocidad_tip=@id_servicio_velocidad_tip");
                oCon.AsignarParametroEntero("@id_servicios_sub", id_servicios_sub);
                oCon.AsignarParametroEntero("@tipo_facturacion", id_tipo_facturacion);
                oCon.AsignarParametroEntero("@id_tarifa", id_tarifa);
                oCon.AsignarParametroEntero("@id_servicio_velocidad_tip", id_tipo_velocidad);
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
        public DataTable ListarTarifasVel(int idTarifa, int idServicio, int idTipoFac, string tiposub)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT grupo,tipo,servicio,tipofac,subservicio,tiposub,modalidad,velocidad,velocidad_tipo,mes_facturacion,meses_cobro,mes_inicio,mes_fin,dias_desde,dias_hasta,porcentaje,nombre as nombre_tarifa,fecha_desde,fecha_hasta,importe,id_servicios_grupos,id_servicios_tipos,id_servicios,factura_mensualmente,id_tipo_facturacion,id_servicios_sub,id_servicios_modalidad,id_servicios_velocidad,id_servicio_velocidad_tip,id_servicios_base,id_servicios_tarifas,idtipodesub,tipodesub,cobro_unico,requiere_ip,orden FROM vw_tarifas" +
                    " WHERE id_servicios_tarifas=@idtarifa and id_tipo_facturacion=@idtipofac and  id_servicios = @idservicio and tiposub=@tiposub1 and idtipodesub=1 and velocidad>0 and id_servicios_sub>0");
                oCon.AsignarParametroEntero("@idtarifa", idTarifa);
                oCon.AsignarParametroEntero("@idservicio", idServicio);
                oCon.AsignarParametroEntero("@idtipofac", idTipoFac);
                oCon.AsignarParametroCadena("@tiposub1", tiposub);

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
