using CapaDatos;
using System;
using System.Data;

namespace CapaNegocios
{
    public class Usuarios_Ctacte_Det_Extra
    {
        private Conexion oCon = new Conexion();

        public Int32 Id;
        public Int32 Id_Usuarios_CtaCte_Det;
        public Int32 Id_Tipo_Extra;
        public Int32 Id_Extra;
        public Decimal Importe_Nuevo;
        public Decimal Importe_original;
        public Decimal Porcentaje;
        public String Extra;
        public String Detalle;

        public enum TiposExtras
        {
            NOVEDAD = 1,
            BONIFICACION = 2,
            EXTRA = 3
        }
        public void Guardar(Usuarios_Ctacte_Det_Extra oDetExtra)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("INSERT INTO usuarios_ctacte_det_extras (id_usuario_ctacte_det,id_tipo_extra,id_extra,extra,importe_original,importe_con_descuento,porcentaje,detalle) VALUES (@id_usuario_ctacte_det1,@id_tipo_extra1,@id_extra1, @extra1,@importe_original1,@importe_con_descuento1,@porcentaje1,@detalle1)");
                oCon.AsignarParametroEntero("@id_usuario_ctacte_det1", oDetExtra.Id_Usuarios_CtaCte_Det);
                oCon.AsignarParametroEntero("@id_tipo_extra1", oDetExtra.Id_Tipo_Extra);
                oCon.AsignarParametroEntero("@id_extra1", oDetExtra.Id_Extra);
                oCon.AsignarParametroCadena("@extra1", oDetExtra.Extra);
                oCon.AsignarParametroDecimal("@importe_original1", oDetExtra.Importe_original);
                oCon.AsignarParametroDecimal("@importe_con_descuento1", oDetExtra.Importe_Nuevo);
                oCon.AsignarParametroDecimal("@porcentaje1", oDetExtra.Porcentaje);
                oCon.AsignarParametroCadena("@detalle1", oDetExtra.Detalle);
                oCon.ComenzarTransaccion();
                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
            }
        }
        public DataTable ListarExtrasDet(Int32 idCtacteDet)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT id,id_usuario_ctacte_det,id_tipo_extra,id_extra,CASE"
                    + " WHEN id_Tipo_extra = 1 THEN 'NOVEDADES'"
                    + " WHEN id_Tipo_extra = 2 THEN 'BONIFICACION'"
                    + " WHEN id_Tipo_extra = 2 THEN 'EXTRA'"
                    + " END extra, importe_original,importe_con_descuento,porcentaje,detalle, (importe_original-importe_con_descuento) as descuento FROM usuarios_ctacte_det_extras WHERE id_usuario_ctacte_det=@id_det and borrado=0");
                oCon.AsignarParametroEntero("@id_det", idCtacteDet);
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
