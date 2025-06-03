using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;


namespace ApssaExactus
{


    public class Global
    {
        // PARAMETROS GLOBALES
        //public static DataSet ds_global;        
        public static string vModulo = null;
        public static string vUsuario = null;
        public static string vPcUsuario = null;
        public static string vIpUsuario = null;

        //USUARIO / para el Login
        public static string vUserBaseDatos = null;   // BASEdeDATOS
        public static string vUserUsuario = null;     // USUARIO , usuario
        public static string vUserGrupo = null;       //GRUPO, grupo
        public static string vUserTienda = null;      //ZONA, zona 
        public static string vUserBodega = null;      //BODEGA, bodega
        public static string vUserClave = null;       //PASSWORD,  clave_reporte
        public static string vUserNombre = null;      //NOMBRE, nombre
        //public static string vUserZona = null;        // tienda
        public static string vUserTiendaDescrip = null;      //ZONA, zona  descripcion
        public static string vUserBodegaDescrip = null;      //BODEGA, bodega descripcion        
        public static string vUserCaja = null;          //CAJA,CODIGO
        public static string vUserCajaDescrip = null;   //CAJA,DESCRIPCION
        public static string vUserGrupo_a = null;       //GRUPOS DE ACCESO A MARGEN

        //Modulos opciones
        public static string vOpcionFormulario1 = null;          // parametro 1 , para opcion de carga de formulario
        public static string vOpcionFormulario2 = null;          // parametro 2 , para opcion de carga de formulario
        public static string vOpcionFormulario3 = null;          // parametro 3 , para opcion de carga de formulario


        //// PARAMETROS GLOBALES
        ////public static DataSet ds_global;        
        //public static string vModulo = null;
        //public static string vUsuario = null;
        //public static string vPcUsuario = null;
        //public static string vIpUsuario = null;

        ////USUARIO / para el Login
        //public static string vUserBaseDatos = null; // BASEdeDATOS
        //public static string vUserUsuario = null;   // USUARIO , u_codigo
        //public static string vUserDescrip = null;   //DESCRIP, u_descrip
        //public static string vUserTienda = null;    //ZONA, u_zona 
        //public static string vUserBodega = null;    //BODEGA, u_bodega
        //public static string vUserClave = null;     //PASSWORD,  u_clave  
        //public static string vUserNombre = null;    //NOMBRE, u_nombre
        //public static string vUserTiendaDescrip = null;      //ZONA, zona  descripcion
        //public static string vUserBodegaDescrip = null;      //BODEGA, bodega descripcion


        ////usuarioreporte.u_codigo = lectoruser[0].ToString();     // USUARIO
        ////usuarioreporte.u_descrip = lectoruser[1].ToString();    //
        ////usuarioreporte.u_zona = lectoruser[2].ToString();       //ZONA
        ////usuarioreporte.u_bodega = lectoruser[3].ToString();     //BODEGA
        ////usuarioreporte.u_clave = lectoruser[4].ToString();      //PASSWORD
        ////usuarioreporte.u_nombre = lectoruser[5].ToString();     //NOMBRE


    }
}
