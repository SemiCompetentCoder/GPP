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

        public static string GetAllItemDesc()
        {
            try
            {
                string sSQL = "select ItemCode, ItemDesc, Cost from ItemDesc";
                return sSQL;
            }
            catch (Exception e)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + e.Message);
            }
        }

        public static string GetInvoiceNumFromLineItem(string itemCode) 
        {
            try
            {
                string sSQL = "select distinct(InvoiceNum) from LineItems where ItemCode = '"+itemCode+"'";
                return sSQL;
            }
            catch (Exception e)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + e.Message);
            }
        }

        public static string UpdateItemDesc(string itemDesc, string itemCost, string itemCode)
        {
            try
            {
                string sSQL = "Update ItemDesc Set ItemDesc = '"+itemDesc+"', Cost = "+itemCost+" where ItemCode = '"+itemCode+"'";
                return sSQL;
            }
            catch (Exception e)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + e.Message);
            }
        }

        public static string InsertIntoItemDesc(string itemDesc, string itemCost, string itemCode) 
        {
            try
            {
                string sSQL = "Insert into ItemDesc (ItemCode, ItemDesc, Cost) Values ('"+itemDesc+"', '"+itemCost+"', "+itemCode+")";
                return sSQL;
            }
            catch (Exception e)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + e.Message);
            }
        }

        public static string DeleteFromItemDesc(string itemCode) 
        {
            try
            {
                string sSQL = "Delete from ItemDesc Where ItemCode = '"+itemCode+"'";
                return sSQL;
            }
            catch (Exception e)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + e.Message);
            }
        }
    }
}
