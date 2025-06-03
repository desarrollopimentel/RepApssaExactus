using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Excel = Microsoft.Office.Interop.Excel;

//using DevExpress.Utils;
//using DevExpress.Data;
//using DevExpress.XtraEditors;
//using DevExpress.XtraGrid;
//using DevExpress.XtraGrid.Views.Grid;

namespace ApssaExactus.LIBCS
{
    public class GeneralLibCS
    {

        public static bool ConfirmarSiNo(string mensaje,string titulo)
        {
            DialogResult x;
            x = MessageBox.Show(mensaje, titulo, MessageBoxButtons.YesNo, MessageBoxIcon.Question); 
            if (x==DialogResult.No)
                return false; 
            else 
                return true;             
        }

        public static string UserName()
        {
            return SystemInformation.UserName;
        }

        public static string UserDomainName()
        {
            return SystemInformation.UserDomainName;
        }


        //public void Exporta2Excel(DevExpress.XtraGrid.Views.Grid.GridView GridView2Xls, string ArchivoExcel) //ImprimeExcel(DataGridView GridView2Xls)
        //{
        //    if (GridView2Xls.RowCount <= 0)
        //    {
        //        MessageBox.Show("No existe informacion a procesar");
        //        return;
        //    }
        //    else
        //    {
        //        try
        //        {
        //            //exporta a excel
        //            GridView2Xls.ExportToXlsx(ArchivoExcel);
        //            //abre el archivo
        //            Excel.Application ExcelApp = new Excel.Application();
        //            Excel.Workbook ExcelWorkbook = default(Excel.Workbook);
        //            ExcelWorkbook = ExcelApp.Workbooks.Open(Filename: ArchivoExcel);
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message);
        //        }
        //    }
        //}



        public static string Left(string text, int length)
        {
            return text.Substring(0, length);
        }

        public static string Right(string text, int length)
        {
            return text.Substring(text.Length - length, length);
        }


        public static string Mid(string text, int start, int end)
        {
            return text.Substring(start, end);
        }

        public static string Mid(string text, int start)
        {
            return text.Substring(start, text.Length - start);
        }

        public static int ContarOcurrenciasEnString(string textString, string textFind)
        {
            // Loop through all instances of the string 'text'.
            int count = 0;
            int i = 0;
            while ((i = textString.IndexOf(textFind, i)) != -1)
            {
                i += textFind.Length;
                count++;
            }
            return count;
        }

        public static string BuscaCaracterEnString(Char target, String searched)
        {
            string cMensaje = string.Empty;

            int startIndex = -1;
            int hitCount = 0;

            while (true)
            {
                startIndex = searched.IndexOf(
                    target, startIndex + 1,
                    searched.Length - startIndex - 1);

                if (startIndex < 0)
                    break;

                cMensaje = cMensaje + startIndex.ToString() + ",";

                hitCount++;
            }

            cMensaje = hitCount.ToString() + "," + cMensaje;  // devuelve numero que veces que ocurre y las posisiones
            int last = cMensaje.LastIndexOf(",");             // quita la ultima coma
            cMensaje = cMensaje.Remove(last, 1);
            return cMensaje;
        }


        public static string BuscaStringEnString(String target, String searched)
        {
            string cMensaje = string.Empty;

            int startIndex = -1;
            int hitCount = 0;

            while (true)
            {
                startIndex = searched.IndexOf(
                    target, startIndex + 1,
                    searched.Length - startIndex - 1);

                if (startIndex < 0)
                    break;

                cMensaje = cMensaje + startIndex.ToString() + ",";

                hitCount++;
            }

            cMensaje = hitCount.ToString() + "," + cMensaje;  // devuelve numero que veces que ocurre y las posisiones


            int last = cMensaje.LastIndexOf(",");             // quita la ultima coma
            cMensaje = cMensaje.Remove(last, 1);
            return cMensaje;
        }

        public static DateTime DevuelveFechasIniFinMesSegunFechaProceso(DateTime fecha_proceso, string inicio_fin)
        {
            DateTime? fechatemp = null;

            fechatemp = fecha_proceso;  // DateTime.Today;

            switch (inicio_fin.ToUpper())
            {
                case "INICIO":
                    return new DateTime(fechatemp.Value.Year, fechatemp.Value.Month, 1);
                case "FIN":
                    return new DateTime(fechatemp.Value.Year, fechatemp.Value.Month + 1, 1).AddDays(-1);
                default:
                    return fecha_proceso;
            }

        }

        public static DateTime DevuelveFechasIniFinMesSegunNumeroMes(int mes_numero, int ano_numero, string inicio_fin)
        {
            //DateTime? fechatemp = null;

            DateTime fechatemp = DateTime.Today;

            switch (inicio_fin.ToUpper())
            {
                case "INICIO":
                    //return new DateTime(fechatemp.Value.Year, fechatemp.Value.Month, 1);
                    return new DateTime(ano_numero, mes_numero, 1);
                case "FIN":
                    //return new DateTime(fechatemp.Value.Year, fechatemp.Value.Month + 1, 1).AddDays(-1);
                    return new DateTime(ano_numero, mes_numero + 1, 1).AddDays(-1);
                default:
                    return fechatemp;
            }

        }

        public static string DevuelveNombreMes(int mes_numero)
        {
            switch (mes_numero)
            {
                case 1:
                    return "ENERO";
                case 2:
                    return "FEBRERO";
                case 3:
                    return "MARZO";
                case 4:
                    return "ABRIL";
                case 5:
                    return "MAYO";
                case 6:
                    return "JUNIO";
                case 7:
                    return "JULIO";
                case 8:
                    return "AGOSTO";
                case 9:
                    return "SEPTIEMBRE";
                case 10:
                    return "OCTUBRE";
                case 11:
                    return "NOVIEMBRE";
                case 12:
                    return "DICIEMBRE";
                default:
                    return "";
            }
        }


        public static int DevuelveMesEnNumero(String mes_texto)
        {
            switch (mes_texto.ToUpper())
            {
                case "ENERO":
                    return 1;
                case "FEBRERO":
                    return 2;
                case "MARZO":
                    return 3;
                case "ABRIL":
                    return 4;
                case "MAYO":
                    return 5;
                case "JUNIO":
                    return 6;
                case "JULIO":
                    return 7;
                case "AGOSTO":
                    return 8;
                case "SEPTIEMBRE":
                    return 9;
                case "OCTUBRE":
                    return 10;
                case "NOVIEMBRE":
                    return 11;
                case "DICIEMBRE":
                    return 12;
                case "JANUARY":
                    return 1;
                case "FEBRUARY":
                    return 2;
                case "MARCH":
                    return 3;
                case "APRIL":
                    return 4;
                case "MAY":
                    return 5;
                case "JUNE":
                    return 6;
                case "JULY":
                    return 7;
                case "AUGUST":
                    return 8;
                case "SEPTEMBER":
                    return 9;
                case "OCTOBER":
                    return 10;
                case "NOVEMBER":
                    return 11;
                case "DECEMBER":
                    return 12;
                default:
                    return 0;
            }


        }




    }
}
