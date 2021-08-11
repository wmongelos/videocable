using CapaDatos;
using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace CapaNegocios
{
    public class Presentacion_Debitos
    {
        public int Id { get; set; }
        public DateTime Fecha_Presentacion { get; set; }
        public int Id_Prefacturacion_Asociada { get; set; }
        public DateTime Fecha_Creacion { get; set; }
        public int Borrado { get; set; }
        public int Id_Estado { get; set; }
        public string Periodo { get; set; }
        public int Id_Forma_De_Pago { get; set; }
        public decimal Monto_Total { get; set; }
        public decimal Monto_Pagado { get; set; }
        public int Cantidad_Recibos { get; set; }
        public int Id_Primer_Recibo { get; set; }
        public int Id_Ultimo_Recibo { get; set; }
        public int Cantidad_Total_Plasticos { get; set; }
        public int Cant_Plasticos_Aceptados { get; set; }
        public int Cant_Plasticos_Rechazados { get; set; }


        private Conexion oCon = new Conexion();

        public enum ESTADO
        {
            ARCHIVO_PENDIENTE = 1,
            RECIBO_PENDIENTE = 2,
            PAGO_GENERADO = 3

        }

        public int Guardar(Presentacion_Debitos oPresentacionDebitos)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("insert into presentacion_debitos(fecha_presentacion, monto_total, fecha_creacion, id_estado, periodo, id_forma_de_pago,cantidad_total_plasticos) VALUES" +
                                       "(@fecha_presentacion, @monto_total, @fecha_creacion, @id_estado, @periodo, @id_forma_de_pago,@cant_plasticos); SELECT @@IDENTITY");
                oCon.AsignarParametroFecha("@fecha_presentacion", oPresentacionDebitos.Fecha_Presentacion);
                oCon.AsignarParametroDecimal("@monto_total", oPresentacionDebitos.Monto_Total);
                oCon.AsignarParametroFecha("@fecha_creacion", oPresentacionDebitos.Fecha_Creacion);
                oCon.AsignarParametroEntero("@id_estado", oPresentacionDebitos.Id_Estado);
                oCon.AsignarParametroCadena("@periodo", oPresentacionDebitos.Periodo);
                oCon.AsignarParametroEntero("@id_forma_de_pago", oPresentacionDebitos.Id_Forma_De_Pago);
                oCon.AsignarParametroEntero("@cant_plasticos", oPresentacionDebitos.Cantidad_Total_Plasticos);
                oCon.ComenzarTransaccion();
                oPresentacionDebitos.Id = oCon.EjecutarScalar();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                throw;
            }
            return oPresentacionDebitos.Id;
        }

        public int Eliminar(int id)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("call spBorrarPresentacion(@id)");
                oCon.AsignarParametroEntero("@id", id);
                oCon.EjecutarComando();
                oCon.DesConectar();
                return 0;
            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                return -1;
            }
        }

        public DataTable Listar(int idPresentacion, DateTime fechaPresentacion, DateTime fechaDesde, DateTime fechaHasta)
        {
            string consulta = String.Empty;
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                consulta = String.Format("select * from vw_presentacion_debitos where borrado>=0 ");
                if (idPresentacion > 0)
                    consulta = String.Format("{0} and id={1}", consulta, idPresentacion);
                else if (fechaPresentacion.Year > 1900)
                    consulta = String.Format("{0} and fecha_presentacion='{1}'", consulta, fechaPresentacion.ToString("yyyy-MM-dd"));
                else
                    consulta = String.Format("{0} and fecha_presentacion>='{1}' and fecha_presentacion<='{2}'", consulta, fechaDesde.ToString("yyyy-MM-dd"), fechaHasta.ToString("yyyy-MM-dd"));
                oCon.CrearComando(consulta);
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

        public DataTable ListarUltimaPresentacion()
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando("select * from presentacion_debitos where borrado=0 order by id desc limit 1");
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
        public DataTable ListarUltimasPresentacion()
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando("select * from vw_presentacion_debitos where borrado=0 order by id desc limit 5");
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

        public DataTable ListarTodas()
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando("select * from vw_presentacion_debitos where borrado=0 order by id desc");
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
        public void ActualizarEstado(int idPresentacion, int idEstado)
        {
            try
            {
                oCon.Conectar();
                oCon.ComenzarTransaccion();
                oCon.CrearComando("UPDATE presentacion_debitos SET id_estado = @id_estado WHERE Id = @id");
                oCon.AsignarParametroEntero("@id_estado", idEstado);
                oCon.AsignarParametroEntero("@id", idPresentacion);
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

        public DataTable ListarUsuariosServiciosDelDebito(int idDebito, DateTime fechaPresentacion)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                //oCon.CrearComando(String.Format("select 0 as id,0 as id_presentacion,id_plastico,id_usuarios_servicios, id_usuarios, codigo_usuario,servicio,usuario,0 as monto_deuda_atrasada,0 as monto_estimado,0 as monto_deuda_adelantada,0 as total from vw_plasticos_usuarios_servicios where (usuarios_servicios_id_estado={0} or usuarios_servicios_id_estado={1} or usuarios_servicios_id_estado={2}) and id_plastico={4} and plasticos_usuarios_borrado=0 and vw_usuarios_servicios_borrado=0 and activo={5} and fecha_inicio_plastico<='{6}' and fecha_factura_usuario_servicio<'{6}' group by id_usuarios_servicios", Convert.ToInt32(Servicios.Servicios_Estados.SIN_CONECTAR), Convert.ToInt32(Servicios.Servicios_Estados.CONECTADO), Convert.ToInt32(Servicios.Servicios_Estados.EN_ESPERA), Convert.ToInt32(Servicios.Servicios_Estados.CORTADO), idDebito, Convert.ToInt32(Plasticos_Usuarios.ESTADO.ACTIVO),fechaPresentacion.ToString("yyyy-MM-dd")));
                oCon.CrearComando(String.Format("select 0 as id, 0 as id_presentacion, datosPlasticosUsuarios.*, usuarios_servicios.id_usuarios, usuarios_servicios.codigo as codigo_usuario, usuarios_servicios.servicio, usuarios_servicios.usuario, '0' as monto_deuda_atrasada, '0' as monto_estimado, '0' as monto_prefacturacion," +
                                               " '0' as monto_deuda_adelantada, '0' as total, usuarios_servicios.fecha_factura as fecha_factura_usuario_servicio" +
                                               " from(select id_plastico, id_usuarios_servicios from plasticos_usuarios where id_plastico ={4}" +
                                               " and borrado = 0 and activo = {5} and fecha_inicio<= '{6}')datosPlasticosUsuarios" +
                                               " inner join(select usuarios_servicios.id, usuarios_servicios.id_usuarios, usuarios_servicios.id_servicios, usuarios_servicios.fecha_factura, servicios.descripcion as servicio, concat_ws(' ', usuarios.apellido, usuarios.nombre) as usuario, usuarios.codigo from" +
                                               " (select * from usuarios_servicios where id_servicios_estados ={0}" +
                                               " or id_servicios_estados = {1} or id_servicios_estados = {2})usuarios_servicios" +
                                               " left join servicios on usuarios_servicios.id_servicios = servicios.id inner join usuarios on usuarios_servicios.id_usuarios = usuarios.id where usuarios_servicios.id_usuarios>0 and usuarios_servicios.borrado=0)usuarios_servicios on datosPlasticosUsuarios.id_usuarios_servicios = usuarios_servicios.id", Convert.ToInt32(Servicios.Servicios_Estados.SIN_CONECTAR), Convert.ToInt32(Servicios.Servicios_Estados.CONECTADO), Convert.ToInt32(Servicios.Servicios_Estados.EN_ESPERA), Convert.ToInt32(Servicios.Servicios_Estados.CORTADO), idDebito, Convert.ToInt32(Plasticos_Usuarios.ESTADO.ACTIVO), fechaPresentacion.ToString("yyyy-MM-dd")));
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

        public bool GenerarArchivoPresentacion(DataTable dtPlasticosPresentacion, int idFormaDePago, Presentacion_Debitos oPresentacionDebitos)
        {
            bool respuesta = false;
            DataTable dtDatosFormaPago = new DataTable();
            Formas_de_pago oFormasDePago = new Formas_de_pago();
            SaveFileDialog datosArchivoGenerar = new SaveFileDialog();
            StreamWriter escritor;

            try
            {
                dtDatosFormaPago = oFormasDePago.ListarPorId(idFormaDePago);
                if (Convert.ToInt32(dtDatosFormaPago.Rows[0]["id_tipo_de_forma"]) == Convert.ToInt32(Formas_de_pago.Tipos_Formas_Pagos.DEBITO_AUTOMATICO))
                {
                    datosArchivoGenerar.FileName = "Presentacion.txt";
                    datosArchivoGenerar.Filter = "Archivos de texto (*.txt)|*.txt|Todos los archivos (*.*)|*.*";
                    if (datosArchivoGenerar.ShowDialog() == DialogResult.OK)
                    {
                        escritor = new StreamWriter(datosArchivoGenerar.FileName);
                        int contLotes = 0;
                        int contPlasticosLote = 0;
                        int cantidadPorLote = 99;
                        int contPlasticos = 0;
                        int primerPlasticoLote = 0;
                        int ultimoPlasticoLote = 0;
                        decimal totalLote = 0;
                        string nroLote = String.Empty;
                        string cabecera = String.Empty;
                        string numeroPlastico = String.Empty;
                        string cantTarjetasLote = "";
                        foreach (DataRow plastico in dtPlasticosPresentacion.Rows)
                        {
                            contPlasticos++;
                            contPlasticosLote++;
                            if (contPlasticosLote == 1)
                            {
                                contLotes++;
                                totalLote = 0;
                                primerPlasticoLote = contPlasticos - 1;
                                if (dtPlasticosPresentacion.Rows.Count - primerPlasticoLote >= cantidadPorLote)
                                    ultimoPlasticoLote = primerPlasticoLote + (cantidadPorLote - 1);
                                else
                                    ultimoPlasticoLote = dtPlasticosPresentacion.Rows.Count - 1;
                                if (primerPlasticoLote == ultimoPlasticoLote)
                                    totalLote += Convert.ToDecimal(dtPlasticosPresentacion.Rows[primerPlasticoLote]["total"]);
                                else
                                {
                                    for (int x = primerPlasticoLote; x < ultimoPlasticoLote; x++)
                                        totalLote += Convert.ToDecimal(dtPlasticosPresentacion.Rows[x]["total"]);
                                    totalLote += Convert.ToDecimal(dtPlasticosPresentacion.Rows[ultimoPlasticoLote]["total"]);
                                }
                                int cantDecimales = GetDecimalLength(totalLote.ToString());
                                string totalLoteCadena = String.Empty;
                                totalLoteCadena = totalLote.ToString().Replace(",", "");
                                if (cantDecimales == 0)
                                    totalLoteCadena = String.Format("{0}00", totalLoteCadena);
                                else if (cantDecimales == 1)
                                    totalLoteCadena = String.Format("{0}0", totalLoteCadena);
                                cantTarjetasLote = ((ultimoPlasticoLote - primerPlasticoLote) + 1).ToString();
                                if (cantTarjetasLote.Length == 1)
                                {
                                    cantTarjetasLote = "0" + cantTarjetasLote;
                                }
                                escritor.WriteLine(String.Format("0DB{0}{1}{2}       {3}{4}{5} 9010                  ", DateTime.Now.ToString("ddMMyy"), dtDatosFormaPago.Rows[0]["codigo_empresa_tarjeta"].ToString().PadLeft(6, '0'), contLotes.ToString().PadLeft(4, '0'), dtDatosFormaPago.Rows[0]["codigo_empresa_banco"].ToString().PadLeft(14, '0'), cantTarjetasLote, totalLoteCadena.PadLeft(15, '0')));
                            }

                            numeroPlastico = plastico["numero"].ToString().Replace("-", "");
                            int cantDecimalesPlastico = GetDecimalLength(plastico["total"].ToString());
                            string totalPlasticoCadena = plastico["total"].ToString().Replace(",", "");
                            if (cantDecimalesPlastico == 0)
                                totalPlasticoCadena = String.Format("{0}00", totalPlasticoCadena);
                            else if (cantDecimalesPlastico == 1)
                                totalPlasticoCadena = String.Format("{0}0", totalPlasticoCadena);
                            escritor.WriteLine(String.Format("   {0} {1}{2}        {3}       {4} ", numeroPlastico, contPlasticos.ToString().PadLeft(8, '0'), DateTime.Now.ToString("ddMMyy"), Convert.ToDouble(totalPlasticoCadena).ToString().PadLeft(15, '0'), plastico["codigo_usuario"].ToString().PadLeft(15, '0')));
                            if (contPlasticosLote == 99)
                                contPlasticosLote = 0;

                        }
                        escritor.Close();
                    }
                }
                respuesta = true;
            }
            catch
            {
                respuesta = false;
            }
            return respuesta;
        }

        public DataTable RetornarSubServicios(int idTarifa, int idUsuario, int idLocacion, int idUsuariosServicios, DateTime fechaInicioServicio, bool contemplarServiciosCortados, bool contemplarServiciosNoFacturablesMensual)
        {
            string consulta = String.Empty;
            DataTable dtEstructuraBonificaciones = new DataTable();
            Bonificaciones oBonificaciones = new Bonificaciones();
            dtEstructuraBonificaciones = oBonificaciones.GenerarDtSubServicios();
            DataRow fila;
            DataView dtv;

            if (idTarifa > 0)
            {
                oCon.Conectar();
                if (idUsuario > 0 || idLocacion > 0 || idUsuariosServicios > 0)
                {
                    if (idUsuariosServicios > 0)
                        consulta = String.Format("select vw_usuarios_servicios_sub.*, vw_tarifas.importe as importe_original, vw_tarifas.importe as importe_con_descuento, vw_tarifas.id_servicios_tarifas " +
                                            "from(select * from vw_usuarios_servicios_sub where id_usuarios_servicios = {0} and(vw_usuarios_servicios_sub.id_servicios_estados = {1} or vw_usuarios_servicios_sub.id_servicios_estados = {2} or vw_usuarios_servicios_sub.id_servicios_estados = {3} or vw_usuarios_servicios_sub.id_servicios_estados = {4}) " +
                                            "and vw_usuarios_servicios_sub.id_servicios_sub_tipos != {5})vw_usuarios_servicios_sub inner join(select * from vw_tarifas where vw_tarifas.tiposub = 'S' and vw_tarifas.id_servicios_tarifas = {6})vw_tarifas on vw_usuarios_servicios_sub.id_servicios_sub = vw_tarifas.id_servicios_sub " +
                                            "and vw_usuarios_servicios_sub.id_tipo_facturacion = vw_tarifas.id_tipo_facturacion and vw_usuarios_servicios_sub.id_servicios_velocidades = vw_tarifas.id_servicios_velocidad " +
                                            "and vw_usuarios_servicios_sub.id_servicios_velocidades_tip = vw_tarifas.id_servicio_velocidad_tip group by vw_usuarios_servicios_sub.id",
                                             idUsuariosServicios, Convert.ToInt16(Servicios.Servicios_Estados.SIN_CONECTAR), Convert.ToInt16(Servicios.Servicios_Estados.CONECTADO), Convert.ToInt16(Servicios.Servicios_Estados.EN_ESPERA), Convert.ToInt16(Servicios.Servicios_Estados.CORTADO), Convert.ToInt16(Servicios_Sub.SERVICIO_SUB_TIPOS.DERECHO_DE_CONEXION), idTarifa);
                    else if (idLocacion > 0)
                        consulta = String.Format("select vw_usuarios_servicios_sub.*, vw_tarifas.importe as importe_original, vw_tarifas.importe as importe_con_descuento, vw_tarifas.id_servicios_tarifas " +
                                            "from(select * from vw_usuarios_servicios_sub where id_usuarios_locaciones = {0} and(vw_usuarios_servicios_sub.id_servicios_estados = {1} or vw_usuarios_servicios_sub.id_servicios_estados = {2} or vw_usuarios_servicios_sub.id_servicios_estados = {3} or vw_usuarios_servicios_sub.id_servicios_estados = {4}) " +
                                            "and vw_usuarios_servicios_sub.id_servicios_sub_tipos != {5})vw_usuarios_servicios_sub inner join(select * from vw_tarifas where vw_tarifas.tiposub = 'S' and vw_tarifas.id_servicios_tarifas = {6})vw_tarifas on vw_usuarios_servicios_sub.id_servicios_sub = vw_tarifas.id_servicios_sub " +
                                            "and vw_usuarios_servicios_sub.id_tipo_facturacion = vw_tarifas.id_tipo_facturacion and vw_usuarios_servicios_sub.id_servicios_velocidades = vw_tarifas.id_servicios_velocidad " +
                                            "and vw_usuarios_servicios_sub.id_servicios_velocidades_tip = vw_tarifas.id_servicio_velocidad_tip group by vw_usuarios_servicios_sub.id",
                                             idLocacion, Convert.ToInt16(Servicios.Servicios_Estados.SIN_CONECTAR), Convert.ToInt16(Servicios.Servicios_Estados.CONECTADO), Convert.ToInt16(Servicios.Servicios_Estados.EN_ESPERA), Convert.ToInt16(Servicios.Servicios_Estados.CORTADO), Convert.ToInt16(Servicios_Sub.SERVICIO_SUB_TIPOS.DERECHO_DE_CONEXION), idTarifa);
                    else
                        consulta = String.Format("select vw_usuarios_servicios_sub.*, vw_tarifas.importe as importe_original, vw_tarifas.importe as importe_con_descuento, vw_tarifas.id_servicios_tarifas " +
                                            " from(SELECT usuarios_servicios_sub.Id AS id,usuarios_servicios_sub.Id_Usuarios_Servicios AS id_usuarios_servicios,usuarios_servicios_sub.Id_Servicios_Sub AS id_servicios_sub,servicios_sub.Id_Servicios_Sub_Tipos AS id_servicios_sub_tipos," +
                                            " servicios_sub.Id_Servicios AS 'id_servicios',servicios.Id_Servicios_Tipos AS 'id_servicios_tipos',servicios.Id_Servicios_Modalidad AS 'id_servicios_modalidad',servicios.Id_Servicios_Ejecutable AS 'id_servicios_ejecutable'," +
                                            " servicios_tipos.Id_Servicios_Grupos AS 'id_servicios_grupos',usuarios_servicios_sub.Id_Servicios_Velocidades AS 'id_servicios_velocidades',usuarios_servicios_sub.Id_Servicios_Velocidades_Tip AS 'id_servicios_velocidades_tip'," +
                                            " usuarios_servicios_sub.Requiere_IP AS 'requiere_ip',usuarios_servicios_sub.Id_Ip_fija AS 'id_ip_fija',usuarios_servicios_sub.Id_Bonificacion_Esp AS 'id_bonificacion_esp',usuarios_servicios_sub.Id_Bonificacion_Aplicada AS 'id_bonificacion_aplicada'," +
                                            " usuarios_servicios_sub.Porcentaje_Bonificacion_Aplicada AS 'porcentaje_bonificacion_aplicada',usuarios_servicios_sub.Nombre_Bonificacion_Aplicacion AS 'nombre_bonificacion_aplicacion',usuarios_servicios_sub.fecha_desde,usuarios_servicios_sub.fecha_hasta," +
                                            " usuarios_servicios_sub.fecha_inicio,usuarios_servicios_sub.fecha_fin,usuarios_servicios.Id_Usuarios AS 'id_usuarios',usuarios_servicios.Id_Usuarios_Locaciones AS 'id_usuarios_locaciones',usuarios_servicios.Id_Tipo_Facturacion AS 'id_tipo_facturacion'," +
                                            " usuarios_servicios.Fecha_Factura AS 'fecha_factura',usuarios_servicios.cant_bocas,usuarios_servicios.Cant_Bocas_Pac AS 'cant_bocas_pac',usuarios_servicios.Id_Servicios_Estados AS 'id_servicios_estados', usuarios_servicios.Meses_Servicio AS 'meses_servicio'," +
                                            " usuarios_servicios.Meses_Cobro AS 'meses_cobro',usuarios_locaciones.Id_Localidades AS 'id_localidades',servicios_sub.Descripcion AS 'servicio_sub',servicios_sub.Valor_Defecto AS 'valor_defecto',servicios_sub.id_iva_alicuotas," +
                                            " servicios_sub_tipos.Nombre AS 'servicio_sub_tipo',servicios_sub_tipos.Cobro_Unico AS 'cobro_unico',IF((ISNULL(servicios_velocidades.Velocidad) = 1), '-', CONCAT(CAST(servicios_velocidades.Velocidad AS char(50) CHARSET utf8), ' MB')) AS 'velocidad'," +
                                            " IF((ISNULL(servicios_velocidades_tip.Nombre) = 1), '-', servicios_velocidades_tip.Nombre) AS 'velocidad_tipo',servicios.Codigo AS 'servicio_codigo',servicios.Descripcion AS 'servicio',servicios.Requiere_Equipo AS 'requiere_equipo'," +
                                            " servicios.Requiere_Tarjeta AS 'requiere_tarjeta',servicios.Requiere_Velocidad AS 'requiere_velocidad',servicios.TipoCorte AS 'tipocorte',servicios.CorteAutomatico AS 'corteautomatico',servicios.Factura_Mensualmente AS 'factura_mensualmente'," +
                                            " servicios_modalidad.Nombre AS 'servicio_modalidad',IF(((SELECT configuracion.Valor_N FROM configuracion WHERE (configuracion.Id = 10)) = 1), (SELECT zonas.Nombre FROM zonas WHERE (zonas.Id = usuarios_servicios.Id_Tipo_Facturacion)), (SELECT servicios_categorias.Nombre FROM servicios_categorias WHERE (servicios_categorias.Id = usuarios_servicios.Id_Tipo_Facturacion))) AS 'tipo_facturacion'," +
                                            " servicios_tipos.Nombre AS 'servicio_tipo',servicios_grupos.Nombre AS 'servicio_grupo',usuarios.Codigo AS 'usuario_codigo',CONCAT(usuarios.Apellido, ' ', usuarios.Nombre) AS 'usuario',usuarios.Apellido AS 'usuarios_apellido'," +
                                            " usuarios.Nombre AS 'usuarios_nombre',usuarios_locaciones.Calle AS 'calle',usuarios_locaciones.Altura AS 'altura',CONCAT('Piso:', usuarios_locaciones.Piso) AS 'piso',CONCAT('Depto.:', usuarios_locaciones.Depto) AS 'depto',localidades.Nombre AS 'localidad','S' AS 'tipo_servicio_sub',usuarios.Calculo_Bonificacion AS 'calculo_bonificacion'" +
                                            " FROM (((((((((((((select usuarios_servicios_sub.* from usuarios_servicios_sub inner join (select id from usuarios_servicios where id_usuarios={0} and (id_servicios_estados={1} or id_servicios_estados={2} or id_servicios_estados={3} or id_servicios_estados={4}) and borrado=0)usuarios_servicios on usuarios_servicios_sub.id_usuarios_servicios=usuarios_servicios.id)usuarios_servicios_sub" +
                                            " LEFT JOIN servicios_sub ON ((usuarios_servicios_sub.Id_Servicios_Sub = servicios_sub.Id)))" +
                                            " LEFT JOIN usuarios_servicios ON ((usuarios_servicios_sub.Id_Usuarios_Servicios = usuarios_servicios.Id)))" +
                                            " LEFT JOIN usuarios ON ((usuarios_servicios.Id_Usuarios = usuarios.Id)))" +
                                            " LEFT JOIN servicios ON ((usuarios_servicios.Id_Servicios = servicios.Id)))" +
                                            " LEFT JOIN servicios_modalidad ON ((servicios.Id_Servicios_Modalidad = servicios_modalidad.Id)))" +
                                            " LEFT JOIN servicios_sub_tipos ON ((servicios_sub.Id_Servicios_Sub_Tipos = servicios_sub_tipos.Id)))" +
                                            " LEFT JOIN servicios_velocidades ON ((usuarios_servicios_sub.Id_Servicios_Velocidades = servicios_velocidades.Id)))" +
                                            " LEFT JOIN servicios_velocidades_tip ON ((usuarios_servicios_sub.Id_Servicios_Velocidades_Tip = servicios_velocidades_tip.Id)))" +
                                            " LEFT JOIN usuarios_locaciones ON ((usuarios_servicios.Id_Usuarios_Locaciones = usuarios_locaciones.Id)))" +
                                            " LEFT JOIN localidades ON ((usuarios_locaciones.Id_Localidades = localidades.Id)))" +
                                            " LEFT JOIN servicios_tipos ON ((servicios.Id_Servicios_Tipos = servicios_tipos.Id)))" +
                                            " LEFT JOIN servicios_grupos ON ((servicios_tipos.Id_Servicios_Grupos = servicios_grupos.Id))))vw_usuarios_servicios_sub inner join(select * from vw_tarifas where vw_tarifas.tiposub = 'S' and vw_tarifas.id_servicios_tarifas = {6})vw_tarifas on vw_usuarios_servicios_sub.id_servicios_sub = vw_tarifas.id_servicios_sub " +
                                            "and vw_usuarios_servicios_sub.id_tipo_facturacion = vw_tarifas.id_tipo_facturacion and vw_usuarios_servicios_sub.id_servicios_velocidades = vw_tarifas.id_servicios_velocidad " +
                                            "and vw_usuarios_servicios_sub.id_servicios_velocidades_tip = vw_tarifas.id_servicio_velocidad_tip and vw_usuarios_servicios_sub.id_servicios_sub_tipos!={5} group by vw_usuarios_servicios_sub.id",
                                             idUsuario, Convert.ToInt16(Servicios.Servicios_Estados.SIN_CONECTAR), Convert.ToInt16(Servicios.Servicios_Estados.CONECTADO), Convert.ToInt16(Servicios.Servicios_Estados.EN_ESPERA), Convert.ToInt16(Servicios.Servicios_Estados.CORTADO), Convert.ToInt16(Servicios_Sub.SERVICIO_SUB_TIPOS.DERECHO_DE_CONEXION), idTarifa);
                }
                else
                    consulta = String.Format("select vw_usuarios_servicios_sub.*, vw_tarifas.importe as importe_original, vw_tarifas.importe as importe_con_descuento, vw_tarifas.id_servicios_tarifas " +
                                            "from(select * from vw_usuarios_servicios_sub where (vw_usuarios_servicios_sub.id_servicios_estados = {0} or vw_usuarios_servicios_sub.id_servicios_estados = {1} or vw_usuarios_servicios_sub.id_servicios_estados = {2} or vw_usuarios_servicios_sub.id_servicios_estados = {3}) " +
                                            "and vw_usuarios_servicios_sub.id_servicios_sub_tipos != {4})vw_usuarios_servicios_sub inner join(select * from vw_tarifas where vw_tarifas.tiposub = 'S' and vw_tarifas.id_servicios_tarifas = {5})vw_tarifas on vw_usuarios_servicios_sub.id_servicios_sub = vw_tarifas.id_servicios_sub " +
                                            "and vw_usuarios_servicios_sub.id_tipo_facturacion = vw_tarifas.id_tipo_facturacion and vw_usuarios_servicios_sub.id_servicios_velocidades = vw_tarifas.id_servicios_velocidad " +
                                            "and vw_usuarios_servicios_sub.id_servicios_velocidades_tip = vw_tarifas.id_servicio_velocidad_tip group by vw_usuarios_servicios_sub.id",
                                             Convert.ToInt16(Servicios.Servicios_Estados.SIN_CONECTAR), Convert.ToInt16(Servicios.Servicios_Estados.CONECTADO), Convert.ToInt16(Servicios.Servicios_Estados.EN_ESPERA), Convert.ToInt16(Servicios.Servicios_Estados.CORTADO), Convert.ToInt16(Servicios_Sub.SERVICIO_SUB_TIPOS.DERECHO_DE_CONEXION), idTarifa);

                oCon.CrearComando(consulta);

                DataTable dt = oCon.Tabla();

                oCon.DesConectar();

                if (dt.Rows.Count > 0)
                {
                    dtv = new DataView(dt);
                    if (contemplarServiciosCortados == false)
                        dtv.RowFilter = String.Format("id_servicios_estados<>{0}", Convert.ToInt16(Servicios.Servicios_Estados.CORTADO));
                    if (contemplarServiciosNoFacturablesMensual == false)
                        dtv.RowFilter = String.Format("factura_mensualmente='SI'");
                    dt = dtv.ToTable();
                    foreach (DataRow filaDb in dt.Rows)
                    {
                        fila = dtEstructuraBonificaciones.NewRow();
                        fila["id_usuario_servicio"] = filaDb["id_usuarios_servicios"];
                        fila["id_usuario_servicio_sub"] = filaDb["id"];
                        fila["id_tipo_facturacion"] = filaDb["id_tipo_facturacion"];
                        fila["id_grupo"] = filaDb["id_servicios_grupos"];
                        fila["id_servicio_tipo"] = filaDb["id_servicios_tipos"];
                        fila["id_servicio"] = filaDb["id_servicios"];
                        fila["id_servicio_sub"] = filaDb["id_servicios_sub"];
                        fila["id_velocidad"] = filaDb["id_servicios_velocidades"];
                        fila["id_velocidad_tipo"] = filaDb["id_servicios_velocidades_tip"];
                        fila["tipo_servicio_sub"] = filaDb["tipo_servicio_sub"];
                        fila["cant_bocas_pac"] = filaDb["cant_bocas_pac"];
                        fila["servicio"] = filaDb["servicio"];
                        fila["subservicio"] = filaDb["servicio_sub"];
                        fila["velocidad"] = filaDb["velocidad"];
                        fila["velocidad_tipo"] = filaDb["velocidad_tipo"];
                        fila["nombre_bonificacion"] = filaDb["nombre_bonificacion_aplicacion"];
                        fila["id_ip_fija"] = filaDb["id_ip_fija"];
                        fila["id_tipo_de_sub"] = filaDb["id_servicios_sub_tipos"];
                        fila["importe_original"] = filaDb["importe_original"];
                        fila["importe_con_descuento"] = filaDb["importe_con_descuento"];
                        fila["id_usuarios"] = filaDb["id_usuarios"];
                        fila["id_usuarios_locaciones"] = filaDb["id_usuarios_locaciones"];
                        fila["fecha_factura"] = Convert.ToDateTime(filaDb["fecha_fin"]).ToString("yyyy-MM-dd");
                        fila["id_servicios_tarifas"] = filaDb["id_servicios_tarifas"];
                        fila["requiere_ip"] = Convert.ToInt32(filaDb["requiere_ip"]);
                        fila["cobro_unico"] = filaDb["cobro_unico"];
                        fila["meses_cobro"] = filaDb["meses_cobro"];
                        fila["meses_servicio"] = filaDb["meses_servicio"];
                        fila["id_servicio_modalidad"] = filaDb["id_servicios_modalidad"];
                        fila["calle"] = filaDb["calle"];
                        fila["altura"] = filaDb["altura"];
                        fila["piso"] = filaDb["piso"];
                        fila["depto"] = filaDb["depto"];
                        fila["localidad"] = filaDb["localidad"];
                        fila["usuario"] = filaDb["usuario"];
                        fila["codigo_usuario"] = filaDb["usuario_codigo"];
                        fila["fecha_inicio_servicio"] = fechaInicioServicio.ToString("yyyy-MM-dd");
                        try
                        {
                            fila["fecha_factura"] = Convert.ToDateTime(filaDb["fecha_fin"]).ToString("yyyy-MM-dd");
                        }
                        catch
                        {
                            fila["fecha_factura"] = filaDb["fecha_fin"];
                        }
                        fila["fecha_factura_servicio"] = filaDb["fecha_factura"];
                        fila["id_servicios_estados"] = filaDb["id_servicios_estados"];
                        fila["id_localidad"] = filaDb["id_localidades"];
                        fila["id_bonificacion_especial"] = filaDb["id_bonificacion_esp"];
                        if (Convert.ToInt32(fila["id_servicio_modalidad"]) == Convert.ToInt32(Servicios._Modalidad.MENSUAL) || Convert.ToInt32(fila["id_servicio_modalidad"]) == Convert.ToInt32(Servicios._Modalidad.PERIODO))
                            fila["fecha_hasta_servicio"] = fechaInicioServicio.AddMonths(Convert.ToInt32(fila["meses_servicio"])).AddDays(-1);
                        else
                            fila["fecha_hasta_servicio"] = fechaInicioServicio;
                        dtEstructuraBonificaciones.Rows.Add(fila);
                    }
                }
            }
            return dtEstructuraBonificaciones;
        }

        public DataTable RetornarDeudasPosterioresDelServicio(DateTime fecha, int idUsuariosServicios)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();

                oCon.CrearComando(String.Format("select * from vw_usuarios_ctacte_det where id_usuarios_servicios={0} and month(fecha_desde)={1} and year(fecha_desde)={2} and (importe_saldo>0 or importe_original=0)", idUsuariosServicios, fecha.Month, fecha.Year));
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

        public DataTable GetEstructuraPresentacionDeudasAnexadas()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id_presentacion", typeof(string));
            dt.Columns.Add("id_plastico", typeof(string));
            dt.Columns.Add("id", typeof(string));
            dt.Columns.Add("id_usuarios_locaciones", typeof(string));
            dt.Columns.Add("id_usuarios_servicios", typeof(string));
            dt.Columns.Add("id_usuarios_servicios_sub", typeof(string));
            dt.Columns.Add("id_comprobante", typeof(string));
            dt.Columns.Add("id_usuarios_ctacte", typeof(string));
            dt.Columns.Add("id_usuarios_ctacte_det", typeof(string));
            dt.Columns.Add("tipo_deuda", typeof(string));
            dt.Columns.Add("servicio_sub", typeof(string));
            dt.Columns.Add("comprobantes_descripcion", typeof(string));
            dt.Columns.Add("fecha_desde", typeof(string));
            dt.Columns.Add("fecha_hasta", typeof(string));
            dt.Columns.Add("total", typeof(string));
            dt.Columns.Add("id_usuarios", typeof(string));
            dt.Columns.Add("id_usuarios_ctacte_recibo_asociado", typeof(string));
            dt.Columns.Add("recibos_descripcion", typeof(string));

            return dt;
        }

        public DataTable ListarPlasticosAsociadosAlUsuario(int idUsuario)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando(String.Format("SELECT plasticos.id, plasticos.numero, plasticos.titular, plasticos.vencimiento  " +
                    "FROM(select id, numero, titular, vencimiento from plasticos where activo = {1} and plasticos.borrado = 0)plasticos " +
                    "inner join(select distinct(plasticos_usuarios.id_plastico)from plasticos_usuarios " +
                    "inner join (select id, id_usuarios from usuarios_servicios where id_usuarios = {0}) " +
                    "usuarios_servicios on plasticos_usuarios.id_usuarios_servicios = usuarios_servicios.id AND plasticos_usuarios.borrado = 0) " +
                    "plasticos_usuarios on plasticos.id = plasticos_usuarios.id_plastico", idUsuario, Convert.ToInt16(Plasticos.ESTADO.ACTIVO)));
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

        public DataTable RetornarDeudasAdicionales(DateTime fecha, int idUsuariosServicios, int idDebito)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                if (idUsuariosServicios > 0)
                    oCon.CrearComando(String.Format("select * from vw_usuarios_ctacte_det where id_usuarios_servicios={0} and id_debito_asociado={1} and mes_presentacion={2} and ano_presentacion={3} and (importe_saldo>0 or importe_original=0)", idUsuariosServicios, idDebito, fecha.Month, fecha.Year));
                else
                    oCon.CrearComando(String.Format("select * from vw_usuarios_ctacte_det where id_debito_asociado={0} and mes_presentacion={1} and ano_presentacion={2} and (importe_saldo>0 or importe_original=0)", idDebito, fecha.Month, fecha.Year));
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

        public DataTable ListarAnexadas(int mes,int anio)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("select usuarios_ctacte.id, usuarios_ctacte.fecha_movimiento, usuarios_ctacte.descripcion, usuarios_ctacte.importe_final, usuarios.codigo, concat(usuarios.apellido,', ',usuarios.nombre) as usuario, " +
                    " plasticos.numero as debito_asociado, plasticos.titular,usuarios_ctacte_det.mes_presentacion,usuarios_ctacte_det.ano_presentacion " +
                    " from usuarios_ctacte " +
                    " left join usuarios_ctacte_det on usuarios_ctacte_det.id_usuarios_ctacte=usuarios_ctacte.id" +
                    " left join usuarios on usuarios.id=usuarios_ctacte.id_usuarios" +
                    " left join plasticos on plasticos.id=usuarios_ctacte_det.id_debito_asociado" +
                    "  where usuarios_ctacte_det.mes_presentacion=@mes and usuarios_ctacte_det.ano_presentacion=@anio group by usuarios_ctacte.id");
                oCon.AsignarParametroEntero("@mes", mes);
                oCon.AsignarParametroEntero("@anio", anio);
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


        public DataTable GenerarEstructuraDtDetallesRecibos()
        {
            DataTable dtDetalleRecibo = new DataTable();
            dtDetalleRecibo.Columns.Add("Nombre", typeof(String));
            dtDetalleRecibo.Columns.Add("Importe", typeof(Decimal));
            dtDetalleRecibo.Columns.Add("Cliente", typeof(string));
            dtDetalleRecibo.Columns.Add("Cuenta", typeof(string));
            dtDetalleRecibo.Columns.Add("Cuit", typeof(string));
            dtDetalleRecibo.Columns.Add("Banco", typeof(string));
            dtDetalleRecibo.Columns.Add("Sucursal", typeof(string));
            dtDetalleRecibo.Columns.Add("Fecha_Comprobante", typeof(string));
            dtDetalleRecibo.Columns.Add("Fecha_Acreditacion", typeof(string));
            dtDetalleRecibo.Columns.Add("Numero", typeof(string));
            dtDetalleRecibo.Columns.Add("Id_formas_de_pago", typeof(string));
            dtDetalleRecibo.Columns.Add("Id_usuarios_locaciones", typeof(Int32));
            return dtDetalleRecibo;
        }

        public DataTable GenerarEstructuraDtFacturasImprimir()
        {
            DataTable dtFacurasAimprimir = new DataTable();

            dtFacurasAimprimir.Columns.Add("Id_Locacion", typeof(Int32));
            dtFacurasAimprimir.Columns.Add("Id_Comprobantes", typeof(Int32));
            dtFacurasAimprimir.Columns.Add("Punto", typeof(Int32));
            dtFacurasAimprimir.Columns.Add("Numero", typeof(Int32));
            return dtFacurasAimprimir;
        }

        public DataTable GenerarEstructuraDtListadoComprobantes()
        {
            DataTable dtListadoComprobantes = new DataTable();

            dtListadoComprobantes.Columns.Add("Id_Comprobante", typeof(Int32));
            dtListadoComprobantes.Columns.Add("Id_Usuario", typeof(Int32));
            return dtListadoComprobantes;
        }

        public void ActualizarMontoPago(int idPresentacion, decimal montoTotal)
        {
            try
            {
                oCon.Conectar();
                oCon.ComenzarTransaccion();
                oCon.CrearComando("UPDATE presentacion_debitos SET monto_total_pago=@monto_total WHERE Id = @id");
                oCon.AsignarParametroDecimal("@monto_total", montoTotal);
                oCon.AsignarParametroEntero("@id", idPresentacion);
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

        public void ActualizarDatosDeRecibos(int idPresentacion, int cantidadRecibos, int idPrimerRecibo, int idUltimoRecibo)
        {
            try
            {
                oCon.Conectar();
                oCon.ComenzarTransaccion();
                oCon.CrearComando("UPDATE presentacion_debitos SET cantidad_recibos=@cantidad_recibos, id_primer_recibo=@id_primer_recibo, id_ultimo_recibo=@id_ultimo_recibo WHERE Id = @id");
                oCon.AsignarParametroEntero("@cantidad_recibos", cantidadRecibos);
                oCon.AsignarParametroEntero("@id_primer_recibo", idPrimerRecibo);
                oCon.AsignarParametroEntero("@id_ultimo_recibo", idUltimoRecibo);
                oCon.AsignarParametroEntero("@id", idPresentacion);
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

        public void ActualizarDatosDePlasticos(int idPresentacion, int cantidadTotalPlasticos, int cantidadPlasticosAceptados, int cantidadPlasticosRechazados)
        {
            try
            {
                oCon.Conectar();
                oCon.ComenzarTransaccion();
                oCon.CrearComando("UPDATE presentacion_debitos SET cantidad_total_plasticos=@cantidad_total_plasticos, cant_plasticos_aceptados=@cant_plasticos_aceptados, cant_plasticos_rechazados=@cant_plasticos_rechazados WHERE Id = @id");
                oCon.AsignarParametroEntero("@cantidad_total_plasticos", cantidadTotalPlasticos);
                oCon.AsignarParametroEntero("@cant_plasticos_aceptados", cantidadPlasticosAceptados);
                oCon.AsignarParametroEntero("@cant_plasticos_rechazados", cantidadPlasticosRechazados);
                oCon.AsignarParametroEntero("@id", idPresentacion);
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

        public decimal CalcularPercepcionDetalle(int idDetalle, int idUsuario, int idComprobante, decimal importe_saldo)
        {
            decimal monto = 0, impuestoProvincial = 0;
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando(String.Format("select id_comprobantes_tipo from comprobantes where id='{0}'", idComprobante.ToString()));
                dt = oCon.Tabla();
                if (dt.Rows.Count > 0)
                {
                    if (Convert.ToInt32(dt.Rows[0]["id_comprobantes_tipo"]) == Convert.ToInt16(Comprobantes_Tipo.Tipo.FACTURA_A))
                    {
                        dt.Clear();
                        oCon.CrearComando(String.Format("select impuesto_provincial from usuarios where id='{0}'", idUsuario.ToString()));
                        dt = oCon.Tabla();
                        if (dt.Rows.Count > 0)
                        {
                            impuestoProvincial = Convert.ToDecimal(dt.Rows[0]["impuesto_provincial"]);
                            decimal neto = importe_saldo / (decimal)1.21;
                            monto = (neto * impuestoProvincial) / 100;
                            oCon.ComenzarTransaccion();
                            oCon.CrearComando("UPDATE usuarios_ctacte_det SET importe_provincial=@importe_provincial WHERE Id = @id");
                            oCon.AsignarParametroDecimal("@importe_provincial", importe_saldo + monto);
                            oCon.AsignarParametroEntero("@id", idDetalle);
                            oCon.EjecutarComando();
                            oCon.ConfirmarTransaccion();
                        }
                    }
                }
                oCon.DesConectar();
            }
            catch (Exception)
            {
                monto = 0;
                oCon.DesConectar();
                throw;
            }
            return monto;
        }

        public decimal CalcularPercepcionEstimado(int idUsuario, decimal importe_saldo)
        {
            decimal monto = 0, impuestoProvincial = 0;
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando(String.Format("select id_comprobantes_iva,impuesto_provincial from usuarios where id='{0}'", idUsuario.ToString()));
                dt = oCon.Tabla();
                if (dt.Rows.Count > 0)
                {
                    if (Convert.ToInt32(dt.Rows[0]["id_comprobantes_iva"]) == Convert.ToInt16(Comprobantes_Iva.Tipo.RESPONSABLE_INSCRIPTO))
                    {
                        impuestoProvincial = Convert.ToDecimal(dt.Rows[0]["impuesto_provincial"]);
                        decimal neto = importe_saldo / (decimal)1.21;
                        monto = (neto * impuestoProvincial) / 100;
                        //if (idUsuario == 8225)
                        //    impuestoProvincial = 0;
                    }
                }
                oCon.DesConectar();
            }
            catch (Exception)
            {
                monto = 0;
                oCon.DesConectar();
                throw;
            }
            return monto;
        }

        public static int GetDecimalLength(string tempValue)
        {
            int decimalLength = 0;
            if (tempValue.Contains(","))
            {
                char[] separator = new char[] { ',' };
                string[] tempstring = tempValue.Split(separator);

                decimalLength = tempstring[1].Length;
            }
            return decimalLength;
        }

        public bool ListarDebitosAsociados(int idUsuario, out DataTable dtServicios)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT plasticos.id, plasticos_usuarios.id as id_plastico_usuario,if(servicios.requiere_velocidad = 0,servicios.descripcion, CONCAT(servicios.descripcion, ' ',servicios_velocidades.velocidad, ' ',servicios_velocidades_tip.nombre)) as servicio,plasticos_usuarios.fecha_baja,plasticos_usuarios.fecha_inicio,plasticos_usuarios.fecha_solicitud,plasticos_usuarios.activo," +
                 "plasticos.numero,plasticos.titular,usuarios_servicios.id_usuarios " +
                 "from plasticos_usuarios "
                + " LEFT JOIN plasticos on plasticos.id=plasticos_usuarios.id_plastico"
                + " LEFT JOIN usuarios_servicios on usuarios_servicios.id=plasticos_usuarios.id_usuarios_servicios"
                + " LEFT JOIN usuarios_servicios_sub on usuarios_servicios_sub.id_usuarios_servicios=usuarios_servicios.id"
                + " LEFT JOIN servicios on servicios.id=usuarios_servicios.id_servicios"
                + " LEFT JOIN servicios_velocidades on servicios_velocidades.id=usuarios_servicios_sub.id_servicios_velocidades"
                + " LEFT JOIN servicios_velocidades_tip on servicios_velocidades_tip.id=usuarios_servicios_sub.id_servicios_velocidades_tip"
                + " where plasticos_usuarios.borrado=0 AND plasticos_usuarios.id_usuario=@id and plasticos.borrado=0 and usuarios_servicios.borrado=0 and plasticos.activo=1 group by usuarios_servicios.id");
                oCon.AsignarParametroEntero("@id", idUsuario);
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }

            if (dt.Rows.Count > 0)
            {
                dtServicios = dt;
                return true;
            }
            else
            {
                dtServicios = null;
                return false;
            }
        }
    }
}
