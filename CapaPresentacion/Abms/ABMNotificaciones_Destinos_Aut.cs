using CapaNegocios;
using System;
using System.Data;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Abms
{
    public partial class ABMNotificaciones_Destinos_Aut : Form
    {
        #region [PROPIEDADES]
        private Thread hilo;
        private delegate void myDel();
        private Int32 IdModulo = 0;
        private DataTable dtModulos;
        private DataTable dtDestinos;
        private DataTable dtDestinosAutomaticos = new DataTable();
        private Notificaciones_Destinatarios oNotificDes = new Notificaciones_Destinatarios();
        private Notificaciones_Destinatarios_Aut oNotificAut = new Notificaciones_Destinatarios_Aut();
        #endregion

        #region [METODOS]
        private void ComenzarCarga()
        {
            pgCircular.Start();

            dgv.DataSource = null;

            hilo = new Thread(new ThreadStart(CargarDatos));
            hilo.Start();
        }

        private void CargarDatos()
        {
            try
            {
                dtModulos = oNotificAut.GetModulos();
                dtDestinos = oNotificDes.ListarPosiblesDestinatarios();

                myDel MD = new myDel(AsignarDatos);

                this.Invoke(MD, new object[] { });

                pgCircular.Stop();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Informacion" + ex.Message);
            }
        }

        private void AsignarDatos()
        {
            dgv.DataSource = dtModulos;

            dgv.Columns["Id"].HeaderText = "Codigo";
            dgv.Columns["Id"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns["Descripcion"].HeaderText = "Modulo";
            dgv.Columns["Formulario"].Visible = false;
            dgv.Enabled = true;

            dgvPosiblesDestinatarios.DataSource = dtDestinos;
            for (int x = 0; x < dgvPosiblesDestinatarios.ColumnCount; x++)
                dgvPosiblesDestinatarios.Columns[x].Visible = false;

            dgvPosiblesDestinatarios.Columns["tipo_destinatario"].Visible = true;
            dgvPosiblesDestinatarios.Columns["area_destinatario"].Visible = true;
            dgvPosiblesDestinatarios.Columns["destinatario"].Visible = true;

            dgvPosiblesDestinatarios.Columns["tipo_destinatario"].HeaderText = "Tipo de destinatario";
            dgvPosiblesDestinatarios.Columns["area_destinatario"].HeaderText = "Área";
            dgvPosiblesDestinatarios.Columns["destinatario"].HeaderText = "Destinatario";


        }

        private void CargarDestinos(Int32 Id)
        {
            dtDestinosAutomaticos = oNotificAut.GetDestinos(Id);

            dgvDestinos.DataSource = dtDestinosAutomaticos;
            dgvDestinos.Columns["Id"].Visible = false;
            dgvDestinos.Columns["Id_Tipo_Destinatario"].Visible = false;
            dgvDestinos.Columns["Id_Destinatario"].Visible = false;
            dgvDestinos.Columns["Id_Notificaciones_Modulos"].Visible = false;


        }

        #endregion

        public ABMNotificaciones_Destinos_Aut()
        {
            InitializeComponent();


        }

        private void ABMNotificaciones_Destinos_Aut_Load(object sender, EventArgs e)
        {
            ComenzarCarga();

            //dtDestinosAutomaticos.Columns.Add("Id", typeof(Int32));
            //dtDestinosAutomaticos.Columns.Add("Id_Noticiaciones_Modulos", typeof(Int32));
            //dtDestinosAutomaticos.Columns.Add("Id_Tipo_Destinatario", typeof(Int32));
            //dtDestinosAutomaticos.Columns.Add("Id_Destinatario", typeof(Int32));
            //dtDestinosAutomaticos.Columns.Add("Id_Destinatario", typeof(Int32));
            //dtDestinosAutomaticos.Columns.Add("Id_Destinatario", typeof(Int32));


        }

        private void ABMNotificaciones_Destinos_Aut_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                IdModulo = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells["Id"].Value.ToString());

                CargarDestinos(IdModulo);
            }
            catch { }
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            pnDestinatarios.Location = new Point(
                       this.ClientSize.Width / 2 - pnDestinatarios.Size.Width / 2,
                       this.ClientSize.Height / 2 - pnDestinatarios.Size.Height / 2);
            pnDestinatarios.Anchor = AnchorStyles.None;
            pnDestinatarios.Visible = true;
        }

        private void btnSeleccionarDestinatario_Click(object sender, EventArgs e)
        {
            if (dgvPosiblesDestinatarios.SelectedRows.Count > 0)
            {
                Int32 Id_Tipo_Destinatario = Convert.ToInt32(dgvPosiblesDestinatarios.SelectedRows[0].Cells["id_tipo_destinatario"].Value);
                Int32 Id_Destinatario = Convert.ToInt32(dgvPosiblesDestinatarios.SelectedRows[0].Cells["id_destinatario"].Value);

                oNotificAut.Guardar(IdModulo, Id_Tipo_Destinatario, Id_Destinatario);

                CargarDestinos(IdModulo);

                pnDestinatarios.Visible = false;
            }
            else
                MessageBox.Show("No ha seleccionado datos.");
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvDestinos.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("¿Desea Eliminar el Destino Seleccionado?", "Mensaje del Sistema",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    oNotificAut.Eliminar(Convert.ToInt32(dgvDestinos.SelectedRows[0].Cells["Id"].Value));
                    CargarDestinos(IdModulo);
                }
            }
        }
    }
}
