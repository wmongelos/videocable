using CapaDatos;
using System;
using System.Data;

namespace CapaNegocios
{
    public class Bonificaciones_Condiciones_Porcentaje
    {
        public Int32 Id { get; set; }
        public Int32 Id_Condicion { get; set; }
        public decimal Porcentaje { get; set; }
        public string Item_Desde { get; set; }
        public string Limite_Desde { get; set; }
        public string Item_Hasta { get; set; }
        public string Limite_Hasta { get; set; }
        public Int32 Borrado { get; set; }

        private Conexion oCon = new Conexion();

        public void Guardar(Bonificaciones_Condiciones_Porcentaje oBonificacionPorcentajes)
        {
            try
            {
                oCon.Conectar();
                if (oBonificacionPorcentajes.Id > 0)
                {
                    oCon.CrearComando("UPDATE bonificaciones_condiciones_porcentaje SET id_condicion=@id_condicion, porcentaje=@porcentaje, item_desde=@item_desde, limite_desde=@limite_desde, item_hasta=@item_hasta, limite_hasta= @limite_hasta,id_personal=@personal where id=@id");
                    oCon.AsignarParametroEntero("@id_condicion", oBonificacionPorcentajes.Id_Condicion);
                    oCon.AsignarParametroDecimal("@porcentaje", oBonificacionPorcentajes.Porcentaje);
                    oCon.AsignarParametroCadena("@item_desde", oBonificacionPorcentajes.Item_Desde);
                    oCon.AsignarParametroCadena("@limite_desde", oBonificacionPorcentajes.Limite_Desde);
                    oCon.AsignarParametroCadena("@item_hasta", oBonificacionPorcentajes.Item_Hasta);
                    oCon.AsignarParametroCadena("@limite_hasta", oBonificacionPorcentajes.Limite_Hasta);
                    oCon.AsignarParametroEntero("@personal", Personal.Id_Login);
                    oCon.AsignarParametroEntero("@id", oBonificacionPorcentajes.Id);
                }
                else
                {
                    oCon.CrearComando("INSERT INTO bonificaciones_condiciones_porcentaje(id_condicion, porcentaje, item_desde, limite_desde, item_hasta, limite_hasta,id_personal) values(@id_condicion, @porcentaje, @item_desde, @limite_desde, @item_hasta, @limite_hasta,@personal)");

                    oCon.AsignarParametroEntero("@id_condicion", oBonificacionPorcentajes.Id_Condicion);
                    oCon.AsignarParametroDecimal("@porcentaje", oBonificacionPorcentajes.Porcentaje);
                    oCon.AsignarParametroCadena("@item_desde", oBonificacionPorcentajes.Item_Desde);
                    oCon.AsignarParametroCadena("@limite_desde", oBonificacionPorcentajes.Limite_Desde);
                    oCon.AsignarParametroCadena("@item_hasta", oBonificacionPorcentajes.Item_Hasta);
                    oCon.AsignarParametroCadena("@limite_hasta", oBonificacionPorcentajes.Limite_Hasta);
                    oCon.AsignarParametroEntero("@personal", Personal.Id_Login);
                }
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

        public void Eliminar(int id)
        {
            try
            {
                oCon.Conectar();
                oCon.ComenzarTransaccion();
                oCon.CrearComando("UPDATE bonificaciones_condiciones_porcentaje SET Borrado = 1,id_personal=@personal WHERE Id = @id");
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

        public DataTable ListarPorIdCondicion(int Id)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando(String.Format("select id, id_condicion, porcentaje, concat('Desde el item ',limite_desde,' ',item_desde) as desde, if(limite_hasta='0','',concat('Hasta el item ',limite_hasta,' ',item_hasta)) as hasta, limite_desde, item_desde, limite_hasta, item_hasta, 2 as operacion from bonificaciones_condiciones_porcentaje where id_condicion={0} and borrado=0", Id));
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch
            {
                oCon.DesConectar();
            }

            return dt;
        }
    }
}
