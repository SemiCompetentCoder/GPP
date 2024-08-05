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


        /// <summary>
        /// Get all Invoices
        ///</summary>
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

        /// <summary>
        /// GetLatestInvoice
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
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

        /// <summary>
        /// GetInvoiceByNumber
        /// </summary>
        /// <param name="InvoiceNumber"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
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

        /// <summary>
        /// GetItemsByInvoice
        /// </summary>
        /// <param name="InvoiceNumber"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string getItemsByInvoice(string InvoiceNumber)
        {
            try
            {
                string sSQL = "SELECT ItemDesc.ItemCode, ItemDesc.ItemDesc, ItemDesc.Cost FROM ItemDesc INNER JOIN (Invoices INNER JOIN LineItems ON Invoices.InvoiceNum = LineItems.InvoiceNum) ON ItemDesc.ItemCode = LineItems.ItemCode WHERE LineItems.InvoiceNum=" + InvoiceNumber;
                return sSQL;
            }
            catch (Exception e)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + e.Message);
            }
        }

        /// <summary>
        /// getAllItems
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
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

        /// <summary>
        /// getItembyCode
        /// </summary>
        /// <param name="ItemCode"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
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
        /// <summary>
        /// Update Invoice
        /// </summary>
        /// <param name="TotalCost"></param>
        /// <param name="InvoiceNumber"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
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

        /// <summary>
        /// Update Invoice Total Cost
        /// </summary>
        /// <param name="newTotal"></param>
        /// <param name="invoiceNum"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
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
        /// <summary>
        /// Insert LineItems
        /// </summary>
        /// <param name="InvoiceNumber"></param>
        /// <param name="LineItemNumber"></param>
        /// <param name="ItemCode"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
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

        /// <summary>
        /// Insert Invoice
        /// </summary>
        /// <param name="InvoiceDate"></param>
        /// <param name="TotalCost"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static string addInvoice(DateTime InvoiceDate, string TotalCost)
        {
            try
            {
                string sSQL = "INSERT INTO Invoices (InvoiceDate, TotalCost) Values (#"+ InvoiceDate.ToString() +"#, "+ TotalCost +")";
                return sSQL;
            }
            catch (Exception e)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + e.Message);
            }
        }
        #endregion

        #region Delete

        /// <summary>
        /// Delete all Invoice Line Items
        /// </summary>
        /// <param name="InvoiceNumber"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
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

        /// <summary>
        /// Delete Invoice
        /// </summary>
        /// <param name="InvoiceNumber"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
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
