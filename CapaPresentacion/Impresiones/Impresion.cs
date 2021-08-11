using CapaNegocios;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Diagnostics;
using QRCoder;
using System.Linq;

namespace CapaPresentacion.Impresiones
{
    public class Impresion
    {

        private Configuracion oConfig = new Configuracion();
        private dsInformes oDs = new dsInformes();
        private Facturacion Ofacturacion = new Facturacion();
        private Usuarios_CtaCte_Recibos Ousuarios_CtaCte_Recibos = new Usuarios_CtaCte_Recibos();
        private Usuarios_Dom_Fiscal oUsuariosDomFiscal = new Usuarios_Dom_Fiscal();
        private Caja_general ocaja_general = new Caja_general();
        private Formas_de_pago OFormasDePago = new Formas_de_pago();
        private Partes oParte = new Partes();
        public Int32 Punto;
        public Int32 Numero;
        public String NumeroMuestra;
        public DateTime Fecha;
        private DataRow Dtr, DrDatosParte;
        private Articulos_Mov oArtMov = new Articulos_Mov();
        private Articulos_Mov_Det oArtMovDet = new Articulos_Mov_Det();
        private const string AfipUrl = @"https://www.afip.gob.ar/fe/qr/";


        private static List<Stream> m_streams;
        private static int m_currentPageIndex = 0;

        public enum MEDIDAS_HOJAS
        {
            A4 = 1
        }

        public DataRow DatosDeLaEmpresa(int id_comprobante_tipo = 0)
        {
            DataRow Dtr;
            Dtr = oDs.Tables["Empresa"].NewRow();
            Dtr["emp_fantasia"] = oConfig.GetValor_C("Empresa").Trim();
            Dtr["emp_direccion"] = oConfig.GetValor_C("Direccion").Trim();
            Dtr["emp_correo"] = oConfig.GetValor_C("Correo").Trim();
            Dtr["emp_condicion_iva"] = oConfig.GetValor_C("Condicion_Iva").Trim();
            Dtr["emp_cuit"] = oConfig.GetValor_C("Cuit").Trim();
            Dtr["emp_Ingresos_Brutos"] = oConfig.GetValor_C("Ingresos_Brutos").Trim();
            Dtr["emp_Municipal"] = oConfig.GetValor_C("Hab_Municipal").Trim();
            Dtr["emp_Inicio_Actividades"] = oConfig.GetValor_C("Inicio_Actividades").Trim();
            Dtr["emp_localidad"] = oConfig.GetValor_C("localidad").Trim();
            Dtr["emp_provincia"] = oConfig.GetValor_C("provincia").Trim();
            Dtr["emp_razon_social"] = oConfig.GetValor_C("Razon_Social").Trim();
            Dtr["emp_telefono"] = oConfig.GetValor_C("Telefono").Trim();
            if (id_comprobante_tipo != 0)
            {
                DataTable dtDetallesComp = new Comprobantes_Detalle_Impresion().Listar(id_comprobante_tipo);
                if (dtDetallesComp.Rows.Count > 0)
                {
                    Dtr["Emp_Descripcion1"] = dtDetallesComp.Rows[0]["detalle1"].ToString();
                    Dtr["Emp_Descripcion2"] = dtDetallesComp.Rows[0]["detalle2"].ToString();
                }
            }
            oDs.Tables["Empresa"].Rows.Add(Dtr);
            return Dtr;
        }
        public DataRow DatosUsuarioServicio(int idUsuLocacion)
        {
            Usuarios_Servicios oUsuServ = new Usuarios_Servicios();
            DataTable dtServ = oUsuServ.ListarServiciosUsuario(Usuarios.CurrentUsuario.Id, idUsuLocacion);
            DataRow Dtr;
            string velocidad = "";
            int cantBocas = 0;
            try
            {
                foreach (DataRow row in dtServ.Rows)
                {
                    if(Convert.ToInt32(row["id_servicios_velocidades"]) >0) //internet
                    {
                        velocidad = row["Velocidad"].ToString() + " MEGAS";
                        cantBocas = Convert.ToInt32(row["cant_bocas_pac"]);

                    }
                }
            }
            catch {}

            Dtr = oDs.Tables["UsuarioServicio"].NewRow();
            Dtr["US_Velocidad"] = velocidad;
            Dtr["US_Servicio"] = "Internet mensual";
            Dtr["US_cantidadbocas"] = cantBocas;
            oDs.Tables["UsuarioServicio"].Rows.Add(Dtr);
            return Dtr;
        }

        public DataRow DatosDelUsuario()
        {
            DataRow Dtr;
            Dtr = oDs.Tables["Usuarios"].NewRow();
            Dtr["Usu_apellido"] = Usuarios.CurrentUsuario.Apellido.ToString().Trim() + ", " + Usuarios.CurrentUsuario.Nombre.ToString().Trim() + "  [Abonado N° " + Usuarios.CurrentUsuario.Codigo + "]";
            Dtr["Usu_nombre"] = Usuarios.CurrentUsuario.Apellido.ToString().Trim();
            Dtr["Usu_localidad"] = Usuarios.CurrentUsuario.localidad != null ? Usuarios.CurrentUsuario.localidad.ToString().Trim() + " (" + Usuarios.CurrentUsuario.Cod_postal.ToString().Trim() + ")" : Usuarios.CurrentUsuarioDomFiscal.Localidad;
            Dtr["Usu_calle"] = Usuarios.CurrentUsuario.Calle.Trim() + " NRO -" + Usuarios.CurrentUsuario.Altura.ToString().Trim() + "(" + Usuarios.CurrentUsuario.piso.Trim() + " " + Usuarios.CurrentUsuario.Depto.Trim() + ")";

            Dtr["Usu_altura"] = Usuarios.CurrentUsuario.Altura;

            Dtr["Usu_piso"] = Usuarios.CurrentUsuario.piso;///  .Trim()+" Nro :"+Usuarios.CurrentUsuario.Altura.ToString();
            Dtr["Usu_depto"] = Usuarios.CurrentUsuario.Depto;
            Dtr["Usu_condicion_iva"] = Usuarios.CurrentUsuario.Condicion_Iva;
            Dtr["Usu_entre_calle"] = Usuarios.CurrentUsuario.Entre1 != null ? Usuarios.CurrentUsuario.Entre1.Trim() + " / " + Usuarios.CurrentUsuario.Entre2.Trim() : "";
            Dtr["Usu_y_calle"] = Usuarios.CurrentUsuario.Entre2 != null ? Usuarios.CurrentUsuario.Entre2 : "";

            Usuarios.CurrentUsuarioDomFiscal = oUsuariosDomFiscal.LlenarDatosLocFiscal(Usuarios.CurrentUsuario.Id_Usuarios_Locacion);
            Dtr["Usu_condicion_iva"] = Usuarios.CurrentUsuarioDomFiscal.CondicionIva;
            Dtr["Usu_calle_fISCAL"] = String.Format("{0} {1} {2} {3}", Usuarios.CurrentUsuarioDomFiscal.Calle, Usuarios.CurrentUsuarioDomFiscal.Altura, Usuarios.CurrentUsuarioDomFiscal.Piso, Usuarios.CurrentUsuarioDomFiscal.Depto);
            Dtr["usu_localidad_fiscal"] = Usuarios.CurrentUsuarioDomFiscal.Localidad;
            Dtr["usu_razon_social"] = Usuarios.CurrentUsuarioDomFiscal.R_Social;
            Dtr["Usu_dni_numero"] = Usuarios.CurrentUsuarioDomFiscal.Cuit;


            oDs.Tables["Usuarios"].Rows.Add(Dtr);
            return Dtr;
        }

        public DataRow DatosDelUsuarioPorId(int IdUsuario)
        {
            DataRow Dtr;
            DataTable DtDatosUsuario = new DataTable();
            DataTable DtDatosFiscal = new DataTable();
            Usuarios oUsuario = new Usuarios();
            Usuarios_Dom_Fiscal oUsuarios_Dom_Fiscal = new Usuarios_Dom_Fiscal();
            oUsuario = oUsuario.traerUsuario(IdUsuario);
            DtDatosFiscal = oUsuarios_Dom_Fiscal.Listar(IdUsuario);
            Dtr = oDs.Tables["Usuarios"].NewRow();
            Dtr["Usu_codigo"] = oUsuario.Codigo.ToString();
            Dtr["Usu_apellido"] = $"{oUsuario.Apellido} [Abonado N° {oUsuario.Codigo}]";
            Dtr["Usu_nombre"] = oUsuario.Nombre;
            Dtr["Usu_localidad"] = oUsuario.localidad;
            Dtr["Usu_calle"] = oUsuario.Calle;
            Dtr["Usu_altura"] = oUsuario.Altura;
            Dtr["Usu_piso"] = oUsuario.piso;
            Dtr["Usu_depto"] = oUsuario.Depto;
            Dtr["Usu_condicion_iva"] = oUsuario.Condicion_Iva;
            Dtr["Usu_dni_numero"] = oUsuario.Numero_Documento;
            Dtr["Usu_entre_calle"] = oUsuario.Entre1;
            Dtr["Usu_y_calle"] = oUsuario.Entre2;
            Dtr["Usu_correo"] = oUsuario.Correo_Electronico;
            Dtr["Usu_telefono_1"] = oUsuario.Telefono_1;
            Dtr["Usu_nacimiento"] = oUsuario.Nacimiento.ToShortDateString();
            Dtr["Usu_TipoDoc"] = oUsuario.Tipo_Documento;
            Dtr["Usu_CUIT"] = oUsuario.CUIT;
            if (DtDatosFiscal.Rows.Count > 0)
            {
                Dtr["Usu_razon_social"] = DtDatosFiscal.Rows[0]["R_social"];
                Dtr["Usu_calle_fiscal"] = String.Format("{0} {1}", DtDatosFiscal.Rows[0]["calle"], DtDatosFiscal.Rows[0]["altura"]);
                Dtr["Usu_localidad_fiscal"] = DtDatosFiscal.Rows[0]["localidad"];
                Dtr["Usu_Condicion_Iva"] = DtDatosFiscal.Rows[0]["condicion_iva"];
            }
            oDs.Tables["Usuarios"].Rows.Add(Dtr);
            return Dtr;
        }


        public DataRow DatosDelParte(int IdParte)
        {
            DrDatosParte = oParte.TraerParteRow(IdParte);
            Dtr = oDs.Tables["PartesDeTrabajo"].NewRow();
            Dtr["Numero"] = DrDatosParte["id"];
            Dtr["Estado"] = DrDatosParte["estado"];
            Dtr["Locacion"] = String.Format("{0}, {1} {2}", DrDatosParte["localidad"], DrDatosParte["calle"], DrDatosParte["altura"]);
            Dtr["Tecnico"] = DrDatosParte["Tecnico"];
            Dtr["FechaReclamo"] = DrDatosParte["fecha_reclamo"];
            Dtr["FechaProgramacion"] = DrDatosParte["fecha_programado"];
            Dtr["FechaRealizacion"] = DrDatosParte["fecha_realizado"];
            Dtr["ParteOperacion"] = DrDatosParte["operacion"];
            Dtr["Area"] = DrDatosParte["area"];
            Dtr["Solicitud"] = DrDatosParte["solicitud"] + " " + DrDatosParte["detalle_falla"];
            Dtr["Operador"] = DrDatosParte["operador"];
            Dtr["solucion"] = DrDatosParte["solucion"];
            Dtr["id_usuarios"] = DrDatosParte["id_usuarios"];

            Dtr["id_locacion"] = DrDatosParte["id_locacion_anterior"];
            if(Convert.ToInt32(Dtr["id_locacion"])==0)
                Dtr["id_locacion"] = DrDatosParte["id_usuarios_locaciones"];
            Dtr["id_operacion"] = DrDatosParte["id_partes_operaciones"];
            Dtr["id_locacion_destino"] = DrDatosParte["id_usuarios_locaciones"];

            oDs.Tables["PartesDeTrabajo"].Rows.Add(Dtr);

            if (Convert.ToInt32(DrDatosParte["Id_Locacion_Anterior"]) > 0)
                DatosDeLocacionDestino(Convert.ToInt32(DrDatosParte["id_usuarios_locaciones"]));


            return Dtr;
        }

        private DataRow DatosImpresion(int IdPuntoCobro, int IdTipoComp)
        {
            IdTipoComp = IdTipoComp == 13 ? 1 : IdTipoComp == 14 ? 2 : IdTipoComp;

            DataRow[] dataFilter = Tablas.DataImpresiones.Select(String.Format("id_puntos_cobros = {0} and id_comprobantes_tipo = {1} and id_personal = {2}", IdPuntoCobro, IdTipoComp, Personal.Id_Login));

            if (dataFilter.Length == 0 || String.IsNullOrEmpty(dataFilter[0]["id"].ToString()))
            {
                throw new ExcepcionImpresoraNoEncontrada("No esta configurada una impresora para el usuario logeado");
            }

            return dataFilter[0];
        }

        public void ServiciosDelUsuario(int IdUsuario)
        {
            DataRow Dtr;
            DataTable DtServiciosAsociados = new DataTable();
            Usuarios_Servicios oUsuarioServicio = new Usuarios_Servicios();
            DtServiciosAsociados = oUsuarioServicio.Listar_activos(IdUsuario);
            foreach (DataRow dr in DtServiciosAsociados.Rows)
            {
                Dtr = oDs.Tables["ServiciosDelUsuario"].NewRow();
                Dtr["Numero"] = dr["id"];
                Dtr["Nombre"] = dr["servicio"];
                Dtr["Tipo"] = dr["tiposervicio"];
                Dtr["Estado"] = dr["estado"];
                Dtr["locacion"] = String.Format("{0}, {1} {2}", dr["localidad"], dr["calle"], dr["altura"]);
                oDs.Tables["ServiciosDelUsuario"].Rows.Add(Dtr);
            }

        }

        public void ServiciosDelParte(int IdParte)
        {

            DataTable DtServiciosDelParte = new DataTable();
            Partes_Usuarios_Servicios oParteUsuarioServicio = new Partes_Usuarios_Servicios();
            DtServiciosDelParte = oParteUsuarioServicio.ListarServiciosPorParte(IdParte, Partes_Usuarios_Servicios.CONDICION_REQ_EQUIPOS.TODOS);

            if (DtServiciosDelParte.Rows.Count == 0)
            {
                DataRow Dtr = oDs.Tables["ServiciosDelParte"].NewRow();

                Dtr["Numero"] = IdParte;
                Dtr["Tipo"] = DrDatosParte["servicio_tipo"];
                oDs.Tables["ServiciosDelParte"].Rows.Add(Dtr);
                oDs.Tables["ServiciosDelParte"].AcceptChanges();
            }
            else
            {
                foreach (DataRow dr in DtServiciosDelParte.Rows)
                {
                    DataRow Dtr = oDs.Tables["ServiciosDelParte"].NewRow();

                    Dtr["Numero"] = dr["id_parte"];
                    Dtr["Nombre"] = dr["servicio"];
                    Dtr["Tipo"] = dr["tiposervicio"]; ;
                    Dtr["Estado"] = dr["estado"];
                    Dtr["locacion"] = String.Format("{0}, {1} {2}", dr["localidad"], dr["calle"], dr["altura"]);
                    oDs.Tables["ServiciosDelParte"].Rows.Add(Dtr);
                    oDs.Tables["ServiciosDelParte"].AcceptChanges();
                }
            }




        }

        private String ObservacionesParte = "";
        private void ObservacionDelParte(int IdParte)
        {
            this.ObservacionesParte = "";

            Parte_Observacion partesObs = new Parte_Observacion();

            DataTable dt = partesObs.Listar(IdParte);

            foreach (DataRow dr in dt.Rows)
                ObservacionesParte += dr["observacion"].ToString();
        }

        public void DatosDeLocacion(int idLocacion)
        {
            DataRow Dtr;
            Usuarios_Locaciones oUsuariosLocaciones = new Usuarios_Locaciones();
            oUsuariosLocaciones = oUsuariosLocaciones.GetLocacion(idLocacion);
            Dtr = oDs.Tables["UsuarioLocacion"].NewRow();
            Dtr["Id"] = oUsuariosLocaciones.Id;
            Dtr["Calle"] = oUsuariosLocaciones.Calle;
            Dtr["Altura"] = oUsuariosLocaciones.Altura;
            Dtr["Piso"] = oUsuariosLocaciones.Piso;
            Dtr["Depto"] = oUsuariosLocaciones.Depto;
            Dtr["Depto"] = oUsuariosLocaciones.Depto;
            Dtr["limiteCalle1"] = oUsuariosLocaciones.Entre_Calle_1;
            Dtr["limiteCalle2"] = oUsuariosLocaciones.Entre_Calle_2;
            Dtr["telefono1"] = String.Format("{0} {1}", oUsuariosLocaciones.Prefijo_1, oUsuariosLocaciones.Telefono_1);
            Dtr["telefono2"] = String.Format("{0} {1}", oUsuariosLocaciones.Prefijo_2, oUsuariosLocaciones.Telefono_2);
            Dtr["Localidad"] = oUsuariosLocaciones.Localidad;
            Dtr["Observaciones"] = String.Format("{0 } {1}", oUsuariosLocaciones.Observacion, ObservacionesParte);
            Dtr["Manzana"] = oUsuariosLocaciones.Manzana;
            Dtr["Parcela"] = oUsuariosLocaciones.Parcela;
            Dtr["postal"] = oUsuariosLocaciones.Codigo_Postal;
            oDs.Tables["UsuarioLocacion"].Rows.Add(Dtr);
            oDs.Tables["UsuarioLocacion"].AcceptChanges();
        }

        public void DatosDeLocacionDestino(int idLocacion)
        {
            DataRow Dtr;
            Usuarios_Locaciones oUsuariosLocaciones = new Usuarios_Locaciones();
            oUsuariosLocaciones = oUsuariosLocaciones.GetLocacion(idLocacion);
            Dtr = oDs.Tables["UsuarioLocacionDestino"].NewRow();
            Dtr["Id"] = oUsuariosLocaciones.Id;
            Dtr["Calle"] = oUsuariosLocaciones.Calle;
            Dtr["Altura"] = oUsuariosLocaciones.Altura;
            Dtr["Piso"] = oUsuariosLocaciones.Piso;
            Dtr["Depto"] = oUsuariosLocaciones.Depto;
            Dtr["limiteCalle1"] = oUsuariosLocaciones.Entre_Calle_1;
            Dtr["limiteCalle2"] = oUsuariosLocaciones.Entre_Calle_2;
            Dtr["telefono1"] = String.Format("{0} {1}", oUsuariosLocaciones.Prefijo_1, oUsuariosLocaciones.Telefono_1);
            Dtr["telefono2"] = String.Format("{0} {1}", oUsuariosLocaciones.Prefijo_2, oUsuariosLocaciones.Telefono_2);
            Dtr["Localidad"] = oUsuariosLocaciones.Localidad;
            Dtr["Observaciones"] = oUsuariosLocaciones.Observacion;
            Dtr["Manzana"] = oUsuariosLocaciones.Manzana;
            Dtr["Parcela"] = oUsuariosLocaciones.Parcela;
            oDs.Tables["UsuarioLocacionDestino"].Rows.Add(Dtr);
            oDs.Tables["UsuarioLocacionDestino"].AcceptChanges();
        }

        public void EquiposDelParte(int IdParte, bool equiposDelUsuario)
        {
            DataRow Dtr;

            DataTable DtEquiposDelParte = new DataTable();
            DataTable dtServiciosDelParte = new DataTable();
            Partes_Usuarios_Servicios oPartesServicios = new Partes_Usuarios_Servicios();
            Partes_Equipos oPartesEquipos = new Partes_Equipos();
            Equipos oEquipos = new Equipos();
            int idUsuario = 0;
            int idLocacion = 0;
            if (equiposDelUsuario)
            {
                List<Int32> usuariosServicio = new List<Int32>();
                dtServiciosDelParte = oPartesServicios.ListarServiciosPorParte(IdParte, Partes_Usuarios_Servicios.CONDICION_REQ_EQUIPOS.TODOS);
                if (dtServiciosDelParte.Rows.Count > 0)
                {
                    idUsuario = Convert.ToInt32(dtServiciosDelParte.Rows[0]["id_usuarios"]);
                    idLocacion = Convert.ToInt32(dtServiciosDelParte.Rows[0]["id_usuarios_locaciones"]);
                    DtEquiposDelParte = oEquipos.ListarEquipoPorUsuarioYLocacion(idUsuario, idLocacion);
                    foreach (DataRow item in dtServiciosDelParte.Rows)
                    {
                        if (!usuariosServicio.Contains(Convert.ToInt32(item["id_usuarios_servicios"])))
                        {
                            usuariosServicio.Add(Convert.ToInt32(item["id_usuarios_servicios"]));
                            if (DtEquiposDelParte.Rows.Count > 0)
                            {
                                foreach (DataRow dr in DtEquiposDelParte.Rows)
                                {
                                    Dtr = oDs.Tables["EquiposDelParte"].NewRow();
                                    Dtr["serie"] = dr["serie"];
                                    Dtr["mac"] = dr["mac"];
                                    Dtr["tipoequipo"] = dr["tipoequipo"];
                                    Dtr["servicio"] = dr["servicio"];
                                    oDs.Tables["EquiposDelParte"].Rows.Add(Dtr);
                                }
                            }
                        }
                    }
                }
                
            }
            else
            {

                DtEquiposDelParte = oPartesEquipos.ListarPorParte(IdParte);
                foreach (DataRow dr in DtEquiposDelParte.Rows)
                {
                    Dtr = oDs.Tables["EquiposDelParte"].NewRow();
                    Dtr["serie"] = dr["serie"];
                    Dtr["mac"] = dr["mac"];
                    Dtr["tipoequipo"] = dr["tipo_equipo"];
                    Dtr["servicio"] = dr["servicio"];
                    oDs.Tables["EquiposDelParte"].Rows.Add(Dtr);
                }
            }

        }
        private void ControlRegistrosVacios()
        {
            for (int x = 0; x < oDs.Tables["PartesDeTrabajo"].Columns.Count; x++)
            {
                if (String.IsNullOrEmpty(oDs.Tables["PartesDeTrabajo"].Rows[0][x].ToString()))
                    oDs.Tables["PartesDeTrabajo"].Rows[0][x] = "------";
            }

            for (int x = 0; x < oDs.Tables["empresa"].Columns.Count; x++)
            {
                if (String.IsNullOrEmpty(oDs.Tables["empresa"].Rows[0][x].ToString()))
                    oDs.Tables["empresa"].Rows[0][x] = "------";
            }

            for (int x = 0; x < oDs.Tables["Usuarios"].Columns.Count; x++)
            {
                if (String.IsNullOrEmpty(oDs.Tables["Usuarios"].Rows[0][x].ToString()))
                    oDs.Tables["Usuarios"].Rows[0][x] = "------";
            }

            for (int x = 0; x < oDs.Tables["ServiciosDelUsuario"].Rows.Count; x++)
            {
                for (int y = 0; y < oDs.Tables["ServiciosDelUsuario"].Columns.Count; y++)
                {
                    if (String.IsNullOrEmpty(oDs.Tables["ServiciosDelUsuario"].Rows[x][y].ToString()))
                        oDs.Tables["ServiciosDelUsuario"].Rows[x][y] = "------";
                }
            }

            for (int x = 0; x < oDs.Tables["ServiciosDelParte"].Rows.Count; x++)
            {
                for (int y = 0; y < oDs.Tables["ServiciosDelParte"].Columns.Count; y++)
                {
                    if (String.IsNullOrEmpty(oDs.Tables["ServiciosDelParte"].Rows[x][y].ToString()))
                        oDs.Tables["ServiciosDelParte"].Rows[x][y] = "------";
                }
            }

            for (int x = 0; x < oDs.Tables["EquiposDelParte"].Rows.Count; x++)
            {
                for (int y = 0; y < oDs.Tables["EquiposDelParte"].Columns.Count; y++)
                {
                    if (String.IsNullOrEmpty(oDs.Tables["EquiposDelParte"].Rows[x][y].ToString()))
                        oDs.Tables["EquiposDelParte"].Rows[x][y] = "------";
                }
            }
        }

        public void DatosDebitos(int idParte, string fechaBaja, string fechaReclamo)
        {
            DataTable dtServiciosBaja = new DataTable();
            DataTable dtDatosDebito = new DataTable();
            DataRow Dtr;
            Plasticos oPlasticos = new Plasticos();
            dtServiciosBaja = oPlasticos.ListarServiciosParaBaja(idParte);
            if (dtServiciosBaja.Rows.Count > 0)
            {
                dtDatosDebito = oPlasticos.Listar("0", 0, Convert.ToInt32(dtServiciosBaja.Rows[0]["id_plastico"]));

                Dtr = oDs.Tables["BajaDebitos"].NewRow();
                Dtr["titular"] = dtDatosDebito.Rows[0]["titular"].ToString();
                Dtr["nrotarjeta"] = dtDatosDebito.Rows[0]["numero"].ToString();
                Dtr["formadepago"] = dtDatosDebito.Rows[0]["formapago"].ToString();
                Dtr["fechabaja"] = fechaBaja;
                Dtr["fechareclamo"] = fechaReclamo;
                oDs.Tables["BajaDebitos"].Rows.Add(Dtr);
                oDs.Tables["BajaDebitos"].AcceptChanges();


                foreach (DataRow fila in dtServiciosBaja.Rows)
                {
                    Dtr = oDs.Tables["BajaDebitosServicios"].NewRow();
                    Dtr["servicio"] = fila["servicio"].ToString();
                    Dtr["usuario"] = fila["usuario"].ToString();
                    Dtr["tipodeservicio"] = fila["servicio_tipo"].ToString();
                    oDs.Tables["BajaDebitosServicios"].Rows.Add(Dtr);
                    oDs.Tables["BajaDebitosServicios"].AcceptChanges();
                }
            }
        }

        public void ImprimirParte(int IdParte, string Impresora = "")
        {
            Configuracion oConfig = new Configuracion();

            //if (oConfig.GetValor_N("Factura_Electronica") == 1)
            //    return;

            try
            {
                Partes oPartes = new Partes();
                oPartes.Impreso(IdParte);

                PaperSize oPS = new PaperSize();
                oPS.RawKind = (int)PaperKind.A4;
                PaperSource oPSource = new PaperSource();
                oPSource.RawKind = 1;

                oDs.Clear();
                oDs.Tables["PartesDeTrabajo"].Clear();
                if (oDs.Tables["PartesDeTrabajo"].Rows.Count == 0)
                    DatosDelParte(IdParte);

                if (oDs.Tables["empresa"].Rows.Count == 0)
                    DatosDeLaEmpresa();

                oDs.Tables["Usuarios"].Clear();
                if(Convert.ToInt32(oDs.Tables["PartesDeTrabajo"].Rows[0]["id_usuarios"]) > 0) 
                { 
                    if (oDs.Tables["Usuarios"].Rows.Count == 0)
                        DatosDelUsuarioPorId(Convert.ToInt32(oDs.Tables["PartesDeTrabajo"].Rows[0]["id_usuarios"]));
                }

                oDs.Tables["ServiciosDelUsuario"].Clear();
                if (Convert.ToInt32(oDs.Tables["PartesDeTrabajo"].Rows[0]["id_usuarios"]) > 0)
                {
                    if (oDs.Tables["ServiciosDelUsuario"].Rows.Count == 0)
                        ServiciosDelUsuario(Convert.ToInt32(oDs.Tables["PartesDeTrabajo"].Rows[0]["id_usuarios"]));
                }

                oDs.Tables["ServiciosDelParte"].Clear();
                if (oDs.Tables["ServiciosDelParte"].Rows.Count == 0)
                    ServiciosDelParte(IdParte);

                oDs.Tables["EquiposDelParte"].Clear();
                if (oDs.Tables["EquiposDelParte"].Rows.Count == 0)
                {
                    if(Convert.ToInt32(oDs.Tables["PartesDeTrabajo"].Rows[0]["id_operacion"])==(int)Partes.Partes_Operaciones.CAMBIO_DE_EQUIPO)
                        EquiposDelParte(IdParte,false);
                    else
                        EquiposDelParte(IdParte, true);

                }

                oDs.Tables["UsuarioLocacion"].Clear();
                if(Convert.ToInt32(oDs.Tables["PartesDeTrabajo"].Rows[0]["id_locacion"]) > 0)
                { 
                    if (oDs.Tables["UsuarioLocacion"].Rows.Count == 0)
                    { 
                        ObservacionDelParte(IdParte); 
                        DatosDeLocacion(Convert.ToInt32(oDs.Tables["PartesDeTrabajo"].Rows[0]["id_locacion"])); 
                    }
                    ControlRegistrosVacios();
                }

                if (oDs.Tables["PartesDeTrabajo"].Rows[0]["ParteOperacion"].ToString() == "CAMBIO DE DOMICILIO")
                {
                    InformeCambioDomicilio rpt = new InformeCambioDomicilio();
                    rpt.SetDataSource(oDs);
                    rpt.SetParameterValue("calle_origen", oDs.Tables["UsuarioLocacion"].Rows[0]["calle"]);
                    rpt.SetParameterValue("altura_origen", oDs.Tables["UsuarioLocacion"].Rows[0]["altura"]);
                    rpt.SetParameterValue("piso_origen", oDs.Tables["UsuarioLocacion"].Rows[0]["piso"]);
                    rpt.SetParameterValue("depto_origen", oDs.Tables["UsuarioLocacion"].Rows[0]["depto"]);
                    rpt.SetParameterValue("entre_origen", oDs.Tables["UsuarioLocacion"].Rows[0]["limitecalle1"]);
                    rpt.SetParameterValue("entre_y_origen", oDs.Tables["UsuarioLocacion"].Rows[0]["limitecalle2"]);
                    rpt.SetParameterValue("localidad_origen", oDs.Tables["UsuarioLocacion"].Rows[0]["localidad"]);

                    rpt.SetParameterValue("calle_destino", oDs.Tables["UsuarioLocacionDestino"].Rows[0]["calle"]);
                    rpt.SetParameterValue("altura_destino", oDs.Tables["UsuarioLocacionDestino"].Rows[0]["altura"]);
                    rpt.SetParameterValue("piso_destino", oDs.Tables["UsuarioLocacionDestino"].Rows[0]["piso"]);
                    rpt.SetParameterValue("depto_destino", oDs.Tables["UsuarioLocacionDestino"].Rows[0]["depto"]);
                    rpt.SetParameterValue("entre_destino", oDs.Tables["UsuarioLocacionDestino"].Rows[0]["limitecalle1"]);
                    rpt.SetParameterValue("entre_y_destino", oDs.Tables["UsuarioLocacionDestino"].Rows[0]["limitecalle2"]);
                    rpt.SetParameterValue("localidad_destino", oDs.Tables["UsuarioLocacionDestino"].Rows[0]["localidad"]);
                    rpt.SetParameterValue("codigo", oDs.Tables["Usuarios"].Rows[0]["usu_codigo"]);


                    if (Impresora == "")
                    {
                        frmReportViewer frm = new frmReportViewer();
                        frm.oViewer.ReportSource = null;
                        frm.oViewer.ReportSource = rpt;
                        frm.ShowDialog();
                        rpt.Close();
                        rpt.Dispose();
                        frm.oViewer.Dispose();
                    }
                    else
                    {
                        PrinterSettings ps = new PrinterSettings();
                        ps.DefaultPageSettings.PaperSize = oPS;
                        ps.DefaultPageSettings.PaperSource = oPSource;
                        rpt.PrintToPrinter(ps, ps.DefaultPageSettings, false);
                    }

                }
                else if (oDs.Tables["PartesDeTrabajo"].Rows[0]["ParteOperacion"].ToString() == "BAJA DE DÉBITO")
                {
                    oDs.Tables["BajaDebitos"].Clear();


                    if (oDs.Tables["BajaDebitos"].Rows.Count == 0)
                    {
                        oDs.Tables["Usuarios"].Clear();
                        DatosDelUsuario();
                        DatosDebitos(IdParte, oDs.Tables["PartesDeTrabajo"].Rows[0]["FechaProgramacion"].ToString(), oDs.Tables["PartesDeTrabajo"].Rows[0]["fechareclamo"].ToString());
                    }

                    string ArchivoRDLC = @"C:\\GIES\\Reports\\BajaDebitos.rdlc";
                    if (oDs.Tables["empresa"].Rows.Count == 0)
                        DatosDeLaEmpresa();

                    ReportDataSource[] oRDS = new ReportDataSource[6];
                    oRDS[0] = new ReportDataSource("BajaDebito", oDs.Tables["BajaDebitos"]);
                    oRDS[1] = new ReportDataSource("BajaDebitosSevicios", oDs.Tables["BajaDebitosServicios"]);
                    oRDS[2] = new ReportDataSource("Empresa", oDs.Tables["Empresa"]);
                    oRDS[3] = new ReportDataSource("Partes", oDs.Tables["PartesDeTrabajo"]);
                    oRDS[4] = new ReportDataSource("Usuario", oDs.Tables["Usuarios"]);
                    oRDS[5] = new ReportDataSource("Locacion", oDs.Tables["UsuarioLocacion"]);

                    if (Impresora == "")
                    {
                        frmRepViewRDLCNoPage frmImp = new frmRepViewRDLCNoPage();
                        frmImp.reportViewer1.LocalReport.ReportPath = ArchivoRDLC;
                        frmImp.reportViewer1.LocalReport.DataSources.Clear();
                        foreach (ReportDataSource item in oRDS)
                        {
                            frmImp.reportViewer1.LocalReport.DataSources.Add(item);

                        }
                        frmImp.ShowDialog();
                    }
                    else
                    {
                        LocalReport localReport = new LocalReport();
                        localReport.ReportEmbeddedResource = ArchivoRDLC;
                        localReport.DataSources.Clear();
                        for (int i = 0; i < oRDS.Length; i++)
                            localReport.DataSources.Add(oRDS[i]);
                        localReport.Refresh();

                        PrinterSettings ps = new PrinterSettings();
                        PaperSource oPaperSource = new PaperSource();

                        oPaperSource.RawKind = 1;
                        ps.PrinterName = /*"Brother HL-2130 series";*/"Microsoft Print to PDF";// this.DatosImpresion(Personal.Id_Punto_Login, 9)["impresora"].ToString();
                        ps.DefaultPageSettings.PaperSource = oPaperSource;

                        ImprimirDirecto(localReport, ps, MEDIDAS_HOJAS.A4, marginMM: 0);
                    }


                }
                else
                {
                    InformeParteTrabajo rpt = new InformeParteTrabajo();
                    rpt.SetDataSource(oDs);

                    if (Impresora == "")
                    {
                        frmReportViewer frm = new frmReportViewer();

                        frm.oViewer.ReportSource = rpt;
                        frm.ShowDialog();
                        rpt.Close();
                        rpt.Dispose();
                        frm.oViewer.Dispose();
                    }
                    else
                    {
                        PrinterSettings ps = new PrinterSettings();
                        ps.DefaultPageSettings.PaperSize = oPS;
                        ps.DefaultPageSettings.PaperSource = oPSource;
                        rpt.PrintToPrinter(ps, ps.DefaultPageSettings, false);
                    }
                }


            }
            catch (Exception c )
            {
                MessageBox.Show("Error al imprimir el parte: "+c.Message);
                throw;
            }
        }

        public Boolean ImprimirPartes(int IdParte, string Impresora = "")
        {
            Partes oPartes = new Partes();

            try
            {
                oPartes.Impreso(IdParte);

                PaperSize oPS = new PaperSize();
                oPS.RawKind = (int)PaperKind.A4;
                PaperSource oPSource = new PaperSource();
                oPSource.RawKind = 1;

                oDs.Clear();
                oDs.Tables["PartesDeTrabajo"].Clear();
                if (oDs.Tables["PartesDeTrabajo"].Rows.Count == 0)
                    DatosDelParte(IdParte);
                if (oDs.Tables["empresa"].Rows.Count == 0)
                    DatosDeLaEmpresa();
                oDs.Tables["Usuarios"].Clear();
                if (oDs.Tables["Usuarios"].Rows.Count == 0)
                    DatosDelUsuarioPorId(Convert.ToInt32(oDs.Tables["PartesDeTrabajo"].Rows[0]["id_usuarios"]));
                oDs.Tables["ServiciosDelUsuario"].Clear();
                if (oDs.Tables["ServiciosDelUsuario"].Rows.Count == 0)
                    ServiciosDelUsuario(Convert.ToInt32(oDs.Tables["PartesDeTrabajo"].Rows[0]["id_usuarios"]));
                oDs.Tables["ServiciosDelParte"].Clear();
                if (oDs.Tables["ServiciosDelParte"].Rows.Count == 0)
                    ServiciosDelParte(IdParte);
                oDs.Tables["EquiposDelParte"].Clear();
                if (oDs.Tables["EquiposDelParte"].Rows.Count == 0)
                    EquiposDelParte(IdParte,false);
                oDs.Tables["UsuarioLocacion"].Clear();
                if (oDs.Tables["UsuarioLocacion"].Rows.Count == 0)
                    DatosDeLocacion(Convert.ToInt32(oDs.Tables["PartesDeTrabajo"].Rows[0]["id_locacion"]));
                ControlRegistrosVacios();

                if (oDs.Tables["PartesDeTrabajo"].Rows[0]["ParteOperacion"].ToString() == "CAMBIO DE DOMICILIO")
                {
                    InformeCambioDomicilio rpt = new InformeCambioDomicilio();
                    rpt.SetDataSource(oDs);
                    rpt.SetParameterValue("calle_origen", oDs.Tables["UsuarioLocacion"].Rows[0]["calle"]);
                    rpt.SetParameterValue("altura_origen", oDs.Tables["UsuarioLocacion"].Rows[0]["altura"]);
                    rpt.SetParameterValue("piso_origen", oDs.Tables["UsuarioLocacion"].Rows[0]["piso"]);
                    rpt.SetParameterValue("depto_origen", oDs.Tables["UsuarioLocacion"].Rows[0]["depto"]);
                    rpt.SetParameterValue("entre_origen", oDs.Tables["UsuarioLocacion"].Rows[0]["limitecalle1"]);
                    rpt.SetParameterValue("entre_y_origen", oDs.Tables["UsuarioLocacion"].Rows[0]["limitecalle2"]);
                    rpt.SetParameterValue("localidad_origen", oDs.Tables["UsuarioLocacion"].Rows[0]["localidad"]);

                    rpt.SetParameterValue("calle_destino", oDs.Tables["UsuarioLocacionDestino"].Rows[0]["calle"]);
                    rpt.SetParameterValue("altura_destino", oDs.Tables["UsuarioLocacionDestino"].Rows[0]["altura"]);
                    rpt.SetParameterValue("piso_destino", oDs.Tables["UsuarioLocacionDestino"].Rows[0]["piso"]);
                    rpt.SetParameterValue("depto_destino", oDs.Tables["UsuarioLocacionDestino"].Rows[0]["depto"]);
                    rpt.SetParameterValue("entre_destino", oDs.Tables["UsuarioLocacionDestino"].Rows[0]["limitecalle1"]);
                    rpt.SetParameterValue("entre_y_destino", oDs.Tables["UsuarioLocacionDestino"].Rows[0]["limitecalle2"]);
                    rpt.SetParameterValue("localidad_destino", oDs.Tables["UsuarioLocacionDestino"].Rows[0]["localidad"]);


                    if (Impresora == "")
                    {
                        frmReportViewer frm = new frmReportViewer();
                        frm.oViewer.ReportSource = null;
                        frm.oViewer.ReportSource = rpt;
                        frm.ShowDialog();
                        rpt.Close();
                        rpt.Dispose();
                        frm.oViewer.Dispose();
                    }
                    else
                    {
                        PrinterSettings ps = new PrinterSettings();
                        ps.DefaultPageSettings.PaperSize = oPS;
                        ps.DefaultPageSettings.PaperSource = oPSource;
                        rpt.PrintToPrinter(ps, ps.DefaultPageSettings, false);
                    }

                }
                else if (oDs.Tables["PartesDeTrabajo"].Rows[0]["ParteOperacion"].ToString() == "BAJA DE DÉBITO")
                {
                    oDs.Tables["BajaDebitos"].Clear();
                    if (oDs.Tables["BajaDebitos"].Rows.Count == 0)
                        DatosDebitos(IdParte, oDs.Tables["PartesDeTrabajo"].Rows[0]["FechaProgramacion"].ToString(), oDs.Tables["PartesDeTrabajo"].Rows[0]["fechareclamo"].ToString());
                    rptBajaDebitos rpt = new rptBajaDebitos();
                    rpt.SetDataSource(oDs);

                    if (Impresora == "")
                    {
                        frmReportViewer frm = new frmReportViewer();

                        frm.oViewer.ReportSource = rpt;
                        frm.ShowDialog();
                        rpt.Close();
                        rpt.Dispose();
                        frm.oViewer.Dispose();
                    }
                    else
                    {
                        PrinterSettings ps = new PrinterSettings();
                        ps.DefaultPageSettings.PaperSize = oPS;
                        ps.DefaultPageSettings.PaperSource = oPSource;
                        rpt.PrintToPrinter(ps, ps.DefaultPageSettings, false);
                    }
                }
                else
                {
                    InformeParteTrabajo rpt = new InformeParteTrabajo();
                    rpt.SetDataSource(oDs);

                    if (Impresora == "")
                    {
                        frmReportViewer frm = new frmReportViewer();

                        frm.oViewer.ReportSource = rpt;
                        frm.ShowDialog();
                        rpt.Close();
                        rpt.Dispose();
                        frm.oViewer.Dispose();
                    }
                    else
                    {
                        PrinterSettings ps = new PrinterSettings();
                        ps.DefaultPageSettings.PaperSize = oPS;
                        ps.DefaultPageSettings.PaperSource = oPSource;
                        rpt.PrintToPrinter(ps, ps.DefaultPageSettings, false);
                        rpt.Dispose();
                        rpt.Close();
                    }
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al imprimir el parte." + ex.Message);

                oPartes.Impreso(IdParte, true);

                return false;
            }


            return true;
        }


        public string Imprime_factura(int IdComprobante, Boolean exportar = false, string rutaSalida = "")
        {
            frmReportViewer frm = new frmReportViewer();
            frm.oViewer.ReportSource = null;

            Ofacturacion.Id_Comprobantes = IdComprobante;
            DataTable dtIvaAlicuotas = Ofacturacion.ListarIvaAlicuotasDetalles();
            DataTable dtIva = Ofacturacion.ListarIvaVentas();

            oDs.Clear();
            DatosDeLaEmpresa(Convert.ToInt32(dtIva.Rows[0]["id_comprobantes_tipo"]));
            DatosDelUsuario();
            string numFactura = "";
            string tipoCom = "";
            string letraCom = "";
            string codigoAfip = "6";

            Decimal Iva5 = 0; //Es el 21 (5 es en la tabla de afip)
            Decimal Iva4 = 0; //Es el 10,5 (4 es en la tabla de afip)


            foreach (DataRow dr in dtIvaAlicuotas.Rows)
            {
                if (Convert.ToInt32(dr["numero_afip"].ToString()) == 5)
                    Iva5 = Convert.ToDecimal(dr["importe_iva"].ToString());

                if (Convert.ToInt32(dr["numero_afip"].ToString()) == 4)
                    Iva4 = Convert.ToDecimal(dr["importe_iva"].ToString());


            }

            String Tipocomprobante = "FACTURA";

            switch (Convert.ToInt32(dtIva.Rows[0]["id_comprobantes_tipo"]))
            {
                case 1:
                    Tipocomprobante = "FACTURA";
                    codigoAfip = "1";
                    break;
                case 2:
                    Tipocomprobante = "FACTURA";
                    codigoAfip = "6";
                    break;
                case 3:
                    Tipocomprobante = "NOTA DE CREDITO";
                    codigoAfip = "3";
                    break;
                case 4:
                    Tipocomprobante = "NOTA DE CREDITO";
                    codigoAfip = "8";
                    break;
                case 6:
                    Tipocomprobante = "REMITO";
                    codigoAfip = "";
                    break;
                case 13:
                    Tipocomprobante = "NOTA DE DEBITO";
                    codigoAfip = "2";
                    break;
                case 14:
                    Tipocomprobante = "NOTA DE DEBITO";
                    codigoAfip = "7";
                    break;
                default:
                    Tipocomprobante = "FACTURA";
                    break;
            }


            try
            {
                DataRow drCom;
                drCom = oDs.Tables["Comprobantes"].NewRow();
                drCom["comp_descripcion"] = Tipocomprobante;
                drCom["comp_letra"] = Convert.ToInt32(dtIva.Rows[0]["id_comprobantes_tipo"]) == 6 ? "X" : dtIva.Rows[0]["letra"].ToString();

                drCom["comp_codigo_afip"] = String.Format("Codigo Nro {0}", codigoAfip);
                drCom["comp_cae"] = dtIva.Rows[0]["cae"].ToString();
                drCom["comp_fecha"] = Convert.ToDateTime(dtIva.Rows[0]["fecha"].ToString()); // oComprobante.Fecha.ToShortDateString();
                drCom["comp_numero"] = dtIva.Rows[0]["punto_venta"].ToString().PadLeft(4, '0') + "-" + dtIva.Rows[0]["numero"].ToString().PadLeft(8, '0');
                drCom["comp_importe1"] = string.Format("{0:C}", (Convert.ToDecimal(dtIva.Rows[0]["Importe_final"].ToString())));
                drCom["Comp_Imp_Provincia1"] = string.Format("{0:C}", (Convert.ToDecimal(dtIva.Rows[0]["Importe_impuesto_provincial"].ToString())));
                drCom["comp_importe_subtotal"] = Convert.ToDecimal(dtIva.Rows[0]["Importe_neto"].ToString());
                //               drCom["comp_iva1"] = Convert.ToDecimal(dtIva.Rows[0]["Importe_iva"].ToString());
                drCom["comp_cae_venvimiento"] = Convert.ToDateTime(dtIva.Rows[0]["fecha"].ToString()).AddDays(10);

                drCom["comp_iva1"] = Iva5;
                drCom["comp_iva2"] = Iva4;
                oDs.Tables["comprobantes"].Rows.Add(drCom);
                letraCom = Convert.ToInt32(dtIva.Rows[0]["id_comprobantes_tipo"]) == 6 ? "X" : dtIva.Rows[0]["letra"].ToString();
                numFactura = Tipocomprobante + " " + letraCom + " " + dtIva.Rows[0]["punto_venta"].ToString().PadLeft(4, '0') + "-" + dtIva.Rows[0]["numero"].ToString().PadLeft(8, '0');


            }
            catch { }


            DataTable dt = Ofacturacion.ListarDetalle();
            foreach (DataRow dr in dt.Rows)
            {
                DataRow drdet;
                drdet = oDs.Tables["Comprobantes_det"].NewRow();
                drdet["comp_det_descripcion"] = dr["Descripcion"].ToString().ToUpper();

                if (dr["Descripcion_adicional"].ToString().Trim() == "S")
                    drdet["comp_det_hasta"] = "SubTotal";

                else
                {
                    drdet["comp_det_desde"] = Convert.ToDateTime(dr["desde"].ToString()).ToShortDateString();
                    drdet["comp_det_hasta"] = Convert.ToDateTime(dr["hasta"].ToString()).ToShortDateString();
                }

                //     drdet["comp_det_unitario"] = Convert.ToDecimal(dr["unitario"].ToString());
                drdet["comp_det_unitario"] = decimal.Round(Convert.ToDecimal(dr["total"].ToString()), 2);
                drdet["comp_det_total"] = decimal.Round(Convert.ToDecimal(dr["total"].ToString()), 2);
                drdet["comp_det_punitorios"] = decimal.Round(Convert.ToDecimal(dr["punitorios"].ToString()), 2);
                drdet["comp_det_bonificaciones"] = decimal.Round(decimal.Multiply(Convert.ToDecimal(dr["bonificaciones"].ToString()), -1), 2);
                oDs.Tables["Comprobantes_det"].Rows.Add(drdet);

            }

            CrystalDecisions.CrystalReports.Engine.ReportDocument rpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
            if (Convert.ToInt32(dtIva.Rows[0]["id_modalidad_fact"]) == 3)
            {
                if (!Debugger.IsAttached)
                    rpt.Load(Application.StartupPath + "\\Reports\\rptFactura_Electronica.rpt");
                else
                    rpt.Load(@"C:\GIES\Reports\rptFactura_Electronica.rpt");
            }
            else
            {
                if (!Debugger.IsAttached)
                    rpt.Load(Application.StartupPath + "\\Reports\\rptFactura_Manual.rpt");
                else
                    rpt.Load(@"C:\GIES\Reports\rptFactura_Manual.rpt");
            }

            rpt.SetDataSource(oDs);


            if (exportar == false)
            {
                Int32 VistaPrevia = oConfig.GetValor_N("VistaPreviaFactura"); //porcentaje de interes
                if (VistaPrevia == 1)
                {

                    frm.oViewer.ReportSource = rpt;
                    frm.ShowDialog();
                    rpt.Close();
                    rpt.Dispose();
                    frm.oViewer.Dispose();
                }
                else
                {
                    PaperSize oPS = new PaperSize();
                    oPS.RawKind = (int)PaperKind.A4;
                    PaperSource oPSource = new PaperSource();
                    DataRow drDatosImpresora;
                    PrinterSettings ps = new PrinterSettings();

                    try
                    {
                        drDatosImpresora = this.DatosImpresion(Puntos_Cobros.Id_Punto, Convert.ToInt32(dtIva.Rows[0]["id_comprobantes_tipo"]));
                        oPSource.RawKind = Convert.ToInt32(drDatosImpresora["impresora_bandeja"].ToString());
                        ps.PrinterName = drDatosImpresora["impresora"].ToString(); ;
                        ps.DefaultPageSettings.PaperSize = oPS;
                        ps.DefaultPageSettings.PaperSource = oPSource;
                    }
                    catch (ExcepcionImpresoraNoEncontrada)
                    {
                        PrintDialog printDialog = new PrintDialog();
                        printDialog.ShowDialog();
                        ps = printDialog.PrinterSettings;
                    }

                    rpt.PrintToPrinter(ps, ps.DefaultPageSettings, false);
                }
                return "";
            }
            else
            {
                rpt.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, rutaSalida + "\\" + numFactura.ToString() + ".pdf");
                return numFactura + ".pdf";
            }

        }

        public void Imprime_Recibo(int IdComprobante, int cuenta)
        {
            //if (System.Diagnostics.Debugger.IsAttached)
            //    return;

            frmReportViewer frm = new frmReportViewer();
            frm.oViewer.ReportSource = null;

            oDs.Clear();
            DatosDeLaEmpresa();
            DatosDelUsuario();

            Ofacturacion.Id_Comprobantes = IdComprobante;

            DataTable dt = Ofacturacion.ListarDetalle();
            DataTable dtAgrupado = dt.Clone();

            oDs.Tables["Comprobantes_det"].Clear();
            //foreach (DataRow dr in dt.Rows)
            //{
            //    DataRow drdet;
            //    drdet = oDs.Tables["Comprobantes_det"].NewRow();
            //    drdet["comp_det_descripcion"] = dr["Descripcion"].ToString().ToUpper();
            //    drdet["comp_det_unitario"] = dr["total"].ToString();
            //    drdet["comp_det_total"] = dr["total"].ToString();
            //    drdet["comp_det_desde"] = Convert.ToDateTime(dr["desde"].ToString()).ToShortDateString();
            //    drdet["comp_det_hasta"] = Convert.ToDateTime(dr["hasta"].ToString()).ToShortDateString();
            //    oDs.Tables["comprobantes_det"].Rows.Add(drdet);
            //}
            DataTable dtAux = dt.Copy();
            DataTable dtAuxFinal = oDs.Tables["comprobantes_det"].Copy();
            var grupoDescripcion = dtAux.AsEnumerable().GroupBy(row => row.Field<string>("Descripcion"));
            int cantidad = 0;
            decimal bonificado = 0;
            decimal unitario = 0;
            decimal iva = 0;
            decimal punitorios = 0;
            decimal total = 0;
            int idComprobantes = Convert.ToInt32(dtAux.Rows[0]["id_comprobantes"]);
            foreach (var grupo in grupoDescripcion)
            {
                string nombre = grupo.Key.ToString();
                DataView dv = dtAux.DefaultView;
                dv.RowFilter = "Descripcion  = '" + nombre + "'";
                DataTable dt2 = new DataTable();
                dt2 = dv.ToTable();
                DateTime fechaDesde = Convert.ToDateTime(dt2.Rows[0]["desde"]);
                DateTime fechaHasta = Convert.ToDateTime(dt2.Rows[dt2.Rows.Count-1]["hasta"]);
                cantidad = 0;
                bonificado = 0;
                unitario = 0;
                iva = 0;
                punitorios = 0;
                total = 0;
                foreach (DataRow item in dt2.Rows)
                {
                    cantidad = cantidad + Convert.ToInt32(item["cantidad"]);
                    bonificado = bonificado + Convert.ToDecimal(item["bonificaciones"]);
                    unitario = unitario + Convert.ToDecimal(item["unitario"]);
                    iva = iva + Convert.ToDecimal(item["iva"]);
                    punitorios = punitorios + Convert.ToDecimal(item["punitorios"]);
                    total = total + Convert.ToDecimal(item["total"]);
                }
                DataRow dr = dtAgrupado.NewRow();
                dr["id"] = 1;
                dr["id_comprobantes"] = idComprobantes;
                dr["descripcion"] = nombre;
                dr["cantidad"] = cantidad;
                dr["unitario"] = unitario;
                dr["iva"] = iva;
                dr["punitorios"] = punitorios;
                dr["bonificaciones"] = bonificado;
                dr["total"] = total;
                dr["desde"] = fechaDesde;
                dr["hasta"] = fechaHasta;
                dr["codigo"] = 0;
                dr["unidad"] = 0;
                dr["descripcion_adicional"] = "";
                dr["id_iva_alicuotas"] = 0;
                dtAgrupado.Rows.Add(dr);

            }

            foreach (DataRow dr in dtAgrupado.Rows)
            {
                DataRow drdet;
                drdet = oDs.Tables["Comprobantes_det"].NewRow();
                drdet["comp_det_descripcion"] = dr["Descripcion"].ToString().ToUpper();
                drdet["comp_det_unitario"] = dr["total"].ToString();
                drdet["comp_det_total"] = dr["total"].ToString();
                drdet["comp_det_desde"] = Convert.ToDateTime(dr["desde"].ToString()).ToShortDateString();
                drdet["comp_det_hasta"] = Convert.ToDateTime(dr["hasta"].ToString()).ToShortDateString();
                oDs.Tables["comprobantes_det"].Rows.Add(drdet);
            }

            DataTable dtdetallerecibos = Ousuarios_CtaCte_Recibos.ListarCtaCteRecibosdet(IdComprobante, "CO");

            decimal total_r = 0;
            DataRow drpag;
            
            foreach (DataRow drp in dtdetallerecibos.Rows)
            {
                drpag = oDs.Tables["Comprobantes_pagos"].NewRow();
                drpag["pago_descripcion"] = drp["Descripcion"].ToString().ToUpper();
                drpag["pago_importe"] = decimal.Round(Convert.ToDecimal(drp["importe"].ToString()), 2);
                total_r = total_r = total_r + decimal.Round(Convert.ToDecimal(drp["importe"].ToString()), 2);
                oDs.Tables["comprobantes_pagos"].Rows.Add(drpag);
            }

            DataRow drCom;
            drCom = oDs.Tables["Comprobantes"].NewRow();
            drCom["comp_descripcion"] = "RECIBO";
            drCom["comp_letra"] = "X";
            drCom["comp_codigo_afip"] = "";
            drCom["comp_fecha"] = Fecha.ToShortDateString();
            drCom["comp_numero"] = NumeroMuestra;
            drCom["comp_importe1"] = string.Format("{0:C}", (total_r));
            oDs.Tables["comprobantes"].Rows.Add(drCom);

            ReciboD rpt1 = new ReciboD();
            ReciboD2 rpt2 = new ReciboD2();


            if (cuenta == 1)
            {
                rpt1.Subreports[0].SetDataSource(oDs);
                rpt1.Subreports[1].SetDataSource(oDs);
                rpt1.Subreports[2].SetDataSource(oDs);
                rpt1.Subreports[3].SetDataSource(oDs);
            }
            else
            {
                rpt2.Subreports[0].SetDataSource(oDs);
                rpt2.Subreports[1].SetDataSource(oDs);
                rpt2.Subreports[2].SetDataSource(oDs);
                rpt2.Subreports[3].SetDataSource(oDs);
            }

            Int32 VistaPrevia = oConfig.GetValor_N("VistaPreviaFactura"); //porcentaje de interes
            if (VistaPrevia == 1)
            {

                if (cuenta == 1)
                {
                    frm.oViewer.ReportSource = rpt1;
                    frm.ShowDialog();

                    rpt1.Close();
                    rpt1.Dispose();
                    frm.oViewer.Dispose();
                }
                else
                {
                    frm.oViewer.ReportSource = rpt2;
                    frm.ShowDialog();

                    rpt2.Close();
                    rpt2.Dispose();
                    frm.oViewer.Dispose();

                }
            }
            else
            {
                PaperSize oPS = new PaperSize();
                oPS.RawKind = (int)PaperKind.A4;
                PaperSource oPSource = new PaperSource();

                int TipoComprobante = cuenta == 1 ? 5 : 9; // 5 RECIBO 9 RECIBO MOROCHO
                DataRow drDatosImpresora;

                PrinterSettings ps = new PrinterSettings();
                try
                {
                    drDatosImpresora = this.DatosImpresion(Puntos_Cobros.Id_Punto, TipoComprobante);
                    oPSource.RawKind = Convert.ToInt32(drDatosImpresora["impresora_bandeja"].ToString());
                    ps.PrinterName = drDatosImpresora["impresora"].ToString();
                    ps.DefaultPageSettings.PaperSize = oPS;
                    ps.DefaultPageSettings.PaperSource = oPSource;
                }
                catch (ExcepcionImpresoraNoEncontrada)
                {
                    PrintDialog printDialog = new PrintDialog();
                    printDialog.ShowDialog();
                    ps = printDialog.PrinterSettings;
                }

                if(cuenta == 1)
                    rpt1.PrintToPrinter(ps, ps.DefaultPageSettings, false);
                else
                    rpt2.PrintToPrinter(ps, ps.DefaultPageSettings, false);
            }
        }

        //en proceso
        public void ImprimeReciboInterno(int IdComprobante, int cuenta)
        {
            string ArchivoRDLC = @"C:\\GIES\\Reports\\ReciboCuenta2.rdlc";
            oDs.Clear();

            DataRow drAbonado =  DatosDelUsuario();
            Comprobantes oComprobantes = new Comprobantes();
            frmReportViewer frm = new frmReportViewer();
            frm.oViewer.ReportSource = null;

            Ofacturacion.Id_Comprobantes = IdComprobante;

            DataTable dt = Ofacturacion.ListarDetalle();
            DataTable dtAgrupado = dt.Clone();

            oDs.Tables["Comprobantes_det"].Clear();

            DataTable dtAux = dt.Copy();
            DataTable dtAuxFinal = oDs.Tables["comprobantes_det"].Copy();
            var grupoDescripcion = dtAux.AsEnumerable().GroupBy(row => row.Field<string>("Descripcion"));
            string abonado = drAbonado["usu_apellido"].ToString();
            
            int cantidad = 0;
            decimal bonificado = 0;
            decimal unitario = 0;
            decimal iva = 0;
            decimal punitorios = 0;
            decimal totalUnidad = 0,total=0;
            int idComprobantes = Convert.ToInt32(dtAux.Rows[0]["id_comprobantes"]);
            foreach (var grupo in grupoDescripcion)
            {
                string nombre = grupo.Key.ToString();
                DataView dv = dtAux.DefaultView;
                dv.RowFilter = "Descripcion  = '" + nombre + "'";
                DataTable dt2 = new DataTable();
                dt2 = dv.ToTable();
                DateTime fechaDesde = Convert.ToDateTime(dt2.Rows[0]["desde"]);
                DateTime fechaHasta = Convert.ToDateTime(dt2.Rows[dt2.Rows.Count - 1]["hasta"]);
                cantidad = 0;
                bonificado = 0;
                unitario = 0;
                iva = 0;
                punitorios = 0;
                totalUnidad = 0;
                foreach (DataRow item in dt2.Rows)
                {
                    cantidad = cantidad + Convert.ToInt32(item["cantidad"]);
                    bonificado = bonificado + Convert.ToDecimal(item["bonificaciones"]);
                    unitario = unitario + Convert.ToDecimal(item["unitario"]);
                    iva = iva + Convert.ToDecimal(item["iva"]);
                    punitorios = punitorios + Convert.ToDecimal(item["punitorios"]);
                    totalUnidad = totalUnidad + Convert.ToDecimal(item["total"]);
                }
                DataRow dr = dtAgrupado.NewRow();
                dr["id"] = 1;
                dr["id_comprobantes"] = idComprobantes;
                dr["descripcion"] = nombre;
                dr["cantidad"] = cantidad;
                dr["unitario"] = unitario;
                dr["iva"] = iva;
                dr["punitorios"] = punitorios;
                dr["bonificaciones"] = bonificado;
                dr["total"] = totalUnidad;
                dr["desde"] = fechaDesde;
                dr["hasta"] = fechaHasta;
                dr["codigo"] = 0;
                dr["unidad"] = 0;
                dr["descripcion_adicional"] = "";
                dr["id_iva_alicuotas"] = 0;
                dtAgrupado.Rows.Add(dr);
                total = total + totalUnidad;
            }

            foreach (DataRow dr in dtAgrupado.Rows)
            {
                DataRow drdet;
                drdet = oDs.Tables["Comprobantes_det"].NewRow();
                drdet["comp_det_descripcion"] = dr["Descripcion"].ToString().ToUpper();
                drdet["comp_det_unitario"] = Convert.ToDecimal(dr["total"]);
                drdet["comp_det_total"] = Convert.ToDecimal(dr["total"]).ToString("c2");
                drdet["comp_det_desde"] = Convert.ToDateTime(dr["desde"].ToString()).ToShortDateString();
                drdet["comp_det_hasta"] = Convert.ToDateTime(dr["hasta"].ToString()).ToShortDateString();
                oDs.Tables["comprobantes_det"].Rows.Add(drdet);
            }

            DataTable dtdetallerecibos = Ousuarios_CtaCte_Recibos.ListarCtaCteRecibosdet(IdComprobante, "CO");

            decimal total_r = 0;
            DataRow drpag;
            DateTime fechaComprobante = Convert.ToDateTime(dtdetallerecibos.Rows[0]["fecha_acreditacion"]);
            foreach (DataRow drp in dtdetallerecibos.Rows)
            {
                drpag = oDs.Tables["Comprobantes_pagos"].NewRow();
                drpag["pago_descripcion"] = drp["Descripcion"].ToString().ToUpper();
                drpag["pago_importe"] = decimal.Round(Convert.ToDecimal(drp["importe"].ToString()), 2);
                drpag["pago_importe_String"] = decimal.Round(Convert.ToDecimal(drp["importe"].ToString()), 2).ToString("c2");
                total_r = total_r = total_r + decimal.Round(Convert.ToDecimal(drp["importe"].ToString()), 2);
                oDs.Tables["comprobantes_pagos"].Rows.Add(drpag);
            }

            DataRow drCom;
            drCom = oDs.Tables["Comprobantes"].NewRow();
            drCom["comp_descripcion"] = "RECIBO";
            drCom["comp_letra"] = "X";
            drCom["comp_codigo_afip"] = "";
            drCom["comp_fecha"] = Fecha.ToShortDateString();
            drCom["comp_numero"] = NumeroMuestra;
            drCom["comp_importe1"] = string.Format("{0:C}", (total_r));
            oDs.Tables["comprobantes"].Rows.Add(drCom);
    

            //ReciboD rpt1 = new ReciboD();
            //ReciboD2 rpt2 = new ReciboD2();

            //rpt2.Subreports[0].SetDataSource(oDs);
            //rpt2.Subreports[1].SetDataSource(oDs);
            //rpt2.Subreports[2].SetDataSource(oDs);
            //rpt2.Subreports[3].SetDataSource(oDs);

            //PaperSize oPS = new PaperSize();
            //oPS.RawKind = (int)PaperKind.A4;
            //PaperSource oPSource = new PaperSource();

            //int TipoComprobante = cuenta == 1 ? 5 : 9; // 5 RECIBO 9 RECIBO MOROCHO

            //oPSource.RawKind = Convert.ToInt32(this.DatosImpresion(Puntos_Cobros.Id_Punto, TipoComprobante)["impresora_bandeja"].ToString());

            Int32 VistaPrevia = oConfig.GetValor_N("VistaPreviaFactura"); //porcentaje de interes

            frmReportViewerRDLC oVisor = new frmReportViewerRDLC();
            oVisor.reportViewer1.LocalReport.ReportPath = ArchivoRDLC;
            var setup = oVisor.reportViewer1.GetPageSettings();
            setup.Margins = new System.Drawing.Printing.Margins(0, 0, 0, 0);
            oVisor.reportViewer1.SetPageSettings(setup);
            oVisor.reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource[] oRDS = new ReportDataSource[2];
            ReportParameter[] oRDSParametros = new ReportParameter[5];
            oRDS[0] = new ReportDataSource("DetallesComprobantes", oDs.Tables["comprobantes_det"]);
            oRDS[1] = new ReportDataSource("Pagos", oDs.Tables["comprobantes_pagos"]);
            oRDSParametros[0] = new ReportParameter("Fecha", fechaComprobante.ToString("dd/MM/yyyy"), true);
            oRDSParametros[1] = new ReportParameter("Abonado",abonado, true);
            oRDSParametros[2] = new ReportParameter("ImporteTotal", total.ToString("c2"), true);
            oRDSParametros[3] = new ReportParameter("Comprobante", NumeroMuestra, true);
            oRDSParametros[4] = new ReportParameter("PagoTotal", total_r.ToString("c2"), true);
            oVisor.reportViewer1.LocalReport.DataSources.Add(oRDS[0]);
            oVisor.reportViewer1.LocalReport.DataSources.Add(oRDS[1]);
            oVisor.reportViewer1.LocalReport.SetParameters(oRDSParametros[0]);
            oVisor.reportViewer1.LocalReport.SetParameters(oRDSParametros[1]);
            oVisor.reportViewer1.LocalReport.SetParameters(oRDSParametros[2]);
            oVisor.reportViewer1.LocalReport.SetParameters(oRDSParametros[3]);
            oVisor.reportViewer1.LocalReport.SetParameters(oRDSParametros[4]);
            oVisor.reportViewer1.RefreshReport();
            oVisor.ShowDialog();


           
        }


        public void ImprimirDetalleCaja(DataTable detalleCaja, DataTable dtFormas, DataTable dtServicios, DataTable dtRetiros, DataTable dtRetirosResumen)
        {

            frmReportViewer frm = new frmReportViewer();
            frm.oViewer.ReportSource = null;
            oDs.Tables["DetalleCaja"].Clear();
            foreach (DataRow item in detalleCaja.Rows)
            {
                oDs.Tables["DetalleCaja"].ImportRow(item);
            }
            oDs.Tables["FormasDePago"].Clear();

            foreach (DataRow item in dtFormas.Rows)
            {
                oDs.Tables["FormasDePago"].ImportRow(item);
            }
            oDs.Tables["CajaServicios"].Clear();
            foreach (DataRow item in dtServicios.Rows)
            {
                oDs.Tables["CajaServicios"].ImportRow(item);
            }
            oDs.Tables["Egresos"].Clear();
            foreach (DataRow item in dtRetiros.Rows)
            {
                oDs.Tables["Egresos"].ImportRow(item);
            }
            oDs.Tables["EgresosResumen"].Clear();

            foreach (DataRow item in dtRetirosResumen.Rows)
            {
                oDs.Tables["EgresosResumen"].ImportRow(item);
            }

            rptDetalleCaja rpt = new rptDetalleCaja();
            rpt.SetDataSource(oDs);
            frm.oViewer.ReportSource = rpt;

            frm.ShowDialog();

            rpt.Close();
            rpt.Dispose();
            frm.oViewer.Dispose();
        }

        public void ImprimirEgresos(DataTable dtDetalleCaja, DataTable dtRetiros, DataTable dtRetirosResumen)
        {
            frmReportViewer frm = new frmReportViewer();
            frm.oViewer.ReportSource = null;
            oDs.Tables["DetalleCaja"].Clear();
            foreach (DataRow item in dtDetalleCaja.Rows)
            {
                oDs.Tables["DetalleCaja"].ImportRow(item);
            }
            oDs.Tables["Egresos"].Clear();
            foreach (DataRow item in dtRetiros.Rows)
            {
                oDs.Tables["Egresos"].ImportRow(item);
            }
            oDs.Tables["EgresosResumen"].Clear();

            foreach (DataRow item in dtRetirosResumen.Rows)
            {
                oDs.Tables["EgresosResumen"].ImportRow(item);
            }

            rptEgresos rpt = new rptEgresos();
            rpt.SetDataSource(oDs);
            frm.oViewer.ReportSource = rpt;

            frm.ShowDialog();

            rpt.Close();
            rpt.Dispose();
            frm.oViewer.Dispose();
        }

        public void ImprimirCajaServicios(DataTable dtDetalleCaja, DataTable dtServicios)
        {
            frmReportViewer frm = new frmReportViewer();
            frm.oViewer.ReportSource = null;
            oDs.Tables["DetalleCaja"].Clear();
            foreach (DataRow item in dtDetalleCaja.Rows)
            {
                oDs.Tables["DetalleCaja"].ImportRow(item);
            }
            oDs.Tables["CajaServicios"].Clear();
            foreach (DataRow item in dtServicios.Rows)
            {
                oDs.Tables["CajaServicios"].ImportRow(item);
            }

            rptCajaServicio rpt = new rptCajaServicio();
            rpt.SetDataSource(oDs);
            frm.oViewer.ReportSource = rpt;

            frm.ShowDialog();

            rpt.Close();
            rpt.Dispose();
            frm.oViewer.Dispose();
        }

        public void ImprimirDetalleCajaRecibos(DataTable detalleCaja, DataTable dtRecibos)
        {
            frmReportViewer frm = new frmReportViewer();
            frm.oViewer.ReportSource = null;
            oDs.Tables["DetalleCaja"].Clear();
            foreach (DataRow item in detalleCaja.Rows)
            {
                oDs.Tables["DetalleCaja"].ImportRow(item);
            }
            oDs.Tables["CajaDetalleRecibos"].Clear();

            foreach (DataRow item in dtRecibos.Rows)
            {
                if (Convert.ToInt32(item["borrado"]) == 0)
                {
                    DataRow dr = oDs.Tables["CajaDetalleRecibos"].NewRow();
                    dr["tipo"] = item["tipo"].ToString();
                    dr["personal"] = item["personal"].ToString();
                    dr["codigo"] = item["cod_usuario"].ToString();
                    dr["usuario"] = item["nombre_usuario"].ToString();
                    dr["subservicio"] = item["nombre_sub"].ToString();
                    dr["monto"] = item["monto"].ToString();
                    dr["forma"] = item["TipoPago"].ToString();
                    dr["importe"] = item["montoPagado"].ToString();
                    dr["recibo"] = item["codigo_muestra"].ToString();
                    dr["factura"] = item["factura"].ToString();

                    oDs.Tables["CajaDetalleRecibos"].Rows.Add(dr);
                }
            }

            rptDetalleCajaRecibos rpt1 = new rptDetalleCajaRecibos();
            rpt1.SetDataSource(oDs);
            frm.oViewer.ReportSource = rpt1;

            frm.ShowDialog();

            rpt1.Close();
            rpt1.Dispose();
            frm.oViewer.Dispose();


        }

        public DataRow DatosPresentacion(int idPresentacion)
        {
            DataRow Dtr, drDatosPresentacion;
            DateTime dtimeAux = new DateTime();
            Presentacion_Debitos oPresentacionDebitos = new Presentacion_Debitos();
            drDatosPresentacion = oPresentacionDebitos.Listar(idPresentacion, dtimeAux, dtimeAux, dtimeAux).Rows[0];
            Dtr = oDs.Tables["DebitosReciboGeneral"].NewRow();
            Dtr["presentacion_codigo"] = drDatosPresentacion["id"];
            Dtr["presentacion_periodo"] = drDatosPresentacion["periodo"];
            Dtr["cantidad_recibos"] = drDatosPresentacion["cantidad_recibos"];
            Dtr["nro_primer_recibo"] = drDatosPresentacion["nro_primer_recibo"];
            Dtr["nro_ultimo_recibo"] = drDatosPresentacion["nro_ultimo_recibo"];
            Dtr["cant_plasticos_aceptados"] = drDatosPresentacion["cant_plasticos_aceptados"];
            Dtr["cant_plasticos_rechazados"] = drDatosPresentacion["cant_plasticos_rechazados"];
            Dtr["monto_total_pagar"] = drDatosPresentacion["monto_total"];
            Dtr["monto_rechazado"] = drDatosPresentacion["monto_rechazado"];
            Dtr["monto_pagado"] = drDatosPresentacion["monto_total_pago"];
            Dtr["cant_plasticos_total"] = drDatosPresentacion["cant_plasticos_total"];
            Dtr["forma_de_pago"] = drDatosPresentacion["forma_de_pago"];
            oDs.Tables["DebitosReciboGeneral"].Rows.Add(Dtr);
            return Dtr;
        }

        public void ImprimirInformePresentacion(int idPresentacion)
        {
            try
            {
                frmReportViewer frm = new frmReportViewer();
                frm.oViewer.ReportSource = null;
                oDs.Clear();
                oDs.Tables["DebitosReciboGeneral"].Clear();
                if (oDs.Tables["DebitosReciboGeneral"].Rows.Count == 0)
                    DatosPresentacion(idPresentacion);
                rptDebitosReciboGeneral rpt = new rptDebitosReciboGeneral();
                rpt.SetDataSource(oDs);
                frm.oViewer.ReportSource = rpt;
                frm.ShowDialog();
                rpt.Close();
                rpt.Dispose();
                frm.oViewer.Dispose();
            }
            catch
            {
                MessageBox.Show("Error al imprimir el recibo de la presentación.");
            }
        }

        public void ImprimirInformeCajaDiaria(DataTable dtDatosCajaDiaria, DataTable dtDatosFormasDePago)
        {
            try
            {
                frmReportViewer frm = new frmReportViewer();
                frm.oViewer.ReportSource = null;
                oDs.Clear();
                oDs.Tables["CajaDiaria"].Clear();
                if (oDs.Tables["CajaDiaria"].Rows.Count == 0)
                {
                    DataRow Dtr = oDs.Tables["CajaDiaria"].NewRow();
                    Dtr["id_personal"] = dtDatosCajaDiaria.Rows[0]["id_personal"];
                    Dtr["personal"] = dtDatosCajaDiaria.Rows[0]["personal"];
                    Dtr["punto_cobro"] = dtDatosCajaDiaria.Rows[0]["punto_cobro"];
                    Dtr["numero_caja"] = dtDatosCajaDiaria.Rows[0]["numero_caja"];
                    Dtr["recibo_desde"] = dtDatosCajaDiaria.Rows[0]["recibo_desde"];
                    Dtr["recibo_hasta"] = dtDatosCajaDiaria.Rows[0]["recibo_hasta"];
                    Dtr["cant_total_recibos"] = dtDatosCajaDiaria.Rows[0]["cant_total_recibos"];
                    Dtr["monto_total_recibos"] = dtDatosCajaDiaria.Rows[0]["monto_total_recibos"];
                    Dtr["cant_total_anulados"] = dtDatosCajaDiaria.Rows[0]["cant_total_anulados"];
                    Dtr["monto_total_anulados"] = dtDatosCajaDiaria.Rows[0]["monto_total_anulados"];
                    Dtr["cant_final_recibos"] = dtDatosCajaDiaria.Rows[0]["cant_final_recibos"];
                    Dtr["monto_final_recibos"] = dtDatosCajaDiaria.Rows[0]["monto_final_recibos"];
                    oDs.Tables["CajaDiaria"].Rows.Add(Dtr);

                    if (dtDatosFormasDePago.Rows.Count > 0)
                    {
                        foreach (DataRow formaPago in dtDatosFormasDePago.Rows)
                            oDs.Tables["FormasDePago"].Rows.Add(formaPago["forma_pago"], formaPago["cantidad"], formaPago["monto"]);
                    }


                    rptCajaDiaria rpt = new rptCajaDiaria();
                    rpt.SetDataSource(oDs);
                    frm.oViewer.ReportSource = rpt;
                    frm.ShowDialog();
                    rpt.Close();
                    rpt.Dispose();
                    frm.oViewer.Dispose();
                }



            }
            catch (Exception c)
            {
                MessageBox.Show("Error al imprimir caja diaria.\n Error: " + c.ToString());
            }
        }

        public void ImprimirCajaGral(DataTable dataTableGral)
        {
            frmReportViewer frm = new frmReportViewer();
            frm.oViewer.ReportSource = null;
            oDs.Clear();

            rptCajaGral cajaGral = new rptCajaGral();
            cajaGral.SetDataSource(dataTableGral);
            frm.oViewer.ReportSource = cajaGral;

            frm.ShowDialog();
            cajaGral.Close();
            cajaGral.Dispose();
            frm.oViewer.Dispose();
        }


        public void ImprimirCajaGral(DataTable dataTableGral, Int32 idCajaGeneral, Int32 Cuenta)
        {

            DataTable dtPie = new DataTable();
            dtPie.Columns.Add("Detalle", typeof(String));
            dtPie.Columns.Add("importe", typeof(Decimal));

            DataTable dtFormas = new DataTable();
            DataTable dtFormasdePagosDetalle = new DataTable();
            // trae las formas de pago de los recibos
            dtFormasdePagosDetalle = ocaja_general.TraerFormasdePago(idCajaGeneral);


            // formas de pago
            dtFormas = OFormasDePago.Listar(); //OFormasDePago.ListarTiposFormasPagos();

            DataColumn DcCan = new DataColumn("Cantidad", typeof(Int32));
            DcCan.DefaultValue = 0;
            dtFormas.Columns.Add(DcCan);

            DataColumn DcImp = new DataColumn("Importe", typeof(Decimal));
            DcImp.DefaultValue = 0;
            dtFormas.Columns.Add(DcImp);

            Int32 Idforma = 0;
            Decimal ImportePago = 0;
            Decimal TotalPagos = 0;

            foreach (DataRow dr in dtFormasdePagosDetalle.Rows)
            {
                Idforma = Convert.ToInt32(dr["id_formas_de_pago"].ToString());
                ImportePago = Convert.ToDecimal(dr["importe"].ToString());
                foreach (DataRow drf in dtFormas.Rows)
                {
                    if (Convert.ToInt32(drf["id"].ToString()) == Idforma)
                    {
                        Boolean sigue = true;
                        if (Cuenta == 1)
                        {
                            if (Convert.ToInt32(dr["cuenta"].ToString()) == 1)
                                sigue = true;
                            else
                                sigue = false;
                        }
                        else
                            sigue = true;


                        if (sigue == true)
                        {
                            drf["cantidad"] = Convert.ToInt32(drf["cantidad"].ToString()) + 1;
                            drf["importe"] = Convert.ToDecimal(drf["importe"].ToString()) + ImportePago;
                            TotalPagos = TotalPagos + ImportePago;
                        }

                    }
                }

            }

            frmReportViewer frm = new frmReportViewer();
            frm.oViewer.ReportSource = null;
            oDs.Clear();

            Decimal ImporteTotal = 0;
            foreach (DataRow dr in dataTableGral.Rows)
            {
                DataRow drCom;
                drCom = oDs.Tables["CajaGral"].NewRow();
                if (Cuenta == 1)
                {
                    drCom["ctarecdesde_1"] = Convert.ToInt32(dr["Recibo_cuenta1_desde"]);
                    drCom["ctarechasta_1"] = Convert.ToInt32(dr["Recibo_cuenta1_hasta"]);
                    drCom["montorecibo1"] = Convert.ToDecimal(dr["importe_cuenta1"]);
                    ImporteTotal = ImporteTotal + Convert.ToDecimal(dr["importe_cuenta1"].ToString());
                }
                else
                {

                    drCom["ctarecdesde_1"] = Convert.ToInt32(dr["Recibo_cuenta1_desde"]);
                    drCom["ctarechasta_1"] = Convert.ToInt32(dr["Recibo_cuenta1_hasta"]);
                    drCom["montorecibo1"] = Convert.ToDecimal(dr["importe_cuenta1"]);

                    drCom["ctarecdesde_2"] = Convert.ToInt32(dr["Recibo_cuenta2_desde"]);
                    drCom["ctarechasta_2"] = Convert.ToInt32(dr["Recibo_cuenta2_hasta"]);
                    drCom["montorecibo2"] = Convert.ToDecimal(dr["importe_cuenta2"]);


                    ImporteTotal = ImporteTotal + Convert.ToDecimal(dr["importe_cuenta2"].ToString()) + Convert.ToDecimal(dr["importe_cuenta1"].ToString());
                }

                drCom["Fecha"] = Convert.ToDateTime(dr["fecha"]);
                drCom["sucursal"] = dr["pto_cobro"].ToString();
                drCom["numero"] = "";
                oDs.Tables["CajaGral"].Rows.Add(drCom);
            }
            oDs.Tables["CajaGral"].AcceptChanges();

            DataRow drComp;
            drComp = oDs.Tables["comprobantes"].NewRow();
            drComp["comp_Fecha"] = DateTime.Now;
            drComp["comp_numero"] = idCajaGeneral.ToString();
            drComp["comp_saldo"] = ImporteTotal;
            if (Cuenta == 1)
                drComp["comp_descripcion"] = "Cuenta 1";
            else
                drComp["comp_descripcion"] = "GENERAL";

            oDs.Tables["comprobantes"].Rows.Add(drComp);

            // parche feooo por si no coincide las formas de pagos con el recibo
            if (ImporteTotal != TotalPagos)
                dtFormas.Rows[0]["importe"] = Convert.ToDecimal(dtFormas.Rows[0]["importe"].ToString()) + (ImporteTotal - TotalPagos);


            foreach (DataRow dr in dtFormas.Rows)
            {
                if (Convert.ToDecimal(dr["importe"].ToString()) > 0)
                {
                    DataRow drCompagos;
                    drCompagos = oDs.Tables["Comprobantes_Pagos"].NewRow();
                    drCompagos["pago_descripcion"] = dr["nombre"].ToString().Trim() + " -  (" + dr["cantidad"].ToString().Trim() + ") ";
                    drCompagos["pago_importe"] = decimal.Round(Convert.ToDecimal(dr["importe"].ToString()), 2);
                    oDs.Tables["Comprobantes_Pagos"].Rows.Add(drCompagos);
                }
            }

            oDs.Tables["Comprobantes_Pagos"].AcceptChanges();



            rptCierreGeneral cajaGral = new rptCierreGeneral();
            cajaGral.SetDataSource(oDs);
            frm.oViewer.ReportSource = cajaGral;

            frm.ShowDialog();
            cajaGral.Close();
            cajaGral.Dispose();
            frm.oViewer.Dispose();
        }

        public void ImprimirRecibosDeb(DataTable dtRecibo)
        {
            frmReportViewer frm = new frmReportViewer();
            frm.oViewer.ReportSource = null;
            oDs.Tables["CajaDiaria"].Clear();
            foreach (DataRow item in dtRecibo.Rows)
            {
                DataRow dr = oDs.Tables["CajaDiaria"].NewRow();
                dr["personal"] = item["periodo1"].ToString();
                dr["recibo_desde"] = item["menor"].ToString();
                dr["recibo_hasta"] = item["mayor"].ToString();
                dr["monto_total_recibos"] = item["importe_total"].ToString();
                oDs.Tables["CajaDiaria"].Rows.Add(dr);
            }
            rptReciboDeb rpt1 = new rptReciboDeb();
            rpt1.SetDataSource(oDs);
            frm.oViewer.ReportSource = rpt1;

            frm.ShowDialog();

            rpt1.Close();
            rpt1.Dispose();
            frm.oViewer.Dispose();


        }

        public DataRow DatosArticulosMov(int idArticulos_mov)
        {
            DataRow dr = oArtMov.TraerArticulosMovRow(idArticulos_mov);
            string tipoDestinatario = string.Empty;

            Dtr = oDs.Tables["ArticulosMov"].NewRow();
            Dtr["personal"] = dr["nombre_personal"];
            Dtr["fecha"] = dr["Fecha"];
            Dtr["Destinatario"] = dr["nombre_destinatario"];
            Dtr["id"] = dr["id"];
            Dtr["id_personal"] = dr["Id_personal"];
            Dtr["id_destinatario"] = dr["id_destinatario"];

            if (dr["Destinatario"].ToString().ToUpper() == "M")
                tipoDestinatario = "MOVIL";
            else if (dr["Destinatario"].ToString().ToUpper() == "A")
                tipoDestinatario = "AREA";
            else if (dr["Destinatario"].ToString().ToUpper() == "P")
                tipoDestinatario = "PERSONAL";
            else
                tipoDestinatario = "SIN DEFINIR";

            Dtr["tipo_destinatario"] = tipoDestinatario;
            oDs.Tables["ArticulosMov"].Rows.Add(Dtr);
            return Dtr;
        }

        public void DatosArticulosMovDet(int idArticulos_mov)
        {
            DataTable dt = oArtMovDet.ListarPorIdArticuloMov(idArticulos_mov);
            foreach (DataRow dr in dt.Rows)
            {
                Dtr = oDs.Tables["ArticulosMovDet"].NewRow();
                Dtr["id_articulos_mov"] = dr["id_articulos_mov"];
                Dtr["id_articulo"] = dr["id_tipo"];
                Dtr["articulo"] = dr["articulo"];
                Dtr["cantidad"] = dr["cantidad"];
                Dtr["importe_unitario"] = dr["importe_unitario"];
                oDs.Tables["ArticulosMovDet"].Rows.Add(Dtr);
            }
        }

        public void ImprimirDetallesAsignacionMoviles(int idArticulos_mov, bool imprimirDirecto = true)
        {
            string ArchivoRDLC = @"C:\\GIES\\Reports\\ArticulosMovRDLC.rdlc";
           
            try
            {
                oDs.Clear();
                oDs.Tables["ArticulosMov"].Clear();
                DatosArticulosMov(idArticulos_mov);
                oDs.Tables["ArticulosMovDet"].Clear();
                DatosArticulosMovDet(idArticulos_mov);
                if (oDs.Tables["empresa"].Rows.Count == 0)
                    DatosDeLaEmpresa();

                ReportDataSource[] oRDS = new ReportDataSource[3];
                oRDS[0] = new ReportDataSource("ArticulosMov", oDs.Tables["ArticulosMov"]);
                oRDS[1] = new ReportDataSource("ArticulosMovDet", oDs.Tables["ArticulosMovDet"]);
                oRDS[2] = new ReportDataSource("Empresa", oDs.Tables["Empresa"]);

                if (!imprimirDirecto)
                {
                    frmReportViewerRDLC frmImp = new frmReportViewerRDLC();

                    frmImp.SetearReportViewerPorDataSet(ArchivoRDLC, oRDS);
                    frmImp.ShowDialog();
                }
                else
                {
                    LocalReport localReport = new LocalReport();
                    localReport.ReportEmbeddedResource = ArchivoRDLC;
                    localReport.DataSources.Clear();
                    for (int i = 0; i < oRDS.Length; i++)
                        localReport.DataSources.Add(oRDS[i]);
                    localReport.Refresh();

                    PrinterSettings ps = new PrinterSettings();
                    PaperSource oPaperSource = new PaperSource();

                    oPaperSource.RawKind = 1;
                    ps.PrinterName = /*"Brother HL-2130 series";*/"Microsoft Print to PDF";// this.DatosImpresion(Personal.Id_Punto_Login, 9)["impresora"].ToString();
                    ps.DefaultPageSettings.PaperSource = oPaperSource;

                    ImprimirDirecto(localReport, ps, MEDIDAS_HOJAS.A4, marginMM: 0);
                }
            }
            catch (Exception ex)
            { 
                throw ex;
            }
        }

        public void ImprimeArticulo(DataTable dtArticulo, string ImporteTotal, bool imprimirDirecto = true)
        {
            string ArchivoRDLC = "CapaPresentacion.Impresiones.ReportesRDLC.rptStockArticulos.rdlc";

            //try
            //{
            oDs.Clear();
            oDs.Tables["Articulos"].Clear();
            foreach (DataRow dr in dtArticulo.Rows)
            {
                Dtr = oDs.Tables["Articulos"].NewRow();
                Dtr["id"] = dr["Id"];
                Dtr["Descripcion"] = dr["Descripcion"];
                Dtr["Stock"] = dr["Stock"];
                Dtr["Stock_Minimo"] = dr["Stock_Minimo"];
                Dtr["Importe"] = dr["Importe"];
                Dtr["Importe_Total"] = dr["Importe_Total"];

                oDs.Tables["Articulos"].Rows.Add(Dtr);


            }
            Dtr["Total"] = ImporteTotal;


            if (oDs.Tables["empresa"].Rows.Count == 0)
                DatosDeLaEmpresa();

            ReportDataSource[] oRDS = new ReportDataSource[2];
            oRDS[0] = new ReportDataSource("Articulos", oDs.Tables["Articulos"]);
            oRDS[1] = new ReportDataSource("Empresa", oDs.Tables["Empresa"]);


            frmReportViewerRDLC frmImp = new frmReportViewerRDLC();

            frmImp.SetearReportViewerPorDataSet(ArchivoRDLC, oRDS);
            frmImp.ShowDialog();


            //}
            //catch (Exception)
            //{

            //    MessageBox.Show("Error en la impresion");
            //}
        }

        public void ImprimirListadoDebitos(DataTable dt, DateTime fecha)
        {
            oDs.Tables["ListadoPresDeb"].Clear();
            foreach (DataRow item in dt.Rows)
            {
                if (Convert.ToInt32(item["tipo_fila"]) == 0)
                {
                    DataRow drNuevo = oDs.Tables["ListadoPresDeb"].NewRow();
                    if (Convert.ToDecimal(item["importe_provincial"]) == 0)
                        drNuevo["cod_abonado"] = item["codigo_usuario"].ToString();
                    else
                        drNuevo["cod_abonado"] = item["codigo_usuario"].ToString() + "    RI";

                    drNuevo["abonado"] = item["usuario"].ToString();
                    drNuevo["importe"] = item["importe_con_descuento"].ToString();
                    drNuevo["num_plastico"] = item["numero_plastico"].ToString();
                    drNuevo["fecha_inicio"] = "";
                    oDs.Tables["ListadoPresDeb"].Rows.Add(drNuevo);
                }
            }
            string ArchivoRDLC = @"C:\\GIES\\Reports\\ListadoPresentacionDeb.rdlc";

            frmReportViewerRDLC oVisor = new frmReportViewerRDLC();
            oVisor.reportViewer1.LocalReport.ReportPath = ArchivoRDLC;
            oVisor.reportViewer1.LocalReport.DataSources.Clear();

            ReportDataSource[] oRDS = new ReportDataSource[6];
            oRDS[0] = new ReportDataSource("listado", oDs.Tables["ListadoPresDeb"]);

            oVisor.reportViewer1.LocalReport.DataSources.Add(oRDS[0]);
            oVisor.ShowDialog();
        }

        public void ImprimirEstadoCta(DataTable dt, string usuario, string saldo)
        {
            oDs.Tables["EstadoCtacte"].Clear();
            foreach (DataRow item in dt.Rows)
            {

                DataRow drNuevo = oDs.Tables["EstadoCtaCte"].NewRow();
                drNuevo["fecha"] = item["fecha_movimiento"].ToString();
                drNuevo["usuario"] = usuario;
                drNuevo["descripcion"] = item["descripcion"].ToString();
                drNuevo["debe"] = item["debe"].ToString();
                drNuevo["haber"] = item["haber"].ToString();
                drNuevo["fecha_hoy"] = DateTime.Now.ToString();
                drNuevo["saldo"] = saldo;
                oDs.Tables["EstadoCtaCte"].Rows.Add(drNuevo);
            }
            string ArchivoRDLC = @"C:\\GIES\\Reports\\ListadoDebeHaber.rdlc";

            frmReportViewerRDLC oVisor = new frmReportViewerRDLC();
            oVisor.reportViewer1.LocalReport.ReportPath = ArchivoRDLC;
            oVisor.reportViewer1.LocalReport.DataSources.Clear();

            ReportDataSource[] oRDS = new ReportDataSource[6];
            oRDS[0] = new ReportDataSource("estadoctacte", oDs.Tables["EstadoCtaCte"]);

            oVisor.reportViewer1.LocalReport.DataSources.Add(oRDS[0]);
            oVisor.ShowDialog();
        }

        public void ImprimirAviso(DataTable dtAvisos,bool exportar = false,string ruta="")
        {
            if(dtAvisos.Rows.Count>0)
            {
                string imprsora = "";
                PrintDialog oPrint = new PrintDialog();
                if (oPrint.ShowDialog() == DialogResult.OK)
                {
                    imprsora = oPrint.PrinterSettings.PrinterName;
                }
                rptAvisos oRptAviso = new rptAvisos();
                DataRow dr;
                oDs.Tables["Avisos"].Clear();
                foreach (DataRow item in dtAvisos.Rows)
                {
                    dr = oDs.Tables["Avisos"].NewRow();
                    dr["Codigo"] = item["codigo"].ToString();
                    dr["Localidad"] = item["Localidad"].ToString();
                    dr["Calle"] = item["Calle"].ToString();
                    dr["Entre1"] = item["entre_calle_1"].ToString();
                    dr["Entre2"] = item["entre_calle_2"].ToString();
                    dr["Altura"] = "Altura: "  + item["altura"].ToString();
                    dr["Piso"] = "Piso: " + item["piso"].ToString();
                    dr["Depto"] = "Depto: " + item["depto"].ToString();
                    dr["Manzana"] = "Manzana: " + item["manzana"].ToString();
                    dr["Servicio"] = item["servicio"].ToString();
                    dr["obs"] = item["observacion"].ToString();
                    dr["Telefono"] = item["telefono"].ToString();
                    oDs.Tables["Avisos"].Rows.Add(dr);
                    if (exportar)
                    {
                        oRptAviso.SetDataSource(oDs);
                        oRptAviso.ExportToDisk(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat, ruta + "\\" + item["codigo"].ToString() + ".pdf");
                        oDs.Tables["Avisos"].Clear();
                    }
                }
                if(!exportar)
                {
                    PaperSize oPS = new PaperSize();
                    oPS.RawKind = (int)PaperKind.A4;
                    PrinterSettings ps = new PrinterSettings();
                    ps.PrinterName = imprsora;
                    ps.DefaultPageSettings.PaperSize = oPS;
                    oRptAviso.SetDataSource(oDs);
                    oRptAviso.PrintToPrinter(ps, ps.DefaultPageSettings, false);
                    oDs.Tables["Avisos"].Clear();
                }
            }
        }
   
        #region Metodos_Para_Impresion_Directa

        private static void ImprimirDirecto(LocalReport report, PrinterSettings printerSettings, MEDIDAS_HOJAS medidaHoja, int marginMM)
        {
            string medidaHojaAncho = string.Empty;
            string medidaHojaAlto = string.Empty;

            if (medidaHoja == MEDIDAS_HOJAS.A4)
            {
                medidaHojaAncho = "210mm";
                medidaHojaAlto = "297mm";
            }

            string deviceInfo =
             @"<DeviceInfo>
                <OutputFormat>EMF</OutputFormat>
                <PageWidth>" + medidaHojaAncho + "</PageWidth>" +
                "<PageHeight>" + medidaHojaAlto + "</PageHeight>" +
                $"<MarginTop>{marginMM}mm</MarginTop>" +
                $"<MarginLeft>{marginMM}mm</MarginLeft>" +
                $"<MarginRight>{marginMM}mm</MarginRight>" +
                $"<MarginBottom>{marginMM}mm</MarginBottom>" +
            "</DeviceInfo>";

            Warning[] warnings;
            m_streams = new List<Stream>();
            report.Render("Image", deviceInfo, CreateStream, out warnings);
            foreach (Stream stream in m_streams)
                stream.Position = 0;

            Print(printerSettings);
        }

        private static void Print(PrinterSettings printSettings)
        {
            if (m_streams == null || m_streams.Count == 0)
                throw new Exception("Error: no stream to print.");
            PrintDocument printDoc = new PrintDocument();
            if (!String.IsNullOrEmpty(printSettings.PrinterName))
                printDoc.PrinterSettings = printSettings;
            if (!printDoc.PrinterSettings.IsValid)
            {
                throw new Exception("Error al encontrar la impresora establecida.");
            }
            else
            {
                printDoc.PrintPage += new PrintPageEventHandler(PrintPage);
                m_currentPageIndex = 0;
                printDoc.Print();
            }
        }

        private static Stream CreateStream(string name, string fileNameExtension, Encoding encoding, string mimeType, bool willSeek)
        {
            Stream stream = new MemoryStream();
            m_streams.Add(stream);
            return stream;
        }

        private static void PrintPage(object sender, PrintPageEventArgs ev)
        {
            Metafile pageImage = new
               Metafile(m_streams[m_currentPageIndex]);

            Rectangle adjustedRect = new Rectangle(
                ev.PageBounds.Left - (int)ev.PageSettings.HardMarginX,
                ev.PageBounds.Top - (int)ev.PageSettings.HardMarginY,
                ev.PageBounds.Width,
                ev.PageBounds.Height);

            ev.Graphics.FillRectangle(Brushes.White, adjustedRect);

            ev.Graphics.DrawImage(pageImage, adjustedRect);

            m_currentPageIndex++;
            ev.HasMorePages = (m_currentPageIndex < m_streams.Count);
        }

        private static void DisposePrint()
        {
            if (m_streams != null)
            {
                foreach (Stream stream in m_streams)
                    stream.Close();
                m_streams = null;
            }
        }

        #endregion
        #region CONTRATOS
        public void ImprimirContratoTemporario(Int32 IdUsuario, Decimal importe, DateTime Fecha)
        {
            frmReportViewer frm = new frmReportViewer();
            frm.oViewer.ReportSource = null;

            rptContratoServTemp rptContrato = new rptContratoServTemp();
            rptContrato.SetParameterValue("Nro", "000000001");
            rptContrato.SetParameterValue("Abonado", String.Format("{0}, {1}", Usuarios.CurrentUsuario.Apellido.ToString(), Usuarios.CurrentUsuario.Nombre.ToString()));
            rptContrato.SetParameterValue("AbonadoNro", Usuarios.CurrentUsuario.Codigo.ToString());
            rptContrato.SetParameterValue("Calle", Usuarios.CurrentUsuario.Calle.ToString());
            rptContrato.SetParameterValue("CalleNro", Usuarios.CurrentUsuario.Altura.ToString());
            rptContrato.SetParameterValue("CallePiso", Usuarios.CurrentUsuario.piso.ToString());
            rptContrato.SetParameterValue("CalleDpto", Usuarios.CurrentUsuario.Depto.ToString());
            rptContrato.SetParameterValue("Localidad", Usuarios.CurrentUsuario.localidad.ToString());
            rptContrato.SetParameterValue("CalleManzana", "");
            rptContrato.SetParameterValue("CalleEntre", Usuarios.CurrentUsuario.Entre1.ToString());
            rptContrato.SetParameterValue("CalleY", Usuarios.CurrentUsuario.Entre2.ToString());
            rptContrato.SetParameterValue("Unidades", "1");
            rptContrato.SetParameterValue("FechaFactura", Fecha.Date.ToShortDateString());
            rptContrato.SetParameterValue("Importe", importe.ToString());

            frm.oViewer.ReportSource = rptContrato;
            frm.ShowDialog();
            rptContrato.Dispose();
            frm.oViewer.Dispose();
        }
        public void ImprimirContratoDebitoAut(String Titular, String TarjetaNro, String FechaVto, Int32 IdTarjeta, String FechaInicio, String Servicios)
        {
            frmReportViewer frm = new frmReportViewer();
            frm.oViewer.ReportSource = null;

            Plasticos_Usuarios oPlasticosUsuarios = new Plasticos_Usuarios();

            DataTable DtPlasticosUsuarios = oPlasticosUsuarios.Listar(IdTarjeta, 0);

            DataView view = new DataView(DtPlasticosUsuarios);
            DataTable distinctValues = new DataTable();
            distinctValues = view.ToTable(true, "codigo", "usuario");

            string codigoUsuarios = "";
            string nombreUsuarios = "";

            foreach (DataRow dr in distinctValues.Rows)
            {
                codigoUsuarios = codigoUsuarios + dr["Codigo"].ToString() + " ";
                nombreUsuarios = nombreUsuarios + dr["Usuario"].ToString() + " ";
            }


            rptContratoDebitoAut rptContrato = new rptContratoDebitoAut();
            // rptContrato.SetParameterValue("Abonado", String.Format("{0}, {1}", Usuarios.CurrentUsuario.Apellido.ToString(), Usuarios.CurrentUsuario.Nombre.ToString()));
            // rptContrato.SetParameterValue("AbonadoNro", Usuarios.CurrentUsuario.Codigo.ToString());

            rptContrato.SetParameterValue("Abonado", Titular);
            rptContrato.SetParameterValue("AbonadoNro", codigoUsuarios);
            rptContrato.SetParameterValue("TarjetaNro", TarjetaNro);
            rptContrato.SetParameterValue("TarjetaVto", Convert.ToDateTime(FechaVto).Date.ToShortDateString());
            rptContrato.SetParameterValue("Abonados", nombreUsuarios);
            rptContrato.SetParameterValue("Fecha_Inicio", FechaInicio);
            rptContrato.SetParameterValue("Servicios", Servicios);


            frm.oViewer.ReportSource = rptContrato;
            frm.ShowDialog();
            rptContrato.Dispose();
            frm.oViewer.Dispose();
        }
        public void ImprimeReportePropuestaDeAdhesionCable(int idUsuario, int idParte, int idLocacion)
        {
            string ArchivoRDLC = @"C:\\GIES\Reports\\PropuestaDeAdhesionCable.rdlc";

            oDs.Tables["Usuarios"].Clear();
            DatosDelUsuarioPorId(idUsuario);
            oDs.Tables["PartesDeTrabajo"].Clear();
            DatosDelParte(idParte);
            oDs.Tables["UsuarioLocacion"].Clear();
            DatosDeLocacion(idLocacion);

            ReportDataSource[] oRDS = new ReportDataSource[3];

            oRDS[0] = new ReportDataSource("Usuarios", oDs.Tables["Usuarios"]);
            oRDS[1] = new ReportDataSource("PartesDeTrabajo", oDs.Tables["PartesDeTrabajo"]);
            oRDS[2] = new ReportDataSource("UsuarioLocacion", oDs.Tables["UsuarioLocacion"]);

            frmRepViewRDLCNoPage frmImp = new frmRepViewRDLCNoPage();
            frmImp.reportViewer1.LocalReport.ReportPath = ArchivoRDLC;
            frmImp.reportViewer1.LocalReport.DataSources.Clear();
            foreach (ReportDataSource item in oRDS)
            {
                frmImp.reportViewer1.LocalReport.DataSources.Add(item);

            }
            frmImp.ShowDialog();

        }
        public void ImprimeReportePropuestaDeAdhesionInternet(int idUsuario, int idLocacion, int idParte)
        {
            string ArchivoRDLC = "C:\\GIES\\Reports\\PropuestaDeAdhesionInternet.rdlc";
            oDs.Tables["Usuarios"].Clear();
            DatosDelUsuarioPorId(idUsuario);
            oDs.Tables["UsuarioLocacion"].Clear();
            DatosDeLocacion(idLocacion);
            oDs.Tables["UsuarioServicio"].Clear();
            DatosUsuarioServicio(idLocacion);
            oDs.Tables["Equiposdelparte"].Clear();
            EquiposDelParte(idParte,false);

            ReportDataSource[] oRDS = new ReportDataSource[4];

            DataTable dtUs = oDs.Tables["Usuarios"];
            DataTable dtUsLoc = oDs.Tables["UsuarioLocacion"];
            DataTable dtUsServ = oDs.Tables["UsuarioServicio"];
            DataTable dtEquipos = oDs.Tables["Equiposdelparte"];

            oRDS[0] = new ReportDataSource("Usuarios", dtUs);
            oRDS[1] = new ReportDataSource("UsuarioLocacion", dtUsLoc);
            oRDS[2] = new ReportDataSource("UsuarioServicio", dtUsServ);
            oRDS[3] = new ReportDataSource("Equiposdelparte", dtEquipos);

            frmReportViewerRDLC frmImp = new frmReportViewerRDLC();
            frmImp.reportViewer1.LocalReport.ReportPath = ArchivoRDLC;
            frmImp.reportViewer1.LocalReport.DataSources.Clear();
            foreach (ReportDataSource item in oRDS)
                frmImp.reportViewer1.LocalReport.DataSources.Add(item);
            frmImp.ShowDialog();
        }
        public void ImprimeReportePropuestaDeAdhesionComplejoDepto(int id_usuario_locacion)
        {
            string ArchivoRDLC = @"C:\GIES\Reports\PropuestaDeAdhesionComplejoDeptos.rdlc";

            Usuarios_Locaciones oUsuLoc = new Usuarios_Locaciones().GetLocacion(id_usuario_locacion);

            string diaHoy = DateTime.Now.Day.ToString();
            string mesHoy = DateTime.Now.ToString("MMMM", CultureInfo.CreateSpecificCulture("es"));
            string anioHoy = DateTime.Now.Year.ToString();

            frmReportViewerRDLC frmImp = new frmReportViewerRDLC();

            List<ReportParameter> listaParametros = new List<ReportParameter>
            {
                new ReportParameter("CalleComplejos", oUsuLoc.Calle),
                new ReportParameter("AlturaComplejos", oUsuLoc.Altura.ToString()),
                new ReportParameter("Servicio", "COMPLEJO DEPTOS"),
                new ReportParameter("Dias", diaHoy),
                new ReportParameter("Mes", mesHoy),
                new ReportParameter("Anio", anioHoy)
            };

            frmImp.SetearReportViewerPorParametros(ArchivoRDLC, listaParametros);
            frmImp.ShowDialog();
        }
        public void imprimirContratoHotel(int idParte)
        {
            string nombreHotel = Usuarios.CurrentUsuario.Apellido + " " + Usuarios.CurrentUsuario.Nombre;
            DataRow dtDatosParte = oParte.TraerParteRow(idParte);
            string calle = dtDatosParte["calle"].ToString();
            string altura = dtDatosParte["altura"].ToString();
            string ArchivoRDLC = "C:\\GIES\\Reports\\PropuestaAdhesionHotel.rdlc";
            DateTime fechaProgramado = Convert.ToDateTime(dtDatosParte["fecha_programado"]);
            string cantDias = fechaProgramado.Day.ToString();
            string nombreMes = fechaProgramado.ToString("MMMM", CultureInfo.CreateSpecificCulture("es"));
            string mesAnio = fechaProgramado.Month.ToString("D2");

            frmReportViewerRDLC frmImp = new frmReportViewerRDLC();
            frmImp.reportViewer1.LocalReport.ReportPath = ArchivoRDLC;
            frmImp.reportViewer1.LocalReport.EnableExternalImages = true;
            ReportParameter rp = new ReportParameter("nombreHotel", nombreHotel);
            ReportParameter rp2 = new ReportParameter("nombreCalle", "calle " + calle);
            ReportParameter rp3 = new ReportParameter("alturaCalle", altura);
            ReportParameter rp4 = new ReportParameter("cantDias", cantDias);
            ReportParameter rp5 = new ReportParameter("nombreMes", nombreMes);
            ReportParameter rp6 = new ReportParameter("mesAnio", mesAnio);

            frmImp.reportViewer1.LocalReport.SetParameters(rp);
            frmImp.reportViewer1.LocalReport.SetParameters(rp2);
            frmImp.reportViewer1.LocalReport.SetParameters(rp3);
            frmImp.reportViewer1.LocalReport.SetParameters(rp4);
            frmImp.reportViewer1.LocalReport.SetParameters(rp5);
            frmImp.reportViewer1.LocalReport.SetParameters(rp6);

            frmImp.ShowDialog();
        }

        public void ImprimirAdhesionDigital(int id_usuario) {
            string ArchivoRDLC = "C:\\GIES\\Reports\\AdhesionDigital.rdlc";
            frmReportViewerRDLC frmImp = new frmReportViewerRDLC();
            frmImp.reportViewer1.LocalReport.ReportPath = ArchivoRDLC;
            frmImp.reportViewer1.LocalReport.EnableExternalImages = true;
            frmImp.ShowDialog();
        }

        public void ImprimirContratoVacaciones(int idParte)
        {
            string nombreAbonado = Usuarios.CurrentUsuario.Apellido + " " + Usuarios.CurrentUsuario.Nombre;
            DataRow dtDatosParte = oParte.TraerParteRow(idParte);
            string calle = dtDatosParte["calle"].ToString() + " Altura" + dtDatosParte["altura"].ToString();
            string ArchivoRDLC = "C:\\GIES\\Reports\\ContratoPlanVacacion.rdlc";
            string tel = Usuarios.CurrentUsuario.Prefijo_1.ToString() + " " + Usuarios.CurrentUsuario.Telefono_1.ToString();
            string email = Usuarios.CurrentUsuario.Correo_Electronico;
            string fecha = Usuarios.CurrentUsuario.Nacimiento.ToString("dd/MM/yyyy");
            string dni = Usuarios.CurrentUsuario.Numero_Documento.ToString();
            string modulo = "0";
            string manzana = "0";
            Usuarios_Servicios oUserSer = new Usuarios_Servicios();
            DataTable dtDatosUsuarioServicios = oUserSer.Traer_datos_usuarios_servicios(Convert.ToInt32(dtDatosParte["id_usuarios_servicios"]));
            string cantBocas = dtDatosUsuarioServicios.Rows[0]["cant_bocas_pac"].ToString();
            string fechaDesde = Convert.ToDateTime(dtDatosUsuarioServicios.Rows[0]["fecha_inicio"]).ToString("dd/MM/yyyy");
            string fechaHasta = Convert.ToDateTime(dtDatosUsuarioServicios.Rows[0]["fecha_factura"]).ToString("dd/MM/yyyy");
            string obs = dtDatosParte["observacion"].ToString();

            DateTime fechaProgramado = Convert.ToDateTime(dtDatosParte["fecha_programado"]);
            string cantDias = fechaProgramado.Day.ToString();
            string nombreMes = fechaProgramado.ToString("MMMM", CultureInfo.CreateSpecificCulture("es"));
            string anio = fechaProgramado.Year.ToString();

            frmReportViewerRDLC frmImp = new frmReportViewerRDLC();
            frmImp.reportViewer1.LocalReport.ReportPath = ArchivoRDLC;
            frmImp.reportViewer1.LocalReport.EnableExternalImages = true;
            //frmImp.SetearReportViewerPorParametros(ArchivoRDLC, new List<ReportParameter>());
            ReportParameter rp = new ReportParameter("nomAbonado", nombreAbonado);
            ReportParameter rp2 = new ReportParameter("dirAbonado", "calle " + calle);
            ReportParameter rp3 = new ReportParameter("telAbonado", tel);
            ReportParameter rp4 = new ReportParameter("emailAbonado", email);
            ReportParameter rp5 = new ReportParameter("nacAbonado", fecha);
            ReportParameter rp6 = new ReportParameter("dniAbonado", dni);
            ReportParameter rp7 = new ReportParameter("moduloAbonado", modulo);
            ReportParameter rp8 = new ReportParameter("manzanaAbonado", manzana);
            ReportParameter rp9 = new ReportParameter("bocasServicio", cantBocas);
            ReportParameter rp10 = new ReportParameter("periodoDesde", fechaDesde);
            ReportParameter rp11 = new ReportParameter("periodoHasta", fechaHasta);
            ReportParameter rp12 = new ReportParameter("observaciones", obs);
            ReportParameter rp13 = new ReportParameter("diaContrato", cantDias);
            ReportParameter rp14 = new ReportParameter("mesContrato", nombreMes);
            ReportParameter rp15 = new ReportParameter("anoContrato", anio);

            frmImp.reportViewer1.LocalReport.SetParameters(rp);
            frmImp.reportViewer1.LocalReport.SetParameters(rp2);
            frmImp.reportViewer1.LocalReport.SetParameters(rp3);
            frmImp.reportViewer1.LocalReport.SetParameters(rp4);
            frmImp.reportViewer1.LocalReport.SetParameters(rp5);
            frmImp.reportViewer1.LocalReport.SetParameters(rp6);
            frmImp.reportViewer1.LocalReport.SetParameters(rp7);
            frmImp.reportViewer1.LocalReport.SetParameters(rp8);
            frmImp.reportViewer1.LocalReport.SetParameters(rp9);
            frmImp.reportViewer1.LocalReport.SetParameters(rp10);
            frmImp.reportViewer1.LocalReport.SetParameters(rp11);
            frmImp.reportViewer1.LocalReport.SetParameters(rp12);
            frmImp.reportViewer1.LocalReport.SetParameters(rp13);
            frmImp.reportViewer1.LocalReport.SetParameters(rp14);
            frmImp.reportViewer1.LocalReport.SetParameters(rp15);



            frmImp.ShowDialog();
        }

        public void ImprimirContratoEdificios(int idParte)
        {
            Usuarios_Servicios oUsuServ = new Usuarios_Servicios();
            Usuarios oUsu = new Usuarios();

            string ArchivoRDLC = @"C:\GIES\Reports\PropuestaDeAdhesionEdificios.rdlc";

            DataRow dtDatosParte = oParte.TraerParteRow(idParte);
            DataTable dtUsuServ = oUsuServ.Traer_datos_usuarios_servicios(Convert.ToInt32(dtDatosParte["id_usuarios_servicios"]));
            DataRow drUsuario = oUsu.getDatos(Convert.ToInt32(dtDatosParte["id_usuarios"]));

            string diaHoy = Convert.ToDateTime(dtUsuServ.Rows[0]["fecha_inicio"]).Day.ToString();
            string mesHoy = Convert.ToDateTime(dtUsuServ.Rows[0]["fecha_inicio"]).ToString("MMMM", CultureInfo.CreateSpecificCulture("es"));
            string anioHoy = Convert.ToDateTime(dtUsuServ.Rows[0]["fecha_inicio"]).Year.ToString();

            frmReportViewerRDLC frmImp = new frmReportViewerRDLC();
            frmImp.reportViewer1.LocalReport.EnableExternalImages = true;
            frmImp.reportViewer1.LocalReport.ReportPath = ArchivoRDLC;

            ReportParameter rp = new ReportParameter("NombreApellido", $"{dtDatosParte["apellido"]}, {dtDatosParte["nombre"]} ");
            ReportParameter rp2 = new ReportParameter("Direccion", $"Calle: {dtDatosParte["calle"]} {dtDatosParte["altura"]} ");
            ReportParameter rp3 = new ReportParameter("Telefono", $"{dtDatosParte["telefono_1"].ToString()} ");
            ReportParameter rp4 = new ReportParameter("Piso", $"{dtDatosParte["piso"].ToString()} ");
            ReportParameter rp5 = new ReportParameter("Dto", $"{dtDatosParte["depto"].ToString()} ");
            ReportParameter rp6 = new ReportParameter("Email", $"{drUsuario["correo_electronico"].ToString()} ");
            ReportParameter rp7 = new ReportParameter("Observaciones", $"{dtDatosParte["observacion"].ToString()} ");
            ReportParameter rp8 = new ReportParameter("Dia", diaHoy);
            ReportParameter rp9 = new ReportParameter("Mes", mesHoy);
            ReportParameter rp10 = new ReportParameter("Anio", anioHoy);

            frmImp.reportViewer1.LocalReport.SetParameters(rp);
            frmImp.reportViewer1.LocalReport.SetParameters(rp2);
            frmImp.reportViewer1.LocalReport.SetParameters(rp3);
            frmImp.reportViewer1.LocalReport.SetParameters(rp4);
            frmImp.reportViewer1.LocalReport.SetParameters(rp5);
            frmImp.reportViewer1.LocalReport.SetParameters(rp6);
            frmImp.reportViewer1.LocalReport.SetParameters(rp7);
            frmImp.reportViewer1.LocalReport.SetParameters(rp8);
            frmImp.reportViewer1.LocalReport.SetParameters(rp9);
            frmImp.reportViewer1.LocalReport.SetParameters(rp10);
            frmImp.ShowDialog();
        }

        #endregion

        public void ImprimirAviso2(DataTable dtAvisos)
        {
            string ArchivoRDLC = "CapaPresentacion.Impresiones.ReportesRDLC.Avisos.rdlc";

            DataRow dr;
            oDs.Tables["Avisos"].Clear();
            foreach (DataRow row in dtAvisos.Rows)
            {
                dr = oDs.Tables["Avisos"].NewRow();
                dr["Usuario"] = row["usuario"].ToString();
                dr["Importe"] = row["importe"].ToString();
                dr["Codigo"] = row["Codigo"].ToString();
                dr["Localidad"] = row["Localidad"].ToString();
                dr["Calle"] = row["Calle"].ToString();
                dr["Entre1"] = row["entre_calle_1"].ToString();
                dr["Entre2"] = row["entre_calle_2"].ToString();
                dr["Altura"] = row["altura"].ToString();
                dr["Piso"] = row["piso"].ToString();
                dr["Depto"] = row["depto"].ToString();
                dr["Manzana"] = row["manzana"].ToString();
                dr["Servicio"] = row["servicio"].ToString();
                dr["obs"] = row["observacion"].ToString();
                dr["detalle"] = row["detalle"].ToString();
                dr["telefono"] = row["telefono"].ToString();
                oDs.Tables["Avisos"].Rows.Add(dr);
            }

            ReportDataSource[] oRDS = new ReportDataSource[1];
            oRDS[0] = new ReportDataSource("Avisos", oDs.Tables["Avisos"]);

            frmReportViewerRDLC frmImp = new frmReportViewerRDLC();
            frmImp.reportViewer1.LocalReport.DataSources.Add(oRDS[0]);
            frmImp.reportViewer1.LocalReport.ReportEmbeddedResource = ArchivoRDLC;
            frmImp.reportViewer1.LocalReport.EnableExternalImages = true;
            ReportParameter rp = new ReportParameter("ImagenPath", @"file:///C:\GIES\Reports\Logo.png");
            frmImp.reportViewer1.LocalReport.SetParameters(rp);

            frmImp.ShowDialog();
        }

        public void ImprimirPropuestaDigital(int idUsuario, int idUsuarioServicio, int idParte)
        {
            Usuarios_Servicios oUsuServ = new Usuarios_Servicios();
            Usuarios oUsu = new Usuarios();

            string ArchivoRDLC = @"C:\\GIES\Reports\\PropuestaAdhesionDigital.rdlc";

            string diaHoy = DateTime.Now.Day.ToString();
            string mesHoy = DateTime.Now.ToString("MMMM", CultureInfo.CreateSpecificCulture("es"));
            string anioHoy = DateTime.Now.Year.ToString();

            DataTable dtUsuServ = oUsuServ.Traer_datos_usuarios_servicios(idUsuarioServicio);
            DataRow drUsuario = oUsu.getDatos(idUsuario);

            Servicios_Tarifas oServTarifas = new Servicios_Tarifas();
            int idTarifaActual = oServTarifas.getTarifaId();
            int idCategoria = Convert.ToInt32(dtUsuServ.Rows[0]["id_servicios_categorias"]);
            decimal importe = new Servicios_Tarifas_Sub().getImporte(idTarifaActual, 8, 17, "S", idCategoria);
            DataTable dtParteEquipo = new Partes_Equipos().ListarPorParte(idParte);
            string equipo = "";
            string serie = "";
            if(dtParteEquipo.Rows.Count > 0)
            {
                equipo = dtParteEquipo.Rows[0]["tipo_equipo"].ToString();
                serie = dtParteEquipo.Rows[0]["serie"].ToString();
            }

            frmReportViewerRDLC frmImp = new frmReportViewerRDLC();
            frmImp.reportViewer1.LocalReport.ReportPath = ArchivoRDLC;
            frmImp.reportViewer1.LocalReport.EnableExternalImages = true;
            ReportParameter rp = new ReportParameter("NombreApellido", $"{drUsuario["apellido"]}, {drUsuario["nombre"]} ");
            ReportParameter rp2 = new ReportParameter("Codigo", $"{drUsuario["codigo"]}");
            ReportParameter rp3 = new ReportParameter("Direccion", $"Calle: {drUsuario["calle"]} {drUsuario["altura"]} ");
            ReportParameter rp4 = new ReportParameter("Telefono", $"{drUsuario["telefono_1"]}");
            string email = drUsuario["correo_electronico"].ToString() == "" ? "-" : drUsuario["correo_electronico"].ToString();
            ReportParameter rp5 = new ReportParameter("Email", email);
            ReportParameter rp6 = new ReportParameter("Modulo", "0");
            ReportParameter rp7 = new ReportParameter("Serie", serie);
            ReportParameter rp8 = new ReportParameter("Dia", diaHoy);
            ReportParameter rp9 = new ReportParameter("Mes", mesHoy);
            ReportParameter rp10 = new ReportParameter("Anio", anioHoy);
            ReportParameter rp11 = new ReportParameter("Dni", $"{drUsuario["numero_documento"]}");
            ReportParameter rp12 = new ReportParameter("DerechoHabilitacion", importe.ToString());
            ReportParameter rp13 = new ReportParameter("Modelo", equipo);

            frmImp.reportViewer1.LocalReport.SetParameters(rp);
            frmImp.reportViewer1.LocalReport.SetParameters(rp2);
            frmImp.reportViewer1.LocalReport.SetParameters(rp3);
            frmImp.reportViewer1.LocalReport.SetParameters(rp4);
            frmImp.reportViewer1.LocalReport.SetParameters(rp5);
            frmImp.reportViewer1.LocalReport.SetParameters(rp6);
            frmImp.reportViewer1.LocalReport.SetParameters(rp7);
            frmImp.reportViewer1.LocalReport.SetParameters(rp8);
            frmImp.reportViewer1.LocalReport.SetParameters(rp9);
            frmImp.reportViewer1.LocalReport.SetParameters(rp10);
            frmImp.reportViewer1.LocalReport.SetParameters(rp11);
            frmImp.reportViewer1.LocalReport.SetParameters(rp12);
            frmImp.reportViewer1.LocalReport.SetParameters(rp13);

            frmImp.ShowDialog();
        }

        public string Imprime_factura_RDLC(bool imprimirDirecto, int IdComprobante, Boolean exportar = false, string rutaSalida = "")
        {
            Ofacturacion.Id_Comprobantes = IdComprobante;
            DataTable dtIvaAlicuotas = Ofacturacion.ListarIvaAlicuotasDetalles();
            DataTable dtIva = Ofacturacion.ListarIvaVentas();

            if (Convert.ToInt32(dtIva.Rows[0]["id_modalidad_fact"]) != 3)
            {
                return Imprime_factura(IdComprobante, exportar, rutaSalida);
            }
            else
            {
                Usuarios oUsuario = new Usuarios().traerUsuario(Convert.ToInt32(dtIva.Rows[0]["Id_usuario"]));
                int documentoAfip = new Comprobantes_Iva().GetTipoDocumentoAfip(Convert.ToInt32(dtIva.Rows[0]["id_comprobantes_tipo"]));
                string compIva = new Comprobantes_Iva().Listar(Convert.ToInt32(dtIva.Rows[0]["id_comprobantes_iva"])).Rows[0]["Descripcion"].ToString();

                oDs.Clear();
                DatosDeLaEmpresa(Convert.ToInt32(dtIva.Rows[0]["id_comprobantes_tipo"]));

                DataRow Dtr;
                Dtr = oDs.Tables["Usuarios"].NewRow();
                if (Convert.ToInt32(dtIva.Rows[0]["id_usuarios_locacion"]) > 0)
                {
                    DataTable dtUsuLoc = new Usuarios_Locaciones().ListarDatosLocacion(Convert.ToInt32(dtIva.Rows[0]["id_usuarios_locacion"]));
                    Dtr["Usu_localidad"] = dtUsuLoc.Rows[0]["localidad"].ToString();
                    Dtr["Usu_calle"] = $"{dtUsuLoc.Rows[0]["Calle"].ToString()} NRO - {dtUsuLoc.Rows[0]["Altura"].ToString()} ({dtUsuLoc.Rows[0]["piso"].ToString()} {dtUsuLoc.Rows[0]["depto"].ToString()})";
                    Dtr["Usu_altura"] = dtUsuLoc.Rows[0]["altura"].ToString();
                    Dtr["Usu_piso"] = dtUsuLoc.Rows[0]["piso"].ToString();
                    Dtr["Usu_depto"] = dtUsuLoc.Rows[0]["depto"].ToString();
                    Dtr["Usu_entre_calle"] = !String.IsNullOrEmpty(dtUsuLoc.Rows[0]["entre_calle_1"].ToString()) ? dtUsuLoc.Rows[0]["entre_calle_1"].ToString().Trim() + " / " + dtUsuLoc.Rows[0]["entre_calle_2"].ToString().Trim() : "";
                    Dtr["Usu_y_calle"] = !String.IsNullOrEmpty(dtUsuLoc.Rows[0]["entre_calle_2"].ToString()) ? dtUsuLoc.Rows[0]["entre_calle_2"].ToString() : "";
                }
                else
                {
                    Dtr["Usu_localidad"] = Usuarios.CurrentUsuario.localidad != null ? Usuarios.CurrentUsuario.localidad.ToString().Trim() + " (" + Usuarios.CurrentUsuario.Cod_postal.ToString().Trim() + ")" : Usuarios.CurrentUsuarioDomFiscal.Localidad;
                    Dtr["Usu_calle"] = Usuarios.CurrentUsuario.Calle.Trim() + " NRO -" + Usuarios.CurrentUsuario.Altura.ToString().Trim() + "(" + Usuarios.CurrentUsuario.piso.Trim() + " " + Usuarios.CurrentUsuario.Depto.Trim() + ")";
                    Dtr["Usu_altura"] = Usuarios.CurrentUsuario.Altura;
                    Dtr["Usu_piso"] = Usuarios.CurrentUsuario.piso;
                    Dtr["Usu_depto"] = Usuarios.CurrentUsuario.Depto;
                    Dtr["Usu_entre_calle"] = Usuarios.CurrentUsuario.Entre1 != null ? Usuarios.CurrentUsuario.Entre1.Trim() + " / " + Usuarios.CurrentUsuario.Entre2.Trim() : "";
                    Dtr["Usu_y_calle"] = Usuarios.CurrentUsuario.Entre2 != null ? Usuarios.CurrentUsuario.Entre2 : "";
                }
                Dtr["Usu_apellido"] = $"{dtIva.Rows[0]["Razon_Social"].ToString()} [Abonado N° {oUsuario.Codigo}]";
                Dtr["Usu_codigo"] = oUsuario.Codigo;
                Dtr["Usu_nombre"] = dtIva.Rows[0]["Razon_Social"].ToString().Trim();
                Dtr["Usu_condicion_iva"] = compIva;
                Dtr["Usu_calle_fISCAL"] = $"{dtIva.Rows[0]["Calle"].ToString()} {dtIva.Rows[0]["Altura"].ToString()}";
                Dtr["usu_localidad_fiscal"] = dtIva.Rows[0]["Localidad"].ToString();
                Dtr["usu_razon_social"] = dtIva.Rows[0]["Razon_Social"].ToString();
                Dtr["Usu_dni_numero"] = dtIva.Rows[0]["Numero_Documento"].ToString();

                oDs.Tables["Usuarios"].Rows.Add(Dtr);

                string numFactura = "";
                string letraCom = "";
                string codigoAfip = "6";

                Decimal Iva5 = 0; //Es el 21 (5 es en la tabla de afip)
                Decimal Iva4 = 0; //Es el 10,5 (4 es en la tabla de afip)

                foreach (DataRow dr in dtIvaAlicuotas.Rows)
                {
                    if (Convert.ToInt32(dr["numero_afip"].ToString()) == 5)
                        Iva5 = Convert.ToDecimal(dr["importe_iva"].ToString());

                    if (Convert.ToInt32(dr["numero_afip"].ToString()) == 4)
                        Iva4 = Convert.ToDecimal(dr["importe_iva"].ToString());
                }

                String Tipocomprobante = "FACTURA";
                switch (Convert.ToInt32(dtIva.Rows[0]["id_comprobantes_tipo"]))
                {
                    case 1:
                        Tipocomprobante = "FACTURA";
                        codigoAfip = "1";
                        break;
                    case 2:
                        Tipocomprobante = "FACTURA";
                        codigoAfip = "6";
                        break;
                    case 3:
                        Tipocomprobante = "NOTA DE CREDITO";
                        codigoAfip = "3";
                        break;
                    case 4:
                        Tipocomprobante = "NOTA DE CREDITO";
                        codigoAfip = "8";
                        break;
                    case 6:
                        Tipocomprobante = "REMITO";
                        codigoAfip = "";
                        break;
                    case 13:
                        Tipocomprobante = "NOTA DE DEBITO";
                        codigoAfip = "2";
                        break;
                    case 14:
                        Tipocomprobante = "NOTA DE DEBITO";
                        codigoAfip = "7";
                        break;
                    case 16:
                        Tipocomprobante = "FACTURA DE CRÉDITO ELECTRÓNICA MiPyME (FCE)";
                        codigoAfip = "201";
                        break;
                    case 17:
                        Tipocomprobante = "NOTA DE CREDITO ELECTRÓNICA MiPyMEs (FCE)";
                        codigoAfip = "203";
                        break;
                    default:
                        Tipocomprobante = "FACTURA";
                        break;
                }

                try
                {
                    DataRow drCom;
                    drCom = oDs.Tables["Comprobantes"].NewRow();
                    drCom["comp_descripcion"] = Tipocomprobante;
                    drCom["comp_letra"] = Convert.ToInt32(dtIva.Rows[0]["id_comprobantes_tipo"]) == 6 ? "X" : dtIva.Rows[0]["letra"].ToString();
                    drCom["comp_codigo_afip"] = String.Format("Codigo Nro {0}", codigoAfip);
                    drCom["comp_cae"] = dtIva.Rows[0]["cae"].ToString();
                    drCom["comp_fecha"] = Convert.ToDateTime(dtIva.Rows[0]["fecha"].ToString()).ToShortDateString();
                    drCom["comp_numero"] = dtIva.Rows[0]["punto_venta"].ToString().PadLeft(4, '0') + "-" + dtIva.Rows[0]["numero"].ToString().PadLeft(8, '0');
                    drCom["comp_importe1"] = string.Format("{0:C}", (Convert.ToDecimal(dtIva.Rows[0]["Importe_final"].ToString())));
                    drCom["Comp_Imp_Provincia1"] = string.Format("{0:C}", (Convert.ToDecimal(dtIva.Rows[0]["Importe_impuesto_provincial"].ToString())));
                    drCom["comp_importe_subtotal"] = Convert.ToDecimal(dtIva.Rows[0]["Importe_neto"].ToString());
                    drCom["comp_cae_venvimiento"] = Convert.ToDateTime(dtIva.Rows[0]["fecha"].ToString()).AddDays(10).ToShortDateString();
                    drCom["comp_iva1"] = Iva5;
                    drCom["comp_iva2"] = Iva4;
                    oDs.Tables["comprobantes"].Rows.Add(drCom);
                    letraCom = Convert.ToInt32(dtIva.Rows[0]["id_comprobantes_tipo"]) == 6 ? "X" : dtIva.Rows[0]["letra"].ToString();
                    numFactura = Tipocomprobante + " " + letraCom + " " + dtIva.Rows[0]["punto_venta"].ToString().PadLeft(4, '0') + "-" + dtIva.Rows[0]["numero"].ToString().PadLeft(8, '0');
                }
                catch { }

                DataTable dt = Ofacturacion.ListarDetalle();
                foreach (DataRow dr in dt.Rows)
                {
                    DataRow drdet;
                    drdet = oDs.Tables["Comprobantes_Det"].NewRow();
                    drdet["comp_det_descripcion"] = dr["Descripcion"].ToString().ToUpper();

                    if (dr["Descripcion_adicional"].ToString().Trim() == "S")
                        drdet["comp_det_hasta"] = "SubTotal";

                    else
                    {
                        drdet["comp_det_desde"] = Convert.ToDateTime(dr["desde"].ToString()).ToShortDateString();
                        drdet["comp_det_hasta"] = Convert.ToDateTime(dr["hasta"].ToString()).ToShortDateString();
                    }

                    drdet["comp_det_unitario"] = decimal.Round(Convert.ToDecimal(dr["total"].ToString()), 2);
                    drdet["comp_det_total"] = decimal.Round(Convert.ToDecimal(dr["total"].ToString()), 2);
                    drdet["comp_det_punitorios"] = decimal.Round(Convert.ToDecimal(dr["punitorios"].ToString()), 2);
                    drdet["comp_det_bonificaciones"] = decimal.Round(decimal.Multiply(Convert.ToDecimal(dr["bonificaciones"].ToString()), -1), 2);
                    oDs.Tables["Comprobantes_Det"].Rows.Add(drdet);
                }

                //string ArchivoRDLC = @"CapaPresentacion.Impresiones.ReportesRDLC.Factura.rdlc";
                string ArchivoRDLC = @"C:\\GIES\\Reports\\Factura.rdlc";

                ReportDataSource[] oRDS = new ReportDataSource[5];
                oRDS[0] = new ReportDataSource("Empresa", oDs.Tables["Empresa"]);
                oRDS[1] = new ReportDataSource("Usuarios", oDs.Tables["Usuarios"]);
                oRDS[2] = new ReportDataSource("Comprobantes", oDs.Tables["Comprobantes"]);
                oRDS[3] = new ReportDataSource("Comprobantes_Det", oDs.Tables["Comprobantes_Det"]);

                string url = "";

                if (Convert.ToInt32(dtIva.Rows[0]["id_comprobantes_tipo"]) != Convert.ToInt32(Comprobantes_Tipo.Tipo.REMITO))
                {
                    var oAfip = new JsonAfip()
                    {
                        ver = 1,
                        fecha = DateTime.Now.Date/*.ToString("yyyy/MM/dd")*/,
                        cuit = Convert.ToInt64(oDs.Tables["Empresa"].Rows[0]["Emp_Cuit"]),
                        ptoVta = Convert.ToInt32(dtIva.Rows[0]["punto_venta"]),
                        tipoCmp = Convert.ToInt32(codigoAfip),
                        nroCmp = Convert.ToInt32(dtIva.Rows[0]["numero"]),
                        importe = Math.Round(Convert.ToDecimal(dtIva.Rows[0]["Importe_final"].ToString()), 2),
                        moneda = "PES",
                        ctz = 1,
                        tipoDocRec = documentoAfip,
                        nroDocRec = (documentoAfip == 96) ? Convert.ToInt64(Usuarios.CurrentUsuario.Numero_Documento) : Convert.ToInt64(Usuarios.CurrentUsuarioDomFiscal.Cuit),
                        tipoCodAut = "E",
                        codAut = Convert.ToInt64(dtIva.Rows[0]["cae"])
                    };
                    var json = new Json<JsonAfip>(oAfip);
                    string objBase64 = json.GetJsonEnBase64();
                    url = $"{AfipUrl}?=p{objBase64}";

                    Iva_Ventas_Qr oIvaVentaQr = new Iva_Ventas_Qr();
                    oIvaVentaQr.Id_Iva_Ventas = Convert.ToInt32(dtIva.Rows[0]["id"]);
                    oIvaVentaQr.Texto = objBase64;
                    oIvaVentaQr.Guardar(oIvaVentaQr);
                }

                ReportParameter rp = new ReportParameter("ImagenPath", @"file:///C:\GIES\Reports\Logo.png");

                if (!exportar)
                {
                    if (imprimirDirecto)
                    {
                        LocalReport localReport = new LocalReport();
                        localReport.ReportPath = ArchivoRDLC;
                        localReport.DataSources.Clear();

                        oRDS[4] = GetReportDataSourceCodigoQR(url, localReport);

                        localReport.SetParameters(rp);
                        localReport.DataSources.Add(oRDS[0]);
                        localReport.DataSources.Add(oRDS[1]);
                        localReport.DataSources.Add(oRDS[2]);
                        localReport.DataSources.Add(oRDS[3]);
                        localReport.DataSources.Add(oRDS[4]);
                        localReport.Refresh();

                        PrinterSettings ps = new PrinterSettings();
                        PaperSource oPaperSource = new PaperSource();

                        oPaperSource.RawKind = 1;
                        if (Debugger.IsAttached)
                            ps.PrinterName = "Microsoft Print to PDF";
                        else
                        {
                            try
                            {
                                ps.PrinterName = this.DatosImpresion(Personal.Id_Punto_Cobro_Predeterminado, Convert.ToInt32(dtIva.Rows[0]["id_comprobantes_tipo"]))["impresora"].ToString();
                            }
                            catch (ExcepcionImpresoraNoEncontrada)
                            {
                                PrintDialog printDialog = new PrintDialog();
                                printDialog.ShowDialog();
                                ps = printDialog.PrinterSettings;
                            }
                        }

                        ps.DefaultPageSettings.PaperSource = oPaperSource;

                        ImprimirDirecto(localReport, ps, MEDIDAS_HOJAS.A4, marginMM: 5);
                    }
                    else
                    {
                        frmReportViewerRDLC oVisor = new frmReportViewerRDLC();
                        //oVisor.reportViewer1.LocalReport.ReportEmbeddedResource = ArchivoRDLC;
                        oVisor.reportViewer1.LocalReport.ReportPath = ArchivoRDLC;
                        oVisor.reportViewer1.LocalReport.DataSources.Clear();
                        oVisor.reportViewer1.RefreshReport();

                        oRDS[4] = GetReportDataSourceCodigoQR(url, oVisor.reportViewer1.LocalReport);

                        oVisor.reportViewer1.LocalReport.SetParameters(rp);
                        oVisor.reportViewer1.LocalReport.DataSources.Add(oRDS[0]);
                        oVisor.reportViewer1.LocalReport.DataSources.Add(oRDS[1]);
                        oVisor.reportViewer1.LocalReport.DataSources.Add(oRDS[2]);
                        oVisor.reportViewer1.LocalReport.DataSources.Add(oRDS[3]);
                        oVisor.reportViewer1.LocalReport.DataSources.Add(oRDS[4]);
                        oVisor.ShowDialog();
                    }

                    return "";
                }
                else
                {
                    LocalReport localReport = new LocalReport();
                    localReport.ReportPath = ArchivoRDLC;
                    localReport.DataSources.Clear();

                    oRDS[4] = GetReportDataSourceCodigoQR(url, localReport);

                    localReport.SetParameters(rp);
                    localReport.DataSources.Add(oRDS[0]);
                    localReport.DataSources.Add(oRDS[1]);
                    localReport.DataSources.Add(oRDS[2]);
                    localReport.DataSources.Add(oRDS[3]);
                    localReport.DataSources.Add(oRDS[4]);

                    Byte[] arrayByte = localReport.Render("PDF");

                    using (FileStream fs = File.Create($"{rutaSalida}\\{numFactura}.pdf"))
                    {
                        fs.Write(arrayByte, 0, arrayByte.Length);
                    }

                    return $"{numFactura}.pdf";
                }
            }
        }

        public ReportDataSource GetReportDataSourceCodigoQR(string info, LocalReport localReport)
        {
            localReport.EnableExternalImages = true;

            QRCodeGenerator qrCodeGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrCodeGenerator.CreateQrCode(info, QRCodeGenerator.ECCLevel.L);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap bitmap = qrCode.GetGraphic(20);
            using (MemoryStream ms = new MemoryStream())
            {
                bitmap.Save(ms, ImageFormat.Bmp);
                oDs.Tables["CodigoQR"].Clear();
                dsInformes.CodigoQRRow codRow = oDs.CodigoQR.NewCodigoQRRow();
                codRow.Imagen = ms.ToArray();
                oDs.CodigoQR.AddCodigoQRRow(codRow);
                ReportDataSource reportDataSource = new ReportDataSource("CodigoQR");
                reportDataSource.Value = oDs.CodigoQR;
                return reportDataSource;
            }
        }

        public void ImprimirCierreGeneralPuntos(int idCajaGeneral)
        {
            string ArchivoRDLC = @"C:\\GIES\\Reports\\CajaGeneral.rdlc";
            Caja_general oCaja = new Caja_general();
            DataTable dt = new DataTable();
            DataTable dtDatosCajaGeneral = new DataTable();
            DataTable dtFormasPago = new DataTable();
            dtDatosCajaGeneral = oCaja.Listar(idCajaGeneral);
            dtFormasPago = oCaja.ListarFormaPago(idCajaGeneral);
            DateTime fecha = Convert.ToDateTime(dtDatosCajaGeneral.Rows[0]["fecha"]);
            decimal totalA=0, totalB=0, total=0;
            decimal TotalFormaPago = 0;
            dt = oCaja.ListarDiscriminadoPuntos(idCajaGeneral);
            DataTable dtFinal = new DataTable();
            DataColumn dcNombre = new DataColumn();
            dcNombre.ColumnName = "nombre";
            dcNombre.DataType = typeof(string);
            DataColumn dcRendido = new DataColumn();
            dcRendido.ColumnName = "rendido";
            dcRendido.DataType = typeof(string);
            DataColumn dcRendidoVacio = new DataColumn();
            dcRendidoVacio.ColumnName = "rendido_vacio";
            dcRendidoVacio.DataType = typeof(string);
            DataColumn dcTotalGeneral = new DataColumn();
            dcTotalGeneral.ColumnName = "total_general";
            dcTotalGeneral.DataType = typeof(string);
            DataColumn dcTotalA = new DataColumn();
            dcTotalA.ColumnName = "total_a";
            dcTotalA.DataType = typeof(string);
            DataColumn dcTotalB = new DataColumn();
            dcTotalB.ColumnName = "total_b";
            dcTotalB.DataType = typeof(string);

            DataColumn dcTotalADecimal = new DataColumn();
            dcTotalADecimal.ColumnName = "total_a_d";
            dcTotalADecimal.DataType = typeof(decimal);
            DataColumn dcTotalBDecimal = new DataColumn();
            dcTotalBDecimal.ColumnName = "total_b_d";
            dcTotalBDecimal.DataType = typeof(decimal);

            dtFinal.Columns.Add(dcNombre);
            dtFinal.Columns.Add(dcRendido);
            dtFinal.Columns.Add(dcRendidoVacio);
            dtFinal.Columns.Add(dcTotalGeneral);
            dtFinal.Columns.Add(dcTotalA);
            dtFinal.Columns.Add(dcTotalB);
            dtFinal.Columns.Add(dcTotalADecimal);
            dtFinal.Columns.Add(dcTotalBDecimal);

            foreach (DataRow item in dt.Rows)
            {
                //------------- el primer new row es para los valores en blanco
                DataRow dr = dtFinal.NewRow();
                dr["nombre"] = item["descripcion"].ToString();
                dr["rendido"] = Convert.ToDecimal(item["Importe_cuenta1"]).ToString("c2");
                dr["rendido_vacio"] = "";
                dr["total_general"] = Convert.ToDecimal(item["Importe_cuenta1"]).ToString("c2");
                dr["total_a"] = "";
                dr["total_b"] = "";
                dr["total_a_d"] = Convert.ToDecimal(item["Importe_cuenta1"]);
                dr["total_b_d"] =0;


                dtFinal.Rows.Add(dr);

                //------------- el segundo new row es para los valores en negro
                DataRow drCuenta2 = dtFinal.NewRow();
                drCuenta2["nombre"] = "ESPECIALES";
                drCuenta2["rendido"] = Convert.ToDecimal(item["Importe_cuenta2"]).ToString("c2");
                drCuenta2["rendido_vacio"] = "";
                drCuenta2["total_general"] = Convert.ToDecimal(item["Importe_cuenta2"]).ToString("c2");
                drCuenta2["total_a"] = "";
                drCuenta2["total_b"] = "";
                drCuenta2["total_a_d"] = 0;
                drCuenta2["total_b_d"] = Convert.ToDecimal(item["Importe_cuenta2"]);

                dtFinal.Rows.Add(drCuenta2);


                //------------- el TERCER new row es para los totales
                Decimal totalGeneral = Convert.ToDecimal(item["Importe_cuenta1"]) + Convert.ToDecimal(item["Importe_cuenta2"]);
                DataRow drTotal = dtFinal.NewRow();
                drTotal["nombre"] = "";
                drTotal["rendido"] = "";
                drTotal["rendido_vacio"] = "TOTAL";
                drTotal["total_general"] = totalGeneral.ToString("c2");
                drTotal["total_a"] = Convert.ToDecimal(item["Importe_cuenta1"]).ToString("c2");
                drTotal["total_b"] = Convert.ToDecimal(item["Importe_cuenta2"]).ToString("c2");
                drTotal["total_a_d"] = 0;
                drTotal["total_b_d"] =0;

                dtFinal.Rows.Add(drTotal);

            }

            foreach (DataRow item in dtFinal.Rows)
            {
                DataRow drdet;
                drdet = oDs.Tables["CajaGeneralPuntos"].NewRow();
                drdet["nombre"] = item["nombre"];
                drdet["rendido"] = item["rendido"];
                drdet["rendidovacio"] = item["rendido_vacio"];
                drdet["totalgeneral"] = item["total_general"];
                drdet["totala"] = item["total_a"];
               
                drdet["totalb"] = item["total_b"];
                totalA = totalA + Convert.ToDecimal(item["total_a_d"]);
                totalB = totalB + Convert.ToDecimal(item["total_b_d"]);
                oDs.Tables["CajaGeneralPuntos"].Rows.Add(drdet);
            }
            // agrego el recumen de totales
            total = totalA + totalB;
            DataRow drTotales;
            drTotales = oDs.Tables["CajaGeneralPuntos"].NewRow();
            drTotales["nombre"] = "";
            drTotales["rendido"] = "";
            drTotales["rendidovacio"] = "TOTAL GRAL";
            drTotales["totalgeneral"] = total.ToString("c2");
            drTotales["totala"] = totalA.ToString("c2");
            drTotales["totalb"] = totalB.ToString("c2");
            oDs.Tables["CajaGeneralPuntos"].Rows.Add(drTotales);

            foreach (DataRow formaPago in dtFormasPago.Rows)
            {
                DataRow drForma;
                drForma = oDs.Tables["FormasDePago"].NewRow();
                drForma["forma_pago"] = formaPago["forma"].ToString().ToUpper();
                drForma["monto"] = Convert.ToDecimal(formaPago["importe"]).ToString("c2");
                if (formaPago["forma"].ToString().ToUpper() != "GASTOS")
                    TotalFormaPago = TotalFormaPago + Convert.ToDecimal(formaPago["importe"]);

                oDs.Tables["FormasDePago"].Rows.Add(drForma);
            }

            DataRow drTotalForma;
            drTotalForma = oDs.Tables["FormasDePago"].NewRow();
            drTotalForma["forma_pago"] = "TOTAL";
            drTotalForma["monto"] = TotalFormaPago.ToString("c2");
            oDs.Tables["FormasDePago"].Rows.Add(drTotalForma);

            frmReportViewerRDLC oVisor = new frmReportViewerRDLC();
            oVisor.reportViewer1.LocalReport.ReportPath = ArchivoRDLC;
            var setup = oVisor.reportViewer1.GetPageSettings();
            setup.Margins = new System.Drawing.Printing.Margins(1, 1, 1, 1);
            oVisor.reportViewer1.SetPageSettings(setup);
            oVisor.reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource[] oRDS = new ReportDataSource[2];
            ReportParameter[] oRDSParametros = new ReportParameter[1];
            oRDS[0] = new ReportDataSource("CajaGeneralPuntos", oDs.Tables["CajaGeneralPuntos"]);
            oRDS[1] = new ReportDataSource("FormaPago", oDs.Tables["FormasDePago"]);
            oRDSParametros[0] = new ReportParameter("fecha", fecha.ToString("dd/MM/yyyy"),true);
            oVisor.reportViewer1.LocalReport.DataSources.Add(oRDS[0]);
            oVisor.reportViewer1.LocalReport.DataSources.Add(oRDS[1]);
            oVisor.reportViewer1.LocalReport.SetParameters(oRDSParametros[0]);
            oVisor.reportViewer1.RefreshReport();
            oVisor.ShowDialog();
        }
    }

    class ExcepcionImpresoraNoEncontrada : Exception
    {
        public ExcepcionImpresoraNoEncontrada() : base() { }
        public ExcepcionImpresoraNoEncontrada(string message) : base(message) { }
        public ExcepcionImpresoraNoEncontrada(string message, Exception innerException)
            : base(message, innerException) { }
    }
    
}
