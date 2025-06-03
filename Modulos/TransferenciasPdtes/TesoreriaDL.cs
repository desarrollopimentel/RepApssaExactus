using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
//using Exactus.DC;
//using Exactus.BE;


namespace ApssaExactus
{
    public class TesoreriaDL
    {

        public static void ActualizarParametrosControlFechaDL(string _modulo, string _parametro, string _valor, string db)
        {
            string strSql = @"  UPDATE PIMENTEL.APSSA_PARAMETROS_REPORTES                    
                                SET 
                                VALOR = @VALOR
                                WHERE MODULO=@MODULO  AND PARAMETRO=@PARAMETRO; ";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@MODULO", _modulo));
            arParams.Add(new SqlParameter("@PARAMETRO", _parametro));
            arParams.Add(new SqlParameter("@VALOR", _valor));

            SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParams.ToArray());
        }

        public static string ObtenerParametrosControlFechasDL(string _modulo, string _parametro, string db)
        {
            string cValor = "";
            string strSql = @"SELECT RTRIM(LTRIM(VALOR)) FROM PIMENTEL.APSSA_PARAMETROS_REPORTES (NOLOCK) WHERE MODULO=@MODULO AND PARAMETRO=@PARAMETRO ;";
            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@MODULO", _modulo));
            arParams.Add(new SqlParameter("@PARAMETRO", _parametro));
            cValor = SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParams.ToArray()).ToString();
            return cValor;
        }

        public static string ObtenerUsuarioActualExactus_DL(string db)
        {
            string cUsuario = string.Empty;

            string strSql = "PIMENTEL.SP_APSSA_USUARIO_ACTUAL_EXACTUS";

            //List<SqlParameter> arParams = new List<SqlParameter>();
            //arParams.Add(new SqlParameter("@TIP_REF", tipo_ref));
            //arParams.Add(new SqlParameter("@DOC_REF", doc_ref));

            cUsuario = Convert.ToString(SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql));

            return cUsuario;
        }

        public static void ActualizarAccesosUsuario_DL(string _usuario, Int16 _acceso, string _user_update, string db)
        {
            string strSql = @"  UPDATE PIMENTEL.APSSA_PRIVILEGIOS_BANCOS                    
                                SET 
                                ACCESO = @ACCESO,
                                USUARIO_UPDATE = @USUARIO_UPDATE
                                WHERE USUARIO=@USUARIO; ";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@ACCESO", _acceso));
            arParams.Add(new SqlParameter("@USUARIO", _usuario));
            arParams.Add(new SqlParameter("@USUARIO_UPDATE", _user_update));

            SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParams.ToArray());
        }


        public static DataTable dtCargarUsuarioBancosAccesos_DL(Int16 _acceso, string db)
        {
            string strSql = @"  SELECT                      
                                USUARIO, NOMBRE
                                FROM PIMENTEL.APSSA_PRIVILEGIOS_BANCOS (NOLOCK)
                                WHERE 1=1 AND ACCESO=@ACCESO; ";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@ACCESO", _acceso));

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParams.ToArray()).Tables[0];
        }

        //-----------------------------------------------------------------------------------------

        //CREATE PROCEDURE[PIMENTEL].[SP_APSSA_CAJAS_CONSULTA]
        //(@FECHA_INI DATETIME,
        //@FECHA_FIN DATETIME,
        //@CAJA CHAR(4))
        public static DataTable dtConsultarCajas_DL(DateTime _fec_ini, DateTime _fec_fin, string _caja, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_CAJAS_CONSULTA";

            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@FECHA_INI", _fec_ini));
            arParam.Add(new SqlParameter("@FECHA_FIN", _fec_fin));
            arParam.Add(new SqlParameter("@CAJA", _caja));

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParam.ToArray()).Tables[0];
        }


        //ALTER PROCEDURE[PIMENTEL].[SP_APSSA_CAJAS_CORREGIR]
        //(@FECHA DATETIME,
        // @CAJA VARCHAR(10),
        // @SOLES_OK DECIMAL(28,8),
        // @DOLAR_OK DECIMAL(28,8),
        // @SALDO_FINAL_LOC DECIMAL(28,8),
        // @SALDO_FINAL_DOL DECIMAL(28,8),
        // @FLAG VARCHAR(1),
        // @NUMERO INT )        
        public static void CorregirCaja_DL(DateTime _fec, string _caja, Decimal _sol_ok, Decimal _dol_ok, 
                                           Decimal _sal_loc, Decimal _sal_dol, string _flag, int _num, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_CAJAS_CORREGIR";

            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@FECHA", _fec));
            arParam.Add(new SqlParameter("@CAJA", _caja));
            arParam.Add(new SqlParameter("@SOLES_OK", _sol_ok));
            arParam.Add(new SqlParameter("@DOLAR_OK", _dol_ok));
            arParam.Add(new SqlParameter("@SALDO_FINAL_LOC", _sal_loc));
            arParam.Add(new SqlParameter("@SALDO_FINAL_DOL", _sal_dol));
            arParam.Add(new SqlParameter("@FLAG", _flag));
            arParam.Add(new SqlParameter("@NUMERO", _num));

            SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParam.ToArray());
        }



        //ALTER PROCEDURE[PIMENTEL].[SP_APSSA_CAJAS_DIFERENCIAS]
        //(@FECHA_INI DATETIME,
        // @FECHA_FIN DATETIME,
        // @CAJA CHAR(4))
        public static DataTable dtDiferenciaCajas_DL(DateTime _fec_ini, DateTime _fec_fin, string _caja, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_CAJAS_DIFERENCIAS";

            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@FECHA_INI", _fec_ini));
            arParam.Add(new SqlParameter("@FECHA_FIN", _fec_fin));
            arParam.Add(new SqlParameter("@CAJA", _caja));

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParam.ToArray()).Tables[0];
        }

        public static void GrabarHistGY_DL(string ope, string docu, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_APLICACION_GY";

            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@OPERACION", ope));
            arParam.Add(new SqlParameter("@DOCUMENTO", docu));

            //arParam.Add(new SqlParameter("@FECHA", _fec));
            //arParam.Add(new SqlParameter("@MONEDA", _mone));
            //arParam.Add(new SqlParameter("@MONTO", _monto));

            SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParam.ToArray());
            //SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql);
        }

        //ALTER PROCEDURE[PIMENTEL].[SP_APSSA_APLICACION_GY_TEMP] (
        //@PROVEEDOR VARCHAR(20),
        //@FECHA DATETIME,
        //@DOCUMENTO VARCHAR(50),
        //@MONEDA VARCHAR(3),
        //@MONTO DECIMAL(28, 2))
        public static void InsertarTempGY_DL(string _prov,DateTime _fec, string _docu, string _mone, Decimal _monto, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_APLICACION_GY_TEMP";

            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@PROVEEDOR", _prov));
            arParam.Add(new SqlParameter("@FECHA", _fec));
            arParam.Add(new SqlParameter("@DOCUMENTO", _docu));
            arParam.Add(new SqlParameter("@MONEDA", _mone));
            arParam.Add(new SqlParameter("@MONTO", _monto));

            SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParam.ToArray());
        }

        public static DataTable GenerarAplicacionGY_DL(string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_APLICACION_GY_GENERAR";

            //List<SqlParameter> arParam = new List<SqlParameter>();
            //arParam.Add(new SqlParameter("@OPERACION", _opera));
            //arParam.Add(new SqlParameter("@DOCUMENTO", _docum));

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql).Tables[0];
        }

        //       public static DataTable EliminarPendientesGY_DL(string _opera, string _docum, string db)
        public static void EliminarPendientesGY_DL(string _opera, string _docum, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_APLICACION_GY";

            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@OPERACION", _opera));
            arParam.Add(new SqlParameter("@DOCUMENTO", _docum));

            SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParam.ToArray());
            //return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParam.ToArray()).Tables[0];
        }


        public static DataTable CargaDatosDocumentoCP_DL(string _opera, string _docum, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_APLICACION_GY";

            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@OPERACION", _opera));
            arParam.Add(new SqlParameter("@DOCUMENTO", _docum));

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParam.ToArray()).Tables[0];
        }


        public static bool ExisteDocumentoCP_DL(string _opera, string _docum, string db)
        {
            int NumReg = 0;
            string strSql = "PIMENTEL.SP_APSSA_APLICACION_GY";

            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@OPERACION", _opera));
            arParam.Add(new SqlParameter("@DOCUMENTO", _docum));

            NumReg = Convert.ToInt32(SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParam.ToArray()));
            return NumReg > 0;
        }

        public static DataTable dtChequeVoucherDL(string cuenta_banco, string tipo_documento, string numero, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_CHEQUE2";
            List<SqlParameter> arParams = new List<SqlParameter>();

            arParams.Add(new SqlParameter("@CUENTA_BANCOS", cuenta_banco));
            arParams.Add(new SqlParameter("@TIPO_DOCUMENTOS", tipo_documento));
            arParams.Add(new SqlParameter("@NUMERO", numero));

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray()).Tables[0];
        }

        public static DataTable dtAsientoContableDL(string asiento, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_ASIENTO_CONTABLE";
            List<SqlParameter> arParams = new List<SqlParameter>();

            arParams.Add(new SqlParameter("@ASIENTO", asiento));

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray()).Tables[0];
        }                
        
        public static DataSet CargaGridVacio(string db)
        {
            DataSet ds_vacio = new DataSet();

            string strSql = @" SELECT TOP 0
                               CP.PROVEEDOR,P.NOMBRE AS NOMBRE,CP.FECHA,CP.FECHA_VENCE AS VENCE,CP.CONTRARECIBO,CP.TIPO,  
                               CP.DOCUMENTO,CP.MONEDA,CP.MONTO,CP.SALDO,CP.MONTO_PAGO,CP.USUARIO,CP.CHEQUE_CUENTA AS CUENTA_BANCARIA 
                               FROM PIMENTEL.DOCUMENTOS_CP CP 
                               INNER JOIN PIMENTEL.PROVEEDOR P ON P.PROVEEDOR=CP.PROVEEDOR 
                            ";

            ds_vacio = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql);
            ds_vacio.Tables[0].TableName = "vacio";
            return ds_vacio;
        }

        public static DataSet Listar_SubTipos(string db)
        {
            try
            {
                DataSet ds_listasubtipo = new DataSet();

                string strSql = @" SELECT * FROM PIMENTEL.SUBTIPO_DOC_CB  
                                   WHERE TIPO='CHQ'  
                                   ORDER BY SUBTIPO; ";

                ds_listasubtipo = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql);

                ds_listasubtipo.Tables[0].TableName = "listasubtipo";
                return ds_listasubtipo;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public static DataSet CargaCuentaBco(string db)
        {
            DataSet ds_cuentabco = new DataSet();
            string strSql = @" SELECT CUENTA_BANCO,NOMBRE,ENTIDAD_FINANCIERA,MONEDA,SALDO 
                               FROM PIMENTEL.CUENTA_BANCARIA";
            ds_cuentabco = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql);
            ds_cuentabco.Tables[0].TableName = "cuentabco";
            return ds_cuentabco;
        }

        public static DataSet CargaCuentaBcoFiltro(string cCuentaBanco, string db)
        {
            DataSet ds_cuentabcofil = new DataSet();
            string strSql = @" SELECT CUENTA_BANCO,NOMBRE,ENTIDAD_FINANCIERA,MONEDA,SALDO   
                                FROM PIMENTEL.CUENTA_BANCARIA  
                                 WHERE NOMBRE LIKE  '%@NOMBRE%' ";
            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@NOMBRE", cCuentaBanco));
            ds_cuentabcofil = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray());
            ds_cuentabcofil.Tables[0].TableName = "cuentabcofil";
            return ds_cuentabcofil;
        }

        public static DataSet CargaCheques(string db)
        {
            DataSet ds_cheque = new DataSet();
            //            string strSql = @" SELECT * FROM PIMENTEL.DOCUMENTOS_CP  
            //                               WHERE TIPO='CHQ'  ";
            string strSql = @" SELECT CP.PROVEEDOR,P.NOMBRE AS NOMBRE,CP.FECHA,CP.FECHA_VENCE AS VENCE,CP.CONTRARECIBO,CP.TIPO,  
                               CP.DOCUMENTO,CP.MONEDA,CP.MONTO,CP.SALDO,CP.MONTO_PAGO,CP.USUARIO,CP.CHEQUE_CUENTA AS CUENTA_BANCARIA 
                               FROM PIMENTEL.DOCUMENTOS_CP CP 
                               INNER JOIN PIMENTEL.PROVEEDOR P ON P.PROVEEDOR=CP.PROVEEDOR 
                            ";

            ds_cheque = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql);
            ds_cheque.Tables[0].TableName = "cheque";
            return ds_cheque;
        }

        public static DataSet CargaChequesFiltro(string cChequeCuenta, string db)
        {
            DataSet ds_chequefil = new DataSet();
         
            string strSql = @" SELECT CP.PROVEEDOR,P.NOMBRE AS NOMBRE,CP.FECHA,CP.FECHA_VENCE AS VENCE,CP.CONTRARECIBO,CP.TIPO,  
                               CP.DOCUMENTO,CP.MONEDA,CP.MONTO,CP.SALDO,CP.MONTO_PAGO,CP.USUARIO,CP.CHEQUE_CUENTA AS CUENTA_BANCARIA 
                               FROM PIMENTEL.DOCUMENTOS_CP CP 
                               INNER JOIN PIMENTEL.PROVEEDOR P ON P.PROVEEDOR=CP.PROVEEDOR 
                               WHERE CHEQUE_CUENTA=@CHEQUE_CUENTA
                            ";             
           
            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@CHEQUE_CUENTA", cChequeCuenta));
            ds_chequefil = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray());
            ds_chequefil.Tables[0].TableName = "chequefil";
            return ds_chequefil;
        }

        public static DataSet CargaCuentaBancaria(string cCuentaBanco, string db)        //DataReader / Cabecera
        {
            DataSet ds_ctabco = new DataSet();
            //SqlDataReader lector = new SqlDataReader();

             string strSql = @" SELECT CB.CUENTA_BANCO,CB.NOMBRE,CB.ENTIDAD_FINANCIERA,CB.MONEDA,CB.SALDO, 
                                EF.DESCRIPCION AS ENTIDAD_NOMBRE, MO.NOMBRE AS MONEDA_NOMBRE 
                                FROM PIMENTEL.CUENTA_BANCARIA  CB 
                                INNER JOIN PIMENTEL.ENTIDAD_FINANCIERA EF ON EF.ENTIDAD_FINANCIERA = CB.ENTIDAD_FINANCIERA 
                                INNER JOIN PIMENTEL.MONEDA MO ON MO.MONEDA = CB.MONEDA  
                                WHERE CB.CUENTA_BANCO = @CUENTA_BANCO 
                             ";
         
            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@CUENTA_BANCO", cCuentaBanco));
            ds_ctabco = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray());
            //lector=SqlHelper.ExecuteReader(ConexionDC.ConectarTest(), CommandType.Text, strSql, arParam.ToArray());
            
            ds_ctabco.Tables[0].TableName = "ctabco";
            return ds_ctabco;
            //return lector;

        }



        public static DataSet ListarCheques(string ctabco, string tipodoc, DateTime fecha1, DateTime fecha2, string db)
        {
            DataSet ds_lcheque = new DataSet();

//            string strSql = @" SELECT CP.PROVEEDOR,P.NOMBRE AS NOMBRE,CP.FECHA,CP.FECHA_VENCE AS VENCE,CP.CONTRARECIBO,CP.TIPO,  
//                               CP.DOCUMENTO,CP.MONEDA,CP.MONTO,CP.SALDO,CP.MONTO_PAGO,CP.USUARIO,CP.CHEQUE_CUENTA AS CUENTA_BANCARIA 
//                               FROM PIMENTEL.DOCUMENTOS_CP CP 
//                               INNER JOIN PIMENTEL.PROVEEDOR P ON P.PROVEEDOR=CP.PROVEEDOR 
//                            ";

//            ds_lcheque = SqlHelper.ExecuteDataset(ConexionDC.Conectar(), CommandType.Text, strSql);

            string strSql = "PIMENTEL.SP_APSSA_CHEQUE_LISTA";          
            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@CUENTA_BANCOS", ctabco));
            arParams.Add(new SqlParameter("@TIPO_DOCUMENTO", tipodoc));
            arParams.Add(new SqlParameter("@FECHA_INI", fecha1));
            arParams.Add(new SqlParameter("@FECHA_FIN", fecha2));

            //SqlHelper.ExecuteNonQuery(ConexionDC.Conectar(), CommandType.StoredProcedure, strSql, arParams.ToArray());
            //ds_lcheque.Tables[0].TableName = "lcheque";
            //return ds_lcheque;

            //ds_lcheque = SqlHelper.ExecuteDataset(ConexionDC.Conectar(), CommandType.StoredProcedure, strSql, arParams.ToArray());
            ds_lcheque = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray());
            ds_lcheque.Tables[0].TableName = "lcheque";
            return ds_lcheque;


        }

        /*
        public static DataSet ProcesaComision(DateTime dFecha1, DateTime dFecha2)
        {            
            // CON PARAMETRO
            DataSet ds_proceso = new DataSet();
         
            string strSql = "APSSA.SP_COMISION_FLOTAS_PROCESA";
          
            List<SqlParameter> arParams = new List<SqlParameter>();
			arParams.Add(new SqlParameter("@FechaProcesoIni", dFecha1));
            arParams.Add(new SqlParameter("@FechaProcesoFin", dFecha2));

            ds_proceso = SqlHelper.ExecuteDataset(ConexionDC.ConectarApssa(), CommandType.StoredProcedure, strSql, arParams.ToArray());
            ds_proceso.Tables[0].TableName = "proceso";
            return ds_proceso;
         
          
        }


        */
    }

}



