using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using CapaDatos;


namespace CapaNegocios
{
    public class Contrato
    {
        public Int32 Id { get; set;}
        public String Nombre { get; set;}
        public Int32 Borrado { get; set;}

        private Conexion oCon = new Conexion();
        public DataTable Listar(int id=0)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                if(id>0)
                {
                    oCon.CrearComando("SELECT id,nombre,borrado FROM contratos WHERE id = @id_con");
                    oCon.AsignarParametroEntero("@id_con", id);
                }else
                    oCon.CrearComando("SELECT id,nombre,borrado FROM contratos WHERE borrado=0");

                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception c)
            {
                oCon.DesConectar();
            }
            return dt;
        }
        public DataTable ListarPorRelacion(int idServicio,int idTipoFac)
        {
            DataTable dt = new DataTable();
            try
            {
                string condicion = "";
                string consulta = "SELECT servicios_contratos.id_servicio,contratos.nombre as nombre_contrato,servicios_contratos.id_tipo_facturacion,servicios_categorias.nombre as categoria,zonas.nombre as zona,contratos.nombre_archivo " +
                    "FROM servicios_contratos " +
                    " LEFT JOIN contratos on contratos.id = servicios_contratos.id_contrato" +
                    " LEFT JOIN servicios on servicios.id = servicios_contratos.id_servicio" +
                    " LEFT JOIN servicios_categorias on servicios_categorias.id = servicios_contratos.id_tipo_facturacion" +
                    " LEFT JOIN zonas on zonas.id = servicios_contratos.id_tipo_facturacion" +
                    " where servicios_contratos.borrado=0 and contratos.borrado=0 ";

                if (idServicio > 0)
                    condicion = string.Format("and servicios_contratos.id_servicio={0}", idServicio);
                else
                    condicion = " and servicios_contratos.id_servicio>=0 ";

                if (idTipoFac > 0)
                    condicion = condicion + string.Format(" and servicios_contratos.id_tipo_facturacion={0}", idTipoFac);
                else
                    condicion = condicion + " and servicios_contratos.id_tipo_facturacion>=0";

                consulta = consulta + condicion;


                oCon.Conectar();
                oCon.CrearComando(consulta);
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }
            return dt;

        }
        public bool GuardarRelacion(int idContrato, int idServicio,int idTipoFac)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("INSERT INTO servicios_contratos (id_contrato,id_servicio,id_tipo_facturacion) VALUES (@id_contrato,@id_servicio,@id_tipo_fac)");
                oCon.AsignarParametroEntero("@id_contrato",idContrato);
                oCon.AsignarParametroEntero("@id_servicio", idServicio);
                oCon.AsignarParametroEntero("@id_tipo_fac", idTipoFac);
                oCon.ComenzarTransaccion();
                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
                return true;
            }
            catch (Exception c)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                return false;
                throw;
            }
        }
        public bool EliminarRelacion(int IdRelacion)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("UPDATE servicios_contratos SET borrado = 1 WHERE id = @idRelacion");
                oCon.AsignarParametroEntero("@idRelacion", IdRelacion);
                oCon.ComenzarTransaccion();
                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
                return true;
            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                return false;
                
            }
        }
    }
}
