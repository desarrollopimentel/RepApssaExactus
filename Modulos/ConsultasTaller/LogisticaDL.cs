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

        //ALTER PROCEDURE[PIMENTEL].[SP_APSSA_TRANSFERENCIAS_PDTES]
        //(@FECHA_INI DATETIME,
        // @FECHA_FIN DATETIME,
        // @BODEGA NVARCHAR(MAX) )
        public static DataTable dtObtenerTransanferenciasPendientes_DL(DateTime _fecha_ini, DateTime _fecha_fin, string _paquete, string _usuario, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string sqlCommand = "PIMENTEL.SP_APSSA_TRANSFERENCIAS_PDTES";
                string connectionString = ConexionDC.ConectarBD(db);
                DataSet ds = new DataSet();
                using (SqlCommand cmd = new SqlCommand(sqlCommand, new SqlConnection(connectionString)))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FECHA_INI", _fecha_ini);
                    cmd.Parameters.AddWithValue("@FECHA_FIN", _fecha_fin);
                    cmd.Parameters.AddWithValue("@PAQUETE", _paquete);
                    cmd.Parameters.AddWithValue("@USUARIO", _usuario);
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
