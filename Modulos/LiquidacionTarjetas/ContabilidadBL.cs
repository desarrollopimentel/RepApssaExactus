
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
//using Exactus.BE;
//using Exactus.DL;


namespace ApssaExactus
{

    public class ProcesosBL
    {
        ProcesosDL objProcesoBL = new ProcesosDL();

        public DataTable dtListarFacturasGy_BL(string db)
        {
            return objProcesoBL.dtListarFacturasGy_DL(db);
        }

        public string BuscarEmbarque_BL(string tipo_ref, string doc_ref, string db)
        {
            return objProcesoBL.BuscarEmbarque_DL(tipo_ref, doc_ref, db);
        }

    }

    public class ContabilidadBL
    {

        public static DataTable dtObtenerReporteLiquidacionTarjetas_BL(DateTime _fecha_ini, DateTime _fecha_fin, string _sucursal, string _tarjeta, string _moneda, string _estado, string db)
        {
            return ContabilidadDL.dtObtenerReporteLiquidacionTarjetas_DL(_fecha_ini, _fecha_fin, _sucursal, _tarjeta, _moneda, _estado, db);
        }

        //    public static DataTable dtObtenerAsientoLiquidacion_BL(string _operacion, string _asiento, Decimal _numero_operacion, string db)
        public static DataTable dtObtenerAsientoLiquidacion_BL(string _operacion, string _asiento, Decimal _numero_operacion, string db)
        {
            //return ContabilidadDL.dtObtenerAsientoLiquidacion_DL(_operacion, _asiento, _numero_operacion, db);
            return ContabilidadDL.dtObtenerAsientoLiquidacion_DL(_operacion, _asiento,  db);
        }

        public static string ObtenerAsientoGenerado_BL(Decimal _num_operacion, string db)
        {
            return ContabilidadDL.ObtenerAsientoGenerado_DL(_num_operacion, db);
        }

        public static string ObtenerMonedaCuentaBanco_BL(string _cuenta_banco, string db)
        {
            return ContabilidadDL.ObtenerMonedaCuentaBanco_DL(_cuenta_banco, db);
        }


        public static DataTable dtLiquidacionTajetasDocumento_TRANSAC_BL(string _operacion, string _tipo_documento, string _documento, Decimal _monto_liquidado, Decimal _tipo_cambio,
                                                                         Int16 _numero_pago, string _caja, Decimal _numero_operacion, string db, SqlTransaction transaction = null)
        {
            return ContabilidadDL.dtLiquidacionTajetasDocumento_TRANSAC_DL(_operacion, _tipo_documento, _documento, _monto_liquidado, _tipo_cambio,
                                                                            _numero_pago, _caja, _numero_operacion, db, transaction);
        }

        public static DataTable dtLiquidarTarjetas_TRANSAC_BL(string _operacion,
                                                                DateTime _fecha_al, Decimal _num_operacion, string _caja, string _tarjeta,
                                                                DateTime _fecha_deposito, Decimal _tipo_cambio, string _moneda,
                                                                Decimal _liq_monto, Decimal _liq_comis, Decimal _liq_neto,
                                                                string _tipo_asiento, string _paquete, string _cuenta_banco, string _tipo, string _subtipo,
                                                                string _usuario, string db, SqlTransaction transaction = null)
        {
            return ContabilidadDL.dtLiquidarTarjetas_TRANSAC_DL(_operacion, _fecha_al, _num_operacion, _caja, _tarjeta,
                                                                  _fecha_deposito, _tipo_cambio, _moneda,
                                                                  _liq_monto, _liq_comis, _liq_neto,
                                                                  _tipo_asiento, _paquete, _cuenta_banco, _tipo, _subtipo,
                                                                  _usuario, db, transaction);
        }


        public static string dtLiquidarTarjetas_TRANSAC_ASIENTO_BL(string _operacion,
                                                                    DateTime _fecha_al, Decimal _num_operacion, string _caja, string _tarjeta,
                                                                    DateTime _fecha_deposito, Decimal _tipo_cambio, string _moneda,
                                                                    Decimal _liq_monto, Decimal _liq_comis, Decimal _liq_neto,
                                                                    string _tipo_asiento, string _paquete, string _cuenta_banco, string _tipo, string _subtipo,
                                                                    string _usuario, string db, SqlTransaction transaction = null)
        {
            return ContabilidadDL.dtLiquidarTarjetas_ASIENTO_TRANSAC_DL(_operacion, _fecha_al, _num_operacion, _caja, _tarjeta,
                                                                          _fecha_deposito, _tipo_cambio, _moneda,
                                                                          _liq_monto, _liq_comis, _liq_neto,
                                                                          _tipo_asiento, _paquete, _cuenta_banco, _tipo, _subtipo,
                                                                          _usuario, db, transaction);
        }


        //-----------------------------------------------------------------------------------------------------------------------------------

        public static DataTable dtLiquidacionTajetasDocumento_BL(string _operacion, string _tipo_documento, string _documento, Decimal _monto_liquidado, Decimal _tipo_cambio,
                                                                 Int16 _numero_pago, string _caja, Decimal _numero_operacion, string db)
        {
            return ContabilidadDL.dtLiquidacionTajetasDocumento_DL(_operacion, _tipo_documento, _documento, _monto_liquidado, _tipo_cambio,
                                                                   _numero_pago, _caja, _numero_operacion, db);
        }


        public static DataTable dtLiquidarTarjetas_BL(string _operacion,
                                                      DateTime _fecha_al, Decimal _num_operacion, string _caja, string _tarjeta,
                                                      DateTime _fecha_deposito, Decimal _tipo_cambio, string _moneda,
                                                      Decimal _liq_monto, Decimal _liq_comis, Decimal _liq_neto,
                                                      string _tipo_asiento, string _paquete, string _cuenta_banco, string _tipo, string _subtipo,
                                                      string _usuario, string db)
        {
            return ContabilidadDL.dtLiquidarTarjetas_DL(_operacion, _fecha_al, _num_operacion, _caja,  _tarjeta,
                                                      _fecha_deposito, _tipo_cambio, _moneda,
                                                      _liq_monto, _liq_comis, _liq_neto,
                                                      _tipo_asiento, _paquete, _cuenta_banco, _tipo, _subtipo,
                                                      _usuario, db);
        }


        public static Decimal ObtenerNumeroOperacion_BL(string _cta_bco, string _tipo, string db)
        {
            return ContabilidadDL.ObtenerNumeroOperacion_DL(_cta_bco, _tipo, db);
        }

        public static DataTable dtGestionaParametrosTarjetas_BL(string _operacion, string _tipo_asiento, string _paquete, string _cuenta_banco, string _tipo, string _subtipo, string db)
        {
            return ContabilidadDL.dtGestionaParametrosTarjetas_DL(_operacion, _tipo_asiento, _paquete, _cuenta_banco, _tipo, _subtipo, db);
        }
        public static DataTable dtObtieneTarjetasListado_BL(string _operacion, DateTime _fecha_al, DateTime _fecha_deposito, 
                                                            string _sucursal, string _tarjeta, string _moneda, Decimal _tipo_cambio, 
                                                            DateTime _fecha_desde, DateTime _fecha_hasta, string _origen, string db)
        {
            return ContabilidadDL.dtObtieneTarjetasListado_DL(_operacion, _fecha_al, _fecha_deposito, _sucursal, _tarjeta, _moneda, _tipo_cambio, _fecha_desde, _fecha_hasta, _origen, db);
        }

        //--------------------------------------------------------------------------------------

        public static bool EliminarItemCargoEntregaRendir_BL(int _cargo, int _item, string db)
        {
            return ContabilidadDL.EliminarItemCargoEntregaRendir_DL(_cargo, _item, db);
        }

        public static DataTable dtObtieneArchivoERCargoV2_BL(DateTime _fecha_inicio, DateTime _fecha_final, string _caja_hist, Int16 _cargo, string db)
        {
            return ContabilidadDL.dtObtieneArchivoERCargoV2_DL(_fecha_inicio, _fecha_final, _caja_hist, _cargo, db);
        }

        public static DataSet CargaExcel_BL(string RutaExcelBL, string NombreHojaBL)
        {
            try
            {
                DataSet ds_le = new DataSet();
                ds_le = ContabilidadDL.CargaExcel_DL(RutaExcelBL, NombreHojaBL);
                ds_le.Tables[0].TableName = "listaexcel";
                return ds_le;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }

        }

        public static DataTable dtListarCamposExcelCambioCentroCosto_BL(string db)
        {
            return ContabilidadDL.dtListarCamposExcelCambioCentroCosto_DL(db);
        }


        public static DataTable dtObtenerStockAuditoria_BL(DateTime _fecha_corte, string _tipo_fecha, string _bodega, string db)
        {
            return ContabilidadDL.dtObtenerStockAuditoria_DL(_fecha_corte, _tipo_fecha, _bodega, db);
        }

        public static DataTable dtProcesaFacturasOtrosV5_BL(string _proveedor, string _documento, string _tipo, DateTime _fecha_documento, DateTime _fecha_contable,
                                                          DateTime _fecha_rige, string _aplicacion,
                                                          Decimal _monto, Decimal _saldo, Decimal _subtotal, Decimal _descuento, Decimal _impuesto1, Decimal _impuesto2,
                                                          Decimal _rubro1, Decimal _rubro2, string _condicion_pago, string _moneda, Int16 _subtipo, DateTime _fecha_vence,
                                                          Decimal _base_impuesto1, Decimal _base_impuesto2, string _rubro8_doc, string _vcuenta_contable,
                                                          string _vcentro_costo, string _vembarque, DateTime _vfecha_proceso, string _vusuario, string _vdetraccion, string db)
        {
            return ContabilidadDL.dtProcesaFacturasOtrosV5_DL(_proveedor, _documento, _tipo, _fecha_documento, _fecha_contable,
                                                            _fecha_rige, _aplicacion,
                                                            _monto, _saldo, _subtotal, _descuento, _impuesto1, _impuesto2,
                                                            _rubro1, _rubro2, _condicion_pago, _moneda, _subtipo, _fecha_vence,
                                                            _base_impuesto1, _base_impuesto2, _rubro8_doc, _vcuenta_contable,
                                                            _vcentro_costo, _vembarque, _vfecha_proceso, _vusuario, _vdetraccion, db);
        }

        public static DataTable dtListarFacturaOtrosV5_BL(string db)
        {
            return ContabilidadDL.dtListarFacturaOtrosV5_DL(db);
        }

        //public static DataTable dtObtenerItemsRebatesBL(Int16 _numero_rebate, string db)
        //{
        //    return ContabilidadDL.dtObtenerItemsRebatesDL(_numero_rebate, db);
        //}

        public static DataTable dtObtenerDatosRebatesBL(DateTime fecha1, DateTime fecha2, string _informacion, Int16 _proceso, string db)
        {
            return ContabilidadDL.dtObtenerDatosRebatesDL(fecha1, fecha2, _informacion, _proceso, db);
        }

        public static DataSet ObtenerEntradaSalidaAlmacenV9(DateTime fecha1, DateTime fecha2, string bode, string ajus, string fami, string subf, string grup, int valor, int actualizar,string db)
        {
            try
            {
                DataSet ds_EntSal = new DataSet();
                ds_EntSal = ContabilidadDL.ObtenerEntradaSalidaAlmacenV9(fecha1, fecha2, bode, ajus, fami, subf, grup, valor, actualizar, db);
                ds_EntSal.Tables[0].TableName = "EntSal";
                return ds_EntSal;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public static DataSet ObtenerEntradaSalidaAlmacenV3(DateTime fecha1, DateTime fecha2, string bode, string ajus, string fami, string subf, string grup, int valor, int actualizar, string db)
        {
            try
            {
                DataSet ds_EntSal = new DataSet();
                ds_EntSal = ContabilidadDL.ObtenerEntradaSalidaAlmacenV3(fecha1, fecha2, bode, ajus, fami, subf, grup, valor, actualizar, db);
                ds_EntSal.Tables[0].TableName = "EntSal";
                return ds_EntSal;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public static DataSet ObtenerEntradaSalidaAlmacenHIST(DateTime fecha1, DateTime fecha2, string bode, string ajus, string fami, string subf, string grup, int valor, string db)
        {
            try
            {
                DataSet ds_EntSal = new DataSet();
                ds_EntSal = ContabilidadDL.ObtenerEntradaSalidaAlmacenHIST(fecha1, fecha2, bode, ajus, fami, subf, grup, valor, db);
                ds_EntSal.Tables[0].TableName = "EntSal";
                return ds_EntSal;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public static DataTable dtObtieneArchivoERCargoBL(DateTime _fecha_inicio, DateTime _fecha_final, Int16 _cargo, string _cuentas, string db)
        {
            return ContabilidadDL.dtObtieneArchivoERCargoDL(_fecha_inicio, _fecha_final, _cargo, _cuentas, db);
        }

        public static DataSet ObtenerEntradaSalidaAlmacenV2(DateTime fecha1, DateTime fecha2, string bode, string ajus, string fami, string subf, string grup, int valor, string db)
        {
            try
            {
                DataSet ds_EntSal = new DataSet();
                ds_EntSal = ContabilidadDL.ObtenerEntradaSalidaAlmacenV2(fecha1, fecha2, bode, ajus, fami, subf, grup, valor, db);
                ds_EntSal.Tables[0].TableName = "EntSal";
                return ds_EntSal;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public static int ObtenerUltimoERCargoBL(string db)
        {
            return ContabilidadDL.ObtenerUltimoERCargoDL(db);
        }

        public static DataTable dtListarCamposCargoCajaChicaER_BL(string db)
        {
            return ContabilidadDL.dtListarCamposCargoCajaChicaER_DL(db);
        }



        public static DataTable dtObtieneArchivoERCargo_BL(DateTime _fecha_inicio, DateTime _fecha_final, string _caja_hist, Int16 _cargo, string db)
        {
            return ContabilidadDL.dtObtieneArchivoERCargo_DL(_fecha_inicio, _fecha_final, _caja_hist, _cargo, db);
        }

        public static DataTable dtGrabarERCargo_BL(int _cargo, int _item, DateTime _fecha_cargo, string _entrega_rendir,
                                                  DateTime _fecha_entrega, string _aplicacion, string _moneda,
                                                  Decimal _monto, string _codigo, string _nombre_prov, string _liquidado,
                                                  string _usuario_liquidacio, DateTime _fecha_liquidacion,
                                                  string _responsable, string _sucursal, string db)
        {
            return ContabilidadDL.dtGrabarERCargo_DL(_cargo, _item, _fecha_cargo, _entrega_rendir,
                                                    _fecha_entrega, _aplicacion, _moneda,
                                                    _monto, _codigo,  _nombre_prov, _liquidado,
                                                    _usuario_liquidacio, _fecha_liquidacion,
                                                    _responsable, _sucursal, db);
        }

        public static DataTable dtObtieneEntregaRendirV2_BL(DateTime _fecha_inicio, DateTime _fecha_final, string _cajas, string _liquidado, string db)
        {
            return ContabilidadDL.dtObtieneEntregaRendirV2_DL(_fecha_inicio, _fecha_final, _cajas, _liquidado, db);
        }

        public static DataTable dtCargaNotasCreditoV4_BL(string _documento, string _tipo, Int16 _subtipo, DateTime _fecha_documento, DateTime _fecha_contable,
                                                      DateTime _fecha_vcmto, string _proveedor, string _moneda, Decimal _tipo_cambio, string _condicion_pago,
                                                      Decimal _subtotal, Decimal _descuento, Decimal _impuesto1, Decimal _impuesto2, Decimal _rubro1, Decimal _rubro2,
                                                      Decimal _monto, string _cuenta_contable, string _centro_costo, string _aplicacion, string _usuario,
                                                      DateTime _fecha_proceso, string _tipo_nc, string _bx, 
                                                      DateTime _ref_fecha, string _ref_tipo, string _ref_serie, string _ref_correlativo, string db)
        {
            return ContabilidadDL.dtCargaNotasCreditoV4_DL(_documento, _tipo, _subtipo, _fecha_documento, _fecha_contable,
                                                        _fecha_vcmto, _proveedor, _moneda, _tipo_cambio, _condicion_pago,
                                                        _subtotal, _descuento, _impuesto1, _impuesto2, _rubro1, _rubro2,
                                                        _monto, _cuenta_contable, _centro_costo, _aplicacion, _usuario,
                                                        _fecha_proceso, _tipo_nc, _bx,
                                                        _ref_fecha, _ref_tipo, _ref_serie, _ref_correlativo, db);
        }

        public static DataTable dtListarCamposExcelNotaCreditoV4_BL(string db)
        {
            return ContabilidadDL.dtListarCamposExcelNotaCreditoV4_DL(db);
        }

        public static DataTable dtProcesaFacturasGyV2_BL(string _proveedor, string _documento, string _tipo, DateTime _fecha_documento, string _aplicacion,
                                                          Decimal _monto, Decimal _saldo, Decimal _subtotal, Decimal _descuento, Decimal _impuesto1, Decimal _impuesto2,
                                                          Decimal _rubro1, Decimal _rubro2, string _condicion_pago, string _moneda, Int16 _subtipo, DateTime _fecha_vence,
                                                          Decimal _base_impuesto1, Decimal _base_impuesto2, string _rubro8_doc, string _vcuenta_contable,
                                                          string _vcentro_costo, string _vembarque, DateTime _vfecha_proceso, string _vusuario, string db)
        {
            return ContabilidadDL.dtProcesaFacturasGyV2_DL(_proveedor, _documento, _tipo, _fecha_documento, _aplicacion,
                                                            _monto, _saldo, _subtotal, _descuento, _impuesto1, _impuesto2,
                                                            _rubro1, _rubro2, _condicion_pago, _moneda, _subtipo, _fecha_vence,
                                                            _base_impuesto1, _base_impuesto2, _rubro8_doc, _vcuenta_contable,
                                                            _vcentro_costo, _vembarque, _vfecha_proceso, _vusuario, db);
        }

        public static DataTable dtProcesaFacturasOtros3BL(string _proveedor, string _documento, string _tipo, DateTime _fecha_documento, DateTime _fecha_contable, string _aplicacion,
                                                          Decimal _monto, Decimal _saldo, Decimal _subtotal, Decimal _descuento, Decimal _impuesto1, Decimal _impuesto2,
                                                          Decimal _rubro1, Decimal _rubro2, string _condicion_pago, string _moneda, Int16 _subtipo, DateTime _fecha_vence,
                                                          Decimal _base_impuesto1, Decimal _base_impuesto2, string _rubro8_doc, string _vcuenta_contable,
                                                          string _vcentro_costo, string _vembarque, DateTime _vfecha_proceso, string _vusuario, string _vdetraccion, string db)
        {
            return ContabilidadDL.dtProcesaFacturasOtros3DL(_proveedor, _documento, _tipo, _fecha_documento, _fecha_contable, _aplicacion,
                                                            _monto, _saldo, _subtotal, _descuento, _impuesto1, _impuesto2,
                                                            _rubro1, _rubro2, _condicion_pago, _moneda, _subtipo, _fecha_vence,
                                                            _base_impuesto1, _base_impuesto2, _rubro8_doc, _vcuenta_contable,
                                                            _vcentro_costo, _vembarque, _vfecha_proceso, _vusuario, _vdetraccion, db);
        }

        public static string ObtieneArticuloFamiliaBL(string _articulo, string db)
        {
            return ContabilidadDL.ObtieneArticuloFamiliaDL(_articulo, db);
        }

        public static DataTable dtListarFondoFijoV3_BL(string db)
        {
            return ContabilidadDL.dtListarFondoFijoV3_DL(db);
        }
        public static DataTable dtListarCamposExcelCajaChicaV3_BL(string db)
        {
            return ContabilidadDL.dtListarCamposExcelCajaChicaV3_DL(db);
        }
        public static string ObtieneDescripcionArticuloEmbarqueBL(string _embarque, string db)
        {
            return ContabilidadDL.ObtieneDescripcionArticuloEmbarqueDL(_embarque, db);
        }

        public static DataTable dtCargaFondoFijoV3_BL(string _documento, string _tipo, Int16 _subtipo, DateTime _fecha_documento, DateTime _fecha_contable, string _contribuyente,
                                                   string _moneda, Decimal _tipo_cambio, Decimal _subtotal, Decimal _descuento, Decimal _impuesto1,
                                                   Decimal _impuesto2, Decimal _rubro1, Decimal _rubro2, Decimal _monto, string _cuenta_banco,
                                                   string _cuenta_contable, string _centro_costo, string _embarque, string _aplicacion, DateTime _fecha_proceso,
                                                   string _usuario, string _cjachica_tipo_operacion, string _cjachica_docu_operacion, string db)
        {
            return ContabilidadDL.dtCargaFondoFijoV3_DL(_documento, _tipo, _subtipo, _fecha_documento, _fecha_contable, _contribuyente,
                                                         _moneda, _tipo_cambio, _subtotal, _descuento, _impuesto1,
                                                         _impuesto2, _rubro1, _rubro2, _monto, _cuenta_banco,
                                                         _cuenta_contable, _centro_costo, _embarque, _aplicacion, _fecha_proceso,
                                                         _usuario, _cjachica_tipo_operacion, _cjachica_docu_operacion, db);
        }

        public static DataTable dtCargaEntregaRendirV3_BL(string _documento, string _tipo, Int16 _subtipo, DateTime _fecha_documento, DateTime _fecha_contable, string _contribuyente,
                                                       string _moneda, Decimal _tipo_cambio, Decimal _subtotal, Decimal _descuento, Decimal _impuesto1,
                                                       Decimal _impuesto2, Decimal _rubro1, Decimal _rubro2, Decimal _monto, string _cuenta_banco,
                                                       string _cuenta_contable, string _centro_costo, string _embarque, string _aplicacion, DateTime _fecha_proceso,
                                                       string _usuario, string _cjachica_tipo_operacion, string _cjachica_docu_operacion, string db)
        {
            return ContabilidadDL.dtCargaEntregaRendirV3_DL(_documento, _tipo, _subtipo, _fecha_documento, _fecha_contable, _contribuyente,
                                                         _moneda, _tipo_cambio, _subtotal, _descuento, _impuesto1,
                                                         _impuesto2, _rubro1, _rubro2, _monto, _cuenta_banco,
                                                         _cuenta_contable, _centro_costo, _embarque, _aplicacion, _fecha_proceso,
                                                         _usuario, _cjachica_tipo_operacion, _cjachica_docu_operacion, db);
        }


        //UPDATE : 2022/06/30
        public static DataTable dtCargaNotasCreditoV3_BL(string _documento, string _tipo, Int16 _subtipo, DateTime _fecha_documento, DateTime _fecha_contable,
                                                      DateTime _fecha_vcmto, string _proveedor, string _moneda, Decimal _tipo_cambio, string _condicion_pago,
                                                      Decimal _subtotal, Decimal _descuento, Decimal _impuesto1, Decimal _impuesto2, Decimal _rubro1, Decimal _rubro2,
                                                      Decimal _monto, string _cuenta_contable, string _centro_costo, string _aplicacion, string _usuario,
                                                      DateTime _fecha_proceso, string _tipo_nc, string _bx, string db)
        {
            return ContabilidadDL.dtCargaNotasCreditoV3_DL(_documento, _tipo, _subtipo, _fecha_documento, _fecha_contable,
                                                        _fecha_vcmto, _proveedor, _moneda, _tipo_cambio, _condicion_pago,
                                                        _subtotal, _descuento, _impuesto1, _impuesto2, _rubro1, _rubro2,
                                                        _monto, _cuenta_contable, _centro_costo, _aplicacion, _usuario,
                                                        _fecha_proceso, _tipo_nc, _bx, db);
        }

        public static DataTable dtListarCamposExcelNotaCreditoV3_BL(string db)
        {
            return ContabilidadDL.dtListarCamposExcelNotaCreditoV3_DL(db);
        }


        //UPDATE : 2022/06/08
        public static DataTable dtObtieneArchivoFFCargoV2_BL(DateTime _fecha_inicio, DateTime _fecha_final, string _caja_hist, Int16 _cargo, string db)
        {
            return ContabilidadDL.dtObtieneArchivoFFCargoV2_DL(_fecha_inicio, _fecha_final, _caja_hist, _cargo, db);
        }


        public static DataTable dtObtieneFondoFijoCargoV2_BL(DateTime _fecha_inicio, DateTime _fecha_final, string _cuentas, string db)
        {
            return ContabilidadDL.dtObtieneFondoFijoCargoV2_DL(_fecha_inicio, _fecha_final, _cuentas, db);
        }

        //--------------------------------------------------------------------------------------

        public static DataTable dtObtieneLiquidacionTarjetasBL(DateTime _fechaini, DateTime _fechafin, string _pen, string _liq, string _tar, string _caja, string db)
        {
            return ContabilidadDL.dtObtieneLiquidacionTarjetasDL(_fechaini, _fechafin, _pen, _liq, _tar, _caja, db);
        }

        
        public static DataTable dtGrabarFFCargoBL(int _cargo, DateTime _fecha_cargo, int _item, string _fondo_fijo,
                                                  DateTime _fecha_fondo, string _sucursal, string _aplicacion, string _moneda,
                                                  Decimal _monto, Decimal _monto_local, Decimal _monto_dolar,
                                                  string _reembolsado, string _responsable, string db)
        {
            return ContabilidadDL.dtGrabarFFCargoDL(_cargo, _fecha_cargo, _item, _fondo_fijo,
                                                    _fecha_fondo, _sucursal, _aplicacion, _moneda,
                                                    _monto, _monto_local, _monto_dolar,
                                                    _reembolsado, _responsable, db);
        }

        public static int ObtenerUltimoFFCargoBL(string db)
        {
            return ContabilidadDL.ObtenerUltimoFFCargoDL(db);
        }

        public static DataTable dtObtieneArchivoFFCargoBL(DateTime _fecha_inicio, DateTime _fecha_final, Int16 _cargo, string db)
        {
            return ContabilidadDL.dtObtieneArchivoFFCargoDL(_fecha_inicio, _fecha_final, _cargo, db);
        }

        public static DataTable dtObtieneFondoFijoCargoBL(DateTime _fecha_inicio, DateTime _fecha_final, string db)
        {
            return ContabilidadDL.dtObtieneFondoFijoCargoDL(_fecha_inicio, _fecha_final, db);
        }

        public static string dtObtenerSucursalCuentaBancariaBL(string _cuenta_banco, string db)
        {
            return ContabilidadDL.dtObtenerSucursalCuentaBancariaDL(_cuenta_banco, db);
        }

        public static DataTable ListarContablesBL(string _contable, string db)
        {
            return ContabilidadDL.ListarContablesDL(_contable, db);
        }


        public static DataTable dtObtieneCreditosCargoBL(string _cjachica_tipo_operacion, string _cjachica_docu_operacion, string db)
        {
            return ContabilidadDL.dtObtieneCreditosCargoDL(_cjachica_tipo_operacion, _cjachica_docu_operacion, db);
        }

        public static DataTable dtListarCamposCargoDetalleCajaChicaBL(string db)
        {
            return ContabilidadDL.dtListarCamposCargoDetalleCajaChicaDL(db);
        }

        public static DataTable dtListarCamposCargoCajaChicaBL(string db)
        {
            return ContabilidadDL.dtListarCamposCargoCajaChicaDL(db);
        }
        //--------------------------------------------------------------------------------------- 14/07/2020


        //--------------------------------------------------------------------------------------



        public static string ObtenerDiasNeto_BL(string _condic, string db)
        {
            return ContabilidadDL.ObtenerDiasNeto_DL(_condic, db);
        }

        // 06092019
        // ALTER PROCEDURE [PIMENTEL].[SP_APSSA_CARGA_DOCUMENTOS_GY]
        public static DataTable dtProcesaDocumentosGY_BL(string _proveedor, string _documento, string _tipo, DateTime _fecha_documento, string _aplicacion,
                                                          Decimal _monto, Decimal _saldo, Decimal _subtotal, Decimal _descuento, Decimal _impuesto1, Decimal _impuesto2,
                                                          Decimal _rubro1, Decimal _rubro2, string _condicion_pago, string _moneda, Int16 _subtipo, DateTime _fecha_vence,
                                                          Decimal _base_impuesto1, Decimal _base_impuesto2, string _rubro8_doc, string _vcuenta_contable,
                                                          string _vcentro_costo, string _vembarque, DateTime _vfecha_proceso, string _vusuario, string _vdetraccion, string db)
        {
            return ContabilidadDL.dtProcesaDocumentosGY_DL(_proveedor, _documento, _tipo, _fecha_documento, _aplicacion,
                                                            _monto, _saldo, _subtotal, _descuento, _impuesto1, _impuesto2,
                                                            _rubro1, _rubro2, _condicion_pago, _moneda, _subtipo, _fecha_vence,
                                                            _base_impuesto1, _base_impuesto2, _rubro8_doc, _vcuenta_contable,
                                                            _vcentro_costo, _vembarque, _vfecha_proceso, _vusuario, _vdetraccion, db);
        }




        //aqui

        public static void CorregirAsientosFA_BL(DateTime _fecha_inicio, DateTime _fecha_final, string db)
        {
            ContabilidadDL.CorregirAsientosFA_DL(_fecha_inicio, _fecha_final, db);
        }



        public static void Cambia_Centro_CostoBL(string _tipo_doc, string _documento, string _codigo, decimal _total, decimal _costo, string _ccosto, string db)
        {
            ContabilidadDL.Cambia_Centro_CostoDL (_tipo_doc,_documento,_codigo,_total,_costo,_ccosto, db);
        }




        public static void DiferenciaCambiariaCP_BL(DateTime _fecha_inicio, DateTime _fecha_final, string db)
        {
            ContabilidadDL.DiferenciaCambiariaCP_DL(_fecha_inicio, _fecha_final, db);
        }


        public static DataTable dtObtenerEtiquetas_BL(Int16 _periodo, Int16 _mes, string _tipo, string db)
        {
            return ContabilidadDL.dtObtenerEtiquetas_DL(_periodo, _mes, _tipo, db);
        }

        


        public static void GrabarRegistroBaseBL(Int16 _periodo, string _tipo, string _dig2, string _cuenta_contable, string _desc_cuenta_contable, Decimal _enero,
                                                Decimal _febrero, Decimal _marzo, Decimal _abril, Decimal _mayo, Decimal _junio, Decimal _julio, Decimal _agosto,
                                                Decimal _setiembre, Decimal _octubre, Decimal _noviembre, Decimal _diciembre, Decimal _acumulado, string _centro_costo,
                                                string _desc_centro_costo, string _extraer, string _concatenar, string _funcion, string _descripcion, string _sucursal,
                                                string _naturaleza, string db)
        {
            ContabilidadDL.GrabarRegistroBaseDL(_periodo, _tipo, _dig2, _cuenta_contable, _desc_cuenta_contable, _enero,
                                                _febrero, _marzo, _abril, _mayo, _junio, _julio, _agosto,
                                                _setiembre, _octubre, _noviembre, _diciembre, _acumulado, _centro_costo,
                                                _desc_centro_costo, _extraer, _concatenar, _funcion, _descripcion, _sucursal,
                                                _naturaleza, db);
        }


        public static DataTable dtEEFFObtenerReclasificacion_BL(Int16 _periodo, Int16 _mes, string db)
        {
            return ContabilidadDL.dtEEFFObtenerReclasificacion_DL(_periodo, _mes, db);
        }

        public static DataTable dtEEFFObtenerBaseHistorico_BL(Int16 _periodo, Int16 _mes, string _tipo, string db)
        {
            return ContabilidadDL.dtEEFFObtenerBaseHistorico_DL(_periodo, _mes, _tipo, db);
        }

        //22/09/2018
        public static DataTable dtEEFFObtenerPresupuestos_BL(Int16 _periodo, Int16 _mes, string _tipo, string _subtipo,
                                                             string _unidad, string _concepto, string db)
        {
            return ContabilidadDL.dtEEFFObtenerPresupuestos_DL(_periodo, _mes, _tipo, _subtipo,
                                                               _unidad, _concepto, db);
        }

        //22/09/2018
        public static DataTable dtEEFFObtenerIndicadores_BL(Int16 _periodo, string _indicador, string _tipo, string _subtipo, string db)
        {
            return ContabilidadDL.dtEEFFObtenerIndicadores_DL(_periodo, _indicador, _tipo, _subtipo, db);
        }

        //20/09/2018
        public static DataTable dtEEFFObtenerParametros_BL(Int16 _periodo, Int16 _mes, string _tipo, string _subtipo,
                                                           string _unidad, string _concepto, string db)
        {
            return ContabilidadDL.dtEEFFObtenerParametros_DL(_periodo, _mes, _tipo, _subtipo, _unidad, _concepto, db);
        }

        public static DataTable dtObtenerResumenMarketing_BL(Int16 _periodo, Int16 _mes, string db)
        {
            return ContabilidadDL.dtObtenerResumenMarketing_DL(_periodo, _mes, db);
        }

        public static DataTable dtObtenerInformacionBaseVista_BL(Int16 _per, Int16 _mes, string db)
        {
            return ContabilidadDL.dtObtenerInformacionBaseVista_DL(_per, _mes, db);
        }

        public static DataTable dtObtenerInformacionBaseHistorico_BL(Int16 _per, Int16 _mes, string _tipo, string db)
        {
            return ContabilidadDL.dtObtenerInformacionBaseHistorico_DL(_per, _mes, _tipo, db);
        }
        public static DataTable dtObtenerInformacionBase_BL(Int16 _per, Int16 _mes, string _tipo, string db)
        {
            return ContabilidadDL.dtObtenerInformacionBase_DL(_per, _mes, _tipo, db);
        }

        public static DataTable dtGenerarInformacionBase_BL(Int16 _per, Int16 _mes, string _temporal, string db)
        {
            return ContabilidadDL.dtGenerarInformacionBase_DL(_per, _mes, _temporal, db);
        }

        // 20/09/2018   --  31/08/2018
        public static DataTable dtObtenerMovimientosPorCC_BL(DateTime _fecha_ini, DateTime _fecha_fin, string db)
        {
            return ContabilidadDL.dtObtenerMovimientosPorCC_DL(_fecha_ini, _fecha_fin, db);
        }

        // 20/09/2018   --  29/08/2018
        public static DataTable dtObtenerCuentasdelMayorBL(DateTime _fecha_ini, DateTime _fecha_fin, string db)
        {
            return ContabilidadDL.dtObtenerCuentasdelMayorDL(_fecha_ini, _fecha_fin, db);
        }

        public static bool ExisteShipToBL(string _shipto, string db)
        {
            return ContabilidadDL.ExisteShipToDL(_shipto, db);
        }

        //SELECT PIMENTEL.Fn_APSSA_GET_FAMILIA_CODE('100350');
        public static string ObtenerFamiliaDeArticuloBL(string _articulo, string db)
        {
            return ContabilidadDL.ObtenerFamiliaDeArticuloDL(_articulo, db);
        }

        //select TIENDA,ABREVIATURA,SHIPTO from pimentel.APSSA_SHIPTO (NOLOCK) WHERE SHIPTO=@SHIPTO
        public static string ObtenerTiendaFromShipToBL(string _shipto, string db)
        {
            return ContabilidadDL.ObtenerTiendaFromShipToDL(_shipto, db);
        }

        public static DataTable dtListarCamposExcelNotaCredito2BL(string db)
        {
            return ContabilidadDL.dtListarCamposExcelNotaCredito2DL(db);
        }

        public static DataTable dtCargaNotasCreditoBL(string _documento, string _tipo, Int16 _subtipo, DateTime _fecha_documento, DateTime _fecha_contable,
                                                      DateTime _fecha_vcmto, string _proveedor, string _moneda, Decimal _tipo_cambio, string _condicion_pago,
                                                      Decimal _subtotal, Decimal _descuento, Decimal _impuesto1, Decimal _impuesto2, Decimal _rubro1, Decimal _rubro2,
                                                      Decimal _monto, string _cuenta_contable, string _centro_costo, string _aplicacion, string _usuario,
                                                      DateTime _fecha_proceso, string _tipo_nc, string db)
        {
            return ContabilidadDL.dtCargaNotasCreditoDL(_documento, _tipo, _subtipo, _fecha_documento, _fecha_contable,
                                                        _fecha_vcmto, _proveedor, _moneda, _tipo_cambio, _condicion_pago,
                                                        _subtotal, _descuento, _impuesto1, _impuesto2, _rubro1, _rubro2,
                                                        _monto, _cuenta_contable, _centro_costo, _aplicacion, _usuario,
                                                        _fecha_proceso, _tipo_nc, db);
        }

        public static DataTable dtListarCamposExcelNotaCreditoBL(string db)
        {
            return ContabilidadDL.dtListarCamposExcelNotaCreditoDL(db);
        }

        public static Decimal ObtenerTipoCambioFechaBL(string _tipo, DateTime _fecha, string db)
        {
            return ContabilidadDL.ObtenerTipoCambioFechaDL(_tipo, _fecha, db);
        }

        public static void ActualizaDocumentoFeBL(string _tipo, string _documento, string _estado, string _mensaje,
                                                  string _transmision, string _motivo, string db)
        {
            ContabilidadDL.ActualizaDocumentoFeDL(_tipo, _documento, _estado, _mensaje,
                                                  _transmision, _motivo, db);
        }





        //centro-cuenta ADD 10/08/2018
        public static bool ExisteCentroCuentaBL(string _ccosto, string _ccontable, string db)
        {
            return ContabilidadDL.ExisteCentroCuentaDL(_ccosto, _ccontable, db);
        }


        public static string Valida_centroBL(string _tipo_doc,string _documento,string _codigo,decimal _costo_soles,decimal _total,string _ccosto,string db)
        {
            return ContabilidadDL.Valida_centroDL(_tipo_doc,_documento,_codigo,_costo_soles,_total,_ccosto, db);
        }


        public static DataTable dtObtenerCamposReclasificacionExcelBiMonedaBL(string db)
        {
            return ContabilidadDL.dtObtenerCamposReclasificacionExcelBiMonedaDL(db);
        }

        // BIMONEDA
        public static DataTable dtObtenerStockCostoPorTipoBiMoneda_BL(string _tipo, string _fam, string _gy, string db)
        {
            return ContabilidadDL.dtObtenerStockCostoPorTipoBiMoneda_DL(_tipo, _fam, _gy, db);
        }

        //EXEC PIMENTEL.SP_APSSA_RECLASIFICACION_CI_PROCESA_BIMONEDA;  BIMONEDA
        public static DataTable dtProcesaReclasificacionBiMonedaCI_BL(string _consecutivo, string _nit, DateTime _fecha_documento, string _bodega, string _localizacion,
                                                                      string _articulo, string _naturaleza, Decimal _cantidad, 
                                                                      Decimal _costo_unitario_local, Decimal _costo_total_local,
                                                                      Decimal _costo_unitario_dolar, Decimal _costo_total_dolar,
                                                                      string _cuenta_contable, string _centro_costo, DateTime _fecha_contable, string _moneda,
                                                                      Decimal _tipo_cambio, string _tipo, string _subtipo, string _paquete_inventario,
                                                                      string _modulo_origen, Int32 _audit_trans_inv, string _aplicacion, string _asiento,
                                                                      DateTime _fecha_proceso, string _usuario, Int32 _corre_reclasif, string db)
        {

            return ContabilidadDL.dtProcesaReclasificacionBiMonedaCI_DL(_consecutivo, _nit, _fecha_documento, _bodega, _localizacion,
                                                                        _articulo, _naturaleza, _cantidad, 
                                                                        _costo_unitario_local,_costo_total_local,
                                                                        _costo_unitario_dolar, _costo_total_dolar,
                                                                        _cuenta_contable, _centro_costo, _fecha_contable, _moneda,
                                                                        _tipo_cambio, _tipo, _subtipo, _paquete_inventario,
                                                                        _modulo_origen, _audit_trans_inv, _aplicacion, _asiento,
                                                                        _fecha_proceso, _usuario, _corre_reclasif, db);
        }
        //OBTIENE STOCK Y COSTOS BIMONEDA
        public static DataTable dtReprocesarStockCostoBiMoneda_BL(DateTime _fecha_rep, string _moneda, string _bodega_ini, string _bodega_fin,
                                                          string _arti_ini, string _arti_fin, string _familia, string db)
        {
            return ContabilidadDL.dtReprocesarStockCostoBiMoneda_DL(_fecha_rep, _moneda, _bodega_ini, _bodega_fin,
                                                            _arti_ini, _arti_fin, _familia, db);
        }

        public static DataTable dtObtenerStockCostoPorTipo_BL(string _tipo, string db)
        {
            return ContabilidadDL.dtObtenerStockCostoPorTipo_DL(_tipo, db);
        }
        public static DataTable dtObtenerStockCostoUnit_BL(DateTime _fecha_rep, string _moneda, string _bodega_ini, string _bodega_fin,
                                                          string _arti_ini, string _arti_fin, string _familia, string db)
        {
            return ContabilidadDL.dtObtenerStockCostoUnit_DL(_fecha_rep, _moneda, _bodega_ini, _bodega_fin,
                                                            _arti_ini, _arti_fin, _familia, db);
        }

        public static DataTable dtObtenerStockCostoProm_BL(DateTime _fecha_rep, string _moneda, string _bodega_ini, string _bodega_fin,
                                                          string _arti_ini, string _arti_fin, string _familia, string db)
        {
            return ContabilidadDL.dtObtenerStockCostoProm_DL(_fecha_rep, _moneda, _bodega_ini, _bodega_fin,
                                                            _arti_ini, _arti_fin, _familia, db);
        }

        public static DataTable dtObtenerTemporalReclaDetalleSoles_BL(string db)
        {
            return ContabilidadDL.dtObtenerTemporalReclaDetalleSoles_DL(db);
        }



        //OBTIENE STOCK Y COSTOS
        public static DataTable dtReprocesarStockCosto_BL(DateTime _fecha_rep, string _moneda, string _bodega_ini, string _bodega_fin,
                                                          string _arti_ini, string _arti_fin, string _familia, string db)
        {
            return ContabilidadDL.dtReprocesarStockCosto_DL(_fecha_rep, _moneda, _bodega_ini, _bodega_fin,
                                                            _arti_ini, _arti_fin, _familia, db);
        }


        //Obtiene Remisiones y Reservados
        public static DataTable dtObtenerRemRes_BL(DateTime _fecha_ini, DateTime _fecha_fin, string _bodega, string _familia,
                                                   string _subfamilia, string _grupo, string db)
        {
            return ContabilidadDL.dtObtenerRemRes_DL(_fecha_ini, _fecha_fin, _bodega, _familia, _subfamilia, _grupo, db);
        }



        //EXEC PIMENTEL.SP_APSSA_RECLASIFICACION_CI_PROCESA;
        public static DataTable dtProcesaReclasificacionCI_BL(string _consecutivo, string _nit, DateTime _fecha_documento, string _bodega, string _localizacion,
                                                              string _articulo, string _naturaleza, Decimal _cantidad, Decimal _costo_unitario_local,
                                                              Decimal _costo_total_local, string _cuenta_contable, string _centro_costo, DateTime _fecha_contable, string _moneda,
                                                              Decimal _tipo_cambio, string _tipo, string _subtipo, string _paquete_inventario,
                                                              string _modulo_origen, Int32 _audit_trans_inv, string _aplicacion, string _asiento,
                                                              DateTime _fecha_proceso, string _usuario, Int32 _corre_reclasif, string db)
        {

            return ContabilidadDL.dtProcesaReclasificacionCI_DL(_consecutivo, _nit, _fecha_documento, _bodega, _localizacion,
                                                                _articulo, _naturaleza, _cantidad, _costo_unitario_local,
                                                                _costo_total_local, _cuenta_contable, _centro_costo, _fecha_contable, _moneda,
                                                                _tipo_cambio, _tipo, _subtipo, _paquete_inventario,
                                                                _modulo_origen, _audit_trans_inv, _aplicacion, _asiento,
                                                                _fecha_proceso, _usuario, _corre_reclasif, db);
        }


        //EXEC PIMENTEL.SP_APSSA_RECLASIFICACION_CI_GET_RECL_TRANSACCIONES;
        public static DataTable dtObtenerResultadoReclasif_Transacciones_BL(string _tipo, Int32 _reclasif, DateTime _fecha_ini, DateTime _fecha_fin, string db)
        {
            return ContabilidadDL.dtObtenerResultadoReclasif_Transacciones_DL(_tipo, _reclasif, _fecha_ini, _fecha_fin, db);
        }

        //EXEC PIMENTEL.SP_APSSA_RECLASIFICACION_CI_GET_RECL_DIARIO;
        public static DataTable dtObtenerResultadoReclasif_Diario_BL(Int32 _reclasif, DateTime _fecha_ini, DateTime _fecha_fin, string db)
        {
            return ContabilidadDL.dtObtenerResultadoReclasif_Diario_DL(_reclasif, _fecha_ini, _fecha_fin, db);
        }

        //EXEC PIMENTEL.SP_APSSA_RECLASIFICACION_CI_GET_RECL_ASIENTO_DIARIO;
        public static DataTable dtObtenerResultadoReclasif_AsientoDiario_BL(Int32 _reclasif, DateTime _fecha_ini, DateTime _fecha_fin, string db)
        {
            return ContabilidadDL.dtObtenerResultadoReclasif_AsientoDiario_DL(_reclasif, _fecha_ini, _fecha_fin, db);
        }

        //EXEC PIMENTEL.SP_APSSA_RECLASIFICACION_CI_GET_RECL_BITACORA;
        public static DataTable dtObtenerResultadoReclasif_Bitacora_BL(Int32 _reclasif, DateTime _fecha_ini, DateTime _fecha_fin, string db)
        {
            return ContabilidadDL.dtObtenerResultadoReclasif_Bitacora_DL(_reclasif, _fecha_ini, _fecha_fin, db);
        }

        //EXEC PIMENTEL.SP_APSSA_RECLASIFICACION_CI_GET_RECL_BITACORA;
        public static DataTable dtObtenerResultadoReclasif_BitacoraDetalle_BL(Int32 _reclasif, DateTime _fecha_ini, DateTime _fecha_fin, string db)
        {
            return ContabilidadDL.dtObtenerResultadoReclasif_BitacoraDetalle_DL(_reclasif, _fecha_ini, _fecha_fin, db);
        }


        //naturaleza
        //localizacion
        //consecutivo
        public static bool ExisteConsecutivoBL(string _ajuste, string _datos, string db)
        {
            return ContabilidadDL.ExisteConsecutivoDL(_ajuste, _datos, db);
        }
        //bodega
        public static bool ExisteBodegaBL(string _bodega, string _datos, string db)
        {
            return ContabilidadDL.ExisteBodegaDL(_bodega, _datos, db);
        }
        //articulo
        public static bool ExisteArticuloBL(string _articulo, string _datos, string db)
        {
            return ContabilidadDL.ExisteArticuloDL(_articulo, _datos, db);
        }
        //nit
        public static bool ExisteNitBL(string _nit, string _datos, string db)
        {
            return ContabilidadDL.ExisteNitDL(_nit, _datos, db);
        }
        public static DataTable dtObtenerCamposReclasificacionExcelBL(string db)
        {
            return ContabilidadDL.dtObtenerCamposReclasificacionExcelDL(db);
        }




        //----------------------------------------------------------------------------------------------------------
        //update: 28/12/2021

        public static DataTable dtCorregirErrAsientosFA_BL(int _year, int _month, string db)
        {
            return ContabilidadDL.dtCorregirErrAsientosFA_DL(_year, _month, db);
        }


        public static DataTable dtProcesarErrFaAsientos_BL(string _tabla, string _operacion, string db)
        {
            return ContabilidadDL.dtProcesarErrFaAsientos_DL(_tabla, _operacion, db);
        }

        public static DataTable dtGenerarErrFaAsientos_BL(int _year, int _month, string _graba, string db)
        {
            return ContabilidadDL.dtGenerarErrFaAsientos_DL(_year, _month, _graba, db);
        }

        //
        public static DataTable dtObtenerErrFaAsDiario_BL(DateTime _fecha_ini, DateTime _fecha_fin, string db)
        {
            return ContabilidadDL.dtObtenerErrFaAsDiario_DL(_fecha_ini, _fecha_fin, db);
        }

        public static DataTable dtObtenerErrFaDiario_BL(DateTime _fecha_ini, DateTime _fecha_fin, string db)
        {
            return ContabilidadDL.dtObtenerErrFaDiario_DL(_fecha_ini, _fecha_fin, db);
        }

        public static DataTable dtObtenerDocumentosCP_BL(DateTime _fecha_ini, DateTime _fecha_fin, string db)
        {
            return ContabilidadDL.dtObtenerDocumentosCP_DL(_fecha_ini, _fecha_fin, db);
        }


        public static string ObtenerSubTipoDocCP_BL(string _tipo, string _subtipo_desc, string db)
        {
            return ContabilidadDL.ObtenerSubTipoDocCP_DL(_tipo, _subtipo_desc, db);
        }

        public static DataTable dtProcesaFacturasCompTarjBL(string _documento, string _tipo, string _subtipo, DateTime _fecha_doc, DateTime _fecha_vcmto, DateTime _fecha_contable,
                                                            string _proveedor, string _moneda, Decimal _tipo_cambio, string _condicion_pago, Decimal _subtotal, Decimal _descuento,
                                                            Decimal _impuesto1, Decimal _impuesto2, Decimal _rubro1, Decimal _rubro2, Decimal _monto, string _cuenta_banco,
                                                            string _cuenta_contable, string _centro_costo, string _aplicacion, DateTime _fecha_proceso, string _usuario, string db)
        {
            return ContabilidadDL.dtProcesaFacturasCompTarjDL(_documento, _tipo, _subtipo, _fecha_doc, _fecha_vcmto, _fecha_contable,
                                                              _proveedor, _moneda, _tipo_cambio, _condicion_pago, _subtotal, _descuento,
                                                              _impuesto1, _impuesto2, _rubro1, _rubro2, _monto, _cuenta_banco,
                                                              _cuenta_contable,  _centro_costo, _aplicacion, _fecha_proceso, _usuario, db);
        }

        public static DataTable dtListarCompTarjBL(string db)
        {
            return ContabilidadDL.dtListarCompTarjDL(db);
        }
        public static DataTable dtListarCamposExcelCompTarjBL(string db)
        {
            return ContabilidadDL.dtListarCamposExcelCompTarjDL(db);
        }

        public static DataTable dtObtenerDocumentosFeBL(DateTime _fecha_ini, DateTime _fecha_fin, string _estado,string _tipo_doc, Int16 _anula, string db)
        {
            return ContabilidadDL.dtObtenerDocumentosFeDL(_fecha_ini, _fecha_fin,_estado,_tipo_doc, _anula, db);
        }

        //public static DataTable dtObtenerDocumentosFeBL(DateTime _fecha_ini, DateTime _fecha_fin, string _tipo_doc, string db)
        //{
        //    return ContabilidadDL.dtObtenerDocumentosFeDL(_fecha_ini, _fecha_fin, _tipo_doc, db);
        //}

        public static string ObtenerSubTipoCajaChicaBL(string _tipo, string _subtipo_desc, string db)
        {
            return ContabilidadDL.ObtenerSubTipoCajaChicaDL(_tipo, _subtipo_desc, db);
        }

        public static DataTable dtObtenerDatosCuentaBancariaBL(string _cuenta_banco, string db)
        {
            return ContabilidadDL.dtObtenerDatosCuentaBancariaDL(_cuenta_banco, db);
        }

        public static DataTable dtObtieneAsientoCreditosBL(string _cjachica_tipo, string _cjachica_asiento, string db)
        {
            return ContabilidadDL.dtObtieneAsientoCreditosDL(_cjachica_tipo, _cjachica_asiento, db);
        }

        public static bool ExisteCuentaBancariaBL(string _cuenta_banco, string db)
        {
            return ContabilidadDL.ExisteCuentaBancariaDL(_cuenta_banco, db);
        }

        public static DataTable dtListarCamposExcelCajaChicaBL(string db)
        {
            return ContabilidadDL.dtListarCamposExcelCajaChicaDL(db);
        }
        public static DataTable dtCargaEntregaRendirBL(string _documento, string _tipo, Int16 _subtipo, DateTime _fecha_documento, DateTime _fecha_contable, string _contribuyente,
                                                       string _moneda, Decimal _tipo_cambio, Decimal _subtotal, Decimal _descuento, Decimal _impuesto1,
                                                       Decimal _impuesto2, Decimal _rubro1, Decimal _rubro2, Decimal _monto, string _cuenta_banco,
                                                       string _cuenta_contable, string _centro_costo, string _aplicacion, DateTime _fecha_proceso,
                                                       string _usuario, string _cjachica_tipo_operacion, string _cjachica_docu_operacion, string db)
        {
            return ContabilidadDL.dtCargaEntregaRendirDL(_documento, _tipo, _subtipo, _fecha_documento, _fecha_contable, _contribuyente,
                                                         _moneda, _tipo_cambio, _subtotal, _descuento, _impuesto1,
                                                         _impuesto2, _rubro1, _rubro2, _monto, _cuenta_banco,
                                                         _cuenta_contable, _centro_costo, _aplicacion, _fecha_proceso,
                                                         _usuario, _cjachica_tipo_operacion, _cjachica_docu_operacion, db);
        }


        public static DataTable dtCargaFondoFijoBL(string _documento, string _tipo, Int16 _subtipo, DateTime _fecha_documento, DateTime _fecha_contable, string _contribuyente,
                                                   string _moneda, Decimal _tipo_cambio, Decimal _subtotal, Decimal _descuento, Decimal _impuesto1,
                                                   Decimal _impuesto2, Decimal _rubro1, Decimal _rubro2, Decimal _monto, string _cuenta_banco,
                                                   string _cuenta_contable, string _centro_costo, string _aplicacion, DateTime _fecha_proceso,
                                                   string _usuario, string _cjachica_tipo_operacion, string _cjachica_docu_operacion, string db)
        {
            return ContabilidadDL.dtCargaFondoFijoDL(_documento, _tipo, _subtipo, _fecha_documento, _fecha_contable, _contribuyente,
                                                     _moneda, _tipo_cambio, _subtotal, _descuento, _impuesto1,
                                                     _impuesto2, _rubro1, _rubro2, _monto, _cuenta_banco,
                                                     _cuenta_contable, _centro_costo, _aplicacion, _fecha_proceso,
                                                     _usuario, _cjachica_tipo_operacion, _cjachica_docu_operacion, db);
        }
        public static bool ExisteMonedaBL(string _moneda, string db)
        {
            return ContabilidadDL.ExisteMonedaDL(_moneda, db);
        }

        public static bool ExisteSubTipoCajaChicaBL(string _tipo_caja_chica, Int32 _subtipo_caja_chica, string db)
        {
            return ContabilidadDL.ExisteSubTipoCajaChicaDL(_tipo_caja_chica, _subtipo_caja_chica, db);
        }

        public static bool ExisteTipoCajaChicaBL(string _tipo_caja_chica, string db)
        {
            return ContabilidadDL.ExisteTipoCajaChicaDL(_tipo_caja_chica, db);
        }

        public static bool ExisteCentroCostoBL(string _ccosto, string db)
        {
            return ContabilidadDL.ExisteCentroCostoDL(_ccosto, db);
        }

        public static DataTable dtObtieneCreditosBL(string _cjachica_tipo_operacion, string _cjachica_docu_operacion, string db)
        {
            return ContabilidadDL.dtObtieneCreditosDL(_cjachica_tipo_operacion, _cjachica_docu_operacion, db);
        }




        public static DataTable dtObtieneEntregaRendirBL(DateTime _fecha_inicio, DateTime _fecha_final, string db)
        {
            return ContabilidadDL.dtObtieneEntregaRendirDL(_fecha_inicio, _fecha_final, db);
        }

        public static DataTable dtObtieneFondoFijoBL(DateTime _fecha_inicio, DateTime _fecha_final, string db)
        {
            return ContabilidadDL.dtObtieneFondoFijoDL(_fecha_inicio, _fecha_final, db);
        }


        public static void AperturaEntregaRendirCajaBL(string _entrega_rendir, string _resposable_tipo, string _responsable_codigo, string _contribuyente,
                                                       string _moneda, string _aplicacion, DateTime _fecha_entrega, Decimal _monto, Decimal _tipo_cambio,
                                                       string _notas, DateTime _fecha_venc, string _usuario, string _tipo_operacion,
                                                       string _cuenta_banco, string _tipo, Int32 _subtipo, string _contribuyente_dcaj, string _moneda_dcaj,
                                                       string _documento, Decimal _monto_dcaj, DateTime _fecha, string _aplicacion_dcaj,
                                                       string _tipo_contribuyente, string db)
        {
            ContabilidadDL.AperturaEntregaRendirCajaDL(_entrega_rendir, _resposable_tipo, _responsable_codigo, _contribuyente,
                                                       _moneda, _aplicacion, _fecha_entrega, _monto, _tipo_cambio,
                                                       _notas, _fecha_venc, _usuario, _tipo_operacion,
                                                       _cuenta_banco, _tipo, _subtipo, _contribuyente_dcaj, _moneda_dcaj,
                                                       _documento, _monto_dcaj, _fecha, _aplicacion_dcaj,
                                                       _tipo_contribuyente, db);
        }



        public static void AperturaEntregaRendirBL(string _entrega_rendir, string _resposable_tipo, string _responsable_codigo, string _contribuyente,
                                                   string _moneda, string _aplicacion, DateTime _fecha_entrega, Decimal _monto, Decimal _tipo_cambio,
                                                   string _notas, DateTime _fecha_venc, string _usuario, string _tipo, string db)
        {
            ContabilidadDL.AperturaEntregaRendirDL(_entrega_rendir, _resposable_tipo, _responsable_codigo, _contribuyente,
                                                   _moneda, _aplicacion, _fecha_entrega, _monto, _tipo_cambio,
                                                   _notas, _fecha_venc, _usuario, _tipo, db);
        }



        public static void AperturaFondoFijoBL(string _fondo_fijo, string _aplicacion, string _cuenta_bancaria, DateTime _fecha_fondo,
                                               string _moneda, Decimal _tipo_cambio, Decimal _monto, string _usuario, string _tipo, string db)
        {
            ContabilidadDL.AperturaFondoFijoDL(_fondo_fijo, _aplicacion, _cuenta_bancaria, _fecha_fondo,
                                               _moneda, _tipo_cambio, _monto, _usuario, _tipo, db);

        }

        public static Decimal ObtenerTipoCambioBL(string _tipo, string db)
        {
            return ContabilidadDL.ObtenerTipoCambioDL(_tipo, db);
        }

        public static string ObtenerCorrelativoEntregaRendirBL(string db)
        {
            return ContabilidadDL.ObtenerCorrelativoEntregaRendirDL(db);
        }

        public static string ObtenerCorrelativoFondoFijoBL(string db)
        {
            return ContabilidadDL.ObtenerCorrelativoFondoFijoDL(db);
        }


        public static DataTable dtListarFondoFijoBL(string db)
        {
            return ContabilidadDL.dtListarFondoFijoDL(db);
        }



        public static DataTable dtProcesaCajaChicaBL(string _documento, string _tipo, Int16 _subtipo, DateTime _fecha_documento, string _contribuyente,
                                                     string _moneda, Decimal _tipo_cambio_dolar, Decimal _subtotal, Decimal _descuento, Decimal _impuesto1,
                                                     Decimal _impuesto2, Decimal _rubro1, Decimal _rubro2, Decimal _monto, string _cuenta_banco,
                                                     string _cuenta_contable, string _centro_costo, string _aplicacion, DateTime _fecha_proceso,
                                                     string _usuario, string _cjachica_tipo_operacion, string _cjachica_docu_operacion, string db)
        {
            return ContabilidadDL.dtProcesaCajaChicaDL(_documento, _tipo, _subtipo, _fecha_documento, _contribuyente,
                                                         _moneda, _tipo_cambio_dolar, _subtotal, _descuento, _impuesto1,
                                                         _impuesto2, _rubro1, _rubro2, _monto, _cuenta_banco,
                                                         _cuenta_contable, _centro_costo, _aplicacion, _fecha_proceso,
                                                         _usuario, _cjachica_tipo_operacion, _cjachica_docu_operacion, db);
        }

        public static bool ExisteEmpleadoBL(string _empleado, string _datos, string db)
        {
            return ContabilidadDL.ExisteEmpleadoDL(_empleado, _datos, db);
        }

        public static DataTable dtListarCamposExcelBL(string db)
        {
            return ContabilidadDL.dtListarCamposExcelDL(db);
        }



        //---------------------------------------------------------------------------------------------------------------------------        
        //public static DataTable dtObtieneCobranzaDetalleDL(string _caja, DateTime _fechaini, DateTime _fechafin, string db)
        public static DataTable dtObtieneCobranzaDetalleBL(string _caja, DateTime _fechaini, DateTime _fechafin, string db)
        {
            return ContabilidadDL.dtObtieneCobranzaDetalleDL(_caja, _fechaini, _fechafin, db);
        }


        public static bool ExisteFacturaCP_BL(string _proveedor, string _tipo_documento, string _documento, string _datos, string db)
        {
            return ContabilidadDL.ExisteFacturaCP_DL(_proveedor, _tipo_documento, _documento, _datos, db);
        }

        public static DataTable dtObtieneCompraSinOcBL(string _consecutivo, string _aplicacion, string _proveedor, string _datos, string db)
        {
            return ContabilidadDL.dtObtieneCompraSinOcDL(_consecutivo, _aplicacion, _proveedor, _datos, db);
        }

        public static DataTable dtObtieneCompraSinOcLineaBL(string _consecutivo, string _aplicacion, string db)
        {
            return ContabilidadDL.dtObtieneCompraSinOcLineaDL(_consecutivo, _aplicacion, db);
        }

        public static bool ExisteProveedorBL(string _proveedor, string _datos, string db)
        {
            return ContabilidadDL.ExisteProveedorDL(_proveedor, _datos, db);
        }

        public static bool ExisteCompraSinOcBL(string _consecutivo, string _aplicacion, string _proveedor, string _datos, string db)
        {
            return ContabilidadDL.ExisteCompraSinOcDL(_consecutivo, _aplicacion, _proveedor, _datos, db);
        }

        public static bool ExisteEmbarqueBL(string _embarque, string _proveedor, string _datos, string db)
        {
            return ContabilidadDL.ExisteEmbarqueDL(_embarque, _proveedor, _datos, db);
        }



        public static DataTable dtTransaccionesDelMayorBL(DateTime _fecha_inicio, DateTime _fecha_final, string db)
        {
            return ContabilidadDL.dtTransaccionesDelMayorDL(_fecha_inicio, _fecha_final, db);
        }


        public static DataTable dtObtieneDatosCierreVentasAjustesBL(Int32 _anno, Int32 _mes, string _tipo, string _operacion, string _usuario, string db)
        {
            return ContabilidadDL.dtObtieneDatosCierreVentasAjustesDL(_anno, _mes, _tipo, _operacion, _usuario, db);
        }

        /// <summary>
        /// 
        /// 
        /// ////////

        public static DataTable dtObtieneEmbarqueVariosDatosLineaBL(string _proveedor, string _tipo_docu_xml, string _documento_xml, string db)
        {
            return ContabilidadDL.dtObtieneEmbarqueVariosDatosLineaDL(_proveedor, _tipo_docu_xml, _documento_xml, db);
        }

        public static DataTable dtObtieneEmbarqueVariosDatosBL(string _proveedor, string _tipo_docu_xml, string _documento_xml, string _campo_retorno, string db)
        {
            return ContabilidadDL.dtObtieneEmbarqueVariosDatosDL(_proveedor, _tipo_docu_xml, _documento_xml, _campo_retorno, db);
        }

        public static string ObtieneEmbarqueVariosDatosBL(string _proveedor, string _tipo_docu_xml, string _documento_xml, string _campo_retorno, string db)
        {
            return ContabilidadDL.ObtieneEmbarqueVariosDatosDL(_proveedor, _tipo_docu_xml, _documento_xml, _campo_retorno, db);
        }



        /// <summary>
        /// 
        /// 
        /// ////////

        public static bool ValidarCondicionPagoBL(string _condicion_pago, string db)
        {
            return ContabilidadDL.ValidarCondicionPagoDL(_condicion_pago, db);
        }
        public static bool ValidarEmbarqueBL(string _embarque, string _proveedor, string _datos, string db)
        {
            return ContabilidadDL.ValidarEmbarqueDL(_embarque, _proveedor, _datos, db);
        }

        public static string ObtieneCuentaCompraArticuloBL(string _articulo_cuenta, string db)
        {
            return ContabilidadDL.ObtieneCuentaCompraArticuloDL(_articulo_cuenta, db);
        }
        public static string ObtieneArticuloFamiliaCodigoBL(string _articulo, string db)
        {
            return ContabilidadDL.ObtieneArticuloFamiliaCodigoDL(_articulo, db);
        }
        public static DataTable dtObtieneEmbarqueDatosLineaBL(string _embarque, string db)
        {
            return ContabilidadDL.dtObtieneEmbarqueDatosLineaDL(_embarque, db);
        }
        public static string ObtieneEmbarqueDatosBL(string _embarque, string _campo_retorno, string db)
        {
            return ContabilidadDL.ObtieneEmbarqueDatosDL(_embarque, _campo_retorno, db);
        }

        public static DataTable dtObtieneEmbarqueDatosBL(string _embarque, string _campo_retorno, string db)
        {
            return ContabilidadDL.dtObtieneEmbarqueDatosDL(_embarque, _campo_retorno, db);
        }

        // 09/09/2017
        public static string ObtieneEmbarqueProveedoresBL(string _proveedor, string _tipo_docu_xml, string _documento_xml, string _campo_retorno, string db)
        {
            return ContabilidadDL.ObtieneEmbarqueProveedoresDL(_proveedor, _tipo_docu_xml, _documento_xml, _campo_retorno, db);
        }

        //public static string ObtieneEmbarqueProveedoresBL(string _proveedor, string _referxml, string _campo_retorno, string db)
        //{
        //    return ContabilidadDL.ObtieneEmbarqueProveedoresDL(_proveedor, _referxml, _campo_retorno, db);
        //}

        public static DataTable dtListarFacturaProveedoresBL(string db)
        {
            return ContabilidadDL.dtListarFacturaProveedoresDL(db);
        }


        public static DataTable dtProcesaFacturasProveedores2BL(string _proveedor, string _documento, string _tipo, DateTime _fecha_documento, string _aplicacion,
                                                              Decimal _monto, Decimal _saldo, Decimal _subtotal, Decimal _descuento, Decimal _impuesto1, Decimal _impuesto2,
                                                              Decimal _rubro1, Decimal _rubro2, string _condicion_pago, string _moneda, Int16 _subtipo, DateTime _fecha_vence,
                                                              Decimal _base_impuesto1, Decimal _base_impuesto2, string _rubro8_doc, string _vcuenta_contable,
                                                              string _vcentro_costo, string _vembarque, DateTime _vfecha_proceso, string _vusuario,
                                                              string _vtip_doc_ref, string _vnum_doc_ref, string _vembarque_oc, string _vdetraccion, string db)
        {
            return ContabilidadDL.dtProcesaFacturasProveedores2DL(_proveedor, _documento, _tipo, _fecha_documento, _aplicacion,
                                                                    _monto, _saldo, _subtotal, _descuento, _impuesto1, _impuesto2,
                                                                    _rubro1, _rubro2, _condicion_pago, _moneda, _subtipo, _fecha_vence,
                                                                    _base_impuesto1, _base_impuesto2, _rubro8_doc, _vcuenta_contable,
                                                                    _vcentro_costo, _vembarque, _vfecha_proceso, _vusuario,
                                                                    _vtip_doc_ref, _vnum_doc_ref, _vembarque_oc, _vdetraccion, db);
        }


        public static DataTable dtProcesaFacturasProveedoresBL(string _proveedor, string _documento, string _tipo, DateTime _fecha_documento, string _aplicacion,
                                                              Decimal _monto, Decimal _saldo, Decimal _subtotal, Decimal _descuento, Decimal _impuesto1, Decimal _impuesto2,
                                                              Decimal _rubro1, Decimal _rubro2, string _condicion_pago, string _moneda, Int16 _subtipo, DateTime _fecha_vence,
                                                              Decimal _base_impuesto1, Decimal _base_impuesto2, string _rubro8_doc, string _vcuenta_contable,
                                                              string _vcentro_costo, string _vembarque, DateTime _vfecha_proceso, string _vusuario, string db)
        {
            return ContabilidadDL.dtProcesaFacturasProveedoresDL(_proveedor, _documento, _tipo, _fecha_documento, _aplicacion,
                                                                _monto, _saldo, _subtotal, _descuento, _impuesto1, _impuesto2,
                                                                _rubro1, _rubro2, _condicion_pago, _moneda, _subtipo, _fecha_vence,
                                                                _base_impuesto1, _base_impuesto2, _rubro8_doc, _vcuenta_contable,
                                                                _vcentro_costo, _vembarque, _vfecha_proceso, _vusuario, db);
        }


        public static DataTable dtProcesaFacturasOtros2BL(string _proveedor, string _documento, string _tipo, DateTime _fecha_documento, string _aplicacion,
                                                      Decimal _monto, Decimal _saldo, Decimal _subtotal, Decimal _descuento, Decimal _impuesto1, Decimal _impuesto2,
                                                      Decimal _rubro1, Decimal _rubro2, string _condicion_pago, string _moneda, Int16 _subtipo, DateTime _fecha_vence,
                                                      Decimal _base_impuesto1, Decimal _base_impuesto2, string _rubro8_doc, string _vcuenta_contable,
                                                      string _vcentro_costo, string _vembarque, DateTime _vfecha_proceso, string _vusuario, string _vdetraccion, string db)
        {
            return ContabilidadDL.dtProcesaFacturasOtros2DL(_proveedor, _documento, _tipo, _fecha_documento, _aplicacion,
                                                        _monto, _saldo, _subtotal, _descuento, _impuesto1, _impuesto2,
                                                        _rubro1, _rubro2, _condicion_pago, _moneda, _subtipo, _fecha_vence,
                                                        _base_impuesto1, _base_impuesto2, _rubro8_doc, _vcuenta_contable,
                                                        _vcentro_costo, _vembarque, _vfecha_proceso, _vusuario, _vdetraccion, db);
        }


        //dtProcesaCompraGYDL(string _linea, Int32 _ti, Int32 _fu, Int32 _sd, Int32 _flotas, Int32 _otr,
        //   Int32 _mes, Int32 _anno, string _usuario, string _tienda, Int32 _orden, string db)



        public static DataTable dtProcesaCompraGYBL(string _linea, string _articulo, string _descripcion, Int32 _stock_n, Int32 _stock,
     Int32 _prom_6, Int32 _prom_3, Int32 _vta_anterior, Int32 _vta_mes, Int32 _vta_estimada, Int32 _proy_ago, Int32 _proy_set,
     Int32 _proy_oct, Int32 _proy_nov, Int32 _proy_dic, string bodega, Int32 _flag, Int32 _flag1, Int32 _flag2, Int32 _flag3, Int32 _flag4,
     string _modelo, Int32 _mes, Int32 _anno, string _usuario, string db)
        {
            return ContabilidadDL.dtProcesaCompraGYDL(_linea, _articulo, _descripcion, _stock_n, _stock,
            _prom_6, _prom_3, _vta_anterior, _vta_mes, _vta_estimada, _proy_ago, _proy_set,
            _proy_oct, _proy_nov, _proy_dic, bodega, _flag, _flag1, _flag2, _flag3, _flag4,
            _modelo, _mes, _anno, _usuario, db);


        }



        /*
    public static DataTable dtProcesaCompraGYBL(string _articulo, string _descripcion, Int32 _stock, 
       Int32 _vta_mes, Int32 _vta_estimada,Int32 _prom_ene_feb, Int32 prom_acum,Int32 _proy_vta_mes,Int32 _proy_ago, Int32 _proy_set,  
       string _linea, string _clase_abc,string produccion,string bodega, Int32 _mes,Int32 _anno,string _usuario,  string db)
    {
        return ContabilidadDL.dtProcesaCompraGYDL( _articulo,  _descripcion,  _stock,
       _vta_mes,  _vta_estimada,  _prom_ene_feb,  prom_acum,  _proy_vta_mes,  _proy_ago,  _proy_set,
        _linea,  _clase_abc,  produccion,  bodega, _mes, _anno, _usuario, db);


    }

*/

        public static DataTable dtProcesaFacturasOtrosBL(string _proveedor, string _documento, string _tipo, DateTime _fecha_documento, string _aplicacion,
                                                      Decimal _monto, Decimal _saldo, Decimal _subtotal, Decimal _descuento, Decimal _impuesto1, Decimal _impuesto2,
                                                      Decimal _rubro1, Decimal _rubro2, string _condicion_pago, string _moneda, Int16 _subtipo, DateTime _fecha_vence,
                                                      Decimal _base_impuesto1, Decimal _base_impuesto2, string _rubro8_doc, string _vcuenta_contable,
                                                      string _vcentro_costo, string _vembarque, DateTime _vfecha_proceso, string _vusuario, string db)
        {
            return ContabilidadDL.dtProcesaFacturasOtrosDL(_proveedor, _documento, _tipo, _fecha_documento, _aplicacion,
                                                            _monto, _saldo, _subtotal, _descuento, _impuesto1, _impuesto2,
                                                            _rubro1, _rubro2, _condicion_pago, _moneda, _subtipo, _fecha_vence,
                                                            _base_impuesto1, _base_impuesto2, _rubro8_doc, _vcuenta_contable,
                                                            _vcentro_costo, _vembarque, _vfecha_proceso, _vusuario, db);
        }

        public static DataTable ObtieneDatosEmbarqueLineaOtrosBL(string _embarque, string db)
        {
            return ContabilidadDL.ObtieneDatosEmbarqueLineaOtrosDL(_embarque, db);
        }

        public static DataTable dtListarFacturaOtrosBL(string db)
        {
            return ContabilidadDL.dtListarFacturaOtrosDL(db);
        }


        public static string ObtieneDatosEmbarqueOtrosBL(string _embarque, string _campo_retorno, string db)
        {
            return ContabilidadDL.ObtieneDatosEmbarqueOtrosDL(_embarque, _campo_retorno, db);
        }

        public static DataTable dtObtieneDatosEmbarqueOtrosBL(string _embarque, string _campo_retorno, string db)
        {
            return ContabilidadDL.dtObtieneDatosEmbarqueOtrosDL(_embarque, _campo_retorno, db);
        }


        public static string ObtieneProveedorFacturaXmlBL(string _proveedorxml, string db)
        {
            return ContabilidadDL.ObtieneProveedorFacturaXmlDL(_proveedorxml, db);
        }


        public static string ObtieneEmbarqueFacturaGyBL(string _guiaremxml, string _campo_retorno, string db)
        {
            return ContabilidadDL.ObtieneEmbarqueFacturaGyDL(_guiaremxml, _campo_retorno, db);
        }

        public static DataTable dtProcesaFacturasGyBL(string _proveedor, string _documento, string _tipo, DateTime _fecha_documento, string _aplicacion,
                                                      Decimal _monto, Decimal _saldo, Decimal _subtotal, Decimal _descuento, Decimal _impuesto1, Decimal _impuesto2,
                                                      Decimal _rubro1, Decimal _rubro2, string _condicion_pago, string _moneda, Int16 _subtipo, DateTime _fecha_vence,
                                                      Decimal _base_impuesto1, Decimal _base_impuesto2, string _rubro8_doc, string _vcuenta_contable,
                                                      string _vcentro_costo, string _vembarque, DateTime _vfecha_proceso, string _vusuario, string db)
        {
            return ContabilidadDL.dtProcesaFacturasGyDL(_proveedor, _documento, _tipo, _fecha_documento, _aplicacion,
                                                        _monto, _saldo, _subtotal, _descuento, _impuesto1, _impuesto2,
                                                        _rubro1, _rubro2, _condicion_pago, _moneda, _subtipo, _fecha_vence,
                                                        _base_impuesto1, _base_impuesto2, _rubro8_doc, _vcuenta_contable,
                                                        _vcentro_costo, _vembarque, _vfecha_proceso, _vusuario, db);
        }



        //public static DataTable dtObtenerCuentaContableDL(string cdb)
        //{
        //    return ContabilidadDL.dtObtenerCuentaContableDL(cdb);
        //}

        public static DataTable dtObtenerInformacionContadoBL(string db)
        {
            return ContabilidadDL.dtObtenerInformacionContadoDL(db);
        }

        public static DataTable dtObtenerMesesHistoricoBL(string db)
        {
            return ContabilidadDL.dtObtenerMesesHistoricoDL(db);
        }

        public static DataTable dtObtenerMesesBL(string db)
        {
            return ContabilidadDL.dtObtenerMesesDL(db);
        }


        public static DataTable dtObtenerAnnosBL(string db)
        {
            return ContabilidadDL.dtObtenerAnnosDL(db);
        }

        public static DataTable dtObtieneBalanceComprobacionExactusBL(string file1_sql, string db)
        {
            return ContabilidadDL.dtObtieneBalanceComprobacionExactusDL(file1_sql, db);
        }


        public static DataTable dtObtieneBalanceComprobacionMensualBL(string file2_sql, string db)
        {
            return ContabilidadDL.dtObtieneBalanceComprobacionMensualDL(file2_sql, db);
        }


        public static DataTable dtObtieneBalanceComprobacionAcumuladoBL(string file3_sql, string db)
        {
            return ContabilidadDL.dtObtieneBalanceComprobacionAcumuladoDL(file3_sql, db);
        }

        public static DataTable dtObtieneBalanceComprobacionResumenBL(string file3_sql, string db)
        {
            return ContabilidadDL.dtObtieneBalanceComprobacionResumenDL(file3_sql, db);
        }

        public static DataSet dsObtenerTablasBalanceComprobacionV3BL(Int32 ano_proc, string mes_proc, string ano_hist, string mes_hist,
                                                                     DateTime fecha1, DateTime fecha2, string acum, string fil1, string fil2, string fil3,
                                                                     string fil4, string fil5, string db)
        {
            try
            {
                DataSet ds_Balance = new DataSet();
                ds_Balance = ContabilidadDL.dsObtenerTablasBalanceComprobacionV3DL(ano_proc, mes_proc, ano_hist, mes_hist, fecha1, fecha2, acum, fil1, fil2, fil3, fil4, fil5, db);
                ds_Balance.Tables[0].TableName = "Balance";
                return ds_Balance;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public static DataSet dsObtenerTablasBalanceComprobacionBL(DateTime fecha1, DateTime fecha2, string acum, string fil1, string fil2, string fil3, string fil4, string fil5, string db)
        {
            try
            {
                DataSet ds_Balance = new DataSet();
                ds_Balance = ContabilidadDL.dsObtenerTablasBalanceComprobacionDL(fecha1, fecha2, acum, fil1, fil2, fil3, fil4, fil5, db);
                ds_Balance.Tables[0].TableName = "Balance";
                return ds_Balance;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public static void EliminarCuentaRubroBL(string cta, string tipgas, string db)
        {
            ContabilidadDL.EliminarCuentaRubroDL(cta, tipgas, db);
        }

        public static void UpdateCuentaRubroBL(string cta, string tipgas, string rub, string eri, string db)
        {
            ContabilidadDL.UpdateCuentaRubroDL(cta, tipgas, rub, eri, db);
        }

        public static void InsertarCuentaRubroBL(string cta, string tipgas, string rub, string eri, string db)
        {
            ContabilidadDL.InsertarCuentaRubroDL(cta, tipgas, rub, eri, db);
        }


        public static bool ExisteCuentaContableBL(string cta, string db)
        {
            return ContabilidadDL.ExisteCuentaContableDL(cta, db);
        }

        public static DataTable dtCargaDatosCuentaContableBL(string cta, string db)
        {
            return ContabilidadDL.dtCargaDatosCuentaContableDL(cta, db);
        }

        public static DataTable dtCuentaContableBL(string cdb)
        {
            return ContabilidadDL.dtCuentaContableDL(cdb);
        }

        public static DataTable dtDirectorioBL(string cdb,String _USER)
        {
            return ContabilidadDL.dtDirectorioDL(cdb,_USER);
        }
                              
        public static DataTable dtObtenerRubroBL(string db)
        {
            return ContabilidadDL.dtObtenerRubroDL(db);
        }
        
        public static DataTable dtObtenerBalanceComprobacionBL(DateTime fecha1, DateTime fecha2, string db)
        {
            return ContabilidadDL.dtObtenerBalanceComprobacionDL(fecha1, fecha2, db);
        }

        public static DataTable dtObtenerBalanceComprobacionSinFormatoBL(DateTime fecha1, DateTime fecha2, string db)
        {
            return ContabilidadDL.dtObtenerBalanceComprobacionSinFormatoDL(fecha1, fecha2, db);
        }

        public static DataTable dtObtenerBalanceComprobacionHistoricoBL(DateTime fecha1, DateTime fecha2, string acum, string db)
        {
            return ContabilidadDL.dtObtenerBalanceComprobacionHistoricoDL(fecha1, fecha2, acum, db);
        }

        public static DataSet ObtenerFacturasTituloGratuitoBL(DateTime fecha1, DateTime fecha2, string bode, string ajus, string fami, string subf, string grup, string db)
        {
            try
            {
                DataSet ds_TitGrat = new DataSet();
                ds_TitGrat = ContabilidadDL.ObtenerFacturasTituloGratuitoDL(fecha1, fecha2, bode, ajus, fami, subf, grup, db);
                ds_TitGrat.Tables[0].TableName = "TitGrat";
                return ds_TitGrat;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public static DataTable Listar_Documentos_CP(DateTime fechaini_doc, DateTime fechafin_doc, string db)
        {
            return ContabilidadDL.ListarDocumentosCP(fechaini_doc, fechafin_doc, db);
        }

        public static DataTable Listar_Documentos_pago_txt(DateTime fechaini, DateTime fechafin, string tipo_documento, string db)
        {
            return ContabilidadDL.Listar_Documentos_pago_txt(fechaini, fechafin, tipo_documento, db);
        }

        public static DataSet ObtenerEntradaSalidaAlmacen(DateTime fecha1, DateTime fecha2, string bode, string ajus, string fami, string subf, string grup, int valor, string db)
        {
            try
            {
                DataSet ds_EntSal = new DataSet();
                ds_EntSal = ContabilidadDL.ObtenerEntradaSalidaAlmacen(fecha1, fecha2, bode, ajus, fami, subf, grup,valor, db);
                ds_EntSal.Tables[0].TableName = "EntSal";
                return ds_EntSal;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public static DataSet ListaEmbarques(DateTime dFechaIni, DateTime dFechaFin, string estados, string bodegas, string db)
        {
            try
            {
                DataSet ds_Emb = new DataSet();
                ds_Emb = ContabilidadDL.ListaEmbarques(dFechaIni, dFechaFin, estados, bodegas, db);
                ds_Emb.Tables[0].TableName = "Emb";
                return ds_Emb;
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
                ds_lv = ContabilidadDL.CargaListaVacia(db);
                ds_lv.Tables[0].TableName = "listavacia";
                return ds_lv;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }

        }

        public static DataSet Listar_Diario_Exactus(string db)
        {
            try
            {
                DataSet ds_ld = new DataSet();
                ds_ld = ContabilidadDL.Listar_Diario_Exactus(db); ;
                ds_ld.Tables[0].TableName = "lstlistadiario";
                return ds_ld;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }

        }

        public static DataSet Listar_Mayor_Exactus(string db)
        {
            try
            {
                DataSet ds_lm = new DataSet();
                ds_lm = ContabilidadDL.Listar_Mayor_Exactus(db);
                ds_lm.Tables[0].TableName = "lstlistamayor";
                return ds_lm;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }

        }

        public static void ActualEquivCuentaNava(string ctaExactus, string ctaNava, string db)
        {
            ContabilidadDL.ActualEquivCuentaNava(ctaExactus, ctaNava, db);
        }

        public static void Actualiza_Arqueo_Caja(decimal blsil, decimal blsfl, decimal blsrl, decimal blsid, decimal blsfd, decimal blsrd, string blcaja, string blusuario, int blnum_aper, string bldb)
        {
            ContabilidadDL.Actualiza_Arqueo_Caja(blsil, blsfl, blsrl, blsid, blsfd, blsrd, blcaja, blusuario, blnum_aper, bldb);
        }


        public static void Actualiza_Fecha_Limite(Int32 blsil, Int32 blsfl, DateTime blsrl,  string bldb)
        {
            ContabilidadDL.Actualiza_Fecha_Limite(blsil, blsfl, blsrl, bldb);
        }


        public static void Actualiza_Usuario(string correo,string fijo,string celular,string anexo,string usuario, string bldb)
        {
            ContabilidadDL.Actualiza_Usuario(correo, fijo,  celular,  anexo,usuario,  bldb);
        }




        public static Ctas_contable ActualizarEquivCuenta(Ctas_contable ctacontable, string db)    // sin usar
        {
            return ContabilidadDL.ActualizarEquivCuenta(ctacontable, db);
        }

        public static DataSet Cgm0102Vacia(string db)
        {
            try
            {
                DataSet ds_lcg = new DataSet();
                ds_lcg = ContabilidadDL.Cgm0102Vacia(db);
                ds_lcg.Tables[0].TableName = "cgmvacia";
                return ds_lcg;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }

        }

        public static string CContable_Exactus2Navasoft(string cCUENTA_CONTABLE, string db)
        {
            return ContabilidadDL.CContable_Exactus2Navasoft(cCUENTA_CONTABLE, db);
        }


        public static string CCosto_Exactus2Navasoft(string cCENTRO_COSTO, string db)
        {
            return ContabilidadDL.CCosto_Exactus2Navasoft(cCENTRO_COSTO, db);
        }

        public static DiarioNavasoftBE AgregarFilaNavasoft(DiarioNavasoftBE diarionavasoft, string db)
        {
            return ContabilidadDL.AgregarFilaNavasoft(diarionavasoft, db);
        }

        public static DataSet MostrarAsientoTemporal(string db)
        {
            try
            {
                DataSet ds_as = new DataSet();
                ds_as = ContabilidadDL.MostrarAsientoTemporal(db);
                ds_as.Tables[0].TableName = "lstlistaasiento";
                return ds_as;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }

        }

        public static DiarioNavasoftBE GrabaAsientoNavasoft(DiarioNavasoftBE asientonavasoft, string db)
        {
            return ContabilidadDL.GrabaAsientoNavasoft(asientonavasoft, db);
        }


        public static DataTable Lista_Detalle_Cajas(string cCAJA_BL, int cMEs_BL, int cANNO_BL, string db_BL)
        {
            try
            {
                //DataSet ds_dc = new DataSet();
                //ds_dc = ContabilidadDL.Obtener_Detalle_Caja(cCAJA_BL, cMEs_BL, cANNO_BL, db_BL);   
                //ds_dc.Tables[0].TableName = "dc";
                return ContabilidadDL.Obtener_Detalle_Caja(cCAJA_BL, cMEs_BL, cANNO_BL, db_BL);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }

            
        }


        public static DataTable Lista_CVGY(string db_BL)
        {
            try
            {
         
                return ContabilidadDL.Obtener_CVGY(db_BL);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }


        }



    }

}

