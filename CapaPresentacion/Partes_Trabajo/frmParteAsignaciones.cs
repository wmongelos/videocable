using CapaNegocios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmParteAsignaciones : Form
    {
        #region PROPIEDADES
        private Thread hilo;
        private delegate void myDel();

        public int id_parte_recibido = 0;
        public int IdParteRecibido = 0;
        public int id_parte_retorno = 0;
        public int form_envio = 0;
        public DataRow drEquipo_sel;
        public List<Partes_Equipos> lista_partes_equipos = new List<Partes_Equipos>();

        public Partes.Partes_Estados Parte_Estado;

        private frmPopUp frmPop = new frmPopUp();

        private Partes oParte = new Partes();
        private Configuracion oConfig = new Configuracion();
        private Partes_Historial oPartesHistorial = new Partes_Historial();
        private Equipos oEquipos = new Equipos();
        private Partes_Equipos oParte_Equipo = new Partes_Equipos();
        private Servicios oServicios = new Servicios();

        private int id;
        private int config_agenda;
        private int id_tecnico;
        private int IdParteEstado = 0;
        private Boolean estado = false;
        private DataTable dtEquiposRequeridos = new DataTable();
        private DataTable dt = new DataTable();
        private DataTable dtDatosServicios = new DataTable();
        #endregion


        #region[METODOS]

        private void comenzarCarga()//carga datos en el datatable
        {
            pgCircular.Start();
            dgv.DataSource = null;
            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.Start();
        }

        private void cargarDatos()
        {
            config_agenda = oConfig.GetValor_N("Agenda_Trabajo");
            if (IdParteRecibido > 0)
                dt.ImportRow(oParte.TraerParteRow(IdParteRecibido));
            else
                dt = oParte.Listar(this.Parte_Estado);
            myDel MD = new myDel(asignarDatos);
            this.Invoke(MD, new object[] { });
            pgCircular.Stop();

        }

        private void asignarDatos()
        {
            dgv.DataSource = dt;

            for (int i = 0; i < dgv.Columns.Count; i++)
                dgv.Columns[i].Visible = false;

            if (IdParteRecibido > 0)
            {
                dgv.Columns["id"].Visible = true;
                dgv.Columns["fecha_reclamo"].Visible = true;
                dgv.Columns["apellido"].Visible = true;
                dgv.Columns["nombre"].Visible = true;
                dgv.Columns["Localidad"].Visible = true;
                dgv.Columns["calle"].Visible = true;
                dgv.Columns["altura"].Visible = true;
                dgv.Columns["detalle_falla"].Visible = true;
            }
            else
            {
                dgv.Columns["id"].Visible = true;
                dgv.Columns["Fecha"].Visible = true;
                dgv.Columns["Usuario"].Visible = true;
                dgv.Columns["Localidad"].Visible = true;
                dgv.Columns["Direccion"].Visible = true;
                dgv.Columns["Falla"].Visible = true;
                dgv.Columns["id"].ReadOnly = true;
                dgv.Columns["Fecha"].ReadOnly = true;
                dgv.Columns["Usuario"].ReadOnly = true;
                dgv.Columns["Localidad"].ReadOnly = true;
                dgv.Columns["Direccion"].ReadOnly = true;
                dgv.Columns["Falla"].ReadOnly = true;
                dgv.Columns["cantidad"].ReadOnly = true;

                dgv.Columns["Fecha"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv.Columns["Usuario"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv.Columns["Localidad"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv.Columns["Direccion"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv.Columns["Falla"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv.Columns["id"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgv.Columns["id"].HeaderText = "Nro.";
                dgv.Columns["Fecha"].HeaderText = "Reclamo";
                dgv.Columns["Falla"].HeaderText = "Solicitud";

                dt.Columns.Add("Sel", typeof(Boolean));
                dt.Columns["Sel"].ReadOnly = false;
                foreach (DataGridViewRow fila in dgv.Rows)
                    fila.Cells["Sel"].Value = false;

                dgv.Columns["Sel"].Width = 40;

                dgv.Columns["Sel"].HeaderText = "Asignar";
                dgv.Sort(dgv.Columns["tiposervicio"], System.ComponentModel.ListSortDirection.Ascending);
                dgv.Columns["id"].Width = 50;
            }

            lblTotal.Text = String.Format("Total de Registros: {0}", dt.Rows.Count);
        }

        public void FiltroGeneral()
        {
            if (txtBuscar.Text.Length > 0)
                dt.DefaultView.RowFilter = String.Format("Usuario Like '%{0}%' or servicio Like '%{0}%' or falla Like '%{0}%' or tecnico Like '%{0}%' or localidad Like '%{0}%' or direccion Like '%{0}%'  ", txtBuscar.Text);
            else
                dt.DefaultView.RowFilter = "id>0";

            int Id = 0;
            if (txtBuscar.Text.Length > 0)
            {
                try
                {
                    if (Int32.TryParse(txtBuscar.Text, out Id))
                        dt.DefaultView.RowFilter = String.Format("id='" + txtBuscar.Text + "'");
                    else
                        dt.DefaultView.RowFilter = String.Format("Usuario Like '%{0}%' or servicio Like '%{0}%' or falla Like '%{0}%' or tecnico Like '%{0}%' or localidad Like '%{0}%' or direccion Like '%{0}%'  ", txtBuscar.Text);
                }
                catch
                {
                    dt.DefaultView.RowFilter = String.Format("Usuario Like '%{0}%' or servicio Like '%{0}%' or falla Like '%{0}%' or tecnico Like '%{0}%' or localidad Like '%{0}%' or direccion Like '%{0}%'  ", txtBuscar.Text);
                }
            }
            else
                dt.DefaultView.RowFilter = "id>0";

        }

        private void AsignarTecnico()
        {
            IdParteEstado = 0;
            int cant_seleccionados = 0;

            foreach (DataGridViewRow fila in dgv.Rows)
            {
                if (Convert.ToBoolean(fila.Cells["Sel"].Value) == true)
                    cant_seleccionados++;
            }

            if (cant_seleccionados > 0)
            {
                frmBusquedaTecnicos frm1 = new frmBusquedaTecnicos();
                frmPop.Formulario = frm1;

                if (frmPop.ShowDialog() == DialogResult.OK)
                {
                    id = frm1.tecnicoSel;
                    this.id_tecnico = id;
                    int idParteEstadoProximo = 0;
                    try
                    {
                        foreach (DataGridViewRow fila in dgv.Rows)
                        {
                            if (Convert.ToBoolean(fila.Cells["Sel"].Value) == true)
                            {
                                try
                                {
                                    id = Convert.ToInt32(fila.Cells["id"].Value);
                                    //me fijo si el servicio asociado a este parte, tiene equipo
                                    DataRow drParte = oParte.TraerParteRow(id);
                                    int idServicio = Convert.ToInt32(drParte["id_servicios"]);
                                    dtDatosServicios = oServicios.BuscarDatosServicio(idServicio);
                                    if (dtDatosServicios.Rows.Count > 0)
                                    {
                                        if (dtDatosServicios.Rows[0]["requiere_equipo"].ToString().Equals("NO"))
                                            idParteEstadoProximo = Convert.ToInt32(Partes.Partes_Estados.ASIGNADO);
                                        else
                                            idParteEstadoProximo = Convert.ToInt32(Partes.Partes_Estados.PENDIENTE_DE_ASIGNACION_DE_EQUIPO);
                                    }
                                    oParte.AsignarTecnico(id, id_tecnico, idParteEstadoProximo);
                                    //IdParteEstado = oParte.SetearEstadoParte(Convert.ToInt32(fila.Cells["id"].Value), 0,0,DateTime.Now,0,0,"");
                                    oPartesHistorial.Id_Partes_Estados = IdParteEstado;
                                    oPartesHistorial.Id_Parte = id;
                                    oPartesHistorial.Id_Usuarios = Convert.ToInt32(fila.Cells["id_usuarios"].Value);
                                    oPartesHistorial.Id_Personal = Personal.Id_Login;
                                    oPartesHistorial.Fecha_Movimiento = DateTime.Now;
                                    oPartesHistorial.Id_area = Personal.Id_Area;
                                    oPartesHistorial.Detalles = "TÉCNICO ASIGNADO.";
                                    oPartesHistorial.GuardarNuevoDetalle(oPartesHistorial);
                                }
                                catch
                                {
                                    MessageBox.Show("Error al asignar técnico.");
                                }
                                IdParteEstado = 0;
                            }
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Error en la asignación de técnicos.");
                    }

                    comenzarCarga();
                }
            }
            else
                MessageBox.Show("No se han seleccionado partes.");
        }
        #endregion

        public frmParteAsignaciones()
        {
            InitializeComponent();
        }

        private void frmParteAsignacion_Equipos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            FiltroGeneral();
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            FiltroGeneral();
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAsignarTecnico_Click(object sender, EventArgs e)
        {
            AsignarTecnico();
        }

        private void frmParteAsignaciones_Load(object sender, EventArgs e)
        {
            dgv.ReadOnly = false;
            comenzarCarga();
        }

        private void btnSeleccionarTodos_Click(object sender, EventArgs e)
        {
            if (estado == false)
            {
                foreach (DataGridViewRow item in dgv.Rows)
                    item.Cells["Sel"].Value = true;
                estado = true;
                btnSeleccionarTodos.Text = "Deseleccionar todos";
            }
            else
            {
                foreach (DataGridViewRow item in dgv.Rows)
                    item.Cells["Sel"].Value = false;
                estado = false;
                btnSeleccionarTodos.Text = "Seleccionar todos";

            }
        }

        private void dgv_SelectionChanged(object sender, EventArgs e)
        {
            try
            {
                if (dgv.Rows.Count > 0)
                {
                    Int32 idParte = Convert.ToInt32(dgv.SelectedRows[0].Cells["id"].Value);
                    String estadoParte = dgv.SelectedRows[0].Cells["Estado"].Value.ToString();
                    lblNumParte.Text = idParte.ToString();
                }
            }
            catch (Exception)
            {
            }
        }
    }
}
