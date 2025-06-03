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

    public class LogisticaDL
    {

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

        public static string ObtenerUsuarioCompradorDL(string _usuario, string db)
        {
            string strSql = @"  SELECT COMPRADOR 
                                FROM PIMENTEL.USUARIO_COMPRADOR (NOLOCK) WHERE USUARIO = @USUARIO ;
                             ";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@USUARIO", _usuario));

            return Convert.ToString(SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParams.ToArray()));
        }


        public static void TestCargarJSON_DL(string db)
        {
            //string sprocname = "InsertPerfCounterData";
            string paramName = "@json";
            // Sample JSON string 
            //string paramValue = "{\"dateTime\":\"2018-03-19T15:15:40.222Z\",\"dateTimeLocal\":\"2018-03-19T11:15:40.222Z\",\"cpuPctProcessorTime\":\"0\",\"memAvailGbytes\":\"28\"}";
            string paramValue = "{\"dateTime\":\"2018-03-19T15:15:40.222Z\",\"dateTimeLocal\":\"2018-03-19T11:15:40.222Z\",\"cpuPctProcessorTime\":\"0\",\"memAvailGbytes\":\"28\"}";

            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {

                string sqlCommand = "PIMENTEL.SP_APSSA_CARGA_JSON_TEST";
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(sqlCommand, conn))
                {
                    // Set command object as a stored procedure
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Add parameter that will be passed to stored procedure
                    cmd.Parameters.Add(new SqlParameter(paramName, paramValue));

                    cmd.ExecuteReader();
                }
            }
        }


        public static void CargarJSON_DL(string _json, string db)
        {
            //string sprocname = "InsertPerfCounterData";
            string paramName = "@json";
            string paramValue = _json;
            //string paramValue = "{\"OrdenCompra\": [ { \"PROCESAR\": null, \"VALIDACION\": null, \"SHIPTO\": \"331056\", \"NUMERO_PEDIDO\": \"4000125955\", \"FECHA_PEDIDO\": \"2023-05-22T16:28:35.7833423\", \"MONEDA\": \"USD\", \"SUBTOTAL\": 52416.00, \"IMPUESTO\": 9434.88, \"TOTAL\": 61850.88, \"FECHA_ENTREGA\": \"2023-05-22T16:28:35.7833423\", \"RUBRO3\": \"NEG.ESP SET/DENNIS DIAZ/VENTA PUNTUAL\", \"RUBRO5\": \"TRANSPORTES LINEA S.A.\" } ], \"OrdenCompraLinea\": [ { \"PROCESAR\": null, \"VALIDACION\": \"\", \"SHIPTO\": \"331056\", \"NUMERO_PEDIDO\": \"4000125955\", \"FECHA_PEDIDO\": \"2023-05-22T16:28:35.0225467\", \"MONEDA\": \"USD\", \"TOTAL\": 1224.84, \"CODIGO\": \"380049\", \"CANTIDAD\": 100.0, \"PRECIO\": 10.38, \"IGV\": 186.84, \"FECHA_ENTREGA\": \"2023-05-22T16:28:35.0225467\", \"RUBRO3\": \"NEG.ESP SET/DENNIS DIAZ/VENTA PUNTUAL\", \"RUBRO5\": \"TRANSPORTES LINEA S.A.\" }, { \"PROCESAR\": null, \"VALIDACION\": \"\", \"SHIPTO\": \"331056\", \"NUMERO_PEDIDO\": \"4000125955\", \"FECHA_PEDIDO\": \"2023-05-22T16:28:35.0225467\", \"MONEDA\": \"USD\", \"TOTAL\": 2629.04, \"CODIGO\": \"340006\", \"CANTIDAD\": 100.0, \"PRECIO\": 22.28, \"IGV\": 401.04, \"FECHA_ENTREGA\": \"2023-05-22T16:28:35.0225467\", \"RUBRO3\": \"NEG.ESP SET/DENNIS DIAZ/VENTA PUNTUAL\", \"RUBRO5\": \"TRANSPORTES LINEA S.A.\" }, { \"PROCESAR\": null, \"VALIDACION\": \"\", \"SHIPTO\": \"331056\", \"NUMERO_PEDIDO\": \"4000125955\", \"FECHA_PEDIDO\": \"2023-05-22T16:28:35.0225467\", \"MONEDA\": \"USD\", \"TOTAL\": 57997.0, \"CODIGO\": \"121428\", \"CANTIDAD\": 100.0, \"PRECIO\": 491.5, \"IGV\": 8847.0, \"FECHA_ENTREGA\": \"2023-05-22T16:28:35.0225467\", \"RUBRO3\": \"NEG.ESP SET/DENNIS DIAZ/VENTA PUNTUAL\", \"RUBRO5\": \"TRANSPORTES LINEA S.A.\" } ] }" ;

            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {

                string sqlCommand = "PIMENTEL.SP_APSSA_CARGA_JSON";
                conn.Open();

                using (SqlCommand cmd = new SqlCommand(sqlCommand, conn))
                {
                    // Set command object as a stored procedure
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Add parameter that will be passed to stored procedure
                    cmd.Parameters.Add(new SqlParameter(paramName, paramValue));

                    cmd.ExecuteReader();
                }
            }
        }


        /*
        //=================================================================================================

            public static void CargarOrdenesCompraTest2_DL(string _usuario, object _json, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_CARGA_OC_EXACTUS_GY_V2";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@sUSUARIO", SqlDbType.VarChar).Value = _usuario;
                    cmd.Parameters.Add("@jsonOrdenCompra", SqlDbType.NVarChar).Value = _json;
                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();
                    cmd.ExecuteNonQuery();
                    cmd.Connection.Close();
                }
            }
        }


        //ALTER PROCEDURE[PIMENTEL].[SP_APSSA_CARGA_OC_EXACTUS_GY_V2]
        //(@sUSUARIO VARCHAR(20),		--- DEBE SER USUARIO COMPRADOR
        // @jsonOrdenCompra NVARCHAR(MAX) )

        public static DataTable dtCargarOrdenesCompraV2_DL(string _usuario, string _json, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_CARGA_OC_EXACTUS_GY_V2";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@sUSUARIO", _usuario);
                    //cmd.Parameters.AddWithValue("@jsonOrdenCompra", _json);

                    ////cmd.Parameters.Add("@sUSUARIO", SqlDbType.VarChar, 20).Value = _usuario;
                    ////cmd.Parameters.Add("@jsonOrdenCompra", SqlDbType.NVarChar, -1).Value = _json;

                    //cmd.Parameters.Add("@sUSUARIO", SqlDbType.VarChar, 20);
                    //cmd.Parameters["@sUSUARIO"].Value = _usuario;

                    ////cmd.Parameters.Add("@jsonOrdenCompra", SqlDbType.NVarChar, -1);
                    ////cmd.Parameters["@jsonOrdenCompra"].Value = _json;

                    //cmd.Parameters.Add("@jsonOrdenCompra", SqlDbType.VarChar, 4000);
                    //cmd.Parameters["@jsonOrdenCompra"].Value = _json;

                    cmd.Parameters.Add("@sUSUARIO", SqlDbType.VarChar).Value = _usuario;
                    cmd.Parameters.Add("@jsonOrdenCompra", SqlDbType.NVarChar).Value = _json;

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

        public static bool CargarOrdenesCompraTest1_DL(string _usuario, string _json, string db)
        {
            int NumReg = 0;
            string strSql = "PIMENTEL.SP_APSSA_CARGA_OC_EXACTUS_GY_V2";

            List<SqlParameter> arParam = new List<SqlParameter>();
            //arParam.Add(new SqlParameter("@sUSUARIO", _usuario));
            //arParam.Add(new SqlParameter("@jsonOrdenCompra", _json));

            arParam.Add(new SqlParameter("@sUSUARIO", SqlDbType.VarChar, 20, _usuario));
            arParam.Add(new SqlParameter("@jsonOrdenCompra", SqlDbType.NVarChar, -1, _json));

            NumReg = SqlHelper.ExecuteNonQuery(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParam.ToArray());
            return NumReg > 0;

        }



        public static bool CargarOrdenesCompraV2_DL(string _usuario, string _json, string db)
        {
            int NumReg = 0;
            string strSql = "PIMENTEL.SP_APSSA_CARGA_OC_EXACTUS_GY_V2";

            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@sUSUARIO", _usuario));
            arParam.Add(new SqlParameter("@jsonOrdenCompra", _json));

            NumReg = Convert.ToInt32(SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParam.ToArray()));
            return NumReg > 0;
        }


        public static DataTable dtCargarOrdenesCompra_DL(string _shipto, string _numero_pedido, DateTime _fecha_pedido, string _proveedor,
                                                         string _moneda, Decimal _total, string _codigo, Decimal _cantidad, Decimal _precio,
                                                         Decimal _igv, DateTime _fecha_entrega, string _rubro3, string _rubro5, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_CARGA_OC_EXACTUS_GY";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@sSHIPTO", _shipto);
                    cmd.Parameters.AddWithValue("@sNUMERO_PEDIDO", _numero_pedido);
                    cmd.Parameters.AddWithValue("@dFECHA_PEDIDO", _fecha_pedido);
                    cmd.Parameters.AddWithValue("@sMONEDA", _moneda);
                    cmd.Parameters.AddWithValue("@nTOTAL", _total);
                    cmd.Parameters.AddWithValue("@sCODIGO", _codigo);
                    cmd.Parameters.AddWithValue("@nCANTIDAD", _cantidad);
                    cmd.Parameters.AddWithValue("@nPRECIO", _precio);
                    cmd.Parameters.AddWithValue("@nIGV", _igv);
                    cmd.Parameters.AddWithValue("@dFECHA_ENTREGA", _fecha_entrega);
                    cmd.Parameters.AddWithValue("@sRUBRO3", _rubro3);
                    cmd.Parameters.AddWithValue("@sRUBRO5", _rubro5);
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
        //=================================================================================================
        */



        //-------------------------------------------------------------------------------------------------

        //ALTER PROCEDURE[PIMENTEL].[SP_APSSA_CARGA_OC_EXACTUS_GY]
        //(@TMP_SQL_CARGA_OC VARCHAR(350),
        //@OPCION VARCHAR(10))	-- 'CREAR', 'LISTAR'  
        public static bool CargarOrdenCompra_DL(string _file, string _opcion, string db)
        {
            int NumReg = 0;
            string strSql = "PIMENTEL.SP_APSSA_CARGA_OC_EXACTUS_GY";

            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@TMP_SQL_CARGA_OC", _file));
            arParam.Add(new SqlParameter("@OPCION", _opcion));

            NumReg = SqlHelper.ExecuteNonQuery(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParam.ToArray());
            return NumReg > 0;
        }

        public static DataTable dtObtenerTablaTempCargaOC_DL(string db)
        {
            string strSql = @"  SELECT 
					             SHIPTO, NUMERO_PEDIDO, FECHA_PEDIDO, MONEDA, TOTAL, CODIGO,
					             CANTIDAD, PRECIO, IGV, FECHA_ENTREGA, RUBRO3, RUBRO5,
					             TOTAL_MERCADERIA, TOTAL_IMPUESTO, TOTAL_ORDEN, USUARIO
                                SPACE(50)AS RUBRO3,
                                SPACE(50)AS RUBRO5
                                FROM PIMENTEL.ORDEN_COMPRA (NOLOCK) ;
                             ";

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql).Tables[0];
        }


        public static bool CargaTablaTemporalCargaOC_DL(string _tabla, string _shipto, string _numero_pedido, DateTime _fecha_pedido, string _moneda, Decimal _total,
                                                        string _codigo, Decimal _cantidad, Decimal _precio, Decimal _igv, DateTime _fecha_entrega, string _rubro3, string _rubro5,
                                                        Decimal _total_mercaderia, Decimal _total_impuesto, Decimal _total_orden, string _usuario, string db)
        {
            int NumReg = 0;
            string strSql = "PIMENTEL.SP_APSSA_CARGA_OC_INSERT";

            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@TMP_SQL_CARGA_OC", _tabla));
            arParam.Add(new SqlParameter("@SHIPTO", _shipto));
            arParam.Add(new SqlParameter("@NUMERO_PEDIDO", _numero_pedido));
            arParam.Add(new SqlParameter("@FECHA_PEDIDO", _fecha_pedido));
            arParam.Add(new SqlParameter("@MONEDA", _moneda));
            arParam.Add(new SqlParameter("@TOTAL", _total));
            arParam.Add(new SqlParameter("@CODIGO", _codigo));
            arParam.Add(new SqlParameter("@CANTIDAD", _cantidad));
            arParam.Add(new SqlParameter("@PRECIO", _precio));
            arParam.Add(new SqlParameter("@IGV", _igv));
            arParam.Add(new SqlParameter("@FECHA_ENTREGA", _fecha_entrega));
            arParam.Add(new SqlParameter("@RUBRO3", _rubro3));
            arParam.Add(new SqlParameter("@RUBRO5", _rubro5));
            arParam.Add(new SqlParameter("@TOTAL_MERCADERIA", _total_mercaderia));
            arParam.Add(new SqlParameter("@TOTAL_IMPUESTO", _total_impuesto));
            arParam.Add(new SqlParameter("@TOTAL_ORDEN", _total_orden));
            arParam.Add(new SqlParameter("@USUARIO", _usuario));

            NumReg = Convert.ToInt32(SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParam.ToArray()));
            return NumReg > 0;
        }

        public static DataTable dtListarTablaTemporalCargaOC_DL(string _file, string _opcion, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_CARGA_OC_TEMPORAL";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TMP_SQL_CARGA_OC", _file);
                    cmd.Parameters.AddWithValue("@OPCION", _opcion);
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


        //ALTER PROCEDURE[PIMENTEL].[SP_APSSA_CARGA_OC_TEMPORAL]
        //(@TMP_SQL_CARGA_OC VARCHAR(350),
        //@OPCION VARCHAR(10))	-- 'CREAR', 'LISTAR'
        public static DataSet dsCrearTablaTemporalCargaOC_DL(string _file, string _opcion, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_CARGA_OC_TEMPORAL";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@TMP_SQL_CARGA_OC", _file);
                    cmd.Parameters.AddWithValue("@OPCION", _opcion);
                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();

                    DataTable table1 = new DataTable();
                    table1.Load(cmd.ExecuteReader());
                    ds.Tables.Add(table1);
                }
                return ds;
            }
        }


        public static DataTable dtListarCamposExactusOrdenCompraMaster_DL(string db)
        {
            string strSql = @"  DECLARE @TIPO_CAMBIO DECIMAL(28,6), @ARTICULO VARCHAR(20);
                                SELECT TOP 0 SPACE(10) AS PROCESAR, SPACE(50) AS VALIDACION,
                                SPACE(20) AS SHIPTO,
                                ORDEN_COMPRA AS NUMERO_PEDIDO,
                                FECHA AS FECHA_PEDIDO,
                                MONEDA,
                                TOTAL_MERCADERIA AS SUBTOTAL,
                                TOTAL_MERCADERIA AS IMPUESTO,
                                TOTAL_MERCADERIA AS TOTAL,
                                FECHA AS FECHA_ENTREGA,
                                SPACE(50)AS RUBRO3,
                                SPACE(50)AS RUBRO5
                                FROM PIMENTEL.ORDEN_COMPRA (NOLOCK) ;
                             ";

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql).Tables[0];
        }


        public static DataTable dtListarCamposExactusOrdenCompra_DL(string db)
        {
            string strSql = @"  DECLARE @TIPO_CAMBIO DECIMAL(28,6), @ARTICULO VARCHAR(20);
                                SELECT TOP 0 SPACE(10) AS PROCESAR, SPACE(50) AS VALIDACION,
                                SPACE(20) AS SHIPTO,
                                ORDEN_COMPRA AS NUMERO_PEDIDO,
                                FECHA AS FECHA_PEDIDO,
                                MONEDA,
                                TOTAL_MERCADERIA AS TOTAL,
                                @ARTICULO AS CODIGO,
                                TOTAL_MERCADERIA AS CANTIDAD,
                                MONTO_DESCUENTO AS PRECIO,
                                TOTAL_IMPUESTO1 AS IGV,
                                FECHA AS FECHA_ENTREGA,
                                SPACE(50)AS RUBRO3,
                                SPACE(50)AS RUBRO5,
                                TOTAL_MERCADERIA AS TOTAL_MERCADERIA,
                                TOTAL_IMPUESTO1 AS TOTAL_IMPUESTO,
                                TOTAL_MERCADERIA AS TOTAL_ORDEN
                                FROM PIMENTEL.ORDEN_COMPRA (NOLOCK) ;
                             ";

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql).Tables[0];
        }


        public static DataTable dtListarCamposExcelOrdenCompra_DL(string db)
        {
            string strSql = @"  DECLARE @TIPO_CAMBIO DECIMAL(28,6), @ARTICULO VARCHAR(20);
                                SELECT TOP 0 SPACE(10) AS PROCESAR, SPACE(50) AS VALIDACION,
                                SPACE(20) AS SHIPTO,
                                ORDEN_COMPRA AS NUMERO_PEDIDO,
                                FECHA AS FECHA_PEDIDO,
                                MONEDA,
                                TOTAL_MERCADERIA AS TOTAL,
                                @ARTICULO AS CODIGO,
                                TOTAL_MERCADERIA AS CANTIDAD,
                                MONTO_DESCUENTO AS PRECIO,
                                TOTAL_IMPUESTO1 AS IGV,
                                FECHA AS FECHA_ENTREGA,
                                SPACE(50)AS RUBRO3,
                                SPACE(50)AS RUBRO5
                                FROM PIMENTEL.ORDEN_COMPRA (NOLOCK) ;
                             ";

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql).Tables[0];
        }

        //-------------------------------------------------------------------------------------------------


        public static DataTable dtCargarParametrosKardex_DL(string _modulo, string _aplicacion, string db)
        {
            string strSql = @"  SELECT                      
                                    PARAMETRO, VALOR, DETALLE
                                    FROM PIMENTEL.APSSA_PARAMETROS_REPORTES (NOLOCK)
                                    WHERE MODULO=@MODULO AND APLICACION=@APLICACION ; ";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@MODULO", _modulo));
            arParams.Add(new SqlParameter("@APLICACION", _aplicacion));

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParams.ToArray()).Tables[0];
        }



        public static DataTable dtObtenerArticuloTransacciones_DL(string _articulo, string _bodega, string _operacion,
                                                                  DateTime _fecha_ini, DateTime _fecha_fin, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_ARTICULOS_EXISTENCIAS_V2";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ARTICULO", _articulo);
                    cmd.Parameters.AddWithValue("@BODEGA", _bodega);
                    cmd.Parameters.AddWithValue("@OPERACION", _operacion);
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



        public static DataTable dtObtenerArticuloExistenciasV2_DL(string _articulo, string _bodega, string _operacion,
                                                                  DateTime _fecha_ini, DateTime _fecha_fin, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_ARTICULOS_EXISTENCIAS_V2";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ARTICULO", _articulo);
                    cmd.Parameters.AddWithValue("@BODEGA", _bodega);
                    cmd.Parameters.AddWithValue("@OPERACION", _operacion);
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




        //ALTER PROCEDURE[PIMENTEL].[SP_APSSA_ARTICULOS_EXISTENCIAS]
        //( @ARTICULO VARCHAR(20),
        //@BODEGA VARCHAR(4),
        //@OPERACION VARCHAR(25)) -- EXISTENCIA, RESERVADO, TRANSITO, REMITIDO, KARDEX
        public static DataTable dtObtenerArticuloExistencias_DL(string _articulo, string _bodega, string _operacion, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_ARTICULOS_EXISTENCIAS";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ARTICULO", _articulo);
                    cmd.Parameters.AddWithValue("@BODEGA", _bodega);
                    cmd.Parameters.AddWithValue("@OPERACION", _operacion);
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



        //---------------------------------------------------------------------------------------------------------------

        //ALTER PROCEDURE[PIMENTEL].[SP_APSSA_DESPACHOS]
        //(@FECHA_INI DATETIME,
        //@FECHA_FIN DATETIME,
        //@ZONA VARCHAR(MAX))

        public static DataTable dtObtenerDespachos_DL(DateTime _fecha_ini, DateTime _fecha_fin, string _zona, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_DESPACHOS";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FECHA_INI", _fecha_ini);
                    cmd.Parameters.AddWithValue("@FECHA_FIN", _fecha_fin);
                    cmd.Parameters.AddWithValue("@ZONA", _zona);
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


        //ALTER PROCEDURE[PIMENTEL].[SP_APSSA_ARTICULOS_REMITIDOS]
        //(@PAR_ARTICULO VARCHAR(20),
        // @PAR_BODEGA VARCHAR(1000) )
        public static DataTable dtObtenerArticulosRemitidos_DL(string _articulo, string _bodega, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_ARTICULOS_REMITIDOS";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PAR_ARTICULO", _articulo);
                    cmd.Parameters.AddWithValue("@PAR_BODEGA", _bodega);
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

        //ALTER PROCEDURE[PIMENTEL].[SP_APSSA_ARTICULOS_TRANSACCIONES]
        //(@FECHA_INI DATETIME,
        //@FECHA_FIN DATETIME,
        //@BODEGA VARCHAR(4),
        //@ARTICULO VARCHAR(20))

        public static DataTable dtObtenerArticuloTransacciones_DL(DateTime _fecha_ini, DateTime _fecha_fin, string _bodega, string _articulo, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_ARTICULOS_TRANSACCIONES";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FECHA_INI", _fecha_ini);
                    cmd.Parameters.AddWithValue("@FECHA_FIN", _fecha_fin);
                    cmd.Parameters.AddWithValue("@BODEGA", _bodega);
                    cmd.Parameters.AddWithValue("@ARTICULO", _articulo);
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





        #region VENTA_COMPRA

        public static DataSet CargaPreferencia(string cModulo, string cReporte, string cPreferencia,string db)
        {
            DataSet ds_pref = new DataSet();
            string strSql = "PIMENTEL.SP_APSSA_VC2015_PREFERENCIA";
            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@Modulo", cModulo));
            arParams.Add(new SqlParameter("@Reporte", cReporte));
            arParams.Add(new SqlParameter("@Preferencia", cPreferencia));
            ds_pref = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray());
            ds_pref.Tables[0].TableName = "pref";
            return ds_pref;
        }


        public static DataSet ObtenerVC2015(DateTime fecha1, DateTime fecha2, string bode, string fami, string subf, string grup, string deta, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db) ))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_VC2015";
                string connectionString = ConexionDC.ConectarBD(db);

                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@fecha1", fecha1);
                    cmd.Parameters.AddWithValue("@fecha2", fecha2);
                    cmd.Parameters.AddWithValue("@Bodega", bode);
                    cmd.Parameters.AddWithValue("@Familia", fami);
                    cmd.Parameters.AddWithValue("@SubFamilia", subf);
                    cmd.Parameters.AddWithValue("@Grupo", grup);
                    cmd.Parameters.AddWithValue("@TipoDetalle", deta);
                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    ds.Tables.Add(table);
                }
                return ds;

            }
        }

        public static DataSet ObtenerVentaCompra(DateTime fecha1, DateTime fecha2, string bode,
                                                 string fami, string subf, string grup, string db)
        {
            DataSet ds_vtacompra = new DataSet();

            string strSql = "PIMENTEL.SP_APSSA_VC2015_GY";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@fecha1", fecha1));
            arParams.Add(new SqlParameter("@fecha2", fecha2));
            arParams.Add(new SqlParameter("@Bodega", bode));
            arParams.Add(new SqlParameter("@Familia", fami));
            arParams.Add(new SqlParameter("@SubFamilia", subf));
            arParams.Add(new SqlParameter("@Grupo", grup));
            
            ds_vtacompra = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray());

            ds_vtacompra.Tables[0].TableName = "vtacompra";
            return ds_vtacompra;
        }

        public static DataSet ObtenerVC2015V3(DateTime fecha1, DateTime fecha2, string bode, string fami, string subf, string grup, string deta, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_VC2015_V2";  // procesa codigos
                string connectionString = ConexionDC.ConectarBD(db);

                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@fecha1", fecha1);
                    cmd.Parameters.AddWithValue("@fecha2", fecha2);
                    cmd.Parameters.AddWithValue("@Bodega", bode);
                    cmd.Parameters.AddWithValue("@Familia", fami);
                    cmd.Parameters.AddWithValue("@SubFamilia", subf);
                    cmd.Parameters.AddWithValue("@Grupo", grup);
                    cmd.Parameters.AddWithValue("@TipoDetalle", deta);
                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    ds.Tables.Add(table);
                }
                return ds;
            }
        }


        #endregion

        public static DataSet Items_sin_movimiento(string bodega,int dias,string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_ITEMS_SIN_MOVIMIENTO";
                string connectionString = ConexionDC.ConectarBD(db);

                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@BODEGA_I", bodega);
                    cmd.Parameters.AddWithValue("@DIAS", dias);
                    
                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    ds.Tables.Add(table);
                }
                return ds;

            }
        }

        public static DataSet CargaExcel_DL(string RutaExcel, string NombreHoja)
        {
            try
            {
                System.Data.OleDb.OleDbConnection connXls;
                System.Data.DataSet DSet;
                System.Data.OleDb.OleDbDataAdapter cmdXls;
                connXls = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                                                                 RutaExcel + ";Extended Properties=\"Excel 12.0;HDR=YES\"");
                cmdXls = new System.Data.OleDb.OleDbDataAdapter

                ("select * from [" + NombreHoja + "$]", connXls);
                cmdXls.TableMappings.Add("Table", "TestTable");
                DSet = new System.Data.DataSet();
                cmdXls.Fill(DSet);
                connXls.Close();
                return DSet;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }

        }


    }


    public class ReportesLogisticaDL
    {
        public DataTable dtPeriodosCuotasDL(string canno, string db)
        {
            string strSql = @"  SELECT                      
                                CMG.PERIODO_CONTABLE, PC.DESCRIPCION, CMG.USUARIO_REGISTRO, U1.NOMBRE,
                                CMG.FECHA_REGISTRO, CMG.USUARIO_ULT_MOD, U1.NOMBRE, CMG.FECHA_ULT_MOD,
                                YEAR(CMG.PERIODO_CONTABLE) AS ANNO, MONTH(CMG.PERIODO_CONTABLE) AS MES
                                FROM   PIMENTEL.CUOTA_MENSUAL_GOODYEAR  CMG(NOLOCK) 
                                INNER JOIN PIMENTEL.PERIODO_CONTABLE PC(NOLOCK) ON (CMG.PERIODO_CONTABLE = PC.FECHA_FINAL AND PC.CONTABILIDAD = 'F' ) 
                                INNER JOIN ERPADMIN.USUARIO U1(NOLOCK) ON (CMG.USUARIO_REGISTRO = U1.USUARIO ) 
                                INNER JOIN ERPADMIN.USUARIO U2(NOLOCK) ON (CMG.USUARIO_ULT_MOD = U2.USUARIO  )
                                WHERE YEAR(CMG.PERIODO_CONTABLE)=@ANNO                                                                     
                                ORDER BY 1 ASC  ";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@ANNO", canno));

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParams.ToArray()).Tables[0];
        }

        public DataTable dtCuotasDelMesDL(string canno, Int32 cmes, string db)
        {
            string strSql = @"  SELECT 
                                DET.PERIODO_CONTABLE, DET.LINEA, C.DESCRIPCION,    
                                C.UNIDAD_MEDIDA, UM.DESCRIPCION, DET.CUOTA,
                                YEAR(DET.PERIODO_CONTABLE) AS ANNO, MONTH(DET.PERIODO_CONTABLE) AS MES                                                        
                                FROM   PIMENTEL.DET_CUOTA_MENSUAL_GOODYEAR DET(NOLOCK), 
	                                   PIMENTEL.CLASIFICACION C(NOLOCK), 
	                                   PIMENTEL.UNIDAD_DE_MEDIDA UM(NOLOCK)  
                                WHERE  DET.LINEA = C.CLASIFICACION AND C.UNIDAD_MEDIDA = UM.UNIDAD_MEDIDA
                                       AND YEAR(PERIODO_CONTABLE)=@ANNO 	                                   
                                ORDER  BY 1 ASC; ";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@ANNO", canno));
            arParams.Add(new SqlParameter("@MES", cmes));

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParams.ToArray()).Tables[0];
        }

        public DataTable dtReporteCuotasDL(string canno, DateTime f1, DateTime f2, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_REPORTE_CUOTAS_COMPRAS";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@ANNO", canno));
            arParams.Add(new SqlParameter("@FECHA_INI", f1));
            arParams.Add(new SqlParameter("@FECHA_FIN", f2));

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray()).Tables[0];
        }

        public DataTable dtSeguimientoComprasDL(DateTime f1, DateTime f2, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_SEGUIMIENTO_COMPRAS";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@FECHA_INI", f1));
            arParams.Add(new SqlParameter("@FECHA_FIN", f2));

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray()).Tables[0];
        }

    }

}
