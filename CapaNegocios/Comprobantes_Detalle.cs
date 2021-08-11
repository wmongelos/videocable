using CapaDatos;
using System;


namespace CapaNegocios
{
    public class Comprobantes_Detalle
    {
        public Int32 Id { get; set; }
        public Int32 Id_Comprobantes { get; set; }
        public String Descripcion { get; set; }
        public Decimal Cantidad { get; set; }
        public Decimal Unitario { get; set; }
        public Decimal Iva { get; set; }
        public Decimal Punitorios { get; set; }
        public Decimal Bonificaciones { get; set; }
        public Decimal Total { get; set; }
        public DateTime Desde { get; set; }
        public DateTime Hasta { get; set; }
        public String Codigo { get; set; }
        public String Unidad { get; set; }
        public String Descripcion_Adicional { get; set; }
        public Int32 Id_Iva_Alicuotas { get; set; }

        private Conexion oCon = new Conexion();

        public Int32 Guardar(Comprobantes_Detalle oComp)
        {
            //try
            //{
            oCon.Conectar();
            oCon.CrearComando("INSERT INTO comprobantes_Detalle(Id_Comprobantes, Descripcion,Cantidad, Unitario, Iva, Punitorios,Bonificaciones,Total,Desde,Hasta,Codigo,Unidad,Descripcion_Adicional,Id_Iva_Alicuotas) " +
                "VALUES(@Id_Comprobantes1, @Descripcion1,@Cantidad1, @Unitario1, @Iva1, @Punitorios1,@Bonificaciones1,@Total1,@Desde1,@Hasta1,@Codigo1,@Unidad1,@Descripcion_Adicional1,@Id_Iva_Alicuotas1); ");

            oCon.AsignarParametroEntero("@Id_Comprobantes1", oComp.Id_Comprobantes);
            oCon.AsignarParametroCadena("@Descripcion1", oComp.Descripcion);
            oCon.AsignarParametroDecimal("@Cantidad1", oComp.Cantidad);
            oCon.AsignarParametroDecimal("@Unitario1", oComp.Unitario);
            oCon.AsignarParametroDecimal("@Iva1", oComp.Iva);
            oCon.AsignarParametroDecimal("@Punitorios1", oComp.Punitorios);
            oCon.AsignarParametroDecimal("@Bonificaciones1", oComp.Bonificaciones);
            oCon.AsignarParametroDecimal("@Total1", oComp.Total);
            oCon.AsignarParametroFecha("@Desde1", oComp.Desde);
            oCon.AsignarParametroFecha("@Hasta1", oComp.Hasta);
            oCon.AsignarParametroCadena("@Codigo1", oComp.Codigo);
            oCon.AsignarParametroCadena("@Unidad1", oComp.Unidad);
            oCon.AsignarParametroCadena("@Descripcion_Adicional1", oComp.Descripcion_Adicional);
            oCon.AsignarParametroEntero("@Id_Iva_Alicuotas1", oComp.Id_Iva_Alicuotas);
            oCon.EjecutarComando();
            oCon.DesConectar();
            //}
            //catch (Exception)
            //{
            //    oCon.CancelarTransaccion();
            //    oCon.DesConectar();
            //    throw;
            //}

            return oComp.Id;
        }

    }
}
