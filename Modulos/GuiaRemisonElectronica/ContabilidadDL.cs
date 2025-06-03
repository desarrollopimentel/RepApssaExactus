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

    public class ProcesosDL
    {





        public DataTable dtListarFacturasGy_DL(string db)
        {
            //string strSql = @"  SELECT TOP 0
            //                    SPACE(10) AS PROCESAR,PROVEEDOR,TIPO,DOCUMENTO,FECHA_DOC,FECHA_RIGE,
            //                    APLICACION,SUBTOTAL,DESCUENTO,IMPUESTO1,IMPUESTO2,RUBRO_1,
            //                    RUBRO_2,MONTO,SALDO,MONEDA,CONDICION_PAGO,CUENTA_BANCARIA,
            //                    NOTAS,SUBTIPO,CENTRO_COSTO,CUENTA_CONTABLE,FECHA_CONTABLE,
            //                    RUBRO_1_DOC,RUBRO_2_DOC,RUBRO_3_DOC,RUBRO_4_DOC,RUBRO_5_DOC,
            //                    RUBRO_6_DOC,RUBRO_7_DOC,RUBRO_8_DOC,RUBRO_9_DOC,RUBRO_10_DOC,
            //                    PAQUETE,TIPO_ASIENTO,RETENCIÓN,EMBARQUE,TIPO_REFERENCIA,
            //                    DOC_REFERENCIA, 
            //                    BASE_IMPUESTO1, BASE_IMPUESTO2, FECHA_VENCE, USUARIO, CARGADO,
            //                    EMB_REFERENCIA, EMB_RUBRO1, EMB_NOTAS, EMB_CONDICIONPAGO, XML_ITEMS
            //                    FROM PIMENTEL.TMP_FACTURA_GY;
            //                 ";

            //string strSql = @"  SELECT TOP 0
            //                    SPACE(10) AS PROCESAR,PROVEEDOR,TIPO,DOCUMENTO,FECHA_DOC,                                
            //                    APLICACION,SUBTOTAL,IMPUESTO1,MONTO,SALDO,MONEDA,CONDICION_PAGO,
            //                    SUBTIPO,CENTRO_COSTO,CUENTA_CONTABLE,FECHA_CONTABLE,RUBRO_8_DOC,
            //                    PAQUETE,TIPO_ASIENTO,EMBARQUE,TIPO_REFERENCIA,DOC_REFERENCIA,
            //                    BASE_IMPUESTO1,FECHA_VENCE,USUARIO,
            //                    EMB_MONTO_LOCAL, EMB_MONTO_DOLAR,XML_ITEMS,
            //                    FECHA_RIGE,DESCUENTO,IMPUESTO2,RUBRO_1,RUBRO_2,CUENTA_BANCARIA,NOTAS,
            //                    RUBRO_1_DOC,RUBRO_2_DOC,RUBRO_3_DOC,RUBRO_4_DOC,RUBRO_5_DOC,
            //                    RUBRO_6_DOC,RUBRO_7_DOC,RUBRO_9_DOC,RUBRO_10_DOC,RETENCIÓN, 
            //                    BASE_IMPUESTO2,  CARGADO,
            //                    EMB_REFERENCIA, EMB_RUBRO1, EMB_NOTAS, EMB_CONDICIONPAGO                                
            //                    FROM PIMENTEL.TMP_FACTURA_GY WITH (NOLOCK);
            //                 ";

            string strSql = @"  SELECT TOP 0
                                SPACE(10) AS PROCESAR,PROVEEDOR,TIPO,DOCUMENTO,FECHA_DOC,                                
                                APLICACION,SUBTOTAL,IMPUESTO1,MONTO,SALDO,MONEDA,
                                0 AS DIFERENCIA,CONDICION_PAGO,
                                SUBTIPO,CENTRO_COSTO,CUENTA_CONTABLE,FECHA_CONTABLE,RUBRO_8_DOC,
                                PAQUETE,TIPO_ASIENTO,EMBARQUE,TIPO_REFERENCIA,DOC_REFERENCIA,
                                BASE_IMPUESTO1,FECHA_VENCE,USUARIO,
                                EMB_MONTO_LOCAL, EMB_MONTO_DOLAR,XML_ITEMS,
                                FECHA_RIGE,DESCUENTO,IMPUESTO2,RUBRO_1,RUBRO_2,CUENTA_BANCARIA,NOTAS,
                                RUBRO_1_DOC,RUBRO_2_DOC,RUBRO_3_DOC,RUBRO_4_DOC,RUBRO_5_DOC,
                                RUBRO_6_DOC,RUBRO_7_DOC,RUBRO_9_DOC,RUBRO_10_DOC,RETENCIÓN, 
                                BASE_IMPUESTO2,  CARGADO,
                                EMB_REFERENCIA, EMB_RUBRO1, EMB_NOTAS, EMB_CONDICIONPAGO                                
                                FROM PIMENTEL.TMP_FACTURA_GY WITH (NOLOCK);
                             ";


            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql).Tables[0];
        }

        public string BuscarEmbarque_DL(string tipo_ref, string doc_ref, string db)
        {
            string cEmbarque = string.Empty;

            string strSql = "PIMENTEL.SP_APSSA_BUSCAR_EMBARQUE";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@TIP_REF", tipo_ref));
            arParams.Add(new SqlParameter("@DOC_REF", doc_ref));

            cEmbarque = Convert.ToString(SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray()));

            return cEmbarque;
        }

    }


    public class ContabilidadDL
    {

        //SELECT DIAS_NETO FROM PIMENTEL.CONDICION_PAGO (NOLOCK) WHERE CONDICION_PAGO='F30D';
        public static string ObtenerDiasNeto_DL(string _condic, string db)
        {
            string strSql = @"SELECT TOP 1 DIAS_NETO
                              FROM PIMENTEL.CONDICION_PAGO (NOLOCK)
                              WHERE CONDICION_PAGO=@CONDICION_PAGO;
                             ";

            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@CONDICION_PAGO", _condic));

            return Convert.ToString(SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray()));
        }

        // 06092019
        // ALTER PROCEDURE [PIMENTEL].[SP_APSSA_CARGA_DOCUMENTOS_GY]
        public static DataTable dtProcesaDocumentosGY_DL(string _proveedor, string _documento, string _tipo, DateTime _fecha_documento, string _aplicacion,
                                                         Decimal _monto, Decimal _saldo, Decimal _subtotal, Decimal _descuento, Decimal _impuesto1, Decimal _impuesto2,
                                                         Decimal _rubro1, Decimal _rubro2, string _condicion_pago, string _moneda, Int16 _subtipo, DateTime _fecha_vence,
                                                         Decimal _base_impuesto1, Decimal _base_impuesto2, string _rubro8_doc, string _vcuenta_contable,
                                                         string _vcentro_costo, string _vembarque, DateTime _vfecha_proceso, string _vusuario, string _vdetraccion, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_CARGA_DOCUMENTOS_GY";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PROVEEDOR", _proveedor);
                    cmd.Parameters.AddWithValue("@DOCUMENTO", _documento);
                    cmd.Parameters.AddWithValue("@TIPO", _tipo);
                    cmd.Parameters.AddWithValue("@FECHA_DOCUMENTO", _fecha_documento);
                    cmd.Parameters.AddWithValue("@APLICACION", _aplicacion);
                    cmd.Parameters.AddWithValue("@MONTO", _monto);
                    cmd.Parameters.AddWithValue("@SALDO", _saldo);
                    cmd.Parameters.AddWithValue("@SUBTOTAL", _subtotal);
                    cmd.Parameters.AddWithValue("@DESCUENTO", _descuento);
                    cmd.Parameters.AddWithValue("@IMPUESTO1", _impuesto1);
                    cmd.Parameters.AddWithValue("@IMPUESTO2", _impuesto2);
                    cmd.Parameters.AddWithValue("@RUBRO1", _rubro1);
                    cmd.Parameters.AddWithValue("@RUBRO2", _rubro2);
                    cmd.Parameters.AddWithValue("@CONDICION_PAGO", _condicion_pago);
                    cmd.Parameters.AddWithValue("@MONEDA", _moneda);
                    cmd.Parameters.AddWithValue("@SUBTIPO", _subtipo);
                    cmd.Parameters.AddWithValue("@FECHA_VENCE", _fecha_vence);
                    cmd.Parameters.AddWithValue("@BASE_IMPUESTO1", _base_impuesto1);
                    cmd.Parameters.AddWithValue("@BASE_IMPUESTO2", _base_impuesto2);
                    cmd.Parameters.AddWithValue("@RUBRO8_DOC", _rubro8_doc);
                    cmd.Parameters.AddWithValue("@VCUENTA_CONTABLE", _vcuenta_contable);
                    cmd.Parameters.AddWithValue("@VCENTRO_COSTO", _vcentro_costo);
                    cmd.Parameters.AddWithValue("@VEMBARQUE", _vembarque);
                    cmd.Parameters.AddWithValue("@VFECHA_PROCESO", _vfecha_proceso);
                    cmd.Parameters.AddWithValue("@VUSUARIO", _vusuario);
                    cmd.Parameters.AddWithValue("@VDETRACCION", _vdetraccion);
                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    ds.Tables.Add(table);
                    cmd.Connection.Close();  //// ADD MXMX
                }
                return ds.Tables[0];
            }
        }




        //ALTER PROCEDURE[PIMENTEL].[SP_APSSA_ERR_FA_CORREGIR_ASIENTOS]
        //(@FECHA_INICIO DATETIME,
        // @FECHA_FINAL DATETIME )
        public static void CorregirAsientosFA_DL(DateTime _fecha_inicio, DateTime _fecha_final, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_ERR_FA_CORREGIR_ASIENTOS";

            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@FECHA_INICIO", _fecha_inicio));
            arParam.Add(new SqlParameter("@FECHA_FINAL", _fecha_final));

            SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParam.ToArray());

        }




        public static void Cambia_Centro_CostoDL(string _tipo_doc,string _documento,string _codigo,decimal _total,decimal _costo,string _ccosto, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_CAMBIA_CENTRO_COSTO_ASIENTO";

            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@TIPO_DOC", _tipo_doc));
            arParam.Add(new SqlParameter("@DOCUMENTO", _documento));
            arParam.Add(new SqlParameter("@CODIGO", _codigo));
            arParam.Add(new SqlParameter("@TOTAL", _total));
            arParam.Add(new SqlParameter("@COSTO", _costo));
            arParam.Add(new SqlParameter("@CENTRO_NUEVO", _ccosto));

            SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParam.ToArray());

        }






        ////ALTER procedure[PIMENTEL].[SP_APSSA_DIF_CAMBIARIA_CORREGIR]
        ////(@FECHA_INICIO DATETIME,
        //// @FECHA_FINAL DATETIME )
        ////AS
        public static void DiferenciaCambiariaCP_DL(DateTime _fecha_inicio, DateTime _fecha_final, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_DIF_CAMBIARIA_CORREGIR";

            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@FECHA_INICIO", _fecha_inicio));
            arParam.Add(new SqlParameter("@FECHA_FINAL", _fecha_final));

            SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParam.ToArray());

        }

        //ALTER PROCEDURE[PIMENTEL].[SP_APSSA_EEFF_GET_ETIQUETAS]
        //(@PAR_PERIODO INT,
        //@PAR_MES     INT,
        //@PAR_TIPO VARCHAR(50))
        public static DataTable dtObtenerEtiquetas_DL(Int16 _periodo, Int16 _mes, string _tipo, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_EEFF_GET_ETIQUETAS";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PAR_PERIODO", _periodo);
                    cmd.Parameters.AddWithValue("@PAR_MES", _mes);
                    cmd.Parameters.AddWithValue("@PAR_TIPO", _tipo);
                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    ds.Tables.Add(table);
                    cmd.Connection.Close();
                }
                return ds.Tables[0];
            }
        }



        


        public static void GrabarRegistroBaseDL(Int16 _periodo,string _tipo,string _dig2,string _cuenta_contable,string _desc_cuenta_contable,Decimal _enero,
                                                Decimal _febrero,Decimal _marzo,Decimal _abril,Decimal _mayo,Decimal _junio,Decimal _julio,Decimal _agosto,
                                                Decimal _setiembre,Decimal _octubre,Decimal _noviembre,Decimal _diciembre,Decimal _acumulado,string _centro_costo,
                                                string _desc_centro_costo,string _extraer,string _concatenar,string _funcion,string _descripcion,string _sucursal,
                                                string _naturaleza,string db)
        {
            string strSql = @"INSERT INTO PIMENTEL.APSSA_EEFF_RECLASIFICACION    
                              (PERIODO,TIPO,DIG2,CUENTA_CONTABLE,DESC_CUENTA_CONTABLE,ENERO,FEBRERO,MARZO,ABRIL,MAYO,JUNIO,
                               JULIO,AGOSTO,SETIEMBRE,OCTUBRE,NOVIEMBRE,DICIEMBRE,ACUMULADO,CENTRO_COSTO,DESC_CENTRO_COSTO,
                               EXTRAER,CONCATENAR,FUNCION,DESCRIPCION,SUCURSAL,NATURALEZA)
	                          VALUES
                              (@PERIODO,@TIPO,@DIG2,@CUENTA_CONTABLE,@DESC_CUENTA_CONTABLE,@ENERO,@FEBRERO,@MARZO,@ABRIL,@MAYO,@JUNIO,
                               @JULIO,@AGOSTO,@SETIEMBRE,@OCTUBRE,@NOVIEMBRE,@DICIEMBRE,@ACUMULADO,@CENTRO_COSTO,@DESC_CENTRO_COSTO,
                               @EXTRAER,@CONCATENAR,@FUNCION,@DESCRIPCION,@SUCURSAL,@NATURALEZA); ";

            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@PERIODO", _periodo));
            arParam.Add(new SqlParameter("@TIPO", _tipo));
            arParam.Add(new SqlParameter("@DIG2", _dig2));
            arParam.Add(new SqlParameter("@CUENTA_CONTABLE", _cuenta_contable));
            arParam.Add(new SqlParameter("@DESC_CUENTA_CONTABLE", _desc_cuenta_contable));
            arParam.Add(new SqlParameter("@ENERO", _enero));
            arParam.Add(new SqlParameter("@FEBRERO", _febrero));
            arParam.Add(new SqlParameter("@MARZO", _marzo));
            arParam.Add(new SqlParameter("@ABRIL", _abril));
            arParam.Add(new SqlParameter("@MAYO", _mayo));
            arParam.Add(new SqlParameter("@JUNIO", _junio));
            arParam.Add(new SqlParameter("@JULIO", _julio));
            arParam.Add(new SqlParameter("@AGOSTO", _agosto));
            arParam.Add(new SqlParameter("@SETIEMBRE", _setiembre));
            arParam.Add(new SqlParameter("@OCTUBRE", _octubre));
            arParam.Add(new SqlParameter("@NOVIEMBRE", _noviembre));
            arParam.Add(new SqlParameter("@DICIEMBRE", _diciembre));
            arParam.Add(new SqlParameter("@ACUMULADO", _acumulado));
            arParam.Add(new SqlParameter("@CENTRO_COSTO", _centro_costo));
            arParam.Add(new SqlParameter("@DESC_CENTRO_COSTO", _desc_centro_costo));
            arParam.Add(new SqlParameter("@EXTRAER", _extraer));
            arParam.Add(new SqlParameter("@CONCATENAR", _concatenar));
            arParam.Add(new SqlParameter("@FUNCION", _funcion));
            arParam.Add(new SqlParameter("@DESCRIPCION", _descripcion));
            arParam.Add(new SqlParameter("@SUCURSAL", _sucursal));
            arParam.Add(new SqlParameter("@NATURALEZA", _naturaleza));

            SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray());
        }



        //ALTER PROCEDURE[PIMENTEL].[SP_APSSA_EEFF_GET_RECLASIFICACION]
        //(@PAR_PERIODO INT,
        //@PAR_MES     INT)
        public static DataTable dtEEFFObtenerReclasificacion_DL(Int16 _periodo, Int16 _mes, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_EEFF_GET_RECLASIFICACION";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PAR_PERIODO", _periodo);
                    cmd.Parameters.AddWithValue("@PAR_MES", _mes);
                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    ds.Tables.Add(table);
                    cmd.Connection.Close();
                }
                return ds.Tables[0];
            }
        }

        //ALTER PROCEDURE[PIMENTEL].[SP_APSSA_EEFF_GET_BASE_HISTORICO]
        //(@PAR_PERIODO INT,
        //@PAR_MES     INT,
        //@PAR_TIPO VARCHAR(50))
        public static DataTable dtEEFFObtenerBaseHistorico_DL(Int16 _periodo, Int16 _mes,string _tipo,  string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_EEFF_GET_BASE_HISTORICO";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PAR_PERIODO", _periodo);
                    cmd.Parameters.AddWithValue("@PAR_MES", _mes);
                    cmd.Parameters.AddWithValue("@PAR_TIPO", _tipo);
                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    ds.Tables.Add(table);
                    cmd.Connection.Close();
                }
                return ds.Tables[0];
            }
        }


        public static DataTable dtEEFFObtenerPresupuestos_DL(Int16 _periodo, Int16 _mes, string _tipo, string _subtipo,
                                                           string _unidad, string _concepto, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_EEFF_GET_PRESUPUESTOS";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PAR_PERIODO", _periodo);
                    cmd.Parameters.AddWithValue("@PAR_MES", _mes);
                    cmd.Parameters.AddWithValue("@TIPO", _tipo);
                    cmd.Parameters.AddWithValue("@SUBTIPO", _subtipo);
                    cmd.Parameters.AddWithValue("@UNIDAD", _unidad);
                    cmd.Parameters.AddWithValue("@CONCEPTO", _concepto);

                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    ds.Tables.Add(table);
                    cmd.Connection.Close();
                }
                return ds.Tables[0];
            }
        }

        //ALTER PROCEDURE[PIMENTEL].[SP_APSSA_EEFF_GET_INDICADORES]
        //(@PERIODO INT,
        //@INDICADOR VARCHAR(50),
        //@TIPO VARCHAR(50),
        //@SUBTIPO VARCHAR(50) )
        public static DataTable dtEEFFObtenerIndicadores_DL(Int16 _periodo,string _indicador,string _tipo, string _subtipo, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_EEFF_GET_INDICADORES";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PERIODO", _periodo);
                    cmd.Parameters.AddWithValue("@INDICADOR", _indicador);
                    cmd.Parameters.AddWithValue("@TIPO", _tipo);
                    cmd.Parameters.AddWithValue("@SUBTIPO", _subtipo);
                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    ds.Tables.Add(table);
                    cmd.Connection.Close();
                }
                return ds.Tables[0];
            }
        }


        //ALTER PROCEDURE[PIMENTEL].[SP_APSSA_EEFF_GET_PARAMETROS]
        //(@PAR_PERIODO INT,
        //@PAR_MES     INT,
        //@TIPO VARCHAR(50),
        //@SUBTIPO VARCHAR(50),
        //@UNIDAD VARCHAR(50),
        //@CONCEPTO VARCHAR(50))

        //20/09/2018
        public static DataTable dtEEFFObtenerParametros_DL(Int16 _periodo, Int16 _mes, string _tipo, string _subtipo,
                                                           string _unidad, string _concepto,  string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_EEFF_GET_PARAMETROS";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PAR_PERIODO", _periodo);
                    cmd.Parameters.AddWithValue("@PAR_MES", _mes);
                    cmd.Parameters.AddWithValue("@TIPO", _tipo);
                    cmd.Parameters.AddWithValue("@SUBTIPO", _subtipo);
                    cmd.Parameters.AddWithValue("@UNIDAD", _unidad);
                    cmd.Parameters.AddWithValue("@CONCEPTO", _concepto);

                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    ds.Tables.Add(table);
                    cmd.Connection.Close();
                }
                return ds.Tables[0];
            }
        }


        //20/09/2018
        //ALTER PROCEDURE[PIMENTEL].[SP_APSSA_EEFF_GET_RESUMEN_MARKETING]
        //(@PAR_PERIODO INT,
        //@PAR_MES     INT)
        public static DataTable dtObtenerResumenMarketing_DL(Int16 _periodo, Int16 _mes, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_EEFF_GET_RESUMEN_MARKETING";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PAR_PERIODO", _periodo);
                    cmd.Parameters.AddWithValue("@PAR_MES", _mes);
                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    ds.Tables.Add(table);
                    cmd.Connection.Close();
                }
                return ds.Tables[0];
            }
        }

        //ALTER PROCEDURE[PIMENTEL].[SP_APSSA_EEFF_GET_BASE_VISTA]
        //(@PAR_PERIODO INT,
        //@PAR_MES     INT)
        public static DataTable dtObtenerInformacionBaseVista_DL(Int16 _per, Int16 _mes, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_EEFF_GET_BASE_VISTA";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PAR_PERIODO", _per);
                    cmd.Parameters.AddWithValue("@PAR_MES", _mes);
                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    ds.Tables.Add(table);
                    cmd.Connection.Close();
                }
                return ds.Tables[0];
            }
        }

        //ALTER PROCEDURE[PIMENTEL].[SP_APSSA_EEFF_GET_BASE_HISTORICO]
        //(@PAR_PERIODO INT,
        //@PAR_MES     INT,
        //@PAR_TIPO VARCHAR(50))
        public static DataTable dtObtenerInformacionBaseHistorico_DL(Int16 _per, Int16 _mes, string _tipo, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_EEFF_GET_BASE_HISTORICO";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PAR_PERIODO", _per);
                    cmd.Parameters.AddWithValue("@PAR_MES", _mes);
                    cmd.Parameters.AddWithValue("@PAR_TIPO", _tipo);
                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    ds.Tables.Add(table);
                    cmd.Connection.Close();
                }
                return ds.Tables[0];
            }
        }

        //ALTER PROCEDURE[PIMENTEL].[SP_APSSA_EEFF_GET_BASE]
        //(@PAR_PERIODO INT,
        //@PAR_MES     INT,
        //@PAR_TIPO VARCHAR(50))
        public static DataTable dtObtenerInformacionBase_DL(Int16 _per, Int16 _mes, string _tipo, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_EEFF_GET_BASE";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PAR_PERIODO", _per);
                    cmd.Parameters.AddWithValue("@PAR_MES", _mes);
                    cmd.Parameters.AddWithValue("@PAR_TIPO", _tipo);
                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    ds.Tables.Add(table);
                    cmd.Connection.Close();
                }
                return ds.Tables[0];
            }
        }

        //ALTER PROCEDURE[PIMENTEL].[SP_APSSA_EEFF_GET_BASE_GENERAR]
        //(@PAR_PERIODO INT,
        // @PAR_MES     INT,
        // @TEMPORAL VARCHAR(2)) -- SI, NO
        public static DataTable dtGenerarInformacionBase_DL(Int16 _per, Int16 _mes, string _temporal, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_EEFF_GET_BASE_GENERAR";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PAR_PERIODO", _per);
                    cmd.Parameters.AddWithValue("@PAR_MES", _mes);
                    cmd.Parameters.AddWithValue("@TEMPORAL", _temporal);
                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    ds.Tables.Add(table);
                    cmd.Connection.Close();
                }
                return ds.Tables[0];
            }
        }

        // 20/09/2018   -- 31/08/2018
        //ALTER PROCEDURE[PIMENTEL].[SP_APSSA_EEFF_GET_MOVIMIENTOS_POR_CC]
        //(@FECHA_INI DATETIME,
        //@FECHA_FIN DATETIME )
        public static DataTable dtObtenerMovimientosPorCC_DL(DateTime _fecha_ini, DateTime _fecha_fin, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_EEFF_GET_MOVIMIENTOS_POR_CC";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FECHA_INI", _fecha_ini);
                    cmd.Parameters.AddWithValue("@FECHA_FIN", _fecha_fin);
                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    ds.Tables.Add(table);
                    cmd.Connection.Close();
                }
                return ds.Tables[0];
            }
        }

        // 20/09/2018   -- 29/08/2018
        //ALTER PROCEDURE[PIMENTEL].[SP_APSSA_EEFF_GET_CUENTAS]
        //(@FECHA_INI DATETIME,
        //@FECHA_FIN DATETIME )
        public static DataTable dtObtenerCuentasdelMayorDL(DateTime _fecha_ini, DateTime _fecha_fin, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_EEFF_GET_CUENTAS";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FECHA_INI", _fecha_ini);
                    cmd.Parameters.AddWithValue("@FECHA_FIN", _fecha_fin);
                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    ds.Tables.Add(table);
                    cmd.Connection.Close();
                }
                return ds.Tables[0];
            }
        }

        public static bool ExisteShipToDL(string _shipto, string db)
        {
            int NumReg = 0;
            string strSql = @"SELECT SHIPTO FROM PIMENTEL.APSSA_SHIPTO (NOLOCK) WHERE SHIPTO=@SHIPTO ;";

            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@SHIPTO", _shipto));

            NumReg = Convert.ToInt32(SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray()));
            return NumReg > 0;
        }


        //SELECT PIMENTEL.Fn_APSSA_GET_FAMILIA_CODE('100350');
        public static string ObtenerFamiliaDeArticuloDL(string _articulo, string db)
        {
            string cArticulo = "";
            string strSql = @"SELECT PIMENTEL.Fn_APSSA_GET_FAMILIA_CODE(@ARTICULO);";
            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@ARTICULO", _articulo));
            cArticulo = SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParams.ToArray()).ToString();
            return cArticulo;
        }


        //select TIENDA,ABREVIATURA,SHIPTO from pimentel.APSSA_SHIPTO (NOLOCK) WHERE SHIPTO=@SHIPTO
        public static string ObtenerTiendaFromShipToDL(string _shipto, string db)
        {
            string cTienda = "";
            string strSql = @"SELECT TIENDA FROM PIMENTEL.APSSA_SHIPTO (NOLOCK) WHERE SHIPTO=@SHIPTO ;";
            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@SHIPTO", _shipto));
            cTienda = SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParams.ToArray()).ToString();
            return cTienda;
        }

        //ALTER PROCEDURE[PIMENTEL].[SP_APSSA_NOTACREDITO_CARGA]
        //(@PAR_DOCUMENTO VARCHAR(50),
        //@PAR_TIPO VARCHAR(3), 
        //@PAR_SUBTIPODOC INT,
        //@PAR_FECHA_DOCUMENTO DATETIME, 
        //@PAR_FECHA_CONTABLE DATETIME,      -- FECHA ASIENTO
        //@PAR_FECHA_VCMTO DATETIME,         -- NEW
        //@PAR_PROVEEDOR VARCHAR(20),
        //@PAR_MONEDA VARCHAR(4), 
        //@PAR_TIPO_CAMBIO DECIMAL(28, 8), 
        //@PAR_CONDICION_PAGO VARCHAR(4),	-- NEW
        //@PAR_SUBTOTAL DECIMAL(28, 8), 
        //@PAR_DESCUENTO DECIMAL(28, 8), 
        //@PAR_IMPUESTO1 DECIMAL(28, 8), -- IGV
        //@PAR_IMPUESTO2 DECIMAL(28, 8), 
        //@PAR_RUBRO1 DECIMAL(28, 8),	-- INAFECTO
        //@PAR_RUBRO2 DECIMAL(28, 8),
        //@PAR_MONTO DECIMAL(28, 8), 
        //@PAR_CUENTA_CONTABLE VARCHAR(25),
        //@PAR_CENTRO_COSTO VARCHAR(25),
        //@PAR_APLICACION VARCHAR(254),
        //@PAR_USUARIO VARCHAR(25),
        //@PAR_FECHA_PROCESO DATETIME,
        //@PAR_TIPO_NC VARCHAR(10) )	

        public static DataTable dtCargaNotasCreditoDL(string _documento, string _tipo, Int16 _subtipo, DateTime _fecha_documento, DateTime _fecha_contable, 
                                                      DateTime _fecha_vcmto, string _proveedor,string _moneda, Decimal _tipo_cambio, string _condicion_pago,
                                                      Decimal _subtotal, Decimal _descuento, Decimal _impuesto1,Decimal _impuesto2, Decimal _rubro1, Decimal _rubro2, 
                                                      Decimal _monto,string _cuenta_contable, string _centro_costo, string _aplicacion, string _usuario,
                                                      DateTime _fecha_proceso,string _tipo_nc, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_NOTACREDITO_CARGA";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PAR_DOCUMENTO", _documento);
                    cmd.Parameters.AddWithValue("@PAR_TIPO", _tipo);
                    cmd.Parameters.AddWithValue("@PAR_SUBTIPO", _subtipo);
                    cmd.Parameters.AddWithValue("@PAR_FECHA_DOCUMENTO", _fecha_documento);
                    cmd.Parameters.AddWithValue("@PAR_FECHA_CONTABLE", _fecha_contable);
                    cmd.Parameters.AddWithValue("@PAR_FECHA_VCMTO", _fecha_vcmto);
                    cmd.Parameters.AddWithValue("@PAR_PROVEEDOR", _proveedor);
                    cmd.Parameters.AddWithValue("@PAR_MONEDA", _moneda);
                    cmd.Parameters.AddWithValue("@PAR_TIPO_CAMBIO", _tipo_cambio);
                    cmd.Parameters.AddWithValue("@PAR_CONDICION_PAGO", _condicion_pago);
                    cmd.Parameters.AddWithValue("@PAR_SUBTOTAL", _subtotal);
                    cmd.Parameters.AddWithValue("@PAR_DESCUENTO", _descuento);
                    cmd.Parameters.AddWithValue("@PAR_IMPUESTO1", _impuesto1);
                    cmd.Parameters.AddWithValue("@PAR_IMPUESTO2", _impuesto2);
                    cmd.Parameters.AddWithValue("@PAR_RUBRO1", _rubro1);
                    cmd.Parameters.AddWithValue("@PAR_RUBRO2", _rubro2);
                    cmd.Parameters.AddWithValue("@PAR_MONTO", _monto);
                    cmd.Parameters.AddWithValue("@PAR_CUENTA_CONTABLE", _cuenta_contable);
                    cmd.Parameters.AddWithValue("@PAR_CENTRO_COSTO", _centro_costo);
                    cmd.Parameters.AddWithValue("@PAR_APLICACION", _aplicacion);
                    cmd.Parameters.AddWithValue("@PAR_USUARIO", _usuario);                  //
                    cmd.Parameters.AddWithValue("@PAR_FECHA_PROCESO", _fecha_proceso);      //            
                    cmd.Parameters.AddWithValue("@PAR_TIPO_NC", _tipo_nc);                  //
                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    ds.Tables.Add(table);
                    cmd.Connection.Close();  //// ADD MXMX
                }
                return ds.Tables[0];
            }
        }


        /*
            string strSql = @"  DECLARE @TIPO_CAMBIO DECIMAL(28,6), @RETENCIONES VARCHAR(10);
                                SELECT TOP 0 SPACE(10) AS PROCESAR,
                                SPACE(10) AS PROCESAR,SPACE(50) AS VALIDACION, DOCUMENTO, TIPO, SPACE(20) AS SUBTIPO, SPACE(5) AS SUBTIPODOC,
                                FECHA_DOC AS FECHA_DOCUMENTO, FECHA_DOC AS FECHA_VCMTO,FECHA_DOC AS FECHA_CONTABLE,PROVEEDOR, MONEDA,
                                @TIPO_CAMBIO AS TIPO_CAMBIO, SUBTOTAL, SUBTOTAL AS DESCUENTO, CONDICION_PAGO,
                                IMPUESTO1 AS IGV, IMPUESTO1 AS IMPUESTO2,RUBRO_1 AS INAFECTO, RUBRO_2 AS RUBRO2,
                                MONTO, SPACE(50) AS CUENTA_BANCO, CUENTA_CONTABLE, CENTRO_COSTO, APLICACION                                
                                FROM PIMENTEL.TMP_FACTURA_GY WITH (NOLOCK);
        */
        public static DataTable dtListarCamposExcelNotaCredito2DL(string db) //grid FACTURA
        {
            string strSql = @"  DECLARE @TIPO_CAMBIO DECIMAL(28,6), @RETENCIONES VARCHAR(10), @VALOR_CERO DECIMAL(20,2);
                                SELECT TOP 0 SPACE(10) AS PROCESAR, 
                                SPACE(50) AS DOCUMENTO, SPACE(25) AS TIPO, SPACE(25) AS SUBTIPO,
                                FECHA_DOC AS FECHA_DOCUMENTO, FECHA_DOC AS FECHA_CONTABLE,FECHA_DOC AS FECHA_VCMTO,PROVEEDOR, 
                                MONEDA, @TIPO_CAMBIO AS TIPO_CAMBIO, CONDICION_PAGO, SUBTOTAL, SUBTOTAL AS DESCUENTO,  
                                IMPUESTO1 AS IGV, IMPUESTO1 AS IMPUESTO2,RUBRO_1 AS INAFECTO, RUBRO_2 AS RUBRO2,
                                MONTO, CUENTA_CONTABLE, CENTRO_COSTO, APLICACION, 
                                SPACE(10) AS TIPO_NC,
                                SPACE(50) AS SHIPTO, SPACE(20) AS PEDIDO, FECHA_DOC AS FECHA_PEDIDO,
                                FECHA_DOC AS  FECHA_ENTREGA, SPACE(25) AS CODIGO, SPACE(250) AS DESCRIPCION, SPACE(15) AS UNIDAD,
                                SPACE(50) AS NUMERO_FE, FECHA_DOC AS FECHA_CREA, @VALOR_CERO AS CANTIDAD, @VALOR_CERO AS VALOR
                                FROM PIMENTEL.TMP_FACTURA_GY WITH (NOLOCK);
                             ";

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql).Tables[0];
        }

        public static DataTable dtListarCamposExcelNotaCreditoDL(string db)
        {
            string strSql = @"  DECLARE @TIPO_CAMBIO DECIMAL(28,6), @RETENCIONES VARCHAR(10), @VALOR_CERO DECIMAL(20,2);
                                SELECT TOP 0 SPACE(10) AS PROCESAR,SPACE(10) AS TIPO_NC,
                                SPACE(50) AS SHIPTO, SPACE(20) AS PEDIDO, FECHA_DOC AS FECHA_PEDIDO,
                                FECHA_DOC AS  FECHA_ENTREGA, SPACE(25) AS CODIGO, SPACE(250) AS DESCRIPCION, SPACE(15) AS UNIDAD,
                                SPACE(50) AS NUMERO_FE, FECHA_DOC AS FECHA_CREA, @VALOR_CERO AS CANTIDAD, @VALOR_CERO AS VALOR,SPACE(10) AS MONEDA
                                FROM PIMENTEL.TMP_FACTURA_GY WITH (NOLOCK);
                             ";

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql).Tables[0];
        }

        //SELECT PIMENTEL.Fn_APSSA_GET_TIPO_CAMBIO_FECHA('TCOM', '26/06/2018');  -- segun fecha del documento
        //SELECT PIMENTEL.Fn_APSSA_GET_TIPO_CAMBIO_FECHA('TVTA', '26/06/2018');  -- segun fecha del documento
        public static Decimal ObtenerTipoCambioFechaDL(string _tipo, DateTime _fecha, string db)
        {
            Decimal nTipoCambio = 0;

            string strSql = @"SELECT PIMENTEL.Fn_APSSA_GET_TIPO_CAMBIO_FECHA(@TIPO, @FECHA) ; ";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@TIPO", _tipo));
            arParams.Add(new SqlParameter("@FECHA", _fecha));

            nTipoCambio = Convert.ToDecimal(SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParams.ToArray()));

            return nTipoCambio;
        }



        public static string Valida_centroDL(string _tipo, string _documento, string _codigo, decimal _costo_soles, decimal _total,string _ccosto, string db)
        {
            
            string strSql = @"SELECT PIMENTEL.Fn_APSSA_CENTRO_COSTO_VALIDA(@TIPO_DOC,@DOCUMENTO,@CODIGO,@TOTAL,@COSTO,@CENTRO_NUEVO) ; ";
            

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@TIPO_DOC", _tipo));
            arParams.Add(new SqlParameter("@DOCUMENTO", _documento));
            arParams.Add(new SqlParameter("@CODIGO", _codigo));
            arParams.Add(new SqlParameter("@TOTAL", _total));
            arParams.Add(new SqlParameter("@COSTO", _costo_soles));
            arParams.Add(new SqlParameter("@CENTRO_NUEVO", _ccosto));

            return  Convert.ToString(SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParams.ToArray()));

            
        }


        //ALTER PROCEDURE[PIMENTEL].[SP_APSSA_FE_UPDATE_DOCUMENTO]
        //(@TIPO_DOCUMENTO VARCHAR(1),
        //@FACTURA VARCHAR(50),
        //@ESTADO_SUNAT VARCHAR(1),		 -- '0','1','2','3','4'
        //@MENSAJE_ESTADO VARCHAR(250),   
        //@ESTADO_TRANSMISION VARCHAR(1), -- 'P','E','B'
        //@MOTIVO_BAJA VARCHAR(250))
        public static void ActualizaDocumentoFeDL(string _tipo, string _documento, string _estado, string _mensaje,
                                                  string _transmision, string _motivo, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_FE_UPDATE_DOCUMENTO";

            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@TIPO_DOCUMENTO", _tipo));
            arParam.Add(new SqlParameter("@FACTURA", _documento));
            arParam.Add(new SqlParameter("@ESTADO_SUNAT", _estado));
            arParam.Add(new SqlParameter("@MENSAJE_ESTADO", _mensaje));
            arParam.Add(new SqlParameter("@ESTADO_TRANSMISION", _transmision));
            arParam.Add(new SqlParameter("@MOTIVO_BAJA", _motivo));

            SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParam.ToArray());

        }






        //centro-cuenta ADD 10/08/2018
        //SELECT * FROM PIMENTEL.CENTRO_CUENTA (NOLOCK) WHERE CENTRO_COSTO='01.04.95.07.00'  AND CUENTA_CONTABLE='63.3.1.1.02' ;
        public static bool ExisteCentroCuentaDL(string _ccosto, string _ccontable, string db)
        {
            int NumReg = 0;
            string strSql = @"SELECT COUNT(*) FROM PIMENTEL.CENTRO_CUENTA WITH (NOLOCK)
                              WHERE CENTRO_COSTO = @CENTRO_COSTO AND CUENTA_CONTABLE=@CUENTA_CONTABLE
                             ";

            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@CENTRO_COSTO", _ccosto));
            arParam.Add(new SqlParameter("@CUENTA_CONTABLE", _ccontable));

            NumReg = Convert.ToInt32(SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray()));
            return NumReg > 0;
        }

        public static DataTable dtObtenerCamposReclasificacionExcelBiMonedaDL(string db)
        {
            string strSql = @"  DECLARE @TIPO_CAMBIO DECIMAL (28,8);                                
                                SELECT TOP 0 SPACE(10) AS PROCESAR,SPACE(50) AS VALIDACION,
                                ATI.CONSECUTIVO, TRANS.NIT, 
                                ATI.FECHA_HORA AS FECHA_DOCUMENTO,-- CONVERTIR
                                TRANS.BODEGA, TRANS.LOCALIZACION, SPACE(20) AS ARTICULO, TRANS.NATURALEZA, TRANS.CANTIDAD, 
                                TRANS.COSTO_TOT_FISC_LOC AS COSTO_UNITARIO_LOCAL, TRANS.COSTO_TOT_FISC_LOC AS COSTO_TOTAL_LOCAL,
                                TRANS.COSTO_TOT_FISC_LOC AS COSTO_UNITARIO_DOLAR, TRANS.COSTO_TOT_FISC_LOC AS COSTO_TOTAL_DOLAR,
                                SPACE(25) AS CUENTA_CONTABLE, SPACE(25) AS CENTRO_COSTO, 
                                ATI.FECHA_HORA AS FECHA_CONTABLE,-- CONVERTIR
                                SPACE(4) AS MONEDA, @TIPO_CAMBIO AS TIPO_CAMBIO, 
                                TRANS.TIPO, TRANS.SUBTIPO, ATI.PAQUETE_INVENTARIO, ATI.MODULO_ORIGEN,
                                GETDATE() AS FECHA_PROCESO, SPACE(25) AS USUARIO,
                                ATI.AUDIT_TRANS_INV, ATI.APLICACION, ATI.ASIENTO
                                FROM PIMENTEL.AUDIT_TRANS_INV ATI  (NOLOCK)  
                                INNER JOIN PIMENTEL.TRANSACCION_INV TRANS  (NOLOCK) ON TRANS.AUDIT_TRANS_INV = ATI.AUDIT_TRANS_INV;
                             ";

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql).Tables[0];
        }

        //ALTER PROCEDURE[PIMENTEL].[SP_APSSA_RECLASIFICACION_CI_GET_VISTAS_BIMONEDA]
        //(@TIPO_COSTO VARCHAR(4),	-- 'UNIT', 'PROM'
        //@FAMILIA VARCHAR(2),	-- 'LL'
        //@SOLO_GY VARCHAR(2))   -- 'SI','NO'        

        //BIMONEDA
        public static DataTable dtObtenerStockCostoPorTipoBiMoneda_DL(string _tipo, string _fam, string _gy, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_RECLASIFICACION_CI_GET_VISTAS_BIMONEDA";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TIPO_COSTO", _tipo);
                    cmd.Parameters.AddWithValue("@FAMILIA", _fam);
                    cmd.Parameters.AddWithValue("@SOLO_GY", _gy);
                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    ds.Tables.Add(table);
                    cmd.Connection.Close();
                }
                return ds.Tables[0];
            }
        }

        //EXEC PIMENTEL.SP_APSSA_RECLASIFICACION_CI_PROCESA_BIMONEDA;  BIMONEDA
        public static DataTable dtProcesaReclasificacionBiMonedaCI_DL(string _consecutivo, string _nit, DateTime _fecha_documento, string _bodega, string _localizacion,
                                                                      string _articulo, string _naturaleza, Decimal _cantidad, 
                                                                      Decimal _costo_unitario_local, Decimal _costo_total_local,
                                                                      Decimal _costo_unitario_dolar, Decimal _costo_total_dolar,
                                                                      string _cuenta_contable, string _centro_costo, DateTime _fecha_contable, string _moneda,
                                                                      Decimal _tipo_cambio, string _tipo, string _subtipo, string _paquete_inventario,
                                                                      string _modulo_origen, Int32 _audit_trans_inv, string _aplicacion, string _asiento,
                                                                      DateTime _fecha_proceso, string _usuario, Int32 _corre_reclasif, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_RECLASIFICACION_CI_PROCESA_BIMONEDA";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PAR_CONSECUTIVO", _consecutivo);
                    cmd.Parameters.AddWithValue("@PAR_NIT", _nit);
                    cmd.Parameters.AddWithValue("@PAR_FECHA_DOCUMENTO", _fecha_documento);
                    cmd.Parameters.AddWithValue("@PAR_BODEGA", _bodega);
                    cmd.Parameters.AddWithValue("@PAR_LOCALIZACION", _localizacion);
                    cmd.Parameters.AddWithValue("@PAR_ARTICULO", _articulo);
                    cmd.Parameters.AddWithValue("@PAR_NATURALEZA", _naturaleza);
                    cmd.Parameters.AddWithValue("@PAR_CANTIDAD", _cantidad);
                    cmd.Parameters.AddWithValue("@PAR_COSTO_UNITARIO_LOCAL", _costo_unitario_local);
                    cmd.Parameters.AddWithValue("@PAR_COSTO_TOTAL_LOCAL", _costo_total_local);
                    cmd.Parameters.AddWithValue("@PAR_COSTO_UNITARIO_DOLAR", _costo_unitario_dolar);        // --- ADD
                    cmd.Parameters.AddWithValue("@PAR_COSTO_TOTAL_DOLAR", _costo_total_dolar);              // --- ADD
                    cmd.Parameters.AddWithValue("@PAR_CUENTA_CONTABLE", _cuenta_contable);
                    cmd.Parameters.AddWithValue("@PAR_CENTRO_COSTO", _centro_costo);
                    cmd.Parameters.AddWithValue("@PAR_FECHA_CONTABLE", _fecha_contable);
                    cmd.Parameters.AddWithValue("@PAR_MONEDA", _moneda);
                    cmd.Parameters.AddWithValue("@PAR_TIPO_CAMBIO", _tipo_cambio);
                    cmd.Parameters.AddWithValue("@PAR_TIPO", _tipo);
                    cmd.Parameters.AddWithValue("@PAR_SUBTIPO", _subtipo);
                    cmd.Parameters.AddWithValue("@PAR_PAQUETE_INVENTARIO", _paquete_inventario);
                    cmd.Parameters.AddWithValue("@PAR_MODULO_ORIGEN", _modulo_origen);
                    cmd.Parameters.AddWithValue("@PAR_AUDIT_TRANS_INV", _audit_trans_inv);
                    cmd.Parameters.AddWithValue("@PAR_APLICACION", _aplicacion);
                    cmd.Parameters.AddWithValue("@PAR_ASIENTO", _asiento);
                    cmd.Parameters.AddWithValue("@PAR_FECHA_PROCESO", _fecha_proceso);
                    cmd.Parameters.AddWithValue("@PAR_USUARIO", _usuario);
                    cmd.Parameters.AddWithValue("@PAR_CORRE_RECLASIFICACION", _corre_reclasif);
                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    ds.Tables.Add(table);
                    cmd.Connection.Close();  //// ADD MXMX

                }
                return ds.Tables[0];
            }
        }

        //OBTIENE STOCK Y COSTOS BIMONEDA
        public static DataTable dtReprocesarStockCostoBiMoneda_DL(DateTime _fecha_rep, string _moneda, string _bodega_ini, string _bodega_fin,
                                                          string _arti_ini, string _arti_fin, string _familia, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_RECLASIFICACION_CI_GET_STOCK_BIMONEDA";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FECHA_REP", _fecha_rep);
                    cmd.Parameters.AddWithValue("@MONEDA", _moneda);
                    cmd.Parameters.AddWithValue("@BODEGA_INI", _bodega_ini);
                    cmd.Parameters.AddWithValue("@BODEGA_FIN", _bodega_fin);
                    cmd.Parameters.AddWithValue("@ARTICULO_INI", _arti_ini);
                    cmd.Parameters.AddWithValue("@ARTICULO_FIN", _arti_fin);
                    cmd.Parameters.AddWithValue("@FAMILIA", _familia);
                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    ds.Tables.Add(table);
                    cmd.Connection.Close();
                }
                return ds.Tables[0];
            }
        }



        //ALTER PROCEDURE[PIMENTEL].[SP_APSSA_RECLASIFICACION_CI_GET_VISTAS]
        //(@TIPO VARCHAR(4))  --UNIT, PROM
        public static DataTable dtObtenerStockCostoPorTipo_DL(string _tipo, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_RECLASIFICACION_CI_GET_VISTAS";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TIPO", _tipo);
                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    ds.Tables.Add(table);
                    cmd.Connection.Close();
                }
                return ds.Tables[0];
            }
        }


        public static DataTable dtObtenerStockCostoUnit_DL(DateTime _fecha_rep, string _moneda, string _bodega_ini, string _bodega_fin,
                                                          string _arti_ini, string _arti_fin, string _familia, string db)
        {
            //string strSql = @"  SELECT * FROM PIMENTEL.TMP_APSSA_RECL_DET_SOLES (NOLOCK) 
	           //                 ORDER BY ARTICULO;        ";
            //return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql).Tables[0];

            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = @"  SELECT * FROM PIMENTEL.TMP_APSSA_RECL_DET_SOLES (NOLOCK) ORDER BY ARTICULO;";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    ds.Tables.Add(table);
                    cmd.Connection.Close();
                }
                return ds.Tables[0];
            }
        }

        public static DataTable dtObtenerStockCostoProm_DL(DateTime _fecha_rep, string _moneda, string _bodega_ini, string _bodega_fin,
                                                          string _arti_ini, string _arti_fin, string _familia, string db)
        {
            //string strSql = @"  SELECT * FROM PIMENTEL.TMP_APSSA_RECL_RES_SOLES (NOLOCK) 
            //                 ORDER BY ARTICULO;         ";
            //return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql).Tables[0];

            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = @"  SELECT * FROM PIMENTEL.TMP_APSSA_RECL_RES_SOLES (NOLOCK) ORDER BY ARTICULO;";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    ds.Tables.Add(table);
                    cmd.Connection.Close();
                }
                return ds.Tables[0];
            }
        }

        public static DataTable dtObtenerTemporalReclaDetalleSoles_DL(string db)
        {
            string strSql = @"  SELECT * FROM PIMENTEL.TMP_APSSA_RECL_DET_SOLES (NOLOCK) 
	                            ORDER BY ARTICULO;
                             ";

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql).Tables[0];
        }


        //ALTER PROCEDURE[PIMENTEL].[SP_APSSA_RECLASIFICACION_CI_GET_STOCK]
        //(@FECHA_REP DATETIME,
        //@MONEDA  VARCHAR(4),
        //@BODEGA_INI VARCHAR(4),
        //@BODEGA_FIN VARCHAR(4),
        //@ARTICULO_INI VARCHAR(20),
        //@ARTICULO_FIN VARCHAR(20),
        //@FAMILIA VARCHAR(12))		--- CLASIFICACION_1 = 'LL'
        public static DataTable dtReprocesarStockCosto_DL(DateTime _fecha_rep, string _moneda, string _bodega_ini, string  _bodega_fin,
                                                          string _arti_ini, string _arti_fin, string _familia, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_RECLASIFICACION_CI_GET_STOCK";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FECHA_REP", _fecha_rep);
                    cmd.Parameters.AddWithValue("@MONEDA", _moneda);
                    cmd.Parameters.AddWithValue("@BODEGA_INI", _bodega_ini);
                    cmd.Parameters.AddWithValue("@BODEGA_FIN", _bodega_fin);
                    cmd.Parameters.AddWithValue("@ARTICULO_INI", _arti_ini);
                    cmd.Parameters.AddWithValue("@ARTICULO_FIN", _arti_fin);
                    cmd.Parameters.AddWithValue("@FAMILIA", _familia);
                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    ds.Tables.Add(table);
                    cmd.Connection.Close();
                }
                return ds.Tables[0];
            }
        }




        //Obtiene Remisiones y Reservados        
        //ALTER PROCEDURE[PIMENTEL].[SP_APSSA_RECLASIFICACION_CI_GET_REMSES]
        //(@FECHA_INI Datetime,
        //@FECHA_FIN Datetime,
        //@BODEGA VARCHAR(MAX),
        //@FAMILIA VARCHAR(MAX),
        //@SUBFAMILIA VARCHAR(MAX),
        //@GRUPO VARCHAR(MAX))

        public static DataTable dtObtenerRemRes_DL(DateTime _fecha_ini, DateTime _fecha_fin, string _bodega, string _familia, 
                                                   string _subfamilia, string _grupo, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_RECLASIFICACION_CI_GET_REMSES";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FECHA_INI", _fecha_ini);
                    cmd.Parameters.AddWithValue("@FECHA_FIN", _fecha_fin);
                    cmd.Parameters.AddWithValue("@BODEGA", _bodega);
                    cmd.Parameters.AddWithValue("@FAMILIA", _familia);
                    cmd.Parameters.AddWithValue("@SUBFAMILIA", _subfamilia);
                    cmd.Parameters.AddWithValue("@GRUPO", _grupo);
                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    ds.Tables.Add(table);
                    cmd.Connection.Close();
                }
                return ds.Tables[0];
            }
        }




        //EXEC PIMENTEL.SP_APSSA_RECLASIFICACION_CI_PROCESA;

        //ALTER PROCEDURE[PIMENTEL].[SP_APSSA_RECLASIFICACION_CI_PROCESA]
        //@PAR_CONSECUTIVO VARCHAR(10),				----- 'RECL'
        //@PAR_NIT VARCHAR(20),						----- '20100025915'
        //@PAR_FECHA_DOCUMENTO DATETIME,            ----- '18/07/2018'
        //@PAR_BODEGA VARCHAR(4),					----- '0004'
        //@PAR_LOCALIZACION VARCHAR(8),				----- '0'
        //@PAR_ARTICULO VARCHAR(20),				----- '100353'
        //@PAR_NATURALEZA VARCHAR(1),				-----  'E', 'S'
        //@PAR_CANTIDAD DECIMAL(28,8),				----- 50
        //@PAR_COSTO_UNITARIO_LOCAL DECIMAL(28,8),  ----- 95.83
        //@PAR_COSTO_TOTAL_LOCAL DECIMAL(28,8),     ----- 105.00
        //@PAR_CUENTA_CONTABLE VARCHAR(25),         ----- '65.9.6.1.74'
        //@PAR_CENTRO_COSTO VARCHAR(25),			----- '01.02.95.01.00'
        //@PAR_FECHA_CONTABLE DATETIME,             ----- '18/07/2018'
        //@PAR_MONEDA VARCHAR(4),					----- 'SOL'
        //@PAR_TIPO_CAMBIO DECIMAL(28,8),			----- 3.335
        //@PAR_TIPO VARCHAR(1),						----- 'M'
        //@PAR_SUBTIPO VARCHAR(1),					----- 'D'
        //@PAR_PAQUETE_INVENTARIO VARCHAR(4),       ----- '0004'  -- BODEGA
        //@PAR_MODULO_ORIGEN  VARCHAR(4),			----- 'CI'
        //@PAR_AUDIT_TRANS_INV INT,                 ----- '2149697'
        //@PAR_APLICACION VARCHAR(249),				----- 'RECL00000929', 'RECL00000930'
        //@PAR_ASIENTO VARCHAR(10),					----- 'CI00014095',  'CI00014096'
        //@PAR_FECHA_PROCESO DATETIME,              ----- '18/07/2018'
        //@PAR_USUARIO VARCHAR(25))					----- 'MCABANILLASS'
        //@PAR_CORRE_RECLASIFICACION INT)			----- 1  NUMERO CORRELATIVO DE AJUSTES    tablas ==> (APSSA_RECLASIFICACION_CI_BITACORA/APSSA_RECLASIFICACION_CI_BITACORA_DETALLE)
        //AS

        //public static Tmp_CostProm ProcesaTmp_CostProm(Tmp_CostProm tmpcostprom, string db)    // temporal
        //{
        //    using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
        //    {
        //        string sqlCommand = @"
        //                                INSERT INTO PIMENTEL.TMP_APSSA_LPREC_CPROME
        //                                (ARTICULO, DESCRIPCION, MONEDA, COSTO_PROMEDIO, CANTIDAD_EN_BODEGA,
        //                                 COSTO_EN_BODEGA, FAMILIA, SUBFAMILIA, GRUPO, MARCA)
        //                                VALUES
        //                                (@ARTICULO, @DESCRIPCION, @MONEDA, @COSTO_PROMEDIO, @CANTIDAD_EN_BODEGA,
        //                                 @COSTO_EN_BODEGA, @FAMILIA, @SUBFAMILIA, @GRUPO, @MARCA)
        //                                ";
        //        string connectionString = ConexionDC.ConectarBD(db);

        //        using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
        //        {
        //            cmd.CommandType = CommandType.Text;
        //            cmd.Parameters.AddWithValue("@ARTICULO", tmpcostprom.articulo);
        //            cmd.Parameters.AddWithValue("@DESCRIPCION", tmpcostprom.descripcion);
        //            cmd.Parameters.AddWithValue("@MONEDA", tmpcostprom.moneda);
        //            cmd.Parameters.AddWithValue("@COSTO_PROMEDIO", tmpcostprom.costo_promedio);
        //            cmd.Parameters.AddWithValue("@CANTIDAD_EN_BODEGA", tmpcostprom.cantidad_en_bodega);
        //            cmd.Parameters.AddWithValue("@COSTO_EN_BODEGA", tmpcostprom.costo_en_bodega);
        //            cmd.Parameters.AddWithValue("@FAMILIA", tmpcostprom.familia);
        //            cmd.Parameters.AddWithValue("@SUBFAMILIA", tmpcostprom.subfamilia);
        //            cmd.Parameters.AddWithValue("@GRUPO", tmpcostprom.grupo);
        //            cmd.Parameters.AddWithValue("@MARCA", tmpcostprom.marca);
        //            cmd.CommandTimeout = 0;
        //            cmd.Connection.Open();
        //            DataTable table = new DataTable();
        //            table.Load(cmd.ExecuteReader());
        //            cmd.Connection.Close();
        //        }

        //        return tmpcostprom;
        //    }
        //}


        public static DataTable dtProcesaReclasificacionCI_DL(string _consecutivo, string _nit, DateTime _fecha_documento, string _bodega, string _localizacion,
                                                              string _articulo, string _naturaleza, Decimal _cantidad, Decimal _costo_unitario_local, 
                                                              Decimal _costo_total_local, string _cuenta_contable, string _centro_costo, DateTime _fecha_contable, string _moneda,
                                                              Decimal _tipo_cambio, string _tipo, string _subtipo, string _paquete_inventario,
                                                              string _modulo_origen, Int32 _audit_trans_inv, string _aplicacion, string _asiento,
                                                              DateTime _fecha_proceso, string _usuario, Int32 _corre_reclasif, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_RECLASIFICACION_CI_PROCESA";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PAR_CONSECUTIVO", _consecutivo);
                    cmd.Parameters.AddWithValue("@PAR_NIT", _nit);
                    cmd.Parameters.AddWithValue("@PAR_FECHA_DOCUMENTO", _fecha_documento);
                    cmd.Parameters.AddWithValue("@PAR_BODEGA", _bodega);
                    cmd.Parameters.AddWithValue("@PAR_LOCALIZACION", _localizacion);
                    cmd.Parameters.AddWithValue("@PAR_ARTICULO", _articulo);
                    cmd.Parameters.AddWithValue("@PAR_NATURALEZA", _naturaleza);
                    cmd.Parameters.AddWithValue("@PAR_CANTIDAD", _cantidad);
                    cmd.Parameters.AddWithValue("@PAR_COSTO_UNITARIO_LOCAL", _costo_unitario_local);
                    cmd.Parameters.AddWithValue("@PAR_COSTO_TOTAL_LOCAL", _costo_total_local);
                    cmd.Parameters.AddWithValue("@PAR_CUENTA_CONTABLE", _cuenta_contable);
                    cmd.Parameters.AddWithValue("@PAR_CENTRO_COSTO", _centro_costo);
                    cmd.Parameters.AddWithValue("@PAR_FECHA_CONTABLE", _fecha_contable);
                    cmd.Parameters.AddWithValue("@PAR_MONEDA", _moneda);
                    cmd.Parameters.AddWithValue("@PAR_TIPO_CAMBIO", _tipo_cambio);
                    cmd.Parameters.AddWithValue("@PAR_TIPO", _tipo);
                    cmd.Parameters.AddWithValue("@PAR_SUBTIPO", _subtipo);
                    cmd.Parameters.AddWithValue("@PAR_PAQUETE_INVENTARIO", _paquete_inventario);
                    cmd.Parameters.AddWithValue("@PAR_MODULO_ORIGEN", _modulo_origen);
                    cmd.Parameters.AddWithValue("@PAR_AUDIT_TRANS_INV", _audit_trans_inv);
                    cmd.Parameters.AddWithValue("@PAR_APLICACION", _aplicacion);
                    cmd.Parameters.AddWithValue("@PAR_ASIENTO", _asiento);
                    cmd.Parameters.AddWithValue("@PAR_FECHA_PROCESO", _fecha_proceso);
                    cmd.Parameters.AddWithValue("@PAR_USUARIO", _usuario);
                    cmd.Parameters.AddWithValue("@PAR_CORRE_RECLASIFICACION", _corre_reclasif);
                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    ds.Tables.Add(table);
                    cmd.Connection.Close();  //// ADD MXMX

                }
                return ds.Tables[0];
            }
        }

        //ALTER PROCEDURE[PIMENTEL].[SP_APSSA_RECLASIFICACION_CI_GET_RECL_TRANSACCIONES]
        //(@TIPO VARCHAR(5),	-- 'TRANS', 'AUDIT' 	
        //@RECLASIFICACION INT,
        //@FECHA_INICIO    DATETIME,
        //@FECHA_FINAL DATETIME)

        //EXEC PIMENTEL.SP_APSSA_RECLASIFICACION_CI_GET_RECL_TRANSACCIONES;
        public static DataTable dtObtenerResultadoReclasif_Transacciones_DL(string _tipo, Int32 _reclasif,DateTime _fecha_ini, DateTime _fecha_fin, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_RECLASIFICACION_CI_GET_RECL_TRANSACCIONES";

            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@TIPO", _tipo));
            arParam.Add(new SqlParameter("@RECLASIFICACION", _reclasif));
            arParam.Add(new SqlParameter("@FECHA_INICIO", _fecha_ini));
            arParam.Add(new SqlParameter("@FECHA_FINAL", _fecha_fin));

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParam.ToArray()).Tables[0];
        }

        //EXEC PIMENTEL.SP_APSSA_RECLASIFICACION_CI_GET_RECL_DIARIO;
        public static DataTable dtObtenerResultadoReclasif_Diario_DL(Int32 _reclasif, DateTime _fecha_ini, DateTime _fecha_fin, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_RECLASIFICACION_CI_GET_RECL_DIARIO";

            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@RECLASIFICACION", _reclasif));
            arParam.Add(new SqlParameter("@FECHA_INICIO", _fecha_ini));
            arParam.Add(new SqlParameter("@FECHA_FINAL", _fecha_fin));

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParam.ToArray()).Tables[0];
        }

        //EXEC PIMENTEL.SP_APSSA_RECLASIFICACION_CI_GET_RECL_ASIENTO_DIARIO;
        public static DataTable dtObtenerResultadoReclasif_AsientoDiario_DL(Int32 _reclasif, DateTime _fecha_ini, DateTime _fecha_fin, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_RECLASIFICACION_CI_GET_RECL_ASIENTO_DIARIO";

            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@RECLASIFICACION", _reclasif));
            arParam.Add(new SqlParameter("@FECHA_INICIO", _fecha_ini));
            arParam.Add(new SqlParameter("@FECHA_FINAL", _fecha_fin));

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParam.ToArray()).Tables[0];
        }

        //EXEC PIMENTEL.SP_APSSA_RECLASIFICACION_CI_GET_RECL_BITACORA;
        public static DataTable dtObtenerResultadoReclasif_Bitacora_DL(Int32 _reclasif, DateTime _fecha_ini, DateTime _fecha_fin, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_RECLASIFICACION_CI_GET_RECL_BITACORA";

            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@RECLASIFICACION", _reclasif));
            arParam.Add(new SqlParameter("@FECHA_INICIO", _fecha_ini));
            arParam.Add(new SqlParameter("@FECHA_FINAL", _fecha_fin));

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParam.ToArray()).Tables[0];
        }

        //EXEC PIMENTEL.SP_APSSA_RECLASIFICACION_CI_GET_RECL_BITACORA;
        public static DataTable dtObtenerResultadoReclasif_BitacoraDetalle_DL(Int32 _reclasif, DateTime _fecha_ini, DateTime _fecha_fin, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_RECLASIFICACION_CI_GET_RECL_BITACORA_DETALLE";

            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@RECLASIFICACION", _reclasif));
            arParam.Add(new SqlParameter("@FECHA_INICIO", _fecha_ini));
            arParam.Add(new SqlParameter("@FECHA_FINAL", _fecha_fin));

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParam.ToArray()).Tables[0];
        }


        //verificar naturaleza
        //verificar localizacion
        //verificar consecutivo
        public static bool ExisteConsecutivoDL(string _ajuste, string _datos, string db)
        {
            int NumReg = 0;
            string strSql = "PIMENTEL.SP_APSSA_GET_CONSECUTIVO_CI";

            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@AJUSTE_CONFIG", _ajuste));
            arParam.Add(new SqlParameter("@DATOS", _datos));

            NumReg = Convert.ToInt32(SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParam.ToArray()));
            return NumReg > 0;
        }
        //verificar bodega
        public static bool ExisteBodegaDL(string _bodega, string _datos, string db)
        {
            int NumReg = 0;
            string strSql = "PIMENTEL.SP_APSSA_GET_BODEGA";

            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@BODEGA", _bodega));
            arParam.Add(new SqlParameter("@DATOS", _datos));

            NumReg = Convert.ToInt32(SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParam.ToArray()));
            return NumReg > 0;
        }


        //verificar articulo
        public static bool ExisteArticuloDL(string _articulo, string _datos, string db)
        {
            int NumReg = 0;
            string strSql = "PIMENTEL.SP_APSSA_GET_ARTICULO";

            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@ARTICULO", _articulo));
            arParam.Add(new SqlParameter("@DATOS", _datos));

            NumReg = Convert.ToInt32(SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParam.ToArray()));
            return NumReg > 0;
        }

        //verificar nit
        //ALTER PROCEDURE[PIMENTEL].[SP_APSSA_GET_NIT]
        //(@NIT VARCHAR(20),
        //@DATOS VARCHAR(2))
        public static bool ExisteNitDL(string _nit, string _datos, string db)
        {
            int NumReg = 0;
            string strSql = "PIMENTEL.SP_APSSA_GET_NIT";

            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@NIT", _nit));
            arParam.Add(new SqlParameter("@DATOS", _datos));

            NumReg = Convert.ToInt32(SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParam.ToArray()));
            return NumReg > 0;
        }


        // TRANS.BODEGA, TRANS.LOCALIZACION, TRANS.ARTICULO, TRANS.NATURALEZA, 
        // TRANS.BODEGA, TRANS.LOCALIZACION, SPACE(20) AS ARTICULO, TRANS.NATURALEZA, 

        public static DataTable dtObtenerCamposReclasificacionExcelDL(string db)
        {
            string strSql = @"  DECLARE @TIPO_CAMBIO DECIMAL (28,8);                                
                                SELECT TOP 0 SPACE(10) AS PROCESAR,SPACE(50) AS VALIDACION,
                                ATI.CONSECUTIVO, TRANS.NIT, 
                                ATI.FECHA_HORA AS FECHA_DOCUMENTO,-- CONVERTIR
                                TRANS.BODEGA, TRANS.LOCALIZACION, SPACE(20) AS ARTICULO, TRANS.NATURALEZA, 
                                TRANS.CANTIDAD, TRANS.COSTO_TOT_FISC_LOC AS COSTO_UNITARIO_LOCAL, TRANS.COSTO_TOT_FISC_LOC AS COSTO_TOTAL_LOCAL,
                                SPACE(25) AS CUENTA_CONTABLE, SPACE(25) AS CENTRO_COSTO, 
                                ATI.FECHA_HORA AS FECHA_CONTABLE,-- CONVERTIR
                                SPACE(4) AS MONEDA, @TIPO_CAMBIO AS TIPO_CAMBIO, 
                                TRANS.TIPO, TRANS.SUBTIPO, ATI.PAQUETE_INVENTARIO, ATI.MODULO_ORIGEN,
                                GETDATE() AS FECHA_PROCESO, SPACE(25) AS USUARIO,
                                ATI.AUDIT_TRANS_INV, ATI.APLICACION, ATI.ASIENTO
                                FROM PIMENTEL.AUDIT_TRANS_INV ATI  (NOLOCK)  
                                INNER JOIN PIMENTEL.TRANSACCION_INV TRANS  (NOLOCK) ON TRANS.AUDIT_TRANS_INV = ATI.AUDIT_TRANS_INV;
                             ";

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql).Tables[0];
        }






        //----------------------------------------------------------------------------------------------------------

        //ALTER PROCEDURE[PIMENTEL].[SP_APSSA_ERR_FA_ASDIARIO_GET]
        //(@FECHA_INICIO DATETIME,
        //@FECHA_FINAL DATETIME )
        public static DataTable dtObtenerErrFaAsDiario_DL(DateTime _fecha_ini, DateTime _fecha_fin, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_ERR_FA_ASDIARIO_GET";

            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@FECHA_INICIO", _fecha_ini));
            arParam.Add(new SqlParameter("@FECHA_FINAL", _fecha_fin));

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParam.ToArray()).Tables[0];
        }

        //ALTER PROCEDURE[PIMENTEL].[SP_APSSA_ERR_FA_DIARIO_GET]
        //(@FECHA_INICIO DATETIME,
        //@FECHA_FINAL DATETIME )
        public static DataTable dtObtenerErrFaDiario_DL(DateTime _fecha_ini, DateTime _fecha_fin, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_ERR_FA_DIARIO_GET";

            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@FECHA_INICIO", _fecha_ini));
            arParam.Add(new SqlParameter("@FECHA_FINAL", _fecha_fin));

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParam.ToArray()).Tables[0];
        }

        //ALTER PROCEDURE[PIMENTEL].[SP_APSSA_DIF_CAMBIARIA_OBTENER]
        //(@FECHA_INICIO DATETIME,
        //@FECHA_FINAL DATETIME )
        public static DataTable dtObtenerDocumentosCP_DL(DateTime _fecha_ini, DateTime _fecha_fin, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_DIF_CAMBIARIA_OBTENER";

            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@FECHA_INICIO", _fecha_ini));
            arParam.Add(new SqlParameter("@FECHA_FINAL", _fecha_fin));

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParam.ToArray()).Tables[0];

        }


        public static string ObtenerSubTipoDocCP_DL(string _tipo, string _subtipo_desc, string db)
        {
            string strSql = @"SELECT TOP 1 SUBTIPO
                              FROM PIMENTEL.SUBTIPO_DOC_CP (NOLOCK)
                              WHERE TIPO=@TIPO AND DESCRIPCION=@SUBTIPO_DESCR;
                             ";

            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@TIPO", _tipo));
            arParam.Add(new SqlParameter("@SUBTIPO_DESCR", _subtipo_desc));

            return Convert.ToString(SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray()));
        }


        //ALTER PROCEDURE[PIMENTEL].[SP_APSSA_FACTURA_COMP_TARJ]
        //(@PAR_DOCUMENTO VARCHAR(50),
        // @PAR_TIPO VARCHAR(3), 
        // @PAR_SUBTIPODOC INT,
        // @PAR_FECHA_DOC DATETIME, 
        // @PAR_FECHA_VCMTO DATETIME,
        // @PAR_FECHA_CONTABLE DATETIME,		-- FECHA ASIENTO
        // @PAR_CONTRIBUYENTE VARCHAR(20),
        // @PAR_MONEDA VARCHAR(4), 
        // @PAR_TIPO_CAMBIO_DOLAR DECIMAL(28, 8), 
        // @PAR_CONDICION_PAGO VARCHAR(4), 
        // @PAR_SUBTOTAL DECIMAL(28, 8), 
        // @PAR_DESCUENTO DECIMAL(28, 8), 
        // @PAR_IMPUESTO1 DECIMAL(28, 8), -- IGV
        // @PAR_IMPUESTO2 DECIMAL(28, 8), 
        // @PAR_RUBRO1 DECIMAL(28, 8),	-- INAFECTO
        // @PAR_RUBRO2 DECIMAL(28, 8),
        // @PAR_MONTO DECIMAL(28, 8), 
        // @PAR_CUENTA_BANCO VARCHAR(20),
        // @PAR_CUENTA_CONTABLE VARCHAR(25),
        // @PAR_CENTRO_COSTO VARCHAR(25),
        // @PAR_APLICACION VARCHAR(254),
        // @PAR_FECHA_PROCESO DATETIME,
        // @PAR_USUARIO   VARCHAR(25) )

        public static DataTable dtProcesaFacturasCompTarjDL(string _documento, string _tipo, string _subtipo, DateTime _fecha_doc, DateTime _fecha_vcmto, DateTime _fecha_contable,
                                                            string _proveedor, string _moneda, Decimal _tipo_cambio, string _condicion_pago, Decimal _subtotal, Decimal _descuento,
                                                            Decimal _impuesto1, Decimal _impuesto2, Decimal _rubro1, Decimal _rubro2, Decimal _monto, string _cuenta_banco,
                                                            string _cuenta_contable, string _centro_costo, string _aplicacion, DateTime _fecha_proceso, string _usuario, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_FACTURA_COMP_TARJ";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PAR_DOCUMENTO", _documento);
                    cmd.Parameters.AddWithValue("@PAR_TIPO", _tipo);
                    cmd.Parameters.AddWithValue("@PAR_SUBTIPODOC", _subtipo);
                    cmd.Parameters.AddWithValue("@PAR_FECHA_DOC", _fecha_doc);
                    cmd.Parameters.AddWithValue("@PAR_FECHA_VCMTO", _fecha_vcmto);
                    cmd.Parameters.AddWithValue("@PAR_FECHA_CONTABLE", _fecha_contable);
                    cmd.Parameters.AddWithValue("@PAR_CONTRIBUYENTE", _proveedor);
                    cmd.Parameters.AddWithValue("@PAR_MONEDA", _moneda);
                    cmd.Parameters.AddWithValue("@PAR_TIPO_CAMBIO_DOLAR", _tipo_cambio);
                    cmd.Parameters.AddWithValue("@PAR_CONDICION_PAGO", _condicion_pago);
                    cmd.Parameters.AddWithValue("@PAR_SUBTOTAL", _subtotal);
                    cmd.Parameters.AddWithValue("@PAR_DESCUENTO", _descuento);
                    cmd.Parameters.AddWithValue("@PAR_IMPUESTO1", _impuesto1);
                    cmd.Parameters.AddWithValue("@PAR_IMPUESTO2", _impuesto2);
                    cmd.Parameters.AddWithValue("@PAR_RUBRO1", _rubro1);
                    cmd.Parameters.AddWithValue("@PAR_RUBRO2", _rubro2);
                    cmd.Parameters.AddWithValue("@PAR_MONTO", _monto);
                    cmd.Parameters.AddWithValue("@PAR_CUENTA_BANCO", _cuenta_banco);
                    cmd.Parameters.AddWithValue("@PAR_CUENTA_CONTABLE", _cuenta_contable);
                    cmd.Parameters.AddWithValue("@PAR_CENTRO_COSTO", _centro_costo);
                    cmd.Parameters.AddWithValue("@PAR_APLICACION", _aplicacion);
                    cmd.Parameters.AddWithValue("@PAR_FECHA_PROCESO", _fecha_proceso);
                    cmd.Parameters.AddWithValue("@PAR_USUARIO", _usuario);
                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    ds.Tables.Add(table);
                    cmd.Connection.Close();  //// ADD MXMX
                }
                return ds.Tables[0];
            }
        }


        public static DataTable dtListarCompTarjDL(string db)      // 20062018
        {
            string strSql = @" DECLARE @TIPO_CAMBIO DECIMAL(28,8), @CUENTA_BANCO VARCHAR(20);
                               SELECT TOP 0
                               SPACE(10) AS PROCESAR,SPACE(50) AS VALIDACION, DOCUMENTO, TIPO,  SPACE(20) AS SUBTIPO, TIPO AS SUBTIPODOC, 
                               FECHA_DOC AS FECHA_DOC, FECHA_DOC AS FECHA_VCMTO, FECHA_DOC AS FECHA_CONTABLE, PROVEEDOR, MONEDA, @TIPO_CAMBIO AS TIPO_CAMBIO, 
                               SUBTOTAL, DESCUENTO, IMPUESTO1 AS IGV, IMPUESTO2, RUBRO_1 AS INAFECTO, RUBRO_2 AS RUBRO2, MONTO, CONDICION_PAGO,
                               @CUENTA_BANCO AS CUENTA_BANCO, CUENTA_CONTABLE, CENTRO_COSTO, APLICACION,
                               SPACE(100) AS DESCRIPCION_CUENTA,SPACE(50) AS SUCURSAL,SPACE(50) AS SCC,SPACE(50) AS ADICIONAL,SPACE(50) AS DESTINO                            
                               FROM PIMENTEL.TMP_FACTURA_GY WITH (NOLOCK);
                             ";

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql).Tables[0];
        }

        public static DataTable dtListarCamposExcelCompTarjDL(string db) // 20062018
        {
            string strSql = @"  DECLARE @TIPO_CAMBIO DECIMAL(28,6), @RETENCIONES VARCHAR(10);
                                SELECT TOP 0 SPACE(10) AS PROCESAR,
                                SPACE(10) AS PROCESAR,SPACE(50) AS VALIDACION, DOCUMENTO, TIPO, SPACE(20) AS SUBTIPO, SPACE(5) AS SUBTIPODOC,
                                FECHA_DOC AS FECHA_DOCUMENTO, FECHA_DOC AS FECHA_VCMTO,FECHA_DOC AS FECHA_CONTABLE,PROVEEDOR, MONEDA,
                                @TIPO_CAMBIO AS TIPO_CAMBIO, SUBTOTAL, SUBTOTAL AS DESCUENTO, CONDICION_PAGO,
                                IMPUESTO1 AS IGV, IMPUESTO1 AS IMPUESTO2,RUBRO_1 AS INAFECTO, RUBRO_2 AS RUBRO2,
                                MONTO, SPACE(50) AS CUENTA_BANCO, CUENTA_CONTABLE, CENTRO_COSTO, APLICACION                                
                                FROM PIMENTEL.TMP_FACTURA_GY WITH (NOLOCK);
                             ";

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql).Tables[0];
        }



        public static DataTable dtObtenerDocumentosFeDL(DateTime _fecha_ini, DateTime _fecha_fin, string _estado, string _tipo_doc, Int16 _anula, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_FE_OBTENER_DOCUMENTOS";

            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@FECHA_INICIO", _fecha_ini));
            arParam.Add(new SqlParameter("@FECHA_FINAL", _fecha_fin));
            arParam.Add(new SqlParameter("@ESTADO", _estado));
            arParam.Add(new SqlParameter("@TIPO_DOC", _tipo_doc));
            arParam.Add(new SqlParameter("@ANULADOS", _anula));

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParam.ToArray()).Tables[0];

        }

        //ALTER PROCEDURE[PIMENTEL].[SP_APSSA_FE_OBTENER_DOCUMENTOS]
        //(@FECHA_INICIO DATETIME,
        //@FECHA_FINAL   DATETIME,
        //@TIPO_DOC VARCHAR(1) )	-- TO-todos, FA-factura, BO-boleta, NC , ND

        //public static DataTable dtObtenerDocumentosFeDL(DateTime _fecha_ini, DateTime _fecha_fin, string _tipo_doc, string db)
        //{
        //    string strSql = "PIMENTEL.SP_APSSA_FE_OBTENER_DOCUMENTOS";

        //    List<SqlParameter> arParam = new List<SqlParameter>();
        //    arParam.Add(new SqlParameter("@FECHA_INICIO", _fecha_ini));
        //    arParam.Add(new SqlParameter("@FECHA_FINAL", _fecha_fin));
        //    arParam.Add(new SqlParameter("@TIPO_DOC", _tipo_doc));

        //    return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParam.ToArray()).Tables[0];

        //}


        public static string ObtenerSubTipoCajaChicaDL(string _tipo, string _subtipo_desc, string db)
        {
            string strSql = @"SELECT TOP 1 SUBTIPO
                              FROM PIMENTEL.SUBTIPO_DOC_CAJA (NOLOCK)
                              WHERE TIPO=@TIPO AND DESCRIPCION=@SUBTIPO_DESCR;
                             ";

            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@TIPO", _tipo));
            arParam.Add(new SqlParameter("@SUBTIPO_DESCR", _subtipo_desc));

            return Convert.ToString(SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray()));
        }


        public static DataTable dtObtenerDatosCuentaBancariaDL(string _cuenta_banco, string db)
        {
            string strSql = @"  SELECT * 
                                FROM PIMENTEL.CUENTA_BANCARIA (NOLOCK)
                                WHERE CUENTA_BANCO = @CUENTA_BANCO;
                             ";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@CUENTA_BANCO", _cuenta_banco));

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParams.ToArray()).Tables[0];
        }

        //ALTER PROCEDURE[PIMENTEL].[SP_APSSA_CREDITOS_ASIENTO]
        //(@PAR_TIPO VARCHAR(2),			-- 'FF' FondoFijo , 'ER' EntregaRendir
        //@PAR_ASIENTO VARCHAR(10))	

        public static DataTable dtObtieneAsientoCreditosDL(string _cjachica_tipo, string _cjachica_asiento, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_CREDITOS_ASIENTO";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@PAR_TIPO", _cjachica_tipo));
            arParams.Add(new SqlParameter("@PAR_ASIENTO", _cjachica_asiento));

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray()).Tables[0];
        }


        public static bool ExisteCuentaBancariaDL(string _cuenta_banco, string db)
        {
            int NumReg = 0;
            string strSql = @"SELECT COUNT(*) 
                              FROM PIMENTEL.CUENTA_BANCARIA WHERE CUENTA_BANCO = @CUENTA_BANCO";

            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@CUENTA_BANCO", _cuenta_banco));

            NumReg = Convert.ToInt32(SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray()));
            return NumReg > 0;
        }

        public static DataTable dtListarCamposExcelCajaChicaDL(string db)
        {
            string strSql = @"  DECLARE @TIPO_CAMBIO DECIMAL(28,6), @RETENCIONES VARCHAR(10);
                                SELECT TOP 0 SPACE(10) AS PROCESAR,
                                SPACE(10) AS PROCESAR, DOCUMENTO, TIPO, SPACE(20) AS SUBTIPO, SPACE(5) AS SUBTIPODOC,
                                FECHA_DOC AS FECHA_DOCUMENTO, FECHA_DOC AS FECHA_CONTABLE,PROVEEDOR AS CONTRIBUYENTE, MONEDA,
                                @TIPO_CAMBIO AS TIPO_CAMBIO, SUBTOTAL, SUBTOTAL AS DESCUENTO,
                                IMPUESTO1 AS IGV, IMPUESTO1 AS IMPUESTO2,RUBRO_1 AS INAFECTO, RUBRO_2 AS RUBRO2,
                                MONTO, SPACE(50) AS CUENTA_BANCO, CUENTA_CONTABLE, CENTRO_COSTO, APLICACION,
                                SPACE(100) AS VALIDACION,
                                SPACE(100) AS DESCRIPCION_CUENTA,SPACE(50) AS SUCURSAL,SPACE(50) AS SCC,SPACE(50) AS ADICIONAL,SPACE(50) AS DESTINO
                                FROM PIMENTEL.TMP_FACTURA_GY WITH (NOLOCK);
                             ";

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql).Tables[0];
        }
        public static DataTable dtCargaEntregaRendirDL(string _documento, string _tipo, Int16 _subtipo, DateTime _fecha_documento, DateTime _fecha_contable, string _contribuyente,
                                                       string _moneda, Decimal _tipo_cambio, Decimal _subtotal, Decimal _descuento, Decimal _impuesto1,
                                                       Decimal _impuesto2, Decimal _rubro1, Decimal _rubro2, Decimal _monto, string _cuenta_banco,
                                                       string _cuenta_contable, string _centro_costo, string _aplicacion, DateTime _fecha_proceso,
                                                       string _usuario, string _cjachica_tipo_operacion, string _cjachica_docu_operacion, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_ENTREGA_RENDIR_CARGA";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PAR_DOCUMENTO", _documento);
                    cmd.Parameters.AddWithValue("@PAR_TIPO", _tipo);
                    cmd.Parameters.AddWithValue("@PAR_SUBTIPODOC", _subtipo);
                    cmd.Parameters.AddWithValue("@PAR_FECHA_DOCUMENTO", _fecha_documento);
                    cmd.Parameters.AddWithValue("@PAR_FECHA_CONTABLE", _fecha_contable);
                    cmd.Parameters.AddWithValue("@PAR_CONTRIBUYENTE", _contribuyente);
                    cmd.Parameters.AddWithValue("@PAR_MONEDA", _moneda);
                    cmd.Parameters.AddWithValue("@PAR_TIPO_CAMBIO_DOLAR", _tipo_cambio);
                    cmd.Parameters.AddWithValue("@PAR_SUBTOTAL", _subtotal);
                    cmd.Parameters.AddWithValue("@PAR_DESCUENTO", _descuento);
                    cmd.Parameters.AddWithValue("@PAR_IMPUESTO1", _impuesto1);
                    cmd.Parameters.AddWithValue("@PAR_IMPUESTO2", _impuesto2);
                    cmd.Parameters.AddWithValue("@PAR_RUBRO1", _rubro1);
                    cmd.Parameters.AddWithValue("@PAR_RUBRO2", _rubro2);
                    cmd.Parameters.AddWithValue("@PAR_MONTO", _monto);
                    cmd.Parameters.AddWithValue("@PAR_CUENTA_BANCO", _cuenta_banco);
                    cmd.Parameters.AddWithValue("@PAR_CUENTA_CONTABLE", _cuenta_contable);
                    cmd.Parameters.AddWithValue("@PAR_CENTRO_COSTO", _centro_costo);
                    cmd.Parameters.AddWithValue("@PAR_APLICACION", _aplicacion);
                    cmd.Parameters.AddWithValue("@PAR_FECHA_PROCESO", _fecha_proceso);
                    cmd.Parameters.AddWithValue("@PAR_USUARIO", _usuario);
                    cmd.Parameters.AddWithValue("@PAR_TIPO_OPERACION", _cjachica_tipo_operacion);
                    cmd.Parameters.AddWithValue("@PAR_DOCU_OPERACION", _cjachica_docu_operacion);
                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    ds.Tables.Add(table);
                    cmd.Connection.Close();  //// ADD MXMX
                }
                return ds.Tables[0];
            }
        }


        public static DataTable dtCargaFondoFijoDL(string _documento, string _tipo, Int16 _subtipo, DateTime _fecha_documento, DateTime _fecha_contable, string _contribuyente,
                                                     string _moneda, Decimal _tipo_cambio, Decimal _subtotal, Decimal _descuento, Decimal _impuesto1,
                                                     Decimal _impuesto2, Decimal _rubro1, Decimal _rubro2, Decimal _monto, string _cuenta_banco,
                                                     string _cuenta_contable, string _centro_costo, string _aplicacion, DateTime _fecha_proceso,
                                                     string _usuario, string _cjachica_tipo_operacion, string _cjachica_docu_operacion, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_FONDO_FIJO_CARGA";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PAR_DOCUMENTO", _documento);
                    cmd.Parameters.AddWithValue("@PAR_TIPO", _tipo);
                    cmd.Parameters.AddWithValue("@PAR_SUBTIPODOC", _subtipo);
                    cmd.Parameters.AddWithValue("@PAR_FECHA_DOCUMENTO", _fecha_documento);
                    cmd.Parameters.AddWithValue("@PAR_FECHA_CONTABLE", _fecha_contable);
                    cmd.Parameters.AddWithValue("@PAR_CONTRIBUYENTE", _contribuyente);
                    cmd.Parameters.AddWithValue("@PAR_MONEDA", _moneda);
                    cmd.Parameters.AddWithValue("@PAR_TIPO_CAMBIO_DOLAR", _tipo_cambio);
                    cmd.Parameters.AddWithValue("@PAR_SUBTOTAL", _subtotal);
                    cmd.Parameters.AddWithValue("@PAR_DESCUENTO", _descuento);
                    cmd.Parameters.AddWithValue("@PAR_IMPUESTO1", _impuesto1);
                    cmd.Parameters.AddWithValue("@PAR_IMPUESTO2", _impuesto2);
                    cmd.Parameters.AddWithValue("@PAR_RUBRO1", _rubro1);
                    cmd.Parameters.AddWithValue("@PAR_RUBRO2", _rubro2);
                    cmd.Parameters.AddWithValue("@PAR_MONTO", _monto);
                    cmd.Parameters.AddWithValue("@PAR_CUENTA_BANCO", _cuenta_banco);
                    cmd.Parameters.AddWithValue("@PAR_CUENTA_CONTABLE", _cuenta_contable);
                    cmd.Parameters.AddWithValue("@PAR_CENTRO_COSTO", _centro_costo);
                    cmd.Parameters.AddWithValue("@PAR_APLICACION", _aplicacion);
                    cmd.Parameters.AddWithValue("@PAR_FECHA_PROCESO", _fecha_proceso);
                    cmd.Parameters.AddWithValue("@PAR_USUARIO", _usuario);
                    cmd.Parameters.AddWithValue("@PAR_TIPO_OPERACION", _cjachica_tipo_operacion);
                    cmd.Parameters.AddWithValue("@PAR_DOCU_OPERACION", _cjachica_docu_operacion);
                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    ds.Tables.Add(table);
                    cmd.Connection.Close();  //// ADD MXMX
                }
                return ds.Tables[0];
            }
        }




        public static bool ExisteMonedaDL(string _moneda, string db)
        {
            int NumReg = 0;
            string strSql = @"SELECT COUNT(*) FROM PIMENTEL.MONEDA WITH (NOLOCK)
                              WHERE MONEDA = @MONEDA ;";

            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@MONEDA", _moneda));

            NumReg = Convert.ToInt32(SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray()));
            return NumReg > 0;
        }

        public static bool ExisteSubTipoCajaChicaDL(string _tipo_caja_chica, Int32 _subtipo_caja_chica, string db)
        {
            int NumReg = 0;
            string strSql = @"SELECT COUNT(*) FROM PIMENTEL.SUBTIPO_DOC_CAJA WITH (NOLOCK)
                              WHERE TIPO = @TIPO  AND SUBTIPO = @SUBTIPO ;";

            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@TIPO", _tipo_caja_chica));
            arParam.Add(new SqlParameter("@SUBTIPO", _subtipo_caja_chica));

            NumReg = Convert.ToInt32(SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray()));
            return NumReg > 0;
        }

        public static bool ExisteTipoCajaChicaDL(string _tipo_caja_chica, string db)
        {
            int NumReg = 0;
            string strSql = @"SELECT COUNT(*) FROM PIMENTEL.SUBTIPO_DOC_CAJA WITH (NOLOCK)
                              WHERE SUBTIPO=0 AND TIPO = @TIPO ;";

            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@TIPO", _tipo_caja_chica));

            NumReg = Convert.ToInt32(SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray()));
            return NumReg > 0;
        }


        public static bool ExisteCentroCostoDL(string _ccosto, string db)
        {
            int NumReg = 0;
            string strSql = @"SELECT COUNT(*) FROM PIMENTEL.CENTRO_COSTO WITH (NOLOCK)
                              WHERE CENTRO_COSTO = @CENTRO_COSTO";

            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@CENTRO_COSTO", _ccosto));

            NumReg = Convert.ToInt32(SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray()));
            return NumReg > 0;
        }


        //ALTER PROCEDURE[PIMENTEL].[SP_APSSA_CREDITOS_LISTAR]
        //(@PAR_TIPO_OPERACION VARCHAR(2),		-- 'FF' FondoFijo , 'ER' EntregaRendir
        //@PAR_DOCU_OPERACION VARCHAR(18))		-- ENTREGA RENDIR ó FONDO FIJO
        public static DataTable dtObtieneCreditosDL(string _cjachica_tipo_operacion, string _cjachica_docu_operacion, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_CREDITOS_LISTAR";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@PAR_TIPO_OPERACION", _cjachica_tipo_operacion));
            arParams.Add(new SqlParameter("@PAR_DOCU_OPERACION", _cjachica_docu_operacion));

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray()).Tables[0];
        }



        //ALTER PROCEDURE[PIMENTEL].[SP_APSSA_ENTREGA_RENDIR_LISTAR]
        //(@FECHA_INICIO DATETIME,
        //@FECHA_FINAL  DATETIME )
        public static DataTable dtObtieneEntregaRendirDL(DateTime _fecha_inicio, DateTime _fecha_final, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_ENTREGA_RENDIR_LISTAR";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@FECHA_INICIO", _fecha_inicio));
            arParams.Add(new SqlParameter("@FECHA_FINAL", _fecha_final));

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray()).Tables[0];
        }

        //ALTER PROCEDURE[PIMENTEL].[SP_APSSA_FONDO_FIJO_LISTAR]
        //(@FECHA_INICIO DATETIME,
        //@FECHA_FINAL  DATETIME )
        public static DataTable dtObtieneFondoFijoDL(DateTime _fecha_inicio, DateTime _fecha_final, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_FONDO_FIJO_LISTAR";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@FECHA_INICIO", _fecha_inicio));
            arParams.Add(new SqlParameter("@FECHA_FINAL", _fecha_final));

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray()).Tables[0];
        }




        /*
         ALTER PROCEDURE [PIMENTEL].[SP_APSSA_ENTREGA_RENDIR_CAJA_APERTURA]
         @PAR_ENTREGA_A_RENDIR VARCHAR(18),
         @PAR_RESPONSABLE_TIPO VARCHAR(1) ,			-- E-empleado, P-proveedor
         @PAR_RESPONSABLE_CODIGO VARCHAR(20) ,		--@PAR_EMPLEADO VARCHAR(20) ó  --@PAR_PROVEEDOR VARCHAR(20) ,
         @PAR_CONTRIBUYENTE VARCHAR(20),
         @PAR_MONEDA VARCHAR(4) ,
         @PAR_APLICACION VARCHAR(249) ,
         @PAR_FECHA_ENTREGA DATETIME ,
         @PAR_MONTO DECIMAL(28, 8) ,
         @PAR_TIPO_CAMBIO DECIMAL(28, 8) ,
         @PAR_NOTAS VARCHAR(MAX) , 
         @PAR_FECHA_VENC DATETIME ,
         @PAR_USUARIO	VARCHAR(25),
         @PAR_TIPO_OPERACION VARCHAR(1),				-- I-insert, U-update
         -- documentos_caja
         @PAR_CUENTA_BANCO VARCHAR(20) ,                 --CuentaBancoER = lookUpCuentaBancoER.EditValue.ToString();
         @PAR_TIPO VARCHAR(3) ,			                 --TipoSalidaER = lookUpTipoSalidaER.EditValue.ToString();
         @PAR_SUBTIPO INT ,								 --SubTipoSalidaER = lookUpSubTipoSalidaER.EditValue.ToString();
         @PAR_CONTRIBUYENTE_DCAJ VARCHAR(20) ,           --ContribuyenteER = txtContribuyenteER.Text;
         @PAR_MONEDA_DCAJ VARCHAR(4) ,					 --MonedaERdebito = lookUpMonedaERdebito.EditValue.ToString();
         @PAR_DOCUMENTO VARCHAR(20) ,					 --DocumentoERdebito = txtDocumentoERdebito.Text;
         @PAR_MONTO_DCAJ DECIMAL(28, 8) ,				 --MontoERdebito = Convert.ToDecimal(txtMontoERdebito.Text);
         @PAR_FECHA DATETIME ,							 --FechaERdebito = Convert.ToDateTime(deFechaERdebito.Text);
         @PAR_APLICACION_DCAJ VARCHAR(249),             --AplicacionERdebito = txtAplicacionERdebito.Text;
         @PAR_TIPO_CONTRIBUYENTE VARCHAR(1) )	
        */
        public static void AperturaEntregaRendirCajaDL(string _entrega_rendir, string _resposable_tipo, string _responsable_codigo, string _contribuyente,
                                                       string _moneda, string _aplicacion, DateTime _fecha_entrega, Decimal _monto, Decimal _tipo_cambio,
                                                       string _notas, DateTime _fecha_venc, string _usuario, string _tipo_operacion,
                                                       string _cuenta_banco, string _tipo, Int32 _subtipo, string _contribuyente_dcaj, string _moneda_dcaj,
                                                       string _documento, Decimal _monto_dcaj, DateTime _fecha, string _aplicacion_dcaj,
                                                       string _tipo_contribuyente, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_ENTREGA_RENDIR_CAJA_APERTURA";

            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@PAR_ENTREGA_A_RENDIR", _entrega_rendir));
            arParam.Add(new SqlParameter("@PAR_RESPONSABLE_TIPO", _resposable_tipo));
            arParam.Add(new SqlParameter("@PAR_RESPONSABLE_CODIGO", _responsable_codigo));
            arParam.Add(new SqlParameter("@PAR_CONTRIBUYENTE", _contribuyente));
            arParam.Add(new SqlParameter("@PAR_MONEDA", _moneda));
            arParam.Add(new SqlParameter("@PAR_APLICACION", _aplicacion));
            arParam.Add(new SqlParameter("@PAR_FECHA_ENTREGA", _fecha_entrega));
            arParam.Add(new SqlParameter("@PAR_MONTO", _monto));
            arParam.Add(new SqlParameter("@PAR_TIPO_CAMBIO", _tipo_cambio));
            arParam.Add(new SqlParameter("@PAR_NOTAS", _notas));
            arParam.Add(new SqlParameter("@PAR_FECHA_VENC", _fecha_venc));
            arParam.Add(new SqlParameter("@PAR_USUARIO", _usuario));
            arParam.Add(new SqlParameter("@PAR_TIPO_OPERACION", _tipo_operacion));
            arParam.Add(new SqlParameter("@PAR_CUENTA_BANCO", _cuenta_banco));
            arParam.Add(new SqlParameter("@PAR_TIPO", _tipo));
            arParam.Add(new SqlParameter("@PAR_SUBTIPO", _subtipo));
            arParam.Add(new SqlParameter("@PAR_CONTRIBUYENTE_DCAJ", _contribuyente_dcaj));
            arParam.Add(new SqlParameter("@PAR_MONEDA_DCAJ", _moneda_dcaj));
            arParam.Add(new SqlParameter("@PAR_DOCUMENTO", _documento));
            arParam.Add(new SqlParameter("@PAR_MONTO_DCAJ", _monto_dcaj));
            arParam.Add(new SqlParameter("@PAR_FECHA", _fecha));
            arParam.Add(new SqlParameter("@PAR_APLICACION_DCAJ", _aplicacion_dcaj));
            arParam.Add(new SqlParameter("@PAR_TIPO_CONTRIBUYENTE", _tipo_contribuyente));

            SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParam.ToArray());

        }

        /*
        ALTER PROCEDURE [PIMENTEL].[SP_APSSA_ENTREGA_RENDIR_APERTURA]
         @PAR_ENTREGA_A_RENDIR VARCHAR(18),
         @PAR_RESPONSABLE_TIPO VARCHAR(1) ,			-- E-empleado, P-proveedor
         @PAR_RESPONSABLE_CODIGO VARCHAR(20) ,		--@PAR_EMPLEADO VARCHAR(20) ó  --@PAR_PROVEEDOR VARCHAR(20) ,
         @PAR_CONTRIBUYENTE VARCHAR(20),
         @PAR_MONEDA VARCHAR(4) ,
         @PAR_APLICACION VARCHAR(249) ,
         @PAR_FECHA_ENTREGA DATETIME ,
         @PAR_MONTO DECIMAL(28, 8) ,
         @PAR_TIPO_CAMBIO DECIMAL(28, 8) ,
         @PAR_NOTAS VARCHAR(MAX) ,
         @PAR_FECHA_VENC DATETIME ,
         @PAR_USUARIO	VARCHAR(25),
         @PAR_TIPO_OPERACION VARCHAR(1),				-- I-insert, U-update
        */
        public static void AperturaEntregaRendirDL(string _entrega_rendir, string _resposable_tipo, string _responsable_codigo, string _contribuyente,
                                                   string _moneda, string _aplicacion, DateTime _fecha_entrega, Decimal _monto, Decimal _tipo_cambio,
                                                   string _notas, DateTime _fecha_venc, string _usuario, string _tipo, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_ENTREGA_RENDIR_APERTURA";

            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@PAR_ENTREGA_A_RENDIR", _entrega_rendir));
            arParam.Add(new SqlParameter("@PAR_RESPONSABLE_TIPO", _resposable_tipo));
            arParam.Add(new SqlParameter("@PAR_RESPONSABLE_CODIGO", _responsable_codigo));
            arParam.Add(new SqlParameter("@PAR_CONTRIBUYENTE", _contribuyente));
            arParam.Add(new SqlParameter("@PAR_MONEDA", _moneda));
            arParam.Add(new SqlParameter("@PAR_APLICACION", _aplicacion));
            arParam.Add(new SqlParameter("@PAR_FECHA_ENTREGA", _fecha_entrega));
            arParam.Add(new SqlParameter("@PAR_MONTO", _monto));
            arParam.Add(new SqlParameter("@PAR_TIPO_CAMBIO", _tipo_cambio));
            arParam.Add(new SqlParameter("@PAR_NOTAS", _notas));
            arParam.Add(new SqlParameter("@PAR_FECHA_VENC", _fecha_venc));
            arParam.Add(new SqlParameter("@PAR_USUARIO", _usuario));
            arParam.Add(new SqlParameter("@PAR_TIPO_OPERACION", _tipo));

            SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParam.ToArray());

        }



        //ALTER PROCEDURE[PIMENTEL].[SP_APSSA_FONDO_FIJO_APERTURA]
        //(@PAR_FONDO_FIJO VARCHAR(50),
        //@PAR_APLICACION VARCHAR(254),
        //@PAR_CUENTA_BANCARIA VARCHAR(20),
        //@PAR_FECHA_FONDO DATETIME,
        //@PAR_MONEDA VARCHAR(4), 
        //@PAR_TIPO_CAMBIO DECIMAL(28, 8), 
        //@PAR_MONTO DECIMAL(28, 8), 
        //@PAR_USUARIO VARCHAR(25),
        //@PAR_TIPO_OPERACION VARCHAR(1)  )		-- I-insert, U-update

        public static void AperturaFondoFijoDL(string _fondo_fijo, string _aplicacion, string _cuenta_bancaria, DateTime _fecha_fondo,
                                               string _moneda, Decimal _tipo_cambio, Decimal _monto, string _usuario, string _tipo, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_FONDO_FIJO_APERTURA";

            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@PAR_FONDO_FIJO", _fondo_fijo));
            arParam.Add(new SqlParameter("@PAR_APLICACION", _aplicacion));
            arParam.Add(new SqlParameter("@PAR_CUENTA_BANCARIA", _cuenta_bancaria));
            arParam.Add(new SqlParameter("@PAR_FECHA_FONDO", _fecha_fondo));
            arParam.Add(new SqlParameter("@PAR_MONEDA", _moneda));
            arParam.Add(new SqlParameter("@PAR_TIPO_CAMBIO", _tipo_cambio));
            arParam.Add(new SqlParameter("@PAR_MONTO", _monto));
            arParam.Add(new SqlParameter("@PAR_USUARIO", _usuario));
            arParam.Add(new SqlParameter("@PAR_TIPO_OPERACION", _tipo));

            SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParam.ToArray());

        }



        //SELECT PIMENTEL.FN_APSSA_GET_TIPO_CAMBIO('TVTA')
        //SELECT PIMENTEL.FN_APSSA_GET_TIPO_CAMBIO('TCOM')
        public static Decimal ObtenerTipoCambioDL(string _tipo, string db)
        {
            Decimal nTipoCambio = 0;

            string strSql = @"SELECT PIMENTEL.FN_APSSA_GET_TIPO_CAMBIO(@TIPO) ; ";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@TIPO", _tipo));

            nTipoCambio = Convert.ToDecimal(SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParams.ToArray()));

            return nTipoCambio;
        }

        public static string ObtenerCorrelativoEntregaRendirDL(string db)
        {
            string cCorrelativoER = string.Empty;

            string strSql = @"SELECT TOP 1 
                              RIGHT('000000000000' + LTRIM(RTRIM((CAST(ENTREGA_A_RENDIR AS INT)+1))),12)
                              FROM PIMENTEL.ENTREGA_A_RENDIR (NOLOCK) ORDER BY ENTREGA_A_RENDIR DESC; ";

            //List<SqlParameter> arParams = new List<SqlParameter>();
            //arParams.Add(new SqlParameter("@ARTICULO_CUENTA", _articulo_cuenta));
            cCorrelativoER = Convert.ToString(SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql));

            return cCorrelativoER;
        }

        public static string ObtenerCorrelativoFondoFijoDL(string db)
        {
            string cCorrelativoFF = string.Empty;

            string strSql = @"SELECT TOP 1 
                              'F' + RIGHT('00000000000' + LTRIM(RTRIM((CAST(SUBSTRING(FONDO_FIJO, 2, 11) AS INT) + 1))), 11)
                              FROM PIMENTEL.FONDO_FIJO(NOLOCK) ORDER BY FONDO_FIJO DESC ; ";

            //List<SqlParameter> arParams = new List<SqlParameter>();
            //arParams.Add(new SqlParameter("@ARTICULO_CUENTA", _articulo_cuenta));
            cCorrelativoFF = Convert.ToString(SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql));

            return cCorrelativoFF;
        }


        public static DataTable dtListarFondoFijoDL(string db)
        {
            string strSql = @" DECLARE @TIPO_CAMBIO DECIMAL(28,8), @CUENTA_BANCO VARCHAR(20);
                               SELECT TOP 0
                               SPACE(10) AS PROCESAR,SPACE(50) AS VALIDACION, DOCUMENTO, TIPO, TIPO AS SUBTIPODOC, 
                               FECHA_DOC AS FECHA_DOCUMENTO, FECHA_DOC AS FECHA_CONTABLE, PROVEEDOR AS CONTRIBUYENTE, MONEDA, @TIPO_CAMBIO AS TIPO_CAMBIO, 
                               SUBTOTAL, DESCUENTO, IMPUESTO1 AS IGV, IMPUESTO2, RUBRO_1 AS INAFECTO, RUBRO_2 AS RUBRO2, MONTO, 
                               @CUENTA_BANCO AS CUENTA_BANCO, CUENTA_CONTABLE, CENTRO_COSTO, APLICACION,
                               SPACE(100) AS DESCRIPCION_CUENTA,SPACE(50) AS SUCURSAL,SPACE(50) AS SCC,SPACE(50) AS ADICIONAL,SPACE(50) AS DESTINO                            
                               FROM PIMENTEL.TMP_FACTURA_GY WITH (NOLOCK);
                             ";

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql).Tables[0];
        }



        /*
        ALTER PROCEDURE [PIMENTEL].[SP_APSSA_CAJA_CHICA_PROCESA]
        (@PAR_DOCUMENTO VARCHAR(50),
         @PAR_TIPO VARCHAR(3), 
         @PAR_SUBTIPODOC INT, 
         @PAR_FECHA_DOCUMENTO DATETIME, 
         @PAR_CONTRIBUYENTE VARCHAR(20),
         @PAR_MONEDA VARCHAR(4), 
         @PAR_TIPO_CAMBIO_DOLAR DECIMAL(28, 8), 
         @PAR_SUBTOTAL DECIMAL(28, 8), 
         @PAR_DESCUENTO DECIMAL(28, 8), 
         @PAR_IMPUESTO1 DECIMAL(28, 8), 
         @PAR_IMPUESTO2 DECIMAL(28, 8), 
         @PAR_RUBRO1 DECIMAL(28, 8),
         @PAR_RUBRO2 DECIMAL(28, 8),
         @PAR_MONTO DECIMAL(28, 8), 
         @PAR_CUENTA_BANCO VARCHAR(20),
         @PAR_CUENTA_CONTABLE VARCHAR(25),
         @PAR_CENTRO_COSTO VARCHAR(25),
         @PAR_APLICACION VARCHAR(254),
         @PAR_FECHA_PROCESO DATETIME,
         @PAR_USUARIO	VARCHAR(25),
         @PAR_TIPO_OPERACION VARCHAR(2),		-- 'FF' FondoFijo , 'ER' EntregaRendir
         @PAR_DOCU_OPERACION VARCHAR(18))		-- ENTREGA RENDIR ó FONDO FIJO 
        */
        public static DataTable dtProcesaCajaChicaDL(string _documento, string _tipo, Int16 _subtipo, DateTime _fecha_documento, string _contribuyente,
                                                     string _moneda, Decimal _tipo_cambio_dolar, Decimal _subtotal, Decimal _descuento, Decimal _impuesto1,
                                                     Decimal _impuesto2, Decimal _rubro1, Decimal _rubro2, Decimal _monto, string _cuenta_banco,
                                                     string _cuenta_contable, string _centro_costo, string _aplicacion, DateTime _fecha_proceso,
                                                     string _usuario, string _cjachica_tipo_operacion, string _cjachica_docu_operacion, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_CAJA_CHICA_PROCESA";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PAR_DOCUMENTO", _documento);
                    cmd.Parameters.AddWithValue("@PAR_TIPO", _tipo);
                    cmd.Parameters.AddWithValue("@PAR_SUBTIPODOC", _subtipo);
                    cmd.Parameters.AddWithValue("@PAR_FECHA_DOCUMENTO", _fecha_documento);
                    cmd.Parameters.AddWithValue("@PAR_CONTRIBUYENTE", _contribuyente);
                    cmd.Parameters.AddWithValue("@PAR_MONEDA", _moneda);
                    cmd.Parameters.AddWithValue("@PAR_TIPO_CAMBIO_DOLAR", _tipo_cambio_dolar);
                    cmd.Parameters.AddWithValue("@PAR_SUBTOTAL", _subtotal);
                    cmd.Parameters.AddWithValue("@PAR_DESCUENTO", _descuento);
                    cmd.Parameters.AddWithValue("@PAR_IMPUESTO1", _impuesto1);
                    cmd.Parameters.AddWithValue("@PAR_IMPUESTO2", _impuesto2);
                    cmd.Parameters.AddWithValue("@PAR_RUBRO1", _rubro1);
                    cmd.Parameters.AddWithValue("@PAR_RUBRO2", _rubro2);
                    cmd.Parameters.AddWithValue("@PAR_MONTO", _monto);
                    cmd.Parameters.AddWithValue("@PAR_CUENTA_BANCO", _cuenta_banco);
                    cmd.Parameters.AddWithValue("@PAR_CUENTA_CONTABLE", _cuenta_contable);
                    cmd.Parameters.AddWithValue("@PAR_CENTRO_COSTO", _centro_costo);
                    cmd.Parameters.AddWithValue("@PAR_APLICACION", _aplicacion);
                    cmd.Parameters.AddWithValue("@PAR_FECHA_PROCESO", _fecha_proceso);
                    cmd.Parameters.AddWithValue("@PAR_USUARIO", _usuario);
                    cmd.Parameters.AddWithValue("@PAR_TIPO_OPERACION", _cjachica_tipo_operacion);
                    cmd.Parameters.AddWithValue("@PAR_DOCU_OPERACION", _cjachica_docu_operacion);
                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    ds.Tables.Add(table);
                    cmd.Connection.Close();  //// ADD MXMX
                }
                return ds.Tables[0];
            }
        }

        public static bool ExisteEmpleadoDL(string _empleado, string _datos, string db)
        {
            int NumReg = 0;
            string strSql = "PIMENTEL.SP_APSSA_GET_EMPLEADO";

            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@EMPLEADO", _empleado));
            arParam.Add(new SqlParameter("@DATOS", _datos));

            NumReg = Convert.ToInt32(SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParam.ToArray()));
            return NumReg > 0;
        }


        // DOCUMENTO TIPO    SUBTIPODOC FECHA   CONTRIBUYENTE MONEDA  TIPO_CAMBIO_DOLAR SUBTOTAL    DESCUENTO 
        // IMPUESTO1   IMPUESTO2 RUBRO1  RUBRO2 MONTO   CUENTA_BANCO CUENTA_CONTABLE CENTRO_COSTO APLICACION  VALIDACION

        public static DataTable dtListarCamposExcelDL(string db)
        {
            string strSql = @"  DECLARE @TIPO_CAMBIO_DOLAR DECIMAL(28,6), @RETENCIONES VARCHAR(10);
                                SELECT TOP 0 SPACE(10) AS PROCESAR,
                                SPACE(10) AS PROCESAR, DOCUMENTO, TIPO, SPACE(10) AS SUBTIPODOC,
                                FECHA_DOC AS FECHA_DOCUMENTO, FECHA_DOC AS FECHA_CONTABLE,PROVEEDOR AS CONTRIBUYENTE, MONEDA,
                                @TIPO_CAMBIO_DOLAR AS TIPO_CAMBIO_DOLAR, SUBTOTAL, SUBTOTAL AS DESCUENTO,
                                IMPUESTO1, IMPUESTO1 AS IMPUESTO2,RUBRO_1 AS RUBRO1, RUBRO_2 AS RUBRO2,
                                MONTO, SPACE(50) AS CUENTA_BANCO, CUENTA_CONTABLE, CENTRO_COSTO, APLICACION,
                                SPACE(100) AS VALIDACION
                                FROM PIMENTEL.TMP_FACTURA_GY WITH (NOLOCK);
                             ";

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql).Tables[0];
        }


        //----------------------------------------------------------------------------------------------------------------------------------------------
        //ALTER PROCEDURE[PIMENTEL].[SP_APSSA_COBRANZA_DETALLE]
        //(@CAJA CHAR(4),
        //@FECHA_INI DATE,
        //@FECHA_FIN  DATE)
        public static DataTable dtObtieneCobranzaDetalleDL(string _caja, DateTime _fechaini, DateTime _fechafin, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_COBRANZA_DETALLE";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CAJA", _caja);
                    cmd.Parameters.AddWithValue("@FECHA_INI", _fechaini);
                    cmd.Parameters.AddWithValue("@FECHA_FIN", _fechafin);
                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    ds.Tables.Add(table);
                    cmd.Connection.Close();  //// ADD MXMX
                }
                return ds.Tables[0];
            }
        }


        //public static DataTable dtObtieneCobranzaDetalleDL(string _caja, DateTime _fechaini, DateTime _fechafin, string db)
        //{
        //    string strSql = "PIMENTEL.SP_APSSA_COBRANZA_DETALLE"; 
        //    List<SqlParameter> arParams = new List<SqlParameter>();
        //    arParams.Add(new SqlParameter("@CAJA", _caja));
        //    arParams.Add(new SqlParameter("@FECHA_INI", _fechaini));
        //    arParams.Add(new SqlParameter("@FECHA_FIN", _fechafin));
        //    return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray()).Tables[0];
        //}


        //ALTER PROCEDURE[PIMENTEL].[SP_APSSA_GET_FACTURA_CP]
        //(@PROVEEDOR VARCHAR(20),
        // @TIPO VARCHAR(3),
        // @DOCUMENTO VARCHAR(50),
        // @DATOS VARCHAR(2))
        public static bool ExisteFacturaCP_DL(string _proveedor, string _tipo_documento, string _documento, string _datos, string db)
        {
            int NumReg = 0;
            string strSql = "PIMENTEL.SP_APSSA_GET_FACTURA_CP";

            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@PROVEEDOR", _proveedor));
            arParam.Add(new SqlParameter("@TIPO", _tipo_documento));
            arParam.Add(new SqlParameter("@DOCUMENTO", _documento));
            arParam.Add(new SqlParameter("@DATOS", _datos));

            NumReg = Convert.ToInt32(SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParam.ToArray()));
            return NumReg > 0;
        }


        public static DataTable dtObtieneCompraSinOcDL(string _consecutivo, string _aplicacion, string _proveedor, string _datos, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_GET_COMPRA_SIN_OC";       //"PIMENTEL.SP_APSSA_GET_CSOC";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@CONSECUTIVO", _consecutivo));
            arParams.Add(new SqlParameter("@APLICACION", _aplicacion));
            arParams.Add(new SqlParameter("@PROVEEDOR", _proveedor));
            arParams.Add(new SqlParameter("@DATOS", _datos));
            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray()).Tables[0];
        }

        public static DataTable dtObtieneCompraSinOcLineaDL(string _consecutivo, string _aplicacion, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_GET_COMPRA_SIN_OC_LINEA";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@CONSECUTIVO", _consecutivo));
            arParams.Add(new SqlParameter("@APLICACION", _aplicacion));
            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray()).Tables[0];
        }



        //ALTER PROCEDURE[PIMENTEL].[SP_APSSA_GET_PROVEEDOR]
        //(@PROVEEDOR VARCHAR(20),
        //@DATOS VARCHAR(2))

        public static bool ExisteProveedorDL(string _proveedor, string _datos, string db)
        {
            int NumReg = 0;
            string strSql = "PIMENTEL.SP_APSSA_GET_PROVEEDOR";

            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@PROVEEDOR", _proveedor));
            arParam.Add(new SqlParameter("@DATOS", _datos));

            NumReg = Convert.ToInt32(SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParam.ToArray()));
            return NumReg > 0;
        }

        //ALTER PROCEDURE[PIMENTEL].[SP_APSSA_GET_COMPRA_SIN_OC]
        //(@CONSECUTIVO VARCHAR(10),		-- CSIN / EDCM / CSOC / RESO
        // @APLICACION  VARCHAR(50),
        // @PROVEEDOR VARCHAR(20),
        // @DATOS VARCHAR(2))

        public static bool ExisteCompraSinOcDL(string _consecutivo, string _aplicacion, string _proveedor, string _datos, string db)
        {
            int NumReg = 0;
            string strSql = "PIMENTEL.SP_APSSA_GET_COMPRA_SIN_OC";       //"PIMENTEL.SP_APSSA_GET_CSOC";

            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@CONSECUTIVO", _consecutivo));
            arParam.Add(new SqlParameter("@APLICACION", _aplicacion));
            arParam.Add(new SqlParameter("@PROVEEDOR", _proveedor));
            arParam.Add(new SqlParameter("@DATOS", _datos));

            NumReg = Convert.ToInt32(SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParam.ToArray()));
            return NumReg > 0;
        }

        //ALTER PROCEDURE[PIMENTEL].[SP_APSSA_GET_EMBARQUE]
        //(@EMBARQUE VARCHAR(10),
        // @PROVEEDOR VARCHAR(20),
        // @DATOS VARCHAR(2))

        public static bool ExisteEmbarqueDL(string _embarque, string _proveedor, string _datos, string db)
        {
            int NumReg = 0;
            string strSql = "PIMENTEL.SP_APSSA_GET_EMBARQUE";

            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@EMBARQUE", _embarque));
            arParam.Add(new SqlParameter("@PROVEEDOR", _proveedor));
            arParam.Add(new SqlParameter("@DATOS", _datos));

            NumReg = Convert.ToInt32(SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParam.ToArray()));
            return NumReg > 0;
        }


        public static DataTable dtTransaccionesDelMayorDL(DateTime _fecha_inicio, DateTime _fecha_final, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_MOV_TRANS_MAYOR";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FECHA_INI", _fecha_inicio);
                    cmd.Parameters.AddWithValue("@FECHA_FIN", _fecha_final);
                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    ds.Tables.Add(table);
                    cmd.Connection.Close();  //// ADD MXMX
                }
                return ds.Tables[0];
            }
        }

        public static DataTable dtObtieneDatosCierreVentasAjustesDL(Int32 _anno, Int32 _mes, string _tipo, string _operacion, string _usuario, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_CIERRE_VENTAS_AJUSTES";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@ANNO_PROCESO", _anno));
            arParams.Add(new SqlParameter("@MES_PROCESO", _mes));
            arParams.Add(new SqlParameter("@TIPO", _tipo));
            arParams.Add(new SqlParameter("@OPERACION", _operacion));
            arParams.Add(new SqlParameter("@USUARIO", _usuario));
            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray()).Tables[0];
        }



        /*
        ALTER PROCEDURE[PIMENTEL].[SP_APSSA_GET_EMBARQUE_VARIOS_DATOS_LINEA]
        (@PROVEEDOR VARCHAR(20),
         @TIPO_DOCU_XML VARCHAR(3),		-- O/C , GRI, 
         @DOCUMENTO_XML VARCHAR(50))		-- @REFERENCIA_XML
        */
        public static DataTable dtObtieneEmbarqueVariosDatosLineaDL(string _proveedor, string _tipo_docu_xml, string _documento_xml, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_GET_EMBARQUE_VARIOS_DATOS_LINEA";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@PROVEEDOR", _proveedor));
            arParams.Add(new SqlParameter("@TIPO_DOCU_XML", _tipo_docu_xml));
            arParams.Add(new SqlParameter("@DOCUMENTO_XML", _documento_xml));
            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray()).Tables[0];
        }

        public static DataTable dtObtieneEmbarqueVariosDatosDL(string _proveedor, string _tipo_docu_xml, string _documento_xml, string _campo_retorno, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_GET_EMBARQUE_VARIOS_DATOS";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@PROVEEDOR", _proveedor));
            arParams.Add(new SqlParameter("@TIPO_DOCU_XML", _tipo_docu_xml));
            arParams.Add(new SqlParameter("@DOCUMENTO_XML", _documento_xml));
            arParams.Add(new SqlParameter("@CAMPO_RETORNO", _campo_retorno));
            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray()).Tables[0];
        }

        /*
        ALTER PROCEDURE [PIMENTEL].[SP_APSSA_GET_EMBARQUE_VARIOS_DATOS]
        (@PROVEEDOR		 VARCHAR(20),
         @TIPO_DOCU_XML  VARCHAR(3),		-- O/C , GRI, 
         @DOCUMENTO_XML  VARCHAR(50),		-- @REFERENCIA_XML
         @CAMPO_RETORNO  VARCHAR(50))	         
        */
        public static string ObtieneEmbarqueVariosDatosDL(string _proveedor, string _tipo_docu_xml, string _documento_xml, string _campo_retorno, string db)
        {
            string cEmbarque = string.Empty;

            string strSql = "PIMENTEL.SP_APSSA_GET_EMBARQUE_VARIOS_DATOS";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@PROVEEDOR", _proveedor));
            arParams.Add(new SqlParameter("@TIPO_DOCU_XML", _tipo_docu_xml));
            arParams.Add(new SqlParameter("@DOCUMENTO_XML", _documento_xml));
            arParams.Add(new SqlParameter("@CAMPO_RETORNO", _campo_retorno));
            cEmbarque = Convert.ToString(SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray()));

            return cEmbarque;
        }




        /// <summary>
        /// 
        /// 
        /// ////////
        public static bool ValidarCondicionPagoDL(string _condicion_pago, string db)
        {
            int NumReg = 0;
            string strSql = @"SELECT COUNT(*) 
                              FROM PIMENTEL.CONDICION_PAGO WITH (NOLOCK)
                              WHERE CONDICION_PAGO=@CONDICION_PAGO";

            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@CONDICION_PAGO", _condicion_pago));

            NumReg = Convert.ToInt32(SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray()));
            return NumReg > 0;
        }

        public static bool ValidarEmbarqueDL(string _embarque, string _proveedor, string _datos, string db)
        {
            int NumReg = 0;
            string strSql = "PIMENTEL.SP_APSSA_BUSCA_EMBARQUE";

            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@EMBARQUE", _embarque));
            arParam.Add(new SqlParameter("@PROVEEDOR", _proveedor));
            arParam.Add(new SqlParameter("@DATOS", _datos));

            NumReg = Convert.ToInt32(SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParam.ToArray()));
            return NumReg > 0;
        }



        public static string ObtieneCuentaCompraArticuloDL(string _articulo_cuenta, string db)
        {
            string cCuentaContable = string.Empty;

            string strSql = @"SELECT LTRIM(RTRIM(CTA_COMPRA_LOC)) 
                              FROM PIMENTEL.ARTICULO_CUENTA WITH (NOLOCK) WHERE ARTICULO_CUENTA=@ARTICULO_CUENTA;";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@ARTICULO_CUENTA", _articulo_cuenta));
            cCuentaContable = Convert.ToString(SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParams.ToArray()));

            return cCuentaContable;
        }

        public static string ObtieneArticuloFamiliaCodigoDL(string _articulo, string db)
        {
            string cFamiliaCodigo = string.Empty;

            string strSql = "SELECT (LTRIM(RTRIM(PIMENTEL.FN_APSSA_GET_FAMILIA_CODE(@ARTICULO))));";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@ARTICULO", _articulo));
            cFamiliaCodigo = Convert.ToString(SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParams.ToArray()));

            return cFamiliaCodigo;
        }

        public static DataTable dtObtieneEmbarqueDatosLineaDL(string _embarque, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_GET_EMBARQUE_DATOS_LINEA";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@EMBARQUE", _embarque));
            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray()).Tables[0];
        }


        public static string ObtieneEmbarqueDatosDL(string _embarque, string _campo_retorno, string db)
        {
            string cEmbarque = string.Empty;

            string strSql = "PIMENTEL.SP_APSSA_GET_EMBARQUE_DATOS";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@EMBARQUE", _embarque));
            arParams.Add(new SqlParameter("@CAMPO_RETORNO", _campo_retorno));
            cEmbarque = Convert.ToString(SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray()));

            return cEmbarque;
        }

        public static DataTable dtObtieneEmbarqueDatosDL(string _embarque, string _campo_retorno, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_GET_EMBARQUE_DATOS";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@EMBARQUE", _embarque));
            arParams.Add(new SqlParameter("@CAMPO_RETORNO", _campo_retorno));
            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray()).Tables[0];
        }

        /*
        ALTER PROCEDURE [PIMENTEL].[SP_APSSA_GET_EMBARQUE_PROV]
        (@PROVEEDOR		 VARCHAR(20),
         @TIPO_DOCU_XML  VARCHAR(3),		-- O/C , GRI, 
         @DOCUMENTO_XML  VARCHAR(50),		-- @REFERENCIA_XML
         @CAMPO_RETORNO  VARCHAR(50))		-- 'EMBARQUE', 'RUBRO1', 'NOTAS' , 'REFERENCIA' , 'SOLES', 'DOLARES'
        */

        public static string ObtieneEmbarqueProveedoresDL(string _proveedor, string _tipo_docu_xml, string _documento_xml, string _campo_retorno, string db)
        {
            string cEmbarque = string.Empty;

            string strSql = "PIMENTEL.SP_APSSA_GET_EMBARQUE_PROV";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@PROVEEDOR", _proveedor));
            arParams.Add(new SqlParameter("@TIPO_DOCU_XML", _tipo_docu_xml));
            arParams.Add(new SqlParameter("@DOCUMENTO_XML", _documento_xml));
            arParams.Add(new SqlParameter("@CAMPO_RETORNO", _campo_retorno));
            cEmbarque = Convert.ToString(SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray()));

            return cEmbarque;
        }

        //public static string ObtieneEmbarqueProveedoresDL(string _proveedor, string _referxml, string _campo_retorno, string db)
        //{
        //    string cEmbarque = string.Empty;
        //    string strSql = "PIMENTEL.SP_APSSA_GET_EMBARQUE_PROV";
        //    List<SqlParameter> arParams = new List<SqlParameter>();
        //    arParams.Add(new SqlParameter("@PROVEEDOR", _proveedor));
        //    arParams.Add(new SqlParameter("@REFERENCIA_XML", _referxml));
        //    arParams.Add(new SqlParameter("@CAMPO_RETORNO", _campo_retorno));
        //    cEmbarque = Convert.ToString(SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray()));
        //    return cEmbarque;
        //}


        public static DataTable dtListarFacturaProveedoresDL(string db)
        {
            //string strSql = @"  DECLARE @EMB_AUDIT_TRANS_INV INT;
            //                    SELECT TOP 0
            //                    SPACE(10) AS PROCESAR,PROVEEDOR,TIPO,DOCUMENTO,FECHA_DOC,                                
            //                    APLICACION,SUBTOTAL,IMPUESTO1,MONTO,SALDO,MONEDA,CONDICION_PAGO,
            //                    SUBTIPO,CENTRO_COSTO,CUENTA_CONTABLE,FECHA_CONTABLE,RUBRO_8_DOC,
            //                    PAQUETE,TIPO_ASIENTO,EMBARQUE,TIPO_REFERENCIA,DOC_REFERENCIA,
            //                    BASE_IMPUESTO1,FECHA_VENCE,USUARIO,
            //                    EMB_MONTO_LOCAL, EMB_MONTO_DOLAR,XML_ITEMS,
            //                    FECHA_RIGE,DESCUENTO,IMPUESTO2,RUBRO_1,RUBRO_2,CUENTA_BANCARIA,NOTAS,
            //                    RUBRO_1_DOC,RUBRO_2_DOC,RUBRO_3_DOC,RUBRO_4_DOC,RUBRO_5_DOC,
            //                    RUBRO_6_DOC,RUBRO_7_DOC,RUBRO_9_DOC,RUBRO_10_DOC,RETENCIÓN, 
            //                    BASE_IMPUESTO2,  CARGADO,
            //                    PROVEEDOR AS EMB_PROVEEDOR, EMB_REFERENCIA, EMB_RUBRO1, EMB_NOTAS, EMB_CONDICIONPAGO,  
            //                    EMBARQUE AS EMB_EMBARQUE, FECHA_DOC AS EMB_FECHA_EMBARQUE,
            //                    SPACE(10) AS EMB_ESTADO, FECHA_DOC AS EMB_U_FECHAGUIA,
            //                    @EMB_AUDIT_TRANS_INV AS EMB_AUDIT_TRANS_INV
            //                    FROM PIMENTEL.TMP_FACTURA_GY WITH (NOLOCK);
            //                 ";

            //string strSql = @"  DECLARE @EMB_AUDIT_TRANS_INV INT, @RETENCIONES VARCHAR(10);
            //                    SELECT TOP 0
            //                    SPACE(10) AS PROCESAR,PROVEEDOR,TIPO,DOCUMENTO,FECHA_DOC,                                
            //                    APLICACION,SUBTOTAL,IMPUESTO1, MONTO, 0 AS DIFERENCIA,
            //                    MONEDA,CONDICION_PAGO, @RETENCIONES AS RETENCIONES,
            //                    SUBTIPO,CENTRO_COSTO,CUENTA_CONTABLE,FECHA_CONTABLE,RUBRO_8_DOC,
            //                    PAQUETE,TIPO_ASIENTO,EMBARQUE,@EMB_AUDIT_TRANS_INV AS EMB_AUDIT_TRANS_INV,
            //                    EMB_MONTO_LOCAL, EMB_MONTO_DOLAR,XML_ITEMS,
            //                    TIPO_REFERENCIA,DOC_REFERENCIA, BASE_IMPUESTO1,SALDO,FECHA_VENCE,USUARIO,                                
            //                    FECHA_RIGE,DESCUENTO,IMPUESTO2,RUBRO_1,RUBRO_2,CUENTA_BANCARIA,NOTAS,
            //                    RUBRO_1_DOC,RUBRO_2_DOC,RUBRO_3_DOC,RUBRO_4_DOC,RUBRO_5_DOC,
            //                    RUBRO_6_DOC,RUBRO_7_DOC,RUBRO_9_DOC,RUBRO_10_DOC, RETENCIÓN, BASE_IMPUESTO2, CARGADO,                                
            //                    PROVEEDOR AS EMB_PROVEEDOR, EMB_REFERENCIA, EMB_RUBRO1, EMB_NOTAS, EMB_CONDICIONPAGO,
            //                    EMBARQUE AS EMB_EMBARQUE, FECHA_DOC AS EMB_FECHA_EMBARQUE,
            //                    SPACE(10) AS EMB_ESTADO, FECHA_DOC AS EMB_U_FECHAGUIA                                
            //                    FROM PIMENTEL.TMP_FACTURA_GY WITH (NOLOCK);
            //                 ";

            string strSql = @"  DECLARE @EMB_AUDIT_TRANS_INV INT, @RETENCIONES VARCHAR(10);
                                SELECT TOP 0
                                SPACE(10) AS PROCESAR,PROVEEDOR,TIPO,DOCUMENTO,FECHA_DOC,                                
                                APLICACION,SUBTOTAL,IMPUESTO1, MONTO, 0 AS DIFERENCIA,
                                MONEDA,CONDICION_PAGO, @RETENCIONES AS RETENCIONES,
                                SUBTIPO,CENTRO_COSTO,CUENTA_CONTABLE,FECHA_CONTABLE,RUBRO_8_DOC,
                                PAQUETE,TIPO_ASIENTO,EMBARQUE,@EMB_AUDIT_TRANS_INV AS EMB_AUDIT_TRANS_INV,
                                EMB_MONTO_LOCAL, EMB_MONTO_DOLAR,XML_ITEMS,
                                TIPO_REFERENCIA,DOC_REFERENCIA, BASE_IMPUESTO1,SALDO,FECHA_VENCE,USUARIO,                                
                                FECHA_RIGE,DESCUENTO,IMPUESTO2,RUBRO_1,RUBRO_2,CUENTA_BANCARIA,NOTAS,
                                RUBRO_1_DOC,RUBRO_2_DOC,RUBRO_3_DOC,RUBRO_4_DOC,RUBRO_5_DOC,
                                RUBRO_6_DOC,RUBRO_7_DOC,RUBRO_9_DOC,RUBRO_10_DOC, RETENCIÓN, BASE_IMPUESTO2, CARGADO,                                
                                PROVEEDOR AS EMB_PROVEEDOR, EMB_REFERENCIA, EMB_RUBRO1, EMB_NOTAS, EMB_CONDICIONPAGO,
                                EMBARQUE AS EMB_EMBARQUE, FECHA_DOC AS EMB_FECHA_EMBARQUE,
                                SPACE(10) AS EMB_ESTADO, FECHA_DOC AS EMB_U_FECHAGUIA,
                                SPACE(3) AS TIP_DOC_REF, SPACE(50) AS NUM_DOC_REF, SPACE(100) AS EMBARQUE_OC, SPACE(1) AS DETRACCION
                                FROM PIMENTEL.TMP_FACTURA_GY WITH (NOLOCK);
                             ";



            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql).Tables[0];
        }



        public static DataTable dtProcesaFacturasProveedores2DL(string _proveedor, string _documento, string _tipo, DateTime _fecha_documento, string _aplicacion,
                                                                Decimal _monto, Decimal _saldo, Decimal _subtotal, Decimal _descuento, Decimal _impuesto1, Decimal _impuesto2,
                                                                Decimal _rubro1, Decimal _rubro2, string _condicion_pago, string _moneda, Int16 _subtipo, DateTime _fecha_vence,
                                                                Decimal _base_impuesto1, Decimal _base_impuesto2, string _rubro8_doc, string _vcuenta_contable,
                                                                string _vcentro_costo, string _vembarque, DateTime _vfecha_proceso, string _vusuario,
                                                                string _vtip_doc_ref, string _vnum_doc_ref, string _vembarque_oc, string _vdetraccion, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_FACTURA_PROV_PROCESA2";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PROVEEDOR", _proveedor);
                    cmd.Parameters.AddWithValue("@DOCUMENTO", _documento);
                    cmd.Parameters.AddWithValue("@TIPO", _tipo);
                    cmd.Parameters.AddWithValue("@FECHA_DOCUMENTO", _fecha_documento);
                    cmd.Parameters.AddWithValue("@APLICACION", _aplicacion);
                    cmd.Parameters.AddWithValue("@MONTO", _monto);
                    cmd.Parameters.AddWithValue("@SALDO", _saldo);
                    cmd.Parameters.AddWithValue("@SUBTOTAL", _subtotal);
                    cmd.Parameters.AddWithValue("@DESCUENTO", _descuento);
                    cmd.Parameters.AddWithValue("@IMPUESTO1", _impuesto1);
                    cmd.Parameters.AddWithValue("@IMPUESTO2", _impuesto2);
                    cmd.Parameters.AddWithValue("@RUBRO1", _rubro1);
                    cmd.Parameters.AddWithValue("@RUBRO2", _rubro2);
                    cmd.Parameters.AddWithValue("@CONDICION_PAGO", _condicion_pago);
                    cmd.Parameters.AddWithValue("@MONEDA", _moneda);
                    cmd.Parameters.AddWithValue("@SUBTIPO", _subtipo);
                    cmd.Parameters.AddWithValue("@FECHA_VENCE", _fecha_vence);
                    cmd.Parameters.AddWithValue("@BASE_IMPUESTO1", _base_impuesto1);
                    cmd.Parameters.AddWithValue("@BASE_IMPUESTO2", _base_impuesto2);
                    cmd.Parameters.AddWithValue("@RUBRO8_DOC", _rubro8_doc);
                    cmd.Parameters.AddWithValue("@VCUENTA_CONTABLE", _vcuenta_contable);
                    cmd.Parameters.AddWithValue("@VCENTRO_COSTO", _vcentro_costo);
                    cmd.Parameters.AddWithValue("@VEMBARQUE", _vembarque);
                    cmd.Parameters.AddWithValue("@VFECHA_PROCESO", _vfecha_proceso);
                    cmd.Parameters.AddWithValue("@VUSUARIO", _vusuario);
                    cmd.Parameters.AddWithValue("@VTIP_DOC_REF", _vtip_doc_ref);
                    cmd.Parameters.AddWithValue("@VNUM_DOC_REF", _vnum_doc_ref);
                    cmd.Parameters.AddWithValue("@VEMBARQUE_OC", _vembarque_oc);
                    cmd.Parameters.AddWithValue("@VDETRACCION", _vdetraccion);
                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    ds.Tables.Add(table);
                    cmd.Connection.Close();  //// ADD MXMX
                }
                return ds.Tables[0];
            }
        }


        public static DataTable dtProcesaFacturasProveedoresDL(string _proveedor, string _documento, string _tipo, DateTime _fecha_documento, string _aplicacion,
                                                                Decimal _monto, Decimal _saldo, Decimal _subtotal, Decimal _descuento, Decimal _impuesto1, Decimal _impuesto2,
                                                                Decimal _rubro1, Decimal _rubro2, string _condicion_pago, string _moneda, Int16 _subtipo, DateTime _fecha_vence,
                                                                Decimal _base_impuesto1, Decimal _base_impuesto2, string _rubro8_doc, string _vcuenta_contable,
                                                                string _vcentro_costo, string _vembarque, DateTime _vfecha_proceso, string _vusuario, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_FACTURA_PROV_PROCESA";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PROVEEDOR", _proveedor);
                    cmd.Parameters.AddWithValue("@DOCUMENTO", _documento);
                    cmd.Parameters.AddWithValue("@TIPO", _tipo);
                    cmd.Parameters.AddWithValue("@FECHA_DOCUMENTO", _fecha_documento);
                    cmd.Parameters.AddWithValue("@APLICACION", _aplicacion);
                    cmd.Parameters.AddWithValue("@MONTO", _monto);
                    cmd.Parameters.AddWithValue("@SALDO", _saldo);
                    cmd.Parameters.AddWithValue("@SUBTOTAL", _subtotal);
                    cmd.Parameters.AddWithValue("@DESCUENTO", _descuento);
                    cmd.Parameters.AddWithValue("@IMPUESTO1", _impuesto1);
                    cmd.Parameters.AddWithValue("@IMPUESTO2", _impuesto2);
                    cmd.Parameters.AddWithValue("@RUBRO1", _rubro1);
                    cmd.Parameters.AddWithValue("@RUBRO2", _rubro2);
                    cmd.Parameters.AddWithValue("@CONDICION_PAGO", _condicion_pago);
                    cmd.Parameters.AddWithValue("@MONEDA", _moneda);
                    cmd.Parameters.AddWithValue("@SUBTIPO", _subtipo);
                    cmd.Parameters.AddWithValue("@FECHA_VENCE", _fecha_vence);
                    cmd.Parameters.AddWithValue("@BASE_IMPUESTO1", _base_impuesto1);
                    cmd.Parameters.AddWithValue("@BASE_IMPUESTO2", _base_impuesto2);
                    cmd.Parameters.AddWithValue("@RUBRO8_DOC", _rubro8_doc);
                    cmd.Parameters.AddWithValue("@VCUENTA_CONTABLE", _vcuenta_contable);
                    cmd.Parameters.AddWithValue("@VCENTRO_COSTO", _vcentro_costo);
                    cmd.Parameters.AddWithValue("@VEMBARQUE", _vembarque);
                    cmd.Parameters.AddWithValue("@VFECHA_PROCESO", _vfecha_proceso);
                    cmd.Parameters.AddWithValue("@VUSUARIO", _vusuario);
                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    ds.Tables.Add(table);
                    cmd.Connection.Close();  //// ADD MXMX
                }
                return ds.Tables[0];
            }
        }



        public static DataTable dtProcesaFacturasOtros2DL(string _proveedor, string _documento, string _tipo, DateTime _fecha_documento, string _aplicacion,
                                                         Decimal _monto, Decimal _saldo, Decimal _subtotal, Decimal _descuento, Decimal _impuesto1, Decimal _impuesto2,
                                                         Decimal _rubro1, Decimal _rubro2, string _condicion_pago, string _moneda, Int16 _subtipo, DateTime _fecha_vence,
                                                         Decimal _base_impuesto1, Decimal _base_impuesto2, string _rubro8_doc, string _vcuenta_contable,
                                                         string _vcentro_costo, string _vembarque, DateTime _vfecha_proceso, string _vusuario, string _vdetraccion, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_FACTURA_OTROS_PROCESA2";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PROVEEDOR", _proveedor);
                    cmd.Parameters.AddWithValue("@DOCUMENTO", _documento);
                    cmd.Parameters.AddWithValue("@TIPO", _tipo);
                    cmd.Parameters.AddWithValue("@FECHA_DOCUMENTO", _fecha_documento);
                    cmd.Parameters.AddWithValue("@APLICACION", _aplicacion);
                    cmd.Parameters.AddWithValue("@MONTO", _monto);
                    cmd.Parameters.AddWithValue("@SALDO", _saldo);
                    cmd.Parameters.AddWithValue("@SUBTOTAL", _subtotal);
                    cmd.Parameters.AddWithValue("@DESCUENTO", _descuento);
                    cmd.Parameters.AddWithValue("@IMPUESTO1", _impuesto1);
                    cmd.Parameters.AddWithValue("@IMPUESTO2", _impuesto2);
                    cmd.Parameters.AddWithValue("@RUBRO1", _rubro1);
                    cmd.Parameters.AddWithValue("@RUBRO2", _rubro2);
                    cmd.Parameters.AddWithValue("@CONDICION_PAGO", _condicion_pago);
                    cmd.Parameters.AddWithValue("@MONEDA", _moneda);
                    cmd.Parameters.AddWithValue("@SUBTIPO", _subtipo);
                    cmd.Parameters.AddWithValue("@FECHA_VENCE", _fecha_vence);
                    cmd.Parameters.AddWithValue("@BASE_IMPUESTO1", _base_impuesto1);
                    cmd.Parameters.AddWithValue("@BASE_IMPUESTO2", _base_impuesto2);
                    cmd.Parameters.AddWithValue("@RUBRO8_DOC", _rubro8_doc);
                    cmd.Parameters.AddWithValue("@VCUENTA_CONTABLE", _vcuenta_contable);
                    cmd.Parameters.AddWithValue("@VCENTRO_COSTO", _vcentro_costo);
                    cmd.Parameters.AddWithValue("@VEMBARQUE", _vembarque);
                    cmd.Parameters.AddWithValue("@VFECHA_PROCESO", _vfecha_proceso);
                    cmd.Parameters.AddWithValue("@VUSUARIO", _vusuario);
                    cmd.Parameters.AddWithValue("@VDETRACCION", _vdetraccion);
                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    ds.Tables.Add(table);
                    cmd.Connection.Close();  //// ADD MXMX
                }
                return ds.Tables[0];
            }
        }


        public static DataTable dtProcesaCompraGYDL(string _linea, Int32 _ti ,Int32 _fu,Int32 _sd,Int32 _flotas, Int32 _otr, 
            Int32 _mes,Int32 _anno,string _usuario, string _tienda, Int32 _orden,string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_COMPRA_VENTA_GY_CARGA_CO";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@LINEA", _linea);
                    cmd.Parameters.AddWithValue("@TI", _ti);
                    cmd.Parameters.AddWithValue("@FU", _fu);
                    cmd.Parameters.AddWithValue("@SD", _sd);
                    cmd.Parameters.AddWithValue("@FLOTAS", _flotas);
                    cmd.Parameters.AddWithValue("@OTR", _otr);
                    cmd.Parameters.AddWithValue("@MES", _mes);
                    cmd.Parameters.AddWithValue("@ANNO", _anno);
                    cmd.Parameters.AddWithValue("@USUARIO", _usuario);
                    cmd.Parameters.AddWithValue("@TIENDA", _tienda);
                    cmd.Parameters.AddWithValue("@ORDEN", _orden);
                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    ds.Tables.Add(table);
                    cmd.Connection.Close();  //// ADD MXMX
                }
                return ds.Tables[0];
            }
        }



        public static DataTable dtProcesaFacturasOtrosDL(string _proveedor, string _documento, string _tipo, DateTime _fecha_documento, string _aplicacion,
                                                         Decimal _monto, Decimal _saldo, Decimal _subtotal, Decimal _descuento, Decimal _impuesto1, Decimal _impuesto2,
                                                         Decimal _rubro1, Decimal _rubro2, string _condicion_pago, string _moneda, Int16 _subtipo, DateTime _fecha_vence,
                                                         Decimal _base_impuesto1, Decimal _base_impuesto2, string _rubro8_doc, string _vcuenta_contable,
                                                         string _vcentro_costo, string _vembarque, DateTime _vfecha_proceso, string _vusuario, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_FACTURA_OTROS_PROCESA";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PROVEEDOR", _proveedor);
                    cmd.Parameters.AddWithValue("@DOCUMENTO", _documento);
                    cmd.Parameters.AddWithValue("@TIPO", _tipo);
                    cmd.Parameters.AddWithValue("@FECHA_DOCUMENTO", _fecha_documento);
                    cmd.Parameters.AddWithValue("@APLICACION", _aplicacion);
                    cmd.Parameters.AddWithValue("@MONTO", _monto);
                    cmd.Parameters.AddWithValue("@SALDO", _saldo);
                    cmd.Parameters.AddWithValue("@SUBTOTAL", _subtotal);
                    cmd.Parameters.AddWithValue("@DESCUENTO", _descuento);
                    cmd.Parameters.AddWithValue("@IMPUESTO1", _impuesto1);
                    cmd.Parameters.AddWithValue("@IMPUESTO2", _impuesto2);
                    cmd.Parameters.AddWithValue("@RUBRO1", _rubro1);
                    cmd.Parameters.AddWithValue("@RUBRO2", _rubro2);
                    cmd.Parameters.AddWithValue("@CONDICION_PAGO", _condicion_pago);
                    cmd.Parameters.AddWithValue("@MONEDA", _moneda);
                    cmd.Parameters.AddWithValue("@SUBTIPO", _subtipo);
                    cmd.Parameters.AddWithValue("@FECHA_VENCE", _fecha_vence);
                    cmd.Parameters.AddWithValue("@BASE_IMPUESTO1", _base_impuesto1);
                    cmd.Parameters.AddWithValue("@BASE_IMPUESTO2", _base_impuesto2);
                    cmd.Parameters.AddWithValue("@RUBRO8_DOC", _rubro8_doc);
                    cmd.Parameters.AddWithValue("@VCUENTA_CONTABLE", _vcuenta_contable);
                    cmd.Parameters.AddWithValue("@VCENTRO_COSTO", _vcentro_costo);
                    cmd.Parameters.AddWithValue("@VEMBARQUE", _vembarque);
                    cmd.Parameters.AddWithValue("@VFECHA_PROCESO", _vfecha_proceso);
                    cmd.Parameters.AddWithValue("@VUSUARIO", _vusuario);
                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    ds.Tables.Add(table);
                    cmd.Connection.Close();  //// ADD MXMX
                }
                return ds.Tables[0];
            }
        }

        public static DataTable ObtieneDatosEmbarqueLineaOtrosDL(string _embarque, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_GET_EMBARQUE_OTROS_LINEA";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@EMBARQUE", _embarque));
            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray()).Tables[0];
        }


        public static DataTable dtListarFacturaOtrosDL(string db)
        {
            //string strSql = @"  DECLARE @EMB_AUDIT_TRANS_INV VARCHAR(25), @RETENCIONES VARCHAR(10);
            //                    SELECT TOP 0
            //                    SPACE(10) AS PROCESAR,PROVEEDOR,TIPO,DOCUMENTO,FECHA_DOC,                                
            //                    APLICACION,SUBTOTAL,IMPUESTO1, MONTO, 0 AS DIFERENCIA,
            //                    MONEDA,CONDICION_PAGO, @RETENCIONES AS RETENCIONES,
            //                    SUBTIPO,CENTRO_COSTO,CUENTA_CONTABLE,FECHA_CONTABLE,RUBRO_8_DOC,
            //                    PAQUETE,TIPO_ASIENTO,EMBARQUE,@EMB_AUDIT_TRANS_INV AS EMB_AUDIT_TRANS_INV,
            //                    EMB_MONTO_LOCAL, EMB_MONTO_DOLAR,XML_ITEMS,
            //                    TIPO_REFERENCIA,DOC_REFERENCIA, BASE_IMPUESTO1,SALDO,FECHA_VENCE,USUARIO,                                
            //                    FECHA_RIGE,DESCUENTO,IMPUESTO2,RUBRO_1,RUBRO_2,CUENTA_BANCARIA,NOTAS,
            //                    RUBRO_1_DOC,RUBRO_2_DOC,RUBRO_3_DOC,RUBRO_4_DOC,RUBRO_5_DOC,
            //                    RUBRO_6_DOC,RUBRO_7_DOC,RUBRO_9_DOC,RUBRO_10_DOC, RETENCIÓN, BASE_IMPUESTO2, CARGADO,                                
            //                    PROVEEDOR AS EMB_PROVEEDOR, EMB_REFERENCIA, EMB_RUBRO1, EMB_NOTAS, EMB_CONDICIONPAGO,
            //                    EMBARQUE AS EMB_EMBARQUE, FECHA_DOC AS EMB_FECHA_EMBARQUE,
            //                    SPACE(10) AS EMB_ESTADO, FECHA_DOC AS EMB_U_FECHAGUIA,
            //                    SPACE(3) AS TIP_DOC_REF, SPACE(50) AS NUM_DOC_REF, SPACE(100) AS EMBARQUE_OC, SPACE(1) AS DETRACCION
            //                    FROM PIMENTEL.TMP_FACTURA_GY WITH (NOLOCK);
            //                 ";
            string strSql = @"  DECLARE @EMB_AUDIT_TRANS_INV VARCHAR(25), @RETENCIONES VARCHAR(10);
                                SELECT TOP 0
                                SPACE(10) AS PROCESAR,SPACE(50) AS VALIDACION,PROVEEDOR,TIPO,DOCUMENTO,FECHA_DOC,                                
                                APLICACION,SUBTOTAL,IMPUESTO1, MONTO, 0 AS DIFERENCIA,
                                MONEDA,CONDICION_PAGO, @RETENCIONES AS RETENCIONES,
                                SUBTIPO,CENTRO_COSTO,CUENTA_CONTABLE,FECHA_CONTABLE,RUBRO_8_DOC,
                                PAQUETE,TIPO_ASIENTO,EMBARQUE,@EMB_AUDIT_TRANS_INV AS EMB_AUDIT_TRANS_INV,
                                EMB_MONTO_LOCAL, EMB_MONTO_DOLAR,XML_ITEMS,
                                TIPO_REFERENCIA,DOC_REFERENCIA, BASE_IMPUESTO1,SALDO,FECHA_VENCE,USUARIO,                                
                                FECHA_RIGE,DESCUENTO,IMPUESTO2,RUBRO_1,RUBRO_2,CUENTA_BANCARIA,NOTAS,
                                RUBRO_1_DOC,RUBRO_2_DOC,RUBRO_3_DOC,RUBRO_4_DOC,RUBRO_5_DOC,
                                RUBRO_6_DOC,RUBRO_7_DOC,RUBRO_9_DOC,RUBRO_10_DOC, RETENCIÓN, BASE_IMPUESTO2, CARGADO,                                
                                PROVEEDOR AS EMB_PROVEEDOR, EMB_REFERENCIA, EMB_RUBRO1, EMB_NOTAS, EMB_CONDICIONPAGO,
                                EMBARQUE AS EMB_EMBARQUE, FECHA_DOC AS EMB_FECHA_EMBARQUE,
                                SPACE(10) AS EMB_ESTADO, FECHA_DOC AS EMB_U_FECHAGUIA,
                                SPACE(3) AS TIP_DOC_REF, SPACE(50) AS NUM_DOC_REF, SPACE(100) AS EMBARQUE_OC, SPACE(1) AS DETRACCION                                
                                FROM PIMENTEL.TMP_FACTURA_GY WITH (NOLOCK);
                             ";

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql).Tables[0];
        }


        public static string ObtieneDatosEmbarqueOtrosDL(string _embarque, string _campo_retorno, string db)
        {
            string cReferencia = string.Empty;

            string strSql = "PIMENTEL.SP_APSSA_GET_EMBARQUE_OTROS";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@EMBARQUE", _embarque));
            arParams.Add(new SqlParameter("@CAMPO_RETORNO", _campo_retorno));
            cReferencia = Convert.ToString(SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray()));

            return cReferencia;
        }


        public static DataTable dtObtieneDatosEmbarqueOtrosDL(string _embarque, string _campo_retorno, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_GET_EMBARQUE_OTROS";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@EMBARQUE", _embarque));
            arParams.Add(new SqlParameter("@CAMPO_RETORNO", _campo_retorno));
            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray()).Tables[0];
        }



        public static string ObtieneProveedorFacturaXmlDL(string _proveedorxml, string db)
        {
            string Nombre_Proveedor = string.Empty;

            string strSql = @" SELECT LTRIM(RTRIM(NOMBRE))
                               FROM PIMENTEL.PROVEEDOR WITH (NOLOCK)
                               WHERE PROVEEDOR = @PROVEEDOR;
                            ";

            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@PROVEEDOR", _proveedorxml));

            Nombre_Proveedor = Convert.ToString(SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray()));

            return Nombre_Proveedor;
        }

        public static string ObtieneEmbarqueFacturaGyDL(string _guiaremxml, string _campo_retorno, string db)
        {
            string cEmbarque = string.Empty;

            string strSql = "PIMENTEL.SP_APSSA_GET_EMBARQUE_GY";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@GUIA_REM_XML", _guiaremxml));
            arParams.Add(new SqlParameter("@CAMPO_RETORNO", _campo_retorno));
            cEmbarque = Convert.ToString(SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray()));

            return cEmbarque;
        }



        public static DataTable dtProcesaFacturasGyDL(string _proveedor, string _documento, string _tipo, DateTime _fecha_documento, string _aplicacion,
                                                      Decimal _monto, Decimal _saldo, Decimal _subtotal, Decimal _descuento, Decimal _impuesto1, Decimal _impuesto2,
                                                      Decimal _rubro1, Decimal _rubro2, string _condicion_pago, string _moneda, Int16 _subtipo, DateTime _fecha_vence,
                                                      Decimal _base_impuesto1, Decimal _base_impuesto2, string _rubro8_doc, string _vcuenta_contable,
                                                      string _vcentro_costo, string _vembarque, DateTime _vfecha_proceso, string _vusuario, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_FACTURA_GY_PROCESA";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PROVEEDOR", _proveedor);
                    cmd.Parameters.AddWithValue("@DOCUMENTO", _documento);
                    cmd.Parameters.AddWithValue("@TIPO", _tipo);
                    cmd.Parameters.AddWithValue("@FECHA_DOCUMENTO", _fecha_documento);
                    cmd.Parameters.AddWithValue("@APLICACION", _aplicacion);
                    cmd.Parameters.AddWithValue("@MONTO", _monto);
                    cmd.Parameters.AddWithValue("@SALDO", _saldo);
                    cmd.Parameters.AddWithValue("@SUBTOTAL", _subtotal);
                    cmd.Parameters.AddWithValue("@DESCUENTO", _descuento);
                    cmd.Parameters.AddWithValue("@IMPUESTO1", _impuesto1);
                    cmd.Parameters.AddWithValue("@IMPUESTO2", _impuesto2);
                    cmd.Parameters.AddWithValue("@RUBRO1", _rubro1);
                    cmd.Parameters.AddWithValue("@RUBRO2", _rubro2);
                    cmd.Parameters.AddWithValue("@CONDICION_PAGO", _condicion_pago);
                    cmd.Parameters.AddWithValue("@MONEDA", _moneda);
                    cmd.Parameters.AddWithValue("@SUBTIPO", _subtipo);
                    cmd.Parameters.AddWithValue("@FECHA_VENCE", _fecha_vence);
                    cmd.Parameters.AddWithValue("@BASE_IMPUESTO1", _base_impuesto1);
                    cmd.Parameters.AddWithValue("@BASE_IMPUESTO2", _base_impuesto2);
                    cmd.Parameters.AddWithValue("@RUBRO8_DOC", _rubro8_doc);
                    cmd.Parameters.AddWithValue("@VCUENTA_CONTABLE", _vcuenta_contable);
                    cmd.Parameters.AddWithValue("@VCENTRO_COSTO", _vcentro_costo);
                    cmd.Parameters.AddWithValue("@VEMBARQUE", _vembarque);
                    cmd.Parameters.AddWithValue("@VFECHA_PROCESO", _vfecha_proceso);
                    cmd.Parameters.AddWithValue("@VUSUARIO", _vusuario);
                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    ds.Tables.Add(table);
                    cmd.Connection.Close();  //// ADD MXMX
                }
                return ds.Tables[0];
            }
        }



        /*
        public static DataTable dtObtenerCuentaContableDL(string cdb)
        {
            string strSql = "PIMENTEL.SP_APSSA_LISTAR_CUENTA_CONTABLE";

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(cdb), CommandType.StoredProcedure, strSql).Tables[0];
        }

        */

        //ALTER PROCEDURE [PIMENTEL].[SP_APSSA_BAL_COMP_RECUPERAR]
        //(@TEMPORAL_SQL  VARCHAR(250))
        // WITH ENCRYPTION 

        public static DataTable dtObtenerInformacionContadoDL(string db)
        {
            string strSql = @" SET LANGUAGE SPANISH;                        
                               SELECT * FROM DBO.BORRAR_REPORTE_CONTADO WITH (NOLOCK)
                               ORDER BY FECHA_HORA;
                            ";

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql).Tables[0];
        }

        public static DataTable dtObtenerMesesHistoricoDL(string db)
        {
            string strSql = @" SET LANGUAGE SPANISH;                        
                               SELECT MES FROM PIMENTEL.Fn_APPSA_GET_MESES('S') ORDER BY IDMES ASC;
                            ";

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql).Tables[0];
        }


        public static DataTable dtObtenerMesesDL(string db)
        {
            string strSql = @" SET LANGUAGE SPANISH;                        
                               SELECT MES FROM PIMENTEL.Fn_APPSA_GET_MESES('N') ORDER BY IDMES ASC;
                            ";

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql).Tables[0];
        }


        public static DataTable dtObtenerAnnosDL(string db)
        {
            //string strSql = @"SELECT DISTINCT ANNO FROM PIMENTEL.APSSA_BALANCE_COMPROBACION  WITH (NOLOCK) ORDER BY ANNO DESC;";
            string strSql = @"SELECT DISTINCT YEAR(FECHA_FINAL) AS ANNO FROM PIMENTEL.PERIODO_CONTABLE 
                              WITH (NOLOCK) ORDER BY YEAR(FECHA_FINAL) DESC  ;";

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql).Tables[0];
        }


        public static DataTable dtObtieneBalanceComprobacionExactusDL(string file_sql, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_BAL_COMP_RECUPERAR";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TEMPORAL_SQL", file_sql);
                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    ds.Tables.Add(table);
                    cmd.Connection.Close();  //// ADD MXMX
                }
                return ds.Tables[0];
            }
        }


        public static DataTable dtObtieneBalanceComprobacionMensualDL(string file_sql, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_BAL_COMP_RECUPERAR";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TEMPORAL_SQL", file_sql);
                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    ds.Tables.Add(table);
                    cmd.Connection.Close();  //// ADD MXMX
                }
                return ds.Tables[0];
            }
        }


        public static DataTable dtObtieneBalanceComprobacionAcumuladoDL(string file_sql, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_BAL_COMP_RECUPERAR";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TEMPORAL_SQL", file_sql);
                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    ds.Tables.Add(table);
                    cmd.Connection.Close();  //// ADD MXMX
                }
                return ds.Tables[0];
            }
        }

        public static DataTable dtObtieneBalanceComprobacionResumenDL(string file_sql, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_BAL_COMP_RECUPERAR";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TEMPORAL_SQL", file_sql);
                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    ds.Tables.Add(table);
                    cmd.Connection.Close();  //// ADD MXMX
                }
                return ds.Tables[0];
            }
        }

        /*

        ALTER PROCEDURE [PIMENTEL].[SP_APSSA_BAL_COMP_V3]
        (@ANNO  INT,							--	AÑO PROCESO
         @MES   VARCHAR(50),					--  MES PROCESO
         @ANNO_HISTORICO   VARCHAR(250),		--	AÑOS HISTORICO
         @MES_HISTORICO   VARCHAR(250),			--  MESES HISTORICO
         @FECHA_INICIO DATETIME,				--  RANGO FECHA INICIO
         @FECHA_FINAL DATETIME,					--  RANGO FECHA FINAL
         @ACUMULA  VARCHAR(2),					--  'SI'   'NO'
         @TMP_SQL_EXAC  VARCHAR(250),
         @TMP_SQL_MENS  VARCHAR(250),
         @TMP_SQL_ACUM  VARCHAR(250),
         @TMP_SQL_RES_GEN  VARCHAR(250),
         @TMP_SQL_RES_TIE  VARCHAR(250) )
         
        */


        public static DataSet dsObtenerTablasBalanceComprobacionV3DL(Int32 ano_proc, string mes_proc, string ano_hist, string mes_hist,
                                                                     DateTime fecha1, DateTime fecha2, string acum, string fil1, string fil2, string fil3,
                                                                     string fil4, string fil5, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_BAL_COMP_V3";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ANNO", ano_proc);
                    cmd.Parameters.AddWithValue("@MES", mes_proc);
                    cmd.Parameters.AddWithValue("@ANNO_HISTORICO", ano_hist);
                    cmd.Parameters.AddWithValue("@MES_HISTORICO", mes_hist);
                    cmd.Parameters.AddWithValue("@FECHA_INICIO", fecha1);
                    cmd.Parameters.AddWithValue("@FECHA_FINAL", fecha2);
                    cmd.Parameters.AddWithValue("@ACUMULA", acum);
                    cmd.Parameters.AddWithValue("@TMP_SQL_EXAC", fil1);
                    cmd.Parameters.AddWithValue("@TMP_SQL_MENS", fil2);
                    cmd.Parameters.AddWithValue("@TMP_SQL_ACUM", fil3);
                    cmd.Parameters.AddWithValue("@TMP_SQL_RES_GEN", fil4);
                    cmd.Parameters.AddWithValue("@TMP_SQL_RES_TIE", fil5);
                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();

                    DataTable table1 = new DataTable();
                    table1.Load(cmd.ExecuteReader());
                    ds.Tables.Add(table1);
                    cmd.Connection.Close();  //// ADD MXMX
                }
                return ds;
            }
        }

        //ALTER PROCEDURE [PIMENTEL].[SP_APSSA_BAL_COMP_V2]
        //(@FECHA_INICIO DATETIME,
        // @FECHA_FINAL DATETIME,
        // @ACUMULA  VARCHAR(2),
        // @TMP_SQL_EXAC  VARCHAR(250),
        // @TMP_SQL_MENS  VARCHAR(250),
        // @TMP_SQL_ACUM  VARCHAR(250),
        // @TMP_SQL_RES_GEN  VARCHAR(250),
        // @TMP_SQL_RES_TIE  VARCHAR(250) )


        public static DataSet dsObtenerTablasBalanceComprobacionDL(DateTime fecha1, DateTime fecha2, string acum, string fil1, string fil2, string fil3, string fil4, string fil5, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_BAL_COMP_V2";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FECHA_INICIO", fecha1);
                    cmd.Parameters.AddWithValue("@FECHA_FINAL", fecha2);
                    cmd.Parameters.AddWithValue("@ACUMULA", acum);
                    cmd.Parameters.AddWithValue("@TMP_SQL_EXAC", fil1);
                    cmd.Parameters.AddWithValue("@TMP_SQL_MENS", fil2);
                    cmd.Parameters.AddWithValue("@TMP_SQL_ACUM", fil3);
                    cmd.Parameters.AddWithValue("@TMP_SQL_RES_GEN", fil4);
                    cmd.Parameters.AddWithValue("@TMP_SQL_RES_TIE", fil5);
                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();
                    //DataTable table = new DataTable();
                    //table.Load(cmd.ExecuteReader());
                    //ds.Tables.Add(table);                  

                    DataTable table1 = new DataTable();
                    table1.Load(cmd.ExecuteReader());
                    ds.Tables.Add(table1);
                    cmd.Connection.Close();  //// ADD MXMX
                }
                return ds;
            }
        }


        public static void EliminarCuentaRubroDL(string cta, string tipgas, string db)
        {
            string strSql = @" DELETE FROM PIMENTEL.APSSA_BALANCE_CONCEPTOS                             
                               WHERE CUENTA_CONTABLE=@CUENTA_CONTABLE AND TIPO_GASTO=@TIPO_GASTO;  ";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@CUENTA_CONTABLE", cta));
            arParams.Add(new SqlParameter("@TIPO_GASTO", tipgas));

            SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParams.ToArray());
        }

        public static void UpdateCuentaRubroDL(string cta, string tipgas, string rub, string eri, string db)
        {
            string strSql = @"UPDATE PIMENTEL.APSSA_BALANCE_CONCEPTOS
                              SET
                              RUBRO=@RUBRO, 
                              RUBROS_ERI=@RUBROS_ERI
                              WHERE CUENTA_CONTABLE=@CUENTA_CONTABLE AND TIPO_GASTO=@TIPO_GASTO;  
                              ";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@CUENTA_CONTABLE", cta));
            arParams.Add(new SqlParameter("@TIPO_GASTO", tipgas));

            SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParams.ToArray());
        }

        public static void InsertarCuentaRubroDL(string cta, string tipgas, string rub, string eri, string db)
        {
            string strSql = @"INSERT INTO PIMENTEL.APSSA_BALANCE_CONCEPTOS
	                            (CUENTA_CONTABLE, TIPO_GASTO, RUBRO, RUBROS_ERI)
	                            VALUES (@CUENTA_CONTABLE, @TIPO_GASTO, @RUBRO, @RUBROS_ERI);";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@CUENTA_CONTABLE", cta));
            arParams.Add(new SqlParameter("@TIPO_GASTO", tipgas));
            arParams.Add(new SqlParameter("@RUBRO", rub));
            arParams.Add(new SqlParameter("@RUBROS_ERI", eri));

            SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParams.ToArray());
        }


        public static bool ExisteCuentaContableDL(string cta, string db)
        {
            int NumReg = 0;
            string strSql = @"SELECT COUNT(*) 
                              FROM PIMENTEL.CUENTA_CONTABLE WITH (NOLOCK)
                              WHERE CUENTA_CONTABLE = @CUENTA_CONTABLE";

            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@CUENTA_CONTABLE", cta));

            NumReg = Convert.ToInt32(SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray()));
            return NumReg > 0;
        }

        public static DataTable dtCargaDatosCuentaContableDL(string cta, string db)
        {
            string strSql = @"SELECT CUENTA_CONTABLE, DESCRIPCION, TIPO, TIPO_DETALLADO, ACEPTA_DATOS,USA_CENTRO_COSTO
                              FROM PIMENTEL.CUENTA_CONTABLE WITH (NOLOCK)
                              WHERE CUENTA_CONTABLE=@CUENTA_CONTABLE; ";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@CUENTA_CONTABLE", cta));

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParams.ToArray()).Tables[0];
        }

        public static DataTable dtCuentaContableDL(string cdb)
        {
            string strSql = @" SELECT                             
                               CUENTA_CONTABLE, DESCRIPCION, TIPO, TIPO_DETALLADO, ACEPTA_DATOS,USA_CENTRO_COSTO
                               FROM PIMENTEL.CUENTA_CONTABLE WITH (NOLOCK)
                               ORDER BY 1;
                            ";

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(cdb), CommandType.StoredProcedure, strSql).Tables[0];
        }



        public static DataTable dtDirectorioDL(string cdb,string _USER)

        {

            
            string strSql = @" SELECT * FROM EMPLEADO WHERE USUARIO='"+ _USER+"'";

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(cdb), CommandType.Text, strSql).Tables[0];
        }

        public static DataTable dtObtenerRubroDL(string db)
        {
            string strSql = @" SELECT                             
                               CON.CUENTA_CONTABLE, CTA.DESCRIPCION, CON.TIPO_GASTO, CON.RUBRO, CON.RUBROS_ERI
                               FROM PIMENTEL.APSSA_BALANCE_CONCEPTOS CON WITH (NOLOCK)
                               INNER JOIN PIMENTEL.CUENTA_CONTABLE CTA  WITH (NOLOCK) ON CON.CUENTA_CONTABLE=CTA.CUENTA_CONTABLE
                               ORDER BY 1;
                            ";

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql).Tables[0];
        }


        public static DataTable dtObtenerBalanceComprobacionDL(DateTime fecha1, DateTime fecha2, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                //string sqlCommand = "PIMENTEL.SP_APSSA_BALANCE_COMPROBACION";
                string sqlCommand = "PIMENTEL.SP_APSSA_BAL_COMP_FORMATO";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FECHA_INICIO", fecha1);
                    cmd.Parameters.AddWithValue("@FECHA_FINAL", fecha2);
                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    ds.Tables.Add(table);
                    cmd.Connection.Close();  //// ADD MXMX
                }
                return ds.Tables[0];
            }
        }

        public static DataTable dtObtenerBalanceComprobacionSinFormatoDL(DateTime fecha1, DateTime fecha2, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                //string sqlCommand = "PIMENTEL.SP_APSSA_BALANCE_COMPROBACION1";
                string sqlCommand = "PIMENTEL.SP_APSSA_BAL_COMP";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FECHA_INICIO", fecha1);
                    cmd.Parameters.AddWithValue("@FECHA_FINAL", fecha2);
                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    ds.Tables.Add(table);
                    cmd.Connection.Close();  //// ADD MXMX
                }
                return ds.Tables[0];
            }
        }

        public static DataTable dtObtenerBalanceComprobacionHistoricoDL(DateTime fecha1, DateTime fecha2, string acum, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                //string sqlCommand = "PIMENTEL.SP_APSSA_BALANCE_COMPROBACION_HISTORICO";
                string sqlCommand = "PIMENTEL.SP_APSSA_BAL_COMP_HIST_FORMATO";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FECHA_INICIO", fecha1);
                    cmd.Parameters.AddWithValue("@FECHA_FINAL", fecha2);
                    cmd.Parameters.AddWithValue("@ACUMULA", acum);
                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    ds.Tables.Add(table);
                    cmd.Connection.Close();  //// ADD MXMX
                }
                return ds.Tables[0];
            }
        }


        public static DataSet ObtenerFacturasTituloGratuitoDL(DateTime fecha1, DateTime fecha2, string bode, string ajus, string fami, string subf, string grup, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_LISTAR_TITULO_GRATUITO";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FECHA_INI", fecha1);
                    cmd.Parameters.AddWithValue("@FECHA_FIN", fecha2);
                    cmd.Parameters.AddWithValue("@BODEGA", bode);
                    cmd.Parameters.AddWithValue("@AJUSTE", ajus);
                    cmd.Parameters.AddWithValue("@FAMILIA", fami);
                    cmd.Parameters.AddWithValue("@SUBFAMILIA", subf);
                    cmd.Parameters.AddWithValue("@GRUPO", grup);
                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    ds.Tables.Add(table);
                    cmd.Connection.Close();  //// ADD MXMX
                }
                return ds;
            }
        }


        public static DataSet ObtenerEntradaSalidaAlmacen(DateTime fecha1, DateTime fecha2, string bode, string ajus, string fami, string subf, string grup,int valor, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_ING_SAL_ALMACEN_A";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FECHA_INI", fecha1);
                    cmd.Parameters.AddWithValue("@FECHA_FIN", fecha2);
                    cmd.Parameters.AddWithValue("@BODEGA", bode);
                    cmd.Parameters.AddWithValue("@AJUSTE", ajus);
                    cmd.Parameters.AddWithValue("@FAMILIA", fami);
                    cmd.Parameters.AddWithValue("@SUBFAMILIA", subf);
                    cmd.Parameters.AddWithValue("@GRUPO", grup);
                    cmd.Parameters.AddWithValue("@TIPO", valor);
                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    ds.Tables.Add(table);
                    cmd.Connection.Close();  //// ADD MXMX
                }
                return ds;
            }
        }

        public static DataTable Listar_Documentos_pago_txt(DateTime fecha_ini, DateTime fecha_fin, string tipo_documento, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_DOCUMENTO_PAGO_TXT";
            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@FECHA_INI", fecha_ini));
            arParams.Add(new SqlParameter("@FECHA_FIN", fecha_fin));
            arParams.Add(new SqlParameter("@TIPO_DOCUMENTO", tipo_documento));
            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray()).Tables[0];

        }
        public static DataSet ListaEmbarques(DateTime dFecha1, DateTime dFecha2, string estados, string bodegas, string db)
        {
            // CON PARAMETRO
            DataSet ds_embarque = new DataSet();
            string strSql = "PIMENTEL.SP_APSSA_EMBARQUES_SIN_FACTURA";
            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@FECHA_INI", dFecha1));
            arParams.Add(new SqlParameter("@FECHA_FIN", dFecha2));
            arParams.Add(new SqlParameter("@ESTADOS", estados));
            arParams.Add(new SqlParameter("@BODEGA", bodegas));
            ds_embarque = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray());
            ds_embarque.Tables[0].TableName = "embarque";
            return ds_embarque;
        }

        public static DataTable ListarDocumentosCP(DateTime fechaini_doc, DateTime fechafin_doc, string db)
        {
            DataTable dt_dcp = new DataTable();
            string str_sp = "PIMENTEL.SP_APSSA_DOCUMENTOS_CP_CREDITOS";
            List<SqlParameter> lst = new List<SqlParameter>();
            lst.Add(new SqlParameter("@fechaini_docu", fechaini_doc));
            lst.Add(new SqlParameter("@fechafin_docu", fechafin_doc));
            dt_dcp = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, str_sp, lst.ToArray()).Tables[0];
            return dt_dcp;
        }

        public static DataSet CargaListaVacia(string db)
        {
            // SIN PARAMETRO
            DataSet ds_listavacia = new DataSet();
            string strSql = "SELECT TOP 0 * FROM APSSA.CTAS_CONTABLE";
            ds_listavacia = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql);
            ds_listavacia.Tables[0].TableName = "listavacia";
            return ds_listavacia;
        }

        public static DataSet Listar_Diario_Exactus(string db)
        {
            try
            {
                DataSet ds_listadiario = new DataSet();

                string strSql = @"
                                    SELECT 
                                    A.TIPO_ASIENTO,A.ORIGEN,A.FECHA,  
                                    D.ASIENTO,D.CONSECUTIVO,D.NIT,D.CENTRO_COSTO,D.CUENTA_CONTABLE,D.FUENTE,
                                    D.DEBITO_LOCAL,D.CREDITO_LOCAL,D.DEBITO_DOLAR,D.CREDITO_DOLAR, 
                                    D.REFERENCIA,D.TIPO_CAMBIO,D.BASE_LOCAL,D.BASE_DOLAR,D.PROYECTO,D.FASE,
                                    D.DEBITO_UNIDADES,D.CREDITO_UNIDADES 
                                    FROM PIMENTEL.DIARIO D
                                    INNER JOIN PIMENTEL.ASIENTO_DE_DIARIO A  ON A.ASIENTO = D.ASIENTO
                                    WHERE LEFT(D.ASIENTO,2)='CP' AND DAY(FECHA)=24;
                                ";
                //WHERE LEFT(ASIENTO,2) IN ('CN','RH')  OR LEFT(ASIENTO,3) IN ('CCP') ";

                ds_listadiario = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql);

                ds_listadiario.Tables[0].TableName = "listadiario";
                return ds_listadiario;
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
                DataSet ds_listamayor = new DataSet();

                string strSql = @" SELECT     
                                 ASIENTO,CONSECUTIVO,NIT,CENTRO_COSTO,CUENTA_CONTABLE,FECHA,TIPO_ASIENTO, 
                                 FUENTE,REFERENCIA,ORIGEN,DEBITO_LOCAL,CREDITO_LOCAL,DEBITO_DOLAR,CREDITO_DOLAR,
                                 CONTABILIDAD,CLASE_ASIENTO,ESTADO_CONS_FISC,ASNT_CONS_FISC,ESTADO_CONS_CORP,ASNT_CONS_CORP, 
                                 DEBITO_UNIDADES,CREDITO_UNIDADES,TIPO_CAMBIO,BASE_LOCAL,BASE_DOLAR,PROYECTO,FASE 
                                 FROM PIMENTEL.MAYOR  ";
                //WHERE ORIGEN IN ('CN','RH','CCP') ";

                ds_listamayor = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql);

                ds_listamayor.Tables[0].TableName = "listamayor";
                return ds_listamayor;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public static void ActualEquivCuentaNava(string ctaExactus, string ctaNava, string db)
        {
            string strSql = @"
                             UPDATE APSSA.CTAS_CONTABLE
                             SET CTA_NAVASOFT = LTRIM(RTRIM(@CTA_NAVASOFT))
                             WHERE CUENTA_CONTABLE= @CUENTA_CONTABLE;
                            ";

            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@CUENTA_CONTABLE", ctaExactus));
            arParam.Add(new SqlParameter("@CTA_NAVASOFT", ctaNava));

            SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray());

        }

        public static void Actualiza_Arqueo_Caja(decimal sil, decimal sfl, decimal srl, decimal sid, decimal sfd, decimal srd, string caja, string usuario, int num_aper, string db)
        {
            string strSql = @"update pimentel.apertura_caja set 
            				SALDO_INICIAL_LOC=@SIL,SALDO_FINAL_LOC=@SFL,
            				SALDO_RECIBO_LOC=@SRL,
            				SALDO_INICIAL_DOL=@SID,
            				SALDO_FINAL_DOL=@SFD,
            				SALDO_RECIBO_DOL=@SRD
							where caja=@CAJA 
							and usuario=@USUARIO 
							and NUM_APERTURA=@NUM_APER";

            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@SIL", sil));
            arParam.Add(new SqlParameter("@SFL", sfl));
            arParam.Add(new SqlParameter("@SRL", srl));
            arParam.Add(new SqlParameter("@SID", sid));
            arParam.Add(new SqlParameter("@SFD", sfd));
            arParam.Add(new SqlParameter("@SRD", srd));
            arParam.Add(new SqlParameter("@CAJA", caja));
            arParam.Add(new SqlParameter("@USUARIO", usuario));
            arParam.Add(new SqlParameter("@NUM_APER", num_aper));

            SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray());

        }



        public static void Actualiza_Fecha_Limite(Int32 sil, Int32 sfl, DateTime srl,  string db)
        {
            string strSql = @"update PIMENTEL.TMP_APSSA_COMPRA_VENTA_GY_FECHA set 
            				FECHA=@FECHA 
            				where MES=@MES
							and ANNO=@ANNO";

            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@MES", sil));
            arParam.Add(new SqlParameter("@ANNO", sfl));
            arParam.Add(new SqlParameter("@FECHA", srl));
            

            SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray());

        }



        public static void Actualiza_Usuario(string correo,string fijo,string celular,string anexo, string usuario,string db)
        {
            string strSql = @"update dbo.empleado set 
            				correo=@correo,
                            fijo=@fijo,
                            celular=@celular,
                            anexo=@anexo    
							where empleado=@usuario" ;

            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@correo", correo.ToUpper ()));
            arParam.Add(new SqlParameter("@fijo", fijo));
            arParam.Add(new SqlParameter("@celular",celular));
            arParam.Add(new SqlParameter("@anexo", anexo));
            arParam.Add(new SqlParameter("@usuario", usuario));


            SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray());

        }





        public static Ctas_contable ActualizarEquivCuenta(Ctas_contable ctacontable, string db)    // sin usar
        {
            string strSql = @"
                             UPDATE APSSA.CTAS_CONTABLE
                             SET CTA_NAVASOFT = LTRIM(RTRIM(@CTA_NAVASOFT))
                             WHERE CUENTA_CONTABLE= @CUENTA_CONTABLE;
                            ";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@CUENTA_CONTABLE", ctacontable.CUENTA_CONTABLE));
            arParams.Add(new SqlParameter("@CTA_NAVASOFT", ctacontable.CTA_NAVASOFT));

            SqlHelper.ExecuteNonQuery(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParams.ToArray());
            return ctacontable;

        }

        public static DataSet Cgm0102Vacia(string db)
        {
            DataSet ds_cgmvacia = new DataSet();
            string strSql = "SELECT TOP 0 * FROM APSSA.TEMP_cgm01022014";
            ds_cgmvacia = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql);
            ds_cgmvacia.Tables[0].TableName = "cgmvacia";
            return ds_cgmvacia;
        }

        public static string CContable_Exactus2Navasoft(string cCUENTA_CONTABLE, string db)
        {
            string cCuenta = null;
            string strSql = @"SELECT CTA_NAVASOFT 
                              FROM APSSA.CTAS_CONTABLE
                              WHERE CUENTA_CONTABLE= @CUENTA_CONTABLE;
                             ";

            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@CUENTA_CONTABLE", cCUENTA_CONTABLE));

            cCuenta = Convert.ToString(SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray()));
            return cCuenta;
        }

        public static string CCosto_Exactus2Navasoft(string cCENTRO_COSTO, string db)
        {
            string cCentro = null;
            string strSql = @"SELECT CTA_NAVASOFT 
                              FROM APSSA.dbo.CTRO_COSTO
                              WHERE CENTRO_COSTO= @CENTRO_COSTO;
                             ";

            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@CENTRO_COSTO", cCENTRO_COSTO));

            cCentro = Convert.ToString(SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray()));
            return cCentro;
        }


        public static DataTable Obtener_Detalle_Caja(string cCAJA, int cMES, int cANNO, string db)
        {
            //DataSet ds_dc_dl = new DataSet();

            string strSql = @"SELECT NUM_APERTURA AS INDICE,LTRIM(RTRIM(CAJA)) AS CAJA,USUARIO,FCH_HORA_APERTURA AS FECHA_APERTURA,FCH_HORA_CIERRE AS FECHA_CIERRE,ESTADO,
							SALDO_INICIAL_LOC,SALDO_INICIAL_DOL,SALDO_RECIBO_LOC,SALDO_RECIBO_DOL,SALDO_FINAL_LOC,SALDO_FINAL_DOL
							FROM PIMENTEL.APERTURA_CAJA WHERE CAJA='" + cCAJA + "' AND ESTADO='C' AND MONTH(FCH_HORA_APERTURA)=" + cMES.ToString() + " AND YEAR(FCH_HORA_APERTURA)=" + cANNO.ToString() + " ORDER BY NUM_APERTURA ASC;";


            //ds_dc_dl = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql);
            //ds_dc_dl.Tables[0].TableName = "dc";
            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql).Tables[0];
        }



        public static DataTable Obtener_CVGY(string db)
        {
            //DataSet ds_dc_dl = new DataSet();

            string strSql = @"SELECT * FROM PIMENTEL.TMP_APSSA_COMPRA_VENTA_GY_FECHA ORDER BY FECHA DESC";

            
            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql).Tables[0];
        }





        // graba asiento temporal
        public static DiarioNavasoftBE AgregarFilaNavasoft(DiarioNavasoftBE diarionavasoft, string db)
        {

            string strSql = @"
                              SET LANGUAGE Spanish;  
                              INSERT INTO APSSA.TEMP_cgm01022014 
                                   (ano_as,mes_as,dia_as,compro,origen,cuenta,ccosto,coddoc,nrodoc,docref,nroref,
                                    fvenci,idrefe,nomref,rucref,glosa,tmovim,debe,haber,debed,haberd,gcosto,
                                    amarre,ctaref,ctapte,moneda,destin,estado,tipcam,codpos,inaigv,flucaj,montus,
                                    fechao,codscc,idcompro,codsub,codsun,fpago,obser,detfec,detnro,detimp,dettas,
                                    codpro,ctaact,crefe,nrefe,frefe,codi,nplan) 
                                    VALUES 
                                   (@ano_as,@mes_as,@dia_as,@compro,@origen,@cuenta,@ccosto,@coddoc,@nrodoc,@docref,@nroref,
                                    @fvenci,@idrefe,@nomref,@rucref,@glosa,@tmovim,@debe,@haber,@debed,@haberd,@gcosto,
                                    @amarre,@ctaref,@ctapte,@moneda,@destin,@estado,@tipcam,@codpos,@inaigv,@flucaj,@montus,
                                    @fechao,@codscc,@idcompro,@codsub,@codsun,@fpago,@obser,@detfec,@detnro,@detimp,@dettas,
                                    @codpro,@ctaact,@crefe,@nrefe,@frefe,@codi,@nplan);";
            //            string strSql = @"
            //                              SET LANGUAGE Spanish;  
            //                              INSERT INTO TEMP_cgm01022014 
            //                                   (ano_as,mes_as,dia_as,compro,origen,cuenta,ccosto,coddoc,nrodoc,docref,nroref,
            //                                    fvenci,idrefe,nomref,rucref,glosa,tmovim,debe,haber,debed,haberd,gcosto,
            //                                    amarre,ctaref,ctapte,moneda,destin,estado,tipcam,codpos,inaigv,flucaj,montus,
            //                                    codscc,idcompro,codsub,codsun,obser,detnro,detimp,dettas,
            //                                    codpro,ctaact,crefe,nrefe,codi,nplan) 
            //                                    VALUES 
            //                                   (@ano_as,@mes_as,@dia_as,@compro,@origen,@cuenta,@ccosto,@coddoc,@nrodoc,@docref,@nroref,
            //                                    @fvenci,@idrefe,@nomref,@rucref,@glosa,@tmovim,@debe,@haber,@debed,@haberd,@gcosto,
            //                                    @amarre,@ctaref,@ctapte,@moneda,@destin,@estado,@tipcam,@codpos,@inaigv,@flucaj,@montus,
            //                                    @codscc,@idcompro,@codsub,@codsun,@obser,@detnro,@detimp,@dettas,
            //                                    @codpro,@ctaact,@crefe,@nrefe,@codi,@nplan);";


            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@ano_as", diarionavasoft.ano_as));
            arParams.Add(new SqlParameter("@mes_as", diarionavasoft.mes_as));
            arParams.Add(new SqlParameter("@dia_as", diarionavasoft.dia_as));
            arParams.Add(new SqlParameter("@compro", diarionavasoft.compro));
            arParams.Add(new SqlParameter("@origen", diarionavasoft.origen));
            arParams.Add(new SqlParameter("@cuenta", diarionavasoft.cuenta));
            arParams.Add(new SqlParameter("@ccosto", diarionavasoft.ccosto));
            arParams.Add(new SqlParameter("@coddoc", diarionavasoft.coddoc));
            arParams.Add(new SqlParameter("@nrodoc", diarionavasoft.nrodoc));
            arParams.Add(new SqlParameter("@docref", diarionavasoft.docref));
            arParams.Add(new SqlParameter("@nroref", diarionavasoft.nroref));
            arParams.Add(new SqlParameter("@fvenci", diarionavasoft.fvenci));
            arParams.Add(new SqlParameter("@idrefe", diarionavasoft.idrefe));
            arParams.Add(new SqlParameter("@nomref", diarionavasoft.nomref));
            arParams.Add(new SqlParameter("@rucref", diarionavasoft.rucref));
            arParams.Add(new SqlParameter("@glosa", diarionavasoft.glosa));
            arParams.Add(new SqlParameter("@tmovim", diarionavasoft.tmovim));
            arParams.Add(new SqlParameter("@debe", diarionavasoft.debe));
            arParams.Add(new SqlParameter("@haber", diarionavasoft.haber));
            arParams.Add(new SqlParameter("@debed", diarionavasoft.debed));
            arParams.Add(new SqlParameter("@haberd", diarionavasoft.haberd));
            arParams.Add(new SqlParameter("@gcosto", diarionavasoft.gcosto));
            arParams.Add(new SqlParameter("@amarre", diarionavasoft.amarre));
            arParams.Add(new SqlParameter("@ctaref", diarionavasoft.ctaref));
            arParams.Add(new SqlParameter("@ctapte", diarionavasoft.ctapte));
            arParams.Add(new SqlParameter("@moneda", diarionavasoft.moneda));
            arParams.Add(new SqlParameter("@destin", diarionavasoft.destin));
            arParams.Add(new SqlParameter("@estado", diarionavasoft.estado));
            arParams.Add(new SqlParameter("@tipcam", diarionavasoft.tipcam));
            arParams.Add(new SqlParameter("@codpos", diarionavasoft.codpos));
            arParams.Add(new SqlParameter("@inaigv", diarionavasoft.inaigv));
            arParams.Add(new SqlParameter("@flucaj", diarionavasoft.flucaj));
            arParams.Add(new SqlParameter("@montus", diarionavasoft.montus));
            arParams.Add(new SqlParameter("@fechao", diarionavasoft.fechao));
            arParams.Add(new SqlParameter("@codscc", diarionavasoft.codscc));
            arParams.Add(new SqlParameter("@idcompro", diarionavasoft.idcompro));
            arParams.Add(new SqlParameter("@codsub", diarionavasoft.codsub));
            arParams.Add(new SqlParameter("@codsun", diarionavasoft.codsun));
            arParams.Add(new SqlParameter("@fpago", diarionavasoft.fpago));
            arParams.Add(new SqlParameter("@obser", diarionavasoft.obser));
            arParams.Add(new SqlParameter("@detfec", diarionavasoft.detfec));
            arParams.Add(new SqlParameter("@detnro", diarionavasoft.detnro));
            arParams.Add(new SqlParameter("@detimp", diarionavasoft.detimp));
            arParams.Add(new SqlParameter("@dettas", diarionavasoft.dettas));
            arParams.Add(new SqlParameter("@codpro", diarionavasoft.codpro));
            arParams.Add(new SqlParameter("@ctaact", diarionavasoft.ctaact));
            arParams.Add(new SqlParameter("@crefe", diarionavasoft.crefe));
            arParams.Add(new SqlParameter("@nrefe", diarionavasoft.nrefe));
            arParams.Add(new SqlParameter("@frefe", diarionavasoft.frefe));
            arParams.Add(new SqlParameter("@codi", diarionavasoft.codi));
            arParams.Add(new SqlParameter("@nplan", diarionavasoft.nplan));

            SqlHelper.ExecuteNonQuery(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParams.ToArray());
            return diarionavasoft;

        }

        public static DataSet MostrarAsientoTemporal(string db)
        {
            try
            {
                DataSet ds_listaasiento = new DataSet();

                string strSql = @"
                                    SELECT * FROM APSSA.TEMP_cgm01022014 
                                ";

                ds_listaasiento = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql);

                ds_listaasiento.Tables[0].TableName = "listaasiento";
                return ds_listaasiento;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        // graba asiento en bdNava01
        public static DiarioNavasoftBE GrabaAsientoNavasoft(DiarioNavasoftBE asientonavasoft, string db)
        {

            string strSql = @"INSERT INTO bdNava01.CGM01022014 
                                               (ano_as,mes_as,dia_as,compro,origen,cuenta,ccosto,coddoc,nrodoc,docref,nroref,
                                                fvenci,idrefe,nomref,rucref,glosa,tmovim,debe,haber,debed,haberd,gcosto,
                                                amarre,ctaref,ctapte,moneda,destin,estado,tipcam,codpos,inaigv,flucaj,montus,
                                                fechao,codscc,idcompro,codsub,codsun,fpago,obser,detfec,detnro,detimp,dettas,
                                                codpro,ctaact,crefe,nrefe,frefe,codi,nplan) 
                                                VALUES 
                                               (@ano_as,@mes_as,@dia_as,@compro,@origen,@cuenta,@ccosto,@coddoc,@nrodoc,@docref,@nroref,
                                                @fvenci,@idrefe,@nomref,@rucref,@glosa,@tmovim,@debe,@haber,@debed,@haberd,@gcosto,
                                                @amarre,@ctaref,@ctapte,@moneda,@destin,@estado,@tipcam,@codpos,@inaigv,@flucaj,@montus,
                                                @fechao,@codscc,@idcompro,@codsub,@codsun,@fpago,@obser,@detfec,@detnro,@detimp,@dettas,
                                                @codpro,@ctaact,@crefe,@nrefe,@frefe,@codi,@nplan)";



            //                        string strSql = @"
            //                                          SET LANGUAGE Spanish;  
            //                                          INSERT INTO CGM01022014  
            //                                               (ano_as,mes_as,dia_as,compro,origen,cuenta,ccosto,coddoc,nrodoc,docref,nroref,
            //                                                fvenci,idrefe,nomref,rucref,glosa,tmovim,debe,haber,debed,haberd,gcosto,
            //                                                amarre,ctaref,ctapte,moneda,destin,estado,tipcam,codpos,inaigv,flucaj,montus,
            //                                                codscc,idcompro,codsub,codsun,obser,detnro,detimp,dettas,
            //                                                codpro,ctaact,crefe,nrefe,codi,nplan) 
            //                                                VALUES 
            //                                               (@ano_as,@mes_as,@dia_as,@compro,@origen,@cuenta,@ccosto,@coddoc,@nrodoc,@docref,@nroref,
            //                                                @fvenci,@idrefe,@nomref,@rucref,@glosa,@tmovim,@debe,@haber,@debed,@haberd,@gcosto,
            //                                                @amarre,@ctaref,@ctapte,@moneda,@destin,@estado,@tipcam,@codpos,@inaigv,@flucaj,@montus,
            //                                                @codscc,@idcompro,@codsub,@codsun,@obser,@detnro,@detimp,@dettas,
            //                                                @codpro,@ctaact,@crefe,@nrefe,@codi,@nplan);";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@ano_as", asientonavasoft.ano_as));
            arParams.Add(new SqlParameter("@mes_as", asientonavasoft.mes_as));
            arParams.Add(new SqlParameter("@dia_as", asientonavasoft.dia_as));
            arParams.Add(new SqlParameter("@compro", asientonavasoft.compro));
            arParams.Add(new SqlParameter("@origen", asientonavasoft.origen));
            arParams.Add(new SqlParameter("@cuenta", asientonavasoft.cuenta));
            arParams.Add(new SqlParameter("@ccosto", asientonavasoft.ccosto));
            arParams.Add(new SqlParameter("@coddoc", asientonavasoft.coddoc));
            arParams.Add(new SqlParameter("@nrodoc", asientonavasoft.nrodoc));
            arParams.Add(new SqlParameter("@docref", asientonavasoft.docref));
            arParams.Add(new SqlParameter("@nroref", asientonavasoft.nroref));
            arParams.Add(new SqlParameter("@fvenci", asientonavasoft.fvenci));
            arParams.Add(new SqlParameter("@idrefe", asientonavasoft.idrefe));
            arParams.Add(new SqlParameter("@nomref", asientonavasoft.nomref));
            arParams.Add(new SqlParameter("@rucref", asientonavasoft.rucref));
            arParams.Add(new SqlParameter("@glosa", asientonavasoft.glosa));
            arParams.Add(new SqlParameter("@tmovim", asientonavasoft.tmovim));
            arParams.Add(new SqlParameter("@debe", asientonavasoft.debe));
            arParams.Add(new SqlParameter("@haber", asientonavasoft.haber));
            arParams.Add(new SqlParameter("@debed", asientonavasoft.debed));
            arParams.Add(new SqlParameter("@haberd", asientonavasoft.haberd));
            arParams.Add(new SqlParameter("@gcosto", asientonavasoft.gcosto));
            arParams.Add(new SqlParameter("@amarre", asientonavasoft.amarre));
            arParams.Add(new SqlParameter("@ctaref", asientonavasoft.ctaref));
            arParams.Add(new SqlParameter("@ctapte", asientonavasoft.ctapte));
            arParams.Add(new SqlParameter("@moneda", asientonavasoft.moneda));
            arParams.Add(new SqlParameter("@destin", asientonavasoft.destin));
            arParams.Add(new SqlParameter("@estado", asientonavasoft.estado));
            arParams.Add(new SqlParameter("@tipcam", asientonavasoft.tipcam));
            arParams.Add(new SqlParameter("@codpos", asientonavasoft.codpos));
            arParams.Add(new SqlParameter("@inaigv", asientonavasoft.inaigv));
            arParams.Add(new SqlParameter("@flucaj", asientonavasoft.flucaj));
            arParams.Add(new SqlParameter("@montus", asientonavasoft.montus));
            arParams.Add(new SqlParameter("@fechao", asientonavasoft.fechao));
            arParams.Add(new SqlParameter("@codscc", asientonavasoft.codscc));
            arParams.Add(new SqlParameter("@idcompro", asientonavasoft.idcompro));
            arParams.Add(new SqlParameter("@codsub", asientonavasoft.codsub));
            arParams.Add(new SqlParameter("@codsun", asientonavasoft.codsun));
            arParams.Add(new SqlParameter("@fpago", asientonavasoft.fpago));
            arParams.Add(new SqlParameter("@obser", asientonavasoft.obser));
            arParams.Add(new SqlParameter("@detfec", asientonavasoft.detfec));
            arParams.Add(new SqlParameter("@detnro", asientonavasoft.detnro));
            arParams.Add(new SqlParameter("@detimp", asientonavasoft.detimp));
            arParams.Add(new SqlParameter("@dettas", asientonavasoft.dettas));
            arParams.Add(new SqlParameter("@codpro", asientonavasoft.codpro));
            arParams.Add(new SqlParameter("@ctaact", asientonavasoft.ctaact));
            arParams.Add(new SqlParameter("@crefe", asientonavasoft.crefe));
            arParams.Add(new SqlParameter("@nrefe", asientonavasoft.nrefe));
            arParams.Add(new SqlParameter("@frefe", asientonavasoft.frefe));
            arParams.Add(new SqlParameter("@codi", asientonavasoft.codi));
            arParams.Add(new SqlParameter("@nplan", asientonavasoft.nplan));

            SqlHelper.ExecuteNonQuery(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParams.ToArray());
            return asientonavasoft;

        }

    }

}



