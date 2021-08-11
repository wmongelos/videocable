using CapaDatos;
using System;
using System.Data;
using System.Windows.Forms;

namespace CapaNegocios
{
    public class Agenda_Encabezado
    {
        public enum Uso_agenda
        {
            TRABAJA_CON_AGENDA = 2,
            NO_TRABAJA_CON_AGENDA = 1
        }

        private Conexion oCon = new Conexion();

        public Personal tecnico = new Personal();

        public bool Insertar_Encabezado(DataRow dr_tecnicos, DateTime fecha)
        {
            bool resultado = false;

            oCon.CrearComando("insert into agenda_encabezado(id_tecnico,fecha_jornada,hora_inicio_1,hora_fin_1,hora_inicio_2,hora_fin_2,rango) values(@id_tecnico,@fecha,@hora_inicio_1,@hora_fin_1,@hora_inicio_2,@hora_fin_2,@rango)");

            oCon.AsignarParametroCadena("@id_tecnico", dr_tecnicos["Id"].ToString());
            oCon.AsignarParametroFecha("@fecha", fecha);

            if (String.IsNullOrEmpty(dr_tecnicos["hora_inicio_1"].ToString()))
                oCon.AsignarParametroNulo("@hora_inicio_1");
            else
                oCon.AsignarParametroCadena("@hora_inicio_1", dr_tecnicos["hora_inicio_1"].ToString());

            if (String.IsNullOrEmpty(dr_tecnicos["hora_fin_1"].ToString()))
                oCon.AsignarParametroNulo("@hora_fin_1");
            else
                oCon.AsignarParametroCadena("@hora_fin_1", dr_tecnicos["hora_fin_1"].ToString());

            if (String.IsNullOrEmpty(dr_tecnicos["hora_inicio_2"].ToString()))
                oCon.AsignarParametroNulo("@hora_inicio_2");
            else
                oCon.AsignarParametroCadena("@hora_inicio_2", dr_tecnicos["hora_inicio_2"].ToString());

            if (String.IsNullOrEmpty(dr_tecnicos["hora_fin_2"].ToString()))
                oCon.AsignarParametroNulo("@hora_fin_2");
            else
                oCon.AsignarParametroCadena("@hora_fin_2", dr_tecnicos["hora_fin_2"].ToString());

            if (String.IsNullOrEmpty(dr_tecnicos["rango"].ToString()))
                oCon.AsignarParametroNulo("@rango");
            else
                oCon.AsignarParametroCadena("@rango", dr_tecnicos["rango"].ToString());


            try
            {
                oCon.Conectar();
                oCon.ComenzarTransaccion();
                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
                resultado = true;
            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                resultado = false;
                throw;

            }
            return resultado;
        }

        public bool Asignar_Parte(int id_tecnico, int id_parte, int estado, DateTime fecha_movil)
        {
            bool resultado = false;

            oCon.CrearComando("Update partes set Id_Tecnicos=@id_tecnico,Id_Partes_Estados=@estado, Fecha_Movil=@fecha_movil where partes.Id=@id");

            oCon.AsignarParametroEntero("@id_tecnico", id_tecnico);
            oCon.AsignarParametroEntero("@id", id_parte);
            oCon.AsignarParametroEntero("@estado", estado);
            oCon.AsignarParametroFecha("@fecha_movil", fecha_movil);

            try
            {
                oCon.Conectar();
                oCon.ComenzarTransaccion();
                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
                resultado = true;
            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                resultado = false;
                throw;

            }
            return resultado;
        }

        public bool Insertar_detalle_agenda(string id_agenda_tecnico, string id_parte, string hora, string detalles, int reservado)
        {
            bool resultado = false;

            oCon.CrearComando("insert into agenda_detalle(id_agenda_tecnico,hora,id_parte,estado,detalles,reservado,id_personal) values(@id_agenda_tecnico,@hora,@id_parte,0,@detalles,@reservado,@id_personal)");

            oCon.AsignarParametroCadena("@id_agenda_tecnico", id_agenda_tecnico);
            oCon.AsignarParametroCadena("@hora", hora);
            oCon.AsignarParametroCadena("@id_parte", id_parte);
            oCon.AsignarParametroCadena("@detalles", detalles);
            oCon.AsignarParametroEntero("@reservado", reservado);
            oCon.AsignarParametroEntero("@id_personal", Personal.Id_Login);

            try
            {
                oCon.Conectar();
                oCon.ComenzarTransaccion();
                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();


                oCon.DesConectar();
                resultado = true;
            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                resultado = false;
                throw;

            }

            return resultado;
        }

        public void BorrarReserva(int idDetalleAgenda)
        {

            oCon.CrearComando("delete from agenda_detalle where Id=@id");
            oCon.AsignarParametroEntero("@id", idDetalleAgenda);

            try
            {
                oCon.Conectar();
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

        public bool SetearDetallesAsignacion(int id_detalle, string detalles)
        {
            bool resultado = false;

            oCon.CrearComando("Update agenda_detalle set Detalles=@detalles where id=@id_detalle");

            oCon.AsignarParametroEntero("@id_detalle", id_detalle);
            oCon.AsignarParametroCadena("@detalles", detalles);

            try
            {
                oCon.Conectar();
                oCon.ComenzarTransaccion();
                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();


                oCon.DesConectar();
                resultado = true;
            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                resultado = false;
                throw;

            }

            return resultado;
        }

        public bool Eliminar_parte_asignado(string id_encabezado, string id_parte, string hora)
        {
            bool resultado = false;

            if (hora != "")
            {
                oCon.CrearComando("Update agenda_detalle set estado=1 where id_agenda_tecnico=@id_encabezado and id_parte=@id_parte and hora=@hora and estado=0");
                oCon.AsignarParametroCadena("@id_encabezado", id_encabezado);
                oCon.AsignarParametroCadena("@id_parte", id_parte);
                oCon.AsignarParametroCadena("@hora", hora + ":00");
            }
            else
            {
                oCon.CrearComando("Update agenda_detalle set estado=1 where id_agenda_tecnico=@id_encabezado and id_parte=@id_parte");
                oCon.AsignarParametroCadena("@id_encabezado", id_encabezado);
                oCon.AsignarParametroCadena("@id_parte", id_parte);

            }

            try
            {
                oCon.Conectar();
                oCon.ComenzarTransaccion();
                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();


                oCon.DesConectar();
                resultado = true;
            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                resultado = false;
                throw;

            }
            return resultado;
        }

        public bool Actualizar_parte(string id_parte, int id_tecnico, int estado_parte)
        {
            bool resultado = false;

            if (estado_parte == 0)
                oCon.CrearComando("Update partes set Id_Tecnicos=@id_tecnico where partes.Id=@id");
            else
            {
                oCon.CrearComando("Update partes set Id_Tecnicos=@id_tecnico,Id_Partes_Estados=@estado_parte where partes.Id=@id");
                oCon.AsignarParametroEntero("@estado_parte", estado_parte);
            }

            oCon.AsignarParametroEntero("@id_tecnico", id_tecnico);
            oCon.AsignarParametroCadena("@id", id_parte);

            try
            {
                oCon.Conectar();
                oCon.ComenzarTransaccion();
                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
                resultado = true;
            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                resultado = false;
                throw;

            }
            return resultado;
        }

        public bool Borrar_partes(int id_encabezado, int id_parte)
        {
            bool resultado = false;

            oCon.CrearComando("Update agenda_detalle set estado=1 where id_agenda_tecnico=@id_encabezado and id_parte=@id_parte");

            oCon.AsignarParametroEntero("@id_encabezado", id_encabezado);
            oCon.AsignarParametroEntero("@id_parte", id_parte);

            try
            {
                oCon.Conectar();
                oCon.ComenzarTransaccion();
                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();


                oCon.DesConectar();
                resultado = true;
            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                resultado = false;
                throw;

            }

            return resultado;

        }

        public bool Activar_partes(int id_encabezado, int id_parte)
        {
            bool resultado = false;

            oCon.CrearComando("Update agenda_detalle set estado=0 where id_agenda_tecnico=@id_encabezado and id_parte=@id_parte");

            oCon.AsignarParametroEntero("@id_encabezado", id_encabezado);
            oCon.AsignarParametroEntero("@id_parte", id_parte);

            try
            {
                oCon.Conectar();
                oCon.ComenzarTransaccion();
                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();


                oCon.DesConectar();
                resultado = true;
            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                resultado = false;
                throw;

            }
            return resultado;

        }

        public DataRow TraerDatosParte(Int32 codigo)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();

                oCon.CrearComando("select partes.Id as Id_Parte, partes.Id_Partes_Estados, date(partes.fecha_programado) as Fecha_Programado, partes.Id_Tecnicos as Tecnico, partes_fallas.Nombre as falla, partes_fallas.Id_Partes_Operaciones,"
                 + " servicios.Descripcion as Servicio, concat(usuarios.Apellido, ' ', usuarios.Nombre) as Usuario, partes.Id_Usuarios_Locaciones as Id_Locacion, partes_usuarios_servicios.Id_usuarios_servicios, partes.Id_Usuarios, partes_usuarios_servicios.Id_servicio AS id_servicios,"
                 + " usuarios_locaciones.calle as Calle, usuarios_locaciones.altura, usuarios_locaciones.Piso,"
                 + " usuarios_locaciones.Depto"
                 + " from partes"
                 + " LEFT JOIN partes_usuarios_servicios ON partes_usuarios_servicios.Id_parte = partes.Id"
                 + " LEFT JOIN partes_fallas ON partes_fallas.Id = partes_usuarios_servicios.id_parte_falla"
                 + " LEFT JOIN usuarios ON usuarios.Id = partes.Id"
                 + " LEFT JOIN usuarios_locaciones ON usuarios_locaciones.id = partes.Id_Usuarios_Locaciones"
                 + " LEFT JOIN servicios ON servicios.Id = partes_usuarios_servicios.id_servicio"
                 + " where partes.Id =@id");
                oCon.AsignarParametroEntero("@id", codigo);

                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }

            if (dt.Rows.Count == 0)
            {
                DataRow dr = dt.NewRow();
                dr["Id_Parte"] = "0";
                return dr;
            }
            else
                return dt.Rows[0];
        }

        public DataTable Buscar_cant_partes(DataTable encabezado)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT DISTINCT id_parte FROM agenda_detalle WHERE id_agenda_tecnico = @id AND estado = 0 and id_parte>0");
                oCon.AsignarParametroCadena("@id", encabezado.Rows[0]["Id"].ToString());
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception j)
            {
                oCon.DesConectar();
                MessageBox.Show(j.Message);
                throw;
            }

            return dt;

        }

        public DataTable Buscar_tecnico()
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();

                oCon.CrearComando("select personal.Id, personal.Nombre, personal.hora_inicio_1, personal.hora_fin_1, personal.hora_inicio_2, personal.hora_fin_2, rango, con_doble_turno, id_personal_areas from (select Id as Id_area from personal_areas where Req_horario=1)areas_con_horario inner join personal on areas_con_horario.Id_area=personal.Id_Personal_Areas and rango is not null and borrado=0");

                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception j)
            {
                oCon.DesConectar();
                MessageBox.Show(j.Message);
                throw;
            }
            return dt;
        }

        public DataTable Buscar_encabezado(DataRow dt_tecnicos, string fecha)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();

                if (dt_tecnicos != null)
                    oCon.CrearComando("SELECT agenda_encabezado.Id,hora_inicio_1,hora_fin_1,hora_inicio_2,hora_fin_2,rango from agenda_encabezado where id_tecnico='" + dt_tecnicos[0].ToString() + "' and fecha_jornada='" + fecha + "'");
                else
                    oCon.CrearComando("SELECT agenda_encabezado.Id from agenda_encabezado where fecha_jornada='" + fecha + "'");

                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception j)
            {
                oCon.DesConectar();
                MessageBox.Show(j.Message);
                throw;
            }

            return dt;
        }

        public DataTable Buscar_detalles_agenda(DataTable encabezado)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando("select Id,hora,id_parte, detalles,reservado from agenda_detalle where id_agenda_tecnico=@id and estado=0");
                oCon.AsignarParametroCadena("@id", encabezado.Rows[0]["Id"].ToString());
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception j)
            {
                oCon.DesConectar();
                MessageBox.Show(j.Message);
                throw;
            }

            return dt;

        }

        public DataTable Buscar_datos_parte(int id_parte)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();

                oCon.CrearComando("select partes.id, usuarios.codigo,concat(usuarios.apellido,' ',usuarios.nombre) as usuario,partes_fallas.nombre as falla, concat(TRIM(usuarios_locaciones.calle),' ',TRIM(CAST(usuarios_locaciones.altura as char(10))),' ',TRIM(usuarios_locaciones.piso),' ',TRIM(usuarios_locaciones.depto),' ',TRIM(localidades.nombre)) as locacion, partes.id_tecnicos, partes.id_partes_estados " +
                    "from partes " +
                    "left join usuarios on usuarios.id=partes.id_usuarios " +
                    "left join partes_usuarios_servicios on partes_usuarios_servicios.id_parte=partes.id " +
                    "left join usuarios_locaciones on usuarios_locaciones.id=partes.id_usuarios_locaciones " +
                    "left join localidades on localidades.id=usuarios_locaciones.id_localidades " +
                    "left join partes_fallas on partes_fallas.id=partes_usuarios_servicios.id_parte_falla " +
                    " where partes.id=@id");
                oCon.AsignarParametroEntero("@id", id_parte);

                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception j)
            {
                oCon.DesConectar();
                MessageBox.Show(j.Message);
                throw;
            }

            return dt;
        }

        public DataTable Agregar_sobreturno(string hora, DataTable grilla_horas)
        {
            int resultado = 0;
            DataTable dt = new DataTable();
            foreach (DataRow row in grilla_horas.Rows)
            {

                if (row["Hora"].ToString() == hora)
                {
                    resultado = 1;
                    break;
                }
            }

            if (resultado == 0)
            {
                DataRow row;
                row = grilla_horas.NewRow();

                row[grilla_horas.Columns["hora"]] = hora;
                grilla_horas.Rows.Add(row);
                grilla_horas.DefaultView.Sort = "Hora ASC";
                return grilla_horas;

            }
            else
            {
                return dt;
            }
        }

        public DataTable Id_agenda_detalle(int id_tecnico, DateTime fecha)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT Id from agenda_encabezado where id_tecnico=@id_tecnico and fecha_jornada=@fecha");

                oCon.AsignarParametroCadena("@id_tecnico", id_tecnico.ToString());
                oCon.AsignarParametroFecha("@fecha", fecha);

                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception j)
            {
                oCon.DesConectar();
                MessageBox.Show(j.Message);
                throw;
            }

            return dt;
        }

    }
}
