using CapaNegocios;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CapaPresentacion.Abms
{
    public partial class ABMOperaciones_Condiciones_Relacion : Form
    {
        private DataTable dtOperacionesCondicionesRel;
        private int idParteOperacion;

        public ABMOperaciones_Condiciones_Relacion()
        {
            InitializeComponent();
        }

        private void ABMOperaciones_Condiciones_Relacion_Load(object sender, EventArgs e)
        {
            CargarOperaciones();
            CrearDGV();
            SeleccionarOperacion();
        }

        private void CrearDGV()
        {
            dtOperacionesCondicionesRel = new Operaciones_Condiciones().Listar();
            dtOperacionesCondicionesRel.Columns.Add(new DataColumn("estadoHabilitado", typeof(bool)) { DefaultValue = false });
            dtOperacionesCondicionesRel.Columns.Add(new DataColumn("estadoAdvertencia", typeof(bool)) { DefaultValue = false });
            dtOperacionesCondicionesRel.Columns.Add(new DataColumn("estadoRestringido", typeof(bool)) { DefaultValue = false });
            dtOperacionesCondicionesRel.Columns.Add(new DataColumn("idRel", typeof(int)) { DefaultValue = 0 });

            dgv.DataSource = dtOperacionesCondicionesRel;

            foreach (DataGridViewColumn col in dgv.Columns)
            {
                col.Visible = false;
            }

            dgv.Columns["descripcion"].Visible = true;
            dgv.Columns["descripcion"].HeaderText = "Condiciones";
            dgv.Columns["estadoHabilitado"].Visible = true;
            dgv.Columns["estadoHabilitado"].HeaderText = "Habilitado";
            dgv.Columns["estadoAdvertencia"].Visible = true;
            dgv.Columns["estadoAdvertencia"].HeaderText = "Advertencia";
            dgv.Columns["estadoRestringido"].Visible = true;
            dgv.Columns["estadoRestringido"].HeaderText = "Restringido";
        }

        private void CargarOperaciones()
        {
            cboPartesOperaciones.DataSource = new Partes().ListarOperaciones();
            cboPartesOperaciones.DisplayMember = "Nombre";
            cboPartesOperaciones.ValueMember = "Id";
            cboPartesOperaciones.SelectedValueChanged += cboPartesOperaciones_SelectedValueChanged;
        }

        private void SeleccionarOperacion()
        {
            idParteOperacion = Convert.ToInt32(cboPartesOperaciones.SelectedValue);
            DataTable dtRelaciones = new Operaciones_Condiciones_Rel().Listar(idParteOperacion);
            limpiarDt();
            if (dtRelaciones.Rows.Count > 0)
            {
                foreach (DataRow row in dtRelaciones.Rows)
                {
                    foreach (DataRow row2 in dtOperacionesCondicionesRel.Rows)
                    {
                        if(Convert.ToInt32(row["id_condicion"]) == Convert.ToInt32(row2["Id"]))
                        {
                            Operaciones_Condiciones_Rel.Estados estadoActual = (Operaciones_Condiciones_Rel.Estados)row["estado"];
                            row2["idRel"] = Convert.ToInt32(row["id"]);
                            switch (estadoActual)
                            {
                                case Operaciones_Condiciones_Rel.Estados.Habilitado:
                                    row2["estadoHabilitado"] = true;
                                    break;
                                case Operaciones_Condiciones_Rel.Estados.Advertencia:
                                    row2["estadoAdvertencia"] = true;
                                    break;
                                case Operaciones_Condiciones_Rel.Estados.Restringido:
                                    row2["estadoRestringido"] = true;
                                    break;
                                default:
                                    break;
                            }
                            
                        }
                    }
                }
            }
            else
            {
                foreach (DataRow row in dtOperacionesCondicionesRel.Rows)
                {
                    row["estadoHabilitado"] = true;
                }
            }
        }

        private void limpiarDt()
        {
            foreach (DataRow row in dtOperacionesCondicionesRel.Rows)
            {
                row["estadoHabilitado"] = false;
                row["estadoAdvertencia"] = false;
                row["estadoRestringido"] = false;
                row["idRel"] = 0;
            }
        }

        private void cboPartesOperaciones_SelectedValueChanged(object sender, EventArgs e)
        {
            SeleccionarOperacion();
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dgv.Columns[e.ColumnIndex].Name == "estadoHabilitado" ||
                dgv.Columns[e.ColumnIndex].Name == "estadoAdvertencia" ||
                dgv.Columns[e.ColumnIndex].Name == "estadoRestringido")
            {
                dgv.Rows[e.RowIndex].Cells["estadoHabilitado"].Value = false;
                dgv.Rows[e.RowIndex].Cells["estadoAdvertencia"].Value = false;
                dgv.Rows[e.RowIndex].Cells["estadoRestringido"].Value = false;

                bool val = !Convert.ToBoolean(dgv.Rows[e.RowIndex].Cells[dgv.Columns[e.ColumnIndex].Name].Value);
                dgv.Rows[e.RowIndex].Cells[dgv.Columns[e.ColumnIndex].Name].Value = val;
            }
        }

        private void GuardarRelaciones()
        {
            List<Operaciones_Condiciones_Rel> listaDeRelaciones = new List<Operaciones_Condiciones_Rel>();
            foreach (DataRow row in dtOperacionesCondicionesRel.Rows)
            {
                int estadoSeleccionado;
                if (Convert.ToBoolean(row["estadoAdvertencia"]))
                    estadoSeleccionado = Convert.ToInt32(Operaciones_Condiciones_Rel.Estados.Advertencia);
                else if (Convert.ToBoolean(row["estadoRestringido"]))
                    estadoSeleccionado = Convert.ToInt32(Operaciones_Condiciones_Rel.Estados.Restringido);
                else
                    estadoSeleccionado = Convert.ToInt32(Operaciones_Condiciones_Rel.Estados.Habilitado);

                Operaciones_Condiciones_Rel oOCR = new Operaciones_Condiciones_Rel();
                oOCR.Id = Convert.ToInt32(row["idRel"]);
                oOCR.Id_Parte_Operaciones = idParteOperacion;
                oOCR.Id_Condicion = Convert.ToInt32(row["id"]);
                oOCR.Estado = estadoSeleccionado;

                listaDeRelaciones.Add(oOCR);
            }

            if(MessageBox.Show("¿Confirmar cambios?", "Mensaje del sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    new Operaciones_Condiciones_Rel().Guardar(listaDeRelaciones);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Hubo un error al guardar la relacion: {ex.Message}", "Mensaje del sistema");
                    return;
                }
                MessageBox.Show("Relaciones guardadas correctamente", "Mensaje del sistema");
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            GuardarRelaciones();
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ABMOperaciones_Condiciones_Relacion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
        }

        private void dgv_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgv.Columns[e.ColumnIndex].Name == "estadoHabilitado")
                e.CellStyle.BackColor = Color.LightGreen;
            else if (dgv.Columns[e.ColumnIndex].Name == "estadoAdvertencia")
                e.CellStyle.BackColor = Color.Khaki;
            else if (dgv.Columns[e.ColumnIndex].Name == "estadoRestringido")
                e.CellStyle.BackColor = Color.Tomato;
        }
    }
}
