using CapaDatos;
using System;
using System.Data;

namespace CapaNegocios
{
    public class Partes_Soluciones
    {
        public Int32 Id { get; set; }
        public Int32 Id_Servicios { get; set; }
        public Int32 Id_Partes_Operaciones { get; set; }
        public Int32 Id_Falla { get; set; }
        public String Nombre { get; set; }
        public Double Importe { get; set; }
        public Int32 Borrado { get; set; }

        private Conexion oCon = new Conexion();

        public void Guardar(Partes_Soluciones oPartes_Soluciones)
        {
            try
            {
                oCon.Conectar();

                if (oPartes_Soluciones.Id > 0)
                {
                    oCon.CrearComando("UPDATE partes_soluciones SET id_servicios=@servicios, id_partes_operaciones=@operaciones," +
                                      "id_falla=@falla, nombre=@nombre,importe=@importe WHERE id = @id");
                    oCon.AsignarParametroEntero("@id", oPartes_Soluciones.Id);
                }
                else
                {
                    oCon.CrearComando("INSERT INTO partes_soluciones (id_servicios,id_partes_operaciones,id_falla,nombre,importe) " +
                                      "VALUES (@servicios,@operaciones,@falla,@nombre,@importe)");
                }
                oCon.AsignarParametroEntero("@servicios", oPartes_Soluciones.Id_Servicios);
                oCon.AsignarParametroEntero("@operaciones", oPartes_Soluciones.Id_Partes_Operaciones);
                oCon.AsignarParametroEntero("@falla", oPartes_Soluciones.Id_Falla);
                oCon.AsignarParametroCadena("@nombre", oPartes_Soluciones.Nombre);
                oCon.AsignarParametroDouble("@importe", oPartes_Soluciones.Importe);
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
                oCon.CrearComando("SELECT * FROM partes_soluciones WHERE borrado=0");
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

        public DataTable ListarSolucionesPorFalla(int idFalla)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT id,id_servicios,id_partes_operaciones,id_falla,nombre,importe FROM partes_soluciones WHERE borrado=0 and id_falla='" + idFalla + "'");
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
                oCon.CrearComando("UPDATE partes_soluciones SET borrado = 1 WHERE id = @id");
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
    }
}
