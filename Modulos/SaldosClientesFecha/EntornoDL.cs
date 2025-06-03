using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
//using Exactus.DC;
//using Exactus.DL;

namespace ApssaExactus
{
    class EntornoDL
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




    }
}
