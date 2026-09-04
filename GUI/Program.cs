using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    internal static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            using (FormLogin login = new FormLogin())
            {
                if (login.ShowDialog() == DialogResult.OK)
                {
                    Application.Run(new Form1());
                }
            }
        }
    }
}
