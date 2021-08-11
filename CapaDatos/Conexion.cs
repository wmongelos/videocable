using MySql.Data.MySqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Data.Common;

namespace CapaDatos
{
    public class Conexion
    {
        private DbConnection conexion = null;
        private DbCommand comando = null;
        private DbTransaction transaccion = null;
        private string conexionString;
        private static DbProviderFactory factory = null;

        public Conexion()
        {
            if (this.conexion == null || this.conexion.State.Equals(ConnectionState.Closed))
                Configurar();
        }

        private String GetStringConexion()
        {
            if (ConfigurationManager.ConnectionStrings["ConnectionStringMysql"] == null)
                return "server=192.168.5.187;uid=wamarpesrl;pwd=rAmOn.moya_1324;database=dbavc;Convert Zero Datetime=True;Connect Timeout=50000";
            else
                return ConfigurationManager.ConnectionStrings["ConnectionStringMysql"].ConnectionString;
        }

        private void Configurar()
        {
            try
            {
                this.conexionString = GetStringConexion();

                // this.conexionString = "server=192.168.5.187;uid=wamarpesrl;pwd=rAmOn.moya_1324;database=dbavc;Convert Zero Datetime=True;Connect Timeout=3000";
                // this.conexionString = "server=192.168.0.30;uid=root;pwd=atcco2010;database=db_atcco;Convert Zero Datetime=True;Connect Timeout=50000";


                Conexion.factory = MySqlClientFactory.Instance;
            }
            catch (ConfigurationException ex)
            {
                throw new ConexionException("Error al cargar la configuración del acceso a datos.", ex);
            }
        }

        public Boolean Conectar(string server, string user, string db, string port)
        {
            bool conecta = false;

            try
            {

            }
            catch (Exception)
            {

                throw;
            }

            return conecta;
        }

        public void Conectar()
        {


            if (this.conexion != null && !this.conexion.State.Equals(ConnectionState.Closed))
            {
                throw new ConexionException("La conexión ya se encuentra abierta.");
            }

            try
            {
                if (this.conexion == null)
                {
                    this.conexion = factory.CreateConnection();
                    this.conexion.ConnectionString = this.conexionString;
                }

                this.conexion.Open();
            }
            catch (DataException ex)
            {
                throw new ConexionException("Error al conectarse a la base de datos.", ex);
            }
        }

        public void DesConectar()
        {
            if (this.conexion.State.Equals(ConnectionState.Open))
                this.conexion.Close();
        }

        public void CrearComando(string sentenciaSQL)
        {
            this.comando = factory.CreateCommand();
            this.comando.Connection = this.conexion;
            this.comando.CommandType = CommandType.Text;
            this.comando.CommandText = sentenciaSQL.ToLower();
            this.comando.CommandTimeout = 0;

            if (this.transaccion != null)
                this.comando.Transaction = this.transaccion;
        }

        private void AsignarParametro(string nombre, string separador, string valor)
        {
            nombre = nombre.ToLower();
            int indice = this.comando.CommandText.IndexOf(nombre);
            string prefijo = this.comando.CommandText.Substring(0, indice);
            string sufijo = this.comando.CommandText.Substring(indice + nombre.Length);

            this.comando.CommandText = String.Format("{0}{1}{2}{3}{4}", prefijo, separador, valor, separador, sufijo);
        }

        public void AsignarParametroCadena(string nombre, string valor)
        {
            AsignarParametro(nombre, "'", valor.ToString());
        }

        public void AsignarParametroEntero(string nombre, int valor)
        {
            AsignarParametro(nombre, "", valor.ToString());
        }

        public void AsignarParametroDecimal(string nombre, decimal valor)
        {
            AsignarParametro(nombre, "", valor.ToString().Replace(",", "."));
        }

        public void AsignarParametroDouble(string nombre, double valor)
        {
            AsignarParametro(nombre, "", valor.ToString().Replace(",", "."));
        }

        public void AsignarParametroFecha(string nombre, DateTime valor)
        {
            AsignarParametro(nombre, "'", valor.ToString("yyyy-MM-dd HH:mm"));
        }

        public void AsignarParametroNulo(string nombre)
        {
            AsignarParametro(nombre, "", "NULL");
        }

        public int EjecutarScalar()
        {
            int escalar = 0;
            try
            {
                escalar = int.Parse(this.comando.ExecuteScalar().ToString());
            }
            catch (InvalidCastException ex)
            {
                throw new ConexionException("Error al ejecutar un escalar." + this.comando.CommandText, ex);
            }

            return escalar;
        }

        public void EjecutarComando()
        {
            try
            {
                this.comando.ExecuteNonQuery();
            }
            catch (DbException ex)
            {
                throw new ConexionException("Error al ejecutar Comando.----> " +" trace: " + ex.StackTrace + "," + this.comando.CommandText, ex);
            }

        }

        public DataTable Tabla()
        {
            DbDataAdapter adapter = factory.CreateDataAdapter();
            DataTable dt = new DataTable();

            adapter.SelectCommand = this.comando;
            adapter.SelectCommand.CommandText = this.comando.CommandText;
            adapter.SelectCommand.Connection = this.comando.Connection;

            try
            {
                adapter.Fill(dt);
                dt.EndLoadData();
            }
            catch (DbException ex)
            {

                throw new ConexionException("Error al consultar Tabla. Error: " + ex.Message.ToString() + " - " + this.comando.CommandText, ex);
            }

            return dt;
        }

        public void ComenzarTransaccion()
        {
            if (this.transaccion == null)
                this.transaccion = this.conexion.BeginTransaction();
        }

        public void CancelarTransaccion()
        {
            if (this.transaccion != null)
            {
                CrearComando("ROLLBACK");
                EjecutarComando();
            }
        }

        public void ConfirmarTransaccion()
        {
            if (this.transaccion != null)
            {
                CrearComando("COMMIT");
                EjecutarComando();
            };
        }
    }
}
