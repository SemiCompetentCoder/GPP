using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls.Primitives;
using System.Windows.Controls;

namespace DummyWPF.Search
{
    public class clsSearchSQL
    {
        /// <summary>
        /// Return all invoices
        /// </summary>
        /// <returns></returns>
        public static string SelectAllInvoice()
        {
            try
            {
                return "SELECT * FROM Invoices";
            }
            catch (Exception e)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + e.Message);
            }
        }
        /// <summary>
        /// Return invoices of entered InvoiceID
        /// </summary>
        /// <param name="sInvoiceID"></param>
        /// <returns></returns>
        public static string selectInvoiceByID(string sInvoiceID)
        {
            try
            {
                return $"SELECT * FROM Invoices WHERE InvoiceNum = {sInvoiceID}";
            }
            catch (Exception e)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + e.Message);
            }
        }

        /// <summary>
        /// Return invoices of entered date
        /// </summary>
        /// <param name="sInvoiceDate"></param>
        /// <returns></returns>
        public static string selectInvoiceByDate(string sInvoiceDate)
        {
            try
            {
                return $"SELECT * FROM Invoices WHERE InvoiceDate = #{sInvoiceDate}#";
            }
            catch (Exception e)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + e.Message);
            }

        }

        /// <summary>
        /// Return invoices of entered TotalCost
        /// </summary>
        /// <param name="sInvoiceTotalCost"></param>
        /// <returns></returns>
        public static string selectInvoiceByTCost(string sInvoiceTotalCost)
        {
            try
            {
                return $"select * from Invoices where TotalCost = {sInvoiceTotalCost}";
            }
            catch (Exception e)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + e.Message);
            }

        }

        /// <summary>
        /// Return invoice of ID and Date
        /// </summary>
        /// <param name="sInvoiceID"></param>
        /// <param name="sInvoiceDate"></param>
        /// <returns></returns>
        public static string selectInvoiceByID_Date(string sInvoiceID, string sInvoiceDate)
        {
            try
            {
                return $"select * from Invoices where InvoiceNum = {sInvoiceID} AND InvoiceDate = #{sInvoiceDate}# ";
            }
            catch (Exception e)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + e.Message);
            }

        }

        /// <summary>
        /// Return invoice of ID Date and Cost
        /// </summary>
        /// <param name="sInvoiceID"></param>
        /// <param name="sInvoiceDate"></param>
        /// <param name="sInvoiceTotalCost"></param>
        /// <returns></returns>
        public static string selectInvoiceByID_Date_Cost(string sInvoiceID, string sInvoiceDate, string sInvoiceTotalCost)
        {
            try
            {
                return $"select * from Invoices where InvoiceNum = {sInvoiceID} AND InvoiceDate = #{sInvoiceDate}# AND TotalCost = {sInvoiceTotalCost}";
            }
            catch (Exception e)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + e.Message);
            }
        }

        /// <summary>
        /// Return invoice of TotalCost
        /// </summary>
        /// <param name="sInvoiceTotalCost"></param>
        /// <returns></returns>
        public static string selectInvoiceByCost(string sInvoiceTotalCost)
        {
            try
            {
                return $"select * from Invoices where TotalCost = {sInvoiceTotalCost}";
            }
            catch (Exception e)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + e.Message);
            }
        }

        /// <summary>
        /// Return invoice of Cost and Date
        /// </summary>
        /// <param name="sInvoiceTotalCost"></param>
        /// <param name="sInvoiceDate"></param>
        /// <returns></returns>
        public static string selectInvoiceByDate_Cost(string sInvoiceDate, string sInvoiceTotalCost)
        {
            try
            {
                return $"select * from Invoices where TotalCost = {sInvoiceTotalCost} AND InvoiceDate = #{sInvoiceDate}# ";
            }
            catch (Exception e)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + e.Message);
            }

        }

        /// <summary>
        /// Return distinct invoice nums
        /// </summary>
        /// <param name="sInvoiceNum"></param>
        /// <returns></returns>
        public static string selectDistinctInvoiceNum()
        {
            try
            {
                return $"SELECT DISTINCT(InvoiceNum) From Invoices order by InvoiceNum";
            }
            catch (Exception e)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + e.Message);
            }
        }

        /// <summary>
        /// Return distinct invoice dates
        /// </summary>
        /// <param name="sInvoiceDate"></param>
        /// <returns></returns>
        public static string selectDistinctInvoiceDate()
        {
            try
            {
                return $"SELECT DISTINCT(InvoiceDate) From Invoices order by InvoiceDate";
            }
            catch (Exception e)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + e.Message);
            }

        }

        /// <summary>
        /// Return distinct invoice costs
        /// </summary>
        /// <param name="sInvoiceTotalCost"></param>
        /// <returns></returns>
        public static string selectDistinctInvoiceTCost()
        {
            try
            {
                return $"SELECT DISTINCT(TotalCost) From Invoices order by TotalCost";
            }
            catch (Exception e)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + e.Message);
            }
        }
}
}
