using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CapaNegocios;

namespace CapaPresentacion.Seguridad
{
    public partial class frmBienvenida : Form
    {
        int Contador = 0;
        Personal oPersonal = new Personal();
        public frmBienvenida()
        {
            InitializeComponent();
        }

        private void frmBienvenida_Load(object sender, EventArgs e)
        {
            imgIzq.Image = Image.FromFile(@"C:\GIES\Imagenes\BIENVENIDA1.jfif");
            imgIzq.SizeMode = PictureBoxSizeMode.CenterImage;
            lblUsuario.Text = Personal.Name_Login.ToString().ToUpper();
            this.Opacity = 0.0;
            timerInicio.Start();
        }

        private void timerInicio_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1)
                this.Opacity+=0.05;
            pbDatos.Value++;
            if(pbDatos.Value == 25)
            {
                lblDatos.Text = "EXTRAYENDO INFORMACION...";
            }
            else if(pbDatos.Value == 50)
            {
                lblDatos.Text = "RECOPILANDO INFORMACION...";
            }
            else if (pbDatos.Value == 750)
            {
                lblDatos.Text = "INSERTANDO INFORMACION...";
            }
            else if (pbDatos.Value == 100)
            {
                lblDatos.Text = "INGRENSANDO...";
                timerInicio.Stop();
                timerFinal.Start();
            }
        }

        private void timerFinal_Tick(object sender, EventArgs e)
        {

            this.Opacity -= 0.01;
            if(this.Opacity == 0)
            {
                timerFinal.Stop();
                this.Close();
                this.DialogResult = DialogResult.OK;
            }
        }
    }
}
