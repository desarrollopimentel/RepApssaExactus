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

    // 05/09/2018
    public class EntidadesDL
    {


        public static DataTable CargaDatosClienteDL(string clie, string db)
        {
            string strSql = @"SELECT CLIENTE, NOMBRE
                              FROM PIMENTEL.CLIENTE (NOLOCK)
                              WHERE CLIENTE = @CLIENTE";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@CLIENTE", clie));

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParams.ToArray()).Tables[0];
        }


        public static DataTable CargaDatosVendedorDL(string vend, string db)
        {
            string strSql = @"SELECT VENDEDOR, NOMBRE
                              FROM PIMENTEL.VENDEDOR (NOLOCK)
                              WHERE VENDEDOR = @VENDEDOR";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@VENDEDOR", vend));

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParams.ToArray()).Tables[0];
        }

    }

    public class AccesoUsuarioDL
    {
        public static bool UsuarioOpcionAccesoDL(string _user, string _parametro, string db)
        {
            int NumReg = 0;
            string strSql = @" SELECT COUNT(*) 
						       FROM PIMENTEL.APSSA_USUARIO_PREFERENCIA WITH (NOLOCK)
						       WHERE USUARIO=@USUARIO AND PARAMETRO=@PARAMETRO ";

            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@USUARIO", _user));
            arParam.Add(new SqlParameter("@PARAMETRO", _parametro));

            NumReg = Convert.ToInt32(SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray()));
            return NumReg > 0;
        }

    }


    public class TablasExactusDL
    {

        public static DataTable dtObtenerEstadosFeDL(string db)
        {
            string strSql = @"SELECT ESTADO, DESCRIPCION
                              FROM PIMENTEL.FE_ESTADO (NOLOCK)
                              ORDER BY 1; ";

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql).Tables[0];
        }
        public static DataTable dtObtenerTipoDocumentoDL(string db)
        {
            string strSql = @"SELECT DISTINCT TIPO_DOCUMENTO AS TIPO,
                              DESCRIPCION= (CASE TIPO_DOCUMENTO
					                            WHEN 'B' THEN 'BOLETA'
					                            WHEN 'F' THEN 'FACTURA'  
					                            WHEN 'D' THEN 'NOTA CREDITO' 
			                                END)
                              FROM PIMENTEL.FACTURA (NOLOCK) WHERE TIPO_DOCUMENTO NOT IN ('R')
                              ORDER BY 1; ";

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql).Tables[0];
        }

        // 05/09/2018
        public static DataTable dtAnalistasCreditoDL(string db)
        {
            string strSql = @"SELECT ANALISTA, NOMBRE
                              FROM PIMENTEL.APSSA_ANALISTAS_CC (NOLOCK)
                              ORDER BY 1; ";

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql).Tables[0];
        }

        // 05/09/2018
        public static DataTable dtCobradoresCreditosDL(string db)
        {
            string strSql = @"SELECT COBRADOR, NOMBRE
                              FROM PIMENTEL.COBRADOR (NOLOCK)
                              ORDER BY 1; ";

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql).Tables[0];
        }

        // 05/09/2018
        public static DataTable dtCategoriaClientesDL(string db)
        {
            string strSql = @"SELECT DISTINCT CATEGORIA_CLIENTE AS CATEGORIA, CATEGORIA_CLIENTE AS DESCRIPCION
                              FROM PIMENTEL.CLIENTE (NOLOCK)
                              ORDER BY 1; ";

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql).Tables[0];
        }


        // 27/04/2018
        //CuentaBanco
        //Moneda
        //TipoSalida
        //SubTipoSalida
        public static DataTable dtObtenerCuentaBancoDL(string db)
        {
            string strSql = @"SELECT CUENTA_BANCO, NOMBRE, ENTIDAD_FINANCIERA,MONEDA,CTA_CONTABLE
                              FROM PIMENTEL.CUENTA_BANCARIA (NOLOCK)
                              ORDER BY 1; ";

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql).Tables[0];
        }


        public static DataTable dtObtenerMonedaDL(string db)
        {
            string strSql = @"SELECT MONEDA, NOMBRE
                              FROM PIMENTEL.MONEDA (NOLOCK)
                              ORDER BY 1; ";

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql).Tables[0];
        }

        //SELECT TIPO, SUBTIPO, DESCRIPCION
        //FROM PIMENTEL.SUBTIPO_DOC_CAJA(NOLOCK);
        public static DataTable dtObtenerTipoSalidaDL(string db)
        {
            string strSql = @"SELECT TIPO, SUBTIPO, DESCRIPCION
                              FROM PIMENTEL.SUBTIPO_DOC_CAJA (NOLOCK)
                              WHERE SUBTIPO='0' ORDER BY 1; ";

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql).Tables[0];
        }


        public static DataTable dtObtenerSubTipoSalidaDL(string _tipo, string db)
        {
            string strSql = @"SELECT TIPO, SUBTIPO, DESCRIPCION
                              FROM PIMENTEL.SUBTIPO_DOC_CAJA (NOLOCK)
                              WHERE TIPO = @TIPO  
                              ORDER BY 1; ";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@TIPO", _tipo));

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParams.ToArray()).Tables[0];
        }


    }


    // 05/04/2018
    public class RRhhDL
    {

        public static DataTable dtSucursalesDesdeCentroCostoDL(string db)
        {
            string strSql = @"SELECT SUCURSAL, DESCRIPCION
                              FROM PIMENTEL.V_APSSA_SUCURSAL_FROM_CC (NOLOCK)
                              ORDER BY SUCURSAL; ";

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql).Tables[0];
        }


        public static DataTable dtTiendasDesdeCentroCostoDL(string db)
        {
            string strSql = @"SELECT TIENDA, DESCRIPCION
                              FROM PIMENTEL.V_APSSA_TIENDA_FROM_CC (NOLOCK)
                              ORDER BY TIENDA; ";

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql).Tables[0];
        }

        public static DataTable dtTiendasDesdeCentroCostoFiltradoDL(string sucur, string db)
        {
            string strSql = @"SELECT TIENDA, DESCRIPCION
                              FROM PIMENTEL.APSSA_CC_TIENDA (NOLOCK)
                              WHERE SUCURSAL IN
                                  (SELECT LTRIM(RTRIM(Item)) as item FROM Pimentel.Fn_APPSA_Split(@SUCURSAL, ',')); ";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@SUCURSAL", sucur));

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParams.ToArray()).Tables[0];
        }

        public static DataTable dtCentroCostosEmpleadosFiltradoSucursalDL(string sucur, string db)
        {
            string strSql = @"SELECT
                                DEP.DEPARTAMENTO, DEP.DESCRIPCION, DEP.JEFE, SU.DESCRIPCION AS SUCURSAL
                                FROM PIMENTEL.DEPARTAMENTO (NOLOCK) DEP
                                INNER JOIN PIMENTEL.APSSA_CC_SUCURSAL (NOLOCK) SU  ON SU.SUCURSAL=SUBSTRING(DEP.DEPARTAMENTO,1,2)
                                WHERE SU.DESCRIPCION IN
                                        (SELECT LTRIM(RTRIM(Item)) as item FROM Pimentel.Fn_APPSA_Split(@SUCURSAL, ','))
                                ORDER BY 1;  ";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@SUCURSAL", sucur));

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParams.ToArray()).Tables[0];
        }

        public static DataTable dtCentroCostosEmpleadosFiltradoTiendaDL(string tiend, string db)
        {
            string strSql = @"SELECT
                                DEP.DEPARTAMENTO, DEP.DESCRIPCION, DEP.JEFE, TI.DESCRIPCION AS TIENDA
                                FROM PIMENTEL.DEPARTAMENTO (NOLOCK) DEP
                                INNER JOIN PIMENTEL.APSSA_CC_TIENDA (NOLOCK) TI  ON TI.TIENDA=SUBSTRING(DEP.DEPARTAMENTO,1,2)+'.'+SUBSTRING(DEP.DEPARTAMENTO,3,2)
                                WHERE TI.DESCRIPCION IN
                                        (SELECT LTRIM(RTRIM(Item)) as item FROM Pimentel.Fn_APPSA_Split(@TIENDA, ','))
                                ORDER BY 1;  ";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@TIENDA", tiend));

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParams.ToArray()).Tables[0];
        }


        public static DataTable dtCentroCostosEmpleadosDL(string db)
        {
            string strSql = @"SELECT DEPARTAMENTO, DESCRIPCION, JEFE
                              FROM PIMENTEL.DEPARTAMENTO(NOLOCK)
                              ORDER BY 1; ";

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql).Tables[0];
        }

        public static bool ExisteEmpleadoDL(string emple, string db)
        {
            int NumReg = 0;
            string strSql = @"SELECT COUNT(*) 
                              FROM PIMENTEL.EMPLEADO (NOLOCK)
                              WHERE EMPLEADO = @EMPLEADO";

            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@EMPLEADO", emple));

            NumReg = Convert.ToInt32(SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray()));
            return NumReg > 0;
        }

        public static DataTable CargaDatosEmpleadoDL(string emple, string db)
        {
            string strSql = @"SELECT EMPLEADO, NOMBRE
                              FROM PIMENTEL.EMPLEADO (NOLOCK)
                              WHERE EMPLEADO = @EMPLEADO";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@EMPLEADO", emple));

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParams.ToArray()).Tables[0];
        }


    }





    //14/09/2016
    public class RutinasVariosDL
    {

        public static DataTable dtObtenerMesesDL(string db)
        {
            string strSql = @" SET LANGUAGE SPANISH;                        
                               SELECT MES FROM PIMENTEL.Fn_APPSA_GET_MESES('N') ORDER BY IDMES ASC;  ";

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql).Tables[0];
        }

        public static DataTable dtObtenerAnnosDL(string db)
        {
            string strSql = @"                   
                              SELECT ANNO FROM PIMENTEL.Fn_APPSA_GET_ANNOS(2015,YEAR(GETDATE())) ORDER BY ANNO DESC;  ";

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql).Tables[0];
        }


    }

    public class Orden_ServiciosDL
    {

        public static void dtGrabaDatosTecnicoDL(string cDescr, string cDepar, string cPuest, string Centr, string cZon, Decimal nComis, string cPuesDes, string cTip, string cAct, string cCodTec, string db)
        {
            string strSql = @"UPDATE PIMENTEL.U_TECNICOS
                                SET
	                                U_DESCRIP=@U_DESCRIP,
	                                U_DEPARTAMENTO=@U_DEPARTAMENTO,
	                                U_PUESTO=@U_PUESTO,
	                                U_CENTRO_COSTO=@U_CENTRO_COSTO,
	                                U_ZONA=@U_ZONA,
	                                U_COMISION=@U_COMISION,
	                                U_PUESTO_DESCRIP=@U_PUESTO_DESCRIP,
	                                U_TIPO=@U_TIPO,
	                                U_ACTIVO=@U_ACTIVO
                                WHERE  U_CODIGO=@U_CODIGO;";

            List<SqlParameter> arParams = new List<SqlParameter>();

            arParams.Add(new SqlParameter("@U_DESCRIP", cDescr));
            arParams.Add(new SqlParameter("@U_DEPARTAMENTO", cDepar));
            arParams.Add(new SqlParameter("@U_PUESTO", cPuest));
            arParams.Add(new SqlParameter("@U_CENTRO_COSTO", Centr));
            arParams.Add(new SqlParameter("@U_ZONA", cZon));
            arParams.Add(new SqlParameter("@U_COMISION", nComis));
            arParams.Add(new SqlParameter("@U_PUESTO_DESCRIP", cPuesDes));
            arParams.Add(new SqlParameter("@U_TIPO", cTip));
            arParams.Add(new SqlParameter("@U_ACTIVO", cAct));
            arParams.Add(new SqlParameter("@U_CODIGO", cCodTec));

            SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParams.ToArray());

        }

    }

    public class InventariosDL
    {
        public DataTable dtListarArticulosReservadosDL(DateTime fini, DateTime fina, string bode, string tip, string docu, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_ARTICULOS_RESERVADOS";
            List<SqlParameter> arParams = new List<SqlParameter>();

            arParams.Add(new SqlParameter("@FECHA_INI", fini));
            arParams.Add(new SqlParameter("@FECHA_FIN", fina));
            arParams.Add(new SqlParameter("@BODEGA", bode));
            arParams.Add(new SqlParameter("@TIPO", tip));
            arParams.Add(new SqlParameter("@DOCUMENTO", docu));

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray()).Tables[0];
        }

        public DataTable dtListarArticulosReservados2DL(DateTime fini, DateTime fina, string zon, string tip, string docu, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_ARTICULOS_RESERVADOS_V2";
            List<SqlParameter> arParams = new List<SqlParameter>();

            arParams.Add(new SqlParameter("@FECHA_INI", fini));
            arParams.Add(new SqlParameter("@FECHA_FIN", fina));
            arParams.Add(new SqlParameter("@ZONA", zon));
            arParams.Add(new SqlParameter("@TIPO", tip));
            arParams.Add(new SqlParameter("@DOCUMENTO", docu));

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray()).Tables[0];
        }

    }

    public class FacturacionDL
    {
        public DataTable dtListarDevolucionesDL(DateTime fini, DateTime fina, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_LISTAR_DEVOLUCIONES";
            List<SqlParameter> arParams = new List<SqlParameter>();

            arParams.Add(new SqlParameter("@FECHAINI", fini));
            arParams.Add(new SqlParameter("@FECHAFIN", fina));

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray()).Tables[0];
        }

        public DataTable dtListarPedidoSinReservaDL(DateTime fini, DateTime fina, string zon, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_LISTAR_PEDIDO_SIN_RESERVA";
            List<SqlParameter> arParams = new List<SqlParameter>();

            arParams.Add(new SqlParameter("@FECHA_INI", fini));
            arParams.Add(new SqlParameter("@FECHA_FIN", fina));
            arParams.Add(new SqlParameter("@ZONA", zon));

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray()).Tables[0];
        }


    }

    public class CargaLookUpDL
    {

        //UPDATE: 2022-06-08
        public DataTable dtListarCuentaBancoDL(string db)
        {
            string strSql = @"SELECT CUENTA_BANCO, NOMBRE                         
	                          FROM PIMENTEL.CUENTA_BANCARIA (NOLOCK)
                              WHERE ENTIDAD_FINANCIERA='CJ_CHICA'                      
                              ORDER BY 2;  
                             ";

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql).Tables[0];
        }


        public DataTable dtListarTarjetasDL(string db)
        {
            string strSql = @"SELECT TIPO_TARJETA AS TARJETA, TIPO_TARJETA AS DESCRIPCION
	                          FROM PIMENTEL.TIPO_TARJETA (NOLOCK)                     
                              ORDER BY TIPO_TARJETA;  
                             ";

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql).Tables[0];
        }
        public DataTable dtListarCondicionPagoDL(string db)
        {
            string strSql = @"SELECT CONDICION_PAGO, DESCRIPCION                        
	                          FROM PIMENTEL.CONDICION_PAGO                         
                              ORDER BY CONDICION_PAGO;  
                             ";

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql).Tables[0];
        }

        public DataTable dtListarDepartamentoDL(string db)
        {
            string strSql = @"SELECT DEPARTAMENTO,DESCRIPCION                 
	                          FROM PIMENTEL.DEPARTAMENTO
                              ORDER BY DEPARTAMENTO ;  
                             ";

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql).Tables[0];
        }

        public DataTable dtListarPuestoDL(string db)
        {
            string strSql = @"SELECT PUESTO,DESCRIPCION               
	                          FROM PIMENTEL.PUESTO
                              ORDER BY PUESTO ;  
                             ";

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql).Tables[0];
        }

        public DataTable dtListarTipoPuestoDL(string db)
        {
            string strSql = @"SELECT U_CODIGO AS CODIGO, U_DESCRIP AS DESCRIPCION
	                          FROM PIMENTEL.U_TECNICO_TIPO                        
                              ORDER BY U_CODIGO;  
                             ";

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql).Tables[0];
        }



        public DataTable dtListarUnidadDL(string db)
        {
            string strSql = @"SELECT USUARIO, USUARIO AS NOMBRE                 
	                          FROM ERPADMIN.USUARIO  WHERE TIPO='G'
                              ORDER BY USUARIO ;  
                             ";

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql).Tables[0];
        }

        public DataTable dtListarGrupoUsuarioDL(string db)
        {
            string strSql = @"SELECT USUARIO, USUARIO AS NOMBRE                 
	                          FROM ERPADMIN.USUARIO  WHERE TIPO='G'
                              ORDER BY USUARIO ;  
                             ";

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql).Tables[0];
        }

        public DataTable dtListarCajaDL(string db)
        {
            string strSql = @"SELECT CAJA, DESCRIPCION                         
	                          FROM PIMENTEL.CAJA 
                              WHERE U_ACTIVO<>'NO'                    
                              ORDER BY CAJA;  
                             ";

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql).Tables[0];
        }

        public DataTable dtListarZonaDL(string db)
        {
            string strSql = @"SELECT ZONA, NOMBRE 	                        
	                          FROM PIMENTEL.ZONA                            
                              ORDER BY ZONA;  
                             ";

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql).Tables[0];
        }


        public DataTable dtListarDocumentoReservaDL(string db)
        {
            string strSql = @"SELECT DISTINCT LEFT(APLICACION,3)  AS TIPO                  
	                          FROM PIMENTEL.EXISTENCIA_RESERVA                            
                              ORDER BY LEFT(APLICACION,3);  
                             ";

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql).Tables[0];
        }

        public DataTable dtListarBodegaDL(string db)
        {
            string strSql = @"SELECT BODEGA, NOMBRE 	                        
	                          FROM PIMENTEL.BODEGA                             
                              ORDER BY BODEGA;  
                             ";

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql).Tables[0];
        }

        public DataTable dtListarFamiliaDL(string db)
        {
            string strSql = @"SELECT CLASIFICACION,DESCRIPCION	                        
	                          FROM PIMENTEL.CLASIFICACION                             
                              WHERE AGRUPACION=1 ORDER BY CLASIFICACION;  
                             ";

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql).Tables[0];
        }

        public DataTable dtListarSubFamiliaDL(string db)
        {
            string strSql = @"SELECT CLASIFICACION,DESCRIPCION	                        
	                          FROM PIMENTEL.CLASIFICACION                             
                              WHERE AGRUPACION=2 ORDER BY CLASIFICACION;  
                             ";

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql).Tables[0];
        }

        public DataTable dtListarGrupoDL(string db)
        {
            string strSql = @"SELECT CLASIFICACION,DESCRIPCION	                        
	                          FROM PIMENTEL.CLASIFICACION                             
                              WHERE AGRUPACION=3 ORDER BY CLASIFICACION;  
                             ";

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql).Tables[0];
        }

        public DataTable dtListarSubFamiliaFiltroDL(string cfamilia, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_LISTAR_SUBFAMILIA";
            List<SqlParameter> arParams = new List<SqlParameter>();

            arParams.Add(new SqlParameter("@FAMILIA", cfamilia));

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray()).Tables[0];
        }

        public DataTable dtListarGrupoFiltroDL(string csubfamilia, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_LISTAR_GRUPO";
            List<SqlParameter> arParams = new List<SqlParameter>();

            arParams.Add(new SqlParameter("@SUBFAMILIA", csubfamilia));

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray()).Tables[0];
        }

        //--------------------------------------------------------------------------------- 16/03/2016
        public DataTable dtListarSubFamiliaFiltro2DL(string cfamilia, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_LISTAR_SUBFAMILIA_CODE";
            List<SqlParameter> arParams = new List<SqlParameter>();

            arParams.Add(new SqlParameter("@FAMILIA", cfamilia));

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray()).Tables[0];
        }

        public DataTable dtListarGrupoFiltro2DL(string csubfamilia, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_LISTAR_GRUPO_CODE";
            List<SqlParameter> arParams = new List<SqlParameter>();

            arParams.Add(new SqlParameter("@SUBFAMILIA", csubfamilia));

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray()).Tables[0];
        }


    }

    public class EntidadesExactusDL
    {
        //MAXMAX  14/12/2021
        public DataTable dtBuscarArticuloDL(string codigo, string descripcion, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_ARTICULO_BUSCAR";
            List<SqlParameter> arParams = new List<SqlParameter>();

            arParams.Add(new SqlParameter("@ARTICULO", codigo));
            arParams.Add(new SqlParameter("@DESCRIPCION", descripcion));

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray()).Tables[0];
        }


        public DataTable dtCajaAbierta_DL(string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_CAJAS_ABIERTAS";
            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql).Tables[0];
        }

        public static bool SiExistePedidoDL(string ped, string db)
        {
            Int32 nEncontrados = 0;

            string strSql = @"SELECT  COUNT(*)
	                            FROM PIMENTEL.PEDIDO
                                WHERE PEDIDO=@PEDIDO;
                             ";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@PEDIDO", ped));
            nEncontrados = Convert.ToInt32(SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParams.ToArray()));
            return nEncontrados > 0;
        }

        public static bool SiExisteOrdenDL(string ord, string db)
        {
            Int32 nEncontrados = 0;

            string strSql = @"SELECT  COUNT(*)
	                            FROM PIMENTEL.ORDEN_SERVICIO
                                WHERE OSERVICIO=@OSERVICIO;
                             ";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@OSERVICIO", ord));
            nEncontrados = Convert.ToInt32(SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParams.ToArray()));
            return nEncontrados > 0;
        }

        public DataTable dtListarMotivoAnulaOS_DL(string db)
        {
            string strSql = @"SELECT 
                              U_CODIGO, U_DESCRIP , U_REFERENCIA
	                          FROM PIMENTEL.U_OS_MOTIVOS_ANUL;
                             ";
            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql).Tables[0];
        }

        public DataTable dtListarPedidoCreditoDL(string tipodoc, DateTime fecha1, DateTime fecha2, string condic, string zona, string cliente, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_LISTA_PEDIDO_CREDITOS";
            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@TIPODOC", tipodoc));
            arParams.Add(new SqlParameter("@FECHA_INI", fecha1));
            arParams.Add(new SqlParameter("@FECHA_FIN", fecha2));
            arParams.Add(new SqlParameter("@CONDICION", condic));
            arParams.Add(new SqlParameter("@ZONA", zona));
            arParams.Add(new SqlParameter("@CLIENTE", cliente));


            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray()).Tables[0];
        }

        public DataTable dtListarUsuarioBodegaDL(string vusuario, string db)
        {
            string strSql = @"SELECT 
	                            U_USUARIO,U_BODEGA
	                            FROM PIMENTEL.U_USUARIO_BODEGA 
                                WHERE U_USUARIO=@U_USUARIO;
                             ";

            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@U_USUARIO", vusuario));
            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParams.ToArray()).Tables[0];
        }

        public DataTable dtListarUsuarioZonaDL(string vusuario, string db)
        {
            string strSql = @"SELECT 
	                            U_USUARIO,U_ZONA
	                            FROM PIMENTEL.U_USUARIO_ZONA
                                WHERE U_USUARIO=@U_USUARIO;
                             ";
            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@U_USUARIO", vusuario));
            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParams.ToArray()).Tables[0];
        }

        public DataTable dtListarUsuarioCajaDL(string vusuario, string db)
        {
            string strSql = @"SELECT 
	                            USUARIO,CAJA
	                            FROM PIMENTEL.USUARIO_CAJA_FA
                                WHERE USUARIO=@USUARIO;
                             ";
            List<SqlParameter> arParams = new List<SqlParameter>();
            arParams.Add(new SqlParameter("@USUARIO", vusuario));
            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParams.ToArray()).Tables[0];
        }

        public DataTable dtListarUsuariosDL(string db)
        {
            string strSql = @"SELECT 
                                  U.USUARIO,U.NOMBRE,
                                  U.CARGO,U.CAJA,U.ZONA,U.BODEGA,U.UNIDAD,U.GRUPO,
                                  U.CORREO_ELECTRONICO,U.TIPO_ACCESO,U.CELULAR,U.FIRMA,
                                  U.TIPO,U.ACTIVO,U.REQ_CAMBIO_CLAVE,
                                  U.FRECUENCIA_CLAVE,U.FECHA_ULT_CLAVE,U.MAX_INTENTOS_CONEX,
                                  U.CLAVE,U.CLAVE_REPORTE                                                                    
                                  FROM ERPADMIN.USUARIO U        
                                  ORDER BY U.GRUPO,U.NOMBRE";


            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql).Tables[0];
        }

        public DataTable dtListarTecnicosDL(string db)
        {
            string strSql = @"SELECT 
	                            U_CODIGO, U_DESCRIP,U_ACTIVO,U_ZONA,U_COMISION,U_DEPARTAMENTO,U_TIPO,U_CENTRO_COSTO,U_PUESTO_DESCRIP,U_PUESTO
	                            FROM PIMENTEL.U_TECNICOS;
                             ";

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql).Tables[0];
        }

        public DataTable dtListarGruposDL(string db)
        {
            string strSql = @"SELECT DISTINCT GRUPO 
                              FROM ERPADMIN.MEMBRESIA ORDER BY GRUPO;
                             ";

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql).Tables[0];
        }

        public DataTable dtListarUsuarioPorGruposDL(string grupo, string db)
        {
            string strSql = @"SELECT 
                              U.USUARIO,U.NOMBRE,
                              U.ZONA AS CODZON ,Z.NOMBRE AS ZONA,
                              U.BODEGA AS CODBOD, B.NOMBRE AS BODEGA,
                              U.CAJA,U.UNIDAD,M.GRUPO,U.CLAVE_REPORTE
                              FROM ERPADMIN.USUARIO U
                              INNER JOIN ERPADMIN.MEMBRESIA M ON M.USUARIO=U.USUARIO
                              LEFT JOIN PIMENTEL.ZONA Z ON U.ZONA=Z.ZONA
                              LEFT JOIN PIMENTEL.BODEGA B ON U.BODEGA=B.BODEGA
                              WHERE M.GRUPO LIKE '%" + grupo + "%';";


            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql).Tables[0];
        }

        public DataTable dtBuscarClienteDL(string codigo, string nombre, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_CLIENTE_BUSCAR";
            List<SqlParameter> arParams = new List<SqlParameter>();

            arParams.Add(new SqlParameter("@CLIENTE", codigo));
            arParams.Add(new SqlParameter("@NOMBRE", nombre));

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray()).Tables[0];
        }

        public DataTable dtBuscarEmpleadoDL(string codigo, string nombre, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_EMPLEADO_BUSCAR";
            List<SqlParameter> arParams = new List<SqlParameter>();

            arParams.Add(new SqlParameter("@EMPLEADO", codigo));
            arParams.Add(new SqlParameter("@NOMBRE", nombre));

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray()).Tables[0];
        }
    }

    public static class Usuario_ReporteDL
    {

        public static void UpdateConfiguracionUsuarioDL(string cTabla, string cAccion, string cUsuario, string cValorCampo, string db)
        {
            string strSql = "PIMENTEL.SP_APSSA_USUARIO_CONFIGURACION_UPDATE";
            List<SqlParameter> arParams = new List<SqlParameter>();

            arParams.Add(new SqlParameter("@TABLA", cTabla));
            arParams.Add(new SqlParameter("@ACCION", cAccion));
            arParams.Add(new SqlParameter("@USUARIO", cUsuario));
            arParams.Add(new SqlParameter("@CAMPO", cValorCampo));

            SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.StoredProcedure, strSql, arParams.ToArray());
        }

        public static void GrabarUsuarioReporteDL(string cUnidad, string cGrupo, string cCaja, string cZona, string cBodega, string cClave_reporte, string cUsuario, string db)
        {

            string strSql = @"UPDATE ERPADMIN.USUARIO
                                    SET  
                                    UNIDAD = @unidad,
                                    GRUPO = @grupo,
                                    CAJA = @caja,
                                    ZONA = @zona,
                                    BODEGA = @bodega,
                                    CLAVE_REPORTE = @clave_reporte
                                    WHERE USUARIO = @usuario;";


            List<SqlParameter> arParam = new List<SqlParameter>();
            arParam.Add(new SqlParameter("@UNIDAD", cUnidad));
            arParam.Add(new SqlParameter("@GRUPO", cGrupo));
            arParam.Add(new SqlParameter("@CAJA", cCaja));
            arParam.Add(new SqlParameter("@ZONA", cZona));
            arParam.Add(new SqlParameter("@BODEGA", cBodega));
            arParam.Add(new SqlParameter("@CLAVE_REPORTE", cClave_reporte));
            arParam.Add(new SqlParameter("@USUARIO", cUsuario));

            SqlHelper.ExecuteScalar(ConexionDC.ConectarBD(db), CommandType.Text, strSql, arParam.ToArray());
        }


        private static Usuario_ReporteBE Carga_Usuario_Reporte(IDataReader reader)
        {
            Usuario_ReporteBE usuario_reporte = new Usuario_ReporteBE();

            usuario_reporte.usuario = Convert.ToString(reader["USUARIO"]);
            usuario_reporte.nombre = Convert.ToString(reader["NOMBRE"]);
            usuario_reporte.tipo = Convert.ToString(reader["TIPO"]);
            usuario_reporte.activo = Convert.ToString(reader["ACTIVO"]);
            usuario_reporte.req_cambio_clave = Convert.ToString(reader["REQ_CAMBIO_CLAVE"]);
            usuario_reporte.frecuencia_clave = Convert.ToInt32(reader["FRECUENCIA_CLAVE"]);
            usuario_reporte.fecha_ult_clave = Convert.ToDateTime(reader["FECHA_ULT_CLAVE"]);
            usuario_reporte.max_intentos_conex = Convert.ToInt32(reader["MAX_INTENTOS_CONEX"]);
            usuario_reporte.clave = Convert.ToString(reader["CLAVE"]);
            usuario_reporte.correo_electronico = Convert.ToString(reader["CORREO_ELECTRONICO"]);
            usuario_reporte.tipo_acceso = Convert.ToString(reader["TIPO_ACCESO"]);
            usuario_reporte.celular = Convert.ToString(reader["CELULAR"]);
            usuario_reporte.firma = Convert.ToString(reader["FIRMA"]);
            usuario_reporte.cargo = Convert.ToString(reader["CARGO"]);
            usuario_reporte.zona = Convert.ToString(reader["ZONA"]);
            usuario_reporte.bodega = Convert.ToString(reader["BODEGA"]);
            usuario_reporte.clave_reporte = Convert.ToString(reader["CLAVE_REPORTE"]);
            usuario_reporte.grupo = Convert.ToString(reader["GRUPO"]);
            return usuario_reporte;
        }

        public static List<Usuario_ReporteBE> ObtenerTodos(string db)
        {
            List<Usuario_ReporteBE> list = new List<Usuario_ReporteBE>();

            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                conn.Open();
                //                string strSql = @"SELECT 
                //                                USUARIO,NOMBRE,TIPO,ACTIVO,REQ_CAMBIO_CLAVE,FRECUENCIA_CLAVE,
                //                                FECHA_ULT_CLAVE,MAX_INTENTOS_CONEX,CLAVE,CORREO_ELECTRONICO,
                //                                TIPO_ACCESO,CELULAR,FIRMA,CARGO    
                //                                FROM ERPADMIN.USUARIO ORDER BY NOMBRE";
                string strSql = @"SELECT 
                                  U.USUARIO,U.NOMBRE,U.TIPO,U.ACTIVO,U.REQ_CAMBIO_CLAVE,
                                  U.FRECUENCIA_CLAVE,U.FECHA_ULT_CLAVE,U.MAX_INTENTOS_CONEX,
                                  U.CLAVE,U.CORREO_ELECTRONICO,U.TIPO_ACCESO,U.CELULAR,U.FIRMA,
                                  U.CARGO,U.ZONA,U.BODEGA,U.CLAVE_REPORTE,M.GRUPO                                      
                                  FROM ERPADMIN.USUARIO U
                                  INNER JOIN ERPADMIN.MEMBRESIA M ON M.USUARIO=U.USUARIO          
                                  ORDER BY M.GRUPO,U.NOMBRE";

                SqlCommand cmd = new SqlCommand(strSql, conn);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    list.Add(Carga_Usuario_Reporte(reader));
                }
            }

            return list;
        }

        public static Usuario_ReporteBE BuscarPor(string usuario, string db)
        {
            Usuario_ReporteBE usuario_reporte = null;

            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                conn.Open();

                //                string strSql = @"SELECT
                //                                USUARIO,NOMBRE,TIPO,ACTIVO,REQ_CAMBIO_CLAVE,FRECUENCIA_CLAVE,
                //                                FECHA_ULT_CLAVE,MAX_INTENTOS_CONEX,CLAVE,CORREO_ELECTRONICO,
                //                                TIPO_ACCESO,CELULAR,FIRMA,CARGO      
                //                                FROM ERPADMIN.USUARIO 
                //                                WHERE USUARIO = @usuario";

                string strSql = @"SELECT 
                                  U.USUARIO,U.NOMBRE,U.TIPO,U.ACTIVO,U.REQ_CAMBIO_CLAVE,
                                  U.FRECUENCIA_CLAVE,U.FECHA_ULT_CLAVE,U.MAX_INTENTOS_CONEX,
                                  U.CLAVE,U.CORREO_ELECTRONICO,U.TIPO_ACCESO,U.CELULAR,U.FIRMA,
                                  U.CARGO,U.ZONA,U.BODEGA,U.CLAVE_REPORTE,M.GRUPO                                      
                                  FROM ERPADMIN.USUARIO U
                                  INNER JOIN ERPADMIN.MEMBRESIA M ON M.USUARIO=U.USUARIO
                                  WHERE U.USUARIO = @usuario";


                SqlCommand cmd = new SqlCommand(strSql, conn);
                cmd.Parameters.AddWithValue("@usuario", usuario);

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    usuario_reporte = Carga_Usuario_Reporte(reader);
                }
            }

            return usuario_reporte;
        }

        public static bool SiExiste(string usuario, string db)
        {
            int nEncontrados = 0;

            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                conn.Open();

                string strSql = @"SELECT Count(*)
                                FROM ERPADMIN.USUARIO  
                                WHERE USUARIO = @usuario";

                SqlCommand cmd = new SqlCommand(strSql, conn);
                cmd.Parameters.AddWithValue("@usuario", usuario);

                nEncontrados = Convert.ToInt32(cmd.ExecuteScalar());
            }

            return nEncontrados > 0;

        }

        public static Usuario_ReporteBE Agregar(Usuario_ReporteBE usuario_reporte, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                string strSql = @"INSERT INTO ERPADMIN.USUARIO 
                                (USUARIO,NOMBRE,TIPO,ACTIVO,REQ_CAMBIO_CLAVE,FRECUENCIA_CLAVE,
                                FECHA_ULT_CLAVE,MAX_INTENTOS_CONEX,CLAVE,CORREO_ELECTRONICO,
                                TIPO_ACCESO,CELULAR,FIRMA,CARGO,ZONA,BODEGA,CLAVE_REPORTE ) 
                                VALUES 
                                (@usuario,@nombre,@tipo,@activo,@req_cambio_clave,@frecuencia_clave,
                                 @fecha_ult_clave,@max_intentos_conex,@clave,@correo_electronico,
                                 @tipo_acceso,@celular,@firma,@cargo,@zona,@bodega,@clave_reporte)
                               SELECT SCOPE_IDENTITY()";

                SqlCommand cmd = new SqlCommand(strSql, conn);

                cmd.Parameters.AddWithValue("@usuario", usuario_reporte.usuario);
                cmd.Parameters.AddWithValue("@nombre", usuario_reporte.nombre);
                cmd.Parameters.AddWithValue("@tipo", usuario_reporte.tipo);
                cmd.Parameters.AddWithValue("@activo", usuario_reporte.activo);
                cmd.Parameters.AddWithValue("@req_cambio_clave", usuario_reporte.req_cambio_clave);
                cmd.Parameters.AddWithValue("@frecuencia_clave", usuario_reporte.frecuencia_clave);
                cmd.Parameters.AddWithValue("@fecha_ult_clave", usuario_reporte.fecha_ult_clave);
                cmd.Parameters.AddWithValue("@max_intentos_conex", usuario_reporte.max_intentos_conex);
                cmd.Parameters.AddWithValue("@clave", usuario_reporte.clave);
                cmd.Parameters.AddWithValue("@correo_electronico", usuario_reporte.correo_electronico);
                cmd.Parameters.AddWithValue("@tipo_acceso", usuario_reporte.tipo_acceso);
                cmd.Parameters.AddWithValue("@celular", usuario_reporte.celular);
                cmd.Parameters.AddWithValue("@firma", usuario_reporte.firma);
                cmd.Parameters.AddWithValue("@cargo", usuario_reporte.cargo);
                cmd.Parameters.AddWithValue("@zona", usuario_reporte.zona);
                cmd.Parameters.AddWithValue("@bodega", usuario_reporte.bodega);
                cmd.Parameters.AddWithValue("@clave_reporte", usuario_reporte.clave_reporte);

                usuario_reporte.usuario = Convert.ToString(cmd.ExecuteScalar());
            }

            return usuario_reporte;

        }

        public static Usuario_ReporteBE Actualizar(Usuario_ReporteBE usuario_reporte, string db)
        {
            using (SqlConnection conn = new SqlConnection(ConexionDC.ConectarBD(db)))
            {
                conn.Open();

                string strSql = @"UPDATE ERPADMIN.USUARIO
                                    SET  
                                    NOMBRE = @nombre,
                                    TIPO = @tipo,
                                    ACTIVO = @activo,
                                    REQ_CAMBIO_CLAVE = @req_cambio_clave,
                                    FRECUENCIA_CLAVE = @frecuencia_clave,
                                    FECHA_ULT_CLAVE = @fecha_ult_clave,
                                    MAX_INTENTOS_CONEX = @max_intentos_conex,
                                    CLAVE = @clave,
                                    CORREO_ELECTRONICO = @correo_electronico,
                                    TIPO_ACCESO = @tipo_acceso,
                                    CELULAR = @celular,
                                    FIRMA = @firma,
                                    CARGO = @cargo
                                    ZONA = @zona,
                                    BODEGA = @bodega,
                                    CLAVE_REPORTE = @clave_reporte
                                    WHERE USUARIO = @usuario;";

                SqlCommand cmd = new SqlCommand(strSql, conn);

                cmd.Parameters.AddWithValue("@usuario", usuario_reporte.usuario);
                cmd.Parameters.AddWithValue("@nombre", usuario_reporte.nombre);
                cmd.Parameters.AddWithValue("@tipo", usuario_reporte.tipo);
                cmd.Parameters.AddWithValue("@activo", usuario_reporte.activo);
                cmd.Parameters.AddWithValue("@req_cambio_clave", usuario_reporte.req_cambio_clave);
                cmd.Parameters.AddWithValue("@frecuencia_clave", usuario_reporte.frecuencia_clave);
                cmd.Parameters.AddWithValue("@fecha_ult_clave", usuario_reporte.fecha_ult_clave);
                cmd.Parameters.AddWithValue("@max_intentos_conex", usuario_reporte.max_intentos_conex);
                cmd.Parameters.AddWithValue("@clave", usuario_reporte.clave);
                cmd.Parameters.AddWithValue("@correo_electronico", usuario_reporte.correo_electronico);
                cmd.Parameters.AddWithValue("@tipo_acceso", usuario_reporte.tipo_acceso);
                cmd.Parameters.AddWithValue("@celular", usuario_reporte.celular);
                cmd.Parameters.AddWithValue("@firma", usuario_reporte.firma);
                cmd.Parameters.AddWithValue("@cargo", usuario_reporte.cargo);
                cmd.Parameters.AddWithValue("@zona", usuario_reporte.zona);
                cmd.Parameters.AddWithValue("@bodega", usuario_reporte.bodega);
                cmd.Parameters.AddWithValue("@clave_reporte", usuario_reporte.clave_reporte);

                cmd.ExecuteNonQuery();

            }

            return usuario_reporte;
        }

        public static DataSet Listar_Usuario_Caja(string Usuario, string db)
        {
            try
            {
                DataSet ds_uc = new DataSet();
                string strSql = @" select U.CAJA,C.DESCRIPCION from pimentel.USUARIO_CAJA_FA  U 
                                   INNER JOIN PIMENTEL.CAJA C ON U.CAJA=C.CAJA
                                   where U.USUARIO='" + Usuario + "'";

                ds_uc = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql);

                ds_uc.Tables[0].TableName = "uc";
                return ds_uc;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public static DataSet Listar_Usuario_Bodega(string Usuario, string db)
        {
            try
            {
                DataSet ds_uz = new DataSet();
                string strSql = @" SELECT U_BODEGA AS BODEGA,U_BODEGA_DESCRIP AS BODEGA_DESCRIP 
                                   FROM PIMENTEL.U_USUARIO_BODEGA 
                                   WHERE U_USUARIO='" + Usuario + "'";

                ds_uz = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql);

                ds_uz.Tables[0].TableName = "uc";
                return ds_uz;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public static DataSet Listar_Usuario_Zona(string Usuario, string db)
        {
            try
            {
                DataSet ds_uz = new DataSet();
                string strSql = @" SELECT U_ZONA AS ZONA,U_ZONA_DESCRIP AS ZONA_DESCRIP 
                                  FROM PIMENTEL.U_USUARIO_ZONA 
                                  WHERE U_USUARIO='" + Usuario + "'";

                ds_uz = SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql);

                ds_uz.Tables[0].TableName = "uz";
                return ds_uz;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

    }

    public class VendedorDL
    {
        public DataTable dtListarVendedorDL(string db)
        {
            string strSql = @"SELECT 
                              VENDEDOR,NOMBRE,EMPLEADO,COMISION,CTR_COMISION,CTA_COMISION,E_MAIL 
                              FROM PIMENTEL.VENDEDOR;
                             ";

            return SqlHelper.ExecuteDataset(ConexionDC.ConectarBD(db), CommandType.Text, strSql).Tables[0];
        }
    }

    public class AccesoGeneralDL
    {

        public static DataSet CargaExcel(string RutaExcel, string NombreHoja)
        {
            try
            {
                System.Data.OleDb.OleDbConnection connXls;
                System.Data.DataSet DSet;
                System.Data.OleDb.OleDbDataAdapter cmdXls;
                connXls = new System.Data.OleDb.OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                //RutaExcel + ";Extended Properties="+"""Excel 12.0;HDR=YES"""+" "+);
                                                                 RutaExcel + ";Extended Properties=\"Excel 12.0;HDR=YES\"");
                //Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & SLibro & ";Extended Properties=""Excel 12.0;HDR=YES""
                //Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" & SLibro & ";Extended Properties=""Excel 12.0;HDR=YES"
                cmdXls = new System.Data.OleDb.OleDbDataAdapter

                ("select * from [" + NombreHoja + "$]", connXls);
                cmdXls.TableMappings.Add("Table", "TestTable");
                DSet = new System.Data.DataSet();
                cmdXls.Fill(DSet);
                connXls.Close();
                return DSet;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }

        }

        /*  PENDIENTE
        public void CargaHojasXls(string TipoLoad)
        {

            string FileXls = null;

            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
                FileXls = openFileDialog1.FileName;

            Excel.Application ExcelApp = new Excel.Application();
            Excel.Workbook ExcelWorkbook = default(Excel.Workbook);

            ExcelWorkbook = ExcelApp.Workbooks.Open(Filename: FileXls);

            foreach (Excel.Worksheet sheet in ExcelWorkbook.Worksheets)
            {
                if (TipoLoad == "ArchXls")
                {
                    cboHojas.Items.Add(sheet.Name);
                    txtPathXls.Text = FileXls;
                }
                else
                {
                    cboHojas.Items.Add(sheet.Name);
                    txtPathXls.Text = FileXls;
                }
            }

            ExcelWorkbook.Close();
            ExcelWorkbook = null;

            ExcelApp.Quit();
            ExcelApp = null;
        }
        */


    }
}
