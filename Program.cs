using System;
using BaiTap_CShap.DAO;
using System.Windows.Forms;

namespace BaiTap_CShap
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new TrangChu());
        }
    }
}
