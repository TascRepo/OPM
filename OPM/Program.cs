using OPM.GUI;
using System;
using System.Windows.Forms;

namespace OPM
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new OPMDASHBOARDA());
            //Application.Run(new SiteForm());
            //Application.Run(new TestTableForm());
            //Application.Run(new Contract_Goods_Form());

        }
    }
}
