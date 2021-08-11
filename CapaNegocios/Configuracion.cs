using CapaDatos;
using System;
using System.Data;

namespace CapaNegocios
{
    public class Configuracion
    {
        public static DataTable dtConfiguracion;
        public static String VersionSistema;
        private Conexion oCon = new Conexion();

        public enum CAMBIO_MESES
        {
            SI = 1,
            NO = 2
        }

        public enum FACTURACION_EMPRESAS
        {
            ZONAS = 1,
            CATEGORIAS = 2
        }

        public Int32 GetValor_N(string variable)
        {
            DataRow[] dr = dtConfiguracion.Select(String.Format("Variable = '{0}'", variable));

            return Convert.ToInt32(dr[0]["Valor_N"]);
        }

        public String GetValor_C(string variable)
        {
            DataRow[] dr = dtConfiguracion.Select(String.Format("Variable = '{0}'", variable));

            if (dr.Length == 0)
            {
                this.SetValor_C(variable, "");
            }

            return Convert.ToString(dr[0]["Valor_C"]);
        }

        public void SetValor_N(string variable, int value)
        {
            oCon.Conectar();
            oCon.CrearComando(String.Format("UPDATE configuracion SET Valor_N = @value WHERE Variable = '{0}'", variable));

            oCon.AsignarParametroEntero("@value", value);
            oCon.EjecutarComando();

            oCon.DesConectar();
        }

        public void SetValor_N(string variable, int value, string descripcion)
        {
            oCon.Conectar();
            oCon.CrearComando("INSERT INTO configuracion(Variable, Valor_N, Descripcion,id_personal) VALUES(@var, @value, @descrip,@personal)");

            oCon.AsignarParametroCadena("@var", variable);
            oCon.AsignarParametroEntero("@value", value);
            oCon.AsignarParametroCadena("@descrip", descripcion);
            oCon.AsignarParametroEntero("@personal", Personal.Id_Login);
            oCon.EjecutarComando();

            oCon.DesConectar();
        }

        public void SetValor_C(string variable, string value)
        {
            oCon.Conectar();
            oCon.CrearComando(String.Format("UPDATE configuracion SET Valor_C = @value,id_personal=@personal WHERE Variable = '{0}'", variable));
            oCon.AsignarParametroCadena("@value", value);
            oCon.AsignarParametroEntero("@personal", Personal.Id_Login);
            oCon.EjecutarComando();
            oCon.DesConectar();
        }

        public void SetValor_C(string variable, string value, string descripcion)
        {
            oCon.Conectar();
            oCon.CrearComando("INSERT INTO configuracion(Variable, Valor_C, Descripcion,id_personal) VALUES(@var, @value, @descrip,@personal)");
            oCon.AsignarParametroCadena("@var", variable);
            oCon.AsignarParametroCadena("@value", value);
            oCon.AsignarParametroCadena("@descrip", descripcion); 
            oCon.AsignarParametroEntero("@personal", Personal.Id_Login);
            oCon.EjecutarComando();
            oCon.DesConectar();
        }

        public Decimal GetValor_Decimal(string variable)
        {
            DataRow[] dr = dtConfiguracion.Select(String.Format("Variable = '{0}'", variable));

            return Convert.ToDecimal(dr[0]["Valor_N"]);
        }

        public void SetValor_Decimal(string variable, Decimal value)
        {
            oCon.Conectar();
            oCon.CrearComando(String.Format("UPDATE configuracion SET Valor_N = @value,id_personal = @personal WHERE Variable = '{0}'", variable));
            oCon.AsignarParametroDecimal("@value", value);
            oCon.AsignarParametroEntero("@personal", Personal.Id_Login);
            oCon.EjecutarComando();

            oCon.DesConectar();
        }

        public void LoadConfiguracion()
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT * FROM Configuracion");
                dtConfiguracion = oCon.Tabla();
                oCon.DesConectar();

                oCon.Conectar();
                oCon.CrearComando("SET GLOBAL sql_mode = '';");
                oCon.DesConectar();
            }
            catch { }
        }

        public DataTable LeerConfiguraciones()
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT Variable,Valor_C,Valor_N,descripcion FROM configuracion ORDER BY Variable ASC");
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }

        public void AgregarVariable(string Variable)
        {

            oCon.Conectar();
            oCon.CrearComando("INSERT INTO configuracion(Variable, Valor_C, Valor_N, Descripcion,id_personal) VALUES (@var,'',1,'',@personal)");
            oCon.AsignarParametroCadena("@var", Variable);
            oCon.AsignarParametroEntero("@personal", Personal.Id_Login);
            oCon.EjecutarComando();
            oCon.DesConectar();

        }
    }
}