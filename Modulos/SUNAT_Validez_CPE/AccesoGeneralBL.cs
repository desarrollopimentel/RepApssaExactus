using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
//using Exactus.BE;
//using Exactus.DL;

namespace ApssaExactus
{

    // 05/09/2018
    public class EntidadesBL
    {
        public static DataTable CargaDatosClienteBL(string clie, string db)
        {
            return EntidadesDL.CargaDatosClienteDL(clie, db);
        }


        public static DataTable CargaDatosVendedorBL(string vend, string db)
        {
            return EntidadesDL.CargaDatosVendedorDL(vend, db);
        }




    }

    public class AccesoUsuarioBL
    {
        public static bool UsuarioOpcionAccesoBL(string _user, string _parametro, string db)
        {
            //return AccesoUsuarioDL.UsuarioOpcionAccesoDL(_user, _parametro, db);
            if (AccesoUsuarioDL.UsuarioOpcionAccesoDL(_user, _parametro, db))
                return true;
            else
                return false;
        }

    }

    // 27/04/2018
    public class TablasExactusBL
    {
        public static DataTable dtObtenerEstadosFeBL(string db)
        {
            return TablasExactusDL.dtObtenerEstadosFeDL(db);
        }

        public static DataTable dtObtenerTipoDocumentoBL(string db)
        {
            return TablasExactusDL.dtObtenerTipoDocumentoDL(db);
        }

        // 05/09/2018
        public static DataTable dtAnalistasCreditoBL(string db)
        {
            return TablasExactusDL.dtAnalistasCreditoDL(db);
        }

        // 05/09/2018
        public static DataTable dtCobradoresCreditosBL(string db)
        {
            return TablasExactusDL.dtCobradoresCreditosDL(db);
        }

        // 05/09/2018
        public static DataTable dtCategoriaClientesBL(string db)
        {
            return TablasExactusDL.dtCategoriaClientesDL(db);
        }
        public static DataTable dtObtenerCuentaBancoBL(string db)
        {
            return TablasExactusDL.dtObtenerCuentaBancoDL(db);
        }

        public static DataTable dtObtenerMonedaBL(string db)
        {
            return TablasExactusDL.dtObtenerMonedaDL(db);
        }

        public static DataTable dtObtenerTipoSalidaBL(string db)
        {
            return TablasExactusDL.dtObtenerTipoSalidaDL(db);
        }

        public static DataTable dtObtenerSubTipoSalidaBL(string _tipo, string db)
        {
            return TablasExactusDL.dtObtenerSubTipoSalidaDL(_tipo, db);
        }


    }


    // 05/04/2018
    public class RRhhBL
    {
        public static DataTable dtSucursalesDesdeCentroCostoBL(string db)
        {
            return RRhhDL.dtSucursalesDesdeCentroCostoDL(db);
        }


        public static DataTable dtTiendasDesdeCentroCostoBL(string db)
        {
            return RRhhDL.dtTiendasDesdeCentroCostoDL(db);
        }

        public static DataTable dtTiendasDesdeCentroCostoFiltradoBL(string sucur, string db)
        {
            return RRhhDL.dtTiendasDesdeCentroCostoFiltradoDL(sucur, db);
        }

        public static DataTable dtCentroCostosEmpleadosFiltradoSucursalBL(string sucur, string db)
        {
            return RRhhDL.dtCentroCostosEmpleadosFiltradoSucursalDL(sucur, db);
        }

        public static DataTable dtCentroCostosEmpleadosFiltradoTiendaBL(string tiend, string db)
        {
            return RRhhDL.dtCentroCostosEmpleadosFiltradoTiendaDL(tiend, db);
        }

        public static DataTable dtCentroCostosEmpleadosBL(string db)
        {
            return RRhhDL.dtCentroCostosEmpleadosDL(db);
        }

        public static bool ExisteEmpleadoBL(string emple, string db)
        {
            return RRhhDL.ExisteEmpleadoDL(emple, db);
        }

        public static DataTable CargaDatosEmpleadoBL(string emple, string db)
        {
            return RRhhDL.CargaDatosEmpleadoDL(emple, db);
        }


    }


    //14/09/2016
    public class RutinasVariosBL
    {

        public static DataTable dtObtenerMesesBL(string db)
        {
            return RutinasVariosDL.dtObtenerMesesDL(db);
        }


        public static DataTable dtObtenerAnnosBL(string db)
        {
            return RutinasVariosDL.dtObtenerAnnosDL(db);
        }
    }


    public class Orden_ServiciosBL
    {
        public static void dtGrabaDatosTecnicoBL(string cDescr, string cDepar, string cPuest, string Centr, string cZon, Decimal nComis, string cPuesDes, string cTip, string cAct, string cCodTec, string db)
        {
            Orden_ServiciosDL.dtGrabaDatosTecnicoDL(cDescr, cDepar, cPuest, Centr, cZon, nComis, cPuesDes, cTip, cAct, cCodTec, db);
        }
    }

    public class InventariosBL
    {
        //Exactus.DL.InventariosDL objInventariosBL = new Exactus.DL.InventariosDL();
        ApssaExactus.InventariosDL objInventariosBL = new ApssaExactus.InventariosDL();

        public DataTable dtListarArticulosReservadosBL(DateTime fini, DateTime fina, string bode, string tip, string docu, string db)
        {
            return objInventariosBL.dtListarArticulosReservadosDL(fini, fina, bode, tip, docu, db);
        }

        public DataTable dtListarArticulosReservados2BL(DateTime fini, DateTime fina, string zon, string tip, string docu, string db)
        {
            return objInventariosBL.dtListarArticulosReservados2DL(fini, fina, zon, tip, docu, db);
        }

    }

    public class FacturacionBL
    {
        ApssaExactus.FacturacionDL objFacturacionBL = new ApssaExactus.FacturacionDL();

        public DataTable dtListarDevolucionesBL(DateTime fini, DateTime fina, string db)
        {
            return objFacturacionBL.dtListarDevolucionesDL(fini, fina, db);
        }

        public DataTable dtListarPedidoSinReservaBL(DateTime fini, DateTime fina, string zon, string db)
        {
            return objFacturacionBL.dtListarPedidoSinReservaDL(fini, fina, zon, db);
        }


    }

    public class CargaLookUpBL
    {
        ApssaExactus.CargaLookUpDL objCargaLookUpBL = new ApssaExactus.CargaLookUpDL();

        //UPDATE: 2022-06-08
        public DataTable dtListarCuentaBancoBL(string db)
        {
            return objCargaLookUpBL.dtListarCuentaBancoDL(db);
        }

        public DataTable dtListarTarjetasBL(string db)
        {
            return objCargaLookUpBL.dtListarTarjetasDL(db);
        }

        public DataTable dtListarCondicionPagoBL(string db)
        {
            return objCargaLookUpBL.dtListarCondicionPagoDL(db);
        }


        public DataTable dtListarDepartamentoBL(string db)
        {
            return objCargaLookUpBL.dtListarDepartamentoDL(db);
        }

        public DataTable dtListarPuestoBL(string db)
        {
            return objCargaLookUpBL.dtListarPuestoDL(db);
        }

        public DataTable dtListarTipoPuestoBL(string db)
        {
            return objCargaLookUpBL.dtListarTipoPuestoDL(db);
        }

        public DataTable dtListarUnidadBL(string db)
        {
            return objCargaLookUpBL.dtListarUnidadDL(db);
        }

        public DataTable dtListarGrupoUsuarioBL(string db)
        {
            return objCargaLookUpBL.dtListarGrupoUsuarioDL(db);
        }

        public DataTable dtListarCajaBL(string db)
        {
            return objCargaLookUpBL.dtListarCajaDL(db);
        }

        public DataTable dtListarZonaBL(string db)
        {
            return objCargaLookUpBL.dtListarZonaDL(db);
        }

        public DataTable dtListarDocumentoReservaBL(string db)
        {
            return objCargaLookUpBL.dtListarDocumentoReservaDL(db);
        }

        public DataTable dtListarBodegaBL(string db)
        {
            return objCargaLookUpBL.dtListarBodegaDL(db);
        }

        public DataTable dtListarFamiliaBL(string db)
        {
            return objCargaLookUpBL.dtListarFamiliaDL(db);
        }

        public DataTable dtListarSubFamiliaBL(string db)
        {
            return objCargaLookUpBL.dtListarSubFamiliaDL(db);
        }

        public DataTable dtListarGrupoBL(string db)
        {
            return objCargaLookUpBL.dtListarGrupoDL(db);
        }

        public DataTable dtListarSubFamiliaFiltroBL(string cfamilia, string db)
        {
            return objCargaLookUpBL.dtListarSubFamiliaFiltroDL(cfamilia, db);
        }

        public DataTable dtListarGrupoFiltroBL(string csubfamilia, string db)
        {
            return objCargaLookUpBL.dtListarGrupoFiltroDL(csubfamilia, db);
        }

        //--------------------------------------------------------------------------------- 16/03/2016
        public DataTable dtListarSubFamiliaFiltro2BL(string cfamilia, string db)
        {
            return objCargaLookUpBL.dtListarSubFamiliaFiltro2DL(cfamilia, db);
        }

        public DataTable dtListarGrupoFiltro2BL(string csubfamilia, string db)
        {
            return objCargaLookUpBL.dtListarGrupoFiltro2DL(csubfamilia, db);
        }


    }

    //MAXMAX  14/12/2021
    public class EntidadesExactusBL
    {
        ApssaExactus.EntidadesExactusDL objEntidadesExactusBL = new ApssaExactus.EntidadesExactusDL();

        public DataTable dtBuscarArticuloBL(string codigo, string descripcion, string db)
        {
            return objEntidadesExactusBL.dtBuscarArticuloDL(codigo, descripcion, db);
        }


        public DataTable dtCajaAbierta_BL(string db)
        {
            return objEntidadesExactusBL.dtCajaAbierta_DL(db);
        }

        public static bool SiExistePedidoBL(string ped, string db)
        {
            if (EntidadesExactusDL.SiExistePedidoDL(ped, db))
                return true;
            else
                return false;
        }

        public static bool SiExisteOrdenBL(string ord, string db)
        {
            if (EntidadesExactusDL.SiExisteOrdenDL(ord, db))
                return true;
            else
                return false;
        }

        public DataTable dtListarMotivoAnulaOS_BL(string db)
        {
            return objEntidadesExactusBL.dtListarMotivoAnulaOS_DL(db);
        }

        public DataTable dtListarPedidoCreditoBL(string tipodoc, DateTime fecha1, DateTime fecha2, string condic, string zona, string cliente, string db)
        {
            return objEntidadesExactusBL.dtListarPedidoCreditoDL(tipodoc, fecha1, fecha2, condic, zona, cliente, db);
        }

        public DataTable dtListarUsuarioBodegaBL(string vusuario, string db)
        {
            return objEntidadesExactusBL.dtListarUsuarioBodegaDL(vusuario, db);
        }

        public DataTable dtListarUsuarioZonaBL(string vusuario, string db)
        {
            return objEntidadesExactusBL.dtListarUsuarioZonaDL(vusuario, db);
        }

        public DataTable dtListarUsuarioCajaBL(string vusuario, string db)
        {
            return objEntidadesExactusBL.dtListarUsuarioCajaDL(vusuario, db);
        }

        public DataTable dtListarUsuariosBL(string db)
        {
            return objEntidadesExactusBL.dtListarUsuariosDL(db);
        }

        public DataTable dtListarTecnicosBL(string db)
        {
            return objEntidadesExactusBL.dtListarTecnicosDL(db);
        }

        public DataTable dtListarGrupoBL(string db)
        {
            return objEntidadesExactusBL.dtListarGruposDL(db);
        }

        public DataTable dtListarUsuarioPorGruposBL(string grupo, string db)
        {
            return objEntidadesExactusBL.dtListarUsuarioPorGruposDL(grupo, db);
        }

        public DataTable dtBuscarClienteBL(string codigo, string nombre, string db)
        {
            return objEntidadesExactusBL.dtBuscarClienteDL(codigo, nombre, db);
        }


        public DataTable dtBuscarEmpleadoBL(string codigo, string nombre, string db)
        {
            return objEntidadesExactusBL.dtBuscarEmpleadoDL(codigo, nombre, db);
        }
    }

    public static class Usuario_ReporteBL
    {

        public static void UpdateConfiguracionUsuarioBL(string cTabla, string cAccion, string cUsuario, string cCampo, string db)
        {
            Usuario_ReporteDL.UpdateConfiguracionUsuarioDL(cTabla, cAccion, cUsuario, cCampo, db);
        }

        public static void GrabarUsuarioReporteBL(string cUnidad, string cGrupo, string cCaja, string cZona, string cBodega, string cClave_reporte, string cUsuario, string db)
        {
            Usuario_ReporteDL.GrabarUsuarioReporteDL(cUnidad, cGrupo, cCaja, cZona, cBodega, cClave_reporte, cUsuario, db);
        }

        public static List<Usuario_ReporteBE> ObtenerTodos(string db)
        {
            return Usuario_ReporteDL.ObtenerTodos(db);
        }

        public static Usuario_ReporteBE BuscarPor(string usuario, string db)
        {
            return Usuario_ReporteDL.BuscarPor(usuario, db);
        }

        public static Usuario_ReporteBE Grabar(Usuario_ReporteBE usuario_reporte, string db)
        {

            if (Usuario_ReporteDL.SiExiste(usuario_reporte.usuario, db))
                return Usuario_ReporteDL.Actualizar(usuario_reporte, db);
            else
                return Usuario_ReporteDL.Agregar(usuario_reporte, db);

        }

    }

    public class VendedorBL
    {
        ApssaExactus.VendedorDL objVendedorBL = new ApssaExactus.VendedorDL();
        public DataTable dtListarVendedorBL(string db)
        {
            return objVendedorBL.dtListarVendedorDL(db);
        }
    }

    public class AccesoGeneralBL
    {

        public static DataSet CargaExcel(string RutaExcelBL, string NombreHojaBL)
        {
            try
            {
                DataSet ds_le = new DataSet();
                ds_le = AccesoGeneralDL.CargaExcel(RutaExcelBL, NombreHojaBL);
                ds_le.Tables[0].TableName = "listaexcel";
                return ds_le;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }

        }

        public static DataSet Listar_Usuario_Caja(string user, string db)
        {
            try
            {
                DataSet ds_lu = new DataSet();
                ds_lu = Usuario_ReporteDL.Listar_Usuario_Caja(user, db);
                ds_lu.Tables[0].TableName = "lu";
                return ds_lu;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }

        }
        //Listar_Usuario_Bodega
        public static DataSet Listar_Usuario_Bodega(string user, string db)
        {
            try
            {
                DataSet ds_lub = new DataSet();
                ds_lub = Usuario_ReporteDL.Listar_Usuario_Bodega(user, db);
                ds_lub.Tables[0].TableName = "lub";
                return ds_lub;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }

        }

        public static DataSet Listar_Usuario_Zona(string user, string db)
        {
            try
            {
                DataSet ds_zon = new DataSet();
                ds_zon = Usuario_ReporteDL.Listar_Usuario_Zona(user, db);
                ds_zon.Tables[0].TableName = "luz";
                return ds_zon;
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }

        }




    }




}
