using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;
//using Microsoft.Reporting.WinForms;
using DevExpress.XtraGrid;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.Utils;
using DevExpress.XtraGrid.Views.Base;   // FORMATOS
using DevExpress.XtraGrid.Views.Grid;
//using Exactus.BL;
//using Exactus.BE;
using DevExpress.XtraGrid.Controls;
using System.Reflection;

namespace ApssaExactus
{
    public partial class frmBusca_Articulo : DevExpress.XtraEditors.XtraForm
    {
        public string familia = string.Empty;
        public string subfamilia = string.Empty;
        public string grupo = string.Empty;
        public string _primeravez = "SI";

        public string _articulo = string.Empty;
        public string _descripcion = string.Empty;
        public string _unidad = string.Empty;


        CargaLookUpBL objCargaLookUpBL = new CargaLookUpBL();        
        
        public frmBusca_Articulo()
        {
            InitializeComponent();
        }

 
        /// ----------------------------------------------------------------------------
        /// Crea una instancia unica del Formulario		
        private static frmBusca_Articulo m_FormDefInstance;

        /// Instancia por defecto
        public static frmBusca_Articulo DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new frmBusca_Articulo();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }
        /// ----------------------------------------------------------------------------


        private void frmBusca_Articulo_Load(object sender, EventArgs e)
        {
            // inicializo             
            _primeravez = "SI";         
            
            Carga_lookUp_Familia();
            Carga_lookUp_SubFamilia();
            Carga_lookUp_Grupo();
            CargaPreferenciaArticulo();
            ObtenerArticulosPreferencia();      // ObtenerArticulos();
            _primeravez = "NO";    
        }

        private void btnActualizaVersionNivel_Click(object sender, EventArgs e)
        {
            ObtenerArticulos();
        }

        public void ObtenerArticulos()
        {
            
            familia = this.lookUpEditFamilia.EditValue.ToString();

            if (!DBNull.Value.Equals(this.lookUpEditSubFamilia.EditValue))
                subfamilia = this.lookUpEditSubFamilia.EditValue.ToString();
            else
                subfamilia = String.Empty;

            if (!DBNull.Value.Equals(this.lookUpEditGrupo.EditValue))
                grupo = this.lookUpEditGrupo.EditValue.ToString();
            else
                grupo = String.Empty;
            
            using (WaitDialogForm waitDialog = new WaitDialogForm("Procesando Información....", "Espere por favor.."))
            {
                DataTable dtArt = new DataTable();
                //dtObtenerArticulosBL(string fami, string subf, string grup, string cdb)
                dtArt = ComercialBL.dtObtenerArticulosBL(familia, subfamilia, grupo, Global.vUserBaseDatos);
                gcArticulo.DataSource = dtArt;
            }

            ConfiguraGridArticulo();
            gcArticulo.Refresh();
        }

        public void ObtenerArticulosPreferencia()
        {
            CargaPreferenciaArticulo();

            using (WaitDialogForm waitDialog = new WaitDialogForm("Procesando Información....", "Espere por favor.."))
            {
                DataTable dtArt = new DataTable();
                //dtObtenerArticulosBL(string fami, string subf, string grup, string cdb)
                dtArt = ComercialBL.dtObtenerArticulosBL(familia, subfamilia, grupo, Global.vUserBaseDatos);
                gcArticulo.DataSource = dtArt;
            }

            ConfiguraGridArticulo();
            gcArticulo.Refresh();
        }


        private void lookUpEditFamilia_EditValueChanged(object sender, EventArgs e)
        {
            if (_primeravez == "NO")
            {
                if (this.lookUpEditFamilia.EditValue.ToString() != "")
                {
                    Carga_lookUp_GrupoFiltro(this.lookUpEditFamilia.EditValue.ToString());
                }
            }            
            
            //if ((_primeravez != "SI") && (this.lookUpEditFamilia.EditValue.ToString() != ""))
            //{
            //    Carga_lookUp_SubFamiliaFiltro(this.lookUpEditFamilia.EditValue.ToString());
            //}
        }

        private void lookUpEditSubFamilia_EditValueChanged(object sender, EventArgs e)
        {
            if (_primeravez == "NO")
            {
                if (this.lookUpEditSubFamilia.EditValue.ToString() != "")
                {
                    Carga_lookUp_GrupoFiltro(this.lookUpEditSubFamilia.EditValue.ToString());
                }
            }
        }

        public void ConfiguraGridArticulo()
        {
            gvArticulo.OptionsView.ColumnAutoWidth = true;
            Font fnt = new Font(gvArticulo.Appearance.Row.Font.Name, 7);
            gvArticulo.Appearance.HeaderPanel.Font = fnt;
            gvArticulo.Appearance.Row.Font = fnt;
            gvArticulo.Appearance.Row.Options.UseFont = true;
            gvArticulo.OptionsView.ShowGroupPanel = false;
            gvArticulo.OptionsView.ShowIndicator = false;
            gvArticulo.OptionsBehavior.Editable = false;
            gvArticulo.OptionsSelection.EnableAppearanceFocusedCell = false;

            // COLOR
            gvArticulo.Columns["ARTICULO"].AppearanceCell.BackColor = Color.Azure;
            gvArticulo.Columns["DESCRIPCION"].AppearanceCell.BackColor = Color.Azure;

        }


        public void Carga_lookUp_Familia()
        {
            DataTable dtFamilia = new DataTable();
            dtFamilia = objCargaLookUpBL.dtListarFamiliaBL(Global.vUserBaseDatos);
            lookUpEditFamilia.Properties.DataSource = dtFamilia;
            lookUpEditFamilia.Properties.DisplayMember = "DESCRIPCION";
            lookUpEditFamilia.Properties.ValueMember = "CLASIFICACION";
            lookUpEditFamilia.EditValue = null;
        }

        public void Carga_lookUp_SubFamilia()
        {
            DataTable dtSubFamilia = new DataTable();
            dtSubFamilia = objCargaLookUpBL.dtListarSubFamiliaBL(Global.vUserBaseDatos);
            lookUpEditSubFamilia.Properties.DataSource = dtSubFamilia;
            lookUpEditSubFamilia.Properties.DisplayMember = "DESCRIPCION";
            lookUpEditSubFamilia.Properties.ValueMember = "CLASIFICACION";
            lookUpEditSubFamilia.EditValue = null;
        }

        public void Carga_lookUp_Grupo()
        {
            DataTable dtGrupo = new DataTable();
            dtGrupo = objCargaLookUpBL.dtListarGrupoBL(Global.vUserBaseDatos);
            lookUpEditGrupo.Properties.DataSource = dtGrupo;
            lookUpEditGrupo.Properties.DisplayMember = "DESCRIPCION";
            lookUpEditGrupo.Properties.ValueMember = "CLASIFICACION";
            lookUpEditGrupo.EditValue = null;
        }

        public void Carga_lookUp_SubFamiliaFiltro(string cfamilia)
        {
            if (cfamilia != "")
            {
                DataTable dtSubFamilia = new DataTable();
                dtSubFamilia = objCargaLookUpBL.dtListarSubFamiliaFiltro2BL(cfamilia, Global.vUserBaseDatos);
                lookUpEditSubFamilia.Properties.DataSource = dtSubFamilia;
                lookUpEditSubFamilia.Properties.DisplayMember = "DESCRIPCION";
                lookUpEditSubFamilia.Properties.ValueMember = "CLASIFICACION";
                lookUpEditSubFamilia.EditValue = null;
            }
        }

        public void Carga_lookUp_GrupoFiltro(string csubfamilia)
        {
            if (csubfamilia != "")
            {
                DataTable dtGrupo = new DataTable();
                dtGrupo = objCargaLookUpBL.dtListarGrupoFiltro2BL(csubfamilia, Global.vUserBaseDatos);
                lookUpEditGrupo.Properties.DataSource = dtGrupo;
                lookUpEditGrupo.Properties.DisplayMember = "DESCRIPCION";
                lookUpEditGrupo.Properties.ValueMember = "CLASIFICACION";
                lookUpEditGrupo.EditValue = null;
            }
        }

        private void gvArticulo_FocusedRowChanged(object sender, FocusedRowChangedEventArgs e)
        {
            _articulo = gvArticulo.GetRowCellValue(gvArticulo.FocusedRowHandle, "ARTICULO").ToString();
            _descripcion = gvArticulo.GetRowCellValue(gvArticulo.FocusedRowHandle, "DESCRIPCION").ToString();
            _unidad = gvArticulo.GetRowCellValue(gvArticulo.FocusedRowHandle, "UNIDAD_ALMACEN").ToString();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Boolean TodoOK = true;

            if (TodoOK == false)
            {
                MessageBox.Show("Existe Información Errónea.", "Carga Cuota Ventas");
                return;
            }
            else
            {
                try
                {
                    //AlmacenaDatoCuotaVenta();
                    //MessageBox.Show("Se Guardo Correctamente la Información.", "Carga Cuota Ventas");
                    //this.Close();
                    this.DialogResult = DialogResult.OK;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void btnFiltarFamilia_Click(object sender, EventArgs e)
        {
            CargaPreferenciaArticulo();
        }

        public void CargaPreferenciaArticulo()
        {
            //lookUpEditFamilia.EditValue = "AC, AR, BA, CA, EP, FI, FO, HE, LA, LL, MI, PR, PU, RA, RE, SG, SO, TA, UL, UO, VA";
            lookUpEditFamilia.EditValue = "AR, BA, CA, FI, HE, LA, LL, PR, RA, RE, SO, TA";


            lookUpEditSubFamilia.EditValue =
            @"AC-028, AC-150, AC-151, AC-171, AC-795, AR-194, AR-195, AR-222, BA-087, BA-186, BA-187, BA-188, BA-189, BA-190, BA-191,
             BA-192, BA-193, BA-208, BA-209, BA-214, BA-215, BA-498, CA-001, CA-002, CA-003, CA-004, CA-006, CA-007, CA-008, CA-009,
             CA-010, CA-011, CA-012, EP-015, EP-050, EP-071, EP-072, EP-073, EP-074, EP-075, EP-076, EP-077, EP-078, EP-079, EP-080,
             EP-081, EP-082, EP-083, EP-084, EP-085, EP-086, EP-088, EP-089, EP-090, EP-091, EP-092, EP-093, EP-094, EP-095, EP-097,
             EP-098, EP-099, EP-100, EP-101, EP-221, EP-499, FI-038, FI-039, FI-110, FI-113, FI-168, FI-169, FI-213, FO-059, FO-172,
             FO-173, FO-174, FO-175, FO-176, FO-177, FO-178, FO-179, FO-180, FO-181, FO-182, FO-183, FO-184, FO-185, FO-211, FO-219,
             HE-150, LA-061, LA-062, LL-001, LL-002, LL-003, LL-004, LL-005, LL-006, LL-007, LL-008, LL-009, LL-010, LL-011, LL-012,
             MI-054, MI-065, MI-066, MI-067, MI-068, MI-069, MI-103, MI-104, MI-105, MI-115, MI-151, MI-206, PR-003, PR-004, PR-006,
             PR-007, PR-008, PR-009, PR-010, PR-011, PR-012, PU-059, PU-063, PU-154, PU-155, PU-156, PU-157, PU-158, PU-159, PU-160,
             PU-161, PU-162, PU-163, PU-165, PU-166, PU-212, RA-016, RA-017, RA-018, RA-019, RA-020, RA-022, RA-023, RA-024, RA-025,
             RA-026, RA-027, RA-028, RA-029, RA-030, RA-031, RA-032, RA-033, RA-205, RE-013, RE-014, RE-096, RE-164, RE-196, RE-197,
             RE-198, RE-199, RE-200, RE-201, RE-202, RE-203, SG-ALB, SG-ALQ, SG-AYD, SG-EQU, SG-FAB, SG-INS, SG-LOC, SG-MAC, SG-MAP,
             SG-MEL, SG-MUE, SG-SAN, SG-SYS, SG-TAL, SG-TRA, SG-VAR, SO-034, SO-035, SO-036, SO-037, SO-040, SO-041, SO-042, SO-043,
             SO-045, SO-046, SO-047, SO-048, SO-049, SO-050, SO-051, SO-052, SO-053, SO-054, SO-055, SO-056, SO-058, SO-166, SO-204,
             SO-207, SO-501, TA-AFI, TA-CAR, TA-DIA, TA-DIR, TA-ELE, TA-ENF, TA-ENG, TA-FRE, TA-GRA, TA-LAV, TA-LUB, TA-MOT, TA-REF,
             TA-RES, TA-REV, TA-SEL, TA-SNR, TA-SUS, TA-TER, TA-TRA, TA-UND, UL-152, UL-153, UL-167, UO-041, UO-046, UO-053, UO-056,
             UO-064, UO-103, UO-104, UO-105, UO-106, UO-107, UO-108, UO-109, UO-111, UO-112, UO-114, UO-115, UO-116, UO-117, UO-118,
             UO-119, UO-120, UO-121, UO-122, UO-123, UO-124, UO-125, UO-126, UO-127, UO-128, UO-129, UO-131, UO-132, UO-133, UO-134,
             UO-135, UO-136, UO-137, UO-138, UO-139, UO-140, UO-141, UO-142, UO-143, UO-144, UO-145, UO-146, UO-147, UO-148, UO-149,
             UO-209, UO-216, UO-217, UO-218, UO-220, VA-000";



            lookUpEditGrupo.EditValue =
            @"AC-028570, AC-150275, AC-150305, AC-150306, AC-150307, AC-150314, AC-150315, AC-150316, AC-150317, AC-150547, AC-150548, 
            AC-150549, AC-150587, AC-150605, AC-150607, AC-150636, AC-150637, AC-151322, AC-151323, AC-151327, AC-151328, AC-151329, 
            AC-151556, AC-151557, AC-151581, AC-171344, AC-171563, AC-171576, AC-171619, AC-795642, AC-795644, AR-194000, AR-194356, 
            AR-194357, AR-194358, AR-194359, AR-194360, AR-194361, AR-194362, AR-194366, AR-195356, AR-195358, AR-195360, AR-195362, 
            AR-195366, AR-195387, AR-195417, AR-195425, AR-195464, AR-195465, AR-195466, AR-195467, AR-195468, AR-195469, AR-195470, 
            AR-195471, AR-195472, AR-195473, AR-195474, AR-195475, AR-195476, AR-195495, AR-222000, BA-087354, BA-186354, BA-186397, 
            BA-187367, BA-188354, BA-188368, BA-188388, BA-188397, BA-188479, BA-188494, BA-189435, BA-189436, BA-189437, BA-189438, 
            BA-189439, BA-189451, BA-189452, BA-189453, BA-189454, BA-189455, BA-189456, BA-189457, BA-189458, BA-189459, BA-189460, 
            BA-189461, BA-189462, BA-189463, BA-190354, BA-190369, BA-190371, BA-190390, BA-190397, BA-190479, BA-191354, BA-191363, 
            BA-191364, BA-191365, BA-191370, BA-191371, BA-191372, BA-191389, BA-191397, BA-191479, BA-192354, BA-193355, BA-208354, 
            BA-209354, BA-214354, BA-215354, BA-498354, BA-498479, CA-001123, CA-002000, CA-003000, CA-004000, CA-006039, CA-006115, 
            CA-006401, CA-007057, CA-007123, CA-008000, CA-009000, CA-010000, CA-011000, CA-012039, CA-012401, EP-015212, EP-050384, 
            EP-050517, EP-071038, EP-071199, EP-071200, EP-072000, EP-072201, EP-072202, EP-072203, EP-072304, EP-072523, EP-073204, 
            EP-074111, EP-074205, EP-074206, EP-075207, EP-075208, EP-076209, EP-076382, EP-077204, EP-078000, EP-078214, EP-078215, 
            EP-078380, EP-078398, EP-079000, EP-080209, EP-080382, EP-081209, EP-081382, EP-082000, EP-083000, EP-084000, EP-085000, 
            EP-086209, EP-086210, EP-088212, EP-088213, EP-088374, EP-089213, EP-090211, EP-090353, EP-090374, EP-090378, EP-090500, 
            EP-091000, EP-091210, EP-092000, EP-092522, EP-093000, EP-093500, EP-094518, EP-095126, EP-095519, EP-097000, EP-098072, 
            EP-098374, EP-098520, EP-098521, EP-099153, EP-099521, EP-100072, EP-100374, EP-100520, EP-100521, EP-101153, EP-101521, 
            EP-101524, EP-221629, EP-499212, FI-038000, FI-038426, FI-038427, FI-038476, FI-038477, FI-038478, FI-038480, FI-038481, 
            FI-038565, FI-039000, FI-039101, FI-039312, FI-039423, FI-039424, FI-039426, FI-039427, FI-039428, FI-039480, FI-110000, 
            FI-110565, FI-113000, FI-168000, FI-168427, FI-168481, FI-169000, FI-169423, FI-169427, FI-213000, FO-059000, FO-172033, 
            FO-173033, FO-174033, FO-175345, FO-176000, FO-177033, FO-178346, FO-179033, FO-179347, FO-179348, FO-180106, FO-181349, 
            FO-182033, FO-183033, FO-183350, FO-184033, FO-184351, FO-185352, FO-211000, FO-211033, FO-219033, HE-150000, HE-150011, 
            HE-150027, HE-150074, HE-150119, HE-150138, HE-150169, HE-150179, HE-150230, HE-150247, HE-150248, HE-150249, HE-150250, 
            HE-150252, HE-150253, HE-150255, HE-150256, HE-150257, HE-150258, HE-150260, HE-150261, HE-150264, HE-150265, HE-150266, 
            HE-150268, HE-150269, HE-150270, HE-150271, HE-150272, HE-150274, HE-150275, HE-150312, HE-150315, HE-150317, HE-150379, 
            HE-150414, HE-150540, HE-150547, HE-150558, HE-150562, HE-150572, HE-150579, HE-150583, HE-150584, HE-150588, HE-150602, 
            HE-150606, HE-150609, HE-150612, HE-150613, HE-150621, HE-150622, HE-150623, HE-150630, HE-150636, HE-150638, HE-150641, 
            HE-150755, LA-061095, LA-061096, LA-061097, LA-061160, LA-061161, LA-061162, LA-061163, LA-061164, LA-061165, LA-061170, 
            LA-061434, LA-061492, LA-061493, LA-061531, LA-061758, LA-062000, LA-062066, LA-062096, LA-062125, LA-062167, LA-062170, 
            LA-062171, LA-062172, LA-062173, LA-062174, LA-062175, LA-062176, LA-062431, LA-062432, LA-062433, LA-062435, LL-001057, 
            LL-001089, LL-001123, LL-002022, LL-002029, LL-002041, LL-003000, LL-003029, LL-003090, LL-004000, LL-004075, LL-004385, 
            LL-004386, LL-004392, LL-004418, LL-005095, LL-006039, LL-006067, LL-006115, LL-006399, LL-006401, LL-007000, LL-007057, 
            LL-007088, LL-007089, LL-007090, LL-007123, LL-008090, LL-009029, LL-009090, LL-010029, LL-010090, LL-011000, LL-012000, 
            LL-012039, LL-012399, LL-012401, LL-012429, MI-054546, MI-065000, MI-065177, MI-065289, MI-065490, MI-065496, MI-065497, 
            MI-065578, MI-066000, MI-066001, MI-066014, MI-066016, MI-066062, MI-066086, MI-066130, MI-066403, MI-066420, MI-067000, 
            MI-067108, MI-067525, MI-067526, MI-068028, MI-068042, MI-068046, MI-068052, MI-068120, MI-068178, MI-068179, MI-068180, 
            MI-068181, MI-068183, MI-068184, MI-068185, MI-068186, MI-068187, MI-068188, MI-068189, MI-068190, MI-068191, MI-068192, 
            MI-068193, MI-068194, MI-068195, MI-068196, MI-068297, MI-068302, MI-068500, MI-068501, MI-068502, MI-068503, MI-068504, 
            MI-068505, MI-068506, MI-068507, MI-068508, MI-068615, MI-069197, MI-103156, MI-103262, MI-104218, MI-104221, MI-104223, 
            MI-104564, MI-104567, MI-104568, MI-104573, MI-104639, MI-105225, MI-115000, MI-151557, MI-206008, MI-206254, PR-003000, 
            PR-004000, PR-006000, PR-007000, PR-008000, PR-009000, PR-010000, PR-011000";

        }

        //private void frmBusca_Articulo_Shown(object sender, EventArgs e)
        //{
        //    PropertyInfo property = typeof(GridView).GetProperty("FindPanel", BindingFlags.Instance | BindingFlags.NonPublic);

        //    //FindControl findPanel = property.GetValue(gvArticulo) as FindControl;
        //    //findPanel.Focus();
        //    FindControl fp = property.GetValue(gvArticulo,object[0]) as FindControl;
        //    fp.Focus();
        //}






    }
}