using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace CapaNegocios
{
    public class Cass
    {
        #region [DECLARACIONES]
        private ConexionesExternas oConExterna = new ConexionesExternas();
        private Conexion oConexion = new Conexion();
        private Aplicaciones_Externas oAppExterna = new Aplicaciones_Externas();
        private string parametro;
        private int idAppExt;
        static DataTable dtInfoCompletaUsuarioServicioCass = new DataTable();
        static DataTable dtPaquetesCass = new DataTable();
        DataTable dtParametrosExt = new DataTable();
        DataTable dtParametros = new DataTable();
        DataTable dtTarjetasFinal = new DataTable();
        public enum ESTADOS_TARJETAS
        {
            ASIGNADA = 1,
            SIN_ASIGNAR = 2,
            FALLO_TARJETA = 3
        }

        public enum FILTROS_GET_DATA
        {
            ID_PARTE = 1,
            ID_USUARIO_SERVICIO=2
        }
        #endregion

        #region [METODOS]
        private Conexion oCon = new Conexion();

        public Cass(int idAppExterna)
        {
            idAppExt = idAppExterna;
            parametro = ObetenerParametro();
            Aplicaciones_Externas oAppExterna = new Aplicaciones_Externas();
            DataTable dtDatosAppExterna = oAppExterna.Listar(idAppExterna);
            if(dtDatosAppExterna.Rows.Count>0)
            {
                oConExterna.conexionString = dtDatosAppExterna.Rows[0]["string_conexion"].ToString();

            }
        }

        public DataTable ListarUsuariosSistemaViejo()
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT cass_usuarios.id as id_cass_usuarios,cass_usuarios.realizado as realizado,usuarios.id AS Id_Usu,Concat(usuarios.Apellido, ' , ' ,usuarios.Nombre)AS Usuario,usuarios.Codigo AS Codigo_Gies, " +
                    "cass_usuarios.codpaq AS Codigo_Paquete, cass_usuarios.nompaq AS Nombre_Paquete, cass_usuarios.codusu AS Codigo_Viejo, " +
                    "cass_usuarios.tipser AS Servicio, cass_usuarios.estado AS Estado, ifnull(cass_usuarios.numtar, 0) AS Tarjeta " +
                    "FROM cass_usuarios " +
                    "LEFT JOIN usuarios ON usuarios.Codigo = cass_usuarios.codusu " +
                    "WHERE usuarios.borrado = 0 GROUP BY usuarios.Codigo,cass_usuarios.codpaq,cass_usuarios.numtar ");
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch { }

            return dt;
        }
        private string ObetenerParametro()
        {
            string salida = "";
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("select parametros from aplicaciones_externas where nombre='CASS'");
                dt = oCon.Tabla();
                oCon.DesConectar();
                if(dt.Rows.Count>0)
                  salida = dt.Rows[0][0].ToString();
            }
            catch (Exception c)
            {
                oCon.DesConectar();
                salida = c.Message;
            }
            return salida;
        }
      
        public Boolean PausarPaquetesAbonado(int IdUsuario, out String salida)
        {
            try
            {
                if (VerificarAbonadoExistente(IdUsuario))
                {
                    oConExterna.Conectar();

                    Usuarios Usuarios = new Usuarios();
                    DataRow DataUsuario = Usuarios.getDatos(IdUsuario);

                    String Codigo = String.Format("{0}{1}", parametro, DataUsuario["codigo"].ToString().PadLeft(6, '0'));
                    String queryPausar = String.Format("call PausarSuscriptor({0}, '{1}', {2})", 0, Codigo, 1);

                    oConExterna.CrearComando(queryPausar);
                    oConExterna.EjecutarComando();
                    oConExterna.Desconectar();
                    salida = "Abonado pausado correctamente";
                    return true;
                }
                else
                {
                    salida = "El abonado no se encuentra en el cass";
                    return false;
                }

            }
            catch (Exception c)
            {
                oConExterna.Desconectar();
                salida = "Hubo un error al intentar pausar al abonado";
                return false;
            }
        }

        public Boolean ReactivarPaquetesAbonado(int IdUsuario, out string Salida)
        {
            try
            {
                if (VerificarAbonadoExistente(IdUsuario)) 
                { 
                    oConExterna.Conectar();


                    Usuarios Usuarios = new Usuarios();
                    DataRow DataUsuario = Usuarios.getDatos(IdUsuario);

                    String Codigo = String.Format("{0}{1}", parametro, DataUsuario["codigo"].ToString().PadLeft(6, '0'));
                    String queryReactivar = String.Format("call PausarSuscriptor({0}, '{1}', {2})", 0, Codigo, 0);

                    oConExterna.CrearComando(queryReactivar);
                    oConExterna.EjecutarComando();
                    oConExterna.Desconectar();
                    Salida = "Reactivacion generada correctamente";
                    return true;
                }
                else
                {
                    Salida = "Abonado no encontrado en el CASS.";
                    return false;
                }

            }
            catch (Exception c)
            {
                oConExterna.Desconectar();
                Salida = "Hubo un error al generar la reactivacion";
                return false;
            }
        }

        public Boolean GenerarCuentaAbonado(int id_usuario,string numTarjeta, int id_TipoFac, out string salida)
        {
            oConExterna.Conectar();
            Usuarios Usuarios = new Usuarios();
            DataRow DataUsuario = Usuarios.getDatos(id_usuario);
            dtParametrosExt = oAppExterna.ListarParametros(idAppExt);
            dtParametros = oAppExterna.ListarParametros_Det(id_TipoFac, idAppExt);

            int Cell = 0, UserArea = 0, UserRoad = 0, Casco = 0, id_usu = 0, StationId = 0, TodoOk = 1;
            String Valores_SinAsignar = "";
            String Usuario = String.Format("{0} {1}", DataUsuario["apellido"], DataUsuario["nombre"]);
            String Domicilio = DataUsuario["calle"].ToString();
            String Codigo = String.Format("{0}{1}", parametro, DataUsuario["codigo"].ToString().PadLeft(6, '0'));
            String Telefono = "12345";
            String Rel = "2";
            String FechaFin = DateTime.Now.ToString("yyyy-MM-dd");

            foreach (DataRow drInfo in dtParametros.Rows)
            {

                if (drInfo["nombre_externo"].ToString() == "StationID")
                    StationId = Convert.ToInt32(drInfo["Valor"].ToString());
                else if (drInfo["nombre_externo"].ToString() == "Cell")
                    Cell = Convert.ToInt32(drInfo["Valor"].ToString());
                else if (drInfo["nombre_externo"].ToString() == "UserArea")
                    UserArea = Convert.ToInt32(drInfo["Valor"].ToString());
                else if (drInfo["nombre_externo"].ToString() == "UserRoad")
                    UserRoad = Convert.ToInt32(drInfo["Valor"].ToString());
                else if (drInfo["nombre_externo"].ToString() == "Hamlet")
                    Casco = Convert.ToInt32(drInfo["Valor"].ToString());

                if (Convert.ToInt32(drInfo["Valor"]) == 0)
                {
                    Valores_SinAsignar = Valores_SinAsignar + "," + drInfo["nombre_externo"].ToString() + " id_TipoFac= " + drInfo["id_tipo_facturacion"] + "\n";
                    TodoOk = 0;
                }
            }

            if (dtParametros.Rows.Count != dtParametrosExt.Rows.Count)
            {
                Valores_SinAsignar = string.Empty;
                Valores_SinAsignar = "ID tipo de facturacion: " + id_TipoFac.ToString() + " No registrado.";
                TodoOk = 0;
            }

            if (TodoOk == 1)
            {
                reabrirCuentaAboando(Codigo);
                String queryAbriCuenta = String.Format("call AbrirCuentaSuscriptor('{0}', {1}, {2}, {3}, '{4}', '{5}', '{6}', '---' ,{7}, {8} , {9})", Usuario, Rel, UserArea, UserRoad, Domicilio, Codigo, Telefono, Casco, StationId, Cell);
                ActualizarCuentaAbonado(id_usuario);              
                String queryAsignarTarjeta = String.Format("call AsignarTarjetaASuscriptor('{0}', '{1}')", Codigo, numTarjeta);

                oConExterna.CrearComando(queryAbriCuenta);
                oConExterna.EjecutarComando();

                oConExterna.CrearComando(queryAsignarTarjeta);
                oConExterna.EjecutarComando();

                oConExterna.Desconectar();
                salida = "";
                return true;
            }
            else
                salida = "Faltan asignar los valores: " + Valores_SinAsignar.ToString();
            return false;

        }

        //ESTE METODO SE LLAMA CUANDO SE CUMPLEN LAS FUNCIONES DE ACTIVAR/DESACTIVAR/PAUSAR/REANUDAR Y SE TIENE QUE ACTUALIZAR LA CUENTA DEL ABONADO EN EL CASS
        //AL LLAMARSE SIEMPRE CUANDO INTERNAMENTE SE CUMPLE UNA FUNCION, ESTE NO REQUIERE DEL OCONEXTERNA.CONECTAR NI DEL OCONEXTERNA.DESCONECTAR.
        public void ActualizarCuentaAbonado(int id_usuario)
        {
            Usuarios Usuarios = new Usuarios();
            DataRow DataUsuario = Usuarios.getDatos(id_usuario);

            String Usuario = String.Format("{0} {1}", DataUsuario["apellido"], DataUsuario["nombre"]);
            String Domicilio = DataUsuario["calle"].ToString();
            String Codigo = String.Format("{0}{1}", parametro, DataUsuario["codigo"]).PadLeft(6, '0');
            String Telefono = "12345";
            String Tip = "2";
            String Rel = "2";

            String FechaFin = DateTime.Now.ToString("yyyy-MM-dd");

            String queryActualizarCuenta = String.Format("call ActualizarCuentaSuscriptor('{0}', {1}, {2}, {3}, '{4}', '{5}', '{6}', '---', {7}, {8}, '')", Usuario, Tip, Rel, Rel, Domicilio, Codigo, Telefono, Rel, Rel);
            oConExterna.CrearComando(queryActualizarCuenta);
            oConExterna.EjecutarComando();
            reabrirCuentaAboando(Codigo);
        }

        public void reabrirCuentaAboando(string codigo)
        {
            String queryReabrirCuenta = String.Format("call ReAbrirCuentaSuscriptor('{0}')", codigo);
            oConExterna.CrearComando(queryReabrirCuenta);
            oConExterna.EjecutarComando();
        }

        public Boolean validarTarjeta(string Tarjeta)
        {
            if (Tarjeta.Length == 16)
                return true;
            else
                return false;

        }

        public Boolean GenerarActivacion(DataTable dtTarjetas, int id_usuario, out string Resultado, bool activaServicioPeriodo = false, DateTime? fecha_programado = null)
        {
            string nombrePaquete = String.Empty;
            Usuarios_Servicios oUsuSer = new Usuarios_Servicios();
            DataTable dtInfotarjeta = new DataTable();
            DataTable dtInfotarjetaParte = new DataTable();
            DataTable dtSubServ = new DataTable();
            string resultado = "", ResultadoActivacion = "";
           
            try
            {
                if (dtTarjetas.Rows.Count > 0)
                {

                    foreach (DataRow dr in dtTarjetas.Rows)
                    {
                        if (this.validarTarjeta(dr["tarjeta"].ToString().Trim()) == false) 
                            resultado += "\nNumero de tarjeta no asignada o invalida";
                        else
                        {
                            dtInfotarjeta.Clear();
                            dtInfotarjeta = this.ListarInfoCompletaUsuario_Servicio(0, 1, dr["tarjeta"].ToString().Trim());
                            if(dtInfotarjeta.Rows.Count > 0) 
                            { 
                                //DT INFO TARJETA VA A TENER REGISTROS SIEMPRE Y CUANDO HAYA UN EQUIPO
                                if (!VerificarTarjetaExistenteAbonado(dr["tarjeta"].ToString().Trim(),id_usuario))
                                {
                                    foreach (DataRow drInfo in dtInfotarjeta.Rows)
                                    {
                                        if(activaServicioPeriodo == false)
                                        {
                                            dtSubServ = this.ObtenerPaquetesDtNuevo(Convert.ToInt32(drInfo["id_subserv"]));
                                            foreach (DataRow drSubServ in dtSubServ.Rows)
                                            {
                                                nombrePaquete = drSubServ["cass_paquete"].ToString();
                                                if (nombrePaquete != string.Empty)
                                                {
                                                    if (id_usuario > 0)
                                                    {
                                                        if (this.ActivarPaqueteNuevo(id_usuario, dr["tarjeta"].ToString().Trim(), nombrePaquete, Convert.ToInt32(dr["id_tipo_fac"]), out ResultadoActivacion))
                                                        {
                                                            oUsuSer.ActivarSubservicio(Convert.ToInt32(drInfo["id_usu_serv_sub"]));
                                                            this.ReactivarPaquetesAbonado(id_usuario, out ResultadoActivacion);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (this.ActivarPaqueteNuevo(Usuarios.CurrentUsuario.Id, dr["tarjeta"].ToString().Trim(), nombrePaquete, Convert.ToInt32(dr["id_tipo_fac"]), out ResultadoActivacion))
                                                        {
                                                            oUsuSer.ActivarSubservicio(Convert.ToInt32(drInfo["id_usu_serv_sub"]));
                                                            this.ReactivarPaquetesAbonado(Usuarios.CurrentUsuario.Id, out ResultadoActivacion);
                                                        }
                                                            
                                                    }
                                                }
                                            }

                                        }
                                        else
                                        {
                                            dtSubServ = this.ObtenerPaquetesDtNuevo(Convert.ToInt32(drInfo["id_subserv"]));
                                            foreach (DataRow drSubServ in dtSubServ.Rows)
                                            {
                                                nombrePaquete = drSubServ["cass_paquete"].ToString();
                                                if (nombrePaquete != string.Empty)
                                                {
                                                    if (id_usuario > 0)
                                                    {
                                                        if (this.ActivarPaqueteNuevo(id_usuario, dr["tarjeta"].ToString().Trim(), nombrePaquete, Convert.ToInt32(dr["id_tipo_fac"]), out ResultadoActivacion))
                                                        {
                                                            oUsuSer.ActivarSubservicio(Convert.ToInt32(drInfo["id_usu_serv_sub"]));
                                                            this.ReactivarPaquetesAbonado(id_usuario, out ResultadoActivacion);
                                                        }
                                                            
                                                    }
                                                    else
                                                    {
                                                        if (this.ActivarPaqueteNuevo(Usuarios.CurrentUsuario.Id, dr["tarjeta"].ToString().Trim(), nombrePaquete, Convert.ToInt32(dr["id_tipo_fac"]), out ResultadoActivacion))
                                                        {
                                                            oUsuSer.ActivarSubservicio(Convert.ToInt32(drInfo["id_usu_serv_sub"]));
                                                            this.ReactivarPaquetesAbonado(Usuarios.CurrentUsuario.Id, out ResultadoActivacion);
                                                        }
                                                           
                                                    }
                                                }
                                            }
                                        }

                                    }
                                    this.LimpiarDtPaquetesCass();
                                    resultado = resultado + $"\nPaquetes de la tarjeta {dr["tarjeta"].ToString()} Asignados correctamente.";
                                }
                                else
                                    resultado = resultado + $"\nLa tarjeta: {dr["tarjeta"].ToString()} ya se encuentra asignada en el CASS.";
                            }
                            else
                            {
                                //ACA VIENE CUANDO NO TENGA UN EQUIPO ASIGNADO PERO SI UNA TARJETA.
                                dtInfotarjetaParte.Clear();
                                dtInfotarjetaParte = this.ListarInfoCompletaPartesyUsuarioServicio(Convert.ToInt32(dr["id_usu_serv"]));
                                if (dtInfotarjetaParte.Rows.Count > 0)
                                {
                                    //DT INFO TARJETA VA A TENER REGISTROS SIEMPRE Y CUANDO HAYA UN EQUIPO
                                    if (!VerificarTarjetaExistente(dr["tarjeta"].ToString().Trim()))
                                    {
                                        foreach (DataRow drInfo in dtInfotarjetaParte.Rows)
                                        {
                                            if (activaServicioPeriodo == false)
                                            {
                                                if (Convert.ToInt32(drInfo["idModalidad"]) != (int)Servicios._Modalidad.DIA)
                                                {
                                                    dtSubServ = this.ObtenerPaquetesDtNuevo(Convert.ToInt32(drInfo["id_servicios_sub"]));
                                                    foreach (DataRow drSubServ in dtSubServ.Rows)
                                                    {
                                                        nombrePaquete = drSubServ["cass_paquete"].ToString();
                                                        if (nombrePaquete != string.Empty)
                                                        {
                                                            if (id_usuario > 0)
                                                            {
                                                                if (this.ActivarPaqueteNuevo(id_usuario, dr["tarjeta"].ToString().Trim(), nombrePaquete, Convert.ToInt32(dr["id_tipo_fac"]), out ResultadoActivacion))
                                                                {
                                                                    oUsuSer.ActivarSubservicio(Convert.ToInt32(drInfo["id_servicios_sub"]));
                                                                    this.ReactivarPaquetesAbonado(id_usuario, out ResultadoActivacion);
                                                                }
                                                                    
                                                            }
                                                            else
                                                            {
                                                                if (this.ActivarPaqueteNuevo(Usuarios.CurrentUsuario.Id, dr["tarjeta"].ToString().Trim(), nombrePaquete, Convert.ToInt32(dr["id_tipo_fac"]), out ResultadoActivacion))
                                                                {
                                                                    oUsuSer.ActivarSubservicio(Convert.ToInt32(drInfo["id_servicios_sub"]));
                                                                    this.ReactivarPaquetesAbonado(Usuarios.CurrentUsuario.Id, out ResultadoActivacion);
                                                                }
                                                                    
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                dtSubServ = this.ObtenerPaquetesDtNuevo(Convert.ToInt32(drInfo["id_servicios_sub"]));
                                                foreach (DataRow drSubServ in dtSubServ.Rows)
                                                {
                                                    nombrePaquete = drSubServ["cass_paquete"].ToString();
                                                    if (nombrePaquete != string.Empty)
                                                    {
                                                        if (id_usuario > 0)
                                                        {
                                                            if (this.ActivarPaqueteNuevo(id_usuario, dr["tarjeta"].ToString().Trim(), nombrePaquete, Convert.ToInt32(dr["id_tipo_fac"]), out ResultadoActivacion))
                                                            {
                                                                oUsuSer.ActivarSubservicio(Convert.ToInt32(drInfo["id_servicios_sub"]));
                                                                this.ReactivarPaquetesAbonado(id_usuario, out ResultadoActivacion);
                                                            }    
                                                        }
                                                        else
                                                        {
                                                            if (this.ActivarPaqueteNuevo(Usuarios.CurrentUsuario.Id, dr["tarjeta"].ToString().Trim(), nombrePaquete, Convert.ToInt32(dr["id_tipo_fac"]), out ResultadoActivacion))
                                                            {
                                                                oUsuSer.ActivarSubservicio(Convert.ToInt32(drInfo["id_servicios_sub"]));
                                                                this.ReactivarPaquetesAbonado(Usuarios.CurrentUsuario.Id, out ResultadoActivacion);
                                                            }
                                                                
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        this.LimpiarDtPaquetesCass();
                                        resultado = resultado + $"\nPaquetes de la tarjeta {dr["tarjeta"].ToString()} Asignados correctamente.";
                                    }
                                    else
                                        resultado = resultado + $"\nEl numero de tarjeta: {dr["tarjeta"].ToString()} ya se encuentra asignada en el CASS. Los paquetes de esta tarjeta no se asignaron";
                                }

                            }

                        }
                    }
                }
                else
                {
                    resultado = "ADVERTENCIA: Servicio/s sin tarjeta/s";
                    Resultado = resultado;
                    return false;
                }

                Resultado = resultado;
                return true;
            }
            catch
            {
                Resultado = resultado + "Hubo un error al activar los paquetes del cass.";
                return false;
            }
        }

        public Boolean ActivarPaqueteNuevo(int id_usuario,string numTarjeta, string paquete, int id_TipoFac, out string salida)
        {
            try
            {
                string SalidaTotal = "";
                if (!VerificarAbonadoExistente(id_usuario))
                {
                    string Tarjeta = numTarjeta;
                    string salidaExistente = "";
                    int id_TipoFacturacion = id_TipoFac;
                    int id_usu = id_usuario;
                    GenerarCuentaAbonado(id_usu, Tarjeta, id_TipoFacturacion, out salidaExistente);
                    SalidaTotal = SalidaTotal + salidaExistente;
                }
                oConExterna.Conectar();
                Usuarios Usuarios = new Usuarios();
                DataRow DataUsuario = Usuarios.getDatos(id_usuario);        
                String Codigo = String.Format("{0}{1}", parametro, DataUsuario["codigo"].ToString().PadLeft(6, '0'));

                String queryAsignarTarjeta = String.Format("call AsignarTarjetaASuscriptor('{0}', '{1}')", Codigo, numTarjeta);
                oConExterna.CrearComando(queryAsignarTarjeta);
                oConExterna.EjecutarComando();

                String AgregarProductoAtarjeta = String.Format("call AgregarProductoAtarjeta('{0}', '{1}', '{2}', {3}, {4})", numTarjeta.Trim(), paquete, DateTime.Now.ToString("yyyy-MM-dd"), 3, 10);
                oConExterna.CrearComando(AgregarProductoAtarjeta);
                oConExterna.EjecutarComando();

                oConExterna.Desconectar();
                ReactivarPaquetesAbonado(id_usuario, out salida);
                salida = "";
                return true;

            }
            catch (Exception c)
            {
                salida = c.Message;
                oConExterna.Desconectar();
                return false;
            }
        }

        public Boolean GenerarDesactivacionDePaquetes(DataTable dtTarjetas,int id_usuario, out string Resultado)
        {

            string nombrePaquete = String.Empty;
            Usuarios_Servicios oUsuSer = new Usuarios_Servicios();
            DataTable dtInfotarjeta = new DataTable();
            DataTable dtSubServ = new DataTable();
            string resultado = "",ResultadoDesactivacion = "";
            try
            {
                if (dtTarjetas.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtTarjetas.Rows)
                    {
                        dtInfotarjeta.Clear();
                        dtInfotarjeta = this.ListarInfoCompletaUsuario_Servicio(0, 1, dr["tarjeta"].ToString());
                        if (VerificarTarjetaExistente(dr["tarjeta"].ToString()))
                        {
                            foreach (DataRow drInfo in dtInfotarjeta.Rows)
                            {
                                dtSubServ = this.ObtenerPaquetesDtNuevo(Convert.ToInt32(drInfo["id_subserv"]));
                                foreach (DataRow drSubServ in dtSubServ.Rows)
                                {
                                    nombrePaquete = drSubServ["cass_paquete"].ToString();
                                    if (nombrePaquete != string.Empty)
                                    {
                                        if (id_usuario > 0)
                                        {
                                            if (this.DesactivarPaquete(id_usuario, dr["tarjeta"].ToString().Trim(), nombrePaquete, out ResultadoDesactivacion))
                                                oUsuSer.DesactivarSubservicio(Convert.ToInt32(drInfo["id_subserv"]));
                                        }
                                        else
                                        {
                                            if (this.DesactivarPaquete(Usuarios.CurrentUsuario.Id, dr["tarjeta"].ToString().Trim(), nombrePaquete, out ResultadoDesactivacion))
                                                oUsuSer.DesactivarSubservicio(Convert.ToInt32(drInfo["id_subserv"]));
                                        }
                                    }
                                }
                            }
                            this.LimpiarDtPaquetesCass();
                            resultado = resultado + $"\n\nPaquetes de la tarjeta {dr["tarjeta"].ToString()} Desactivados correctamente.";
                        }
                        else
                            resultado = resultado + $"\n\nEl numero de tarjeta: {dr["tarjeta"].ToString()} no se encuentra asignada en el CASS.";
                    }
                }
                else
                {
                    resultado = "ADVERTENCIA: Tarjeta/s no Asignada/s para desactivar paquetes.";
                    Resultado = resultado;
                    return false;
                }

                Resultado = resultado;
                return true;
            }
            catch
            {
                Resultado = resultado + "Hubo un error al activar los paquetes del cass.";
                return false;
            }
        }

        public Boolean DesactivarPaquete(Int32 id_usuario,string numTarjeta, string paquete, out string salida)
        {
            try
            {
                oConExterna.Conectar();
                String QuitarProductoAtarjeta = String.Format("call QuitarProductoDeTarjeta('{0}', '{1}')", numTarjeta.Trim(), paquete);
                oConExterna.CrearComando(QuitarProductoAtarjeta);
                oConExterna.EjecutarComando();

                ActualizarCuentaAbonado(id_usuario);

                oConExterna.Desconectar();

                salida = "";
                return true;

            }
            catch (Exception c)
            {
                salida = c.Message;
                oConExterna.Desconectar();
                return false;
            }
        }

        public Boolean GenerarEliminacionUsuario(DataTable dtTarjeta, int id_usuario , out string Resultado)
        {
            string salidaTotal = "";
            if (dtTarjeta.Rows.Count > 0)
            {
                foreach(DataRow dr in dtTarjeta.Rows)
                {
                    if (dr["Tarjeta"].ToString() != "")
                    {
                        if (EliminarTarjetaAbonado(dr["Tarjeta"].ToString().Trim()))
                            salidaTotal = salidaTotal + $"\nTarjeta {dr["Tarjeta"].ToString()} Eliminada correctamente";
                    }
                }               
            }
            else { 
                salidaTotal = "No hay tarjetas , reveer si los servicios asociados a esta accion poseen tarjetas asignadas.";
                Resultado = salidaTotal;
                return false;
            }

            if (VerificarAbonadoExistente(id_usuario))
            {
                Usuarios Usuarios = new Usuarios();
                DataRow DataUsuario = Usuarios.getDatos(id_usuario);
                String Codigo = String.Format("{0}{1}", parametro, DataUsuario["codigo"].ToString().PadLeft(6, '0'));
                if (EliminarCuentaAbonado(Codigo))
                    salidaTotal = salidaTotal + $"\nCuenta de usuario en el cass Cerrada correctamente.";
                else
                    salidaTotal = salidaTotal + $"\nNo se pudo cerrar la cuenta del usuario en el cass, verificarlo manualmente";
            }

            Resultado = salidaTotal;
            return true;
        }

        private Boolean EliminarCuentaAbonado(string CodigoUsuario)
        {
            try 
            { 
                oConExterna.Conectar();
                String queryCerrarCuenta = String.Format("call CerrarCuentaSuscriptor('{0}')", CodigoUsuario);
                oConExterna.CrearComando(queryCerrarCuenta);
                oConExterna.EjecutarComando();

                oConExterna.Desconectar();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        private Boolean EliminarTarjetaAbonado(string Tarjeta)
        {
            try
            {
                oConExterna.Conectar();
                String queryEliminarTarjeta = String.Format("call RegresarTarjetaDeSuscriptor('{0}')", Tarjeta.Trim());
                oConExterna.CrearComando(queryEliminarTarjeta);
                oConExterna.EjecutarComando();

                oConExterna.Desconectar();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public string ObtenerPaqueteString(int idSub)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT cass_paquete from cass where id_servicios_sub=@id");
                oCon.AsignarParametroEntero("@id", idSub);
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
                return string.Empty;
                throw;
            }
            if (dt.Rows.Count > 0)
                return dt.Rows[0]["cass_paquete"].ToString();
            else
                return string.Empty;
        }

        public DataTable ObtenerPaquetesDt(int idSub)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT cass_paquete from cass where borrado=0 and id_servicios_sub=@id");
                oCon.AsignarParametroEntero("@id", idSub);
                dt = oCon.Tabla();

                oCon.DesConectar();
                return dt;
            }
            catch (Exception)
            {
                oCon.DesConectar();
                return dt;
                throw;
            }
        }

        public DataTable ObtenerPaquetesDtNuevo(int idSub)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT cass_paquete from cass where borrado=0 and id_servicios_sub=@id");
                oCon.AsignarParametroEntero("@id", idSub);
                dt = oCon.Tabla();

                if (dtPaquetesCass.Rows.Count == 0)
                    dtPaquetesCass = dt.Copy();

                foreach (DataRow dr in dt.Rows)
                    dtPaquetesCass.ImportRow(dr);

                oCon.DesConectar();
                return dt;
            }
            catch (Exception)
            {
                oCon.DesConectar();
                return dt;
                throw;
            }
        }

        public DataTable ListarPaquetesTarjeta(double idTarjeta)
        {
            DataTable dtPaquetes = new DataTable();
            try
            {
                oConExterna.Conectar();
                oConExterna.CrearComando("SELECT wester_item.*,caproduct.productname as paquete FROM wester_item" +
                    " LEFT JOIN caproduct on caproduct.productid=wester_item.combinationid WHERE wester_item.cardid=@carid");
                oConExterna.AsignarParametroCadena("@carid", idTarjeta.ToString());
                dtPaquetes = oConExterna.Tabla();

                oConExterna.Desconectar();
            }
            catch (Exception)
            {
                oConExterna.Desconectar();

                throw;
            }
            return dtPaquetes;
        }

        public DataTable ListarTarjetasUser(string numtarjeta)
        {
            DataTable dt;
            try
            {
                oConExterna.Conectar();
                oConExterna.CrearComando("SELECT caproduct.productId AS Id_Producto, iccard_time.id AS id_Time,iccard_info.cardId AS IdTarjeta,iccard_info.userId AS Id_User, " +
                    "user_info.userName AS Usuario, user_info.userIdentityCardID AS Codigo_GIES, caproduct.ProductName AS Producto, iccard_info.icNo AS Serie, " +
                    "iccard_time.endDate AS Fecha_Corte,iccard_time.state AS EstadoProducto, iccard_info.state AS EstadoTarjeta " +
                    "FROM iccard_time " +
                    "LEFT JOIN iccard_info ON iccard_time.cardId = iccard_info.cardId " +
                    "LEFT JOIN caproduct ON iccard_time.productId = caproduct.productId " +
                    "LEFT JOIN user_info ON iccard_info.userId = user_info.userID " +
                    "WHERE iccard_info.icNo = @carnum ");
                oConExterna.AsignarParametroCadena("@carnum", numtarjeta);
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

        public DataTable ListarPaquetesUser(string CodUser)
        {
            String Codigo = String.Format("{0}{1}", parametro, CodUser.ToString().PadLeft(6, '0'));
            DataTable dt;
            try
            {
                oConExterna.Conectar();
                oConExterna.CrearComando("SELECT caproduct.productId AS Id_Producto, iccard_time.id AS id_Time,iccard_info.cardId AS IdTarjeta,iccard_info.userId AS Id_User, " +
                    "user_info.userName AS Usuario, user_info.userIdentityCardID AS Codigo_GIES, caproduct.ProductName AS Producto, iccard_info.icNo AS Serie, " +
                    "iccard_time.endDate AS Fecha_Corte,iccard_time.state AS EstadoProducto, iccard_info.state AS EstadoTarjeta " +
                    "FROM iccard_time " +
                    "LEFT JOIN iccard_info ON iccard_time.cardId = iccard_info.cardId " +
                    "LEFT JOIN caproduct ON iccard_time.productId = caproduct.productId " +
                    "LEFT JOIN user_info ON iccard_info.userId = user_info.userID " +
                    "WHERE user_info.userIdentityCardID = @codUser ");

                oConExterna.AsignarParametroCadena("@codUser", Codigo.ToString());
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

        public DataTable ObtenerSubServiciosCASS()
        {
            DataTable dt;
            try
            {
                oConExterna.Conectar();
                oConExterna.CrearComando("SELECT productId AS Id_Servicio_CASS, ProductName AS Servicio_CASS " +
                    "FROM caproduct ");
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

        public DataTable Listar_Relacion()
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT servicios_sub.id as id_sub,servicios.id as id_serv,cass.id,servicios.Descripcion AS ServicioGIES,servicios_sub.Descripcion AS SubServicioGIES, cass.Cass_Paquete AS SubServicioCASS " +
                    "FROM cass " +
                    "LEFT JOIN servicios_sub ON cass.Id_Servicios_Sub = servicios_sub.Id " +
                    "LEFT JOIN servicios ON servicios_sub.Id_Servicios = servicios.id " +
                    "WHERE servicios_sub.borrado = 0 and servicios.borrado=0 and cass.borrado=0; ");
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception)
            {

                throw;
            }


            return dt;

        }

        public void Guardar(int id_SubServ, int id_servicio, string Producto)
        {

            try
            {
                oCon.Conectar();

                oCon.CrearComando("INSERT INTO Cass(id_servicios_Sub,id_servicio,Cass_Paquete,id_personal) " +
                    "VALUES(@id_Serv_Sub,@id_Serv, @Producto,@personal)");
                oCon.AsignarParametroEntero("@id_Serv_Sub", id_SubServ);
                oCon.AsignarParametroEntero("@id_Serv", id_servicio);
                oCon.AsignarParametroCadena("@Producto", Producto);
                oCon.AsignarParametroEntero("@personal", Personal.Id_Login);
                oCon.ComenzarTransaccion();
                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();

            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();

                throw;
            }

        }

        public DataTable ListarTarjetasGIES(string Tarjeta)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando(String.Format("SELECT equipos.Id AS Id_equipo, usuarios_servicios.Id AS Id_Usu_serv, usuarios.Id AS Id_usu, usuarios.Codigo AS codUsu, " +
                    "CONCAT(usuarios.Apellido, ' , ', usuarios.Nombre) AS Usuario, equipos.Serie, equipos.Mac, equipos_tipos.Nombre AS TipoEquipo, equipos_tarjetas.Numero AS Tarjeta " +
                    "FROM usuarios_servicios " +
                    "LEFT JOIN usuarios ON usuarios_servicios.Id_Usuarios = usuarios.id " +
                    "LEFT JOIN equipos ON equipos.Id_Usuarios_Servicios = usuarios_servicios.Id " +
                    "LEFT JOIN equipos_tarjetas ON equipos.Id_Tarjeta = equipos_tarjetas.id " +
                    "LEFT JOIN equipos_tipos ON equipos.Id_Equipos_Tipos = equipos_tipos.id " +
                    "WHERE usuarios_servicios.borrado = 0 AND equipos.borrado = 0 AND equipos_tarjetas.Borrado = 0 " +
                    "AND equipos_tarjetas.Numero = '{0}'", Tarjeta));
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }

        public DataTable ListarInfoCompletaUsuario_Servicio(int id_usu_serv, int vieneTarjeta =0, string tarjeta = "")
        {
            string condicion = string.Empty;
            string consulta = string.Empty;
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();

                consulta = "SELECT usuarios_servicios_sub.Id AS id_usu_serv_sub,usuarios_servicios.id AS id_usu_serv, " +
                        "usuarios_servicios_sub.Id_Servicios_Sub AS id_subserv, usuarios_servicios.Id_Servicios AS id_serv, " +
                        "usuarios_servicios.Id_Usuarios AS id_usuario, usuarios_servicios.Id_Tipo_Facturacion AS id_tipo_fac, " +
                        "usuarios_servicios.Id_Usuarios_Locaciones AS id_usu_loc, servicios.Descripcion AS Servicio,servicios.id_servicios_modalidad as idModalidad, " +
                        "servicios_sub.Descripcion AS Subservicio, ifnull(equipos.Serie, 0) AS Serie, ifnull(equipos_tarjetas.Numero, 0) AS Tarjeta,DATE(usuarios_servicios.Fecha_Inicio) AS fecha_inicioUsuServ, DATE(usuarios_servicios_sub.fecha_inicio) as fecha_inicio " +
                        "FROM usuarios_servicios_sub " +
                        "LEFT JOIN servicios_sub ON usuarios_servicios_sub.Id_Servicios_Sub = servicios_sub.id " +
                        "LEFT JOIN usuarios_servicios ON usuarios_servicios_sub.Id_Usuarios_Servicios = usuarios_servicios.Id " +
                        "LEFT JOIN servicios ON usuarios_servicios.Id_Servicios = servicios.id " +
                        "LEFT JOIN equipos ON equipos.Id_Usuarios_Servicios = usuarios_servicios.id " +
                        "LEFT JOIN equipos_tarjetas ON equipos.Id_Tarjeta = equipos_tarjetas.id ";

                if (vieneTarjeta == 0 && id_usu_serv > 0) 
                    condicion = String.Format(" WHERE usuarios_servicios_sub.Id_Usuarios_Servicios = {0} AND servicios.Id_Aplicaciones_Externas = {1} ",id_usu_serv, (int)Aplicaciones_Externas.Aplicacion_Externa.CASS);
                else
                    if(tarjeta != "") 
                        condicion = String.Format(" WHERE equipos_tarjetas.Numero = '{0}' AND servicios.Id_Aplicaciones_Externas = {1}  ", tarjeta, (int)Aplicaciones_Externas.Aplicacion_Externa.CASS);

                condicion += " and usuarios_servicios.borrado=0 AND usuarios_servicios_sub.borrado=0 AND equipos.borrado=0 AND equipos_tarjetas.borrado=0;";


                oCon.CrearComando(String.Format("{0} {1}", consulta, condicion));
                dt = oCon.Tabla();
                if(dtInfoCompletaUsuarioServicioCass.Rows.Count == 0)
                    dtInfoCompletaUsuarioServicioCass = dt.Clone();

                foreach (DataRow dr in dt.Rows)
                    dtInfoCompletaUsuarioServicioCass.ImportRow(dr);

                oCon.DesConectar();
            }
            catch (Exception)
            {

                throw;
            }

            //ESTE IF ES PARA QUE HAGA UNA ACUMULACION DEL TOTAL DE TARJETAS DEL USUARIO EN UNA TABLA ESTATICA, LUEGO SE BORRA
            if (vieneTarjeta == 0)
                return dtInfoCompletaUsuarioServicioCass;
            //SI NO VIENE UNA TARJETA, RETORNA EL DATATABLE CONSULTADO NORMALMENTE
            else
                return dt;
        }

        public DataTable ListarInfoCompletaPartesyUsuarioServicio(int id_usu_serv)
        {
            string condicion = string.Empty;
            string consulta = string.Empty;
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();

                consulta = "SELECT * " +
                    "FROM partes_equipos " +
                    "LEFT JOIN usuarios_servicios ON partes_equipos.Id_Usuarios_Servicios = usuarios_servicios.id " +
                    "LEFT JOIN servicios on usuarios_servicios.id_Servicios = servicios.id " + 
                    "LEFT JOIN equipos_tarjetas ON partes_equipos.Id_Tarjeta = equipos_tarjetas.id " +
                    "LEFT JOIN usuarios_servicios_sub ON usuarios_servicios_sub.Id_Usuarios_Servicios = usuarios_servicios.id " +
                    "WHERE partes_equipos.borrado = 0 AND usuarios_servicios.borrado = 0 AND usuarios_servicios_sub.borrado = 0 " +
                    "AND equipos_tarjetas.borrado = 0 ";

                condicion = $" AND usuarios_servicios.id = {id_usu_serv} ";

                oCon.CrearComando(String.Format("{0} {1}", consulta, condicion));
                dt = oCon.Tabla();

                oCon.DesConectar();
            }
            catch (Exception)
            {

                throw;
            }

            return dt;
        }

        public DataTable ListarDataTarjetaSinEquipo(int id_usu_serv)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando(String.Format("SELECT partes_equipos.id AS id_parte_equipo, usuarios_servicios.id AS id_usu_serv, equipos_tarjetas.id AS id_tarjeta, " +
                    "equipos_tarjetas.Numero AS Tarjeta, usuarios_servicios.Id_Tipo_Facturacion AS id_tipo_facturacion, usuarios_servicios.Id_Servicios AS id_serv,servicios.id_servicios_modalidad as idModalidad " +
                    "FROM partes_equipos " +
                    "LEFT JOIN usuarios_servicios ON  partes_equipos.Id_Usuarios_Servicios = usuarios_servicios.id " +
                    "LEFT JOIN servicios on usuarios_servicios.id_servicios = servicios.id " +
                    "LEFT JOIN equipos_tarjetas ON partes_equipos.Id_Tarjeta = equipos_tarjetas.id " +
                    "WHERE id_usuarios_servicios = {0} ; ", id_usu_serv));
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }

        public void LimpiarDtInfoCompleta()
        {
            dtInfoCompletaUsuarioServicioCass.Clear();
        }

        public void LimpiarDtPaquetesCass()
        {
            dtPaquetesCass.Clear();
        }

        public string obtenerCodigoUsuario(int id_usuario)
        {
            Usuarios Usuarios = new Usuarios();
            DataRow DataUsuario = Usuarios.getDatos(id_usuario);

            String Codigo = String.Format("{0}{1}", parametro, DataUsuario["codigo"].ToString().PadLeft(6, '0'));
            return Codigo;
        }

        public Int32 getUserIdCass(string codUsu)
        {
            DataTable dt;
            try { 
                oConExterna.Conectar();
                oConExterna.CrearComando("SELECT * FROM user_info WHERE user_info.userIdentityCardID = @cod;");

                oConExterna.AsignarParametroCadena("@cod", codUsu.ToString());
                dt = oConExterna.Tabla();

                oConExterna.Desconectar();
                if (dt.Rows.Count > 0)
                    return Convert.ToInt32(dt.Rows[0]["userId"]);
                else
                    return 0;
            }
            catch(Exception e)
            {
                throw e;
            }
        }

        public Boolean VerificarTarjetaExistente(String Tarjeta)
        {
            DataTable dt;
            try
            {
                oConExterna.Conectar();
                oConExterna.CrearComando("SELECT * FROM iccard_info WHERE iccard_info.icNo = @numTar and deleted=0");

                oConExterna.AsignarParametroCadena("@numTar", Tarjeta.ToString());
                dt = oConExterna.Tabla();

                oConExterna.Desconectar();
                if (dt.Rows.Count > 0)
                    return true;
                else
                    return false;
            }
            catch
            {
                oConExterna.Desconectar();
                return true;
            }

        }

        public Boolean VerificarTarjetaExistenteAbonado(String Tarjeta, int id_usuario)
        {
            DataTable dt;
            try
            {
                string codigo = "";
                int user_id = 0;
                codigo = this.obtenerCodigoUsuario(id_usuario);
                user_id = this.getUserIdCass(codigo);
                oConExterna.Conectar();
                oConExterna.CrearComando("SELECT * FROM iccard_info WHERE iccard_info.icNo = @numTar and deleted=0 and userid != @idUser ");

                oConExterna.AsignarParametroCadena("@numTar", Tarjeta.ToString());
                oConExterna.AsignarParametroEntero("@idUser", user_id);
                dt = oConExterna.Tabla();

                oConExterna.Desconectar();
                if (dt.Rows.Count > 0)
                    return true;
                else
                    return false;
            }
            catch
            {
                oConExterna.Desconectar();
                return true;
            }
        }

        public Boolean VerificarAbonadoExistente(int id_usu)
        {
            Usuarios Usuarios = new Usuarios();
            int id_usuario = id_usu;
            DataRow DataUsuario = Usuarios.getDatos(id_usuario);
            String Codigo = String.Format("{0}{1}", parametro, DataUsuario["codigo"].ToString().PadLeft(6, '0'));
            DataTable dt;
            try
            {
                oConExterna.Conectar();
                oConExterna.CrearComando(" SELECT * FROM user_info WHERE user_info.userIdentityCardID =@codAb and userDeleted=0 ");

                oConExterna.AsignarParametroCadena("@codAb", Codigo.ToString());
                dt = oConExterna.Tabla();

                oConExterna.Desconectar();
                if (dt.Rows.Count > 0)
                    return true;
                else
                    return false;
            }
            catch(Exception)
            {
                oConExterna.Desconectar();
                return true;
                throw;
            }

        }

        public DataTable GenerarDtTarjetas(DataTable DtServiciosAsociados)
        {
            bool ActivacionOk = false;

            //CREO LAS TABLAS PARA LA INFORMACION DEL CASS
            DataTable dtInfoCompletaCass = new DataTable();
            //TABLA QUE VA A CONTENER LAS TARJETAS A ACTIVAR EN EL CASS
            DataTable dtTarjetas = new DataTable();
            dtTarjetas.Columns.Add("Tarjeta", typeof(String));
            dtTarjetas.Columns.Add("id_tipo_facturacion", typeof(Int32));
            dtTarjetas.Columns.Add("id_usu_serv", typeof(Int32));
            dtTarjetas.Columns.Add("id_usu_serv_sub", typeof(Int32));


            foreach (DataRow dr in DtServiciosAsociados.Rows)
            {
                if (Convert.ToInt32(dr["id_app_ext"]) == (int)Aplicaciones_Externas.Aplicacion_Externa.CASS)
                    dtInfoCompletaCass = this.ListarInfoCompletaUsuario_Servicio(Convert.ToInt32(dr["id_usuarios_servicios"]));
            }

            //AGRUPO LA TABLA POR TARJETA, POR SI ES QUE TIENE MAS DE UN SERVICIO CON MAS DE UNA TARJETA
            if(dtInfoCompletaCass.Rows.Count > 0 && dtInfoCompletaCass.Rows[0]["tarjeta"].ToString() != "0") 
            { 
                dtTarjetas = dtInfoCompletaCass.AsEnumerable()
                                    .GroupBy(r => new { Col1 = r["tarjeta"] })
                                    .Select(g => g.OrderBy(r => r["id_serv"]).First())
                                     .CopyToDataTable();
            }

            dtTarjetasFinal = dtTarjetas.Copy();
            //LIMPIO la tabla de paquete de cass
            this.LimpiarDtPaquetesCass();

            //LIMPIO LA TABLA DE INFORMACION ESTATICA
            this.LimpiarDtInfoCompleta();
            dtInfoCompletaCass.Clear();
            dtTarjetas.Clear();

            return dtTarjetasFinal;
        }

        public DataTable GenerarDtPreAsignacion(DataTable DtServiciosAsociados)
        {
            bool ActivacionOk = false;

            //CREO LAS TABLAS PARA LA INFORMACION DEL CASS
            DataTable dtInfoCompletaCass = new DataTable();
            //TABLA QUE VA A CONTENER LAS TARJETAS A ACTIVAR EN EL CASS
            DataTable dtTarjetas = new DataTable();
            dtTarjetas.Columns.Add("Tarjeta", typeof(String));
            dtTarjetas.Columns.Add("id_tipo_facturacion", typeof(Int32));
            dtTarjetas.Columns.Add("id_usu_serv", typeof(Int32));
            dtTarjetas.Columns.Add("id_usu_serv_sub", typeof(Int32));


            foreach (DataRow dr in DtServiciosAsociados.Rows)
            {
                if (Convert.ToInt32(dr["id_app_ext"]) == (int)Aplicaciones_Externas.Aplicacion_Externa.CASS)
                    dtInfoCompletaCass = this.ListarDataTarjetaSinEquipo(Convert.ToInt32(dr["id_usuarios_servicios"]));
            }

            //AGRUPO LA TABLA POR TARJETA, POR SI ES QUE TIENE MAS DE UN SERVICIO CON MAS DE UNA TARJETA
            if (dtInfoCompletaCass.Rows.Count > 0 && dtInfoCompletaCass.Rows[0]["tarjeta"].ToString() != "0")
            {
                dtTarjetas = dtInfoCompletaCass.AsEnumerable()
                                    .GroupBy(r => new { Col1 = r["tarjeta"] })
                                    .Select(g => g.OrderBy(r => r["id_serv"]).First())
                                     .CopyToDataTable();
            }

            dtTarjetasFinal = dtTarjetas.Copy();
            //LIMPIO la tabla de paquete de cass
            this.LimpiarDtPaquetesCass();

            //LIMPIO LA TABLA DE INFORMACION ESTATICA
            this.LimpiarDtInfoCompleta();
            dtInfoCompletaCass.Clear();
            dtTarjetas.Clear();

            return dtTarjetasFinal;
        }

        //OBTIENE LOS DATOS DEL USUARIO ENVIANDOLE UN ID_USUARIO_SERVICIO, usar este para enviar a generardtTarjetas
        //ESTE SIRVE PARA UN USUARIO SERVICIO EN ESPECIFICO
        //30-06-2021
        public DataTable getFullDataUser(int id_usuario_servicio,int id_parte, int filtroGetData)
        {
            DataTable dt = new DataTable();
            DataTable dtAux = new DataTable();
            string comando = "";
            string condicion = "";
            try
            {
                oCon.Conectar();
                if(filtroGetData == (int)Cass.FILTROS_GET_DATA.ID_USUARIO_SERVICIO)
                {
                    if (id_usuario_servicio > 0) {
                        dtAux.Clear();
                        comando = "SELECT partes_equipos.id AS id_parte_equipo,usuarios_servicios.id AS id_usuarios_servicios,usuarios_servicios_sub.Id AS id_usu_serv_sub, " +
                            "servicios.id AS id_serv,servicios_sub.id AS id_subser, equipos_tarjetas.numero as tarjeta, usuarios_servicios.id_tipo_facturacion,servicios.Id_Aplicaciones_Externas AS id_app_ext,  " +
                            "usuarios_servicios.borrado as borradoUsuServ,usuarios_servicios_sub.borrado as borradoUsuServSub,equipos_tarjetas.borrado as borradoTarjeta " +
                            "FROM partes_equipos " +
                            "LEFT JOIN equipos_tarjetas ON partes_equipos.Id_Tarjeta = equipos_tarjetas.id " +
                            "LEFT JOIN usuarios_servicios ON partes_equipos.Id_Usuarios_Servicios = usuarios_servicios.id " +
                            "LEFT JOIN servicios ON usuarios_servicios.Id_Servicios = servicios.id " +
                            "LEFT JOIN usuarios_servicios_sub ON usuarios_servicios_sub.Id_Usuarios_Servicios = usuarios_servicios.id " +
                            "LEFT JOIN servicios_sub ON usuarios_servicios_sub.Id_Servicios_Sub = servicios_sub.id ";

                        condicion = String.Format("WHERE usuarios_servicios.id = {0} and usuarios_servicios_sub.borrado=0 AND usuarios_servicios.borrado=0 and equipos_Tarjetas.borrado=0; ", id_usuario_servicio);
                        oCon.CrearComando(String.Format("{0} {1}", comando, condicion));
                        dtAux = oCon.Tabla();
                        if (dtAux.Rows.Count > 0)
                            dt = dtAux.Copy();
                        else
                        {
                            dtAux.Clear();
                            comando = "";
                            comando = "SELECT equipos.id AS id_equi, usuarios_servicios.id AS id_usuarios_servicios,usuarios_servicios_sub.id AS id_usu_serv_sub, " +
                                "servicios.id AS id_serv, servicios_sub.Id AS id_subser, equipos_tarjetas.numero as tarjeta,servicios.Id_Aplicaciones_Externas AS id_app_ext,  " +
                                "usuarios_servicios.borrado as borradoUsuServ,usuarios_servicios_sub.borrado as borradoUsuServSub,equipos_tarjetas.borrado as borradoTarjeta " +
                                "FROM equipos " +
                                "LEFT JOIN usuarios_servicios ON equipos.Id_Usuarios_Servicios = usuarios_servicios.id " +
                                "LEFT JOIN servicios ON usuarios_servicios.Id_Servicios = servicios.id " +
                                "LEFT JOIN usuarios_servicios_sub ON usuarios_servicios_sub.Id_Usuarios_Servicios = usuarios_servicios.id " +
                                "LEFT JOIN servicios_sub ON usuarios_servicios_sub.Id_Servicios_Sub = servicios_sub.id " +
                                "LEFT JOIN equipos_tarjetas ON equipos.Id_Tarjeta = equipos_tarjetas.id ";
                            oCon.CrearComando(String.Format("{0} {1}", comando, condicion));
                            dtAux = oCon.Tabla();
                            dt = dtAux.Copy();

                        }
                    }
                }
                else if(filtroGetData == (int)Cass.FILTROS_GET_DATA.ID_PARTE)
                {
                    if(id_parte > 0) { 
                        comando = "SELECT partes_equipos.id AS id_parte_equipo,usuarios_servicios.id AS id_usuarios_servicios,usuarios_servicios_sub.Id AS id_usu_serv_sub, " +
                            "servicios.id AS id_serv,servicios_sub.id AS id_subser,equipos_tarjetas.numero as tarjeta,servicios.Id_Aplicaciones_Externas AS id_app_ext, " +
                            "usuarios_servicios.borrado as borradoUsuServ,usuarios_servicios_sub.borrado as borradoUsuServSub,equipos_tarjetas.borrado as borradoTarjeta " +
                            "FROM partes_equipos " +
                            "LEFT JOIN equipos_tarjetas ON partes_equipos.Id_Tarjeta = equipos_tarjetas.id " +
                            "LEFT JOIN usuarios_servicios ON partes_equipos.Id_Usuarios_Servicios = usuarios_servicios.id " +
                            "LEFT JOIN servicios ON usuarios_servicios.Id_Servicios = servicios.id " +
                            "LEFT JOIN usuarios_servicios_sub ON usuarios_servicios_sub.Id_Usuarios_Servicios = usuarios_servicios.id " +
                            "LEFT JOIN servicios_sub ON usuarios_servicios_sub.Id_Servicios_Sub = servicios_sub.id ";

                        condicion = String.Format("WHERE partes_equipos.id_partes = {0} and usuarios_servicios_sub.borrado=0 AND usuarios_servicios.borrado=0 and equipos_Tarjetas.borrado=0; ", id_parte);
                        oCon.CrearComando(String.Format("{0} {1}", comando, condicion));
                        dtAux = oCon.Tabla();
                        if(dtAux.Rows.Count == 0)
                        {
                            dtAux.Clear();
                            comando = "";
                            condicion = "";
                            comando = "SELECT partes_equipos.id AS id_parte_equipo,usuarios_servicios.id AS id_usuarios_servicios, " +
                                "servicios.id AS id_serv,equipos_tarjetas.numero as tarjeta, " +
                                "servicios.Id_Aplicaciones_Externas AS id_app_ext, " +
                                "usuarios_servicios.borrado as borradoUsuServ,usuarios_servicios_sub.borrado as borradoUsuServSub,equipos_tarjetas.borrado as borradoTarjeta " +
                                "FROM partes_usuarios_servicios " +
                                "LEFT JOIN partes ON partes_usuarios_servicios.Id_parte = partes.id " +
                                "LEFT JOIN usuarios_servicios ON partes_usuarios_servicios.Id_usuarios_servicios = usuarios_servicios.Id " +
                                "LEFT JOIN usuarios_servicios_sub on usuarios_servicios_sub.id_usuarios_servicios = usuarios_servicios.id " +
                                "LEFT JOIN partes_equipos ON usuarios_servicios.id = partes_equipos.Id_Usuarios_Servicios " +
                                "LEFT JOIN servicios ON partes_usuarios_servicios.Id_servicio = servicios.id " +
                                "LEFT JOIN equipos_tarjetas ON partes_equipos.Id_Tarjeta = equipos_tarjetas.id " +
                                "LEFT JOIN equipos ON partes_equipos.Id_Equipos = equipos.id ";
                            condicion = String.Format(" WHERE id_parte = {0} AND usuarios_servicios.borrado=0 and equipos_Tarjetas.borrado=0; ", id_parte);
                            oCon.CrearComando(String.Format("{0} {1}", comando, condicion));
                            dtAux = oCon.Tabla();
                        }
                        dt = dtAux.Copy();
                    }
                }
                oCon.DesConectar();
            }
            catch (Exception e)
            {
                string salida = e.ToString();
                oCon.DesConectar();
                throw;
            }
            return dt;
        }

        public Boolean actualizarCass(DataTable dtFullData,int idUsuario, out string resultadoActualizar)
        {
            DataTable dtTarjeta = new DataTable();
            string resultado = "";
            dtTarjeta = this.GenerarDtTarjetas(dtFullData);
            bool accionCorrectaDesactivar = false;
            bool accionCorrectaEliminar = false;
            bool accionCorrectaActivar = false;
            if (dtTarjeta.Rows.Count == 0)
            {
                dtTarjeta.Clear();
                dtTarjeta = this.GenerarDtPreAsignacion(dtFullData);
            }
            try 
            {
                if (this.GenerarDesactivacionDePaquetes(dtTarjeta, idUsuario, out resultado))
                    accionCorrectaDesactivar = true;
                else
                    accionCorrectaDesactivar = false;

                if (this.GenerarEliminacionUsuario(dtTarjeta, idUsuario, out resultado))
                    accionCorrectaEliminar = true;
                else
                    accionCorrectaEliminar = false;

                if (this.GenerarActivacion(dtTarjeta, idUsuario, out resultado))
                    accionCorrectaActivar = true;
                else
                    accionCorrectaActivar = false;

                resultado = "";
                if (accionCorrectaDesactivar == true && accionCorrectaEliminar == true && accionCorrectaActivar == true)
                {

                    resultado = "Operaciones realizadas correctamente.";
                    resultadoActualizar = resultado;
                    return true;
                }

                else
                {
                    if(accionCorrectaActivar == false)
                    {
                        resultado += "Error al activar paquetes.";
                    }
                    if (accionCorrectaEliminar == false)
                    {
                        resultado += "- error al eliminar la cuenta.";
                    }
                    if(accionCorrectaDesactivar == false)
                    {
                        resultado += "- error al Desactivar los paquetes.";
                    }
                    resultado = "Hubo una falla al actualizarCass, revisar.";
                    resultadoActualizar = resultado;
                    return false;
                }

            }
            catch(Exception e)
            {
                string cadena = "";
                cadena = resultado ;
                resultadoActualizar = resultado;
                return false;
                throw;
            }
        }

        #endregion
    }
}
