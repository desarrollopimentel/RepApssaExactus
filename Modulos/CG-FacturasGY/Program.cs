using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApssaExactus
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            //Application.Run(new frmLoginUsuario());
            //frmEstadoCuentaClienteExactus.cs
            //Application.Run(new frmEstadoCuentaClienteExactus());

            string[] arguments = Environment.GetCommandLineArgs();

            string _base = "";
            string _user = "";

            for (int i = 0; i < arguments.Length; i++)
            {
                //Console.WriteLine("{0}: [{1}]", i, arguments[i]);

                switch (i)
                {
                    case 0:
                        //Executable
                        break;
                    case 1:
                        _base = arguments[1];          // "PIMENTEL";    // txtBaseDatos.Text
                        break;
                    case 2:
                        _user = arguments[2];          // "MCABANILLASS";   // txtUsuario.Text;
                        break;
                    default:
                        //Statement
                        break;
                }


            }

            //PRODUCCION
            //Application.Run(new frm_ObtenerGRE(_base, _user));  //v2 OKOK
            //Application.Run(new frm_FacturasSinCargos(_base, _user));   // OKOK
            Application.Run(new frmCargaFacturaGYv2025(_base, _user));   // OKOK

            //DESARROLLO
            //Application.Run(new frmCargaFacturaGYv2025("TESTING", "MCABANILLASS"));
            //Application.Run(new frmCargaFacturaGYv2025("PIMENTEL", "MCABANILLASS"));
        }
    }

}
