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
    public class ComercialDL
    {

        public static bool EliminarArticuloWebDL(string _articulo, string db)
        {
            int NumReg = 0;
            string strSql = @"DELETE FROM PIMENTEL.APSSA_ARTICULO_WEB WHERE ARTICULO=@ARTICULO; ";

            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@ARTICULO", _articulo));

            NumReg = Convert.ToInt32(SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray()));

            return NumReg > 0;
        }

        public static bool VerificarSiYaEstaRegistradoIdProductWebDL(string id_prod, string db)
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

        public static bool VerificarSiYaEstaRegistradoArticuloWebDL(string art, string db)
        {
            int NumReg = 0;
            string strSql = @"SELECT COUNT(*) 
                              FROM PIMENTEL.APSSA_ARTICULO_WEB (NOLOCK)
                              WHERE ARTICULO = @ARTICULO";

            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@ARTICULO", art));

            NumReg = Convert.ToInt32(SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray()));
            return NumReg > 0;
        }

        //ALTER PROCEDURE[PIMENTEL].[SP_APSSA_ARTICULO_WEB_UPDATE_ARTICULO]
        //(@TIPO_OPERACION VARCHAR(1),
        //@ARTICULO VARCHAR(20) ,
        //@ID_PRODUCT INT,
        //@DESCRIPCION VARCHAR(254) ,
        //@UNIDAD VARCHAR(6) ,
        //@EX_STOCK DECIMAL(12, 2) ,
        //@EX_PRECIO DECIMAL(12, 2) ,
        //@PS_STOCK DECIMAL(12, 2) ,
        //@PS_PRECIO DECIMAL(12, 2) ,
        //@CARGA_STOCK DECIMAL(12, 2) ,
        //@CARGA_PRECIO DECIMAL(12, 2) ,
        //@ATRIBUTO1 DECIMAL(12, 2) ,
        //@ATRIBUTO2 DECIMAL(12, 2) ,
        //@ATRIBUTO3 DECIMAL(12, 2) ,
        //@ATRIBUTO4 DECIMAL(12, 2) ,
        //@ATRIBUTO5 DECIMAL(12, 2) ,
        //@EXISTE VARCHAR(1) ,
        //@ACTIVO VARCHAR(1) ,
        //@OBSERVACIONES TEXT,
        //@USUARIO VARCHAR(25) ,
        //@FECHA_PROCESO DATETIME)

        public static void ActualizarArticulosWebDL(string _tipo_operacion, string _articulo, Int16 _id_product, string _descripcion, string _unidad,
                            Decimal _ex_stock, Decimal _ex_precio, Decimal _ps_stock, Decimal _ps_precio, Decimal _carga_stock, Decimal _carga_precio,
                            Decimal _atributo1, Decimal _atributo2, Decimal _atributo3, Decimal _atributo4, Decimal _atributo5,
                            string _existe, string _activo, string _observaciones, string _usuario, DateTime _fecha_proceso, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_ARTICULO_WEB_UPDATE_ARTICULO";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@TIPO_OPERACION", _tipo_operacion));
            arParams.Add(new SqlParameter("@ARTICULO", _articulo));
            arParams.Add(new SqlParameter("@ID_PRODUCT", _id_product));
            arParams.Add(new SqlParameter("@DESCRIPCION", _descripcion));
            arParams.Add(new SqlParameter("@UNIDAD", _unidad));
            arParams.Add(new SqlParameter("@EX_STOCK", _ex_stock));
            arParams.Add(new SqlParameter("@EX_PRECIO", _ex_precio));
            arParams.Add(new SqlParameter("@PS_STOCK", _ps_stock));
            arParams.Add(new SqlParameter("@PS_PRECIO", _ps_precio));
            arParams.Add(new SqlParameter("@CARGA_STOCK", _carga_stock));
            arParams.Add(new SqlParameter("@CARGA_PRECIO", _carga_precio));
            arParams.Add(new SqlParameter("@ATRIBUTO1", _atributo1));
            arParams.Add(new SqlParameter("@ATRIBUTO2", _atributo2));
            arParams.Add(new SqlParameter("@ATRIBUTO3", _atributo3));
            arParams.Add(new SqlParameter("@ATRIBUTO4", _atributo4));
            arParams.Add(new SqlParameter("@ATRIBUTO5", _atributo5));
            arParams.Add(new SqlParameter("@EXISTE", _existe));
            arParams.Add(new SqlParameter("@ACTIVO", _activo));
            arParams.Add(new SqlParameter("@OBSERVACIONES", _observaciones));
            arParams.Add(new SqlParameter("@USUARIO", _usuario));
            arParams.Add(new SqlParameter("@FECHA_PROCESO", _fecha_proceso));

            SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray());


            //SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql);
        }


        //ALTER PROCEDURE [PIMENTEL].[SP_APSSA_ARTICULO_WEB_UPDATE_TABLA]
        public static void ActualizarTablaArticulosWebDL(string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_ARTICULO_WEB_UPDATE_TABLA";

            List<SqlParameter> arParam = new List<SqlParameter>();

            SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql);
        }


        public static void GrabarArticulosWebTemporalDL(string v_articulo, Int16 v_id_product, string v_descripcion, string v_unidad, Decimal v_ex_stock,
                                                        Decimal v_ex_precio, Decimal v_ps_stock, Decimal v_ps_precio, Decimal v_carga_stock, Decimal v_carga_precio,
                                                        Decimal v_atributo1, Decimal v_atributo2, Decimal v_atributo3, Decimal v_atributo4, Decimal v_atributo5,
                                                        string v_existe, string v_activo, string v_observaciones, string v_usuario, DateTime v_fecha_proceso, string db)
        {
            string strSql = @"INSERT INTO PIMENTEL.APSSA_ARTICULO_WEB_TEMP                            
	                            (ARTICULO,ID_PRODUCT,DESCRIPCION,UNIDAD,EX_STOCK,EX_PRECIO,PS_STOCK,PS_PRECIO,
                                CARGA_STOCK,CARGA_PRECIO,ATRIBUTO1,ATRIBUTO2,ATRIBUTO3,ATRIBUTO4,ATRIBUTO5,
                                EXISTE,ACTIVO,OBSERVACIONES,USUARIO,FECHA_PROCESO)
	                            VALUES
	                            (@ARTICULO,@ID_PRODUCT,@DESCRIPCION,@UNIDAD,@EX_STOCK,@EX_PRECIO,@PS_STOCK,@PS_PRECIO,
                                @CARGA_STOCK,@CARGA_PRECIO,@ATRIBUTO1,@ATRIBUTO2,@ATRIBUTO3,@ATRIBUTO4,@ATRIBUTO5,
                                @EXISTE,@ACTIVO,@OBSERVACIONES,@USUARIO,@FECHA_PROCESO); ";

            List<SqlParameter> arParam = new List<SqlParameter>();

            arParam.Add(new SqlParameter("@ARTICULO", v_articulo));
            arParam.Add(new SqlParameter("@ID_PRODUCT", v_id_product));
            arParam.Add(new SqlParameter("@DESCRIPCION", v_descripcion));
            arParam.Add(new SqlParameter("@UNIDAD", v_unidad));
            arParam.Add(new SqlParameter("@EX_STOCK", v_ex_stock));
            arParam.Add(new SqlParameter("@EX_PRECIO", v_ex_precio));
            arParam.Add(new SqlParameter("@PS_STOCK", v_ps_stock));
            arParam.Add(new SqlParameter("@PS_PRECIO", v_ps_precio));
            arParam.Add(new SqlParameter("@CARGA_STOCK", v_carga_stock));
            arParam.Add(new SqlParameter("@CARGA_PRECIO", v_carga_precio));
            arParam.Add(new SqlParameter("@ATRIBUTO1", v_atributo1));
            arParam.Add(new SqlParameter("@ATRIBUTO2", v_atributo2));
            arParam.Add(new SqlParameter("@ATRIBUTO3", v_atributo3));
            arParam.Add(new SqlParameter("@ATRIBUTO4", v_atributo4));
            arParam.Add(new SqlParameter("@ATRIBUTO5", v_atributo5));
            arParam.Add(new SqlParameter("@EXISTE", v_existe));
            arParam.Add(new SqlParameter("@ACTIVO", v_activo));
            arParam.Add(new SqlParameter("@OBSERVACIONES", v_observaciones));
            arParam.Add(new SqlParameter("@USUARIO", v_usuario));
            arParam.Add(new SqlParameter("@FECHA_PROCESO", v_fecha_proceso));

            SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray());
        }


        public static void EliminarArticulosWebTemporalDL(string db)
        {
            string strSql = @" DELETE FROM PIMENTEL.APSSA_ARTICULO_WEB_TEMP; ";

            SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql);
        }

        public static DataTable dtObtenerDatosArticulosWebTemporalDL(string db)
        {
            string strSql = @" SELECT 
                               ARTICULO,ID_PRODUCT,DESCRIPCION,UNIDAD,EX_STOCK,EX_PRECIO,PS_STOCK,PS_PRECIO,
                               CARGA_STOCK,CARGA_PRECIO,ATRIBUTO1,ATRIBUTO2,ATRIBUTO3,ATRIBUTO4,ATRIBUTO5,
                               EXISTE,ACTIVO,OBSERVACIONES
                               FROM PIMENTEL.APSSA_ARTICULO_WEB_TEMP (NOLOCK)
                               ORDER BY 2 ASC";

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql).Tables[0];
        }


        public static DataTable dtObtenerDatosArticulosWebDL(string db)
        {
            string strSql = @" SELECT 
                               ARTICULO,ID_PRODUCT,DESCRIPCION,UNIDAD,EX_STOCK,EX_PRECIO,PS_STOCK,PS_PRECIO,
                               CARGA_STOCK,CARGA_PRECIO,ATRIBUTO1,ATRIBUTO2,ATRIBUTO3,ATRIBUTO4,ATRIBUTO5,
                               EXISTE,ACTIVO,OBSERVACIONES,USUARIO,FECHA_PROCESO
                               FROM PIMENTEL.APSSA_ARTICULO_WEB (NOLOCK)
                               ORDER BY 2 ASC";

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql).Tables[0];

         }


        //******************************************************************************************

        //ALTER PROCEDURE[PIMENTEL].[SP_APSSA_FACTURACION_GENERAL]
        //(@REP_ANNO INT,
        //@REP_MES INT,
        //@REP_TIPO VARCHAR(1),		-- 'D' -- detalle,  'R' -- resumen
        //@REP_DEVOLUCIONES BIT)		--  1 = INCLUYE /* True */  , 0 = NO INCLUYE /* False */

        public static DataTable dtObtieneFacturacionGeneralDL(string _anno, Int32 _mes, string _tipo, Int32 _incluyedevol, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_FACTURACION_GENERAL";

                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@REP_ANNO", _anno);
                    cmd.Parameters.AddWithValue("@REP_MES", _mes);
                    cmd.Parameters.AddWithValue("@REP_TIPO", _tipo);
                    cmd.Parameters.AddWithValue("@REP_DEVOLUCIONES", _incluyedevol);
                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    ds.Tables.Add(table);
                }
                return ds.Tables[0];
            }
        }


        public static DataTable dtDiferenciaCambiariaCabeceraDL(Int32 _mes, string _anno, string _tipo, string _m, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_DIF_CAMBIARIA_DOCUMENTOS";

                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MES", _mes);
                    cmd.Parameters.AddWithValue("@ANNO", _anno);
                    cmd.Parameters.AddWithValue("@TIPO", _tipo);
                    cmd.Parameters.AddWithValue("@M", _m);
                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    ds.Tables.Add(table);
                }
                return ds.Tables[0];
            }
        }


        public static DataTable dtDiferenciaCambiariaDetalleDL(Int32 _mes, string _anno, string _tipo, string _m, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_DIF_CAMBIARIA_DOCUMENTOS";

                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@MES", _mes);
                    cmd.Parameters.AddWithValue("@ANNO", _anno);
                    cmd.Parameters.AddWithValue("@TIPO", _tipo);
                    cmd.Parameters.AddWithValue("@M", _m);
                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    ds.Tables.Add(table);
                }
                return ds.Tables[0];
            }
        }



        public static DataTable dtDiferenciaCambiariaAsientoDL(string _asiento, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_DIF_CAMBIARIA_ASIENTO";

                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ASIENTO", _asiento);
                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    ds.Tables.Add(table);
                }
                return ds.Tables[0];

            }
        }

        
        

        public static DataTable dtObtieneFacturacionGeneralDetalleDL(string _anno, Int32 _mes, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_FACTURACION_GENERAL_DETALLE";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ANNO_REPORTE", _anno);
                    cmd.Parameters.AddWithValue("@MES_REPORTE", _mes);
                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    ds.Tables.Add(table);
                }
                return ds.Tables[0];
            }
        }

        public static DataTable dtObtieneFacturacionHistoricaDetalleDL(string _anno, Int32 _mes, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_FACTURACION_GENERAL_HISTORICO";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ANNO_REPORTE", _anno);
                    cmd.Parameters.AddWithValue("@MES_REPORTE", _mes);
                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    ds.Tables.Add(table);
                }
                return ds.Tables[0];
            }
        }


        //******************************************************************************************





        public static DataTable dtObtenerFacturasPDF_DL(string db)
        {
            //string strSql = @"
            //                SELECT TIPO_DOC AS TIPO, DOCUMENTO AS FACTURA, 'xx@msn.com' as E_MAIL,
            //                *
            //                FROM DBO.BORRAR_PROMO_GY WITH (NOLOCK)
            //                ORDER BY FECHA_DOC, TIPO_DOC, DOCUMENTO  ";

            string strSql = @"
                            SELECT TIPO, FACTURA, E_MAIL
                            FROM PIMENTEL.APSSA_FACTURA_PDF WITH (NOLOCK)
                            ORDER BY TIPO, FACTURA  ";

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql).Tables[0];
        }




        /*
        ALTER PROCEDURE [PIMENTEL].[SP_APSSA_REPORTE_VENTAS_DIARIA_V2]
        (@REP_ANNO VARCHAR(4),
         @REP_MES INT,
         @REP_TIPO VARCHAR(1),
         @USUARIO VARCHAR(25),			-- USUARIO
         @PERFIL VARCHAR(100),			-- NULL, CENTRO_SUR, NORTE
         @REP_TIENDA VARCHAR(1500))		-- R-resumen, D-detalle
        */

        // 21/10/2016
        // SELECT * FROM PIMENTEL.APSSA_USUARIO_PREFERENCIA  WHERE USUARIO='MCABANILLASS' AND VALOR='NORTE'

        public static string UsuarioPreferenciaZonaDL(string _user, string _tipo, string db)
        {
            string cZonas = string.Empty;
            string strSql = @" SELECT 
                               PIMENTEL.FN_GET_USUARIO_ZONAS(@USUARIO, @TIPO) ";

            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@USUARIO", _user));
            arParam.Add(new SqlParameter("@TIPO", _tipo));

            cZonas = Convert.ToString(SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray()));
            return cZonas;
        }

        public static string UsuarioPreferenciaSucursalDL(string _user, string _tipo, string db)
        {
            string cSucursales = string.Empty;
            string strSql = @" SELECT 
                               PIMENTEL.FN_GET_USUARIO_SUCURSALES(@USUARIO, @TIPO) ";
            //FROM PIMENTEL.APSSA_USUARIO_PREFERENCIA WITH (NOLOCK)
            //WHERE USUARIO=@USUARIO AND VALOR=@PERFIL 

            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@USUARIO", _user));
            arParam.Add(new SqlParameter("@TIPO", _tipo));

            cSucursales = Convert.ToString(SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray()));
            return cSucursales;
        }

        public static bool UsuarioTienePerfilDL(string _user, string _perfil, string db)
        {
            int NumReg = 0;
            string strSql = @" SELECT COUNT(*) 
                               FROM PIMENTEL.APSSA_USUARIO_PREFERENCIA WITH (NOLOCK)
                               WHERE USUARIO=@USUARIO AND VALOR=@PERFIL ";

            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@USUARIO", _user));
            arParam.Add(new SqlParameter("@PERFIL", _perfil));

            NumReg = Convert.ToInt32(SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray()));
            return NumReg > 0;
        }

        public static DataTable dtObtieneVentaDiariaV3DL(string _anno, Int32 _mes, string _tipo, string _user, string _perfil, string _tienda, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_REPORTE_VENTAS_DIARIA_V3";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@REP_ANNO", _anno);
                    cmd.Parameters.AddWithValue("@REP_MES", _mes);
                    cmd.Parameters.AddWithValue("@REP_TIPO", _tipo);
                    cmd.Parameters.AddWithValue("@USUARIO", _user);
                    cmd.Parameters.AddWithValue("@PERFIL", _perfil);
                    cmd.Parameters.AddWithValue("@REP_TIENDA", _tienda);
                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    ds.Tables.Add(table);
                }
                return ds.Tables[0];
            }
        }


        public static DataTable dtObtieneVentaDiariaV2DL(string _anno, Int32 _mes, string _tipo, string _user, string _perfil, string _tienda, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_REPORTE_VENTAS_DIARIA_V2";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@REP_ANNO", _anno);
                    cmd.Parameters.AddWithValue("@REP_MES", _mes);
                    cmd.Parameters.AddWithValue("@REP_TIPO", _tipo);
                    cmd.Parameters.AddWithValue("@USUARIO", _user);
                    cmd.Parameters.AddWithValue("@PERFIL", _perfil);
                    cmd.Parameters.AddWithValue("@REP_TIENDA", _tienda);
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
        // 16/06/2017 avila 
        public static DataTable Lista_venta_llantas_DL(string _tienda, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_VENTA_LLANTAS_6_MESES";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@tienda", _tienda);
                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    ds.Tables.Add(table);
                }
                return ds.Tables[0];
            }
        }



        public static DataTable dtObtieneVentaDiariaDL(string _anno, Int32 _mes, string _tipo, string _tienda, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_REPORTE_VENTAS_DIARIA";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@REP_ANNO", _anno);
                    cmd.Parameters.AddWithValue("@REP_MES", _mes);
                    cmd.Parameters.AddWithValue("@REP_TIPO", _tipo);
                    cmd.Parameters.AddWithValue("@REP_TIENDA", _tienda);
                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    ds.Tables.Add(table);
                }
                return ds.Tables[0];
            }
        }

        

        public static DataTable dtObtieneCuotaGY_DL(Int32 _anno, Int32 _mes, string _usuario, string _tienda, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_CARGA_CUOTA_COMPRA";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ANNO", _anno);
                    cmd.Parameters.AddWithValue("@MES", _mes);
                    cmd.Parameters.AddWithValue("@USUARIO", _usuario);
                    cmd.Parameters.AddWithValue("@TIENDA", _tienda);
                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    ds.Tables.Add(table);
                }
                return ds.Tables[0];
            }
        }


        public static DataTable dtObtieneDataGY_DL(Int32 _anno, Int32 _mes, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_CARGA_CUOTA_COMPRA_DATA";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ANNO", _anno);
                    cmd.Parameters.AddWithValue("@MES", _mes);
                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    ds.Tables.Add(table);
                }
                return ds.Tables[0];
            }
        }







        public static DataTable dtObtenerBodegasPorUsuarioDL(string usu, string db)
        {
            string strSql = @"
                            SELECT LTRIM(RTRIM(B.BODEGA)) AS BODEGA,LTRIM(RTRIM(B.NOMBRE)) AS NOMBRE 
                            FROM PIMENTEL.BODEGA B WITH (NOLOCK)
                            WHERE B.BODEGA NOT IN ('ND')
	                            AND B.BODEGA IN (SELECT U_BODEGA FROM PIMENTEL.U_USUARIO_BODEGA WITH (NOLOCK) WHERE U_USUARIO=@USUARIO)
                            ";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@USUARIO", usu));

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParams.ToArray()).Tables[0];
        }


        public static DataTable dtObtenerMovimientosPorArticuloDL(DateTime fini, DateTime ffin, string bod, string fam, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_TRANSACCIONES_ARTICULO";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@FECHA_INI", fini));
            arParams.Add(new SqlParameter("@FECHA_FIN", ffin));
            arParams.Add(new SqlParameter("@BODEGA", bod));
            arParams.Add(new SqlParameter("@FAMILIA", fam));

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray()).Tables[0];
        }

        // AVILA 03/10/2017
        public static DataTable dtObtenerDetraccionesDL(string fini, string db)
        {
            string strSql = "pimentel.sp_apssa_detraccion_txt";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@ffin", fini));

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray()).Tables[0];
        }

        // AVILA 03/11/2017
        public static DataTable dtObtenerPagoProveedoresDL(string fcuenta, string ftrans, string fbanco, string db)
        {
            string strSql = "pimentel.sp_apssa_pago_proveedores_txt";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@fcuenta", fcuenta));
            arParams.Add(new SqlParameter("@ftrans", ftrans));
            arParams.Add(new SqlParameter("@fbanco", fbanco));

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray()).Tables[0];
        }

        public static DataTable dtObtenerPagoProveedoresDL2(string fcuenta, string ftrans, string freferencia, string ffecha, string fbanco, string db)
        {
            string strSql = "pimentel.sp_apssa_pago_proveedores_txt2";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@cuenta", fcuenta));
            arParams.Add(new SqlParameter("@transfe", ftrans));
            arParams.Add(new SqlParameter("@referencia", freferencia));
            arParams.Add(new SqlParameter("@fecha", ffecha));
            arParams.Add(new SqlParameter("@fbanco", fbanco));
            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray()).Tables[0];
        }

        public static DataTable dtObtener_aplicacionesDL(string fini, string ffin, string fproveedor, string db)
        {
            string strSql = "pimentel.sp_apssa_aplicaciones_cp";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@fini", fini));
            arParams.Add(new SqlParameter("@ffin", ffin));
            arParams.Add(new SqlParameter("@mproveedor", fproveedor));
            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray()).Tables[0];
        }



        #region FACTURACION

        public static DataTable dtObtieneTablaTemporal_DL(string file_sql, string db)
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

        public static DataSet dsObtenerTablasFacturacion_DL(DateTime fecha1, DateTime fecha2, string fil1, string fil2, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_REPGER_FACTURACION";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FECHAINI", fecha1);
                    cmd.Parameters.AddWithValue("@FECHAFIN", fecha2);
                    cmd.Parameters.AddWithValue("@TMP_SQL_DET", fil1);
                    cmd.Parameters.AddWithValue("@TMP_SQL_RES", fil2);
                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();

                    DataTable table1 = new DataTable();
                    table1.Load(cmd.ExecuteReader());
                    ds.Tables.Add(table1);
                }
                return ds;
            }
        } 


        #endregion
        

        #region CUOTA_VENTAS


        // 27/04/2016
        //-------------------------------------------------------------------------------------------

        public static DataTable dtListarVendedoresCuotasFiltradoDL(string zon, string db)
        {
            string strSql = @"SELECT 
                              V.VENDEDOR, V.NOMBRE  FROM PIMENTEL.VENDEDOR V
                              WHERE V.VENDEDOR NOT IN ('ND') AND V.ACTIVO='S' 
                                AND (V.U_ZONA
                                     IN (SELECT LTRIM(RTRIM(Item)) as item FROM Pimentel.Fn_APPSA_Split(@ZONA, ',')))
                              ORDER BY V.NOMBRE; ";
            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@ZONA", zon));
            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParams.ToArray()).Tables[0];
        }


        public static DataTable dtListarTablaClientes2DL(string zon, string act, string ven, string cli, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_BUSCA_CLIENTE";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@ZONA", zon));
            arParams.Add(new SqlParameter("@ACTIVO", act));
            arParams.Add(new SqlParameter("@VENDEDOR", ven));
            arParams.Add(new SqlParameter("@CLIENTE", cli));

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray()).Tables[0];
        }

        public static DataTable dtListarTablaVendedores2DL(string zon, string act, string ven, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_BUSCA_VENDEDOR";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@ZONA", zon));
            arParams.Add(new SqlParameter("@ACTIVO", act));
            arParams.Add(new SqlParameter("@VENDEDOR", ven));

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray()).Tables[0];
        }

        //-------------------------------------------------------------------------------------------


        // 13/04/2016
        public static void EliminarCuotaCentroCostoDL(Int32 id, string cc, string tie, Decimal uni, Decimal mon, string mone, string db)
        {
            string strSql = @"UPDATE PIMENTEL.APSSA_CUOTA_VENTAS_CENTRO_COSTO 
                              SET
                              UNIDADES = @UNIDADES, 
                              MONTO = @MONTO
                              WHERE IDPERIODO=@IDPERIODO AND CENTRO_COSTO=@CENTRO_COSTO AND TIENDA=@TIENDA AND MONEDA=@MONEDA; ";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@IDPERIODO", id));
            arParams.Add(new SqlParameter("@CENTRO_COSTO", cc));
            arParams.Add(new SqlParameter("@TIENDA", tie));
            arParams.Add(new SqlParameter("@UNIDADES", uni));
            arParams.Add(new SqlParameter("@MONTO", mon));
            arParams.Add(new SqlParameter("@MONEDA", mone));

            SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParams.ToArray());
        }


        public static void UpdateCuotaCentroCostoDL(Int32 id, string cc, string tie, Decimal uni, Decimal mon, string mone, string db)
        {
            string strSql = @"UPDATE PIMENTEL.APSSA_CUOTA_VENTAS_CENTRO_COSTO 
                              SET
                              UNIDADES = @UNIDADES, 
                              MONTO = @MONTO
                              WHERE IDPERIODO=@IDPERIODO AND CENTRO_COSTO=@CENTRO_COSTO AND TIENDA=@TIENDA AND MONEDA=@MONEDA; ";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@IDPERIODO", id));
            arParams.Add(new SqlParameter("@CENTRO_COSTO", cc));
            arParams.Add(new SqlParameter("@TIENDA", tie));
            arParams.Add(new SqlParameter("@UNIDADES", uni));
            arParams.Add(new SqlParameter("@MONTO", mon));
            arParams.Add(new SqlParameter("@MONEDA", mone));

            SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParams.ToArray());
        }

        public static void InsertarCuotaCentroCostoDL(Int32 id, DateTime fi, DateTime ff, string cc, string tie, string tie_nom, Decimal uni, Decimal mon, string mone, string db)
        {
            string strSql = @"INSERT INTO PIMENTEL.APSSA_CUOTA_VENTAS_CENTRO_COSTO 
                                (IDPERIODO,FECHA_INICIO,FECHA_FINAL,CENTRO_COSTO,TIENDA,TIENDA_DESCRIPCION,UNIDADES,MONTO,MONEDA)
                                VALUES
                                (@IDPERIODO,@FECHA_INICIO,@FECHA_FINAL,@CENTRO_COSTO,@TIENDA,@TIENDA_DESCRIPCION,@UNIDADES,@MONTO,@MONEDA)
                            ";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@IDPERIODO", id));
            arParams.Add(new SqlParameter("@FECHA_INICIO", fi));
            arParams.Add(new SqlParameter("@FECHA_FINAL", ff));
            arParams.Add(new SqlParameter("@CENTRO_COSTO", cc));
            arParams.Add(new SqlParameter("@TIENDA", tie));
            arParams.Add(new SqlParameter("@TIENDA_DESCRIPCION", tie_nom));
            arParams.Add(new SqlParameter("@UNIDADES", uni));
            arParams.Add(new SqlParameter("@MONTO", mon));
            arParams.Add(new SqlParameter("@MONEDA", mone));

            SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParams.ToArray());
        }


        public static void EliminarCuotaClienteDL(Int32 id, string cc, string tie, string ven, string cli, string mone, string db)
        {
            string strSql = @" DELETE FROM PIMENTEL.APSSA_CUOTA_VENTAS_CLIENTE                          
                               WHERE IDPERIODO=@IDPERIODO AND CENTRO_COSTO=@CENTRO_COSTO AND TIENDA=@TIENDA
                                     AND VENDEDOR=@VENDEDOR  AND CLIENTE=@CLIENTE AND MONEDA=@MONEDA; ";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@IDPERIODO", id));
            arParams.Add(new SqlParameter("@CENTRO_COSTO", cc));
            arParams.Add(new SqlParameter("@TIENDA", tie));
            arParams.Add(new SqlParameter("@VENDEDOR", ven));
            arParams.Add(new SqlParameter("@CLIENTE", cli));
            arParams.Add(new SqlParameter("@MONEDA", mone));

            SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParams.ToArray());
        }

        public static void EliminarCuotaVendedorDL(Int32 id, string cc, string tie, string ven, string mone, string db)
        {
            string strSql = @" DELETE FROM PIMENTEL.APSSA_CUOTA_VENTAS_VENDEDOR                         
                               WHERE IDPERIODO=@IDPERIODO AND CENTRO_COSTO=@CENTRO_COSTO 
                                    AND TIENDA=@TIENDA AND VENDEDOR=@VENDEDOR  AND MONEDA=@MONEDA; ";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@IDPERIODO", id));
            arParams.Add(new SqlParameter("@CENTRO_COSTO", cc));
            arParams.Add(new SqlParameter("@TIENDA", tie));
            arParams.Add(new SqlParameter("@VENDEDOR", ven));
            arParams.Add(new SqlParameter("@MONEDA", mone));

            SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParams.ToArray());
        }


        public static void UpdateCuotaClienteDL(Int32 id, string cc, string tie, string ven, string cli, Decimal uni, Decimal mon, string mone, string db)
        {
            string strSql = @"UPDATE PIMENTEL.APSSA_CUOTA_VENTAS_CLIENTE
                              SET
                              UNIDADES = @UNIDADES, 
                              MONTO = @MONTO
                              WHERE IDPERIODO=@IDPERIODO AND CENTRO_COSTO=@CENTRO_COSTO AND TIENDA=@TIENDA
                                     AND VENDEDOR=@VENDEDOR  AND CLIENTE=@CLIENTE AND MONEDA=@MONEDA; ";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@IDPERIODO", id));
            arParams.Add(new SqlParameter("@CENTRO_COSTO", cc));
            arParams.Add(new SqlParameter("@TIENDA", tie));
            arParams.Add(new SqlParameter("@VENDEDOR", ven));
            arParams.Add(new SqlParameter("@CLIENTE", cli));
            arParams.Add(new SqlParameter("@UNIDADES", uni));
            arParams.Add(new SqlParameter("@MONTO", mon));
            arParams.Add(new SqlParameter("@MONEDA", mone));

            SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParams.ToArray());
        }

        public static void InsertarCuotaClienteDL(Int32 id, DateTime fi, DateTime ff, string cc, string tie, string tie_nom,
                                                   string ven, string ven_nom, string cli, string cli_nom, Decimal uni, Decimal mon, string mone, string db)
        {
            string strSql = @"INSERT INTO PIMENTEL.APSSA_CUOTA_VENTAS_CLIENTE                            
	                         (IDPERIODO,FECHA_INICIO, FECHA_FINAL, CENTRO_COSTO, TIENDA, TIENDA_DESCRIPCION, 
                              VENDEDOR, VENDEDOR_NOMBRE, CLIENTE, CLIENTE_NOMBRE,UNIDADES, MONTO,MONEDA)
	                         VALUES
	                         (@IDPERIODO,@FECHA_INICIO, @FECHA_FINAL, @CENTRO_COSTO, @TIENDA, @TIENDA_DESCRIPCION, 
                              @VENDEDOR, @VENDEDOR_NOMBRE, @CLIENTE, @CLIENTE_NOMBRE, @UNIDADES, @MONTO,@MONEDA)
                            ";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@IDPERIODO", id));
            arParams.Add(new SqlParameter("@FECHA_INICIO", fi));
            arParams.Add(new SqlParameter("@FECHA_FINAL", ff));
            arParams.Add(new SqlParameter("@CENTRO_COSTO", cc));
            arParams.Add(new SqlParameter("@TIENDA", tie));
            arParams.Add(new SqlParameter("@TIENDA_DESCRIPCION", tie_nom));
            arParams.Add(new SqlParameter("@VENDEDOR", ven));
            arParams.Add(new SqlParameter("@VENDEDOR_NOMBRE", ven_nom));
            arParams.Add(new SqlParameter("@CLIENTE", cli));
            arParams.Add(new SqlParameter("@CLIENTE_NOMBRE", cli_nom));
            arParams.Add(new SqlParameter("@UNIDADES", uni));
            arParams.Add(new SqlParameter("@MONTO", mon));
            arParams.Add(new SqlParameter("@MONEDA", mone));

            SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParams.ToArray());
        }


        public static void UpdateCuotaVendedorDL(Int32 id, string cc, string tie, string ven, Decimal uni, Decimal mon, string mone, string db)
        {
            string strSql = @"UPDATE PIMENTEL.APSSA_CUOTA_VENTAS_VENDEDOR
                              SET
                              UNIDADES = @UNIDADES, 
                              MONTO = @MONTO
                              WHERE IDPERIODO=@IDPERIODO AND CENTRO_COSTO=@CENTRO_COSTO 
                                    AND TIENDA=@TIENDA AND VENDEDOR=@VENDEDOR  AND MONEDA=@MONEDA; ";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@IDPERIODO", id));
            arParams.Add(new SqlParameter("@CENTRO_COSTO", cc));
            arParams.Add(new SqlParameter("@TIENDA", tie));
            arParams.Add(new SqlParameter("@VENDEDOR", ven));
            arParams.Add(new SqlParameter("@UNIDADES", uni));
            arParams.Add(new SqlParameter("@MONTO", mon));
            arParams.Add(new SqlParameter("@MONEDA", mone));

            SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParams.ToArray());
        }

        public static void InsertarCuotaVendedorDL(Int32 id, DateTime fi, DateTime ff, string cc, string tie, string tie_nom,
                                                   string ven, string ven_nom, Decimal uni, Decimal mon, string mone, string db)
        {
            string strSql = @"INSERT INTO PIMENTEL.APSSA_CUOTA_VENTAS_VENDEDOR                            
	                         (IDPERIODO,FECHA_INICIO, FECHA_FINAL, CENTRO_COSTO, TIENDA, TIENDA_DESCRIPCION, 
                              VENDEDOR, VENDEDOR_NOMBRE, UNIDADES, MONTO,MONEDA)
	                         VALUES
	                         (@IDPERIODO,@FECHA_INICIO, @FECHA_FINAL, @CENTRO_COSTO, @TIENDA, @TIENDA_DESCRIPCION, 
                              @VENDEDOR, @VENDEDOR_NOMBRE, @UNIDADES, @MONTO,@MONEDA)
                            ";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@IDPERIODO", id));
            arParams.Add(new SqlParameter("@FECHA_INICIO", fi));
            arParams.Add(new SqlParameter("@FECHA_FINAL", ff));
            arParams.Add(new SqlParameter("@CENTRO_COSTO", cc));
            arParams.Add(new SqlParameter("@TIENDA", tie));
            arParams.Add(new SqlParameter("@TIENDA_DESCRIPCION", tie_nom));
            arParams.Add(new SqlParameter("@VENDEDOR", ven));
            arParams.Add(new SqlParameter("@VENDEDOR_NOMBRE", ven_nom));
            arParams.Add(new SqlParameter("@UNIDADES", uni));
            arParams.Add(new SqlParameter("@MONTO", mon));
            arParams.Add(new SqlParameter("@MONEDA", mone));

            SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParams.ToArray());
        }



        public static DataTable CargaDatosClienteDL(string cli, string db)
        {
            string strSql = @"SELECT CLIENTE, NOMBRE
                              FROM PIMENTEL.CLIENTE
                              WHERE CLIENTE=@CLIENTE; ";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@CLIENTE", cli));

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParams.ToArray()).Tables[0];
        }

        public static DataTable CargaDatosVendedorDL(string ven, string db)
        {
            string strSql = @"SELECT VENDEDOR, NOMBRE
                              FROM PIMENTEL.VENDEDOR
                              WHERE VENDEDOR = @VENDEDOR";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@VENDEDOR", ven));

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParams.ToArray()).Tables[0];
        }


        public static bool ExisteClienteDL(string cli, string db)
        {
            int NumReg = 0;
            string strSql = @"SELECT COUNT(*) 
                              FROM PIMENTEL.CLIENTE
                              WHERE CLIENTE = @CLIENTE";

            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@CLIENTE", cli));

            NumReg = Convert.ToInt32(SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray()));
            return NumReg > 0;
        }
        public static bool ExisteVendedorDL(string ven, string db)
        {
            int NumReg = 0;
            string strSql = @"SELECT COUNT(*) 
                              FROM PIMENTEL.VENDEDOR
                              WHERE VENDEDOR = @VENDEDOR";

            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@VENDEDOR", ven));

            NumReg = Convert.ToInt32(SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray()));
            return NumReg > 0;
        }

        public static DataTable dtListarTablaClientesDL(string db)
        {
            string strSql = @"SELECT
                              CLIENTE, NOMBRE, CONTRIBUYENTE,CATEGORIA_CLIENTE,FECHA_INGRESO,
                              CONDICION_PAGO,NIVEL_PRECIO,MONEDA_NIVEL,MULTIMONEDA
                              FROM PIMENTEL.CLIENTE
                              ORDER BY CLIENTE; ";

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql).Tables[0];
        }

        public static DataTable dtListarTablaVendedoresDL(string db)
        {
            string strSql = @"SELECT V.VENDEDOR, V.NOMBRE, 
                                V.U_REGION AS REGION, 
                                REGION_NOMBRE=(SELECT LTRIM(RTRIM( DESCRIPCION))
				                                FROM PIMENTEL.CENTRO_COSTO 
				                                WHERE ACEPTA_DATOS='N' AND SUBSTRING(CENTRO_COSTO,4,2)='00' AND SUBSTRING(CENTRO_COSTO,6,9)='.00.00.00' 
                                                        AND SUBSTRING(CENTRO_COSTO,1,2)=V.U_REGION), 
                                V.U_TIENDA  AS TIENDA,  
                                TIENDA_NOMBRE=(SELECT LTRIM(RTRIM(DESCRIPCION))
				                                FROM PIMENTEL.CENTRO_COSTO 
				                                WHERE ACEPTA_DATOS='N'  AND SUBSTRING(CENTRO_COSTO,6,9)='.00.00.00' AND SUBSTRING(CENTRO_COSTO,4,2)=V.U_TIENDA),
                                V.ACTIVO
                                FROM PIMENTEL.VENDEDOR V
                                WHERE V.VENDEDOR NOT IN ('ND') ORDER BY V.NOMBRE; ";

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql).Tables[0];
        }


        public static DataTable dtListarVendedoresCuotasDL(string db)
        {
            string strSql = @"SELECT 
                              VENDEDOR, NOMBRE  FROM PIMENTEL.VENDEDOR
                              WHERE VENDEDOR NOT IN ('ND') AND ACTIVO<>'N' ORDER BY NOMBRE; ";

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql).Tables[0];
        }


        public static DataTable dtListarCentroCostoCuotasDL(string db)
        {
            string strSql = @"SELECT CENTRO_COSTO, DESCRIPCION 
                              FROM PIMENTEL.APSSA_CENTRO_COSTO ORDER BY CENTRO_COSTO; ";

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql).Tables[0];
        }

        public static DataTable dtListarZonaCuotasDL(string db)
        {
            string strSql = @"SELECT ZONA, NOMBRE FROM PIMENTEL.ZONA
                              WHERE ZONA NOT IN ('ND') ORDER BY ZONA; ";

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql).Tables[0];
        }


        public static DataTable dtObtenerCuotasporClienteDL(Int32 perio, string centro, string tiend, string vende, string clien, string mone, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_CV_CLIENTE_LISTAR";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@IDPERIODO", perio));
            arParams.Add(new SqlParameter("@CENTRO_COSTO", centro));
            arParams.Add(new SqlParameter("@TIENDA", tiend));
            arParams.Add(new SqlParameter("@VENDEDOR", vende));
            arParams.Add(new SqlParameter("@CLIENTE", clien));
            arParams.Add(new SqlParameter("@MONEDA", mone));

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray()).Tables[0];
        }


        public static DataTable dtObtenerCuotasporVendedorDL(Int32 perio, string centro, string tiend, string vende, string mone, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_CV_VENDEDOR_LISTAR";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@IDPERIODO", perio));
            arParams.Add(new SqlParameter("@CENTRO_COSTO", centro));
            arParams.Add(new SqlParameter("@TIENDA", tiend));
            arParams.Add(new SqlParameter("@VENDEDOR", vende));
            arParams.Add(new SqlParameter("@MONEDA", mone));

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray()).Tables[0];
        }

        public static DataTable dtObtenerCuotasporCentroCostoDL(Int32 perio, string mone, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_CV_CENTRO_COSTO_LISTAR";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@IDPERIODO", perio));
            arParams.Add(new SqlParameter("@MONEDA", mone));

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray()).Tables[0];
        }

        /// ------------------------------------------------------------------------------------------------------------
        /// ////////////////////////////////////////////////////

        public static void EliminarCuotaVentaPorPeriodoDL(Int32 idper, string db)
        {
            string strSql = @"DELETE FROM PIMENTEL.APSSA_CUOTA_VENTAS
                              WHERE IDPERIODO=@IDPERIODO; ";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@IDPERIODO", idper));
            SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParams.ToArray());
        }

        public static DataTable dtListarCuotaVentasPorPeriodo_DL(Int32 perio, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_CUOTA_VENTAS_CV_LISTAR";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@IDPERIODO", perio));

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray()).Tables[0];
        }


        public static bool ExisteInformacionCuotaVentaPorPeriodoDL(Int32 idper, string db)
        {
            int NumReg = 0;
            string strSql = @"SELECT COUNT(*) 
                              FROM PIMENTEL.APSSA_CUOTA_VENTAS
                              WHERE IDPERIODO=@IDPERIODO; ";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@IDPERIODO", idper));

            NumReg = Convert.ToInt32(SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParams.ToArray()));
            return NumReg > 0;
        }


        public static DataTable dtObtenerDatoPeriodoDL(string cYear, string cPeriodo, string db)
        {
            string strSql = @"SELECT
                              IDPERIODO,TIPO,ANNO,PERIODO,FECHA_INICIO,FECHA_FINAL,COMENTARIO
                              FROM PIMENTEL.APSSA_CUOTAS_VENTAS_PERIODOS
                              WHERE ANNO=@ANNO AND PERIODO=@PERIODO;
                             ";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@ANNO", cYear));
            arParams.Add(new SqlParameter("@PERIODO", cPeriodo));

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParams.ToArray()).Tables[0];
        }


        public static DataTable dtObtenerPeriodoVentasDL(string anno, string db)
        {
            string strSql = @"SELECT
                              IDPERIODO,TIPO,ANNO,PERIODO,FECHA_INICIO,FECHA_FINAL,COMENTARIO
                              FROM PIMENTEL.APSSA_CUOTAS_VENTAS_PERIODOS
                              WHERE ANNO=@ANNO
                              ORDER BY FECHA_FINAL DESC;                                 
                              ";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@ANNO", anno));

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParams.ToArray()).Tables[0];
        }



        public static void GrabarCuotasVentas_DL(string tip, Int32 id_per, DateTime fech_ini, DateTime fech_fin, string cen_cos, string tien, string tien_des,
                                                 string vend, string vend_nom, string clie, string clie_nom, string art, string art_des,
                                                 Decimal unid, Decimal mont, string mone, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_CUOTA_VENTAS_CV_GRABAR";

            List<SqlParameter> arParam = new List<SqlParameter>();

            arParam.Add(new SqlParameter("@TIPO", tip));
            arParam.Add(new SqlParameter("@IDPERIODO", id_per));
            arParam.Add(new SqlParameter("@FECHA_INICIO", fech_ini));
            arParam.Add(new SqlParameter("@FECHA_FINAL", fech_fin));
            arParam.Add(new SqlParameter("@CENTRO_COSTO", cen_cos));
            arParam.Add(new SqlParameter("@TIENDA", tien));
            arParam.Add(new SqlParameter("@TIENDA_DESCRIPCION", tien_des));
            arParam.Add(new SqlParameter("@VENDEDOR", vend));
            arParam.Add(new SqlParameter("@VENDEDOR_NOMBRE", vend_nom));
            arParam.Add(new SqlParameter("@CLIENTE", clie));
            arParam.Add(new SqlParameter("@CLIENTE_NOMBRE", clie_nom));
            arParam.Add(new SqlParameter("@ARTICULO", art));
            arParam.Add(new SqlParameter("@ARTICULO_DESCRIPCION", art_des));
            arParam.Add(new SqlParameter("@UNIDADES", unid));
            arParam.Add(new SqlParameter("@MONTO", mont));
            arParam.Add(new SqlParameter("@MONEDA", mone));

            SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParam.ToArray());
        }

        public static void GrabarCuotasCC_DL(DateTime fech, string zon, string nomzon, Decimal tie_uni, Decimal tie_mon,
                                        Decimal fur_uni, Decimal fur_mon, Decimal sub_uni, Decimal sub_mon,
                                        Decimal flo_uni, Decimal flo_mon, Decimal tal_uni, Decimal tal_mon, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_CUOTA_VENTAS_CC_GRABAR";

            List<SqlParameter> arParam = new List<SqlParameter>();

            arParam.Add(new SqlParameter("@FECHA", fech));
            arParam.Add(new SqlParameter("@ZONA", zon));
            arParam.Add(new SqlParameter("@NOMBRE_ZONA", nomzon));
            arParam.Add(new SqlParameter("@CUOTATIENDA_UNI", tie_uni));
            arParam.Add(new SqlParameter("@CUOTATIENDA_MON", tie_mon));
            arParam.Add(new SqlParameter("@CUOTAFLOTAURB_UNI", fur_uni));
            arParam.Add(new SqlParameter("@CUOTAFLOTAURB_MON", fur_mon));
            arParam.Add(new SqlParameter("@CUOTASUBDIST_UNI", sub_uni));
            arParam.Add(new SqlParameter("@CUOTASUBDIST_MON", sub_mon));
            arParam.Add(new SqlParameter("@CUOTAFLOTA_UNI", flo_uni));
            arParam.Add(new SqlParameter("@CUOTAFLOTA_MON", flo_mon));
            arParam.Add(new SqlParameter("@CUOTATALLER_UNI", tal_uni));
            arParam.Add(new SqlParameter("@CUOTATALLER_MON", tal_mon));

            SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParam.ToArray());
        }

        #endregion

        #region LISTA_PRECIO

        // 01/06/2016
        public static DataTable dtObtenerStockPorBodegasDL(string deta, string fami, string cdb)
        {
            string strSql = "PIMENTEL.SP_APSSA_STOCK_BODEGAS";
            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@DETALLE", deta));
            arParams.Add(new SqlParameter("@FAMILIA", fami));

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(cdb), CommandType.StoredProcedure, strSql, arParams.ToArray()).Tables[0];
        }

        public static DataTable dtObtenerStockArticulosPorBodegaDL(string artic, string deta, string cdb)
        {
            string strSql = "PIMENTEL.SP_APSSA_STOCK_ARTICULO_BODEGA";
            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@ARTICULO", artic));
            arParams.Add(new SqlParameter("@DETALLE", deta));

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(cdb), CommandType.StoredProcedure, strSql, arParams.ToArray()).Tables[0];
        }


        // maxmax 27/05/2016
        public static DataTable dtObtenerListaPreciosActualNuevo3DL(DateTime FecProc, Decimal tipo_camb, string inc_igv, string bodega, string famil, string cdb)
        {
            string strSql = "PIMENTEL.SP_APSSA_LISTA_PRECIOS_VISOR_TIENDA_V3";
            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@FECHA_PROCESO", FecProc));
            arParams.Add(new SqlParameter("@TIPO_CAMBIO", tipo_camb));
            arParams.Add(new SqlParameter("@CON_IGV", inc_igv));
            arParams.Add(new SqlParameter("@BODEGA", bodega));
            arParams.Add(new SqlParameter("@FAMILIA", famil));

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(cdb), CommandType.StoredProcedure, strSql, arParams.ToArray()).Tables[0];
        }


        // maxmax 23/05/2016
        public static DataTable dtObtenerListaPreciosActualNuevo2DL(DateTime FecProc, Decimal tipo_camb, string inc_igv, string famil, string cdb)
        {
            string strSql = "PIMENTEL.SP_APSSA_LISTA_PRECIOS_VISOR_TIENDA_V2";
            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@FECHA_PROCESO", FecProc));
            arParams.Add(new SqlParameter("@TIPO_CAMBIO", tipo_camb));
            arParams.Add(new SqlParameter("@CON_IGV", inc_igv));
            arParams.Add(new SqlParameter("@FAMILIA", famil));

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(cdb), CommandType.StoredProcedure, strSql, arParams.ToArray()).Tables[0];
        }

        // maxmax 07/04/2016
        public static DataTable dtObtenerListaPreciosActualNuevoDL(DateTime FecProc, Decimal tipo_camb, string famil, string cdb)
        {
            string strSql = "PIMENTEL.SP_APSSA_LISTA_PRECIOS_VISOR_TIENDA";
            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@FECHA_PROCESO", FecProc));
            arParams.Add(new SqlParameter("@TIPO_CAMBIO", tipo_camb));
            arParams.Add(new SqlParameter("@FAMILIA", famil));

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(cdb), CommandType.StoredProcedure, strSql, arParams.ToArray()).Tables[0];
        }

        public static DataTable dtListarVersionNivelSugerida_V2DL(string moneda, DateTime dFechaIni, DateTime dFechaFin, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_LISTA_VERSION_NIVEL_V2";
            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@MONEDA", moneda));
            arParams.Add(new SqlParameter("@FECHA_INICIO", dFechaIni));
            arParams.Add(new SqlParameter("@FECHA_FINAL", dFechaFin));
            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray()).Tables[0];
        }

        public static void InsertaRegistrosFromTempListaPrecioToArticuloPrecioDL(string file_tmp, string db)
        {
            string strSql = @"PIMENTEL.SP_APSSA_LISTA_PRECIO_SOLES_GRABAR";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@TABLATEMP", file_tmp));

            SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray());
        }

        public static bool ExisteTablaSQLTempListaPrecioDL(string file_tmp, string db)      // PENDIENTE
        {
            int NumReg = 0;
            string strSql = @"SELECT COUNT(*) 
                              FROM PIMENTEL.ARTICULO
                              WHERE ARTICULO = @ARTICULO";

            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@TABLATEMP", file_tmp));

            NumReg = Convert.ToInt32(SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray()));
            return NumReg > 0;
        }


        public static void CrearTablaSQLTempListaPrecioDL(string file_tmp, string db)
        {
            string strSql = @"PIMENTEL.SP_APSSA_LISTA_PRECIO_SOLES_CREAR";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@TABLATEMP", file_tmp));

            SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray());
        }


        public static DataTable dtObtenerListaPreciosSolesGeneradaDL(string tmpsql, string cdb)
        {
            string strSql = "PIMENTEL.SP_APSSA_LISTA_PRECIO_SOLES_MOSTRAR";
            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@TABLATEMP", tmpsql));

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(cdb), CommandType.StoredProcedure, strSql, arParams.ToArray()).Tables[0];
        }

        public static DataTable dtObtenerListaPreciosActualV2DL(DateTime FecProc, Decimal tipo_camb, string famil, string cdb)
        {
            string strSql = "PIMENTEL.SP_APSSA_LISTA_PRECIOS_VISOR_V2";
            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@FECHA_PROCESO", FecProc));
            arParams.Add(new SqlParameter("@TIPO_CAMBIO", tipo_camb));
            arParams.Add(new SqlParameter("@FAMILIA", famil));

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(cdb), CommandType.StoredProcedure, strSql, arParams.ToArray()).Tables[0];
        }

        public static DataTable CargaDatosArticuloDL(string art, string db)
        {
            string strSql = @"SELECT ARTICULO, DESCRIPCION, UNIDAD_ALMACEN
                              FROM PIMENTEL.ARTICULO
                              WHERE ARTICULO=@ARTICULO; ";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@ARTICULO", art));

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParams.ToArray()).Tables[0];
        }

        public static bool ExisteArticuloDL(string art, string db)
        {
            int NumReg = 0;
            string strSql = @"SELECT COUNT(*) 
                              FROM PIMENTEL.ARTICULO
                              WHERE ARTICULO = @ARTICULO";

            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@ARTICULO", art));

            NumReg = Convert.ToInt32(SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray()));
            return NumReg > 0;
        }


        public static DataTable dtObtenerArticulosDL(string fami, string subf, string grup, string cdb)
        {
            string strSql = "PIMENTEL.SP_APSSA_LISTAR_ARTICULOS";
            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@FAMILIA", fami));
            arParams.Add(new SqlParameter("@SUBFAMILIA", subf));
            arParams.Add(new SqlParameter("@GRUPO", grup));

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(cdb), CommandType.StoredProcedure, strSql, arParams.ToArray()).Tables[0];
        }

        public static void EliminarArticuloPromocionDL(string art, string db)
        {
            string strSql = @" DELETE FROM PIMENTEL.APSSA_LISTA_PRECIO_PROMOCION                             
                               WHERE ARTICULO=@ARTICULO;";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@ARTICULO", art));

            SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParams.ToArray());
        }

        public static void UpdateArticuloPromocionDL(string art, Decimal pre, DateTime fech, string usu, string db)
        {
            string strSql = @"UPDATE PIMENTEL.APSSA_LISTA_PRECIO_PROMOCION
                              SET
                                PRECIO=@PRECIO, 
                                FECHA_ULT_MODIF=@FECHA_ULT_MODIF, 
                                USUARIO_ULT_MODIF=@USUARIO_ULT_MODIF
                                WHERE ARTICULO=@ARTICULO;  
                              ";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@ARTICULO", art));
            arParams.Add(new SqlParameter("@PRECIO", pre));
            arParams.Add(new SqlParameter("@FECHA_ULT_MODIF", fech));
            arParams.Add(new SqlParameter("@USUARIO_ULT_MODIF", usu));

            SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParams.ToArray());
        }

        public static void InsertarArticuloPromocionDL(string art, Decimal pre, DateTime fech, string usu, string db)
        {
            string strSql = @"INSERT INTO PIMENTEL.APSSA_LISTA_PRECIO_PROMOCION 
	                            (ARTICULO, PRECIO, FECHA_ULT_MODIF, USUARIO_ULT_MODIF)
	                            VALUES (@ARTICULO, @PRECIO, @FECHA_ULT_MODIF, @USUARIO_ULT_MODIF);";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@ARTICULO", art));
            arParams.Add(new SqlParameter("@PRECIO", pre));
            arParams.Add(new SqlParameter("@FECHA_ULT_MODIF", fech));
            arParams.Add(new SqlParameter("@USUARIO_ULT_MODIF", usu));

            SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParams.ToArray());
        }

        public static DataTable dtObtenerArticuloPromocionDL(string cdb)
        {
            string strSql = "PIMENTEL.SP_APSSA_LISTA_PRECIO_PROMOCION";

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(cdb), CommandType.StoredProcedure, strSql).Tables[0];
        }

        // maxmax 05/04/2016
        //public static DataTable dtGenerarListaDePrecioSolesDL(string filesqltemp, string cnivel_precio, string cmoneda, Int32 nversion, DateTime dFechaIni, DateTime dFechaFin,
        //                                                      Decimal ntipo_camb, string corig_niv_prec, string corig_moned, Int32 norig_versi, string cusuario, string db)
        //{
        //    string strSql = "PIMENTEL.SP_APSSA_LISTA_PRECIO_SOLES_GENERAR";
        //    List<SqlParameter> arParams = new List<SqlParameter>();
        //    arParams.Add(new SqlParameter("@TABLATEMP", filesqltemp));
        //    arParams.Add(new SqlParameter("@NIVEL_PRECIO", cnivel_precio));
        //    arParams.Add(new SqlParameter("@MONEDA", cmoneda));
        //    arParams.Add(new SqlParameter("@VERSION", nversion));
        //    arParams.Add(new SqlParameter("@FECHA_INICIO", dFechaIni));
        //    arParams.Add(new SqlParameter("@FECHA_FINAL", dFechaFin));
        //    arParams.Add(new SqlParameter("@TIPO_CAMB", ntipo_camb));
        //    arParams.Add(new SqlParameter("@ORIG_NIV_PREC", corig_niv_prec));
        //    arParams.Add(new SqlParameter("@ORIG_MONED", corig_moned));
        //    arParams.Add(new SqlParameter("@ORIG_VERSI", norig_versi));
        //    arParams.Add(new SqlParameter("@USUARIO", cusuario));

        //    return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray()).Tables[0];
        //}

        public static void dtGenerarListaDePrecioSolesDL(string filesqltemp, string cnivel_precio, string cmoneda, Int32 nversion, DateTime dFechaIni, DateTime dFechaFin,
                                                         Decimal ntipo_camb, string corig_niv_prec, string corig_moned, Int32 norig_versi, string cusuario, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_LISTA_PRECIO_SOLES_GENERAR";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@TABLATEMP", filesqltemp));
            arParams.Add(new SqlParameter("@NIVEL_PRECIO", cnivel_precio));
            arParams.Add(new SqlParameter("@MONEDA", cmoneda));
            arParams.Add(new SqlParameter("@VERSION", nversion));
            arParams.Add(new SqlParameter("@FECHA_INICIO", dFechaIni));
            arParams.Add(new SqlParameter("@FECHA_FINAL", dFechaFin));
            arParams.Add(new SqlParameter("@TIPO_CAMB", ntipo_camb));
            arParams.Add(new SqlParameter("@ORIG_NIV_PREC", corig_niv_prec));
            arParams.Add(new SqlParameter("@ORIG_MONED", corig_moned));
            arParams.Add(new SqlParameter("@ORIG_VERSI", norig_versi));
            arParams.Add(new SqlParameter("@USUARIO", cusuario));

            SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray());
        }

        // maxmax 01/04/2016
        public static void EliminarTipoCambioApssaDL(string tc, DateTime fec, Decimal mon, string db)
        {
            string strSql = @" DELETE FROM PIMENTEL.APSSA_TIPO_CAMBIO                               
                               WHERE TIPO_CAMBIO=@TIPO_CAMBIO AND FECHA=@FECHA AND MONTO=@MONTO;";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@TIPO_CAMBIO", tc));
            arParams.Add(new SqlParameter("@FECHA", fec));
            arParams.Add(new SqlParameter("@MONTO", mon));

            SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParams.ToArray());
        }


        public static void UpdateTipoCambioApssaDL(string tc, DateTime fec, string usua, Decimal mon, string db)
        {
            string strSql = @"UPDATE PIMENTEL.APSSA_TIPO_CAMBIO 
                              SET
                              MONTO=@MONTO
                              WHERE TIPO_CAMBIO=@TIPO_CAMBIO AND FECHA=@FECHA AND USUARIO=@USUARIO;
                              ";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@TIPO_CAMBIO", tc));
            arParams.Add(new SqlParameter("@FECHA", fec));
            arParams.Add(new SqlParameter("@USUARIO", usua));
            arParams.Add(new SqlParameter("@MONTO", mon));

            SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParams.ToArray());
        }



        public static void InsertarTipoCambioApssaDL(string tc, DateTime fec, string usua, Decimal mon, string db)
        {
            string strSql = @"INSERT INTO PIMENTEL.APSSA_TIPO_CAMBIO (TIPO_CAMBIO,FECHA,USUARIO,MONTO)
                              VALUES(@TIPO_CAMBIO,@FECHA,@USUARIO,@MONTO);";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@TIPO_CAMBIO", tc));
            arParams.Add(new SqlParameter("@FECHA", fec));
            arParams.Add(new SqlParameter("@USUARIO", usua));
            arParams.Add(new SqlParameter("@MONTO", mon));

            SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParams.ToArray());
        }


        public static Decimal ObtieneTipoCambioApssaDL(DateTime fecha_pro, string db)
        {
            Decimal cTipoCambio = 0;
            string strSql = @" SET LANGUAGE SPANISH;
	                           SELECT PIMENTEL.Fn_APSSA_GET_TIPO_CAMBIO_APSSA_FECHA('TVTA',@FECHA_PROCESO);
                             ";

            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@FECHA_PROCESO", fecha_pro));

            cTipoCambio = Convert.ToDecimal(SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray()));
            return cTipoCambio;
        }

        // maxmax 28/03/2016
        public static DataTable dtObtenerTipoCambioHistoricoDL(DateTime fecpro, string db)
        {
            string strSql = @"PIMENTEL.SP_APSSA_LISTA_TIPO_CAMBIO_HIST";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@FECHA_PROCESO", fecpro));

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray()).Tables[0];
        }

        // maxmax 22/03/2016
        public static Decimal ObtieneTipoCambioDL(DateTime fecha_pro, string db)
        {
            Decimal cTipoCambio = 0;
            string strSql = @" SET LANGUAGE SPANISH;
	                           SELECT PIMENTEL.Fn_APSSA_GET_TIPO_CAMBIO_FECHA('TVTA',@FECHA_PROCESO);
                             ";

            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@FECHA_PROCESO", fecha_pro));

            cTipoCambio = Convert.ToDecimal(SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray()));
            return cTipoCambio;
        }

        public static DataTable dtObtenerListaPreciosActualDL(DateTime FecProc, Decimal tipo_camb, string famil, string cdb)
        {
            string strSql = "PIMENTEL.SP_APSSA_LISTA_PRECIOS_VISOR";
            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@FECHA_PROCESO", FecProc));
            arParams.Add(new SqlParameter("@TIPO_CAMBIO", tipo_camb));
            arParams.Add(new SqlParameter("@FAMILIA", famil));

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(cdb), CommandType.StoredProcedure, strSql, arParams.ToArray()).Tables[0];
        }

        // maxmax 19/03/2016
        public static Int32 GrabarPorcentajesListaPrecioDL(string cnivel_precio, string cfamilia,
                     Decimal nmargen_minimo, Decimal nmargen_maximo, Decimal ncosto_prome_increm, string cusuario, string cdb)
        {
            Int32 NumReg = 0;
            string strSql = "PIMENTEL.SP_APSSA_PORCENTAJES_NIVEL_PRECIO_GRABAR";
            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@NIVEL_PRECIO", cnivel_precio));
            arParams.Add(new SqlParameter("@FAMILIA", cfamilia));
            arParams.Add(new SqlParameter("@MARGEN_MINIMO", nmargen_minimo));
            arParams.Add(new SqlParameter("@MARGEN_MAXIMO", nmargen_maximo));
            arParams.Add(new SqlParameter("@COSTPROM_INCREM", ncosto_prome_increm));

            NumReg = Convert.ToInt32(SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(cdb), CommandType.StoredProcedure, strSql, arParams.ToArray()));
            return NumReg;
        }


        public static void CerearCostoReposicionDL(string db)
        {
            string strSql = @"UPDATE PIMENTEL.TMP_APSSA_LPREC_REPOSI 
                              SET COSTO_REPOSICION=0
                              FROM PIMENTEL.TMP_APSSA_LPREC_REPOSI";

            SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql);
        }

        public static DataTable MostrarCostReposDL(string db)
        {
            string strSql = @"SELECT ARTICULO, MONEDA, COSTO_REPOSICION, DESCRIPCION
                              FROM PIMENTEL.TMP_APSSA_LPREC_REPOSI ";

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql).Tables[0];

        }

        public static DataTable MostrarCostPromDL(string db)
        {
            string strSql = @"SELECT 
                              ARTICULO, DESCRIPCION, MONEDA, COSTO_PROMEDIO, CANTIDAD_EN_BODEGA,
                              COSTO_EN_BODEGA, FAMILIA, SUBFAMILIA, GRUPO, MARCA
                              FROM PIMENTEL.TMP_APSSA_LPREC_CPROME ";

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql).Tables[0];
        }


        public static Tmp_CostProm ProcesaTmp_CostProm(Tmp_CostProm tmpcostprom, string db)    // temporal
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = @"
                                        INSERT INTO PIMENTEL.TMP_APSSA_LPREC_CPROME
                                        (ARTICULO, DESCRIPCION, MONEDA, COSTO_PROMEDIO, CANTIDAD_EN_BODEGA,
                                         COSTO_EN_BODEGA, FAMILIA, SUBFAMILIA, GRUPO, MARCA)
                                        VALUES
                                        (@ARTICULO, @DESCRIPCION, @MONEDA, @COSTO_PROMEDIO, @CANTIDAD_EN_BODEGA,
                                         @COSTO_EN_BODEGA, @FAMILIA, @SUBFAMILIA, @GRUPO, @MARCA)
                                        ";
                string connectionString = ConexionDC.ConectarBD(db);

                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@ARTICULO", tmpcostprom.articulo);
                    cmd.Parameters.AddWithValue("@DESCRIPCION", tmpcostprom.descripcion);
                    cmd.Parameters.AddWithValue("@MONEDA", tmpcostprom.moneda);
                    cmd.Parameters.AddWithValue("@COSTO_PROMEDIO", tmpcostprom.costo_promedio);
                    cmd.Parameters.AddWithValue("@CANTIDAD_EN_BODEGA", tmpcostprom.cantidad_en_bodega);
                    cmd.Parameters.AddWithValue("@COSTO_EN_BODEGA", tmpcostprom.costo_en_bodega);
                    cmd.Parameters.AddWithValue("@FAMILIA", tmpcostprom.familia);
                    cmd.Parameters.AddWithValue("@SUBFAMILIA", tmpcostprom.subfamilia);
                    cmd.Parameters.AddWithValue("@GRUPO", tmpcostprom.grupo);
                    cmd.Parameters.AddWithValue("@MARCA", tmpcostprom.marca);
                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    cmd.Connection.Close();
                }

                return tmpcostprom;
            }
        }


        public static Tmp_CostRepos ProcesaTmp_CostRepos(Tmp_CostRepos tmpcostrepos, string db)    // temporal
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = @"
                                        INSERT INTO PIMENTEL.TMP_APSSA_LPREC_REPOSI
                                        (ARTICULO, MONEDA, COSTO_REPOSICION, DESCRIPCION)
                                        VALUES
                                        (@ARTICULO, @MONEDA, @COSTO_REPOSICION, @DESCRIPCION)
                                        ";
                string connectionString = ConexionDC.ConectarBD(db);
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@ARTICULO", tmpcostrepos.articulo);
                    cmd.Parameters.AddWithValue("@MONEDA", tmpcostrepos.moneda);
                    cmd.Parameters.AddWithValue("@COSTO_REPOSICION", tmpcostrepos.costo_reposicion);
                    cmd.Parameters.AddWithValue("@DESCRIPCION", tmpcostrepos.descripcion);
                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    cmd.Connection.Close();
                }

                return tmpcostrepos;
            }
        }


        /*
        public static Tmp_CostProm ProcesaTmp_CostProm(Tmp_CostProm tmpcostprom, string db)    // temporal
        {
            string strSql = @"
                            INSERT INTO PIMENTEL.TMP_APSSA_LPREC_CPROME
                            (ARTICULO, DESCRIPCION, MONEDA, COSTO_PROMEDIO, CANTIDAD_EN_BODEGA,
                             COSTO_EN_BODEGA, FAMILIA, SUBFAMILIA, GRUPO, MARCA)
                            VALUES
                            (@ARTICULO, @DESCRIPCION, @MONEDA, @COSTO_PROMEDIO, @CANTIDAD_EN_BODEGA,
                             @COSTO_EN_BODEGA, @FAMILIA, @SUBFAMILIA, @GRUPO, @MARCA)
                            ";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@ARTICULO", tmpcostprom.articulo));
            arParams.Add(new SqlParameter("@DESCRIPCION", tmpcostprom.descripcion));
            arParams.Add(new SqlParameter("@MONEDA", tmpcostprom.moneda));
            arParams.Add(new SqlParameter("@COSTO_PROMEDIO", tmpcostprom.costo_promedio));
            arParams.Add(new SqlParameter("@CANTIDAD_EN_BODEGA", tmpcostprom.cantidad_en_bodega));
            arParams.Add(new SqlParameter("@COSTO_EN_BODEGA", tmpcostprom.costo_en_bodega));
            arParams.Add(new SqlParameter("@FAMILIA", tmpcostprom.familia));
            arParams.Add(new SqlParameter("@SUBFAMILIA", tmpcostprom.subfamilia));
            arParams.Add(new SqlParameter("@GRUPO", tmpcostprom.grupo));
            arParams.Add(new SqlParameter("@MARCA", tmpcostprom.marca));

            SqlHelper.ExecuteNonQuery(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParams.ToArray());
            return tmpcostprom;
        }


        public static Tmp_CostRepos ProcesaTmp_CostRepos(Tmp_CostRepos tmpcostrepos, string db)    // temporal
        {
            string strSql = @"
                            INSERT INTO PIMENTEL.TMP_APSSA_LPREC_REPOSI
                            (ARTICULO, MONEDA, COSTO_REPOSICION, DESCRIPCION)
                            VALUES
                            (@ARTICULO, @MONEDA, @COSTO_REPOSICION, @DESCRIPCION)
                            ";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@ARTICULO", tmpcostrepos.articulo));
            arParams.Add(new SqlParameter("@MONEDA", tmpcostrepos.moneda));
            arParams.Add(new SqlParameter("@COSTO_REPOSICION", tmpcostrepos.costo_reposicion));
            arParams.Add(new SqlParameter("@DESCRIPCION", tmpcostrepos.descripcion));

            SqlHelper.ExecuteNonQuery(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParams.ToArray());
            return tmpcostrepos;
        }
        */

        public static DataTable dtGenerarListaDePrecio2DL
                    (string cnivel_precio, string cmoneda, Int32 nversion, DateTime dFechaIni, DateTime dFechaFin,
                     Decimal nmargen_minimo, Decimal nmargen_maximo, Decimal ncosto_prome_increm, Decimal ntipo_camb,
                     string cusuario, string cdb)
        {
            string strSql = "PIMENTEL.SP_APSSA_LISTA_PRECIO_PROCESO_V2";
            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@NIVEL_PRECIO", cnivel_precio));
            arParams.Add(new SqlParameter("@MONEDA", cmoneda));
            arParams.Add(new SqlParameter("@VERSION", nversion));
            arParams.Add(new SqlParameter("@FECHA_INICIO", dFechaIni));
            arParams.Add(new SqlParameter("@FECHA_FINAL", dFechaFin));
            arParams.Add(new SqlParameter("@U_MARGEN_MINIMO", nmargen_minimo));
            arParams.Add(new SqlParameter("@U_MARGEN_MAXIMO", nmargen_maximo));
            arParams.Add(new SqlParameter("@U_COSTPROM_INCREM", ncosto_prome_increm));
            arParams.Add(new SqlParameter("@TIPO_CAMB", ntipo_camb));
            arParams.Add(new SqlParameter("@USUARIO", cusuario));

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(cdb), CommandType.StoredProcedure, strSql, arParams.ToArray()).Tables[0];
        }


        public static DataTable dtListarCostosPromedios2DL(DateTime dFecha, string moneda, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_VALORIZAR_INVENTARIO_V2";
            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@FECHA_PROCESO", dFecha));
            arParams.Add(new SqlParameter("@MONEDA", moneda));
            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray()).Tables[0];
        }




        public static void DeleteTmp_CostProm(string db)
        {
            string strSql = @"DELETE FROM PIMENTEL.TMP_APSSA_LPREC_CPROME ";

            SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql);
        }

        public static void DeleteTmp_CostRepos(string db)
        {
            string strSql = @"DELETE FROM PIMENTEL.TMP_APSSA_LPREC_REPOSI ";

            SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql);
        }

        public static Int32 GrabarParametrosListaPrecioDL(string cnivel_precio, string cmoneda,
                     Decimal nmargen_minimo, Decimal nmargen_maximo, Decimal ncosto_prome_increm, string cusuario, string cdb)
        {
            Int32 NumReg = 0;
            string strSql = "PIMENTEL.SP_APSSA_PARAMETROS_NIVEL_PRECIO_GRABAR";
            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@NIVEL_PRECIO", cnivel_precio));
            arParams.Add(new SqlParameter("@MONEDA", cmoneda));
            arParams.Add(new SqlParameter("@MARGEN_MINIMO", nmargen_minimo));
            arParams.Add(new SqlParameter("@MARGEN_MAXIMO", nmargen_maximo));
            arParams.Add(new SqlParameter("@COSTPROM_INCREM", ncosto_prome_increm));

            NumReg = Convert.ToInt32(SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(cdb), CommandType.StoredProcedure, strSql, arParams.ToArray()));
            return NumReg;
        }


        public static Int32 GrabarListaDePrecioDL
                    (string cnivel_precio, string cmoneda, Int32 nversion,
                     string carticulo, Int32 carticulo_version,
                     DateTime dFechaIni, DateTime dFechaFin,
                     Decimal nprecio, Decimal nmargen_mulr, Decimal nmargen_utilidad, Decimal nmargen_utilidad_min,
                     string cusuario, string cdb)
        {
            Int32 NumReg = 0;
            string strSql = "PIMENTEL.SP_APSSA_LISTA_PRECIO_GRABAR";
            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@NIVEL_PRECIO", cnivel_precio));
            arParams.Add(new SqlParameter("@MONEDA", cmoneda));
            arParams.Add(new SqlParameter("@VERSION", nversion));
            arParams.Add(new SqlParameter("@ARTICULO", carticulo));
            arParams.Add(new SqlParameter("@VERSION_ARTICULO", carticulo_version));
            arParams.Add(new SqlParameter("@FECHA_INICIO", dFechaIni));
            arParams.Add(new SqlParameter("@FECHA_FINAL", dFechaFin));
            arParams.Add(new SqlParameter("@PRECIO", nprecio));
            arParams.Add(new SqlParameter("@MARGEN_MULR", nmargen_mulr));
            arParams.Add(new SqlParameter("@MARGEN_UTILIDAD", nmargen_utilidad));
            arParams.Add(new SqlParameter("@MARGEN_UTILIDAD_MIN", nmargen_utilidad_min));
            arParams.Add(new SqlParameter("@USUARIO", cusuario));
            NumReg = Convert.ToInt32(SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(cdb), CommandType.StoredProcedure, strSql, arParams.ToArray()));
            return NumReg;
        }


        public static Int32 GrabarVersionNivelDL
                    (string cnivel_precio, string cmoneda, Int32 nversion,
                     string cestado, string cimpuesto,
                     DateTime dFechaIni, DateTime dFechaFin, string cusuario, string cdb)
        {
            Int32 NumReg = 0;
            ////string strSql = "PIMENTEL.SP_GRABAR_LISTA_VERSION_NIVEL";
            string strSql = "PIMENTEL.SP_APSSA_GRABAR_LISTA_VERSION_NIVEL";
            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@NIVEL_PRECIO", cnivel_precio));
            arParams.Add(new SqlParameter("@MONEDA", cmoneda));
            arParams.Add(new SqlParameter("@VERSION", nversion));
            arParams.Add(new SqlParameter("@FECHA_INICIO", dFechaIni));
            arParams.Add(new SqlParameter("@FECHA_FINAL", dFechaFin));
            arParams.Add(new SqlParameter("@ESTADO", cestado));
            arParams.Add(new SqlParameter("@IMPUESTO", cimpuesto));
            arParams.Add(new SqlParameter("@USUARIO", cusuario));
            NumReg = Convert.ToInt32(SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(cdb), CommandType.StoredProcedure, strSql, arParams.ToArray()));
            return NumReg;
        }


        public static DataTable dtGenerarListaDePrecioDL
                    (string cnivel_precio, string cmoneda, Int32 nversion,
                     Decimal nmargen_minimo, Decimal nmargen_maximo, Decimal ncosto_prome_increm,
                     DateTime dFechaIni, DateTime dFechaFin, string cusuario, string cdb)
        {
            string strSql = "PIMENTEL.SP_APSSA_LISTA_PRECIO_PROCESO";
            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@NIVEL_PRECIO", cnivel_precio));
            arParams.Add(new SqlParameter("@MONEDA", cmoneda));
            arParams.Add(new SqlParameter("@VERSION", nversion));
            arParams.Add(new SqlParameter("@U_MARGEN_MINIMO", nmargen_minimo));
            arParams.Add(new SqlParameter("@U_MARGEN_MAXIMO", nmargen_maximo));
            arParams.Add(new SqlParameter("@FECHA_INICIO", dFechaIni));
            arParams.Add(new SqlParameter("@FECHA_FINAL", dFechaFin));
            arParams.Add(new SqlParameter("@USUARIO", cusuario));
            arParams.Add(new SqlParameter("@U_COSTPROM_INCREM", ncosto_prome_increm));

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(cdb), CommandType.StoredProcedure, strSql, arParams.ToArray()).Tables[0];
        }

        public static DataTable dtListarVersionNivelSugeridaDL(string moneda, DateTime dFechaIni, DateTime dFechaFin, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_LISTA_VERSION_NIVEL";
            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@MONEDA", moneda));
            arParams.Add(new SqlParameter("@FECHA_INICIO", dFechaIni));
            arParams.Add(new SqlParameter("@FECHA_FINAL", dFechaFin));
            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray()).Tables[0];
        }


        public static DataTable dtListarCostosPromediosDL(DateTime dFecha, string moneda, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_VALORIZAR_INVENTARIO";
            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@FECHA_PROCESO", dFecha));
            arParams.Add(new SqlParameter("@MONEDA", moneda));
            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray()).Tables[0];
        }

        public static DataTable dtListarParametrosNivelPreciosDL(string moneda, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_PARAMETROS_NIVEL_PRECIO";
            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@MONEDA", moneda));
            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray()).Tables[0];
        }


        public static DataTable dtListarPorcentajeNivelPreciosDL(string nivel_precio, Int32 version, string moneda, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_NIVEL_PRECIO";
            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@NIVEL_PRECIO", nivel_precio));
            arParams.Add(new SqlParameter("@VERSION", version));
            arParams.Add(new SqlParameter("@MONEDA", moneda));
            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray()).Tables[0];
        }


        #endregion  
        
        #region CARGAR_LISTA_PRECIO (ANTERIOR)

        public static DataSet Listar_NivelPrecio(string db)
        {
            try
            {
                DataSet ds_nivelprecio = new DataSet();
                string strSql = @"SELECT DISTINCT NIVEL_PRECIO
                                  FROM PIMENTEL.NIVEL_PRECIO";
                ds_nivelprecio = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql);

                ds_nivelprecio.Tables[0].TableName = "nivelprecio";
                return ds_nivelprecio;
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
                DataSet ds_moneda = new DataSet();
                string strSql = @"SELECT DISTINCT MONEDA
                                  FROM PIMENTEL.NIVEL_PRECIO";
                ds_moneda = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql);

                ds_moneda.Tables[0].TableName = "moneda";
                return ds_moneda;
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
                DataSet ds_listaprecio = new DataSet();
                //ds_listaprecio = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure,
                //"PIMENTEL.SP_APSSA_LISTAR_NIVEL_PRECIO");
                string strSql = @"SELECT NIVEL_PRECIO,MONEDA,CONDICION_PAGO,ESQUEMA_TRABAJO,
                                  DESCUENTOS,SUGERIR_DESCUENTO 
                                  FROM PIMENTEL.NIVEL_PRECIO";
                ds_listaprecio = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql);

                ds_listaprecio.Tables[0].TableName = "listaprecio";
                return ds_listaprecio;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public static DataSet CargaListaVacia(string db)
        {
            // SIN PARAMETRO
            DataSet ds_listavacia = new DataSet();
            string strSql = "SELECT TOP 0 * FROM PIMENTEL.ARTICULO_PRECIO";
            ds_listavacia = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql);
            ds_listavacia.Tables[0].TableName = "listavacia";
            return ds_listavacia;
        }

        public static bool ExisteListaPrecioVersion(string sNIVEL_PRECIO, string sMONEDA, string sVERSION, string db)
        {
            int NumReg = 0;
            string strSql = @"SELECT COUNT(*) 
                              FROM PIMENTEL.ARTICULO_PRECIO
                              WHERE NIVEL_PRECIO = @NIVEL_PRECIO AND MONEDA = @MONEDA AND VERSION = @VERSION";

            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@NIVEL_PRECIO", sNIVEL_PRECIO));
            arParam.Add(new SqlParameter("@MONEDA", sMONEDA));
            arParam.Add(new SqlParameter("@VERSION", sVERSION));

            NumReg = Convert.ToInt32(SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray()));
            return NumReg > 0;
        }

        public static DataSet CargaListaDatos(string Condicion1, string db)
        {
            // CON PARAMETRO
            DataSet ds_listadatos = new DataSet();
            string strSql = "SELECT * FROM PIMENTEL.ARTICULO_PRECIO WHERE NIVEL_PRECIO = @CONDI1";
            //ds_listadatos = SqlHelper.ExecuteDataset(ConexionDC.ConectarTest(), CommandType.Text,
            //                "SELECT * FROM PIMENTEL.ARTICULO_PRECIO WHERE NIVEL_PRECIO =@CONDI1", 
            //                new SqlParameter("@CONDI1", Condicion1));
            ds_listadatos = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql,
                            new SqlParameter("@CONDI1", Condicion1));
            ds_listadatos.Tables[0].TableName = "listadatos";
            return ds_listadatos;
        }

        public static Articulo_Precio AgregarFila(Articulo_Precio listapre, string db)
        {

            string strSql = @"
                            INSERT INTO PIMENTEL.ARTICULO_PRECIO
                            (NIVEL_PRECIO,MONEDA,VERSION,ARTICULO,VERSION_ARTICULO,PRECIO,ESQUEMA_TRABAJO,MARGEN_MULR,
                                MARGEN_UTILIDAD,FECHA_INICIO,FECHA_FIN,FECHA_ULT_MODIF,USUARIO_ULT_MODIF,MARGEN_UTILIDAD_MIN)
                            VALUES                                                        
                            (@NIVEL_PRECIO,@MONEDA,@VERSION,@ARTICULO,@VERSION_ARTICULO,@PRECIO,@ESQUEMA_TRABAJO,@MARGEN_MULR,
                                @MARGEN_UTILIDAD,@FECHA_INICIO,@FECHA_FIN,@FECHA_ULT_MODIF,@USUARIO_ULT_MODIF,@MARGEN_UTILIDAD_MIN);
                            ";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@NIVEL_PRECIO", listapre.NIVEL_PRECIO));
            //arParams[0].Direction = ParameterDirection.Output;
            arParams.Add(new SqlParameter("@MONEDA", listapre.MONEDA));
            arParams.Add(new SqlParameter("@VERSION", listapre.VERSION));
            arParams.Add(new SqlParameter("@ARTICULO", listapre.ARTICULO));
            arParams.Add(new SqlParameter("@VERSION_ARTICULO", listapre.VERSION_ARTICULO));
            arParams.Add(new SqlParameter("@PRECIO", listapre.PRECIO));
            arParams.Add(new SqlParameter("@ESQUEMA_TRABAJO", listapre.ESQUEMA_TRABAJO));
            arParams.Add(new SqlParameter("@MARGEN_MULR", listapre.MARGEN_MULR));
            arParams.Add(new SqlParameter("@MARGEN_UTILIDAD", listapre.MARGEN_UTILIDAD));
            arParams.Add(new SqlParameter("@FECHA_INICIO", listapre.FECHA_INICIO));
            arParams.Add(new SqlParameter("@FECHA_FIN", listapre.FECHA_FIN));
            arParams.Add(new SqlParameter("@FECHA_ULT_MODIF", listapre.FECHA_ULT_MODIF));
            arParams.Add(new SqlParameter("@USUARIO_ULT_MODIF", listapre.USUARIO_ULT_MODIF));
            arParams.Add(new SqlParameter("@MARGEN_UTILIDAD_MIN", listapre.MARGEN_UTILIDAD_MIN));


            SqlHelper.ExecuteNonQuery(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParams.ToArray());
            //Articulo_precio.NIVEL_PRECIO = (System.Decimal)arParams[0].Value;
            return listapre;

        }

        public static Articulo_Precio AgregarFila_SP(Articulo_Precio listapre, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_ARTICULO_PRECIO_INSERT";
            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@NIVEL_PRECIO", listapre.NIVEL_PRECIO));
            arParams.Add(new SqlParameter("@MONEDA", listapre.MONEDA));
            arParams.Add(new SqlParameter("@VERSION", listapre.VERSION));
            arParams.Add(new SqlParameter("@ARTICULO", listapre.ARTICULO));
            arParams.Add(new SqlParameter("@VERSION_ARTICULO", listapre.VERSION_ARTICULO));
            arParams.Add(new SqlParameter("@PRECIO", listapre.PRECIO));
            arParams.Add(new SqlParameter("@ESQUEMA_TRABAJO", listapre.ESQUEMA_TRABAJO));
            arParams.Add(new SqlParameter("@MARGEN_MULR", listapre.MARGEN_MULR));
            arParams.Add(new SqlParameter("@MARGEN_UTILIDAD", listapre.MARGEN_UTILIDAD));
            arParams.Add(new SqlParameter("@FECHA_INICIO", listapre.FECHA_INICIO));
            arParams.Add(new SqlParameter("@FECHA_FIN", listapre.FECHA_FIN));
            arParams.Add(new SqlParameter("@FECHA_ULT_MODIF", listapre.FECHA_ULT_MODIF));
            arParams.Add(new SqlParameter("@USUARIO_ULT_MODIF", listapre.USUARIO_ULT_MODIF));
            arParams.Add(new SqlParameter("@MARGEN_UTILIDAD_MIN", listapre.MARGEN_UTILIDAD_MIN));

            SqlHelper.ExecuteNonQuery(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray());
            return listapre;
        }


        #endregion

        #region VARIOS

        public static DataSet MostrarBoletaFalla(string boleta, string db)
        {
            DataSet ds_falla = new DataSet();

            string strSql = @"SELECT 
                                F.BOLETA,F.USUARIO,F.FALLA,F.TIPO_EQUIPO_CS,
                                F.DETALLE_FALLA,F.SOLUCION_FALLA,F.CONFIRMADA,
	                            T.DESCRIPCION
                            FROM PIMENTEL.BOLETA_FALLA F
                            INNER JOIN PIMENTEL.TIPO_EQUIPO_CS T ON T.TIPO_EQUIPO_CS=F.TIPO_EQUIPO_CS
                            WHERE BOLETA=@boleta;
                             ";

            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@boleta", boleta));

            ds_falla = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray());
            ds_falla.Tables[0].TableName = "falla";
            return ds_falla;
        }

        public static DataSet MostrarDetalleComisiones(DateTime fecha1, DateTime fecha2, string zona, string tecnico, string db)
        {
            DataSet ds_comtaller = new DataSet();

            string strSql = "PIMENTEL.SP_APSSA_COMISION_TALLER_V2";
            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@FECHA_INI", fecha1));
            arParams.Add(new SqlParameter("@FECHA_FIN", fecha2));
            arParams.Add(new SqlParameter("@ZONA", zona));
            arParams.Add(new SqlParameter("@TECNICO", tecnico));

            ds_comtaller = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray());
            ds_comtaller.Tables[0].TableName = "comtaller";
            return ds_comtaller;
        }

        public static DataSet CargaDatosEstado(string estado, string db)
        {
            DataSet ds_est = new DataSet();

            string strSql = @"SELECT ESTADO, DESCRIPCION
                              FROM PIMENTEL.ESTADO_ORDEN_SERVICIO
                              WHERE ESTADO=@estado;
                             ";

            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@estado", estado));
            ds_est = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray());

            ds_est.Tables[0].TableName = "est";
            return ds_est;
        }

        public static DataSet ListaEstado(string db)
        {
            DataSet ds_estado = new DataSet();

            string strSql = @"SELECT ESTADO, DESCRIPCION
                              FROM PIMENTEL.ESTADO_ORDEN_SERVICIO
                              ORDER BY ESTADO;
                             ";

            ds_estado = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql);

            ds_estado.Tables[0].TableName = "estado";
            return ds_estado;
        }

        public static DataSet CargaDatosDepartamento(string codzona, string db)
        {
            DataSet ds_depart = new DataSet();

            string strSql = @"SELECT DEPARTAMENTO,DESCRIPCION,JEFE
                              FROM PIMENTEL.DEPARTAMENTO
                              WHERE DESCRIPCION LIKE '%TALLER%'
                                    AND SUBSTRING(DEPARTAMENTO,3,2)=SUBSTRING(@codzona,3,2)
                             ";

            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@codzona", codzona));
            ds_depart = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray());

            ds_depart.Tables[0].TableName = "depart";
            return ds_depart;
        }

        public static DataSet ListaDepartamento(string db)
        {
            DataSet ds_depar = new DataSet();

            string strSql = @"SELECT DEPARTAMENTO,DESCRIPCION
                              FROM PIMENTEL.DEPARTAMENTO
                              WHERE DESCRIPCION LIKE '%TALLER%' 
                              ORDER BY DEPARTAMENTO;
                             ";

            ds_depar = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql);

            ds_depar.Tables[0].TableName = "depar";
            return ds_depar;
        }

        public static DataSet CargaDatosLocalizacion(string codbodega, string db)
        {
            DataSet ds_locali = new DataSet();

            string strSql = @"SELECT BODEGA,LOCALIZACION,DESCRIPCION
                              FROM PIMENTEL.LOCALIZACION
                              WHERE LOCALIZACION=@codbodega;
                             ";

            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@codbodega", codbodega));
            ds_locali = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray());

            ds_locali.Tables[0].TableName = "locali";
            return ds_locali;
        }

        public static DataSet ListaLocalizacion(string db)
        {
            DataSet ds_local = new DataSet();

            string strSql = @"SELECT BODEGA,LOCALIZACION,DESCRIPCION
                              FROM PIMENTEL.LOCALIZACION
                              WHERE BODEGA='3000'
                              ORDER BY LOCALIZACION;
                             ";

            ds_local = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql);

            ds_local.Tables[0].TableName = "local";
            return ds_local;
        }

        public static DataSet CargaDatosTienda(string codzona, string db)
        {
            DataSet ds_tiend = new DataSet();

            string strSql = @"SELECT ZONA, NOMBRE, U_SUCURSAL, U_CODSUC
                              FROM PIMENTEL.ZONA
                              WHERE ZONA=@codzona;
                             ";

            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@codzona", codzona));
            ds_tiend = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray());

            ds_tiend.Tables[0].TableName = "tiend";
            return ds_tiend;
        }

        public static DataSet ListaTiendas(string db)
        {
            DataSet ds_tienda = new DataSet();

            string strSql = @"SELECT ZONA, NOMBRE
                              FROM PIMENTEL.ZONA
                              ORDER BY ZONA;
                             ";

            ds_tienda = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql);

            ds_tienda.Tables[0].TableName = "tienda";
            return ds_tienda;
        }

        public static DataSet CargaDatoVendedor(string codigov, string db)
        {
            DataSet ds_vend = new DataSet();

            string strSql = @"SELECT VENDEDOR, NOMBRE, EMPLEADO  
                              FROM PIMENTEL.VENDEDOR
                              WHERE VENDEDOR=@codigovend;
                             ";

            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@codigovend", codigov));
            ds_vend = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray());

            ds_vend.Tables[0].TableName = "vend";
            return ds_vend;
        }

        public static DataSet ListarTecnico(string tienda, string tecnico, string db)
        {
            DataSet ds_ltecnico = new DataSet();

            string strSql = "PIMENTEL.SP_APSSA_LISTA_TECNICO";
            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@ZONA", tienda));
            arParams.Add(new SqlParameter("@TECNICO", tecnico));

            ds_ltecnico = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray());
            ds_ltecnico.Tables[0].TableName = "ltecnico";
            return ds_ltecnico;
        }

        public static DataSet ListarVendedor(string tienda, string vendedor, string db)
        {
            DataSet ds_lvendedor = new DataSet();

            string strSql = "PIMENTEL.SP_APSSA_LISTA_VENDEDOR";
            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@ZONA", tienda));
            arParams.Add(new SqlParameter("@VENDEDOR", vendedor));

            ds_lvendedor = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray());
            ds_lvendedor.Tables[0].TableName = "lvendedor";
            return ds_lvendedor;
        }

        public static DataTable Listar_Facturas_PDF(string fechai, string fechaf, string cliente, string nombre,string nd,string db)//ANDY
        {
            DataSet ds_fac = new DataSet();

            string strSql = "PIMENTEL.SP_APSSA_FE_PDF";
            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@FECHAI", fechai));
            arParams.Add(new SqlParameter("@FECHAF", fechaf));
            arParams.Add(new SqlParameter("@CLIENTE", cliente));
            arParams.Add(new SqlParameter("@NOMBRE", nombre));
            arParams.Add(new SqlParameter("@ND", nd));
            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray()).Tables[0];
        }

        #endregion

        #region GRABAR ORDEN_SERVICIO

        public static DataSet CargaOrdenCabecera(string pedido, string db)
        {
            DataSet ds_os = new DataSet();

           string strSql = @"SELECT 
            		PEDIDO,ESTADO,FECHA_PEDIDO,FECHA_PROMETIDA,FECHA_PROX_EMBARQU,FECHA_ULT_EMBARQUE,FECHA_ULT_CANCELAC,
		            ORDEN_COMPRA,FECHA_ORDEN,TARJETA_CREDITO,EMBARCAR_A,DIREC_EMBARQUE,DIRECCION_FACTURA,RUBRO1,RUBRO2,
		            RUBRO3,RUBRO4,RUBRO5,OBSERVACIONES,COMENTARIO_CXC,TOTAL_MERCADERIA,MONTO_ANTICIPO,MONTO_FLETE,MONTO_SEGURO,
		            MONTO_DOCUMENTACIO,TIPO_DESCUENTO1,TIPO_DESCUENTO2,MONTO_DESCUENTO1,MONTO_DESCUENTO2,PORC_DESCUENTO1,
		            PORC_DESCUENTO2,TOTAL_IMPUESTO1,TOTAL_IMPUESTO2,TOTAL_A_FACTURAR,PORC_COMI_VENDEDOR,PORC_COMI_COBRADOR,
		            TOTAL_CANCELADO,TOTAL_UNIDADES,IMPRESO,FECHA_HORA,DESCUENTO_VOLUMEN,TIPO_PEDIDO,MONEDA_PEDIDO,
		            VERSION_NP,AUTORIZADO,DOC_A_GENERAR,CLASE_PEDIDO,MONEDA,NIVEL_PRECIO,COBRADOR,RUTA,USUARIO,CONDICION_PAGO,
		            BODEGA,ZONA,VENDEDOR,CLIENTE,CLIENTE_DIRECCION,CLIENTE_CORPORAC,CLIENTE_ORIGEN,PAIS,SUBTIPO_DOC_CXC,
		            TIPO_DOC_CXC,BACKORDER,CONTRATO,PORC_INTCTE,DESCUENTO_CASCADA,TIPO_CAMBIO,FIJAR_TIPO_CAMBIO,
		            ORIGEN_PEDIDO,DESC_DIREC_EMBARQUE,DIVISION_GEOGRAFICA1,DIVISION_GEOGRAFICA2,BASE_IMPUESTO1,BASE_IMPUESTO2,
		            MONTO_AFECTO_PERCEPCION,FLAG_MONTO_DOCUMENTACION,NOMBRE_CLIENTE,FECHA_PROYECTADA,FECHA_APROBACION,
		            TIPO_DOCUMENTO,VERSION_COTIZACION,RAZON_CANCELA_COTI,DES_CANCELA_COTI,CAMBIOS_COTI,COTIZACION_PADRE,
		            U_POSICION,U_DNI,U_NOMBRE,U_APELLIDO,U_DIRECCION,U_EMAIL,U_TELEFONO,U_PLACA,U_MARCA,U_MODELO,
		            U_CHASIS,U_TIPOVEHICULO,U_ENTREGADO,U_KILOMETRAJE,U_SERVICIOMINA,U_OSERVICIO,PEDIDO
                    FROM PIMENTEL.PEDIDO
                    WHERE PEDIDO = @pedido;
                             ";

            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@pedido", pedido));
            ds_os = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray());

            ds_os.Tables[0].TableName = "ds_os";
            return ds_os;
        }  

        public static DataSet CargaOrdenLinea(string pedido, Int32 linea, string db)
        {
            DataSet ds_osl = new DataSet();

            string strSql = @"SELECT 
                    PEDIDO,PEDIDO_LINEA,BODEGA,LOTE,LOCALIZACION,ARTICULO,ESTADO,FECHA_ENTREGA,LINEA_USUARIO,
                    PRECIO_UNITARIO,CANTIDAD_PEDIDA,CANTIDAD_A_FACTURA,CANTIDAD_FACTURADA,CANTIDAD_RESERVADA,
                    CANTIDAD_BONIFICAD,CANTIDAD_CANCELADA,TIPO_DESCUENTO,MONTO_DESCUENTO,PORC_DESCUENTO,
                    DESCRIPCION,COMENTARIO,PEDIDO_LINEA_BONIF,UNIDAD_DISTRIBUCIO,FECHA_PROMETIDA,LINEA_ORDEN_COMPRA,
                    PROYECTO,FASE,CENTRO_COSTO,CUENTA_CONTABLE,U_BOLETA,BOLETA_CS,U_DOC_REF,U_TECNICO,U_OSERVICIO
                    FROM PIMENTEL.PEDIDO_LINEA
                    WHERE PEDIDO = @pedido and PEDIDO_LINEA=@linea;
                             ";
            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@pedido", pedido));
            arParam.Add(new SqlParameter("@linea", linea));
            ds_osl = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray());

            ds_osl.Tables[0].TableName = "ds_osl";
            return ds_osl;
        }  


        public static Orden_Servicio AgregarOrdenCabecera(Orden_Servicio orden_servicio, string db)
         {                
            string strSql = "PIMENTEL.SP_APSSA_ORDEN_SERVICIO_INSERT";          
            List<SqlParameter> arParams = new List<SqlParameter>();

            arParams.Add(new SqlParameter("@OSERVICIO", orden_servicio.oservicio));
            arParams.Add(new SqlParameter("@ESTADO", orden_servicio.estado));
            arParams.Add(new SqlParameter("@FECHA_SERVICIO", orden_servicio.fecha_servicio));
            arParams.Add(new SqlParameter("@FECHA_PROMETIDA", orden_servicio.fecha_prometida));
            arParams.Add(new SqlParameter("@FECHA_PROX_EMBARQU", orden_servicio.fecha_prox_embarqu));
            arParams.Add(new SqlParameter("@FECHA_ULT_EMBARQUE", orden_servicio.fecha_ult_embarque));
            arParams.Add(new SqlParameter("@FECHA_ULT_CANCELAC", orden_servicio.fecha_ult_cancelac));
            arParams.Add(new SqlParameter("@ORDEN_COMPRA", orden_servicio.orden_compra));
            arParams.Add(new SqlParameter("@FECHA_ORDEN", orden_servicio.fecha_orden));
            arParams.Add(new SqlParameter("@TARJETA_CREDITO", orden_servicio.tarjeta_credito));
            arParams.Add(new SqlParameter("@EMBARCAR_A", orden_servicio.embarcar_a));
            arParams.Add(new SqlParameter("@DIREC_EMBARQUE", orden_servicio.direc_embarque));
            arParams.Add(new SqlParameter("@DIRECCION_FACTURA", orden_servicio.direccion_factura));
            arParams.Add(new SqlParameter("@RUBRO1", orden_servicio.rubro1));
            arParams.Add(new SqlParameter("@RUBRO2", orden_servicio.rubro2));
            arParams.Add(new SqlParameter("@RUBRO3", orden_servicio.rubro3));
            arParams.Add(new SqlParameter("@RUBRO4", orden_servicio.rubro4));
            arParams.Add(new SqlParameter("@RUBRO5", orden_servicio.rubro5));
            arParams.Add(new SqlParameter("@OBSERVACIONES", orden_servicio.observaciones));
            arParams.Add(new SqlParameter("@COMENTARIO_CXC", orden_servicio.comentario_cxc));
            arParams.Add(new SqlParameter("@TOTAL_MERCADERIA", orden_servicio.total_mercaderia));
            arParams.Add(new SqlParameter("@MONTO_ANTICIPO", orden_servicio.monto_anticipo));
            arParams.Add(new SqlParameter("@MONTO_FLETE", orden_servicio.monto_flete));
            arParams.Add(new SqlParameter("@MONTO_SEGURO", orden_servicio.monto_seguro));
            arParams.Add(new SqlParameter("@MONTO_DOCUMENTACIO", orden_servicio.monto_documentacio));
            arParams.Add(new SqlParameter("@TIPO_DESCUENTO1", orden_servicio.tipo_descuento1));
            arParams.Add(new SqlParameter("@TIPO_DESCUENTO2", orden_servicio.tipo_descuento2));
            arParams.Add(new SqlParameter("@MONTO_DESCUENTO1", orden_servicio.monto_descuento1));
            arParams.Add(new SqlParameter("@MONTO_DESCUENTO2", orden_servicio.monto_descuento2));
            arParams.Add(new SqlParameter("@PORC_DESCUENTO1", orden_servicio.porc_descuento1));
            arParams.Add(new SqlParameter("@PORC_DESCUENTO2", orden_servicio.porc_descuento2));
            arParams.Add(new SqlParameter("@TOTAL_IMPUESTO1", orden_servicio.total_impuesto1));
            arParams.Add(new SqlParameter("@TOTAL_IMPUESTO2", orden_servicio.total_impuesto2));
            arParams.Add(new SqlParameter("@TOTAL_A_FACTURAR", orden_servicio.total_a_facturar));
            arParams.Add(new SqlParameter("@PORC_COMI_VENDEDOR", orden_servicio.porc_comi_vendedor));
            arParams.Add(new SqlParameter("@PORC_COMI_COBRADOR", orden_servicio.porc_comi_cobrador));
            arParams.Add(new SqlParameter("@TOTAL_CANCELADO", orden_servicio.total_cancelado));
            arParams.Add(new SqlParameter("@TOTAL_UNIDADES", orden_servicio.total_unidades));
            arParams.Add(new SqlParameter("@IMPRESO", orden_servicio.impreso));
            arParams.Add(new SqlParameter("@FECHA_HORA", orden_servicio.fecha_hora));
            arParams.Add(new SqlParameter("@DESCUENTO_VOLUMEN", orden_servicio.descuento_volumen));
            arParams.Add(new SqlParameter("@TIPO_SERVICIO", orden_servicio.tipo_servicio));
            arParams.Add(new SqlParameter("@MONEDA_SERVICIO", orden_servicio.moneda_servicio));
            arParams.Add(new SqlParameter("@VERSION_NP", orden_servicio.version_np));
            arParams.Add(new SqlParameter("@AUTORIZADO", orden_servicio.autorizado));
            arParams.Add(new SqlParameter("@DOC_A_GENERAR", orden_servicio.doc_a_generar));
            arParams.Add(new SqlParameter("@CLASE_SERVICIO", orden_servicio.clase_servicio));
            arParams.Add(new SqlParameter("@MONEDA", orden_servicio.moneda));
            arParams.Add(new SqlParameter("@NIVEL_PRECIO", orden_servicio.nivel_precio));
            arParams.Add(new SqlParameter("@COBRADOR", orden_servicio.cobrador));
            arParams.Add(new SqlParameter("@RUTA", orden_servicio.ruta));
            arParams.Add(new SqlParameter("@USUARIO", orden_servicio.usuario));
            arParams.Add(new SqlParameter("@CONDICION_PAGO", orden_servicio.condicion_pago));
            arParams.Add(new SqlParameter("@BODEGA", orden_servicio.bodega));
            arParams.Add(new SqlParameter("@ZONA", orden_servicio.zona));
            arParams.Add(new SqlParameter("@VENDEDOR", orden_servicio.vendedor));
            arParams.Add(new SqlParameter("@CLIENTE", orden_servicio.cliente));
            arParams.Add(new SqlParameter("@CLIENTE_DIRECCION", orden_servicio.cliente_direccion));
            arParams.Add(new SqlParameter("@CLIENTE_CORPORAC", orden_servicio.cliente_corporac));
            arParams.Add(new SqlParameter("@CLIENTE_ORIGEN", orden_servicio.cliente_origen));
            arParams.Add(new SqlParameter("@PAIS", orden_servicio.pais));
            arParams.Add(new SqlParameter("@SUBTIPO_DOC_CXC", orden_servicio.subtipo_doc_cxc));
            arParams.Add(new SqlParameter("@TIPO_DOC_CXC", orden_servicio.tipo_doc_cxc));
            arParams.Add(new SqlParameter("@BACKORDER", orden_servicio.backorder));
            arParams.Add(new SqlParameter("@CONTRATO", orden_servicio.contrato));
            arParams.Add(new SqlParameter("@PORC_INTCTE", orden_servicio.porc_intcte));
            arParams.Add(new SqlParameter("@DESCUENTO_CASCADA", orden_servicio.descuento_cascada));
            arParams.Add(new SqlParameter("@TIPO_CAMBIO", orden_servicio.tipo_cambio));
            arParams.Add(new SqlParameter("@FIJAR_TIPO_CAMBIO", orden_servicio.fijar_tipo_cambio));
            arParams.Add(new SqlParameter("@ORIGEN_PEDIDO", orden_servicio.origen_pedido));
            arParams.Add(new SqlParameter("@DESC_DIREC_EMBARQUE", orden_servicio.desc_direc_embarque));
            arParams.Add(new SqlParameter("@DIVISION_GEOGRAFICA1", orden_servicio.division_geografica1));
            arParams.Add(new SqlParameter("@DIVISION_GEOGRAFICA2", orden_servicio.division_geografica2));
            arParams.Add(new SqlParameter("@BASE_IMPUESTO1", orden_servicio.base_impuesto1));
            arParams.Add(new SqlParameter("@BASE_IMPUESTO2", orden_servicio.base_impuesto2));
            arParams.Add(new SqlParameter("@MONTO_AFECTO_PERCEPCION", orden_servicio.monto_afecto_percepcion));
            arParams.Add(new SqlParameter("@FLAG_MONTO_DOCUMENTACION", orden_servicio.flag_monto_documentacion));
            arParams.Add(new SqlParameter("@NOMBRE_CLIENTE", orden_servicio.nombre_cliente));
            arParams.Add(new SqlParameter("@FECHA_PROYECTADA", orden_servicio.fecha_proyectada));
            arParams.Add(new SqlParameter("@FECHA_APROBACION", orden_servicio.fecha_aprobacion));
            arParams.Add(new SqlParameter("@TIPO_DOCUMENTO", orden_servicio.tipo_documento));
            arParams.Add(new SqlParameter("@VERSION_COTIZACION", orden_servicio.version_cotizacion));
            arParams.Add(new SqlParameter("@RAZON_CANCELA_COTI", orden_servicio.razon_cancela_coti));
            arParams.Add(new SqlParameter("@DES_CANCELA_COTI", orden_servicio.des_cancela_coti));
            arParams.Add(new SqlParameter("@CAMBIOS_COTI", orden_servicio.cambios_coti));
            arParams.Add(new SqlParameter("@COTIZACION_PADRE", orden_servicio.cotizacion_padre));
            arParams.Add(new SqlParameter("@U_POSICION", orden_servicio.u_posicion));
            arParams.Add(new SqlParameter("@U_DNI", orden_servicio.u_dni));
            arParams.Add(new SqlParameter("@U_NOMBRE", orden_servicio.u_nombre));
            arParams.Add(new SqlParameter("@U_APELLIDO", orden_servicio.u_apellido));
            arParams.Add(new SqlParameter("@U_DIRECCION", orden_servicio.u_direccion));
            arParams.Add(new SqlParameter("@U_EMAIL", orden_servicio.u_email));
            arParams.Add(new SqlParameter("@U_TELEFONO", orden_servicio.u_telefono));
            arParams.Add(new SqlParameter("@U_PLACA", orden_servicio.u_placa));
            arParams.Add(new SqlParameter("@U_MARCA", orden_servicio.u_marca));
            arParams.Add(new SqlParameter("@U_MODELO", orden_servicio.u_modelo));
            arParams.Add(new SqlParameter("@U_CHASIS", orden_servicio.u_chasis));
            arParams.Add(new SqlParameter("@U_TIPOVEHICULO", orden_servicio.u_tipovehiculo));
            arParams.Add(new SqlParameter("@U_ENTREGADO", orden_servicio.u_entregado));
            arParams.Add(new SqlParameter("@U_KILOMETRAJE", orden_servicio.u_kilometraje));
            arParams.Add(new SqlParameter("@U_SERVICIOMINA", orden_servicio.u_serviciomina));
            arParams.Add(new SqlParameter("@U_OSERVICIO", orden_servicio.u_oservicio));
            arParams.Add(new SqlParameter("@PEDIDO", orden_servicio.pedido));
                     
            SqlHelper.ExecuteNonQuery(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray());
            return orden_servicio;
         }


           public static Orden_Servicio_Linea AgregarOrdenLinea(Orden_Servicio_Linea orden_servicio_linea, string db)
             {
                 string strSql = "PIMENTEL.SP_APSSA_ORDEN_SERVICIO_LINEA_INSERT";          
                List<SqlParameter> arParams = new List<SqlParameter>();

                arParams.Add(new SqlParameter("@OSERVICIO", orden_servicio_linea.oservicio));
                arParams.Add(new SqlParameter("@OSERVICIO_LINEA", orden_servicio_linea.oservicio_linea));
                arParams.Add(new SqlParameter("@BODEGA", orden_servicio_linea.bodega));
                arParams.Add(new SqlParameter("@LOTE", orden_servicio_linea.lote));
                arParams.Add(new SqlParameter("@LOCALIZACION", orden_servicio_linea.localizacion));
                arParams.Add(new SqlParameter("@ARTICULO", orden_servicio_linea.articulo));
                arParams.Add(new SqlParameter("@ESTADO_ORDEN", orden_servicio_linea.estado_orden));
                arParams.Add(new SqlParameter("@FECHA_ENTREGA", orden_servicio_linea.fecha_entrega));
                arParams.Add(new SqlParameter("@LINEA_USUARIO", orden_servicio_linea.linea_usuario));
                arParams.Add(new SqlParameter("@PRECIO_UNITARIO", orden_servicio_linea.precio_unitario));
                arParams.Add(new SqlParameter("@CANTIDAD_PEDIDA", orden_servicio_linea.cantidad_pedida));
                arParams.Add(new SqlParameter("@CANTIDAD_A_FACTURA", orden_servicio_linea.cantidad_a_factura));
                arParams.Add(new SqlParameter("@CANTIDAD_FACTURADA", orden_servicio_linea.cantidad_facturada));
                arParams.Add(new SqlParameter("@CANTIDAD_RESERVADA", orden_servicio_linea.cantidad_reservada));
                arParams.Add(new SqlParameter("@CANTIDAD_BONIFICAD", orden_servicio_linea.cantidad_bonificad));
                arParams.Add(new SqlParameter("@CANTIDAD_CANCELADA", orden_servicio_linea.cantidad_cancelada));
                arParams.Add(new SqlParameter("@TIPO_DESCUENTO", orden_servicio_linea.tipo_descuento));
                arParams.Add(new SqlParameter("@MONTO_DESCUENTO", orden_servicio_linea.monto_descuento));
                arParams.Add(new SqlParameter("@PORC_DESCUENTO", orden_servicio_linea.porc_descuento));
                arParams.Add(new SqlParameter("@DESCRIPCION", orden_servicio_linea.descripcion));
                arParams.Add(new SqlParameter("@COMENTARIO", orden_servicio_linea.comentario));
                arParams.Add(new SqlParameter("@PEDIDO_LINEA_BONIF", orden_servicio_linea.pedido_linea_bonif));
                arParams.Add(new SqlParameter("@UNIDAD_DISTRIBUCIO", orden_servicio_linea.unidad_distribucio));
                arParams.Add(new SqlParameter("@FECHA_PROMETIDA", orden_servicio_linea.fecha_prometida));
                arParams.Add(new SqlParameter("@LINEA_ORDEN_COMPRA", orden_servicio_linea.linea_orden_compra));
                arParams.Add(new SqlParameter("@PROYECTO", orden_servicio_linea.proyecto));
                arParams.Add(new SqlParameter("@FASE", orden_servicio_linea.fase));
                arParams.Add(new SqlParameter("@CENTRO_COSTO", orden_servicio_linea.centro_costo));
                arParams.Add(new SqlParameter("@CUENTA_CONTABLE", orden_servicio_linea.cuenta_contable));
                arParams.Add(new SqlParameter("@PEDIDO", orden_servicio_linea.pedido));
                arParams.Add(new SqlParameter("@U_BOLETA", orden_servicio_linea.u_boleta));
                arParams.Add(new SqlParameter("@BOLETA_CS", orden_servicio_linea.boleta_cs));
                arParams.Add(new SqlParameter("@U_DOC_REF", orden_servicio_linea.u_doc_ref));
                arParams.Add(new SqlParameter("@U_TECNICO", orden_servicio_linea.u_tecnico));
                arParams.Add(new SqlParameter("@U_OSERVICIO", orden_servicio_linea.u_oservicio));
                arParams.Add(new SqlParameter("@USUARIO", orden_servicio_linea.usuario));
                arParams.Add(new SqlParameter("@ORDEN_ASIGNACION", orden_servicio_linea.orden_asignacion));
                arParams.Add(new SqlParameter("@ESTADO_BOLETA", orden_servicio_linea.estado_boleta));
                arParams.Add(new SqlParameter("@FEC_HR_INICIO", orden_servicio_linea.fec_hr_inicio));
                arParams.Add(new SqlParameter("@FEC_HR_ORIGINAL", orden_servicio_linea.fec_hr_original));
                arParams.Add(new SqlParameter("@USUARIO_MODIFICA", orden_servicio_linea.usuario_modifica));
                arParams.Add(new SqlParameter("@FALLA", orden_servicio_linea.falla));
                arParams.Add(new SqlParameter("@TIPO_EQUIPO_CS", orden_servicio_linea.tipo_equipo_cs));
                arParams.Add(new SqlParameter("@BOLETA", orden_servicio_linea.boleta));
                arParams.Add(new SqlParameter("@DETALLE_FALLA", orden_servicio_linea.detalle_falla));
                arParams.Add(new SqlParameter("@SOLUCION_FALLA", orden_servicio_linea.solucion_falla));
                arParams.Add(new SqlParameter("@CONFIRMADA", orden_servicio_linea.confirmada));
     
                 SqlHelper.ExecuteNonQuery(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray());
                 return orden_servicio_linea;
             }         

        public static bool ValidarPedidoTieneOrdenServicio(string pedido, string db)
        {
            string strSql = @"SELECT COUNT(*) 
                              FROM PIMENTEL.PEDIDO
                              WHERE PEDIDO = @pedido 
                              AND LEFT(LTRIM(RTRIM(U_OSERVICIO)),2)='OS';";
                       
            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@pedido", pedido));

            int count = Convert.ToInt32(SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray()));

            if (count == 0)
                return false;
            else
                return true;
        }


        public static bool ValidarExisteOrdenServicio(string oserv, string db)
        {
            string strSql = @"SELECT COUNT(*) 
                              FROM PIMENTEL.ORDEN_SERVICIO
                              WHERE OSERVICIO = @oservicio ;";
                       
            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@oservicio", oserv));

            int count = Convert.ToInt32(SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray()));

            if (count == 0)
                return false;
            else
                return true;
        } 

        public static void GrabarNumeroOrden(string codigoz, string orden, string db)
        {
            string strSql = @"UPDATE PIMENTEL.U_ORDEN_SERV_CON  
                              SET U_VALOR_CONSECUTIVO = @orden                 
                              WHERE U_ZONA=@codigoz;";

            List<SqlParameter> arParam = new List<SqlParameter>();

            arParam.Add(new SqlParameter("@codigoz", codigoz));
            arParam.Add(new SqlParameter("@orden", orden));

            SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray());
        }


        public static string VerificaNumeroOrden(string codzona, string db)
        {
            string cValor_Consecutivo = null;

            string strSql = @"SELECT U_VALOR_CONSECUTIVO
                              FROM PIMENTEL.U_ORDEN_SERV_CON 
                              WHERE U_ZONA=@codzona;
                             ";

            List<SqlParameter> arParam = new List<SqlParameter>();

            arParam.Add(new SqlParameter("@codzona", codzona));

            cValor_Consecutivo = Convert.ToString(SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray()));
            return cValor_Consecutivo;
        }


        public static DataSet CargaNumeroOrden(string codigoz, string db)
        {
            DataSet ds_uo = new DataSet();

            string strSql = @"SELECT U_CODIGO, U_VALOR_CONSECUTIVO, U_VALOR_MAXIMO, U_ZONA, U_EMITIDOS
                              FROM PIMENTEL.U_ORDEN_SERV_CON 
                              WHERE U_ZONA=@codigozona;
                             ";

            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@codigozona", codigoz));
            ds_uo = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray());

            ds_uo.Tables[0].TableName = "uo";
            return ds_uo;
        }

        // Graba PEDIDO            Orden Servicio 
        // (PEDIDO/U_OSERVICIO/ESTADO/FECHA_APROBACION)
        public static void GrabarPedido(string pedido, string orden, string db)
        {
            string strSql = @"UPDATE PIMENTEL.PEDIDO        
                              SET U_OSERVICIO = @orden                 
                              WHERE PEDIDO=@pedido;";

            List<SqlParameter> arParam = new List<SqlParameter>();

            arParam.Add(new SqlParameter("@pedido", pedido));
            arParam.Add(new SqlParameter("@orden", orden));

            SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray());
        }

        // Graba PEDIDO_LINEA     (graba igual todas las lineas)    Orden Servicio DEtalle      
        // (PEDIDO/U_OSERVICIO/ESTADO)
        public static void GrabarPedidoDetalle(string pedido, string orden, string estado, string db)
        {
            string strSql = @"UPDATE PIMENTEL.PEDIDO_LINEA        
                              SET                               
                              U_OSERVICIO = @orden,
                              ESTADO = @estado
                              WHERE PEDIDO=@pedido ;";

            List<SqlParameter> arParam = new List<SqlParameter>();

            arParam.Add(new SqlParameter("@pedido", pedido));
            arParam.Add(new SqlParameter("@orden", orden));
            arParam.Add(new SqlParameter("@estado", estado));

            SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray());
        }

        // Graba PEDIDO_LINEA   por Item     Orden Servicio Detalle   (graba solo las lineas con tecnicos)
        // (PEDIDO/U_OSERVICIO/U_TECNICO/ARTICULO/PEDIDO_LINEA)
        public static void GrabarPedidoDetallePorItem(string pedido, string orden, string tecnico, string articulo, Int32 linea, string db)
        {
            string strSql = @"UPDATE PIMENTEL.PEDIDO_LINEA        
                              SET                               
                              U_OSERVICIO = @orden,  
                              U_TECNICO = @tecnico
                              WHERE PEDIDO=@pedido AND ARTICULO=@articulo AND PEDIDO_LINEA=@linea;";

            List<SqlParameter> arParam = new List<SqlParameter>();

            arParam.Add(new SqlParameter("@pedido", pedido));
            arParam.Add(new SqlParameter("@orden", orden));
            arParam.Add(new SqlParameter("@tecnico", tecnico));
            arParam.Add(new SqlParameter("@articulo", articulo));
            arParam.Add(new SqlParameter("@linea", linea));
         
            SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray());
        }

        // Graba BOLETA    
        // (BOLETA/U_OSERVICIO/ESTADO/DEPARTAMENTO/USUARIO_ULT_MOD/NOTAS_CLIENTE/HORAS_COBRO)
        public static void GrabarBoletaServicio(string boleta, string orden, string estado, string departamento, string usuario, string notas, string horas, string db)
        {
            string strSql = @"UPDATE PIMENTEL.BOLETA        
                              SET
                                U_OSERVICIO = @orden,
                                ESTADO = @estado,
                                DEPARTAMENTO = @departamento,
                                USUARIO_ULT_MOD = @usuario,
                                NOTAS_CLIENTE = @notas,
                                HORAS_COBRO = @horas
                              WHERE BOLETA = @boleta;";

            List<SqlParameter> arParam = new List<SqlParameter>();

            arParam.Add(new SqlParameter("@orden", orden));
            arParam.Add(new SqlParameter("@estado", estado));
            arParam.Add(new SqlParameter("@departamento", departamento));
            arParam.Add(new SqlParameter("@usuario", usuario));
            arParam.Add(new SqlParameter("@notas", notas));
            arParam.Add(new SqlParameter("@horas", horas));
            arParam.Add(new SqlParameter("@boleta", boleta));

            SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray());
        }


        // Graba BOLETA_ESTADO   /  el pedido crea con el estado 1 IN ingresada
        //HACER 2 REGISTRO  (ESTADOS: AS, PR, FI) / (ORDEN: 2, 3, 4)	// se debe finalizar en Orden de Servicio				
        //INSERT INTO BOLETA_ESTADO					
        //BOLETA/ORDEN_ASIGNACION/USUARIO/ESTADO/FEC_HR_INICIO/FEC_HR_ORIGINAL/USUARIO_MODIFICA
        public static void GrabarBoletaEstado(string boleta, Int32 orden_asignacion, string usuario, string estado,
                                              DateTime fec_hr_inicio, DateTime fec_hr_original, string usuario_modifica, string db)
        {
            string strSql = @"INSERT INTO PIMENTEL.BOLETA_ESTADO 
                              (BOLETA, ORDEN_ASIGNACION,USUARIO,ESTADO,FEC_HR_INICIO,FEC_HR_ORIGINAL,USUARIO_MODIFICA)
                              VALUES  
                              (@boleta, @orden_asignacion,@usuario,@estado,@fec_hr_inicio,@fec_hr_original,@usuario_modifica)
                             ";

            List<SqlParameter> arParam = new List<SqlParameter>();

            arParam.Add(new SqlParameter("@boleta", boleta));
            arParam.Add(new SqlParameter("@orden_asignacion", orden_asignacion));
            arParam.Add(new SqlParameter("@usuario", usuario));
            arParam.Add(new SqlParameter("@estado", estado));
            arParam.Add(new SqlParameter("@fec_hr_inicio", fec_hr_inicio));
            arParam.Add(new SqlParameter("@fec_hr_original", fec_hr_original));
            arParam.Add(new SqlParameter("@usuario_modifica", usuario_modifica));

            SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray());
        }


        public static void UpdateBoletaEstado(string boleta, Int32 orden_asignacion, string usuario, string estado,
                                              DateTime fec_hr_inicio, DateTime fec_hr_original, string usuario_modifica, string db)
        {

            string strSql = "PIMENTEL.SP_APSSA_BOLETA_ESTADO_UPDATE";
            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@BOLETA", boleta));
            arParams.Add(new SqlParameter("@ORDEN_ASIGNACION", orden_asignacion));
            arParams.Add(new SqlParameter("@USUARIO", usuario));
            arParams.Add(new SqlParameter("@ESTADO", estado));
            arParams.Add(new SqlParameter("@FEC_HR_INICIO", fec_hr_inicio));
            arParams.Add(new SqlParameter("@FEC_HR_ORIGINAL", fec_hr_original));
            arParams.Add(new SqlParameter("@USUARIO_MODIFICA", usuario_modifica));

            SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray());
        }



        // Graba BOLETA_FALLA /(el pedido crea el registro DETALLE_FALLA=null,SOLUCION_FALLA=null,CONFIRMADA="NO")
        //actualizar REGISTRO  					
        //UPDATE BOLETA_FALLA					
        //BOLETA/FALLA/TIPO_EQUIPO_CS/USUARIO/DETALLE_FALLA/SOLUCION_FALLA/CONFIRMADA	
        public static void GrabarBoletaFalla(string boleta, string usuario,string falla, string tipo_equipo_cs,
                                             string detalle_falla, string solucion_falla, string confirmada, string db)                                


        {
            string strSql = @"UPDATE PIMENTEL.BOLETA_FALLA      
                              SET
                                USUARIO = @usuario,
                                DETALLE_FALLA = @detalle_falla,
                                SOLUCION_FALLA = @solucion_falla,
                                CONFIRMADA = @confirmada
                              WHERE FALLA=@falla  AND TIPO_EQUIPO_CS=@tipo_equipo_cs  AND BOLETA=@boleta;
                              ";

            List<SqlParameter> arParam = new List<SqlParameter>();

            arParam.Add(new SqlParameter("@falla", falla));
            arParam.Add(new SqlParameter("@tipo_equipo_cs", tipo_equipo_cs));
            arParam.Add(new SqlParameter("@boleta", boleta));
            arParam.Add(new SqlParameter("@usuario", usuario));
            arParam.Add(new SqlParameter("@detalle_falla", detalle_falla));
            arParam.Add(new SqlParameter("@solucion_falla", solucion_falla));
            arParam.Add(new SqlParameter("@confirmada", confirmada));

            SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray());
        }

        public static void GrabaPedidoVehiculo(string pedidoveh, string posicion, string dni, string nombre,
                                               string apellido, string direccion, string email, string telefono,
                                               string placa, string tipovehiculo, string modelo, string marca,
                                               Int32 kilometraje, string chasis, string entregado, string serviciomina, string db)
        {

            string strSql = "PIMENTEL.SP_APSSA_PEDIDO_VEHICULO_GRABAR";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@PEDIDO", pedidoveh));
            arParams.Add(new SqlParameter("@POSICION", posicion));
            arParams.Add(new SqlParameter("@DNI", dni));
            arParams.Add(new SqlParameter("@NOMBRE", nombre));
            arParams.Add(new SqlParameter("@APELLIDO", apellido));
            arParams.Add(new SqlParameter("@DIRECCION", direccion));
            arParams.Add(new SqlParameter("@EMAIL", email));
            arParams.Add(new SqlParameter("@TELEFONO", telefono));
            arParams.Add(new SqlParameter("@PLACA", placa));
            arParams.Add(new SqlParameter("@TIPOVEHICULO", tipovehiculo));
            arParams.Add(new SqlParameter("@MODELO", modelo));
            arParams.Add(new SqlParameter("@MARCA", marca));
            arParams.Add(new SqlParameter("@KILOMETRAJE", kilometraje));
            arParams.Add(new SqlParameter("@CHASIS", chasis));
            arParams.Add(new SqlParameter("@ENTREGADO", entregado));
            arParams.Add(new SqlParameter("@SERVICIOMINA", serviciomina));

            SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray());
        }

        #endregion

        #region ORDEN_SERVICIO

        public static DataSet Obtener_OS_Pedido_Detalle_DL(DateTime fecha1, DateTime fecha2, string zona, string tecnico, string anulado, string db)
        {
            DataSet ds_ossinfac = new DataSet();
            string strSql = "PIMENTEL.SP_APSSA_OS_PEDIDO";
            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@FECHA_INI", fecha1));
            arParams.Add(new SqlParameter("@FECHA_FIN", fecha2));
            arParams.Add(new SqlParameter("@ZONA", zona));
            arParams.Add(new SqlParameter("@TECNICO", tecnico));
            arParams.Add(new SqlParameter("@ANULADOS", anulado));
            ds_ossinfac = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray());
            ds_ossinfac.Tables[0].TableName = "ossinfac";
            return ds_ossinfac;
        }

        public static string ObtenerPedidoConOrden_DL(string oser, string db)
        {
            string cPedido = string.Empty;

            string strSql = @"SELECT TOP 1 PEDIDO
                              FROM PIMENTEL.ORDEN_SERVICIO
                              WHERE ESTADO<>'*' AND OSERVICIO=@OSERVICIO";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@OSERVICIO", oser));

            cPedido = Convert.ToString(SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParams.ToArray()));

            return cPedido;
        }

        public static string ObtenerOrdenServicioPreferencia_DL(string mod, string apl, string par, string db)
        {
            string cValor = string.Empty;

            string strSql = "PIMENTEL.SP_APSSA_PARAMETROS_REPORTES";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@MODULO", mod));
            arParams.Add(new SqlParameter("@APLICACION", apl));
            arParams.Add(new SqlParameter("@PARAMETRO", par));
            cValor = Convert.ToString(SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray()));

            return cValor;
        }

        /*
        public static DataSet OS_SinFacturar(DateTime fecha1, DateTime fecha2, string zona, string tecnico, string anulado, string db)
        {
            DataSet ds_ossinfac = new DataSet();
            string strSql = "PIMENTEL.SP_APSSA_OS_SIN_FACTURA";
            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@FECHA_INI", fecha1));
            arParams.Add(new SqlParameter("@FECHA_FIN", fecha2));
            arParams.Add(new SqlParameter("@ZONA", zona));
            arParams.Add(new SqlParameter("@TECNICO", tecnico));
            arParams.Add(new SqlParameter("@ANULADOS", anulado));
            ds_ossinfac = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray());
            ds_ossinfac.Tables[0].TableName = "ossinfac";
            return ds_ossinfac;
        }

        public static DataSet OS_SinFacturarDetalle(DateTime fecha1, DateTime fecha2, string zona, string tecnico, string anulado, string db)
        {
            DataSet ds_ossinfac = new DataSet();
            string strSql = "PIMENTEL.SP_APSSA_OS_SIN_FACTURA_DETALLE";
            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@FECHA_INI", fecha1));
            arParams.Add(new SqlParameter("@FECHA_FIN", fecha2));
            arParams.Add(new SqlParameter("@ZONA", zona));
            arParams.Add(new SqlParameter("@TECNICO", tecnico));
            arParams.Add(new SqlParameter("@ANULADOS", anulado));
            ds_ossinfac = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray());
            ds_ossinfac.Tables[0].TableName = "ossinfac";
            return ds_ossinfac;
        }
        */

        public static DataSet OS_SinFacturar(DateTime fecha1, DateTime fecha2, string zona, string tecnico, string anulado, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_OS_SIN_FACTURA";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FECHA_INI", fecha1);
                    cmd.Parameters.AddWithValue("@FECHA_FIN", fecha2);
                    cmd.Parameters.AddWithValue("@ZONA", zona);
                    cmd.Parameters.AddWithValue("@TECNICO", tecnico);
                    cmd.Parameters.AddWithValue("@ANULADOS", anulado);
                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    ds.Tables.Add(table);
                }
                return ds;
            }
        }

        public static DataSet OS_SinFacturarDetalle(DateTime fecha1, DateTime fecha2, string zona, string tecnico, string anulado, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_OS_SIN_FACTURA_DETALLE";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FECHA_INI", fecha1);
                    cmd.Parameters.AddWithValue("@FECHA_FIN", fecha2);
                    cmd.Parameters.AddWithValue("@ZONA", zona);
                    cmd.Parameters.AddWithValue("@TECNICO", tecnico);
                    cmd.Parameters.AddWithValue("@ANULADOS", anulado);
                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    ds.Tables.Add(table);
                }
                return ds;
            }
        }




        public static void AnularOrden_GrabaReferenciaDL(string orden, string pedido, string ref_orden, string ref_pedido, string obs, string db)
        {
            string strSql = @"INSERT INTO PIMENTEL.APSSA_ORDEN_SERVICIO_ANULADOS
		                        (OSERVICIO, PEDIDO, REF_OSERVICIO, REF_PEDIDO, OBSERVACION)
		                        VALUES
		                        (@OSERVICIO, @PEDIDO, @REF_OSERVICIO, @REF_PEDIDO, @OBSERVACION);";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@OSERVICIO", orden));
            arParams.Add(new SqlParameter("@PEDIDO", pedido));
            arParams.Add(new SqlParameter("@REF_OSERVICIO", ref_orden));
            arParams.Add(new SqlParameter("@REF_PEDIDO", ref_pedido));
            arParams.Add(new SqlParameter("@OBSERVACION", obs));

            SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParams.ToArray());
        }

        
        public static DataSet OrdenServicioAnulados(DateTime fecha1, DateTime fecha2, string zona, string tecnico, string db)
        {
            DataSet ds_osanulado = new DataSet();
            string strSql = "PIMENTEL.SP_APSSA_ORDEN_SERVICIO_ANULADOS";
            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@FECHA_INI", fecha1));
            arParams.Add(new SqlParameter("@FECHA_FIN", fecha2));
            arParams.Add(new SqlParameter("@ZONA", zona));
            arParams.Add(new SqlParameter("@TECNICO", tecnico));
            ds_osanulado = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray());
            ds_osanulado.Tables[0].TableName = "osanulado";
            return ds_osanulado;
        }

        public static DataSet OrdenServicioAnuladosDetalle(DateTime fecha1, DateTime fecha2, string zona, string tecnico, string db)
        {
            DataSet ds_osanulado = new DataSet();
            string strSql = "PIMENTEL.SP_APSSA_ORDEN_SERVICIO_ANULADOS_DET";
            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@FECHA_INI", fecha1));
            arParams.Add(new SqlParameter("@FECHA_FIN", fecha2));
            arParams.Add(new SqlParameter("@ZONA", zona));
            arParams.Add(new SqlParameter("@TECNICO", tecnico));
            ds_osanulado = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray());
            ds_osanulado.Tables[0].TableName = "osanulado";
            return ds_osanulado;
        }

        public static DataSet OrdenServicioSinFacturar(DateTime fecha1, DateTime fecha2, string zona, string tecnico, string anulado, string db)
        {
            DataSet ds_ossinfac = new DataSet();
            string strSql = "PIMENTEL.SP_APSSA_ORDEN_SERVICIO_SIN_FACTURA";
            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@FECHA_INI", fecha1));
            arParams.Add(new SqlParameter("@FECHA_FIN", fecha2));
            arParams.Add(new SqlParameter("@ZONA", zona));
            arParams.Add(new SqlParameter("@TECNICO", tecnico));
            arParams.Add(new SqlParameter("@ANULADOS", anulado));
            ds_ossinfac = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray());
            ds_ossinfac.Tables[0].TableName = "ossinfac";
            return ds_ossinfac;
        }

        public static DataSet OrdenServicioSinFacturarDetalle(DateTime fecha1, DateTime fecha2, string zona, string tecnico, string anulado, string db)
        {
            DataSet ds_ossinfac = new DataSet();
            string strSql = "PIMENTEL.SP_APSSA_ORDEN_SERVICIO_SIN_FACTURA_DET";
            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@FECHA_INI", fecha1));
            arParams.Add(new SqlParameter("@FECHA_FIN", fecha2));
            arParams.Add(new SqlParameter("@ZONA", zona));
            arParams.Add(new SqlParameter("@TECNICO", tecnico));
            arParams.Add(new SqlParameter("@ANULADOS", anulado));
            ds_ossinfac = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray());
            ds_ossinfac.Tables[0].TableName = "ossinfac";
            return ds_ossinfac;
        }

        public static void EliminaOrdenServicioLinea(string orden, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_ORDEN_SERVICIO_LINEA_ELIMINAR";
                                      
            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@OSERVICIO", orden));
         
            SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray());
        }

        public static DataSet Mostrar_PedidoUpdateOrdenServicioDetalle(string orden, string db)
        {
            DataSet ds_lpedorddet = new DataSet();
            string strSql = "PIMENTEL.SP_APSSA_MOSTRAR_PEDIDO_UPDATE_ORDEN_DETALLE";
            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@PEDIDO", orden));
            ds_lpedorddet = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray());
            ds_lpedorddet.Tables[0].TableName = "ds_lpedorddet";
            return ds_lpedorddet;
        }

        public static void LiberarOrdenServicio(string orden, string pedido, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_ORDEN_SERVICIO_LIBERAR";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@OSERVICIO", orden));
            arParams.Add(new SqlParameter("@PEDIDO", pedido));
         
            SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray());
        }

        public static void AnularOrdenServicio(string orden, string pedido, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_ORDEN_SERVICIO_ANULAR";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@OSERVICIO", orden));
            arParams.Add(new SqlParameter("@PEDIDO", pedido));
         
            SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray());
        }
        

        public static DataSet CargaOrdenServicioVacio(string db)
        {
            DataSet ds_listvaciaordserv = new DataSet();
            string strSql = "SELECT TOP 0 * FROM PIMENTEL.ARTICULO_PRECIO";
            ds_listvaciaordserv = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql);
            ds_listvaciaordserv.Tables[0].TableName = "listvaciaordserv";
            return ds_listvaciaordserv;
        }

        public static DataSet CargaOrdenServicioDetalleVacio(string db)
        {
            DataSet ds_listvaciaordservdet = new DataSet();
            string strSql = "SELECT TOP 0 * FROM PIMENTEL.ARTICULO_PRECIO";
            ds_listvaciaordservdet = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql);
            ds_listvaciaordservdet.Tables[0].TableName = "listvaciaordservdet";
            return ds_listvaciaordservdet;
        }

        public static DataSet ListarOrdenServicio(DateTime fecha1, DateTime fecha2, string zona, string cliente, string db)
        {
            DataSet ds_lordservicio = new DataSet();

            string strSql = "PIMENTEL.SP_APSSA_LISTAR_ORDEN_SERVICIO";  //"PIMENTEL.SP_APSSA_ORDEN_SERVICIO";
            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@FECHA_INI", fecha1));
            arParams.Add(new SqlParameter("@FECHA_FIN", fecha2));
            arParams.Add(new SqlParameter("@ZONA", zona));
            arParams.Add(new SqlParameter("@CLIENTE", cliente));

            ds_lordservicio = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray());
            ds_lordservicio.Tables[0].TableName = "lordservicio";
            return ds_lordservicio;
        }

        public static DataSet ListarOrdenServicioDetalle(string orden, string db)
        {
            DataSet ds_lordserviciodet = new DataSet();

            string strSql = "PIMENTEL.SP_APSSA_LISTAR_ORDEN_SERVICIO_DETALLE";  //"PIMENTEL.SP_APSSA_ORDEN_SERVICIO_DETALLE";
            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@OSERVICIO", orden));

            ds_lordserviciodet = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray());
            ds_lordserviciodet.Tables[0].TableName = "lordserviciodet";
            return ds_lordserviciodet;
        }

        public static DataSet MostrarOrdenServicioDetalle(string orden, string db)
        {
            DataSet ds_lordserviciodet = new DataSet();

            string strSql = "PIMENTEL.SP_APSSA_MOSTRAR_ORDEN_SERVICIO_DETALLE_V2";  //"PIMENTEL.SP_APSSA_MOSTRAR_ORDEN_SERVICIO_DETALLE";
            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@OSERVICIO", orden));

            ds_lordserviciodet = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray());
            ds_lordserviciodet.Tables[0].TableName = "lordserviciodet";
            return ds_lordserviciodet;
        }

        #endregion

        #region BOLETA_SERVICIO

        public static DataSet CargaBoletaServicioVacio(string db)
        {
            DataSet ds_listvaciaserv = new DataSet();
            string strSql = "SELECT TOP 0 * FROM PIMENTEL.ARTICULO_PRECIO";
            ds_listvaciaserv = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql);
            ds_listvaciaserv.Tables[0].TableName = "listvaciaserv";
            return ds_listvaciaserv;
        }

        public static DataSet CargaBoletaServicioDetalleVacio(string db)
        {
            DataSet ds_listvaciaservdet = new DataSet();
            string strSql = "SELECT TOP 0 * FROM PIMENTEL.ARTICULO_PRECIO";
            ds_listvaciaservdet = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql);
            ds_listvaciaservdet.Tables[0].TableName = "listvaciaservdet";
            return ds_listvaciaservdet;
        }


        public static DataSet ListarBoletaServicio(DateTime fecha1, DateTime fecha2, string zona, string cliente, string db)
        {
            DataSet ds_lservicio = new DataSet();

            string strSql = "PIMENTEL.SP_APSSA_BOLETA_SERVICIO";
            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@FECHA_INI", fecha1));
            arParams.Add(new SqlParameter("@FECHA_FIN", fecha2));
            arParams.Add(new SqlParameter("@ZONA", zona));
            arParams.Add(new SqlParameter("@CLIENTE", cliente));

            ds_lservicio = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray());
            ds_lservicio.Tables[0].TableName = "lservicio";
            return ds_lservicio;
        }

        public static DataSet ListarBoletaServicioDetalle(string servicio, string db)
        {
            DataSet ds_lserviciodet = new DataSet();

            string strSql = "PIMENTEL.SP_APSSA_BOLETA_SERVICIO_DETALLE";
            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@PEDIDO", servicio));

            ds_lserviciodet = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray());
            ds_lserviciodet.Tables[0].TableName = "lserviciodet";
            return ds_lserviciodet;
        }

        public static DataSet MostrarBoletaServicioDetalle(string servicio, string db)
        {
            DataSet ds_lserviciodet = new DataSet();

            //string strSql = "PIMENTEL.SP_APSSA_MOSTRAR_BOLETA_SERVICIO_DETALLE";
            string strSql = "PIMENTEL.SP_APSSA_MOSTRAR_BOLETA_SERVICIO_DETALLE_V2";
            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@PEDIDO", servicio));

            ds_lserviciodet = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray());
            ds_lserviciodet.Tables[0].TableName = "lserviciodet";
            return ds_lserviciodet;
        }


        #endregion

        #region PEDIDO
        public static DataSet CargaTipoVehiculo(string db)
        {
            DataSet ds_tipoveh = new DataSet();

            string strSql = @"SELECT TIPO_EQUIPO_CS,DESCRIPCION  
                              FROM PIMENTEL.TIPO_EQUIPO_CS
                              ORDER BY TIPO_EQUIPO_CS;
                             ";

            ds_tipoveh = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql);

            ds_tipoveh.Tables[0].TableName = "tipoveh";
            return ds_tipoveh;
        }

        public static DataSet MostrarPedidoVehiculo(string pedidoveh, string db)
        {
            DataSet ds_lpedveh = new DataSet();

            string strSql = "PIMENTEL.SP_APSSA_PEDIDO_VEHICULO_MOSTRAR";
            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@PEDIDO", pedidoveh));

            ds_lpedveh = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray());
            ds_lpedveh.Tables[0].TableName = "lpedveh";
            return ds_lpedveh;
        }

        public static DataSet CargaPedidoVacio(string db)
        {
            DataSet ds_listvaciaped = new DataSet();
            string strSql = "SELECT TOP 0 * FROM PIMENTEL.ARTICULO_PRECIO";
            ds_listvaciaped = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql);
            ds_listvaciaped.Tables[0].TableName = "listvaciaped";
            return ds_listvaciaped;
        }

        public static DataSet CargaPedidoDetalleVacio(string db)
        {
            DataSet ds_listvaciapeddet = new DataSet();
            string strSql = "SELECT TOP 0 * FROM PIMENTEL.ARTICULO_PRECIO";
            ds_listvaciapeddet = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql);
            ds_listvaciapeddet.Tables[0].TableName = "listvaciapeddet";
            return ds_listvaciapeddet;
        }

        public static DataSet ListarPedido(string tipodoc, DateTime fecha1, DateTime fecha2, string zona, string cliente, string db)
        {
            DataSet ds_lpedido = new DataSet();

            string strSql = "PIMENTEL.SP_APSSA_LISTA_PEDIDO";
            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@TIPODOC", tipodoc));
            arParams.Add(new SqlParameter("@FECHA_INI", fecha1));
            arParams.Add(new SqlParameter("@FECHA_FIN", fecha2));
            arParams.Add(new SqlParameter("@ZONA", zona));
            arParams.Add(new SqlParameter("@CLIENTE", cliente));

            ds_lpedido = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray());
            ds_lpedido.Tables[0].TableName = "lpedido";
            return ds_lpedido;
        }

        public static DataSet ListarPedidoDetalle(string pedido, string db)
        {
            DataSet ds_lpedidodet = new DataSet();

            string strSql = "PIMENTEL.SP_APSSA_LISTA_PEDIDO_DETALLE";
            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@PEDIDO", pedido));

            ds_lpedidodet = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray());
            ds_lpedidodet.Tables[0].TableName = "lpedidodet";
            return ds_lpedidodet;
        }

        public static DataSet MostrarPedidoDetalle(string pedido, string db)
        {
            DataSet ds_lpedidodet = new DataSet();

            string strSql = "PIMENTEL.SP_APSSA_MOSTRAR_PEDIDO_DETALLE";
            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@PEDIDO", pedido));

            ds_lpedidodet = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray());
            ds_lpedidodet.Tables[0].TableName = "lpedidodet";
            return ds_lpedidodet;
        }


        #endregion

        #region COTIZACION

        public static DataSet CargaCotizacionVacio(string db)
        {
            DataSet ds_listvaciacot = new DataSet();
            string strSql = "SELECT TOP 0 * FROM PIMENTEL.ARTICULO_PRECIO";
            ds_listvaciacot = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql);
            ds_listvaciacot.Tables[0].TableName = "listvaciacot";
            return ds_listvaciacot;
        }

        public static DataSet CargaCotizacionDetalleVacio(string db)
        {
            DataSet ds_listvaciacotdet = new DataSet();
            string strSql = "SELECT TOP 0 * FROM PIMENTEL.ARTICULO_PRECIO";
            ds_listvaciacotdet = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql);
            ds_listvaciacotdet.Tables[0].TableName = "listvaciacotdet";
            return ds_listvaciacotdet;
        }


        public static DataSet ListarCotizacion(string tipodoc, DateTime fecha1, DateTime fecha2, string zona, string cliente, string db)
        {
            DataSet ds_lcotizacion = new DataSet();

            string strSql = "PIMENTEL.SP_APSSA_LISTA_COTIZACION";
            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@TIPODOC", tipodoc));
            arParams.Add(new SqlParameter("@FECHA_INI", fecha1));
            arParams.Add(new SqlParameter("@FECHA_FIN", fecha2));
            arParams.Add(new SqlParameter("@ZONA", zona));
            arParams.Add(new SqlParameter("@CLIENTE", cliente));

            ds_lcotizacion = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray());
            ds_lcotizacion.Tables[0].TableName = "lcotizacion";
            return ds_lcotizacion;
        }

        public static DataSet ListarCotizacionDetalle(string cotizacion, string db)
        {
            DataSet ds_lcotizadet = new DataSet();

            string strSql = "PIMENTEL.SP_APSSA_LISTA_COTIZACION_DETALLE";
            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@COTIZACION", cotizacion));

            ds_lcotizadet = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray());
            ds_lcotizadet.Tables[0].TableName = "lcotizadet";
            return ds_lcotizadet;
        }


        public static DataSet MostrarCotizacionDetalle(string cotizacion, string db)
        {
            DataSet ds_lcotizaciondet = new DataSet();

            string strSql = "PIMENTEL.SP_APSSA_MOSTRAR_COTIZACION_DETALLE";
            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@COTIZACION", cotizacion));

            ds_lcotizaciondet = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray());
            ds_lcotizaciondet.Tables[0].TableName = "lcotizaciondet";
            return ds_lcotizaciondet;
        }

        #endregion

        #region COMISION_TALLER   UPDATE 17/12/2015


        public static Int32 GrabarTecnicoComisione_DL(string _tecnico, string _articulo, Decimal _comision, string _alcance, string _estado, string _observaciones, string db)
        {
            Int32 NumReg = 0;
            string strSql = "PIMENTEL.SP_APSSA_GRABA_TECNICO_COMISION";
            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@TECNICO", _tecnico));
            arParams.Add(new SqlParameter("@ARTICULO", _articulo));
            arParams.Add(new SqlParameter("@COMISION", _comision));
            arParams.Add(new SqlParameter("@ALCANCE", _alcance));
            arParams.Add(new SqlParameter("@ESTADO", _estado));
            arParams.Add(new SqlParameter("@OBSERVACIONES", _observaciones));

            NumReg = Convert.ToInt32(SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray()));
            return NumReg;
        }


        public static DataTable CargaTecnicoComisiones_DL(string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_LISTA_TECNICO_COMISION";
            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql).Tables[0];
        }

        public static Int32 GrabarComisionesTaller_DL(DateTime fecha_ini, DateTime fecha_fin, string db)
        {
            Int32 NumReg = 0;
            string strSql = "PIMENTEL.SP_APSSA_COMISION_TALLER_GRABAR";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@FECHA_INI", fecha_ini));
            arParams.Add(new SqlParameter("@FECHA_FIN", fecha_fin));
            NumReg = Convert.ToInt32(SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray()));
            return NumReg;
        }

        public static Int32 GrabarComisionesTaller2_DL(
                        DateTime fecha_ini, DateTime fecha_fin, string tipo_fac, string factura, DateTime fecha_fac, DateTime fecha_os, string oservicio, Int32 oservicio_linea,
                        string articulo, Decimal monto_soles, Decimal monto_dolares, Decimal porc_comis, Decimal comision_soles, string u_tecnico, string tipo_tecnico,
                        string estado_servicio, string pedido, Int32 pedido_linea, string boleta_cs, string bodega, string zona, string db)
        {
            Int32 NumReg = 0;
            string strSql = "PIMENTEL.SP_APSSA_SERVICIOS_COMISIONES_DETALLE_GRABAR";
            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@FECHA_INI", fecha_ini));
            arParams.Add(new SqlParameter("@FECHA_FIN", fecha_fin));
            arParams.Add(new SqlParameter("@TIPO_FAC", tipo_fac));
            arParams.Add(new SqlParameter("@FACTURA", factura));
            arParams.Add(new SqlParameter("@FECHA_FAC", fecha_fac));
            arParams.Add(new SqlParameter("@FECHA_OS", fecha_os));
            arParams.Add(new SqlParameter("@OSERVICIO", oservicio));
            arParams.Add(new SqlParameter("@OSERVICIO_LINEA", oservicio_linea));
            arParams.Add(new SqlParameter("@ARTICULO", articulo));
            arParams.Add(new SqlParameter("@MONTO_SOLES", monto_soles));
            arParams.Add(new SqlParameter("@MONTO_DOLARES", monto_dolares));
            arParams.Add(new SqlParameter("@PORC_COMIS", porc_comis));
            arParams.Add(new SqlParameter("@COMISION_SOLES", comision_soles));
            arParams.Add(new SqlParameter("@U_TECNICO", u_tecnico));
            arParams.Add(new SqlParameter("@TIPO_TECNICO", tipo_tecnico));
            arParams.Add(new SqlParameter("@ESTADO_SERVICIO", estado_servicio));
            arParams.Add(new SqlParameter("@PEDIDO", pedido));
            arParams.Add(new SqlParameter("@PEDIDO_LINEA", pedido_linea));
            arParams.Add(new SqlParameter("@BOLETA_CS", boleta_cs));
            arParams.Add(new SqlParameter("@BODEGA", bodega));
            arParams.Add(new SqlParameter("@ZONA", zona));

            NumReg = Convert.ToInt32(SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray()));
            return NumReg;
        }



        //maxmax  23/02/2016
        public static DataTable DetalleComisionTaller2_DL(string origen, DateTime fecha1, DateTime fecha2, string zona, string tecnico, string db)
        {
            //string strSql = "PIMENTEL.SP_APSSA_COMISION_TALLER_DETALLE_V2";
            //List<SqlParameter> arParam = new List<SqlParameter>();
            //arParam.Add(new SqlParameter("@ORIGEN", origen));
            //arParam.Add(new SqlParameter("@FECHA_INI", fecha1));
            //arParam.Add(new SqlParameter("@FECHA_FIN", fecha2));
            //arParam.Add(new SqlParameter("@ZONA", zona));
            //arParam.Add(new SqlParameter("@TECNICO", tecnico));
            //return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParam.ToArray()).Tables[0];
            //return ds;

            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_COMISION_TALLER_DETALLE_V2";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ORIGEN", origen);
                    cmd.Parameters.AddWithValue("@FECHA_INI", fecha1);
                    cmd.Parameters.AddWithValue("@FECHA_FIN", fecha2);
                    cmd.Parameters.AddWithValue("@ZONA", zona);
                    cmd.Parameters.AddWithValue("@TECNICO", tecnico);
                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    ds.Tables.Add(table);
                }

                return ds.Tables[0];
            }
        }
        
        
        
        public static DataTable ResumenComisionTecnicos2_DL(string origen, DateTime fecha1, DateTime fecha2, string zona, string tecnico, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_COMISION_TALLER_TECNICOS_V2";
            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@ORIGEN", origen));
            arParam.Add(new SqlParameter("@FECHA_INI", fecha1));
            arParam.Add(new SqlParameter("@FECHA_FIN", fecha2));
            arParam.Add(new SqlParameter("@ZONA", zona));
            arParam.Add(new SqlParameter("@TECNICO", tecnico));

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParam.ToArray()).Tables[0];
        }

        public static DataTable ResumenComisionJefes2_DL(string origen, DateTime fecha1, DateTime fecha2, string zona, string tecnico, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_COMISION_TALLER_JEFES_V2";
            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@ORIGEN", origen));
            arParam.Add(new SqlParameter("@FECHA_INI", fecha1));
            arParam.Add(new SqlParameter("@FECHA_FIN", fecha2));
            arParam.Add(new SqlParameter("@ZONA", zona));
            arParam.Add(new SqlParameter("@TECNICO", tecnico));

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParam.ToArray()).Tables[0];
        }

        public static DataSet DetalleComisionTallerDL(string origen, DateTime fecha1, DateTime fecha2, string zona, string tecnico, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_COMISION_TALLER_DETALLE";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ORIGEN", origen);
                    cmd.Parameters.AddWithValue("@FECHA_INI", fecha1);
                    cmd.Parameters.AddWithValue("@FECHA_FIN", fecha2);
                    cmd.Parameters.AddWithValue("@ZONA", zona);
                    cmd.Parameters.AddWithValue("@TECNICO", tecnico);
                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    ds.Tables.Add(table);
                }
                return ds;
            }
        }

        public static DataSet ResumenComisionTecnicosDL(string origen, DateTime fecha1, DateTime fecha2, string zona, string tecnico, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_COMISION_TALLER_TECNICOS";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ORIGEN", origen);
                    cmd.Parameters.AddWithValue("@FECHA_INI", fecha1);
                    cmd.Parameters.AddWithValue("@FECHA_FIN", fecha2);
                    cmd.Parameters.AddWithValue("@ZONA", zona);
                    cmd.Parameters.AddWithValue("@TECNICO", tecnico);
                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    ds.Tables.Add(table);
                }
                return ds;
            }
        }

        public static DataSet ResumenComisionJefesDL(string origen, DateTime fecha1, DateTime fecha2, string zona, string tecnico, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_COMISION_TALLER_JEFES";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ORIGEN", origen);
                    cmd.Parameters.AddWithValue("@FECHA_INI", fecha1);
                    cmd.Parameters.AddWithValue("@FECHA_FIN", fecha2);
                    cmd.Parameters.AddWithValue("@ZONA", zona);
                    cmd.Parameters.AddWithValue("@TECNICO", tecnico);
                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    ds.Tables.Add(table);
                }
                return ds;
            }
        }

        public static DataSet ProcesaComisionTallerDL(DateTime fecha1, DateTime fecha2, string zona, string tecnico, string db)
        {
            DataSet ds_comtaller = new DataSet();
            string strSql = "PIMENTEL.SP_APSSA_COMISION_TALLER_V3";
            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@FECHA_INI", fecha1));   // PENDIENTE ORIGEN
            arParams.Add(new SqlParameter("@FECHA_FIN", fecha2));
            arParams.Add(new SqlParameter("@ZONA", zona));
            arParams.Add(new SqlParameter("@TECNICO", tecnico));
            ds_comtaller = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray());
            ds_comtaller.Tables[0].TableName = "comtaller";
            return ds_comtaller;

        }

        #endregion


        #region COMISION_FLOTAS_RRHH   UPDATE 06/07/2018, PARA frmComisionesATF_V3

        public static void InsertarVendedorPeriodoDL(Int32 id, string vend, string db)
        {
            string strSql = @"INSERT INTO PIMENTEL.APSSA_ATF_VENDEDOR
                                (IDPERIODO,VENDEDOR)
                                VALUES
                                (@IDPERIODO,@VENDEDOR)
                            ";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@IDPERIODO", id));
            arParams.Add(new SqlParameter("@VENDEDOR", vend));

            SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParams.ToArray());
        }


        public static bool VerificarVendedorPeriodoDL(string _vendedor, string _periodo, string db)
        {
            int NumReg = 0;
            string strSql = @" SELECT COUNT(*) 
                               FROM PIMENTEL.APSSA_ATF_VENDEDOR WITH (NOLOCK)
                               WHERE VENDEDOR=@VENDEDOR AND IDPERIODO=@IDPERIODO ";

            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@VENDEDOR", _vendedor));
            arParam.Add(new SqlParameter("@IDPERIODO", _periodo));

            NumReg = Convert.ToInt32(SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray()));
            return NumReg > 0;
        }

        public static DataTable dtObtenerVendedores_DL(string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_COMISION_RRHH_VENDEDOR";

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql).Tables[0];
        }

        public static DataTable dtObtenerCentroCosto_DL(string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_COMISION_RRHH_CENTROCOSTO";

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql).Tables[0];
        }

        #endregion


        #region COMISION_FLOTAS  NUEVO  UPDATE 08/08/2016, PARA frmComisionesATF


        //trae los vendedores ATF del periodo a procesar
        public static DataTable dtObtenerVendedoresATF_DL(Int32 idper, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_COMISION_ATF_VENDEDORES";
            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@IDPERIODO", idper));

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParam.ToArray()).Tables[0];
        }

        //ALTER PROCEDURE [PIMENTEL].[SP_APSSA_COMISION_ATF_REPORTE]
        //@FECHA_COMISION_INI DATETIME,
        //@FECHA_COMISION_FIN DATETIME,
        //@REPORTE VARCHAR(50)
        public static DataTable dtObtenerReporteComisionesATF_DL(DateTime dFecha1, DateTime dFecha2, string creporte, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_COMISION_ATF_REPORTE";
            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@FECHA_COMISION_INI", dFecha1));
            arParam.Add(new SqlParameter("@FECHA_COMISION_FIN", dFecha2));
            arParam.Add(new SqlParameter("@REPORTE", creporte));

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParam.ToArray()).Tables[0];
        }


        //ObtieneComisionesATF(archivo_sql_tmp_atf);
        //ObtieneComisionesATF_Jefes(archivo_sql_tmp_atf_jefe);
        //ObtieneComisionesDetalle(archivo_sql_tmp_atf_detalle);

        public static DataTable dtObtieneComisionesVendedoresATF_DL(string file_sql, string db)
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


        public static DataTable ObtenerCuotasATF_DL(Int32 idperiodo, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                //string sqlCommand = "PIMENTEL.SP_APSSA_COMISION_ATF_VENDEDORES";        //"PIMENTEL.SP_APSSA_COMISION_GET_ATF";
                //string sqlCommand = "PIMENTEL.SP_APSSA_COMISION_CUOTAS_ATF";
                string sqlCommand = "PIMENTEL.SP_APSSA_COMISION_ATF_CUOTAS";
                string connectionString = ConexionDC.ConectarBDSA(db);     // usuario SA
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDPERIODO", idperiodo);
                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    ds.Tables.Add(table);
                }
                return ds.Tables[0];
            }
        }

        public static DataTable ObtenerVentasFlotasATF_DL(Int32 didper, DateTime dFecha1, DateTime dFecha2, DateTime dFechaP, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_COMISION_ATF_VENTAS";         //"PIMENTEL.SP_APSSA_COMISION_VENTAS_FLOTAS_V5";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@IDPERIODO", didper);
                    cmd.Parameters.AddWithValue("@FECHA_COMISION_INI", dFecha1);
                    cmd.Parameters.AddWithValue("@FECHA_COMISION_FIN", dFecha2);
                    cmd.Parameters.AddWithValue("@FECHA_PROCESO", dFechaP);
                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    ds.Tables.Add(table);
                }
                return ds.Tables[0];
            }
        }

        //ALTER PROCEDURE [PIMENTEL].[SP_APSSA_COMISION_ATF_PROCESA]
        //(@ACTUALIZA	VARCHAR(2), -- 'SI', 'NO'
        // @IDPERIODO INT,			
        // @FECHA_COMISION_INI DATETIME,
        // @FECHA_COMISION_FIN DATETIME,
        // @FECHA_PROCESO DATETIME,
        // @TMP_SQL_ATF  VARCHAR(250),
        // @TMP_SQL_ATF_JEFE  VARCHAR(250) )

        public static DataSet ProcesaComisionATF2_DL(string cActualiza, Int32 idperiodo, DateTime dFecha1, DateTime dFecha2, DateTime dFechaP, string atf, string jefe, string deta, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_COMISION_ATF_PROCESA_V2";          //"PIMENTEL.SP_APSSA_COMISION_FLOTAS_PROCESA_V5";
                //string connectionString = ConexionDC.ConectarBD(db);
                string connectionString = ConexionDC.ConectarBDSA(db);     // usuario SA
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTUALIZA", cActualiza);
                    cmd.Parameters.AddWithValue("@IDPERIODO ", idperiodo);
                    cmd.Parameters.AddWithValue("@FECHA_COMISION_INI", dFecha1);
                    cmd.Parameters.AddWithValue("@FECHA_COMISION_FIN", dFecha2);
                    cmd.Parameters.AddWithValue("@FECHA_PROCESO", dFechaP);
                    cmd.Parameters.AddWithValue("@TMP_SQL_ATF", atf);
                    cmd.Parameters.AddWithValue("@TMP_SQL_ATF_JEFE", jefe);
                    cmd.Parameters.AddWithValue("@TMP_SQL_ATF_DETALLE", deta);
                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    ds.Tables.Add(table);
                }
                return ds;
            }
        }

        public static DataSet ProcesaComisionATF_DL(string cActualiza, Int32 idperiodo, DateTime dFecha1, DateTime dFecha2, DateTime dFechaP, string atf, string jefe, string deta, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_COMISION_ATF_PROCESA";          //"PIMENTEL.SP_APSSA_COMISION_FLOTAS_PROCESA_V5";
                //string connectionString = ConexionDC.ConectarBD(db);
                string connectionString = ConexionDC.ConectarBDSA(db);     // usuario SA
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTUALIZA", cActualiza);
                    cmd.Parameters.AddWithValue("@IDPERIODO ", idperiodo);
                    cmd.Parameters.AddWithValue("@FECHA_COMISION_INI", dFecha1);
                    cmd.Parameters.AddWithValue("@FECHA_COMISION_FIN", dFecha2);
                    cmd.Parameters.AddWithValue("@FECHA_PROCESO", dFechaP);
                    cmd.Parameters.AddWithValue("@TMP_SQL_ATF", atf);
                    cmd.Parameters.AddWithValue("@TMP_SQL_ATF_JEFE", jefe);
                    cmd.Parameters.AddWithValue("@TMP_SQL_ATF_DETALLE", deta);
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

        #region COMISION_FLOTAS   UPDATE 29/02/2016, PARA frmComisionesFlotas_V4

        /*                    */

        public static DataTable dtObtenerResumenReporteFlotas_DL(DateTime dFecha1, DateTime dFecha2, string creporte, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_COMISION_FLOTAS_REPORTE";
            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@FECHA_COMISION_INI", dFecha1));
            arParam.Add(new SqlParameter("@FECHA_COMISION_FIN", dFecha2));
            arParam.Add(new SqlParameter("@REPORTE", creporte));

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParam.ToArray()).Tables[0];
        }


        public static DataSet ObtenerResumenFlotas_DL(DateTime dFecha1, DateTime dFecha2, DateTime dFechaP, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_COMISION_FLOTAS_RESUMEN";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FECHA_COMISION_INI", dFecha1);
                    cmd.Parameters.AddWithValue("@FECHA_COMISION_FIN", dFecha2);
                    cmd.Parameters.AddWithValue("@FECHA_PROCESO", dFechaP);
                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    ds.Tables.Add(table);
                }
                return ds;
            }
        }



        public static DataSet ObtenerVentasFlotas_V4_DL(DateTime dFecha1, DateTime dFecha2, DateTime dFechaP, string cfam1, string cfam2, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_COMISION_VENTAS_FLOTAS_V4";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FECHA_COMISION_INI", dFecha1);
                    cmd.Parameters.AddWithValue("@FECHA_COMISION_FIN", dFecha2);
                    cmd.Parameters.AddWithValue("@FECHA_PROCESO", dFechaP);
                    cmd.Parameters.AddWithValue("@FAMILIA1", cfam1);
                    cmd.Parameters.AddWithValue("@FAMILIA2", cfam2);
                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    ds.Tables.Add(table);
                }
                return ds;
            }
        }

        public static DataSet ProcesaComision_V4_DL(string cActualiza, DateTime dFecha1, DateTime dFecha2, DateTime dFechaP, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_COMISION_FLOTAS_PROCESA_V4";
                //string connectionString = ConexionDC.ConectarBD(db);
                string connectionString = ConexionDC.ConectarBDSA(db);     // usuario SA
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ACTUALIZA", cActualiza);
                    cmd.Parameters.AddWithValue("@FECHA_COMISION_INI", dFecha1);
                    cmd.Parameters.AddWithValue("@FECHA_COMISION_FIN", dFecha2);
                    cmd.Parameters.AddWithValue("@FECHA_PROCESO", dFechaP);
                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    ds.Tables.Add(table);
                }
                return ds;
            }
        }


        //***********************************************************************************************************************************


        public static DataTable dtRecuperaComisionesTaller_DL(DateTime f1, DateTime f2, string opcion, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_GET_COMISION_TALLER";
            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@FECHA_INI", f1));
            arParam.Add(new SqlParameter("@FECHA_FIN", f2));
            arParam.Add(new SqlParameter("@OPCION", opcion));

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParam.ToArray()).Tables[0];
        }

        public static DataTable dtRecuperarComisionesTallerDetalle_DL(DateTime f1, DateTime f2, string db)
        {
            string strSql = @"SELECT
                              FECHA_FAC,TIP_FAC,FACTURA,ORDEN,FECHA,NOMBRE_TECNICO,RAZON_SOCIAL,
                              ITEM,ARTICULO,SERVICIO,MONEDA,P_UNIT,CANTIDAD,MONTO,TIPCAM,MONTO_SOLES,
                              MONTO_DOLARES,PORC_COMIS,COMISION_SOLES,PEDIDO,ESTADO,CLIENTE,CP,
                              NIVEL_PRECIO,COBRADOR,RUTA,ZONA,ZONA_NOMBRE,BODEGA,TECNICO,VENDEDOR,
                              BOLETA_CS,BS,FECHA_INI,FECHA_FIN 
                              FROM PIMENTEL.APSSA_COMISION_TALLER
                              WHERE FECHA_INI >= @FECHA_INI  AND  FECHA_FIN<= @FECHA_FIN;
                             ";
            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@FECHA_INI", f1));
            arParam.Add(new SqlParameter("@FECHA_FIN", f2));
            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray()).Tables[0];
        }

        public static DataTable dtRecuperarComisionesTallerTecnico_DL(DateTime f1, DateTime f2, string db)
        {
            string strSql = @"SELECT
                              FECHA_FAC,TIP_FAC,FACTURA,ORDEN,FECHA,NOMBRE_TECNICO,RAZON_SOCIAL,
                              ITEM,ARTICULO,SERVICIO,MONEDA,P_UNIT,CANTIDAD,MONTO,TIPCAM,MONTO_SOLES,
                              MONTO_DOLARES,PORC_COMIS,COMISION_SOLES,PEDIDO,ESTADO,CLIENTE,CP,
                              NIVEL_PRECIO,COBRADOR,RUTA,ZONA,ZONA_NOMBRE,BODEGA,TECNICO,VENDEDOR,
                              BOLETA_CS,BS,FECHA_INI,FECHA_FIN 
                              FROM PIMENTEL.APSSA_COMISION_TALLER
                              WHERE FECHA_INI >= @FECHA_INI  AND  FECHA_FIN<= @FECHA_FIN;
                             ";
            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@FECHA_INI", f1));
            arParam.Add(new SqlParameter("@FECHA_FIN", f2));
            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray()).Tables[0];
        }

        public static DataTable dtRecuperarComisionesTallerJefeTaller_DL(DateTime f1, DateTime f2, string db)
        {
            string strSql = @"SELECT
                              FECHA_FAC,TIP_FAC,FACTURA,ORDEN,FECHA,NOMBRE_TECNICO,RAZON_SOCIAL,
                              ITEM,ARTICULO,SERVICIO,MONEDA,P_UNIT,CANTIDAD,MONTO,TIPCAM,MONTO_SOLES,
                              MONTO_DOLARES,PORC_COMIS,COMISION_SOLES,PEDIDO,ESTADO,CLIENTE,CP,
                              NIVEL_PRECIO,COBRADOR,RUTA,ZONA,ZONA_NOMBRE,BODEGA,TECNICO,VENDEDOR,
                              BOLETA_CS,BS,FECHA_INI,FECHA_FIN 
                              FROM PIMENTEL.APSSA_COMISION_TALLER
                              WHERE FECHA_INI >= @FECHA_INI  AND  FECHA_FIN<= @FECHA_FIN;
                             ";
            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@FECHA_INI", f1));
            arParam.Add(new SqlParameter("@FECHA_FIN", f2));
            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray()).Tables[0];
        }


        public static DataTable CargaDatoPeriodoComision_DL(string cTipo, string cYear, string cPeriodo, string db)
        {
            string strSql = @"SELECT
                              IDPERIODO,TIPO,ANNO,PERIODO,FECHA_INICIO,FECHA_FINAL,COMENTARIO
                              FROM PIMENTEL.APSSA_COMISION_PERIODOS
                              WHERE TIPO=@TIPO and ANNO=@ANNO AND PERIODO=@PERIODO;
                             ";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@TIPO", cTipo));
            arParams.Add(new SqlParameter("@ANNO", cYear));
            arParams.Add(new SqlParameter("@PERIODO", cPeriodo));

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParams.ToArray()).Tables[0];
        }

        public static DataTable CargaPeriodosComision_DL(string tipo, string anno, string db)
        {
            string strSql = @"  SELECT
                                    IDPERIODO,TIPO,ANNO,PERIODO,FECHA_INICIO,FECHA_FINAL,ESTADO,COMENTARIO
                                    FROM PIMENTEL.APSSA_COMISION_PERIODOS 
                                    WHERE ANNO=@ANNO AND TIPO=@TIPO
                                    ORDER BY FECHA_FINAL DESC; ";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@TIPO", tipo));
            arParams.Add(new SqlParameter("@ANNO", anno));


            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParams.ToArray()).Tables[0];
        }


        public static DataTable Listar_Annos_Comision_DL(string tipo, string db)
        {
            string strSql = @" SELECT DISTINCT ANNO 
                                   FROM PIMENTEL.APSSA_COMISION_PERIODOS  
                                   WHERE TIPO=@TIPO  
                                   ORDER BY ANNO DESC; ";

            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@TIPO", tipo));

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray()).Tables[0];
        }

        public static void GrabarPeriodosComision_DL(DateTime dfecinicio, DateTime dfecfinal, string cestado, string ccomentario, string ctipo, string canno, string cperiodo, string db)
        {

            string strSql = @"UPDATE PIMENTEL.APSSA_COMISION_PERIODOS        
                                SET  
                                FECHA_INICIO=@FECHA_INICIO,
                                FECHA_FINAL=@FECHA_FINAL,
                                ESTADO=@ESTADO,
                                COMENTARIO=@COMENTARIO
                                WHERE  TIPO=@TIPO AND ANNO=@ANNO AND PERIODO=@PERIODO;";

            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@FECHA_INICIO", dfecinicio));
            arParam.Add(new SqlParameter("@FECHA_FINAL", dfecfinal));
            arParam.Add(new SqlParameter("@ESTADO", cestado));
            arParam.Add(new SqlParameter("@COMENTARIO", ccomentario));
            arParam.Add(new SqlParameter("@TIPO", ctipo));
            arParam.Add(new SqlParameter("@ANNO", canno));
            arParam.Add(new SqlParameter("@PERIODO", cperiodo));

            SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray());
        }



        //************************************************************************************************************
        public static DataTable dtRecuperarComisionesDetalle_DL(DateTime f1, DateTime f2, string db)
        {
            string strSql = @"SELECT
	                          F_Facturacion,C_fac,N_Fac,codcdv,nomcdv,codven,nomven,codcli,nomcli,tienda,
	                          mone,tcam,codf,codi,descr,cant,cdes,Monto,pena45,pena90,comision,flag,
	                          situacion,vencimiento,uabono,dias,letra,nlet,estado,penalidad,politica,
	                          observacion,tipo,fproceso,fecha_corte,fupdate,codcli_nav,codven_nav,codf_nav,codi_nav 
                              FROM PIMENTEL.APSSA_COMISION_COMISION
                              WHERE FECHA_CORTE BETWEEN @FECHA_INI AND @FECHA_FIN;
                             ";
            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@FECHA_INI", f1));
            arParam.Add(new SqlParameter("@FECHA_FIN", f2));
            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray()).Tables[0];
        }

        public static DataTable dtRecuperarFletes_DL(DateTime f1, DateTime f2, string db)
        {
            string strSql = @"SELECT 
	                          F_Facturacion,C_fac,N_Fac,codcdv,nomcdv,codven,nomven,codcli,nomcli,tienda,
	                          mone,tcam,codf,codi,descr,cant,cdes,Monto,pena45,pena90,comision,flag,
	                          situacion,vencimiento,uabono,dias,letra,nlet,estado,penalidad,politica,
	                          observacion,tipo,fproceso,fecha_corte,fupdate,codcli_nav,codven_nav,codf_nav,codi_nav 
                              FROM PIMENTEL.APSSA_COMISION_FLETE
                              WHERE FECHA_CORTE BETWEEN @FECHA_INI AND @FECHA_FIN;
                             ";
            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@FECHA_INI", f1));
            arParam.Add(new SqlParameter("@FECHA_FIN", f2));
            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray()).Tables[0];
        }


        public static DataTable dtRecuperarPenalidades_DL(DateTime f1, DateTime f2, string db)
        {
            string strSql = @"SELECT 
	                          F_Facturacion,C_fac,N_Fac,codcdv,nomcdv,codven,nomven,codcli,nomcli,tienda,
	                          mone,tcam,codf,codi,descr,cant,cdes,Monto,pena45,pena90,comision,flag,
	                          situacion,vencimiento,uabono,dias,letra,nlet,estado,penalidad,politica,
	                          observacion,tipo,fproceso,fecha_corte,fupdate,codcli_nav,codven_nav,codf_nav,codi_nav                             
                              FROM PIMENTEL.APSSA_COMISION_PENALIDAD
                              WHERE FECHA_CORTE BETWEEN @FECHA_INI AND @FECHA_FIN;
                             ";
            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@FECHA_INI", f1));
            arParam.Add(new SqlParameter("@FECHA_FIN", f2));
            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray()).Tables[0];
        }

        public static DataTable dtRecuperarVentaSoles_DL(DateTime f1, DateTime f2, string db)
        {
            string strSql = @"SELECT
	                          VENDEDOR,VENDEDOR_NOMBRE,FECHA,TIPO_DOC,DOCUMENTO,CP,CONDIC_PAGO,COD_CLIENTE,
	                          CLIENTE,MONEDA,T_CAMBIO,CODIGO,COD_PROV,DESCRIPCION,CANTIDAD,PRECIO_U,TOTAL,
	                          ESTA_DESPACHADO,DESPACHADO,BASE_COMISION,PORC_COMIS,MONTO_COMISION,FAMILIA,
	                          SUB_FAMILIA,GRUPO,MARCA,LINEA,BODEGA,TIENDA,SUCURSAL,LUGAR,SCC,VENTA_DOLAR,
	                          COSTO_DOLAR,MARGEN_DOLAR,PORC_MARGEN_DOLAR,VENTA_SOLES,COSTO_SOLES,MARGEN_SOLES,
	                          PORC_MARGEN_SOLES,FAM_TIPO,OBSERVACIONES,SITUACION,VENCIMIENTO,UABONO,DIAS,
	                          SALDO,LETRA,LETRA_NUM,LETRA_SALDO,LETRA_VCMTO,LETRA_PENA,LETRA_DIAS,LETRA_UABONO,
	                          ESTADO,PENALIDAD,POLITICA,FLAG,FECHA_CORTE,FPROCESO	 
                              FROM PIMENTEL.APSSA_COMISION_VENTAS_SOLES
                              WHERE FECHA_CORTE BETWEEN @FECHA_INI AND @FECHA_FIN;
                             ";
            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@FECHA_INI", f1));
            arParam.Add(new SqlParameter("@FECHA_FIN", f2));
            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray()).Tables[0];
        }

        public static DataSet Listar_Annos(string db)
        {
            try
            {
                DataSet ds_listano = new DataSet();

                string strSql = @" SELECT DISTINCT ANNO 
                                   FROM PIMENTEL.APSSA_COMISION_PERIODOS  
                                   WHERE TIPO='F'   
                                   ORDER BY ANNO DESC; ";

                ds_listano = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql);

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
                DataSet ds_listaper = new DataSet();

                string strSql = @"SELECT
                                  IDPERIODO,TIPO,ANNO,PERIODO,FECHA_INICIO,FECHA_FINAL,COMENTARIO
                                  FROM PIMENTEL.APSSA_COMISION_PERIODOS
                                  WHERE TIPO='F' and ANNO=@ANNO
                                  ORDER BY FECHA_FINAL DESC;                                 
                                 ";

                List<SqlParameter> arParam = new List<SqlParameter>();
                arParam.Add(new SqlParameter("@ANNO", cAnno));
                ds_listaper = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray());

                ds_listaper.Tables[0].TableName = "listaper";
                return ds_listaper;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public static DataSet CargaDatoPeriodo(string cYear, string cPeriodo, string db)
        {
            DataSet ds_per = new DataSet();

            string strSql = @"SELECT
                              IDPERIODO,TIPO,ANNO,PERIODO,FECHA_INICIO,FECHA_FINAL,COMENTARIO
                              FROM PIMENTEL.APSSA_COMISION_PERIODOS
                              WHERE TIPO='F' and ANNO=@ANNO AND PERIODO=@PERIODO;
                             ";



            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@ANNO", cYear));
            arParam.Add(new SqlParameter("@PERIODO", cPeriodo));
            ds_per = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray());

            ds_per.Tables[0].TableName = "per";
            return ds_per;
        }

        public static DataSet CargaParametros(Int32 idperiod, string db)
        {
            try
            {
                DataSet ds_pa = new DataSet();

                string strSql = @"  SELECT IDPERIODO,
                                    IDPARAMETRO,CATEGORIA,VALOR,DESCRIPCION_PARAMETRO,FECHA_INICIO,FECHA_FINAL
                                    FROM PIMENTEL.APSSA_COMISION_PARAMETROS
                                    WHERE IDPERIODO=@IDPERIODO;
                                 ";
                List<SqlParameter> arParam = new List<SqlParameter>();
                arParam.Add(new SqlParameter("@IDPERIODO", idperiod));
                ds_pa = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray());

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

                string strSql = @"  SELECT
                                    IDPERIODO,TIPO,ANNO,PERIODO,FECHA_INICIO,FECHA_FINAL,COMENTARIO
                                    FROM PIMENTEL.APSSA_COMISION_PERIODOS 
                                    WHERE TIPO='F'
                                    ORDER BY FECHA_FINAL DESC;
                                 ";

                ds_pe = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql);

                ds_pe.Tables[0].TableName = "pe";
                return ds_pe;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public static void GrabarParametro(string cValor, string cIdPara, string db)
        {

            string strSql = @"UPDATE PIMENTEL.APSSA_COMISION_PARAMETROS
                                SET  VALOR = @VALOR                 
                                WHERE IDPARAMETRO LIKE @IDPARAMETRO;";

            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@VALOR", cValor));
            arParam.Add(new SqlParameter("@IDPARAMETRO", cIdPara));

            SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray());
        }

        public static void GrabarPeriodos(DateTime dfecinicio, DateTime dfecfinal, string canno, string cperiodo, string db)
        {

            string strSql = @"UPDATE PIMENTEL.APSSA_COMISION_PERIODOS        
                                SET  
                                FECHA_INICIO=@FECHA_INICIO,
                                FECHA_FINAL=@FECHA_FINAL
                                WHERE  TIPO='F' AND ANNO=@ANNO AND PERIODO=@PERIODO;";

            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@FECHA_INICIO", dfecinicio));
            arParam.Add(new SqlParameter("@FECHA_FINAL", dfecfinal));
            arParam.Add(new SqlParameter("@ANNO", canno));
            arParam.Add(new SqlParameter("@PERIODO", cperiodo));

            SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray());
        }


        //FLETES
        public static bool ValidarFacturaBoleta(string cdocu, string ndocu, DateTime f1, DateTime f2, string db)
        {
            string strSql = @"SELECT COUNT(*) 
                              FROM PIMENTEL.FACTURA
                              WHERE TIPO_DOCUMENTO=@TIPO_DOCUMENTO AND FACTURA=@FACTURA  ;";

            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@TIPO_DOCUMENTO", cdocu));
            arParam.Add(new SqlParameter("@FACTURA", ndocu));

            int count = Convert.ToInt32(SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray()));

            if (count == 0)
                return false;
            else
                return true;
        }

        public static void DeleteTmpFlete(string db)
        {
            string strSql = @"DELETE FROM PIMENTEL.TMP_APSSA_FLETE
                             ";

            SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql);
        }

        public static void ProcesaTmpFlete(string cCdocu, string cNdocu, Decimal nFlete, DateTime fecha1, DateTime fecha2, string db)
        {
            string strSql = @"INSERT INTO PIMENTEL.TMP_APSSA_FLETE
                                (f_facturacion,c_fac,n_fac,codcdv,nomcdv,codcli,nomcli,
                                 codven,nomven,tienda,mone,codf,codi,descr,cant,cdes,
                                 monto,pena45,pena90,fproceso,comision,observacion)
                                 SELECT 
                                 F.FECHA as f_facturacion,F.TIPO_DOCUMENTO as c_fac,F.FACTURA as n_fac,
                                 F.CONDICION_PAGO, C.DESCRIPCION,F.CLIENTE,F.NOMBRE_CLIENTE,F.VENDEDOR,
                                 V.NOMBRE,Z.NOMBRE, space(1) as MONE,space(15) as CODF,space(11) as CODI,
                                 space(25) as DESCR,0 as CANT,0 as cdes,0 as monto,0 as pena45,
                                 0 as pena90, GETDATE() as FPROCESO, 
                                 CAST(@monto AS DECIMAL(10, 2))/100 as COMISION,
                                 'FLETES DEL PERIODO '+CONVERT (char(10), @fecha1, 103)+
                                 ' AL '+CONVERT (char(10), @fecha2, 103) AS 'OBSERVACION'
                                 FROM PIMENTEL.FACTURA F
                                 LEFT JOIN PIMENTEL.VENDEDOR V ON F.VENDEDOR=V.VENDEDOR
                                 LEFT JOIN PIMENTEL.CONDICION_PAGO C ON F.CONDICION_PAGO=C.CONDICION_PAGO 
                                 LEFT JOIN PIMENTEL.ZONA  Z ON F.ZONA=Z.ZONA  
                                 WHERE  F.TIPO_DOCUMENTO = @cdocu and F.FACTURA = @ndocu ;
                             ";

            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@cdocu", cCdocu));
            arParam.Add(new SqlParameter("@ndocu", cNdocu));
            arParam.Add(new SqlParameter("@monto", nFlete));
            arParam.Add(new SqlParameter("@fecha1", fecha1));
            arParam.Add(new SqlParameter("@fecha2", fecha2));

            SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray());
        }

        public static Tmp_Flete GrabaTmpFlete(Tmp_Flete tmpflete, string db) // DEBE GRABAR EN HISTORICO
        {
            string strSql = @"INSERT INTO PIMENTEL.APSSA_COMISION_FLETE
                            (f_facturacion,c_fac,n_fac,codcdv,nomcdv,codcli,nomcli,
                             codven,nomven,tienda,mone,codf,codi,descr,cant,cdes,
                             monto, pena45,pena90,fproceso,comision,observacion)
                             VALUES
                            (@f_facturacion,@c_fac,@n_fac,@codcdv,@nomcdv,@codcli,@nomcli,
                             @codven,@nomven,@tienda,@mone,@codf,@codi,@descr,@cant,@cdes,
                             @monto,@pena45,@pena90,@fproceso,@comision,@observacion);
                            ";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@f_facturacion", tmpflete.f_facturacion));
            arParams.Add(new SqlParameter("@c_fac", tmpflete.c_fac));
            arParams.Add(new SqlParameter("@n_fac", tmpflete.n_fac));
            arParams.Add(new SqlParameter("@codcdv", tmpflete.codcdv));
            arParams.Add(new SqlParameter("@nomcdv", tmpflete.nomcdv));
            arParams.Add(new SqlParameter("@codcli", tmpflete.codcli));
            arParams.Add(new SqlParameter("@nomcli", tmpflete.nomcli));
            arParams.Add(new SqlParameter("@codven", tmpflete.codven));
            arParams.Add(new SqlParameter("@nomven", tmpflete.nomven));
            arParams.Add(new SqlParameter("@tienda", tmpflete.tienda));
            arParams.Add(new SqlParameter("@mone", tmpflete.mone));
            arParams.Add(new SqlParameter("@codf", tmpflete.codf));
            arParams.Add(new SqlParameter("@codi", tmpflete.codi));
            arParams.Add(new SqlParameter("@descr", tmpflete.descr));
            arParams.Add(new SqlParameter("@cant", tmpflete.cant));
            arParams.Add(new SqlParameter("@cdes", tmpflete.cdes));
            arParams.Add(new SqlParameter("@monto", tmpflete.monto));
            arParams.Add(new SqlParameter("@pena45", tmpflete.pena45));
            arParams.Add(new SqlParameter("@pena90", tmpflete.pena90));
            arParams.Add(new SqlParameter("@fproceso", tmpflete.fproceso));
            arParams.Add(new SqlParameter("@comision", tmpflete.comision));
            arParams.Add(new SqlParameter("@observacion", tmpflete.observacion));

            SqlHelper.ExecuteNonQuery(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParams.ToArray());
            return tmpflete;
        }

        public static DataSet CargaTmpFlete(string db)      //MAX31122015
        {
            DataSet ds_TmpFlete = new DataSet();

            string strSql = @" SELECT 
                              f_facturacion,c_fac,n_fac,codcdv,nomcdv,codcli,nomcli,
                              codven,nomven,tienda,mone,tcam,codf,codi,descr,cant,cdes,
                              monto,pena45,pena90,fproceso,comision,observacion
                              FROM PIMENTEL.TMP_APSSA_FLETE;
                            ";

            ds_TmpFlete = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql);
            ds_TmpFlete.Tables[0].TableName = "TmpFlete";
            return ds_TmpFlete;
        }

        //PENALIDAD
        public static void DeleteTmpPenalidad(string db)
        {
            string strSql = @"DELETE FROM PIMENTEL.TMP_APSSA_PENALIDAD
                             ";

            SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql);
        }

        //        public static void ProcesaTmpPenalidad(string cCdocu, string cNdocu, Decimal nFlete, string db)
        //        {
        //            string strSql = @"INSERT INTO PIMENTEL.TMP_APSSA_PENALIDAD
        //                                (f_facturacion,c_fac,n_fac,codcdv,nomcdv,codcli,nomcli,codven,nomven,nomtie,
        //                                mone,codf,codi,descr,cant,despacho,monto,pena45,pena90,fproceso,comision,
        //                                situacion,vencimiento,uabono,dias,letra,nlet,estado,penalidad,politica)
        //                                SELECT 
        //                                F.FECHA as f_facturacion,F.TIPO_DOCUMENTO as c_fac,F.FACTURA as n_fac,
        //                                F.CONDICION_PAGO, C.DESCRIPCION,F.CLIENTE,F.NOMBRE_CLIENTE,F.VENDEDOR,
        //                                V.NOMBRE,Z.NOMBRE, space(1) as MONE,space(15) as CODF,space(11) as CODI,
        //                                space(25) as DESCR,0 as CANT,0 as despacho,0 as monto,0 as pena45,
        //                                0 as pena90, GETDATE() as FPROCESO, 
        //                                CAST(@monto AS DECIMAL(10, 2))/100 as COMISION,'FLETES' as OBSERVACION
        //                                FROM PIMENTEL.FACTURA F
        //                                LEFT JOIN PIMENTEL.VENDEDOR V ON F.VENDEDOR=V.VENDEDOR
        //                                LEFT JOIN PIMENTEL.CONDICION_PAGO C ON F.CONDICION_PAGO=C.CONDICION_PAGO 
        //                                LEFT JOIN PIMENTEL.ZONA  Z ON F.ZONA=Z.ZONA  
        //                                WHERE  F.TIPO_DOCUMENTO = @cdocu and F.FACTURA = @ndocu ;
        //                             ";

        //            List<SqlParameter> arParam = new List<SqlParameter>();
        //            arParam.Add(new SqlParameter("@cdocu", cCdocu));
        //            arParam.Add(new SqlParameter("@ndocu", cNdocu));
        //            arParam.Add(new SqlParameter("@monto", nFlete));

        //            SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray());
        //        }

        public static Tmp_Penalidad ProcesaTmpPenalidad(Tmp_Penalidad tmppenalidad, string db)    // temporal
        {
            string strSql = @"
                            INSERT INTO PIMENTEL.TMP_APSSA_PENALIDAD
                            (f_facturacion,c_fac,n_fac,codcdv,nomcdv,codcli,nomcli,
                             codven,nomven,tienda,mone,codf,codi,descr,cant,cdes,
                             monto,pena45,pena90,fproceso,comision,observacion,situacion,vencimiento,
                             uabono,dias,letra,nlet,estado,penalidad,politica,flag)
                            VALUES
                            (@f_facturacion,@c_fac,@n_fac,@codcdv,@nomcdv,@codcli,@nomcli,
                             @codven,@nomven,@tienda,@mone,@codf,@codi,@descr,@cant,@cdes,
                             @monto,@pena45,@pena90,@fproceso,@comision,@observacion,@situacion,@vencimiento,
                             @uabono,@dias,@letra,@nlet,@estado,@penalidad,@politica,@flag)
                            ";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@f_facturacion", tmppenalidad.f_facturacion));
            arParams.Add(new SqlParameter("@c_fac", tmppenalidad.c_fac));
            arParams.Add(new SqlParameter("@n_fac", tmppenalidad.n_fac));
            arParams.Add(new SqlParameter("@codcdv", tmppenalidad.codcdv));
            arParams.Add(new SqlParameter("@nomcdv", tmppenalidad.nomcdv));
            arParams.Add(new SqlParameter("@codcli", tmppenalidad.codcli));
            arParams.Add(new SqlParameter("@nomcli", tmppenalidad.nomcli));
            arParams.Add(new SqlParameter("@codven", tmppenalidad.codven));
            arParams.Add(new SqlParameter("@nomven", tmppenalidad.nomven));
            arParams.Add(new SqlParameter("@tienda", tmppenalidad.tienda));
            arParams.Add(new SqlParameter("@mone", tmppenalidad.mone));
            arParams.Add(new SqlParameter("@codf", tmppenalidad.codf));
            arParams.Add(new SqlParameter("@codi", tmppenalidad.codi));
            arParams.Add(new SqlParameter("@descr", tmppenalidad.descr));
            arParams.Add(new SqlParameter("@cant", tmppenalidad.cant));
            arParams.Add(new SqlParameter("@cdes", tmppenalidad.cdes));
            arParams.Add(new SqlParameter("@monto", tmppenalidad.monto));
            arParams.Add(new SqlParameter("@pena45", tmppenalidad.pena45));
            arParams.Add(new SqlParameter("@pena90", tmppenalidad.pena90));
            arParams.Add(new SqlParameter("@fproceso", tmppenalidad.fproceso));
            arParams.Add(new SqlParameter("@comision", tmppenalidad.comision));
            arParams.Add(new SqlParameter("@observacion", tmppenalidad.observacion)); //ojo
            arParams.Add(new SqlParameter("@situacion", tmppenalidad.situacion));
            arParams.Add(new SqlParameter("@vencimiento", tmppenalidad.vencimiento));
            arParams.Add(new SqlParameter("@uabono", tmppenalidad.uabono));
            arParams.Add(new SqlParameter("@dias", tmppenalidad.dias));
            arParams.Add(new SqlParameter("@letra", tmppenalidad.letra));
            arParams.Add(new SqlParameter("@nlet", tmppenalidad.nlet));
            arParams.Add(new SqlParameter("@estado", tmppenalidad.estado));
            arParams.Add(new SqlParameter("@penalidad", tmppenalidad.penalidad));
            arParams.Add(new SqlParameter("@politica", tmppenalidad.politica));
            arParams.Add(new SqlParameter("@flag", tmppenalidad.flag)); //ojo

            SqlHelper.ExecuteNonQuery(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParams.ToArray());
            return tmppenalidad;
        }

        public static Tmp_Penalidad GrabaTmpPenalidad(Tmp_Penalidad tmppenalidad, string db) // DEBE GRABAR EN HISTORICO
        {
            string strSql = @"
                            INSERT INTO PIMENTEL.APSSA_COMISION_PENALIDAD
                            (f_facturacion,c_fac,n_fac,codcdv,nomcdv,codcli,nomcli,
                             codven,nomven,tienda,mone,codf,codi,descr,cant,cdes,
                             monto,pena45,pena90,fproceso,comision,situacion,vencimiento,
                             uabono,dias,letra,nlet,estado,penalidad,politica)
                            VALUES
                            (@f_facturacion,@c_fac,@n_fac,@codcdv,@nomcdv,@codcli,@nomcli,
                             @codven,@nomven,@tienda,@mone,@codf,@codi,@descr,@cant,@cdes,
                             @monto,@pena45,@pena90,@fproceso,@comision,@situacion,@vencimiento,
                             @uabono,@dias,@letra,@nlet,@estado,@penalidad,@politica)
                            ";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@f_facturacion", tmppenalidad.f_facturacion));
            arParams.Add(new SqlParameter("@c_fac", tmppenalidad.c_fac));
            arParams.Add(new SqlParameter("@n_fac", tmppenalidad.n_fac));
            arParams.Add(new SqlParameter("@codcdv", tmppenalidad.codcdv));
            arParams.Add(new SqlParameter("@nomcdv", tmppenalidad.nomcdv));
            arParams.Add(new SqlParameter("@codcli", tmppenalidad.codcli));
            arParams.Add(new SqlParameter("@nomcli", tmppenalidad.nomcli));
            arParams.Add(new SqlParameter("@codven", tmppenalidad.codven));
            arParams.Add(new SqlParameter("@nomven", tmppenalidad.nomven));
            arParams.Add(new SqlParameter("@tienda", tmppenalidad.tienda));
            arParams.Add(new SqlParameter("@mone", tmppenalidad.mone));
            arParams.Add(new SqlParameter("@codf", tmppenalidad.codf));
            arParams.Add(new SqlParameter("@codi", tmppenalidad.codi));
            arParams.Add(new SqlParameter("@descr", tmppenalidad.descr));
            arParams.Add(new SqlParameter("@cant", tmppenalidad.cant));
            arParams.Add(new SqlParameter("@cdes", tmppenalidad.cdes));
            arParams.Add(new SqlParameter("@monto", tmppenalidad.monto));
            arParams.Add(new SqlParameter("@pena45", tmppenalidad.pena45));
            arParams.Add(new SqlParameter("@pena90", tmppenalidad.pena90));
            arParams.Add(new SqlParameter("@fproceso", tmppenalidad.fproceso));
            arParams.Add(new SqlParameter("@comision", tmppenalidad.comision));
            arParams.Add(new SqlParameter("@situacion", tmppenalidad.situacion));
            arParams.Add(new SqlParameter("@vencimiento", tmppenalidad.vencimiento));
            arParams.Add(new SqlParameter("@uabono", tmppenalidad.uabono));
            arParams.Add(new SqlParameter("@dias", tmppenalidad.dias));
            arParams.Add(new SqlParameter("@letra", tmppenalidad.letra));
            arParams.Add(new SqlParameter("@nlet", tmppenalidad.nlet));
            arParams.Add(new SqlParameter("@estado", tmppenalidad.estado));
            arParams.Add(new SqlParameter("@penalidad", tmppenalidad.penalidad));
            arParams.Add(new SqlParameter("@politica", tmppenalidad.politica));

            SqlHelper.ExecuteNonQuery(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParams.ToArray());
            return tmppenalidad;
        }

        //BORRAR TEMPORAL VENTAS FLOTAS
        public static void DeleteTmpVentas(string db)
        {
            string strSql = @"DELETE FROM PIMENTEL.TMP_APSSA_VENTAS";

            SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql);
        }

        //OBTIENE VENTAS FLOTAS
        public static DataSet ObtenerVentasFlotas(DateTime dFecha1, DateTime dFecha2, string cfam1, string cfam2, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_COMISION_VENTAS_FLOTAS";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FECHAINI", dFecha1);
                    cmd.Parameters.AddWithValue("@FECHAFIN", dFecha2);
                    cmd.Parameters.AddWithValue("@FAMILIA1", cfam1);
                    cmd.Parameters.AddWithValue("@FAMILIA2", cfam2);
                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    ds.Tables.Add(table);
                }
                return ds;
            }
        }

        //public static DataSet ObtenerVentasFlotasSqlHelper(DateTime dFecha1, DateTime dFecha2, string cfam1, string cfam2, string db)
        //{
        //    DataSet ds_vtaflota = new DataSet();
        //    string strSql = "PIMENTEL.SP_APSSA_COMISION_VENTAS_FLOTAS";
        //    List<SqlParameter> arParams = new List<SqlParameter>();
        //    arParams.Add(new SqlParameter("@FECHAINI", dFecha1));
        //    arParams.Add(new SqlParameter("@FECHAFIN", dFecha2));
        //    arParams.Add(new SqlParameter("@FAMILIA1", cfam1));
        //    arParams.Add(new SqlParameter("@FAMILIA2", cfam2));
        //    ds_vtaflota = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray());
        //    ds_vtaflota.Tables[0].TableName = "vtaflota";
        //    return ds_vtaflota;
        //}

        //PROCESA COMISION
        public static DataSet ProcesaComisionSqlHelper(DateTime dFecha1, DateTime dFecha2, string db)
        {
            // CON PARAMETRO
            DataSet ds_proceso = new DataSet();

            //string strSql = "APSSA.SP_COMISION_FLOTAS_PROCESA";
            string strSql = "PIMENTEL.SP_APSSA_COMISION_FLOTAS_PROCESA";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@FechaProcesoIni", dFecha1));
            arParams.Add(new SqlParameter("@FechaProcesoFin", dFecha2));

            ds_proceso = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray());

            ds_proceso.Tables[0].TableName = "proceso";
            return ds_proceso;
        }

        public static DataSet ProcesaComision(DateTime dFecha1, DateTime dFecha2, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_COMISION_FLOTAS_PROCESA_V2";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FechaProcesoIni", dFecha1);
                    cmd.Parameters.AddWithValue("@FechaProcesoFin", dFecha2);
                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    ds.Tables.Add(table);
                }
                return ds;
            }
        }

        //--------------------------------------------------------------------------------------
        //-- GENERA COPIAS TEMPORALES
        //SELECT * INTO A_COMIS_FLETES FROM @FLETE;				--apssa.dbo.TMP_FLETES		fletes
        //SELECT * INTO A_COMIS_PENALIDADES FROM #finall;		--apssa.dbo.TMP_PENALIDADES penalidades
        //SELECT * INTO A_COMIS_VENTASOL FROM #periodo;			--apssa.dbo.TMP_VENTAS		ventas soles
        //SELECT * INTO A_COMIS_VENTADOL FROM #ventasdol;		--apssa.dbo.TMP_VENTASDOL	ventas dolares
        //SELECT * INTO A_COMIS_COMISIONES FROM #resumen;		--apssa.dbo.TMP_RESUMEN		comisiones SOLO DEL PERIODO, PARA REPORTE
        //SELECT * INTO A_COMIS_CANJEADAS FROM #canjeadas;		--apssa.dbo.TMP_CANJEADAS	canjeadas
        //SELECT * INTO A_COMIS_HISTORICO FROM @COMISION;		--si todo OK, debe reemplazar a PIMENTEL.APSSA_COMISION_FLOTAS
        //----------------------------------------------------------------------------------------

        public static DataTable dtListarResumenDL(string db)
        {
            string strSql = @"SELECT * 
                              FROM PIMENTEL.TMP_APSSA_COMIS_RESUMEN 
                              ORDER BY VENDEDOR;
                             ";

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql).Tables[0];
        }

        public static DataTable dtListarDetalleDL(string db)
        {
            string strSql = @"SELECT * 
                              FROM PIMENTEL.TMP_APSSA_COMIS_COMISION;
                             ";

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql).Tables[0];
        }

        public static DataTable dtListarFletesDL(string db)
        {
            string strSql = @"SELECT * 
                              FROM PIMENTEL.TMP_APSSA_COMIS_FLETE;
                             ";

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql).Tables[0];
        }


        public static DataTable dtListarPenalidadesDL(string db)
        {
            string strSql = @"SELECT *
                              FROM PIMENTEL.TMP_APSSA_COMIS_PENALIDAD;
                             ";

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql).Tables[0];
        }

        public static DataTable dtListarVentaSolesDL(string db)
        {
            string strSql = @"SELECT * 
                              FROM PIMENTEL.TMP_APSSA_COMIS_VENTASOL;
                             ";

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql).Tables[0];
        }

        public static DataTable dtListarVentaDolaresDL(string db)
        {
            string strSql = @"SELECT *
                              FROM PIMENTEL.TMP_APSSA_COMIS_VENTADOL;
                             ";

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql).Tables[0];
        }


        public static DataTable dtListarCanjeadasDL(string db)
        {
            string strSql = @"SELECT * 
                              FROM PIMENTEL.TMP_APSSA_COMIS_CANJEADA;
                             ";

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql).Tables[0];
        }

        public static void GrabarComisiones(string dfecini, string dfecfin, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                bool success = false;   //una variable boleana para determinar si se realizó la operación
                SqlTransaction sqlTransac = null;
                int Valor_Retornado = 0;    //variable para el valor de retorno
                try
                {
                    conn.Open();
                    sqlTransac = conn.BeginTransaction(System.Data.IsolationLevel.Serializable); //se inicia la transacción
                    SqlCommand sqlcmd = new SqlCommand("APSSA.SP_COMISION_FLOTAS_GUARDAR", conn, sqlTransac);
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.Parameters.Clear(); //se limpian los parámetros
                    //tipo de datos que coincida en sql server por ejemplo c# es string en sql server es varchar()
                    sqlcmd.Parameters.AddWithValue("@FechaProcesoIni", dfecini);
                    sqlcmd.Parameters.AddWithValue("@FechaProcesoFin", dfecfin);
                    SqlParameter ValorRetorno = new SqlParameter("@Comprobacion", SqlDbType.Int);   //declaramos el parámetro de retorno
                    ValorRetorno.Direction = ParameterDirection.Output; //asignamos el valor de retorno
                    sqlcmd.Parameters.Add(ValorRetorno);
                    sqlcmd.ExecuteNonQuery();
                    Valor_Retornado = Convert.ToInt32(ValorRetorno.Value);  // traemos el valor de retorno

                    //dependiendo del valor de retorno se asigna la variable success
                    //si el procedimiento retorna un 1 la operación se realizó con éxito
                    //de no ser así se mantiene en false y pr lo tanto falló la operación
                    if (Valor_Retornado == 1)
                        success = true;
                }
                catch (Exception)
                {
                    //MessageBox.Show("Error en la operación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (success)
                    {
                        sqlTransac.Commit(); //se realiza la transacción
                        conn.Close();
                        //MessageBox.Show("Se guardó la información satisfactoriamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        sqlTransac.Rollback();   //se deshace la transacción
                        conn.Close();
                    }
                }
            }

        }


        public static bool ExisteParametroPeriodoDL(Int32 periodo, string db)
        {

            string strSql = @"SELECT COUNT(*) 
                              FROM PIMENTEL.APSSA_COMISION_PARAMETROS 
                              WHERE IDPERIODO=@IDPERIODO  ;";

            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@IDPERIODO", periodo));

            int count = Convert.ToInt32(SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray()));

            if (count == 0)
                return false;
            else
                return true;
        }


        public static Int32 GrabarParametrosPeriodoDL(Int32 per_origen, Int32 per_destino, string cdb)
        {
            Int32 NumReg = 0;
            string strSql = "PIMENTEL.SP_APSSA_PARAMETROS_COMISIONES_CLONAR";
            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@PERIODO_ORIGEN", per_origen));
            arParams.Add(new SqlParameter("@PERIODO_DESTINO", per_destino));

            NumReg = Convert.ToInt32(SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(cdb), CommandType.StoredProcedure, strSql, arParams.ToArray()));
            return NumReg;
        }


        public static DataSet ObtenerVentasFlotasDL(DateTime dFecha1, DateTime dFecha2, string cfam1, string cfam2, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_COMISION_VENTAS_FLOTAS_V3";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FECHAINI", dFecha1);
                    cmd.Parameters.AddWithValue("@FECHAFIN", dFecha2);
                    cmd.Parameters.AddWithValue("@FAMILIA1", cfam1);
                    cmd.Parameters.AddWithValue("@FAMILIA2", cfam2);
                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    ds.Tables.Add(table);
                }
                return ds;
            }
        }

        public static DataSet ProcesaComisionDL(DateTime dFecha1, DateTime dFecha2, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_COMISION_FLOTAS_PROCESA_V3";
                //string connectionString = ConexionDC.ConectarBD(db);
                string connectionString = ConexionDC.ConectarBDSA(db);     // usuario SA
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FechaProcesoIni", dFecha1);
                    cmd.Parameters.AddWithValue("@FechaProcesoFin", dFecha2);
                    cmd.CommandTimeout = 0;
                    cmd.Connection.Open();
                    DataTable table = new DataTable();
                    table.Load(cmd.ExecuteReader());
                    ds.Tables.Add(table);
                }
                return ds;
            }
        }


        public static void EliminaInformacionDeProcesoAnteriorDL(string db)
        {
            string strSql = @"
                                DELETE FROM PIMENTEL.TMP_APSSA_COMISION;
                                DELETE FROM PIMENTEL.TMP_APSSA_FLETE;
                                DELETE FROM PIMENTEL.TMP_APSSA_PENALIDAD;
                                DELETE FROM PIMENTEL.TMP_APSSA_VENTAS;
                              ";

            SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql);
        }


        #endregion

        #region APROBACION_FACTURAS_DEVOLUCION
        public static DataSet CargaFacturas_Pendientes_Devolucion(string cliente, string fechai, string fechaf,int tipo_consulta,string db)
        {
            string strSql=string.Empty;
            if (tipo_consulta == 0)
            {
               // strSql = @"set language spanish; 
                 //            SELECT F.Tipo_Documento,F.Factura,F.Cliente,F.Nombre_Cliente,F.Fecha,F.Total_Mercaderia,F.Total_Factura,
                   //          F.Usa_Despachos,ISNULL(CAST(F.AUDIT_TRANS_INV AS VARCHAR),'') AS Aud_Inv,F.Cobrada,F.Condicion_Pago,F.MONEDA_FACTURA as Moneda,F.Vendedor,'' as OBSERVACION   
                     //        FROM PIMENTEL.FACTURA F 
                       //      WHERE TIPO_DOCUMENTO IN('F','B') AND F.ANULADA='N'
                         //    AND F.FECHA BETWEEN '" + fechai + "' AND '" + fechaf +
                           //  "' AND f.TIPO_DOCUMENTO+F.FACTURA not in (SELECT tipo_documento+factura FROM PIMENTEL.U_APROBACION_FD) ";

                strSql = @"set language spanish; 
                             SELECT F.Tipo_Documento,F.Factura,F.Cliente,F.Nombre_Cliente,F.Fecha,F.Total_Mercaderia,F.Total_Factura,
                             F.Usa_Despachos,ISNULL(CAST(F.AUDIT_TRANS_INV AS VARCHAR),'') AS Aud_Inv,F.Cobrada,F.Condicion_Pago,F.MONEDA_FACTURA as Moneda,F.Vendedor,'' as OBSERVACION   
                             FROM PIMENTEL.FACTURA F 
                             WHERE TIPO_DOCUMENTO IN('F','B') AND F.ANULADA='N'
                             AND F.FECHA BETWEEN '" + fechai + "' AND '" + fechaf +"'";

                if (cliente.Trim() != string.Empty)
                {
                    strSql = strSql + " AND F.CLIENTE='" + cliente + "'";
                }
                
            }
            else
            {
             //   strSql = @"set language spanish; 
               //              SELECT Tipo_documento,Factura,Cliente,Nombre_Cliente,Fecha,Total_Mercaderia,Total_Factura,Usuario_Aprueba,Fecha_Aprueba 
                 //            FROM PIMENTEL.U_APROBACION_FD 
                   //          WHERE FECHA BETWEEN '" + fechai + "' AND '" + fechaf +"' " ;

                strSql = @"set language spanish; 
                             SELECT Tipo_documento,Factura,Cliente,Nombre_Cliente
                             FROM PIMENTEL.FACTURA 
                             WHERE FECHA BETWEEN '" + fechai + "' AND '" + fechaf + "' ";

                if (cliente.Trim() != string.Empty)
                {
                    strSql = strSql + " AND CLIENTE='" + cliente + "'";
                }
                
            }

            DataSet ds_ = new DataSet();

            ds_ = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql);

            ds_.Tables[0].TableName = "FAC";
            return ds_;
        }


        public static DataSet Carga_Pedidos_7_Dias(string fechai, string fechaf, int tipo_consulta, string db)
        {
            string strSql = string.Empty;
            if (tipo_consulta == 0)
            {
                strSql = @"set language spanish; 
                            select CONVERT(DATE,fecha_pedido,103) AS fecha,pedido,cliente,nombre_cliente,CreatedBy     from pimentel.pedido 
                            where  CONDICION_PAGO in('F07D','B07')
                            and estado='N' and u_f7 is null
                            AND FECHA_PEDIDO BETWEEN '" + fechai + "' AND '" + fechaf + "'";
                                
            }
            else
            {
                

                strSql = @"set language spanish; 
                           select CONVERT(DATE,fecha_pedido,103) AS fecha,pedido,cliente,nombre_cliente,CreatedBy , estado,U_F7 as aprobado    from pimentel.pedido 
                            where  CONDICION_PAGO in('F07D','B07')
                            and u_f7='S' 
                            and FECHA_PEDIDO BETWEEN '" + fechai + "' AND '" + fechaf + "' ";

                
            }

            DataSet ds_ = new DataSet();

            ds_ = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql);

            ds_.Tables[0].TableName = "FAC";
            return ds_;
        }





        //public static Tmp_CostRepos ProcesaTmp_CostRepos(Tmp_CostRepos tmpcostrepos, string db)    // temporal
        public static Aprobacion_FD InsertarFD(Aprobacion_FD tmp_AprobacionFD,string bd)
        {
            
            string strSql = "UPDATE PIMENTEL.PEDIDO SET U_F7 ='S' WHERE PEDIDO=@PEDIDO AND ESTADO='N'";
                List<SqlParameter> arParams = new List<SqlParameter>();

                    arParams.Add(new SqlParameter("@PEDIDO",tmp_AprobacionFD.PEDIDO.Trim()));
                    
                    
                    SqlHelper.ExecuteNonQuery(ConexionDC.ConectarBD(bd), CommandType.Text, strSql, arParams.ToArray());
                    //return listapre;
                    
                    return tmp_AprobacionFD;
                    
        }
           

        #endregion

        #region INVENTARIO_VALORIZADO
        public static DataTable Inventario_Valorizado(String fecha_proceso,string moneda,string bodega,string familia,string subfamilia,string db)
        {
            //DataSet ds_ = new DataSet();

            //string strSql = "PIMENTEL.SP_VALORIZACION_INVENTARIO_BODEGA";
            //List<SqlParameter> arParams = new List<SqlParameter>();
            //arParams.Add(new SqlParameter("@FECHA_PROCESO", fecha_proceso));
            //arParams.Add(new SqlParameter("@MONEDA", moneda));
            //arParams.Add(new SqlParameter("@BODEGA", bodega));
            //arParams.Add(new SqlParameter("@FAMILIA", familia));
            //arParams.Add(new SqlParameter("@SUBFAMILIA", subfamilia));
           
            //ds_ = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray());
            //ds_.Tables[0].TableName = "INV";
            //return ds_.Tables[0];

            string TIPO_SP = string.Empty;
            TIPO_SP = "PIMENTEL.SP_VALORIZACION_INVENTARIO_BODEGA";
            string sqlCommand = TIPO_SP;
            string connectionString = ConexionDC.ConectarBD(db);
            DataSet ds = new DataSet();
            using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FECHA_PROCESO", fecha_proceso);
                cmd.Parameters.AddWithValue("@MONEDA", moneda);
                cmd.Parameters.AddWithValue("@BODEGA", bodega);
                cmd.Parameters.AddWithValue("@FAMILIA", familia);
                cmd.Parameters.AddWithValue("@SUBFAMILIA", subfamilia);
                
                cmd.CommandTimeout = 1000;
                cmd.Connection.Open();
                DataTable table = new DataTable();
                table.Load(cmd.ExecuteReader());
                ds.Tables.Add(table);
            }
            return ds.Tables[0];
        }

#endregion




//        #region COMISION_FLOTAS   UPDATE 20/07/2015, PARA frmComisionesFlotas_V3  XXXXXXXXXXXXXXXXXXXXXXXXXXXX

//        public static DataTable dtRecuperaComisionesTaller_DL(DateTime f1, DateTime f2, string opcion, string db)
//        {
//            string strSql = "PIMENTEL.SP_APSSA_GET_COMISION_TALLER";
//            List<SqlParameter> arParam = new List<SqlParameter>();
//            arParam.Add(new SqlParameter("@FECHA_INI", f1));
//            arParam.Add(new SqlParameter("@FECHA_FIN", f2));
//            arParam.Add(new SqlParameter("@OPCION", opcion));

//            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParam.ToArray()).Tables[0];
//        }

//        public static DataTable dtRecuperarComisionesTallerDetalle_DL(DateTime f1, DateTime f2, string db)
//        {
//            string strSql = @"SELECT
//                              FECHA_FAC,TIP_FAC,FACTURA,ORDEN,FECHA,NOMBRE_TECNICO,RAZON_SOCIAL,
//                              ITEM,ARTICULO,SERVICIO,MONEDA,P_UNIT,CANTIDAD,MONTO,TIPCAM,MONTO_SOLES,
//                              MONTO_DOLARES,PORC_COMIS,COMISION_SOLES,PEDIDO,ESTADO,CLIENTE,CP,
//                              NIVEL_PRECIO,COBRADOR,RUTA,ZONA,ZONA_NOMBRE,BODEGA,TECNICO,VENDEDOR,
//                              BOLETA_CS,BS,FECHA_INI,FECHA_FIN 
//                              FROM PIMENTEL.APSSA_COMISION_TALLER
//                              WHERE FECHA_INI >= @FECHA_INI  AND  FECHA_FIN<= @FECHA_FIN;
//                             ";
//            List<SqlParameter> arParam = new List<SqlParameter>();
//            arParam.Add(new SqlParameter("@FECHA_INI", f1));
//            arParam.Add(new SqlParameter("@FECHA_FIN", f2));
//            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray()).Tables[0];
//        }

//        public static DataTable dtRecuperarComisionesTallerTecnico_DL(DateTime f1, DateTime f2, string db)
//        {
//            string strSql = @"SELECT
//                              FECHA_FAC,TIP_FAC,FACTURA,ORDEN,FECHA,NOMBRE_TECNICO,RAZON_SOCIAL,
//                              ITEM,ARTICULO,SERVICIO,MONEDA,P_UNIT,CANTIDAD,MONTO,TIPCAM,MONTO_SOLES,
//                              MONTO_DOLARES,PORC_COMIS,COMISION_SOLES,PEDIDO,ESTADO,CLIENTE,CP,
//                              NIVEL_PRECIO,COBRADOR,RUTA,ZONA,ZONA_NOMBRE,BODEGA,TECNICO,VENDEDOR,
//                              BOLETA_CS,BS,FECHA_INI,FECHA_FIN 
//                              FROM PIMENTEL.APSSA_COMISION_TALLER
//                              WHERE FECHA_INI >= @FECHA_INI  AND  FECHA_FIN<= @FECHA_FIN;
//                             ";
//            List<SqlParameter> arParam = new List<SqlParameter>();
//            arParam.Add(new SqlParameter("@FECHA_INI", f1));
//            arParam.Add(new SqlParameter("@FECHA_FIN", f2));
//            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray()).Tables[0];
//        }

//        public static DataTable dtRecuperarComisionesTallerJefeTaller_DL(DateTime f1, DateTime f2, string db)
//        {
//            string strSql = @"SELECT
//                              FECHA_FAC,TIP_FAC,FACTURA,ORDEN,FECHA,NOMBRE_TECNICO,RAZON_SOCIAL,
//                              ITEM,ARTICULO,SERVICIO,MONEDA,P_UNIT,CANTIDAD,MONTO,TIPCAM,MONTO_SOLES,
//                              MONTO_DOLARES,PORC_COMIS,COMISION_SOLES,PEDIDO,ESTADO,CLIENTE,CP,
//                              NIVEL_PRECIO,COBRADOR,RUTA,ZONA,ZONA_NOMBRE,BODEGA,TECNICO,VENDEDOR,
//                              BOLETA_CS,BS,FECHA_INI,FECHA_FIN 
//                              FROM PIMENTEL.APSSA_COMISION_TALLER
//                              WHERE FECHA_INI >= @FECHA_INI  AND  FECHA_FIN<= @FECHA_FIN;
//                             ";
//            List<SqlParameter> arParam = new List<SqlParameter>();
//            arParam.Add(new SqlParameter("@FECHA_INI", f1));
//            arParam.Add(new SqlParameter("@FECHA_FIN", f2));
//            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray()).Tables[0];
//        }


//        public static DataTable CargaDatoPeriodoComision_DL(string cTipo, string cYear, string cPeriodo, string db)
//        {
//            string strSql = @"SELECT
//                              IDPERIODO,TIPO,ANNO,PERIODO,FECHA_INICIO,FECHA_FINAL,COMENTARIO
//                              FROM PIMENTEL.APSSA_COMISION_PERIODOS
//                              WHERE TIPO=@TIPO and ANNO=@ANNO AND PERIODO=@PERIODO;
//                             ";

//            List<SqlParameter> arParams = new List<SqlParameter>();
//            arParams.Add(new SqlParameter("@TIPO", cTipo));
//            arParams.Add(new SqlParameter("@ANNO", cYear));
//            arParams.Add(new SqlParameter("@PERIODO", cPeriodo));

//            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParams.ToArray()).Tables[0];
//        }

//        public static DataTable CargaPeriodosComision_DL(string tipo, string anno, string db)
//        {
//            string strSql = @"  SELECT
//                                    IDPERIODO,TIPO,ANNO,PERIODO,FECHA_INICIO,FECHA_FINAL,ESTADO,COMENTARIO
//                                    FROM PIMENTEL.APSSA_COMISION_PERIODOS 
//                                    WHERE ANNO=@ANNO AND TIPO=@TIPO
//                                    ORDER BY FECHA_FINAL DESC; ";

//            List<SqlParameter> arParams = new List<SqlParameter>();
//            arParams.Add(new SqlParameter("@TIPO", tipo));
//            arParams.Add(new SqlParameter("@ANNO", anno));


//            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParams.ToArray()).Tables[0];
//        }


//        public static DataTable Listar_Annos_Comision_DL(string tipo, string db)
//        {
//            string strSql = @" SELECT DISTINCT ANNO 
//                                   FROM PIMENTEL.APSSA_COMISION_PERIODOS  
//                                   WHERE TIPO=@TIPO  
//                                   ORDER BY ANNO DESC; ";

//            List<SqlParameter> arParam = new List<SqlParameter>();
//            arParam.Add(new SqlParameter("@TIPO", tipo));

//            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray()).Tables[0];
//        }

//        public static void GrabarPeriodosComision_DL(DateTime dfecinicio, DateTime dfecfinal, string cestado, string ccomentario, string ctipo, string canno, string cperiodo, string db)
//        {

//            string strSql = @"UPDATE PIMENTEL.APSSA_COMISION_PERIODOS        
//                                SET  
//                                FECHA_INICIO=@FECHA_INICIO,
//                                FECHA_FINAL=@FECHA_FINAL,
//                                ESTADO=@ESTADO,
//                                COMENTARIO=@COMENTARIO
//                                WHERE  TIPO=@TIPO AND ANNO=@ANNO AND PERIODO=@PERIODO;";

//            List<SqlParameter> arParam = new List<SqlParameter>();
//            arParam.Add(new SqlParameter("@FECHA_INICIO", dfecinicio));
//            arParam.Add(new SqlParameter("@FECHA_FINAL", dfecfinal));
//            arParam.Add(new SqlParameter("@ESTADO", cestado));
//            arParam.Add(new SqlParameter("@COMENTARIO", ccomentario));
//            arParam.Add(new SqlParameter("@TIPO", ctipo));
//            arParam.Add(new SqlParameter("@ANNO", canno));
//            arParam.Add(new SqlParameter("@PERIODO", cperiodo));

//            SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray());
//        }



//        //************************************************************************************************************
//        public static DataTable dtRecuperarComisionesDetalle_DL(DateTime f1, DateTime f2, string db)
//        {
//            string strSql = @"SELECT
//	                          F_Facturacion,C_fac,N_Fac,codcdv,nomcdv,codven,nomven,codcli,nomcli,nomtie,
//	                          mone,tcam,codf,codi,descr,cant,cdes,Monto,pena45,pena90,comision,flag,
//	                          situacion,vencimiento,uabono,dias,letra,nlet,estado,penalidad,politica,
//	                          observacion,tipo,fproceso,fecha_corte,fupdate,codcli_nav,codven_nav,codf_nav,codi_nav 
//                              FROM PIMENTEL.APSSA_COMISION_COMISION
//                              WHERE FECHA_CORTE BETWEEN @FECHA_INI AND @FECHA_FIN;
//                             ";
//            List<SqlParameter> arParam = new List<SqlParameter>();
//            arParam.Add(new SqlParameter("@FECHA_INI", f1));
//            arParam.Add(new SqlParameter("@FECHA_FIN", f2));
//            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray()).Tables[0];
//        }

//        public static DataTable dtRecuperarFletes_DL(DateTime f1, DateTime f2, string db)
//        {
//            string strSql = @"SELECT 
//	                          F_Facturacion,C_fac,N_Fac,codcdv,nomcdv,codven,nomven,codcli,nomcli,nomtie,
//	                          mone,tcam,codf,codi,descr,cant,cdes,Monto,pena45,pena90,comision,flag,
//	                          situacion,vencimiento,uabono,dias,letra,nlet,estado,penalidad,politica,
//	                          observacion,tipo,fproceso,fecha_corte,fupdate,codcli_nav,codven_nav,codf_nav,codi_nav 
//                              FROM PIMENTEL.APSSA_COMISION_FLETE
//                              WHERE FECHA_CORTE BETWEEN @FECHA_INI AND @FECHA_FIN;
//                             ";
//            List<SqlParameter> arParam = new List<SqlParameter>();
//            arParam.Add(new SqlParameter("@FECHA_INI", f1));
//            arParam.Add(new SqlParameter("@FECHA_FIN", f2));
//            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray()).Tables[0];
//        }


//        public static DataTable dtRecuperarPenalidades_DL(DateTime f1, DateTime f2, string db)
//        {
//            string strSql = @"SELECT 
//	                          F_Facturacion,C_fac,N_Fac,codcdv,nomcdv,codven,nomven,codcli,nomcli,nomtie,
//	                          mone,tcam,codf,codi,descr,cant,cdes,Monto,pena45,pena90,comision,flag,
//	                          situacion,vencimiento,uabono,dias,letra,nlet,estado,penalidad,politica,
//	                          observacion,tipo,fproceso,fecha_corte,fupdate,codcli_nav,codven_nav,codf_nav,codi_nav                             
//                              FROM PIMENTEL.APSSA_COMISION_PENALIDAD
//                              WHERE FECHA_CORTE BETWEEN @FECHA_INI AND @FECHA_FIN;
//                             ";
//            List<SqlParameter> arParam = new List<SqlParameter>();
//            arParam.Add(new SqlParameter("@FECHA_INI", f1));
//            arParam.Add(new SqlParameter("@FECHA_FIN", f2));
//            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray()).Tables[0];
//        }

//        public static DataTable dtRecuperarVentaSoles_DL(DateTime f1, DateTime f2, string db)
//        {
//            string strSql = @"SELECT
//	                          VENDEDOR,VENDEDOR_NOMBRE,FECHA,TIPO_DOC,DOCUMENTO,CP,CONDIC_PAGO,COD_CLIENTE,
//	                          CLIENTE,MONEDA,T_CAMBIO,CODIGO,COD_PROV,DESCRIPCION,CANTIDAD,PRECIO_U,TOTAL,
//	                          ESTA_DESPACHADO,DESPACHADO,BASE_COMISION,PORC_COMIS,MONTO_COMISION,FAMILIA,
//	                          SUB_FAMILIA,GRUPO,MARCA,LINEA,BODEGA,TIENDA,SUCURSAL,LUGAR,SCC,VENTA_DOLAR,
//	                          COSTO_DOLAR,MARGEN_DOLAR,PORC_MARGEN_DOLAR,VENTA_SOLES,COSTO_SOLES,MARGEN_SOLES,
//	                          PORC_MARGEN_SOLES,FAM_TIPO,OBSERVACIONES,SITUACION,VENCIMIENTO,UABONO,DIAS,
//	                          SALDO,LETRA,LETRA_NUM,LETRA_SALDO,LETRA_VCMTO,LETRA_PENA,LETRA_DIAS,LETRA_UABONO,
//	                          ESTADO,PENALIDAD,POLITICA,FLAG,FECHA_CORTE,FPROCESO	 
//                              FROM PIMENTEL.APSSA_COMISION_VENTAS_SOLES
//                              WHERE FECHA_CORTE BETWEEN @FECHA_INI AND @FECHA_FIN;
//                             ";
//            List<SqlParameter> arParam = new List<SqlParameter>();
//            arParam.Add(new SqlParameter("@FECHA_INI", f1));
//            arParam.Add(new SqlParameter("@FECHA_FIN", f2));
//            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray()).Tables[0];
//        }

//        public static DataSet Listar_Annos(string db)
//        {
//            try
//            {
//                DataSet ds_listano = new DataSet();

//                string strSql = @" SELECT DISTINCT ANNO 
//                                   FROM PIMENTEL.APSSA_COMISION_PERIODOS  
//                                   WHERE TIPO='F'   
//                                   ORDER BY ANNO DESC; ";

//                ds_listano = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql);

//                ds_listano.Tables[0].TableName = "listano";
//                return ds_listano;
//            }
//            catch (Exception ex)
//            {
//                throw new ArgumentException(ex.Message);
//            }
//        }

//        public static DataSet Listar_periodo(string cAnno, string db)
//        {
//            try
//            {
//                DataSet ds_listaper = new DataSet();

//                string strSql = @"SELECT
//                                  IDPERIODO,TIPO,ANNO,PERIODO,FECHA_INICIO,FECHA_FINAL,COMENTARIO
//                                  FROM PIMENTEL.APSSA_COMISION_PERIODOS
//                                  WHERE TIPO='F' and ANNO=@ANNO
//                                  ORDER BY FECHA_FINAL DESC;                                 
//                                 ";

//                List<SqlParameter> arParam = new List<SqlParameter>();
//                arParam.Add(new SqlParameter("@ANNO", cAnno));
//                ds_listaper = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray());

//                ds_listaper.Tables[0].TableName = "listaper";
//                return ds_listaper;
//            }
//            catch (Exception ex)
//            {
//                throw new ArgumentException(ex.Message);
//            }
//        }

//        public static DataSet CargaDatoPeriodo(string cYear, string cPeriodo, string db)
//        {
//            DataSet ds_per = new DataSet();

//            string strSql = @"SELECT
//                              IDPERIODO,TIPO,ANNO,PERIODO,FECHA_INICIO,FECHA_FINAL,COMENTARIO
//                              FROM PIMENTEL.APSSA_COMISION_PERIODOS
//                              WHERE TIPO='F' and ANNO=@ANNO AND PERIODO=@PERIODO;
//                             ";



//            List<SqlParameter> arParam = new List<SqlParameter>();
//            arParam.Add(new SqlParameter("@ANNO", cYear));
//            arParam.Add(new SqlParameter("@PERIODO", cPeriodo));
//            ds_per = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray());

//            ds_per.Tables[0].TableName = "per";
//            return ds_per;
//        }

//        public static DataSet CargaParametros(Int32 idperiod, string db)
//        {
//            try
//            {
//                DataSet ds_pa = new DataSet();

//                string strSql = @"  SELECT IDPERIODO,
//                                    IDPARAMETRO,CATEGORIA,VALOR,DESCRIPCION_PARAMETRO,FECHA_INICIO,FECHA_FINAL
//                                    FROM PIMENTEL.APSSA_COMISION_PARAMETROS
//                                    WHERE IDPERIODO=@IDPERIODO;
//                                 ";
//                List<SqlParameter> arParam = new List<SqlParameter>();
//                arParam.Add(new SqlParameter("@IDPERIODO", idperiod));
//                ds_pa = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray());

//                ds_pa.Tables[0].TableName = "pa";
//                return ds_pa;
//            }
//            catch (Exception ex)
//            {
//                throw new ArgumentException(ex.Message);
//            }
//        }

//        public static DataSet CargaPeriodos(string db)
//        {
//            try
//            {
//                DataSet ds_pe = new DataSet();

//                string strSql = @"  SELECT
//                                    IDPERIODO,TIPO,ANNO,PERIODO,FECHA_INICIO,FECHA_FINAL,COMENTARIO
//                                    FROM PIMENTEL.APSSA_COMISION_PERIODOS 
//                                    WHERE TIPO='F'
//                                    ORDER BY FECHA_FINAL DESC;
//                                 ";

//                ds_pe = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql);

//                ds_pe.Tables[0].TableName = "pe";
//                return ds_pe;
//            }
//            catch (Exception ex)
//            {
//                throw new ArgumentException(ex.Message);
//            }
//        }

//        public static void GrabarParametro(string cValor, string cIdPara, string db)
//        {

//            string strSql = @"UPDATE PIMENTEL.APSSA_COMISION_PARAMETROS
//                                SET  VALOR = @VALOR                 
//                                WHERE IDPARAMETRO LIKE @IDPARAMETRO;";

//            List<SqlParameter> arParam = new List<SqlParameter>();
//            arParam.Add(new SqlParameter("@VALOR", cValor));
//            arParam.Add(new SqlParameter("@IDPARAMETRO", cIdPara));

//            SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray());
//        }

//        public static void GrabarPeriodos(DateTime dfecinicio, DateTime dfecfinal, string canno, string cperiodo, string db)
//        {

//            string strSql = @"UPDATE PIMENTEL.APSSA_COMISION_PERIODOS        
//                                SET  
//                                FECHA_INICIO=@FECHA_INICIO,
//                                FECHA_FINAL=@FECHA_FINAL
//                                WHERE  TIPO='F' AND ANNO=@ANNO AND PERIODO=@PERIODO;";

//            List<SqlParameter> arParam = new List<SqlParameter>();
//            arParam.Add(new SqlParameter("@FECHA_INICIO", dfecinicio));
//            arParam.Add(new SqlParameter("@FECHA_FINAL", dfecfinal));
//            arParam.Add(new SqlParameter("@ANNO", canno));
//            arParam.Add(new SqlParameter("@PERIODO", cperiodo));

//            SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray());
//        }


//        //FLETES
//        public static bool ValidarFacturaBoleta(string cdocu, string ndocu, DateTime f1, DateTime f2, string db)
//        {
//            string strSql = @"SELECT COUNT(*) 
//                              FROM PIMENTEL.FACTURA
//                              WHERE TIPO_DOCUMENTO=@TIPO_DOCUMENTO AND FACTURA=@FACTURA  ;";

//            List<SqlParameter> arParam = new List<SqlParameter>();
//            arParam.Add(new SqlParameter("@TIPO_DOCUMENTO", cdocu));
//            arParam.Add(new SqlParameter("@FACTURA", ndocu));

//            int count = Convert.ToInt32(SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray()));

//            if (count == 0)
//                return false;
//            else
//                return true;
//        }

//        public static void DeleteTmpFlete(string db)
//        {
//            string strSql = @"DELETE FROM PIMENTEL.TMP_APSSA_FLETE
//                             ";

//            SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql);
//        }

//        public static void ProcesaTmpFlete(string cCdocu, string cNdocu, Decimal nFlete, DateTime fecha1, DateTime fecha2, string db)
//        {
//            string strSql = @"INSERT INTO PIMENTEL.TMP_APSSA_FLETE
//                                (f_facturacion,c_fac,n_fac,codcdv,nomcdv,codcli,nomcli,
//                                 codven,nomven,nomtie,mone,codf,codi,descr,cant,cdes,
//                                 monto,pena45,pena90,fproceso,comision,observacion)
//                                 SELECT 
//                                 F.FECHA as f_facturacion,F.TIPO_DOCUMENTO as c_fac,F.FACTURA as n_fac,
//                                 F.CONDICION_PAGO, C.DESCRIPCION,F.CLIENTE,F.NOMBRE_CLIENTE,F.VENDEDOR,
//                                 V.NOMBRE,Z.NOMBRE, space(1) as MONE,space(15) as CODF,space(11) as CODI,
//                                 space(25) as DESCR,0 as CANT,0 as cdes,0 as monto,0 as pena45,
//                                 0 as pena90, GETDATE() as FPROCESO, 
//                                 CAST(@monto AS DECIMAL(10, 2))/100 as COMISION,
//                                 'FLETES DEL PERIODO '+CONVERT (char(10), @fecha1, 103)+
//                                 ' AL '+CONVERT (char(10), @fecha2, 103) AS 'OBSERVACION'
//                                 FROM PIMENTEL.FACTURA F
//                                 LEFT JOIN PIMENTEL.VENDEDOR V ON F.VENDEDOR=V.VENDEDOR
//                                 LEFT JOIN PIMENTEL.CONDICION_PAGO C ON F.CONDICION_PAGO=C.CONDICION_PAGO 
//                                 LEFT JOIN PIMENTEL.ZONA  Z ON F.ZONA=Z.ZONA  
//                                 WHERE  F.TIPO_DOCUMENTO = @cdocu and F.FACTURA = @ndocu ;
//                             ";

//            List<SqlParameter> arParam = new List<SqlParameter>();
//            arParam.Add(new SqlParameter("@cdocu", cCdocu));
//            arParam.Add(new SqlParameter("@ndocu", cNdocu));
//            arParam.Add(new SqlParameter("@monto", nFlete));
//            arParam.Add(new SqlParameter("@fecha1", fecha1));
//            arParam.Add(new SqlParameter("@fecha2", fecha2));

//            SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray());
//        }

//        public static Tmp_Flete GrabaTmpFlete(Tmp_Flete tmpflete, string db) // DEBE GRABAR EN HISTORICO
//        {
//            string strSql = @"INSERT INTO PIMENTEL.APSSA_COMISION_FLETE
//                            (f_facturacion,c_fac,n_fac,codcdv,nomcdv,codcli,nomcli,
//                             codven,nomven,nomtie,mone,codf,codi,descr,cant,cdes,
//                             monto, pena45,pena90,fproceso,comision,observacion)
//                             VALUES
//                            (@f_facturacion,@c_fac,@n_fac,@codcdv,@nomcdv,@codcli,@nomcli,
//                             @codven,@nomven,@nomtie,@mone,@codf,@codi,@descr,@cant,@cdes,
//                             @monto,@pena45,@pena90,@fproceso,@comision,@observacion);
//                            ";

//            List<SqlParameter> arParams = new List<SqlParameter>();
//            arParams.Add(new SqlParameter("@f_facturacion", tmpflete.f_facturacion));
//            arParams.Add(new SqlParameter("@c_fac", tmpflete.c_fac));
//            arParams.Add(new SqlParameter("@n_fac", tmpflete.n_fac));
//            arParams.Add(new SqlParameter("@codcdv", tmpflete.codcdv));
//            arParams.Add(new SqlParameter("@nomcdv", tmpflete.nomcdv));
//            arParams.Add(new SqlParameter("@codcli", tmpflete.codcli));
//            arParams.Add(new SqlParameter("@nomcli", tmpflete.nomcli));
//            arParams.Add(new SqlParameter("@codven", tmpflete.codven));
//            arParams.Add(new SqlParameter("@nomven", tmpflete.nomven));
//            arParams.Add(new SqlParameter("@nomtie", tmpflete.nomtie));
//            arParams.Add(new SqlParameter("@mone", tmpflete.mone));
//            arParams.Add(new SqlParameter("@codf", tmpflete.codf));
//            arParams.Add(new SqlParameter("@codi", tmpflete.codi));
//            arParams.Add(new SqlParameter("@descr", tmpflete.descr));
//            arParams.Add(new SqlParameter("@cant", tmpflete.cant));
//            arParams.Add(new SqlParameter("@cdes", tmpflete.cdes));
//            arParams.Add(new SqlParameter("@monto", tmpflete.monto));
//            arParams.Add(new SqlParameter("@pena45", tmpflete.pena45));
//            arParams.Add(new SqlParameter("@pena90", tmpflete.pena90));
//            arParams.Add(new SqlParameter("@fproceso", tmpflete.fproceso));
//            arParams.Add(new SqlParameter("@comision", tmpflete.comision));
//            arParams.Add(new SqlParameter("@observacion", tmpflete.observacion));

//            SqlHelper.ExecuteNonQuery(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParams.ToArray());
//            return tmpflete;
//        }

//        public static DataSet CargaTmpFlete(string db)
//        {
//            DataSet ds_TmpFlete = new DataSet();

//            string strSql = @" SELECT 
//                              f_facturacion,c_fac,n_fac,codcdv,nomcdv,codcli,nomcli,
//                              codven,nomven,nomtie,mone,codf,codi,descr,cant,cdes,
//                              monto,pena45,pena90,fproceso,comision,observacion
//                              FROM PIMENTEL.TMP_APSSA_FLETE;
//                            ";

//            ds_TmpFlete = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql);
//            ds_TmpFlete.Tables[0].TableName = "TmpFlete";
//            return ds_TmpFlete;
//        }

//        //PENALIDAD
//        public static void DeleteTmpPenalidad(string db)
//        {
//            string strSql = @"DELETE FROM PIMENTEL.TMP_APSSA_PENALIDAD
//                             ";

//            SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql);
//        }

//        //        public static void ProcesaTmpPenalidad(string cCdocu, string cNdocu, Decimal nFlete, string db)
//        //        {
//        //            string strSql = @"INSERT INTO PIMENTEL.TMP_APSSA_PENALIDAD
//        //                                (f_facturacion,c_fac,n_fac,codcdv,nomcdv,codcli,nomcli,codven,nomven,nomtie,
//        //                                mone,codf,codi,descr,cant,despacho,monto,pena45,pena90,fproceso,comision,
//        //                                situacion,vencimiento,uabono,dias,letra,nlet,estado,penalidad,politica)
//        //                                SELECT 
//        //                                F.FECHA as f_facturacion,F.TIPO_DOCUMENTO as c_fac,F.FACTURA as n_fac,
//        //                                F.CONDICION_PAGO, C.DESCRIPCION,F.CLIENTE,F.NOMBRE_CLIENTE,F.VENDEDOR,
//        //                                V.NOMBRE,Z.NOMBRE, space(1) as MONE,space(15) as CODF,space(11) as CODI,
//        //                                space(25) as DESCR,0 as CANT,0 as despacho,0 as monto,0 as pena45,
//        //                                0 as pena90, GETDATE() as FPROCESO, 
//        //                                CAST(@monto AS DECIMAL(10, 2))/100 as COMISION,'FLETES' as OBSERVACION
//        //                                FROM PIMENTEL.FACTURA F
//        //                                LEFT JOIN PIMENTEL.VENDEDOR V ON F.VENDEDOR=V.VENDEDOR
//        //                                LEFT JOIN PIMENTEL.CONDICION_PAGO C ON F.CONDICION_PAGO=C.CONDICION_PAGO 
//        //                                LEFT JOIN PIMENTEL.ZONA  Z ON F.ZONA=Z.ZONA  
//        //                                WHERE  F.TIPO_DOCUMENTO = @cdocu and F.FACTURA = @ndocu ;
//        //                             ";

//        //            List<SqlParameter> arParam = new List<SqlParameter>();
//        //            arParam.Add(new SqlParameter("@cdocu", cCdocu));
//        //            arParam.Add(new SqlParameter("@ndocu", cNdocu));
//        //            arParam.Add(new SqlParameter("@monto", nFlete));

//        //            SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray());
//        //        }

//        public static Tmp_Penalidad ProcesaTmpPenalidad(Tmp_Penalidad tmppenalidad, string db)    // temporal
//        {
//            string strSql = @"
//                            INSERT INTO PIMENTEL.TMP_APSSA_PENALIDAD
//                            (f_facturacion,c_fac,n_fac,codcdv,nomcdv,codcli,nomcli,
//                             codven,nomven,nomtie,mone,codf,codi,descr,cant,cdes,
//                             monto,pena45,pena90,fproceso,comision,observacion,situacion,vencimiento,
//                             uabono,dias,letra,nlet,estado,penalidad,politica,flag)
//                            VALUES
//                            (@f_facturacion,@c_fac,@n_fac,@codcdv,@nomcdv,@codcli,@nomcli,
//                             @codven,@nomven,@nomtie,@mone,@codf,@codi,@descr,@cant,@cdes,
//                             @monto,@pena45,@pena90,@fproceso,@comision,@observacion,@situacion,@vencimiento,
//                             @uabono,@dias,@letra,@nlet,@estado,@penalidad,@politica,@flag)
//                            ";

//            List<SqlParameter> arParams = new List<SqlParameter>();
//            arParams.Add(new SqlParameter("@f_facturacion", tmppenalidad.f_facturacion));
//            arParams.Add(new SqlParameter("@c_fac", tmppenalidad.c_fac));
//            arParams.Add(new SqlParameter("@n_fac", tmppenalidad.n_fac));
//            arParams.Add(new SqlParameter("@codcdv", tmppenalidad.codcdv));
//            arParams.Add(new SqlParameter("@nomcdv", tmppenalidad.nomcdv));
//            arParams.Add(new SqlParameter("@codcli", tmppenalidad.codcli));
//            arParams.Add(new SqlParameter("@nomcli", tmppenalidad.nomcli));
//            arParams.Add(new SqlParameter("@codven", tmppenalidad.codven));
//            arParams.Add(new SqlParameter("@nomven", tmppenalidad.nomven));
//            arParams.Add(new SqlParameter("@nomtie", tmppenalidad.tienda));   //nomtie
//            arParams.Add(new SqlParameter("@mone", tmppenalidad.mone));
//            arParams.Add(new SqlParameter("@codf", tmppenalidad.codf));
//            arParams.Add(new SqlParameter("@codi", tmppenalidad.codi));
//            arParams.Add(new SqlParameter("@descr", tmppenalidad.descr));
//            arParams.Add(new SqlParameter("@cant", tmppenalidad.cant));
//            arParams.Add(new SqlParameter("@cdes", tmppenalidad.cdes));
//            arParams.Add(new SqlParameter("@monto", tmppenalidad.monto));
//            arParams.Add(new SqlParameter("@pena45", tmppenalidad.pena45));
//            arParams.Add(new SqlParameter("@pena90", tmppenalidad.pena90));
//            arParams.Add(new SqlParameter("@fproceso", tmppenalidad.fproceso));
//            arParams.Add(new SqlParameter("@comision", tmppenalidad.comision));
//            arParams.Add(new SqlParameter("@observacion", tmppenalidad.observacion)); //ojo
//            arParams.Add(new SqlParameter("@situacion", tmppenalidad.situacion));
//            arParams.Add(new SqlParameter("@vencimiento", tmppenalidad.vencimiento));
//            arParams.Add(new SqlParameter("@uabono", tmppenalidad.uabono));
//            arParams.Add(new SqlParameter("@dias", tmppenalidad.dias));
//            arParams.Add(new SqlParameter("@letra", tmppenalidad.letra));
//            arParams.Add(new SqlParameter("@nlet", tmppenalidad.nlet));
//            arParams.Add(new SqlParameter("@estado", tmppenalidad.estado));
//            arParams.Add(new SqlParameter("@penalidad", tmppenalidad.penalidad));
//            arParams.Add(new SqlParameter("@politica", tmppenalidad.politica));
//            arParams.Add(new SqlParameter("@flag", tmppenalidad.flag)); //ojo

//            SqlHelper.ExecuteNonQuery(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParams.ToArray());
//            return tmppenalidad;
//        }

//        public static Tmp_Penalidad GrabaTmpPenalidad(Tmp_Penalidad tmppenalidad, string db) // DEBE GRABAR EN HISTORICO
//        {
//            string strSql = @"
//                            INSERT INTO PIMENTEL.APSSA_COMISION_PENALIDAD
//                            (f_facturacion,c_fac,n_fac,codcdv,nomcdv,codcli,nomcli,
//                             codven,nomven,nomtie,mone,codf,codi,descr,cant,cdes,
//                             monto,pena45,pena90,fproceso,comision,situacion,vencimiento,
//                             uabono,dias,letra,nlet,estado,penalidad,politica)
//                            VALUES
//                            (@f_facturacion,@c_fac,@n_fac,@codcdv,@nomcdv,@codcli,@nomcli,
//                             @codven,@nomven,@nomtie,@mone,@codf,@codi,@descr,@cant,@cdes,
//                             @monto,@pena45,@pena90,@fproceso,@comision,@situacion,@vencimiento,
//                             @uabono,@dias,@letra,@nlet,@estado,@penalidad,@politica)
//                            ";

//            List<SqlParameter> arParams = new List<SqlParameter>();
//            arParams.Add(new SqlParameter("@f_facturacion", tmppenalidad.f_facturacion));
//            arParams.Add(new SqlParameter("@c_fac", tmppenalidad.c_fac));
//            arParams.Add(new SqlParameter("@n_fac", tmppenalidad.n_fac));
//            arParams.Add(new SqlParameter("@codcdv", tmppenalidad.codcdv));
//            arParams.Add(new SqlParameter("@nomcdv", tmppenalidad.nomcdv));
//            arParams.Add(new SqlParameter("@codcli", tmppenalidad.codcli));
//            arParams.Add(new SqlParameter("@nomcli", tmppenalidad.nomcli));
//            arParams.Add(new SqlParameter("@codven", tmppenalidad.codven));
//            arParams.Add(new SqlParameter("@nomven", tmppenalidad.nomven));
//            arParams.Add(new SqlParameter("@nomtie", tmppenalidad.tienda));   //nomtie
//            arParams.Add(new SqlParameter("@mone", tmppenalidad.mone));
//            arParams.Add(new SqlParameter("@codf", tmppenalidad.codf));
//            arParams.Add(new SqlParameter("@codi", tmppenalidad.codi));
//            arParams.Add(new SqlParameter("@descr", tmppenalidad.descr));
//            arParams.Add(new SqlParameter("@cant", tmppenalidad.cant));
//            arParams.Add(new SqlParameter("@cdes", tmppenalidad.cdes));
//            arParams.Add(new SqlParameter("@monto", tmppenalidad.monto));
//            arParams.Add(new SqlParameter("@pena45", tmppenalidad.pena45));
//            arParams.Add(new SqlParameter("@pena90", tmppenalidad.pena90));
//            arParams.Add(new SqlParameter("@fproceso", tmppenalidad.fproceso));
//            arParams.Add(new SqlParameter("@comision", tmppenalidad.comision));
//            arParams.Add(new SqlParameter("@situacion", tmppenalidad.situacion));
//            arParams.Add(new SqlParameter("@vencimiento", tmppenalidad.vencimiento));
//            arParams.Add(new SqlParameter("@uabono", tmppenalidad.uabono));
//            arParams.Add(new SqlParameter("@dias", tmppenalidad.dias));
//            arParams.Add(new SqlParameter("@letra", tmppenalidad.letra));
//            arParams.Add(new SqlParameter("@nlet", tmppenalidad.nlet));
//            arParams.Add(new SqlParameter("@estado", tmppenalidad.estado));
//            arParams.Add(new SqlParameter("@penalidad", tmppenalidad.penalidad));
//            arParams.Add(new SqlParameter("@politica", tmppenalidad.politica));

//            SqlHelper.ExecuteNonQuery(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParams.ToArray());
//            return tmppenalidad;
//        }

//        //BORRAR TEMPORAL VENTAS FLOTAS
//        public static void DeleteTmpVentas(string db)
//        {
//            string strSql = @"DELETE FROM PIMENTEL.TMP_APSSA_VENTAS";

//            SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql);
//        }

//        //OBTIENE VENTAS FLOTAS
//        public static DataSet ObtenerVentasFlotas(DateTime dFecha1, DateTime dFecha2, string cfam1, string cfam2, string db)
//        {
//            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
//            {
//                string sqlCommand = "PIMENTEL.SP_APSSA_COMISION_VENTAS_FLOTAS";
//                string connectionString = ConexionDC.ConectarBD(db);
//                DataSet ds = new DataSet();
//                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
//                {
//                    cmd.CommandType = CommandType.StoredProcedure;
//                    cmd.Parameters.AddWithValue("@FECHAINI", dFecha1);
//                    cmd.Parameters.AddWithValue("@FECHAFIN", dFecha2);
//                    cmd.Parameters.AddWithValue("@FAMILIA1", cfam1);
//                    cmd.Parameters.AddWithValue("@FAMILIA2", cfam2);
//                    cmd.CommandTimeout = 0;
//                    cmd.Connection.Open();
//                    DataTable table = new DataTable();
//                    table.Load(cmd.ExecuteReader());
//                    ds.Tables.Add(table);
//                }
//                return ds;
//            }
//        }

//        //public static DataSet ObtenerVentasFlotasSqlHelper(DateTime dFecha1, DateTime dFecha2, string cfam1, string cfam2, string db)
//        //{
//        //    DataSet ds_vtaflota = new DataSet();
//        //    string strSql = "PIMENTEL.SP_APSSA_COMISION_VENTAS_FLOTAS";
//        //    List<SqlParameter> arParams = new List<SqlParameter>();
//        //    arParams.Add(new SqlParameter("@FECHAINI", dFecha1));
//        //    arParams.Add(new SqlParameter("@FECHAFIN", dFecha2));
//        //    arParams.Add(new SqlParameter("@FAMILIA1", cfam1));
//        //    arParams.Add(new SqlParameter("@FAMILIA2", cfam2));
//        //    ds_vtaflota = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray());
//        //    ds_vtaflota.Tables[0].TableName = "vtaflota";
//        //    return ds_vtaflota;
//        //}

//        //PROCESA COMISION
//        public static DataSet ProcesaComisionSqlHelper(DateTime dFecha1, DateTime dFecha2, string db)
//        {
//            // CON PARAMETRO
//            DataSet ds_proceso = new DataSet();

//            //string strSql = "APSSA.SP_COMISION_FLOTAS_PROCESA";
//            string strSql = "PIMENTEL.SP_APSSA_COMISION_FLOTAS_PROCESA";

//            List<SqlParameter> arParams = new List<SqlParameter>();
//            arParams.Add(new SqlParameter("@FechaProcesoIni", dFecha1));
//            arParams.Add(new SqlParameter("@FechaProcesoFin", dFecha2));

//            ds_proceso = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray());

//            ds_proceso.Tables[0].TableName = "proceso";
//            return ds_proceso;
//        }

//        public static DataSet ProcesaComision(DateTime dFecha1, DateTime dFecha2, string db)
//        {
//            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
//            {
//                string sqlCommand = "PIMENTEL.SP_APSSA_COMISION_FLOTAS_PROCESA_V2";
//                string connectionString = ConexionDC.ConectarBD(db);
//                DataSet ds = new DataSet();
//                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
//                {
//                    cmd.CommandType = CommandType.StoredProcedure;
//                    cmd.Parameters.AddWithValue("@FechaProcesoIni", dFecha1);
//                    cmd.Parameters.AddWithValue("@FechaProcesoFin", dFecha2);
//                    cmd.CommandTimeout = 0;
//                    cmd.Connection.Open();
//                    DataTable table = new DataTable();
//                    table.Load(cmd.ExecuteReader());
//                    ds.Tables.Add(table);
//                }
//                return ds;
//            }
//        }

//        //--------------------------------------------------------------------------------------
//        //-- GENERA COPIAS TEMPORALES
//        //SELECT * INTO A_COMIS_FLETES FROM @FLETE;				--apssa.dbo.TMP_FLETES		fletes
//        //SELECT * INTO A_COMIS_PENALIDADES FROM #finall;		--apssa.dbo.TMP_PENALIDADES penalidades
//        //SELECT * INTO A_COMIS_VENTASOL FROM #periodo;			--apssa.dbo.TMP_VENTAS		ventas soles
//        //SELECT * INTO A_COMIS_VENTADOL FROM #ventasdol;		--apssa.dbo.TMP_VENTASDOL	ventas dolares
//        //SELECT * INTO A_COMIS_COMISIONES FROM #resumen;		--apssa.dbo.TMP_RESUMEN		comisiones SOLO DEL PERIODO, PARA REPORTE
//        //SELECT * INTO A_COMIS_CANJEADAS FROM #canjeadas;		--apssa.dbo.TMP_CANJEADAS	canjeadas
//        //SELECT * INTO A_COMIS_HISTORICO FROM @COMISION;		--si todo OK, debe reemplazar a PIMENTEL.APSSA_COMISION_FLOTAS
//        //----------------------------------------------------------------------------------------

//        public static DataTable dtListarFletesDL(string db)
//        {
//            string strSql = @"SELECT * 
//                              FROM PIMENTEL.TMP_APSSA_COMIS_FLETE;
//                             ";

//            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql).Tables[0];
//        }


//        public static DataTable dtListarPenalidadesDL(string db)
//        {
//            string strSql = @"SELECT *
//                              FROM PIMENTEL.TMP_APSSA_COMIS_PENALIDAD;
//                             ";

//            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql).Tables[0];
//        }

//        public static DataTable dtListarVentaSolesDL(string db)
//        {
//            string strSql = @"SELECT * 
//                              FROM PIMENTEL.TMP_APSSA_COMIS_VENTASOL;
//                             ";

//            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql).Tables[0];
//        }

//        public static DataTable dtListarVentaDolaresDL(string db)
//        {
//            string strSql = @"SELECT *
//                              FROM PIMENTEL.TMP_APSSA_COMIS_VENTADOL;
//                             ";

//            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql).Tables[0];
//        }


//        public static DataTable dtListarCanjeadasDL(string db)
//        {
//            string strSql = @"SELECT * 
//                              FROM PIMENTEL.TMP_APSSA_COMIS_CANJEADA;
//                             ";

//            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql).Tables[0];
//        }

//        public static void GrabarComisiones(string dfecini, string dfecfin, string db)
//        {
//            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
//            {
//                bool success = false;   //una variable boleana para determinar si se realizó la operación
//                SqlTransaction sqlTransac = null;
//                int Valor_Retornado = 0;    //variable para el valor de retorno
//                try
//                {
//                    conn.Open();
//                    sqlTransac = conn.BeginTransaction(System.Data.IsolationLevel.Serializable); //se inicia la transacción
//                    SqlCommand sqlcmd = new SqlCommand("APSSA.SP_COMISION_FLOTAS_GUARDAR", conn, sqlTransac);
//                    sqlcmd.CommandType = CommandType.StoredProcedure;
//                    sqlcmd.Parameters.Clear(); //se limpian los parámetros
//                    //tipo de datos que coincida en sql server por ejemplo c# es string en sql server es varchar()
//                    sqlcmd.Parameters.AddWithValue("@FechaProcesoIni", dfecini);
//                    sqlcmd.Parameters.AddWithValue("@FechaProcesoFin", dfecfin);
//                    SqlParameter ValorRetorno = new SqlParameter("@Comprobacion", SqlDbType.Int);   //declaramos el parámetro de retorno
//                    ValorRetorno.Direction = ParameterDirection.Output; //asignamos el valor de retorno
//                    sqlcmd.Parameters.Add(ValorRetorno);
//                    sqlcmd.ExecuteNonQuery();
//                    Valor_Retornado = Convert.ToInt32(ValorRetorno.Value);  // traemos el valor de retorno

//                    //dependiendo del valor de retorno se asigna la variable success
//                    //si el procedimiento retorna un 1 la operación se realizó con éxito
//                    //de no ser así se mantiene en false y pr lo tanto falló la operación
//                    if (Valor_Retornado == 1)
//                        success = true;
//                }
//                catch (Exception)
//                {
//                    //MessageBox.Show("Error en la operación", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//                }
//                finally
//                {
//                    if (success)
//                    {
//                        sqlTransac.Commit(); //se realiza la transacción
//                        conn.Close();
//                        //MessageBox.Show("Se guardó la información satisfactoriamente", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                    }
//                    else
//                    {
//                        sqlTransac.Rollback();   //se deshace la transacción
//                        conn.Close();
//                    }
//                }
//            }

//        }


//        public static bool ExisteParametroPeriodoDL(Int32 periodo, string db)
//        {

//            string strSql = @"SELECT COUNT(*) 
//                              FROM PIMENTEL.APSSA_COMISION_PARAMETROS 
//                              WHERE IDPERIODO=@IDPERIODO  ;";

//            List<SqlParameter> arParam = new List<SqlParameter>();
//            arParam.Add(new SqlParameter("@IDPERIODO", periodo));

//            int count = Convert.ToInt32(SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray()));

//            if (count == 0)
//                return false;
//            else
//                return true;
//        }


//        public static Int32 GrabarParametrosPeriodoDL(Int32 per_origen, Int32 per_destino, string cdb)
//        {
//            Int32 NumReg = 0;
//            string strSql = "PIMENTEL.SP_APSSA_PARAMETROS_COMISIONES_CLONAR";
//            List<SqlParameter> arParams = new List<SqlParameter>();
//            arParams.Add(new SqlParameter("@PERIODO_ORIGEN", per_origen));
//            arParams.Add(new SqlParameter("@PERIODO_DESTINO", per_destino));

//            NumReg = Convert.ToInt32(SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(cdb), CommandType.StoredProcedure, strSql, arParams.ToArray()));
//            return NumReg;
//        }


//        public static DataSet ObtenerVentasFlotasDL(DateTime dFecha1, DateTime dFecha2, string cfam1, string cfam2, string db)
//        {
//            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
//            {
//                string sqlCommand = "PIMENTEL.SP_APSSA_COMISION_VENTAS_FLOTAS_V3";
//                string connectionString = ConexionDC.ConectarBD(db);
//                DataSet ds = new DataSet();
//                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
//                {
//                    cmd.CommandType = CommandType.StoredProcedure;
//                    cmd.Parameters.AddWithValue("@FECHAINI", dFecha1);
//                    cmd.Parameters.AddWithValue("@FECHAFIN", dFecha2);
//                    cmd.Parameters.AddWithValue("@FAMILIA1", cfam1);
//                    cmd.Parameters.AddWithValue("@FAMILIA2", cfam2);
//                    cmd.CommandTimeout = 0;
//                    cmd.Connection.Open();
//                    DataTable table = new DataTable();
//                    table.Load(cmd.ExecuteReader());
//                    ds.Tables.Add(table);
//                }
//                return ds;
//            }
//        }

//        public static DataSet ProcesaComisionDL(DateTime dFecha1, DateTime dFecha2, string db)
//        {
//            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
//            {
//                string sqlCommand = "PIMENTEL.SP_APSSA_COMISION_FLOTAS_PROCESA_V3";
//                //string connectionString = ConexionDC.ConectarBD(db);
//                string connectionString = ConexionDC.ConectarBDSA(db);     // usuario SA
//                DataSet ds = new DataSet();
//                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
//                {
//                    cmd.CommandType = CommandType.StoredProcedure;
//                    cmd.Parameters.AddWithValue("@FechaProcesoIni", dFecha1);
//                    cmd.Parameters.AddWithValue("@FechaProcesoFin", dFecha2);
//                    cmd.CommandTimeout = 0;
//                    cmd.Connection.Open();
//                    DataTable table = new DataTable();
//                    table.Load(cmd.ExecuteReader());
//                    ds.Tables.Add(table);
//                }
//                return ds;
//            }
//        }


//        public static void EliminaInformacionDeProcesoAnteriorDL(string db)
//        {
//            string strSql = @"
//                                DELETE FROM PIMENTEL.TMP_APSSA_COMISION;
//                                DELETE FROM PIMENTEL.TMP_APSSA_FLETE;
//                                DELETE FROM PIMENTEL.TMP_APSSA_PENALIDAD;
//                                DELETE FROM PIMENTEL.TMP_APSSA_VENTAS;
//                              ";

//            SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql);
//        }


//        #endregion

    }
}




//#region COMISION_FLOTAS  NUEVO  UPDATE 08/08/2016, PARA frmComisionesATF


////ALTER PROCEDURE [PIMENTEL].[SP_APSSA_COMISION_ATF_REPORTE]
////@FECHA_COMISION_INI DATETIME,
////@FECHA_COMISION_FIN DATETIME,
////@REPORTE VARCHAR(50)
//public static DataTable dtObtenerReporteComisionesATF_DL(DateTime dFecha1, DateTime dFecha2, string creporte, string db)
//{
//    string strSql = "PIMENTEL.SP_APSSA_COMISION_ATF_REPORTE";
//    List<SqlParameter> arParam = new List<SqlParameter>();
//    arParam.Add(new SqlParameter("@FECHA_COMISION_INI", dFecha1));
//    arParam.Add(new SqlParameter("@FECHA_COMISION_FIN", dFecha2));
//    arParam.Add(new SqlParameter("@REPORTE", creporte));

//    return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParam.ToArray()).Tables[0];
//}


////ObtieneComisionesATF(archivo_sql_tmp_atf);
////ObtieneComisionesATF_Jefes(archivo_sql_tmp_atf_jefe);
////ObtieneComisionesDetalle(archivo_sql_tmp_atf_detalle);

//public static DataTable dtObtieneComisionesVendedoresATF_DL(string file_sql, string db)
//{
//    using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
//    {
//        string sqlCommand = "PIMENTEL.SP_APSSA_TEMPORAL_RECUPERAR";
//        string connectionString = ConexionDC.ConectarBD(db);
//        DataSet ds = new DataSet();
//        using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
//        {
//            cmd.CommandType = CommandType.StoredProcedure;
//            cmd.Parameters.AddWithValue("@TEMPORAL_SQL", file_sql);
//            cmd.CommandTimeout = 0;
//            cmd.Connection.Open();
//            DataTable table = new DataTable();
//            table.Load(cmd.ExecuteReader());
//            ds.Tables.Add(table);
//        }
//        return ds.Tables[0];
//    }
//}


//public static DataTable ObtenerVendedoresATF_DL(Int32 idperiodo, string db)
//{
//    using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
//    {
//        string sqlCommand = "PIMENTEL.SP_APSSA_COMISION_ATF_VENDEDORES";        //"PIMENTEL.SP_APSSA_COMISION_GET_ATF";
//        string connectionString = ConexionDC.ConectarBDSA(db);     // usuario SA
//        DataSet ds = new DataSet();
//        using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
//        {
//            cmd.CommandType = CommandType.StoredProcedure;
//            cmd.Parameters.AddWithValue("@IDPERIODO", idperiodo);
//            cmd.CommandTimeout = 0;
//            cmd.Connection.Open();
//            DataTable table = new DataTable();
//            table.Load(cmd.ExecuteReader());
//            ds.Tables.Add(table);
//        }
//        return ds.Tables[0];
//    }
//}

//public static DataTable ObtenerVentasFlotasATF_DL(DateTime dFecha1, DateTime dFecha2, DateTime dFechaP, string db)
//{
//    using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
//    {
//        string sqlCommand = "PIMENTEL.SP_APSSA_COMISION_ATF_VENTAS";         //"PIMENTEL.SP_APSSA_COMISION_VENTAS_FLOTAS_V5";
//        string connectionString = ConexionDC.ConectarBD(db);
//        DataSet ds = new DataSet();
//        using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
//        {
//            cmd.CommandType = CommandType.StoredProcedure;
//            cmd.Parameters.AddWithValue("@FECHA_COMISION_INI", dFecha1);
//            cmd.Parameters.AddWithValue("@FECHA_COMISION_FIN", dFecha2);
//            cmd.Parameters.AddWithValue("@FECHA_PROCESO", dFechaP);
//            cmd.CommandTimeout = 0;
//            cmd.Connection.Open();
//            DataTable table = new DataTable();
//            table.Load(cmd.ExecuteReader());
//            ds.Tables.Add(table);
//        }
//        return ds.Tables[0];
//    }
//}

////ALTER PROCEDURE [PIMENTEL].[SP_APSSA_COMISION_ATF_PROCESA]
////(@ACTUALIZA	VARCHAR(2), -- 'SI', 'NO'
//// @IDPERIODO INT,			
//// @FECHA_COMISION_INI DATETIME,
//// @FECHA_COMISION_FIN DATETIME,
//// @FECHA_PROCESO DATETIME,
//// @TMP_SQL_ATF  VARCHAR(250),
//// @TMP_SQL_ATF_JEFE  VARCHAR(250) )

//public static DataSet ProcesaComisionATF_DL(string cActualiza, Int32 idperiodo, DateTime dFecha1, DateTime dFecha2, DateTime dFechaP, string atf, string jefe, string deta, string db)
//{
//    using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
//    {
//        string sqlCommand = "PIMENTEL.SP_APSSA_COMISION_ATF_PROCESA";          //"PIMENTEL.SP_APSSA_COMISION_FLOTAS_PROCESA_V5";
//        //string connectionString = ConexionDC.ConectarBD(db);
//        string connectionString = ConexionDC.ConectarBDSA(db);     // usuario SA
//        DataSet ds = new DataSet();
//        using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
//        {
//            cmd.CommandType = CommandType.StoredProcedure;
//            cmd.Parameters.AddWithValue("@ACTUALIZA", cActualiza);
//            cmd.Parameters.AddWithValue("@IDPERIODO ", idperiodo);
//            cmd.Parameters.AddWithValue("@FECHA_COMISION_INI", dFecha1);
//            cmd.Parameters.AddWithValue("@FECHA_COMISION_FIN", dFecha2);
//            cmd.Parameters.AddWithValue("@FECHA_PROCESO", dFechaP);
//            cmd.Parameters.AddWithValue("@TMP_SQL_ATF", atf);
//            cmd.Parameters.AddWithValue("@TMP_SQL_ATF_JEFE", jefe);
//            cmd.Parameters.AddWithValue("@TMP_SQL_ATF_DETALLE", deta);
//            cmd.CommandTimeout = 0;
//            cmd.Connection.Open();
//            DataTable table = new DataTable();
//            table.Load(cmd.ExecuteReader());
//            ds.Tables.Add(table);
//        }
//        return ds;
//    }
//}

//#endregion

