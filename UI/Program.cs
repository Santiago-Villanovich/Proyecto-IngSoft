using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;

namespace UI
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            BLL_DigitoVerificador verificadorDV = new BLL_DigitoVerificador();
            /*if (verificadorDV.VerificarEstadoTabla(new BLL_User().GetAll(), "Users"))
            {
                Application.Run(new LogIn());
            }
            else
            {
                Application.Run(new CorruptedDataBase());
            }*/

            Application.Run(new LogIn());

        }
    }
}
