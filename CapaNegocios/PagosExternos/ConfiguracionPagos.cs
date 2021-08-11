using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;

namespace CapaNegocios.PagosExternos
{
    public class ConfiguracionPagos
    {
        private Conexion oCon = new Conexion();

        public bool Guardar(string propiedad, object valor, int plataforma)
        {
            try
            {
                DataTable dt = new DataTable();
                oCon.Conectar();
                oCon.CrearComando("select count(id) as cantidad from configuracion_pagos where variable=@propiedad and id_plataforma=@plataforma");
                oCon.AsignarParametroCadena("@propiedad",propiedad);
                oCon.AsignarParametroEntero("@plataforma", plataforma);
                dt = oCon.Tabla();
                if(Convert.ToInt32(dt.Rows[0]["cantidad"])==0)
                {
                    string consultaAdd = "INSERT INTO configuracion_pagos (variable,id_plataforma,valor_c) VALUES (@propiedad,@plataforma,@valor);";
                    if (valor is int || valor is decimal)
                        consultaAdd = consultaAdd.Replace("valor_c", "valor_n");

                    oCon.CrearComando(consultaAdd);
                    oCon.AsignarParametroCadena("@propiedad", propiedad);
                    oCon.AsignarParametroEntero("@plataforma", plataforma);
                    if (valor is int || valor is decimal)
                        oCon.AsignarParametroDecimal("@valor", (decimal)valor);
                    else if (valor is string)
                        oCon.AsignarParametroCadena("@valor", (string)valor);
                    else if (valor is DateTime)
                        oCon.AsignarParametroFecha("@valor", (DateTime)valor);
                    oCon.EjecutarComando();
                }
                else
                {
                    string consulta = "update configuracion_pagos set valor_c = @valor where variable=@propiedad and id_plataforma=@plataforma";
                    if (valor is int || valor is decimal)
                        consulta = consulta.Replace("valor_c", "valor_n");
                    oCon.CrearComando(consulta);
                    if (valor is int || valor is decimal)
                        oCon.AsignarParametroDecimal("@valor", (decimal)valor);
                    else if (valor is string)
                        oCon.AsignarParametroCadena("@valor", (string)valor);
                    else if (valor is DateTime)
                        oCon.AsignarParametroFecha("@valor", (DateTime)valor);

                    oCon.AsignarParametroCadena("@propiedad", propiedad);
                    oCon.AsignarParametroEntero("@plataforma", plataforma);

                    oCon.EjecutarComando();
                }
                
                oCon.DesConectar();
                return true;
            }
            catch (Exception c)
            {
                oCon.DesConectar();
                string error = c.ToString();
                return false;
                throw;
            }
        }

        public object Get(string propiedad, int plataforma, TypeCode tipoValor)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                string consulta = "Select @valor from configuracion_pagos where variable = @propiedad and id_plataforma=@plataforma";
                if (tipoValor == TypeCode.String)
                    consulta = consulta.Replace("@valor", "Valor_C");
                else if (tipoValor == TypeCode.Decimal || tipoValor == TypeCode.Int32)
                    consulta = consulta.Replace("@valor", "Valor_N");
                oCon.CrearComando(consulta);
                oCon.AsignarParametroCadena("@propiedad", propiedad);
                oCon.AsignarParametroEntero("@plataforma", plataforma);

                dt = oCon.Tabla();
                oCon.DesConectar();
                if (dt.Rows.Count > 0)
                {
                    if (tipoValor == TypeCode.String)
                        return dt.Rows[0]["valor_C"].ToString();
                    else if (tipoValor == TypeCode.Decimal)
                        return Convert.ToDecimal(dt.Rows[0]["valor_n"]);
                    else if (tipoValor == TypeCode.Int32)
                        return Convert.ToInt32(dt.Rows[0]["valor_n"]);
                    else
                        return null;
                }
                else
                    return null;
            }
            catch (Exception)
            {
                oCon.DesConectar();
                return null;
            }
        }

    }
}
