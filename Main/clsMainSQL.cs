using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
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

        #region Selects

        //Get all Invoices
        public static string GetAllInvoices()
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

        //GetLatestInvoice
        public static string getLatestInvoice()
        {
            try
            {
                string sSQL = "Select InvoiceNum, InvoiceDate, TotalCost from Invoices where InvoiceNum = (select max(InvoiceNum) from Invoices)";
                return sSQL;
            }
            catch (Exception e)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + e.Message);
            }
        }

        //GetInvoiceByNumber
        public static string getInvoiceByNumber(string InvoiceNumber)
        {
            try
            {
                string sSQL = "SELECT InvoiceNum, InvoiceDate, TotalCost FROM Invoices where InvoiceNum = " + InvoiceNumber;
                return sSQL;
            }
            catch (Exception e)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + e.Message);
            }
        }

        //GetItemsByInvoice
        public static string getItemsByInvoice(string InvoiceNumber)
        {
            try
            {
                string sSQL = "SELECT ItemDesc.ItemCode, ItemDesc.ItemDesc, ItemDesc.ItemCost FROM ItemDesc INNER JOIN LineItems ON ItemDesc.ItemCode = LineItems.ItemCode WHERE LineItems.InvoiceNum = " + InvoiceNumber;
                return sSQL;
            }
            catch (Exception e)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + e.Message);
            }
        }

        //getAllItems
        public static string getAllItems()
        {
            try
            {
                string sSQL = "SELECT * FROM ItemDesc";
                return sSQL;
            }
            catch (Exception e)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + e.Message);
            }
        }

        //getItembyCode
        public static string getItemByCode(string ItemCode)
        {
            try
            {
                string sSQL = "SELECT * FROM ItemDesc WHERE ItemCode = '" + ItemCode + "'";
                return sSQL;
            }
            catch (Exception e)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + e.Message);
            }
        }

        



        #endregion


        #region Updates
        //Update Invoice
        public static string UpdateInvoice(string TotalCost, string InvoiceNumber)
        {
            try
            {
                string sSQL = "UPDATE Invoices SET TotalCost = " + TotalCost + " WHERE InvoiceNum = " + InvoiceNumber;
                return sSQL;
            }
            catch (Exception e)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + e.Message);
            }
        }

        public static string UpdateInvoiceTotalCost(string newTotal, string invoiceNum) 
        { 
            try
            {
                string sSQL = "UPDATE Invoices SET TotalCost = " + newTotal + " WHERE InvoiceNum = " + invoiceNum;
                return sSQL;
            }
            catch (Exception e)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + e.Message);
            }
        }
        #endregion

        #region Inserts
        //Insert LineItems
        public static string addLineItem(string InvoiceNumber, string LineItemNumber, string ItemCode)
        {
            try
            {
                string sSQL = "INSERT INTO LineItems (InvoiceNum, LineItemNum, ItemCode) Values ("+ InvoiceNumber + ", "+ LineItemNumber +", '"+ ItemCode +"')";
                return sSQL;
            }
            catch (Exception e)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + e.Message);
            }
        }

        //Insert Invoice
        public static string addInvoice(DateTime InvoiceDate, string TotalCost)
        {
            try
            {
                string sSQL = "INSERT INTO Invoices (InvoiceDate, TotalCost) Values (#"+ InvoiceDate +"#, "+ TotalCost +")";
                return sSQL;
            }
            catch (Exception e)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + e.Message);
            }
        }
        #endregion

        #region Delete

        //Delete all Invoice Line Items
        public static string deleteAllInvoiceLineItems(string InvoiceNumber)
        {
            try
            {
                string sSQL = "DELETE FROM LineItems WHERE InvoiceNum = " + InvoiceNumber;
                return sSQL;
            }
            catch (Exception e)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + e.Message);
            }
        }

        //Delete Invoice
        public static string deleteInvoice(string InvoiceNumber)
        {
            try
            {
                string sSQL = "DELETE FROM Invoices WHERE InvoiceNum = " + InvoiceNumber;
                return sSQL;
            }
            catch (Exception e)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + e.Message);
            }
        }
        #endregion


    }
}
