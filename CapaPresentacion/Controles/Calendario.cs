using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CapaPresentacion.Controles
{
    public delegate void CalendarioHandler(DateTime fechaSeleccionada, int cantidadProgramaciones);

    public partial class Calendario : UserControl
    {
        [Description("Evento que se desencadena cuando se presiona el boton de confirmar"), Category("Calendario")]
        public event CalendarioHandler Confirmacion;

        [Description("Evento que se desencadena cuando se confirma una fecha pasada"), Category("Calendario")]
        public event CalendarioHandler SeleccionFechaPasada;

        private bool permitirFechaPasada = true;
        [Description("Permitir que se puedan seleccionar fechas menores a la actual"), Category("Calendario")]
        public bool PermitirFechaPasada 
        {
            get => permitirFechaPasada; 
            set { permitirFechaPasada = value; } 
        }

        private DateTime? fechaPreseleccionada = null;
        [Description("Fecha preseleccionada por defecto en el calendario"), Category("Calendario")]
        public DateTime? FechaPreseleccionada
        {
            get => fechaPreseleccionada;
            set 
            { 
                fechaPreseleccionada = value; 
                if(value != null)
                {
                    this.mesSeleccionado = value.Value.Month;
                    this.anioSeleccionado = value.Value.Year;
                    CargarGrilla();
                    SeleccionarFechaPreseleccionada();
                }
            }
        }

        public List<CalendarioFecha> FechasCargadas;

        private static DataTable estructuraGrilla;

        private int mesSeleccionado;
        private int anioSeleccionado;

        static Calendario()
        {
            estructuraGrilla = new DataTable();
            estructuraGrilla.Columns.AddRange(new DataColumn[]
                {
                    new DataColumn("dia_numero", typeof(int)),
                    new DataColumn("dia_nombre", typeof(string)),
                    new DataColumn("fecha", typeof(DateTime)),
                    new DataColumn("cantidad", typeof(int)) { DefaultValue = 0 }
                }
            );
        }

        public Calendario()
        {
            InitializeComponent();
            FechasCargadas = new List<CalendarioFecha>();
            dgvCalendario.AllowUserToOrderColumns = false;
            mesSeleccionado = DateTime.Now.Month;
            anioSeleccionado = DateTime.Now.Year;
            dgvCalendario.DataSource = estructuraGrilla;
            dgvCalendario.Columns["cantidad"].Visible = false;
            dgvCalendario.Columns["fecha"].Visible = false;
            dgvCalendario.Columns["dia_numero"].HeaderText = "Numero";
            dgvCalendario.Columns["dia_nombre"].HeaderText = "Dia";
            dgvCalendario.Columns["dia_nombre"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Confirmacion = null;
            CargarGrilla();
        }

        private void CargarGrilla()
        {
            estructuraGrilla.Clear();
            lblTitulo.Text = $"{PrimeraLetraMayuscula(new DateTime(anioSeleccionado, mesSeleccionado, 1).ToString("MMMM"))}" +
                             $" - {new DateTime(anioSeleccionado, mesSeleccionado, 1).ToString("yyyy")}";
            List<DateTime> fechas = ListarFechas(anioSeleccionado, mesSeleccionado);
            foreach (DateTime fecha in fechas)
            {
                DataRow dr = estructuraGrilla.NewRow();
                dr["dia_numero"] = fecha.Day;
                dr["dia_nombre"] = PrimeraLetraMayuscula(fecha.ToString("dddd"));
                dr["fecha"] = fecha;
                estructuraGrilla.Rows.Add(dr);
            }
        }

        private void pnlIzq_Click(object sender, EventArgs e)
        {
            if (mesSeleccionado == 1)
            {
                mesSeleccionado = 12;
                anioSeleccionado -= 1;
            }
            else
                mesSeleccionado -= 1;
            CargarGrilla();
        }

        private void pnlDer_Click(object sender, EventArgs e)
        {
            if (mesSeleccionado == 12)
            {
                mesSeleccionado = 1;
                anioSeleccionado += 1;
            }
            else
                mesSeleccionado += 1;
            CargarGrilla();
        }

        public List<DateTime> ListarFechas(int anio, int mes)
        {
            return Enumerable.Range(1, DateTime.DaysInMonth(anio, mes))
                             .Select(day => new DateTime(anio, mes, day))
                             .ToList();
        }

        private bool VerificarFechaCargada(DateTime fechaSeleccionada, out string descripcion, out int cantidadProgramaciones)
        {
            bool esta = false;
            StringBuilder sb = new StringBuilder();
            cantidadProgramaciones = 0;
            foreach (CalendarioFecha cf in FechasCargadas)
            {
                if (cf.Fecha.Date.Equals(fechaSeleccionada.Date))
                {
                    sb.AppendLine($"{cf.Descripcion}");
                    cantidadProgramaciones++;
                    esta = true;
                }
            }

            if (esta)
                sb.AppendLine($"Cantidad de reprogramaciones ({cantidadProgramaciones})");

            descripcion = sb.ToString();
            return esta;
        }

        private string PrimeraLetraMayuscula(string cadena)
        {
            return $"{char.ToUpper(cadena.ToLower()[0])}{cadena.ToLower().Substring(1)}";
        }

        private void dgvCalendario_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if(VerificarFechaCargada(Convert.ToDateTime(dgvCalendario.Rows[e.RowIndex].Cells["fecha"].Value), out string desc, out int cant))
            {   
                txtDescripcion.Text = desc;
                estructuraGrilla.Rows[e.RowIndex]["cantidad"] = cant;
            }
            else
            {
                txtDescripcion.Text = string.Empty;
                estructuraGrilla.Rows[e.RowIndex]["cantidad"] = 0;
            }

            lblFecha.Text = $"Dia {dgvCalendario.Rows[e.RowIndex].Cells["dia_nombre"].Value} " +
                            $"{dgvCalendario.Rows[e.RowIndex].Cells["dia_numero"].Value} " +
                            $"de {PrimeraLetraMayuscula(new DateTime(anioSeleccionado, mesSeleccionado, 1).ToString("MMMM"))} " +
                            $"de {anioSeleccionado}";
        }

        private void dgvCalendario_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if(VerificarFechaCargada(Convert.ToDateTime(dgvCalendario.Rows[e.RowIndex].Cells["fecha"].Value), out string desc, out int cant))
            {
                dgvCalendario.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Aquamarine;
            }
        }

        private void SeleccionarFechaPreseleccionada()
        {
            foreach (DataGridViewRow row in dgvCalendario.Rows)
            {
                if (Convert.ToInt32(row.Cells["dia_numero"].Value) == fechaPreseleccionada.Value.Day)
                {
                    row.Selected = true;
                    dgvCalendario.FirstDisplayedScrollingRowIndex = Convert.ToInt32(row.Cells["dia_numero"].Value) - 1;
                    break;
                }
            }
        }

        private void ConfirmarFecha()
        {
            if (Confirmacion == null)
                return;

            if (dgvCalendario.SelectedRows.Count > 0)
            {
                if (!permitirFechaPasada)
                {
                    if (Convert.ToDateTime(dgvCalendario.SelectedRows[0].Cells["fecha"].Value).Date < DateTime.Now.Date)
                    {
                        SeleccionFechaPasada(Convert.ToDateTime(dgvCalendario.SelectedRows[0].Cells["fecha"].Value), 0);
                        return;
                    }
                }

                Confirmacion(Convert.ToDateTime(dgvCalendario.SelectedRows[0].Cells["fecha"].Value), Convert.ToInt32(dgvCalendario.SelectedRows[0].Cells["cantidad"].Value));
            }
        }

        private void btnAccion_Click(object sender, EventArgs e)
        {
            ConfirmarFecha();
        }

        private void dgvCalendario_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            ConfirmarFecha();
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            base.OnVisibleChanged(e);

            if (Visible && !Disposing)
            {
                if (fechaPreseleccionada != null)
                {
                    SeleccionarFechaPreseleccionada();
                }
            }
        }

        public class CalendarioFecha
        {
            public DateTime Fecha { get; set; }
            public string Descripcion { get; set; }

            public CalendarioFecha(DateTime Fecha, string Descripcion)
            {
                this.Fecha = Fecha;
                this.Descripcion = Descripcion;
            }
        }
    }
}
