using BanglaProject.WindowsForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BanglaProject
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
            Application.Run(new FormLogin());
            //Application.Run(new FormAdminView());
            //Application.Run(new FormAddUser());
            //Application.Run(new FormEditUser());
            //Application.Run(new FormAddProduct());
            //Application.Run(new FormEmployee());
            //Application.Run(new FormUpdateProduct());
            //Application.Run(new FormManageProducts());
            //Application.Run(new FormAddSales());
            //Application.Run(new FromSalesReport());
        }
    }
}
