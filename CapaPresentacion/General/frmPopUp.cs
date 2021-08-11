using System;
using System.Drawing;
using System.Windows.Forms;

namespace CapaPresentacion
{
    public partial class frmPopUp : Form
    {
        public Form Formulario { get; set; }
        public Boolean Maximizar { get; set; } = true;
        public Panel pnlPanel { get; set; }
        public Form FormularioVacio = new Form();
        public bool InsertarMenu = false;
        public Font Fuente = null;
        public Controles.boton oBotonConfirmar = new Controles.boton();
        public bool accionConfirma = false;
        public frmPopUp()
        {
            InitializeComponent();
            this.MaximumSize = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);

            //this.Height = Screen.PrimaryScreen.WorkingArea.Height;
            //this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            //this.Location = Screen.PrimaryScreen.WorkingArea.Location;
        }
        private void Formulario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                Cerrar();

        }
        private void OBotonConfirmar_Click(object sender, System.EventArgs e)
        {
            this.accionConfirma = true;
            Cerrar();
        }
        private void frmPopUp_Load(object sender, EventArgs e)
        {

            if (Formulario == null)
            {
                Formulario = FormularioVacio;
                Formulario.FormBorderStyle = FormBorderStyle.None;
                Formulario.StartPosition = FormStartPosition.CenterScreen;
                Formulario.Controls.Add(pnlPanel);
                pnlPanel.Visible = true;
                pnlPanel.Dock = DockStyle.Top;
                Formulario.AutoSize = false;
                Formulario.AutoSizeMode = AutoSizeMode.GrowAndShrink;
                Formulario.KeyPreview = true;
                Formulario.MaximumSize = new System.Drawing.Size(pnlPanel.Width, pnlPanel.Height);

                if (InsertarMenu)
                {
                    Panel oPanelBotones = new Panel();
                    oPanelBotones.BackColor = Formulario.BackColor;
                    oPanelBotones.Width = pnlPanel.Width;
                    oPanelBotones.Dock = DockStyle.Bottom;
                    oPanelBotones.Height = 60;
                    oPanelBotones.Visible = true;
                    oPanelBotones.Location = new Point(pnlPanel.Location.X, pnlPanel.Location.Y + pnlPanel.Height);
                    oBotonConfirmar.Text = "Confirmar";
                    oBotonConfirmar.Visible = true;
                    oBotonConfirmar.Width = 100;
                    oBotonConfirmar.Height = 40;
                    Formulario.Controls.Add(oPanelBotones);
                    oPanelBotones.BringToFront();
                    oPanelBotones.Controls.Add(oBotonConfirmar);
                    oBotonConfirmar.Location = new Point(oPanelBotones.Width/2 - oBotonConfirmar.Width /2 ,10);
                    Formulario.MaximumSize = new System.Drawing.Size(pnlPanel.Width, pnlPanel.Height+ oPanelBotones.Height);
                    oBotonConfirmar.BringToFront();
                    if (Fuente!=null)
                    {
                        Formulario.Font = this.Fuente;
                      
                    }
                }

                CrearEventos();
            }
            if (this.Maximizar)
            {
                this.Formulario.Width = Screen.PrimaryScreen.WorkingArea.Width - 100;
                this.Formulario.Height = Screen.PrimaryScreen.WorkingArea.Height - 100;
            }
            else
            {
                if (pnlPanel != null)
                {
                    this.Formulario.Width = pnlPanel.Width;
                    this.Formulario.Height = pnlPanel.Height;

                }
            }
            this.DialogResult = Formulario.ShowDialog();
        }

        public void Cerrar()
        {

            this.DialogResult = DialogResult.OK;
            Formulario.Close();
            this.Close();
        }
    }
}
