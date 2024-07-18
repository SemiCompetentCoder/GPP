using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DummyWPF.Items
{
    public class clsItemsSQL
    {
        /// <summary>
        /// Get all line items from the database
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string GetAllItems()
        {
            try
            {
                string sSQL = "SELECT * FROM LineItems";
                return sSQL;
            }
            catch (Exception e)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + e.Message);
            }
        }
    }
}
