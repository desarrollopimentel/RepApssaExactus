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
            //Application.Run(new frmEstadoCuentaClienteExactus());

            string[] arguments = Environment.GetCommandLineArgs();

            string _base = "";
            string _user = "";
            string _pass = "";

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
                    case 3:
                        _pass = arguments[3];           // "12345";         // txtPassword.T
                        break;
                    default:
                        //Statement
                        break;
                }


            }

            //PRODUCCION
            Application.Run(new frmSaldoClientesSegunFecha(_base, _user));   // OKOK
            //DESARROLLO
            //Application.Run(new frmEstadoCuentaClientev2023("PIMENTEL", "MCABANILLASS"));   // OKOK
            //Application.Run(new frmSaldoClientesSegunFecha("PIMENTEL", "MCABANILLASS"));   // OKOK

            

        }
    }
}
