using CapaDatos;
using System;
using System.Data;

namespace CapaNegocios
{
    public class Informes_Servicios
    {
        private Conexion oCon = new Conexion();
        public DataTable ListarDatosInforme(int idEstadoServicio, int idTipoFacturacion, int idFacturacionMensual)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                if (idFacturacionMensual == 0)
                {
                    if (idEstadoServicio > 0 && idTipoFacturacion > 0)
                    {
                        oCon.CrearComando(String.Format("select servicios.id, servicios_tipos.id as id_servicios_tipos, servicios_grupos.id as id_servicios_grupos, servicios_grupos.nombre as grupo, servicios_tipos.nombre as tipo, servicios.servicio,  IF(IFNULL(usuariosservicios.cantidad,1)=1,0,usuariosservicios.cantidad) as cantidad_servicios, IF(IFNULL(datosusuarios.cantidad_usuarios,1)=1,0,datosusuarios.cantidad_usuarios) as cantidad_usuarios" +
                                         " from(select id, descripcion as servicio, id_servicios_tipos from servicios where borrado = 0)servicios" +
                                         " left join(select id_servicios, count(id) as cantidad from usuarios_servicios where id_servicios_estados = {0} and id_tipo_facturacion = {1} and borrado=0 group by id_servicios)usuariosservicios" +
                                         " on servicios.id = usuariosservicios.id_servicios" +
                                         " left join(select id_servicios, count(id_usuarios) as cantidad_usuarios from(select id_servicios, id_usuarios from usuarios_servicios where id_servicios_estados={0} and id_tipo_facturacion={1} and borrado=0 group by id_servicios, id_usuarios)datosusuarios group by id_servicios)datosusuarios on servicios.id = datosusuarios.id_servicios left join servicios_tipos on servicios.id_servicios_tipos = servicios_tipos.id" +
                                         " left join servicios_grupos on servicios_grupos.id = servicios_tipos.id_servicios_grupos", idEstadoServicio, idTipoFacturacion));
                    }
                    else if (idEstadoServicio > 0 && idTipoFacturacion == 0)
                    {
                        oCon.CrearComando(String.Format("select servicios.id, servicios_tipos.id as id_servicios_tipos, servicios_grupos.id as id_servicios_grupos, servicios_grupos.nombre as grupo, servicios_tipos.nombre as tipo, servicios.servicio,  IF(IFNULL(usuariosservicios.cantidad,1)=1,0,usuariosservicios.cantidad) as cantidad_servicios, IF(IFNULL(datosusuarios.cantidad_usuarios,1)=1,0,datosusuarios.cantidad_usuarios) as cantidad_usuarios" +
                                         " from(select id, descripcion as servicio, id_servicios_tipos from servicios where borrado = 0)servicios" +
                                         " left join(select id_servicios, count(id) as cantidad from usuarios_servicios where id_servicios_estados = {0} and borrado=0 group by id_servicios)usuariosservicios" +
                                         " on servicios.id = usuariosservicios.id_servicios" +
                                         " left join(select id_servicios, count(id_usuarios) as cantidad_usuarios from(select id_servicios, id_usuarios from usuarios_servicios where id_servicios_estados={0} and  borrado=0 group by id_servicios, id_usuarios)datosusuarios group by id_servicios)datosusuarios on servicios.id = datosusuarios.id_servicios left join servicios_tipos on servicios.id_servicios_tipos = servicios_tipos.id" +
                                         " left join servicios_grupos on servicios_grupos.id = servicios_tipos.id_servicios_grupos", idEstadoServicio));
                    }
                    else if (idEstadoServicio == 0 && idTipoFacturacion > 0)
                    {
                        oCon.CrearComando(String.Format("select servicios.id, servicios_tipos.id as id_servicios_tipos, servicios_grupos.id as id_servicios_grupos, servicios_grupos.nombre as grupo, servicios_tipos.nombre as tipo, servicios.servicio,  IF(IFNULL(usuariosservicios.cantidad,1)=1,0,usuariosservicios.cantidad) as cantidad_servicios, IF(IFNULL(datosusuarios.cantidad_usuarios,1)=1,0,datosusuarios.cantidad_usuarios) as cantidad_usuarios" +
                                         " from(select id, descripcion as servicio, id_servicios_tipos from servicios where borrado = 0)servicios" +
                                         " left join(select id_servicios, count(id) as cantidad from usuarios_servicios where id_tipo_facturacion = {0} and borrado=0 group by id_servicios)usuariosservicios" +
                                         " on servicios.id = usuariosservicios.id_servicios" +
                                         " left join(select id_servicios, count(id_usuarios) as cantidad_usuarios from(select id_servicios, id_usuarios from usuarios_servicios where id_tipo_facturacion={0} and borrado=0 group by id_servicios, id_usuarios)datosusuarios group by id_servicios)datosusuarios on servicios.id = datosusuarios.id_servicios left join servicios_tipos on servicios.id_servicios_tipos = servicios_tipos.id" +
                                         " left join servicios_grupos on servicios_grupos.id = servicios_tipos.id_servicios_grupos", idTipoFacturacion));
                    }
                    else if (idEstadoServicio == 0 && idTipoFacturacion == 0)
                    {
                        oCon.CrearComando(String.Format("select servicios.id, servicios_tipos.id as id_servicios_tipos, servicios_grupos.id as id_servicios_grupos, servicios_grupos.nombre as grupo, servicios_tipos.nombre as tipo, servicios.servicio,  IF(IFNULL(usuariosservicios.cantidad,1)=1,0,usuariosservicios.cantidad) as cantidad_servicios, IF(IFNULL(datosusuarios.cantidad_usuarios,1)=1,0,datosusuarios.cantidad_usuarios) as cantidad_usuarios" +
                                         " from(select id, descripcion as servicio, id_servicios_tipos from servicios where borrado = 0)servicios" +
                                         " left join(select id_servicios, count(id) as cantidad from usuarios_servicios where borrado=0 group by id_servicios)usuariosservicios" +
                                         " on servicios.id = usuariosservicios.id_servicios" +
                                         " left join(select id_servicios, count(id_usuarios) as cantidad_usuarios from(select id_servicios, id_usuarios from usuarios_servicios where  borrado=0 group by id_servicios, id_usuarios)datosusuarios group by id_servicios)datosusuarios on servicios.id = datosusuarios.id_servicios left join servicios_tipos on servicios.id_servicios_tipos = servicios_tipos.id" +
                                         " left join servicios_grupos on servicios_grupos.id = servicios_tipos.id_servicios_grupos"));
                    }
                }
                else
                {
                    string query = String.Empty;
                    if (idEstadoServicio > 0 && idTipoFacturacion > 0)
                    {
                        query = String.Format("select servicios.id, servicios_tipos.id as id_servicios_tipos, servicios_grupos.id as id_servicios_grupos, servicios_grupos.nombre as grupo, servicios_tipos.nombre as tipo, servicios.servicio,  IF(IFNULL(usuariosservicios.cantidad,1)=1,0,usuariosservicios.cantidad) as cantidad_servicios, IF(IFNULL(datosusuarios.cantidad_usuarios,1)=1,0,datosusuarios.cantidad_usuarios) as cantidad_usuarios, IF(IFNULL(montos.importe,1)=1,0,montos.importe) as facturado" +
                                         " from(select id, descripcion as servicio, id_servicios_tipos from servicios where borrado = 0)servicios" +
                                         " left join(select id_servicios, count(id) as cantidad from usuarios_servicios where id_servicios_estados = {0} and id_tipo_facturacion = {1} and borrado=0 group by id_servicios)usuariosservicios" +
                                         " on servicios.id = usuariosservicios.id_servicios" +
                                         " left join(select id_servicios, count(id_usuarios) as cantidad_usuarios from(select id_servicios, id_usuarios from usuarios_servicios where id_servicios_estados={0} and id_tipo_facturacion={1} and borrado=0 group by id_servicios, id_usuarios)datosusuarios group by id_servicios)datosusuarios on servicios.id = datosusuarios.id_servicios left join servicios_tipos on servicios.id_servicios_tipos = servicios_tipos.id" +
                                         " left join servicios_grupos on servicios_grupos.id = servicios_tipos.id_servicios_grupos", idEstadoServicio, idTipoFacturacion);
                    }
                    else if (idEstadoServicio > 0 && idTipoFacturacion == 0)
                    {
                        query = String.Format("select servicios.id, servicios_tipos.id as id_servicios_tipos, servicios_grupos.id as id_servicios_grupos, servicios_grupos.nombre as grupo, servicios_tipos.nombre as tipo, servicios.servicio,  IF(IFNULL(usuariosservicios.cantidad,1)=1,0,usuariosservicios.cantidad) as cantidad_servicios, IF(IFNULL(datosusuarios.cantidad_usuarios,1)=1,0,datosusuarios.cantidad_usuarios) as cantidad_usuarios,IF(IFNULL(montos.importe,1)=1,0,montos.importe) as facturado" +
                                         " from(select id, descripcion as servicio, id_servicios_tipos from servicios where borrado = 0)servicios" +
                                         " left join(select id_servicios, count(id) as cantidad from usuarios_servicios where id_servicios_estados = {0} and borrado=0 group by id_servicios)usuariosservicios" +
                                         " on servicios.id = usuariosservicios.id_servicios" +
                                         " left join(select id_servicios, count(id_usuarios) as cantidad_usuarios from(select id_servicios, id_usuarios from usuarios_servicios where id_servicios_estados={0} and  borrado=0 group by id_servicios, id_usuarios)datosusuarios group by id_servicios)datosusuarios on servicios.id = datosusuarios.id_servicios left join servicios_tipos on servicios.id_servicios_tipos = servicios_tipos.id" +
                                         " left join servicios_grupos on servicios_grupos.id = servicios_tipos.id_servicios_grupos", idEstadoServicio);
                    }
                    else if (idEstadoServicio == 0 && idTipoFacturacion > 0)
                    {
                        query = String.Format("select servicios.id, servicios_tipos.id as id_servicios_tipos, servicios_grupos.id as id_servicios_grupos, servicios_grupos.nombre as grupo, servicios_tipos.nombre as tipo, servicios.servicio,  IF(IFNULL(usuariosservicios.cantidad,1)=1,0,usuariosservicios.cantidad) as cantidad_servicios, IF(IFNULL(datosusuarios.cantidad_usuarios,1)=1,0,datosusuarios.cantidad_usuarios) as cantidad_usuarios,IF(IFNULL(montos.importe,1)=1,0,montos.importe) as facturado" +
                                         " from(select id, descripcion as servicio, id_servicios_tipos from servicios where borrado = 0)servicios" +
                                         " left join(select id_servicios, count(id) as cantidad from usuarios_servicios where id_tipo_facturacion = {0} and borrado=0 group by id_servicios)usuariosservicios" +
                                         " on servicios.id = usuariosservicios.id_servicios" +
                                         " left join(select id_servicios, count(id_usuarios) as cantidad_usuarios from(select id_servicios, id_usuarios from usuarios_servicios where id_tipo_facturacion={0} and borrado=0 group by id_servicios, id_usuarios)datosusuarios group by id_servicios)datosusuarios on servicios.id = datosusuarios.id_servicios left join servicios_tipos on servicios.id_servicios_tipos = servicios_tipos.id" +
                                         " left join servicios_grupos on servicios_grupos.id = servicios_tipos.id_servicios_grupos", idTipoFacturacion);
                    }
                    else if (idEstadoServicio == 0 && idTipoFacturacion == 0)
                    {
                        query = String.Format("select servicios.id, servicios_tipos.id as id_servicios_tipos, servicios_grupos.id as id_servicios_grupos, servicios_grupos.nombre as grupo, servicios_tipos.nombre as tipo, servicios.servicio,  IF(IFNULL(usuariosservicios.cantidad,1)=1,0,usuariosservicios.cantidad) as cantidad_servicios, IF(IFNULL(datosusuarios.cantidad_usuarios,1)=1,0,datosusuarios.cantidad_usuarios) as cantidad_usuarios,IF(IFNULL(montos.importe,1)=1,0,montos.importe) as facturado" +
                                         " from(select id, descripcion as servicio, id_servicios_tipos from servicios where borrado = 0)servicios" +
                                         " left join(select id_servicios, count(id) as cantidad from usuarios_servicios where borrado=0 group by id_servicios)usuariosservicios" +
                                         " on servicios.id = usuariosservicios.id_servicios" +
                                         " left join(select id_servicios, count(id_usuarios) as cantidad_usuarios from(select id_servicios, id_usuarios from usuarios_servicios where  borrado=0 group by id_servicios, id_usuarios)datosusuarios group by id_servicios)datosusuarios on servicios.id = datosusuarios.id_servicios left join servicios_tipos on servicios.id_servicios_tipos = servicios_tipos.id" +
                                         " left join servicios_grupos on servicios_grupos.id = servicios_tipos.id_servicios_grupos");
                    }

                    query = String.Format("{0} left join (select id_servicios, id_servicios_estados, id_tipo_facturacion, sum(importe) as importe from" +
                                        " (select usuarios_ctacte_det.id_servicios, usuarios_ctacte_det.id_servicios_estados, usuarios_ctacte_det.id_tipo_facturacion, (usuarios_ctacte_det.importe_original - usuarios_ctacte_det.importe_bonificacion) as importe from" +
                                        " (select id from usuarios_ctacte where id_facturacion ={1} and borrado = 0)usuariosctacte inner join(select usuarios_ctacte_det.*, usuarios_servicios.id_servicios_estados, usuarios_servicios.id_tipo_facturacion from" +
                                        " (select * from usuarios_ctacte_det where borrado = 0)usuarios_ctacte_det left join usuarios_servicios on usuarios_ctacte_det.id_usuarios_servicios = usuarios_servicios.id)usuarios_ctacte_det on usuariosctacte.id = usuarios_ctacte_det.id_usuarios_ctacte)montosservicios group by id_servicios)montos on servicios.id = montos.id_servicios", query, idFacturacionMensual);

                    oCon.CrearComando(query);
                }

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
        public DataTable Listar_Datos_Informe_Servicios(int idEstadoServicio, int idTipoFacturacion, int id_Facturacion_Empresa, DateTime fecha_factura, int condicion = 0)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                string Consulta = string.Empty;
                string Condicion = string.Empty;
                Consulta = "select usuarios.codigo as Codigo, usuarios.nombre,usuarios.apellido, comprobantes_iva.descripcion as condicion_iva,usuarios_tipos.tipo, usuarios.Numero_documento,usuarios.cuit, usuarios.correo_electronico, " +
                    "localidades.nombre as localidad, usuarios_locaciones.calle, usuarios_locaciones.altura,usuarios_locaciones.piso,usuarios_locaciones.depto,usuarios_locaciones.codigo_postal,usuarios_locaciones.prefijo_1,usuarios_locaciones.telefono_1, usuarios_locaciones.prefijo_2,usuarios_locaciones.telefono_2, " +
                    "ifnull(servicios_categorias.nombre, ' -') as categoria,servicios_grupos.nombre as grupo_servicio,servicios_tipos.nombre as tipo_servicio, servicios.descripcion as servicio,servicios_estados.estado, " +
                    "usuarios_servicios.fecha_factura as contratado_hasta,usuarios_servicios.meses_servicio,usuarios_servicios.meses_cobro, usuarios_servicios.cant_bocas,usuarios_servicios.cant_bocas_pac, " +
                    "usuarios_locaciones.saldo as saldo_locacion " +
                    "from usuarios_servicios " +
                    "left join usuarios on usuarios.id = usuarios_servicios.id_usuarios " +
                    "left join servicios on servicios.id = usuarios_servicios.id_servicios " +
                    "left join usuarios_locaciones on usuarios_locaciones.id = usuarios_servicios.id_usuarios_locaciones " +
                    "left join servicios_estados on servicios_estados.id = usuarios_servicios.id_servicios_Estados " +
                    "left join servicios_categorias on servicios_categorias.id = usuarios_servicios.id_tipo_facturacion " +
                    "left join comprobantes_iva on comprobantes_iva.id = usuarios.id_comprobantes_iva " +
                    "left join usuarios_Tipos on usuarios_tipos.id = usuarios.id_usuarios_tipos " +
                    "left join localidades on localidades.id = usuarios_locaciones.id_localidades " +
                    "LEFT JOIN zonas_localidades ON zonas_localidades.Id_Localidad = localidades.id " +
                    "LEFT JOIN zonas ON zonas_localidades.Id_Zona = zonas.id " +
                    "LEFT JOIN servicios_tipos ON servicios_tipos.id = servicios.id_servicios_tipos " +
                    "LEFT JOIN servicios_grupos ON servicios_grupos.id = servicios_tipos.id_servicios_grupos " +
                    "where usuarios.borrado = 0 and usuarios_servicios.borrado = 0";
              
                if (id_Facturacion_Empresa == (int)Configuracion.FACTURACION_EMPRESAS.ZONAS) 
                {
                    if (idEstadoServicio > 0 && idTipoFacturacion == 0)
                        Condicion = " and servicios_Estados.id =  " + idEstadoServicio;
                    else if (idEstadoServicio == 0 && idTipoFacturacion > 0)
                        Condicion = " and zonas.id = " + idTipoFacturacion;
                    else if(idTipoFacturacion ==0 && idEstadoServicio == 0 )
                        Condicion = string.Format(" and servicios_Estados.id > 0 and zonas.id > 0");
                    else
                        Condicion = string.Format(" and servicios_Estados.id = {0} and zonas.id = {1}", idEstadoServicio, idTipoFacturacion);
                }
                else
                {
                    if (idEstadoServicio > 0 && idTipoFacturacion == 0)
                        Condicion = " and servicios_Estados.id =  " + idEstadoServicio;
                    else if (idEstadoServicio == 0 && idTipoFacturacion > 0)
                        Condicion = " and servicios_categorias.id = " + idTipoFacturacion;
                    else
                        Condicion = string.Format(" and servicios_Estados.id ={0}  and servicios_categorias.id ={1} ", idEstadoServicio, idTipoFacturacion);
                }

                
                if (condicion == 1)
                    Condicion = Condicion + " and date(usuarios_servicios.fecha_factura) <= @fecha";

                string consultaFinal = Consulta + condicion;
                oCon.CrearComando(Consulta + Condicion);
                if (condicion == 1)
                    oCon.AsignarParametroFecha("@fecha", fecha_factura);


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
