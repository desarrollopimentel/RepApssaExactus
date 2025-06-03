using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
//using Exactus.BE;
//using Exactus.DL;
//using System.Data;
using System.Data.SqlClient;
//using Exactus.DC;
//using Exactus.BE;

namespace ApssaExactus
{

    public class LogisticaBL
    {

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

    }



    public class ReportesLogisticaBL
    {
        //Exactus.DL.ReportesLogisticaDL objReportesLogisticaBL = new Exactus.DL.ReportesLogisticaDL();
        ApssaExactus.ReportesLogisticaDL objReportesLogisticaBL = new ApssaExactus.ReportesLogisticaDL();
        
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
