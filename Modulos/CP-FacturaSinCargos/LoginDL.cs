using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
//using Exactus.DC;
//using Exactus.BE;

namespace ApssaExactus
{

    public class LoginDL
    {

        public class UsuarioDL
        {

            public static void GrabaAccesoUsuarioMenuDL(string usuario,
                                                        string id_mod, string mod, string id_sub, string sub,
                                                        string id_gru, string gru, string id_ite, string ite,
                                                        string id_opc, string opc, Int32 visible, string db)
            {
                string strSql = "PIMENTEL.SP_APSSA_USUARIO_MENU_UPDATED";
                List<SqlParameter> arParams = new List<SqlParameter>();

                arParams.Add(new SqlParameter("@USUARIO", usuario));
                arParams.Add(new SqlParameter("@ID_MODULO", id_mod));
                arParams.Add(new SqlParameter("@MODULO", mod));
                arParams.Add(new SqlParameter("@ID_SUBMODULO", id_sub));
                arParams.Add(new SqlParameter("@SUBMODULO", sub));
                arParams.Add(new SqlParameter("@ID_GRUPO", id_gru));
                arParams.Add(new SqlParameter("@GRUPO", gru));
                arParams.Add(new SqlParameter("@ID_ITEM", id_ite));
                arParams.Add(new SqlParameter("@ITEM", ite));
                arParams.Add(new SqlParameter("@ID_OPCION", id_opc));
                arParams.Add(new SqlParameter("@OPCION", opc));
                arParams.Add(new SqlParameter("@VISIBLE", visible));

                SqlHelper.ExecuteNonQuery(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray());

            }

            public static DataTable dtListarUsuarioMenuDL_SP(string usu, string db)
            {
                string strSql = "PIMENTEL.SP_APSSA_USUARIO_MENU_ACCESOS";
                List<SqlParameter> arParams = new List<SqlParameter>();

                arParams.Add(new SqlParameter("@USUARIO", usu));

                return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray()).Tables[0];
            }

            public static DataTable dtListarUsuarioMenuDL(string usu, string db)
            {
                string strSql = @"SELECT 
                                  MODULO,SUBMODULO,GRUPO,ITEM,OPCION,VISIBLE,ID_ITEM                                     
                                  FROM PIMENTEL.APSSA_MENU_ACCESOS_USUARIO
                                  WHERE USUARIO=@usu;
                                ";

                List<SqlParameter> arParam = new List<SqlParameter>();
                arParam.Add(new SqlParameter("@usu", usu));

                return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray()).Tables[0];
            }

            public static DataTable dtListarUsuarioDL(string usu, string db)
            {
                string strSql = @"SELECT 
                                  USUARIO,
                                  ID_MODULO,MODULO,
                                  ID_SUBMODULO,SUBMODULO,
                                  ID_GRUPO,GRUPO,
                                  ID_ITEM,ITEM,                                
                                  ID_OPCION,OPCION,VISIBLE 
                                  FROM PIMENTEL.APSSA_MENU_ACCESOS_USUARIO
                                  WHERE USUARIO=@usu;
                                ";

                List<SqlParameter> arParam = new List<SqlParameter>();
                arParam.Add(new SqlParameter("@usu", usu));

                return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray()).Tables[0];
            }

            public static DataTable dtAcceso_Tag(string usu, string tag, string db)
            {
                string strSql = "PIMENTEL.SP_APSSA_ACCESO_TAG";
                List<SqlParameter> arParams = new List<SqlParameter>();

                arParams.Add(new SqlParameter("@usuario", usu));
                arParams.Add(new SqlParameter("@id_opcion", tag));

                return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray()).Tables[0];
            }

        }        

        public static bool DBCambiarClaveUsuario(string usuario, string clave_anterior,string clave_nueva,string db)
        {
            string strSql = @" UPDATE ERPADMIN.USUARIO
                               SET
                               CLAVE_REPORTE = @clave_nueva
                               WHERE USUARIO = @usuario AND CLAVE_REPORTE = @clave_anterior ;";
         
            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@usuario", usuario));
            arParam.Add(new SqlParameter("@clave_anterior", clave_anterior));
            arParam.Add(new SqlParameter("@clave_nueva", clave_nueva));

            int count = Convert.ToInt32(SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray()));

            //if (count == 0)
            if (count != 0)
                return false;
            else
                return true;
        }

        public static bool DBAutenticarUsuario(string usuario, string password, string db)
        {
            string strSql = @"SELECT COUNT(*) 
                              FROM ERPADMIN.USUARIO
                              WHERE USUARIO = @usuario AND CLAVE_REPORTE = @password ;";

            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@usuario", usuario));
            arParam.Add(new SqlParameter("@password ", password));

            int count = Convert.ToInt32(SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray()));

            if (count == 0)
                return false;
            else
                return true;
        }

        public static bool DBAutenticarUsuarioSinClave(string usuario, string db)
        {
            string strSql = @"SELECT COUNT(*) 
                              FROM ERPADMIN.USUARIO
                              WHERE USUARIO = @usuario ;";

            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@usuario", usuario));

            int count = Convert.ToInt32(SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray()));

            if (count == 0)
                return false;
            else
                return true;
        }

        public static DataSet DBCargaDatosUsuario(string usuario, string db)
        {
            DataSet ds_usuario = new DataSet();

            string strSql = @"SELECT 
                                U.USUARIO, U.NOMBRE, U.ZONA, U.BODEGA, U.CLAVE_REPORTE, M.GRUPO,
                                Z.NOMBRE AS ZONA_DESCRIP,B.NOMBRE AS BODEGA_DESCRIP,U.GRUPO AS GRUPO_A,
                                ISNULL(U.CAJA,'ND') AS CAJA,ISNULL(C.DESCRIPCION,'ND') AS CAJA_DESCRIP
                                FROM ERPADMIN.USUARIO U
                                INNER JOIN ERPADMIN.MEMBRESIA M ON M.USUARIO=U.USUARIO
                                INNER JOIN PIMENTEL.ZONA Z ON Z.ZONA=U.ZONA
                                INNER JOIN PIMENTEL.BODEGA B ON B.BODEGA=U.BODEGA
								LEFT JOIN PIMENTEL.CAJA C ON U.CAJA=C.CAJA
                                WHERE U.USUARIO = @usuario;
                             ";

            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@usuario", usuario));
            ds_usuario = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray());

            ds_usuario.Tables[0].TableName = "ds_usuario";
            return ds_usuario;
        }      
        

 
    }

}
