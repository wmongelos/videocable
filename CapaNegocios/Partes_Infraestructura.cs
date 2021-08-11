using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaNegocios
{
    public class Partes_Infraestructura
    {
        public int Id_Parte { get; set; }
        public int Id_Localidad { get; set; }
        public int Id_Calle { get; set; }
        public int Altura { get; set; }
        public string Piso { get; set; }
        public string Depto { get; set; }
        public string Entre_Calle_1 { get; set; }
        public string Entre_Calle_2 { get; set; }
        public string Detalle { get; set; }
        public int Id_Grupo_Servicio { get; set; }
        public int Id_Tipo_Servicio { get; set; }

        private Conexion oCon = new Conexion();

        public void Guardar(Partes_Infraestructura oParteInfra)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("INSERT INTO partes_infraestructura(Id_Parte, Id_Localidad, Id_Calle, Altura, Piso, Depto, Entre_Calle_1, Entre_Calle_2, Detalle, Id_Grupo_Servicio, Id_Tipo_Servicio) " +
                    "VALUES(@idParte, @idLocalidad, @idCalle, @Altura, @Piso, @Depto, @EntreCalle1, @EntreCalle2, @Detalle, @idGrupoServicio, @idTipoServicio)");
                oCon.AsignarParametroEntero("@idParte", oParteInfra.Id_Parte);
                oCon.AsignarParametroEntero("@idLocalidad", oParteInfra.Id_Localidad);
                oCon.AsignarParametroEntero("@idCalle", oParteInfra.Id_Calle);
                oCon.AsignarParametroEntero("@Altura", oParteInfra.Altura);
                oCon.AsignarParametroCadena("@Piso", oParteInfra.Piso);
                oCon.AsignarParametroCadena("@Depto", oParteInfra.Depto);
                oCon.AsignarParametroCadena("@EntreCalle1", oParteInfra.Entre_Calle_1);
                oCon.AsignarParametroCadena("@EntreCalle2", oParteInfra.Entre_Calle_2);
                oCon.AsignarParametroCadena("@Detalle", oParteInfra.Detalle);
                oCon.AsignarParametroEntero("@idGrupoServicio", oParteInfra.Id_Grupo_Servicio);
                oCon.AsignarParametroEntero("@idTipoServicio", oParteInfra.Id_Tipo_Servicio);
                oCon.ComenzarTransaccion();
                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
            }
            catch (Exception ex)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                throw ex;
            }
        }
    }
}
