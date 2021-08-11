using CapaDatos;
using System;
using System.Data;


namespace CapaNegocios
{
    public class Usuarios_Locaciones_Uf
    {
        public Int32 Id { get; set; }
        public String Apellido { get; set; }
        public String Nombre { get; set; }
        public String Piso { get; set; }
        public String Depto { get; set; }
        public String Descripcion { get; set; }
        public Int32 IdUsuario { get; set; }
        private Conexion oCon = new Conexion();


        public Int32 Guardar(Usuarios_Locaciones_Uf oUnidades, Int32 idUsuarioLoc)
        {
            Int32 retorno = 0;

            try
            {
                oCon.Conectar();
                if (oUnidades.Id != 0)
                {
                    oCon.CrearComando("UPDATE usuarios_locaciones_uf SET apellido=@apellido1, nombre=@nombre1,piso=@piso1,depto=@depto1, descripcion=@descripcion1, id_usuario=@idUsu WHERE id=@idUf");
                    oCon.AsignarParametroEntero("@idUf", oUnidades.Id);
                }
                else
                    oCon.CrearComando("INSERT INTO usuarios_locaciones_uf (apellido, nombre,piso,depto,descripcion,id_usuario) VALUES (@apellido1, @nombre1,@piso1,@depto1,@descripcion1,@idUsu);SELECT @@IDENTITY");
                oCon.AsignarParametroCadena("@apellido1", oUnidades.Apellido);
                oCon.AsignarParametroCadena("@nombre1", oUnidades.Nombre);
                oCon.AsignarParametroCadena("@piso1", oUnidades.Piso);
                oCon.AsignarParametroCadena("@depto1", oUnidades.Depto);
                oCon.AsignarParametroCadena("@descripcion1", oUnidades.Descripcion);
                oCon.AsignarParametroEntero("@idUsu", oUnidades.IdUsuario);

                oCon.ComenzarTransaccion();
                if (oUnidades.Id > 0)
                    oCon.EjecutarComando();
                else
                    retorno = oCon.EjecutarScalar();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                retorno = -1;
            }
            if (retorno != -1 && oUnidades.Id == 0)
            {
                GuardarRelacion(idUsuarioLoc, retorno);
            }
            return retorno;
        }

        public Int32 GuardarRelacion(int idLoc, int idUf)
        {
            Int32 retorno = 0;
            try
            {
                oCon.Conectar();
                oCon.CrearComando("INSERT INTO usuarios_locaciones_uf_relacion (id_usuarios_locaciones,id_usuarios_locaciones_uf) VALUES (@idLoc,@idUf);SELECT @@IDENTITY");
                oCon.AsignarParametroEntero("@idLoc", idLoc);
                oCon.AsignarParametroEntero("@idUf", idUf);
                oCon.ComenzarTransaccion();
                retorno = oCon.EjecutarScalar();
                oCon.ComenzarTransaccion();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                retorno = -1;
            }
            return retorno;
        }

        public Int32 EditarRelacionPadre(int idLoc, int idUf, int idLocPadre)
        {
            Int32 retorno = 0;
            try
            {
                oCon.Conectar();
                oCon.CrearComando("UPDATE usuarios_locaciones_uf_relacion SET id_usuarios_locaciones_padre =@padre WHERE id_usuarios_locaciones=@idLoc and id_usuarios_locaciones_uf=@idUf");
                oCon.AsignarParametroEntero("@idLoc", idLoc);
                oCon.AsignarParametroEntero("@idUf", idUf);
                oCon.AsignarParametroEntero("@padre", idLocPadre);

                oCon.ComenzarTransaccion();
                retorno = oCon.EjecutarScalar();
                oCon.ComenzarTransaccion();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                retorno = -1;
            }
            return retorno;
        }

        public DataTable Listar(int idUsuarioLocacion)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT usuarios_locaciones_uf_relacion.Id_Usuarios_Locaciones_Uf, usuarios_locaciones_uf.id,usuarios_locaciones_uf.id_usuario,usuarios_locaciones_uf.apellido, usuarios_locaciones_uf.nombre,usuarios_locaciones_uf.piso,usuarios_locaciones_uf.depto,usuarios_locaciones_uf.descripcion FROM usuarios_locaciones_uf_relacion INNER JOIN  usuarios_locaciones_uf on usuarios_locaciones_uf.id=usuarios_locaciones_uf_relacion.Id_Usuarios_Locaciones_Uf WHERE usuarios_locaciones_uf_relacion.Id_Usuarios_Locaciones=@id ");
                oCon.AsignarParametroEntero("@id", idUsuarioLocacion);
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
