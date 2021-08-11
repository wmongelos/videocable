using CapaDatos;
using System;
using System.Data;

namespace CapaNegocios
{
    public class Articulos_Mov_Det
    {
        public Int32 Id;
        public Int32 Id_Articulos_Mov;
        public Int32 Id_Articulos;
        public Int32 Cantidad;
        public Double Importe_Unitario;
        public String Tipo;

        private Conexion oCon = new Conexion();

        public enum TipoDestino { AREAS = 1, PERSONAL = 2, MOVIL = 3 };

        public enum TipoMuestra { AGRUPADO = 1, DETALLADO = 2 };

        public void Guardar(Articulos_Mov_Det oAMD)
        {
            try
            {
                oCon.Conectar();

                oCon.CrearComando(" INSERT INTO Articulos_Mov_Det(Id_Articulos_Mov, Id_Tipo,Tipo , Cantidad, Importe_Unitario) " +
                    "VALUES (@idArticulosMov, @idTipo, @Tipo , @cantidad, @importeUnitario) ");

                oCon.AsignarParametroEntero("@idArticulosMov", oAMD.Id_Articulos_Mov);
                oCon.AsignarParametroEntero("@idTipo", oAMD.Id_Articulos);
                oCon.AsignarParametroCadena("@Tipo", oAMD.Tipo);
                oCon.AsignarParametroEntero("@cantidad", oAMD.Cantidad);
                oCon.AsignarParametroDouble("@importeUnitario", oAMD.Importe_Unitario);

                oCon.ComenzarTransaccion();
                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();
                throw;
            }
        }

        public DataTable ListarArticulosDesdeHasta(int mostrar, DateTime desde, DateTime hasta, int TipoDestino, int Destino)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();

                string agrupacion = string.Empty;
                string cantidad = string.Empty;
                if (mostrar == Convert.ToInt32(TipoMuestra.AGRUPADO))
                {
                    cantidad = " SUM(articulos_mov_det.cantidad) as cantidad ";
                    agrupacion = " GROUP BY id_tipo";
                }
                else if (mostrar == Convert.ToInt32(TipoMuestra.DETALLADO))
                {
                    cantidad = " articulos_mov_det.cantidad ";
                    agrupacion = " order by fecha";
                }

                string consulta = "SELECT articulos_mov.id as id_art_mov, articulos_mov_det.id as id_art_mov_det,  if(articulos_mov_det.tipo = 'E', 'Equipo', if(articulos_mov_det.tipo = 'A', 'Articulo','Sin definir')) as tipo, " +
                    "articulos_mov.id_destinatario ,articulos_mov.destinatario,personal.nombre as entrega,articulos_mov_det.id_tipo, " +
                    "" + cantidad + ",articulos_mov.fecha, " +
                    "CASE articulos_mov_det.Tipo " +
                    "WHEN 'E' THEN(SELECT concat(equipos_tipos.Nombre, ' - Serie: ', equipos.Serie, '- Mac: ', equipos.Mac) FROM equipos LEFT JOIN equipos_tipos ON equipos_tipos.Id = equipos.Id_Equipos_Tipos WHERE equipos.Id = articulos_mov_det.Id_tipo) " +
                    "WHEN 'A' THEN(SELECT Descripcion FROM Articulos WHERE Articulos.Id = articulos_mov_det.Id_tipo) " +
                    "END AS Producto " +
                    "from articulos_mov_det " +
                    "left join articulos_mov ON articulos_mov_det.id_articulos_mov = articulos_mov.id " +
                    "left join personal ON articulos_mov.id_personal = personal.id";

                string condicion = " WHERE articulos_mov.fecha between @desde and @hasta";

                if (TipoDestino == Convert.ToInt32(Articulos_Mov_Det.TipoDestino.AREAS))
                {
                    condicion = string.Format("{0} and articulos_mov.destinatario = 'A' ", condicion);
                }
                else if (TipoDestino == Convert.ToInt32(Articulos_Mov_Det.TipoDestino.PERSONAL))
                {
                    condicion = string.Format("{0} and articulos_mov.destinatario = 'P' ", condicion);
                }
                else if (TipoDestino == Convert.ToInt32(Articulos_Mov_Det.TipoDestino.MOVIL))
                {
                    condicion = string.Format("{0} and articulos_mov.destinatario = 'M' ", condicion);
                }

                if (Destino > 0)
                {
                    condicion = string.Format(" {0} and articulos_mov.id_destinatario = {1} ", condicion, Destino);
                }

                consulta = string.Format("{0} {1} {2}", consulta, condicion, agrupacion);

                oCon.CrearComando(consulta);

                oCon.AsignarParametroFecha("@desde", desde);
                oCon.AsignarParametroFecha("@hasta", hasta);

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

        public DataTable ListarPorIdArticuloMov(int idArtMov)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();

                string consulta = string.Format("SELECT articulos_mov_det.id, id_articulos_mov , id_tipo, cantidad, "
                        + " importe_unitario, articulos.descripcion as articulo"
                        + " FROM articulos_mov_det"
                        + " LEFT JOIN articulos ON articulos.id = articulos_mov_det.id_tipo"
                        + " where id_articulos_mov = {0}", idArtMov);

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

    }
}
