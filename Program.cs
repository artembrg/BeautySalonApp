using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeautySalon
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            /*using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Select * from EmployeesID", connection);
                DataSet ds = new DataSet();
                sqlDataAdapter.Fill(ds, "EmployeesID");
                DataTable EmplID = ds.Tables["EmployeesID"];
                foreach (DataRow dr in EmplID.Rows)
                {
                    var IDFIO = dr.ItemArray;
                    servChoiceInput.Items.Add(IDFIO[0] + ". " + IDFIO[1]);
                }
            }*/
        }
    }
}
