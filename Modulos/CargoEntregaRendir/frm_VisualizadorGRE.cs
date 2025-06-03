using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ApssaExactus
{
    public partial class frm_VisualizadorGRE : Form
    {
        public string path;
        public frm_VisualizadorGRE()
        {
            InitializeComponent();
        }


        /// ----------------------------------------------------------------------------
        /// Crea una instancia unica del Formulario		
        private static frm_VisualizadorGRE m_FormDefInstance;

        /// Instancia por defecto
        public static frm_VisualizadorGRE DefInstance
        {
            get
            {
                if (m_FormDefInstance == null || m_FormDefInstance.IsDisposed)
                    m_FormDefInstance = new frm_VisualizadorGRE();
                return m_FormDefInstance;
            }
            set
            {
                m_FormDefInstance = value;
            }
        }
        /// ----------------------------------------------------------------------------


        private void frm_VisualizadorGRE_Load(object sender, EventArgs e)
        {
            PDF.src = path;
            
        }
    }
}
