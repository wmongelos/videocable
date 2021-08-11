using CapaNegocios;
using System;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Abms
{
    public partial class AbmNotificaciones : Form
    {
        int idAreaPersonal, idPersonal, idPrioridad, idTipoDestinatario, rangoDias, idTipoEmisor, idAdjuntoSeleccionado;
        bool ejecutarTarea = false;
        DateTime fechaDesde, fechaHasta;
        DataTable dtNotificaciones;
        DataTable dtUltimaNotificacion;
        Notificaciones oNotificaciones = new Notificaciones();
        Notificaciones_Adjuntos oNotificacionesAdjuntos = new Notificaciones_Adjuntos();
        Notificaciones_Destinatarios oNotificacionesDestinatarios = new Notificaciones_Destinatarios();
        Thread hilo;
        delegate void myDel();
        DataView dtvNotificaciones;
        DialogResult dialogResult;
        TabPage ultimaTabSeleccionada = null;



        private void ComenzarCarga()
        {
            btnBuscar.Enabled = false;
            pgCircular.Start();
            hilo = new Thread(new ThreadStart(CargarDatos));
            hilo.IsBackground = true;
            hilo.Start();
        }

        private void CargarDatos()
        {
            int idDestinatario = 0;
            try
            {
                oNotificaciones.ActualizarEstadoDestinatarios(idPersonal);
                dtNotificaciones = oNotificaciones.ListarParaPersonalEspecifico(idAreaPersonal, idPersonal, idTipoDestinatario, 0, idPrioridad, fechaDesde, fechaHasta);
                if (idTipoDestinatario == Convert.ToInt32(Notificaciones_Destinatarios.Tipo_Destinatario.PERSONAL))
                    idDestinatario = idPersonal;
                else if (idTipoDestinatario == Convert.ToInt32(Notificaciones_Destinatarios.Tipo_Destinatario.AREA))
                    idDestinatario = idAreaPersonal;
                else
                    idDestinatario = Puntos_Cobros.Id_Punto;
                dtUltimaNotificacion = oNotificaciones.RetornarUltimaNotificacionPendiente(idTipoDestinatario, idDestinatario);
                myDel MD = new myDel(AsignarDatos);
                this.Invoke(MD, new object[] { });
                pgCircular.Stop();
            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message);
            }
        }

        private void AsignarDatos()
        {
            dtvNotificaciones = new DataView(dtNotificaciones);
            dtvNotificaciones.RowFilter = String.Format("enviadarecibida={0}", Convert.ToInt32(Notificaciones.SITUACION.RECIBIDAS));
            dgvNotificacionesRecibidas.DataSource = dtvNotificaciones;


            dtvNotificaciones = new DataView(dtNotificaciones);
            dtvNotificaciones.RowFilter = String.Format("enviadarecibida={0}", Convert.ToInt32(Notificaciones.SITUACION.ENVIADAS));
            dgvNotificacionesEnviadas.DataSource = dtvNotificaciones;
            FormatearGrillas();
            if (ultimaTabSeleccionada == null)
                tabControlNotificaciones.SelectedTab = tabRecibidas;
            cboPrioridad.SelectedIndex = idPrioridad;
            cboTipoEmisor.SelectedIndex = idTipoEmisor;
            lblTotal.Text = String.Format("Recibidas: {0}. Enviadas: {1}.", dgvNotificacionesRecibidas.Rows.Count, dgvNotificacionesEnviadas.Rows.Count);
            btnBuscar.Enabled = true;

            if (dtUltimaNotificacion.Rows.Count > 0)
            {
                if (dtUltimaNotificacion.Rows[0]["fecha_limite"].ToString() != String.Empty)
                {
                    lblAdvertencia.Text = String.Format("Tiene una notificación pendiente en la fecha {0}", dtUltimaNotificacion.Rows[0]["fecha_limite"]);
                    lblAdvertencia.Visible = true;
                }
                else
                {
                    lblAdvertencia.Text = String.Empty;
                    lblAdvertencia.Visible = false;
                }
            }
            else
            {
                lblAdvertencia.Text = String.Empty;
                lblAdvertencia.Visible = false;
            }
        }

        private void FormatearGrillas()
        {
            int IndexColumn = -1;
            for (int x = 0; x < dgvNotificacionesRecibidas.ColumnCount; x++)
                dgvNotificacionesRecibidas.Columns[x].Visible = false;
            //agrega columna ver mensaje
            DataGridViewLinkColumn colVerMensaje = new DataGridViewLinkColumn();
            colVerMensaje.Name = "colVerMensaje";
            colVerMensaje.HeaderText = "Mensaje";
            colVerMensaje.Text = "Ver";
            colVerMensaje.Width = 50;
            colVerMensaje.UseColumnTextForLinkValue = true;
            colVerMensaje.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            IndexColumn = dgvNotificacionesRecibidas.Columns.IndexOf(colVerMensaje);
            if (IndexColumn >= 0)
                dgvNotificacionesRecibidas.Columns.RemoveAt(IndexColumn);
            dgvNotificacionesRecibidas.Columns.Add(colVerMensaje);
            //agrega columna ver adjuntos
            IndexColumn = -1;
            DataGridViewLinkColumn colVerAdjuntos = new DataGridViewLinkColumn();
            colVerAdjuntos.Name = "colVerAdjuntos";
            colVerAdjuntos.HeaderText = "Adjuntos";
            colVerAdjuntos.Text = "Ver";
            colVerAdjuntos.Width = 50;
            colVerAdjuntos.UseColumnTextForLinkValue = true;
            colVerAdjuntos.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            IndexColumn = dgvNotificacionesRecibidas.Columns.IndexOf(colVerAdjuntos);
            if (IndexColumn >= 0)
                dgvNotificacionesRecibidas.Columns.RemoveAt(IndexColumn);
            dgvNotificacionesRecibidas.Columns.Add(colVerAdjuntos);

            dgvNotificacionesRecibidas.Columns["fecha_creacion"].Visible = true;
            dgvNotificacionesRecibidas.Columns["tipo_emisor"].Visible = true;
            dgvNotificacionesRecibidas.Columns["area_emisor"].Visible = true;
            dgvNotificacionesRecibidas.Columns["emisor"].Visible = true;
            dgvNotificacionesRecibidas.Columns["fecha_limite"].Visible = true;
            dgvNotificacionesRecibidas.Columns["prioridad"].Visible = true;
            dgvNotificacionesRecibidas.Columns["tareas_ejecutar"].Visible = true;

            dgvNotificacionesRecibidas.Columns["fecha_creacion"].HeaderText = "Recibida";
            dgvNotificacionesRecibidas.Columns["tipo_emisor"].HeaderText = "Tipo de remitente";
            dgvNotificacionesRecibidas.Columns["area_emisor"].HeaderText = "Área del remitente";
            dgvNotificacionesRecibidas.Columns["emisor"].HeaderText = "Remitente";
            dgvNotificacionesRecibidas.Columns["fecha_limite"].HeaderText = "Finalización";
            dgvNotificacionesRecibidas.Columns["prioridad"].HeaderText = "Prioridad";
            dgvNotificacionesRecibidas.Columns["tareas_ejecutar"].HeaderText = "Tareas automáticas";

            dgvNotificacionesRecibidas.Columns["fecha_creacion"].Width = 170;
            dgvNotificacionesRecibidas.Columns["tipo_emisor"].Width = 150;
            dgvNotificacionesRecibidas.Columns["area_emisor"].Width = 150;
            dgvNotificacionesRecibidas.Columns["emisor"].Width = 370;
            dgvNotificacionesRecibidas.Columns["fecha_limite"].Width = 100;
            dgvNotificacionesRecibidas.Columns["prioridad"].Width = 100;
            dgvNotificacionesRecibidas.Columns["tareas_ejecutar"].Width = 150;

            dgvNotificacionesRecibidas.Columns["colVerAdjuntos"].Width = 80;
            dgvNotificacionesRecibidas.Columns["colVerMensaje"].Width = 80;
            ColorearGrilla(dgvNotificacionesRecibidas, Convert.ToInt32(Notificaciones.SITUACION.RECIBIDAS));
            foreach (DataGridViewRow fila in dgvNotificacionesRecibidas.Rows)
                fila.Height = 30;
            //grilla notificaciones enviadas
            IndexColumn = -1;
            for (int x = 0; x < dgvNotificacionesEnviadas.ColumnCount; x++)
                dgvNotificacionesEnviadas.Columns[x].Visible = false;

            DataGridViewLinkColumn colVerMensaje2 = new DataGridViewLinkColumn();
            colVerMensaje2.Name = "colVerMensaje";
            colVerMensaje2.HeaderText = "Mensaje";
            colVerMensaje2.Text = "Ver";
            colVerMensaje2.Width = 50;
            colVerMensaje2.UseColumnTextForLinkValue = true;
            colVerMensaje2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            IndexColumn = dgvNotificacionesEnviadas.Columns.IndexOf(colVerMensaje2);
            if (IndexColumn >= 0)
                dgvNotificacionesEnviadas.Columns.RemoveAt(IndexColumn);
            dgvNotificacionesEnviadas.Columns.Add(colVerMensaje2);

            IndexColumn = -1;
            DataGridViewLinkColumn colVerAdjuntos2 = new DataGridViewLinkColumn();
            colVerAdjuntos2.Name = "colVerAdjuntos";
            colVerAdjuntos2.HeaderText = "Adjuntos";
            colVerAdjuntos2.Text = "Ver";
            colVerAdjuntos2.Width = 50;
            colVerAdjuntos2.UseColumnTextForLinkValue = true;
            colVerAdjuntos2.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            IndexColumn = dgvNotificacionesEnviadas.Columns.IndexOf(colVerAdjuntos2);
            if (IndexColumn >= 0)
                dgvNotificacionesEnviadas.Columns.RemoveAt(IndexColumn);
            dgvNotificacionesEnviadas.Columns.Add(colVerAdjuntos2);

            IndexColumn = -1;
            DataGridViewLinkColumn colVerDestinatarios = new DataGridViewLinkColumn();
            colVerDestinatarios.Name = "colVerDestinatarios";
            colVerDestinatarios.HeaderText = "Destinatarios";
            colVerDestinatarios.Text = "Ver";
            colVerDestinatarios.Width = 50;
            colVerDestinatarios.UseColumnTextForLinkValue = true;
            colVerDestinatarios.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            IndexColumn = dgvNotificacionesEnviadas.Columns.IndexOf(colVerDestinatarios);
            if (IndexColumn >= 0)
                dgvNotificacionesEnviadas.Columns.RemoveAt(IndexColumn);
            dgvNotificacionesEnviadas.Columns.Add(colVerDestinatarios);

            IndexColumn = -1;
            DataGridViewLinkColumn colRealizado = new DataGridViewLinkColumn();
            colRealizado.Name = "colRealizado";
            colRealizado.HeaderText = "Acción";
            colRealizado.Text = "Realizar";
            colRealizado.Width = 50;
            colRealizado.UseColumnTextForLinkValue = true;
            colRealizado.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            IndexColumn = dgvNotificacionesEnviadas.Columns.IndexOf(colRealizado);
            if (IndexColumn >= 0)
                dgvNotificacionesEnviadas.Columns.RemoveAt(IndexColumn);
            dgvNotificacionesEnviadas.Columns.Add(colRealizado);



            IndexColumn = -1;
            DataGridViewLinkColumn colCancelar = new DataGridViewLinkColumn();
            colCancelar.Name = "colCancelar";
            colCancelar.HeaderText = "Acción";
            colCancelar.Text = "Cancelar";
            colCancelar.Width = 50;
            colCancelar.UseColumnTextForLinkValue = true;
            colCancelar.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            IndexColumn = dgvNotificacionesEnviadas.Columns.IndexOf(colCancelar);
            if (IndexColumn >= 0)
                dgvNotificacionesEnviadas.Columns.RemoveAt(IndexColumn);
            dgvNotificacionesEnviadas.Columns.Add(colCancelar);

            dgvNotificacionesEnviadas.Columns["fecha_limite"].Visible = true;
            dgvNotificacionesEnviadas.Columns["prioridad"].Visible = true;
            dgvNotificacionesEnviadas.Columns["tareas_ejecutar"].Visible = true;

            dgvNotificacionesEnviadas.Columns["fecha_limite"].HeaderText = "Finalización";
            dgvNotificacionesEnviadas.Columns["prioridad"].HeaderText = "Prioridad";
            dgvNotificacionesEnviadas.Columns["tareas_ejecutar"].HeaderText = "Tareas automáticas";

            dgvNotificacionesEnviadas.Columns["prioridad"].Width = 550;
            dgvNotificacionesEnviadas.Columns["fecha_limite"].Width = 140;
            dgvNotificacionesEnviadas.Columns["tareas_ejecutar"].Width = 150;
            dgvNotificacionesEnviadas.Columns["colVerMensaje"].Width = 80;
            dgvNotificacionesEnviadas.Columns["colVerAdjuntos"].Width = 80;
            dgvNotificacionesEnviadas.Columns["colverDestinatarios"].Width = 80;
            ColorearGrilla(dgvNotificacionesEnviadas, Convert.ToInt32(Notificaciones.SITUACION.ENVIADAS));
            foreach (DataGridViewRow fila in dgvNotificacionesEnviadas.Rows)
                fila.Height = 30;
            if (ultimaTabSeleccionada != null)
                tabControlNotificaciones.SelectedTab = ultimaTabSeleccionada;
        }

        private void SetearVariablesBusqueda()
        {
            idPrioridad = Convert.ToInt32(cboPrioridad.SelectedIndex);
            idTipoEmisor = Convert.ToInt32(cboTipoEmisor.SelectedIndex);
            rangoDias = 7;
            fechaDesde = dtpFechaDesde.Value.AddDays(-rangoDias);
            fechaHasta = dtpFechaHasta.Value;
        }

        private void ColorearGrilla(DataGridView datagrid, int idSituacion)
        {
            if (datagrid.Rows.Count > 0)
            {
                int idEstadoNotificacion = 0;
                int idPrioridad = 0;
                foreach (DataGridViewRow fila in datagrid.Rows)
                {
                    if (idSituacion == Convert.ToInt32(Notificaciones.SITUACION.RECIBIDAS))
                        idEstadoNotificacion = Convert.ToInt32(fila.Cells["id_estado_notificacion_destinatario"].Value);
                    else
                        idEstadoNotificacion = Convert.ToInt32(fila.Cells["id_estado_notificacion"].Value);
                    idPrioridad = Convert.ToInt32(fila.Cells["id_prioridad"].Value);
                    //if (idSituacion == Convert.ToInt32(Notificaciones.SITUACION.RECIBIDAS)){
                    if (idEstadoNotificacion == Convert.ToInt32(Notificaciones.ESTADO_NOTIFICACION.PENDIENTE))
                        fila.DefaultCellStyle.BackColor = Color.Gold;
                    else if (idEstadoNotificacion == Convert.ToInt32(Notificaciones.ESTADO_NOTIFICACION.VISTO))
                        fila.DefaultCellStyle.BackColor = Color.MediumTurquoise;
                    else if (idEstadoNotificacion == Convert.ToInt32(Notificaciones.ESTADO_NOTIFICACION.RESUELTO))
                        fila.DefaultCellStyle.BackColor = Color.LightGreen;
                    else if (idEstadoNotificacion == Convert.ToInt32(Notificaciones.ESTADO_NOTIFICACION.VENCIDO))
                        fila.DefaultCellStyle.BackColor = Color.Tomato;
                    else
                        fila.DefaultCellStyle.BackColor = Color.DarkGray;
                    //}

                    if (idPrioridad == Convert.ToInt32(Notificaciones.PRIORIDAD.ALTA))
                        fila.Cells["prioridad"].Style.BackColor = Color.Red;
                }
            }
        }

        private int EjecutarAdjunto()
        {
            DataTable dtAdjuntos = oNotificacionesAdjuntos.GetTablaModeloDatosAdjuntos();
            dtAdjuntos.Rows.Add(dgvDatosAdicionales.SelectedCells[0].OwningRow.Cells["id"].Value.ToString(), dgvDatosAdicionales.SelectedCells[0].OwningRow.Cells["id_adjunto"].Value.ToString(), dgvDatosAdicionales.SelectedCells[0].OwningRow.Cells["id_tipo_modulo_sistema"].Value.ToString(), dgvDatosAdicionales.SelectedCells[0].OwningRow.Cells["id_accion"].Value.ToString(), dgvDatosAdicionales.SelectedCells[0].OwningRow.Cells["id_notificacion"].Value.ToString());
            if (oNotificacionesAdjuntos.EjecutarAdjuntos(dtAdjuntos) > 0)
            {
                MessageBox.Show("Tareas realizadas correctamente.");
                return 1;
            }
            else
            {
                MessageBox.Show("Hubo un error al ejecutar las tareas.");
                return -1;
            }

        }

        private int PasarARealizado()
        {
            if (Convert.ToInt32(dgvDatosAdicionales.SelectedCells[0].OwningRow.Cells["id_estado_realizacion"].Value) != Convert.ToInt32(Notificaciones_Adjuntos.ESTADO.REALIZADO))
            {
                try
                {
                    oNotificacionesAdjuntos.ActualizarEstado(Convert.ToInt32(dgvDatosAdicionales.SelectedCells[0].OwningRow.Cells["id"].Value), Convert.ToInt32(Notificaciones_Adjuntos.ESTADO.REALIZADO));
                    MessageBox.Show("Operación realizada correctamente.");
                    return 1;
                }
                catch
                {
                    MessageBox.Show("Error al cambiar de estado.");
                    return -1;
                }
            }
            else
            {
                MessageBox.Show("Ya se encuentra realizado.");
                return -1;
            }

        }

        private void btnNuevaNotificacion_Click(object sender, EventArgs e)
        {
            ABMCargaEdicionNotificacion abmCargaEdicionNotificacion = new ABMCargaEdicionNotificacion(0, null);
            frmPopUp frmPU = new frmPopUp();
            frmPU.Formulario = abmCargaEdicionNotificacion;
            frmPU.ShowDialog();
            if (abmCargaEdicionNotificacion.DialogResult == DialogResult.OK)
                ComenzarCarga();
        }

        private void dgvNotificacionesRecibidas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvNotificacionesRecibidas.SelectedCells.Count > 0)
            {
                if (dgvNotificacionesRecibidas.Columns[e.ColumnIndex].Name.Equals("colVerAdjuntos"))
                {
                    oNotificacionesDestinatarios.ActualizarEstado(Convert.ToInt32(dgvNotificacionesRecibidas.SelectedCells[0].OwningRow.Cells["id_destinatario"].Value), Convert.ToInt32(Notificaciones_Destinatarios.Estado_Notificacion.VISTO));
                    //oNotificaciones.ActualizarEstado(Convert.ToInt32(dgvNotificacionesRecibidas.SelectedRows[0].Cells["id_notificacion_origen"].Value));

                    DataTable dtAdjuntos = new DataTable();
                    dtAdjuntos = oNotificacionesAdjuntos.Listar(Convert.ToInt32(dgvNotificacionesRecibidas.SelectedCells[0].OwningRow.Cells["id"].Value));
                    if (dtAdjuntos.Rows.Count > 0)
                    {
                        btnEjecutar.Visible = true;
                        lblTituloPanel.Text = "Datos adjuntos";
                        lblDatosAdicionales.Text = "Adjuntos";
                        txtDatosAdicionales.Text = String.Format("{0} {1}", "Datos de adjuntos:", dgvNotificacionesRecibidas.SelectedCells[0].OwningRow.Cells["mensaje"].Value.ToString());
                        dgvDatosAdicionales.DataSource = null;
                        dgvDatosAdicionales.DataSource = dtAdjuntos;
                        for (int x = 0; x < dgvDatosAdicionales.ColumnCount; x++)
                            dgvDatosAdicionales.Columns[x].Visible = false;
                        if (Convert.ToInt32(dgvNotificacionesRecibidas.SelectedCells[0].OwningRow.Cells["ejecutar"].Value) == Convert.ToInt32(Notificaciones.EJECUTAR.SI))
                        {
                            ejecutarTarea = true;
                            btnEjecutar.Text = "Ejecutar tareas";
                        }
                        else
                        {
                            ejecutarTarea = false;
                            btnEjecutar.Text = "Pasar a realizado";
                            //DataGridViewCheckBoxColumn colMarcarRealizado = new DataGridViewCheckBoxColumn();
                            //colMarcarRealizado.Name = "colMarcarRealizado";
                            //colMarcarRealizado.HeaderText = "Realizado";
                            //colMarcarRealizado.Width = 50;
                            //colMarcarRealizado.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                            //dgvDatosAdicionales.Columns.Add(colMarcarRealizado);
                        }

                        dgvDatosAdicionales.Columns["tipo_adjunto"].Visible = true;
                        dgvDatosAdicionales.Columns["datos_adjunto"].Visible = true;
                        dgvDatosAdicionales.Columns["tipo_adjunto"].HeaderText = "Tipo de adjunto";
                        dgvDatosAdicionales.Columns["datos_adjunto"].HeaderText = "Adjunto";
                        dgvDatosAdicionales.Columns["tipo_adjunto"].Width = 150;
                        dgvDatosAdicionales.Columns["datos_adjunto"].Width = 500;
                        foreach (DataGridViewRow fila in dgvDatosAdicionales.Rows)
                        {
                            fila.Height = 30;
                            if (Convert.ToInt32(fila.Cells["id_estado_realizacion"].Value) == Convert.ToInt32(Notificaciones_Adjuntos.ESTADO.PENDIENTE))
                                fila.DefaultCellStyle.BackColor = Color.Gold;
                            else
                                fila.DefaultCellStyle.BackColor = Color.LightGreen;
                        }
                        //dgvDatosAdicionales.ReadOnly = false;
                        //foreach(DataGridViewColumn columna in dgvDatosAdicionales.Columns){
                        //    if (columna.Name != "colMarcarRealizado")
                        //        columna.ReadOnly = true;
                        //}
                        //dgvDatosAdicionales.Columns["tipo_adjunto"].Width = 200;
                        //dgvDatosAdicionales.Columns["datos_adjunto"].Width = 200;
                        //dgvDatosAdicionales.Columns["colMarcarRealizado"].Width = 80;
                        panelDatosAdicionales.Location = new Point(
                        this.ClientSize.Width / 2 - panelDatosAdicionales.Size.Width / 2,
                        this.ClientSize.Height / 2 - panelDatosAdicionales.Size.Height / 2);
                        panelDatosAdicionales.Anchor = AnchorStyles.None;
                        panelDatosAdicionales.Visible = true;
                    }
                    else
                        MessageBox.Show("No posee datos adjuntos.");
                }

                if (dgvNotificacionesRecibidas.Columns[e.ColumnIndex].Name.Equals("colVerMensaje"))
                {
                    oNotificacionesDestinatarios.ActualizarEstado(Convert.ToInt32(dgvNotificacionesRecibidas.SelectedCells[0].OwningRow.Cells["id_destinatario"].Value), Convert.ToInt32(Notificaciones_Destinatarios.Estado_Notificacion.VISTO));
                    //oNotificaciones.ActualizarEstado(Convert.ToInt32(dgvNotificacionesRecibidas.SelectedRows[0].Cells["id_notificacion_origen"].Value));

                    object mensaje = dgvNotificacionesRecibidas.SelectedCells[0].OwningRow.Cells["mensaje"].Value;
                    if (mensaje != DBNull.Value && String.IsNullOrEmpty(mensaje.ToString()) == false)
                    {
                        lblPanelMensaje.Text = mensaje.ToString();
                        panelMensajeNotificacion.Location = new Point(
                        this.ClientSize.Width / 2 - panelMensajeNotificacion.Size.Width / 2,
                        this.ClientSize.Height / 2 - panelMensajeNotificacion.Size.Height / 2);
                        panelMensajeNotificacion.Anchor = AnchorStyles.None;
                        panelMensajeNotificacion.Visible = true;
                    }
                    else
                        MessageBox.Show("No posee datos en el mensaje.");
                }
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            dgvDatosAdicionales.DataSource = null;
            panelDatosAdicionales.Visible = false;
            if (tabControlNotificaciones.SelectedTab == tabRecibidas)
                ComenzarCarga();
        }

        private void dgvNotificacionesEnviadas_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvNotificacionesEnviadas.SelectedCells.Count > 0)
            {
                if (dgvNotificacionesEnviadas.Columns[e.ColumnIndex].Name.Equals("colVerAdjuntos"))
                {
                    DataTable dtAdjuntos = new DataTable();
                    dtAdjuntos = oNotificacionesAdjuntos.Listar(Convert.ToInt32(dgvNotificacionesEnviadas.SelectedCells[0].OwningRow.Cells["id"].Value));
                    if (dtAdjuntos.Rows.Count > 0)
                    {

                        ejecutarTarea = false;
                        btnEjecutar.Text = "Pasar a realizado";
                        lblTituloPanel.Text = "Datos adjuntos";
                        lblDatosAdicionales.Text = "Adjuntos";
                        txtDatosAdicionales.Text = String.Format("{0} {1}", "Datos de adjuntos:", dgvNotificacionesEnviadas.SelectedCells[0].OwningRow.Cells["mensaje"].Value.ToString());

                        dgvDatosAdicionales.DataSource = null;
                        dgvDatosAdicionales.DataSource = dtAdjuntos;
                        for (int x = 0; x < dgvDatosAdicionales.ColumnCount; x++)
                            dgvDatosAdicionales.Columns[x].Visible = false;


                        int IndexColumn = 0;
                        DataGridViewLinkColumn colVerObservacion = new DataGridViewLinkColumn();
                        colVerObservacion.Name = "colVerObservacion";
                        colVerObservacion.HeaderText = "Observación";
                        colVerObservacion.Text = "Ver";
                        colVerObservacion.Width = 50;
                        colVerObservacion.UseColumnTextForLinkValue = true;
                        colVerObservacion.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        IndexColumn = dgvDatosAdicionales.Columns.IndexOf(colVerObservacion);
                        if (IndexColumn >= 0)
                            dgvDatosAdicionales.Columns.RemoveAt(IndexColumn);
                        dgvDatosAdicionales.Columns.Add(colVerObservacion);

                        dgvDatosAdicionales.Columns["tipo_adjunto"].Visible = true;
                        dgvDatosAdicionales.Columns["datos_adjunto"].Visible = true;
                        dgvDatosAdicionales.Columns["estado_realizacion_adjunto"].Visible = true;

                        dgvDatosAdicionales.Columns["tipo_adjunto"].HeaderText = "Tipo de adjunto";
                        dgvDatosAdicionales.Columns["datos_adjunto"].HeaderText = "Adjunto";
                        dgvDatosAdicionales.Columns["estado_realizacion_adjunto"].HeaderText = "Estado de realización";
                        dgvDatosAdicionales.Columns["tipo_adjunto"].Width = 150;
                        foreach (DataGridViewRow fila in dgvDatosAdicionales.Rows)
                        {
                            fila.Height = 30;
                            if (Convert.ToInt32(fila.Cells["id_estado_realizacion"].Value) == Convert.ToInt32(Notificaciones_Adjuntos.ESTADO.PENDIENTE))
                                fila.DefaultCellStyle.BackColor = Color.Gold;
                            else
                                fila.DefaultCellStyle.BackColor = Color.LightGreen;
                        }

                        if (Convert.ToInt32(dgvNotificacionesEnviadas.SelectedCells[0].OwningRow.Cells["ejecutar"].Value) == Convert.ToInt32(Notificaciones.EJECUTAR.SI))
                        {
                            foreach (DataGridViewRow adjunto in dgvDatosAdicionales.Rows)
                            {
                                if (Convert.ToInt32(adjunto.Cells["id_estado_realizacion"].Value) == Convert.ToInt32(Notificaciones_Adjuntos.ESTADO.PENDIENTE))
                                    adjunto.DefaultCellStyle.BackColor = Color.Gold;
                                else
                                    adjunto.DefaultCellStyle.BackColor = Color.LightGreen;
                            }
                        }

                        panelDatosAdicionales.Location = new Point(
                        this.ClientSize.Width / 2 - panelDatosAdicionales.Size.Width / 2,
                        this.ClientSize.Height / 2 - panelDatosAdicionales.Size.Height / 2);
                        panelDatosAdicionales.Anchor = AnchorStyles.None;
                        panelDatosAdicionales.Visible = true;
                    }
                    else
                        MessageBox.Show("No posee datos adjuntos.");
                }

                if (dgvNotificacionesEnviadas.Columns[e.ColumnIndex].Name.Equals("colVerDestinatarios"))
                {
                    DataTable dtDestinatarios = new DataTable();
                    dtDestinatarios = oNotificacionesDestinatarios.Listar(Convert.ToInt32(dgvNotificacionesEnviadas.SelectedCells[0].OwningRow.Cells["id"].Value));
                    if (dtDestinatarios.Rows.Count > 0)
                    {
                        lblTituloPanel.Text = "Destinatarios";
                        lblDatosAdicionales.Text = "Destinatarios:";
                        btnEjecutar.Visible = false;
                        dgvDatosAdicionales.DataSource = null;
                        dgvDatosAdicionales.DataSource = dtDestinatarios;
                        for (int x = 0; x < dgvDatosAdicionales.ColumnCount; x++)
                            dgvDatosAdicionales.Columns[x].Visible = false;

                        dgvDatosAdicionales.Columns["tipo_destinatario"].Visible = true;
                        dgvDatosAdicionales.Columns["destinatario"].Visible = true;
                        dgvDatosAdicionales.Columns["estado_notificacion_destinatario"].Visible = true;


                        dgvDatosAdicionales.Columns["tipo_destinatario"].HeaderText = "Tipo de destinatario";
                        dgvDatosAdicionales.Columns["destinatario"].HeaderText = "Destinatario";
                        dgvDatosAdicionales.Columns["estado_notificacion_destinatario"].HeaderText = "Situación";


                        foreach (DataGridViewRow fila in dgvDatosAdicionales.Rows)
                        {
                            fila.Height = 30;
                            if (Convert.ToInt32(fila.Cells["id_estado_notificacion_destinatario"].Value) == Convert.ToInt32(Notificaciones_Destinatarios.Estado_Notificacion.VISTO))
                                fila.Cells["estado_notificacion_destinatario"].Style.BackColor = Color.CornflowerBlue;
                        }
                        panelDatosAdicionales.Location = new Point(
                        this.ClientSize.Width / 2 - panelDatosAdicionales.Size.Width / 2,
                        this.ClientSize.Height / 2 - panelDatosAdicionales.Size.Height / 2);
                        panelDatosAdicionales.Anchor = AnchorStyles.None;
                        panelDatosAdicionales.Visible = true;
                    }

                }

                if (dgvNotificacionesEnviadas.Columns[e.ColumnIndex].Name.Equals("colVerMensaje"))
                {
                    object mensaje = dgvNotificacionesEnviadas.SelectedCells[0].OwningRow.Cells["mensaje"].Value;
                    if (mensaje != DBNull.Value && String.IsNullOrEmpty(mensaje.ToString()) == false)
                    {
                        lblPanelMensaje.Text = mensaje.ToString();
                        panelMensajeNotificacion.Location = new Point(
                        this.ClientSize.Width / 2 - panelMensajeNotificacion.Size.Width / 2,
                        this.ClientSize.Height / 2 - panelMensajeNotificacion.Size.Height / 2);
                        panelMensajeNotificacion.Anchor = AnchorStyles.None;
                        panelMensajeNotificacion.Visible = true;
                    }
                    else
                        MessageBox.Show("No posee datos en el mensaje.");
                }

                if (dgvNotificacionesEnviadas.Columns[e.ColumnIndex].Name.Equals("colCancelar"))
                {
                    if (Convert.ToInt32(dgvNotificacionesEnviadas.SelectedCells[0].OwningRow.Cells["id_estado_notificacion"].Value) != Convert.ToInt32(Notificaciones.ESTADO_NOTIFICACION.CANCELADO))
                    {
                        DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea cancelar la notificación seleccionada?", "", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            oNotificaciones.ActualizarEstado(Convert.ToInt32(dgvNotificacionesEnviadas.SelectedCells[0].OwningRow.Cells["id"].Value), Convert.ToInt32(Notificaciones.ESTADO_NOTIFICACION.CANCELADO));
                            ComenzarCarga();
                        }
                    }
                    else
                        MessageBox.Show("La notificación ya se encuentra cancelada.");
                }

                if (dgvNotificacionesEnviadas.Columns[e.ColumnIndex].Name.Equals("colRealizado"))
                {
                    if (Convert.ToInt32(dgvNotificacionesEnviadas.SelectedCells[0].OwningRow.Cells["id_estado_notificacion"].Value) != Convert.ToInt32(Notificaciones.ESTADO_NOTIFICACION.CANCELADO) && Convert.ToInt32(dgvNotificacionesEnviadas.SelectedCells[0].OwningRow.Cells["id_estado_notificacion"].Value) != Convert.ToInt32(Notificaciones.ESTADO_NOTIFICACION.RESUELTO) && Convert.ToInt32(dgvNotificacionesEnviadas.SelectedCells[0].OwningRow.Cells["id_estado_notificacion"].Value) != Convert.ToInt32(Notificaciones.ESTADO_NOTIFICACION.VENCIDO))
                    {
                        DataTable dtAdjuntos = new DataTable();
                        DataTable dtDestinatarios = new DataTable();
                        dtAdjuntos = oNotificacionesAdjuntos.Listar(Convert.ToInt32(dgvNotificacionesEnviadas.SelectedCells[0].OwningRow.Cells["id"].Value));
                        dtDestinatarios = dtDestinatarios = oNotificacionesDestinatarios.Listar(Convert.ToInt32(dgvNotificacionesEnviadas.SelectedCells[0].OwningRow.Cells["id"].Value));
                        if (dtAdjuntos.Rows.Count == 0)
                        {

                            DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea marcar como realizada la notificación seleccionada?", "", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                oNotificaciones.ActualizarEstado(Convert.ToInt32(dgvNotificacionesEnviadas.SelectedCells[0].OwningRow.Cells["id"].Value), Convert.ToInt32(Notificaciones.ESTADO_NOTIFICACION.RESUELTO));

                                foreach (DataRow destinatario in dtDestinatarios.Rows)
                                    oNotificacionesDestinatarios.ActualizarEstado(Convert.ToInt32(destinatario["id"]), Convert.ToInt32(Notificaciones_Destinatarios.Estado_Notificacion.RESUELTO));






                                ComenzarCarga();
                            }
                        }
                        else
                            MessageBox.Show("La notificación posee adjuntos, no puede ser realizada por el emisor.");
                    }
                    else
                        MessageBox.Show("No se puede marcar como realizada está notificación.");
                }
            }
        }

        private void AbmNotificaciones_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (panelDatosAdicionales.Visible || panelMensajeNotificacion.Visible || panelObservacion.Visible)
                {

                    panelDatosAdicionales.Visible = false;
                    panelMensajeNotificacion.Visible = false;
                    panelObservacion.Visible = false;
                    if (tabControlNotificaciones.SelectedTab == tabRecibidas)
                        ComenzarCarga();
                }
                else
                    this.Close();
            }
        }

        private void btnEjecutar_Click(object sender, EventArgs e)
        {
            if (dgvDatosAdicionales.SelectedCells.Count > 0)
            {
                int respuesta = 0;
                if (ejecutarTarea)
                    respuesta = EjecutarAdjunto();
                else
                    respuesta = PasarARealizado();
                if (respuesta > 0)
                {
                    dialogResult = MessageBox.Show("¿Quiere agregar alguna observación al adjunto?", "", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        panelDatosAdicionales.Visible = false;
                        idAdjuntoSeleccionado = Convert.ToInt32(dgvDatosAdicionales.SelectedCells[0].OwningRow.Cells["id"].Value.ToString());
                        txtObservacion.Text = String.Empty;
                        panelObservacion.Location = new Point(
                        this.ClientSize.Width / 2 - panelObservacion.Size.Width / 2,
                        this.ClientSize.Height / 2 - panelObservacion.Size.Height / 2);
                        panelObservacion.Anchor = AnchorStyles.None;
                        panelObservacion.Visible = true;
                    }
                    else
                    {
                        panelDatosAdicionales.Visible = false;
                        panelObservacion.Visible = false;
                        panelMensaje.Visible = false;
                        panelMensajeNotificacion.Visible = false;
                        ComenzarCarga();
                    }

                }
            }
        }





        private void btnGuardarObservacion_Click(object sender, EventArgs e)
        {
            try
            {
                oNotificacionesAdjuntos.ActualizarObservacion(idAdjuntoSeleccionado, txtObservacion.Text);
                MessageBox.Show("Observación guardada correctamente.");
                panelDatosAdicionales.Visible = false;
                panelObservacion.Visible = false;
                panelMensaje.Visible = false;
                panelMensajeNotificacion.Visible = false;
                ComenzarCarga();
            }
            catch
            {
                MessageBox.Show("Error al guardar observación.");
            }
            idAdjuntoSeleccionado = 0;
            panelMensajeNotificacion.Visible = false;
        }




        private void dgvDatosAdicionales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvDatosAdicionales.SelectedCells.Count > 0)
            {
                if (dgvDatosAdicionales.Columns[e.ColumnIndex].Name.Equals("colVerObservacion"))
                {
                    object mensaje = dgvDatosAdicionales.SelectedCells[0].OwningRow.Cells["observacion"].Value;
                    if (mensaje != DBNull.Value && String.IsNullOrEmpty(mensaje.ToString()) == false)
                    {
                        lblPanelMensaje.Text = mensaje.ToString();
                        panelMensajeNotificacion.Location = new Point(
                        this.ClientSize.Width / 2 - panelMensajeNotificacion.Size.Width / 2,
                        this.ClientSize.Height / 2 - panelMensajeNotificacion.Size.Height / 2);
                        panelMensajeNotificacion.Anchor = AnchorStyles.None;
                        panelMensajeNotificacion.BringToFront();
                        panelMensajeNotificacion.Visible = true;
                    }
                    else
                        MessageBox.Show("No posee observaciones.");
                }
            }
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            panelObservacion.Visible = false;
            idAdjuntoSeleccionado = 0;
            txtObservacion.Text = String.Empty;
            panelDatosAdicionales.Visible = false;
            panelObservacion.Visible = false;
            panelMensaje.Visible = false;
            panelMensajeNotificacion.Visible = false;
            ComenzarCarga();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            lblPanelMensaje.Text = String.Empty;
            panelMensajeNotificacion.Visible = false;
            if (tabControlNotificaciones.SelectedTab == tabRecibidas)
                ComenzarCarga();
        }

        private void tabControlNotificaciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtvNotificaciones = new DataView(dtNotificaciones);
            if (tabControlNotificaciones.SelectedTab == tabRecibidas)
            {
                ultimaTabSeleccionada = tabRecibidas;
                dtvNotificaciones.RowFilter = String.Format("enviadarecibida={0}", Convert.ToInt32(Notificaciones.SITUACION.RECIBIDAS));
                dgvNotificacionesRecibidas.DataSource = null;
                dgvNotificacionesRecibidas.DataSource = dtvNotificaciones;
            }
            else
            {
                ultimaTabSeleccionada = tabEnviadas;
                dtvNotificaciones.RowFilter = String.Format("enviadarecibida={0}", Convert.ToInt32(Notificaciones.SITUACION.ENVIADAS));
                dgvNotificacionesEnviadas.DataSource = null;
                dgvNotificacionesEnviadas.DataSource = dtvNotificaciones;
            }
            FormatearGrillas();
            lblTotal.Text = String.Format("Recibidas: {0}. Enviadas: {1}.", dgvNotificacionesRecibidas.Rows.Count, dgvNotificacionesEnviadas.Rows.Count);

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            SetearVariablesBusqueda();
            ComenzarCarga();
        }

        public AbmNotificaciones()
        {
            InitializeComponent();
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AbmNotificaciones_Load(object sender, EventArgs e)
        {
            fechaDesde = new DateTime();
            fechaHasta = new DateTime();
            dtNotificaciones = new DataTable();
            dtUltimaNotificacion = new DataTable();
            idAreaPersonal = Personal.Id_Area;
            idPersonal = Personal.Id_Login;
            idPrioridad = Convert.ToInt32(Notificaciones.PRIORIDAD.TODAS);
            idTipoDestinatario = Convert.ToInt32(Notificaciones_Destinatarios.Tipo_Destinatario.PERSONAL);
            idTipoEmisor = Convert.ToInt32(Notificaciones.TIPO_EMISOR.AMBOS);
            rangoDias = 7;
            fechaDesde = DateTime.Now.AddDays(-rangoDias);
            fechaHasta = DateTime.Now;
            tabControlNotificaciones.SelectedTab = tabRecibidas;
            ComenzarCarga();
        }
    }
}
