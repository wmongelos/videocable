using CapaDatos;
using System;
using System.Data;

namespace CapaNegocios
{
    public class Usuarios_Saldos_Locacion
    {
        public event PorcentajeHandler OnPorcentaje;

        private readonly Configuracion oConfig = new Configuracion();
        private readonly Conexion oCon = new Conexion();
        private readonly int FINAL_DATATABLE = -1;
        private decimal sumCtacte = 0;
        private decimal sumLocacion = 0;
        private int numeroRegistros;
        private int numeroRegistrosPorPorcentaje;
        private bool actualizando;

        public Usuarios_Saldos_Locacion()
        {
            OnPorcentaje = null;
            actualizando = false;
        }

        public void ActualizarSaldos(DataTable dtCtacteDet)
        {
            actualizando = true;

            if (OnPorcentaje != null)
            {
                DeterminarCantidadDeRegistrosPorPorcentaje(dtCtacteDet.Rows.Count);
            }

            if (dtCtacteDet == null || dtCtacteDet.Rows.Count == 0)
                return;

            int idCtaCteSiguiente = FINAL_DATATABLE;
            if (dtCtacteDet.Rows.Count > 1)
                idCtaCteSiguiente = Convert.ToInt32(dtCtacteDet.Rows[1]["id_ctacte"]);

            int idUsuarioLocSiguiente = FINAL_DATATABLE;
            if (dtCtacteDet.Rows.Count > 1)
                idUsuarioLocSiguiente = Convert.ToInt32(dtCtacteDet.Rows[1]["id_usu_locacion"]);

            try
            {
                oCon.Conectar();
                oCon.ComenzarTransaccion();
                int index = 0, porcentaje = 0;
                foreach (DataRow dr in dtCtacteDet.Rows)
                {
                    if (!actualizando)
                    {
                        oCon.CancelarTransaccion();
                        oCon.DesConectar();
                        return;
                    }

                    index++;
                    if(OnPorcentaje != null && numeroRegistros < 100)
                    {
                        int porcen = Convert.ToInt32(100 / numeroRegistros);
                        OnPorcentaje(++(porcen));
                    }
                    else if (OnPorcentaje != null && index % numeroRegistrosPorPorcentaje == 0)
                    {
                        OnPorcentaje(++porcentaje);
                    }

                    sumCtacte += Convert.ToDecimal(dr["importe_saldo_det"]);
                    sumLocacion += Convert.ToDecimal(dr["importe_saldo_det"]);


                    if (Convert.ToInt32(dr["id_ctacte"]) != idCtaCteSiguiente || idCtaCteSiguiente == FINAL_DATATABLE)
                    {
                        ActualizarSaldoCtacte(sumCtacte, Convert.ToInt32(dr["id_ctacte"]));
                        sumCtacte = 0;

                        if (Convert.ToInt32(dr["id_usu_locacion"]) != idUsuarioLocSiguiente || idUsuarioLocSiguiente == FINAL_DATATABLE)
                        {
                            ActualizarSaldoUsuarioLocacion(sumLocacion, Convert.ToInt32(dr["id_usu_locacion"]));
                            sumLocacion = 0;
                        }
                    }

                    ActualizarIdsSiguientes(index, ref idCtaCteSiguiente, ref idUsuarioLocSiguiente, dtCtacteDet);
                }
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                actualizando = false;
                throw;
            }
        }

        public void CancelarActualizacionDeSaldos()
        {
            actualizando = false;
        }

        private void ActualizarSaldoCtacte(decimal saldo, int idCtacte)
        { 
            try
            {
                string comando = "UPDATE usuarios_ctacte SET importe_saldo = @saldo" +
                    "WHERE usuarios_ctacte.id = @idCtacte";
                oCon.CrearComando(comando);
                oCon.AsignarParametroDecimal("@saldo", saldo);
                oCon.AsignarParametroEntero("@idCtacte", idCtacte);
                oCon.EjecutarComando();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ActualizarSaldoUsuarioLocacion(decimal saldo, int idUsuLocacion)
        {
            try
            {
                string comando = "UPDATE usuarios_locaciones SET saldo = @saldo " +
                    "WHERE usuarios_locaciones.id = @idUsuLoc";
                oCon.CrearComando(comando);
                oCon.AsignarParametroDecimal("@saldo", saldo);
                oCon.AsignarParametroEntero("@idUsuLoc", idUsuLocacion);
                oCon.EjecutarComando();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ActualizarIdsSiguientes(int index, ref int idCtaCteSiguiente, ref int idUsuarioLocSiguiente, DataTable dtCtacteDet)
        {
            if (index + 1 < dtCtacteDet.Rows.Count)
            {
                idCtaCteSiguiente = Convert.ToInt32(dtCtacteDet.Rows[index + 1]["id_ctacte"]);
                idUsuarioLocSiguiente = Convert.ToInt32(dtCtacteDet.Rows[index + 1]["id_usu_locacion"]);
            }
            else
            {
                idCtaCteSiguiente = FINAL_DATATABLE;
                idUsuarioLocSiguiente = FINAL_DATATABLE;
            }
        }

        private void DeterminarCantidadDeRegistrosPorPorcentaje(int cantidadDeRegistros)
        {
            numeroRegistros = cantidadDeRegistros;
            numeroRegistrosPorPorcentaje = Convert.ToInt32(Math.Ceiling(Convert.ToDecimal(numeroRegistros / 100)));
        }
    }
}
