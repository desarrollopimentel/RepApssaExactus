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

    public class LogisticaBL
    {


        public static DataTable dtListarGuiasDeRemision_BL(DateTime _fini, DateTime _fina, string _zon, string _tie, string _opc, string db)
        {
            return LogisticaDL.dtListarGuiasDeRemision_DL(_fini, _fina, _zon, _tie, _opc, db);
        }



        public static DataTable dtListarBitacoraDesreserva_BL(DateTime _fecha_ini, DateTime _fecha_fin, string _opcion, string db)
        {
            return LogisticaDL.dtListarBitacoraDesreserva_DL(_fecha_ini, _fecha_fin, _opcion, db);
        }

        public static bool EliminarReservaArticulo_BL(string _tipodoc, string _documento, string _bodega, string _articulo, string _aplicacion, Decimal _cantidad, string _usuario, string db)
        {
            try
            {
                return LogisticaDL.EliminarReservaArticulo_DL(_tipodoc, _documento, _bodega, _articulo, _aplicacion, _cantidad, _usuario, db);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public static DataTable dtListarArticulosReservados_BL(DateTime fini, DateTime fina, string zon, string tip, string docu, string db)
        {
            return LogisticaDL.dtListarArticulosReservados_DL(fini, fina, zon, tip, docu, db);
        }


        public static string ObtenerUsuarioCompradorBL(string _usuario, string db)
        {
            return LogisticaDL.ObtenerUsuarioCompradorDL(_usuario, db);
        }


        public static void TestCargarJSON_BL(string db)
        {
            LogisticaDL.TestCargarJSON_DL(db);
        }

        public static void CargarJSON_BL(string _json, string db)
        {
            LogisticaDL.CargarJSON_DL(_json, db);
        }


        /*
        //=================================================================================================

        public static void CargarOrdenesCompraTest2_BL(string _usuario, object _json, string db)
        {
            try
            {
                LogisticaDL.CargarOrdenesCompraTest2_DL(_usuario, _json, db);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public static DataTable dtCargarOrdenesCompraV2_BL(string _usuario, string _json, string db)
        {
            return LogisticaDL.dtCargarOrdenesCompraV2_DL(_usuario, _json, db);
        }



        public static bool CargarOrdenesCompraTest1_BL(string _usuario, string _json, string db)
        {
            try
            {
                return LogisticaDL.CargarOrdenesCompraTest1_DL(_usuario, _json, db);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }


        public static bool CargarOrdenesCompraV2_BL(string _usuario, string _json, string db)
        {
            try
            {
                return LogisticaDL.CargarOrdenesCompraV2_DL(_usuario, _json, db);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }



        public static DataTable dtCargarOrdenesCompra_BL(string _shipto, string _numero_pedido, DateTime _fecha_pedido, string _proveedor,
                                                         string _moneda, Decimal _total, string _codigo, Decimal _cantidad, Decimal _precio,
                                                         Decimal _igv, DateTime _fecha_entrega, string _rubro3, string _rubro5, string db)
        {

            return LogisticaDL.dtCargarOrdenesCompra_DL(_shipto, _numero_pedido, _fecha_pedido, _proveedor,
                                                         _moneda, _total, _codigo, _cantidad, _precio,
                                                         _igv, _fecha_entrega, _rubro3, _rubro5, db);
        }

        //=================================================================================================
        */


        //public static DataSet CargaExcel(string RutaExcelBL, string NombreHojaBL)
        //{
        //    try
        //    {
        //        DataSet ds_le = new DataSet();
        //        ds_le = AccesoGeneralDL.CargaExcel(RutaExcelBL, NombreHojaBL);
        //        ds_le.Tables[0].TableName = "listaexcel";
        //        return ds_le;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new ArgumentException(ex.Message);
        //    }
        //}


        //-------------------------------------------------------------------------------------------------

        public static bool CargarOrdenCompra_BL(string _file, string _opcion, string db)
        {
            try
            {
                return LogisticaDL.CargarOrdenCompra_DL(_file, _opcion, db);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }


        public static bool CargaTablaTemporalCargaOC_BL(string _tabla, string _shipto, string _numero_pedido, DateTime _fecha_pedido, string _moneda, Decimal _total,
                                                        string _codigo, Decimal _cantidad, Decimal _precio, Decimal _igv, DateTime _fecha_entrega, string _rubro3, string _rubro5,
                                                        Decimal _total_mercaderia, Decimal _total_impuesto, Decimal _total_orden, string _usuario, string db)
        {
            try
            {
                return LogisticaDL.CargaTablaTemporalCargaOC_DL(_tabla, _shipto, _numero_pedido, _fecha_pedido, _moneda, _total,
                                                                _codigo, _cantidad, _precio, _igv, _fecha_entrega, _rubro3, _rubro5,
                                                                _total_mercaderia, _total_impuesto, _total_orden, _usuario, db);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }


        public static DataTable dtListarTablaTemporalCargaOC_BL(string _file, string _opcion, string db)
        {
            return LogisticaDL.dtListarTablaTemporalCargaOC_DL(_file, _opcion, db);
        }
        public static DataSet dsCrearTablaTemporalCargaOC_BL(string _file, string _opcion, string db)
        {
            try
            {
                DataSet ds_Cobranza = new DataSet();
                ds_Cobranza = LogisticaDL.dsCrearTablaTemporalCargaOC_DL(_file, _opcion, db);
                ds_Cobranza.Tables[0].TableName = "Balance";
                return ds_Cobranza;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }


        public static DataTable dtListarCamposExactusOrdenCompraMaster_BL(string db)
        {
            return LogisticaDL.dtListarCamposExactusOrdenCompraMaster_DL(db);
        }

        public static DataTable dtListarCamposExactusOrdenCompra_BL(string db)
        {
            return LogisticaDL.dtListarCamposExactusOrdenCompra_DL(db);
        }

        public static DataTable dtListarCamposExcelOrdenCompra_BL(string db)
        {
            return LogisticaDL.dtListarCamposExcelOrdenCompra_DL(db);
        }
        //-------------------------------------------------------------------------------------------------





        public static DataTable dtCargarParametrosKardex_BL(string _modulo, string _aplicacion, string db)
        {
            return LogisticaDL.dtCargarParametrosKardex_DL(_modulo, _aplicacion, db);
        }

        public static DataTable dtObtenerArticuloTransacciones_BL(string _articulo, string _bodega, string _operacion,
                                                                  DateTime _fecha_ini, DateTime _fecha_fin, string db)
        {
            return LogisticaDL.dtObtenerArticuloTransacciones_DL(_articulo, _bodega, _operacion, _fecha_ini, _fecha_fin, db);
        }

        public static DataTable dtObtenerArticuloExistenciasV2_BL(string _articulo, string _bodega, string _operacion,
                                                                  DateTime _fecha_ini, DateTime _fecha_fin, string db)
        {
            return LogisticaDL.dtObtenerArticuloExistenciasV2_DL(_articulo, _bodega, _operacion, _fecha_ini, _fecha_fin, db);
        }

        public static DataTable dtObtenerArticuloExistencias_BL(string _articulo, string _bodega, string _operacion, string db)
        {
            return LogisticaDL.dtObtenerArticuloExistencias_DL(_articulo, _bodega, _operacion, db);
        }


        //---------------------------------------------------------------------------------------------------------------
        public static DataTable dtObtenerDespachos_BL(DateTime _fecha_ini, DateTime _fecha_fin, string _zona, string db)
        {
            return LogisticaDL.dtObtenerDespachos_DL(_fecha_ini, _fecha_fin, _zona, db);
        }


        //Obtiene Articulos Remitidos
        public static DataTable dtObtenerArticulosRemitidos_BL(string _articulo, string _bodega, string db)
        {
            return LogisticaDL.dtObtenerArticulosRemitidos_DL(_articulo, _bodega, db);
        }

        //Obtiene Articulos Transacciones
        public static DataTable dtObtenerArticuloTransacciones_BL(DateTime _fecha_ini, DateTime _fecha_fin, string _bodega, string _articulo,string db)
        {
            return LogisticaDL.dtObtenerArticuloTransacciones_DL(_fecha_ini, _fecha_fin, _bodega, _articulo, db);
        }


        #region VENTA_COMPRA

        public static DataSet CargaPreferencia(string cModulo, string cReporte, string cPreferencia, string db)
        {
            try
            {
                DataSet ds_pr = new DataSet();
                ds_pr = LogisticaDL.CargaPreferencia(cModulo, cReporte, cPreferencia, db);
                ds_pr.Tables[0].TableName = "pr";
                return ds_pr;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }

        }

        public static DataSet ObtenerVC2015(DateTime fecha1, DateTime fecha2, string bode,string fami, string subf, string grup, string deta,string db)
        {
            try
            {
                DataSet ds_VentComp = new DataSet();
                ds_VentComp = LogisticaDL.ObtenerVC2015(fecha1, fecha2, bode, fami, subf, grup, deta,db);
                ds_VentComp.Tables[0].TableName = "VentComp";
                return ds_VentComp;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public static DataSet ObtenerVentaCompra(DateTime fecha1, DateTime fecha2, string bode, 
                                                 string fami, string subf ,string grup, string db)
        {
            try
            {
                DataSet ds_VentComp = new DataSet();
                ds_VentComp = LogisticaDL.ObtenerVentaCompra(fecha1, fecha2, bode, fami, subf, grup, db);
                ds_VentComp.Tables[0].TableName = "VentComp";
                return ds_VentComp;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public static DataSet ObtenerVC2015V3(DateTime fecha1, DateTime fecha2, string bode, string fami, string subf, string grup, string deta, string db)
        {
            try
            {
                DataSet ds_VentComp = new DataSet();
                ds_VentComp = LogisticaDL.ObtenerVC2015V3(fecha1, fecha2, bode, fami, subf, grup, deta, db);
                ds_VentComp.Tables[0].TableName = "VentComp";
                return ds_VentComp;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }


        #endregion

        public static DataSet Items_sin_movimiento(string bodega,int dias,string bd)
        {
            try
            {
                DataSet ds_ = new DataSet();
                ds_ = LogisticaDL.Items_sin_movimiento(bodega, dias, bd);
                ds_.Tables[0].TableName = "Items";
                return ds_;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }


        public static DataSet CargaExcel_BL(string RutaExcelBL, string NombreHojaBL)
        {
            try
            {
                DataSet ds_le = new DataSet();
                ds_le = LogisticaDL.CargaExcel_DL(RutaExcelBL, NombreHojaBL);
                ds_le.Tables[0].TableName = "listaexcel";
                return ds_le;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }

        }



    }



    public class ReportesLogisticaBL
    {
        // Exactus.DL.ReportesLogisticaDL objReportesLogisticaBL = new Exactus.DL.ReportesLogisticaDL();
        ReportesLogisticaDL objReportesLogisticaBL = new ReportesLogisticaDL();

        public DataTable dtPeriodosCuotasBL(string canno, string db)
        {
            return objReportesLogisticaBL.dtPeriodosCuotasDL(canno, db);
        }

        public DataTable dtCuotasDelMesBL(string canno, Int32 cmes, string db)
        {
            return objReportesLogisticaBL.dtCuotasDelMesDL(canno, cmes, db);
        }

        public DataTable dtReporteCuotasBL(string canno, DateTime f1, DateTime f2, string db)
        {
            return objReportesLogisticaBL.dtReporteCuotasDL(canno, f1, f2, db);
        }

        public DataTable dtSeguimientoComprasBL(DateTime f1, DateTime f2, string db)
        {
            return objReportesLogisticaBL.dtSeguimientoComprasDL(f1, f2, db);
        }

    }





}
