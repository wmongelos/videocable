using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CapaDatos;
using System.Data;


namespace CapaNegocios
{
    public class Climpuestos
    {
        public String Cae;
        public Int32 Id_Comprobante;
        public Int32 Id_Iva_Ventas;
        public Double Numero;

        private Configuracion oConfig = new Configuracion();
        private Conexion oCon = new Conexion();

        public enum Campo_Busqueda
        {
            id = 1,
            id_Comprobante = 2 ,
            Numero = 3,
            cae = 4,
            id_usuario = 5


        }
        public DataTable ListarIvaVentas(Int32 Campo_De_Busqueda)
        {
            String Consulta="";
            String Filtro="";
            String Orden="";

            oCon.Conectar();
            Consulta = String.Format("select iva_ventas.*,puntos_venta.* ,usuarios.codigo, " +
                "concat(usuarios.apellido, ' , ', usuarios.nombre) AS Usuario, usuarios.Nombre as Nombre, usuarios.Apellido as Apellido, usuarios_locaciones.Calle, usuarios_locaciones.Altura, " +
                "localidades.Nombre AS Localidad, provincias.Nombre AS Provincia, localidades.Codigo_Postal AS Codigo_Postal, " +
                "usuarios.Numero_Documento, usuarios.Id_Comprobantes_Iva, usuarios_locaciones.Id AS Id_Locacion " +
                "from iva_ventas " +
                "left join puntos_venta on puntos_venta.numero = iva_ventas.punto_venta " +
                "left join usuarios on usuarios.id = iva_ventas.id_usuario " +
                "LEFT JOIN usuarios_locaciones ON usuarios_locaciones.Id_Usuarios = usuarios.id " +
                "LEFT JOIN localidades ON usuarios_locaciones.Id_Localidades = localidades.id " +
                "LEFT JOIN provincias ON usuarios_locaciones.Id_Provincias = provincias.id");

            switch (Campo_De_Busqueda)
            { 
                case (int)Campo_Busqueda.id:
                    break;
                case (int)Campo_Busqueda.id_Comprobante:
                    break;
                case (int)Campo_Busqueda.Numero:
                    break;
                case (int)Campo_Busqueda.cae:
                    Filtro = " where iva_ventas.cae='"+Cae+ "' and iva_ventas.borrado=0";
                    break;
                case (int)Campo_Busqueda.id_usuario:
                    break;
                default:
                    Filtro = "";
                    break;
             }
 

            oCon.CrearComando(Consulta+Filtro);
            DataTable dt = oCon.Tabla();

            oCon.DesConectar();

            return dt;


        }

        public DataTable ListarIvaVentasConEstadoPendiente()
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                string comando = "select if(estado = 1, CONVERT(usuarios.codigo, char(11)), '-') as codigo, if(estado = 1, CONCAT(usuarios.apellido, ', ', usuarios.nombre), '-') as usuario, iva_ventas.id as id_iva_ventas, iva_ventas.id_comprobantes, iva_ventas.id_usuario, iva_ventas.id_usuarios_locacion,"
                              + " iva_Ventas.id_usuarios_locacion_ficscal, iva_ventas.fecha, iva_ventas.punto_venta, iva_ventas.numero, iva_ventas.letra, iva_ventas.numero_documento,"
                              + " if(estado = 1, iva_ventas.razon_social, '-') as razon_social, if(estado = 1, iva_ventas.fantasia, '-') as fantasia, "
                              + " if(estado = 1, iva_ventas.localidad, '-') as localidad, if(estado = 1, iva_ventas.calle, '-') as calle, if(estado = 1, iva_ventas.altura, '-') as altura, iva_ventas.cae,"
                              + " iva_ventas.vencimiento, iva_ventas.id_comprobantes_iva, iva_ventas.id_comprobantes_tipo, iva_Ventas.importe_neto, iva_ventas.importe_iva,"
                              + " iva_ventas.importe_impuesto_provincial, iva_ventas.importe_final, comprobantes.descripcion as comprobante_descripcion, iva_Ventas.estado"
                              + " from iva_ventas"
                              + " left join usuarios on usuarios.id = iva_ventas.id_usuario"
                              + " left join comprobantes on comprobantes.id = iva_ventas.id_comprobantes"
                              + " where estado != 0";
                oCon.CrearComando(comando);
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
            }
            return dt;
        }

    }
}
