using CapaNegocios;
using System;
using System.Data;
using System.Windows.Forms;

namespace CapaPresentacion.Inventario
{
    public partial class FrmBuscadorGen : Form
    {
        public enum Tipo { AREAS = 1, PERSONAL = 2, MOVIL = 3, ARTICULOS = 4, PROVEEDORES = 5, EQUIPOS = 6, EQUIPOS_TARJETAS = 7 }
        public Int32 Id;
        public String Value;
        public Double ImporteArt;
        public Int32 Stock;
        public Int32 StockMin;
        public Int32 IdArtRubros;
        public Tipo List;
        public String Equipo;
        public String MarcaEquipo;
        public String SerieEquipo;
        public String MacEquipo;
        public Int32 IdEquipoEstado;
        public Int32 idEquipoTipo;
        public Int64 NumeroTarjeta;

        public Int32 id_usuario; // AGREGUE ESTA LINEA DE CODIGO


        private String textoBuscador = string.Empty;

        private DataTable Data;

        public FrmBuscadorGen()
        {
            InitializeComponent();
        }

        public FrmBuscadorGen(String textoBuscador)
        {
            InitializeComponent();
            this.textoBuscador = textoBuscador;
        }


        private void CargarDatos()
        {
            switch (this.List)
            {
                case Tipo.AREAS:
                    Personal_Areas oAreas = new Personal_Areas();
                    Data = oAreas.Listar();
                    break;
                case Tipo.PERSONAL:
                    Personal oPersonal = new Personal();
                    Data = oPersonal.Listar();
                    break;
                case Tipo.MOVIL:
                    Moviles oMovil = new Moviles();
                    Data = oMovil.Listar();
                    break;
                case Tipo.ARTICULOS:
                    Articulos oArticulos = new Articulos();
                    Data = oArticulos.Listar();
                    Data.Columns["Descripcion"].ColumnName = "Nombre";
                    break;
                case Tipo.PROVEEDORES:
                    Proveedores oProveedores = new Proveedores();
                    Data = oProveedores.Listar();
                    break;
                case Tipo.EQUIPOS:
                    Equipos oEquipos = new Equipos();
                    Data = oEquipos.ListarEquiposDisponibles();
                    break;
                case Tipo.EQUIPOS_TARJETAS:
                    Equipos_Tarjetas oEquipoTarjeta = new Equipos_Tarjetas();
                    Data = oEquipoTarjeta.ListarEquiposRequierenTarjeta();
                    break;
                default:
                    break;
            }

            dgv.DataSource = Data;

            for (int i = 0; i < dgv.ColumnCount; i++)
                dgv.Columns[i].Visible = false;

            switch (this.List)
            {
                case Tipo.AREAS:
                case Tipo.PERSONAL:
                case Tipo.MOVIL:
                case Tipo.ARTICULOS:
                    dgv.Columns["Nombre"].Visible = true;
                    break;
                case Tipo.PROVEEDORES:
                    dgv.Columns["Razon_social"].HeaderText = "Razon social";
                    dgv.Columns["Razon_social"].Name = "Nombre";
                    dgv.Columns["Nombre"].Visible = true;
                    break;
                case Tipo.EQUIPOS:
                    dgv.Columns["Nombre"].Visible = true;
                    dgv.Columns["Marca"].Visible = true;
                    dgv.Columns["Serie"].Visible = true;
                    dgv.Columns["Mac"].Visible = true;
                    dgv.Columns["Nombre"].HeaderText = "Nombre";
                    dgv.Columns["Marca"].HeaderText = "Marca";
                    dgv.Columns["Mac"].HeaderText = "Mac";
                    dgv.Columns["Serie"].HeaderText = "Serie";
                    break;
                case Tipo.EQUIPOS_TARJETAS:
                    dgv.Columns["NumeroTarjeta"].Visible = true;
                    dgv.Columns["Usuario"].Visible = true;
                    dgv.Columns["Equipo"].Visible = true;
                    dgv.Columns["NumeroTarjeta"].HeaderText = "NumeroTarjeta";
                    dgv.Columns["Usuario"].HeaderText = "Usuario";
                    dgv.Columns["Equipo"].HeaderText = "Equipo";

                    break;
                default:
                    break;
            }
        }

        private void FrmBuscadorGen_Load(object sender, EventArgs e)
        {
            this.CargarDatos();
        }

        private void FrmBuscadorGen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.DialogResult = DialogResult.Cancel;
        }

        private void AsignarValorSeleccionado(int indiceRowDgv)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                this.Id = Convert.ToInt32(dgv.Rows[indiceRowDgv].Cells["Id"].Value);
                if (List == Tipo.ARTICULOS)
                {
                    this.Value = dgv.Rows[indiceRowDgv].Cells["Nombre"].Value.ToString();
                    this.ImporteArt = Convert.ToDouble(dgv.Rows[indiceRowDgv].Cells["Importe"].Value);
                    this.Stock = Convert.ToInt32(dgv.Rows[indiceRowDgv].Cells["Stock"].Value);
                    this.StockMin = Convert.ToInt32(dgv.Rows[indiceRowDgv].Cells["Stock_Minimo"].Value);
                    this.IdArtRubros = Convert.ToInt32(dgv.Rows[indiceRowDgv].Cells["Id_Articulos_Rubros"].Value);
                }
                if (List == Tipo.EQUIPOS)
                {
                    this.IdEquipoEstado = Convert.ToInt32(dgv.Rows[indiceRowDgv].Cells["id_Equipo_Estado"].Value);
                    this.Equipo = Convert.ToString(dgv.Rows[indiceRowDgv].Cells["Nombre"].Value);
                    this.MarcaEquipo = Convert.ToString(dgv.Rows[indiceRowDgv].Cells["Marca"].Value);
                    this.SerieEquipo = Convert.ToString(dgv.Rows[indiceRowDgv].Cells["Serie"].Value);
                    this.MacEquipo = Convert.ToString(dgv.Rows[indiceRowDgv].Cells["Mac"].Value);
                    this.idEquipoTipo = Convert.ToInt32(dgv.Rows[indiceRowDgv].Cells["id_Equipo_Tipo"].Value);
                }
                if (List == Tipo.EQUIPOS_TARJETAS)
                {
                    this.NumeroTarjeta = Convert.ToInt64(dgv.Rows[indiceRowDgv].Cells["NumeroTarjeta"].Value);
                    this.id_usuario = Convert.ToInt32(dgv.SelectedRows[0].Cells["id_usuario"].Value);
                }

                this.DialogResult = DialogResult.OK;
            }
        }

        private void dgv_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            AsignarValorSeleccionado(e.RowIndex);
        }

        private void txtBuscador_TextChanged(object sender, EventArgs e)
        {
            if (this.List == FrmBuscadorGen.Tipo.EQUIPOS)
            {
                Data.DefaultView.RowFilter = String.Format("Nombre LIKE '%{0}%' OR Marca LIKE '%{0}%' OR Serie LIKE '%{0}%' OR Mac LIKE '%{0}%'", txtBuscador.Text);
            }
            else if (this.List == FrmBuscadorGen.Tipo.ARTICULOS)
            {
                Data.DefaultView.RowFilter = String.Format("Nombre LIKE '%{0}%'", txtBuscador.Text);
            }
            else
            {
                Data.DefaultView.RowFilter = String.Format("NumeroTarjeta LIKE '%{0}%'", txtBuscador.Text);
            }
        }

        private void dgv_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int i = dgv.CurrentRow.Index;
                AsignarValorSeleccionado(dgv.CurrentRow.Index);
            }
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void FrmBuscadorGen_Shown(object sender, EventArgs e)
        {
            if (!this.textoBuscador.Equals(string.Empty))
            {
                txtBuscador.Text = this.textoBuscador;
                if (dgv.Rows.Count > 0)
                {
                    dgv.Rows[0].Selected = true;
                    dgv.Focus();
                }
                else
                {
                    txtBuscador.Focus();
                    txtBuscador.SelectAll();
                }

            }
        }
    }
}