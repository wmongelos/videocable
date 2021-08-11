using CapaDatos;
using System;
using System.Data;

namespace CapaNegocios
{
    public class Partes_Equipos
    {
        public Int32 Id { get; set; }
        public Int32 Id_Partes { get; set; }
        public Int32 Id_Usuarios { get; set; }
        public Int32 Id_Equipos { get; set; }
        public Int32 Id_Equipos_Tipos { get; set; }
        public Int32 Id_Servicios { get; set; }
        public Int32 Id_Usuarios_Servicios { get; set; }
        public Int32 Id_equipo_anterior { get; set; }
        public Int32 Id_parte_equipo_anterior { get; set; }
        public Int32 Id_Tarjeta { get; set; }
        public Int32 Id_Tarjeta_Anterior { get; set; }

        private Conexion oCon = new Conexion();

        public enum PartesEquiposEstados
        {
            PENDIENTE_ACTIVACION = 2,
            ACTIVADO = 0,
            DESACTIVADO = 1
        }

        public enum TIPO_ITEM_BUSQUEDA_EQUIPO
        {
            PARTE = 1,
            PARTE_EQUIPO = 2
        }

        public Int32 Guardar(Partes_Equipos oParte_Equ)
        {
            try
            {
                oCon.Conectar();

                if (oParte_Equ.Id == 0)
                {
                    oCon.CrearComando("INSERT INTO partes_equipos(Id_Partes, Id_Usuarios,id_usuarios_servicios,Id_Equipos_Tipos, id_equipos,  Id_Servicios,id_equipo_anterior,id_parte_equipo_anterior, id_tarjeta_anterior,borrado, id_tarjeta) VALUES(@parte, @usuario,@id_usuarios_servicios, @tipo, @idEquipos, @servicio,@id_equipo_anterior,@id_parte_equipo_anterior, @id_tarjeta_anterior,@borrado, @tarjeta); SELECT @@IDENTITY");
                    oCon.AsignarParametroEntero("@parte", oParte_Equ.Id_Partes);
                    oCon.AsignarParametroEntero("@usuario", oParte_Equ.Id_Usuarios);
                    oCon.AsignarParametroEntero("@id_usuarios_servicios", oParte_Equ.Id_Usuarios_Servicios);
                    oCon.AsignarParametroEntero("@tipo", oParte_Equ.Id_Equipos_Tipos);
                    oCon.AsignarParametroEntero("@idEquipos", oParte_Equ.Id_Equipos);
                    oCon.AsignarParametroEntero("@servicio", oParte_Equ.Id_Servicios);
                    oCon.AsignarParametroEntero("@id_equipo_anterior", oParte_Equ.Id_equipo_anterior);
                    oCon.AsignarParametroEntero("@id_parte_equipo_anterior", oParte_Equ.Id_parte_equipo_anterior);
                    oCon.AsignarParametroEntero("@tarjeta", oParte_Equ.Id_Tarjeta);
                    oCon.AsignarParametroEntero("@id_tarjeta_anterior", oParte_Equ.Id_Tarjeta_Anterior);

                    if (oParte_Equ.Id_parte_equipo_anterior == 0)
                        oCon.AsignarParametroEntero("@borrado", Convert.ToInt32(PartesEquiposEstados.ACTIVADO));
                    else
                        oCon.AsignarParametroEntero("@borrado", Convert.ToInt32(PartesEquiposEstados.PENDIENTE_ACTIVACION));
                }
                else
                {
                    oCon.CrearComando("update partes_equipos set id_equipos_tipos=@idEquiposTipos where id=@id; SELECT @@IDENTITY");
                    oCon.AsignarParametroEntero("@idEquiposTipos", oParte_Equ.Id_Equipos_Tipos);

                    oCon.AsignarParametroEntero("@id", oParte_Equ.Id);

                }

                oCon.ComenzarTransaccion();
                oParte_Equ.Id = oCon.EjecutarScalar();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                throw;
            }

            return oParte_Equ.Id;
        }

        public DataTable ListarPorParte(int id)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT partes_equipos.id, partes_equipos.id_partes, partes_equipos.id_usuarios, partes_equipos.id_servicios, partes_equipos.id_equipos, servicios.descripcion as servicio, " +
                    " equipos_tipos.nombre as tipo_equipo, equipos.descripcion as nombre, equipos.mac as mac, equipos.serie as serie, partes_equipos.id_tarjeta, partes_equipos.id_tarjeta_anterior, equipos_tarjetas.numero as NumeroTarjeta," +
                    " partes_equipos.id_usuarios_servicios, partes_equipos.id_equipos_tipos, id_equipo_anterior, id_parte_equipo_anterior, if(equipos_tipos.requiere_tarjeta>0,'SI','NO') as requiere_tarjeta, if (partes_equipos.id_equipos > 0, if (equipos_tipos.requiere_tarjeta = 1 and partes_equipos.id_tarjeta = 0,'REQUIERE TARJETA', 'ASIGNADO'),'REQUIERE EQUIPO') as parte_equipo_estado " +
                    " from 	partes_equipos left join equipos_tipos on partes_equipos.id_equipos_tipos=equipos_tipos.id left join equipos on partes_equipos.id_equipos = equipos.id  left join servicios on partes_equipos.id_servicios = servicios.id left join equipos_tarjetas on partes_equipos.id_tarjeta = equipos_tarjetas.id where partes_equipos.id_partes = @parte and(partes_equipos.borrado = @activado or partes_equipos.borrado = @pendiente_activacion)");
                oCon.AsignarParametroEntero("@parte", id);
                oCon.AsignarParametroEntero("@activado", Convert.ToInt32(PartesEquiposEstados.ACTIVADO));
                oCon.AsignarParametroEntero("@pendiente_activacion", Convert.ToInt32(PartesEquiposEstados.PENDIENTE_ACTIVACION));
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

        public void AsignarEquipo(int IdParteEquipo, int IdEquipo)
        {
            try
            {
                DataTable DtDatosParteEquipo = new DataTable();
                DataTable DtDatosEquipoNuevo = new DataTable();
                DataTable DtDatosEquipoAnterior = new DataTable();
                int IdEquipoParteEquipo = 0;
                int IdTarjetaParteEquipo = 0;
                int IdTarjetaEquipoNuevo = 0;
                oCon.Conectar();

                if (IdParteEquipo > 0)
                {
                    oCon.CrearComando(String.Format("select * from partes_equipos where id={0}", IdParteEquipo));
                    DtDatosParteEquipo = oCon.Tabla();
                    IdEquipoParteEquipo = Convert.ToInt32(DtDatosParteEquipo.Rows[0]["id_equipos"]);
                    IdTarjetaParteEquipo = Convert.ToInt32(DtDatosParteEquipo.Rows[0]["id_tarjeta"]);
                }

                if (IdEquipo > 0)
                {
                    oCon.CrearComando(String.Format("select * from equipos where id={0}", IdEquipo));
                    DtDatosEquipoNuevo = oCon.Tabla();
                    IdTarjetaEquipoNuevo = Convert.ToInt32(DtDatosEquipoNuevo.Rows[0]["id_tarjeta"]);
                }

                if (IdTarjetaEquipoNuevo > 0)
                {
                    oCon.CrearComando("UPDATE partes_equipos SET id_tarjeta=@tarjeta, Id_Equipos=@Equipo WHERE Id=@id");
                    oCon.AsignarParametroEntero("@tarjeta", IdTarjetaEquipoNuevo);
                }
                else
                {
                    if (IdTarjetaParteEquipo == 0)
                        oCon.CrearComando("UPDATE partes_equipos SET Id_Equipos=@Equipo, id_tarjeta=0 WHERE Id=@id");
                    else
                        oCon.CrearComando("UPDATE partes_equipos SET Id_Equipos=@Equipo WHERE Id=@id");
                }

                oCon.AsignarParametroEntero("@Equipo", IdEquipo);
                oCon.AsignarParametroEntero("@id", IdParteEquipo);

                oCon.ComenzarTransaccion();
                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();

                if (IdEquipoParteEquipo > 0)
                {
                    oCon.CrearComando("UPDATE equipos SET id_usuarios=0, id_usuarios_servicios=0, id_equipos_estados=@id_estado, id_tarjeta=0 WHERE Id=@id");
                    oCon.AsignarParametroEntero("@id_estado", Convert.ToInt32(Equipos.Equipos_Estados.DISPONIBLE_EN_STOCK));
                    oCon.AsignarParametroEntero("@id", IdEquipoParteEquipo);
                    oCon.ComenzarTransaccion();
                    oCon.EjecutarComando();
                    oCon.ConfirmarTransaccion();
                }

                if (IdTarjetaParteEquipo > 0)
                {
                    if (IdTarjetaEquipoNuevo > 0)
                    {
                        oCon.CrearComando("UPDATE equipos_tarjetas SET Estado=@Estado  WHERE Id = @id_tarjeta");
                        oCon.AsignarParametroEntero("@Estado", Convert.ToInt32(Equipos_Tarjetas.Tarjetas_Estados.DISPONIBLE));
                        oCon.AsignarParametroEntero("@id_tarjeta", IdTarjetaParteEquipo);
                        oCon.EjecutarComando();
                        oCon.ConfirmarTransaccion();
                    }
                    else
                    {
                        oCon.CrearComando("UPDATE equipos SET id_tarjeta=@id_tarjeta WHERE Id=@id");
                        oCon.AsignarParametroEntero("@id_tarjeta", IdTarjetaParteEquipo);
                        oCon.AsignarParametroEntero("@id", IdEquipo);
                        oCon.ComenzarTransaccion();
                        oCon.EjecutarComando();
                        oCon.ConfirmarTransaccion();
                    }
                }


                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();

                throw;
            }
        }


        
        public void Eliminar(int id)
        {
            try
            {
                oCon.Conectar();
                oCon.ComenzarTransaccion();
                oCon.CrearComando("UPDATE partes_equipos SET Borrado = @desactivado WHERE Id = @id");
                oCon.AsignarParametroEntero("@desactivado", Convert.ToInt32(PartesEquiposEstados.DESACTIVADO));
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

        public bool ActivarRegistroParteEquipo(int id,out string salida)
        {
            try
            {
                oCon.Conectar();
                oCon.ComenzarTransaccion();
                oCon.CrearComando("UPDATE partes_equipos SET Borrado = @activado WHERE Id = @id");
                oCon.AsignarParametroEntero("@activado", Convert.ToInt32(PartesEquiposEstados.ACTIVADO));
                oCon.AsignarParametroEntero("@id", id);
                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
                salida = "";
                return true;
            }
            catch (Exception c)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                salida = c.ToString();
                return false;
            }
        }

        public void QuitarEquipoAsignado(int idParteEquipo, int idEquipo)
        {

            try
            {
                oCon.Conectar();
                oCon.ComenzarTransaccion();
                oCon.CrearComando("UPDATE partes_equipos SET id_equipos =0 WHERE Id = @id");
                oCon.AsignarParametroEntero("@id", idParteEquipo);
                oCon.EjecutarComando();

                oCon.CrearComando("UPDATE partes_equipos SET id_equipos =0 WHERE Id = @id");
                oCon.AsignarParametroEntero("@id", idParteEquipo);
                oCon.EjecutarComando();

                oCon.CrearComando("UPDATE equipos SET id_equipos_estados = @estado, id_usuarios=@idUsuario, id_usuarios_servicios=@idUsuariosServicios WHERE Id = @id");
                oCon.AsignarParametroEntero("@estado", Convert.ToInt32(Equipos.Equipos_Estados.DISPONIBLE_EN_STOCK));
                oCon.AsignarParametroEntero("@idUsuario", 0);
                oCon.AsignarParametroEntero("@idUsuariosServicios", 0);
                oCon.AsignarParametroEntero("@id", idEquipo);

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

        public DataTable BuscarParteEquipo(int Id)
        {
            DataTable dt;
            try
            {
                oCon.Conectar();
                oCon.CrearComando("select partes_equipos.*,(select id_servicios_tipos from servicios where id=id_servicios) as id_servicios_tipo from partes_equipos where Id=@id and borrado!=1");
                oCon.AsignarParametroEntero("@id", Id);
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

        public DataTable ListarPorUsuarioServicio(int id_usuServ)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT *  " +
                    "FROM  partes_equipos " +
                    "LEFT JOIN equipos_tarjetas ON partes_equipos.Id_Tarjeta = equipos_tarjetas.id " +
                    "WHERE partes_equipos.Id_Usuarios_Servicios = @idUsuServ; ");
                oCon.AsignarParametroEntero("@idUsuServ", id_usuServ);
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
