using CapaDatos;
using System;
using System.Data;

namespace CapaNegocios
{
    public class Partes_Historial
    {
        public Int32 Id { get; set; }
        public Int32 Id_Parte { get; set; }
        public Int32 Id_Personal { get; set; }
        public Int32 Id_Usuarios { get; set; }
        public Int32 Id_Partes_Estados { get; set; }
        public DateTime Fecha_Movimiento { get; set; }
        public String Detalles { get; set; }
        public Int32 Id_area { get; set; }
        public String NombreArea { get; set; }

        private Conexion oCon = new Conexion();

        public DataTable Listar(int id_parte)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("select partes_historial.id, id_parte, id_partes_estados, partes_historial.id_personal, partes_historial.id_usuarios, partes_historial.id_area, fecha_movimiento, partes_estados.nombre as parte_estado, detalles, personal.nombre as operador, personal_areas.nombre as area " +
                                  " from partes_historial left join partes_estados on partes_historial.id_partes_estados = partes_estados.id left join personal on partes_historial.id_personal = personal.id" +
                                  " left join personal_areas on partes_historial.id_area = personal_areas.id where id_parte =@id_parte");

                oCon.AsignarParametroEntero("@id_parte", id_parte);
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

        public Int32 GuardarNuevoDetalle(Partes_Historial oPartesHistorial)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("INSERT INTO partes_historial(id_parte, id_personal, id_usuarios, id_partes_estados, fecha_movimiento, detalles, id_area) " +
                    "VALUES(@id_parte, @id_personal, @id_usuarios, @id_partes_estados, @fecha_movimiento, @detalles, @id_area); SELECT @@IDENTITY");
                oCon.AsignarParametroEntero("@id_parte", oPartesHistorial.Id_Parte);
                oCon.AsignarParametroEntero("@id_personal", oPartesHistorial.Id_Personal);
                oCon.AsignarParametroEntero("@id_usuarios", oPartesHistorial.Id_Usuarios);
                oCon.AsignarParametroEntero("@id_partes_estados", oPartesHistorial.Id_Partes_Estados);
                oCon.AsignarParametroFecha("@fecha_movimiento", oPartesHistorial.Fecha_Movimiento);
                oCon.AsignarParametroCadena("@detalles", oPartesHistorial.Detalles);
                oCon.AsignarParametroEntero("@id_area", oPartesHistorial.Id_area);

                oCon.ComenzarTransaccion();
                oPartesHistorial.Id = oCon.EjecutarScalar();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
            }
            catch (Exception ex)
            {
                string msj = ex.Message;
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                throw;
            }

            return oPartesHistorial.Id;
        }
    }
}
