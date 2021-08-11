using CapaNegocios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Windows.Forms;

namespace CapaPresentacion.Abms
{
    public partial class frmAsignacionMinetti : Form
    {
        #region [PROPIEDADES]
        private Thread hilo;
        private delegate void myDel();
        private Equipos oEquipo = new Equipos();
        private Equipos_Tarjetas oTarjeta = new Equipos_Tarjetas();
        public int idUsuarioServicioSeleccionado;
        private int Id;
        public string Tarjeta, Serie_Equipo;
        public int Viene = 0;
        public int idEquipo = 0;
        public int id_Usuario_Viene = 0;
        #endregion

        public frmAsignacionMinetti()
        {
            InitializeComponent();
        }

        #region [METODOS]
        private void comenzarCarga()
        {
            hilo = new Thread(new ThreadStart(cargarDatos));
            hilo.Start();
        }

        private void cargarDatos()
        {
            try
            {
                myDel MD = new myDel(asignarDatos);
                this.Invoke(MD, new object[] { });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar Informacion" + ex.Message);
            }
        }

        private void asignarDatos()
        {

            controles(true);
            asignarValores();
        }

        private void controles(bool state)
        {

            txtSerieEquipo.Enabled = state;
            btnGuardar.Enabled = state;
            btnCancelar.Enabled = state;
        }

        private void limpiarValores()
        {
            Id = 0;
            txtSerieEquipo.Text = "";
        }

        private void asignarValores()
        {
            if(Viene == 1) 
            {
                txtSerie.Text = Tarjeta;
                txtSerieEquipo.Text = Serie_Equipo;          
            }
        }

        private void nuevoRegistro()
        {
            Id = 0;
            txtSerieEquipo.Text = "";
            txtSerieEquipo.Enabled = true;
            txtSerieEquipo.Focus();
        }

        private void guardarRegistro()
        {
            idEquipo = 0;
            int idTarjeta = 0;

            if (txtSerieEquipo.Text.Trim().Length == 0)
            {
                lblError.Text = "Ingrese numero de serie del equipo";
                lblError.Visible = true;
                txtSerieEquipo.Focus();
            }
            else
            {
                if (txtSerie.Text.Trim().Length == 0)
                {
                    lblError.Text = "Ingrese numero de tarjeta";
                    lblError.Visible = true;

                    txtSerie.Focus();
                }
                else
                {
                    DataTable dtEquipo = new DataTable();
                    DataTable dtTarjeta = new DataTable();
                    dtEquipo = oEquipo.BuscarEquipos(2, "", txtSerieEquipo.Text.Trim());
                    if (dtEquipo.Rows.Count > 0)
                    {
                        oEquipo.Id_Equipos_Tipos = 2;//id_equipo_tipo minetti
                        oEquipo.Id = Convert.ToInt32(dtEquipo.Rows[0]["id"]);
                        oEquipo.Id_Equipos_Marcas = 4;//(minetti)
                        oEquipo.Serie = txtSerieEquipo.Text.Trim();
                        oEquipo.Id_Usuarios = Usuarios.CurrentUsuario.Id;
                        oEquipo.Id_Usuarios_servicios = idUsuarioServicioSeleccionado;
                        oEquipo.Id_Equipos_Estados = (int)Equipos.Equipos_Estados.ASIGNADO_A_USUARIO;
                        idEquipo = oEquipo.Id;
                    }
                    else
                    {
                        oEquipo.Id_Equipos_Tipos = 2;//id_equipo_tipo minetti
                        oEquipo.Id_Usuarios = Usuarios.CurrentUsuario.Id;
                        oEquipo.Id_Usuarios_servicios = idUsuarioServicioSeleccionado;
                        oEquipo.Id_Equipos_Estados = (int)Equipos.Equipos_Estados.ASIGNADO_A_USUARIO;
                        oEquipo.Id = 0;
                        oEquipo.Id_Equipos_Marcas = 4;//(minetti)
                        oEquipo.Serie = txtSerieEquipo.Text.Trim();
                        oEquipo.Mac = "0";
                        idEquipo = oEquipo.Guardar(oEquipo);
                    }
                    if (idEquipo > 0)
                    {
                        dtTarjeta = oTarjeta.Listar(txtSerie.Text.Trim());

                        if (dtTarjeta.Rows.Count > 0)
                        {
                            oTarjeta.Id = Convert.ToInt32(dtTarjeta.Rows[0]["id"]);
                            idTarjeta = Convert.ToInt32(dtTarjeta.Rows[0]["id"]);
                            oTarjeta.Id_Equipos_Tipos = 2;
                        }
                        else
                        {
                            oTarjeta.Id = 0;
                            oTarjeta.Id_Equipos_Tipos = 2;
                            oTarjeta.Id_Estado = 3;
                            oTarjeta.Numero = txtSerie.Text.Trim();
                            idTarjeta = oTarjeta.Guardar(oTarjeta);
                        }
                        if (idTarjeta > 0)
                        {
                            if(Viene == 0) 
                            { 
                                if (oEquipo.AsignarEquipoAUsuario(idEquipo, Usuarios.CurrentUsuario.Id, idUsuarioServicioSeleccionado, 3) == 1)
                                {

                                    oTarjeta.AsignarTarjetaEquipo(idEquipo, idTarjeta);
                                    MessageBox.Show("Equipo guardado correctamente", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    lblError.Visible = false;
                                }
                            }
                            else 
                            {
                                if (oEquipo.AsignarEquipoAUsuario(idEquipo, id_Usuario_Viene, idUsuarioServicioSeleccionado, 3) == 1)
                                {

                                    oTarjeta.AsignarTarjetaEquipo(idEquipo, idTarjeta);
                                    MessageBox.Show("Equipo guardado correctamente", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    lblError.Visible = false;
                                }

                            }

                        }
                        else
                            MessageBox.Show("Error al intentar guardar tarjeta.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                        MessageBox.Show("Error al intentar guardar equipo.", "Mensaje del Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);


                }


            }

        }

        #endregion

        private void frmAsignacionMinetti_Load(object sender, EventArgs e)
        {
            comenzarCarga();
        }

        private void ABMProvincias_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
                this.Close();
            if (e.Control && e.KeyCode == Keys.P)
                btnTodos.Visible = true;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            controles(false);
            comenzarCarga();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            controles(true);
            limpiarValores();
            nuevoRegistro();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            guardarRegistro();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgv_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            asignarValores();
        }

        private void imgReturn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void boton1_Click(object sender, EventArgs e)
        {
            //RESULTADO
            //1---->NO SE ENCONTRO USUARIO SERVICIO ALGUNO
            //2---->NO SE ENCONTRO NINGUN SERVICIO MINETTI CONTRATADO
            //3---->NO S ENCONTRO NINGUN EQUIPO ASIGNADO
            //4---->ASIGNADO CORRECTAMENTE
            List<Int32> ListaEquipo = new List<Int32>();
            List<string> ListaTarjeta = new List<string>();
            DataTable dtEquiposMinetti = new DataTable();
            dtEquiposMinetti = oEquipo.ListarTarjetasAux();
            int cod = 0;
            int idUsuarioServicio = 0;
            string numTarjeta;
            int idEquipo, idTarjeta;
            Usuarios oUsuario = new Usuarios();
            DataTable dtInfoUsuario = new DataTable();
            DataTable dtServiciosDelUs = new DataTable();
            Usuarios_Servicios oUsuSer = new Usuarios_Servicios();
            DataTable dtEquiposDelUsuario = new DataTable();
            DataTable dtDatosEquipo = new DataTable();
            DataView dv;
            DataTable dtFiltrada = new DataTable();
            DataTable dtDatosTarjeta = new DataTable();
            int contador = 0;
            int cantEquipoAsignado = 0;
            int cantSinServicios = 0;
            int cantSinServiciosMin = 0;
            int cantSinEquipo = 0;
            int idTarjetaListaMin = 0;
            int idLocaicion = 0;
            foreach (DataRow item in dtEquiposMinetti.Rows)
            {
                cantEquipoAsignado = 0;
                idTarjeta = 0;
                idTarjetaListaMin = Convert.ToInt32(item["id"]);
                cod = Convert.ToInt32(item["cod_usu"]);

                numTarjeta = item["tarjetac"].ToString();
                if (!ListaTarjeta.Contains(numTarjeta))
                {
                    ListaTarjeta.Add(numTarjeta);
                    dtDatosTarjeta = oTarjeta.Listar(numTarjeta);
                    if (dtDatosTarjeta.Rows.Count > 0)
                        idTarjeta = Convert.ToInt32(dtDatosTarjeta.Rows[0]["id"]);
                    else
                    {
                        oTarjeta.Id = 0;
                        oTarjeta.Id_Equipos_Tipos = 2;
                        oTarjeta.Id_Estado = 3;
                        oTarjeta.Numero = numTarjeta;
                        idTarjeta = oTarjeta.Guardar(oTarjeta);
                    }
                    if (idTarjeta > 0)
                    {
                        oUsuario = oUsuario.traerUsuario(0, cod);

                        dtServiciosDelUs = oUsuSer.ListarServiciosYSubServiciosActivos(oUsuario.Id);
                        if (dtServiciosDelUs.Rows.Count > 0)
                        {
                            foreach (DataRow servicio in dtServiciosDelUs.Rows)
                            {
                                dv = dtServiciosDelUs.DefaultView;
                                dv.RowFilter = "id_servicio=6";
                                dtFiltrada = dv.ToTable();
                                if (dtFiltrada.Rows.Count > 0)
                                {
                                    if (Convert.ToInt32(servicio["id_servicio"]) == 6 && (Convert.ToInt32(servicio["id_servicio_sub"]) == 0))
                                    {
                                        idLocaicion = Convert.ToInt32(servicio["id_locacion"]);
                                        idUsuarioServicio = Convert.ToInt32(servicio["id_usuario_Servicio"]);
                                        dtEquiposDelUsuario = oEquipo.ListarEquipoPorUsuariosServicio(idUsuarioServicio);
                                        if (dtEquiposDelUsuario.Rows.Count > 0)
                                        {
                                            foreach (DataRow itemEquipo in dtEquiposDelUsuario.Rows)
                                            {
                                                idEquipo = Convert.ToInt32(itemEquipo["id_equipo"]);
                                                if (!ListaEquipo.Contains(idEquipo) && cantEquipoAsignado == 0)
                                                {
                                                    oTarjeta.AsignarTarjetaEquipo(idEquipo, idTarjeta);
                                                    oEquipo.EditarTarjetas(idTarjetaListaMin, 4);
                                                    ListaEquipo.Add(idEquipo);
                                                    cantEquipoAsignado++;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            oEquipo.Id = 0;
                                            oEquipo.Id_Usuarios = oUsuario.Id;
                                            oEquipo.Id_Usuarios_servicios = idUsuarioServicio;
                                            oEquipo.Id_Equipos_Estados = (int)Equipos.Equipos_Estados.ASIGNADO_A_USUARIO;
                                            oEquipo.Id_Equipos_Tipos = 2;//id_equipo_tipo minetti
                                            oEquipo.Id_Equipos_Modelos = 8;//modelo de un minetti
                                            oEquipo.Id_Equipos_Marcas = 4;//(minetti)
                                            oEquipo.Serie = "8888888888";
                                            oEquipo.Descripcion = "9";
                                            oEquipo.Mac = "0";
                                            idEquipo = oEquipo.Guardar(oEquipo);
                                            oTarjeta.AsignarTarjetaEquipo(idEquipo, idTarjeta);
                                            oEquipo.GuardarUsuarioServicioEquipo(idUsuarioServicio, idEquipo, oUsuario.Id, idLocaicion, DateTime.Now, 9);
                                        }
                                    }

                                }
                                else
                                {
                                    oEquipo.EditarTarjetas(idTarjetaListaMin, 2);
                                }
                            }
                        }
                        else
                        {
                            oEquipo.EditarTarjetas(idTarjetaListaMin, 1);
                        }
                    }
                    contador++;

                }
            }
            lblError.Text = "cantidad sin servicios:" + cantSinServicios.ToString() + "cantidad sin servicios minetti:" + cantSinServiciosMin.ToString() + " cantidad sin equipos: " + cantSinEquipo.ToString();
            lblError.Visible = true;
        }

    }
}
