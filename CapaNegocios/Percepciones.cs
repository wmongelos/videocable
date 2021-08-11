using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CapaNegocios
{
    public class Percepciones
    {
        private static Configuracion oConfig = new Configuracion();
        private static decimal IvaDivide = 1.21m;

        public static void CalcularPercepcionesEnDtFinal(DataTable dtfinal, bool modificarImportesPagos = true)
        {
            bool calculaPercepcion = true;
            string mensaje = "";
            int idCtacte = 0;
            decimal impuestoProvincial = 0;
            Facturacion oFacturacion = new Facturacion();

            foreach (DataRow dr in dtfinal.Rows)
            {
                idCtacte = Convert.ToInt32(dr["id_usuarios_ctacte"]);

                if (!Convert.ToBoolean(dr["elige"]))
                    continue;

                if (Convert.ToInt32(dr["encabezado"]) == 2 && Convert.ToInt32(dr["percepcion"]) == 1)
                {
                    calculaPercepcion = true;
                }
                else if (Convert.ToInt32(dr["encabezado"]) == 2 && Convert.ToInt32(dr["percepcion"]) != 1)
                {
                    calculaPercepcion = false;
                }

                if (oFacturacion.PlanDePagoFactura(idCtacte, out mensaje) == true)
                {
                    dr["elige"] = true;
                    dr["importe_pago"] = 1;
                    dr["importe_total"] = Convert.ToDecimal(dr["importe_saldo"].ToString());

                }
                if (mensaje != "")
                    calculaPercepcion = false;


                if (calculaPercepcion)
                {
                    if (Convert.ToInt32(dr["Id_Comprobantes_Tipo"].ToString()) != (int)Comprobantes_Tipo.Tipo.CREDITO_A_CUENTA)
                    {
                        if (Convert.ToInt32(dr["presenta_ventas"].ToString()) == 0)
                        {
                            DataTable dtDinamica = new DataTable();
                            Usuarios oUsu = new Usuarios();
                            dtDinamica.Clear();
                            int id_usuario = 0;
                            id_usuario = Convert.ToInt32(dr["id_usuarios"].ToString());
                            dtDinamica =  oUsu.ObtenerPercepcionEspecialActual(id_usuario);
                            Decimal NetoLinea = Decimal.Round((Convert.ToDecimal(dr["importe_original"].ToString()) - Convert.ToDecimal(dr["importe_bonificacion"].ToString())) / IvaDivide, 2);
                            if (dtDinamica.Rows.Count > 0)
                            {
                                impuestoProvincial = Convert.ToDecimal(dtDinamica.Rows[0]["percepcion_esp"].ToString());
                                dr["importe_provincial"]= Decimal.Round(NetoLinea * impuestoProvincial / 100 , 2);
                            }
                            else
                            { 
                                dr["importe_provincial"] = 0;                             
                                if (Usuarios.CurrentUsuarioDomFiscal.Id > 0)
                                {
                                    dr["importe_provincial"] = Decimal.Round(NetoLinea * Usuarios.CurrentUsuarioDomFiscal.ImpuestoProvincial / 100, 2);
                                }
                                else
                                {
                                    dr["importe_provincial"] = Decimal.Round(NetoLinea * Usuarios.CurrentUsuario.Impuesto_Provincial / 100, 2);
                                }
                                if ((Usuarios.CurrentUsuario.Condicion_Iva != "CONSUMIDOR FINAL" && Convert.ToDecimal(dr["importe_provincial"]) == 0) && (Usuarios.CurrentUsuario.Exento_Impuesto_Provincial != Convert.ToInt32(Usuarios_Dom_Fiscal.CondicionARBA.Exento)))
                                {
                                    dr["importe_provincial"] = Decimal.Round(NetoLinea * oConfig.GetValor_N("Retencion_IIBB") / 100, 2);
                                }
                            }
                        }
                    }
                }

                decimal importeTotal = Convert.ToDecimal(dr["importe_saldo"].ToString()) + Convert.ToDecimal(dr["importe_Provincial"].ToString());
                dr["importe_total"] = importeTotal;

                if (modificarImportesPagos)
                {
                    if (Convert.ToBoolean(dr["elige"].ToString()) == true)
                        dr["importe_pago"] = Convert.ToDecimal(dr["importe_total"].ToString());
                    else
                        dr["importe_pago"] = 0;
                } 
            }
        }
    }
}