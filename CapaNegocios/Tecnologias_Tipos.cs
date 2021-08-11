using CapaDatos;
using System;
using System.Data;
namespace CapaNegocios
{
    public class Tecnologias_Tipos
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        private Conexion oCon = new Conexion();

        public enum TIPO
        {
            TIPO_EQUIPO = 1,
            SERVICIO = 2
        }

        public void Guardar(Tecnologias_Tipos oTecno)
        {

            try
            {
                oCon.Conectar();

                if (oTecno.Id > 0)
                {
                    oCon.CrearComando("UPDATE tecnologias SET Descripcion = @des WHERE Id = @id");

                    oCon.AsignarParametroEntero("@id", oTecno.Id);
                }
                else
                {
                    oCon.CrearComando("INSERT INTO tecnologias(Descripcion) " +
                        "VALUES(@des)");
                }
                oCon.AsignarParametroCadena("@des", oTecno.Descripcion);

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

        public DataTable Listar()
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT enacom_tec_relacion.Id AS idRelacion, tecnologias.Id AS Id_Tecno, enacom_tec.id AS id_AccesoEnacom, CONCAT(tecnologias.Descripcion,' - ',enacom_tec.Descripcion) AS Tecnologia " +
                    "FROM enacom_tec_relacion " +
                    "LEFT JOIN enacom_tec ON enacom_tec.id = enacom_tec_relacion.Id_enacom_tec " +
                    "LEFT JOIN tecnologias ON tecnologias.Id = enacom_tec_relacion.id_tecnologia " +
                    "WHERE tecnologias.Borrado = 0");
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception)
            {

                throw;
            }
            return dt;

        }

        public void Eliminar(Int32 Id)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando(String.Format("UPDATE tecnologias SET Borrado = 1 WHERE Id = {0}", Id));
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

        public void GuardarRelacionEquipoTecnologia(int id_tipo, int id_relacion, string Tipo)
        {

            try
            {
                oCon.Conectar();
                oCon.CrearComando("INSERT INTO tipoaccesos(id_tipo , Id_enacom_tec_relacion, Tipo) " +
                    "VALUES(@idTipo,@idRelacion, @Tipo)");
                oCon.AsignarParametroEntero("@idTipo", id_tipo);
                oCon.AsignarParametroEntero("@idRelacion", id_relacion);
                oCon.AsignarParametroCadena("@Tipo", Tipo);
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

        public DataTable ListarRelacionEquipoTecnologia()
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();

                oCon.CrearComando("SELECT tipoaccesos.*,tecnologias.Descripcion AS Tecnologia, enacom_tec.Descripcion AS Acceso , enacom_tec_relacion.*  " +
                    "FROM tipoaccesos " +
                    "LEFT JOIN enacom_tec_relacion ON tipoaccesos.Id_enacom_tec_relacion = enacom_tec_relacion.Id " +
                    "LEFT JOIN tecnologias ON tecnologias.id = enacom_tec_relacion.id_tecnologia " +
                    "LEFT JOIN enacom_tec ON enacom_tec.id = enacom_tec_relacion.Id_enacom_tec " +
                    "WHERE tecnologias.Borrado = 0");
                dt = oCon.Tabla();
                oCon.DesConectar();

            }
            catch (Exception)
            {
                throw;
            }
            return dt;
        }

        public void EliminarRelacionTecnoEquipo(int Id_tipoacceso, int id_tipo)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando(String.Format("UPDATE tipoaccesos SET Borrado = 1 WHERE id_TipoAcceso = {0} AND id_Tipo = {1}", Id_tipoacceso, id_tipo));
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
