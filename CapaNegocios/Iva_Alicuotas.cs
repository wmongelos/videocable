using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;

namespace CapaNegocios
{
    public class Iva_Alicuotas
    {
        public static DataTable dtIvaAlicuotas;

        public enum IVA_ALICUOTAS
        {
            IVA21 = 1,
            IVA105 = 3
        }

        private Conexion oCon = new Conexion();

        public DataTable Listar()
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT * from Iva_Alicuotas where borrado=0 ");
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

        public int idIvaAliCuotas(int idSEF, string tipo)
        {
            DataTable dt = new DataTable();
            int id = 0;
            string consulta = "";
            try
            {
                switch (tipo)
                {
                    case "S":
                        consulta = string.Format("SELECT id_iva_alicuotas from servicios_sub where id={0}", idSEF);
                        break;
                    case "E":
                        consulta = string.Format("SELECT id_iva_alicuotas from equipos_tipos where id={0}", idSEF);
                        break;
                    case "P":
                        consulta = string.Format("SELECT id_iva_alicuotas from partes_fallas where id={0}", idSEF);
                        break;
                    default:
                        break;
                }
                oCon.Conectar();
                oCon.CrearComando(consulta);
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }
            if (dt.Rows.Count > 0)
                id = Convert.ToInt32(dt.Rows[0]["id_iva_alicuotas"]);
            return id;
        }

        public DataTable ListarComprobantesQuePresentanVentas(int puntoVenta, int idTipoComp, DateTime fechaDesde, DateTime fechaHasta)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                string comando = "select * from iva_ventas where borrado = 0 and Punto_venta = @puntoVenta and Id_Comprobantes_Tipo = @idCompTipo and fecha between @fechaDesde and @fechaHasta and numero>0 ORDER BY numero ASC";
                oCon.CrearComando(comando);
                oCon.AsignarParametroEntero("@puntoVenta", puntoVenta);
                oCon.AsignarParametroEntero("@idCompTipo", idTipoComp);
                oCon.AsignarParametroFecha("@fechaDesde", fechaDesde);
                oCon.AsignarParametroFecha("@fechaHasta", fechaHasta);
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
            }
            return dt;
        }

        public DataTable VerificarExistenciaDeNumeros(List<int> numeros, int puntoVenta, int idTipoComp, string desc = "")
        {
            DataTable dtNumerosNoEncontrados = new DataTable();
            dtNumerosNoEncontrados.Columns.Add(new DataColumn("numero", typeof(int)));
            dtNumerosNoEncontrados.Columns.Add(new DataColumn("punto_venta", typeof(int)));
            dtNumerosNoEncontrados.Columns.Add(new DataColumn("codigo_afip", typeof(int)));
            dtNumerosNoEncontrados.Columns.Add(new DataColumn("descripcion", typeof(string)));
            try
            {
                int codigoAfip = new Comprobantes_Tipo().getNumeroAfip(idTipoComp);
                oCon.Conectar();
                foreach (int numero in numeros)
                {
                    string comando = "select id from iva_ventas " 
                      +  " where iva_ventas.borrado = 0 and numero = @numero and Punto_Venta = @puntoVenta and id_comprobantes_tipo = @idCompTipo";
                    oCon.CrearComando(comando);
                    oCon.AsignarParametroEntero("@numero", numero);
                    oCon.AsignarParametroEntero("@puntoVenta", puntoVenta);
                    oCon.AsignarParametroEntero("@idCompTipo", idTipoComp);
                    DataTable dtResult = oCon.Tabla();
                    if (dtResult.Rows.Count == 0)
                    {
                        DataRow dr = dtNumerosNoEncontrados.NewRow();
                        dr["numero"] = numero;
                        dr["punto_venta"] = puntoVenta;
                        dr["codigo_afip"] = codigoAfip;
                        dr["descripcion"] = desc;
                        dtNumerosNoEncontrados.Rows.Add(dr);
                    }
                }
                oCon.DesConectar();
            }
            catch (Exception ex)
            {
                oCon.DesConectar();
            }
            return dtNumerosNoEncontrados;
        }
    }
}
