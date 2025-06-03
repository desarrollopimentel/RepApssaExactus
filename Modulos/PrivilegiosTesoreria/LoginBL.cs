using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
//using Exactus.BE;
//using Exactus.DL;

namespace ApssaExactus
{
    public class LoginBL
    {

        public class UsuarioBL
        {
            //LoginDL.UsuarioDL objUsuarioBL = new LoginDL.UsuarioDL();

            public static DataTable dtListarUsuarioBL(string usu, string db)
            {
                //return objUsuarioBL.dtListarUsuarioDL(usu, db);
                return LoginDL.UsuarioDL.dtListarUsuarioDL(usu, db);
            }

            public static int dtAccesos_Tag(string usu,string tag, string db)
            {
               int visible=0;
               DataTable dt = new DataTable();
               //dt = objUsuarioBL.dtAcceso_Tag(usu, tag, db);
               dt = LoginDL.UsuarioDL.dtAcceso_Tag(usu, tag, db);
               for (int i = 0; i < dt.Rows.Count; i++)
               {
                   // OPCION 0  BLOQUEA
                   if (Convert.ToInt32(dt.Rows[i]["VISIBLE"]) == 0)
                   {
                       visible = 0;
                   }
                   // OPCION 1  MUESTRA
                   if (Convert.ToInt32(dt.Rows[i]["VISIBLE"]) == 1)
                   {
                       visible = 1;    
                   }

                   // opcion 9  OCULTA
                   if (Convert.ToInt32(dt.Rows[i]["VISIBLE"]) == 9)
                   {
                       visible=9;
                   }
               }
               return visible;
           
            }

            public static DataTable dtListarUsuarioMenuDL_SP(string usu, string db)
            {
                //return objUsuarioBL.dtListarUsuarioMenuDL_SP(usu, db);
                return LoginDL.UsuarioDL.dtListarUsuarioMenuDL_SP(usu, db);
            }

            public static DataTable dtListarUsuarioMenuDL(string usu, string db)
            {
                //return objUsuarioBL.dtListarUsuarioMenuDL(usu, db);
                return LoginDL.UsuarioDL.dtListarUsuarioMenuDL(usu, db);
            }

            public static void GrabaAccesoUsuarioMenu(string usuario,
                                                        string id_mod, string mod, string id_sub, string sub,
                                                        string id_gru, string gru, string id_ite, string ite,
                                                        string id_opc, string opc, Int32 visible, string db)
            {
                LoginDL.UsuarioDL.GrabaAccesoUsuarioMenuDL(usuario, id_mod, mod, id_sub, sub,
                                                                    id_gru, gru, id_ite, ite,
                                                                    id_opc, opc, visible, db);
            }



        }         

        public static bool DBCambiarClaveUsuario(string usuario, string clave_anterior,string clave_nueva,string db)
        {
            if (LoginDL.DBCambiarClaveUsuario(usuario, clave_anterior,clave_nueva,db))
                return true; 
            else
                return false;
        }

        public static DataSet DBCargaDatosUsuario(string usuario, string db)
        {
            try
            {
                DataSet ds_usuario = new DataSet();
                ds_usuario = LoginDL.DBCargaDatosUsuario(usuario,db);
                ds_usuario.Tables[0].TableName = "listausuarios";
                return ds_usuario;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        

        public static bool DBAutenticarUsuario(string usuario, string password, string db)
        {
            if (LoginDL.DBAutenticarUsuario(usuario, password, db))
                return true;    
            else
                return false;
        }

        public static bool DBAutenticarUsuarioSinClave(string usuario, string db)
        {
            if (LoginDL.DBAutenticarUsuarioSinClave(usuario, db))
                return true;
            else
                return false;
        }


    }
}
