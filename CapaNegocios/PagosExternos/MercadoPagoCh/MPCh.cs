using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;

namespace CapaNegocios.PagosExternos.MercadoPagoCh
{
    public class MPCh
    {
        private ConexionesExternas oConExterna;


        public List<PagoExterno> Listar()
        {
            DataTable dt = new DataTable();
            List<PagoExterno> oLista = new List<PagoExterno>();
            Usuarios_CtaCte oUsuarioCCT = new Usuarios_CtaCte();
            Usuarios oUsuario = new Usuarios();
            oConExterna = new ConexionesExternas();
            ConfiguracionPagos oConfPagos = new ConfiguracionPagos();
            string servidor = (string)oConfPagos.Get("servidor", (int)PagoExterno.Plataforma.MERCADOPAGO, TypeCode.String);
            string user = (string)oConfPagos.Get("usuario", (int)PagoExterno.Plataforma.MERCADOPAGO, TypeCode.String);
            string pass = (string)oConfPagos.Get("clave", (int)PagoExterno.Plataforma.MERCADOPAGO, TypeCode.String);
            string db = (string)oConfPagos.Get("base", (int)PagoExterno.Plataforma.MERCADOPAGO, TypeCode.String);
            if (Personal.Name_Login == "ADMINISTRADOR")
                oConExterna.conexionString = "server=localhost;uid=root;pwd=root2020;database=db_avcdigital;";
            else
                oConExterna.conexionString = $"server=192.168.20.250;uid=gestionavc;pwd=gest10n_avc;database=avcdigital;";

            oConExterna.Conectar();
            try
            {
                oConExterna.CrearComando("SELECT mercadopago_cabecera.id as id_cabecera, mercadopago_cabecera.fecha as fecha_creado,mercadopago_cabecera.pagado as fecha_pago,mercadopago_cabecera.total,"
                    + " mercadopago_cabecera.payment_id, mercadopago_cabecera.abonado, mercadopago_registros.id_comprobantes,mercadopago_registros.id as id_registro, mercadopago_registros.id_usuarios_ctacte,"
                    + " mercadopago_registros.descripcion"
                    + " from mercadopago_cabecera"
                    + " left join mercadopago_registros on mercadopago_registros.id_cabecera = mercadopago_cabecera.id"
                    + " WHERE mercadopago_cabecera.`status`  = 'approved' and"
                    + " date(mercadopago_registros.pasado_gies) = date('0000-00-00');");
                dt = oConExterna.Tabla();
                oConExterna.Desconectar();
                if (dt.Rows.Count > 0)
                {
                    foreach (DataRow item in dt.Rows)
                    {
                        DataTable dtDatos = oUsuarioCCT.ListarDatosCtaCte(Convert.ToInt32(item["id_usuarios_ctacte"]));
                        if (dtDatos.Rows.Count > 0)
                        {
                            PagoExterno oPago = new PagoExterno();
                            oUsuario = oUsuario.traerUsuario(Convert.ToInt32(dtDatos.Rows[0]["id_usuarios"]));
                            oPago.CodigoUsuario = Convert.ToInt32(item["abonado"]);
                            oPago.DescripcionUCC = item["descripcion"].ToString();
                            oPago.IdUsuarioCtaCte = Convert.ToInt32(item["id_usuarios_ctacte"]);
                            oPago.ImportePago = Convert.ToDecimal(item["total"]);
                            oPago.IdUsuario =oUsuario.Id;
                            oPago.FechaEmitido = Convert.ToDateTime(item["fecha_creado"]);
                            oPago.FechaPago = Convert.ToDateTime(item["fecha_pago"]);
                            oPago.FechaVencimiento = new DateTime();
                            oPago.IdPlataforma = 2;
                            oPago.IdComprobante = 0;
                            oPago.IdComprobanteTipo = 0;
                            oPago.ImporteSaldo = oPago.ImportePago;
                            oPago.Pagado = true;
                            oPago.Link = "No disponible";
                            oPago.Borrado = 0;
                            oPago.IdPago = Convert.ToInt32(item["id_registro"]);
                            oPago.Id = 0;
                            oPago.NombreUsuario = oUsuario.Apellido + ", " + oUsuario.Nombre;
                            oLista.Add(oPago);
                        }
                    }
                }
                else
                {
                    return new List<PagoExterno>();
                }
            }
            catch (Exception c)
            {
                string d = c.ToString();
                oConExterna.Desconectar();
            }
           
            return oLista;
        }

        public bool MarcarDeudaPagada(int idPagoMercadoPago, out string salida)
        {
            try
            {
                oConExterna = new ConexionesExternas();
                ConfiguracionPagos oConfPagos = new ConfiguracionPagos();

                string servidor = (string)oConfPagos.Get("servidor", (int)PagoExterno.Plataforma.MERCADOPAGO, TypeCode.String);
                string user = (string)oConfPagos.Get("usuario", (int)PagoExterno.Plataforma.MERCADOPAGO, TypeCode.String);
                string pass = (string)oConfPagos.Get("clave", (int)PagoExterno.Plataforma.MERCADOPAGO, TypeCode.String);
                string db = (string)oConfPagos.Get("base", (int)PagoExterno.Plataforma.MERCADOPAGO, TypeCode.String);
                if (Personal.Name_Login == "ADMINISTRADOR")
                    oConExterna.conexionString = "server=localhost;uid=root;pwd=root2020;database=db_avcdigital;";
                else
                    oConExterna.conexionString = $"server={servidor.ToLower()};uid={user.ToLower()};pwd={pass.ToLower()};database={db.ToLower()};";


                oConExterna.Conectar();
                oConExterna.CrearComando("UPDATE mercadopago_registros set pasado_gies = @fecha WHERE id = @idregistro");
                oConExterna.AsignarParametroFecha("@fecha", DateTime.Now);
                oConExterna.AsignarParametroEntero("@idregistro", idPagoMercadoPago);
                oConExterna.ComenzarTransaccion();
                oConExterna.EjecutarComando();
                oConExterna.ConfirmarTransaccion();
                oConExterna.Desconectar();
                salida = "";
                return true;
            }
            catch (Exception c)
            {
                oConExterna.CancelarTransaccion();
                oConExterna.Desconectar();
                salida = c.ToString();
                return false;
                throw;
            }
        }
    }
}
