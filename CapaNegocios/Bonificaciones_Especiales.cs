using CapaDatos;
using System;
using System.Data;

namespace CapaNegocios
{
    public class Bonificaciones_Especiales
    {
        public Int32 Id { get; set; }
        public String Nombre { get; set; }
        public Decimal Porcentaje { get; set; }
        public Int32 Id_Servicios_Grupo { get; set; }
        public Int32 Borrado { get; set; }

        private Conexion oCon = new Conexion();

        public void Guardar(Bonificaciones_Especiales oBoni)
        {
            try
            {
                oCon.Conectar();

                if (oBoni.Id > 0)
                {
                    oCon.CrearComando("UPDATE Bonificaciones_Especiales set Nombre = @nombre, Porcentaje = @porcen, Id_Servicios_Grupos = @grupo WHERE Id = @id");
                    oCon.AsignarParametroEntero("@id", oBoni.Id);
                }
                else
                    oCon.CrearComando("INSERT Bonificaciones_Especiales(Nombre, Porcentaje, Id_Servicios_Grupos) VALUES(@nombre, @porcen, @grupo)");

                oCon.AsignarParametroCadena("@nombre", oBoni.Nombre);
                oCon.AsignarParametroDecimal("@porcen", oBoni.Porcentaje);
                oCon.AsignarParametroEntero("@grupo", oBoni.Id_Servicios_Grupo);

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
                oCon.CrearComando("SELECT *,(SELECT nombre from Servicios_Grupos WHERE Id = Id_Servicios_Grupos) AS Grupo FROM Bonificaciones_Especiales WHERE Borrado = 0 ORDER BY Id");
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
                oCon.CrearComando("UPDATE Bonificaciones_Especiales SET Borrado = 1 WHERE Id = @id");
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
