using CapaDatos;
using System;
using System.Data;

namespace CapaNegocios
{
    public class Comprobantes_Iva
    {
        public Int32 Id { get; set; }
        public String Descripcion { get; set; }
        public Int32 Discrimina_Iva { get; set; }
        public Int32 Documento_Afip { get; set; }
        public String Letra { get; set; }

        public static Comprobantes_Iva CurrentComprobantes_Iva = new Comprobantes_Iva();

        public enum Tipo
        {
            CONSUMIDOR_FINAL = 1,
            RESPONSABLE_INSCRIPTO = 2,
            RESPONSABLE_MONOTRIBUTO = 3,
            EXENTO = 4,
        }

        private Conexion oCon = new Conexion();

        public DataTable Listar(int idComprobanteIva = 0)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                if(idComprobanteIva == 0)
                {
                    oCon.CrearComando("SELECT * from comprobantes_iva");
                }
                else
                {
                    oCon.CrearComando("SELECT * from comprobantes_iva where id = @idCompiva");
                    oCon.AsignarParametroEntero("@idCompiva", idComprobanteIva);
                }
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

        public Comprobantes_Iva Listarportipo()
        {

            Comprobantes_Iva oComprobantes_iva = new Comprobantes_Iva();
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT  * from comprobantes_iva WHERE Id = @id");
                oCon.AsignarParametroEntero("@id", Id);
                dt = oCon.Tabla();
                oCon.DesConectar();
                if (dt.Rows.Count == 0)
                {
                    CurrentComprobantes_Iva.Id = 0;
                }
                else
                {
                    CurrentComprobantes_Iva.Id = Convert.ToInt32(dt.Rows[0]["id"]);
                    CurrentComprobantes_Iva.Descripcion = dt.Rows[0]["descripcion"].ToString();
                    CurrentComprobantes_Iva.Discrimina_Iva = Convert.ToInt32(dt.Rows[0]["id"]);
                    CurrentComprobantes_Iva.Letra = dt.Rows[0]["letra"].ToString();
                    CurrentComprobantes_Iva.Documento_Afip = Convert.ToInt32(dt.Rows[0]["Documento_Afip"]);
                }
            }
            catch (Exception)
            {
                oCon.DesConectar();

                throw;
            }
            return CurrentComprobantes_Iva;
        }

        public Int32 GetTipoDocumentoAfip(int id)
        {
            Int32 tipoDocumentoAfip = 0;
            DataTable dtResultado = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("select documento_afip from comprobantes_iva where id=@id1");
                oCon.AsignarParametroEntero("@id1", id);
                dtResultado = oCon.Tabla();
                oCon.DesConectar();
            }
            catch
            {
                oCon.DesConectar();
                tipoDocumentoAfip = 0;
                throw;
            }
            if (dtResultado.Rows.Count > 0)
                tipoDocumentoAfip = Convert.ToInt32(dtResultado.Rows[0]["documento_afip"]);
            else
                tipoDocumentoAfip = 0;
            return tipoDocumentoAfip;
        }
    }
}
