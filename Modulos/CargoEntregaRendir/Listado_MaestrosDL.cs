using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
//using Exactus.DC;

namespace ApssaExactus
{
    public class Listado_MaestrosDL
    {

        public static DataSet ListarEstadosRebatesDL(string db)
        {
            try
            {
                DataSet ds_bo = new DataSet();
                string strSql = @"PIMENTEL.SP_APSSA_LISTAR_BODEGAS";
                List<SqlParameter> arParam = new List<SqlParameter>();
                //arParam.Add(new SqlParameter("@TIPO", ctipobodega));
                ds_bo = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql);

                ds_bo.Tables[0].TableName = "bo";
                return ds_bo;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        //ALTER PROCEDURE[PIMENTEL].[SP_APSSA_LISTAR_PRODUCTOS]
        //(@FAMILIA VARCHAR(500),
        //@SUBFAMILIA VARCHAR(1500),
        //@GRUPO VARCHAR(1500)  )	
        public static DataSet Listar_Articulo(string ctipoarticulo, string _fam, string _sub, string _gru, string db)
        {
            try
            {
                DataSet ds_bo = new DataSet();
                string strSql = @"PIMENTEL.SP_APSSA_LISTAR_PRODUCTOS";
                List<SqlParameter> arParam = new List<SqlParameter>();
                arParam.Add(new SqlParameter("@TIPO", ctipoarticulo));
                arParam.Add(new SqlParameter("@FAMILIA", _fam));
                arParam.Add(new SqlParameter("@SUBFAMILIA", _sub));
                arParam.Add(new SqlParameter("@GRUPO", _gru));
                ds_bo = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParam.ToArray());

                ds_bo.Tables[0].TableName = "bo";
                return ds_bo;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }


        //---------------------------------------------------------------------------
        public static DataSet Listar_CentroCostosEmpleadosDL(string usuario, string db)
        {
            try
            {

                DataSet ds_su = new DataSet();
                string strSql = "PIMENTEL.SP_APSSA_LISTAR_CC_EMPLEADOS";
                List<SqlParameter> arParams = new List<SqlParameter>();

                arParams.Add(new SqlParameter("@USUARIO", usuario));

                ds_su = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray());
                ds_su.Tables[0].TableName = "sucursal";
                return ds_su;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        //


        public static DataSet Listar_Sucursal2(string usuario, string db)
        {
            try
            {

                DataSet ds_su = new DataSet();
                string strSql = "PIMENTEL.SP_APSSA_LISTAR_SUCURSAL2";
                List<SqlParameter> arParams = new List<SqlParameter>();

                arParams.Add(new SqlParameter("@USUARIO", usuario));

                ds_su = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray());
                ds_su.Tables[0].TableName = "sucursal";
                return ds_su;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public static DataSet Listado_Zonas2(string usuario, string db)
        {
            try
            {

                DataSet ds_zonas = new DataSet();
                string strSql = "PIMENTEL.SP_APSSA_LISTAR_ZONAS2";
                List<SqlParameter> arParams = new List<SqlParameter>();

                arParams.Add(new SqlParameter("@USUARIO", usuario));

                ds_zonas = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray());
                ds_zonas.Tables[0].TableName = "zonas";
                return ds_zonas;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }

        }

        public static DataSet Listado_ZonasInSucursal2(string usuario, string cSucursales, string db)
        {
            try
            {

                DataSet ds_zo = new DataSet();
                string strSql = "PIMENTEL.SP_APSSA_LISTAR_ZONAinSUCURSAL2";
                List<SqlParameter> arParams = new List<SqlParameter>();

                arParams.Add(new SqlParameter("@USUARIO", usuario));
                arParams.Add(new SqlParameter("@SUCURSAL", cSucursales));

                ds_zo = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray());
                ds_zo.Tables[0].TableName = "sucursal";
                return ds_zo;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        
        
        public static DataSet Listar_Transaccion(string db)
        {
            try
            {
                DataSet ds_tr = new DataSet();
                ds_tr = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure,
                "PIMENTEL.SP_APSSA_LISTAR_AJUSTE_CONFIG");
                ds_tr.Tables[0].TableName = "tr";
                return ds_tr;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }        
        
        public static DataSet Listado_Cajas(string usuario,string db)
        {
            try
            {
                DataSet ds_cajas = new DataSet();
                string strSql = @"PIMENTEL.SP_APSSA_LISTAR_CAJA";
                List<SqlParameter> arParam = new List<SqlParameter>();
                arParam.Add(new SqlParameter("@USUARIO",usuario));
                ds_cajas = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParam.ToArray());
                ds_cajas.Tables[0].TableName = "sucursal";
                return ds_cajas;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public static DataSet Listado_Empleados_CC(string sucursal, string empleado, string fechaini, string fechafin, string db)
        {
            try
            {
                DataSet ds_emp = new DataSet();
                string strSql = @"PIMENTEL.LISTAR_EMPLEADOS_FECHA";
                List<SqlParameter> arParam = new List<SqlParameter>();
                arParam.Add(new SqlParameter("@SUCURSAL", sucursal));
                arParam.Add(new SqlParameter("@EMPLEADO", empleado));
                arParam.Add(new SqlParameter("@FECHAINI", Convert.ToDateTime(fechaini)));
                arParam.Add(new SqlParameter("@FECHAFIN", Convert.ToDateTime(fechafin)));              
                ds_emp = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParam.ToArray());
                ds_emp.Tables[0].TableName = "empleadofecha";              
                return ds_emp;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }         


        public static DataSet Listado_Empleados_Centro_Costos(string centroCosto, string db)
        {
            try
            {
                DataSet ds_emp = new DataSet();
                string strSql = @"PIMENTEL.LISTAR_EMPLEADOS_CENTRO_COSTO";
                List<SqlParameter> arParam = new List<SqlParameter>();
                arParam.Add(new SqlParameter("@centroCosto", centroCosto));
                ds_emp = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParam.ToArray());
                ds_emp.Tables[0].TableName = "empleadosCentroCosto";
                return ds_emp;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }                  

        public static DataSet Listado_Empleados(string usuario,string db)
        {
            try
            {
                DataSet ds_emp = new DataSet();
                string strSql = @"PIMENTEL.SP_APSSA_LISTAR_EMPLEADO";
                List<SqlParameter> arParam = new List<SqlParameter>();
                arParam.Add(new SqlParameter("@USUARIO", usuario));
                ds_emp = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParam.ToArray());
                ds_emp.Tables[0].TableName = "sucursal";
                return ds_emp;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }           
       
          public static DataSet Listado_Empleados2(string db)
        {
            try
            {
                DataSet ds_emp = new DataSet();
                ds_emp = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, "PIMENTEL.SP_APSSA_LISTAR_EMPLEADOS_PAGOS");
                ds_emp.Tables[0].TableName = "empleado";
                return ds_emp;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }

        }

          public static DataSet Listado_Empleados_Concepto(string db)
          {
              try
              {
                  DataSet ds_emp = new DataSet();
                  ds_emp = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, "PIMENTEL.SP_APSSA_LISTAR_EMPLEADOS_CONCEPTOS");
                  ds_emp.Tables[0].TableName = "EmpleadoConcepto";
                  return ds_emp;
              }
              catch (Exception ex)
              {
                  throw new ArgumentException(ex.Message);
              }

          }

          public static DataSet Listado_Periodo(string db)
          {
              try
              {
                  DataSet ds_listp = new DataSet();

                  string strSql = @" SELECT DISTINCT NUMERO_NOMINA 
                                   FROM PIMENTEL.EMPLEADO_CONC_NOMI  
                                   ORDER BY NUMERO_NOMINA DESC 
                                   ";

                  ds_listp = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql);

                  ds_listp.Tables[0].TableName = "listp";
                  return ds_listp;
              }
              catch (Exception ex)
              {
                  throw new ArgumentException(ex.Message);
              }
          }

          public static DataSet Listado_Empleado(string empleado, string nombre, string db)
          {
              try
              {
                  DataSet ds_emp = new DataSet();
                  string strSql = @"PIMENTEL.SP_APSSA_EMPLEADO";
                  List<SqlParameter> arParam = new List<SqlParameter>();
                  arParam.Add(new SqlParameter("@EMPLEADO", empleado));
                  arParam.Add(new SqlParameter("@NOMBRE", nombre));
                  ds_emp = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParam.ToArray());
                  ds_emp.Tables[0].TableName = "empleadonombre";
                  return ds_emp;
              }
              catch (Exception ex)
              {
                  throw new ArgumentException(ex.Message);
              }
          }       

          public static DataSet Listado_Empleado_Datos(string db)
          {
              try
              {
                  DataSet ds_empda = new DataSet();
                  ds_empda = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure,
                  "PIMENTEL.SP_APSSA_EMPLEADO_DATOS");
                  ds_empda.Tables[0].TableName = "empda";
                  return ds_empda;
              }
              catch (Exception ex)
              {
                  throw new ArgumentException(ex.Message);
              }
          }  
       
                        
        public static DataSet Listado_Zonas(string db)
        {
            try
            {
                DataSet ds_zonas = new DataSet();
                ds_zonas = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure,
                "PIMENTEL.SP_APSSA_LISTAR_ZONAS");
                ds_zonas.Tables[0].TableName = "zonas";
                return ds_zonas;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }        


        public static DataSet Listado_Subsidios(string db)
        {
            try
            {
                DataSet ds_ls = new DataSet();
                ds_ls = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure,
                "pimentel.SP_APSSA_Listar_Subsidio");
                ds_ls.Tables[0].TableName = "lstSubsidios";
                return ds_ls;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }

        }
        
        public static DataSet Listado_Categoria_clientes(string db)
        {
            try
            {
                DataSet ds_lcc = new DataSet();
                ds_lcc = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, "Pimentel.SP_APSSA_LISTAR_CAT_CLIENTE");
                ds_lcc.Tables[0].TableName = "lcc";
                return ds_lcc;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public static DataSet Listar_Sucursal(string db)
        {
            try
            {
                DataSet ds_su = new DataSet();
                ds_su = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure,
                "PIMENTEL.SP_APSSA_LISTAR_SUCURSAL");
                ds_su.Tables[0].TableName = "sucursal";
                return ds_su;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public static DataSet Listado_ZonasInSucursal(string cSucursales,string db)
        {
            try
            {
                DataSet ds_zo = new DataSet();

                string strSql = @"PIMENTEL.SP_APSSA_LISTAR_ZONAinSUCURSAL";
                
                List<SqlParameter> arParam = new List<SqlParameter>();
                arParam.Add(new SqlParameter("@Sucursal", cSucursales));
                ds_zo = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParam.ToArray());
         
                ds_zo.Tables[0].TableName = "sucursal";
                return ds_zo;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public static DataSet Listar_CondicionPago(string db)
        {
            try
            {
                DataSet ds_cp = new DataSet();
                string strSql = @"  SELECT CONDICION_PAGO,DESCRIPCION   
                                    FROM PIMENTEL.CONDICION_PAGO";

                ds_cp = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql);

                ds_cp.Tables[0].TableName = "cp";
                return ds_cp;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

    
        public static DataSet Listar_Bodega(string ctipobodega,string db)
        {
            try
            {
                DataSet ds_bo = new DataSet();
                string strSql = @"PIMENTEL.SP_APSSA_LISTAR_BODEGAS";
                List<SqlParameter> arParam = new List<SqlParameter>();
                arParam.Add(new SqlParameter("@TIPO", ctipobodega));
                ds_bo = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParam.ToArray());

                ds_bo.Tables[0].TableName = "bo";
                return ds_bo;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }



        public static DataSet Listar_accesos2(string tipo,string usuario, string db)
        {
            try
            {
                DataSet ds_bo = new DataSet();
                string strSql = @"PIMENTEL.SP_APSSA_LISTAR_ACCESOS";
                List<SqlParameter> arParam = new List<SqlParameter>();
                arParam.Add(new SqlParameter("@USUARIO", usuario));
                arParam.Add(new SqlParameter("@TIPO", tipo));
                ds_bo = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParam.ToArray());

                ds_bo.Tables[0].TableName = "bo";
                return ds_bo;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }




        public static DataSet Listar_accesos3(string usuario, string db)
        {
            try
            {
                DataSet ds_bo = new DataSet();
                string strSql = @"PIMENTEL.SP_APSSA_LISTAR_ACCESOS_MONITOR";
                List<SqlParameter> arParam = new List<SqlParameter>();
                arParam.Add(new SqlParameter("@USUARIO", usuario));
                ds_bo = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParam.ToArray());

                ds_bo.Tables[0].TableName = "bo";
                return ds_bo;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }





        public static DataSet Listar_Familia(string db)
        {
            try
            {
                DataSet ds_fa = new DataSet();
                ds_fa = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure,
                "PIMENTEL.SP_APSSA_LISTAR_FAMILIAS");
                ds_fa.Tables[0].TableName = "fa";
                return ds_fa;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        
        public static DataSet Listar_SubFamilia(string cFamilia,string db)
        {
            try
            {
                DataSet ds_sf = new DataSet();
                string strSql = @"PIMENTEL.SP_APSSA_LISTAR_SUBFAMILIA";
                List<SqlParameter> arParam = new List<SqlParameter>();
                arParam.Add(new SqlParameter("@Familia", cFamilia));
                ds_sf = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParam.ToArray());
                ds_sf.Tables[0].TableName = "sf";
                return ds_sf;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }        
    
        public static DataSet Listar_Grupo(string csubfamilia, string db)
        {
            try
            {
                DataSet ds_gr = new DataSet();
                string strSql = @"PIMENTEL.SP_APSSA_LISTAR_GRUPO";
                List<SqlParameter> arParam = new List<SqlParameter>();
                arParam.Add(new SqlParameter("@SubFamilia", csubfamilia));
                ds_gr = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParam.ToArray());

                ds_gr.Tables[0].TableName = "gr";
                return ds_gr;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public static DataSet Listar_Modulos_Apssa(string db)
        {
            try
            {
                DataSet ds_lm = new DataSet();
                string strSql = @" select * from pimentel.APSSA_MODULOS_APSSA_REP order by Modulo,Reporte ";

                ds_lm = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql);

                ds_lm.Tables[0].TableName = "lm";
                return ds_lm;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }


        public static DataSet Listar_EMPLEADOS(string db)
        {
            try
            {
                DataSet ds_empl = new DataSet();
                string strSql = @"  SELECT EMPLEADO,NOMBRE,SEXO,ACTIVO FROM PIMENTEL.EMPLEADO";

                ds_empl = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql);

                ds_empl.Tables[0].TableName = "EMP";
                return ds_empl;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public static DataSet Listar_DEPARTAMENTO_EMPL(string db)
        {
            try
            {
                DataSet ds_dep = new DataSet();
                string strSql = @"  SELECT DEPARTAMENTO,DESCRIPCION,JEFE FROM PIMENTEL.DEPARTAMENTO";

                ds_dep = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql);

                ds_dep.Tables[0].TableName = "dep";
                return ds_dep;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

    }
}   
