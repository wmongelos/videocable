using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
namespace CapaNegocios
{
    public class Plasticos
    {
        public int Id { get; set; }
        public string Titular { get; set; }
        public string Numero { get; set; }
        public DateTime Vencimiento { get; set; }
        public int Id_Forma_de_Pago { get; set; }
        public int Activo { get; set; }
        public int Borrado { get; set; }
        public Configuracion oConfing = new Configuracion();
        private Conexion oCon = new Conexion();

        public enum ESTADO
        {
            ACTIVO = 1,
            NO_ACTIVO = 0
        }

        public bool Guardar(Plasticos oPlasticos)
        {
            try
            {
                oCon.Conectar();

                if (oPlasticos.Id > 0)
                {
                    oCon.CrearComando("UPDATE plasticos set titular=@titular, numero = @numero, vencimiento=@vencimiento, id_forma_de_pago=@forma_de_pago, activo=@activo,id_personal=@personal WHERE Id = @id");
                    oCon.AsignarParametroEntero("@id", oPlasticos.Id);
                }
                else
                    oCon.CrearComando("INSERT INTO plasticos(titular,numero,vencimiento,id_forma_de_pago,activo,id_personal ) VALUES" +
                                      "(@titular,@numero, @vencimiento,@forma_de_pago,@activo,@personal);SELECT @@IDENTITY");
                oCon.AsignarParametroCadena("@titular", oPlasticos.Titular);
                oCon.AsignarParametroCadena("@numero", oPlasticos.Numero);
                oCon.AsignarParametroFecha("@vencimiento", oPlasticos.Vencimiento);
                oCon.AsignarParametroEntero("@forma_de_pago", oPlasticos.Id_Forma_de_Pago);
                oCon.AsignarParametroEntero("@activo", oPlasticos.Activo);
                oCon.AsignarParametroEntero("@personal", Personal.Id_Login);
                oCon.ComenzarTransaccion();
                if (oPlasticos.Id > 0)
                    oCon.EjecutarComando();
                else
                    oPlasticos.Id = oCon.EjecutarScalar();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
                return true;
            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                return false;
                throw;
            }
        }

        public void Eliminar(int id)
        {
            try
            {
                oCon.Conectar();
                oCon.ComenzarTransaccion();
                oCon.CrearComando("UPDATE plasticos SET borrado = 1 WHERE Id = @id");
                oCon.AsignarParametroEntero("@id", id);
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

        public DataTable Listar(string nroPlastico, double codUsuario, int idplastico = 0)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                if (idplastico > 0)
                {
                    oCon.CrearComando("select plasticos.id, numero, vencimiento, formas_de_pago.nombre as formapago, titular, formas_de_pago.id as id_forma_de_pago," +
                                  "if (plasticos.activo = 1,'ACTIVA','BAJA') as activoTexto,plasticos.activo,plasticos.borrado " +
                                  "from plasticos " +
                                  "left join formas_de_pago on plasticos.id_forma_de_pago = formas_de_pago.id " +
                                  "where plasticos.borrado = 0 and plasticos.id=@idplastico order by plasticos.id asc");
                    oCon.AsignarParametroEntero("@idplastico", idplastico);
                }
                else
                if (nroPlastico != "0")
                {
                    oCon.CrearComando("select plasticos.id, numero, vencimiento, formas_de_pago.nombre as formapago, titular, formas_de_pago.id as id_forma_de_pago," +
                                  "if (plasticos.activo = 1,'ACTIVA','BAJA') as activoTexto,plasticos.activo,plasticos.borrado " +
                                  "from plasticos left join formas_de_pago on plasticos.id_forma_de_pago = formas_de_pago.id " +
                                  "where plasticos.borrado = 0 and plasticos.numero=@nroplastico order by plasticos.id asc");
                    oCon.AsignarParametroCadena("@nroplastico", nroPlastico);
                }
                else if (codUsuario > 0)
                {
                    oCon.CrearComando("select plasticos.id,plasticos.numero,plasticos.vencimiento,formas_de_pago.nombre as formapago,plasticos.titular,formas_de_pago.id as id_forma_de_pago,if(plasticos.activo=1,'ACTIVA','BAJA') as activotexto,plasticos.activo,plasticos.borrado"
                        + " from plasticos"
                        + " left join plasticos_usuarios on plasticos_usuarios.id_plastico = plasticos.id"
                        + " left join usuarios_servicios on usuarios_servicios.id = plasticos_usuarios.id_usuarios_servicios"
                        + " left join usuarios on usuarios.id = usuarios_servicios.id_usuarios"
                        + " left join formas_de_pago on formas_de_pago.id = plasticos.id_forma_de_pago"
                        + " where plasticos.borrado = 0 and plasticos_usuarios.borrado = 0 and usuarios.codigo = @codusuario limit 1");
                    oCon.AsignarParametroDouble("@codusuario", codUsuario);
                }
                else
                    oCon.CrearComando("select plasticos.id,numero, vencimiento, formas_de_pago.nombre as formapago, titular,formas_de_pago.id as id_forma_de_pago," +
                                      "if (plasticos.activo = 1,'ACTIVA','BAJA') as activoTexto,plasticos.activo,plasticos.borrado " +
                                      "from plasticos left join formas_de_pago on plasticos.id_forma_de_pago = formas_de_pago.id " +
                                      "where plasticos.borrado = 0 order by plasticos.id asc");
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

        public DataTable ListarServiciosPorAsociar(int id_usuario)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando("select usuarios_servicios.id,usuarios_servicios.id_servicios,servicios.descripcion as servicio,servicios_Estados.estado, usuarios_locaciones.calle,usuarios_locaciones.altura, localidades.nombre as localidad, servicios.requiere_tarjeta " +
                    " from usuarios_servicios " +
                    " left join servicios on servicios.id=usuarios_servicios.id_servicios" +
                    " left join servicios_estados on servicios_estados.id=usuarios_servicios.id_servicios_estados" +
                    " left join usuarios_locaciones on usuarios_locaciones.id=usuarios_servicios.id_usuarios_locaciones" +
                    " left join localidades on localidades.id=usuarios_locaciones.id_localidades " +
                    "where usuarios_servicios.id_usuarios=@id_usuarios and usuarios_servicios.id_servicios_estados!=@cortado and usuarios_servicios.id_servicios_estados!=@retirado and usuarios_servicios.borrado = 0");
                oCon.AsignarParametroEntero("@id_usuarios", id_usuario);
                oCon.AsignarParametroEntero("@cortado", Convert.ToInt32(Servicios.Servicios_Estados.CORTADO));
                oCon.AsignarParametroEntero("@retirado", Convert.ToInt32(Servicios.Servicios_Estados.RETIRADO));
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

        public DataTable ListarPresentacionDebitos(string tipo_sub, int id_tarifa, int idFormaPago)
        {

            DataTable dt = new DataTable();
            int id_tipo_facturaciion = oConfing.GetValor_N("Id_Tipo_Facturacion");
            oCon.Conectar();
            if (id_tipo_facturaciion == 1)
            {
                oCon.CrearComando("select plasticos.id, plasticos.titular, plasticos.numero, plasticos.vencimiento, (select nombre from formas_de_pago where formas_de_pago.id = plasticos.id_forma_de_pago) as formapago,(select id from formas_de_pago where formas_de_pago.id = plasticos.id_forma_de_pago) as id_forma_de_pago, if (plasticos.activo = 1,'ACTIVA','BAJA') as activoTexto, plasticos.activo,plasticos.borrado " +
                ", plasticos_usuarios.id_usuarios_servicios " +
                ", usuarios_servicios_sub.Id_Servicios_Sub " +
                ", vw_tarifas.tiposub, vw_tarifas.id_servicios_tarifas, vw_tarifas.importe, vw_tarifas.id_tipo_facturacion " +
                ", usuarios_servicios.Id_Servicios_Categorias " +
                ", usuarios_servicios.Id_Zonas " +
                ", (SELECT sum(vw_tarifas.importe)) as suma " +
                "from plasticos " +
               "inner join plasticos_usuarios on plasticos_usuarios.id_plastico = plasticos.id " +
               "inner join usuarios_servicios_sub on usuarios_servicios_sub.id_usuarios_Servicios = plasticos_usuarios.id_usuarios_servicios " +
               "inner join vw_tarifas on vw_tarifas.id_servicios_sub = usuarios_servicios_sub.Id_Servicios_Sub " +
               "inner join usuarios_servicios on usuarios_servicios.id = usuarios_servicios_sub.id_usuarios_servicios " +
               "where plasticos.borrado = 0 and plasticos.activo = 1 and vw_tarifas.tiposub = @tiposub1 and vw_tarifas.id_servicios_tarifas =@id_servicios_tarifas1 and plasticos_usuarios.borrado = 0 " +
               " AND vw_tarifas.id_tipo_facturacion = usuarios_servicios.Id_Zonas and plasticos.id_forma_de_pago=@id_forma_de_pago " +
               "group by plasticos.id ");

            }
            else
            {
                oCon.CrearComando("select plasticos.id, plasticos.titular, plasticos.numero, plasticos.vencimiento, (select nombre from formas_de_pago where formas_de_pago.id = plasticos.id_forma_de_pago) as formapago,(select id from formas_de_pago where formas_de_pago.id = plasticos.id_forma_de_pago) as id_forma_de_pago, if (plasticos.activo = 1,'ACTIVA','BAJA') as activoTexto, plasticos.activo,plasticos.borrado " +
                ", plasticos_usuarios.id_usuarios_servicios " +
                ", usuarios_servicios_sub.Id_Servicios_Sub " +
                ", vw_tarifas.tiposub, vw_tarifas.id_servicios_tarifas, vw_tarifas.importe, vw_tarifas.id_tipo_facturacion " +
                ", usuarios_servicios.Id_Servicios_Categorias " +
                ", usuarios_servicios.Id_Zonas " +
                ", (SELECT sum(vw_tarifas.importe)) as suma " +
                "from plasticos " +
               "inner join plasticos_usuarios on plasticos_usuarios.id_plastico = plasticos.id " +
               "inner join usuarios_servicios_sub on usuarios_servicios_sub.id_usuarios_Servicios = plasticos_usuarios.id_usuarios_servicios " +
               "inner join vw_tarifas on vw_tarifas.id_servicios_sub = usuarios_servicios_sub.Id_Servicios_Sub " +
               "inner join usuarios_servicios on usuarios_servicios.id = usuarios_servicios_sub.id_usuarios_servicios " +
               "where plasticos.borrado = 0 and plasticos.activo = 1 and vw_tarifas.tiposub = @tiposub1 and vw_tarifas.id_servicios_tarifas =@id_servicios_tarifas1 and plasticos_usuarios.borrado = 0 " +
               " AND vw_tarifas.id_tipo_facturacion = usuarios_servicios.Id_Servicios_Categorias and plasticos.id_forma_de_pago=@id_forma_de_pago " +
               "group by plasticos.id ");
            }
            oCon.AsignarParametroCadena("@tiposub1", tipo_sub);
            oCon.AsignarParametroEntero("@id_servicios_tarifas1", id_tarifa);
            oCon.AsignarParametroEntero("@id_forma_de_pago", idFormaPago);
            dt = oCon.Tabla();
            int z = dt.Rows.Count;
            oCon.DesConectar();
            return dt;
        }

        public void DesactivarServiciosDebito(DataTable dtServiciosBaja)
        {
            try
            {
                List<int> listadoDebitos = new List<int>();
                oCon.Conectar();
                foreach (DataRow servicio in dtServiciosBaja.Rows)
                {
                    if (listadoDebitos.Contains(Convert.ToInt32(servicio["id_plastico"])) == false)
                        listadoDebitos.Add(Convert.ToInt32(servicio["id_plastico"]));
                    oCon.CrearComando("update plasticos_usuarios SET fecha_baja=@fechabaja, activo=0 where id_usuarios_servicios=@idusuariosservicios and id_plastico=@idplastico");
                    oCon.AsignarParametroFecha("@fechabaja", DateTime.Now);
                    oCon.AsignarParametroEntero("@idusuariosservicios", Convert.ToInt32(servicio["id_usuarios_servicios"]));
                    oCon.AsignarParametroEntero("@idplastico", Convert.ToInt32(servicio["id_plastico"]));
                    oCon.ComenzarTransaccion();
                    oCon.EjecutarComando();
                    oCon.ConfirmarTransaccion();
                }

                DataTable dtServiciosActivos = new DataTable();
                foreach (int debito in listadoDebitos)
                {
                    dtServiciosActivos.Clear();
                    oCon.CrearComando("select count(id) as cantidad from plasticos_usuarios where activo=1 and id_plastico=@idplastico");
                    oCon.AsignarParametroEntero("@idplastico", debito);
                    dtServiciosActivos = oCon.Tabla();
                    if (Convert.ToInt32(dtServiciosActivos.Rows[0]["cantidad"]) == 0)
                    {
                        oCon.CrearComando("update plasticos SET activo=0 where id=@idplastico");
                        oCon.AsignarParametroEntero("@idplastico", debito);
                        oCon.ComenzarTransaccion();
                        oCon.EjecutarComando();
                        oCon.ConfirmarTransaccion();
                    }
                }
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                throw;
            }

        }

        public DataTable ListarServiciosParaBaja(int idParte)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando("select partes_usuarios_servicios.*, usuarios_servicios.id_servicios, " +
                    "servicios.descripcion as servicio, servicios_tipos.nombre as servicio_tipo, " +
                    "CONCAT(usuarios.apellido,', ',usuarios.nombre) as usuario " +
                    "from partes_usuarios_servicios " +
                    " left join usuarios_servicios on partes_usuarios_servicios.id_usuarios_servicios = usuarios_servicios.id" +
                    " left join servicios on servicios.id = usuarios_servicios.id_servicios" +
                    " left join servicios_tipos on servicios_tipos.id = usuarios_servicios.id_servicios_tipo" +
                    " left join usuarios on usuarios.id = usuarios_servicios.id_usuarios" +
                    " where partes_usuarios_servicios.id_parte = @idparte");
                oCon.AsignarParametroEntero("@idparte", idParte);
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
    
        public bool ExisterNumeroTarjeta (string numeroTarjeta, out string salida, out int idPlastico, out DataTable dtDatosPlastico, out DataTable dtServiciosAdheridos)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT *  from plasticos WHERE numero=@num and borrado=0");
                oCon.AsignarParametroCadena("@num", numeroTarjeta);
                dt = oCon.Tabla();
                oCon.DesConectar();
                if (dt.Rows.Count > 0)
                {
                    string titular = dt.Rows[0]["titular"].ToString().ToUpper();
                    salida = $"Este número de tarjeta ya existe. \n Titular: {titular}. \n ¿Desea cargar los datos de la tarjeta existente? ";
                    idPlastico = Convert.ToInt32(dt.Rows[0]["id"]);
                    dtDatosPlastico = dt;
                    oCon.Conectar();
                    oCon.CrearComando("select plasticos_usuarios.id as id_plastico_usuario,plasticos_usuarios.id_usuarios_servicios,"
                        + " plasticos_usuarios.fecha_inicio, plasticos_usuarios.fecha_baja, plasticos_usuarios.activo,"
                        + " servicios.descripcion as servicio, usuarios.codigo,"
                        + " concat_ws(' ', trim(usuarios_locaciones.calle), ' nro: ', cast(usuarios_locaciones.altura as char(50)), ' piso: ', usuarios_locaciones.piso, 'depto: ', usuarios_locaciones.depto) as locacion"
                        + " from plasticos_usuarios"
                        + " left join usuarios_servicios on usuarios_servicios.id = plasticos_usuarios.id_usuarios_servicios"
                        + " left join usuarios on usuarios.id = usuarios_servicios.id_usuarios"
                        + " left join usuarios_locaciones on usuarios_locaciones.id = usuarios_servicios.id_usuarios_locaciones"
                        + " left join servicios on servicios.id = usuarios_servicios.id_servicios"
                        + "  where plasticos_usuarios.id_plastico = @idplastico and plasticos_usuarios.borrado = 0 and usuarios_servicios.borrado = 0");
                    oCon.AsignarParametroEntero("@idplastico", idPlastico);
                    dtServiciosAdheridos = oCon.Tabla();
                    oCon.DesConectar();
                    return false;
                }
                else
                {
                    dtDatosPlastico = null;
                    idPlastico = 0;
                    salida = "";
                    dtServiciosAdheridos = null;
                    return true;
                }
            }
            catch (Exception c)
            {
                oCon.DesConectar();
                salida = c.ToString();
                idPlastico = 0;
                dtDatosPlastico = null;
                dtServiciosAdheridos = null;
                return false;
            }
        }

    }
}
