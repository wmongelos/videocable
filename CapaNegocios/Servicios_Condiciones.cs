using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;

namespace CapaNegocios
{
    public class Servicios_Condiciones
    {

        private Conexion oCon = new Conexion();

        public int Id { get; set; }
        public int Id_Servicio { get; set; }
        public int Id_Tipo_Condicion { get; set; }
        public int Id_Condicion { get; set; }
        public int Cantidad { get; set; }
        public int Id_Tipo_Facturacion { get; set; }
        public int Borrado { get; set; }

        public enum TIPO_CONDICION
        {
            GRUPO = 0,
            TIPO = 1,
            SERVICIO = 2
        }

        public void Guardar(Servicios_Condiciones oServicios_Condiciones)
        {
            try
            {
                oCon.Conectar();

                oCon.CrearComando("INSERT INTO servicios_condiciones(Id_Servicio, Id_Tipo_Condicion, Id_Condicion,Id_Tipo_Facturacion, Cantidad, id_personal) " +
                    "VALUES (@Id_Servicio, @Id_Tipo_Condicion, @Id_Condicion, @Id_Tipo_Facturacion, @Cantidad,@personal);SELECT @@IDENTITY");

                oCon.AsignarParametroEntero("@Id_Servicio", oServicios_Condiciones.Id_Servicio);
                oCon.AsignarParametroEntero("@Id_Tipo_Condicion", oServicios_Condiciones.Id_Tipo_Condicion);
                oCon.AsignarParametroEntero("@Id_Condicion", oServicios_Condiciones.Id_Condicion);
                oCon.AsignarParametroEntero("@Id_Tipo_Facturacion", oServicios_Condiciones.Id_Tipo_Facturacion);
                oCon.AsignarParametroEntero("@Cantidad", oServicios_Condiciones.Cantidad);
                oCon.AsignarParametroEntero("@personal", Personal.Id_Login);

                oCon.ComenzarTransaccion();
                oServicios_Condiciones.Id = oCon.EjecutarScalar();
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

        public DataTable Listar(int Id_Servicio)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT servicios_condiciones.Id, servicios_condiciones.Id_Servicio, servicios_condiciones.Id_Condicion, servicios_condiciones.Id_Tipo_Condicion, servicios_condiciones.cantidad, 'Servicios' as tipo_item, CASE Id_Tipo_Condicion WHEN 0 THEN 'Grupo' WHEN 1 THEN 'Tipo' WHEN 2 THEN 'Servicio' END AS Tipo_Condicion, CASE Id_Tipo_Condicion WHEN 0 THEN(select servicios_grupos.Nombre from servicios_grupos where servicios_grupos.Id = servicios_condiciones.Id_Condicion) WHEN 1 THEN(select servicios_tipos.Nombre from servicios_tipos where servicios_tipos.Id = servicios_condiciones.Id_Condicion) WHEN 2 THEN(select servicios.Descripcion from servicios where servicios.Id = servicios_condiciones.Id_Condicion) END AS Nombre_Condicion, servicios_condiciones.id_tipo_facturacion, (CASE (SELECT `configuracion`.`Valor_N` FROM `configuracion` WHERE (`configuracion`.`Variable` = 'Id_Tipo_Facturacion')) WHEN 1 THEN (SELECT `zonas`.`Nombre` FROM `zonas` WHERE (`zonas`.`Id` = `servicios_condiciones`.`Id_Tipo_Facturacion`)) WHEN 2 THEN (SELECT `servicios_categorias`.`Nombre` FROM `servicios_categorias` WHERE (`servicios_categorias`.`Id` = `servicios_condiciones`.`Id_Tipo_Facturacion`)) END) AS 'tipofac' from servicios_condiciones where servicios_condiciones.Id_Servicio = @Id_Servicio and borrado = 0");
                oCon.AsignarParametroEntero("@Id_Servicio", Id_Servicio);
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

        public DataTable Listar(int Id_Servicio, int idTipoFac)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT servicios_condiciones.Id, servicios_condiciones.Id_Servicio, servicios_condiciones.Id_Condicion, servicios_condiciones.Id_Tipo_Condicion, servicios_condiciones.cantidad, 'Servicios' as tipo_item, CASE Id_Tipo_Condicion WHEN 0 THEN 'Grupo' WHEN 1 THEN 'Tipo' WHEN 2 THEN 'Servicio' END AS Tipo_Condicion, CASE Id_Tipo_Condicion WHEN 0 THEN(select servicios_grupos.Nombre from servicios_grupos where servicios_grupos.Id = servicios_condiciones.Id_Condicion) WHEN 1 THEN(select servicios_tipos.Nombre from servicios_tipos where servicios_tipos.Id = servicios_condiciones.Id_Condicion) WHEN 2 THEN(select servicios.Descripcion from servicios where servicios.Id = servicios_condiciones.Id_Condicion) END AS Nombre_Condicion, servicios_condiciones.id_tipo_facturacion, (CASE (SELECT `configuracion`.`Valor_N` FROM `configuracion` WHERE (`configuracion`.`Variable` = 'Id_Tipo_Facturacion')) WHEN 1 THEN (SELECT `zonas`.`Nombre` FROM `zonas` WHERE (`zonas`.`Id` = `servicios_condiciones`.`Id_Tipo_Facturacion`)) WHEN 2 THEN (SELECT `servicios_categorias`.`Nombre` FROM `servicios_categorias` WHERE (`servicios_categorias`.`Id` = `servicios_condiciones`.`Id_Tipo_Facturacion`)) END) AS 'tipofac' from servicios_condiciones where servicios_condiciones.Id_Servicio = @Id_Servicio  and (servicios_condiciones.id_tipo_facturacion=@idtipofac or servicios_condiciones.id_tipo_facturacion=0) and borrado = 0");
                oCon.AsignarParametroEntero("@Id_Servicio", Id_Servicio);
                oCon.AsignarParametroEntero("@idtipofac", idTipoFac);
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

        public void Eliminar(int id)
        {
            try
            {
                oCon.Conectar();
                oCon.ComenzarTransaccion();
                oCon.CrearComando("UPDATE servicios_condiciones SET Borrado = 1 WHERE Id = @id");
                oCon.AsignarParametroEntero("@id", id);
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

        public bool Verificar_Condiciones(int Id_Servicio, DataTable dtServAContratarYContratados, int idTipoFac)
        {
            int CantCondicionesCumplidas = 0;
            int idTotal = 0;
            bool seCumplieronCondiciones = true;
            DataTable dtCondServAContratar = new DataTable();
            Servicios_Condiciones oServiciosCondiciones = new Servicios_Condiciones();
            DataTable dtServiciosRecibidos = dtServAContratarYContratados;
            int idUsuariosServicios = 0;
            List<int> listaUsuariosServicios = new List<int>();

            //DataColumn colUsuariosServicios = new DataColumn
            //{
            //    ColumnName = "id_usuarios_servicios",
            //    DataType = typeof(Int32),
            //    DefaultValue = 0
            //};
            //dtServiciosRecibidos.Columns.Add(colUsuariosServicios);

            foreach (DataRow fila in dtServiciosRecibidos.Rows)
            {
                fila["id_servicios_categoria"] = idTipoFac;

                if (Convert.ToInt32(fila["id_usuarios_servicios"]) > idUsuariosServicios)
                    idUsuariosServicios = Convert.ToInt32(fila["id_usuarios_servicios"]);
            }

            if (dtServiciosRecibidos.Rows.Count > 0)
            {
                foreach (DataRow fila in dtServiciosRecibidos.Rows)
                {
                    if (fila["id_tipo"] != DBNull.Value && Convert.ToInt32(fila["id_tipo"]) == 0)
                    {
                        idUsuariosServicios++;
                        fila["id_usuarios_servicios"] = idUsuariosServicios;
                    }
                    else
                        fila["id_usuarios_servicios"] = idUsuariosServicios;
                }
            }

            dtCondServAContratar = oServiciosCondiciones.Listar(Id_Servicio, idTipoFac);
            if (dtCondServAContratar.Rows.Count > 0 && dtServiciosRecibidos != null && dtServiciosRecibidos.Rows.Count > 0)
            {
                foreach (DataRow Condicion in dtCondServAContratar.Rows)
                {
                    idTotal = 0;
                    listaUsuariosServicios.Clear();
                    int IdTipoCondicion = Convert.ToInt32(Condicion["Id_Tipo_Condicion"]);
                    if (IdTipoCondicion == Convert.ToInt32(Servicios_Condiciones.TIPO_CONDICION.GRUPO))
                    {
                        foreach (DataRow fila in dtServiciosRecibidos.Rows)
                        {
                            if (Convert.ToInt32(fila["id_servicios_grupos"]) == Convert.ToInt32(Condicion["Id_Condicion"]) && fila["id_servicios_tipo_sub"] != DBNull.Value && Convert.ToInt32(fila["id_servicios_tipo_sub"]) == Convert.ToInt32(Servicios_Sub.SERVICIO_SUB_TIPOS.SUBSERVICIO) && listaUsuariosServicios.Contains(Convert.ToInt32(fila["id_usuarios_servicios"])) == false)
                            {
                                if (Convert.ToInt32(Condicion["id_tipo_facturacion"]) == 0 || (Convert.ToInt32(Condicion["id_tipo_facturacion"]) != 0 && fila["id_servicios_categoria"] != DBNull.Value && Convert.ToInt32(fila["id_servicios_categoria"]) != 0 && Convert.ToInt32(Condicion["id_tipo_facturacion"]) == Convert.ToInt32(fila["id_servicios_categoria"])))
                                {
                                    idTotal += Convert.ToInt32(fila["CantidadPac"]);
                                    listaUsuariosServicios.Add(Convert.ToInt32(fila["id_usuarios_servicios"]));
                                }
                            }
                        }

                        if (idTotal >= Convert.ToInt32(Condicion["cantidad"]))
                            CantCondicionesCumplidas++;
                    }
                    else if (IdTipoCondicion == Convert.ToInt32(Servicios_Condiciones.TIPO_CONDICION.TIPO))
                    {
                        foreach (DataRow fila in dtServiciosRecibidos.Rows)
                        {
                            if (Convert.ToInt32(fila["id_servicios_tipos"]) == Convert.ToInt32(Condicion["Id_Condicion"]) && fila["id_servicios_tipo_sub"] != DBNull.Value && Convert.ToInt32(fila["id_servicios_tipo_sub"]) == Convert.ToInt32(Servicios_Sub.SERVICIO_SUB_TIPOS.SUBSERVICIO) && listaUsuariosServicios.Contains(Convert.ToInt32(fila["id_usuarios_servicios"])) == false)
                            {
                                if (Convert.ToInt32(Condicion["id_tipo_facturacion"]) == 0 || (Convert.ToInt32(Condicion["id_tipo_facturacion"]) != 0 && fila["id_servicios_categoria"] != DBNull.Value && Convert.ToInt32(fila["id_servicios_categoria"]) != 0 && Convert.ToInt32(Condicion["id_tipo_facturacion"]) == Convert.ToInt32(fila["id_servicios_categoria"])))
                                {
                                    idTotal += Convert.ToInt32(fila["CantidadPac"]);
                                    listaUsuariosServicios.Add(Convert.ToInt32(fila["id_usuarios_servicios"]));
                                }
                            }
                        }

                        if (idTotal >= Convert.ToInt32(Condicion["cantidad"]))
                            CantCondicionesCumplidas++;
                    }
                    else if (IdTipoCondicion == Convert.ToInt32(Servicios_Condiciones.TIPO_CONDICION.SERVICIO))
                    {
                        foreach (DataRow fila in dtServiciosRecibidos.Rows)
                        {
                            if (Convert.ToInt32(fila["id_servicios"]) == Convert.ToInt32(Condicion["Id_Condicion"]) && fila["id_servicios_tipo_sub"] != DBNull.Value && Convert.ToInt32(fila["id_servicios_tipo_sub"]) == Convert.ToInt32(Servicios_Sub.SERVICIO_SUB_TIPOS.SUBSERVICIO) && listaUsuariosServicios.Contains(Convert.ToInt32(fila["id_usuarios_servicios"])) == false)
                            {
                                if (Convert.ToInt32(Condicion["id_tipo_facturacion"]) == 0 || (Convert.ToInt32(Condicion["id_tipo_facturacion"]) != 0 && fila["id_servicios_categoria"] != DBNull.Value && Convert.ToInt32(fila["id_servicios_categoria"]) != 0 && Convert.ToInt32(Condicion["id_tipo_facturacion"]) == Convert.ToInt32(fila["id_servicios_categoria"])))
                                {
                                    idTotal += Convert.ToInt32(fila["CantidadPac"]);
                                    listaUsuariosServicios.Add(Convert.ToInt32(fila["id_usuarios_servicios"]));
                                }
                            }
                        }

                        if (idTotal >= Convert.ToInt32(Condicion["cantidad"]))
                            CantCondicionesCumplidas++;
                    }
                }

                if (CantCondicionesCumplidas >= dtCondServAContratar.Rows.Count)
                    seCumplieronCondiciones = true;
                else
                    seCumplieronCondiciones = false;
            }
            else if (dtCondServAContratar.Rows.Count == 0)
                seCumplieronCondiciones = true;
            else
                seCumplieronCondiciones = false;


            return seCumplieronCondiciones;
        }

    }
}