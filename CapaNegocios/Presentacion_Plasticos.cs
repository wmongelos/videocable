using CapaDatos;
using System;
using System.Data;

namespace CapaNegocios
{
    public class Presentacion_Plasticos
    {
        public int Id { get; set; }
        public int Id_Presentacion { get; set; }
        public int Id_Plastico { get; set; }
        public int Id_Estado { get; set; }
        public decimal Monto_Estimado { get; set; }
        public decimal Monto_Deuda_Adelantada { get; set; }
        public decimal Monto_Deuda_Atrasada { get; set; }
        public decimal Monto_Prefacturacion { get; set; }

        private Conexion oCon = new Conexion();

        public enum ESTADO
        {
            PAGO_PENDIENTE = 1,
            CONTRACARGO = 2,
            RECHAZADO = 3,
            PAGADO = 4
        }

        public int Guardar(Presentacion_Plasticos oPresentacionPlasticos)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("insert into presentacion_plasticos(id_presentacion, id_plastico, id_estado, monto_estimado, monto_prefacturacion, monto_deuda_adelantada, monto_deuda_atrasada) VALUES" +
                                       "(@id_presentacion, @id_plastico, @id_estado, @monto_estimado, @monto_prefacturacion, @monto_deuda_adelantada, @monto_deuda_atrasada); SELECT @@IDENTITY");
                oCon.AsignarParametroEntero("@id_presentacion", oPresentacionPlasticos.Id_Presentacion);
                oCon.AsignarParametroEntero("@id_plastico", oPresentacionPlasticos.Id_Plastico);
                oCon.AsignarParametroEntero("@id_estado", oPresentacionPlasticos.Id_Estado);
                oCon.AsignarParametroDecimal("@monto_estimado", oPresentacionPlasticos.Monto_Estimado);
                oCon.AsignarParametroDecimal("@monto_prefacturacion", oPresentacionPlasticos.Monto_Prefacturacion);
                oCon.AsignarParametroDecimal("@monto_deuda_adelantada", oPresentacionPlasticos.Monto_Deuda_Adelantada);
                oCon.AsignarParametroDecimal("@monto_deuda_atrasada", oPresentacionPlasticos.Monto_Deuda_Atrasada);
                oCon.ComenzarTransaccion();
                oPresentacionPlasticos.Id = oCon.EjecutarScalar();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                throw;
            }
            return oPresentacionPlasticos.Id;
        }
        public DataTable Listar(int id_presentacion)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando(String.Format("select * from vw_presentacion_plasticos where id_presentacion={0} limit 10", id_presentacion));
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
        public DataTable GetEstructuraPresentacionPlasticos()
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando(String.Format("select * from vw_presentacion_plasticos where id_presentacion=0"));
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
        public void ActualizarEstado(int idPresentacionPlastico, int idPlastico, int idEstado)
        {
            try
            {
                oCon.Conectar();
                oCon.ComenzarTransaccion();
                oCon.CrearComando("UPDATE presentacion_plasticos SET id_estado = @id_estado WHERE id_presentacion = @id_presentacion and id_plastico=@id_plastico");
                oCon.AsignarParametroEntero("@id_estado", idEstado);
                oCon.AsignarParametroEntero("@id_presentacion", idPresentacionPlastico);
                oCon.AsignarParametroEntero("@id_plastico", idPlastico);
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
