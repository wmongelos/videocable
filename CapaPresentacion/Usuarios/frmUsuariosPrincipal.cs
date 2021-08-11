using CapaNegocios;
using CapaPresentacion.Abms;
using CapaPresentacion.Busquedas;
using CapaPresentacion.Controles;
using CapaPresentacion.Herramientas;
using CapaPresentacion.Inventario;
using CapaPresentacion.Partes_Trabajo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;


namespace CapaPresentacion
{
    public partial class frmUsuariosPrincipal : Form
    {
        private Usuarios oUsu = new Usuarios();
        private Usuarios_Servicios_Novedades oNovedades = new Usuarios_Servicios_Novedades();
        private Partes oPartes = new Partes();
        private Usuarios_Locaciones oUsuLoc = new Usuarios_Locaciones();
        private Usuarios_CtaCte oUsuCtaCte = new Usuarios_CtaCte();
        private Servicios oServicios = new Servicios();
        private Usuarios_Servicios oUsuariosServicios = new Usuarios_Servicios();
        private Presentacion_Debitos oPresentacionDebitos = new Presentacion_Debitos();
        private Equipos oEquipo = new Equipos();
        private Equipos_Tarjetas oEquipoTarjeta = new Equipos_Tarjetas();
        private bool trabajaIsp = false;
        private DataTable dtLocaciones;
        private DataTable dtDebitos = new DataTable();
        private DataTable dtEquipos_Tarjetas = new DataTable();
        int id_usu;
        private DataTable dtServiciosContratados = new DataTable();
        private DataTable dtEstados = new DataTable();
        private Thread hilo;
        private delegate void myDel();
        frmPopUp frmP = new frmPopUp();
        private static frmUsuariosPrincipal aForm = null;
        private int idUsuarioServicio = 0, respuesta = 0, idLocacionPadre, idUsuarioPadre, idUsuarioServicioPadre, indice;
        Boolean NovedadesActivas = false;
        Boolean ObservacionesActivas = false;
        Boolean Partes_Abiertos = false;
        Boolean cargado = false;
        private Notificaciones_Destinatarios oNotificacionesDestinatarios = new Notificaciones_Destinatarios();

        public Dictionary<boton, bool> permisoBotones = new Dictionary<boton, bool>();
        private bool GrillaCompleta;

        #region[METODOS CREADOS]

        public void comenzarCarga()
        {
            dgvLocaciones.DataSource = null;
            dgvServiciosActivos.DataSource = null;
            txtbusca.Text = "";

            MostrarCarga();

            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.Start();
        }
        private static int ReadTmpFile(string archivo)
        {
            try
            {
                // Read from the temp file.
                int codigo2;
                string ff = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile);
                string fileName = ff + archivo;
                StreamReader myReader = File.OpenText(fileName);
                codigo2 = Convert.ToInt32(myReader.ReadToEnd());
                myReader.Close();
                File.WriteAllText(fileName, String.Empty);
                return codigo2;
            }
            catch (Exception ex)
            {
                return -1;
            }
        }
        private void cargarDatos()
        {

            int codigoUsuarioError = ReadTmpFile(@"\\gies.txt");
            if (codigoUsuarioError > 0)
            {
                oUsu.LlenarObjeto(codigoUsuarioError);
            }
            try
            {
                dtEstados = Tablas.DataServicios_Estados;

                Partes_Abiertos = false;
                respuesta = oNotificacionesDestinatarios.ControlarNotificacionesActivas(Personal.Id_Login, Personal.Id_Area, Puntos_Cobros.Id_Punto);


                if (Usuarios.CurrentUsuario.Id > 0)
                {
                    try
                    {
                        dtServiciosContratados = oUsuariosServicios.ListarServiciosYSubServiciosActivos(Usuarios.CurrentUsuario.Id);
                        Usuarios.Current_dtServicios = dtServiciosContratados;
                        //ordeno los servicios y sub
                        DataView dv = new DataView(dtServiciosContratados);
                        dv.Sort = "id_usuario_servicio, id_Tipo";
                        dtServiciosContratados = dv.ToTable();
                        dtLocaciones = oUsuLoc.ListarLocacionesServicio(Usuarios.CurrentUsuario.Id, 0, true);

                        NovedadesActivas = oNovedades.HayNovedades(Usuarios.CurrentUsuario.Id);

                        Partes_Abiertos = oPartes.ContarPartesPorEstado(Usuarios.CurrentUsuario.Id, (int)Partes.Partes_Estados.REALIZADO, (int)Partes.Partes_Estados.ANULADO);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al cargar Informacion 1" + ex.Message);
                    }
                }


                myDel MD = new myDel(AsignarDatos);
                this.Invoke(MD, new object[] { });
                pgCircular.Stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Información" + ex.Message);
            }


        }

        private void MostrarCarga()
        {
            pnlCargando2.Show();
            foreach (Control item in this.Controls)
            {
                if (item.Name != "pgCircular2")
                {
                    if (item.Name != "pnlTitulo")
                        item.Enabled = false;
                }
            }
            pgCircular2.Start();
        }

        private void AsignarDatos()
        {

            if (Usuarios.CurrentUsuario.Id != 0)
                PonerDatosUsuarios();

            if (respuesta == 0)
                btnNotificaciones.BackColor = Color.Transparent;
            else if (respuesta == Convert.ToInt32(Notificaciones.PRIORIDAD.ALTA))
                btnNotificaciones.BackColor = Color.Red;
            else if (respuesta == Convert.ToInt32(Notificaciones.PRIORIDAD.MEDIA))
                btnNotificaciones.BackColor = Color.Yellow;
            else if (respuesta == Convert.ToInt32(Notificaciones.PRIORIDAD.BAJA))
                btnNotificaciones.BackColor = Color.Green;

            if (Usuarios.CurrentUsuario.Id > 0)
            {
                try
                {
                    dgvLocaciones.DataSource = dtLocaciones;
                    ArmarGrilla();


                    if (Partes_Abiertos == true)
                    { btnHistorialPartes.BackColor = Color.FromArgb(255, 50, 50); }
                    else
                    { btnHistorialPartes.BackColor = Color.Transparent; }


                    Decimal SaldoCta = 0;
                    if (dtLocaciones.Rows.Count > 0)
                    {
                        int posi = 0;
                        for (int i = 0; i < dgvLocaciones.Rows.Count; i++)
                        {

                            if (dgvLocaciones.Rows[i].Cells["saldo"].Value.ToString().Length > 0 && dgvLocaciones.Rows[i].Cells["saldo"].Value != null)
                                SaldoCta = SaldoCta + Convert.ToDecimal(dgvLocaciones.Rows[i].Cells["saldo"].Value.ToString());

                            if (Int32.Parse(dgvLocaciones.Rows[i].Cells["id"].Value.ToString()) == Usuarios.CurrentUsuario.Id_Usuarios_Locacion)
                                posi = i;
                        }
                        if (dgvLocaciones.Rows.Count > 0)
                        {
                            int flag = 0;
                            for (int i = 0; i < dtLocaciones.Rows.Count; i++)
                            {
                                if (Convert.ToInt32(dtLocaciones.Rows[i]["id"]) == Usuarios.CurrentUsuario.Id_Usuarios_Locacion)
                                {
                                    dgvLocaciones.Rows[i].Selected = true;
                                    flag = 1;
                                }
                            }
                            if(flag==0)
                                dgvLocaciones.Rows[0].Selected = true;
                        }
                        //si se rompe todo en el if (dgvLocaciones.Rows.Count > 0) iba dgvLocaciones.Rows[0].Selected = true;



                    }

                    if (NovedadesActivas)
                        btnNovedades.BackColor = Color.FromArgb(255, 50, 50);
                    else
                        btnNovedades.BackColor = Color.FromArgb(72, 84, 101);

                    ObservacionesActivas = oNovedades.HayObservaciones(Usuarios.CurrentUsuario.Id);
                    if (ObservacionesActivas)
                        btnObs.BackColor = Color.FromArgb(255, 50, 50);
                    else
                        btnObs.BackColor = Color.FromArgb(72, 84, 101);

                    switch (Usuarios.CurrentUsuario.Id_Comprobantes_Iva)
                    {
                        case (int)Comprobantes_Iva.Tipo.CONSUMIDOR_FINAL:
                            lblCondicionIva.BackColor = Color.FromArgb(Convert.ToInt32(Tablas.DataCondIVA.Rows[0]["color1"]), Convert.ToInt32(Tablas.DataCondIVA.Rows[0]["color2"]), Convert.ToInt32(Tablas.DataCondIVA.Rows[0]["color3"]));
                            lblCondicionIva.Text = "CONSUMIDOR FINAL";
                            break;
                        case (int)Comprobantes_Iva.Tipo.RESPONSABLE_MONOTRIBUTO:
                            lblCondicionIva.Text = "RESPONSABLE MONOTRIBUTO";
                            lblCondicionIva.BackColor = Color.FromArgb(Convert.ToInt32(Tablas.DataCondIVA.Rows[1]["color1"]), Convert.ToInt32(Tablas.DataCondIVA.Rows[1]["color2"]), Convert.ToInt32(Tablas.DataCondIVA.Rows[1]["color3"]));
                            break;
                        case (int)Comprobantes_Iva.Tipo.RESPONSABLE_INSCRIPTO:
                            lblCondicionIva.Text = "RESPONSABLE INSCRIPTO";
                            lblCondicionIva.BackColor = Color.FromArgb(Convert.ToInt32(Tablas.DataCondIVA.Rows[1]["color1"]), Convert.ToInt32(Tablas.DataCondIVA.Rows[1]["color2"]), Convert.ToInt32(Tablas.DataCondIVA.Rows[1]["color3"]));
                            break;
                        case (int)Comprobantes_Iva.Tipo.EXENTO:
                            lblCondicionIva.Text = "EXENTO";
                            lblCondicionIva.BackColor = Color.FromArgb(Convert.ToInt32(Tablas.DataCondIVA.Rows[1]["color1"]), Convert.ToInt32(Tablas.DataCondIVA.Rows[1]["color2"]), Convert.ToInt32(Tablas.DataCondIVA.Rows[1]["color3"]));
                            break;
                        default:
                            lblCondicionIva.Visible = false;
                            break;
                    }
                    lblCondicionIva.Visible = true;

                    LbSaldoCta.Text = "Saldo $ " + SaldoCta.ToString();

                    dgvServiciosActivos.DataSource = dtServiciosContratados;

                    FiltrarLocaciones();
                    VerificarTieneDebito();
                    cargado = true;


                   
                }
                catch (Exception)
                {

                    throw;
                }


            }
            else
                btnUnificarLocaciones.Enabled = false;

            spDatosServicios.SplitterDistance = 261;
            OcultarCarga();

            Configuracion oConfig = new Configuracion();
            if (oConfig.GetValor_N("Agenda_Trabajo") == Convert.ToInt32(Agenda_Encabezado.Uso_agenda.TRABAJA_CON_AGENDA)
                && frmAgenda.pendienteDeAbrir)
            {
                frmAgenda frmagenda = frmAgenda.GetInstancia();
                frmAgenda.pendienteDeAbrir = false;
                frmagenda.Mostrar();
            }

     

            foreach (DataGridViewRow row in dgvServiciosActivos.Rows)
            {
                if (Convert.ToInt32(row.Cells["id_estado"].Value) == (Int32)Servicios.Servicios_Estados.CONECTADO)
                {
                    dgvServiciosActivos.CurrentCell = dgvServiciosActivos.Rows[row.Index].Cells["Servicio_sub"];

                    break;
                }
            }

            txtbusca.Focus();
        }
        public void VerificarTieneDebito()
        {
            if (dtServiciosContratados.Rows.Count > 0)
            {
                if (oPresentacionDebitos.ListarDebitosAsociados(Usuarios.CurrentUsuario.Id, out Usuarios.Current_dtServicios_Debitos))
                {
                    btnDebito.Enabled = true;
                    btnDebito.BackColor = Color.FromArgb(255, 50, 50);
                }
                else
                    btnDebito.BackColor = Color.FromArgb(72, 84, 101);
            }
            else
                btnDebito.BackColor = Color.FromArgb(72, 84, 101);
        }

        private void PonerDatosUsuarios()
        {
            try
            {
                LBApellido.Text = Usuarios.CurrentUsuario.Apellido.Trim() + " , " + Usuarios.CurrentUsuario.Nombre.Trim() + " [" + Usuarios.CurrentUsuario.Codigo.ToString().Trim() + "]";
                LBNumero_documento.Text = "Documento : (" + Usuarios.CurrentUsuario.Tipo_Documento + ") Nro " + Usuarios.CurrentUsuario.Numero_Documento;
                lbcuit.Text = "C. Iva : (" + Usuarios.CurrentUsuario.Condicion_Iva + ") Nro " + Usuarios.CurrentUsuario.CUIT;
                lbnaciemiento.Text = Usuarios.CurrentUsuario.Profesion + " -  Nacimiento :" + Usuarios.CurrentUsuario.Nacimiento.ToString("d MMM yyyy");
                lbcorreo.Text = Usuarios.CurrentUsuario.Correo_Electronico;

                lblAdhesionDA.Text = Usuarios.CurrentUsuario.Adhesion_Debito == 1 ? "SI" : "NO";
                lblAdhesionFE.Text = Usuarios.CurrentUsuario.Adhesion_FacDigital == 1 ? "SI" : "NO";
            }
            catch
            {
            }
        }

        private void OcultarCarga()
        {
            pnlCargando2.Hide();
            pgCircular2.Stop();
            foreach (Control item in this.Controls)
            {
                item.Enabled = true;
            }
        }

        public void RefrescarSaldo()
        {
            try
            {
                for (int i = 0; i < dgvLocaciones.Rows.Count; i++)
                {
                    Usuarios_Locaciones.ActualizarSaldo(Int32.Parse(dgvLocaciones.Rows[i].Cells["id"].Value.ToString()));
                }
                comenzarCarga();
            }
            catch { };
        }

        private void AgregarColumna()
        {
            if (!dgvServiciosActivos.Columns.Contains("Equipos"))
            {
                DataGridViewLinkColumn ctotal = new DataGridViewLinkColumn();
                ctotal.Text = "Ver";
                ctotal.DataPropertyName = "Equipos";
                ctotal.Name = "Equipos";
                ctotal.LinkColor = Color.White;
                ctotal.VisitedLinkColor = Color.White;
                ctotal.UseColumnTextForLinkValue = true;
                ctotal.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                ctotal.Width = 100;
                ctotal.HeaderText = "Equipos";
                dgvServiciosActivos.Columns.Add(ctotal);
            }
           
        }

        private void FormatearGrillaNueva()
        {
            foreach (DataGridViewRow dr in dgvServiciosActivos.Rows)
            {
                DataGridViewTextBoxCell noaparece = new DataGridViewTextBoxCell();
                if (Convert.ToInt32(dr.Cells["id_tipo"].Value.ToString()) == 1)
                {
                    dr.DefaultCellStyle.BackColor = Color.FromArgb(43, 58, 68);
                    dr.DefaultCellStyle.BackColor = Color.FromArgb(0, 0, 0);
                    dr.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Regular);
                    dr.DefaultCellStyle.ForeColor = Color.White;
                }
                else
                {
                    if (Convert.ToInt32(dr.Cells["id_tipo"].Value.ToString()) == 3)
                    {
                        dr.DefaultCellStyle.BackColor = Color.FromArgb(43, 58, 68);
                        dr.DefaultCellStyle.BackColor = Color.FromArgb(40, 40, 40);
                        dr.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Italic);
                        dr.DefaultCellStyle.ForeColor = Color.White;
                    }
                    else
                    {
                        if (Convert.ToInt32(dr.Cells["sub_borrado"].Value) == -1)
                        {
                            dr.DefaultCellStyle.BackColor = Color.FromArgb(255, 200, 200);
                            dr.DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Regular);

                        }
                        else
                            dr.DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Regular);

                    }

                }
                String estado = dr.Cells["estado"].Value.ToString();
                DataRow[] drConectado;
                int color1, color2, color3;

                if (Convert.ToInt32(dr.Cells["id_tipo"].Value.ToString()) == 1 || (Convert.ToInt32(dr.Cells["id_tipo"].Value.ToString()) == 4))
                {
                    switch (estado)
                    {
                        case "CONECTADO":
                            drConectado = dtEstados.Select(String.Format("estado='{0}'", estado));
                            color1 = Convert.ToInt32(drConectado[0]["color1"]);
                            color2 = Convert.ToInt32(drConectado[0]["color2"]);
                            color3 = Convert.ToInt32(drConectado[0]["color3"]);
                            dr.DefaultCellStyle.BackColor = Color.FromArgb(color1, color2, color3);
                            break;

                        case "CORTADO":
                            drConectado = dtEstados.Select(String.Format("estado='{0}'", estado));
                            color1 = Convert.ToInt32(drConectado[0]["color1"]);
                            color2 = Convert.ToInt32(drConectado[0]["color2"]);
                            color3 = Convert.ToInt32(drConectado[0]["color3"]);
                            dr.DefaultCellStyle.BackColor = Color.FromArgb(color1, color2, color3);
                            break;
                        default:
                            break;

                    }
                }


                dr.Height = 30;
            }
            foreach (DataGridViewColumn item in dgvServiciosActivos.Columns)
            {
                item.Visible = false;
                item.SortMode = DataGridViewColumnSortMode.NotSortable;

            }
            dgvServiciosActivos.Columns["servicio_sub"].Visible = true;
            dgvServiciosActivos.Columns["servicio_sub"].DisplayIndex = 0;
            dgvServiciosActivos.Columns["servicio_sub"].HeaderText = "Servicio";

            dgvServiciosActivos.Columns["categoria"].Visible = true;
            dgvServiciosActivos.Columns["categoria"].DisplayIndex = 1;
            dgvServiciosActivos.Columns["categoria"].HeaderText = "Categoria";

            dgvServiciosActivos.Columns["fecha_inicio"].Visible = true;
            dgvServiciosActivos.Columns["fecha_inicio"].DisplayIndex = 2;
            dgvServiciosActivos.Columns["fecha_inicio"].HeaderText = "Conexion";
            dgvServiciosActivos.Columns["fecha_inicio"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvServiciosActivos.Columns["bonificacion_esp"].Visible = true;
            dgvServiciosActivos.Columns["bonificacion_esp"].HeaderText = "Bonificacion Esp.";

            dgvServiciosActivos.Columns["estado"].Visible = true;
            dgvServiciosActivos.Columns["estado"].DisplayIndex = 3;
            dgvServiciosActivos.Columns["estado"].HeaderText = "Estado";
            dgvServiciosActivos.Columns["estado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvServiciosActivos.Columns["fecha_estado"].Visible = true;
            dgvServiciosActivos.Columns["fecha_estado"].DisplayIndex = 4;
            dgvServiciosActivos.Columns["fecha_estado"].HeaderText = "Ult. Cambio";
            dgvServiciosActivos.Columns["fecha_estado"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            dgvServiciosActivos.Columns["fecha_factura"].Visible = true;
            dgvServiciosActivos.Columns["fecha_factura"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvServiciosActivos.Columns["fecha_factura"].DefaultCellStyle.Format = "d MMM yyyy";
            dgvServiciosActivos.Columns["fecha_factura"].HeaderText = "Fin del servicio";

            dgvServiciosActivos.Columns["fecha_factura"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;

            dgvServiciosActivos.Columns["cant_bocas"].Visible = true;
            dgvServiciosActivos.Columns["cant_bocas"].HeaderText = "Uds";
            dgvServiciosActivos.Columns["cant_bocas"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dgvServiciosActivos.Columns["cant_bocas"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            int contador = 0;
            foreach (DataGridViewRow item in dgvServiciosActivos.Rows)
            {
                int idTipo = Convert.ToInt32(item.Cells["id_tipo"].Value);
                if (idTipo != 1 && idTipo != 3)
                    item.Visible = false;
                if (idTipo == 3 || idTipo == 4)
                {
                    item.DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Italic);

                }
                if (idTipo == 1 && contador == 0)
                {
                    indice = item.Index;
                    contador++;
                }

            }

            //dgvServiciosActivos.DefaultCellStyle = dgvServiciosActivos5.DefaultCellStyle;
            if (dgvServiciosActivos.Rows.Count > 0)
            {
                dgvServiciosActivos.Rows[indice].Cells["servicio_sub"].Selected = true;
            }



        }

        private void FiltrarLocaciones()
        {
            if (dtLocaciones.Rows.Count > 0)
            {
                try
                {
                    PoneDatosdeLocacion();

                    DataView v1 = dtServiciosContratados.DefaultView;
                    v1.RowFilter = string.Format("id_locacion = {0} ", Convert.ToInt32(dgvLocaciones.SelectedRows[0].Cells["id"].Value.ToString()));
                    dgvServiciosActivos.DataSource = null;
                    dgvServiciosActivos.DataSource = v1;
                    FormatearGrillaNueva();
                    AgregarColumna();
                }
                catch { }
            }
        }

        private void ArmarGrilla()
        {
            for (int i = 0; i < dtLocaciones.Columns.Count; i++)
                dgvLocaciones.Columns[i].Visible = false;

            dgvLocaciones.Columns["calle"].Visible = true;
            dgvLocaciones.Columns["Altura"].Visible = true;
            dgvLocaciones.Columns["Piso"].Visible = true;
            dgvLocaciones.Columns["Depto"].Visible = true;
            dgvLocaciones.Columns["saldo"].DefaultCellStyle.Format = "c2";
            dgvLocaciones.Columns["saldo"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dgvLocaciones.Columns["saldo"].Visible = true;

            foreach (DataGridViewRow item in dgvLocaciones.Rows)
            {
                if (Convert.ToInt32(item.Cells["activo1"].Value) == 1)
                {
                    item.DefaultCellStyle.BackColor = Color.Gainsboro;
                    item.DefaultCellStyle.ForeColor = Color.Black;
                }
                if (dgvLocaciones.Rows.Count > 1)
                    btnUnificarLocaciones.Enabled = true;
                else
                    btnUnificarLocaciones.Enabled = false;
            }

        }

        private void PoneDatosdeLocacion()
        {
            try
            {
                //if para seleccionar la locacion que clickeaste en el marcador del mapa.
                Usuarios.CurrentUsuario.Id_Usuarios_Locacion = Convert.ToInt32(dgvLocaciones.SelectedRows[0].Cells["id"].Value.ToString());
                lbcategoria.Text = "Id: " + Usuarios.CurrentUsuario.Id.ToString() + "-" + dgvLocaciones.SelectedRows[0].Cells["id"].Value.ToString();
                lbcategoria.Location = new Point((pnlCategoria.Size.Width) - lbcategoria.Width, pnlCategoria.Height / 4);
                lbcalle.Text = dgvLocaciones.SelectedRows[0].Cells["calle"].Value.ToString() + " Nro " + dgvLocaciones.SelectedRows[0].Cells["Altura"].Value.ToString();
                lbdepto.Text = dgvLocaciones.SelectedRows[0].Cells["depto"].Value.ToString();
                lbentre.Text = dgvLocaciones.SelectedRows[0].Cells["entre_calle_1"].Value.ToString() + " y " + dgvLocaciones.SelectedRows[0].Cells["entre_calle_2"].Value.ToString();
                lblocalidad.Text = dgvLocaciones.SelectedRows[0].Cells["localidad"].Value.ToString();
                lbmanzana.Text = dgvLocaciones.SelectedRows[0].Cells["manzana"].Value.ToString();
                lbpiso.Text = dgvLocaciones.SelectedRows[0].Cells["piso"].Value.ToString();
                lbobservacion.Text = dgvLocaciones.SelectedRows[0].Cells["observacion"].Value.ToString();
                lbte1.Text = "(" + dgvLocaciones.SelectedRows[0].Cells["prefijo_1"].Value.ToString() + ") " + dgvLocaciones.SelectedRows[0].Cells["telefono_1"].Value.ToString();
                lbte2.Text = "(" + dgvLocaciones.SelectedRows[0].Cells["prefijo_2"].Value.ToString() + ") " + dgvLocaciones.SelectedRows[0].Cells["telefono_2"].Value.ToString();
                lbpostal.Text = dgvLocaciones.SelectedRows[0].Cells["codigo_postal"].Value.ToString();
                lbparcela.Text = dgvLocaciones.SelectedRows[0].Cells["parcela"].Value.ToString();
                lbobservacion.Text = dgvLocaciones.SelectedRows[0].Cells["Observacion"].Value.ToString();


                Usuarios.CurrentUsuario.Calle = dgvLocaciones.SelectedRows[0].Cells["calle"].Value.ToString();
                Usuarios.CurrentUsuario.Altura = Convert.ToInt32(dgvLocaciones.SelectedRows[0].Cells["Altura"].Value.ToString());
                Usuarios.CurrentUsuario.Depto = dgvLocaciones.SelectedRows[0].Cells["depto"].Value.ToString();
                Usuarios.CurrentUsuario.piso = dgvLocaciones.SelectedRows[0].Cells["piso"].Value.ToString();
                Usuarios.CurrentUsuario.Prefijo_1 = Convert.ToInt32(dgvLocaciones.SelectedRows[0].Cells["prefijo_1"].Value.ToString());
                Usuarios.CurrentUsuario.Telefono_1 = Convert.ToInt32(dgvLocaciones.SelectedRows[0].Cells["telefono_1"].Value.ToString());
                Usuarios.CurrentUsuario.Prefijo_2 = Convert.ToInt32(dgvLocaciones.SelectedRows[0].Cells["prefijo_2"].Value.ToString());
                Usuarios.CurrentUsuario.Telefono_2 = Convert.ToInt32(dgvLocaciones.SelectedRows[0].Cells["telefono_2"].Value.ToString());
                Usuarios.CurrentUsuario.Observacion = dgvLocaciones.SelectedRows[0].Cells["Observacion"].Value.ToString();
            }
            catch
            {

            }
        }

        private void Buscar()
        {
            oUsu.Codigo = 0;
            oUsu.Usuario = "";
            oUsu.Calle = "";
            oUsu.Altura = 0;

            Int32 opcion = 0;
            if (bUsuario.Checked == true) { opcion = 1; }
            if (bNombre.Checked == true) { opcion = 2; }
            if (Bdomicilio.Checked == true) { opcion = 3; }
            if (bDocumento.Checked == true) { opcion = 4; }
            if (bTarjeta.Checked == true) { opcion = 5; }
            if (txtbuscaraltura.Visible == false) { txtbuscaraltura.Text = ""; }

            Int32 i = 0;

            if (bUsuario.Checked == true && int.TryParse(txtbusca.Text, out i) == true)
            {
                oUsu.Tipo_Busqueda = "C";
                oUsu.LlenarObjeto(Convert.ToInt32(txtbusca.Text), Convert.ToInt32(txtbusca.Text));

                if (Usuarios.CurrentUsuario.Id == 0)
                {
                    MessageBox.Show("Codigo de Usuario Inexistente", "Mensaje del Sistema", MessageBoxButtons.OK,
                       MessageBoxIcon.Exclamation);
                }
                else
                {
                    if (Usuarios.CurrentUsuario != null)
                        PonerDatosUsuarios();

                    comenzarCarga();

                }
            }
            else if (bTarjeta.Checked == true && int.TryParse(txtbusca.Text, out i) == true)
            {
                if (txtbusca.Text != "")
                {
                    using (frmPopUp frmPo = new frmPopUp())
                    {
                        FrmBuscadorGen frm = new FrmBuscadorGen(txtbusca.Text.Trim());
                        frm.List = FrmBuscadorGen.Tipo.EQUIPOS_TARJETAS;
                        frmPo.Formulario = frm;
                        frmPo.Maximizar = true;
                        if (frmPo.ShowDialog() == DialogResult.OK)
                        {
                            id_usu = frm.id_usuario;
                        }
                        oUsu.Tipo_Busqueda = "C";
                        oUsu.LlenarObjeto(Convert.ToInt32(id_usu));
                        if (Usuarios.CurrentUsuario.Id == 0)
                        {
                            MessageBox.Show("Codigo de Usuario Inexistente", "Mensaje del Sistema", MessageBoxButtons.OK,
                               MessageBoxIcon.Exclamation);
                        }
                        else
                        {
                            if (Usuarios.CurrentUsuario != null)
                                PonerDatosUsuarios();
                            comenzarCarga();
                        }
                    }

                }

            }

            else if (txtbusca.Text == "" && bTarjeta.Checked == true)
            {
                using (frmPopUp frmPo = new frmPopUp())
                {
                    FrmBuscadorGen frm = new FrmBuscadorGen();
                    frm.List = FrmBuscadorGen.Tipo.EQUIPOS_TARJETAS;
                    frmPo.Formulario = frm;
                    frmPo.Maximizar = true;
                    if (frmPo.ShowDialog() == DialogResult.OK)
                    {
                        id_usu = frm.id_usuario;
                    }
                    oUsu.Tipo_Busqueda = "C";
                    oUsu.LlenarObjeto(Convert.ToInt32(id_usu));
                    if (id_usu == 0)
                    {
                        MessageBox.Show("Codigo de Usuario Inexistente", "Mensaje del Sistema", MessageBoxButtons.OK,
                           MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        if (Usuarios.CurrentUsuario != null)
                        {
                            PonerDatosUsuarios();
                            comenzarCarga();
                        }

                    }
                }
            }
            else
            {
                frmBusquedaUsuarios frm = new frmBusquedaUsuarios(opcion, txtbusca.Text, txtbuscaraltura.Text);

                frmPopUp frmPop = new frmPopUp();
                frmPop.Formulario = frm;

                if (frmPop.ShowDialog() == DialogResult.OK)
                {
                    LBApellido.Text = frm.apellido.Trim() + " , " + frm.nombre.Trim() + " [" + frm.codigo.ToString().Trim() + "]";
                    comenzarCarga();
                }
            }
        }

        private void VerEquipos()
        {
            //try
            //{
            using (frmPopUp frmPo = new frmPopUp())
            {
                frmUsuariosEquipos frm = new frmUsuariosEquipos(Convert.ToInt32(dgvServiciosActivos.CurrentRow.Cells["id_usuario_servicio"].Value), Usuarios.CurrentUsuario.Codigo, Convert.ToInt32(dgvServiciosActivos.CurrentRow.Cells["id_servicio"].Value), Convert.ToInt32(dgvServiciosActivos.CurrentRow.Cells["id_locacion"].Value));
                frmPo.Formulario = frm;
                frmPo.Maximizar = true;
                frmPo.ShowDialog();

            }

            //}
            //catch (Exception EX)
            //{
            //    MessageBox.Show(EX.Message);
            //}
        }

        private void Genera_Comprobantes()
        {
            if (dgvLocaciones.SelectedRows.Count > 0)
            {
                //try
                //{
                //frmGeneraComprobantesManual frm = new frmGeneraComprobantesManual(dtUsuarios_Servicios, dtLocaciones);
                int idLocacionSeleccionada = 0;
                if (dgvLocaciones.SelectedRows.Count > 0)
                    idLocacionSeleccionada = Convert.ToInt32(dgvLocaciones.SelectedRows[0].Cells["id"].Value);
                frmGeneraComprobantesManual frm = new frmGeneraComprobantesManual(Usuarios.CurrentUsuario.Id, idLocacionSeleccionada, dtServiciosContratados, dtLocaciones);
                frmMain.Instance().openForm(frm);
                //}
                //catch { }
            }

        }

        private void Recibos()
        {
            if (dgvLocaciones.SelectedRows.Count > 0)
            {
                try
                {

                    ComprobarFechas();
                }
                catch { }
            }
        }

        private void ComprobarFechas()
        {
            Boolean pregunta = false;
            foreach (DataRow dr in dtServiciosContratados.Rows)
            {
                if (Convert.ToDateTime(dr["fecha_factura"].ToString()) < DateTime.Now)
                    pregunta = true;
            }
            if (pregunta)
            {
                DialogResult result;
                result = MessageBox.Show("GENERA PERIODOS", "Existen servicios con peridodos caducados", MessageBoxButtons.YesNo);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    Genera_Comprobantes();
                }
                else
                {
                    frmUsuariosCtaCte frm = new frmUsuariosCtaCte(Usuarios.CurrentUsuario.Id, Usuarios.CurrentUsuario.Id_Usuarios_Locacion);

                    frmMain.Instance().openForm(frm);
                }
            }
            else
            {
                try
                {
                frmUsuariosCtaCte frm = new frmUsuariosCtaCte(Usuarios.CurrentUsuario.Id, Usuarios.CurrentUsuario.Id_Usuarios_Locacion);
                frmMain.Instance().openForm(frm);

                }
                catch (Exception v)
                {

                    throw;
                }
            }
        }

        private void AbrirCuentaCorriente()
        {
            if (Usuarios.CurrentUsuario.Id != 0)
            {
                try
                {
                    if (dgvLocaciones.SelectedRows.Count > 0)
                    {
                        frmUsuariosCtaCteConsultaNuevo frm = new frmUsuariosCtaCteConsultaNuevo(Usuarios.CurrentUsuario.Id, 0);
                        frmMain.Instance().openForm(frm);
                    }
                }
                catch { }
            }
            else
            {
                Buscar();
                try
                {
                    if (dgvLocaciones.SelectedRows.Count > 0)
                    {
                        frmUsuariosCtaCteConsultaNuevo frm = new frmUsuariosCtaCteConsultaNuevo(Usuarios.CurrentUsuario.Id, 0);
                        frmMain.Instance().openForm(frm);
                    }
                }
                catch { }
            }
        }
        private void Controles()
        {
            if (dgvServiciosActivos.CurrentRow != null)
            {
                int idTipo = Convert.ToInt32(dgvServiciosActivos.CurrentRow.Cells["id_tipo"].Value);
                Boolean habilitaDes;
                if (idTipo != 1)
                {
                    habilitaDes = false;
                    btnCambioEquipo.Enabled = habilitaDes;
                    btnCambioEstados.Enabled = habilitaDes;
                    btnContratacion.Enabled = habilitaDes;
                    btnComplementarias.Enabled = habilitaDes;
                    btnHistorialPartes.Enabled = habilitaDes;
                    btnGeneracomprobantes.Enabled = habilitaDes;
                    btnHistorialCambios.Enabled = habilitaDes;

                }
                else
                {
                    habilitaDes = true;
                    btnCambioEquipo.Enabled = habilitaDes;
                    btnCambioEstados.Enabled = habilitaDes;
                    btnContratacion.Enabled = habilitaDes;
                    btnComplementarias.Enabled = habilitaDes;
                    btnHistorialPartes.Enabled = habilitaDes;
                    btnGeneracomprobantes.Enabled = habilitaDes;
                    btnHistorialCambios.Enabled = habilitaDes;
                }
                if (idTipo == 3 || idTipo == 4)
                {
                    string nombrePadre = dgvServiciosActivos.CurrentRow.Cells["usuario"].Value.ToString();
                    idLocacionPadre = Convert.ToInt32(dgvServiciosActivos.CurrentRow.Cells["Id_Usuarios_Locaciones_Padre"].Value);
                    DataTable dtDatosLocacionPadre = oUsuLoc.ListarDatosLocacion(idLocacionPadre);
                    if (dtDatosLocacionPadre.Rows.Count > 0)
                        idUsuarioPadre = Convert.ToInt32(dtDatosLocacionPadre.Rows[0]["id_usuarios"]);
                    lblUsuarioPadreDato.Text = nombrePadre;
                    idUsuarioServicioPadre = Convert.ToInt32(dgvServiciosActivos.CurrentRow.Cells["Id_Usuario_servicio"].Value);
                    DataTable dtDatosUsuarioServicioPadre = oUsuariosServicios.Traer_datos_usuarios_servicios(idUsuarioServicioPadre);
                    if (dtDatosUsuarioServicioPadre.Rows.Count > 0)
                        idUsuarioPadre = Convert.ToInt32(dtDatosUsuarioServicioPadre.Rows[0]["id_usuarios"]);
                }
                else
                    lblUsuarioPadreDato.Text = "-";
            }
            SetearPermisosDePanelInferior();
        }

        private void SetearPermisosDePanelInferior()
        {
            foreach (var boton in permisoBotones)
            {
                boton.Key.Enabled = boton.Value;
            }
        }
        #endregion

        #region[METODOS CONTROLES]
        public static frmUsuariosPrincipal Instance()
        {
            if (aForm == null)
                aForm = new frmUsuariosPrincipal();

            return aForm;
        }

        private frmUsuariosPrincipal()
        {
            InitializeComponent();
        }

        private void frmUsuariosPrincipal_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F5) //recibos
                Recibos();

            if (e.KeyCode == Keys.F8) // busca usuario
                Buscar();
            if (e.Control && e.KeyCode == Keys.S)       // Ctrl-S Save
            {
                // Do what you want here
                frmPopUp oPop = new frmPopUp();
                frmBusquedaUsuSerSub oFrm = new frmBusquedaUsuSerSub();
                oFrm.idUsuario = Usuarios.CurrentUsuario.Id;
                oFrm.eliminar = 0;
                oFrm.cambiaEstado = 1;
                oPop.Formulario = oFrm;
                oPop.ShowDialog();
                if (oFrm.cambiaEstado == 1)
                    comenzarCarga();
                e.SuppressKeyPress = true;  // Stops other controls on the form receiving event.
            }
            if (e.Control && e.KeyCode == Keys.L)       // Ctrl-L cambio id_fac (loc/cat)
            {
                // Do what you want here
                frmPopUp oPop = new frmPopUp();
                frmCambioFac oFrm = new frmCambioFac();
                oFrm.calleActual = dgvLocaciones.SelectedRows[0].Cells["calle"].Value.ToString();
                oFrm.deptoActual = dgvLocaciones.SelectedRows[0].Cells["depto"].Value.ToString();
                oFrm.pisoActual = dgvLocaciones.SelectedRows[0].Cells["piso"].Value.ToString();
                oFrm.idLocacion = Convert.ToInt32(dgvLocaciones.SelectedRows[0].Cells["id"].Value);
                oFrm.idCalleActual = Convert.ToInt32(dgvLocaciones.SelectedRows[0].Cells["id_Calle"].Value);
                oFrm.idLocalidadActual = Convert.ToInt32(dgvLocaciones.SelectedRows[0].Cells["id_localidades"].Value);
                oFrm.alturaActual = Convert.ToInt32(dgvLocaciones.SelectedRows[0].Cells["altura"].Value);
                oFrm.Id_Usuarios_Servicios = Convert.ToInt32(dgvServiciosActivos.CurrentRow.Cells["id_usuario_servicio"].Value);
                oFrm.Fecha_Factura = Convert.ToDateTime(dgvServiciosActivos.CurrentRow.Cells["fecha_factura"].Value);
                oFrm.Servicio = dgvServiciosActivos.CurrentRow.Cells["servicio"].Value.ToString();
                oFrm.idZonaActual = Convert.ToInt32(dgvServiciosActivos.CurrentRow.Cells["id_tipo_facturacion"].Value);
                using (frmPopUp frmpo = new frmPopUp())
                {
                    frmpo.Formulario = oFrm;
                    frmpo.Maximizar = false;

                    if (frmpo.ShowDialog() == DialogResult.OK)
                    {
                        if (oFrm.seModificoAlgo == true)
                            comenzarCarga();
                    }
                }

                e.SuppressKeyPress = true;  // Stops other controls on the form receiving event.
            }
            if (e.KeyCode == Keys.F7) // busca usuario
            {
                Usuarios oUsuAux = oUsu.traerUltimoUsuario();
                oUsu.LlenarObjeto(oUsuAux.Id);
                comenzarCarga();
            }
            if (e.KeyCode == Keys.F3 && Usuarios.CurrentUsuario.Id > 0) // busca usuario anterior
            {
               
                oUsu.LlenarObjeto(Usuarios.CurrentUsuario.Id - 1);
                comenzarCarga();
            }
            if (e.KeyCode == Keys.F4 && Usuarios.CurrentUsuario.Id > 0) // busca usuario posterior
            {
                oUsu.LlenarObjeto(Usuarios.CurrentUsuario.Id + 1);
                comenzarCarga();

            }

            if (e.KeyCode == Keys.F9) //CONTROL + T ENTRAS A LA CUENTA CORRIENTE
                AbrirCuentaCorriente();

        }
        private void txtbuscarcalle_Enter(object sender, EventArgs e)
        {
            txtbuscaraltura.Enabled = true;
        }

        private void txtbuscaraltura_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (Char)Keys.Enter)
                Buscar();
        }

        private void txtbusca_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (bUsuario.Checked == true || bDocumento.Checked == true || bTarjeta.Checked == true)
            {
                if (Char.IsDigit(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (Char.IsControl(e.KeyChar))
                {
                    e.Handled = false;
                }
                else if (Char.IsSeparator(e.KeyChar))
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }

            if (bTarjeta.Checked == true)
                txtbusca.Numerico = true;
            if (bUsuario.Checked == true)
                txtbusca.Numerico = true;
            if (bNombre.Checked == true)
                txtbusca.Numerico = false;
            if (Bdomicilio.Checked == true)
                txtbusca.Numerico = false;
            if (bDocumento.Checked == true)
                txtbusca.Numerico = true;

            if (e.KeyChar == (Char)Keys.Enter)
                Buscar();
        }

        private void dgvLocaciones_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(dgvLocaciones.SelectedRows[0].Cells["activo1"].Value) == 1)
                    DeseleccionarLocacion();
                else
                    FiltrarLocaciones();

            }
            catch { }
        }

        private void DeseleccionarLocacion()
        {
            dgvServiciosActivos.DataSource = null;
            dgvLocaciones.ClearSelection();
            lbBocas_Pac.Text = "-";
            lbBocas.Text = "-";
            lbpostal.Text = "-";
            lbpiso.Text = "-";
            lbparcela.Text = "-";
            lbmanzana.Text = "-";
            lbdepto.Text = "-";
            lbobservacion.Text = "-";
            lbentre.Text = "-";
            lbcalle.Text = "-";
            lblocalidad.Text = "-";
            lbte2.Text = "-";
            lbte1.Text = "-";
            lbcategoria.Text = "-";
            lblUsuarioPadreDato.Text = "-";
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void bUsuario_Click(object sender, EventArgs e)
        {
            txtbusca.Text = "";
            txtbuscaraltura.Text = "";
            txtbuscaraltura.Enabled = false;
            txtbusca.Focus();
        }

        private void bNombre_Click(object sender, EventArgs e)
        {
            txtbusca.Text = "";
            txtbuscaraltura.Text = "";
            txtbuscaraltura.Enabled = true;
            txtbusca.Focus();
        }

        private void Bdomicilio_Click(object sender, EventArgs e)
        {
            txtbusca.Text = "";
            txtbuscaraltura.Enabled = true;
            txtbusca.Focus();
        }

        private void bDocumento_Click(object sender, EventArgs e)
        {
            txtbusca.Text = "";
            txtbuscaraltura.Text = "";
            txtbuscaraltura.Enabled = false;
            txtbusca.Focus();
        }

        private void btnLocacionF_Click(object sender, EventArgs e)
        {
            if (Usuarios.CurrentUsuario.Id > 0)
            {
                using (frmPopUp frm = new frmPopUp())
                {
                    ABMUsuarios_LocacionFiscal frmLocFiscal = new ABMUsuarios_LocacionFiscal(Usuarios.CurrentUsuario.Id);

                    frm.Formulario = frmLocFiscal;
                    frm.Maximizar = false;
                    frm.ShowDialog();
                }
            }
        }

        private void btnDatosPersonales_Click(object sender, EventArgs e)
        {
            if (Usuarios.CurrentUsuario.Id > 0)
            {
                if (Usuarios.CurrentUsuario.Id_Usuarios_Tipos == (Int32)Usuarios.Usuarios_Tipos.ABONADO)
                {
                    ABMUsuario Abm = new ABMUsuario();
                    Abm.DataLocaciones = dtLocaciones;
                    frmPopUp frmpopup = new frmPopUp();
                    frmpopup.Maximizar = false;
                    frmpopup.Formulario = Abm;
                    frmpopup.ShowDialog();
                    if (frmpopup.DialogResult == DialogResult.OK)
                    {
                        comenzarCarga();
                        oUsu.LlenarObjeto(Usuarios.CurrentUsuario.Id);
                        PonerDatosUsuarios();
                    }
                }
                else
                {
                    ABMClientes Abm = new ABMClientes(Usuarios.CurrentUsuario.Id);
                    frmPopUp frmpopup = new frmPopUp();
                    frmpopup.Maximizar = false;
                    frmpopup.Formulario = Abm;
                    frmpopup.ShowDialog();
                    if (frmpopup.DialogResult == DialogResult.OK)
                    {
                        comenzarCarga();
                        oUsu.LlenarObjeto(Usuarios.CurrentUsuario.Id);
                        PonerDatosUsuarios();
                    }
                }
            }
            else
            {
                MessageBox.Show("No se ha seleccionado un usuario.");
            }
        }

        private void btnRecibos_Click(object sender, EventArgs e)
        {
            if (Usuarios.CurrentUsuario.Id == 0)
                Buscar();

            Recibos();
        }

        private void btnGeneracomprobantes_Click(object sender, EventArgs e)
        {
            if (Usuarios.CurrentUsuario.Id == 0)
                Buscar();

            Genera_Comprobantes();
        }

        private void btnCorreos_Click(object sender, EventArgs e)
        {
            try
            {
                ABMUsuarios_Telefonos frm = new ABMUsuarios_Telefonos(Usuarios.CurrentUsuario.Id, Convert.ToInt32(dgvLocaciones.SelectedRows[0].Cells["id"].Value.ToString()));
                frm.ShowDialog();
            }
            catch { }
        }

        private void btnHistorialPartes_Click(object sender, EventArgs e)
        {
            if (Usuarios.CurrentUsuario.Id > 0 && dgvLocaciones.SelectedRows.Count > 0)
            {
                int id_locacion_elegida = Convert.ToInt32(dgvLocaciones.SelectedRows[0].Cells["id"].Value);
                frmPartesHistorial frmPartesConsulta = new frmPartesHistorial(Usuarios.CurrentUsuario.Id, id_locacion_elegida);
                frmMain frmmain = frmMain.Instance();
                frmmain.openForm(frmPartesConsulta);
            }
            else
            {
                frmPartesHistorial frmPartesConsulta = new frmPartesHistorial(Usuarios.CurrentUsuario.Id, Usuarios.CurrentUsuario.Id_Usuarios_Locacion);
                frmMain frmmain = frmMain.Instance();
                if (Usuarios.CurrentUsuario.Id <= 0)
                    Buscar();
                if (Usuarios.CurrentUsuario.Id > 0)
                {
                    frmPartesHistorial frmPartesConsulta2 = new frmPartesHistorial(Usuarios.CurrentUsuario.Id, Usuarios.CurrentUsuario.Id_Usuarios_Locacion);
                    frmMain frmmain2 = frmMain.Instance();
                    frmmain.openForm(frmPartesConsulta2);
                }

            }


        }

        private void btnCambioDomicilio_Click(object sender, EventArgs e)
        {
            int cantPartesAbiertos = 0;
            DialogResult dialogResult = DialogResult.No;

            if (dgvLocaciones.SelectedRows.Count > 0)
            {
                if (oUsuLoc.RetornarEstadoLocacion(Convert.ToInt32(dgvLocaciones.SelectedRows[0].Cells["id"].Value)) == Convert.ToInt32(Usuarios_Locaciones.Locacion_Estados.ACTIVA))
                {
                    cantPartesAbiertos = oPartes.ListarPartesAbiertos(Convert.ToInt32(dgvLocaciones.SelectedRows[0].Cells["id"].Value), Convert.ToInt16(Partes.Partes_Operaciones.CAMBIO_DE_DOMICILIO)).Rows.Count;
                    if (cantPartesAbiertos > 0)
                        dialogResult = MessageBox.Show("La locación aún posee un cambio de domicilio pendiente. ¿Desea continuar de todas formas?", "", MessageBoxButtons.YesNo);
                    if ((cantPartesAbiertos > 0 && dialogResult == DialogResult.Yes) || cantPartesAbiertos == 0)
                    {
                        frmModificarLocacion frmModificar = new frmModificarLocacion(Usuarios.CurrentUsuario.Id, Convert.ToInt32(dgvLocaciones.SelectedRows[0].Cells["id"].Value.ToString()));
                        frmMain frmmain = frmMain.Instance();
                        frmmain.openForm(frmModificar);
                    }
                }
                else
                    MessageBox.Show("La locación seleccionada no se encuentra activa.");
            }
            else
            {
                if (Usuarios.CurrentUsuario.Id == 0)
                {
                    Buscar();
                    cantPartesAbiertos = oPartes.ListarPartesAbiertos(Usuarios.CurrentUsuario.Id_Usuarios_Locacion, Convert.ToInt16(Partes.Partes_Operaciones.CAMBIO_DE_DOMICILIO)).Rows.Count;
                    if (cantPartesAbiertos > 0)
                        dialogResult = MessageBox.Show("La locación aún posee un cambio de domicilio pendiente. ¿Desea continuar de todas formas?", "", MessageBoxButtons.YesNo);
                    if ((cantPartesAbiertos > 0 && dialogResult == DialogResult.Yes) || cantPartesAbiertos == 0)
                    {
                        frmModificarLocacion frmModificar = new frmModificarLocacion(Usuarios.CurrentUsuario.Id, Usuarios.CurrentUsuario.Id_Usuarios_Locacion);
                        frmMain frmmain = frmMain.Instance();
                        frmmain.openForm(frmModificar);
                    }
                }
            }
        }

        private void btnActualiza_Click(object sender, EventArgs e)
        {
            comenzarCarga();
        }

        private void btnConsulta_Ctacte_Click(object sender, EventArgs e)
        {
            AbrirCuentaCorriente();
        }

        private void btnHistorialCambios_Click(object sender, EventArgs e)
        {
            //if (Usuarios.CurrentUsuario.Id != 0)
            //{
            //    using (frmPopUp frm = new frmPopUp())
            //    {
            //        frmCambioServicio frmCambio = new frmCambioServicio();

            //        frm.Formulario = frmCambio;
            //        frm.Maximizar = true;
            //        if (frm.ShowDialog() == DialogResult.OK)
            //            comenzarCarga();
            //    }
            //}
            if(dgvServiciosActivos.Rows.Count == 0)
            {
                MessageBox.Show("Es necesario seleccionar un usuario", "Mensaje del sistema");
                return;
            }

            int idUsuSer = Convert.ToInt32(dgvServiciosActivos.CurrentRow.Cells["id_usuario_servicio"].Value);
            frmMain frmmain = frmMain.Instance();
            frmmain.openForm(new Complementarias.frmCambioServicio(idUsuSer));
        }

        private void BtnActualizarSaldo_Click(object sender, EventArgs e)
        {
            RefrescarSaldo();
        }

        private void btnContratarServ_Click(object sender, EventArgs e)
        {
            frmPopUp frmPop = new frmPopUp();
            try
            {
                if (Usuarios.CurrentUsuario.Id != 0)
                {
                    Complementarias.frmComplementarias frmComple = new Complementarias.frmComplementarias(idUsuarioServicio, Convert.ToDecimal(dgvLocaciones.SelectedRows[0].Cells["saldo"].Value));
                    frmPop.Formulario = frmComple;
                    frmPop.ShowDialog();
                    if (frmComple.huboCambios == true)
                        comenzarCarga();
                }
                else
                {
                    Buscar();
                    Complementarias.frmComplementarias frmComple = new Complementarias.frmComplementarias(idUsuarioServicio, Convert.ToDecimal(dgvLocaciones.SelectedRows[0].Cells["saldo"].Value));
                    frmPop.Formulario = frmComple;
                    frmPop.ShowDialog();
                    if (frmComple.huboCambios == true)
                        comenzarCarga();
                }
            }
            catch
            {

            }
        }

        private void dgvServiciosActivos_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                idUsuarioServicio = Convert.ToInt32(dgvServiciosActivos.CurrentRow.Cells["id_usuario_servicio"].Value);
                //lblTipoCantidad.Text = String.Format("{0}:", dgvServiciosActivos5.CurrentRow.Cells["tipo"].Value.ToString());
                lblTipoCantidadPac.Text = String.Format("{0} P.:", lblTipoCantidad.Text);
                lbBocas.Text = dgvServiciosActivos.CurrentRow.Cells["cant_bocas"].Value.ToString();
                lbBocas_Pac.Text = dgvServiciosActivos.CurrentRow.Cells["Cant_Bocas_Pac"].Value.ToString();
                //Usuarios_Servicios.Current_IdUsuarioServicio = Convert.ToInt32(dgvServiciosActivos5.CurrentRow.Cells["id_usuario_servicio"].Value);
                lblMesesCobro.Text = dgvServiciosActivos.CurrentRow.Cells["meses_cobro"].Value.ToString();
                lblMesesServicio.Text = dgvServiciosActivos.CurrentRow.Cells["meses_servicio"].Value.ToString();
                //btnUF.Enabled = dgvServiciosActivos5.CurrentRow.Cells["tipo"].Value.ToString() == "BO" ? false : true;
            }
            catch (Exception)
            {
                throw;

            };
        }

        private void dgvServiciosActivos_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            Int32 mue = 0;
            if (dgvServiciosActivos.Columns[e.ColumnIndex].Name == "Equipos")
            {
                VerEquipos();
            }

        }

        private void btnCambioEquipo_Click(object sender, EventArgs e)
        {
            if (dgvServiciosActivos.SelectedCells.Count > 0)
            {
                frmMain frmmain = frmMain.Instance();
                if (Usuarios.CurrentUsuario.Id != 0)
                {
                    Equipos oEquipo = new Equipos();
                    DataTable dtEquipos = oEquipo.BuscarEquipoPorUsuarioServicio(Convert.ToInt32(dgvServiciosActivos.SelectedCells[0].OwningRow.Cells["id_usuario_servicio"].Value));
                    if (dtEquipos.Rows.Count > 0)
                    {
                        frmEquiposCambio frm = new frmEquiposCambio(Usuarios.Current_IdUsuario, Convert.ToInt32(dgvLocaciones.SelectedRows[0].Cells["id"].Value.ToString()));
                        frm.idUsuarioServicio = Convert.ToInt32(dgvServiciosActivos.SelectedCells[0].OwningRow.Cells["id_usuario_servicio"].Value);
                        frmmain.openForm(frm);
                    }
                }
                else
                {
                    try
                    {
                        Buscar();
                        frmEquiposCambio frm = new frmEquiposCambio(Usuarios.Current_IdUsuario, Convert.ToInt32(dgvLocaciones.SelectedRows[0].Cells["id"].Value.ToString()));
                        frmmain.openForm(frm);
                    }
                    catch { }
                }
            }
            else
                MessageBox.Show("Debe seleccionar un servicio de la grilla de servicios contratados.");
        }

        private void btnNovedades_Click(object sender, EventArgs e)
        {
            if (Usuarios.CurrentUsuario.Id != 0)
            {
                using (frmPopUp frm = new frmPopUp())
                {
                    Cuenta_Corriente.frmUsuariosCtaCteNovedades frmO = new Cuenta_Corriente.frmUsuariosCtaCteNovedades();
                    frm.Formulario = frmO;
                    frm.Maximizar = false;
                    frm.ShowDialog();
                }
            }
        }

        private void btnObs_Click(object sender, EventArgs e)
        {
            if (Usuarios.CurrentUsuario.Id != 0)
            {
                using (frmPopUp frm = new frmPopUp())
                {
                    ABMUsuariosObs frmO = new ABMUsuariosObs();
                    frmO.idUsuario = Usuarios.Current_IdUsuario;
                    frm.Formulario = frmO;
                    frm.Maximizar = false;
                    frm.ShowDialog();
                }
            }
        }

        private void btnContratacion_Click(object sender, EventArgs e)
        {
            if (Usuarios.CurrentUsuario.Id != 0)
            {
                frmParteConexion frm;
                if (Usuarios.CurrentUsuario.Id_Usuarios_Tipos != 0)
                    frm = new frmParteConexion(Usuarios.CurrentUsuario.Id_Usuarios_Tipos);
                else
                    frm = new frmParteConexion(1);

                frm.IdUsuario = Usuarios.CurrentUsuario.Id;

                DialogResult dialogResult = MessageBox.Show("¿Desea Contratar Servicios en la Misma Locacion?", "Mensaje del Sistema",
                    MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Yes)
                    frm.MismaLocacion = true;
                else if (dialogResult == DialogResult.No)
                    frm.MismaLocacion = false;
                else
                    return;

                frm.TipoOperacion = 1;
                frmMain.Instance().openForm(frm);
            }
            else
            {
                MessageBox.Show("Debe Seleccionar un Usuario", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                btnBuscar.PerformClick();
            }
        }

        private void btnNotificaciones_Click(object sender, EventArgs e)
        {
            AbmNotificaciones frmNotificaciones = new AbmNotificaciones();
            frmMain.Instance().openForm(frmNotificaciones);
        }

        private void btnLocacionesFiscales_Click(object sender, EventArgs e)
        {
            if (Usuarios.CurrentUsuario.Id > 0)
            {
                ABMLocaciones_Fiscales ABMLocacionesFiscales = new ABMLocaciones_Fiscales(Usuarios.CurrentUsuario.Id);
                frmPopUp frmpopup = new frmPopUp();
                frmpopup.Maximizar = false;
                frmpopup.Formulario = ABMLocacionesFiscales;
                frmpopup.ShowDialog();
                if (frmpopup.DialogResult == DialogResult.OK)
                    comenzarCarga();
            }

        }

        private void dgvServiciosActivos_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                Usuarios_Servicios.Current_IdUsuarioServicio = Convert.ToInt32(dgvServiciosActivos.CurrentRow.Cells["id_usuario_servicio"].Value);
            }
            catch { }
        }

        private void frmUsuariosPrincipal_Load(object sender, EventArgs e)
        {
            comenzarCarga();
        }

        private void btnUF_Click(object sender, EventArgs e)
        {
            if (Usuarios_Servicios.Current_IdUsuarioServicio != 0)
            {
                using (frmPopUp frm = new frmPopUp())
                {
                    ABMUnidadesFuncionales frmABM = new ABMUnidadesFuncionales();
                    frm.Formulario = frmABM;
                    frm.Maximizar = false;

                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        if (frmABM.idUsuario > 0)
                        {
                            oUsu.Tipo_Busqueda = "C";
                            oUsu.LlenarObjeto(frmABM.idUsuario);
                            comenzarCarga();
                        }
                    }
                }
            }
        }

        private void boton1_Click(object sender, EventArgs e)
        {

            if (dgvServiciosActivos.Rows.Count > 0)
            {
                if (dgvServiciosActivos.SelectedCells.Count > 0)
                {
                    frmPopUp opop = new frmPopUp();
                    frmBusquedaUsuSerSub ofrm = new frmBusquedaUsuSerSub();
                    ofrm.idUsuario = Convert.ToInt32(dgvServiciosActivos.CurrentRow.Cells["id_usuarios"].Value);
                    DataTable dtSub = new DataTable();
                    opop.Formulario = ofrm;

                    int idDescuento = 0, idUsuSer = Convert.ToInt32(dgvServiciosActivos.CurrentRow.Cells["id_usuario_servicio"].Value);

                    DataTable dtDescuentosEspeciales = new DataTable();
                    Bonificaciones oBonificaciones = new Bonificaciones();
                    DataView dtvDecuentosEspeciales;
                    dtDescuentosEspeciales = oBonificaciones.ListarPorTipo(Convert.ToInt32(Bonificaciones.TIPO_BONIFICACION.ESPECIAL));
                    if (dtDescuentosEspeciales.Rows.Count > 0)
                    {
                        if (dtDescuentosEspeciales.Select(String.Format("modalidad_venta_pago={0}", Convert.ToInt32(Bonificaciones.MODALIDAD_VENTA_PAGO.VENTA))).Count() > 0)
                        {
                            dtvDecuentosEspeciales = new DataView(dtDescuentosEspeciales);
                            dtvDecuentosEspeciales.RowFilter = String.Format("modalidad_venta_pago={0}", Convert.ToInt32(Bonificaciones.MODALIDAD_VENTA_PAGO.VENTA));
                            frmBonificacionesEspeciales frmBonificacionesEspeciales = new frmBonificacionesEspeciales(dtvDecuentosEspeciales.ToTable());
                            frmPopUp frmpp = new frmPopUp();
                            frmpp.Formulario = frmBonificacionesEspeciales;
                            frmpp.Maximizar = false;
                            frmpp.ShowDialog();
                            if (frmBonificacionesEspeciales.DialogResult == DialogResult.OK)
                            {
                                idDescuento = frmBonificacionesEspeciales.idDescuentoSeleccionado;
                                if (idDescuento > 0)
                                {
                                    DataTable dtSubServicios = new DataTable();
                                    if (opop.ShowDialog() == DialogResult.OK)
                                    {
                                        dtSubServicios = ofrm.dtSubServiciosElegidos;
                                        if (dtSubServicios.Rows.Count > 0)
                                        {
                                            if (oUsuariosServicios.ActualizarBonificacionEsp(idDescuento, dtSubServicios) == 0)
                                            {
                                                MessageBox.Show("Bonificacion asiganada correctamente", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                comenzarCarga();
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                            MessageBox.Show("No hay descuentos especiales cargados en el sistema.");
                    }
                    else
                        MessageBox.Show("No hay descuentos especiales cargados en el sistema.");
                }
                else
                    MessageBox.Show("No ha seleccionado un subservicio.");
            }
            else
                MessageBox.Show("No hay servicios en la grilla.");
        }

        private void frmUsuariosPrincipal_KeyPress(object sender, KeyPressEventArgs e)
        {
            int control = Convert.ToInt32(Keys.Control);
            int g = Convert.ToInt32(Keys.E);
            int ke = Convert.ToInt32(e.KeyChar);

            if (Convert.ToInt32(e.KeyChar) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.G))
            {
                frmPopUp oPop = new frmPopUp();
                frmBusquedaUsuSerSub oFrm = new frmBusquedaUsuSerSub();
                oFrm.idUsuario = Usuarios.CurrentUsuario.Id;
                oFrm.eliminar = 0;
                oFrm.cambiaEstado = 1;
                oPop.Formulario = oFrm;
                oPop.ShowDialog();
                if (oFrm.cambiaEstado == 1)
                    comenzarCarga();
            }
            if (Convert.ToInt32(e.KeyChar) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.N))
            {
                frmPopUp oPop = new frmPopUp();
                frmBusquedaUsuSerSub oFrm = new frmBusquedaUsuSerSub();
                oFrm.idUsuario = Usuarios.CurrentUsuario.Id;
                oFrm.eliminar = 1;
                oPop.Formulario = oFrm;
                oPop.ShowDialog();
                if (oFrm.eliminado == 1)
                    comenzarCarga();
            }


        }

        private void frmUsuariosPrincipal_KeyUp(object sender, KeyEventArgs e)
        {
            if (Convert.ToInt32(e.KeyData) == Convert.ToInt32(Keys.Control) + Convert.ToInt32(Keys.N))
            {
                frmPopUp oPop = new frmPopUp();
                frmBusquedaUsuSerSub oFrm = new frmBusquedaUsuSerSub();
                oFrm.idUsuario = Usuarios.CurrentUsuario.Id;
                oFrm.eliminar = 1;
                oPop.Formulario = oFrm;
                if (oPop.ShowDialog() == DialogResult.OK)
                {
                    comenzarCarga();
                }
            }
        }

        private void dgvServiciosActivos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                switch (dgvServiciosActivos.Columns[e.ColumnIndex].Name.ToString())
                {
                    case "fecha_factura":
                        frmFechaFactura FRM = new frmFechaFactura();
                        FRM.Id_Usuarios_Servicios = Convert.ToInt32(dgvServiciosActivos.CurrentRow.Cells["id_usuario_servicio"].Value);
                        FRM.Fecha_Factura = Convert.ToDateTime(dgvServiciosActivos.CurrentRow.Cells["fecha_factura"].Value);
                        FRM.Servicio = dgvServiciosActivos.CurrentRow.Cells["servicio"].Value.ToString();

                        using (frmPopUp frmpo = new frmPopUp())
                        {
                            frmpo.Formulario = FRM;
                            frmpo.Maximizar = false;

                            frmpo.ShowDialog();
                        }
                        break;
                    case "bonificacion_esp":
                        if (MessageBox.Show("¿Desea Eliminar la Bonificacion Especial?", "Mensaje del Sistema",
                            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            try
                            {
                                frmPopUp oPop = new frmPopUp();
                                frmResponsable frmre = new frmResponsable();
                                oPop.Formulario = frmre;
                                oPop.Maximizar = false;
                                if (oPop.ShowDialog() == DialogResult.OK)
                                {
                                    oUsuariosServicios.QuitarBonificacionesEspeciales(Convert.ToInt32(dgvServiciosActivos.CurrentRow.Cells["id_usuario_servicio"].Value));
                                    this.comenzarCarga();
                                }
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("No se puede eliminar el movimiento", "Baja de Movimiento", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        break;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void btnEditarDatosLocacion_Click(object sender, EventArgs e)
        {
            if (dgvLocaciones.SelectedRows.Count > 0)
            {
                ABMEdicionLocacion frmEdicionLocacion = new ABMEdicionLocacion(Convert.ToInt32(dgvLocaciones.SelectedRows[0].Cells["id"].Value));
                frmPopUp frmpp = new frmPopUp();
                frmpp.Formulario = frmEdicionLocacion;
                frmpp.Maximizar = false;
                frmpp.ShowDialog();
            }
        }

        private void cmsUsuarioServicio_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void dgvServiciosActivos_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void cmsUsuarioServicio_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Name == "mnuVerISP")
            {
                frmPopUp oPop = new frmPopUp();

                //ISP VIEJO
               /* frmVerISP oVerISP = new frmVerISP();
                 oVerISP.idUsuario = Usuarios.CurrentUsuario.Id;
                  oVerISP.idUsuarioServicio = Convert.ToInt32(dgvServiciosActivos.CurrentRow.Cells["id_usuario_servicio"].Value);
                  oVerISP.idServicio = Convert.ToInt32(dgvServiciosActivos.CurrentRow.Cells["id_servicio"].Value);
                  oVerISP.codUsuario = Usuarios.CurrentUsuario.Codigo;
                  oVerISP.nombreUsuario = Usuarios.CurrentUsuario.Apellido + ", " + Usuarios.CurrentUsuario.Nombre;
                  oVerISP.locacion = dgvLocaciones.SelectedRows[0].Cells["calle"].Value.ToString() + " " + dgvLocaciones.SelectedRows[0].Cells["altura"].Value.ToString() + " " + dgvLocaciones.SelectedRows[0].Cells["piso"].Value.ToString() + " " + dgvLocaciones.SelectedRows[0].Cells["depto"].Value.ToString();
                  oVerISP.servicio = dgvServiciosActivos.CurrentRow.Cells["servicio"].Value.ToString();
                  oVerISP.telefonoUsuario = "(" + dgvLocaciones.SelectedRows[0].Cells["prefijo_1"].Value.ToString() + ") " + dgvLocaciones.SelectedRows[0].Cells["telefono_1"].Value.ToString();
                  oVerISP.ver = true;*/

                //ISP NUEVO
                AppExternas.frmVerISPNuevo oVerISP = new AppExternas.frmVerISPNuevo();
                oVerISP.id_usuarioGlobal = Usuarios.CurrentUsuario.Id;
                oVerISP.id_usuarioServicioGlobal = Convert.ToInt32(dgvServiciosActivos.CurrentRow.Cells["id_usuario_servicio"].Value);
                oVerISP.id_servicioGlobal = Convert.ToInt32(dgvServiciosActivos.CurrentRow.Cells["id_servicio"].Value);

                oPop.Formulario = oVerISP;
                oPop.Maximizar = true;
                oPop.ShowDialog();

            }
            if (e.ClickedItem.Name == "mnuVerEquipos")
                VerEquipos();
        }

        private void btnDebito_Click(object sender, EventArgs e)
        {
            if (Usuarios.CurrentUsuario.Id > 0)
            {
                if (btnDebito.BackColor == Color.FromArgb(255, 50, 50))
                {
                    ABMPlasticos_Usuarios ABMPlasticosUsuario = new ABMPlasticos_Usuarios(Convert.ToInt32(Usuarios.Current_dtServicios_Debitos.Rows[0]["id"]), Usuarios.Current_dtServicios_Debitos.Rows[0]["numero"].ToString(), Usuarios.Current_dtServicios_Debitos.Rows[0]["titular"].ToString());
                    ABMPlasticosUsuario.ShowDialog();
                }
                else
                {
                    if (MessageBox.Show("El abonado no esta adherido a débito automático. ¿Desea dar de alta una nueva tarjeta y asociarle servicios?", "Mensaje del Sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Debitos_Automaticos.frmNuevoDebito oFrmNuevo = new Debitos_Automaticos.frmNuevoDebito();
                        if (oFrmNuevo.ShowDialog() == DialogResult.OK)
                            comenzarCarga();
                    }
                }
            }
        }

        private void dgvLocaciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (Convert.ToInt32(dgvLocaciones.SelectedRows[0].Cells["activo1"].Value) == 1)
                    DeseleccionarLocacion();
            }
            catch
            {

            }
        }

        private void dgvLocaciones_SelectionChanged(object sender, EventArgs e)
        {
            if (cargado == true)
            {
                try
                {
                    if (Convert.ToInt32(dgvLocaciones.SelectedRows[0].Cells["activo1"].Value) == 1)
                        DeseleccionarLocacion();
                }
                catch
                {
                }
            }
        }

        public void dgvLocaciones_Seleccionar()
        {
            if (Usuarios.CurrentUsuario.Id_Usuarios_Locacion > 0)
            {
                DeseleccionarLocacion();
                for (int i = 0; i < dtLocaciones.Rows.Count; i++)
                {
                    if (Convert.ToInt32(dtLocaciones.Rows[i]["id"]) == Usuarios.CurrentUsuario.Id_Usuarios_Locacion)
                        dgvLocaciones.Rows[i].Selected = true;
                }
            }
        }
        private void verHistorialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmPopUp oPop = new frmPopUp();
            frmServiciosHistorial oHistorial = new frmServiciosHistorial(idUsuarioServicio);
            oPop.Formulario = oHistorial;
            oPop.Maximizar = true;
            oPop.ShowDialog();
        }

        private void bTarjeta_Click(object sender, EventArgs e)
        {
            txtbusca.Text = "";
            txtbuscaraltura.Text = "";
            txtbusca.Focus();
        }

        private void verCASSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //DECLARACIONES OBJETOS
            Cass oCass = new Cass(Convert.ToInt32(Tablas.DataCass.Rows[0]["id"]));
            Equipos oEqui = new Equipos();
            Partes_Equipos oparteEquipo = new Partes_Equipos();

            //TABLAS
            DataTable dtEquiposUsuario = new DataTable();
            DataTable dtTarjetaAsociada = new DataTable();
            DataRow drUsuServ;

            //VARIABLES SIMPLES
            int id_tipoFact = Convert.ToInt32(dgvServiciosActivos.CurrentRow.Cells["id_tipo_facturacion"].Value);
            int id_Usuario_Servicios = Convert.ToInt32(dgvServiciosActivos.CurrentRow.Cells["id_usuario_servicio"].Value);
            int id_estadoServicio = 0;
            //ASIGNACIONES
            dtEquiposUsuario = oEqui.BuscarEquipoPorUsuarioServicio(id_Usuario_Servicios);
            dtTarjetaAsociada = oparteEquipo.ListarPorUsuarioServicio(id_Usuario_Servicios);
            drUsuServ = oUsuariosServicios.getInfoUsuServicio(id_Usuario_Servicios);
            if(!(drUsuServ[0] is DBNull))
                id_estadoServicio = Convert.ToInt32(drUsuServ["id_servicios_estados"]);

            //oCass.GenerarDtTarjetas(DataTable dt);
            if (id_estadoServicio > 0)
            {
                if (id_estadoServicio != (int)Servicios.Servicios_Estados.RETIRADO)
                {
                    if (dtEquiposUsuario.Rows.Count > 0)
                    {
                        FrmCass oFCass;
                        frmPopUp oPop = new frmPopUp();
                        oFCass = new FrmCass(Convert.ToString(dtEquiposUsuario.Rows[0]["numtarjeta"]), idUsuarioServicio);
                        oFCass.id_Tipo_facturacion = id_tipoFact;
                        oPop.Formulario = oFCass;
                        oPop.Maximizar = true;
                        oPop.ShowDialog();
                    }
                    else if (dtTarjetaAsociada.Rows.Count > 0)
                    {
                        frmPopUp oPop = new frmPopUp();
                        FrmCass oFCass;
                        oFCass = new FrmCass(Convert.ToString(dtTarjetaAsociada.Rows[0]["numero"]), idUsuarioServicio);
                        oFCass.id_Tipo_facturacion = id_tipoFact;
                        oPop.Formulario = oFCass;
                        oPop.Maximizar = true;
                        oPop.ShowDialog();
                    }
                    else
                    {
                        frmPopUp oPop = new frmPopUp();
                        FrmCass oFCass = new FrmCass("", idUsuarioServicio);
                        oPop.Formulario = oFCass;
                        oPop.Maximizar = true;
                        oPop.ShowDialog();
                    }
                }
                else
                {
                    MessageBox.Show("El servicio se encuentra retirado, no podra realizar acciones sobre el CASS");
                    frmPopUp oPop = new frmPopUp();
                    FrmCass oFCass = new FrmCass("", idUsuarioServicio);
                    oFCass.servicioRetirado = true;
                    oPop.Formulario = oFCass;
                    oPop.Maximizar = true;
                    oPop.ShowDialog();
                }

            }
            else
                MessageBox.Show("No se pudo encontrar el estado del servicio");
        }

        private void actualizarFechaDeServicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(dgvServiciosActivos.SelectedCells.Count>0)
            {

                int idUsuarioServicio = Convert.ToInt32(dgvServiciosActivos.Rows[dgvServiciosActivos.SelectedCells[0].RowIndex].Cells["id_usuario_servicio"].Value);
                if (oUsuariosServicios.ActualizarFechaFacturaPorDet(idUsuarioServicio))
                {
                    dtServiciosContratados = oUsuariosServicios.ListarServiciosYSubServiciosActivos(Usuarios.CurrentUsuario.Id);
                }
                else
                    MessageBox.Show("Hubo un error al intentar actualizar la fecha del servicio");
            }
        }

        private void btnUnificarLocaciones_Click(object sender, EventArgs e)
        {

            frmMain frmmain = frmMain.Instance();
            frmmain.openForm(new frmUnificarLocacion());

        }

        private void pnlSuperior_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnMapas_Click(object sender, EventArgs e)
        {
            Mapas.frmGeolocalizacion oFormulario = new Mapas.frmGeolocalizacion();
            oFormulario.ShowDialog();
        }

        private void btnDirec_Click(object sender, EventArgs e)
        {
            Mapas.frmDireccionMapa oFormulario = new Mapas.frmDireccionMapa();
            oFormulario.ShowDialog();
        }

        private void btnVerMapa_Click(object sender, EventArgs e)
        {
            if (Usuarios.CurrentUsuario.Id != 0)
            {
                Mapas.frmVerUsuarioMapa oFormulario = new Mapas.frmVerUsuarioMapa();
                oFormulario.ShowDialog();
            }
            else
                MessageBox.Show("Primero busque un Usuario");
        }

        private void boton2_Click(object sender, EventArgs e)
        {
            PagosExternos.CaptarPagos.frmListaPagos olista = new PagosExternos.CaptarPagos.frmListaPagos();
            frmPopUp oPop = new frmPopUp();
            oPop.Formulario = olista;
            oPop.ShowDialog();
        }

        private void boton3_Click(object sender, EventArgs e)
        {
            PagosExternos.frmPagosGuardados olista = new PagosExternos.frmPagosGuardados();
            frmPopUp oPop = new frmPopUp();
            oPop.Formulario = olista;
            oPop.ShowDialog();
        }

        private void mnuVerISP_Click(object sender, EventArgs e)
        {

        }

        private void dgvServiciosActivos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
            {
                if (GrillaCompleta)
                {
                    GrillaCompleta = false;
                    dgvServiciosActivos.Columns["servicio_sub"].Frozen = false;
                    dgvServiciosActivos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgvServiciosActivos.Columns["servicio_sub"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;

                    FormatearGrillaNueva();

                }
                else
                {
                    foreach (DataGridViewColumn item in dgvServiciosActivos.Columns)
                        item.Visible = true;
                    dgvServiciosActivos.Columns["servicio_sub"].Frozen = true;
                    dgvServiciosActivos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                    GrillaCompleta = true;
                }
            }
        }

        private void dgvServiciosActivos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int idUsuSer = Convert.ToInt32(dgvServiciosActivos.CurrentRow.Cells["id_usuario_servicio"].Value);
            Controles();
            try
            {
                foreach (DataGridViewRow item in dgvServiciosActivos.Rows)
                {
                    if (Convert.ToInt32(item.Cells["id_usuario_servicio"].Value) == idUsuSer)
                    {
                        string sub = item.Cells["servicio_sub"].Value.ToString();
                        if ((Convert.ToInt32(item.Cells["id_tipo"].Value) != 1))
                        {
                            if (item.Visible == false)
                                item.Visible = true;
                            else
                                item.Visible = false;

                        }
                        else
                        {
                            if ((Convert.ToInt32(item.Cells["id_tipo"].Value) != 1))
                                item.Visible = false;
                        }
                    }
                }
            }
            catch (Exception ex) { }
        }

        private void dgvServiciosActivos_CellEnter_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Controles();

                idUsuarioServicio = Convert.ToInt32(dgvServiciosActivos.CurrentRow.Cells["id_usuario_servicio"].Value);
                //   lblTipoCantidad.Text = String.Format("{0}:", dgvServiciosActivos.CurrentRow.Cells["usuario_tipo"].Value.ToString());
                //   lblTipoCantidadPac.Text = String.Format("{0} P.:", lblTipoCantidad.Text);
                lbBocas.Text = dgvServiciosActivos.CurrentRow.Cells["cant_bocas"].Value.ToString();
                lbBocas_Pac.Text = dgvServiciosActivos.CurrentRow.Cells["Cant_Bocas_Pac"].Value.ToString();
                Usuarios_Servicios.Current_IdUsuarioServicio = Convert.ToInt32(dgvServiciosActivos.CurrentRow.Cells["id_usuario_servicio"].Value);
                lblMesesCobro.Text = dgvServiciosActivos.CurrentRow.Cells["meses_cobro"].Value.ToString();
                lblMesesServicio.Text = dgvServiciosActivos.CurrentRow.Cells["meses_servicio"].Value.ToString();
                // btnUF.Enabled = dgvServiciosActivos.CurrentRow.Cells["usuario_tipo"].Value.ToString() == "BO" ? false : true;

            }
            catch
            {

            };
        }

        private void lblUsuarioPadreDato_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (lblUsuarioPadreDato.Text != "-")
            {
                oUsu.Tipo_Busqueda = "C";
                oUsu.LlenarObjeto(idUsuarioPadre);
                comenzarCarga();
            }
        }

        private void dgvServiciosActivos_CellMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            Controles();

            if (dgvServiciosActivos.Columns[e.ColumnIndex].Name == "Equipos")
            {
                if (dgvServiciosActivos.Columns[e.ColumnIndex].Name == "Equipos")
                {
                    if (dgvServiciosActivos.Rows[e.RowIndex].Cells["requiere_equipo"].Value.ToString().Equals("SI"))
                        VerEquipos();
                    else
                        MessageBox.Show("Este servicio no requiere equipos.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            if (e.Button == MouseButtons.Right)
            {
                try
                {
                    var hti = dgvServiciosActivos.HitTest(e.X, e.Y);
                    // Add this
                    dgvServiciosActivos.CurrentCell = dgvServiciosActivos.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    // Can leave these here - doesn't hurt
                    dgvServiciosActivos.Rows[e.RowIndex].Selected = true;
                    dgvServiciosActivos.Focus();
                    
                    if(dgvServiciosActivos.CurrentRow.Cells["requiere_equipo"].Value.ToString().ToLower().Equals("si"))
                        mnuVerEquipos.Enabled = true;
                    else
                        mnuVerEquipos.Enabled = false;

                    if (dgvServiciosActivos.CurrentRow.Cells["requiere_velocidad"].Value.ToString().ToLower().Equals("si"))
                        mnuVerISP.Enabled = true;
                    else
                        mnuVerISP.Enabled = false;

                    cmsUsuarioServicio.Show(Cursor.Position);

                }
                catch
                {

                }
            }
        }

        private void dgvServiciosActivos_SelectionChanged_1(object sender, EventArgs e)
        {
            try
            {
                if (dgvServiciosActivos.CurrentRow != null)
                    Usuarios_Servicios.Current_IdUsuarioServicio = Convert.ToInt32(dgvServiciosActivos.CurrentRow.Cells["id_usuario_servicio"].Value);
                Controles();
            }
            catch { }
        }
        #endregion

    }

}
//270919fede