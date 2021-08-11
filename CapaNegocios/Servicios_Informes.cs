using CapaDatos;
using System;
using System.Data;

namespace CapaNegocios
{
    public class Servicios_Informes
    {
        private Conexion oCon = new Conexion();
        DataTable dt_resultado = new DataTable();

        public DataTable ListarCantidadServicios(int id_estado, int seleccion, int item_seleccionado)
        {

            dt_resultado.Clear();

            try
            {
                oCon.Conectar();

                switch (seleccion)
                {
                    case 0:
                        oCon.CrearComando("select servicios_grupos.id, nombre, (select count(id) from vw_usuarios_servicios where id_grupo=servicios_grupos.id and id_estado=@id_estado) as cant_servicios from servicios_grupos");
                        oCon.AsignarParametroEntero("@id_estado", id_estado);
                        break;
                    case 1:
                        oCon.CrearComando("select servicios_tipos.id, nombre, (select count(id) from vw_usuarios_servicios where id_servicio_tipo=servicios_tipos.id and id_estado=@id_estado) as cant_servicios from servicios_tipos where id_servicios_grupos=@item and borrado=0");
                        oCon.AsignarParametroEntero("@id_estado", id_estado);
                        oCon.AsignarParametroEntero("@item", item_seleccionado);
                        break;
                    case 2:
                        oCon.CrearComando("select servicios.id, descripcion as nombre, (select count(id) from vw_usuarios_servicios where id_servicio=servicios.id and id_estado=@id_estado) as cant_servicios from servicios where id_servicios_tipos=@item and borrado=0");
                        oCon.AsignarParametroEntero("@id_estado", id_estado);
                        oCon.AsignarParametroEntero("@item", item_seleccionado);
                        break;
                    case 3:
                        oCon.CrearComando("select id, descripcion as nombre, (select nombre from servicios_sub_tipos where id = id_servicios_sub_tipos) as tipo_subservicio, (select count(id_usuarios_servicios_sub) from vw_subservicios where id_servicios_sub = servicios_sub.id) as cant_servicios from servicios_sub where id_servicios =@item");
                        oCon.AsignarParametroEntero("@item", item_seleccionado);
                        break;
                }





                dt_resultado = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }



            return dt_resultado;
        }

        public DataTable VerDetalles(int id_estado, int seleccion, int item_seleccionado)
        {
            dt_resultado.Clear();

            try
            {
                oCon.Conectar();

                switch (seleccion)
                {
                    case 0:
                        oCon.CrearComando("select id, servicio as Servicio, servicio_tipo as Tipo_de_servicio, grupo as Grupo, estado as Estado, concat(apellido,' ',nombre) as Usuario, calle as Calle, altura as Altura, localidad as Localidad from vw_usuarios_servicios where id_estado=@id_estado and id_grupo=@item");

                        break;
                    case 1:
                        oCon.CrearComando("select id, servicio as Servicio, servicio_tipo as Tipo_de_servicio, grupo as Grupo, estado as Estado, concat(apellido,' ',nombre) as Usuario, calle as Calle, altura as Altura, localidad as Localidad from vw_usuarios_servicios where id_estado=@id_estado and id_servicio_tipo=@item");

                        break;
                    case 2:
                        oCon.CrearComando("select id, servicio as Servicio, servicio_tipo as Tipo_de_servicio, grupo as Grupo, estado as Estado, concat(apellido,' ',nombre) as Usuario, calle as Calle, altura as Altura, localidad as Localidad from vw_usuarios_servicios where id_estado=@id_estado and id_servicio=@item");

                        break;
                    case 3:
                        oCon.CrearComando("select id_usuarios_servicios_sub as id, subservicio as Subservicio, tipo_subservicio ,servicio as Servicio, tipo_servicio, estado as Estado, concat(apellido,' ',nombre) as Usuario, calle as Calle, altura as Altura, localidad as Localidad from vw_subservicios where id_estado=@id_estado and id_servicios_sub=@item");

                        break;
                }


                oCon.AsignarParametroEntero("@id_estado", id_estado);
                oCon.AsignarParametroEntero("@item", item_seleccionado);


                dt_resultado = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }



            return dt_resultado;
        }

    }
}
