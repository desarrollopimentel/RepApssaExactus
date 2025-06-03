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
    public class ComercialBL
    {

        public static bool EliminarArticuloWebBL(string _articulo, string db)
        {
            return ComercialDL.EliminarArticuloWebDL(_articulo, db);
        }
        public static bool VerificarSiYaEstaRegistradoIdProductWebBL(string id_prod, string db)
        {
            return ComercialDL.VerificarSiYaEstaRegistradoIdProductWebDL(id_prod, db);
        }

        public static bool VerificarSiYaEstaRegistradoArticuloWebBL(string art, string db)
        {
            return ComercialDL.VerificarSiYaEstaRegistradoArticuloWebDL(art, db);
        }

        public static void ActualizarArticulosWebBL(string _tipo_operacion, string _articulo, Int16 _id_product, string _descripcion, string _unidad,
                            Decimal _ex_stock, Decimal _ex_precio, Decimal _ps_stock, Decimal _ps_precio, Decimal _carga_stock, Decimal _carga_precio,
                            Decimal _atributo1, Decimal _atributo2, Decimal _atributo3, Decimal _atributo4, Decimal _atributo5,
                            string _existe, string _activo, string _observaciones, string _usuario, DateTime _fecha_proceso, string db)
        {
            ComercialDL.ActualizarArticulosWebDL(_tipo_operacion, _articulo, _id_product, _descripcion, _unidad,
                                                 _ex_stock, _ex_precio, _ps_stock, _ps_precio, _carga_stock, _carga_precio,
                                                 _atributo1, _atributo2, _atributo3, _atributo4, _atributo5,
                                                 _existe, _activo, _observaciones, _usuario, _fecha_proceso, db);
        }

        public static void ActualizarTablaArticulosWebBL(string db)
        {
            ComercialDL.ActualizarTablaArticulosWebDL(db);
        }

        public static void GrabarArticulosWebTemporalBL(string v_articulo, Int16 v_id_product, string v_descripcion, string v_unidad, Decimal v_ex_stock,
                                                        Decimal v_ex_precio, Decimal v_ps_stock, Decimal v_ps_precio, Decimal v_carga_stock, Decimal v_carga_precio,
                                                        Decimal v_atributo1, Decimal v_atributo2, Decimal v_atributo3, Decimal v_atributo4, Decimal v_atributo5,
                                                        string v_existe, string v_activo, string v_observaciones, string v_usuario, DateTime v_fecha_proceso, string db)
        {
            ComercialDL.GrabarArticulosWebTemporalDL(v_articulo, v_id_product, v_descripcion, v_unidad, v_ex_stock,
                                                     v_ex_precio, v_ps_stock, v_ps_precio, v_carga_stock, v_carga_precio,
                                                     v_atributo1, v_atributo2, v_atributo3, v_atributo4, v_atributo5,
                                                     v_existe, v_activo, v_observaciones, v_usuario, v_fecha_proceso, db);
        }

        public static void EliminarArticulosWebTemporalBL(string db)
        {
            ComercialDL.EliminarArticulosWebTemporalDL(db);
        }

        public static DataTable dtObtenerDatosArticulosWebTemporalBL(string db)
        {
            return ComercialDL.dtObtenerDatosArticulosWebTemporalDL(db);
        }

        public static DataTable dtObtenerDatosArticulosWebBL(string db)
        {
            return ComercialDL.dtObtenerDatosArticulosWebDL(db);
        }


        //******************************************************************************************

        public static DataTable dtObtieneFacturacionGeneralBL(string _anno, Int32 _mes, string _tipo, Int32 _incluyedevol, string db)
        {
            return ComercialDL.dtObtieneFacturacionGeneralDL(_anno, _mes, _tipo, _incluyedevol, db);
        }

        public static DataTable dtObtieneDiferenciaCambiariaCabeceraBL(Int32 _mes, string _anno, string _tipo, string _m, string db)
        {
            return ComercialDL.dtDiferenciaCambiariaCabeceraDL(_mes, _anno ,_tipo, _m, db);
        }

        public static DataTable dtObtieneDiferenciaCambiariaDetalleBL(Int32 _mes, string _anno, string _tipo, string _m, string db)
        {
            return ComercialDL.dtDiferenciaCambiariaDetalleDL(_mes, _anno, _tipo, _m, db);
            
        }


        public static DataTable dtObtieneDiferenciaCambiariaAsientoBL(string _asiento, string db)
        {
            return ComercialDL.dtDiferenciaCambiariaAsientoDL(_asiento, db);
        }


        public static DataTable dtObtieneFacturacionGeneralDetalleBL(string _anno, Int32 _mes, string db)
        {
            return ComercialDL.dtObtieneFacturacionGeneralDetalleDL(_anno, _mes, db);
        }

        public static DataTable dtObtieneFacturacionHistoricaDetalleBL(string _anno, Int32 _mes, string db)
        {
            return ComercialDL.dtObtieneFacturacionHistoricaDetalleDL(_anno, _mes, db);
        }
        //******************************************************************************************


        public static DataTable dtObtenerFacturasPDF_BL(string db)
        {
            return ComercialDL.dtObtenerFacturasPDF_DL(db);
        }

        // 16/06/2017 avila
        
        public static DataTable Lista_venta_llantas(string cCAJA_BL, string db_BL)
        {
            return ComercialDL.Lista_venta_llantas_DL(cCAJA_BL, db_BL);
        }


        ////21/10/2016

        public static string UsuarioPreferenciaZonaBL(string _user, string _tipo, string db)
        {
            return ComercialDL.UsuarioPreferenciaZonaDL(_user, _tipo, db);
        }

        public static string UsuarioPreferenciaSucursalBL(string _user, string _tipo, string db)
        {
            return ComercialDL.UsuarioPreferenciaSucursalDL(_user, _tipo, db);
        }

        public static bool UsuarioTienePerfilBL(string _user, string _perfil, string db)
        {
            return ComercialDL.UsuarioTienePerfilDL(_user, _perfil, db);
        }

        public static DataTable dtObtieneVentaDiariaV3BL(string _anno, Int32 _mes, string _tipo, string _user, string _perfil, string _tienda, string db)
        {
            return ComercialDL.dtObtieneVentaDiariaV3DL(_anno, _mes, _tipo, _user, _perfil, _tienda, db);
        }


        public static DataTable dtObtieneVentaDiariaV2BL(string _anno, Int32 _mes, string _tipo, string _user, string _perfil, string _tienda, string db)
        {
            return ComercialDL.dtObtieneVentaDiariaV2DL(_anno, _mes, _tipo, _user, _perfil, _tienda, db);
        }
        ////12/09/2016
        public static DataTable dtObtieneVentaDiariaBL(string _anno, Int32 _mes, string _tipo, string _tienda, string db)
        {
            return ComercialDL.dtObtieneVentaDiariaDL(_anno, _mes, _tipo, _tienda, db);
        }


        public static DataTable dtObtieneCuotaGY_BL(Int32 _anno, Int32 _mes, string _usuario, string _tienda, string db)
        {
            return ComercialDL.dtObtieneCuotaGY_DL(_anno, _mes, _usuario, _tienda, db);
        }


        public static DataTable dtObtieneDataGY_BL(Int32 _anno, Int32 _mes, string db)
        {
            return ComercialDL.dtObtieneDataGY_DL(_anno, _mes,  db);
        }


        public static DataTable dtObtenerBodegasPorUsuarioBL(string usu, string db)
        {
            return ComercialDL.dtObtenerBodegasPorUsuarioDL(usu, db);
        }

        // 04/054/2016
        public static DataTable dtObtenerMovimientosPorArticuloBL(DateTime fini, DateTime ffin, string bod, string fam, string db)
        {
            return ComercialDL.dtObtenerMovimientosPorArticuloDL(fini, ffin, bod, fam, db);
        }

        //  avila 03/10/2017
        public static DataTable Listar_detracciones_BL(string fini, string db)
        {
            return ComercialDL.dtObtenerDetraccionesDL(fini, db);
        }
       

        //  avila 08/11/2017
        public static DataTable Listar_pago_proveedores_BL(string fcuenta, string ftrans, string fbanco, string db)
        {
            return ComercialDL.dtObtenerPagoProveedoresDL(fcuenta, ftrans, fbanco, db);
        }

        public static DataTable Listar_pago_proveedores_BL2(string fcuenta, string ftrans, string freferencia, string ffecha, string fbanco, string db)
        {
            return ComercialDL.dtObtenerPagoProveedoresDL2(fcuenta, ftrans, freferencia, ffecha, fbanco, db);
        }
        //  avila 14/12/2017  frm_aplicaciones
        public static DataTable Listar_aplicaciones_BL(string fini, string ffin, string mproveedor, string db)
        {
            return ComercialDL.dtObtener_aplicacionesDL(fini, ffin, mproveedor,  db);
        }


        #region FACTURACION

        public static DataTable dtObtieneTablaTemporal_BL(string file_sql, string db)
        {
            return ComercialDL.dtObtieneTablaTemporal_DL(file_sql, db);
        }

        public static DataSet dsObtenerTablasFacturacion_BL(DateTime fecha1, DateTime fecha2, string fil1, string fil2, string db)
        {
            try
            {
                DataSet ds_Balance = new DataSet();
                ds_Balance = ComercialDL.dsObtenerTablasFacturacion_DL(fecha1, fecha2, fil1, fil2, db);
                ds_Balance.Tables[0].TableName = "Facturacion";
                return ds_Balance;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }


        #endregion

        #region CUOTA_VENTAS

        // 27/04/2016
        //-------------------------------------------------------------------------------------------

        public static DataTable dtListarVendedoresCuotasFiltradoBL(string zon, string db)
        {
            return ComercialDL.dtListarVendedoresCuotasFiltradoDL(zon, db);
        }

        public static DataTable dtListarTablaClientes2BL(string zon, string act, string ven, string cli, string db)
        {
            return ComercialDL.dtListarTablaClientes2DL(zon, act, ven, cli, db);
        }

        public static DataTable dtListarTablaVendedores2BL(string zon, string act, string ven, string db)
        {
            return ComercialDL.dtListarTablaVendedores2DL(zon, act, ven, db);
        }

        //-------------------------------------------------------------------------------------------


        // 13/04/2016
        public static void EliminarCuotaCentroCostoBL(Int32 id, string cc, string tie, Decimal uni, Decimal mon, string mone, string db)
        {
            ComercialDL.EliminarCuotaCentroCostoDL(id, cc, tie, uni, mon, mone, db);
        }

        public static void UpdateCuotaCentroCostoBL(Int32 id, string cc, string tie, Decimal uni, Decimal mon, string mone, string db)
        {
            ComercialDL.UpdateCuotaCentroCostoDL(id, cc, tie, uni, mon, mone, db);
        }

        public static void InsertarCuotaCentroCostoBL(Int32 id, DateTime fi, DateTime ff, string cc, string tie, string tie_nom, Decimal uni, Decimal mon, string mone, string db)
        {
            ComercialDL.InsertarCuotaCentroCostoDL(id, fi, ff, cc, tie, tie_nom, uni, mon, mone, db);
        }


        public static void EliminarCuotaClienteBL(Int32 id, string cc, string tie, string ven, string cli, string mone, string db)
        {
            ComercialDL.EliminarCuotaClienteDL(id, cc, tie, ven, cli, mone, db);
        }

        public static void EliminarCuotaVendedorBL(Int32 id, string cc, string tie, string ven, string mone, string db)
        {
            ComercialDL.EliminarCuotaVendedorDL(id, cc, tie, ven, mone, db);
        }

        public static void UpdateCuotaClienteBL(Int32 id, string cc, string tie, string ven, string cli, Decimal uni, Decimal mon, string mone, string db)
        {
            ComercialDL.UpdateCuotaClienteDL(id, cc, tie, ven, cli, uni, mon, mone, db);
        }

        public static void InsertarCuotaClienteBL(Int32 id, DateTime fi, DateTime ff, string cc, string tie, string tie_nom,
                                                   string ven, string ven_nom, string cli, string cli_nom, Decimal uni, Decimal mon, string mone, string db)
        {
            ComercialDL.InsertarCuotaClienteDL(id, fi, ff, cc, tie, tie_nom, ven, ven_nom, cli, cli_nom, uni, mon, mone, db);
        }

        public static void UpdateCuotaVendedorBL(Int32 id, string cc, string tie, string ven, Decimal uni, Decimal mon, string mone, string db)
        {
            ComercialDL.UpdateCuotaVendedorDL(id, cc, tie, ven, uni, mon, mone, db);
        }

        public static void InsertarCuotaVendedorBL(Int32 id, DateTime fi, DateTime ff, string cc, string tie, string tie_nom,
                                                   string ven, string ven_nom, Decimal uni, Decimal mon, string mone, string db)
        {
            ComercialDL.InsertarCuotaVendedorDL(id, fi, ff, cc, tie, tie_nom, ven, ven_nom, uni, mon, mone, db);
        }


        public static DataTable CargaDatosClienteBL(string cli, string db)
        {

            return ComercialDL.CargaDatosClienteDL(cli, db);

        }

        public static DataTable CargaDatosVendedorBL(string ven, string db)
        {
            return ComercialDL.CargaDatosVendedorDL(ven, db);
        }

        public static bool ExisteClienteBL(string cli, string db)
        {
            return ComercialDL.ExisteClienteDL(cli, db);
        }

        public static bool ExisteVendedorBL(string ven, string db)
        {
            return ComercialDL.ExisteVendedorDL(ven, db);
        }

        public static DataTable dtListarTablaClientesBL(string db)
        {
            return ComercialDL.dtListarTablaClientesDL(db);
        }

        public static DataTable dtListarTablaVendedoresBL(string db)
        {
            return ComercialDL.dtListarTablaVendedoresDL(db);
        }

        public static DataTable dtListarVendedoresCuotasBL(string db)
        {
            return ComercialDL.dtListarVendedoresCuotasDL(db);
        }

        public static DataTable dtListarCentroCostoCuotasBL(string db)
        {
            return ComercialDL.dtListarCentroCostoCuotasDL(db);
        }

        public static DataTable dtListarZonaCuotasBL(string db)
        {
            return ComercialDL.dtListarZonaCuotasDL(db);
        }

        public static DataTable dtObtenerCuotasporClienteBL(Int32 perio, string centro, string tiend, string vende, string clien, string mone, string db)
        {
            return ComercialDL.dtObtenerCuotasporClienteDL(perio, centro, tiend, vende, clien, mone, db);
        }


        public static DataTable dtObtenerCuotasporVendedorBL(Int32 perio, string centro, string tiend, string vende, string mone, string db)
        {
            return ComercialDL.dtObtenerCuotasporVendedorDL(perio, centro, tiend, vende, mone, db);
        }

        public static DataTable dtObtenerCuotasporCentroCostoBL(Int32 perio, string mone, string db)
        {
            return ComercialDL.dtObtenerCuotasporCentroCostoDL(perio, mone, db);
        }


        public static void EliminarCuotaVentaPorPeriodoBL(Int32 idper, string db)
        {
            ComercialDL.EliminarCuotaVentaPorPeriodoDL(idper, db);
        }

        public static DataTable dtListarCuotaVentasPorPeriodo_BL(Int32 perio, string db)
        {
            return ComercialDL.dtListarCuotaVentasPorPeriodo_DL(perio, db);
        }

        public static bool ExisteInformacionCuotaVentaPorPeriodoBL(Int32 idper, string db)
        {
            return ComercialDL.ExisteInformacionCuotaVentaPorPeriodoDL(idper, db);
        }


        public static DataTable dtObtenerDatoPeriodoBL(string cYear, string cPeriodo, string db)
        {
            return ComercialDL.dtObtenerDatoPeriodoDL(cYear, cPeriodo, db);

        }

        public static DataTable dtObtenerPeriodoVentasBL(string anno, string db)
        {
            return ComercialDL.dtObtenerPeriodoVentasDL(anno, db);

        }

        public static void GrabarCuotasVentas_BL(string tip, Int32 id_per, DateTime fech_ini, DateTime fech_fin, string cen_cos, string tien, string tien_des,
                                                 string vend, string vend_nom, string clie, string clie_nom, string art, string art_des,
                                                 Decimal unid, Decimal mont, string mone, string db)
        {
            ComercialDL.GrabarCuotasVentas_DL(tip, id_per, fech_ini, fech_fin, cen_cos, tien, tien_des, vend, vend_nom, clie, clie_nom,
                                              art, art_des, unid, mont, mone, db);
        }



        public static void GrabarCuotasCC_BL(DateTime fech, string zon, string nomzon, Decimal tie_uni, Decimal tie_mon,
                                             Decimal fur_uni, Decimal fur_mon, Decimal sub_uni, Decimal sub_mon,
                                             Decimal flo_uni, Decimal flo_mon, Decimal tal_uni, Decimal tal_mon, string db)
        {
            ComercialDL.GrabarCuotasCC_DL(fech, zon, nomzon, tie_uni, tie_mon, fur_uni, fur_mon, sub_uni, sub_mon,
                                          flo_uni, flo_mon, tal_uni, tal_mon, db);
        }

        #endregion

        #region LISTA_PRECIO

        // maxmax 01/06/2016
        public static DataTable dtObtenerStockPorBodegasBL(string deta, string fami, string cdb)
        {
            return ComercialDL.dtObtenerStockPorBodegasDL(deta, fami, cdb);
        }

        public static DataTable dtObtenerStockArticulosPorBodegaBL(string artic, string deta, string cdb)
        {
            return ComercialDL.dtObtenerStockArticulosPorBodegaDL(artic, deta, cdb);
        }

        // maxmax 27/05/2016
        public static DataTable dtObtenerListaPreciosActualNuevo3BL(DateTime FecProc, Decimal tipo_camb, string inc_igv, string bodega, string famil, string cdb)
        {
            return ComercialDL.dtObtenerListaPreciosActualNuevo3DL(FecProc, tipo_camb, inc_igv, bodega, famil, cdb);
        }


        // maxmax 23/05/2016
        public static DataTable dtObtenerListaPreciosActualNuevo2BL(DateTime FecProc, Decimal tipo_camb, string inc_igv, string famil, string cdb)
        {
            return ComercialDL.dtObtenerListaPreciosActualNuevo2DL(FecProc, tipo_camb, inc_igv, famil, cdb);
        }

        // maxmax 07/04/2016
        public static DataTable dtObtenerListaPreciosActualNuevoBL(DateTime FecProc, Decimal tipo_camb, string famil, string cdb)
        {
            return ComercialDL.dtObtenerListaPreciosActualNuevoDL(FecProc, tipo_camb, famil, cdb);
        }

        public static DataTable dtListarVersionNivelSugerida_V2BL(string moneda, DateTime dFechaIni, DateTime dFechaFin, string db)
        {
            return ComercialDL.dtListarVersionNivelSugerida_V2DL(moneda, dFechaIni, dFechaFin, db);
        }

        public static void InsertaRegistrosFromTempListaPrecioToArticuloPrecioBL(string file_tmp, string db)
        {
            ComercialDL.InsertaRegistrosFromTempListaPrecioToArticuloPrecioDL(file_tmp, db);
        }

        public static void CrearTablaSQLTempListaPrecioBL(string file_tmp, string db)
        {
            ComercialDL.CrearTablaSQLTempListaPrecioDL(file_tmp, db);
        }

        public static DataTable dtObtenerListaPreciosSolesGeneradaBL(string tmpsql, string cdb)
        {
            return ComercialDL.dtObtenerListaPreciosSolesGeneradaDL(tmpsql, cdb);
        }

        public static DataTable dtObtenerListaPreciosActualV2BL(DateTime FecProc, Decimal tipo_camb, string famil, string cdb)
        {
            return ComercialDL.dtObtenerListaPreciosActualV2DL(FecProc, tipo_camb, famil, cdb);
        }

        public static DataTable CargaDatosArticuloBL(string art, string db)
        {
            return ComercialDL.CargaDatosArticuloDL(art, db);
        }

        public static bool ExisteArticuloBL(string art, string db)
        {
            return ComercialDL.ExisteArticuloDL(art, db);
        }

        public static DataTable dtObtenerArticulosBL(string fami, string subf, string grup, string cdb)
        {
            return ComercialDL.dtObtenerArticulosDL(fami, subf, grup, cdb);
        }

        public static void EliminarArticuloPromocionBL(string art, string db)
        {
            ComercialDL.EliminarArticuloPromocionDL(art, db);
        }

        public static void UpdateArticuloPromocionBL(string art, Decimal pre, DateTime fech, string usu, string db)
        {
            ComercialDL.UpdateArticuloPromocionDL(art, pre, fech, usu, db);
        }

        public static void InsertarArticuloPromocionBL(string art, Decimal pre, DateTime fech, string usu, string db)
        {
            ComercialDL.InsertarArticuloPromocionDL(art, pre, fech, usu, db);
        }

        public static DataTable dtObtenerArticuloPromocionBL(string cdb)
        {
            return ComercialDL.dtObtenerArticuloPromocionDL(cdb);
        }

        // maxmax 05/04/2016
        public static void dtGenerarListaDePrecioSolesBL(string filesqltemp, string cnivel_precio, string cmoneda, Int32 nversion, DateTime dFechaIni, DateTime dFechaFin,
                                                              Decimal ntipo_camb, string corig_niv_prec, string corig_moned, Int32 norig_versi, string cusuario, string db)
        {
            ComercialDL.dtGenerarListaDePrecioSolesDL(filesqltemp, cnivel_precio, cmoneda, nversion, dFechaIni, dFechaFin, ntipo_camb, corig_niv_prec, corig_moned, norig_versi, cusuario, db);
        }

        // maxmax 01/04/2016
        public static void EliminarTipoCambioApssaBL(string tc, DateTime fec, Decimal mon, string db)
        {
            ComercialDL.EliminarTipoCambioApssaDL(tc, fec, mon, db);
        }

        public static void UpdateTipoCambioApssaBL(string tc, DateTime fec, string usua, Decimal mon, string db)
        {
            ComercialDL.UpdateTipoCambioApssaDL(tc, fec, usua, mon, db);
        }

        public static void InsertarTipoCambioApssaBL(string tc, DateTime fec, string usua, Decimal mon, string db)
        {
            ComercialDL.InsertarTipoCambioApssaDL(tc, fec, usua, mon, db);
        }


        public static Decimal ObtieneTipoCambioApssaBL(DateTime fecha_pro, string db)
        {
            return ComercialDL.ObtieneTipoCambioApssaDL(fecha_pro, db);
        }

        // maxmax 28/03/2016
        public static DataTable dtObtenerTipoCambioHistoricoBL(DateTime fecpro, string db)
        {
            return ComercialDL.dtObtenerTipoCambioHistoricoDL(fecpro, db);

        }

        // maxmax 22/03/2016
        public static Decimal ObtieneTipoCambioBL(DateTime fecha_pro, string db)
        {
            return ComercialDL.ObtieneTipoCambioDL(fecha_pro, db);
        }


        public static DataTable dtObtenerListaPreciosActualBL(DateTime FecProc, Decimal tipo_camb, string famil, string cdb)
        {
            return ComercialDL.dtObtenerListaPreciosActualDL(FecProc, tipo_camb, famil, cdb);
        }


        // maxmax 19/03/2016
        public static Int32 GrabarPorcentajesListaPrecioBL(string cnivel_precio, string cfamilia,
             Decimal nmargen_minimo, Decimal nmargen_maximo, Decimal ncosto_prome_increm, string cusuario, string cdb)
        {
            return ComercialDL.GrabarPorcentajesListaPrecioDL(cnivel_precio, cfamilia,
                     nmargen_minimo, nmargen_maximo, ncosto_prome_increm, cusuario, cdb);
        }

        public static void CerearCostoReposicionBL(string db)
        {
            ComercialDL.CerearCostoReposicionDL(db);
        }

        public static DataTable MostrarCostReposBL(string db)
        {
            return ComercialDL.MostrarCostReposDL(db);
        }

        public static DataTable MostrarCostPromBL(string db)
        {
            return ComercialDL.MostrarCostPromDL(db);
        }


        public static DataTable dtGenerarListaDePrecio2BL
                    (string cnivel_precio, string cmoneda, Int32 nversion, DateTime dFechaIni, DateTime dFechaFin,
                     Decimal nmargen_minimo, Decimal nmargen_maximo, Decimal ncosto_prome_increm, Decimal ntipo_camb,
                     string cusuario, string cdb)
        {
            return ComercialDL.dtGenerarListaDePrecio2DL
                    (cnivel_precio, cmoneda, nversion, dFechaIni, dFechaFin,
                     nmargen_minimo, nmargen_maximo, ncosto_prome_increm, ntipo_camb,
                     cusuario, cdb);
        }


        public static DataTable dtListarCostosPromedios2BL(DateTime dFecha, string moneda, string db)
        {
            return ComercialDL.dtListarCostosPromedios2DL(dFecha, moneda, db);
        }


        public static Tmp_CostProm ProcesaTmp_CostProm(Tmp_CostProm tmpcostprom, string db)       // temporal   
        {
            return ComercialDL.ProcesaTmp_CostProm(tmpcostprom, db);
        }


        public static Tmp_CostRepos ProcesaTmp_CostRepos(Tmp_CostRepos tmpcostrepos, string db)    // temporal         
        {
            return ComercialDL.ProcesaTmp_CostRepos(tmpcostrepos, db);
        }


        public static void DeleteTmp_CostProm(string db)
        {
            ComercialDL.DeleteTmp_CostProm(db);
        }

        public static void DeleteTmp_CostRepos(string db)
        {
            ComercialDL.DeleteTmp_CostRepos(db);
        }

        public static Int32 GrabarParametrosListaPrecioBL(string cnivel_precio, string cmoneda,
             Decimal nmargen_minimo, Decimal nmargen_maximo, Decimal ncosto_prome_increm, string cusuario, string cdb)
        {
            return ComercialDL.GrabarParametrosListaPrecioDL(cnivel_precio, cmoneda,
                     nmargen_minimo, nmargen_maximo, ncosto_prome_increm, cusuario, cdb);
        }

        public static Int32 GrabarListaDePrecioBL
                    (string cnivel_precio, string cmoneda, Int32 nversion,
                     string carticulo, Int32 carticulo_version,
                     DateTime dFechaIni, DateTime dFechaFin,
                     Decimal nprecio, Decimal nmargen_mulr, Decimal nmargen_utilidad, Decimal nmargen_utilidad_min,
                     string cusuario, string cdb)
        {
            return ComercialDL.GrabarListaDePrecioDL
                    (cnivel_precio, cmoneda, nversion,
                     carticulo, carticulo_version,
                     dFechaIni, dFechaFin,
                     nprecio, nmargen_mulr, nmargen_utilidad, nmargen_utilidad_min,
                     cusuario, cdb);
        }


        public static Int32 GrabarVersionNivelBL
                    (string cnivel_precio, string cmoneda, Int32 nversion,
                     string cestado, string cimpuesto,
                     DateTime dFechaIni, DateTime dFechaFin, string cusuario, string cdb)
        {
            return ComercialDL.GrabarVersionNivelDL
                    (cnivel_precio, cmoneda, nversion,
                     cestado, cimpuesto,
                     dFechaIni, dFechaFin, cusuario, cdb);
        }


        public static DataTable dtGenerarListaDePrecioBL
                    (string cnivel_precio, string cmoneda, Int32 nversion,
                     Decimal nmargen_minimo, Decimal nmargen_maximo, Decimal ncosto_prome_increm,
                     DateTime dFechaIni, DateTime dFechaFin, string cusuario, string cdb)
        {
            return ComercialDL.dtGenerarListaDePrecioDL
                    (cnivel_precio, cmoneda, nversion,
                     nmargen_minimo, nmargen_maximo, ncosto_prome_increm,
                     dFechaIni, dFechaFin, cusuario, cdb);
        }

        public static DataTable dtListarVersionNivelSugeridaBL(string moneda, DateTime dFechaIni, DateTime dFechaFin, string db)
        {
            return ComercialDL.dtListarVersionNivelSugeridaDL(moneda, dFechaIni, dFechaFin, db);
        }

        public static DataTable dtListarCostosPromediosBL(DateTime dFecha, string moneda, string db)
        {
            return ComercialDL.dtListarCostosPromediosDL(dFecha, moneda, db);
        }

        public static DataTable dtListarParametrosNivelPreciosBL(string moneda, string db)
        {
            return ComercialDL.dtListarParametrosNivelPreciosDL(moneda, db);
        }

        /*         */

        public static DataTable dtListarPorcentajeNivelPreciosBL(string nivel_precio, Int32 version, string moneda, string db)
        {
            return ComercialDL.dtListarPorcentajeNivelPreciosDL(nivel_precio, version, moneda, db);
        }

        #endregion

        //#region LISTA_PRECIO anterior
        //public static Int32 GrabarParametrosListaPrecioBL(string cnivel_precio, string cmoneda,
        //     Decimal nmargen_minimo, Decimal nmargen_maximo, Decimal ncosto_prome_increm, string cusuario, string cdb)
        //{
        //    return ComercialDL.GrabarParametrosListaPrecioDL(cnivel_precio, cmoneda,
        //             nmargen_minimo, nmargen_maximo, ncosto_prome_increm, cusuario, cdb);
        //}

        //public static Int32 GrabarListaDePrecioBL
        //            (string cnivel_precio, string cmoneda, Int32 nversion,
        //             string carticulo, Int32 carticulo_version,
        //             DateTime dFechaIni, DateTime dFechaFin,
        //             Decimal nprecio, Decimal nmargen_mulr, Decimal nmargen_utilidad, Decimal nmargen_utilidad_min,
        //             string cusuario, string cdb)
        //{
        //    return ComercialDL.GrabarListaDePrecioDL
        //            (cnivel_precio, cmoneda, nversion,
        //             carticulo, carticulo_version,
        //             dFechaIni, dFechaFin,
        //             nprecio, nmargen_mulr, nmargen_utilidad, nmargen_utilidad_min,
        //             cusuario, cdb);
        //}


        //public static Int32 GrabarVersionNivelBL
        //            (string cnivel_precio, string cmoneda, Int32 nversion,
        //             string cestado, string cimpuesto,
        //             DateTime dFechaIni, DateTime dFechaFin, string cusuario, string cdb)
        //{
        //    return ComercialDL.GrabarVersionNivelDL
        //            (cnivel_precio, cmoneda, nversion,
        //             cestado, cimpuesto,
        //             dFechaIni, dFechaFin, cusuario, cdb);
        //}


        //public static DataTable dtGenerarListaDePrecioBL
        //            (string cnivel_precio, string cmoneda, Int32 nversion,
        //             Decimal nmargen_minimo, Decimal nmargen_maximo, Decimal ncosto_prome_increm,
        //             DateTime dFechaIni, DateTime dFechaFin, string cusuario, string cdb)
        //{
        //    return ComercialDL.dtGenerarListaDePrecioDL
        //            (cnivel_precio, cmoneda, nversion,
        //             nmargen_minimo, nmargen_maximo, ncosto_prome_increm,
        //             dFechaIni, dFechaFin, cusuario, cdb);
        //}

        //public static DataTable dtListarVersionNivelSugeridaBL(string moneda, DateTime dFechaIni, DateTime dFechaFin, string db)
        //{
        //    return ComercialDL.dtListarVersionNivelSugeridaDL(moneda, dFechaIni, dFechaFin, db);
        //}

        //public static DataTable dtListarCostosPromediosBL(DateTime dFecha, string moneda, string db)
        //{
        //    return ComercialDL.dtListarCostosPromediosDL(dFecha, moneda, db);
        //}

        //public static DataTable dtListarParametrosNivelPreciosBL(string moneda, string db)
        //{
        //    return ComercialDL.dtListarParametrosNivelPreciosDL(moneda, db);
        //}
        //#endregion

        #region VARIOS

        public static DataSet MostrarBoletaFalla(string boleta, string db)
        {
            try
            {
                DataSet ds_falla = new DataSet();
                ds_falla = ComercialDL.MostrarBoletaFalla(boleta,db);
                ds_falla.Tables[0].TableName = "ds_falla";
                return ds_falla;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }

        }

        public static DataSet MostrarDetalleComisiones(DateTime fecha1, DateTime fecha2, string zona, string tecnico, string db)
        {
            try
            {
                return ComercialDL.MostrarDetalleComisiones(fecha1, fecha2, zona, tecnico, db);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public static DataSet CargaDatosEstado(string estado, string db)
        {
            try
            {
                return ComercialDL.CargaDatosEstado(estado, db);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }  

        public static DataSet ListaEstado(string db)
        {
            try
            {
                DataSet ds_esta = new DataSet();
                ds_esta = ComercialDL.ListaEstado(db);
                ds_esta.Tables[0].TableName = "esta";
                return ds_esta;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public static DataSet CargaDatosDepartamento(string codzona, string db)
        {
            try
            {
                return ComercialDL.CargaDatosDepartamento(codzona, db);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }  

        public static DataSet ListaDepartamento(string db)
        {
            try
            {
                DataSet ds_depar = new DataSet();
                ds_depar = ComercialDL.ListaDepartamento(db);
                ds_depar.Tables[0].TableName = "depar";
                return ds_depar;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public static DataSet CargaDatosLocalizacion(string codbodega, string db)
        {
            try
            {
                return ComercialDL.CargaDatosLocalizacion(codbodega, db);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }  

        public static DataSet ListaLocalizacion(string db)
        {
            try
            {
                DataSet ds_local = new DataSet();
                ds_local = ComercialDL.ListaLocalizacion(db);
                ds_local.Tables[0].TableName = "local";
                return ds_local;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public static DataSet CargaDatosTienda(string codzona, string db)
        {
            try
            {
                return ComercialDL.CargaDatosTienda(codzona, db);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }  

        public static DataSet ListaTiendas(string db)
        {
            try
            {
                DataSet ds_tienda = new DataSet();
                ds_tienda = ComercialDL.ListaTiendas(db);
                ds_tienda.Tables[0].TableName = "tienda";
                return ds_tienda;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public static DataSet CargaDatoVendedor(string codigov, string db)  
        {
            try
            {
                return ComercialDL.CargaDatoVendedor(codigov,db);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public static DataSet ListarTecnico(string tienda, string tecnico, string db)
        {
            try
            {
                return ComercialDL.ListarTecnico(tienda, tecnico, db);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public static DataSet ListarVendedor(string tienda, string vendedor, string db)
        {
            try
            {
                return ComercialDL.ListarVendedor(tienda, vendedor,db);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public static DataSet CargaExcel(string RutaExcelBL, string NombreHojaBL)
        {
            try
            {
                DataSet ds_le = new DataSet();
                //ds_le = AccesoGeneralDL.CargaExcel(RutaExcelBL, NombreHojaBL);
                ds_le = CargaExcel(RutaExcelBL, NombreHojaBL);
                ds_le.Tables[0].TableName = "listaexcel";
                return ds_le;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }

        }

        public static DataTable Listar_Facturas_PDF_BL(string fechai_bl, string fechaf_bl, string cliente_bl, string nombre_bl,string nd_bl, string bd)
        {//ANDY
            try
            {
                DataSet ds = new DataSet();
                return ComercialDL.Listar_Facturas_PDF(fechai_bl, fechaf_bl, cliente_bl, nombre_bl,nd_bl, bd);
                //ds = ComercialDL.Listar_Facturas_PDF(fechai_bl, fechaf_bl, cliente_bl, nombre_bl, bd);
                //ds.Tables[0].TableName = "TBL";

            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }

        }

        #endregion

        #region GRABAR ORDEN_SERVICIO

        public static DataSet CargaOrdenCabecera(string pedido, string db)
        {
            try
            {
                DataSet ds_os = new DataSet();
                ds_os = ComercialDL.CargaOrdenCabecera(pedido, db);
                ds_os.Tables[0].TableName = "listaordencab";
                return ds_os;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public static DataSet CargaOrdenLinea(string pedido, Int32 linea, string db)
        {
            try
            {
                DataSet ds_osl = new DataSet();
                ds_osl = ComercialDL.CargaOrdenLinea(pedido, linea, db);
                ds_osl.Tables[0].TableName = "listaordenlinea";
                return ds_osl;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public static Orden_Servicio AgregarOrdenCabecera(Orden_Servicio orden_servicio, string db)
        {
            return ComercialDL.AgregarOrdenCabecera(orden_servicio, db);
        }

        public static Orden_Servicio_Linea AgregarOrdenLinea(Orden_Servicio_Linea orden_servicio_linea, string db)
        {
            return ComercialDL.AgregarOrdenLinea(orden_servicio_linea, db);
        }


        public static bool ValidarPedidoTieneOrdenServicio(string pedido, string db)
        {
            if (ComercialDL.ValidarPedidoTieneOrdenServicio(pedido, db))
                return true;    
            else
                return false;
        }

        public static bool ValidarExisteOrdenServicio(string oserv, string db)
        {
            if (ComercialDL.ValidarExisteOrdenServicio(oserv, db))
                return true;    
            else
                return false;
        }

        public static void GrabarNumeroOrden(string codigoz, string orden, string db)
        {
            ComercialDL.GrabarNumeroOrden(codigoz, orden, db);
        }

        public static string VerificaNumeroOrden(string codzona, string db)
        {
            try
            {
                return ComercialDL.VerificaNumeroOrden(codzona, db);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public static DataSet CargaNumeroOrden(string codigoz, string db)
        {
            try
            {
                return ComercialDL.CargaNumeroOrden(codigoz, db);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public static void GrabarPedido(string pedido, string orden, string db)
        {
            try
            {
                ComercialDL.GrabarPedido(pedido, orden, db);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public static void GrabarPedidoDetalle(string pedido, string orden, string estado, string db)
        {
            try
            {
                ComercialDL.GrabarPedidoDetalle(pedido, orden, estado, db);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public static void GrabarPedidoDetallePorItem(string pedido, string orden, string tecnico, string articulo, Int32 linea, string db)
        {
            ComercialDL.GrabarPedidoDetallePorItem(pedido, orden, tecnico, articulo, linea, db);
        }

        public static void GrabarBoletaServicio(string boleta, string orden, string estado, string departamento, string usuario, string notas, string horas, string db)
        {
            ComercialDL.GrabarBoletaServicio(boleta, orden, estado, departamento, usuario, notas, horas, db);
        }

        public static void GrabarBoletaEstado(string boleta, Int32 orden_asignac, string usuario, string estado,
                                              DateTime fec_hr_inicio, DateTime fec_hr_original, string usuario_modifica, string db)        
        {
            ComercialDL.GrabarBoletaEstado(boleta, orden_asignac, usuario, estado,
                                              fec_hr_inicio, fec_hr_original, usuario_modifica, db);  
        }


        public static void GrabarBoletaFalla(string falla, string tipo_equipo_cs, string boleta, string usuario,
                                             string detalle_falla, string solucion_falla, string confirmada, string db)        
        {
            ComercialDL.GrabarBoletaFalla(falla, tipo_equipo_cs, boleta, usuario,
                                             detalle_falla, solucion_falla, confirmada, db);  
        }         

        #endregion

        #region ORDEN_SERVICIO

        public static DataSet Obtener_OS_Pedido_Detalle_BL(DateTime fecha1, DateTime fecha2, string zona, string tecnico, string anulado, string db)
        {
            try
            {
                return ComercialDL.Obtener_OS_Pedido_Detalle_DL(fecha1, fecha2, zona, tecnico, anulado, db);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        
        public static string ObtenerPedidoConOrden_BL(string oser, string db)
        {
            return ComercialDL.ObtenerPedidoConOrden_DL(oser, db);
        }


        public static string ObtenerOrdenServicioPreferencia_BL(string mod, string apl, string par, string db)
        {
            return ComercialDL.ObtenerOrdenServicioPreferencia_DL(mod, apl, par, db);
        }

        public static DataSet OS_SinFacturar(DateTime fecha1, DateTime fecha2, string zona, string tecnico, string anulado, string db)
        {
            try
            {
                return ComercialDL.OS_SinFacturar(fecha1, fecha2, zona, tecnico, anulado, db);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public static DataSet OS_SinFacturarDetalle(DateTime fecha1, DateTime fecha2, string zona, string tecnico, string anulado, string db)
        {
            try
            {
                return ComercialDL.OS_SinFacturarDetalle(fecha1, fecha2, zona, tecnico, anulado, db);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        } 

        public static void AnularOrden_GrabaReferenciaBL(string orden, string pedido, string ref_orden, string ref_pedido, string obs, string db)
        {
            try
            {
                ComercialDL.AnularOrden_GrabaReferenciaDL(orden, pedido, ref_orden, ref_pedido, obs, db);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }          
        
        public static DataSet OrdenServicioAnulados(DateTime fecha1, DateTime fecha2, string zona, string tecnico, string db)
        {
            try
            {
                return ComercialDL.OrdenServicioAnulados(fecha1, fecha2, zona, tecnico, db);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public static DataSet OrdenServicioAnuladosDetalle(DateTime fecha1, DateTime fecha2, string zona, string tecnico, string db)
        {
            try
            {
                return ComercialDL.OrdenServicioAnuladosDetalle(fecha1, fecha2, zona, tecnico, db);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public static DataSet OrdenServicioSinFacturar(DateTime fecha1, DateTime fecha2, string zona, string tecnico, string anulado, string db)
        {
            try
            {
                return ComercialDL.OrdenServicioSinFacturar(fecha1, fecha2, zona, tecnico, anulado, db);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public static DataSet OrdenServicioSinFacturarDetalle(DateTime fecha1, DateTime fecha2, string zona, string tecnico, string anulado, string db)
        {
            try
            {
                return ComercialDL.OrdenServicioSinFacturarDetalle(fecha1, fecha2, zona, tecnico, anulado, db);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }   

        public static void UpdateBoletaEstado(string boleta, Int32 orden_asignacion, string usuario, string estado,
                                              DateTime fec_hr_inicio, DateTime fec_hr_original, string usuario_modifica, string db)
        {            
            try
            {
                ComercialDL.UpdateBoletaEstado(boleta, orden_asignacion, usuario, estado,
                                              fec_hr_inicio, fec_hr_original, usuario_modifica, db);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }          
        }


        public static void EliminaOrdenServicioLinea(string orden, string db)
        {            
            try
            {
                ComercialDL.EliminaOrdenServicioLinea(orden, db);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }          
        }

        public static DataSet Mostrar_PedidoUpdateOrdenServicioDetalle(string orden, string db)
        {
            try
            {
                return ComercialDL.Mostrar_PedidoUpdateOrdenServicioDetalle(orden, db);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }         


        public static void LiberarOrdenServicio(string orden, string pedido, string db)
        {            
            try
            {
                ComercialDL.LiberarOrdenServicio(orden, pedido, db);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }          
        }


        public static void AnularOrdenServicio(string orden, string pedido, string db)
        {            
            try
            {
                ComercialDL.AnularOrdenServicio(orden, pedido, db);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }          
        }


        public static DataSet CargaOrdenServicioVacio(string db)
        {
            try
            {
                DataSet ds_lvordser = new DataSet();
                ds_lvordser = ComercialDL.CargaBoletaServicioVacio(db);
                ds_lvordser.Tables[0].TableName = "listavaciaordser";
                return ds_lvordser;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }

        }

        public static DataSet CargaOrdenServicioDetalleVacio(string db)
        {
            try
            {
                DataSet ds_lvordserdet = new DataSet();
                ds_lvordserdet = ComercialDL.CargaOrdenServicioDetalleVacio(db);
                ds_lvordserdet.Tables[0].TableName = "listavaciaordserdet";
                return ds_lvordserdet;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }

        }

        public static DataSet ListarOrdenServicio(DateTime fecha1, DateTime fecha2, string zona, string cliente, string db)
        {
            try
            {
                return ComercialDL.ListarOrdenServicio(fecha1, fecha2, zona, cliente, db);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public static DataSet ListarOrdenServicioDetalle(string orden, string db)
        {
            try
            {
                return ComercialDL.ListarOrdenServicioDetalle(orden, db);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public static DataSet MostrarOrdenServicioDetalle(string orden, string db)
        {
            try
            {
                return ComercialDL.MostrarOrdenServicioDetalle(orden, db);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        #endregion

        #region BOLETA_SERVICIO

        public static DataSet CargaBoletaServicioVacio(string db)
        {
            try
            {
                DataSet ds_lvser = new DataSet();
                ds_lvser = ComercialDL.CargaBoletaServicioVacio(db);
                ds_lvser.Tables[0].TableName = "listavaciaser";
                return ds_lvser;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }

        }

        public static DataSet CargaBoletaServicioDetalleVacio(string db)
        {
            try
            {
                DataSet ds_lvserdet = new DataSet();
                ds_lvserdet = ComercialDL.CargaBoletaServicioDetalleVacio(db);
                ds_lvserdet.Tables[0].TableName = "listavaciaserdet";
                return ds_lvserdet;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }

        }

        public static DataSet ListarBoletaServicio(DateTime fecha1, DateTime fecha2, string zona, string cliente, string db)
        {
            try
            {
                return ComercialDL.ListarBoletaServicio(fecha1, fecha2, zona, cliente, db);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public static DataSet ListarBoletaServicioDetalle(string servicio, string db)
        {
            try
            {
                return ComercialDL.ListarBoletaServicioDetalle(servicio, db);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public static DataSet MostrarBoletaServicioDetalle(string servicio, string db)
        {
            try
            {
                return ComercialDL.MostrarBoletaServicioDetalle(servicio,db);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        #endregion

        #region PEDIDOS
        public static DataSet CargaTipoVehiculo(string db)
        {
            try
            {
                DataSet ds_listv = new DataSet();
                ds_listv = ComercialDL.CargaTipoVehiculo(db);
                ds_listv.Tables[0].TableName = "listv";
                return ds_listv;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }

        }

        public static void GrabaPedidoVehiculo(string pedidoveh, string posicion, string dni, string nombre,
                                               string apellido, string direccion, string email, string telefono,
                                               string placa, string tipovehiculo, string modelo, string marca,
                                               Int32 kilometraje, string chasis, string entregado, string serviciomina, string db)
        {
            ComercialDL.GrabaPedidoVehiculo(pedidoveh, posicion, dni, nombre,
                                            apellido, direccion, email, telefono,
                                            placa, tipovehiculo, modelo, marca,
                                            kilometraje, chasis, entregado, serviciomina, db);
        }

        public static DataSet MostrarPedidoVehiculo(string pedidoveh, string db)
        {
            try
            {
                return ComercialDL.MostrarPedidoVehiculo(pedidoveh, db);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }        

        public static DataSet CargaPedidoVacio(string db)
        {
            try
            {
                DataSet ds_lvped = new DataSet();
                ds_lvped = ComercialDL.CargaPedidoVacio(db);
                ds_lvped.Tables[0].TableName = "listavaciaped";
                return ds_lvped;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }

        }

        public static DataSet CargaPedidoDetalleVacio(string db)
        {
            try
            {
                DataSet ds_lvpeddet = new DataSet();
                ds_lvpeddet = ComercialDL.CargaPedidoDetalleVacio(db);
                ds_lvpeddet.Tables[0].TableName = "listavaciapeddet";
                return ds_lvpeddet;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }

        }

        public static DataSet ListarPedido(string tipodoc, DateTime fecha1, DateTime fecha2, string zona, string cliente, string db)
        {
            try
            {
                return ComercialDL.ListarPedido(tipodoc, fecha1, fecha2, zona, cliente, db);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public static DataSet ListarPedidoDetalle(string pedido, string db)
        {
            try
            {
                return ComercialDL.ListarPedidoDetalle(pedido, db);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public static DataSet MostrarPedidoDetalle(string pedido, string db)
        {
            try
            {
                return ComercialDL.MostrarPedidoDetalle(pedido, db);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }


        #endregion

        #region COTIZACION

        public static DataSet CargaCotizacionVacio(string db)
        {
            try
            {
                DataSet ds_lvcot = new DataSet();
                ds_lvcot = ComercialDL.CargaCotizacionVacio(db);
                ds_lvcot.Tables[0].TableName = "listavaciacot";
                return ds_lvcot;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public static DataSet CargaCotizacionDetalleVacio(string db)
        {
            try
            {
                DataSet ds_lvcotdet = new DataSet();
                ds_lvcotdet = ComercialDL.CargaCotizacionDetalleVacio(db);
                ds_lvcotdet.Tables[0].TableName = "listavaciacotdet";
                return ds_lvcotdet;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public static DataSet ListarCotizacion(string tipodoc, DateTime fecha1, DateTime fecha2, string zona, string cliente, string db)
        {
            try
            {
                return ComercialDL.ListarCotizacion(tipodoc, fecha1, fecha2, zona, cliente, db);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public static DataSet ListarCotizacionDetalle(string cotizacion, string db)
        {
            try
            {
                return ComercialDL.ListarCotizacionDetalle(cotizacion, db);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public static DataSet MostrarCotizacionDetalle(string cotizacion, string db)
        {
            try
            {
                return ComercialDL.MostrarCotizacionDetalle(cotizacion, db);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }


        #endregion

        #region CARGAR_LISTA_PRECIOS
        public static bool ExisteListaPrecioVersion(string lNIVEL_PRECIO, string lMONEDA, string lVERSION, string db)
        {
            if (ComercialDL.ExisteListaPrecioVersion(lNIVEL_PRECIO, lMONEDA, lVERSION, db))
                return true;    //ComercialDL.ExisteListaPrecioVersion(lNIVEL_PRECIO,lMONEDA,lVERSION);
            else
                return false;

        }

        public static DataSet Listar_NivelPrecio(string db)
        {
            try
            {
                DataSet ds_np = new DataSet();
                ds_np = ComercialDL.Listar_NivelPrecio(db);
                ds_np.Tables[0].TableName = "lstnivelprecio";
                return ds_np;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public static DataSet Listar_Monedas(string db)
        {
            try
            {
                DataSet ds_mo = new DataSet();
                ds_mo = ComercialDL.Listar_Monedas(db);
                ds_mo.Tables[0].TableName = "lstmoneda";
                return ds_mo;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }

        }

        public static DataSet Listar_ListaPrecio(string db)
        {
            try
            {
                DataSet ds_lp = new DataSet();
                ds_lp = ComercialDL.Listar_ListaPrecio(db);
                ds_lp.Tables[0].TableName = "lstlistaprecio";
                return ds_lp;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }

        }

        public static DataSet CargaListaVacia(string db)
        {
            try
            {
                DataSet ds_lv = new DataSet();
                ds_lv = ComercialDL.CargaListaVacia(db);
                ds_lv.Tables[0].TableName = "listavacia";
                return ds_lv;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }

        }

        public static DataSet CargaListaDatos(string Condicion1_bl, string db)
        {
            try
            {
                DataSet ds_ld = new DataSet();
                ds_ld = ComercialDL.CargaListaDatos(Condicion1_bl, db);
                ds_ld.Tables[0].TableName = "listadatos";
                return ds_ld;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public static Articulo_Precio AgregarFila(Articulo_Precio listapre, string db)
        {
            return ComercialDL.AgregarFila(listapre, db);
        }

        public static Articulo_Precio AgregarFila_SP(Articulo_Precio listapre, string db)
        {
            return ComercialDL.AgregarFila_SP(listapre, db);
        }

        #endregion

        #region COMISION TALLER

        public static Int32 GrabarTecnicoComisione_BL(string _tecnico, string _articulo, Decimal _comision, string _alcance, string _estado, string _observaciones, string db)
        {
            return ComercialDL.GrabarTecnicoComisione_DL(_tecnico, _articulo, _comision, _alcance, _estado, _observaciones, db);
        }

        public static DataTable CargaTecnicoComisiones_BL(string db)
        {
            return ComercialDL.CargaTecnicoComisiones_DL(db);
        }

        public static Int32 GrabarComisionesTaller_BL(DateTime fecha_ini, DateTime fecha_fin, string db)
        {
            return ComercialDL.GrabarComisionesTaller_DL(fecha_ini, fecha_fin, db);
        }

        public static Int32 GrabarComisionesTaller2_BL(
                        DateTime fecha_ini, DateTime fecha_fin, string tipo_fac, string factura, DateTime fecha_fac, DateTime fecha_os, string oservicio, Int32 oservicio_linea,
                        string articulo, Decimal monto_soles, Decimal monto_dolares, Decimal porc_comis, Decimal comision_soles, string u_tecnico, string tipo_tecnico,
                        string estado_servicio, string pedido, Int32 pedido_linea, string boleta_cs, string bodega, string zona, string db)
        {
            return ComercialDL.GrabarComisionesTaller2_DL(fecha_ini, fecha_fin, tipo_fac, factura, fecha_fac, fecha_os, oservicio, oservicio_linea,
                                articulo, monto_soles, monto_dolares, porc_comis, comision_soles, u_tecnico, tipo_tecnico,
                                estado_servicio, pedido, pedido_linea, boleta_cs, bodega, zona, db);
        }


        public static DataTable DetalleComisionTaller2_BL(string origen, DateTime fecha1, DateTime fecha2, string zona, string tecnico, string db)
        {
            return ComercialDL.DetalleComisionTaller2_DL(origen, fecha1, fecha2, zona, tecnico, db);
        }


        public static DataTable ResumenComisionTecnicos2_BL(string origen, DateTime fecha1, DateTime fecha2, string zona, string tecnico, string db)
        {
            return ComercialDL.ResumenComisionTecnicos2_DL(origen, fecha1, fecha2, zona, tecnico, db);
        }

        public static DataTable ResumenComisionJefes2_BL(string origen, DateTime fecha1, DateTime fecha2, string zona, string tecnico, string db)
        {
            return ComercialDL.ResumenComisionJefes2_DL(origen, fecha1, fecha2, zona, tecnico, db);
        }

        public static DataSet DetalleComisionTallerBL(string origen, DateTime fecha1, DateTime fecha2, string zona, string tecnico, string db)
        {
            try
            {
                DataSet ds_comtaller1 = new DataSet();
                ds_comtaller1 = ComercialDL.DetalleComisionTallerDL(origen, fecha1, fecha2, zona, tecnico, db);
                ds_comtaller1.Tables[0].TableName = "Comision1";
                return ds_comtaller1;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public static DataSet ResumenComisionTecnicosBL(string origen, DateTime fecha1, DateTime fecha2, string zona, string tecnico, string db)
        {
            try
            {
                DataSet ds_comtaller2 = new DataSet();
                ds_comtaller2 = ComercialDL.ResumenComisionTecnicosDL(origen, fecha1, fecha2, zona, tecnico, db);
                ds_comtaller2.Tables[0].TableName = "Comision2";
                return ds_comtaller2;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public static DataSet ResumenComisionJefesBL(string origen, DateTime fecha1, DateTime fecha2, string zona, string tecnico, string db)
        {
            try
            {
                DataSet ds_comtaller3 = new DataSet();
                ds_comtaller3 = ComercialDL.ResumenComisionJefesDL(origen, fecha1, fecha2, zona, tecnico, db);
                ds_comtaller3.Tables[0].TableName = "Comision3";
                return ds_comtaller3;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public static DataSet ProcesaComisionTallerBL(DateTime fecha1, DateTime fecha2, string zona, string tecnico, string db)
        {
            try
            {
                DataSet ds_comtaller = new DataSet();
                ds_comtaller = ComercialDL.ProcesaComisionTallerDL(fecha1, fecha2, zona, tecnico, db);
                ds_comtaller.Tables[0].TableName = "Comision";
                return ds_comtaller;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        #endregion

        #region COMISION_FLOTAS_RRHH   UPDATE 06/07/2018, PARA frmComisionesATF_V3

        public static void InsertarVendedorPeriodoBL(Int32 id, string vend, string db)
        {
            ComercialDL.InsertarVendedorPeriodoDL(id, vend, db);
        }

        public static bool VerificarVendedorPeriodoBL(string _vendedor, string _periodo, string db)
        {
            return ComercialDL.VerificarVendedorPeriodoDL(_vendedor, _periodo, db);
        }


        public static DataTable dtObtenerVendedores_BL(string db)
        {
            return ComercialDL.dtObtenerVendedores_DL(db);
        }

        public static DataTable dtObtenerCentroCosto_BL(string db)
        {
            return ComercialDL.dtObtenerCentroCosto_DL(db);
        }

        #endregion

        #region COMISION_FLOTAS NUEVO   UPDATE 08/08/2016, PARA frmComisionesATF

        public static DataTable dtObtenerVendedoresATF_BL(Int32 idper, string db)
        {
            return ComercialDL.dtObtenerVendedoresATF_DL(idper, db);
        }

        public static DataTable dtObtenerReporteComisionesATF_BL(DateTime dFecha1, DateTime dFecha2, string creporte, string db)
        {
            return ComercialDL.dtObtenerReporteComisionesATF_DL(dFecha1, dFecha2, creporte, db);
        }

        //ObtieneComisionesATF(archivo_sql_tmp_atf);
        //ObtieneComisionesATF_Jefes(archivo_sql_tmp_atf_jefe);
        //ObtieneComisionesDetalle(archivo_sql_tmp_atf_detalle);

        public static DataTable dtObtieneComisionesVendedoresATF_BL(string file1_sql, string db)
        {
            return ComercialDL.dtObtieneComisionesVendedoresATF_DL(file1_sql, db);
        }

        public static DataTable ObtenerCuotasATF_BL(Int32 idperiodo, string db)
        {
            try
            {
                DataTable dt_Comision = new DataTable();
                dt_Comision = ComercialDL.ObtenerCuotasATF_DL(idperiodo, db);
                dt_Comision.TableName = "Comision";
                return dt_Comision;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public static DataTable ObtenerVentasFlotasATF_BL(Int32 didper, DateTime dFechaIni, DateTime dFechaFin, DateTime dFechaP, string db)
        {
            try
            {
                DataTable dt_vtaatf = new DataTable();
                dt_vtaatf = ComercialDL.ObtenerVentasFlotasATF_DL(didper, dFechaIni, dFechaFin, dFechaP, db);
                dt_vtaatf.TableName = "VtaFlotas";
                return dt_vtaatf;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public static DataSet ProcesaComisionATF2_BL(string cActualiza, Int32 idperiodo, DateTime dFechaIni, DateTime dFechaFin, DateTime dFechaP, string atf, string jefe, string deta, string db)
        {
            try
            {
                DataSet ds_Comision = new DataSet();
                ds_Comision = ComercialDL.ProcesaComisionATF2_DL(cActualiza, idperiodo, dFechaIni, dFechaFin, dFechaP, atf, jefe, deta, db);  //PENDIENTE
                ds_Comision.Tables[0].TableName = "Comision";
                return ds_Comision;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public static DataSet ProcesaComisionATF_BL(string cActualiza, Int32 idperiodo, DateTime dFechaIni, DateTime dFechaFin, DateTime dFechaP, string atf, string jefe, string deta, string db)
        {
            try
            {
                DataSet ds_Comision = new DataSet();
                ds_Comision = ComercialDL.ProcesaComisionATF_DL(cActualiza, idperiodo, dFechaIni, dFechaFin, dFechaP, atf, jefe, deta, db);  //PENDIENTE
                ds_Comision.Tables[0].TableName = "Comision";
                return ds_Comision;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        #endregion

        #region COMISION_FLOTAS    UPDATE 29/02/2016, PARA frmComisionesFlotas_V4

        public static DataTable dtObtenerResumenReporteFlotas_BL(DateTime dFecha1, DateTime dFecha2, string creporte, string db)
        {
            return ComercialDL.dtObtenerResumenReporteFlotas_DL(dFecha1, dFecha2, creporte, db);
        }


        public static DataSet ObtenerResumenFlotas_BL(DateTime dFecha1, DateTime dFecha2, DateTime dFechaP, string db)
        {
            try
            {
                DataSet ds_Flotas = new DataSet();
                ds_Flotas = ComercialDL.ObtenerResumenFlotas_DL(dFecha1, dFecha2, dFechaP, db);
                ds_Flotas.Tables[0].TableName = "Flotas";
                return ds_Flotas;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public static DataSet ObtenerVentasFlotas_V4_BL(DateTime dFechaIni, DateTime dFechaFin, DateTime dFechaP, string cfami1, string cfami2, string db)
        {
            try
            {
                DataSet ds_Flotas = new DataSet();
                ds_Flotas = ComercialDL.ObtenerVentasFlotas_V4_DL(dFechaIni, dFechaFin, dFechaP, cfami1, cfami2, db);
                ds_Flotas.Tables[0].TableName = "Flotas";
                return ds_Flotas;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public static DataSet ProcesaComision_V4_BL(string cActualiza, DateTime dFechaIni, DateTime dFechaFin, DateTime dFechaP, string db)
        {
            try
            {
                DataSet ds_Comision = new DataSet();
                ds_Comision = ComercialDL.ProcesaComision_V4_DL(cActualiza, dFechaIni, dFechaFin, dFechaP, db);  //PENDIENTE
                ds_Comision.Tables[0].TableName = "Comision";
                return ds_Comision;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }


        //***********************************************************************************************************************************



        public static DataTable dtRecuperaComisionesTaller_BL(DateTime f1, DateTime f2, string opcion, string db)
        {
            return ComercialDL.dtRecuperaComisionesTaller_DL(f1, f2, opcion, db);
        }

        public static DataTable dtRecuperarComisionesTallerDetalle_BL(DateTime f1, DateTime f2, string db)
        {
            return ComercialDL.dtRecuperarComisionesTallerDetalle_DL(f1, f2, db);
        }

        public static DataTable dtRecuperarComisionesTallerTecnico_BL(DateTime f1, DateTime f2, string db)
        {
            return ComercialDL.dtRecuperarComisionesTallerTecnico_DL(f1, f2, db);
        }

        public static DataTable dtRecuperarComisionesTallerJefeTaller_BL(DateTime f1, DateTime f2, string db)
        {
            return ComercialDL.dtRecuperarComisionesTallerJefeTaller_DL(f1, f2, db);
        }

        public static DataTable CargaDatoPeriodoComision_BL(string cTipo, string cYear, string cPeriodo, string db)
        {
            return ComercialDL.CargaDatoPeriodoComision_DL(cTipo, cYear, cPeriodo, db);
        }

        public static DataTable CargaPeriodosComision_BL(string tipo, string anno, string db)
        {
            return ComercialDL.CargaPeriodosComision_DL(tipo, anno, db);
        }

        public static DataTable Listar_Annos_Comision_BL(string tipo, string db)
        {
            return ComercialDL.Listar_Annos_Comision_DL(tipo, db);
        }

        public static void GrabarPeriodosComision_BL(DateTime dfecinicio, DateTime dfecfinal, string cestado, string ccomentario, string ctipo, string canno, string cperiodo, string db)
        {
            ComercialDL.GrabarPeriodosComision_DL(dfecinicio, dfecfinal, cestado, ccomentario, ctipo, canno, cperiodo, db);
        }




        //************************************************************************************************************
        public static DataTable dtRecuperarComisionesDetalle_BL(DateTime f1, DateTime f2, string db)
        {
            return ComercialDL.dtRecuperarComisionesDetalle_DL(f1, f2, db);
        }

        public static DataTable dtRecuperarFletes_BL(DateTime f1, DateTime f2, string db)
        {
            return ComercialDL.dtRecuperarFletes_DL(f1, f2, db);
        }

        public static DataTable dtRecuperarPenalidades_BL(DateTime f1, DateTime f2, string db)
        {
            return ComercialDL.dtRecuperarPenalidades_DL(f1, f2, db);
        }

        public static DataTable dtRecuperarVentaSoles_BL(DateTime f1, DateTime f2, string db)
        {
            return ComercialDL.dtRecuperarVentaSoles_DL(f1, f2, db);
        }

        public static DataSet Listar_Annos(string db)
        {
            try
            {
                DataSet ds_listano = new DataSet();
                ds_listano = ComercialDL.Listar_Annos(db);
                ds_listano.Tables[0].TableName = "listano";
                return ds_listano;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }

        }

        public static DataSet Listar_periodo(string cAnno, string db)
        {
            try
            {
                DataSet ds_listper = new DataSet();
                ds_listper = ComercialDL.Listar_periodo(cAnno, db);
                ds_listper.Tables[0].TableName = "listper";
                return ds_listper;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }

        }

        public static DataSet CargaParametros(Int32 idperiod, string db)
        {
            try
            {
                DataSet ds_pa = new DataSet();
                ds_pa = ComercialDL.CargaParametros(idperiod, db);
                ds_pa.Tables[0].TableName = "pa";
                return ds_pa;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }

        }

        public static DataSet CargaPeriodos(string db)
        {
            try
            {
                DataSet ds_pe = new DataSet();
                ds_pe = ComercialDL.CargaPeriodos(db);
                ds_pe.Tables[0].TableName = "pe";
                return ds_pe;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }

        }

        public static DataSet CargaDatoPeriodo(string cYear, string cPeriodo, string db) //CargaDatoPeriodo(string cAno) //CargaPeriodos       
        {
            try
            {
                return ComercialDL.CargaDatoPeriodo(cYear, cPeriodo, db);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public static void GrabarParametro(string cValor, string cIdPara, string db)
        {
            ComercialDL.GrabarParametro(cValor, cIdPara, db);
        }

        public static void GrabarPeriodos(DateTime dfecinicio, DateTime dfecfinal, string canno, string cperiodo, string db)
        {
            ComercialDL.GrabarPeriodos(dfecinicio, dfecfinal, canno, cperiodo, db);
        }


        // PENALIDAD
        public static void DeleteTmpPenalidad(string db)
        {
            ComercialDL.DeleteTmpPenalidad(db);
        }

        public static Tmp_Penalidad ProcesaTmpPenalidad(Tmp_Penalidad tmppenalidad, string db)
        {
            return ComercialDL.ProcesaTmpPenalidad(tmppenalidad, db);
        }

        public static Tmp_Penalidad GrabaTmpPenalidad(Tmp_Penalidad tmppenalidad, string db)  // DEBE GRABAR EN HISTORICO
        {
            return ComercialDL.GrabaTmpPenalidad(tmppenalidad, db);
        }

        // FLETE
        public static bool ValidarFacturaBoleta(string cdocu, string ndocu, DateTime f1, DateTime f2, string db)
        {
            if (ComercialDL.ValidarFacturaBoleta(cdocu, ndocu, f1, f2, db))
                return true;
            else
                return false;
        }

        public static void DeleteTmpFlete(string db)
        {
            ComercialDL.DeleteTmpFlete(db);
        }

        public static void ProcesaTmpFlete(string cCdocu, string cNdocu, Decimal nFlete, DateTime fecha1, DateTime fecha2, string db)
        {
            ComercialDL.ProcesaTmpFlete(cCdocu, cNdocu, nFlete, fecha1, fecha2, db);
        }

        public static DataSet CargaTmpFlete(string db)
        {
            try
            {
                DataSet ds_TmpFlete = new DataSet();
                ds_TmpFlete = ComercialDL.CargaTmpFlete(db);
                ds_TmpFlete.Tables[0].TableName = "TmpFlete";
                return ds_TmpFlete;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }

        }

        public static Tmp_Flete GrabaTmpFlete(Tmp_Flete tmpflete, string db)  // DEBE GRABAR EN HISTORICO
        {
            return ComercialDL.GrabaTmpFlete(tmpflete, db);
        }

        // VENTAS DEL PERIODO - FLOTAS
        public static void DeleteTmpVentas(string db)
        {
            ComercialDL.DeleteTmpVentas(db);
        }

        public static DataSet ObtenerVentasFlotas(DateTime dFechaIni, DateTime dFechaFin, string cfami1, string cfami2, string db)
        {
            try
            {
                DataSet ds_Flotas = new DataSet();
                ds_Flotas = ComercialDL.ObtenerVentasFlotas(dFechaIni, dFechaFin, cfami1, cfami2, db);
                ds_Flotas.Tables[0].TableName = "Flotas";
                return ds_Flotas;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        // COMISIONES
        public static DataSet ProcesaComision(DateTime dFechaIni, DateTime dFechaFin, string db)
        {
            try
            {
                DataSet ds_Comision = new DataSet();
                ds_Comision = ComercialDL.ProcesaComision(dFechaIni, dFechaFin, db);  //PENDIENTE
                ds_Comision.Tables[0].TableName = "Comision";
                return ds_Comision;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public static DataTable dtListarResumenBL(string db)
        {
            return ComercialDL.dtListarResumenDL(db);
        }

        public static DataTable dtListarDetalleBL(string db)
        {
            return ComercialDL.dtListarDetalleDL(db);
        }

        public static DataTable dtListarFletesBL(string db)
        {
            return ComercialDL.dtListarFletesDL(db);
        }

        public static DataTable dtListarPenalidadesBL(string db)
        {
            return ComercialDL.dtListarPenalidadesDL(db);
        }

        public static DataTable dtListarVentaSolesBL(string db)
        {
            return ComercialDL.dtListarVentaSolesDL(db);
        }

        public static DataTable dtListarVentaDolaresBL(string db)
        {
            return ComercialDL.dtListarVentaDolaresDL(db);
        }

        public static DataTable dtListarCanjeadasBL(string db)
        {
            return ComercialDL.dtListarCanjeadasDL(db);
        }

        public static void GrabarComisiones(string dfecini, string dfecfin, string db)
        {
            ComercialDL.GrabarComisiones(dfecini, dfecfin, db);
        }

        public static bool ExisteParametroPeriodoBL(Int32 periodo, string db)
        {
            if (ComercialDL.ExisteParametroPeriodoDL(periodo, db))
                return true;
            else
                return false;
        }

        public static Int32 GrabarParametrosPeriodoBL(Int32 per_origen, Int32 per_destino, string cdb)
        {
            return ComercialDL.GrabarParametrosPeriodoDL(per_origen, per_destino, cdb);
        }


        public static DataSet ObtenerVentasFlotasBL(DateTime dFechaIni, DateTime dFechaFin, string cfami1, string cfami2, string db)
        {
            try
            {
                DataSet ds_Flotas = new DataSet();
                ds_Flotas = ComercialDL.ObtenerVentasFlotasDL(dFechaIni, dFechaFin, cfami1, cfami2, db);
                ds_Flotas.Tables[0].TableName = "Flotas";
                return ds_Flotas;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public static DataSet ProcesaComisionBL(DateTime dFechaIni, DateTime dFechaFin, string db)
        {
            try
            {
                DataSet ds_Comision = new DataSet();
                ds_Comision = ComercialDL.ProcesaComisionDL(dFechaIni, dFechaFin, db);  //PENDIENTE
                ds_Comision.Tables[0].TableName = "Comision";
                return ds_Comision;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public static void EliminaInformacionDeProcesoAnteriorBL(string db)
        {
            ComercialDL.EliminaInformacionDeProcesoAnteriorDL(db);
        }


        #endregion

        #region APROBACION FACTURAS DEVOLUCION
        public static DataSet CargaFacturas_Pendientes_Devolucion(string cliente, string fechai, string fechaf,int tipo_consulta, string db)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = ComercialDL.CargaFacturas_Pendientes_Devolucion(cliente, fechai, fechaf, tipo_consulta, db);
                ds.Tables[0].TableName = "lista";
                return ds;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }

        }

         // 28/12/2017  jose avila
        public static DataSet Carga_Pedidos_7_Dias(string fechai, string fechaf, int tipo_consulta, string db)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = ComercialDL.Carga_Pedidos_7_Dias(fechai, fechaf, tipo_consulta, db);
                ds.Tables[0].TableName = "lista";
                return ds;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }

        }




        public static Aprobacion_FD InsertarFD(Aprobacion_FD AprobacionFD, string db)
        {
            return ComercialDL.InsertarFD(AprobacionFD, db);
            
        }

        #endregion

        #region INVENTARIO_VALORIZADO
        public static DataTable Inventario_Valorizado(String fecha_proceso, string moneda, string bodega, string familia, string subfamilia, string db)
        {
            return ComercialDL.Inventario_Valorizado(fecha_proceso, moneda, bodega, familia, subfamilia, db);
        }

        #endregion


        //#region COMISION_FLOTAS    UPDATE 20/07/2015, PARA frmComisionesFlotas_V3

        //public static DataTable dtRecuperaComisionesTaller_BL(DateTime f1, DateTime f2, string opcion, string db)
        //{
        //    return ComercialDL.dtRecuperaComisionesTaller_DL(f1, f2, opcion, db);
        //}

        //public static DataTable dtRecuperarComisionesTallerDetalle_BL(DateTime f1, DateTime f2, string db)
        //{
        //    return ComercialDL.dtRecuperarComisionesTallerDetalle_DL(f1, f2, db);
        //}

        //public static DataTable dtRecuperarComisionesTallerTecnico_BL(DateTime f1, DateTime f2, string db)
        //{
        //    return ComercialDL.dtRecuperarComisionesTallerTecnico_DL(f1, f2, db);
        //}

        //public static DataTable dtRecuperarComisionesTallerJefeTaller_BL(DateTime f1, DateTime f2, string db)
        //{
        //    return ComercialDL.dtRecuperarComisionesTallerJefeTaller_DL(f1, f2, db);
        //}



        //public static DataTable CargaDatoPeriodoComision_BL(string cTipo, string cYear, string cPeriodo, string db)
        //{
        //    return ComercialDL.CargaDatoPeriodoComision_DL(cTipo, cYear, cPeriodo, db);
        //}

        //public static DataTable CargaPeriodosComision_BL(string tipo, string anno, string db)
        //{
        //    return ComercialDL.CargaPeriodosComision_DL(tipo, anno, db);
        //}

        //public static DataTable Listar_Annos_Comision_BL(string tipo, string db)
        //{
        //    return ComercialDL.Listar_Annos_Comision_DL(tipo, db);
        //}

        //public static void GrabarPeriodosComision_BL(DateTime dfecinicio, DateTime dfecfinal, string cestado, string ccomentario, string ctipo, string canno, string cperiodo, string db)
        //{
        //    ComercialDL.GrabarPeriodosComision_DL(dfecinicio, dfecfinal, cestado, ccomentario, ctipo, canno, cperiodo, db);
        //}




        ////************************************************************************************************************
        //public static DataTable dtRecuperarComisionesDetalle_BL(DateTime f1, DateTime f2, string db)
        //{
        //    return ComercialDL.dtRecuperarComisionesDetalle_DL(f1, f2, db);
        //}

        //public static DataTable dtRecuperarFletes_BL(DateTime f1, DateTime f2, string db)
        //{
        //    return ComercialDL.dtRecuperarFletes_DL(f1, f2, db);
        //}

        //public static DataTable dtRecuperarPenalidades_BL(DateTime f1, DateTime f2, string db)
        //{
        //    return ComercialDL.dtRecuperarPenalidades_DL(f1, f2, db);
        //}

        //public static DataTable dtRecuperarVentaSoles_BL(DateTime f1, DateTime f2, string db)
        //{
        //    return ComercialDL.dtRecuperarVentaSoles_DL(f1, f2, db);
        //}

        //public static DataSet Listar_Annos(string db)
        //{
        //    try
        //    {
        //        DataSet ds_listano = new DataSet();
        //        ds_listano = ComercialDL.Listar_Annos(db);
        //        ds_listano.Tables[0].TableName = "listano";
        //        return ds_listano;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new ArgumentException(ex.Message);
        //    }

        //}

        //public static DataSet Listar_periodo(string cAnno, string db)
        //{
        //    try
        //    {
        //        DataSet ds_listper = new DataSet();
        //        ds_listper = ComercialDL.Listar_periodo(cAnno, db);
        //        ds_listper.Tables[0].TableName = "listper";
        //        return ds_listper;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new ArgumentException(ex.Message);
        //    }

        //}

        //public static DataSet CargaParametros(Int32 idperiod, string db)
        //{
        //    try
        //    {
        //        DataSet ds_pa = new DataSet();
        //        ds_pa = ComercialDL.CargaParametros(idperiod, db);
        //        ds_pa.Tables[0].TableName = "pa";
        //        return ds_pa;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new ArgumentException(ex.Message);
        //    }

        //}

        //public static DataSet CargaPeriodos(string db)
        //{
        //    try
        //    {
        //        DataSet ds_pe = new DataSet();
        //        ds_pe = ComercialDL.CargaPeriodos(db);
        //        ds_pe.Tables[0].TableName = "pe";
        //        return ds_pe;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new ArgumentException(ex.Message);
        //    }

        //}

        //public static DataSet CargaDatoPeriodo(string cYear, string cPeriodo, string db) //CargaDatoPeriodo(string cAno) //CargaPeriodos       
        //{
        //    try
        //    {
        //        return ComercialDL.CargaDatoPeriodo(cYear, cPeriodo, db);
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new ArgumentException(ex.Message);
        //    }
        //}

        //public static void GrabarParametro(string cValor, string cIdPara, string db)
        //{
        //    ComercialDL.GrabarParametro(cValor, cIdPara, db);
        //}

        //public static void GrabarPeriodos(DateTime dfecinicio, DateTime dfecfinal, string canno, string cperiodo, string db)
        //{
        //    ComercialDL.GrabarPeriodos(dfecinicio, dfecfinal, canno, cperiodo, db);
        //}


        //// PENALIDAD
        //public static void DeleteTmpPenalidad(string db)
        //{
        //    ComercialDL.DeleteTmpPenalidad(db);
        //}

        //public static Tmp_Penalidad ProcesaTmpPenalidad(Tmp_Penalidad tmppenalidad, string db)
        //{
        //    return ComercialDL.ProcesaTmpPenalidad(tmppenalidad, db);
        //}

        //public static Tmp_Penalidad GrabaTmpPenalidad(Tmp_Penalidad tmppenalidad, string db)  // DEBE GRABAR EN HISTORICO
        //{
        //    return ComercialDL.GrabaTmpPenalidad(tmppenalidad, db);
        //}

        //// FLETE
        //public static bool ValidarFacturaBoleta(string cdocu, string ndocu, DateTime f1, DateTime f2, string db)
        //{
        //    if (ComercialDL.ValidarFacturaBoleta(cdocu, ndocu, f1, f2, db))
        //        return true;
        //    else
        //        return false;
        //}

        //public static void DeleteTmpFlete(string db)
        //{
        //    ComercialDL.DeleteTmpFlete(db);
        //}

        //public static void ProcesaTmpFlete(string cCdocu, string cNdocu, Decimal nFlete, DateTime fecha1, DateTime fecha2, string db)
        //{
        //    ComercialDL.ProcesaTmpFlete(cCdocu, cNdocu, nFlete, fecha1, fecha2, db);
        //}

        //public static DataSet CargaTmpFlete(string db)
        //{
        //    try
        //    {
        //        DataSet ds_TmpFlete = new DataSet();
        //        ds_TmpFlete = ComercialDL.CargaTmpFlete(db);
        //        ds_TmpFlete.Tables[0].TableName = "TmpFlete";
        //        return ds_TmpFlete;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new ArgumentException(ex.Message);
        //    }

        //}

        //public static Tmp_Flete GrabaTmpFlete(Tmp_Flete tmpflete, string db)  // DEBE GRABAR EN HISTORICO
        //{
        //    return ComercialDL.GrabaTmpFlete(tmpflete, db);
        //}

        //// VENTAS DEL PERIODO - FLOTAS
        //public static void DeleteTmpVentas(string db)
        //{
        //    ComercialDL.DeleteTmpVentas(db);
        //}

        //public static DataSet ObtenerVentasFlotas(DateTime dFechaIni, DateTime dFechaFin, string cfami1, string cfami2, string db)
        //{
        //    try
        //    {
        //        DataSet ds_Flotas = new DataSet();
        //        ds_Flotas = ComercialDL.ObtenerVentasFlotas(dFechaIni, dFechaFin, cfami1, cfami2, db);
        //        ds_Flotas.Tables[0].TableName = "Flotas";
        //        return ds_Flotas;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new ArgumentException(ex.Message);
        //    }
        //}

        //// COMISIONES
        //public static DataSet ProcesaComision(DateTime dFechaIni, DateTime dFechaFin, string db)
        //{
        //    try
        //    {
        //        DataSet ds_Comision = new DataSet();
        //        ds_Comision = ComercialDL.ProcesaComision(dFechaIni, dFechaFin, db);  //PENDIENTE
        //        ds_Comision.Tables[0].TableName = "Comision";
        //        return ds_Comision;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new ArgumentException(ex.Message);
        //    }
        //}

        //public static DataTable dtListarFletesBL(string db)
        //{
        //    return ComercialDL.dtListarFletesDL(db);
        //}

        //public static DataTable dtListarPenalidadesBL(string db)
        //{
        //    return ComercialDL.dtListarPenalidadesDL(db);
        //}

        //public static DataTable dtListarVentaSolesBL(string db)
        //{
        //    return ComercialDL.dtListarVentaSolesDL(db);
        //}

        //public static DataTable dtListarVentaDolaresBL(string db)
        //{
        //    return ComercialDL.dtListarVentaDolaresDL(db);
        //}

        //public static DataTable dtListarCanjeadasBL(string db)
        //{
        //    return ComercialDL.dtListarCanjeadasDL(db);
        //}

        //public static void GrabarComisiones(string dfecini, string dfecfin, string db)
        //{
        //    ComercialDL.GrabarComisiones(dfecini, dfecfin, db);
        //}

        //public static bool ExisteParametroPeriodoBL(Int32 periodo, string db)
        //{
        //    if (ComercialDL.ExisteParametroPeriodoDL(periodo, db))
        //        return true;
        //    else
        //        return false;
        //}

        //public static Int32 GrabarParametrosPeriodoBL(Int32 per_origen, Int32 per_destino, string cdb)
        //{
        //    return ComercialDL.GrabarParametrosPeriodoDL(per_origen, per_destino, cdb);
        //}


        //public static DataSet ObtenerVentasFlotasBL(DateTime dFechaIni, DateTime dFechaFin, string cfami1, string cfami2, string db)
        //{
        //    try
        //    {
        //        DataSet ds_Flotas = new DataSet();
        //        ds_Flotas = ComercialDL.ObtenerVentasFlotasDL(dFechaIni, dFechaFin, cfami1, cfami2, db);
        //        ds_Flotas.Tables[0].TableName = "Flotas";
        //        return ds_Flotas;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new ArgumentException(ex.Message);
        //    }
        //}

        //public static DataSet ProcesaComisionBL(DateTime dFechaIni, DateTime dFechaFin, string db)
        //{
        //    try
        //    {
        //        DataSet ds_Comision = new DataSet();
        //        ds_Comision = ComercialDL.ProcesaComisionDL(dFechaIni, dFechaFin, db);  //PENDIENTE
        //        ds_Comision.Tables[0].TableName = "Comision";
        //        return ds_Comision;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new ArgumentException(ex.Message);
        //    }
        //}

        //public static void EliminaInformacionDeProcesoAnteriorBL(string db)
        //{
        //    ComercialDL.EliminaInformacionDeProcesoAnteriorDL(db);
        //}


        //#endregion


    }


}


        //#region COMISION_FLOTAS NUEVO   UPDATE 08/08/2016, PARA frmComisionesATF

        //public static DataTable dtObtenerReporteComisionesATF_BL(DateTime dFecha1, DateTime dFecha2, string creporte, string db)
        //{
        //    return ComercialDL.dtObtenerReporteComisionesATF_DL(dFecha1, dFecha2, creporte, db);
        //}

        ////ObtieneComisionesATF(archivo_sql_tmp_atf);
        ////ObtieneComisionesATF_Jefes(archivo_sql_tmp_atf_jefe);
        ////ObtieneComisionesDetalle(archivo_sql_tmp_atf_detalle);

        //public static DataTable dtObtieneComisionesVendedoresATF_BL(string file1_sql, string db)
        //{
        //    return ComercialDL.dtObtieneComisionesVendedoresATF_DL(file1_sql, db);
        //}

        //public static DataTable ObtenerVendedoresATF_BL(Int32 idperiodo, string db)
        //{
        //    try
        //    {
        //        DataTable dt_Comision = new DataTable();
        //        dt_Comision = ComercialDL.ObtenerVendedoresATF_DL(idperiodo, db);
        //        dt_Comision.TableName = "Comision";
        //        return dt_Comision;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new ArgumentException(ex.Message);
        //    }
        //}

        //public static DataTable ObtenerVentasFlotasATF_BL(DateTime dFechaIni, DateTime dFechaFin, DateTime dFechaP, string db)
        //{
        //    try
        //    {
        //        DataTable dt_vtaatf = new DataTable();
        //        dt_vtaatf = ComercialDL.ObtenerVentasFlotasATF_DL(dFechaIni, dFechaFin, dFechaP, db);
        //        dt_vtaatf.TableName = "VtaFlotas";
        //        return dt_vtaatf;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new ArgumentException(ex.Message);
        //    }
        //}

        //public static DataSet ProcesaComisionATF_BL(string cActualiza, Int32 idperiodo, DateTime dFechaIni, DateTime dFechaFin, DateTime dFechaP, string atf, string jefe, string deta, string db)
        //{
        //    try
        //    {
        //        DataSet ds_Comision = new DataSet();
        //        ds_Comision = ComercialDL.ProcesaComisionATF_DL(cActualiza, idperiodo, dFechaIni, dFechaFin, dFechaP, atf, jefe, deta, db);  //PENDIENTE
        //        ds_Comision.Tables[0].TableName = "Comision";
        //        return ds_Comision;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new ArgumentException(ex.Message);
        //    }
        //}

        //#endregion
