using CapaDatos;
using System;
using System.Data;

namespace CapaNegocios
{
    public class Usuarios_Dom_Fiscal
    {
        public Int32 Id { get; set; }
        public Int32 Id_Usuarios { get; set; }
        public String R_Social { get; set; }
        public Int32 Id_Usuarios_TipoDoc { get; set; }
        public Double Numero_Documento { get; set; }
        public String Calle { get; set; }
        public Int32 Altura { get; set; }
        public String Piso { get; set; }
        public String Depto { get; set; }
        public String Codigo_Postal { get; set; }
        public Int32 Borrado { get; set; }
        public double Cuit { get; set; }
        public Int32 idCondicionIva { get; set; }
        public Int32 idLocacionAsociada { get; set; }
        public String Telefono { get; set; }
        public String Localidad { get; set; }
        public Int32 Id_Provincia { get; set; }
        public String CondicionIva { get; set; }
        public decimal ImpuestoProvincial;
        public int Exento_impuesto_provincial { get; set; }
        public enum CondicionARBA
        {
            Exento = 1,
            NoExento = 2
        }

        public enum CondicionIVA
        {
            CONSUMIDOR_FINAL = 1,
            RESPONSABLE_INSCRIPTO = 2
        }
        public Comprobantes_Iva Ocomprobantes_Iva = new Comprobantes_Iva();

        private Conexion oCon = new Conexion();

        public Int32 Guardar(Usuarios_Dom_Fiscal oDomFiscal)
        {
            try
            {
                oCon.Conectar();

                if (oDomFiscal.Id > 0)
                {
                    oCon.CrearComando("update usuarios_dom_fiscal set Id_Usuarios=@idUsuarios, R_Social=@rsoc, Calle= @calle, Altura=@altura, Piso=@piso, Depto=@depto, Codigo_Postal=@cp, id_condicion_iva=@idCondicionIva, cuit=@cuit, telefono=@telefono, localidad=@localidad, id_provincia=@idProvincia, id_locacion_asociada=0,impuesto_provincial=@impuesto_pro where Id=@idDomFiscal;");
                    oCon.AsignarParametroEntero("@idUsuarios", oDomFiscal.Id_Usuarios);
                    oCon.AsignarParametroCadena("@rsoc", oDomFiscal.R_Social);
                    //oCon.AsignarParametroEntero("@tipodoc", oDomFiscal.Id_Usuarios_TipoDoc);
                    //oCon.AsignarParametroDouble("@numdoc", oDomFiscal.Numero_Documento);
                    oCon.AsignarParametroCadena("@calle", oDomFiscal.Calle);
                    oCon.AsignarParametroEntero("@altura", oDomFiscal.Altura);
                    oCon.AsignarParametroCadena("@piso", oDomFiscal.Piso);
                    oCon.AsignarParametroCadena("@depto", oDomFiscal.Depto);
                    oCon.AsignarParametroCadena("@cp", oDomFiscal.Codigo_Postal);
                    oCon.AsignarParametroEntero("@idCondicionIva", oDomFiscal.idCondicionIva);
                    //oCon.AsignarParametroEntero("@idLocacionAsociada", oDomFiscal.idLocacionAsociada);
                    oCon.AsignarParametroDouble("@cuit", oDomFiscal.Cuit);
                    oCon.AsignarParametroCadena("@telefono", oDomFiscal.Telefono);
                    oCon.AsignarParametroCadena("@localidad", oDomFiscal.Localidad);
                    oCon.AsignarParametroEntero("@idProvincia", oDomFiscal.Id_Provincia);
                    oCon.AsignarParametroDecimal("@impuesto_pro", oDomFiscal.ImpuestoProvincial);
                    oCon.AsignarParametroEntero("@idDomFiscal", oDomFiscal.Id);
                }
                else
                {
                    oCon.CrearComando("INSERT INTO Usuarios_Dom_Fiscal(Id_Usuarios, R_Social, Calle, Altura, Piso, Depto, Codigo_Postal, id_condicion_iva, cuit, telefono, localidad, id_provincia, id_locacion_asociada,impuesto_provincial) VALUES(@idUsuarios, @rsoc, @calle, @altura, @piso, @depto, @cp, @idCondicionIva, @cuit, @telefono, @localidad, @idProvincia, 0, @impuesto_pro); SELECT @@IDENTITY");
                    oCon.AsignarParametroEntero("@idUsuarios", oDomFiscal.Id_Usuarios);
                    oCon.AsignarParametroCadena("@rsoc", oDomFiscal.R_Social);
                    oCon.AsignarParametroCadena("@calle", oDomFiscal.Calle);
                    oCon.AsignarParametroEntero("@altura", oDomFiscal.Altura);
                    oCon.AsignarParametroCadena("@piso", oDomFiscal.Piso);
                    oCon.AsignarParametroCadena("@depto", oDomFiscal.Depto);
                    oCon.AsignarParametroCadena("@cp", oDomFiscal.Codigo_Postal);
                    oCon.AsignarParametroEntero("@idCondicionIva", oDomFiscal.idCondicionIva);
                    oCon.AsignarParametroDouble("@cuit", oDomFiscal.Cuit);
                    oCon.AsignarParametroCadena("@telefono", oDomFiscal.Telefono);
                    oCon.AsignarParametroCadena("@localidad", oDomFiscal.Localidad);
                    oCon.AsignarParametroEntero("@idProvincia", oDomFiscal.Id_Provincia);
                    oCon.AsignarParametroDecimal("@impuesto_pro", oDomFiscal.ImpuestoProvincial);

                }

                if (oDomFiscal.Id == 0)
                    oDomFiscal.Id = oCon.EjecutarScalar();
                else
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

            return oDomFiscal.Id;

        }

        public DataTable Listar(int idUsuario)
        {
            string consulta = String.Empty;
            DataTable dt = new DataTable();

            if (idUsuario > 0)
                consulta = String.Format("select * from vw_usuarios_dom_fiscal where id_usuarios={0} and borrado=0", idUsuario);
            else
                consulta = String.Format("select * from vw_usuarios_dom_fiscal where borrado=0");

            try
            {
                oCon.Conectar();
                oCon.CrearComando(consulta);
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                throw;
            }

            return dt;
        }

        public DataTable ListarLocacionesDeServicio(int idLocacionFiscal)
        {
            string consulta = String.Empty;
            DataTable dt = new DataTable();

            if (idLocacionFiscal > 0)
                consulta = String.Format("select * from vw_usuarios_locaciones where id_locacion_fiscal_asociada={0}", idLocacionFiscal);
            else
                consulta = String.Format("select * from vw_usuarios_locaciones");

            try
            {
                oCon.Conectar();
                oCon.CrearComando(consulta);
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                throw;
            }

            return dt;
        }

        public DataTable ListarDatosLocFiscal(int idDomFiscal)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT * FROM vw_usuarios_dom_fiscal WHERE id=@id1");
                oCon.AsignarParametroEntero("@id1", idDomFiscal);
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

        public void Eliminar(int id)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("UPDATE usuarios_dom_fiscal SET Borrado=1 WHERE Id=@id1");
                oCon.AsignarParametroEntero("@id1", id);
                oCon.ComenzarTransaccion();
                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();

                oCon.CrearComando("UPDATE usuarios_locaciones SET id_locacion_fiscal_asociada=0 WHERE Id_locacion_fiscal_asociada=@idLocacionAsociada");
                oCon.AsignarParametroEntero("@idLocacionAsociada", id);
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

        public Usuarios_Dom_Fiscal LlenarDatosLocFiscal(int idLocacionServicio)
        {
            DataTable dtDatosLocacionFiscal = new DataTable();
            DataTable dtDatosUsuario = new DataTable();
            Usuarios_Locaciones oUsuariosLocaciones = new Usuarios_Locaciones();
            Usuarios_Dom_Fiscal oUsuariosDomFiscal = new Usuarios_Dom_Fiscal();
            Usuarios oUsuarios = new Usuarios();

            oUsuariosLocaciones = oUsuariosLocaciones.GetLocacion(idLocacionServicio);
            if (oUsuariosLocaciones.Id_Locacion_Fiscal_Asociada > 0)
            {
                dtDatosLocacionFiscal = oUsuariosDomFiscal.ListarDatosLocFiscal(oUsuariosLocaciones.Id_Locacion_Fiscal_Asociada);
                oUsuariosDomFiscal.Id = Convert.ToInt32(dtDatosLocacionFiscal.Rows[0]["id"]);
                oUsuariosDomFiscal.idCondicionIva = Convert.ToInt32(dtDatosLocacionFiscal.Rows[0]["id_condicion_iva"]);
                oUsuariosDomFiscal.Altura = Convert.ToInt32(dtDatosLocacionFiscal.Rows[0]["altura"]);
                oUsuariosDomFiscal.Calle = dtDatosLocacionFiscal.Rows[0]["calle"].ToString();
                oUsuariosDomFiscal.Codigo_Postal = dtDatosLocacionFiscal.Rows[0]["codigo_postal"].ToString();
                oUsuariosDomFiscal.Cuit = Convert.ToDouble(dtDatosLocacionFiscal.Rows[0]["cuit"]);
                oUsuariosDomFiscal.Depto = dtDatosLocacionFiscal.Rows[0]["depto"].ToString();
                oUsuariosDomFiscal.idLocacionAsociada = 0;
                oUsuariosDomFiscal.Id_Provincia = 0;
                oUsuariosDomFiscal.Id_Usuarios = Convert.ToInt32(dtDatosLocacionFiscal.Rows[0]["id_usuarios"]);
                oUsuariosDomFiscal.Id_Usuarios_TipoDoc = Convert.ToInt32(dtDatosLocacionFiscal.Rows[0]["id_usuarios_tipodoc"]);
                oUsuariosDomFiscal.Localidad = dtDatosLocacionFiscal.Rows[0]["localidad"].ToString();
                try
                {
                    oUsuariosDomFiscal.Numero_Documento = Convert.ToDouble(dtDatosLocacionFiscal.Rows[0]["numero_documento"]);
                }
                catch { oUsuariosDomFiscal.Numero_Documento = 0; }
                oUsuariosDomFiscal.Piso = dtDatosLocacionFiscal.Rows[0]["piso"].ToString();
                oUsuariosDomFiscal.R_Social = dtDatosLocacionFiscal.Rows[0]["r_social"].ToString();
                oUsuariosDomFiscal.Telefono = dtDatosLocacionFiscal.Rows[0]["telefono"].ToString();
                oUsuariosDomFiscal.ImpuestoProvincial = Convert.ToDecimal(dtDatosLocacionFiscal.Rows[0]["impuesto_provincial"].ToString());
                oUsuariosDomFiscal.CondicionIva = dtDatosLocacionFiscal.Rows[0]["condicion_iva"].ToString();
                oUsuariosDomFiscal.Exento_impuesto_provincial = Convert.ToInt32(dtDatosLocacionFiscal.Rows[0]["Exento_impuesto_provincial"].ToString());

            }
            else
            {
                //se llena con los datos del usuario
                dtDatosUsuario = oUsuarios.Buscar_datos_usuario(oUsuariosLocaciones.Id_Usuarios);
                if (dtDatosUsuario.Rows.Count > 0)
                {
                    oUsuariosDomFiscal.Id = 0;
                    oUsuariosDomFiscal.idCondicionIva = Convert.ToInt32(dtDatosUsuario.Rows[0]["id_comprobantes_iva"]);
                    oUsuariosDomFiscal.Altura = Usuarios.CurrentUsuario.Altura;
                    oUsuariosDomFiscal.Calle = oUsuariosLocaciones.Calle;
                    oUsuariosDomFiscal.Codigo_Postal = string.Empty;
                    oUsuariosDomFiscal.Cuit = Convert.ToDouble(dtDatosUsuario.Rows[0]["cuit"]);
                    oUsuariosDomFiscal.Depto = Usuarios.CurrentUsuario.Depto;
                    oUsuariosDomFiscal.idLocacionAsociada = 0;
                    oUsuariosDomFiscal.Id_Provincia = 0;
                    oUsuariosDomFiscal.Id_Usuarios = Convert.ToInt32(dtDatosUsuario.Rows[0]["id_usuario"]);
                    oUsuariosDomFiscal.Id_Usuarios_TipoDoc = Convert.ToInt32(dtDatosUsuario.Rows[0]["id_usuarios_tipodoc"]);
                    oUsuariosDomFiscal.Localidad = oUsuariosLocaciones.Localidad;
                    oUsuariosDomFiscal.Numero_Documento = Convert.ToDouble(dtDatosUsuario.Rows[0]["numero_documento"]);
                    oUsuariosDomFiscal.Piso = Usuarios.CurrentUsuario.piso;
                    oUsuariosDomFiscal.R_Social = String.Format("{0} {1}", dtDatosUsuario.Rows[0]["apellido"], dtDatosUsuario.Rows[0]["nom_usu"]);
                    oUsuariosDomFiscal.Telefono = Usuarios.CurrentUsuario.Telefono_1.ToString();
                    oUsuariosDomFiscal.ImpuestoProvincial = Usuarios.CurrentUsuario.Impuesto_Provincial;
                    oUsuariosDomFiscal.CondicionIva = Usuarios.CurrentUsuario.Condicion_Iva;
                    oUsuariosDomFiscal.Exento_impuesto_provincial = Convert.ToInt32(dtDatosUsuario.Rows[0]["exento_impuesto_provincial"]);
                }
            }

            try
            {
                int Exento = Convert.ToInt32(oUsuariosDomFiscal.Exento_impuesto_provincial);
                if (Exento == (int)Usuarios_Dom_Fiscal.CondicionARBA.Exento)
                {
                    Usuarios.CurrentUsuario.Impuesto_Provincial = 0;
                    oUsuariosDomFiscal.ImpuestoProvincial = Usuarios.CurrentUsuario.Impuesto_Provincial;
                }
            }
            catch
            {
            }

            if (Convert.ToInt32(oUsuariosDomFiscal.idCondicionIva) == (int)Comprobantes_Iva.Tipo.CONSUMIDOR_FINAL)
            {
                oUsuariosDomFiscal.ImpuestoProvincial = 0;
            }

            Ocomprobantes_Iva.Id = oUsuariosDomFiscal.idCondicionIva;
            oUsuariosDomFiscal.Ocomprobantes_Iva =  Ocomprobantes_Iva.Listarportipo();

            return oUsuariosDomFiscal;
        }
    }
}
