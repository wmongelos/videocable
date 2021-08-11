using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;


namespace CapaNegocios
{
    public class PlataformasPagos
    {

        public int Id { get; set; }
        public string Nombre { get; set; }
        public int Activa { get; set; }

        private Conexion oCon = new Conexion();

        public DataTable Listar(int estado)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT id,nombre,activa from plataformas_pagos WHERE activa=@estado and borrado=0");
                oCon.AsignarParametroEntero("@estado", estado);
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();

                throw;
            }
            if (dt.Rows.Count > 0)
                dt.Rows.Add(0, "TODAS", 1);
            return dt;
        }
    
        public bool GuardarRelacionForma(int idPlataforma, int idFormaPago)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("INSERT INTO plataformas_formas_pagos (id_plataforma,id_forma_pago) VALUES (@plataforma,@forma)");
                oCon.AsignarParametroEntero("@plataforma",idPlataforma);
                oCon.AsignarParametroEntero("@forma",idFormaPago);
                oCon.EjecutarComando();
                oCon.DesConectar();
                return true;
            }
            catch (Exception c)
            {
                string salida = c.ToString();
                oCon.DesConectar();
                return false;
            }
        }
        
        public bool EliminarRelacionForma(int id)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("UPDATE plataformas_formas_pagos set borrado=1 WHERE id=@relacion");
                oCon.AsignarParametroEntero("@relacion", id);
                oCon.EjecutarComando();
                oCon.DesConectar();
                return true;
            }
            catch (Exception c)
            {
                oCon.DesConectar();
                string salida = c.ToString();
                return false;
            }
        }
    
        public Formas_de_pago GetIdFormaPago(int idPlataforma)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("select plataformas_formas_pagos.id_forma_pago,formas_de_pago.nombre,id_tipo_de_forma,activo,requiere_presentacion,requiere_presentacion2," +
                    " codigo_empresa_tarjeta,codigo_empresa_banco " +
                    " from plataformas_formas_pagos" +
                    " LEFT JOIN formas_de_pago on formas_de_pago.id = plataformas_formas_pagos.id_forma_pago" +
                    " WHERE id_plataforma = @plataforma");
                oCon.AsignarParametroEntero("@plataforma", idPlataforma);
                dt = oCon.Tabla();
                oCon.DesConectar();
                if (dt.Rows.Count > 0)
                {
                    Formas_de_pago oForma = new Formas_de_pago();
                    oForma.Id = Convert.ToInt32(dt.Rows[0]["id_forma_pago"]);
                    oForma.Nombre = dt.Rows[0]["nombre"].ToString();
                    oForma.Tipo_De_Forma = Convert.ToInt32(dt.Rows[0]["id_tipo_de_forma"]);
                    oForma.Requiere_Presentacion = Convert.ToInt32(dt.Rows[0]["requiere_presentacion"]);
                    oForma.Codigo_Empresa_Banco = dt.Rows[0]["codigo_empresa_banco"].ToString();
                    oForma.Codigo_Empresa_Tarjeta = dt.Rows[0]["codigo_empresa_tarjeta"].ToString();
                    return oForma;
                }
                else
                    return null;
            }
            catch (Exception c)
            {
                oCon.DesConectar();
                string salida = c.ToString();
                return null;
            }
        }
    }
}
