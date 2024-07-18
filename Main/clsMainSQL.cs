using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DummyWPF.Main
{
    public class clsMainSQL
    {

        /// <summary>
        /// Get all invoices from the database
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string GetAllInvoice()
        {
            try
            {
                string sSQL = "SELECT * FROM Invoices";
                return sSQL;
            }
            catch (Exception e)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + e.Message);
            }
        }

        
    }
}
