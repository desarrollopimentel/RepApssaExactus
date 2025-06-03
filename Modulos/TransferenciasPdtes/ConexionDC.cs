using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
//using cConexion;

namespace ApssaExactus
{


    public class ConexionDC
    {
        public static string ConectarBD(string base_datos)
        {
            string CadenaConexion = null;

            if (base_datos == "PIMENTEL")
            {
                CadenaConexion = "Data Source=10.10.2.11;Initial Catalog=PIMENTEL;Persist Security Info=True;user ID=sa;Password=$3rv3r2021";
            }
            else if (base_datos == "TESTING") //PRUEBA
            {
                CadenaConexion = "Data Source=192.168.2.6;Initial Catalog=TESTING;Persist Security Info=True;user ID=sa;Password=T3$t1ng2020";
            }
            else if (base_datos == "DESARROLLO") //DESARROLLO
            {
                CadenaConexion = "Data Source=192.168.2.6;Initial Catalog=DESARROLLO;Persist Security Info=True;user ID=sa;Password=T3$t1ng2020";
            }
            else if (base_datos == "REPORTES") //REPORTES
            {
                CadenaConexion = "Data Source=10.10.2.17;Initial Catalog=RPT_PIMENTEL;Persist Security Info=True;user ID=sa;Password=nsGsMrZJOQ9mIOH";
            }
            else if (base_datos == "DIRECTORIO")    // DATOS DE LOS USUARIOS
            {
                CadenaConexion = "Data Source=192.168.2.17;Initial Catalog=DIRECTORIO;Persist Security Info=True;user ID=sa;Password=sql12345";
            }

            return CadenaConexion;
        }


        public static string ConectarBDSA(string base_datos)
        {
            string CadenaConexion = null;

            if (base_datos == "PIMENTEL")
            {
                CadenaConexion = "Data Source=10.10.2.11;Initial Catalog=PIMENTEL;Persist Security Info=True;user ID=sa;Password=$3rv3r2021";
            }
            else if (base_datos == "TESTING")
            {
                CadenaConexion = "Data Source=10.10.2.31;Initial Catalog=TESTING;Persist Security Info=True;user ID=sa;Password=T3$t1ng2020";
            }
            else if (base_datos == "DESARROLLO")
            {
                CadenaConexion = "Data Source=10.10.2.31;Initial Catalog=DESARROLLO;Persist Security Info=True;user ID=sa;Password=T3$t1ng2020";
            }

            return CadenaConexion;
        }
        public static string ConectarBDDW(string base_datos)
        {
            string CadenaConexion = null;

            if (base_datos == "DW_APSSA")
            {
                CadenaConexion = "Data Source=10.10.2.31;Initial Catalog=DW_APSSA;Persist Security Info=True;user ID=sa;Password=nsGsMrZJOQ9mIOH";
            }
            return CadenaConexion;
        }



    }
}


    
