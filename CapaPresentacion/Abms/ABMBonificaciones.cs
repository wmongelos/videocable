using CapaNegocios;
using System;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Abms
{
    public partial class ABMBonificaciones : Form
    {
        private Thread hilo;
        private delegate void myDel();
        private Bonificaciones oBonificaciones = new Bonificaciones();
        private DataTable DtBonificaciones = new DataTable();
        private Configuracion oConfiguracion = new Configuracion();
        private Bonificaciones_Aplicacion oBonificacionesAplicacion = new Bonificaciones_Aplicacion();
        private int IdTipoFacturacionDb;
        private int IdBonificacion = 0;
        private DataTable DtBonificacionAplicaciones = new DataTable();
        private DataTable DtVelocidadesSubServicio = new DataTable();
        private Servicios_Tarifas oServiciosTarifas = new Servicios_Tarifas();

        private void ComenzarCarga()
        {
            pgCircular.Start();
            hilo = new Thread(new ThreadStart(CargarDatos));
            hilo.IsBackground = true;
            hilo.Start();
        }


        private void CargarDatos()
        {
            try
            {
                DtBonificaciones = oBonificaciones.Listar();
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
            dgvBonificaciones.DataSource = DtBonificaciones;
            for (int x = 0; x < dgvBonificaciones.Columns.Count; x++)
                dgvBonificaciones.Columns[x].Visible = false;

            dgvBonificaciones.Columns["nombre"].Visible = true;
            dgvBonificaciones.Columns["tipo_bonif_texto"].Visible = true;
            dgvBonificaciones.Columns["modulo_aplicacion"].Visible = true;
            dgvBonificaciones.Columns["fecha_aplicacion"].Visible = true;
            dgvBonificaciones.Columns["fecha_desde_texto"].Visible = true;
            dgvBonificaciones.Columns["fecha_hasta_texto"].Visible = true;
            dgvBonificaciones.Columns["cantidad_periodos_texto"].Visible = true;
            dgvBonificaciones.Columns["porcentaje_texto"].Visible = true;

            dgvBonificaciones.Columns["nombre"].HeaderText = "Bonificación";
            dgvBonificaciones.Columns["tipo_bonif_texto"].HeaderText = "Tipo de bonificación";
            dgvBonificaciones.Columns["modulo_aplicacion"].HeaderText = "Se aplica en:";
            dgvBonificaciones.Columns["fecha_aplicacion"].HeaderText = "Tiempo";
            dgvBonificaciones.Columns["fecha_desde_texto"].HeaderText = "Aplicada desde";
            dgvBonificaciones.Columns["fecha_hasta_texto"].HeaderText = "Aplicada hasta";
            dgvBonificaciones.Columns["cantidad_periodos_texto"].HeaderText = "Cantidad de periodos";
            dgvBonificaciones.Columns["porcentaje_texto"].HeaderText = "Porcentaje";

            dgvBonificaciones.Columns["nombre"].Width = 250;
            dgvBonificaciones.Columns["porcentaje_texto"].Width = 300;
            dgvBonificaciones.Columns["fecha_desde_texto"].Width = 80;
            dgvBonificaciones.Columns["fecha_hasta_texto"].Width = 80;
            dgvBonificaciones.Columns["cantidad_periodos_texto"].Width = 150;
            dgvBonificaciones.Columns["fecha_aplicacion"].Width = 150;
            dgvBonificaciones.Columns["tipo_bonif_texto"].Width = 150;
            dgvBonificaciones.Columns["modulo_aplicacion"].Width = 150;

            dgvBonificaciones.Columns["nombre"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvBonificaciones.Columns["tipo_bonif_texto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvBonificaciones.Columns["modulo_aplicacion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvBonificaciones.Columns["fecha_aplicacion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvBonificaciones.Columns["fecha_desde_texto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvBonificaciones.Columns["fecha_hasta_texto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvBonificaciones.Columns["cantidad_periodos_texto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgvBonificaciones.Columns["porcentaje_texto"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            Controles(false);
            AsignarValores();
            if (dgvBonificaciones.Rows.Count == 0)
            {
                btnEditar.Enabled = false;
                btnEliminar.Enabled = false;
                btnAsignarItem.Enabled = false;
                btnEliminarAplicacion.Enabled = false;
            }
            else
            {
                btnEditar.Enabled = true;
                btnEliminar.Enabled = true;
                btnAsignarItem.Enabled = true;
                btnEliminarAplicacion.Enabled = true;
            }
        }

        private void Controles(bool state)
        {
            btnActualizar.Enabled = !state;
            btnNuevo.Enabled = !state;
            if (state == false)
            {
                dgvBonificaciones.Enabled = !state;
                if (dgvBonificaciones.Rows.Count > 0)
                {
                    btnEditar.Enabled = !state;
                    btnEliminar.Enabled = !state;
                }
            }
            else
            {
                btnEditar.Enabled = !state;
                btnEliminar.Enabled = !state;
                dgvBonificaciones.Enabled = !state;
            }
            btnGuardar.Enabled = state;
            btnCancelar.Enabled = state;
            pnlDatos.Enabled = state;

            txtNombre.Focus();
        }

        private void LimpiarValores()
        {
            txtNombre.Text = String.Empty;
            cboTipoBonificaciones.SelectedIndex = 0;
            chkPorContratacion.Checked = false;
            dtpFechaDesde.Value = DateTime.Now;
            dtpFechaHasta.Value = DateTime.Now;
            chkContemplarMeses.Checked = false;
            spCantidadPeriodos.Value = spCantidadPeriodos.Minimum;
            spPorcentaje.Value = spPorcentaje.Minimum;
            IdBonificacion = 0;
        }

        private void AsignarValores()
        {
            if (dgvBonificaciones.Rows.Count > 0)
            {
                if (dgvBonificaciones.SelectedRows.Count > 0)
                {
                    IdBonificacion = Convert.ToInt32(dgvBonificaciones.SelectedRows[0].Cells["id"].Value);
                    txtNombre.Text = dgvBonificaciones.SelectedRows[0].Cells["nombre"].Value.ToString();
                    cboTipoBonificaciones.SelectedIndex = Convert.ToInt32(dgvBonificaciones.SelectedRows[0].Cells["tipo_bonificacion"].Value);
                    if (Convert.ToInt32(dgvBonificaciones.SelectedRows[0].Cells["por_contratacion"].Value) == 1)
                    {
                        chkPorContratacion.Checked = true;
                        spCantidadPeriodos.Value = Convert.ToInt32(dgvBonificaciones.SelectedRows[0].Cells["cantidad_periodos"].Value);
                    }
                    else
                    {
                        chkPorContratacion.Checked = false;
                        spCantidadPeriodos.Value = spCantidadPeriodos.Minimum;
                    }

                    try
                    {
                        dtpFechaDesde.Value = Convert.ToDateTime(dgvBonificaciones.SelectedRows[0].Cells["fecha_desde"].Value);
                        dtpFechaHasta.Value = Convert.ToDateTime(dgvBonificaciones.SelectedRows[0].Cells["fecha_hasta"].Value);
                    }
                    catch
                    {
                        dtpFechaDesde.Value = DateTime.Now;
                        dtpFechaHasta.Value = DateTime.Now;
                    }

                    if (Convert.ToInt32(dgvBonificaciones.SelectedRows[0].Cells["contemplar_fecha_completa"].Value) == 1)
                        chkContemplarMeses.Checked = false;
                    else
                        chkContemplarMeses.Checked = true;

                    if (Convert.ToInt32(dgvBonificaciones.SelectedRows[0].Cells["modalidad_venta_pago"].Value) == Convert.ToInt32(Bonificaciones.MODALIDAD_VENTA_PAGO.VENTA))
                    {
                        rbVenta.Checked = true;
                        rbPago.Checked = false;
                    }
                    else
                    {
                        rbVenta.Checked = false;
                        rbPago.Checked = true;
                    }

                    spPorcentaje.Value = Convert.ToDecimal(dgvBonificaciones.SelectedRows[0].Cells["porcentaje"].Value);
                }
                else
                {
                    IdBonificacion = Convert.ToInt32(dgvBonificaciones.Rows[0].Cells["id"].Value);
                    txtNombre.Text = dgvBonificaciones.Rows[0].Cells["nombre"].Value.ToString();
                    cboTipoBonificaciones.SelectedIndex = Convert.ToInt32(dgvBonificaciones.Rows[0].Cells["tipo_bonificacion"].Value);
                    if (Convert.ToInt32(dgvBonificaciones.Rows[0].Cells["por_contratacion"].Value) == 1)
                    {
                        chkPorContratacion.Checked = true;
                        spCantidadPeriodos.Value = Convert.ToInt32(dgvBonificaciones.Rows[0].Cells["cantidad_periodos"].Value);
                    }
                    else
                    {
                        chkPorContratacion.Checked = false;
                        spCantidadPeriodos.Value = spCantidadPeriodos.Minimum;
                    }

                    try
                    {
                        dtpFechaDesde.Value = Convert.ToDateTime(dgvBonificaciones.Rows[0].Cells["fecha_desde"].Value);
                        dtpFechaHasta.Value = Convert.ToDateTime(dgvBonificaciones.Rows[0].Cells["fecha_hasta"].Value);
                    }
                    catch
                    {
                        dtpFechaDesde.Value = DateTime.Now;
                        dtpFechaHasta.Value = DateTime.Now;
                    }

                    if (Convert.ToInt32(dgvBonificaciones.Rows[0].Cells["contemplar_fecha_completa"].Value) == 1)
                        chkContemplarMeses.Checked = false;
                    else
                        chkContemplarMeses.Checked = true;

                    if (Convert.ToInt32(dgvBonificaciones.Rows[0].Cells["modalidad_venta_pago"].Value) == Convert.ToInt32(Bonificaciones.MODALIDAD_VENTA_PAGO.VENTA))
                    {
                        rbVenta.Checked = true;
                        rbPago.Checked = false;
                    }
                    else
                    {
                        rbVenta.Checked = false;
                        rbPago.Checked = true;
                    }
                    spPorcentaje.Value = Convert.ToDecimal(dgvBonificaciones.Rows[0].Cells["porcentaje"].Value);
                }

                if (cboTipoBonificaciones.SelectedIndex == Convert.ToInt32(Bonificaciones.TIPO_BONIFICACION.ESPECIAL))
                    btnAsignarItem.Enabled = false;
                else
                    btnAsignarItem.Enabled = true;
                ActualizarGrillaAplicaciones();
            }
            else
                dgvAplicaciones.DataSource = null;
            if (dgvAplicaciones.Rows.Count > 0)
                btnEliminarAplicacion.Enabled = true;
            else
                btnEliminarAplicacion.Enabled = false;

        }

        private void ActualizarGrillaAplicaciones()
        {
            dgvAplicaciones.DataSource = null;
            DtBonificacionAplicaciones.Clear();
            DtBonificacionAplicaciones = oBonificacionesAplicacion.Listar(IdTipoFacturacionDb, IdBonificacion);
            dgvAplicaciones.DataSource = DtBonificacionAplicaciones;
            dgvAplicaciones.ClearSelection();
            for (int x = 0; x < dgvAplicaciones.Columns.Count; x++)
            {
                dgvAplicaciones.Columns[x].Visible = false;
                dgvAplicaciones.Columns[x].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
            dgvAplicaciones.Columns["nivel"].Visible = true;
            dgvAplicaciones.Columns["catzona"].Visible = true;
            dgvAplicaciones.Columns["grupo"].Visible = true;
            dgvAplicaciones.Columns["tipo_servicio"].Visible = true;
            dgvAplicaciones.Columns["servicio"].Visible = true;
            dgvAplicaciones.Columns["subservicio"].Visible = true;
            dgvAplicaciones.Columns["velocidad"].Visible = true;
            dgvAplicaciones.Columns["velocidad_tipo"].Visible = true;
            dgvAplicaciones.Columns["tipo_servicio_sub"].Visible = true;

            dgvAplicaciones.Columns["nivel"].HeaderText = "Aplicada a";
            if (IdTipoFacturacionDb == Convert.ToInt32(Tipo_Facturacion.Id_Tipo_Facturacion.POR_CATEGORIAS))
                dgvAplicaciones.Columns["catzona"].HeaderText = "Categoría";
            else
            {
                dgvAplicaciones.Columns["localidad"].Visible = true;
                dgvAplicaciones.Columns["localidad"].HeaderText = "Localidad";
                dgvAplicaciones.Columns["catzona"].HeaderText = "Zona";
            }

            dgvAplicaciones.Columns["grupo"].HeaderText = "Grupo";
            dgvAplicaciones.Columns["tipo_servicio"].HeaderText = "Tipo de servicio";
            dgvAplicaciones.Columns["servicio"].HeaderText = "Servicio";
            dgvAplicaciones.Columns["subservicio"].HeaderText = "Sub servicio";
            dgvAplicaciones.Columns["velocidad"].HeaderText = "Velocidad (Mb)";
            dgvAplicaciones.Columns["velocidad_tipo"].HeaderText = "Tipo de velocidad";
            dgvAplicaciones.Columns["tipo_servicio_sub"].HeaderText = "Tipo de sub servicio";
            dgvAplicaciones.Columns["nivel"].Width = 150;
            dgvAplicaciones.Columns["catzona"].Width = 100;
            dgvAplicaciones.Columns["grupo"].Width = 100;
            dgvAplicaciones.Columns["tipo_servicio"].Width = 100;
            dgvAplicaciones.Columns["servicio"].Width = 100;
            dgvAplicaciones.Columns["subservicio"].Width = 100;
            dgvAplicaciones.Columns["velocidad"].Width = 70;
            dgvAplicaciones.Columns["velocidad_tipo"].Width = 100;
            dgvAplicaciones.Columns["tipo_servicio_sub"].Width = 100;
            dgvAplicaciones.Columns["velocidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            AgregarLinkColumn();


            ColorearGrillaAplicaciones();
        }

        private void ColorearGrillaAplicaciones()
        {
            foreach (DataGridViewRow fila in dgvAplicaciones.Rows)
            {
                if (Convert.ToInt32(fila.Cells["requiere_condiciones"].Value) == Convert.ToInt32(Bonificaciones_Aplicacion.REQUIERE_CONDICIONES.NO_REQUIERE))
                    fila.DefaultCellStyle.BackColor = Color.Gold;
                else
                {
                    if (Convert.ToInt32(fila.Cells["cantidad_condiciones"].Value) > 0)
                        fila.DefaultCellStyle.BackColor = Color.LightGreen;
                    else
                        fila.DefaultCellStyle.BackColor = Color.LightCoral;
                }
            }
        }

        private void GuardarRegistro()
        {
            if (String.IsNullOrEmpty(txtNombre.Text) == false)
            {
                oBonificaciones.Id = IdBonificacion;
                oBonificaciones.Nombre = txtNombre.Text;
                oBonificaciones.Porcentaje = spPorcentaje.Value;
                oBonificaciones.Fecha_Desde = dtpFechaDesde.Value;
                oBonificaciones.Fecha_Hasta = dtpFechaHasta.Value;
                oBonificaciones.Tipo_Bonificacion = cboTipoBonificaciones.SelectedIndex;

                if (chkContemplarMeses.Checked)
                {
                    oBonificaciones.Mes_desde = dtpFechaDesde.Value.Month;
                    oBonificaciones.Mes_hasta = dtpFechaHasta.Value.Month;
                    oBonificaciones.Contemplar_fecha_completa = 0;
                }
                else
                {
                    oBonificaciones.Mes_desde = 0;
                    oBonificaciones.Mes_hasta = 0;
                    oBonificaciones.Contemplar_fecha_completa = 1;
                }

                if (chkPorContratacion.Checked)
                {
                    oBonificaciones.Por_contratacion = 1;
                    oBonificaciones.Cantidad_periodos = Convert.ToInt32(spCantidadPeriodos.Value);
                }
                else
                {
                    oBonificaciones.Por_contratacion = 0;
                    oBonificaciones.Cantidad_periodos = 0;
                }

                if (rbVenta.Checked)
                    oBonificaciones.Modalidad_Venta_Pago = Convert.ToInt32(Bonificaciones.MODALIDAD_VENTA_PAGO.VENTA);
                else
                    oBonificaciones.Modalidad_Venta_Pago = Convert.ToInt32(Bonificaciones.MODALIDAD_VENTA_PAGO.PAGO);


                oBonificaciones.Guardar(oBonificaciones);
                if (oBonificaciones.Id != 0)
                    oBonificaciones.ActualizarDatosAplicaciones(oBonificaciones.Id, oBonificaciones.Porcentaje, oBonificaciones.Fecha_Desde, oBonificaciones.Fecha_Hasta, oBonificaciones.Nombre, oBonificaciones.Tipo_Bonificacion, oBonificaciones.Cantidad_periodos, oBonificaciones.Mes_desde, oBonificaciones.Mes_hasta, oBonificaciones.Por_contratacion, oBonificaciones.Contemplar_fecha_completa);
                MessageBox.Show("Operación realizada correctamente.");
                ComenzarCarga();
            }
            else
            {
                MessageBox.Show("Debe ingresar un nombre a la bonificación.");
                txtNombre.Focus();
            }
        }

        private void EliminarRegistro()
        {
            try
            {
                foreach (DataGridViewRow Aplicacion in dgvAplicaciones.Rows)
                {
                    oBonificacionesAplicacion.EliminarCondiciones(Convert.ToInt32(Aplicacion.Cells["id"].Value));
                    oBonificacionesAplicacion.Eliminar(Convert.ToInt32(Aplicacion.Cells["id"].Value));
                }
                oBonificaciones.Eliminar(IdBonificacion);
                MessageBox.Show("Operación realizada correctamente.");
                if (dgvBonificaciones.Rows.Count == 0)
                    DtBonificacionAplicaciones.Clear();
                ComenzarCarga();
            }
            catch { MessageBox.Show("Error al eliminar."); }
        }

        private void AsignarAplicacion()
        {
            frmBusquedaServicios frmBonificacionItems;
            if (Convert.ToInt32(dgvBonificaciones.SelectedRows[0].Cells["tipo_bonificacion"].Value) == Convert.ToInt32(Bonificaciones.TIPO_BONIFICACION.COMBINACION))
                frmBonificacionItems = new frmBusquedaServicios(Convert.ToInt32(Bonificaciones_Aplicacion.SELECCION.TODOS), 0);
            else
                frmBonificacionItems = new frmBusquedaServicios(Convert.ToInt32(Bonificaciones_Aplicacion.SELECCION.SERVICIOS_Y_SUBSERVICIOS), 0);
            if (IdTipoFacturacionDb == Convert.ToInt32(Tipo_Facturacion.Id_Tipo_Facturacion.POR_ZONAS))
                frmBonificacionItems.desplegarFormLocalidades = true;
            frmPopUp frmpopup = new frmPopUp();
            frmpopup.Maximizar = false;
            frmpopup.Formulario = frmBonificacionItems;
            frmpopup.ShowDialog();
            if (frmBonificacionItems.DialogResult == DialogResult.OK)
            {
                oBonificacionesAplicacion.Id = 0;
                oBonificacionesAplicacion.Id_Grupo = Convert.ToInt32(frmBonificacionItems.DrDatosItem["id_grupo"]);
                oBonificacionesAplicacion.Id_Tipo_Servicio = Convert.ToInt32(frmBonificacionItems.DrDatosItem["id_tipo_servicio"]);
                oBonificacionesAplicacion.Id_Servicio = Convert.ToInt32(frmBonificacionItems.DrDatosItem["id_servicio"]);
                oBonificacionesAplicacion.Id_Servicio_Sub = Convert.ToInt32(frmBonificacionItems.DrDatosItem["id_servicio_sub"]);
                oBonificacionesAplicacion.Tipo_Servicio_Sub = frmBonificacionItems.DrDatosItem["tipo_servicio_sub"].ToString();
                oBonificacionesAplicacion.Id_Tipo_Facturacion = Convert.ToInt32(frmBonificacionItems.DrDatosItem["id_cat_zona"]);
                oBonificacionesAplicacion.Nivel = Convert.ToInt32(frmBonificacionItems.DrDatosItem["nivel"]);
                oBonificacionesAplicacion.Id_Bonificacion = Convert.ToInt32(dgvBonificaciones.SelectedRows[0].Cells["id"].Value);
                oBonificacionesAplicacion.Porcentaje = Convert.ToDecimal(dgvBonificaciones.SelectedRows[0].Cells["porcentaje"].Value);
                oBonificacionesAplicacion.Fecha_Desde = Convert.ToDateTime(dgvBonificaciones.SelectedRows[0].Cells["fecha_desde"].Value);
                oBonificacionesAplicacion.Fecha_Hasta = Convert.ToDateTime(dgvBonificaciones.SelectedRows[0].Cells["fecha_hasta"].Value);
                oBonificacionesAplicacion.Nombre = dgvBonificaciones.SelectedRows[0].Cells["nombre"].Value.ToString();
                oBonificacionesAplicacion.Tipo_Bonificacion = Convert.ToInt32(dgvBonificaciones.SelectedRows[0].Cells["tipo_bonificacion"].Value);
                oBonificacionesAplicacion.Requiere_Condiciones = Convert.ToInt32(Bonificaciones_Aplicacion.REQUIERE_CONDICIONES.REQUIERE);

                if (Convert.ToInt32(dgvBonificaciones.SelectedRows[0].Cells["por_contratacion"].Value) == 1)
                {
                    oBonificacionesAplicacion.Por_Contratacion = 1;
                    oBonificacionesAplicacion.Cantidad_Periodos = Convert.ToInt32(dgvBonificaciones.SelectedRows[0].Cells["cantidad_periodos"].Value);
                }
                else
                {
                    oBonificacionesAplicacion.Por_Contratacion = 0;
                    oBonificacionesAplicacion.Cantidad_Periodos = 0;
                }

                if (Convert.ToInt32(dgvBonificaciones.SelectedRows[0].Cells["contemplar_fecha_completa"].Value) == 0)
                {
                    oBonificacionesAplicacion.Contemplar_Fecha_Completa = 0;
                    oBonificacionesAplicacion.Mes_Desde = oBonificacionesAplicacion.Fecha_Desde.Month;
                    oBonificacionesAplicacion.Mes_Hasta = oBonificacionesAplicacion.Fecha_Hasta.Month;
                }
                else
                {
                    oBonificacionesAplicacion.Contemplar_Fecha_Completa = 1;
                    oBonificacionesAplicacion.Mes_Desde = 0;
                    oBonificacionesAplicacion.Mes_Hasta = 0;
                }

                if (oBonificacionesAplicacion.Nivel == Convert.ToInt32(Bonificaciones_Aplicacion.NIVEL.SUBSERVICIO) && frmBonificacionItems.DrDatosItem["requerimiento_velocidad"].ToString() == "SI")
                {
                    DtVelocidadesSubServicio = oBonificacionesAplicacion.ListarVelocidadesSubServicio(Convert.ToInt32(oServiciosTarifas.TraerDatosTarifaActual().Rows[0]["id"]), oBonificacionesAplicacion.Id_Tipo_Facturacion, oBonificacionesAplicacion.Id_Servicio_Sub);

                    if (DtVelocidadesSubServicio.Rows.Count > 0)
                    {
                        ABMBonificaciones_VelocidadSubServicio frmSeleccionVelocidades = new ABMBonificaciones_VelocidadSubServicio(DtVelocidadesSubServicio, frmBonificacionItems.DrDatosItem["nombre"].ToString().Trim());
                        frmpopup.Maximizar = false;
                        frmpopup.Formulario = frmSeleccionVelocidades;
                        frmpopup.ShowDialog();
                        if (frmSeleccionVelocidades.DialogResult == DialogResult.OK)
                        {
                            oBonificacionesAplicacion.Id_Velocidad = frmSeleccionVelocidades.IdVelocidad;
                            oBonificacionesAplicacion.Id_Velocidad_Tipo = frmSeleccionVelocidades.IdVelocidadTipo;
                        }
                        else
                        {
                            oBonificacionesAplicacion.Id_Velocidad = 0;
                            oBonificacionesAplicacion.Id_Velocidad_Tipo = 0;
                        }
                    }
                    else
                    {
                        oBonificacionesAplicacion.Id_Velocidad = 0;
                        oBonificacionesAplicacion.Id_Velocidad_Tipo = 0;
                    }
                }
                else
                {
                    oBonificacionesAplicacion.Id_Velocidad = 0;
                    oBonificacionesAplicacion.Id_Velocidad_Tipo = 0;
                }

                if (IdTipoFacturacionDb == Convert.ToInt32(Tipo_Facturacion.Id_Tipo_Facturacion.POR_ZONAS))
                {
                    if (frmBonificacionItems.listaLocalidades.Count == 0)
                        oBonificacionesAplicacion.Guardar(oBonificacionesAplicacion);
                    else
                    {
                        foreach (int localidad in frmBonificacionItems.listaLocalidades)
                        {
                            oBonificacionesAplicacion.Id_Localidad = localidad;
                            oBonificacionesAplicacion.Guardar(oBonificacionesAplicacion);
                        }
                    }
                }
                else
                    oBonificacionesAplicacion.Guardar(oBonificacionesAplicacion);
                ActualizarGrillaAplicaciones();

            }
        }

        private void AgregarLinkColumn()
        {
            int IndexColumn = -1;

            DataGridViewLinkColumn ColVerCondiciones = new DataGridViewLinkColumn();
            ColVerCondiciones.Name = "ColVerCondiciones";
            ColVerCondiciones.HeaderText = "Condiciones";
            ColVerCondiciones.Text = "Ver";
            ColVerCondiciones.Width = 50;
            ColVerCondiciones.UseColumnTextForLinkValue = true;
            ColVerCondiciones.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            IndexColumn = -1;
            IndexColumn = dgvAplicaciones.Columns.IndexOf(ColVerCondiciones);
            if (IndexColumn >= 0)
                dgvAplicaciones.Columns.RemoveAt(IndexColumn);
            dgvAplicaciones.Columns.Add(ColVerCondiciones);
        }

        public ABMBonificaciones()
        {
            InitializeComponent();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            ComenzarCarga();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            Controles(true);
            LimpiarValores();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            Controles(true);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarRegistro();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Controles(false);
        }

        private void dgvBonificaciones_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            AsignarValores();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea eliminar la bonificación seleccionada?", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                EliminarRegistro();
            }
        }

        private void btnAsignarItem_Click(object sender, EventArgs e)
        {
            AsignarAplicacion();
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ABMBonificaciones_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void btnEliminarAplicacion_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("¿Está seguro que desea eliminar la aplicación seleccionada?", "", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    if (dgvAplicaciones.SelectedRows.Count > 0)
                    {
                        oBonificacionesAplicacion.EliminarCondiciones(Convert.ToInt32(dgvAplicaciones.SelectedRows[0].Cells["id"].Value));
                        oBonificacionesAplicacion.Eliminar(Convert.ToInt32(dgvAplicaciones.SelectedRows[0].Cells["id"].Value));
                        MessageBox.Show("Operación realizada correctamente.");
                        ActualizarGrillaAplicaciones();
                    }
                    else
                        MessageBox.Show("No se ha seleccionado una aplicación para eliminar.");
                }
                catch { MessageBox.Show("Error al eliminar."); }
            }
        }

        private void dgvAplicaciones_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvAplicaciones.Columns[e.ColumnIndex].Name.Equals("ColVerCondiciones"))
            {
                frmPopUp frmpopup = new frmPopUp();
                frmpopup.Maximizar = false;
                if (Convert.ToInt32(dgvBonificaciones.SelectedRows[0].Cells["tipo_bonificacion"].Value) == Convert.ToInt32(Bonificaciones.TIPO_BONIFICACION.COMBINACION))
                {
                    ABMBonificaciones_Condiciones ABMCondiciones = new ABMBonificaciones_Condiciones(Convert.ToInt32(dgvAplicaciones.SelectedRows[0].Cells["id"].Value), Convert.ToInt32(dgvAplicaciones.SelectedRows[0].Cells["id_tipo_facturacion"].Value));
                    frmpopup.Formulario = ABMCondiciones;
                    frmpopup.ShowDialog();
                    ActualizarGrillaAplicaciones();
                }
                else
                {
                    ABMBonificaciones_CondicionesRepeticion ABMCondicionesRepeticion = new ABMBonificaciones_CondicionesRepeticion(Convert.ToInt32(dgvAplicaciones.SelectedRows[0].Cells["id"].Value));
                    frmpopup.Formulario = ABMCondicionesRepeticion;
                    frmpopup.ShowDialog();
                    ActualizarGrillaAplicaciones();
                }
            }
        }

        private void ABMBonificaciones_Load(object sender, EventArgs e)
        {
            IdTipoFacturacionDb = oConfiguracion.GetValor_N("Id_Tipo_Facturacion");
            cboTipoBonificaciones.SelectedIndex = 0;
            rbVenta.Checked = true;
            rbPago.Checked = false;
            ComenzarCarga();
        }

        private void cboTipoBonificaciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cboTipoBonificaciones.SelectedIndex != Convert.ToInt32(Bonificaciones.TIPO_BONIFICACION.REPETICION))
                {
                    spPorcentaje.Value = spPorcentaje.Minimum;
                    spPorcentaje.Enabled = true;
                }
                else
                {
                    spPorcentaje.Value = spPorcentaje.Minimum;
                    spPorcentaje.Enabled = false;
                }

                if (cboTipoBonificaciones.SelectedIndex == Convert.ToInt32(Bonificaciones.TIPO_BONIFICACION.ESPECIAL))
                {
                    rbVenta.Checked = true;
                    rbVenta.Enabled = true;
                    rbPago.Enabled = true;
                }
                else
                {
                    rbVenta.Checked = true;
                    rbVenta.Enabled = false;
                    rbPago.Enabled = false;
                }
            }
            catch
            {
                spPorcentaje.Value = spPorcentaje.Minimum;
                spPorcentaje.Enabled = true;
                rbVenta.Checked = true;
                rbVenta.Enabled = false;
                rbPago.Enabled = false;
            }
        }

        private void chkPorContratacion_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPorContratacion.Checked)
            {
                chkContemplarMeses.Enabled = false;
                chkContemplarMeses.Checked = false;
                spCantidadPeriodos.Enabled = true;
                dtpFechaDesde.Enabled = true;
                dtpFechaHasta.Enabled = true;
            }
            else
            {
                chkContemplarMeses.Enabled = true;
                chkContemplarMeses.Checked = false;
                spCantidadPeriodos.Enabled = false;
                dtpFechaDesde.Enabled = true;
                dtpFechaHasta.Enabled = true;
            }
        }

        private void chkContemplarMeses_CheckedChanged(object sender, EventArgs e)
        {
            if (chkContemplarMeses.Checked)
            {
                chkPorContratacion.Enabled = false;
                chkPorContratacion.Checked = false;
                spCantidadPeriodos.Enabled = false;
                dtpFechaDesde.Enabled = true;
                dtpFechaHasta.Enabled = true;
                dtpFechaDesde.CustomFormat = "MMMM";
                dtpFechaHasta.CustomFormat = "MMMM";
            }
            else
            {
                chkPorContratacion.Enabled = true;
                chkPorContratacion.Checked = false;
                spCantidadPeriodos.Enabled = true;
                dtpFechaDesde.Enabled = true;
                dtpFechaHasta.Enabled = true;
                dtpFechaDesde.CustomFormat = "dd/MM/yyyy";
                dtpFechaHasta.CustomFormat = "dd/MM/yyyy";
            }
        }
    }
}
