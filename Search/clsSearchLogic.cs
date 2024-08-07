using DummyWPF.Main;
using GroupProject3280.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DummyWPF.Search
{
    public class clsSearchLogic
    {
        /// <summary>
        /// List of keywords to help datagrid filtering
        /// </summary>
        public enum Selection
        {
            NUM,
            DATE,
            COST,
            NUM_DATE,
            DATE_COST,
        }

        /// <summary>
        /// Database access
        /// </summary>
        private clsDataAccess db;

        /// <summary>
        /// Line Items model
        /// </summary>
        private modLineItems iineItems;

        /// <summary>
        /// Create data access object 
        /// </summary>
        /// <exception cref="Exception"></exception>
        public clsSearchLogic()
        {
            try
            {
                db = new clsDataAccess();
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }

        }

        /// <summary>
        /// Fill Invoice List
        /// </summary>
        /// <exception cref="Exception"></exception>
        public List<modInvoice> RetrieveInvoices()
        {
            List<modInvoice> InvoiceList = new List<modInvoice>();
            try
            {
                //string sSQL = clsSearchSQL.SelectAllInvoice();
                //return ParseInvoice(sSQL);

                db = new clsDataAccess();

                DataSet ds = new DataSet();
                int iRet = 0;

                ds = db.ExecuteSQLStatement(clsSearchSQL.SelectAllInvoice(), ref iRet);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    modInvoice invoice = new modInvoice();
                    invoice.InvoiceNum = int.Parse(dr[0].ToString());
                    invoice.InvoiceDate = DateTime.Parse(dr[1].ToString());
                    invoice.TotalCost = decimal.Parse(dr[2].ToString());
                    InvoiceList.Add(invoice);
                }


            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }

            return InvoiceList;


        }

        /// <summary>
        /// Returns a list of distinct invoice numbers
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public List<int> RetrieveInvoiceNums()
        {
            try
            {
                DataSet ds = new DataSet();
                string sSQL = clsSearchSQL.selectDistinctInvoiceNum();
                
                List<int> iInvoiceNumTemp = new List<int>();
                int iRet = 0;

                ds = db.ExecuteSQLStatement(sSQL, ref iRet);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (dr[0] is int a)
                    {
                        iInvoiceNumTemp.Add(a);
                    }
                }
                return iInvoiceNumTemp;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }


        }

        /// <summary>
        /// Returns a list of distinct invoice dates
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public List<DateTime> RetrieveInvoiceDates()
        {
            try
            {
                DataSet ds = new DataSet();
                string sSQL = clsSearchSQL.selectDistinctInvoiceDate();
                List<DateTime> iInvoiceDateTemp = new List<DateTime>();
                int iRet = 0;

                ds = db.ExecuteSQLStatement(sSQL, ref iRet);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (dr[0] is DateTime a)
                    {
                        iInvoiceDateTemp.Add(a);
                    }
                }
                return iInvoiceDateTemp;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }


        }

        /// <summary>
        /// Returns a list of invoice costs
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public List<decimal> RetrieveInvoiceCosts()
        {
            try
            {
                DataSet ds = new DataSet();
                string sSQL = clsSearchSQL.selectDistinctInvoiceTCost();
                List<decimal> iInvoiceCostTemp = new List<decimal>();
                int iRet = 0;

                ds = db.ExecuteSQLStatement(sSQL, ref iRet);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    if (dr[0] is decimal a)
                    {
                        iInvoiceCostTemp.Add(a);
                    }
                }
                return iInvoiceCostTemp;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }

        }

        /// <summary>
        /// Return a modInvoice list of SQL argument
        /// </summary>
        /// <param name="sSQL"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public List<modInvoice> ParseInvoice(string sSQL)
        {
            try
            {
                DataSet ds = new DataSet();
                List<modInvoice> invoiceList = new List<modInvoice>();
                int iRet = 0;

                ds = db.ExecuteSQLStatement(sSQL, ref iRet);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {

                    modInvoice invoiceEntry = new modInvoice();

                    if (dr[0] is int a)
                    {
                        invoiceEntry.InvoiceNum = a;
                    }
                    if (dr[1] is DateTime b)
                    {
                        invoiceEntry.InvoiceDate = b;
                    }
                    if (dr[2] is decimal c)
                    {
                        invoiceEntry.TotalCost = c;
                    }

                    invoiceList.Add(invoiceEntry);
                }
                return invoiceList;
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }


        }

        /// <summary>
        /// Return a modInvoice list of 3 arguments [invoiceNum, invoiceDate, invoiceCost]
        /// </summary>
        /// <param name="invoiceNum"></param>
        /// <param name="invoiceDate"></param>
        /// <param name="invoiceCost"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public List<modInvoice> RetrieveSearch(string invoiceNum, string invoiceDate, string invoiceCost)
        {
            try
            {
                DataSet ds = new DataSet();
                string sSQL = clsSearchSQL.selectInvoiceByID_Date_Cost(invoiceNum, invoiceDate, invoiceCost);
                return ParseInvoice(sSQL);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Return a modInvoice list of 2 arguments [invoiceNum, invoiceDate, invoiceCost]
        /// </summary>
        /// <param name="type"></param>
        /// <param name="entry1"></param>
        /// <param name="entry2"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public List<modInvoice> RetrieveSearch(Selection type, string entry1, string entry2)
        {
            try
            {
                string sSQL;
                switch (type)
                {
                    case Selection.NUM_DATE:
                        sSQL = clsSearchSQL.selectInvoiceByID_Date(entry1, entry2);
                        break;
                    case Selection.DATE_COST:
                        sSQL = clsSearchSQL.selectInvoiceByDate_Cost(entry1, entry2);
                        break;
                    default:
                        return null;
                }
                return ParseInvoice(sSQL);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Return a modInvoice list of 1 argument [invoiceNum, invoiceDate, invoiceCost]
        /// </summary>
        /// <param name="type"></param>
        /// <param name="entry"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public List<modInvoice> RetrieveSearch(Selection type, string entry)
        {
            try
            {
                string sSQL;
                switch (type)
                {
                    case Selection.NUM:
                        sSQL = clsSearchSQL.selectInvoiceByID(entry);
                        break;
                    case Selection.DATE:
                        sSQL = clsSearchSQL.selectInvoiceByDate(entry);
                        break;
                    case Selection.COST:
                        sSQL = clsSearchSQL.selectInvoiceByCost(entry);
                        break;
                    default:
                        return null;
                }

                return ParseInvoice(sSQL);
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
            
        }

    }
}
