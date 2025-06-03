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
            //Application.Run(new frm_PrivilegiosTesoreria(_base, _user));   // OKOK
            Application.Run(new frm_PrivilegiosTesoreria_v2(_base, _user));  //v2 OKOK
            //DESARROLLO
            //Application.Run(new frm_PrivilegiosTesoreria("PIMENTEL", "MCABANILLASS"));
            //Application.Run(new frm_PrivilegiosTesoreria2("TESTING", "MCABANILLASS"));
            //Application.Run(new frm_PrivilegiosTesoreria_v2("PIMENTEL", "MCABANILLASS"));
            //Application.Run(new XtraForm1());
        }
    }

}
