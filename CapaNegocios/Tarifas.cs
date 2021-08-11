using CapaDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace CapaNegocios
{
    public class Tarifas
    {
        private Conexion Conexion = new Conexion();
        public DataTable GetData(Int32 IdTipoFacturacion, Int32 IdServiciosModalidad)
        {
            DataTable DataTarifa = new DataTable();
            DataTarifa.Columns.Add("Id_Servicios", typeof(Int32));
            DataTarifa.Columns.Add("Id_Servicios_Sub", typeof(Int32));
            DataTarifa.Columns.Add("Descripcion", typeof(String));
            DataTarifa.Columns.Add("Importe", typeof(Decimal));

            try
            {
                Conexion.Conectar();
                Conexion.CrearComando(String.Format("SELECT Descripcion, Id FROM Servicios WHERE Id IN " +
                    "(SELECT Id_Servicios FROM Tipo_Facturacion_Servicios WHERE Id_Tipo_Facturacion = {0}) " +
                    "AND Id_Servicios_Modalidad = {1}", IdTipoFacturacion, IdServiciosModalidad));

                DataTable DataServicios = Conexion.Tabla();

                foreach (DataRow DrItemServicio in DataServicios.Rows) 
                {
                    DataRow DrTarifa = DataTarifa.NewRow();
                    DrTarifa["Id_Servicios"] = DrItemServicio["Id"];
                    DrTarifa["Id_Servicios_Sub"] = 0;
                    DrTarifa["Descripcion"] = DrItemServicio["Descripcion"];
                    DrTarifa["Importe"] = 0;

                    DataTarifa.Rows.Add(DrTarifa);

                    Conexion.CrearComando(String.Format("SELECT Descripcion, Id_Servicios, Id, Requiere_IP FROM Servicios_Sub " +
                        "WHERE Id IN (SELECT Id_Servicios_Sub FROM Tipo_Facturacion_Servicios " +
                        "WHERE Id_Tipo_Facturacion = {0} AND Id_Servicios = {1})", IdTipoFacturacion, DrItemServicio["Id"]));

                    DataTable DataServiciosSub = Conexion.Tabla();

                    foreach (DataRow DrItemServicioSub in DataServiciosSub.Rows)
                    {
                        if (DrItemServicioSub["Requiere_IP"].ToString() == "1")
                        {
                            Tablas Tablas = new Tablas();

                            foreach (DataRow DrVelocidadTipo in Tablas.DataServicios_Velocidades_Tipos.Rows)
                            {
                                foreach (DataRow DrVelocidad in Tablas.DataServicios_Velocidades.Rows)
                                {
                                    DrTarifa = DataTarifa.NewRow();
                                    DrTarifa["Id_Servicios"] = DrItemServicioSub["Id_Servicios"];
                                    DrTarifa["Id_Servicios_Sub"] = DrItemServicioSub["Id"];
                                    DrTarifa["Descripcion"] = String.Format("{0} {1} MB", DrVelocidadTipo["Nombre"], DrVelocidad["Velocidad"]);
                                    DrTarifa["Importe"] = 0;

                                    DataTarifa.Rows.Add(DrTarifa);
                                }
                            }
                        }
                        else
                        {
                            DrTarifa = DataTarifa.NewRow();
                            DrTarifa["Id_Servicios"] = DrItemServicioSub["Id_Servicios"];
                            DrTarifa["Id_Servicios_Sub"] = DrItemServicioSub["Id"];
                            DrTarifa["Descripcion"] = DrItemServicioSub["Descripcion"];
                            DrTarifa["Importe"] = 0;

                            DataTarifa.Rows.Add(DrTarifa);
                        }
                    }
                }

                DataTarifa.AcceptChanges();

                Conexion.DesConectar();
            }
            catch { }



            return DataTarifa;
        }
    }
}
