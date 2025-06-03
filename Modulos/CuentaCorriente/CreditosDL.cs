using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
//using Exactus.DC;
//using Exactus.BE;

namespace ApssaExactus
{

    public class CreditosDL
    {

        public static int ActualizarConstanciaInscripcion_DL(string _cliente, string _tipo, string _documento, DateTime _fecha, string _constancia, string db)
        {
            int result = 0;
            string strSql = @"UPDATE PIMENTEL.DOCUMENTOS_CC SET
                              U_FECHA_TITULO_VALOR = @FECHA,
	                          U_CODIGO_TITULO_VALOR = @CONSTANCIA
	                          WHERE CLIENTE = @CLIENTE 
                                AND TIPO = @TIPO
                                AND DOCUMENTO = @DOCUMENTO ;";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@CLIENTE", _cliente));
            arParams.Add(new SqlParameter("@TIPO", _tipo));
            arParams.Add(new SqlParameter("@DOCUMENTO", _documento));
            arParams.Add(new SqlParameter("@FECHA", _fecha));
            arParams.Add(new SqlParameter("@CONSTANCIA", _constancia));

            result = Convert.ToInt16(SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParams.ToArray()));
            return result;

        }


        //ALTER PROCEDURE[PIMENTEL].[SP_APSSA_CLIENTE_CANJE_DETALLE]
        //(@TIPO_CANJE VARCHAR(20),
        // @DOCUMENTO_CANJE VARCHAR(20))
        //AS
        public static DataTable dtDetalleCanjeLetraDL(string _tipo_canje, string _documento_canje, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_CLIENTE_CANJE_DETALLE";
            List<SqlParameter> arParams = new List<SqlParameter>();

            arParams.Add(new SqlParameter("@TIPO_CANJE", _tipo_canje));
            arParams.Add(new SqlParameter("@DOCUMENTO_CANJE", _documento_canje));
            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray()).Tables[0];
        }

        //-------------------------------------------------------


        public static int GrabarClausulaLetra_DL(DateTime _fecha, string _tipo, string _activo, string _clausula, string db)
        {
            int result = 0;
            string strSql = @"INSERT INTO PIMENTEL.APSSA_FORMATO_LETRA_CC
	                            (FECHA, TIPO, CLAUSULA, ACTIVO)
	                            VALUES (@FECHA, @TIPO, @CLAUSULA, @ACTIVO);";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@FECHA", _fecha));
            arParams.Add(new SqlParameter("@TIPO", _tipo));
            arParams.Add(new SqlParameter("@ACTIVO", _activo));
            arParams.Add(new SqlParameter("@CLAUSULA", _clausula));

            result = Convert.ToInt16(SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParams.ToArray()));
            return result;
        }

        public static int ActualizarClausulaLetra_DL(Int16 _id_clausula, DateTime _fecha, string _tipo, string _activo, string _clausula, string db)
        {
            int result = 0;
            string strSql = @"UPDATE PIMENTEL.APSSA_FORMATO_LETRA_CC SET
                              FECHA=@FECHA,
	                          TIPO=@TIPO, 
                              ACTIVO=@ACTIVO,
                              CLAUSULA=@CLAUSULA
	                          WHERE ID_CLAUSULA=@ID_CLAUSULA ;";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@FECHA", _fecha));
            arParams.Add(new SqlParameter("@TIPO", _tipo));
            arParams.Add(new SqlParameter("@ACTIVO", _activo));
            arParams.Add(new SqlParameter("@CLAUSULA", _clausula));
            arParams.Add(new SqlParameter("@ID_CLAUSULA", _id_clausula));

            result = Convert.ToInt16(SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParams.ToArray()));
            return result;

        }

        public static DataTable CargaDatosClausula_DL(Int16 _id, string db)
        {
            string strSql = @"SELECT ID_CLAUSULA, FECHA, TIPO, CLAUSULA, ACTIVO
                              FROM PIMENTEL.APSSA_FORMATO_LETRA_CC (NOLOCK) 
                              WHERE ID_CLAUSULA=@ID_CLAUSULA ; ";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@ID_CLAUSULA", _id));
            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParams.ToArray()).Tables[0];
        }

        public static DataTable dtFormatosLetras_DL(string db)
        {
            string strSql = @"SELECT ID_CLAUSULA,FECHA,TIPO,CLAUSULA,ACTIVO
                              FROM PIMENTEL.APSSA_FORMATO_LETRA_CC (NOLOCK)  
                              ORDER BY 1;
                             ";
            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql).Tables[0];
        }

        public static string ObtenerClausulaLetraCC_DL(Int16 _id, string _tipo, string db)
        {
            string cClausula = null;
            string strSql = @"SELECT CLAUSULA
                              FROM PIMENTEL.APSSA_FORMATO_LETRA_CC (NOLOCK) 
                              WHERE ID_CLAUSULA = @ID AND TIPO = @TIPO ;
                             ";

            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@ID", _id));
            arParam.Add(new SqlParameter("@TIPO", _tipo));

            cClausula = Convert.ToString(SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray()));
            return cClausula;
        }







        public static bool VerificarSiYaEstaRegistradoAnalistaCreditosDL(string id_prod, string db)
        {
            int NumReg = 0;
            string strSql = @"SELECT COUNT(*) 
                              FROM PIMENTEL.APSSA_ARTICULO_WEB (NOLOCK)
                              WHERE ID_PRODUCT = @ID_PRODUCT";

            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@ID_PRODUCT", id_prod));

            NumReg = Convert.ToInt32(SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray()));
            return NumReg > 0;
        }
        public static DataTable dtObtenerUsuariosAnalistasCreditosDL(string cdb)
        {
            string strSql = "PIMENTEL.SP_APSSA_LISTAR_ANALISTAS";
            List<SqlParameter> arParams = new List<SqlParameter>();

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(cdb), CommandType.StoredProcedure, strSql, arParams.ToArray()).Tables[0];
        }

        public static DataTable CargaDatosAnalistaCreditoDL(string art, string db)
        {
            string strSql = @"SELECT ARTICULO, DESCRIPCION, UNIDAD_ALMACEN
                              FROM PIMENTEL.ARTICULO
                              WHERE ARTICULO=@ARTICULO; ";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@ARTICULO", art));

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParams.ToArray()).Tables[0];
        }

        public static bool ExisteAnalistaCreditoDL(string art, string db)
        {
            int NumReg = 0;
            string strSql = @"SELECT COUNT(*) 
                              FROM PIMENTEL.APSSA_ANALISTAS_CC (NOLOCK)
                              WHERE ARTICULO = @ANALISTA";

            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@ANALISTA", art));

            NumReg = Convert.ToInt32(SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray()));
            return NumReg > 0;
        }

        public static void ActualizarAnalistasCreditoDL(string _tipo_operacion, string _analista, string _area, string _analista_cc, string _nombre,
                                                        string _referencia, string _observaciones, string _estado, string _moneda_credito,
                                                         Decimal _limite_credito, Decimal _limite_credito_sol, Decimal _limite_credito_dol, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_ANALISTA_CC_UPDATE";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@ANALISTA", _analista));
            arParams.Add(new SqlParameter("@AREA", _area));
            arParams.Add(new SqlParameter("@ANALISTA_CC", _analista_cc));
            arParams.Add(new SqlParameter("@NOMBRE", _nombre));
            arParams.Add(new SqlParameter("@REFERENCIA", _referencia));
            arParams.Add(new SqlParameter("@OBSERVACIONES", _observaciones));
            arParams.Add(new SqlParameter("@ESTADO", _estado));
            arParams.Add(new SqlParameter("@MONEDA_CREDITO", _moneda_credito));
            arParams.Add(new SqlParameter("@LIMITE_CREDITO", _limite_credito));
            arParams.Add(new SqlParameter("@LIMITE_CREDITO_SOL", _limite_credito_sol));
            arParams.Add(new SqlParameter("@LIMITE_CREDITO_DOL", _limite_credito_dol));

            SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray());

        }


        public static DataTable dtObtenerAnalistasCreditoDL(string db)
        {
            string strSql = @" SELECT 
                               ANALISTA,NOMBRE,AREA,ANALISTA_CC,REFERENCIA,OBSERVACIONES,ESTADO,
                               MONEDA_CREDITO,LIMITE_CREDITO,LIMITE_CREDITO_SOL,LIMITE_CREDITO_DOL
                               FROM PIMENTEL.APSSA_ANALISTAS_CC (NOLOCK)
                               ORDER BY 2 ASC";

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql).Tables[0];

        }

        //--------------------------------------------------------------------------------------------------------------------------

        // 2022-06-10
        public static DataTable dtSaldoClientesV2_DL(string _zona, DateTime _fecha, string _moneda, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_SALDOS_CLIENTES_V2";
            List<SqlParameter> arParams = new List<SqlParameter>();

            arParams.Add(new SqlParameter("@ZONA", _zona));
            arParams.Add(new SqlParameter("@FECHA", _fecha));
            arParams.Add(new SqlParameter("@MONEDA", _moneda));
            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray()).Tables[0];
        }

        //ALTER PROCEDURE[PIMENTEL].[SP_APSSA_SALDOS_CLIENTES]
        //(@ZONA CHAR(1000),
        //@FECHA DATE,
        //@MONEDA CHAR(3))
        public static DataTable dtSaldoClientesDL(string _zona, DateTime _fecha, string _moneda, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_SALDOS_CLIENTES";
            List<SqlParameter> arParams = new List<SqlParameter>();

            arParams.Add(new SqlParameter("@ZONA", _zona));
            arParams.Add(new SqlParameter("@FECHA", _fecha));
            arParams.Add(new SqlParameter("@MONEDA", _moneda));
            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray()).Tables[0];
        }



        //Update: 20/09/2020

        public static DataTable dtObtieneTablaCobranzaV2DL(string file_sql, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_TEMPORAL_RECUPERAR_V2";
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
                }
                return ds.Tables[0];
            }
        }



        public static DataSet dsObtenerTablasCobranzasV2DL(DateTime fecha1, DateTime fecha2, string zon, string fil1, string fil2, string fil3,
                                                             string fil4, string fil5, string fil6, string fil7, string fil8, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_COBRANZAS_V2";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FECHA_INI", fecha1);
                    cmd.Parameters.AddWithValue("@FECHA_FIN", fecha2);
                    cmd.Parameters.AddWithValue("@TIENDA", zon);
                    cmd.Parameters.AddWithValue("@TMP_SQL_TOTAL", fil1);
                    cmd.Parameters.AddWithValue("@TMP_SQL_TIPOABONO", fil2);
                    cmd.Parameters.AddWithValue("@TMP_SQL_UNIDADNEG", fil3);
                    cmd.Parameters.AddWithValue("@TMP_SQL_CREDITO", fil4);
                    cmd.Parameters.AddWithValue("@TMP_SQL_LIQCRED", fil5);
                    cmd.Parameters.AddWithValue("@TMP_SQL_DIAS_DET", fil6);
                    cmd.Parameters.AddWithValue("@TMP_SQL_DIAS_RES", fil7);
                    cmd.Parameters.AddWithValue("@TMP_SQL_CONTADO", fil8);
                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();

                    DataTable table1 = new DataTable();
                    table1.Load(cmd.ExecuteReader());
                    ds.Tables.Add(table1);
                }
                return ds;
            }
        }


        //--------------------------------------------------------------------------------------------------------------------------



        public static DataTable dtObtenerListaReactivaPeruDL(string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_GET_REACTIVA_PERU";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@TEMPORAL_SQL", file_sql);
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


        //ALTER FUNCTION[PIMENTEL].[Fn_APPSA_CLIENTE_CONTACTOS] 
        //(@CLIENTE VARCHAR(20))
        public static DataTable dtGetContactosPorClientesDL(string _cliente, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "SELECT CONTACTO FROM PIMENTEL.Fn_APPSA_CLIENTE_CONTACTOS(@CLIENTE);";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@CLIENTE", _cliente);
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


        //ALTER PROCEDURE[PIMENTEL].[SP_APSSA_GET_CLIENTE_EMAIL_UPDATE]
        //(@OPERACION VARCHAR(1), -- U-update, I-insert,D-delete
        //@CLIENTE VARCHAR(25),
        //@RAZON_SOCIAL VARCHAR(200),
        //@EMAIL1 VARCHAR(200),
        //@EMAIL1_FLAG VARCHAR(1),
        //@EMAIL2 VARCHAR(200),
        //@EMAIL2_FLAG VARCHAR(1),
        //@EMAIL3 VARCHAR(200),
        //@EMAIL3_FLAG VARCHAR(1),
        //@EMAIL4 VARCHAR(200),
        //@EMAIL4_FLAG VARCHAR(1),
        //@OBSERVACIONES VARCHAR(200),
        //@ESTADO VARCHAR(1)  )	

        public static void dtGetContactosClientesUpdateDL(string _operacion, string _cliente, string _razon,
                                                               string _email1, string _flag1,
                                                               string _email2, string _flag2,
                                                               string _email3, string _flag3,
                                                               string _email4, string _flag4,
                                                               string _observ, string _estado, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string strSql = "PIMENTEL.SP_APSSA_GET_CLIENTE_EMAIL_UPDATE";
                List<SqlParameter> arParams = new List<SqlParameter>();
                arParams.Add(new SqlParameter("@OPERACION", _operacion));
                arParams.Add(new SqlParameter("@CLIENTE", _cliente));
                arParams.Add(new SqlParameter("@RAZON_SOCIAL", _razon));
                arParams.Add(new SqlParameter("@EMAIL1", _email1));
                arParams.Add(new SqlParameter("@EMAIL1_FLAG", _flag1));
                arParams.Add(new SqlParameter("@EMAIL2", _email2));
                arParams.Add(new SqlParameter("@EMAIL2_FLAG", _flag2));
                arParams.Add(new SqlParameter("@EMAIL3", _email3));
                arParams.Add(new SqlParameter("@EMAIL3_FLAG", _flag3));
                arParams.Add(new SqlParameter("@EMAIL4", _email4));
                arParams.Add(new SqlParameter("@EMAIL4_FLAG", _flag4));
                arParams.Add(new SqlParameter("@OBSERVACIONES", _observ));
                arParams.Add(new SqlParameter("@ESTADO", _estado));

                SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray());

                //string sqlCommand = "PIMENTEL.SP_APSSA_GET_CLIENTE_EMAIL_UPDATE";
                //string connectionString = ConexionDC.ConectarBD(db);
                //DataSet ds = new DataSet();
                //using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                //{
                //    cmd.CommandType = CommandType.StoredProcedure;
                //    cmd.Parameters.AddWithValue("@OPERACION", _operacion);
                //    cmd.Parameters.AddWithValue("@CLIENTE", _cliente);
                //    cmd.Parameters.AddWithValue("@RAZON_SOCIAL", _razon);
                //    cmd.Parameters.AddWithValue("@EMAIL1", _email1);
                //    cmd.Parameters.AddWithValue("@EMAIL1_FLAG", _flag1);
                //    cmd.Parameters.AddWithValue("@EMAIL2", _email2);
                //    cmd.Parameters.AddWithValue("@EMAIL2_FLAG", _flag2);
                //    cmd.Parameters.AddWithValue("@EMAIL3", _email3);
                //    cmd.Parameters.AddWithValue("@EMAIL3_FLAG", _flag3);
                //    cmd.Parameters.AddWithValue("@EMAIL4", _email4);
                //    cmd.Parameters.AddWithValue("@EMAIL4_FLAG", _flag4);
                //    cmd.Parameters.AddWithValue("@OBSERVACIONES", _observ);
                //    cmd.Parameters.AddWithValue("@ESTADO", _estado);
                //    cmd.CommandTimeout = 0;
                //    cmd.Connection.Open();
                //    DataTable table = new DataTable();
                //    table.Load(cmd.ExecuteReader());
                //    ds.Tables.Add(table);
                //    cmd.Connection.Close();  //// ADD MXMX
                //}
                //return ds.Tables[0];
            }
        }

        public static void EliminarContactoClienteDL(string cte, string db)
        {
            string strSql = @" DELETE FROM PIMENTEL.APSSA_CLIENTE_EMAIL                             
                               WHERE CLIENTE=@CLIENTE;  ";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@CLIENTE", cte));
            SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParams.ToArray());
        }

        public static DataTable dtGetContactosClientesDL(string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_GET_CLIENTE_EMAIL";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    //cmd.Parameters.AddWithValue("@TEMPORAL_SQL", file_sql);
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

        //ALTER PROCEDURE[PIMENTEL].[SP_APSSA_ESTADO_CUENTA_RECUPERAR]
        //(@TEMPORAL_SQL VARCHAR(250))

        public static DataTable dtRecuperaTablaEstadoCuentaDL(string file_sql, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_ESTADO_CUENTA_RECUPERAR";
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

        //ALTER PROCEDURE[PIMENTEL].[SP_APSSA_GET_TABLAS_ESTADO_CUENTA]
        //(@FECHA_INI DATETIME,
        //@FECHA_FIN DATETIME,
        //@TMP_SQL_ESTCTA_DET VARCHAR(250),
        //@TMP_SQL_ESTCTA_RES VARCHAR(250) )
        public static DataSet dsObtenerTablasEstadoCuentaDL(DateTime fecha1, DateTime fecha2, string fil1, string fil2, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_GET_TABLAS_ESTADO_CUENTA";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FECHA_INI", fecha1);
                    cmd.Parameters.AddWithValue("@FECHA_FIN", fecha2);
                    cmd.Parameters.AddWithValue("@TMP_SQL_ESTCTA_DET", fil1);
                    cmd.Parameters.AddWithValue("@TMP_SQL_ESTCTA_RES", fil2);
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








        //-----------------------------------------------------------------------------------------------------------------------        



        //ALTER PROCEDURE[PIMENTEL].[SP_APSSA_DOCUMENTOS_CLIENTE_CASTIGO]
        //(@PAR_CLIENTE VARCHAR(20), 
        //@PAR_ESTADO VARCHAR(100) )
        public static DataTable dtEsClienteCastigadoDL(string _clie, string _esta, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_DOCUMENTOS_CLIENTE_CASTIGO";
            List<SqlParameter> arParams = new List<SqlParameter>();

            arParams.Add(new SqlParameter("@PAR_CLIENTE", _clie));
            arParams.Add(new SqlParameter("@PAR_ESTADO", _esta));
            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray()).Tables[0];
        }

        public static DataTable dtObtenerDocumentosDesprovisionSegunFechaDL(DateTime _fini, DateTime _ffin, string _est, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_DOCUMENTOS_DESPROVISION_CLIENTES";
            List<SqlParameter> arParams = new List<SqlParameter>();

            arParams.Add(new SqlParameter("@PAR_FECHA_INI", _fini));
            arParams.Add(new SqlParameter("@PAR_FECHA_FIN", _ffin));
            arParams.Add(new SqlParameter("@PAR_ESTADO", _est));
            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray()).Tables[0];
        }

        public static DataTable dtObtenerDocumentosProvisionSegunFechaDL(DateTime _fini, DateTime _ffin, string _est, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_DOCUMENTOS_PROVISION_CLIENTES";
            List<SqlParameter> arParams = new List<SqlParameter>();

            arParams.Add(new SqlParameter("@PAR_FECHA_INI", _fini));
            arParams.Add(new SqlParameter("@PAR_FECHA_FIN", _ffin));
            arParams.Add(new SqlParameter("@PAR_ESTADO", _est));
            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray()).Tables[0];
        }


        public static DataTable dtConsultarIndicadoresClienteDL(Int16 _ano, Int16 _mes, string _tienda, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_COBRANZA_INDICADOR_CONSULTA";
            List<SqlParameter> arParams = new List<SqlParameter>();

            arParams.Add(new SqlParameter("@PAR_ANO", _ano));
            arParams.Add(new SqlParameter("@PAR_MES", _mes));
            arParams.Add(new SqlParameter("@PAR_TIENDA", _tienda));
            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray()).Tables[0];
        }

        //ALTER PROCEDURE[PIMENTEL].[SP_APSSA_COBRANZA_INDICADOR_PROCESO]
        //(@PAR_ANO INT,
        //@PAR_MES INT, 
        //@PAR_TIENDA VARCHAR(3000) )
        public static DataTable dtProcesarIndicadoresClienteDL(Int16 _ano, Int16 _mes, string _tienda, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_COBRANZA_INDICADOR_PROCESO";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds_saldos = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PAR_ANO", _ano);
                    cmd.Parameters.AddWithValue("@PAR_MES", _mes);
                    cmd.Parameters.AddWithValue("@PAR_TIENDA", _tienda);
                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    ds_saldos.Tables.Add(table);
                    cmd.Connection.Close();
                }
                return ds_saldos.Tables[0];
            }
        }



        //ALTER PROCEDURE[PIMENTEL].[SP_APSSA_CONSULTA_APLICACION_CC_V2]
        //(@PAR_FECHA_DESDE DATETIME,
        // @PAR_FECHA_HASTA DATETIME,
        // @PAR_MONEDA NVARCHAR(MAX),	--VARCHAR(3),	 -- SOL, USD
        // @PAR_SUCURSAL      NVARCHAR(MAX),
        // @PAR_TIENDA NVARCHAR(MAX),
        // @PAR_CATEGORIA_CLIENTE NVARCHAR(MAX),
        // @PAR_CLIENTE_DESDE VARCHAR(20),
        // @PAR_CLIENTE_HASTA VARCHAR(20),
        // @PAR_VENDEDOR VARCHAR(4),
        // @PAR_COBRADOR NVARCHAR(MAX),
        // @PAR_ANALISTA NVARCHAR(MAX) )
        public static DataTable dtObtenerAplicacionesFiltroCC_DL(DateTime _fecha_desde, DateTime _fecha_hasta, string _moneda, string _sucursal, string _tienda,
                                                                 string _categoria_cliente, string _cliente_desde, string _cliente_hasta, string _vendedor,
                                                                 string _cobrador, string _analista, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_CONSULTA_APLICACION_CC_V2";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds_saldos = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PAR_FECHA_DESDE", _fecha_desde);
                    cmd.Parameters.AddWithValue("@PAR_FECHA_HASTA", _fecha_hasta);
                    cmd.Parameters.AddWithValue("@PAR_MONEDA", _moneda);
                    cmd.Parameters.AddWithValue("@PAR_SUCURSAL", _sucursal);
                    cmd.Parameters.AddWithValue("@PAR_TIENDA", _tienda);
                    cmd.Parameters.AddWithValue("@PAR_CATEGORIA_CLIENTE", _categoria_cliente);
                    cmd.Parameters.AddWithValue("@PAR_CLIENTE_DESDE", _cliente_desde);
                    cmd.Parameters.AddWithValue("@PAR_CLIENTE_HASTA", _cliente_hasta);
                    cmd.Parameters.AddWithValue("@PAR_VENDEDOR", _vendedor);
                    cmd.Parameters.AddWithValue("@PAR_COBRADOR", _cobrador);
                    cmd.Parameters.AddWithValue("@PAR_ANALISTA", _analista);
                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    ds_saldos.Tables.Add(table);
                    cmd.Connection.Close();
                }
                return ds_saldos.Tables[0];
            }
        }

        //ALTER PROCEDURE[PIMENTEL].[SP_APSSA_SALDOS_INVERTIDOS_V2]
        //(@PAR_FECHA_SALDO DATE,
        //@PAR_SUCURSAL      NVARCHAR(MAX),
        //@PAR_TIENDA NVARCHAR(MAX),
        //@PAR_CATEGORIA_CLIENTE NVARCHAR(MAX),
        //@PAR_CLIENTE_DESDE VARCHAR(20),
        //@PAR_CLIENTE_HASTA VARCHAR(20),
        //@PAR_VENDEDOR VARCHAR(4),
        //@PAR_COBRADOR NVARCHAR(MAX),
        //@PAR_ANALISTA NVARCHAR(MAX),
        //@PAR_TIPO VARCHAR(100))
        public static DataTable dtObtenerSaldosInvertidoFiltroDL(DateTime _fecha_saldo, string _sucursal, string _tienda, string _categoria_cliente,
                                                                 string _cliente_desde, string _cliente_hasta, string _vendedor, string _cobrador,
                                                                 string _analista, string _tipo, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_SALDOS_INVERTIDOS_V2";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds_saldos = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PAR_FECHA_SALDO", _fecha_saldo);  //@EJERCICIO
                    cmd.Parameters.AddWithValue("@PAR_SUCURSAL", _sucursal);
                    cmd.Parameters.AddWithValue("@PAR_TIENDA", _tienda);
                    cmd.Parameters.AddWithValue("@PAR_CATEGORIA_CLIENTE", _categoria_cliente);
                    cmd.Parameters.AddWithValue("@PAR_CLIENTE_DESDE", _cliente_desde);
                    cmd.Parameters.AddWithValue("@PAR_CLIENTE_HASTA", _cliente_hasta);
                    cmd.Parameters.AddWithValue("@PAR_VENDEDOR", _vendedor);
                    cmd.Parameters.AddWithValue("@PAR_COBRADOR", _cobrador);
                    cmd.Parameters.AddWithValue("@PAR_ANALISTA", _analista);
                    cmd.Parameters.AddWithValue("@PAR_TIPO", _tipo);
                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    ds_saldos.Tables.Add(table);
                    cmd.Connection.Close();
                }
                return ds_saldos.Tables[0];
            }
        }


        //ALTER PROCEDURE[PIMENTEL].[SP_APSSA_CLIENTE_SALDO_SEGUN_FECHA_V2]
        //(@PAR_FECHA_SALDO DATE,
        //@PAR_SUCURSAL      NVARCHAR(MAX),
        //@PAR_TIENDA NVARCHAR(MAX),
        //@PAR_CATEGORIA_CLIENTE NVARCHAR(MAX),
        //@PAR_CLIENTE_DESDE VARCHAR(20),
        //@PAR_CLIENTE_HASTA VARCHAR(20),
        //@PAR_VENDEDOR VARCHAR(4),
        //@PAR_COBRADOR NVARCHAR(MAX),
        //@PAR_ANALISTA NVARCHAR(MAX) )
        public static DataTable dtObtenerSaldoClienteSegunFechaFiltroDL(DateTime _fecha_saldo, string _sucursal, string _tienda, string _categoria_cliente,
                                                                        string _cliente_desde, string _cliente_hasta, string _vendedor, string _cobrador,
                                                                        string _analista, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_CLIENTE_SALDO_SEGUN_FECHA_V2";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds_saldos = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PAR_FECHA_SALDO", _fecha_saldo);  //@EJERCICIO
                    cmd.Parameters.AddWithValue("@PAR_SUCURSAL", _sucursal);
                    cmd.Parameters.AddWithValue("@PAR_TIENDA", _tienda);
                    cmd.Parameters.AddWithValue("@PAR_CATEGORIA_CLIENTE", _categoria_cliente);
                    cmd.Parameters.AddWithValue("@PAR_CLIENTE_DESDE", _cliente_desde);
                    cmd.Parameters.AddWithValue("@PAR_CLIENTE_HASTA", _cliente_hasta);
                    cmd.Parameters.AddWithValue("@PAR_VENDEDOR", _vendedor);
                    cmd.Parameters.AddWithValue("@PAR_COBRADOR", _cobrador);
                    cmd.Parameters.AddWithValue("@PAR_ANALISTA", _analista);
                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    ds_saldos.Tables.Add(table);
                    cmd.Connection.Close();
                }
                return ds_saldos.Tables[0];
            }
        }

        public static DataTable dtObtenerSaldoClienteSegunFechaFiltroV3DL(DateTime _fecha_saldo, string _sucursal, string _tienda, string _categoria_cliente,
                                                                          string _cliente_desde, string _cliente_hasta, string _vendedor, string _cobrador,
                                                                          string _analista, string _saldo_cero, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_CLIENTE_SALDO_SEGUN_FECHA_V3";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds_saldos = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PAR_FECHA_SALDO", _fecha_saldo);  //@EJERCICIO
                    cmd.Parameters.AddWithValue("@PAR_SUCURSAL", _sucursal);
                    cmd.Parameters.AddWithValue("@PAR_TIENDA", _tienda);
                    cmd.Parameters.AddWithValue("@PAR_CATEGORIA_CLIENTE", _categoria_cliente);
                    cmd.Parameters.AddWithValue("@PAR_CLIENTE_DESDE", _cliente_desde);
                    cmd.Parameters.AddWithValue("@PAR_CLIENTE_HASTA", _cliente_hasta);
                    cmd.Parameters.AddWithValue("@PAR_VENDEDOR", _vendedor);
                    cmd.Parameters.AddWithValue("@PAR_COBRADOR", _cobrador);
                    cmd.Parameters.AddWithValue("@PAR_ANALISTA", _analista);
                    cmd.Parameters.AddWithValue("@PAR_SALDO_LOCAL_CERO", _saldo_cero);
                    //@PAR_SALDO_LOCAL_CERO
                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    ds_saldos.Tables.Add(table);
                    cmd.Connection.Close();
                }
                return ds_saldos.Tables[0];
            }
        }

        //SALDOS INVERTIDOS
        //ALTER PROCEDURE[PIMENTEL].[SP_APSSA_SALDOS_INVERTIDOS]
        //(@PAR_FECHA_SALDO DATE,
        // @PAR_CLIENTE_INI   VARCHAR(20),
        // @PAR_CLIENTE_FIN VARCHAR(20),
        // @PAR_TIPO VARCHAR(100))
        public static DataTable dtObtenerSaldosInvertidoDL(DateTime _fecha_saldo, string _cliente_ini, string _cliente_fin, string _tipo, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_SALDOS_INVERTIDOS";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds_saldos = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PAR_FECHA_SALDO", _fecha_saldo);  //@EJERCICIO
                    cmd.Parameters.AddWithValue("@PAR_CLIENTE_INI", _cliente_ini);
                    cmd.Parameters.AddWithValue("@PAR_CLIENTE_FIN", _cliente_fin);
                    cmd.Parameters.AddWithValue("@PAR_TIPO", _tipo);
                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    ds_saldos.Tables.Add(table);
                    cmd.Connection.Close();
                }
                return ds_saldos.Tables[0];
            }
        }

        //SALDO DE CLIENTE A UNA FECHA
        //ALTER PROCEDURE[PIMENTEL].[SP_APSSA_CLIENTE_SALDO_SEGUN_FECHA]
        //(@PAR_FECHA_SALDO DATE,
        // @PAR_CLIENTE_INI   VARCHAR(20),
        // @PAR_CLIENTE_FIN VARCHAR(20))
        public static DataTable dtObtenerSaldoClienteSegunFechaDL(DateTime _fecha_saldo, string _cliente_ini, string _cliente_fin, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_CLIENTE_SALDO_SEGUN_FECHA";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds_saldos = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PAR_FECHA_SALDO", _fecha_saldo);  //@EJERCICIO
                    cmd.Parameters.AddWithValue("@PAR_CLIENTE_INI", _cliente_ini);
                    cmd.Parameters.AddWithValue("@PAR_CLIENTE_FIN", _cliente_fin);
                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    ds_saldos.Tables.Add(table);
                    cmd.Connection.Close();
                }
                return ds_saldos.Tables[0];
            }
        }


        //(clie, ejerc, mes, bda);
        //ALTER PROCEDURE[PIMENTEL].[SP_APSSA_COBRANZA_INDICADOR_DETALLE]
        //(@PAR_ANO INT,
        // @PAR_MES INT, 
        // @PAR_CLIENTE VARCHAR(20) )
        public static DataTable dtObtenerClienteDetalleCobranzaDL(Int32 _ejercicio, Int32 _mes, string _cliente, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_COBRANZA_INDICADOR_DETALLE";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds_saldos = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PAR_ANO", _ejercicio);  //@EJERCICIO
                    cmd.Parameters.AddWithValue("@PAR_MES", _mes);
                    cmd.Parameters.AddWithValue("@PAR_CLIENTE", _cliente);
                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    ds_saldos.Tables.Add(table);
                    cmd.Connection.Close();
                }
                return ds_saldos.Tables[0];
            }
        }


        //14/08/2018
        //ALTER PROCEDURE[PIMENTEL].[SP_APSSA_CLIENTE_INDICADORES]
        //(@PAR_ANO INT,
        // @PAR_CLIENTE VARCHAR(20))

        public static DataTable dtObtenerClienteIndicadoresDL(Int32 _ejercicio, string cliente, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_CLIENTE_INDICADORES";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds_saldos = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PAR_ANO", _ejercicio); //@EJERCICIO
                    cmd.Parameters.AddWithValue("@PAR_CLIENTE", cliente);
                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    ds_saldos.Tables.Add(table);
                    cmd.Connection.Close();
                }
                return ds_saldos.Tables[0];
            }
        }

        //ALTER PROCEDURE[PIMENTEL].[SP_APSSA_CONSULTA_APLICACION_CC]
        //(@FECHA_INICIO DATETIME,
        //@FECHA_FINAL DATETIME,
        //@MONEDA VARCHAR(3),	 -- SOL, USD
        //@SUCURSAL VARCHAR(1000),
        //@TIENDA VARCHAR(1000)) 
        public static DataTable dtObtenerAplicacionesCC_DL(DateTime _fecha_ini, DateTime _fecha_fin, string _moneda,
                                                           string _sucursal, string _tienda, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_CONSULTA_APLICACION_CC";
            List<SqlParameter> arParams = new List<SqlParameter>();

            arParams.Add(new SqlParameter("@FECHA_INICIO", _fecha_ini));
            arParams.Add(new SqlParameter("@FECHA_FINAL", _fecha_fin));
            arParams.Add(new SqlParameter("@MONEDA", _moneda));
            arParams.Add(new SqlParameter("@SUCURSAL", _sucursal));
            arParams.Add(new SqlParameter("@TIENDA", _tienda));
            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray()).Tables[0];
        }



        //ALTER PROCEDURE[PIMENTEL].[SP_APSSA_GET_ANALISTA_CC]
        //(@ANALISTA VARCHAR(25),
        //@DATOS VARCHAR(2),		-- SI-listado,  NO-count
        //@COMBO     VARCHAR(2),	-- SI-ANALISTA, NOMBRE / NO-varios campos
        //@ESTADO VARCHAR(50))	    -- I-inactivo A-activo ó NULL

        // 05/07/2018
        public static DataTable dtObtenerAnalistasCC_DL(string _anal, string _documento, string _combo, string _tipo, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_GET_ANALISTA_CC";
            List<SqlParameter> arParams = new List<SqlParameter>();

            arParams.Add(new SqlParameter("@ANALISTA", _anal));
            arParams.Add(new SqlParameter("@DATOS", _documento));
            arParams.Add(new SqlParameter("@COMBO", _combo));
            arParams.Add(new SqlParameter("@ESTADO", _tipo));

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray()).Tables[0];
        }

        //03/07/2018
        public static DataTable dtDocumentosClienteHistoricoDL(string contribuyente, string cliente, DateTime fecini, DateTime fecfin, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_CLIENTE_DOCUMENTOS_HISTORICO";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds_saldos = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CONTRIBUYENTE", contribuyente);
                    cmd.Parameters.AddWithValue("@CLIENTE", cliente);
                    cmd.Parameters.AddWithValue("@FECHA_INI", fecini);
                    cmd.Parameters.AddWithValue("@FECHA_FIN", fecfin);
                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    ds_saldos.Tables.Add(table);
                }
                return ds_saldos.Tables[0];
            }
        }



        //ALTER PROCEDURE[PIMENTEL].[SP_APSSA_LETRA_LUGAR_GIRO]
        //(@TIPO VARCHAR(3),
        //@DOCUMENTO VARCHAR(50))        
        public static DataTable dtObtenerLugarGiroLetra_DL(string _tipo, string _documento, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_LETRA_LUGAR_GIRO";
            List<SqlParameter> arParams = new List<SqlParameter>();

            arParams.Add(new SqlParameter("@TIPO", _tipo));
            arParams.Add(new SqlParameter("@DOCUMENTO", _documento));

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray()).Tables[0];
        }


        //ALTER PROCEDURE[PIMENTEL].[SP_APSSA_LETRA_IMPRIMIR]
        //(@CLIENTE VARCHAR(20),
        //@TIPO VARCHAR(3),
        //@DOCUMENTO VARCHAR(50))

        //27/06/2018
        public static DataTable dtObtenerDatosLetras_DL(string _cliente, string _tipo, string _documento, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_LETRA_IMPRIMIR";
            List<SqlParameter> arParams = new List<SqlParameter>();

            arParams.Add(new SqlParameter("@CLIENTE", _cliente));
            arParams.Add(new SqlParameter("@TIPO", _tipo));
            arParams.Add(new SqlParameter("@DOCUMENTO", _documento));

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray()).Tables[0];
        }


        //ALTER PROCEDURE [PIMENTEL].[SP_APSSA_COBRANZAS]
        //(@FECHA_INI DATE,
        // @FECHA_FIN DATE,
        // @TIENDA VARCHAR(3000),
        // @TMP_SQL_TOTAL  VARCHAR(250),
        // @TMP_SQL_CREDITO VARCHAR(250),
        // @TMP_SQL_TIPOABONO  VARCHAR(250),
        // @TMP_SQL_UNIDADNEG  VARCHAR(250),
        // @TMP_SQL_DIAS_DET  VARCHAR(250),
        // @TMP_SQL_DIAS_RES  VARCHAR(250))
        //AS

        //ALTER PROCEDURE [PIMENTEL].[SP_APSSA_TEMPORAL_RECUPERAR]
        //(@TEMPORAL_SQL  VARCHAR(250))
        //AS

        public static DataTable dtObtieneTablaCobranzaDL(string file_sql, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_TEMPORAL_RECUPERAR";
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
                }
                return ds.Tables[0];
            }
        }



        //12/09/2016
        public static DataSet dsObtenerTablasCobranzasDL(DateTime fecha1, DateTime fecha2, string zon, string fil1, string fil2, string fil3,
                                                             string fil4, string fil5, string fil6, string fil7, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                //string sqlCommand = "PIMENTEL.SP_APSSA_PRUEBA_BORRARV2";
                string sqlCommand = "PIMENTEL.SP_APSSA_COBRANZAS";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FECHA_INI", fecha1);
                    cmd.Parameters.AddWithValue("@FECHA_FIN", fecha2);
                    cmd.Parameters.AddWithValue("@TIENDA", zon);
                    cmd.Parameters.AddWithValue("@TMP_SQL_TOTAL", fil1);
                    cmd.Parameters.AddWithValue("@TMP_SQL_TIPOABONO", fil2);
                    cmd.Parameters.AddWithValue("@TMP_SQL_UNIDADNEG", fil3);
                    cmd.Parameters.AddWithValue("@TMP_SQL_CREDITO", fil4);
                    cmd.Parameters.AddWithValue("@TMP_SQL_LIQCRED", fil5);
                    cmd.Parameters.AddWithValue("@TMP_SQL_DIAS_DET", fil6);
                    cmd.Parameters.AddWithValue("@TMP_SQL_DIAS_RES", fil7);
                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();

                    DataTable table1 = new DataTable();
                    table1.Load(cmd.ExecuteReader());
                    ds.Tables.Add(table1);
                }
                return ds;
            }
        }


        //06/09/2016
        public static DataTable dtObtenerCobranzas_DL(DateTime fechaini, DateTime fechafin, string tienda, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_COBRANZAS";
            List<SqlParameter> arParams = new List<SqlParameter>();

            arParams.Add(new SqlParameter("@FECHA_INI", fechaini));
            arParams.Add(new SqlParameter("@FECHA_FIN", fechafin));
            arParams.Add(new SqlParameter("@TIENDA", tienda));

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray()).Tables[0];
        }



    }

    public class ReportesCreditosDL
    {
        public DataTable dtDocumentosClienteDL(DateTime vfechareporte, string vsucursal, string vzonas, string vcondicionpago, string db)
        {
            /*
            string strSql = "PIMENTEL.SP_APSSA_CREDITOSyCOBRANZA";
            List<SqlParameter> arParams = new List<SqlParameter>();

            arParams.Add(new SqlParameter("@FechaRep", vfechareporte));
            arParams.Add(new SqlParameter("@Sucursal", vsucursal));
            arParams.Add(new SqlParameter("@Zona", vzonas));
            arParams.Add(new SqlParameter("@ConPago", vcondicionpago));

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray()).Tables[0];

            */

            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_CREDITOSyCOBRANZA";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds_saldos = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FechaRep", vfechareporte);
                    cmd.Parameters.AddWithValue("@Sucursal", vsucursal);
                    cmd.Parameters.AddWithValue("@Zona", vzonas);
                    cmd.Parameters.AddWithValue("@ConPago", vcondicionpago);

                    //cmd.Parameters.AddWithValue("@CONTRIBUYENTE", contribuyente);

                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    ds_saldos.Tables.Add(table);
                }
                return ds_saldos.Tables[0];
            }




        }
        public DataTable Reporte_Detalle_abonos(DateTime fechaini, DateTime fechafin, string tienda, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_ABONOS_DETALLE";
            List<SqlParameter> arParams = new List<SqlParameter>();

            arParams.Add(new SqlParameter("@FECHA_INI", fechaini));
            arParams.Add(new SqlParameter("@FECHA_FIN", fechafin));
            arParams.Add(new SqlParameter("@TIENDA", tienda));


            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray()).Tables[0];
        }

    }
    public class Reportes_Saldos_vs_AbonosDL//ESTOS PROCEDIMIENTOS SON DEL SERVIDOR 2.17 DW_APSSA
    {
        public DataTable dtsaldos(DateTime fecha_inicial, DateTime fecha_final, string db)
        {
            string strSql = "SP_DW_APSSA_REPORTE_SALDOS";
            List<SqlParameter> arParams = new List<SqlParameter>();

            arParams.Add(new SqlParameter("@FECHA_INI", fecha_inicial));
            arParams.Add(new SqlParameter("@FECHA_FIN", fecha_final));

            //ConexionDC.ConectarBDDW ----->db==DW_APSSA
            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBDDW(db), CommandType.StoredProcedure, strSql, arParams.ToArray()).Tables[0];
        }

        public DataTable dtabonos(DateTime fecha_inicial, DateTime fecha_final, string db)
        {
            string strSql = "SP_DW_APSSA_REPORTE_ABONOS";
            List<SqlParameter> arParams = new List<SqlParameter>();

            arParams.Add(new SqlParameter("@FECHA_INI", fecha_inicial));
            arParams.Add(new SqlParameter("@FECHA_FIN", fecha_final));

            //ConexionDC.ConectarBDDW ----->db==DW_APSSA
            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBDDW(db), CommandType.StoredProcedure, strSql, arParams.ToArray()).Tables[0];
        }
        public DataTable dtsaldos_x_abonos(DateTime fecha_inicial, DateTime fecha_final, string db)
        {
            string strSql = "SP_DW_APSSA_REPORTE_ABONO_X_SALDO";
            List<SqlParameter> arParams = new List<SqlParameter>();

            arParams.Add(new SqlParameter("@FECHA_INI", fecha_inicial));
            arParams.Add(new SqlParameter("@FECHA_FIN", fecha_final));

            //ConexionDC.ConectarBDDW ----->db==DW_APSSA
            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBDDW(db), CommandType.StoredProcedure, strSql, arParams.ToArray()).Tables[0];
        }

    }


    public class EstadoCuentaDL
    {

        public DataTable dtCanjeLetrasClienteDL(string contribuyente, string cliente, DateTime fecini, DateTime fecfin, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_CLIENTE_CANJE_LETRAS";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds_saldos = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CONTRIBUYENTE", contribuyente);
                    cmd.Parameters.AddWithValue("@CLIENTE", cliente);
                    cmd.Parameters.AddWithValue("@FECHA_INI", fecini);
                    cmd.Parameters.AddWithValue("@FECHA_FIN", fecfin);

                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    ds_saldos.Tables.Add(table);
                }
                return ds_saldos.Tables[0];
            }
        }

        public DataTable dtSaldoDocumentosClienteDL(string contribuyente, string cliente, DateTime fecini, DateTime fecfin, string db)
        {

            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_CLIENTE_DOCUMENTOS_SALDOS";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds_saldos = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@CONTRIBUYENTE", contribuyente);
                    cmd.Parameters.AddWithValue("@CLIENTE", cliente);
                    cmd.Parameters.AddWithValue("@FECHA_INI", fecini);
                    cmd.Parameters.AddWithValue("@FECHA_FIN", fecfin);

                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    ds_saldos.Tables.Add(table);
                }
                return ds_saldos.Tables[0];
            }
        }

        public DataTable dtSaldoClienteDL(string cliente, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_CLIENTE_SALDOS";
            List<SqlParameter> arParams = new List<SqlParameter>();

            arParams.Add(new SqlParameter("@CLIENTE", cliente));

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray()).Tables[0];
        }

        public DataTable dtInformacionClienteDL(string cliente, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_CLIENTE_DATOS";
            List<SqlParameter> arParams = new List<SqlParameter>();

            arParams.Add(new SqlParameter("@CLIENTE", cliente));

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray()).Tables[0];
        }

        public DataTable dtLetrasEstadoClienteDL(string cliente, DateTime fecfin, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_CLIENTE_ESTADO_LETRAS";
            List<SqlParameter> arParams = new List<SqlParameter>();

            arParams.Add(new SqlParameter("@CLIENTE", cliente));
            arParams.Add(new SqlParameter("@FECHAREP", fecfin));

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray()).Tables[0];
        }


    }


}
