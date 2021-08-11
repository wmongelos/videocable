using CapaDatos;
using System;
using System.Data;


namespace CapaNegocios
{
    public class Isp
    {

        public static string cadenaConexion = Tablas.DataIsp.Rows[0]["string_conexion"].ToString();      
        private ConexionesExternas oConExterna = new ConexionesExternas();
        private Aplicaciones_Externas oApp = new Aplicaciones_Externas();
        private Servicios_Velocidades oVel = new Servicios_Velocidades();

        public enum EQUIPO_ESTADO
        {
            NO_DISPONIBLE_NO_DADO_DE_ALTA_EN_INVENTARIO = 1,
            NO_DISPONIBLE_EN_REPARACION = 2,
            NO_DISPONIBLE_DADO_DE_BAJA_EN_INVENTARIO = 3,
            DISPONIBLE_USO_INFRASTUCTURA = 4,
            DISPONIBLE_USO_CLIENTE = 5
        }

        public Int32 VerificarExisteUsuario(int codUsuario)
        {
            DataTable dt = new DataTable();
            Int32 idCustomer = 0;
            try
            {

                oConExterna.conexionString = Isp.cadenaConexion;
                oConExterna.Conectar();
                oConExterna.CrearComando("SELECT customer_id FROM customer where company_name=@cod_usuario");
                oConExterna.AsignarParametroCadena("@cod_usuario", codUsuario.ToString());
                dt = oConExterna.Tabla();
                oConExterna.Desconectar();

            }
            catch (Exception)
            {
                oConExterna.Desconectar();
                throw;
            }
            if (dt.Rows.Count > 0)
                idCustomer = Convert.ToInt32(dt.Rows[0]["customer_id"]);
            else
                idCustomer = 0;

            return idCustomer;
        }

        public Int32 GuardarUsuario(int codUsuario, string nombreUsuario, string apellidoUsuario, string email)
        {
            Int32 idGenerado = 0;
            oConExterna.conexionString = Isp.cadenaConexion;
            try
            {
                string pass = nombreUsuario;
                string user = nombreUsuario;
                if (nombreUsuario.Length > 16)
                {
                    pass = nombreUsuario.Substring(0, 16);
                    user = nombreUsuario.Substring(0, 16);
                }
                if (nombreUsuario.Length > 40)
                    nombreUsuario = nombreUsuario.Substring(0, 40);
                if(apellidoUsuario.Length>40)
                    apellidoUsuario = apellidoUsuario.Substring(0, 40);


                oConExterna.Conectar();
                oConExterna.CrearComando("INSERT INTO customer (created,created_by,updated,updated_by,username,password,first_name,last_name,mobile,company_name,email,enabled) VALUES (@fecha,999,@fecha1,999,@usuario,@pass,@nombre,@apellido,@tel,@codusu,@email,1);SELECT @@IDENTITY");
                oConExterna.AsignarParametroFecha("@fecha", DateTime.Now);
                oConExterna.AsignarParametroFecha("@fecha1", DateTime.Now);
                oConExterna.AsignarParametroCadena("@usuario", user);
                oConExterna.AsignarParametroCadena("@pass",pass);
                oConExterna.AsignarParametroCadena("@nombre", nombreUsuario);
                oConExterna.AsignarParametroCadena("@apellido", apellidoUsuario);
                oConExterna.AsignarParametroCadena("@tel", "0");
                oConExterna.AsignarParametroEntero("@codusu", codUsuario);
                oConExterna.AsignarParametroCadena("@email", email);
                idGenerado = oConExterna.EjecutarScalar();
                oConExterna.Desconectar();

            }
            catch (Exception)
            {
                idGenerado = 0;
                oConExterna.Desconectar();
            }
            return idGenerado;
        }

        public Int32 VerificarExisteLocacion(int idLocacion)
        {
            Int32 idLocation = 0;
            DataTable dt = new DataTable();
            oConExterna.conexionString = Isp.cadenaConexion;
            try
            {
                oConExterna.Conectar();
                oConExterna.CrearComando("SELECT location_id FROM location WHERE description=@idloc");
                oConExterna.AsignarParametroCadena("@idloc", idLocacion.ToString());
                dt = oConExterna.Tabla();
                oConExterna.Desconectar();
            }
            catch (Exception)
            {
                oConExterna.Desconectar();
            }
            if (dt.Rows.Count > 0)
                idLocation = Convert.ToInt32(dt.Rows[0]["location_id"]);
            else
                idLocation = 0;
            return idLocation;
        }

        public Int32 GuardarLocacion(int idLocacion, int idCustomer, string nombreUsuario, string tel, string tel2, string dir1, string dir2, string dir3, string ciudad, string estado, string codPostal, string correoUsuario)
        {
            Int32 idLocation = 0;
            oConExterna.conexionString = Isp.cadenaConexion;
            try
            {
                oConExterna.Conectar();
                oConExterna.CrearComando("INSERT INTO location (customer_id,created,created_by,updated,updated_by,description,name,telephone,telephone2,addr_1,addr_2,addr_3,city,state,country,zip,email,enabled) values (@idcustomer,@fecha,999,@fecha1,999,@idlocacion,@nombre,@tel1,@tel2,@dir1,@dir2,@dir3,@ciudad,@estado,'Argentina',@codpostal,@email,0);SELECT @@IDENTITY");
                oConExterna.AsignarParametroEntero("@idcustomer", idCustomer);
                oConExterna.AsignarParametroFecha("@fecha", DateTime.Now);
                oConExterna.AsignarParametroFecha("@fecha1", DateTime.Now);
                oConExterna.AsignarParametroCadena("@idlocacion", idLocacion.ToString());
                oConExterna.AsignarParametroCadena("@nombre", nombreUsuario.ToString());
                oConExterna.AsignarParametroCadena("@tel1", tel);
                oConExterna.AsignarParametroCadena("@tel2", tel2);
                oConExterna.AsignarParametroCadena("@dir1", dir1);
                oConExterna.AsignarParametroCadena("@dir2", "0");
                oConExterna.AsignarParametroCadena("@dir3", "0");
                oConExterna.AsignarParametroCadena("@ciudad", ciudad);
                oConExterna.AsignarParametroCadena("@estado", estado);
                oConExterna.AsignarParametroCadena("@codpostal", codPostal);
                oConExterna.AsignarParametroCadena("@email", correoUsuario);



                idLocation = oConExterna.EjecutarScalar();
                oConExterna.Desconectar();
            }
            catch (Exception)
            {
                oConExterna.Desconectar();
                throw;
            }
            return idLocation;
        }

        public Int32 VerificarExisteEquipo(string mac, string serie)
        {
            Int32 idEquipment = 0;
            DataTable dt = new DataTable();
            oConExterna.conexionString = Isp.cadenaConexion;
            try
            {
                oConExterna.Conectar();
                oConExterna.CrearComando("SELECT id FROM equipments WHERE mac=@mac1");
                oConExterna.AsignarParametroCadena("@mac1", mac);
                dt = oConExterna.Tabla();
                oConExterna.Desconectar();
            }
            catch (Exception)
            {
                oConExterna.Desconectar();
                idEquipment = 0;
            }
            if (dt.Rows.Count > 0)
                idEquipment = Convert.ToInt32(dt.Rows[0]["id"]);
            else
                idEquipment = 0;
            return idEquipment;
        }

        public Int32 ActualizarDatosEquipment(int id, string mac, string ip, string marca, string modelo,string serial="")
        {
            try
            {
                oConExterna.Conectar();
                oConExterna.CrearComando("update equipments set brand=@marca_equipo,model=@modelo_equipo,mac=@mac_equipo,ip=@ip_equipo, serial= @serie where id=@id_equipo");
                oConExterna.AsignarParametroEntero("@id_equipo", id);
                oConExterna.AsignarParametroCadena("@marca_equipo", marca);
                oConExterna.AsignarParametroCadena("@modelo_equipo", modelo);
                oConExterna.AsignarParametroCadena("@mac_equipo", mac);
                oConExterna.AsignarParametroCadena("@ip_equipo", ip);
                oConExterna.AsignarParametroCadena("@serie", serial);
                oConExterna.ComenzarTransaccion();
                oConExterna.EjecutarComando();
                oConExterna.ConfirmarTransaccion();
                oConExterna.Desconectar();
            }
            catch (Exception c)
            {

                oConExterna.CancelarTransaccion();
                oConExterna.Desconectar();
                return -1;
                //throw;
            }
            return 0;
        }

        public Int32 GuardarEquipo(string mac, string serial, string user, string pass, string ip, string marca, string modelo)
        {
            Int32 idEquipment = 0;
            oConExterna.conexionString = Isp.cadenaConexion;
            try
            {
                oConExterna.Conectar();
                oConExterna.CrearComando("INSERT INTO equipments (mac,serial,created_by,updated_by,created,updated,user,password,ip,status,brand,model) values (@mac1,@serial1,999,999,@fechahoy,@fechahoy1,@usuario,@contrasenia,@ip,@estado,@marca,@modelo);SELECT @@IDENTITY");
                oConExterna.AsignarParametroCadena("@mac1", mac);
                oConExterna.AsignarParametroCadena("@serial1", serial);
                oConExterna.AsignarParametroFecha("@fechahoy", DateTime.Now);
                oConExterna.AsignarParametroFecha("@fechahoy1", DateTime.Now);
                oConExterna.AsignarParametroCadena("@usuario", user);
                oConExterna.AsignarParametroCadena("@contrasenia", pass);
                oConExterna.AsignarParametroCadena("@ip", ip);
                oConExterna.AsignarParametroEntero("@estado", (int)EQUIPO_ESTADO.DISPONIBLE_USO_CLIENTE);
                oConExterna.AsignarParametroCadena("@marca", marca);
                oConExterna.AsignarParametroCadena("@modelo", modelo);
                oConExterna.ComenzarTransaccion();
                idEquipment = oConExterna.EjecutarScalar();
                oConExterna.ConfirmarTransaccion();
                oConExterna.Desconectar();
            }
            catch (Exception)
            {
                oConExterna.CancelarTransaccion();
                oConExterna.Desconectar();
                idEquipment = -1;
                throw;
            }
            return idEquipment;
        }

        public Int32 GuardarAccesAccount(int idCustomer, int idProduct, int idLocation, string usuario, string contrasenia, string ip, string mac)
        {
            Int32 idAccesAccount = 0;
            oConExterna.conexionString = Isp.cadenaConexion;
            try
            {
                oConExterna.Conectar();
                oConExterna.CrearComando("INSERT INTO account_access (customer_id,product_id,location_id,created,created_by,updated,updated_by,username,password,ip,user_mac,enabled) VALUES (@idcustomer,@idproduct,@idlocation,@fecha,999,@fecha1,999,@usuario,@pass,@ip,@mac,1);SELECT @@IDENTITY");
                oConExterna.AsignarParametroEntero("@idcustomer", idCustomer);
                oConExterna.AsignarParametroEntero("@idproduct", idProduct);
                oConExterna.AsignarParametroEntero("@idlocation", idLocation);
                oConExterna.AsignarParametroFecha("@fecha", DateTime.Now);
                oConExterna.AsignarParametroFecha("@fecha1", DateTime.Now);
                oConExterna.AsignarParametroCadena("@usuario", usuario);
                oConExterna.AsignarParametroCadena("@pass", contrasenia);
                oConExterna.AsignarParametroCadena("@ip", ip);
                oConExterna.AsignarParametroCadena("@mac", mac);


                idAccesAccount = oConExterna.EjecutarScalar();
                oConExterna.Desconectar();
            }
            catch (Exception)
            {
                idAccesAccount = 0;
                oConExterna.Desconectar();
                throw;
            }
            return idAccesAccount;
        }

        public Int32 obtenerIdAccesAccount(int idEquipo)
        {
            oConExterna.conexionString = Isp.cadenaConexion;

            DataTable dt = new DataTable();
            try
            {
                oConExterna.Conectar();
                oConExterna.CrearComando("SELECT account from account_equipments where equipment=@id order by account desc");
                oConExterna.AsignarParametroEntero("@id", idEquipo);
                dt = oConExterna.Tabla();
                oConExterna.Desconectar();
            }
            catch (Exception)
            {
                oConExterna.Desconectar();
                throw;
            }
            if (dt.Rows.Count > 1)
            {
                return Convert.ToInt32(dt.Rows[0][0]);
            }
            if (dt.Rows.Count > 0)
            {
                return Convert.ToInt32(dt.Rows[0][0]);
            }
            else
                return 0;
        }

        public DataTable ListarDatosAccoun(int id)
        {
            oConExterna.conexionString = Isp.cadenaConexion;

            DataTable dt = new DataTable();
            try
            {
                oConExterna.Conectar();
                oConExterna.CrearComando("select * from account_access where account_id=@id");
                oConExterna.AsignarParametroEntero("@id", id);
                dt = oConExterna.Tabla();
                oConExterna.Desconectar();
            }
            catch (Exception)
            {
                oConExterna.Desconectar();
                throw;
            }
            return dt;
        }

        public DataTable ListarProductos(int idApp)
        {
            DataTable dtDatosApp = new DataTable();
            DataTable dtProductos = new DataTable();

            cadenaConexion = "";
            Int32 error = 0;

            if (idApp != 0)
            {
                dtDatosApp = oApp.Listar(idApp);
                if (dtDatosApp.Rows.Count > 0)
                {
                    Isp.cadenaConexion = dtDatosApp.Rows[0]["string_conexion"].ToString();
                    if (cadenaConexion != "")
                    {
                        oConExterna.conexionString = cadenaConexion;
                    }
                    else
                        error = -3;
                }
                else
                    error = -2;
            }
            else
                error = -1;

            if (error == 0)
            {
                try
                {
                    oConExterna.Conectar();
                    oConExterna.CrearComando("SELECT product_id,name,description,enabled,created,created_by,updated,updated_by,bandwidth,simmetry,timeframe,access_type,n_access,volume_bytes,volume_time,fw_rule,ip_type,type,config FROM product_access order by name asc");
                    dtProductos = oConExterna.Tabla();
                    oConExterna.Desconectar();

                }
                catch (Exception)
                {
                    oConExterna.Desconectar();
                    throw;
                }

            }

            return dtProductos;
        }

        public Int32 GuardarCustomerEquipment(int idAccesAccount, int idEquipment)
        {
            Int32 salida = 0;
            oConExterna.conexionString = Isp.cadenaConexion;
            try
            {
                oConExterna.Conectar();
                oConExterna.CrearComando("insert into account_equipments (account,equipment) values (@idaccount,@idequipment)");
                oConExterna.AsignarParametroEntero("@idaccount", idAccesAccount);
                oConExterna.AsignarParametroEntero("@idequipment", idEquipment);
                oConExterna.ComenzarTransaccion();
                oConExterna.EjecutarComando();
                oConExterna.ConfirmarTransaccion();
                oConExterna.Desconectar();
            }
            catch (Exception)
            {
                oConExterna.CancelarTransaccion();
                oConExterna.Desconectar();
                salida = -1;
                throw;
            }
            return salida;
        }

        public Int32 CortarServicio(int idAccesAccount)
        {
            int salida = 0;
            try
            {
                oConExterna.Conectar();
                oConExterna.CrearComando("UPDATE account_access SET product_id=103 where account_id=@id");
                oConExterna.AsignarParametroEntero("@id", idAccesAccount);
                oConExterna.ComenzarTransaccion();
                oConExterna.EjecutarComando();
                oConExterna.ConfirmarTransaccion();
                oConExterna.Desconectar();
            }
            catch (Exception)
            {
                salida = -1;
                oConExterna.CancelarTransaccion();
                oConExterna.Desconectar();
                throw;
            }
            return salida;
        }

        public Int32 BajarServicio(int idAccesAccount)
        {
            try
            {
                oConExterna.Conectar();
                oConExterna.CrearComando("UPDATE account_access SET product_id=123 where account_id=@id");
                oConExterna.AsignarParametroEntero("@id", idAccesAccount);
                oConExterna.ComenzarTransaccion();
                oConExterna.EjecutarComando();
                oConExterna.ConfirmarTransaccion();
                oConExterna.Desconectar();
                return 0;
            }
            catch (Exception)
            {
                oConExterna.CancelarTransaccion();
                oConExterna.Desconectar();
                return -1;
            }
        }
   
        public DataTable ListarEquiposPorAccount(int idAccount)
        {
            DataTable dt = new DataTable();

            try
            {
                oConExterna.Conectar();
                oConExterna.CrearComando("SELECT account_equipments.equipment,equipments.mac,equipments.serial,equipments.brand,equipments.model,equipments.ip,equipments.user,equipments.password from account_equipments left join equipments on equipments.id=account_equipments.equipment where account=@id_account");
                oConExterna.AsignarParametroEntero("@id_account", idAccount);
                dt = oConExterna.Tabla();
                oConExterna.Desconectar();
            }
            catch (Exception)
            {
                oConExterna.Desconectar();
                throw;
            }
            return dt;

        }

        public DataTable ListarAccessAccountPorCustomerLocation(int idCustomer, int idLocation = 0)
        {
            DataTable dt = new DataTable();
            try
            {
                oConExterna.Conectar();
                if (idLocation > 0)
                {
                    oConExterna.CrearComando("SELECT * FROM account_access where customer_id=@id_customer and location_id=@id_location");
                    oConExterna.AsignarParametroEntero("@id_customer", idCustomer);
                    oConExterna.AsignarParametroEntero("@id_location", idLocation);
                }
                else
                {
                    oConExterna.CrearComando("SELECT * FROM account_access where customer_id=@id_customer");
                    oConExterna.AsignarParametroEntero("@id_customer", idCustomer);
                }

                dt = oConExterna.Tabla();
                oConExterna.Desconectar();
            }
            catch (Exception)
            {
                oConExterna.Desconectar();
            }
            return dt;
        }

        public Int32 DesafectarEquipo(int idAccountAccess, int idEquipment)
        {
            try
            {
                oConExterna.Conectar();
                oConExterna.CrearComando("delete from account_equipments where account=@id_account and equipment=@id_equipment");
                oConExterna.AsignarParametroEntero("@id_account", idAccountAccess);
                oConExterna.AsignarParametroEntero("@id_equipment", idEquipment);
                oConExterna.ComenzarTransaccion();
                oConExterna.EjecutarComando();
                oConExterna.ConfirmarTransaccion();
                oConExterna.Desconectar();
            }
            catch (Exception)
            {
                oConExterna.CancelarTransaccion();
                oConExterna.Desconectar();
                return -1;
            }
            return 0;
        }

        public Int32 DesafectarPorEquipo(int idEquipment)
        {
            try
            {
                oConExterna.Conectar();
                oConExterna.CrearComando("delete from account_equipments where and equipment=@id_equipment");
                oConExterna.AsignarParametroEntero("@id_equipment", idEquipment);
                oConExterna.ComenzarTransaccion();
                oConExterna.EjecutarComando();
                oConExterna.ConfirmarTransaccion();
                oConExterna.Desconectar();
            }
            catch (Exception)
            {
                oConExterna.CancelarTransaccion();
                oConExterna.Desconectar();
                return -1;
            }
            return 0;
        }

        public DataTable ListarAccessAccount(int idCustomer, int idLocation = 0)
        {
            DataTable dt = new DataTable();
            try
            {
                oConExterna.Conectar();
                if (idLocation > 0)
                {
                    oConExterna.CrearComando("SELECT account_access.account_id,account_access.product_id,account_access.customer_id,account_access.location_id,product_Access.name,account_access.enabled,if (account_access.enabled=0,'INACTIVO','ACTIVO') AS activo,account_access.username,account_access.password,account_access.ip,account_access.notes FROM account_access left join product_access on product_access.product_id=account_access.product_id  where customer_id=@id_customer and location_id=@id_location");
                    oConExterna.AsignarParametroEntero("@id_customer", idCustomer);
                    oConExterna.AsignarParametroEntero("@id_location", idLocation);

                }
                else
                {
                    oConExterna.CrearComando("SELECT account_access.account_id,account_access.product_id,account_access.customer_id,account_access.location_id,product_Access.name,account_access.enabled,if (account_access.enabled=0,'INACTIVO','ACTIVO') AS activo,account_access.username,account_access.password,account_access.ip,account_access.notes FROM account_access left join product_access on product_access.product_id=account_access.product_id where customer_id=@id_customer");
                    oConExterna.AsignarParametroEntero("@id_customer", idCustomer);
                }
                dt = oConExterna.Tabla();
                oConExterna.Desconectar();
            }
            catch (Exception c)
            {
                string tex = c.Message;
                oConExterna.Desconectar();
                throw;
            }
            return dt;
        }

        public Int32 CambiarProducto(int idAccessAccount, int idProductoNuevo)
        {
            try
            {
                oConExterna.Conectar();
                oConExterna.CrearComando("UPDATE account_access set product_id=@producto where account_id=@account");
                oConExterna.AsignarParametroEntero("@account", idAccessAccount);
                oConExterna.AsignarParametroEntero("@producto", idProductoNuevo);
                oConExterna.ComenzarTransaccion();
                oConExterna.EjecutarComando();
                oConExterna.ConfirmarTransaccion();
                oConExterna.Desconectar();
                return 0;
            }
            catch (Exception)
            {
                oConExterna.Desconectar();
                return -1;

            }
        }

        public DataTable ListarDatosConexion(int idAccess)
        {
            DataTable dt = new DataTable();
            try
            {
                oConExterna.Conectar();
                oConExterna.CrearComando("select radius.radacct.NASIPAddress AS 'ROUTER_ACCESO',"
                + " radius.radacct.FramedIPAddress AS 'IP_CONEXION',"
                + " radius.radacct.CallingStationId AS 'MAC_conexion',"
                + " radius.radacct.FramedProtocol AS 'Protocolo_conexion',"
                + " radius.radacct.CalledStationId AS 'VLAN_conexion',"
                + " radius.radacct.AcctStartTime AS 'Tiempo_de_conexion',"
                + " radius.radacct.AcctSessionTime AS 'Segundos_conectado',"
                + " radius.radacct.UserName,"
                + " isptb.account_access.customer_id"
                + " from radius.radacct"
                + " left join isptb.account_access  on isptb.account_access.username = radacct.username"
                + " where isptb.account_access.account_id = @id order by radius.radacct.radacctid desc limit 1");
                oConExterna.AsignarParametroEntero("@id", idAccess);
                dt = oConExterna.Tabla();
                oConExterna.Desconectar();
            }
            catch (Exception c)
            {
                oConExterna.Desconectar();
                string mensahe = c.Message;
                throw;
            }
            return dt;
        }

        public string GetIpRedacct(int idAccessAccount)
        {
            DataTable dt = new DataTable();
            string ip = string.Empty;
            try
            {
                Isp.cadenaConexion = "server=192.168.2.55;user=avcbd;pwd=avcdadmin;database=isptb;port=3306";
                oConExterna.Conectar();
                oConExterna.CrearComando("SELECT nas_ip FROM radacct_isp WHERE account_id=@id order by start_date desc limit 1");
                oConExterna.AsignarParametroEntero("@id", idAccessAccount);
                dt = oConExterna.Tabla();
                oConExterna.Desconectar();
            }
            catch (Exception)
            {
                oConExterna.Desconectar();
                throw;
            }
            if (dt.Rows.Count > 0)
                ip = dt.Rows[0]["nas_ip"].ToString();
            return ip;
        }

        public Boolean GenerarActivacion(DataTable dtUsuariosServicios, out string Resultado, out int estadoOperacion)
        {
            int estadoOperacionFinal = 0;
            try 
            { 
                //FILTRO LA TABLA ENVIADA PARA AQUELLOS SERVICIOS QUE UNICAMENTE ESTAN ASOCIADOS AL ISP
                DataTable tablaFiltrada = dtUsuariosServicios.AsEnumerable()
                                .Where(r => r.Field<int>("idAppExt") == (int)Aplicaciones_Externas.Aplicacion_Externa.ISP)
                                .CopyToDataTable();
                DataTable dtRelacion = new DataTable();

                //DECLARACIONES DE LAS VARAIBLES EN BASE A LA TABLA QUE SE PASA COMO PARAMETRO
                int idCustomerIsp = 0;
                int idLocationIsp = 0;
                int idEquipoIsp = 0;
                string resultadoInterno = "";
                int codUsuIsp = Convert.ToInt32(tablaFiltrada.Rows[0]["codUsu"]);
                int idUsuarioGies = Convert.ToInt32(tablaFiltrada.Rows[0]["id_usuario"]);
                int id_usuario_locacion_isp = Convert.ToInt32(tablaFiltrada.Rows[0]["id_usuarios_locaciones"]);
                string NombreUsuIsp = tablaFiltrada.Rows[0]["nombreUsu"].ToString();
                string ApellidoUsuIsp = tablaFiltrada.Rows[0]["apellidoUsu"].ToString();
                int IdAccesAccountIsp = 0;
                string varAuxIsp = " ";


                idCustomerIsp = this.VerificarExisteUsuario(codUsuIsp);
                idLocationIsp = this.VerificarExisteLocacion(id_usuario_locacion_isp);
                if (idCustomerIsp == 0)
                {
                    idCustomerIsp = this.GuardarUsuario(codUsuIsp, NombreUsuIsp, ApellidoUsuIsp, "Sin-Email");
                    if (idCustomerIsp > 0)
                        resultadoInterno += "\nCuenta Creada Correctamente.";
                }
                else
                    resultadoInterno += $"\nUsuario Codigo: {codUsuIsp} / CodigoIsp: {idCustomerIsp} ya existente en el ISP.";

                if (idLocationIsp == 0)
                {
                    idLocationIsp = this.GuardarLocacion(id_usuario_locacion_isp, idCustomerIsp, NombreUsuIsp, varAuxIsp, varAuxIsp, varAuxIsp, varAuxIsp, varAuxIsp, varAuxIsp, varAuxIsp, varAuxIsp, varAuxIsp); ;
                    if (idLocationIsp > 0)
                        resultadoInterno += "\nLocacion creada correctamente";
                }
                else
                    resultadoInterno += $"\nLocacion {idLocationIsp} ya existente en el isp.";

                foreach(DataRow dr in tablaFiltrada.Rows)
                {
                    idEquipoIsp = 0;
                    idEquipoIsp = this.VerificarExisteEquipo(dr["serie"].ToString(), dr["Mac"].ToString());
                    if (idEquipoIsp == 0)
                    {
                        idEquipoIsp = this.GuardarEquipo(dr["Serie"].ToString(), dr["mac"].ToString(), dr["equipo_usuario"].ToString(), dr["equipo_clave"].ToString(), dr["equipo_ip"].ToString(), dr["marca"].ToString(), dr["Modelo"].ToString());
                        resultadoInterno += $"\nEquipo generado correctamente.";
                    }
                    else 
                    { 
                        this.DesafectarPorEquipo(idEquipoIsp);
                        resultadoInterno += $"\nEl equipo con id {idEquipoIsp} se encontraba asignado a otro usuario. Se desafecto correctamente.";                   
                    }

                    if (idEquipoIsp > 0 && idLocationIsp > 0 && idCustomerIsp > 0)
                    {
                        //LISTO LAS RELACIONES PARA EL TIPO DE VELOCIDAD Y LA VELOCIDAD QUE POSEE EL ABONADO
                        if(Convert.ToInt32(dr["id_velocidad"]) > 0 && Convert.ToInt32(dr["idtipovelocidad"]) > 0)
                        {
                            dtRelacion = oVel.ListarRelacionesExternasPorVelocidades(Convert.ToInt32(dr["id_velocidad"]), Convert.ToInt32(dr["idtipovelocidad"]));
                            if (dtRelacion.Rows.Count > 0)
                            {
                                //DEJO EL FOREACH POR LAS DUDAS SI EN ALGUN MOMENTO SE ASIGNA MAS DE UNA RELACION , PERO NO DEBERIA PASAR, SIEMPRE EN DT RELACION DEBERIA HABER UN REGISTRO
                                foreach (DataRow drRelacion in dtRelacion.Rows)
                                {
                                    IdAccesAccountIsp = this.GuardarAccesAccount(idCustomerIsp, Convert.ToInt32(drRelacion["id_paquete_externo"]), idLocationIsp, dr["equipo_usuario"].ToString(), dr["equipo_clave"].ToString(), dr["equipo_ip"].ToString(), dr["mac"].ToString());
                                    resultadoInterno += $"\nPaquetes asignados correctamente.";
                                    if (IdAccesAccountIsp > 0)
                                    {
                                        if (this.GuardarCustomerEquipment(IdAccesAccountIsp, idEquipoIsp) == 0)
                                        {
                                            if (oApp.GuardarUsuarioProducto(idUsuarioGies, id_usuario_locacion_isp, Convert.ToInt32(drRelacion["id_paquete_externo"]), IdAccesAccountIsp, idCustomerIsp, idLocationIsp, Personal.Id_Login) == 0)
                                            {
                                                resultadoInterno += $"\nOperaciones realizadas correctamente.";
                                                estadoOperacionFinal = (int)Aplicaciones_Externas.Estado_Acciones.EXITOSA;
                                            }
                                            else
                                            {
                                                resultadoInterno += $"\nNo se guardaron los datos en el GIES. ";
                                                estadoOperacionFinal = (int)Aplicaciones_Externas.Estado_Acciones.PENDIENTE;
                                            }
                                        }
                                        else
                                        {
                                            resultadoInterno += $"\nNo se guardo el customer equipment.";
                                            estadoOperacionFinal = (int)Aplicaciones_Externas.Estado_Acciones.PENDIENTE;
                                        }
                                    }
                                    else
                                    {
                                        estadoOperacionFinal = (int)Aplicaciones_Externas.Estado_Acciones.PENDIENTE;
                                        resultadoInterno += $"\nNo se pudo establecer la relacion equipo-cuenta";
                                    }

                                }
                            }
                            else
                            {
                                estadoOperacionFinal = (int)Aplicaciones_Externas.Estado_Acciones.FALLIDA;
                                resultadoInterno += $"\nNo hay relaciones establecidas para la velocidad {dr["velocidad"].ToString()} de tipo {dr["tipovelocidad"].ToString()}";
                            }
                        }
                        else
                        {
                            estadoOperacionFinal = (int)Aplicaciones_Externas.Estado_Acciones.FALLIDA;
                            resultadoInterno += $"\nVelocidad indefinida en el usuario.";
                        }                                          
                    }
                    else
                    {
                        estadoOperacionFinal = (int)Aplicaciones_Externas.Estado_Acciones.FALLIDA;
                        resultadoInterno += $"\nHUBO UNA FALLA, NO SE ASIGNARON CORRECTAMENTE LOS PROCESOS ANTERIORES.CUSTOMERID,LOCATIONID,EQUIPOID";
                    }
  
                }
                estadoOperacion = estadoOperacionFinal;
                Resultado = resultadoInterno;
                return true;
            }
            catch(Exception e)
            {
                estadoOperacionFinal = (int)Aplicaciones_Externas.Estado_Acciones.FALLIDA;
                estadoOperacion = estadoOperacionFinal;
                Resultado = $"{e.ToString()}";
                return false;
            }
        }

        public Boolean GenerarCorteDeServicioIsp(DataTable dtInfoUsuario, out string Resultado, out int estadoOperacion)
        {

            DataTable tablaFiltrada = dtInfoUsuario.AsEnumerable()
                .Where(r => r.Field<int>("idAppExt") == (int)Aplicaciones_Externas.Aplicacion_Externa.ISP)
                .CopyToDataTable();
            DataTable dtCortar = new DataTable();
            DataTable dtRelacion = new DataTable();

            int idCustomerIsp = 0;
            int idLocationIsp = 0;
            int idAccesAccount = 0;
            int codUsuIsp = Convert.ToInt32(tablaFiltrada.Rows[0]["codUsu"]);
            int id_usuario_locacion_isp = Convert.ToInt32(tablaFiltrada.Rows[0]["id_usuarios_locaciones"]);
            string resultadointerno = "";
            int estadoInterno = 0;

            try
            {
                idCustomerIsp = this.VerificarExisteUsuario(codUsuIsp);
                idLocationIsp = this.VerificarExisteLocacion(id_usuario_locacion_isp);

                if (idCustomerIsp > 0 && idLocationIsp > 0)
                    dtCortar = this.ListarAccessAccountPorCustomerLocation(idCustomerIsp, idLocationIsp);
                else if (idCustomerIsp > 0)
                    dtCortar = this.ListarAccessAccountPorCustomerLocation(idCustomerIsp);
                else
                    resultadointerno += "\nNo existe el el abonado en el ISP";

                if (dtCortar.Rows.Count > 0)
                {
                    foreach (DataRow drCorte in dtCortar.Rows)
                    {
                        idAccesAccount = 0;
                        idAccesAccount = Convert.ToInt32(drCorte["account_id"]);

                        if (idAccesAccount > 0)
                        {
                            if (this.CortarServicio(idAccesAccount) == 0)
                            {
                                foreach (DataRow dr in tablaFiltrada.Rows)
                                {
                                    dtRelacion = oVel.ListarRelacionesExternasPorVelocidades(Convert.ToInt32(dr["id_velocidad"]), Convert.ToInt32(dr["idtipovelocidad"]));
                                    foreach (DataRow drRelacion in dtRelacion.Rows)
                                    {
                                        if (oApp.CambiarProducto(idAccesAccount, 103, Convert.ToInt32(drRelacion["id_paquete_externo"])) == 0)
                                        {
                                            estadoInterno = (int)Aplicaciones_Externas.Estado_Acciones.EXITOSA;
                                        }
                                        else
                                        {
                                            resultadointerno += $"\nFaltan grabar datos en el GIES.";
                                            estadoInterno = (int)Aplicaciones_Externas.Estado_Acciones.PENDIENTE;
                                        }
                                    }

                                }
                                resultadointerno += $"\nCorte generado correctamente en el isp. Account Acces : {idAccesAccount}";
                            }
                            else
                            {
                                estadoInterno = (int)Aplicaciones_Externas.Estado_Acciones.FALLIDA;
                                resultadointerno += $"\nNo se pudo generar el corte para este account access:{idAccesAccount} ";
                            }

                        }
                    }
                    estadoOperacion = estadoInterno;
                    Resultado = resultadointerno;
                    return true;
                }
                else
                {
                    estadoInterno = (int)Aplicaciones_Externas.Estado_Acciones.FALLIDA;
                    estadoOperacion = estadoInterno;
                    resultadointerno += "\nNo se pudo generar el corte, el usuario no posee una cuenta de acceso en el isp";
                    Resultado = resultadointerno;
                    return false;
                }
            }
            catch (Exception)
            {
                estadoInterno = (int)Aplicaciones_Externas.Estado_Acciones.FALLIDA;
                estadoOperacion = estadoInterno;
                resultadointerno += "\nERROR AL GENERAR CORTES EN EL ISP";
                Resultado = resultadointerno;
                return false;
                throw;
            }


        }

        public Boolean generarReactivaciondeServicioIsp(DataTable dtInfoUsuario, out string Resultado, out int estadoOperacion)
        {

            DataTable tablaFiltrada = dtInfoUsuario.AsEnumerable()
                .Where(r => r.Field<int>("idAppExt") == (int)Aplicaciones_Externas.Aplicacion_Externa.ISP)
                .CopyToDataTable();
            DataTable dtReactivar = new DataTable();
            DataTable dtRelacion = new DataTable();

            int idCustomerIsp = 0;
            int idLocationIsp = 0;
            int idAccesAccount = 0;
            int codUsuIsp = Convert.ToInt32(tablaFiltrada.Rows[0]["codUsu"]);
            int id_usuario_locacion_isp = Convert.ToInt32(tablaFiltrada.Rows[0]["id_usuarios_locaciones"]);
            string resultadointerno = "";
            int estadoInterno = 0;
            try
            {
                idCustomerIsp = this.VerificarExisteUsuario(codUsuIsp);
                idLocationIsp = this.VerificarExisteLocacion(id_usuario_locacion_isp);
                if (idCustomerIsp > 0 && idLocationIsp > 0)
                    dtReactivar = this.ListarAccessAccountPorCustomerLocation(idCustomerIsp, idLocationIsp);
                else if (idCustomerIsp > 0)
                    dtReactivar = this.ListarAccessAccountPorCustomerLocation(idCustomerIsp);
                else
                    resultadointerno += "\nNo existe el el abonado en el ISP";

                if (dtReactivar.Rows.Count > 0)
                {
                    foreach (DataRow drCorte in dtReactivar.Rows)
                    {
                        idAccesAccount = 0;
                        idAccesAccount = Convert.ToInt32(drCorte["account_id"]);

                        if (idAccesAccount > 0)
                        {
                            foreach (DataRow dr in tablaFiltrada.Rows)
                            {
                                dtRelacion = oVel.ListarRelacionesExternasPorVelocidades(Convert.ToInt32(dr["id_velocidad"]), Convert.ToInt32(dr["idtipovelocidad"]));
                                foreach (DataRow drRelacion in dtRelacion.Rows)
                                {
                                    if (this.CambiarProducto(idAccesAccount, Convert.ToInt32(drRelacion["id_paquete_externo"])) == 0)
                                    {
                                        if (oApp.CambiarProducto(idAccesAccount, Convert.ToInt32(drRelacion["id_paquete_externo"]), 103) == 0)
                                            estadoInterno = (int)Aplicaciones_Externas.Estado_Acciones.EXITOSA;
                                        else
                                        {
                                            estadoInterno = (int)Aplicaciones_Externas.Estado_Acciones.PENDIENTE;
                                            resultadointerno += "\nFaltan grabar datos en el GIES";
                                        }
                                    }
                                    else
                                    {
                                        estadoInterno = (int)Aplicaciones_Externas.Estado_Acciones.FALLIDA;
                                        resultadointerno += "\nNo se pudo generar la reconexion correctamente";
                                    }
                                }
                            }
                            resultadointerno += $"\nReactivacion generada correctamente en el isp. Account Acces : {idAccesAccount}";
                        }
                    }
                    estadoOperacion = estadoInterno;
                    resultadointerno += "\nReactivacion generada correctamente.";
                    Resultado = resultadointerno;
                    return true;
                }
                else
                {
                    estadoInterno = (int)Aplicaciones_Externas.Estado_Acciones.FALLIDA;
                    estadoOperacion = estadoInterno;
                    resultadointerno += "\nNo se pudo generar la reactivacion, el usuario no posee una cuenta de acceso en el isp";
                    Resultado = resultadointerno;
                    return false;
                }
            }
            catch (Exception)
            {
                estadoInterno = (int)Aplicaciones_Externas.Estado_Acciones.FALLIDA;
                estadoOperacion = estadoInterno;
                resultadointerno += "\nERROR AL GENERAR REACTIVACIONES.";
                Resultado = resultadointerno;
                return false;
                throw;
            }
           
        }

        public Boolean generarBajaISP(DataTable dtInfoUsuario, out string Resultado, out int estadoOperacion)
        {

            DataTable tablaFiltrada = dtInfoUsuario.AsEnumerable()
               .Where(r => r.Field<int>("idAppExt") == (int)Aplicaciones_Externas.Aplicacion_Externa.ISP)
               .CopyToDataTable();
            DataTable dtEliminar = new DataTable();
            DataTable dtRelacion = new DataTable();

            int idCustomerIsp = 0;
            int idLocationIsp = 0;
            int idAccesAccount = 0;
            int codUsuIsp = Convert.ToInt32(tablaFiltrada.Rows[0]["codUsu"]);
            int id_usuario_locacion_isp = Convert.ToInt32(tablaFiltrada.Rows[0]["id_usuarios_locaciones"]);
            string resultadointerno = "";
            int estadoInterno = 0;
            try
            {
                idCustomerIsp = this.VerificarExisteUsuario(codUsuIsp);
                idLocationIsp = this.VerificarExisteLocacion(id_usuario_locacion_isp);

                if (idCustomerIsp > 0 && idLocationIsp > 0)
                    dtEliminar = this.ListarAccessAccountPorCustomerLocation(idCustomerIsp, idLocationIsp);
                else if (idCustomerIsp > 0)
                    dtEliminar = this.ListarAccessAccountPorCustomerLocation(idCustomerIsp);
                else
                    resultadointerno += "\nNo existe el el abonado en el ISP";

                if (dtEliminar.Rows.Count > 0)
                {
                    foreach (DataRow drCorte in dtEliminar.Rows)
                    {
                        idAccesAccount = 0;
                        idAccesAccount = Convert.ToInt32(drCorte["account_id"]);

                        if (idAccesAccount > 0)
                        {
                            foreach (DataRow dr in tablaFiltrada.Rows)
                            {
                                dtRelacion = oVel.ListarRelacionesExternasPorVelocidades(Convert.ToInt32(dr["id_velocidad"]), Convert.ToInt32(dr["idtipovelocidad"]));
                                foreach (DataRow drRelacion in dtRelacion.Rows)
                                {
                                    if (this.BajarServicio(idAccesAccount) == 0)
                                    {
                                        if(oApp.CambiarProducto(idAccesAccount, 123, Convert.ToInt32(drRelacion["id_paquete_externo"])) == 0)
                                        {
                                            estadoInterno = (int)Aplicaciones_Externas.Estado_Acciones.EXITOSA;
                                        }
                                        else
                                        {
                                            estadoInterno = (int)Aplicaciones_Externas.Estado_Acciones.PENDIENTE;
                                            resultadointerno += "\nFalta guardar datos en GIES";
                                        }
                                    }
                                    else
                                    {
                                        estadoInterno = (int)Aplicaciones_Externas.Estado_Acciones.PENDIENTE;
                                        resultadointerno += "\nNo se pudo generar la baja correctamente del servicio";
                                    }

                                }

                            }
                            resultadointerno += $"\nBaja de cuenta generada correctamente en el isp. Account Acces : {idAccesAccount}";
                        }
                    }
                    estadoOperacion = estadoInterno;
                    resultadointerno += "\nBaja generada correctamente.";
                    Resultado = resultadointerno;
                    return true;
                }
                else
                {
                    estadoInterno = (int)Aplicaciones_Externas.Estado_Acciones.FALLIDA;
                    estadoOperacion = estadoInterno;
                    resultadointerno += "\nNo se pudo generar la baja, el usuario no posee una cuenta de acceso en el isp";
                    Resultado = resultadointerno;
                    return false;
                }
            }
            catch (Exception)
            {
                estadoInterno = (int)Aplicaciones_Externas.Estado_Acciones.FALLIDA;
                estadoOperacion = estadoInterno;
                resultadointerno += "\nERROR AL GENERAR BAJAS";
                Resultado = resultadointerno;
                return false;
                throw;
            }
        }

    }
}
