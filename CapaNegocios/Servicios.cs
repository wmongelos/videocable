using CapaDatos;
using System;
using System.Data;

namespace CapaNegocios
{
    public class Servicios
    {
        public enum _Requiere_equipo { SI, NO };
        public enum _Requiere_velocidad { SI, NO };
        public enum _Modalidad { DIA = 1, MENSUAL = 2, PERIODO = 3, UNICO = 4, PERIODO_CERRADO_POR_MES = 5, PERIODO_CERRADO_POR_DIA = 6 };
        public enum _Requiere_tarjeta { SI, NO };

        public Int32 Id { get; set; }
        public String Descripcion { get; set; }
        public _Requiere_equipo Requiere_Equipo { get; set; }
        public _Requiere_velocidad Requiere_Velocidad { get; set; }
        public _Requiere_tarjeta Requiere_Tarjeta { get; set; }
        public _Modalidad Modalidad { get; set; }
        public Int32 Id_Servicios_Tipos { get; set; }
        public Int32 Id_Servicios_Modalidad { get; set; }
        public Int32 TipodeCorte { get; set; }
        public Int32 CorteAutomatico { get; set; }
        public Int32 Dias_Bonificacion { get; set; }
        public Int32 Requiere_Servicio_Padre { get; set; }
        public Int32 Fecha_Inicio_Servicio { get; set; }
        public Int32 Forzar_Inicio_Mes { get; set; }
        public Int32 Aplicaciones_Externas { get; set; }
        public Int32 Id_Aplicaciones_Externas { get; set; }
        public Int32 Borrado { get; set; }
        public enum _Factura_mensualmente { NO, SI };
        public _Factura_mensualmente Factura_Mensualmente { get; set; }
        public Int32 Id_Contrato { get; set; }
        public Int32 Cuenta { get; set; }
        public Int32 GeneraDeudaCortado { get; set; }
        public Int32 GeneraDeudaRetirado { get; set; }
        public Int32 Origen_meses { get; set; }
        public Int32 Id_parte_corte { set; get; }

        public Int32 Habilita_Debito { get; set; }

        private Conexion oCon = new Conexion();

        public enum Servicios_Estados
        {
            SIN_CONECTAR = 1,
            CONECTADO = 2,
            EN_ESPERA = 3,
            CORTADO = 4,
            RETIRADO = 5,
            CON_FACTIBILIDAD = 6,
            FACTIBILIDAD_POSITIVA = 7,
            FACTIBILIDAD_NEGATIVA = 8
        }

        public enum TipoCorte
        {
            FALTA_PAGO = 0,
            FIN_DE_CONTRATO = 1
        }

        public enum _CorteAutomatico
        {
            NO = 0,
            SI = 1
        }


        public enum Origen_Meses
        {
            FIJO = 1,
            PERSONALIZADO = 2
        }


        public void Guardar(Servicios oServicio, int id_personal)
        {
            try
            {
                oCon.Conectar();

                if (oServicio.Id > 0)
                {
                    oCon.CrearComando("UPDATE servicios set Descripcion = @descrip, Requiere_Equipo = @requiere, Requiere_Velocidad = @velocidad, Requiere_Tarjeta = @tarjeta, Id_Servicios_Tipos = @tipo, Id_Servicios_Modalidad = @modalidad, Dias_Bonificacion = @boni, TipoCorte=@TipoCorte, CorteAutomatico=@CorteAutomatico,  Fecha_Inicio_Servicio = @fechainiser, Forzar_Inicio_Mes = @iniciomes, Requiere_Servicio_Padre = @servpadre, Factura_Mensualmente=@facturacionmensual, Aplicacion_Externa = @externas, Id_Aplicaciones_Externas = @externasid, id_contrato = @contrato, cuenta = @cuenta,genera_deuda_cortado=@deuda_cortado,genera_deuda_retirado=@deuda_retirado,Id_Personal=@personal,OrigenMeses=@oriMes,id_parte_corte=@parteCorte,habilita_debito=@debito WHERE Id = @id");
                    oCon.AsignarParametroEntero("@id", oServicio.Id);
                }
                else
                {
                    oCon.CrearComando("INSERT INTO servicios(Descripcion, Requiere_Equipo, Requiere_Velocidad, Requiere_Tarjeta, Id_Servicios_Tipos, Id_Servicios_Modalidad, Dias_Bonificacion, TipoCorte, CorteAutomatico, Fecha_Inicio_Servicio, Forzar_Inicio_Mes, Requiere_Servicio_Padre, Factura_Mensualmente, Aplicacion_Externa, Id_Aplicaciones_Externas, Id_Contrato, Cuenta,genera_deuda_cortado,genera_deuda_retirado,Id_Personal, OrigenMeses,id_parte_corte,habilita_debito)VALUES(@descrip, @requiere, @velocidad, @tarjeta, @tipo, @modalidad, @boni, @TipoCorte, @CorteAutomatico, @fechainiser, @iniciomes, @servpadre, @facturacionmensual, @externas, @externasid, @contrato, @cuenta,@deuda_cortado,@deuda_retirado,@personal,@oriMes,@parteCorte,@debito); SELECT @@IDENTITY");
                }

                oCon.AsignarParametroCadena("@descrip", oServicio.Descripcion);
                oCon.AsignarParametroCadena("@requiere", oServicio.Requiere_Equipo.ToString());
                oCon.AsignarParametroCadena("@velocidad", oServicio.Requiere_Velocidad.ToString());
                oCon.AsignarParametroCadena("@tarjeta", oServicio.Requiere_Tarjeta.ToString());
                oCon.AsignarParametroEntero("@tipo", oServicio.Id_Servicios_Tipos);
                oCon.AsignarParametroEntero("@modalidad", oServicio.Id_Servicios_Modalidad);
                oCon.AsignarParametroEntero("@servpadre", oServicio.Requiere_Servicio_Padre);
                oCon.AsignarParametroEntero("@boni", oServicio.Dias_Bonificacion);
                oCon.AsignarParametroEntero("@TipoCorte", oServicio.TipodeCorte);
                oCon.AsignarParametroEntero("@CorteAutomatico", oServicio.CorteAutomatico);
                oCon.AsignarParametroEntero("@fechainiser", oServicio.Fecha_Inicio_Servicio);
                oCon.AsignarParametroEntero("@iniciomes", oServicio.Forzar_Inicio_Mes);
                oCon.AsignarParametroEntero("@externas", oServicio.Aplicaciones_Externas);
                oCon.AsignarParametroEntero("@externasid", oServicio.Id_Aplicaciones_Externas);
                oCon.AsignarParametroCadena("@facturacionmensual", oServicio.Factura_Mensualmente.ToString());
                oCon.AsignarParametroEntero("@contrato", oServicio.Id_Contrato);
                oCon.AsignarParametroEntero("@cuenta", oServicio.Cuenta);
                oCon.AsignarParametroEntero("@deuda_cortado", oServicio.GeneraDeudaCortado);
                oCon.AsignarParametroEntero("@deuda_retirado", oServicio.GeneraDeudaRetirado);
                oCon.AsignarParametroEntero("@personal", id_personal);
                oCon.AsignarParametroEntero("@oriMes", oServicio.Origen_meses);
                oCon.AsignarParametroEntero("@parteCorte", oServicio.Id_parte_corte);
                oCon.AsignarParametroEntero("@debito", oServicio.Habilita_Debito);

                oCon.ComenzarTransaccion();

                if (oServicio.Id > 0)
                    oCon.EjecutarComando();
                else
                    oServicio.Id = oCon.EjecutarScalar();

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

        public void Eliminar(int id)
        {
            try
            {
                oCon.Conectar();
                oCon.ComenzarTransaccion();
                oCon.CrearComando("UPDATE servicios SET Borrado = 1,id_personal=@personal WHERE Id = @id");
                oCon.AsignarParametroEntero("@personal", Personal.Id_Login);
                oCon.AsignarParametroEntero("@id", id);
                oCon.EjecutarComando();
                oCon.ConfirmarTransaccion();
                oCon.CrearComando("UPDATE servicios_sub SET borrado=1,id_personal=@personal where id_servicios=@id");
                oCon.AsignarParametroEntero("@personal", Personal.Id_Login);
                oCon.AsignarParametroEntero("@id", id);
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


        public int VerificarEliminar(int idServicio, out int Usuarios_Totales)
        {
            int Total = 0;
            int retorno = 0;
            DataTable dt;
            try
            {
                oCon.Conectar();
                oCon.CrearComando("select * from usuarios_Servicios where id_Servicios=@idservicios and (id_servicios_estados=1 or id_servicios_estados=2 or id_servicios_estados=3);");
                oCon.AsignarParametroEntero("@idservicios", idServicio);
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }
            if (dt.Rows.Count > 0)
                retorno = 1;
            else
                retorno = 0;

            foreach (DataRow dr in dt.Rows)
            {
                Total = Total + 1;
            }
            Usuarios_Totales = Total;
            return retorno;
        }

        public int Verificacion_Servicio_Tarifa_Sub(int idServicio, int id_Tarifa)
        {
            int retorno = 0;
            DataTable dt;
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT * " +
                    "FROM servicios_tarifas_sub " +
                    "WHERE id_servicios = @idservicios AND id_servicios_tarifas = @id_tarifa; ");
                oCon.AsignarParametroEntero("@idservicios", idServicio);
                oCon.AsignarParametroEntero("@id_tarifa", id_Tarifa);
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }
            if (dt.Rows.Count > 0)
                retorno = 1;
            else
                retorno = 0;

            return retorno;
        }
        public int Verificacion_Servicio_Tarifa_Sub_Esp(int idServicio, int id_Tarifa)
        {
            int retorno = 0;
            DataTable dt;
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT * " +
                    "FROM servicios_tarifas_sub_esp " +
                    "WHERE Id_Servicios_Tarifas = @id_tarifa AND id_servicios = @idservicios");
                oCon.AsignarParametroEntero("@idservicios", idServicio);
                oCon.AsignarParametroEntero("@id_tarifa", id_Tarifa);
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }
            if (dt.Rows.Count > 0)
                retorno = 1;
            else
                retorno = 0;

            return retorno;
        }

        public int Verificacion_Categoria(int idServicio)
        {
            int retorno = 0;
            DataTable dt;
            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT * " +
                    "FROM tipo_facturacion_servicios " +
                    "LEFT JOIN servicios_categorias ON servicios_categorias.id = tipo_facturacion_servicios.Id_Tipo_Facturacion " +
                    "WHERE id_servicios = @idservicios " +
                    "GROUP BY servicios_categorias.id; ");
                oCon.AsignarParametroEntero("@idservicios", idServicio);
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }
            if (dt.Rows.Count > 0)
                retorno = 1;
            else
                retorno = 0;

            return retorno;
        }

        public void EliminarCategoria(int id_servicio)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("DELETE FROM tipo_facturacion_servicios WHERE id_servicios=@idserv");
                oCon.AsignarParametroEntero("@idserv", id_servicio);
                oCon.EjecutarComando();
                oCon.ComenzarTransaccion();
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

        public void EliminarUsuarioServicio(int id_servicio)
        {
            try
            {
                oCon.Conectar();
                oCon.CrearComando("UPDATE usuarios_servicios SET borrado=1 WHERE id_servicios=@idserv");
                oCon.AsignarParametroEntero("@idserv", id_servicio);
                oCon.EjecutarComando();
                oCon.ComenzarTransaccion();
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

        public void EliminarTarifas(int id_servicio, int TarifaSub, int TarifaSubEsp)
        {
            try
            {
                oCon.Conectar();
                if (TarifaSub == 1 && TarifaSubEsp == 1)
                {
                    oCon.CrearComando("DELETE FROM servicios_tarifas_sub WHERE id_servicios=@idserv");
                    oCon.AsignarParametroEntero("@idserv", id_servicio);
                    oCon.EjecutarComando();
                    oCon.ComenzarTransaccion();
                    oCon.ConfirmarTransaccion();

                    oCon.CrearComando("DELETE FROM servicios_tarifas_sub_esp WHERE id_servicios=@idserv");
                    oCon.AsignarParametroEntero("@idserv", id_servicio);
                    oCon.EjecutarComando();
                    oCon.ComenzarTransaccion();
                    oCon.ConfirmarTransaccion();
                }
                else
                {
                    if (TarifaSub == 1)
                        oCon.CrearComando("DELETE FROM servicios_tarifas_sub WHERE id_servicios=@idserv");
                    if (TarifaSubEsp == 1)
                        oCon.CrearComando("DELETE FROM servicios_tarifas_sub_esp WHERE id_servicios=@idserv");
                    oCon.AsignarParametroEntero("@idserv", id_servicio);
                    oCon.EjecutarComando();
                    oCon.ComenzarTransaccion();
                    oCon.ConfirmarTransaccion();
                    oCon.DesConectar();
                }
            }
            catch (Exception)
            {
                oCon.CancelarTransaccion();
                oCon.DesConectar();

                throw;
            }

        }

        public DataTable getOrigenMeses()
        {
            DataTable dtOrigen = new DataTable();
            dtOrigen.Columns.Add("Id", typeof(Int32));
            dtOrigen.Columns.Add("Origen", typeof(String));

            foreach (Origen_Meses origen in Enum.GetValues(typeof(Origen_Meses)))
            {
                int id = (int)origen;
                string valor = origen.ToString();
                dtOrigen.Rows.Add(id, valor);
            }

            dtOrigen.AcceptChanges();

            return dtOrigen;
        }

        public DataTable ListarPorModalidad(_Modalidad oMod)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT Servicios.Id, servicios.Descripcion, T.Nombre AS Tipo, M.Nombre as Modalidad, Requiere_Equipo,  Requiere_Tarjeta, " +
                    "Servicios.Id_Servicios_Tipos, Id_Servicios_Modalidad, T.Id_Servicios_Grupos FROM Servicios " +
                    "LEFT JOIN Servicios_Tipos AS T ON T.Id = Servicios.Id_Servicios_Tipos " +
                    "LEFT JOIN Servicios_Modalidad AS M ON M.Id = Servicios.Id_Servicios_Modalidad " +
                    "WHERE Servicios.Borrado = 0 AND Id_Servicios_Modalidad = @modalidad ORDER BY Id");

                oCon.AsignarParametroEntero("@modalidad", Convert.ToInt32(oMod));

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

        public DataTable ListarServiciosAplicacionesExternas(int id_app_ext)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT * FROM SERVICIOS where borrado =0 and id_aplicaciones_externas = @id_app_ext");

                oCon.AsignarParametroEntero("@id_app_ext", id_app_ext);

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


        public DataTable Listar(bool conTodos = false)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                if (conTodos)
                    oCon.CrearComando("SELECT 0 as id , UPPER('TODOS') as nombre union all SELECT servicios.id, servicios.Descripcion FROM servicios WHERE servicios.borrado = 0 ORDER BY id");
                else
                {
                    oCon.CrearComando("SELECT Servicios.Id, Servicios.Codigo, T.Nombre AS Tipo, servicios.Descripcion , M.Nombre as Modalidad, Requiere_Equipo, Requiere_Velocidad, Requiere_Tarjeta, Dias_Bonificacion," +
                    "Servicios.Id_Servicios_Tipos, Id_Servicios_Modalidad, T.Id_Servicios_Grupos, (SELECT COUNT(*) FROM servicios_condiciones WHERE Id_Servicio = Servicios.Id and servicios_condiciones.borrado=0) AS Condicion, " +
                    "Servicios.TipoCorte, Servicios.CorteAutomatico, Servicios.Fecha_Inicio_Servicio, Servicios.Forzar_Inicio_Mes, Servicios.Requiere_Servicio_Padre, Servicios.Factura_Mensualmente, Servicios.Aplicacion_Externa, Servicios.Id_Aplicaciones_Externas, Servicios.Id_Contrato, Servicios.Cuenta, Servicios.genera_deuda_cortado, Servicios.genera_deuda_retirado, servicios.OrigenMeses, servicios.id_parte_corte,servicios.habilita_debito FROM Servicios " +
                    "LEFT JOIN Servicios_Tipos AS T ON T.Id = Servicios.Id_Servicios_Tipos " +
                    "LEFT JOIN Servicios_Modalidad AS M ON M.Id = Servicios.Id_Servicios_Modalidad " +
                    "WHERE Servicios.Borrado = 0 ORDER BY Tipo, Descripcion");
                }

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

        public DataTable ListarPorTipoFacturacion(int id)
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT Id_Servicios, servicios.descripcion, T.Nombre AS Tipo,M.Nombre as Modalidad, Requiere_Equipo, " +
                    "Requiere_Velocidad, Requiere_Tarjeta, Servicios_Grupos.Id as Id_Servicios_Grupos, Id_Servicios_Tipos, Id_Servicios_Modalidad, T.Id_Servicios_Grupos, Id_Tipo_Facturacion, " +
                    "(SELECT Nombre from Servicios_Grupos WHERE Id = (Select Id_Servicios_Grupos FROM Servicios_Tipos WHERE Id = Id_Servicios_Tipos)) AS Grupo, Dias_Bonificacion, servicios.Fecha_Inicio_Servicio, servicios.Requiere_Servicio_Padre,servicios.origenmeses " +
                    "from tipo_facturacion_servicios " +
                    "LEFT JOIN Servicios on Servicios.Id = tipo_facturacion_servicios.Id_Servicios " +
                    "LEFT JOIN Servicios_Tipos AS T ON T.Id = Servicios.Id_Servicios_Tipos " +
                    "LEFT JOIN Servicios_Modalidad AS M ON M.Id = Servicios.Id_Servicios_Modalidad " +
                    "LEFT JOIN Servicios_Grupos ON Servicios_Grupos.id = T.Id_Servicios_Grupos " +
                    "WHERE tipo_facturacion_servicios.id_tipo_facturacion = @id and Servicios.Borrado = 0 GROUP BY Id_Servicios ORDER BY Id_Servicios");

                oCon.AsignarParametroEntero("@id", id);
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

        public DataTable ListarGrupos()
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT * FROM Servicios_Grupos ORDER BY Id");
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

        public DataTable ListarCategorias()
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT * FROM Servicios_Categorias ORDER BY Id");
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

        public DataTable ListarModalidades()
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT * FROM Servicios_Modalidad ORDER BY Orden");
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

        public DataTable ListarEstados()
        {
            DataTable dt = new DataTable();

            try
            {
                oCon.Conectar();
                oCon.CrearComando("SELECT * FROM servicios_estados ORDER BY Id");
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

        public DataTable ListarContratos()
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Id", typeof(Int32));
            dt.Columns.Add("Contrato", typeof(String));
            dt.Rows.Add(0, "NINGUNO");
            dt.Rows.Add(1, "PLAN VERANO");

            return dt;
        }

        public DataTable BuscarDatosServicio(int Id_Servicio)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando("select servicios.Id, servicios.Descripcion, servicios.Id_Servicios_Tipos,servicios_tipos.id_servicios_grupos, (select servicios_tipos.Nombre from servicios_tipos where servicios_tipos.Id=servicios.Id_Servicios_Tipos) as Servicio_Tipo, servicios.Id_Servicios_Modalidad, (SELECT servicios_modalidad.Nombre from servicios_modalidad where servicios_modalidad.Id=servicios.Id_Servicios_Modalidad) as Modalidad, servicios.Requiere_Equipo,servicios.Requiere_Tarjeta,servicios.Requiere_Velocidad,Forzar_inicio_mes,servicios.requiere_servicio_padre,servicios.fecha_inicio_servicio,servicios.id_aplicaciones_externas,servicios.genera_deuda_cortado,servicios.genera_deuda_retirado from servicios inner join servicios_tipos on servicios_tipos.id=servicios.id_servicios_tipos where servicios.id=@id_servicio and servicios.borrado=0");
                oCon.AsignarParametroEntero("@id_servicio", Id_Servicio);
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

        public DataTable ListarEspeciales()
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando(String.Format("SELECT * from servicios where id_servicios_modalidad = {0}", (int)Servicios._Modalidad.PERIODO));
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

        public DataRow getInfoServicio(int id_servicio)
        {
            DataTable dt = new DataTable();
            try
            {
                oCon.Conectar();
                oCon.CrearComando(String.Format("SELECT * FROM servicios where id = {0} ", id_servicio));
                dt = oCon.Tabla();
                oCon.DesConectar();
            }
            catch (Exception)
            {
                oCon.DesConectar();
                throw;
            }
            
            return dt.Rows[0];
        }

    }
}
