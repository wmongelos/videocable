using CapaDatos;
using System;
using System.Data;

namespace CapaNegocios
{
    public class Equipos_Tarjetas
    {
        public Int32 Id { get; set; }
        public string Numero { get; set; }
        public Int32 Id_Estado { get; set; }
        public Int32 Borrado { get; set; }
        public Int32 Id_Equipos_Tipos { get; set; }

        public enum Tarjetas_Estados
        {
            DISPONIBLE = 1,
            ENTREGADA = 2,
            CON_FALLA = 3
        }

        private Conexion oCon = new Conexion();

        public int Guardar(Equipos_Tarjetas oEquipoTarjeta)
        {
            try
            {
                oCon.Conectar();
                if (oEquipoTarjeta.Id > 0)
                {
                    oCon.CrearComando("UPDATE equipos_tarjetas SET Numero=@numero, id_Equipos_Tipo=@idEquiposTipo, Estado=@estado,id_personal=@personal WHERE id=@id; SELECT @@IDENTITY");
                    oCon.AsignarParametroCadena("@numero", oEquipoTarjeta.Numero);
                    oCon.AsignarParametroEntero("@idEquiposTipo", oEquipoTarjeta.Id_Equipos_Tipos);
                    oCon.AsignarParametroEntero("@estado", oEquipoTarjeta.Id_Estado);
                    oCon.AsignarParametroEntero("@personal", Personal.Id_Login);
                    oCon.AsignarParametroEntero("@id", oEquipoTarjeta.Id);
                }
                else
                {
                    oCon.CrearComando("INSERT INTO equipos_tarjetas (Numero, id_Equipos_Tipo, Estado, Borrado,id_personal) " +
                        "VALUES (@Numero, @id_Equipos_Tipo, @Estado, @borrado,@personal);SELECT @@IDENTITY");
                    oCon.AsignarParametroCadena("@Numero", oEquipoTarjeta.Numero);
                    oCon.AsignarParametroEntero("@id_Equipos_Tipo", oEquipoTarjeta.Id_Equipos_Tipos);
                    oCon.AsignarParametroEntero("@Estado", oEquipoTarjeta.Id_Estado);
                    oCon.AsignarParametroEntero("@borrado", 0);
                    oCon.AsignarParametroEntero("@personal", Personal.Id_Login);

                }

                oCon.ComenzarTransaccion();
                oEquipoTarjeta.Id = oCon.EjecutarScalar();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                throw;
            }

            return oEquipoTarjeta.Id;
        }

        public void Eliminar(int id)
        {
            try
            {
                oCon.Conectar();
                oCon.ComenzarTransaccion();
                oCon.CrearComando("UPDATE equipos_tarjetas SET Borrado = 1,id_personal=@personal  WHERE Id = @id");
                oCon.AsignarParametroEntero("@personal", Personal.Id_Login);
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

        public void AsignarTarjetaEquipo(int idEquipo, int idTarjeta)
        {
            try
            {
                oCon.Conectar();
                oCon.ComenzarTransaccion();


                oCon.CrearComando("UPDATE equipos SET id_tarjeta = @id_tarjeta,id_personal=@personal WHERE Id = @id");
                oCon.AsignarParametroEntero("@id_tarjeta", idTarjeta);
                oCon.AsignarParametroEntero("@personal", Personal.Id_Login);
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

        public void QuitarTarjetaEquipo(int idEquipo)
        {
            try
            {
                oCon.Conectar();
                oCon.ComenzarTransaccion();


                oCon.CrearComando("UPDATE equipos SET id_tarjeta = 0,id_personal=@personal WHERE Id = @id");
                oCon.AsignarParametroEntero("@personal", Personal.Id_Login);
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

        public void AsignarTarjetaParteEquipo(int idParteEquipo, int idTarjeta)
        {
            try
            {
                oCon.Conectar();
                oCon.ComenzarTransaccion();


                oCon.CrearComando("UPDATE partes_equipos SET id_tarjeta = @id_tarjeta,id_personal=@personal WHERE Id = @id");
                oCon.AsignarParametroEntero("@id_tarjeta", idTarjeta);
                oCon.AsignarParametroEntero("@personal", Personal.Id_Login);
                oCon.AsignarParametroEntero("@id", idParteEquipo);
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

        public void CambiarEstadoTarjeta(int idTarjeta, int idEstado)
        {
            try
            {
                oCon.Conectar();
                oCon.ComenzarTransaccion();


                oCon.CrearComando("UPDATE equipos_tarjetas SET Estado=@Estado,id_personal=@personal  WHERE Id = @id_tarjeta");
                oCon.AsignarParametroEntero("@id_tarjeta", idTarjeta);
                oCon.AsignarParametroEntero("@Estado", idEstado);
                oCon.AsignarParametroEntero("@personal", Personal.Id_Login);
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

        public DataTable ListarPorTipoEquipoYEstado(int IdEstado, int IdEquipoTipo)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando(String.Format("select equipos_tarjetas.Id, equipos_tarjetas.Numero, (select equipos_tipos.Nombre from equipos_tipos where equipos_tipos.Id = equipos_tarjetas.Id_Equipos_Tipo) as EquipoTipo, " +
                    "equipos.serie, equipos.mac, concat(usuarios.apellido, ' ', usuarios.nombre) as usuario, servicios.descripcion as servicio, equipos_tarjetas.Estado, " +
                    "CASE equipos_tarjetas.Estado WHEN 1 THEN('DISPONIBLE') WHEN 2 THEN('ENTREGADA') WHEN 3 THEN('CON FALLA') END AS EstadoNombre, equipos.Id as idEquipo, equipos_tarjetas.Id_Equipos_Tipo " +
                    "from equipos_tarjetas left join equipos_tipos on equipos_tarjetas.Id_Equipos_Tipo = equipos_tipos.id left join equipos on equipos_tarjetas.Id = equipos.Id_Tarjeta " +
                    "left join usuarios on equipos.id_usuarios = usuarios.id left join usuarios_servicios on equipos.id_usuarios_servicios = usuarios_servicios.id " +
                    "left join servicios on usuarios_servicios.id_servicios = servicios.id where equipos_tarjetas.Borrado = 0 and equipos_tarjetas.estado={0} and equipos_tarjetas.id_equipos_tipo={1}", IdEstado, IdEquipoTipo));
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

        public DataTable Listar(string nroTarjeta = "")
        {
            DataTable dt = new DataTable();
            string consulta = "select usuarios.id as id_usu,equipos_tarjetas.Id, equipos_tarjetas.Numero, (select equipos_tipos.Nombre from equipos_tipos where equipos_tipos.Id = equipos_tarjetas.Id_Equipos_Tipo) as EquipoTipo, " +
                    "equipos.serie, equipos.mac, concat(usuarios.apellido, ' ', usuarios.nombre) as usuario, servicios.descripcion as servicio, equipos_tarjetas.Estado, " +
                    "CASE equipos_tarjetas.Estado WHEN 1 THEN('DISPONIBLE') WHEN 2 THEN('ENTREGADA') WHEN 3 THEN('CON FALLA') END AS EstadoNombre, equipos.Id as idEquipo, equipos_tarjetas.Id_Equipos_Tipo " +
                    "from equipos_tarjetas left join equipos_tipos on equipos_tarjetas.Id_Equipos_Tipo = equipos_tipos.id left join equipos on equipos_tarjetas.Id = equipos.Id_Tarjeta " +
                    "left join usuarios on equipos.id_usuarios = usuarios.id left join usuarios_servicios on equipos.id_usuarios_servicios = usuarios_servicios.id " +
                    "left join servicios on usuarios_servicios.id_servicios = servicios.id where equipos_tarjetas.Borrado = 0";
            if (nroTarjeta != "")
                consulta = consulta + string.Format(" and equipos_tarjetas.numero='{0}'", nroTarjeta);
            try
            {
                oCon.Conectar();
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

        public DataTable Verificar_Tarjeta_Disponible(string nroTarjeta = "")
        {
            DataTable dt = new DataTable();
            /*string consulta = "select usuarios.id as id_usu,equipos_tarjetas.Id, equipos_tarjetas.Numero, (select equipos_tipos.Nombre from equipos_tipos where equipos_tipos.Id = equipos_tarjetas.Id_Equipos_Tipo) as EquipoTipo, " +
                    "equipos.serie, equipos.mac, concat(usuarios.apellido, ' ', usuarios.nombre) as usuario, servicios.descripcion as servicio, equipos_tarjetas.Estado, " +
                    "CASE equipos_tarjetas.Estado WHEN 1 THEN('DISPONIBLE') WHEN 2 THEN('ENTREGADA') WHEN 3 THEN('CON FALLA') END AS EstadoNombre, ifnull(equipos.Id,0) as idEquipo, equipos_tarjetas.Id_Equipos_Tipo " +
                    "from equipos_tarjetas left join equipos_tipos on equipos_tarjetas.Id_Equipos_Tipo = equipos_tipos.id left join equipos on equipos_tarjetas.Id = equipos.Id_Tarjeta " +
                    "left join usuarios on equipos.id_usuarios = usuarios.id left join usuarios_servicios on equipos.id_usuarios_servicios = usuarios_servicios.id " +
                    "left join servicios on usuarios_servicios.id_servicios = servicios.id where equipos_tarjetas.Borrado = 0 and equipos_tarjetas.estado = 1 ";
            */
            string consulta = " SELECT equipos_tarjetas.id AS Id_Tarjeta, ifnull(equipos.id,0) AS id_Equipo, equipos.Descripcion AS Equi, equipos_tipos.Nombre AS Tipo_Equipo, " +
                "equipos.serie, equipos.mac, equipos_tipos.Id AS Id_Equipo_tipo, CONCAT(usuarios.Apellido, ' , ', usuarios.Nombre) AS Usuario, " +
                "usuarios.id AS Id_Usu , usuarios.Codigo AS CodUsu, equipos_tarjetas.Numero AS Tarjeta " +
                "FROM equipos_tarjetas " +
                "LEFT JOIN equipos ON equipos.Id_Tarjeta = equipos_tarjetas.id " +
                "LEFT JOIN equipos_tipos ON equipos_tarjetas.Id_Equipos_Tipo = equipos_tipos.id " +
                "LEFT JOIN usuarios ON equipos.Id_Usuarios = usuarios.id " +
                "WHERE equipos_tarjetas.Borrado = 0 ";

            if (nroTarjeta != "")
                consulta = consulta + string.Format(" and equipos_tarjetas.numero='{0}' ", nroTarjeta);
            try
            {
                oCon.Conectar();
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
        public DataTable Listar_Tarjetas(string nroTarjeta = "")
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando(string.Format("SELECT * from equipos_tarjetas where equipos_tarjetas.numero='{0}'", nroTarjeta));
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

        public DataTable ListarEquiposRequierenTarjeta()
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();

                oCon.CrearComando("SELECT equipos_tarjetas.id, usuarios.id AS id_usuario , equipos_tarjetas.Numero AS NumeroTarjeta, concat(usuarios.Apellido , ' , ' , usuarios.Nombre) AS Usuario, equipos_tipos.Nombre AS Equipo " +
                    "FROM usuarios_servicios_equipos " +
                    "LEFT JOIN equipos ON equipos.id = usuarios_servicios_equipos.id_equipo " +
                    "LEFT JOIN equipos_tipos ON equipos_tipos.id = equipos.Id_Equipos_Tipos " +
                    "LEFT JOIN equipos_tarjetas ON equipos_tarjetas.id = equipos.Id_Tarjeta " +
                    "LEFT JOIN usuarios ON usuarios.id = usuarios_servicios_equipos.id_usuario " +
                    "WHERE equipos_tipos.Requiere_Tarjeta = 1 AND equipos_tarjetas.Estado = 3 AND usuarios.Borrado=0");
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

        public DataTable Listar_Tarjeta_AsignadaAEquipo(string nroTarjeta = "")
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando(string.Format("SELECT equipos_tarjetas.id AS Id_Tarjeta, ifnull(equipos.id,0) AS id_Equipo, equipos.Descripcion AS Equi, equipos_tipos.Nombre AS Tipo_Equipo, " +
                    "equipos.serie, equipos.mac, equipos_tipos.Id AS Id_Equipo_tipo " +
                    "FROM equipos_tarjetas " +
                    "LEFT JOIN equipos ON equipos.Id_Tarjeta = equipos_tarjetas.id " +
                    "LEFT JOIN equipos_tipos ON equipos_tarjetas.Id_Equipos_Tipo = equipos_tipos.id " +
                    "WHERE equipos_tarjetas.Numero = '{0}'", nroTarjeta));
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


        public Boolean verificarTarjetaAsignada(int id_tarjeta)
        {

            try
            {
                DataTable dtVerificacion = new DataTable();
                oCon.Conectar();
                oCon.CrearComando(string.Format("SELECT usuarios.id AS idUsu,equipos.id AS idEqui,equipos_tarjetas.id AS id_tarjeta, " +
                    "usuarios.codigo AS codUsu, CONCAT(usuarios.Apellido, ' , ', usuarios.nombre) AS Usuario " +
                    "FROM equipos " +
                    "LEFT JOIN equipos_tarjetas on equipos.Id_Tarjeta = equipos_tarjetas.id " +
                    "LEFT JOIN usuarios ON equipos.Id_Usuarios = usuarios.id " +
                    "WHERE equipos.id_tarjeta = {0} ; ", id_tarjeta));
                dtVerificacion = oCon.Tabla();
                oCon.DesConectar();
                if (dtVerificacion.Rows.Count > 0)
                    return true;
                else
                    return false;

            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }
        }




    }
}
