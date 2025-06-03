using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;

namespace ApssaExactus
{
    public partial class frmArticulosExplorador : DevExpress.XtraBars.Ribbon.RibbonForm
    {

        // CARGA_ENTORNO_VARIABLES
        public Int32 NumIntentos = 1;
        public string _base_datos = null;
        public string _usuario = null;


        public frmArticulosExplorador(string _base, string _user)
        {
            InitializeComponent();

            _base_datos = _base;    // txtBaseDatos.Text
            _usuario = _user;       // txtUsuario.Text;

        }

        /// ----------------------------------------------------------------------------
        /// Crea una instancia unica del Formulario		
        private static frmArticulosExplorador m_FormDefInstance;
        private static string _base;
        private static string _user;
        //private static string _pass;

        /// Instancia por defecto
        public static frmArticulosExplorador DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new frmArticulosExplorador(_base, _user);
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }
        /// ----------------------------------------------------------------------------
        /// 




    }
}