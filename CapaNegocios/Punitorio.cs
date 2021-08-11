using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;

namespace CapaNegocios
{
    public delegate void PorcentajeHandler(int numero);

    public class Punitorio
    {
        public event PorcentajeHandler OnPorcentaje;

        private const string LogPath = @"C:\GIES\punitorios_log";

        private readonly Configuracion oConfig = new Configuracion();
        private readonly Conexion oCon = new Conexion();
        private readonly int FINAL_DATATABLE = -1;
        private readonly decimal punitoriosPorcentajeMensual;
        private readonly int diasDeTolerancia;
        private DateTime fechaDesdePuedeCalcular;
        private DateTime fechaHasta;
        private int numeroRegistros;
        private int numeroRegistrosPorPorcentaje;
        private bool actualizando;
        private bool _bonificar;
        private bool escribirLog;
        private string rutaLog;

        public Punitorio()
        {
            punitoriosPorcentajeMensual = oConfig.GetValor_Decimal("Punitorios_Porcentaje");
            diasDeTolerancia = oConfig.GetValor_N("Punitorios_Tolerancia");
            fechaDesdePuedeCalcular = Convert.ToDateTime(oConfig.GetValor_C("FechaAPartirCalculaPunitorio"));
            OnPorcentaje = null;
            actualizando = false;
            escribirLog = false;
        }

        public void ActualizarPunitorios(DataTable dtCtacteDet, int idUsuarioCtacteACalcular = 0, DateTime? calcularHasta = null)
        {
            actualizando = true;

            if (!calcularHasta.HasValue)
                this.fechaHasta = DateTime.Now;
            else
                this.fechaHasta = calcularHasta.Value.Date;

            if (OnPorcentaje != null)
            {
                DeterminarCantidadDeRegistrosPorPorcentaje(dtCtacteDet.Rows.Count);
            }

            int idCtaCteSiguiente = FINAL_DATATABLE;
            if (dtCtacteDet.Rows.Count > 1)
                idCtaCteSiguiente = Convert.ToInt32(dtCtacteDet.Rows[1]["id_ctacte"]);

            int idUsuarioLocSiguiente = FINAL_DATATABLE;
            if (dtCtacteDet.Rows.Count > 1)
                idUsuarioLocSiguiente = Convert.ToInt32(dtCtacteDet.Rows[1]["id_usu_locacion"]);

            decimal sumaSaldoUsuarioLocacion = 0;
            decimal punitorioSumaCtacte = 0;
            decimal punitorioCtacte = 0;
            int cantidadDiasPunitorio = 0;

            if (Directory.Exists(LogPath))
            {
                escribirLog = true;
                rutaLog = Path.Combine(LogPath, $"{DateTime.Now.ToString("yyyy-MM-dd")}.txt");
                File.Create(rutaLog).Close();
                EscribirLog($"-->Inicio del proceso: {DateTime.Now}");
                EscribirLog($"Cantidad total de registros: {dtCtacteDet.Rows.Count}");
                EscribirLog("Referencias:");
                EscribirLog("DET: ID_Usuario, ID_Ctacte, ID_Ctacte_Det, ID_Comprobante_Tipo, Importe_Saldo_Det, Importe_Punitorio, Pudo_Calcular_Punitorio, Punitorio_Calculado, Dias_Punitorio");
                EscribirLog("CTACTE: ID_Usuario, ID_Ctacte, ID_Comprobante_Tipo, Suma_Punitorios_Ctacte");
                EscribirLog("LOCACION: ID_Usuario, Suma_Saldo_Locacion");
                EscribirLog("********************************************");
            }

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
                    if (OnPorcentaje != null && index % numeroRegistrosPorPorcentaje == 0)
                    {
                        OnPorcentaje(++porcentaje); 
                    }
                    punitorioCtacte = 0;
                    sumaSaldoUsuarioLocacion += Convert.ToDecimal(dr["importe_saldo_det"]) - Convert.ToDecimal(dr["importe_punitorio"]);

                    bool pudoCalcular = false;
                    if (PuedeCalcularPunitorio(dr, idUsuarioCtacteACalcular))
                    {
                        Dictionary<string, decimal> resultado = CalcularPunitorio(Convert.ToDateTime(dr["fecha_desde"]), Convert.ToDecimal(dr["importe_saldo_det"]), Convert.ToDecimal(dr["importe_punitorio"]));
                        punitorioCtacte = resultado["punitorio"];
                        cantidadDiasPunitorio = (int)resultado["cantidadDias"];
                        pudoCalcular = true;
                    }
                    else
                    {
                        punitorioCtacte = 0;
                        cantidadDiasPunitorio = 0;
                    }
                    punitorioSumaCtacte += punitorioCtacte;
                    sumaSaldoUsuarioLocacion += punitorioCtacte;
                    GuardarPunitorioCtacteDet(punitorioCtacte, Convert.ToInt32(dr["id_ctacte_Det"]));

                    EscribirLog($"DET - {dr["id_usuarios"]} - {dr["id_ctacte"]} - *{dr["id_ctacte_det"]} - {dr["id_comprobantes_tipo"]} - {dr["importe_saldo_det"]} - {dr["importe_punitorio"]} - {pudoCalcular} - {punitorioCtacte} - {cantidadDiasPunitorio}");

                    if (Convert.ToInt32(dr["id_ctacte"]) != idCtaCteSiguiente || 
                        idCtaCteSiguiente == FINAL_DATATABLE && ElCtacteEsCeroOIgual(Convert.ToInt32(dr["id_ctacte"]), idUsuarioCtacteACalcular))
                    {
                        GuardarPunitorioCtacte(punitorioSumaCtacte, Convert.ToInt32(dr["id_ctacte"]), cantidadDiasPunitorio);
                        EscribirLog($"CTACTE - {dr["id_usuarios"]} - {dr["id_ctacte"]} - {dr["id_comprobantes_tipo"]} - {punitorioSumaCtacte}");
                        punitorioSumaCtacte = 0;

                        if (Convert.ToInt32(dr["id_usu_locacion"]) != idUsuarioLocSiguiente || idUsuarioLocSiguiente == FINAL_DATATABLE)
                        {
                            ActualizarSaldoLocacion(Convert.ToInt32(dr["id_usu_locacion"]), sumaSaldoUsuarioLocacion);
                            EscribirLog($"LOCACION - {dr["id_usuarios"]} - {sumaSaldoUsuarioLocacion}");
                            sumaSaldoUsuarioLocacion = 0;
                        }
                    }

                    //Cambia valor de idUsuariosLocSiguiente y idCtaCteSiguiente
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
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
                EscribirLog($"-->Fin del proceso: {DateTime.Now}");
                actualizando = false;
            }
            catch (Exception ex)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                actualizando = false;
                EscribirLog($"Error: {ex.Message}");
                throw ex;
            }
        }

        public void CancelarActualizacionDePunitorios()
        {
            actualizando = false;
        }

        public void RecalcularPunitorio(DataTable dtCtacteDet, int idCtacte, bool bonificar, DateTime? calcularHasta = null)
        {
            if (!calcularHasta.HasValue)
                this.fechaHasta = DateTime.Now;
            else
                this.fechaHasta = calcularHasta.Value.Date;

            _bonificar = bonificar;
            int idCtaCteSiguiente = FINAL_DATATABLE;
            if (dtCtacteDet.Rows.Count > 1)
                idCtaCteSiguiente = Convert.ToInt32(dtCtacteDet.Rows[1]["id_ctacte"]);

            int idUsuarioLocSiguiente = FINAL_DATATABLE;
            if (dtCtacteDet.Rows.Count > 1)
                idUsuarioLocSiguiente = Convert.ToInt32(dtCtacteDet.Rows[1]["id_usu_locacion"]);

            decimal sumaSaldoUsuarioLocacion = 0;
            decimal punitorioSumaCtacte = 0;
            decimal punitorioCtacte = 0;
            int cantidadDiasPunitorio = 0;
            try
            {
                oCon.Conectar();
                oCon.ComenzarTransaccion();
                int index = 0;
                foreach (DataRow dr in dtCtacteDet.Rows)
                {
                    index++;
                    if (Convert.ToInt32(dr["id_ctacte"]) == idCtacte)
                        sumaSaldoUsuarioLocacion += Convert.ToDecimal(dr["importe_saldo_det"]) - Convert.ToDecimal(dr["importe_punitorio"]);
                    else
                        sumaSaldoUsuarioLocacion += Convert.ToDecimal(dr["importe_saldo_det"]);

                    if (PuedeCalcularPunitorio(dr, idCtacte))
                    {
                        if (!bonificar)
                        {
                            Dictionary<string, decimal> resultado = CalcularPunitorio(Convert.ToDateTime(dr["fecha_desde"]), Convert.ToDecimal(dr["importe_saldo_det"]), Convert.ToDecimal(dr["importe_punitorio"]));
                            punitorioCtacte = resultado["punitorio"];
                            cantidadDiasPunitorio = (int)resultado["cantidadDias"];

                            punitorioSumaCtacte += punitorioCtacte;
                            sumaSaldoUsuarioLocacion += punitorioCtacte;
                        }
                        GuardarPunitorioCtacteDet(punitorioCtacte, Convert.ToInt32(dr["id_ctacte_Det"]));
                    }

                    if (Convert.ToInt32(dr["id_ctacte"]) == idCtacte && Convert.ToInt32(dr["id_ctacte"]) != idCtaCteSiguiente ||
                        idCtaCteSiguiente == FINAL_DATATABLE && ElCtacteEsCeroOIgual(Convert.ToInt32(dr["id_ctacte"]), idCtacte))
                    {
                        GuardarPunitorioCtacte(punitorioSumaCtacte, Convert.ToInt32(dr["id_ctacte"]), cantidadDiasPunitorio);
                        punitorioSumaCtacte = 0;
                    }

                    if (idUsuarioLocSiguiente == FINAL_DATATABLE)
                    {
                        ActualizarSaldoLocacion(Convert.ToInt32(dr["id_usu_locacion"]), sumaSaldoUsuarioLocacion);
                        sumaSaldoUsuarioLocacion = 0;
                    }

                    //Cambia valor de idUsuariosLocSiguiente y idCtaCteSiguiente
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
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
                actualizando = false;
            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                actualizando = false;
                throw;
            }
        }   

        private Dictionary<string, decimal> CalcularPunitorio(DateTime fechaDesde, decimal importe_saldo_Det, decimal importe_punitorio)
        {
            Dictionary<string, decimal> resultado = new Dictionary<string, decimal>();
            resultado.Add("cantidadDias", 0);
            resultado.Add("punitorio", 0);

            if ((fechaHasta.Year > fechaDesde.Year ||
               (fechaHasta.Year == fechaDesde.Year &&
                fechaHasta.Month > fechaDesde.Month)) &&
                fechaDesde >= fechaDesdePuedeCalcular)
            {
                int diasACalcular = (int)(fechaHasta - fechaDesde).TotalDays - diasDeTolerancia;
                decimal punitorio = decimal.Round((importe_saldo_Det - importe_punitorio) * ((punitoriosPorcentajeMensual / 30) * diasACalcular) / 100, 2);

                resultado["cantidadDias"] = diasACalcular;
                resultado["punitorio"] = punitorio;
            }

            return resultado;
        }

        private bool PuedeCalcularPunitorio(DataRow dr, int idUsuarioCtacteAVerificar)
        {
            if (_bonificar)
            {
                return ElCtacteEsCeroOIgual(Convert.ToInt32(dr["id_ctacte"]), idUsuarioCtacteAVerificar);
            }
            else
            {
                DataRow drServicio;
                DataRow[] drs;
                bool categoriaConPunitorio, modalidadConPunitorio, calcula;

                calcula = ElCtacteEsCeroOIgual(Convert.ToInt32(dr["id_ctacte"]), idUsuarioCtacteAVerificar);

                try 
                { 
                    //Si la modalidad genera punitorio
                    drServicio = Tablas.DataServicios.Select($"id = {Convert.ToInt32(dr["id_Servicios"])}")[0];
                    drs = Tablas.DataServicios_Modalidades.Select($"id = {Convert.ToInt32(drServicio["id_servicios_modalidad"])}");
                    modalidadConPunitorio = Convert.ToInt32(drs[0]["genera_punitorio"]) == 1 ? true : false;

                    //Si la categoria genera punitorio
                    drs = Tablas.DataServiciosCategorias.Select($"id = {Convert.ToInt32(dr["id_servicios_categorias"])}");
                    categoriaConPunitorio = Convert.ToInt32(drs[0]["genera_punitorio"]) == 1 ? true : false;
                }
                catch
                {
                    modalidadConPunitorio = false;
                    categoriaConPunitorio = false;
                }

                return (calcula && modalidadConPunitorio && categoriaConPunitorio && Convert.ToInt32(dr["id_debito_asociado"]) == 0);
            }
        }

        private void GuardarPunitorioCtacteDet(decimal punitorio, int idCtaCteDet)
        {
            try
            {
                string comando = "UPDATE usuarios_ctacte_det "
                               + " SET usuarios_ctacte_det.importe_punitorio_anterior = usuarios_ctacte_det.importe_punitorio," 
                               + " usuarios_ctacte_det.Importe_Punitorio = @pun, "
                               + " usuarios_ctacte_det.importe_final = usuarios_ctacte_det.importe_original - usuarios_Ctacte_det.importe_bonificacion + usuarios_ctacte_det.importe_provincial + @unp,"
                               + " usuarios_ctacte_det.importe_saldo = usuarios_ctacte_det.importe_final - importe_pago"
                               + " WHERE usuarios_ctacte_det.id = @idctactedet";
                oCon.CrearComando(comando);
                oCon.AsignarParametroDecimal("@pun", punitorio);
                oCon.AsignarParametroDecimal("@unp", punitorio);
                oCon.AsignarParametroEntero("@idctactedet", idCtaCteDet);
                oCon.EjecutarComando();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void GuardarPunitorioCtacte(decimal punitorio, int idCtacte, int diasPunitorio)
        {
            try
            {
                string comando = "UPDATE usuarios_ctacte"
                                + " SET usuarios_ctacte.importe_punitorio_anterior = usuarios_ctacte.importe_punitorio," 
                                + " usuarios_ctacte.Importe_Punitorio = @pun,"
                                + " usuarios_ctacte.importe_final = usuarios_ctacte.importe_original - usuarios_ctacte.importe_bonificacion + usuarios_ctacte.importe_provincial + @npu,"
                                + " usuarios_ctacte.importe_saldo = usuarios_ctacte.importe_final - importe_pago,"
                                + " usuarios_ctacte.dias_punitorio = @diasPuni "
                                + " WHERE usuarios_ctacte.Id = @idctacte";
                oCon.CrearComando(comando);
                oCon.AsignarParametroDecimal("@pun", punitorio);
                oCon.AsignarParametroDecimal("@npu", punitorio);
                oCon.AsignarParametroEntero("@idctacte", idCtacte);
                oCon.AsignarParametroEntero("@diasPuni", diasPunitorio);
                oCon.EjecutarComando();
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ActualizarSaldoLocacion(int idUsuLocacion, decimal saldoUsuarioLocacion)
        {
            try
            {
                string comando = "UPDATE usuarios_locaciones SET Saldo = @saldo WHERE id = @idUsuLoc;";
                oCon.CrearComando(comando);
                oCon.AsignarParametroDecimal("@saldo", saldoUsuarioLocacion);
                oCon.AsignarParametroEntero("@idUsuLoc", idUsuLocacion);
                oCon.EjecutarComando();
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void DeterminarCantidadDeRegistrosPorPorcentaje(int cantidadDeRegistros)
        {
            if(cantidadDeRegistros < 100)
            {
                numeroRegistros = cantidadDeRegistros;
                numeroRegistrosPorPorcentaje = 100 / numeroRegistros;
            }
            else
            {
                numeroRegistros = cantidadDeRegistros;
                numeroRegistrosPorPorcentaje = numeroRegistros / 100;
            }
        }

        private bool ElCtacteEsCeroOIgual(int currentUsuarioCtacte, int usuarioCtacteAVerificar)
        {
            if (usuarioCtacteAVerificar == 0 || currentUsuarioCtacte == usuarioCtacteAVerificar)
                return true;
            return false;
        }

        private void EscribirLog(string log)
        {
            if (escribirLog)
            {
                List<string> lines = new List<string> { log };
                File.AppendAllLines(rutaLog, lines);
            }
        }

        public DataTable ListarIncongruencias()
        {
            try
            {
                string comando = "SELECT * FROM"
                + " (SELECT "
                + " usuarios_ctacte.id as id_ctacte,"
                + " usuarios_ctacte.importe_punitorio as punitorio_ctacte,"
                + " sum(usuarios_ctacte_det.importe_punitorio) as punitorio_ctacte_det,"
                + " sum(usuarios_ctacte_det.importe_saldo) as saldo_det,"
                + " usuarios_ctacte.importe_saldo as saldo_ctacte,"
                + " usuarios_ctacte.id_usuarios,"
                + " usuarios.codigo,"
                + " usuarios_ctacte.descripcion"
                + " FROM usuarios_ctacte_det"
                + " LEFT JOIN usuarios_ctacte ON usuarios_ctacte.id = usuarios_ctacte_det.id_usuarios_ctacte"
                + " INNER JOIN usuarios ON usuarios.id = usuarios_ctacte.id_usuarios"
                + " WHERE usuarios_ctacte.borrado = 0 and usuarios_ctacte_det.borrado = 0 and"
                + " usuarios_ctacte_det.importe_punitorio != 0"
                + " GROUP BY id_ctacte) T"
                + " WHERE T.punitorio_ctacte != T.punitorio_ctacte_det AND saldo_det > 0 AND saldo_ctacte > 0";

                oCon.Conectar();
                oCon.CrearComando(comando);
                DataTable dt = oCon.Tabla();
                oCon.DesConectar();

                return dt;
            }
            catch (Exception ex)
            {
                oCon.DesConectar();
                throw ex;
            }
        }

    }
}



