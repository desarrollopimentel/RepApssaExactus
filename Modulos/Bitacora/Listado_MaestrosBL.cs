using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
//using Exactus.DL;

namespace ApssaExactus
{
    public class Listado_MaestrosBL
    {


        //public static DataSet Listar_VendedoresComisiones(Int16 _rep_anno, string _rep_tipo, string _usuario, string db)
        //{
        //    try
        //    {
        //        DataSet ds_su = new DataSet();
        //        ds_su = Listado_MaestrosDL.Listar_VendedoresComisiones(_rep_anno, _rep_tipo, _usuario, db);
        //        ds_su.Tables[0].TableName = "lstvend";
        //        return ds_su;

        //    }
        //    catch (Exception ex)
        //    {
        //        throw new ArgumentException(ex.Message);
        //    }
        //}

        public static DataSet ListarEstadosRebatesBL(string db)
        {
            try
            {
                DataSet ds_bo = new DataSet();
                ds_bo = Listado_MaestrosDL.ListarEstadosRebatesDL(db);
                ds_bo.Tables[0].TableName = "lstbo";
                return ds_bo;
            }
            catch (Exception ex)
            {

                throw new ArgumentException(ex.Message);

            }
        }

        public static DataSet Listar_Articulo(string ctipoarticulo, string _fam, string _sub, string _gru, string db)
        {
            try
            {
                DataSet ds_bo = new DataSet();
                ds_bo = Listado_MaestrosDL.Listar_Articulo(ctipoarticulo, _fam, _sub, _fam, db);
                ds_bo.Tables[0].TableName = "lstbo";
                return ds_bo;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }



        //---------------------------------------------------------------------------------

        public static DataSet Listar_CentroCostosEmpleadosBL(string usuario, string db)
        {
            try
            {
                DataSet ds_su = new DataSet();
                ds_su = Listado_MaestrosDL.Listar_CentroCostosEmpleadosDL(usuario, db);
                ds_su.Tables[0].TableName = "lstsu";
                return ds_su;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }


        //---------------------------------------------------------------------------------


        public static DataSet Listar_Sucursal2(string usuario, string db)
        {
            try
            {
                DataSet ds_su = new DataSet();
                ds_su = Listado_MaestrosDL.Listar_Sucursal2(usuario, db);
                ds_su.Tables[0].TableName = "lstsu";
                return ds_su;

            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public static DataSet Listar_Zonas2(string usuario, string db)
        {
            try
            {
                DataSet ds_zo = new DataSet();
                ds_zo = Listado_MaestrosDL.Listado_Zonas2(usuario, db);
                ds_zo.Tables[0].TableName = "lstzo";
                return ds_zo;

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
                ds_zo = Listado_MaestrosDL.Listado_ZonasInSucursal2(usuario, cSucursales, db);
                ds_zo.Tables[0].TableName = "lstzo";
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
                ds_tr = Listado_MaestrosDL.Listar_Transaccion(db);
                ds_tr.Tables[0].TableName = "lsttr";
                return ds_tr;

            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }        
        
        public static DataSet Listar_Cajas(string usuariobl,string db)
        {
            try
            {
                DataSet ds_ca = new DataSet();
                ds_ca = Listado_MaestrosDL.Listado_Cajas(usuariobl,db);
                ds_ca.Tables[0].TableName = "lstca";
                return ds_ca;

            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public static DataSet Listar_Empleados_CC(string sucursal,string empleado,string fechaini,string fechafin, string db)
        {
            try
            {
                DataSet ds_em = new DataSet();
                ds_em = Listado_MaestrosDL.Listado_Empleados_CC(sucursal,empleado,fechaini,fechafin, db);
                ds_em.Tables[0].TableName = "lstemcosfec";
                return ds_em;

            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }


     
        public static DataSet Listar_Empleados_Centro_Costos(string centroCosto, string db)
        {
            try
            {

                DataSet ds_em = new DataSet();
                ds_em = Listado_MaestrosDL.Listado_Empleados_Centro_Costos(centroCosto, db);
                ds_em.Tables[0].TableName = "lstemcos";
                return ds_em;

            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

               
        public static DataSet Listar_Empleados(string usuariobl, string db)
        {
            try
            {

                DataSet ds_em = new DataSet();
                ds_em = Listado_MaestrosDL.Listado_Empleados(usuariobl,db);
                ds_em.Tables[0].TableName = "lstem";
                return ds_em;

            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public static DataSet Listar_Empleados2(string db)
        {
            try
            {

                DataSet ds_em = new DataSet();
                ds_em = Listado_MaestrosDL.Listado_Empleados2(db);
                ds_em.Tables[0].TableName = "lstem";
                return ds_em;

            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public static DataSet Listar_Empleados_Concepto(string db)
        {
            try
            {

                DataSet ds_em = new DataSet();
                ds_em = Listado_MaestrosDL.Listado_Empleados_Concepto(db);
                ds_em.Tables[0].TableName = "lstemco";
                return ds_em;

            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public static DataSet Listar_Periodo(string db)
        {
            try
            {

                DataSet ds_listp = new DataSet();
                ds_listp = Listado_MaestrosDL.Listado_Periodo(db);
                ds_listp.Tables[0].TableName = "listp";
                return ds_listp;

            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }

        }

        public static DataSet Listar_Empleado(string empleado, string nombre, string db)
        {
            try
            {

                DataSet ds_empda = new DataSet();
                ds_empda = Listado_MaestrosDL.Listado_Empleado(empleado, nombre, db);
                ds_empda.Tables[0].TableName = "lstempda";
                return ds_empda;

            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public static DataSet Listar_Empleado_Datos(string db)
        {
            try
            {

                DataSet ds_empda = new DataSet();
                ds_empda = Listado_MaestrosDL.Listado_Empleado_Datos(db);
                ds_empda.Tables[0].TableName = "lstempda";
                return ds_empda;

            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }  
                   
        public static DataSet Listar_Zonas(string db)
        {
            try
            {

                DataSet ds_zo = new DataSet();
                ds_zo = Listado_MaestrosDL.Listado_Zonas(db);
                ds_zo.Tables[0].TableName = "lstzo";
                return ds_zo;

            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

      
       
        public static DataSet Listar_Categoria_Clientes(string db)
        {
            try
            {

                DataSet ds_lcc = new DataSet();
                ds_lcc = Listado_MaestrosDL.Listado_Categoria_clientes(db);
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
                ds_su = Listado_MaestrosDL.Listar_Sucursal(db);
                ds_su.Tables[0].TableName = "lstsu";
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
                ds_zo = Listado_MaestrosDL.Listado_ZonasInSucursal(cSucursales,db);
                ds_zo.Tables[0].TableName = "lstzo";
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
                ds_cp = Listado_MaestrosDL.Listar_CondicionPago(db);
                ds_cp.Tables[0].TableName = "lstcp";
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
                ds_bo = Listado_MaestrosDL.Listar_Bodega(ctipobodega,db);
                ds_bo.Tables[0].TableName = "lstbo";
                return ds_bo;
            }
            catch (Exception ex)
            {

                throw new ArgumentException(ex.Message);

            }
        }


        //public static DataSet Listar_Bodega(string ctipobodega, string db)
        public static DataSet listar_acceso2(string tipo,string usuario, string db)
        {
            try
            {
                DataSet ds_bo = new DataSet();
                
                ds_bo = Listado_MaestrosDL.Listar_accesos2(tipo,usuario, db);
                ds_bo.Tables[0].TableName = "lstbo";
                return ds_bo;
            }
            catch (Exception ex)
            {

                throw new ArgumentException(ex.Message);

            }
        }


        public static DataSet listar_acceso3(string usuario, string db)
        {
            try
            {
                DataSet ds_bo = new DataSet();

                ds_bo = Listado_MaestrosDL.Listar_accesos3(usuario, db);
                ds_bo.Tables[0].TableName = "lstbo";
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
                ds_fa = Listado_MaestrosDL.Listar_Familia(db);
                ds_fa.Tables[0].TableName = "lstfa";
                return ds_fa;

            }
            catch (Exception ex)
            {

                throw new ArgumentException(ex.Message);

            }
        }
        
        public static DataSet Listar_SubFamilia(string cFamilia, string db)
        {
            try
            {
                DataSet ds_sf = new DataSet();
                ds_sf = Listado_MaestrosDL.Listar_SubFamilia(cFamilia, db);
                ds_sf.Tables[0].TableName = "lstsf";
                return ds_sf;

            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public static DataSet Listar_Grupo(string csubfamilia,string db)
        {
            try
            {
                DataSet ds_gr = new DataSet();
                ds_gr = Listado_MaestrosDL.Listar_Grupo(csubfamilia,db);
                ds_gr.Tables[0].TableName = "lstgr";
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
                DataSet ds_lma = new DataSet();
                ds_lma = Listado_MaestrosDL.Listar_Modulos_Apssa(db);
                ds_lma.Tables[0].TableName = "tbl_lma";
                return ds_lma;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        //Listar_Modulos_Apssa

        public static DataSet Listar_Empleados(string db)
        {
            try
            {
                DataSet ds_empl = new DataSet();
                ds_empl = Listado_MaestrosDL.Listar_EMPLEADOS(db);
                ds_empl.Tables[0].TableName = "emp";
                return ds_empl;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public static DataSet Listar_Departamento_Empleado(string db)
        {
            try
            {
                DataSet ds_depemp = new DataSet();
                ds_depemp = Listado_MaestrosDL.Listar_DEPARTAMENTO_EMPL(db);
                ds_depemp.Tables[0].TableName = "depem";
                return ds_depemp;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }


    }
}
