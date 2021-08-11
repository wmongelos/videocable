using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using CapaDatos;

namespace CapaNegocios.PagosExternos
{
    public class PagoExterno
    {
        public int Id { get; set; }
        public int IdPago { get; set; }
        public int IdPlataforma { get; set; }
        public int IdUsuario { get; set; }
        public int CodigoUsuario { get; set; }
        public int IdUsuarioCtaCte { get; set; }
        public int IdComprobante { get; set; }
        public int IdComprobanteTipo { get; set; }
        public decimal ImporteSaldo { get; set; }
        public decimal ImportePago { get; set; }
        public DateTime FechaEmitido { get; set; }
        public DateTime FechaPago { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public bool Pagado { get; set; }
        public string ComprobanteAGenerar { get; set; }
        public string NombreUsuario { get; set; }
        public string Link { get; set; }
        //UCC USUARIO CUENTA CORRIENTE
        public string DescripcionUCC { get; set; } 
        public string NombrePlataforma { get; set; }

        public List<PagoExterno> Lista = new List<PagoExterno>();

        public int Borrado { get; set; }
        private Conexion oCon = new Conexion();

        public enum TipoBusqueda
        {
            TODO = 0,
            PAGO = 1,
            IMPAGO = 2
        }
        public enum Plataforma
        {
            CAPTARPAGOS = 1,
            MERCADOPAGO = 2,
            BAPROPAGOS = 3
        }

        public bool Guardar(PagoExterno pago)
        {
            try
            {
                DataTable dt = new DataTable();
                oCon.Conectar();
                oCon.CrearComando("select id from pagos_externos where id_pago = @pago and id_plataforma=@plataforma and borrado = 0");
                oCon.AsignarParametroEntero("@pago", pago.IdPago);
                oCon.AsignarParametroEntero("@plataforma", pago.IdPlataforma);
                dt = oCon.Tabla();
                if (dt.Rows.Count == 0)
                {
                    oCon.CrearComando("INSERT INTO pagos_externos (id_pago,id_plataforma,id_usuario,codigo_usuario,id_usuario_ctacte,importe_saldo,importe_pago,fecha_emitido,fecha_vencimiento,fecha_pago,link) " +
                        "VALUES (@idpago,@idplataforma,@idusuario,@codusuario,@idctacte,@importesaldo,@importepago,@femitido,@fvencimiento,@fpago,@url);SELECT @@IDENTITY;");
                    oCon.AsignarParametroEntero("@idpago", pago.IdPago);
                    oCon.AsignarParametroEntero("@idplataforma", pago.IdPlataforma);
                    oCon.AsignarParametroEntero("@idusuario", pago.IdUsuario);
                    oCon.AsignarParametroEntero("@codusuario", pago.CodigoUsuario);
                    oCon.AsignarParametroEntero("@idctacte", pago.IdUsuarioCtaCte);
                    oCon.AsignarParametroDecimal("@importesaldo", pago.ImporteSaldo);
                    oCon.AsignarParametroDecimal("@importepago", pago.ImportePago);
                    oCon.AsignarParametroFecha("@femitido", pago.FechaEmitido);
                    oCon.AsignarParametroFecha("@fvencimiento", pago.FechaVencimiento);
                    oCon.AsignarParametroFecha("@fpago", pago.FechaVencimiento);
                    oCon.AsignarParametroCadena("@url", pago.Link);
                    pago.Id = oCon.EjecutarScalar();
                }
                oCon.DesConectar();
                return true;
            }
            catch (Exception c)
            {
                pago.Id = -1;
                string salida = c.ToString();
                return false;
            }
        }
        public bool Guardar(List<PagoExterno> listaPagos)
        {
            try
            {
                oCon.Conectar();
                foreach (PagoExterno oPago in listaPagos)
                {
                    oCon.CrearComando("INSERT INTO pagos_externos (id_pago,id_plataforma,id_usuario,codigo_usuario,id_usuario_ctacte,importe_saldo,importe_pago,fecha_emitido,fecha_vencimiento,fecha_pago,link) " +
                        "VALUES (@idpago,@idplataforma,@idusuario,@codusuario,@idctacte,@importesaldo,@importepago,@femitido,@fvencimiento,@fpago,@url);SELECT @@IDENTITY;");
                    oCon.AsignarParametroEntero("@idpago", oPago.IdPago);
                    oCon.AsignarParametroEntero("@idplataforma", oPago.IdPlataforma);
                    oCon.AsignarParametroEntero("@idusuario", oPago.IdUsuario);
                    oCon.AsignarParametroEntero("@codusuario", oPago.CodigoUsuario);
                    oCon.AsignarParametroEntero("@idctacte", oPago.IdUsuarioCtaCte);
                    oCon.AsignarParametroDecimal("@importesaldo", oPago.ImporteSaldo);
                    oCon.AsignarParametroDecimal("@importepago", oPago.ImportePago);
                    oCon.AsignarParametroFecha("@femitido", oPago.FechaEmitido);
                    oCon.AsignarParametroFecha("@fvencimiento", oPago.FechaVencimiento);
                    oCon.AsignarParametroFecha("@fpago", oPago.FechaVencimiento);
                    oCon.AsignarParametroCadena("@url", oPago.Link);
                    oPago.Id = oCon.EjecutarScalar();
                }
                oCon.DesConectar();
                return true;
            }
            catch (Exception c)
            {
                listaPagos[0] = new PagoExterno();
                listaPagos[0].DescripcionUCC = $"Error: {c}";
                oCon.DesConectar();
                return false;
            }
        }

        public List<PagoExterno> Listar(DateTime desde, DateTime hasta,int idPlataforma=0)
        {
            List<PagoExterno> oLista = new List<PagoExterno>();
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                string consulta = "select pagos_externos.id,pagos_externos.id_pago,pagos_externos.id_usuario,pagos_externos.id_plataforma,pagos_externos.codigo_usuario,concat(usuarios.apellido, ', ',usuarios.nombre) as abonado, "
                    + " usuarios_ctacte.descripcion as factura,pagos_externos.id_usuario_ctacte, usuarios_ctacte.importe_final,pagos_externos.importe_saldo,pagos_externos.importe_pago,pagos_externos.fecha_emitido,pagos_externos.fecha_pago,pagos_externos.fecha_vencimiento,usuarios_ctacte.importe_saldo as importe_saldo_ctacte,pagos_externos.link,plataformas_pagos.nombre as Plataforma"
                    + " from pagos_externos "
                    + " LEFT JOIN usuarios on usuarios.id=pagos_externos.id_usuario"
                    + " LEFT JOIN usuarios_ctacte on usuarios_ctacte.id=pagos_externos.id_usuario_ctacte"
                    + " LEFT JOIN plataformas_pagos on plataformas_pagos.id = pagos_externos.id_plataforma"
                    + " WHERE date(pagos_externos.fecha_emitido) between date(@desde) and date(@hasta) and pagos_externos.id_comprobante_generado = 0 and pagos_externos.importe_pago > 0 ";
                if (idPlataforma == 0)
                    consulta = consulta + " and pagos_externos.id_plataforma > 0 ";
                else
                    consulta = consulta + $" and pagos_externos.id_plataforma = {idPlataforma}";
                oCon.CrearComando(consulta);
                oCon.AsignarParametroFecha("@desde", desde);
                oCon.AsignarParametroFecha("@hasta", hasta);
                dt = oCon.Tabla();
                oCon.DesConectar();
                if (dt.Rows.Count > 0)
                {
                    PagoExterno oPago = new PagoExterno();
                    foreach (DataRow item in dt.Rows)
                    {
                        oPago = new PagoExterno();
                        oPago.Id = Convert.ToInt32(item["id"]);
                        oPago.IdPago = Convert.ToInt32(item["id_pago"]);
                        oPago.IdUsuario = Convert.ToInt32(item["id_usuario"]);
                        oPago.CodigoUsuario = Convert.ToInt32(item["codigo_usuario"]);
                        oPago.NombreUsuario = item["abonado"].ToString();
                        oPago.IdPlataforma = Convert.ToInt32(item["id_plataforma"]);
                        oPago.IdUsuarioCtaCte = Convert.ToInt32(item["id_usuario_ctacte"]);
                        oPago.DescripcionUCC = item["factura"].ToString();
                        oPago.FechaEmitido = Convert.ToDateTime(item["fecha_emitido"]);
                        oPago.FechaPago = Convert.ToDateTime(item["fecha_pago"]);
                        oPago.FechaVencimiento = Convert.ToDateTime(item["fecha_vencimiento"]);
                        oPago.ImportePago = Convert.ToDecimal(item["importe_pago"]);
                        oPago.ImporteSaldo = Convert.ToDecimal(item["importe_saldo"]);
                        oPago.Pagado = !Convert.ToBoolean(item["importe_saldo_ctacte"]);
                        oPago.NombrePlataforma = item["plataforma"].ToString();
                        oPago.Link = item["link"].ToString();

                        Usuarios_CtaCte oCtaCte = new Usuarios_CtaCte();
                        oCtaCte = oCtaCte.Get(oPago.IdUsuarioCtaCte);
                        int cuenta = 1;
                        if(oCtaCte.UsuCtaCteDet != null && oCtaCte.UsuCtaCteDet.Count > 0)
                        {
                            var detConTipoS = oCtaCte.UsuCtaCteDet.Where(x => x.Tipo == "S").ToList();
                            if(detConTipoS.Count > 0)
                            {
                                foreach (var det in detConTipoS)
                                {
                                    int idSer = det.Id_Servicios;
                                    DataTable dtCopiaServicios = Tablas.DataServicios.Copy();
                                    DataView dv = dtCopiaServicios.DefaultView;
                                    dv.RowFilter = $"id = {idSer}";
                                    DataTable dtaux = dv.ToTable();
                                    if (Convert.ToInt32(dtaux.Rows[0]["cuenta"]) == 2)
                                        cuenta = 2;
                                }
                            }
                        }


                        if (oPago.ImportePago == 0)
                            oPago.ComprobanteAGenerar = "";
                        else if (oPago.Pagado)
                            oPago.ComprobanteAGenerar = "RECIBO Y CREDITO A CUENTA";
                        else
                        {
                            if(cuenta==1)
                                oPago.ComprobanteAGenerar = "RECIBO";
                            else
                                oPago.ComprobanteAGenerar = "RECIBO X";

                        }
                        oLista.Add(oPago);
                    }
                }
            }
            catch (Exception c)
            {
                oCon.DesConectar();
            }
            return oLista;
        }

        public bool ActualizarPago(double idPago, int idPlataforma,decimal importe, DateTime fecha)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("update pagos_Externos set importe_pago=@nuevo where id_pago=@pago, id_plataforma=@plataforma, fecha_pago=@fecha");
                oCon.AsignarParametroDecimal("@nuevo", importe);
                oCon.AsignarParametroDouble("@pago", idPago);
                oCon.AsignarParametroEntero("@plataforma", idPlataforma);
                oCon.AsignarParametroFecha("@fecha",fecha);
                oCon.EjecutarComando();
                oCon.DesConectar();
                return true;
            }
            catch (Exception)
            {
                oCon.DesConectar();
                return false;
            }
        }

        public bool ActualizarPago(List<PagoExterno> listaIdPago, int idPlataforma)
        {
            try
            {
                oCon.Conectar();
                foreach (PagoExterno pago in listaIdPago)
                {
                    oCon.CrearComando("update pagos_Externos set importe_pago=@nuevo,fecha_pago = fechapago where id_pago=@pago and id_plataforma=@plataforma");
                    oCon.AsignarParametroDecimal("@nuevo", pago.ImportePago);
                    oCon.AsignarParametroFecha("@fechapago", pago.FechaPago);
                    oCon.AsignarParametroDouble("@pago", pago.Id);
                    oCon.AsignarParametroEntero("@plataforma", idPlataforma);
                    oCon.EjecutarComando();

                }
                oCon.DesConectar();
                return true;
            }
            catch (Exception)
            {
                oCon.DesConectar();
                return false;
            }
        }

        public bool AsignarComprobante(List<PagoExterno> listaPagos)
        {
            try
            {
                oCon.Conectar();
                foreach (PagoExterno item in listaPagos)
                {
                    oCon.CrearComando("update pagos_Externos set id_tipo_comprobante=@tipo, id_comprobante_generado=@compro where id=@idpago");
                    oCon.AsignarParametroDecimal("@compro", item.IdComprobante);
                    oCon.AsignarParametroDecimal("@tipo", item.IdComprobanteTipo);
                    oCon.AsignarParametroDouble("@idpago", item.Id);
                    oCon.EjecutarComando();
                }

                oCon.DesConectar();
                return true;
            }
            catch (Exception c)
            {
                string salida = c.ToString();
                oCon.DesConectar();
                return false;
            }
        }

    }
}
