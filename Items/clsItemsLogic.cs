using DummyWPF.Main;
using GroupProject3280;
using GroupProject3280.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DummyWPF.Items
{
    public class clsItemsLogic
    {
        /// <summary>
        /// Database access
        /// </summary>
        private clsDataAccess db = new clsDataAccess();

        public List<modItemDesc> getItemDescs()
        {
            try
            {
                // get item rows from the ItemDesc table
                int iRetVal = 0;
                DataSet ds = new DataSet();
                ds = db.ExecuteSQLStatement(clsItemsSQL.GetAllItemDesc(), ref iRetVal);

                List<modItemDesc> itemList = new List<modItemDesc>();

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    modItemDesc newItem = new modItemDesc();
                    //Debug.WriteLine(dr[0].ToString());
                    //Debug.WriteLine(dr[1].ToString());
                    //Debug.WriteLine(dr[2].ToString());
                    //Debug.WriteLine("\n");
                    newItem.ItemCode = dr[0].ToString();
                    newItem.ItemDesc = dr[1].ToString();
                    newItem.ItemCost = decimal.Parse(dr[2].ToString());
                    itemList.Add(newItem);
                }

                return itemList;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }

        }

        /// <summary>
        /// Get info for the specified line item
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static modItemDesc getInfoForSpecificLineItem(string code) {
            try
            {
                // get item rows from the ItemDesc table
                int iRetVal = 0;
                DataSet ds = new DataSet();
                clsDataAccess db = new clsDataAccess();
                ds = db.ExecuteSQLStatement(clsItemsSQL.GetItemInfo(code), ref iRetVal);

                modItemDesc newItem = new modItemDesc();

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    Debug.WriteLine(dr[0].ToString());
                    Debug.WriteLine(dr[1].ToString());
                    Debug.WriteLine(dr[2].ToString());
                    //Debug.WriteLine("\n");
                    newItem.ItemCode = dr[0].ToString();
                    newItem.ItemDesc = dr[1].ToString();
                    newItem.ItemCost = decimal.Parse(dr[2].ToString());
                    return newItem;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }

            return null;
        }

        /// <summary>
        /// Check if item desc with code exists
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        private bool? checkIfExists(string code) 
        {
            try
            {
                modItemDesc info = getInfoForSpecificLineItem(code);
                if (info != null)
                {
                    if (info.ItemCost == -1)
                    {
                        return false;
                    }
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Insert or update a line item
        /// </summary>
        /// <param name="code"></param>
        /// <param name="desc"></param>
        /// <param name="cost"></param>
        /// <exception cref="Exception"></exception>
        public void submitLineItem(string code, string desc, string cost)
        {
            try
            {
                bool? exists = checkIfExists(code);
                Debug.WriteLine(exists.Value);
                if (exists != null) {
                    // get item rows from the ItemDesc table
                    if ((bool)exists) // This needs separate error handling
                    {
                        db.ExecuteNonQuery(clsItemsSQL.UpdateItemDesc(desc, cost, code));
                    }
                    else
                    {
                        db.ExecuteNonQuery(clsItemsSQL.InsertIntoItemDesc(desc, cost, code));
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Delete item if not associated with invoice
        /// </summary>
        /// <param name="code"></param>
        /// <exception cref="Exception"></exception>
        public void deleteLineItem(string code) 
        {
            try
            {
                string invoiceNum = db.ExecuteScalarSQL(clsItemsSQL.GetInvoiceNumFromLineItem(code));
                if (invoiceNum == "")
                {
                    db.ExecuteNonQuery(clsItemsSQL.DeleteFromItemDesc(code));
                }
                else
                {
                    MessageBox.Show("Cannot delete item, has associated invoice", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }
    }
}
