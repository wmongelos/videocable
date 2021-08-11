using CapaNegocios;
using System;

namespace CapaPresentacion.Partes_Trabajo
{
    public partial class frmAvisos : frmUsuarioLocacion
    {
        private new Int32 Usuario_Id = 0;
        private Int32 Locacion_Id = 0;
        private Int32 servicios_id = 0;

        private Usuarios_Avisos oUsuarios_Avisos = new Usuarios_Avisos();

        private Usuarios oUsu = new Usuarios();
        private Usuarios_Locaciones oUsuLoc = new Usuarios_Locaciones();
        private Usuarios_Servicios oUsuser = new Usuarios_Servicios();

        public frmAvisos(Int32 usuid, Int32 locaid, Int32 Servid)
        {
            InitializeComponent();
            Usuario_Id = usuid;
            Locacion_Id = locaid;
            servicios_id = Servid;
        }

        private void btnGenerarAviso_Click(object sender, EventArgs e)
        {
            genera_Aviso();
        }

        private void genera_Aviso()
        {
            oUsuarios_Avisos.id_usuarios = Usuario_Id;
            oUsuarios_Avisos.id_usuarios_locaciones = Convert.ToInt32(this.Usuario_Locacon_Id.ToString());
            oUsuarios_Avisos.id_usuarios_servicios = Convert.ToInt32(this.servicios_id.ToString());
            oUsuarios_Avisos.id_avisos_tipo = 1;
            oUsuarios_Avisos.id_personal = 1;
            oUsuarios_Avisos.fecha = DateTime.Now;
            oUsuarios_Avisos.descripcion = txtdescripcion.Text;
            oUsuarios_Avisos.receptor = txtReceptor.Text;
            oUsuarios_Avisos.tipo_de_comunicacion = "Correspondencia";
            oUsuarios_Avisos.Guardar(oUsuarios_Avisos);
            this.Close();
        }

        private void btnCancela_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
