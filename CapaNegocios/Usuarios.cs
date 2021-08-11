using CapaDatos;
using System;
using System.Data;

namespace CapaNegocios
{
    public class Usuarios
    {
        public Int32 Id { get; set; }
        public Int32 Codigo { get; set; }
        public String Apellido { get; set; }
        public String Nombre { get; set; }
        public Int32 Id_Usuarios_TipoDoc { get; set; }
        public Double Numero_Documento { get; set; }
        public Int32 Id_Comprobantes_Iva { get; set; }
        public Double CUIT { get; set; }
        public DateTime Nacimiento { get; set; }
        public Int32 Id_Usuarios_Profesiones { get; set; }
        public String Correo_Electronico { get; set; }
        public Int32 Prefijo_1 { get; set; }
        public Int32 Telefono_1 { get; set; }
        public Int32 Prefijo_2 { get; set; }
        public Int32 Telefono_2 { get; set; }
        public string Calle { get; set; }
        public Int32 Altura { get; set; }
        public string localidad { get; set; }
        public string Usuario { get; set; }
        public string Direccion { get; set; }
        public string piso { get; set; }
        public string Depto { get; set; }
        public string Entre1 { get; set; }
        public string Entre2 { get; set; }
        public string Observacion { get; set; }
        public string Manzana { get; set; }
        public Int32 Id_Usuarios_Locacion { get; set; }
        public string Profesion { get; set; }
        public string Condicion_Iva { get; set; }
        public string Tipo_Documento { get; set; }
        public string Cod_postal { get; set; }
        public Int32 Adhesion_FacDigital { get; set; }
        public Int32 Debito_Automatico { get; set; }
        public Int32 Id_Usuarios_Tipos { get; set; }
        public Int32 Calculo_Bonificacion { get; set; }
        public String Tipo_Busqueda { get; set; }
        public Int32 Id_Localidad { get; set; }
        public Int32 Adhesion_Debito { get; set; }

        public Decimal Impuesto_Provincial { get; set; }
        public Int32 Exento_Impuesto_Provincial { get; set; }
        public int Presentacion { get; set; }

        private Usuarios_Dom_Fiscal oDomFiscal = new Usuarios_Dom_Fiscal();
        private Usuarios_Locaciones oUsuarioLocacion = new Usuarios_Locaciones();

        public enum Usuarios_Tipos
        {
            ABONADO = 1,
            CLIENTE = 2,
            PROSPECTO = 3
        }

        public enum _Calculo_Bonificacion { POR_USUARIO = 0, POR_LOCACION = 1, NO_SE_APLICA = 2 };

        public static Int32 Current_IdUsuario;
        public static Int32 Current_IdUsuarioLocacion;
        public static Int32 Current_IdUsuarioLocacionFiscal;
        public static DataTable Current_dtServicios;
        public static DataTable Current_dtServicios_Debitos;
        public static DataRow Usuario_Sel;

        public static Usuarios CurrentUsuario = new Usuarios();
        public static Usuarios_Dom_Fiscal CurrentUsuarioDomFiscal = new Usuarios_Dom_Fiscal();

        private Conexion oCon = new Conexion();

        public DataTable ListarTipoDoc()
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT * FROM Usuarios_TipoDoc ORDER BY Id");
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

        public Int32 Guardar(Usuarios oUsu)
        {
            try
            {
                oCon.Conectar();

                if (oUsu.Id > 0)
                {
                    //oUsu.Codigo = oUsu.Id;

                    oCon.CrearComando("UPDATE usuarios SET Apellido = @apellido, Nombre = @nombre, Id_Usuarios_TipoDoc = @tipodoc, " +
                        "Numero_Documento = @doc, Id_Comprobantes_Iva = @iva, CUIT = @cuit, Nacimiento = @nac, Id_Usuarios_Profesiones = @profesion, " +
                        "Correo_Electronico = @email, Adhesion_FacDigital = @facdig, Debito_Automatico = @debito, id_usuarios_tipos = @tipousu, calculo_bonificacion=@calculo_bonificacion, impuesto_provincial = @impuesto, exento_impuesto_provincial = @exento,id_personal=@personal WHERE Id = @id");

                    oCon.AsignarParametroEntero("@id", oUsu.Id);
                }
                else
                    oCon.CrearComando("INSERT INTO usuarios(Codigo, Apellido, Nombre, Id_Usuarios_TipoDoc, Numero_Documento, Id_Comprobantes_Iva, CUIT, Nacimiento, " +
                        "Id_Usuarios_Profesiones, Correo_Electronico, Adhesion_FacDigital, Debito_Automatico, id_usuarios_tipos, calculo_bonificacion, impuesto_provincial, exento_impuesto_provincial,id_personal) " +
                        "VALUES(@codigo, @apellido, @nombre, @tipodoc, @doc, @iva, @cuit, @nac, @profesion, @email, @facdig, @debito, @tipousu, @calculo_bonificacion, @impuesto, @exento,@personal); SELECT @@IDENTITY");
                if (oUsu.Id == 0)
                    oCon.AsignarParametroEntero("@codigo", oUsu.Codigo);
                oCon.AsignarParametroCadena("@apellido", oUsu.Apellido);
                oCon.AsignarParametroCadena("@nombre", oUsu.Nombre);
                oCon.AsignarParametroEntero("@tipodoc", oUsu.Id_Usuarios_TipoDoc);
                oCon.AsignarParametroDouble("@doc", oUsu.Numero_Documento);
                oCon.AsignarParametroEntero("@iva", oUsu.Id_Comprobantes_Iva);
                oCon.AsignarParametroDouble("@cuit", oUsu.CUIT);
                oCon.AsignarParametroFecha("@nac", oUsu.Nacimiento.Date);
                oCon.AsignarParametroEntero("@profesion", oUsu.Id_Usuarios_Profesiones);
                oCon.AsignarParametroCadena("@email", oUsu.Correo_Electronico);
                oCon.AsignarParametroEntero("@facdig", oUsu.Adhesion_FacDigital);
                oCon.AsignarParametroEntero("@debito", oUsu.Debito_Automatico);
                oCon.AsignarParametroEntero("@tipousu", oUsu.Id_Usuarios_Tipos);
                oCon.AsignarParametroEntero("@calculo_bonificacion", oUsu.Calculo_Bonificacion);
                oCon.AsignarParametroDecimal("@impuesto", oUsu.Impuesto_Provincial);
                oCon.AsignarParametroEntero("@exento", oUsu.Exento_Impuesto_Provincial);
                oCon.AsignarParametroEntero("@personal", Personal.Id_Login);

                if (oUsu.Id == 0)
                {
                    oUsu.Id = oCon.EjecutarScalar();

                    oCon.CrearComando("UPDATE usuarios SET Codigo = @codigo where usuarios.id = @id");
                    oCon.AsignarParametroEntero("@codigo", oUsu.Id);
                    oCon.AsignarParametroEntero("@id", oUsu.Id);
                    oCon.EjecutarComando();
                }
                else
                    oCon.EjecutarComando();

                //CurrentUsuario = oUsu;

                oCon.ConfirmarTransaccion();

                oCon.DesConectar();

                LlenarObjeto(oUsu.Id);
            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();

                throw;
            }

            return oUsu.Id;
        }

        public DataRow getDatos(Int32 idUsuario)
        {
            DataTable dt = new DataTable();

            try
            {
                //oCon.Conectar();
                //oCon.CrearComando(String.Format("SELECT * FROM usuarios_vw WHERE ID = {0}", idUsuario));
                //dt = oCon.Tabla();
                //oCon.DesConectar();

                oCon.Conectar();
                oCon.CrearComando(String.Format("SELECT usuarios.id,usuarios.codigo,usuarios.apellido,usuarios.nombre,usuarios.Numero_Documento,usuarios_locaciones.piso,usuarios_locaciones.depto,usuarios_locaciones.telefono_1," +
                          " usuarios_locaciones.manzana, usuarios_locaciones.entre_Calle_1, usuarios_locaciones.entre_Calle_2, usuarios_locaciones.observacion," +
                          " usuarios.cuit, usuarios.Correo_Electronico, (select nombre from localidades where usuarios_locaciones.id = localidades.id) " +
                          " as localidad, usuarios_locaciones.calle, usuarios_locaciones.altura, usuarios.calculo_bonificacion, comprobantes_iva.Descripcion AS Condicion_Iva FROM usuarios," +
                          " usuarios_locaciones,comprobantes_iva where usuarios.Id_Comprobantes_Iva = comprobantes_iva.id and usuarios.id = usuarios_locaciones.id_usuarios and usuarios.id = {0} ", idUsuario));
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }

            return dt.Rows[0];
        }

        public Usuarios traerUsuario(Int32 idUsu, Int32 cod = 0)
        {
            Usuarios oUsuario = new Usuarios();
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                if (idUsu != 0)
                {
                    oCon.CrearComando(String.Format("SELECT usuarios.id,usuarios.presentacion as Presentacion  ,usuarios_locaciones.id as locacion_id, usuarios.codigo, CONCAT(usuarios.nombre,' ', usuarios.apellido) as Usuario, usuarios.Numero_Documento," +
                    " usuarios.cuit, usuarios.adhesion_facdigital, (select nombre from localidades where usuarios_locaciones.id = localidades.id) as localidad," +
                    " usuarios_locaciones.calle,usuarios_locaciones.altura, usuarios_locaciones.piso,usuarios_locaciones.depto," +
                    " usuarios_locaciones.manzana,usuarios_locaciones.entre_calle_1,usuarios_locaciones.entre_calle_2,usuarios_locaciones.observacion," +
                    " usuarios.nombre, usuarios.apellido, usuarios.calculo_bonificacion, usuarios.correo_electronico, usuarios.id_usuarios_tipos, usuarios.impuesto_provincial, usuarios.exento_impuesto_provincial, usuarios.Debito_Automatico,usuarios_tipodoc.tipo as tipo_doc  FROM usuarios left join usuarios_locaciones on usuarios_locaciones.id_usuarios=usuarios.id  LEFT JOIN usuarios_tipodoc on usuarios_tipodoc.id=usuarios.id_usuarios_tipodoc where usuarios.id = usuarios_locaciones.id_usuarios and usuarios.id = {0} ", idUsu));
                }
                else
                {

                    oCon.CrearComando(String.Format("SELECT usuarios.id,usuarios.presentacion as Presentacion ,usuarios_locaciones.id as locacion_id, usuarios.codigo, CONCAT(usuarios.nombre,' ', usuarios.apellido) as Usuario, usuarios.Numero_Documento," +
                    " usuarios.cuit, usuarios.adhesion_facdigital, (select nombre from localidades where usuarios_locaciones.id = localidades.id) as localidad," +
                    " usuarios_locaciones.calle,usuarios_locaciones.altura, usuarios_locaciones.piso,usuarios_locaciones.depto," +
                    " usuarios_locaciones.manzana,usuarios_locaciones.entre_calle_1,usuarios_locaciones.entre_calle_2,usuarios_locaciones.observacion," +
                    " usuarios.nombre, usuarios.apellido, usuarios.calculo_bonificacion, usuarios.correo_electronico, usuarios.id_usuarios_tipos, usuarios.impuesto_provincial, usuarios.exento_impuesto_provincial, usuarios.Debito_Automatico,usuarios_tipodoc.tipo as tipo_doc  FROM usuarios left join usuarios_locaciones on usuarios_locaciones.id_usuarios=usuarios.id  LEFT JOIN usuarios_tipodoc on usuarios_tipodoc.id=usuarios.id_usuarios_tipodoc where usuarios.id = usuarios_locaciones.id_usuarios  and  usuarios.codigo = {0} ", cod));

                    // oCon.CrearComando(String.Format("SELECT usuarios.id, usuarios_locaciones.id as locacion_id, usuarios.codigo, CONCAT(usuarios.nombre,' ', usuarios.apellido) as Usuario, usuarios.Numero_Documento," +
                    //" usuarios.cuit, usuarios.adhesion_facdigital, (select nombre from localidades where usuarios_locaciones.id = localidades.id) as localidad," +
                    //" usuarios_locaciones.calle,usuarios_locaciones.altura, usuarios_locaciones.piso,usuarios_locaciones.depto," +
                    //" usuarios_locaciones.manzana,usuarios_locaciones.entre_calle_1,usuarios_locaciones.entre_calle_2,usuarios_locaciones.observacion," +
                    //" usuarios.nombre, usuarios.apellido, usuarios.calculo_bonificacion, usuarios.correo_electronico, usuarios.id_usuarios_tipos, usuarios.impuesto_provincial, usuarios.exento_impuesto_provincial, usuarios.Debito_Automatico,usuarios_tipodoc.tipo as tipo_doc " +
                    //"FROM usuarios,usuarios_locaciones LEFT JOIN usuarios_tipodoc on usuarios_tipodoc.id=usuarios.id_usuarios_tipodoc where usuarios.id = usuarios_locaciones.id_usuarios and  usuarios.codigo = {0} ", cod));
                }


                dt = oCon.Tabla();

                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }
            if (dt.Rows.Count > 0)
            {
                oUsuario.Id = Convert.ToInt32(dt.Rows[0]["id"]);
                oUsuario.Codigo = Convert.ToInt32(dt.Rows[0]["codigo"]);
                oUsuario.Usuario = dt.Rows[0]["Usuario"].ToString();
                oUsuario.Nombre = dt.Rows[0]["nombre"].ToString();
                oUsuario.Apellido = dt.Rows[0]["apellido"].ToString();
                oUsuario.Numero_Documento = Convert.ToDouble(dt.Rows[0]["Numero_Documento"]);
                oUsuario.CUIT = Convert.ToInt64(dt.Rows[0]["cuit"]);
                oUsuario.localidad = dt.Rows[0]["localidad"].ToString();
                oUsuario.Calle = dt.Rows[0]["calle"].ToString();
                oUsuario.Altura = Convert.ToInt32(dt.Rows[0]["altura"]);
                oUsuario.piso = dt.Rows[0]["piso"].ToString();
                oUsuario.Depto = dt.Rows[0]["depto"].ToString();
                oUsuario.Manzana = dt.Rows[0]["manzana"].ToString();
                oUsuario.Entre1 = dt.Rows[0]["entre_calle_1"].ToString();
                oUsuario.Entre2 = dt.Rows[0]["entre_calle_2"].ToString();
                oUsuario.Observacion = dt.Rows[0]["observacion"].ToString();
                oUsuario.Id_Usuarios_Locacion = Convert.ToInt32(dt.Rows[0]["locacion_id"]);
                oUsuario.Calculo_Bonificacion = Convert.ToInt32(dt.Rows[0]["calculo_bonificacion"]);
                oUsuario.Correo_Electronico = dt.Rows[0]["correo_electronico"].ToString();
                oUsuario.Id_Usuarios_Tipos = Convert.ToInt32(dt.Rows[0]["id_usuarios_tipos"]);
                oUsuario.Impuesto_Provincial = Convert.ToDecimal(dt.Rows[0]["impuesto_provincial"]);
                oUsuario.Exento_Impuesto_Provincial = Convert.ToInt32(dt.Rows[0]["exento_impuesto_provincial"]);
                oUsuario.Adhesion_FacDigital = Convert.ToInt32(dt.Rows[0]["Adhesion_FacDigital"]);
                oUsuario.Adhesion_Debito = Convert.ToInt32(dt.Rows[0]["Debito_Automatico"]);
                oUsuario.Tipo_Documento = dt.Rows[0]["tipo_doc"].ToString();
                oUsuario.Presentacion = Convert.ToInt32(dt.Rows[0]["presentacion"]);
            }
            else
                oUsuario = null;
            return oUsuario;
        }

        public DataTable getDatos_ultimo()
        {
            DataTable dt = new DataTable();
            bool buscarTodos = true;
            try
            {
                string orden = "order by apellido,nombre";

                string filtro = "SELECT usuarios.id,usuarios.codigo,usuarios.apellido,usuarios.nombre,usuarios.Numero_Documento," +
                    "usuarios.cuit, usuarios.id_usuarios_tipos, usuarios.adhesion_facdigital, usuarios.calculo_bonificacion, usuarios.nacimiento,usuarios.Correo_Electronico,(select nombre from localidades where usuarios_locaciones.id_localidades=localidades.id)" +
                    "as localidad,usuarios_locaciones.calle,usuarios_locaciones.altura,usuarios_locaciones.piso,usuarios_locaciones.depto,usuarios_locaciones.manzana,usuarios_locaciones.telefono_1," +
                    "(select nombre from usuarios_profesiones where usuarios_profesiones.id = usuarios.id_usuarios_profesiones) as profesion," +
                    "id_comprobantes_iva,(select descripcion from comprobantes_iva where comprobantes_iva.id = usuarios.id_comprobantes_iva) as condicion_iva," +
                    "id_usuarios_tipodoc,(select tipo from usuarios_tipodoc where usuarios_tipodoc.id = usuarios.id_usuarios_tipodoc) as tipo_doc," +
                    "usuarios_locaciones.entre_calle_1,usuarios_locaciones.entre_calle_2,usuarios_locaciones.observacion,usuarios_locaciones.id as id_usuarios_locaciones, usuarios_locaciones.id_localidades, usuarios_locaciones.saldo " +
                    "FROM usuarios , usuarios_locaciones where usuarios.id=usuarios_locaciones.id_usuarios ";

                if (Codigo != 0)
                {
                    Apellido = "";
                    Nombre = "";
                    Correo_Electronico = "";
                    Numero_Documento = 0;
                    CUIT = 0;
                    filtro = filtro + "and  usuarios.codigo=" + Codigo + " ";
                    buscarTodos = false;
                }

                if (String.IsNullOrEmpty(Apellido) == false)
                {
                    Correo_Electronico = "";
                    Numero_Documento = 0;
                    CUIT = 0;
                    Codigo = 0;
                    filtro = filtro + "and  (usuarios.apellido like '%" + Apellido + "%' ";
                    buscarTodos = false;
                }

                if (String.IsNullOrEmpty(Nombre) == false)
                {
                    Correo_Electronico = "";
                    Numero_Documento = 0;
                    CUIT = 0;
                    Codigo = 0;
                    filtro = filtro + "or  usuarios.nombre like '%" + Nombre + "%' )";
                    buscarTodos = false;
                }

                if (Numero_Documento != 0)
                {
                    Apellido = "";
                    Nombre = "";
                    Calle = "";
                    CUIT = 0;
                    Codigo = 0;
                    Correo_Electronico = "";
                    filtro = filtro + "and  usuarios.Numero_Documento =" + Numero_Documento + " ";
                    buscarTodos = false;
                }

                if (String.IsNullOrEmpty(Calle) == false)
                {
                    Apellido = "";
                    Nombre = "";
                    Numero_Documento = 0;
                    Codigo = 0;
                    CUIT = 0;
                    Correo_Electronico = "";
                    if (Char.IsNumber(Convert.ToChar(Calle.Substring(0, 1))))
                    {
                        filtro = filtro + "and  usuarios_locaciones.calle ='" + Calle + "' and usuarios_locaciones.altura >= " + Altura + " ";

                    }
                    else
                    {
                        filtro = filtro + "and  usuarios_locaciones.calle like '%" + Calle + "%' and usuarios_locaciones.altura >= " + Altura + " ";

                    }
                    orden = " order by usuarios_locaciones.calle DESC ,usuarios_locaciones.altura ASC ";
                    buscarTodos = false;
                }

                if (CUIT != 0)
                {
                    Apellido = "";
                    Nombre = "";
                    Calle = "";
                    Codigo = 0;
                    //  Numero_Documento = 0;
                    Correo_Electronico = "";
                    filtro = filtro + "and  (usuarios.Cuit=" + CUIT + " or usuarios.Numero_Documento=" + Numero_Documento + ")";
                    buscarTodos = false;
                }

                if (String.IsNullOrEmpty(Correo_Electronico) == false)
                {
                    Calle = "";
                    Codigo = 0;
                    Numero_Documento = 0;
                    CUIT = 0;
                    filtro = filtro + "and  usuarios.Correo_Electronico like '%" + Correo_Electronico + "%'";
                    buscarTodos = false;
                }

                filtro = filtro + orden;
                if (buscarTodos)
                    filtro = String.Format("select * from ({0})filtro order by id desc limit 100", filtro);
                oCon.Conectar();
                oCon.CrearComando(filtro);
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

        public DataTable Buscar_datos_usuario(int id)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT usuarios.id AS Id_usuario, usuarios.Codigo, usuarios.Nombre AS Nom_usu, usuarios.Apellido, usuarios.Id_Usuarios_TipoDoc,usuarios.Exento_Impuesto_Provincial, (select usuarios_tipodoc.Tipo from usuarios_tipodoc where usuarios_tipodoc.Id=usuarios.Id_Usuarios_TipoDoc) AS tdoc, usuarios.Numero_Documento, (select comprobantes_iva.Descripcion from comprobantes_iva where comprobantes_iva.Id=usuarios.Id_Comprobantes_Iva) AS Descripcion, usuarios.Cuit, usuarios.Nacimiento, usuarios.Correo_Electronico, (select usuarios_profesiones.Nombre from usuarios_profesiones where usuarios_profesiones.Id=usuarios.Id_Usuarios_Profesiones) AS Nom_profesion, usuarios.Id_Comprobantes_Iva, usuarios.Id_Usuarios_Profesiones, usuarios.adhesion_facdigital, usuarios.calculo_bonificacion, usuarios.id_usuarios_tipos, usuarios.debito_automatico, usuarios.impuesto_provincial from usuarios where id=@id");
                oCon.AsignarParametroEntero("@id", id);
                dt = oCon.Tabla();
                oCon.DesConectar();
                DataTable dtDinamica = new DataTable();
                dtDinamica.Clear();
                dtDinamica = ObtenerPercepcionEspecialActual(Convert.ToInt32(id));
                if (dtDinamica.Rows.Count > 0)
                {
                    decimal impuestoProvincial = 0;
                    impuestoProvincial = Convert.ToDecimal(dtDinamica.Rows[0]["percepcion_esp"].ToString());
                    dt.Rows[0]["Impuesto_Provincial"] = impuestoProvincial;
                    dt.AcceptChanges();
                }
            }
            catch (Exception)
            {
                oCon.DesConectar();

                throw;
            }


            return dt;
        }

        public DataTable Buscar_datos_usuario(double dni)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT usuarios.Id_Comprobantes_Iva,usuarios_locaciones.id AS Id_Usuario_Locacion,concat(usuarios.apellido,' , ',usuarios.nombre) AS Usuario,  " +
                    "usuarios.id AS Id_usuario, usuarios.Codigo, usuarios.Nombre AS Nom_usu, usuarios.Apellido, " +
                    "usuarios.Id_Usuarios_TipoDoc, (select usuarios_tipodoc.Tipo from usuarios_tipodoc where usuarios_tipodoc.Id = usuarios.Id_Usuarios_TipoDoc) AS tdoc, " +
                    "usuarios.Numero_Documento, (select comprobantes_iva.Descripcion from comprobantes_iva where comprobantes_iva.Id = usuarios.Id_Comprobantes_Iva) AS Descripcion, " +
                    "usuarios.Cuit, usuarios.Nacimiento, usuarios.Correo_Electronico,  " +
                    "(select usuarios_profesiones.Nombre from usuarios_profesiones where usuarios_profesiones.Id = usuarios.Id_Usuarios_Profesiones) AS Nom_profesion, " +
                    "usuarios.Id_Comprobantes_Iva, usuarios.Id_Usuarios_Profesiones,  " +
                    "usuarios.adhesion_facdigital, usuarios.calculo_bonificacion,  " +
                    "usuarios.id_usuarios_tipos, usuarios.debito_automatico , usuarios_locaciones.Calle, usuarios_locaciones.Altura, " +
                    "localidades.Nombre AS Localidad, ifnull(provincias.Nombre, 'Buenos Aires') AS Provincia, localidades.Codigo_Postal AS Codigo_postal " +
                    "from usuarios " +
                    "LEFT JOIN usuarios_locaciones ON usuarios_locaciones.Id_Usuarios = usuarios.id " +
                    "LEFT JOIN localidades ON usuarios_locaciones.Id_Localidades = localidades.id " +
                    "LEFT JOIN provincias ON usuarios_locaciones.Id_Provincias = provincias.id " +
                    "where numero_documento = @numero_documento or cuit = @numero_documento2");
                oCon.AsignarParametroDouble("@numero_documento", dni);
                oCon.AsignarParametroDouble("@numero_documento2", dni);
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

        public void Guardar_Correo(Usuarios oUsu)
        {
            try
            {
                oCon.Conectar();

                if (oUsu.Id > 0)
                {
                    oCon.CrearComando("UPDATE usuarios SET Correo_Electronico = @email,id_personal=@personal WHERE Id = @id");

                    oCon.AsignarParametroEntero("@id", oUsu.Id);
                    oCon.AsignarParametroCadena("@email", oUsu.Correo_Electronico);
                    oCon.AsignarParametroEntero("@persoanl", Personal.Id_Login);

                }


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

        public void LlenarObjeto(int id, int cod = 0)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                if (cod == 0)
                {
                    
                    oCon.CrearComando(String.Format("SELECT id, codigo, CONCAT(usuarios.nombre,' ', usuarios.apellido) as Usuario, Numero_Documento," +
                    " cuit, (select nombre from usuarios_profesiones where usuarios.id_usuarios_profesiones = usuarios_profesiones.id) as profesion," +
                    " (select tipo from usuarios_tipodoc where usuarios.id_usuarios_tipodoc= usuarios_tipodoc.id) as Tipo_Documento," +
                    " (select descripcion from comprobantes_iva where usuarios.id_comprobantes_iva = comprobantes_iva.id) as Condicion_Iva," +
                    " nombre, apellido,correo_electronico, Id_Usuarios_TipoDoc, Id_Comprobantes_Iva, Id_Usuarios_Profesiones, calculo_bonificacion,Impuesto_provincial,Exento_Impuesto_provincial, id_usuarios_tipos, Debito_Automatico, Adhesion_FacDigital,nacimiento FROM usuarios where id = {0} and borrado = 0", id));

                   
                }
                else
                {
                    oCon.CrearComando(String.Format("SELECT id, codigo, CONCAT(usuarios.nombre,' ', usuarios.apellido) as Usuario, Numero_Documento," +
                    " cuit, (select nombre from usuarios_profesiones where usuarios.id_usuarios_profesiones = usuarios_profesiones.id) as profesion," +
                    " (select tipo from usuarios_tipodoc where usuarios.id_usuarios_tipodoc= usuarios_tipodoc.id) as Tipo_Documento," +
                    " (select descripcion from comprobantes_iva where usuarios.id_comprobantes_iva = comprobantes_iva.id) as Condicion_Iva," +
                    " nombre, apellido,correo_electronico, Id_Usuarios_TipoDoc, Id_Comprobantes_Iva, Id_Usuarios_Profesiones, calculo_bonificacion,Impuesto_provincial,Exento_Impuesto_provincial, id_usuarios_tipos, Debito_Automatico, Adhesion_FacDigital,nacimiento FROM usuarios where codigo = {0} and borrado = 0", cod));

                }

                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
            }
            if (dt.Rows.Count > 0)
            {
                CurrentUsuario.Id = Convert.ToInt32(dt.Rows[0]["id"]);
                CurrentUsuario.Codigo = Convert.ToInt32(dt.Rows[0]["codigo"]);
                CurrentUsuario.Usuario = dt.Rows[0]["Usuario"].ToString();
                CurrentUsuario.Nombre = dt.Rows[0]["nombre"].ToString();
                CurrentUsuario.Apellido = dt.Rows[0]["apellido"].ToString();
                CurrentUsuario.Numero_Documento = Convert.ToDouble(dt.Rows[0]["Numero_Documento"]);
                CurrentUsuario.CUIT = Convert.ToInt64(dt.Rows[0]["cuit"]);
                CurrentUsuario.Profesion = dt.Rows[0]["profesion"].ToString();
                CurrentUsuario.Condicion_Iva = dt.Rows[0]["condicion_iva"].ToString();
                CurrentUsuario.Tipo_Documento = dt.Rows[0]["tipo_documento"].ToString();
                CurrentUsuario.Correo_Electronico = dt.Rows[0]["correo_electronico"].ToString();
                CurrentUsuario.Id_Usuarios_TipoDoc = Convert.ToInt32(dt.Rows[0]["id_usuarios_tipodoc"]);
                CurrentUsuario.Id_Comprobantes_Iva = Convert.ToInt32(dt.Rows[0]["id_comprobantes_iva"]);
                CurrentUsuario.Id_Usuarios_Profesiones = Convert.ToInt32(dt.Rows[0]["id_usuarios_profesiones"]);
                CurrentUsuario.Calculo_Bonificacion = Convert.ToInt32(dt.Rows[0]["calculo_bonificacion"]);
                CurrentUsuario.Id_Usuarios_Tipos = Convert.ToInt32(dt.Rows[0]["id_usuarios_tipos"]);
                CurrentUsuario.Impuesto_Provincial = Convert.ToDecimal(dt.Rows[0]["Impuesto_Provincial"]);
                CurrentUsuario.Exento_Impuesto_Provincial = Convert.ToInt32(dt.Rows[0]["Exento_Impuesto_Provincial"]);
                CurrentUsuario.Adhesion_Debito = Convert.ToInt32(dt.Rows[0]["Debito_Automatico"]);
                CurrentUsuario.Adhesion_FacDigital = Convert.ToInt32(dt.Rows[0]["Adhesion_FacDigital"]);
                CurrentUsuario.Nacimiento = Convert.ToDateTime(dt.Rows[0]["Nacimiento"]);
                if (Current_IdUsuarioLocacion > 0)
                {
                    CurrentUsuarioDomFiscal = oDomFiscal.LlenarDatosLocFiscal(Current_IdUsuarioLocacion);
                }
                else
                {
                    CurrentUsuarioDomFiscal = oDomFiscal.LlenarDatosLocFiscal(0);

                }

            }
            else
            {
                CurrentUsuario.Id = 0;
            }
        }

        public void ActualizarEstadoDebitoAutomatico(int IdUsuarios, int IdEstado)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("UPDATE usuarios SET debito_automatico = @IdEstado,id_personal=@personal WHERE Id = @Id");
                oCon.AsignarParametroEntero("@IdEstado", IdEstado);
                oCon.AsignarParametroEntero("@personal", Personal.Id_Login);
                oCon.AsignarParametroEntero("@Id", IdUsuarios);
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

        public DataTable ListarUsuariosTipos()
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando("select * from usuarios_tipos");
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

        public DataTable Listar(int id)
        {
            string query = String.Empty;
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                if (id > 0)
                    query = String.Format("select * from vw_usuarios where id={0} and borrado=0", id);
                else
                    query = String.Format("Select * from vw_usuarios where borrado=0");

                oCon.CrearComando(query);
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception ex)
            {
                string msj = ex.Message;
                oCon.DesConectar();
                throw;
            }

            return dt;
        }

        public DataTable Busqueda(string filtro)
        {
            DataTable dataTable = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando(String.Format("  SELECT usuarios.codigo as codigo_usuario, "
                    + " usuarios.apellido, usuarios.nombre, localidades.nombre as localidad, localidades.abreviatura as AbvLocalidad, usuarios_locaciones.calle,"
                    + " usuarios_locaciones.altura, usuarios_locaciones.piso, usuarios_locaciones.depto, usuarios_locaciones.entre_calle_1,"
                    + "  usuarios_locaciones.entre_calle_2, usuarios_locaciones.saldo, usuarios_locaciones.id_usuarios, usuarios_locaciones.id as id_locacion,"
                    + " usuarios_locaciones.id_localidades, usuarios_locaciones.id_usuarios as id, usuarios_locaciones.id as id_usuarios_locaciones,"
                    + " usuarios_locaciones.id_locacion_fiscal_asociada, usuarios_locaciones.activo,"
                    + "  (SELECT COUNT(*) FROM usuarios_servicios"
                    + "  LEFT JOIN servicios_tipos ON usuarios_servicios.id_servicios_tipo = servicios_tipos.id"
                    + "  WHERE usuarios_locaciones.id = usuarios_servicios.id_usuarios_locaciones"
                    + "  and usuarios_servicios.id_servicios_estados IN(1, 2, 3) and usuarios_servicios.borrado = 0 and id_servicios_grupos = 1) as CABLE,"
                    + "  (SELECT COUNT(*) FROM usuarios_servicios"
                    + "  LEFT JOIN servicios_tipos ON usuarios_servicios.id_servicios_tipo = servicios_tipos.id"
                    + "  WHERE usuarios_locaciones.id = usuarios_servicios.id_usuarios_locaciones"
                    + "  and usuarios_servicios.id_servicios_estados IN(1, 2, 3) and usuarios_servicios.borrado = 0 and id_servicios_grupos = 2) as INTERNET"
                    + "  from usuarios_locaciones"
                    + "  LEFT JOIN localidades ON usuarios_locaciones.id_localidades = localidades.id"
                    + "  LEFT JOIN usuarios ON usuarios_locaciones.id_usuarios = usuarios.id"
                    + "  LEFT JOIN usuarios_tipos ON usuarios.id_usuarios_tipos = usuarios_tipos.id WHERE {0} ", filtro));
                dataTable = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }

            return dataTable;
        }

        public DataTable tempDatosUsuarios(int id)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("select usuarios.id,usuarios.codigo,usuarios.apellido,usuarios.nombre,usuarios.numero_documento,usuarios.cuit,"
                    + " usuarios.id_usuarios_tipos, usuarios.adhesion_facdigital, usuarios.calculo_bonificacion, usuarios.nacimiento, usuarios.correo_electronico,"
                    + " localidades.Nombre AS localidad,"
                    + " usuarios_locaciones.calle, usuarios_locaciones.altura, usuarios_locaciones.piso, usuarios_locaciones.depto, usuarios_locaciones.manzana,"
                    + " usuarios_locaciones.telefono_1, usuarios_profesiones.Nombre AS profesion,"
                    + " usuarios.id_comprobantes_iva, comprobantes_iva.Descripcion as condicion_iva,"
                    + " usuarios.id_usuarios_tipodoc, usuarios_tipodoc.Tipo as tipo_doc,"
                    + " usuarios_locaciones.entre_calle_1, usuarios_locaciones.entre_calle_2, usuarios_locaciones.observacion,"
                    + " usuarios_locaciones.id as id_usuarios_locaciones, usuarios_locaciones.id_localidades, usuarios_locaciones.saldo"
                    + " from usuarios"
                    + " LEFT JOIN usuarios_locaciones ON usuarios_locaciones.Id_Usuarios = usuarios.id"
                    + " LEFT JOIN localidades ON localidades.Id = usuarios_locaciones.Id_Localidades"
                    + " LEFT JOIN usuarios_profesiones ON usuarios_profesiones.Id = usuarios.Id_Usuarios_Profesiones"
                    + " LEFT JOIN comprobantes_iva ON comprobantes_iva.Id = usuarios.id_comprobantes_iva"
                    + " LEFT JOIN usuarios_tipodoc ON usuarios_tipodoc.Id = usuarios.Id_Usuarios_TipoDoc"
                    + " where usuarios.id = @id");
                oCon.AsignarParametroEntero("@id", id);
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

        public int TraerId(Int32 cod)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("select id from usuarios where codigo=@cod");
                oCon.AsignarParametroEntero("@cod", Convert.ToInt32(cod));
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }
            if (dt.Rows.Count > 0)
            {
                return Convert.ToInt32(dt.Rows[0]["id"]);
            }
            else
                return 0;
        }

        public Usuarios traerUltimoUsuario()//MAXI 17/10
        {
            Usuarios oUsuario = new Usuarios();
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();

                oCon.CrearComando("SELECT usuarios.id, usuarios_locaciones.id as locacion_id, usuarios.codigo, CONCAT(usuarios.nombre,' ', usuarios.apellido) as Usuario, usuarios.Numero_Documento," +
                " usuarios.cuit, usuarios.adhesion_facdigital, (select nombre from localidades where usuarios_locaciones.id = localidades.id) as localidad," +
                " usuarios_locaciones.calle,usuarios_locaciones.altura, usuarios_locaciones.piso,usuarios_locaciones.depto," +
                " usuarios_locaciones.manzana,usuarios_locaciones.entre_calle_1,usuarios_locaciones.entre_calle_2,usuarios_locaciones.observacion," +
                " usuarios.nombre, usuarios.apellido, usuarios.calculo_bonificacion, usuarios.correo_electronico, usuarios.id_usuarios_tipos, usuarios.impuesto_provincial, usuarios.exento_impuesto_provincial, usuarios.Debito_Automatico FROM usuarios,usuarios_locaciones where usuarios.id = usuarios_locaciones.id_usuarios order by usuarios.id desc limit 1");

                dt = oCon.Tabla();

                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }
            if (dt.Rows.Count > 0)
            {
                oUsuario.Id = Convert.ToInt32(dt.Rows[0]["id"]);
                oUsuario.Codigo = Convert.ToInt32(dt.Rows[0]["codigo"]);
                oUsuario.Usuario = dt.Rows[0]["Usuario"].ToString();
                oUsuario.Nombre = dt.Rows[0]["nombre"].ToString();
                oUsuario.Apellido = dt.Rows[0]["apellido"].ToString();
                oUsuario.Numero_Documento = Convert.ToDouble(dt.Rows[0]["Numero_Documento"]);
                oUsuario.CUIT = Convert.ToInt64(dt.Rows[0]["cuit"]);
                oUsuario.localidad = dt.Rows[0]["localidad"].ToString();
                oUsuario.Calle = dt.Rows[0]["calle"].ToString();
                oUsuario.Altura = Convert.ToInt32(dt.Rows[0]["altura"]);
                oUsuario.piso = dt.Rows[0]["piso"].ToString();
                oUsuario.Depto = dt.Rows[0]["depto"].ToString();
                oUsuario.Manzana = dt.Rows[0]["manzana"].ToString();
                oUsuario.Entre1 = dt.Rows[0]["entre_calle_1"].ToString();
                oUsuario.Entre2 = dt.Rows[0]["entre_calle_2"].ToString();
                oUsuario.Observacion = dt.Rows[0]["observacion"].ToString();
                oUsuario.Id_Usuarios_Locacion = Convert.ToInt32(dt.Rows[0]["locacion_id"]);
                oUsuario.Calculo_Bonificacion = Convert.ToInt32(dt.Rows[0]["calculo_bonificacion"]);
                oUsuario.Correo_Electronico = dt.Rows[0]["correo_electronico"].ToString();
                oUsuario.Id_Usuarios_Tipos = Convert.ToInt32(dt.Rows[0]["id_usuarios_tipos"]);
                oUsuario.Impuesto_Provincial = Convert.ToDecimal(dt.Rows[0]["impuesto_provincial"]);
                oUsuario.Exento_Impuesto_Provincial = Convert.ToInt32(dt.Rows[0]["exento_impuesto_provincial"]);
                oUsuario.Adhesion_FacDigital = Convert.ToInt32(dt.Rows[0]["Adhesion_FacDigital"]);
                oUsuario.Adhesion_Debito = Convert.ToInt32(dt.Rows[0]["Debito_Automatico"]);
            }
            else
                oUsuario = null;
            return oUsuario;
        }

        public int ActualizarUniverso(int id)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("update usuarios set presentacion=1,id_personal=@personal where id=@id");
                oCon.AsignarParametroEntero("@perosnal", Personal.Id_Login);
                oCon.AsignarParametroEntero("@id", id);
                oCon.ComenzarTransaccion();
                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
                return 0;
            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                return -1;
                throw;
            }
        }
        public DataTable listar()
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT usuarios_servicios.`*`, servicios.Descripcion AS servicios,usuarios.Codigo FROM usuarios_servicios"
                + " LEFT JOIN servicios ON servicios.Id = usuarios_servicios.Id_Servicios"
                + " LEFT JOIN usuarios ON usuarios.Id = usuarios_servicios.Id_Usuarios"
                + " WHERE servicios.Id = 1 AND usuarios_servicios.Id_Servicios_Estados = 2 AND usuarios_servicios.Borrado = 0 AND usuarios.presentacion = 0 limit 1500");
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

        public DataTable ListarUsuariosExportacionTXT()
        {
            DataTable dt = new DataTable();
            DataTable dt1 = new DataTable();
            int Tel1 = 0;
            int Tel2 = 0;
            int Telefono1 = 0;
            int Telefono2 = 0;
            try
            {
                oCon.Conectar();

                oCon.CrearComando("SELECT usuarios.Id, usuarios.Codigo, usuarios.Apellido, usuarios.Nombre, " +
                    "usuarios.Numero_Documento, usuarios.Cuit, localidades.Nombre AS Localidad, concat(usuarios_locaciones.Prefijo_1, '-', usuarios_locaciones.Telefono_1) AS Telefono, " +
                    "usuarios.Correo_Electronico AS Mail, usuarios_locaciones.Saldo AS Saldo, localidades.Abreviatura AS LocalidadAbv " +
                    "FROM usuarios_locaciones " +
                    "LEFT JOIN usuarios ON usuarios_locaciones.Id_Usuarios = usuarios.id " +
                    "LEFT JOIN localidades ON usuarios_locaciones.id_localidades = localidades.Id " +
                    "WHERE usuarios.borrado = 0 ORDER BY apellido");
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

        public DataTable ListarTodosUsuariosARBA()
        {
            DataTable dt;
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT CONCAT(usuarios.Apellido , ' , ', usuarios.Nombre) AS Name, usuarios.*, usuarios_dom_fiscal.* " +
                                  "FROM usuarios " +
                                  "LEFT JOIN usuarios_dom_fiscal ON usuarios_dom_fiscal.Id_Usuarios = usuarios.id " +
                                  "WHERE usuarios.borrado = 0 and usuarios.Id_Comprobantes_Iva > 1");
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

        public void ActualizaImpuesto_Provincial(double cuit, decimal impuesto_provincial)
        {
            try
            {
                oCon.Conectar();
                if (impuesto_provincial != 0)
                    oCon.CrearComando("update usuarios set Impuesto_Provincial= @impuesto,id_personal=@personal where Cuit= @cuit");
                else
                    oCon.CrearComando("update usuarios set Impuesto_Provincial= @impuesto, exento_impuesto_provincial=1,id_personal=@personal where Cuit= @cuit");

                oCon.AsignarParametroDecimal("@impuesto", impuesto_provincial);
                oCon.AsignarParametroEntero("@personal", Personal.Id_Login);
                oCon.AsignarParametroDouble("@cuit", cuit);
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

        public string GetCampo(string campo, int idUsuario)
        {
            string valor = string.Empty;
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando($"SELECT {campo} FROM usuarios WHERE borrado = 0 and id = {idUsuario}");
                dt = oCon.Tabla();
                valor = dt.Rows[0][campo].ToString();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
            }
            return valor;
        }

        public void GuardarPercepcionEspeciales(DateTime Desde, DateTime Hasta, int Id_Usuario, decimal Percepcion, string Cuit,string Numero_Tramite)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("INSERT INTO usuarios_impuestos_esp(id_usuarios, cuit, desde, hasta, percepcion_esp,Numero_Tramite,id_personal)" +
                        " VALUES(@id_Usu, @cuit, @desde, @hasta, @impuesto,@Num_Tramite, @personal);");
                oCon.AsignarParametroEntero("@id_Usu", Id_Usuario);
                oCon.AsignarParametroCadena("@cuit", Cuit);
                oCon.AsignarParametroFecha("@desde", Desde);
                oCon.AsignarParametroFecha("@hasta", Hasta);
                oCon.AsignarParametroDecimal("@impuesto", Percepcion);
                oCon.AsignarParametroCadena("@Num_Tramite", Numero_Tramite);
                oCon.AsignarParametroEntero("@personal", Personal.Id_Login);
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

        public DataTable Listar_PercepcionesEsp(int id_Usuario)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT *  " +
                    "FROM usuarios_impuestos_esp " +
                    "LEFT JOIN personal ON usuarios_impuestos_esp.id_personal = personal.id " +
                    "WHERE usuarios_impuestos_esp.borrado = 0 AND usuarios_impuestos_esp.id_usuarios = @id_Usu");
                oCon.AsignarParametroEntero("@id_Usu", id_Usuario);
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

        public DataTable VerificarUltimaPercepcionEsp(int id_Usuario)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT * " +
                    "FROM usuarios_impuestos_esp " +
                    "WHERE usuarios_impuestos_esp.id_usuarios = @id_Usu and borrado = 0 ORDER BY id DESC " +
                    "LIMIT 1; ");
                oCon.AsignarParametroEntero("@id_Usu", id_Usuario);
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

        public DataTable ObtenerPercepcionEspecialActual(int id_Usuario)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT * , DATE(NOW()) " +
                    "FROM usuarios_impuestos_esp " +
                    "WHERE usuarios_impuestos_esp.id_usuarios = @id_Usu and borrado = 0 " +
                    "AND DATE(NOW()) >= desde AND DATE(NOW()) <= hasta " +
                    "ORDER BY id DESC ; ");
                oCon.AsignarParametroEntero("@id_Usu", id_Usuario);
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


        public DataTable Listar_Activos_Mensuales(string filtro)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                if(filtro == "")
                {
                    oCon.CrearComando("SELECT t.id_servicio AS id_servicio, t.id_servicios_estados AS id_servicios_estados, t.Tipo_Serv AS Tipo_Servicio, t.servicio AS Servicio, t.Modalidad AS Modalidad, t.Factura_mensualmente AS Factura_Mensualmente,sum(t.cantidad) AS Cantidad " +
                        "FROM( " +
                        "SELECT servicios.id AS id_servicio, servicios_tipos.Nombre AS Tipo_Serv, servicios.Descripcion AS Servicio, servicios_modalidad.Nombre AS Modalidad, " +
                        "COUNT(usuarios_servicios.Id_Servicios) AS Cantidad, servicios_estados.Estado AS Estado, usuarios_servicios.Id_Servicios_Estados AS id_servicios_estados, " +
                        "servicios.Factura_Mensualmente " +
                        "FROM usuarios_servicios " +
                        "LEFT JOIN servicios ON usuarios_servicios.Id_Servicios = servicios.id " +
                        "LEFT JOIN servicios_modalidad ON servicios.Id_Servicios_Modalidad = servicios_modalidad.id " +
                        "LEFT JOIN servicios_estados ON usuarios_servicios.Id_Servicios_Estados = servicios_estados.id " +
                        "LEFT JOIN servicios_tipos ON servicios.Id_Servicios_Tipos = servicios_tipos.id " +
                        "WHERE usuarios_servicios.borrado = 0 AND servicios.borrado = 0 " +
                        "GROUP BY servicios.id, usuarios_servicios.Id_Servicios_Estados " +
                        "ORDER BY servicios.Id_Servicios_Modalidad) AS  T " +
                        "GROUP BY T.id_servicio ORDER BY T.Tipo_serv ");

                }
                else 
                {
                    oCon.CrearComando(String.Format("SELECT t.id_servicio AS id_servicio, t.id_servicios_estados AS id_servicios_estados,t.Tipo_Serv AS Tipo_Servicio, t.servicio AS Servicio, t.Modalidad AS Modalidad,sum(t.cantidad) AS Cantidad, t.Factura_mensualmente AS Factura_Mensualmente " +
                        "FROM( " +
                        "SELECT servicios.id AS id_servicio, servicios_tipos.Nombre AS Tipo_Serv, servicios.Descripcion AS Servicio, servicios_modalidad.Nombre AS Modalidad, " +
                        "COUNT(usuarios_servicios.Id_Servicios) AS Cantidad, servicios_estados.Estado AS Estado, usuarios_servicios.Id_Servicios_Estados AS id_servicios_estados, " +
                        "servicios.Factura_Mensualmente " +
                        "FROM usuarios_servicios " +
                        "LEFT JOIN servicios ON usuarios_servicios.Id_Servicios = servicios.id " +
                        "LEFT JOIN servicios_modalidad ON servicios.Id_Servicios_Modalidad = servicios_modalidad.id " +
                        "LEFT JOIN servicios_estados ON usuarios_servicios.Id_Servicios_Estados = servicios_estados.id " +
                        "LEFT JOIN servicios_tipos ON servicios.Id_Servicios_Tipos = servicios_tipos.id " +
                        "WHERE usuarios_servicios.borrado = 0 AND servicios.borrado = 0 " +
                        "GROUP BY servicios.id, usuarios_servicios.Id_Servicios_Estados " +
                        "ORDER BY servicios.Id_Servicios_Modalidad) AS T WHERE T.id_servicios_Estados IN ({0}) " +
                        "GROUP BY T.id_servicio ORDER BY T.Tipo_serv ", filtro));
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

        public DataTable Listar_Activos_Mensuales_usuarios(int id_Servicio, string Filtro) 
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                if (Filtro == "")
                {
                    oCon.CrearComando(String.Format("(select count(*) as CantUsu from (SELECT id_usuarios,count(*) FROM usuarios_servicios WHERE  id_servicios = {0} and borrado = 0 group by id_usuarios) as e) ", id_Servicio));

                }
                else
                {
                    oCon.CrearComando(String.Format("(select count(*) as CantUsu from (SELECT id_usuarios,count(*) FROM usuarios_servicios WHERE id_servicios_estados in ({0}) and id_servicios = {1} and borrado = 0 group by id_usuarios) as e)", Filtro,id_Servicio));
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

        public DataTable ObtenerTotalUsuariosActivos(string Filtro)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                if(Filtro == "")
                {
                    oCon.CrearComando(" (select count(*) as CantUsu " +
                    "FROM( " +
                    "        SELECT id_usuarios, count(*)" +
                    "        FROM usuarios_servicios" +
                    "         WHERE borrado = 0  group by id_usuarios " +
                    "    ) " +
                    "as e) ");
                }
                else
                {
                    oCon.CrearComando(String.Format(" (select count(*) as CantUsu " +
                    "FROM( " +
                    "        SELECT id_usuarios, count(*)" +
                    "        FROM usuarios_servicios" +
                    "         WHERE borrado = 0 AND usuarios_servicios.id_servicios_estados IN({0}) group by id_usuarios " +
                    "    ) " +
                    "as e) ", Filtro));
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





    }
}
