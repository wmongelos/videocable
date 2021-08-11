using CapaNegocios;
using CapaPresentacion.Busquedas;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Abms
{
    public partial class ABMCargaEdicionNotificacion : Form
    {
        private int idNotificacion;
        Thread hilo;
        delegate void myDel();
        Notificaciones oNotificaciones = new Notificaciones();
        Notificaciones_Adjuntos oNotificacionesAdjuntos = new Notificaciones_Adjuntos();
        Notificaciones_Destinatarios oNotificacionesDestinatarios = new Notificaciones_Destinatarios();
        Partes oPartes = new Partes();
        DataTable dtDatosNotificacion, dtDatosDestinatarios, dtDatosAdjuntos, dtPosiblesDestinatarios, dtAdjuntosRecibidos;
        DateTime fechaDesde, fechaHasta;
        DialogResult dialogResult;


        private void ComenzarCarga()
        {
            hilo = new Thread(new ThreadStart(CargarDatos));
            hilo.IsBackground = true;
            hilo.Start();
        }

        private void CargarDatos()
        {
            try
            {
                dtDatosNotificacion = oNotificaciones.Listar(idNotificacion, 0, 0, fechaDesde, fechaHasta);
                dtDatosDestinatarios = oNotificacionesDestinatarios.Listar(idNotificacion);
                dtDatosAdjuntos = oNotificacionesAdjuntos.Listar(idNotificacion);
                if (dtAdjuntosRecibidos != null && dtAdjuntosRecibidos.Rows.Count > 0)
                {
                    foreach (DataRow adjunto in dtAdjuntosRecibidos.Rows)
                        dtDatosAdjuntos.Rows.Add(0, adjunto["idTipoAdjunto"], adjunto["idAdjunto"], 0, 0, "PARTE", adjunto["datosAdjunto"], 0, 0);
                }
                myDel MD = new myDel(AsignarDatos);
                this.Invoke(MD, new object[] { });
            }
            catch { }

        }

        private void AsignarDatos()
        {
            if (dtDatosNotificacion.Rows.Count > 0)
            {
                txtMensaje.Text = String.Format("{0}", dtDatosNotificacion.Rows[0]["mensaje"].ToString());
                cboPrioridad.SelectedIndex = Convert.ToInt32(dtDatosNotificacion.Rows[0]["id_prioridad"]);
                dtpFechaLimite.Value = Convert.ToDateTime(dtDatosNotificacion.Rows[0]["fecha_limite"]);
            }
            else
            {
                cboPrioridad.SelectedIndex = Convert.ToInt32(Notificaciones.PRIORIDAD.MEDIA);
                dtpFechaLimite.Value = DateTime.Now;
            }

            dgvDestinatarios.DataSource = dtDatosDestinatarios;
            dgvAdjuntos.DataSource = dtDatosAdjuntos;

            for (int x = 0; x < dgvDestinatarios.ColumnCount; x++)
                dgvDestinatarios.Columns[x].Visible = false;
            for (int x = 0; x < dgvAdjuntos.ColumnCount; x++)
                dgvAdjuntos.Columns[x].Visible = false;

            dgvDestinatarios.Columns["tipo_destinatario"].Visible = true;
            dgvDestinatarios.Columns["destinatario"].Visible = true;
            dgvAdjuntos.Columns["tipo_adjunto"].Visible = true;
            dgvAdjuntos.Columns["datos_adjunto"].Visible = true;

            dgvDestinatarios.Columns["tipo_destinatario"].HeaderText = "Tipo de destinatario";
            dgvDestinatarios.Columns["destinatario"].HeaderText = "Destinatario";
            dgvAdjuntos.Columns["tipo_adjunto"].HeaderText = "Tipo de adjunto";
            dgvAdjuntos.Columns["datos_adjunto"].HeaderText = "Adjunto";
            dgvAdjuntos.Columns["tipo_adjunto"].Width = 150;
        }

        private bool ValidarDatos()
        {
            bool respuesta = true;

            if (txtMensaje.Text == String.Empty)
            {
                MessageBox.Show("No se ha escrito ningún mensaje.");
                txtMensaje.Focus();
                return false;
            }

            if (dtDatosDestinatarios.Rows.Count == 0)
            {
                MessageBox.Show("La notificación debe contener al menos un destinatario.");
                btnAgregarDestinatario.Focus();
                return false;
            }

            if (dtpFechaLimite.Value == DateTime.Now)
            {
                dialogResult = MessageBox.Show("Está creando una notificación que tiene como fecha de respuesta o ejecución límite el día de hoy. ¿Desea continuar?", "", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                    return true;
                else
                {
                    dtpFechaLimite.Focus();
                    return false;
                }
            }

            if (dtDatosAdjuntos.Rows.Count == 0)
            {
                dialogResult = MessageBox.Show("La notificación no tiene datos adjuntos. ¿Desea continuar?", "", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                    return true;
                else
                {
                    btnBuscarAdjunto.Focus();
                    return false;
                }
            }

            return respuesta;
        }

        private void GuardarYEnviar()
        {
            if (ValidarDatos())
            {
                try
                {
                    oNotificaciones.Id = 0;
                    oNotificaciones.Fecha_Creacion = DateTime.Now;
                    oNotificaciones.Id_Tipo_Emisor = Convert.ToInt32(Notificaciones.TIPO_EMISOR.USUARIO);
                    oNotificaciones.Id_Emisor = Personal.Id_Login;
                    oNotificaciones.Mensaje = txtMensaje.Text;
                    oNotificaciones.Id_Prioridad = cboPrioridad.SelectedIndex + 1;
                    oNotificaciones.Fecha_Limite = dtpFechaLimite.Value;
                    oNotificaciones.Id_Estado_Notificacion = Convert.ToInt32(Notificaciones.ESTADO_NOTIFICACION.PENDIENTE);
                    oNotificaciones.Id_Area_Emisor = Personal.Id_Area;
                    oNotificaciones.Ejecutar = Convert.ToInt32(Notificaciones.EJECUTAR.No);
                    oNotificaciones.Id = oNotificaciones.Guardar(oNotificaciones);


                    foreach (DataRow destinatario in dtDatosDestinatarios.Rows)
                    {
                        oNotificacionesDestinatarios.Id = 0;
                        oNotificacionesDestinatarios.Id_Notificacion_Origen = oNotificaciones.Id;
                        oNotificacionesDestinatarios.Id_Tipo_Destinatario = Convert.ToInt32(destinatario["id_tipo_destinatario"]);
                        oNotificacionesDestinatarios.Id_Destinatario = Convert.ToInt32(destinatario["id_destinatario"]);
                        oNotificacionesDestinatarios.Id_Estado_Notificacion_Destinatario = Convert.ToInt32(Notificaciones_Destinatarios.Estado_Notificacion.PENDIENTE);
                        oNotificacionesDestinatarios.Guardar(oNotificacionesDestinatarios);
                    }

                    foreach (DataRow adjunto in dtDatosAdjuntos.Rows)
                    {
                        oNotificacionesAdjuntos.Id = 0;
                        oNotificacionesAdjuntos.Id_Tipo_Modulo_Sistema = Convert.ToInt32(adjunto["id_tipo_modulo_sistema"]);
                        oNotificacionesAdjuntos.Id_Item_Modulo = Convert.ToInt32(adjunto["id_adjunto"]);
                        oNotificacionesAdjuntos.Id_Estado_Realizacion = Convert.ToInt32(Notificaciones_Adjuntos.ESTADO.PENDIENTE);
                        oNotificacionesAdjuntos.Id_Notificacion = oNotificaciones.Id;

                        oNotificacionesAdjuntos.Guardar(oNotificacionesAdjuntos);
                    }
                    MessageBox.Show("Notificación registrada correctamente.");
                    this.DialogResult = DialogResult.OK;
                }
                catch
                {
                    MessageBox.Show("Error al guardar notificación.");
                }
            }
        }

        private void BuscarDestinatario()
        {
            dtPosiblesDestinatarios = oNotificacionesDestinatarios.ListarPosiblesDestinatarios();
            dgvPosiblesDestinatarios.DataSource = dtPosiblesDestinatarios;
            for (int x = 0; x < dgvPosiblesDestinatarios.ColumnCount; x++)
                dgvPosiblesDestinatarios.Columns[x].Visible = false;

            dgvPosiblesDestinatarios.Columns["tipo_destinatario"].Visible = true;
            dgvPosiblesDestinatarios.Columns["area_destinatario"].Visible = true;
            dgvPosiblesDestinatarios.Columns["destinatario"].Visible = true;

            dgvPosiblesDestinatarios.Columns["tipo_destinatario"].HeaderText = "Tipo de destinatario";
            dgvPosiblesDestinatarios.Columns["area_destinatario"].HeaderText = "Área";
            dgvPosiblesDestinatarios.Columns["destinatario"].HeaderText = "Destinatario";

            panelDestinatarios.Location = new Point(
                        this.ClientSize.Width / 2 - panelDestinatarios.Size.Width / 2,
                        this.ClientSize.Height / 2 - panelDestinatarios.Size.Height / 2);
            panelDestinatarios.Anchor = AnchorStyles.None;
            panelDestinatarios.Visible = true;
        }

        private void QuitarDestinatario()
        {
            if (dgvDestinatarios.SelectedRows.Count > 0)
            {
                dtDatosDestinatarios.Rows.RemoveAt(dgvDestinatarios.SelectedRows[0].Index);
                dtDatosDestinatarios.AcceptChanges();
            }
            else
                MessageBox.Show("No se ha seleccionado un destinatario.");
        }

        private void AgregarDestinatario()
        {
            if (dgvPosiblesDestinatarios.SelectedRows.Count > 0)
            {
                DateTime fecha = new DateTime();
                dtDatosDestinatarios.Rows.Add(0, 0, Convert.ToInt32(dgvPosiblesDestinatarios.SelectedRows[0].Cells["id_tipo_destinatario"].Value), Convert.ToInt32(dgvPosiblesDestinatarios.SelectedRows[0].Cells["id_destinatario"].Value), 0, 0, dgvPosiblesDestinatarios.SelectedRows[0].Cells["tipo_destinatario"].Value.ToString(), dgvPosiblesDestinatarios.SelectedRows[0].Cells["destinatario"].Value.ToString(), "", fecha.Date, "", fecha.Date);
                dtDatosDestinatarios.AcceptChanges();
            }
            else
                MessageBox.Show("No ha seleccionado datos.");
        }

        private void BuscarAdjuntos()
        {
            frmPopUp frmPU = new frmPopUp();
            List<int> listaEstadosParte = new List<int>();
            DataRow drDatosParte;

            if ((cboTipoAdjunto.SelectedIndex + 1) == Convert.ToInt32(Notificaciones_Adjuntos.TIPO_ADJUNTOS.PARTE))
            {
                frmBusquedaPartes frmBusquedaParte = new frmBusquedaPartes();
                listaEstadosParte.Add(Convert.ToInt32(Partes.Partes_Estados.PENDIENTE_DE_ASIGNACION_DE_TECNICO));
                listaEstadosParte.Add(Convert.ToInt32(Partes.Partes_Estados.PENDIENTE_DE_ASIGNACION_DE_EQUIPO));
                listaEstadosParte.Add(Convert.ToInt32(Partes.Partes_Estados.PENDIENTE_DE_ASIGNACION_DE_TARJETA));
                listaEstadosParte.Add(Convert.ToInt32(Partes.Partes_Estados.ASIGNADO));
                frmBusquedaParte.AsignarListaEstados(listaEstadosParte);
                frmPU.Formulario = frmBusquedaParte;
                frmPU.ShowDialog();
                if (frmPU.DialogResult == DialogResult.OK)
                {
                    drDatosParte = oPartes.TraerParteRow(frmBusquedaParte.id_parte_seleccionado);
                    if (drDatosParte != null)
                    {
                        dtDatosAdjuntos.Rows.Add(0, Convert.ToString(cboTipoAdjunto.SelectedIndex + 1), drDatosParte["id"].ToString(), 0, 0, "PARTE", String.Format("Nro.de parte: {0}, - Solicitud: {1}{2}Operación: {3}", drDatosParte["id"].ToString(), drDatosParte["solicitud"].ToString(), Environment.NewLine, drDatosParte["operacion"].ToString()), "0", "0");
                        dtDatosAdjuntos.AcceptChanges();
                    }
                }
            }
            else if ((cboTipoAdjunto.SelectedIndex + 1) != Convert.ToInt32(Notificaciones_Adjuntos.TIPO_ADJUNTOS.PARTE))
            {
                frmBusquedaUsuarios frm = new frmBusquedaUsuarios(1, "", "");
                DataRow drDatosUsuarioLocacion;
                frmPU.Maximizar = true;
                frmPU.Formulario = frm;

                if (frmPU.ShowDialog() == DialogResult.OK)
                {
                    drDatosUsuarioLocacion = frm.usuario_e;
                    if (drDatosUsuarioLocacion != null)
                    {
                        if ((cboTipoAdjunto.SelectedIndex + 1) == Convert.ToInt32(Notificaciones_Adjuntos.TIPO_ADJUNTOS.USUARIO))
                            dtDatosAdjuntos.Rows.Add(0, Convert.ToString(cboTipoAdjunto.SelectedIndex + 1), drDatosUsuarioLocacion["id"].ToString(), 0, 0, "USUARIO", String.Format("Código: {0}  Usuario: {1} {2}", drDatosUsuarioLocacion["codigo_usuario"], drDatosUsuarioLocacion["apellido"], drDatosUsuarioLocacion["nombre"]), "0", "0");
                        else
                            dtDatosAdjuntos.Rows.Add(0, Convert.ToString(cboTipoAdjunto.SelectedIndex + 1), drDatosUsuarioLocacion["id"].ToString(), 0, 0, "LOCACIÓN", String.Format("Calle:{0} Altura:{1} Piso:{2} Depto.:{3} Localidad:{4}", drDatosUsuarioLocacion["calle"], drDatosUsuarioLocacion["altura"], drDatosUsuarioLocacion["piso"], drDatosUsuarioLocacion["depto"], drDatosUsuarioLocacion["localidad"]), "0", "0");
                        dtDatosAdjuntos.AcceptChanges();
                    }
                }
            }
        }

        private void QuitarAdjuntos()
        {
            if (dgvAdjuntos.SelectedRows.Count > 0)
            {
                dtDatosAdjuntos.Rows.RemoveAt(dgvAdjuntos.SelectedRows[0].Index);
                dtDatosAdjuntos.AcceptChanges();
            }
            else
                MessageBox.Show("No se ha seleccionado un adjunto para eliminar.");
        }


        private void btnEnviar_Click(object sender, EventArgs e)
        {
            GuardarYEnviar();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            panelDestinatarios.Visible = false;
        }

        private void btnSeleccionarDestinatario_Click(object sender, EventArgs e)
        {
            AgregarDestinatario();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            QuitarDestinatario();
        }

        private void btnBuscarAdjunto_Click(object sender, EventArgs e)
        {
            BuscarAdjuntos();
        }

        private void lblTipoAdjunto_Click(object sender, EventArgs e)
        {

        }

        private void cboTipoAdjunto_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void boton1_Click(object sender, EventArgs e)
        {
            QuitarAdjuntos();
        }

        private void txtMensaje_TextChanged(object sender, EventArgs e)
        {

        }

        private void AbmCargaEdicionNotificacion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (panelDestinatarios.Visible)
                    panelDestinatarios.Visible = false;
                else
                    this.Close();
            }
        }

        private void panelDestinatarios_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnAgregarDestinatario_Click(object sender, EventArgs e)
        {
            BuscarDestinatario();
        }

        public ABMCargaEdicionNotificacion(int idNotificacion, DataTable dtAdjuntosRecibidos)
        {
            this.idNotificacion = idNotificacion;
            this.dtAdjuntosRecibidos = new DataTable();
            this.dtAdjuntosRecibidos = dtAdjuntosRecibidos;
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AbmCargaEdicionNotificacion_Load(object sender, EventArgs e)
        {
            dtDatosNotificacion = new DataTable();
            dtDatosDestinatarios = new DataTable();
            dtDatosAdjuntos = new DataTable();
            dtPosiblesDestinatarios = new DataTable();
            cboTipoAdjunto.SelectedIndex = 0;

            if (idNotificacion > 0)
                lblTituloHeader.Text = String.Format("Edición de notificación");
            else
                lblTituloHeader.Text = String.Format("Nueva notificación");
            ComenzarCarga();
        }
    }
}
