using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
//using Exactus.BE;
//using Exactus.DL;
//using System.Data.SqlClient;

namespace ApssaExactus
{
    public class TesoreriaBL
    {

        public static void ActualizarParametrosControlFechaBL(string _modulo, string _parametro, string _valor, string db)
        {
            TesoreriaDL.ActualizarParametrosControlFechaDL(_modulo, _parametro, _valor, db);
        }

        public static string ObtenerParametrosControlFechasBL(string _modulo, string _parametro, string db)
        {
            return TesoreriaDL.ObtenerParametrosControlFechasDL(_modulo, _parametro, db);
        }

        public static string ObtenerUsuarioActualExactus_BL(string db)
        {
            return TesoreriaDL.ObtenerUsuarioActualExactus_DL(db);
        }

        public static void ActualizarAccesosUsuario_BL(string _usuario, Int16 _acceso, string _user_update, string db)
        {
            TesoreriaDL.ActualizarAccesosUsuario_DL(_usuario, _acceso, _user_update, db);
        }

        public static DataTable dtCargarUsuarioBancosAccesos_BL(Int16 _acceso, string db)
        {
            return TesoreriaDL.dtCargarUsuarioBancosAccesos_DL(_acceso, db);
        }

        //-----------------------------------------------------------------------------------------
        public static DataTable dtConsultarCajas_BL(DateTime _fec_ini, DateTime _fec_fin, string _caja, string db)
        {
            return TesoreriaDL.dtConsultarCajas_DL(_fec_ini, _fec_fin, _caja, db);
        }

        public static void CorregirCaja_BL(DateTime _fec, string _caja, Decimal _sol_ok, Decimal _dol_ok,
                                           Decimal _sal_loc, Decimal _sal_dol, string _flag, int _num, string db)
        {
            TesoreriaDL.CorregirCaja_DL(_fec, _caja,  _sol_ok, _dol_ok,_sal_loc, _sal_dol, _flag, _num, db);
        }

        public static DataTable dtDiferenciaCajas_BL(DateTime _fec_ini, DateTime _fec_fin, string _caja, string db)
        {
            return TesoreriaDL.dtDiferenciaCajas_DL(_fec_ini, _fec_fin, _caja, db);
        }

        public static void GrabarHistGY_BL(string ope, string docu, string db)
        {
            TesoreriaDL.GrabarHistGY_DL(ope, docu, db);
        }
        public static void InsertarTempGY_BL(string _prov, DateTime _fec, string _docu, string _mone, Decimal _monto, string db)
        {
            TesoreriaDL.InsertarTempGY_DL(_prov,_fec,_docu,_mone,_monto, db);
        }
        public static DataTable GenerarAplicacionGY_BL(string db)
        {
            return TesoreriaDL.GenerarAplicacionGY_DL(db);
        }

        //public static DataTable EliminarPendientesGY_BL(string _opera, string _docum, string db)
        public static void EliminarPendientesGY_BL(string _opera, string _docum, string db)        
        {
            TesoreriaDL.EliminarPendientesGY_DL(_opera, _docum, db);
        }

        public static DataTable CargaDatosDocumentoCP_BL(string _opera, string _docum, string db)
        {
            return TesoreriaDL.CargaDatosDocumentoCP_DL(_opera, _docum, db);
        }
        public static bool ExisteDocumentoCP_BL(string _opera, string _docum, string db)
        {
            return TesoreriaDL.ExisteDocumentoCP_DL(_opera, _docum, db);
        }


        public static DataTable dtChequeVoucherBL(string cuenta_banco, string tipo_documento, string numero, string db)
        {
            return TesoreriaDL.dtChequeVoucherDL(cuenta_banco, tipo_documento, numero, db);
        }

        public static DataTable dtAsientoContableBL(string asiento, string db)
        {
            return TesoreriaDL.dtAsientoContableDL(asiento, db);
        }                
        
        public static DataSet CargaGridVacio(string db)
        {
            try
            {
                DataSet ds_v = new DataSet();
                ds_v = TesoreriaDL.CargaGridVacio(db);
                ds_v.Tables[0].TableName = "lstvacio";
                return ds_v;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public static DataSet CargaCuentaBanco(string cCtaBanco, string db)
        {
            try
            {
                if ((cCtaBanco == null) || (cCtaBanco == string.Empty))
                {
                    return TesoreriaDL.CargaCuentaBco(db);
                }
                else
                {
                    return TesoreriaDL.CargaCuentaBcoFiltro(cCtaBanco,db);
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public static DataSet CargaListaCheques(string cChequeCuenta, string db)
        {
            try
            {
                if ((cChequeCuenta == null) || (cChequeCuenta == string.Empty))
                {
                    return TesoreriaDL.CargaCheques(db);
                }
                else
                {
                    return TesoreriaDL.CargaChequesFiltro(cChequeCuenta, db);
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public static DataSet Listar_SubTipos(string db)
        {
            try
            {
                DataSet ds_lst = new DataSet();
                ds_lst = TesoreriaDL.Listar_SubTipos(db);
                ds_lst.Tables[0].TableName = "lstsubtipo";
                return ds_lst;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }

        }

        public static DataSet CargaCuentaBancaria(string cCuentaBanco, string db)        
        {
            try
            {
                return TesoreriaDL.CargaCuentaBancaria(cCuentaBanco, db);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }


        public static DataSet ListarCheques(string ctabco, string tipodoc, DateTime fecha1, DateTime fecha2, string db)
        {
            try
            {
                return TesoreriaDL.ListarCheques(ctabco,tipodoc,fecha1,fecha2, db);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }


    }

}
