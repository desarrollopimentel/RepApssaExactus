using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
//using Exactus.BE;
//using Exactus.DL;

namespace ApssaExactus
{
    public class CreditosBL
    {

        public static int ActualizarConstanciaInscripcion_BL(string _cliente, string _tipo, string _documento, DateTime _fecha, string _constancia, string db)
        {
            try
            {
                return CreditosDL.ActualizarConstanciaInscripcion_DL(_cliente, _tipo, _documento, _fecha, _constancia, db);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }

        }


        public static DataTable dtDetalleCanjeLetraBL(string _tipo_canje, string _documento_canje, string db)
        {
            return CreditosDL.dtDetalleCanjeLetraDL(_tipo_canje, _documento_canje, db);
        }

        public static int GrabarClausulaLetra_BL(DateTime _fecha, string _tipo, string _activo, string _clausula, string db)
        {
            try
            {
                return CreditosDL.GrabarClausulaLetra_DL(_fecha, _tipo, _activo, _clausula, db);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public static int ActualizarClausulaLetra_BL(Int16 _id_clausula, DateTime _fecha, string _tipo, string _activo, string _clausula, string db)
        {
            try
            {
                return CreditosDL.ActualizarClausulaLetra_DL(_id_clausula, _fecha, _tipo, _activo, _clausula, db);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }

        }

        public static DataTable CargaDatosClausula_BL(Int16 _id, string db)
        {
            return CreditosDL.CargaDatosClausula_DL(_id, db);
        }

        public static DataTable dtFormatosLetras_BL(string db)
        {
            return CreditosDL.dtFormatosLetras_DL(db);
        }


        public static string ObtenerClausulaLetraCC_DL(Int16 _id, string _tipo, string db)
        {
            return CreditosDL.ObtenerClausulaLetraCC_DL(_id, _tipo, db);
        }




        public static bool VerificarSiYaEstaRegistradoAnalistaCreditosBL(string id_prod, string db)
        {
            return CreditosDL.VerificarSiYaEstaRegistradoAnalistaCreditosDL(id_prod, db);
        }

        public static DataTable dtObtenerUsuariosAnalistasCreditosBL(string cdb)
        {
            return CreditosDL.dtObtenerUsuariosAnalistasCreditosDL(cdb);
        }

        public static DataTable CargaDatosAnalistaCreditoBL(string art, string db)
        {
            return CreditosDL.CargaDatosAnalistaCreditoDL(art, db);
        }
        public static bool ExisteAnalistaCreditoBL(string analista, string db)
        {
            return CreditosDL.ExisteAnalistaCreditoDL(analista, db);
        }

        public static void ActualizarAnalistasCreditoBL(string _tipo_operacion, string _analista, string _area, string _analista_cc, string _nombre,
                                                        string _referencia, string _observaciones, string _estado, string _moneda_credito,
                                                         Decimal _limite_credito, Decimal _limite_credito_sol, Decimal _limite_credito_dol, string db)
        {
            CreditosDL.ActualizarAnalistasCreditoDL(_tipo_operacion, _analista, _area, _analista_cc, _nombre,
                                                    _referencia, _observaciones, _estado, _moneda_credito,
                                                    _limite_credito, _limite_credito_sol, _limite_credito_dol, db);
        }

        public static DataTable dtObtenerAnalistasCreditoBL(string db)
        {
            return CreditosDL.dtObtenerAnalistasCreditoDL(db);
        }

        //--------------------------------------------------------------------------------------------------------------------------

        // 2022-06-10
        public static DataTable dtSaldoClientesV2_BL(string _zona, DateTime _fecha, string _moneda, string db)
        {
            return CreditosDL.dtSaldoClientesV2_DL(_zona, _fecha, _moneda, db);
        }



        //Update: 20/09/2020

        public static DataTable dtObtieneTablaCobranzaV2BL(string file_sql, string db)
        {
            return CreditosDL.dtObtieneTablaCobranzaV2DL(file_sql, db);
        }


        public static DataSet dsObtenerTablasCobranzasV2BL(DateTime fecha1, DateTime fecha2, string zon, string fil1, string fil2, string fil3,
                                                             string fil4, string fil5, string fil6, string fil7, string fil8, string db)
        {
            try
            {
                DataSet ds_Cobranza = new DataSet();
                ds_Cobranza = CreditosDL.dsObtenerTablasCobranzasV2DL(fecha1, fecha2, zon, fil1, fil2, fil3, fil4, fil5, fil6, fil7, fil8, db);
                ds_Cobranza.Tables[0].TableName = "Balance";
                return ds_Cobranza;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        //--------------------------------------------------------------------------------------------------------------------------



        public static DataTable dtObtenerListaReactivaPeruBL(string db)
        {
            return CreditosDL.dtObtenerListaReactivaPeruDL(db);
        }

        public static DataTable dtGetContactosPorClientesBL(string _cliente, string db)
        {
            return CreditosDL.dtGetContactosPorClientesDL(_cliente, db);
        }


        public static void dtGetContactosClientesUpdateBL(string _operacion, string _cliente, string _razon,
                                                            string _email1, string _flag1,
                                                            string _email2, string _flag2,
                                                            string _email3, string _flag3,
                                                            string _email4, string _flag4,
                                                            string _observ, string _estado, string db)
        {
            CreditosDL.dtGetContactosClientesUpdateDL(_operacion, _cliente, _razon,
                                                      _email1, _flag1,
                                                      _email2, _flag2,
                                                      _email3, _flag3,
                                                      _email4, _flag4,
                                                      _observ, _estado, db);
        }

        public static void EliminarContactoClienteBL(string cte, string db)
        {
            CreditosDL.EliminarContactoClienteDL(cte, db);
        }

        public static DataTable dtGetContactosClientesBL(string db)
        {
            return CreditosDL.dtGetContactosClientesDL(db);
        }

        public static DataTable dtRecuperaTablaEstadoCuentaBL(string file_sql, string db)
        {
            return CreditosDL.dtRecuperaTablaEstadoCuentaDL(file_sql, db);
        }


        public static DataSet dsObtenerTablasEstadoCuentaBL(DateTime fecha1, DateTime fecha2, string fil1, string fil2, string db)
        {
            try
            {
                DataSet ds_Estado = new DataSet();
                ds_Estado = CreditosDL.dsObtenerTablasEstadoCuentaDL(fecha1, fecha2, fil1, fil2, db);
                ds_Estado.Tables[0].TableName = "EstCuenta";
                return ds_Estado;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }





        //-----------------------------------------------------------------------------------------------------------------------  
        public static DataTable dtSaldoClientesBL(string _zona, DateTime _fecha, string _moneda, string db)
        {
            return CreditosDL.dtSaldoClientesDL(_zona, _fecha, _moneda, db);
        }

        public static DataTable dtEsClienteCastigadoBL(string _clie, string _esta, string db)
        {
            return CreditosDL.dtEsClienteCastigadoDL(_clie, _esta, db);
        }

        public static DataTable dtObtenerDocumentosDesprovisionSegunFechaBL(DateTime _fini, DateTime _ffin, string _est, string db)
        {
            return CreditosDL.dtObtenerDocumentosDesprovisionSegunFechaDL(_fini, _ffin, _est, db);
        }

        public static DataTable dtObtenerDocumentosProvisionSegunFechaBL(DateTime _fini, DateTime _ffin, string _est, string db)
        {
            return CreditosDL.dtObtenerDocumentosProvisionSegunFechaDL(_fini, _ffin, _est, db);
        }

        public static DataTable dtConsultarIndicadoresClienteBL(Int16 _ano, Int16 _mes, string _tienda, string db)
        {
            return CreditosDL.dtConsultarIndicadoresClienteDL(_ano, _mes, _tienda, db);
        }

        public static DataTable dtProcesarIndicadoresClienteBL(Int16 _ano, Int16 _mes, string _tienda, string db)
        {
            return CreditosDL.dtProcesarIndicadoresClienteDL(_ano, _mes, _tienda, db);
        }

        public static DataTable dtObtenerAplicacionesFiltroCC_BL(DateTime _fecha_desde, DateTime _fecha_hasta, string _moneda, string _sucursal, string _tienda,
                                                                 string _categoria_cliente, string _cliente_desde, string _cliente_hasta, string _vendedor,
                                                                 string _cobrador, string _analista, string db)
        {
            return CreditosDL.dtObtenerAplicacionesFiltroCC_DL(_fecha_desde, _fecha_hasta, _moneda, _sucursal, _tienda,
                                                               _categoria_cliente, _cliente_desde, _cliente_hasta, _vendedor,
                                                               _cobrador, _analista, db);
        }

        public static DataTable dtObtenerSaldosInvertidoFiltroBL(DateTime _fecha_saldo, string _sucursal, string _tienda, string _categoria_cliente,
                                                                        string _cliente_desde, string _cliente_hasta, string _vendedor, string _cobrador,
                                                                        string _analista, string _tipo, string db)
        {
            return CreditosDL.dtObtenerSaldosInvertidoFiltroDL(_fecha_saldo, _sucursal, _tienda, _categoria_cliente,
                                                                      _cliente_desde, _cliente_hasta, _vendedor, _cobrador,
                                                                      _analista, _tipo, db);
        }

        public static DataTable dtObtenerSaldoClienteSegunFechaFiltroBL(DateTime _fecha_saldo, string _sucursal, string _tienda, string _categoria_cliente,
                                                                        string _cliente_desde, string _cliente_hasta, string _vendedor, string _cobrador,
                                                                        string _analista, string db)
        {
            return CreditosDL.dtObtenerSaldoClienteSegunFechaFiltroDL(_fecha_saldo, _sucursal, _tienda, _categoria_cliente,
                                                                      _cliente_desde, _cliente_hasta, _vendedor, _cobrador,
                                                                      _analista, db);
        }

        public static DataTable dtObtenerSaldoClienteSegunFechaFiltroV3BL(DateTime _fecha_saldo, string _sucursal, string _tienda, string _categoria_cliente,
                                                                        string _cliente_desde, string _cliente_hasta, string _vendedor, string _cobrador,
                                                                        string _analista, string _saldo_cero, string db)
        {
            return CreditosDL.dtObtenerSaldoClienteSegunFechaFiltroV3DL(_fecha_saldo, _sucursal, _tienda, _categoria_cliente,
                                                                        _cliente_desde, _cliente_hasta, _vendedor, _cobrador,
                                                                        _analista, _saldo_cero, db);
        }

        public static DataTable dtObtenerSaldosInvertidoBL(DateTime _fecha_saldo, string _cliente_ini, string _cliente_fin, string _tipo, string db)
        {
            return CreditosDL.dtObtenerSaldosInvertidoDL(_fecha_saldo, _cliente_ini, _cliente_fin, _tipo, db);
        }

        public static DataTable dtObtenerSaldoClienteSegunFechaBL(DateTime _fecha_saldo, string _cliente_ini, string _cliente_fin, string db)
        {
            return CreditosDL.dtObtenerSaldoClienteSegunFechaDL(_fecha_saldo, _cliente_ini, _cliente_fin, db);
        }

        public static DataTable dtObtenerClienteDetalleCobranzaBL(Int32 _ejercicio, Int32 _mes, string _cliente, string db)
        {
            return CreditosDL.dtObtenerClienteDetalleCobranzaDL(_ejercicio, _mes, _cliente, db);
        }

        //14/08/2018
        public static DataTable dtObtenerClienteIndicadoresBL(Int32 _ejercicio, string cliente, string db)
        {
            return CreditosDL.dtObtenerClienteIndicadoresDL(_ejercicio, cliente, db);
        }

        //03/07/2018
        public static DataTable dtObtenerAplicacionesCC_BL(DateTime _fecha_ini, DateTime _fecha_fin, string _moneda, string _sucursal, string _tienda, string db)
        {
            return CreditosDL.dtObtenerAplicacionesCC_DL(_fecha_ini, _fecha_fin, _moneda, _sucursal, _tienda, db);
        }

        //03/07/2018
        public static DataTable dtObtenerAnalistasCC_BL(string _anal, string _documento, string _combo, string _tipo, string db)
        {
            return CreditosDL.dtObtenerAnalistasCC_DL(_anal, _documento, _combo, _tipo, db);
        }


        //03/07/2018
        public static DataTable dtDocumentosClienteHistoricoBL(string contribuyente, string cliente, DateTime fecini, DateTime fecfin, string db)
        {
            return CreditosDL.dtDocumentosClienteHistoricoDL(contribuyente, cliente, fecini, fecfin, db);
        }

        //27/06/2018
        public static DataTable dtObtenerLugarGiroLetra_BL(string _tipo, string _documento, string db)
        {
            return CreditosDL.dtObtenerLugarGiroLetra_DL(_tipo, _documento, db);
        }

        public static DataTable dtObtenerDatosLetras_BL(string _cliente, string _tipo, string _documento, string db)
        {
            return CreditosDL.dtObtenerDatosLetras_DL(_cliente, _tipo, _documento, db);
        }



        public static DataTable dtObtieneTablaCobranzaBL(string file_sql, string db)
        {
            return CreditosDL.dtObtieneTablaCobranzaDL(file_sql, db);
        }



        //12/09/2016
        public static DataSet dsObtenerTablasCobranzasBL(DateTime fecha1, DateTime fecha2, string zon, string fil1, string fil2, string fil3,
                                                             string fil4, string fil5, string fil6, string fil7, string db)
        {
            try
            {
                DataSet ds_Cobranza = new DataSet();
                ds_Cobranza = CreditosDL.dsObtenerTablasCobranzasDL(fecha1, fecha2, zon, fil1, fil2, fil3, fil4, fil5, fil6, fil7, db);
                ds_Cobranza.Tables[0].TableName = "Balance";
                return ds_Cobranza;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }



        //06/09/2016
        public static DataTable dtObtenerCobranzas_BL(DateTime fechaini, DateTime fechafin, string tienda, string db)
        {
            return CreditosDL.dtObtenerCobranzas_DL(fechaini, fechafin, tienda, db);
        }

    }


    public class ReportesCreditosBL
    {
        //Exactus.DL.ReportesCreditosDL objReportesCreditosBL = new Exactus.DL.ReportesCreditosDL();
        ReportesCreditosDL objReportesCreditosBL = new ReportesCreditosDL();

        public DataTable dtDocumentosClienteBL(DateTime vfechareporte, string vsucursal, string vzonas, string vcondicionpago, string db)
        {
            return objReportesCreditosBL.dtDocumentosClienteDL(vfechareporte, vsucursal, vzonas, vcondicionpago, db);
        }
        public DataTable Reporte_Abonos_detalle(DateTime fecha_inicial, DateTime fecha_final, string tienda, string db)
        {
            return objReportesCreditosBL.Reporte_Detalle_abonos(fecha_inicial, fecha_final, tienda, db);
        }




    }

    public class Reportes_Saldos_vs_Abonos
    {
        //DL.Reportes_Saldos_vs_AbonosDL obj_sa = new DL.Reportes_Saldos_vs_AbonosDL();
        Reportes_Saldos_vs_AbonosDL obj_sa = new Reportes_Saldos_vs_AbonosDL();
        public DataTable Reporte_saldos_vs_abonos_saldos(DateTime fecha_inicial, DateTime fecha_final, string db)
        {
            return obj_sa.dtsaldos(fecha_inicial, fecha_final, db);
        }
        public DataTable Reporte_saldos_vs_abonos_abonos(DateTime fecha_inicial, DateTime fecha_final, string db)
        {
            return obj_sa.dtabonos(fecha_inicial, fecha_final, db);
        }
        public DataTable Reporte_saldos_x_abonos(DateTime fecha_inicial, DateTime fecha_final, string db)
        {
            return obj_sa.dtsaldos_x_abonos(fecha_inicial, fecha_final, db);
        }
    }


    public class EstadoCuentaBL
    {
        //Exactus.DL.EstadoCuentaDL objEstadoCuentaBL = new Exactus.DL.EstadoCuentaDL();
        EstadoCuentaDL objEstadoCuentaBL = new EstadoCuentaDL();

        public DataTable dtCanjeLetrasClienteBL(string contribuyente, string cliente, DateTime fecini, DateTime fecfin, string db)
        {
            return objEstadoCuentaBL.dtCanjeLetrasClienteDL(contribuyente, cliente, fecini, fecfin, db);
        }

        public DataTable dtSaldoDocumentosClienteBL(string contribuyente, string cliente, DateTime fecini, DateTime fecfin, string db)
        {
            return objEstadoCuentaBL.dtSaldoDocumentosClienteDL(contribuyente, cliente, fecini, fecfin, db);
        }

        public DataTable dtSaldoClienteBL(string cliente, string db)
        {
            return objEstadoCuentaBL.dtSaldoClienteDL(cliente, db);
        }

        public DataTable dtInformacionClienteBL(string cliente, string db)
        {
            return objEstadoCuentaBL.dtInformacionClienteDL(cliente, db);
        }

        public DataTable dtLetrasEstadoClienteBL(string cliente, DateTime fecfin, string db)
        {
            return objEstadoCuentaBL.dtLetrasEstadoClienteDL(cliente, fecfin, db);
        }

    }

}
