using CapaDatos;
using System;
using System.Data;

namespace CapaNegocios
{
    public class Caja_Egreso
    {
        public Int32 id { get; set; }
        public Int32 idPuntoGestion { get; set; }
        public Int32 idCaja { get; set; }
        public Int32 idPersonal { get; set; }
        public Int32 idTipo { get; set; }
        public DateTime fecha { get; set; }
        public Decimal monto { get; set; }
        public String NumeroComprobante { get; set; }
        public String Detalle { get; set; }

        private Conexion oCon = new Conexion();

        public enum TiposEgresos
        {
            GASTO = 1,
            RETIRO = 2,
            VALE = 3
        }

        public void Guardar(Caja_Egreso oEgreso)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("INSERT INTO caja_egresos (id_Punto_Gestion,id_Personal,Fecha,Monto,Id_Tipo,Id_Caja,Numero_Comprobante,detalle) VALUES (@idPunto,@idPersonal,@fecha1,@monto1,@idTipo,@idCaja,@numeroComprobante,@detalle)");
                oCon.AsignarParametroEntero("@idPunto", oEgreso.idPuntoGestion);
                oCon.AsignarParametroEntero("@idPersonal", oEgreso.idPersonal);
                oCon.AsignarParametroFecha("@fecha1", oEgreso.fecha);
                oCon.AsignarParametroDecimal("@monto1", oEgreso.monto);
                oCon.AsignarParametroEntero("@idTipo", oEgreso.idTipo);
                oCon.AsignarParametroEntero("@idCaja", oEgreso.idCaja);
                oCon.AsignarParametroCadena("@numeroComprobante", oEgreso.NumeroComprobante);
                oCon.AsignarParametroCadena("@detalle", oEgreso.Detalle);

                oCon.EjecutarComando();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }
        }

        public DataTable Listar(int idCaja, int Id_Punto_Gestion)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT Caja_egresos.Id,Caja_egresos.id_Punto_Gestion,Caja_egresos.id_Personal,Caja_egresos.Fecha,Caja_egresos.Monto,IF(Caja_egresos.Id_Tipo=1,'GASTO','RETIRO')AS tipo,Caja_egresos.Id_Caja,Caja_egresos.Numero_Comprobante,puntos_cobros.descripcion,personal.nombre, Caja_egresos.detalle FROM Caja_egresos"
                + " inner join puntos_cobros on puntos_cobros.id = caja_egresos.id_punto_gestion"
                + " inner join personal on personal.id = caja_egresos.id_personal"
                + "  WHERE Id_Caja =@idCaja and caja_egresos.id_punto_gestion=@gestion and Caja_egresos.borrado=0");

                oCon.AsignarParametroEntero("@idCaja", idCaja);
                oCon.AsignarParametroEntero("@gestion", Id_Punto_Gestion);
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();

            }
            return dt;

        }

        public void ActualizarEgresosCajas(int idCaja)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("update caja_egresos set id_caja=@idcaja where id_Caja=0 and id_punto_gestion=@idpunto");
                oCon.AsignarParametroEntero("@idpunto", Puntos_Cobros.Id_Punto);
                oCon.AsignarParametroEntero("@idcaja", idCaja);
                oCon.ComenzarTransaccion();
                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();

            }
            catch (Exception e)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                throw;
            }
        }

        public Int32 ElininarEgreso(int id)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("UPDATE caja_egresos set borrado=1,id_personal=@personal where id=@id");
                oCon.AsignarParametroEntero("@personal", Personal.Id_Login);
                oCon.AsignarParametroEntero("@id", id);
                oCon.ComenzarTransaccion();
                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
                return 0;
            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                return -1;
                throw;
            }

        }
    
        public bool MontoRetirado(int idCaja,out decimal monto, out string salida)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT sum(monto) as retirado from caja_egresos where id_caja = @caja and borrado=0");
                oCon.AsignarParametroEntero("@caja", idCaja);
                dt = oCon.Tabla();
                oCon.DesConectar();
                if (dt.Rows.Count > 0)
                    monto = Convert.ToDecimal(dt.Rows[0]["retirado"]);
                else
                    monto = 0;
                salida = "";
                return true;
            }
            catch (Exception c)
            {
                oCon.DesConectar();
                salida = c.ToString();
                monto = 0;
                return false;
            }
        }
    }

}
