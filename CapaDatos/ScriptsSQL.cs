using System;
using System.Configuration;
using System.Data;
using System.Data.Common;

namespace CapaDatos
{
    public class ScriptsSQL
    {
        private Conexion Conexion = new Conexion();
        private DataTable DataSchema = new DataTable();
        private String DataBase;

        public ScriptsSQL()
        {
            DbConnectionStringBuilder db = new DbConnectionStringBuilder();

            db.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectionStringMysql"].ConnectionString;

            var username = db["uid"].ToString();
            var userpass = db["pwd"].ToString();
            var server = db["server"].ToString();
            var database = db["database"].ToString();

            this.DataBase = database;

            LoadDataSchema();
        }

        private void LoadDataSchema()
        {
            try
            {
                Conexion.Conectar();
                Conexion.CrearComando(String.Format("select * from information_schema.columns  where table_schema = '{0}'", DataBase));
                DataSchema = Conexion.Tabla();
                Conexion.DesConectar();
            }
            catch (Exception)
            {

                throw;
            }

        }

        public void GenerarBaseDatos()
        {
            string query = String.Format("CREATE DATABASE IF NOT EXISTS {0};", DataBase);

            query += Environment.NewLine;

            query += @"DROP TABLE IF EXISTS `agenda_detalle`;
                            CREATE TABLE `agenda_detalle` (
                              `Id` int(11) NOT NULL AUTO_INCREMENT,
                              `id_agenda_tecnico` varchar(255) DEFAULT NULL,
                              `hora` time DEFAULT NULL,
                              `id_parte` varchar(255) DEFAULT NULL,
                              `estado` int(11) DEFAULT NULL,
                              `Detalles` text,
                              `reservado` int(1) DEFAULT NULL,
                              `id_personal` int(4) NOT NULL DEFAULT '0',
                              PRIMARY KEY (`Id`)
                            ) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;";

            query += Environment.NewLine;

            query += @"DROP TABLE IF EXISTS `agenda_encabezado`;
                    CREATE TABLE `agenda_encabezado` (
                      `Id` int(11) NOT NULL AUTO_INCREMENT,
                      `id_tecnico` varchar(255) DEFAULT NULL,
                      `fecha_jornada` datetime DEFAULT NULL,
                      `hora_inicio_1` time DEFAULT NULL,
                      `hora_fin_1` time DEFAULT NULL,
                      `hora_inicio_2` time DEFAULT NULL,
                      `hora_fin_2` time DEFAULT NULL,
                      `rango` int(11) DEFAULT NULL,
                      `id_personal` int(4) NOT NULL DEFAULT '0',
                      PRIMARY KEY (`Id`)
                    ) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;";

            try
            {
                Conexion.Conectar();
                Conexion.CrearComando(query);
                Conexion.EjecutarComando();
                Conexion.DesConectar();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void ActualizarBase()
        {
            /// Version 9.0.4.0
            AgregarCampo("Usuarios", "CampoPrueba", TypeCode.Int32, 11);
            AgregarCampo("partes_usuarios_servicios", "id_usuarios_servicios_sub", TypeCode.Int32, 11);

            AgregarTabla("agenda_detalles", @"CREATE TABLE `agenda_detalles` (
                          `id` int(11) NOT NULL AUTO_INCREMENT,
                          `id_agenda_tecnico` varchar(255) DEFAULT NULL,
                          `hora` time DEFAULT NULL,
                          `id_parte` varchar(255) DEFAULT NULL,
                          `estado` int(11) DEFAULT NULL,
                          `detalles` text,
                          `reservado` int(1) DEFAULT NULL,
                          `id_personal` int(4) NOT NULL DEFAULT '0',
                          PRIMARY KEY (`id`)
                        ) ENGINE=InnoDB DEFAULT CHARSET=utf8 ROW_FORMAT=DYNAMIC;");



            ///
        }

        public void AgregarCampo(String Tabla, String NombreCol, TypeCode ColType, Int32 Longitud)
        {
            DataRow[] DataRow = DataSchema.Select(String.Format("table_name = '{0}' and column_name = '{1}'", Tabla, NombreCol));

            if (DataRow.Length > 0)
                return;

            string CampoTipo = "";

            switch (ColType)
            {
                case TypeCode.Int32:
                    CampoTipo = String.Format("int({0})", Longitud);
                    break;
                case TypeCode.String:
                    CampoTipo = String.Format("varchar({0})", Longitud);
                    break;
                case TypeCode.Decimal:
                    CampoTipo = String.Format("decimal({0}, 2)", Longitud);
                    break;
                case TypeCode.DateTime:
                    CampoTipo = String.Format("datetime", Longitud);
                    break;
            }

            string querySql = String.Format("ALTER TABLE {0} ADD {1} {2}", Tabla, NombreCol, CampoTipo);

            try
            {
                Conexion.Conectar();
                Conexion.CrearComando(querySql);
                Conexion.EjecutarComando();
                Conexion.DesConectar();
            }
            catch (Exception)
            {

                throw new Exception(String.Format("Error al agregar el Campo {0} de la Tabla {1}", NombreCol, Tabla));
            }
        }

        public void AgregarTabla(String Tabla, String Query)
        {
            DataRow[] DataRow = DataSchema.Select(String.Format("table_name = '{0}'", Tabla));

            if (DataRow.Length > 0)
                return;


            try
            {
                Conexion.Conectar();
                Conexion.CrearComando(Query);
                Conexion.EjecutarComando();
                Conexion.DesConectar();
            }
            catch (Exception)
            {

                throw new Exception(String.Format("Error al agregar la Tabla {0}", Tabla));
            }
        }
    }
}