using GroupProject3280;
using GroupProject3280.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DummyWPF.Main
{
    public class clsMainLogic
    {
        /// <summary>
        /// Database access
        /// </summary>
        private clsDataAccess db;

        /// <summary>
        /// SQL queries
        /// </summary>
        private clsMainSQL sql;

        /// <summary>
        /// Error Handler
        /// </summary>
        private clsErrorHandling errorHandler;

        /// <summary>
        /// Invoice List storage
        /// </summary>
        private List<modInvoice> InvoiceList { get; set; }

        /// <summary>
        /// get all invoices
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public List<modInvoice> getInvoices()
        {
            try
            {
                db = new clsDataAccess();

                DataSet ds = new DataSet();
                int iRet = 0;

                InvoiceList = new List<modInvoice>();
                ds = db.ExecuteSQLStatement(clsMainSQL.GetAllInvoices(), ref iRet);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    modInvoice invoice = new modInvoice();
                    invoice.InvoiceNum = int.Parse(dr[0].ToString());
                    invoice.InvoiceDate = DateTime.Parse(dr[1].ToString());
                    invoice.TotalCost = int.Parse(dr[2].ToString());
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
        /// Get invoice by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public modInvoice getInvoiceById(int id)
        {
            modInvoice invoice = new modInvoice();
            try
            {
                db = new clsDataAccess();
                DataSet ds = new DataSet();
                int iRet = 0;
                ds = db.ExecuteSQLStatement(clsMainSQL.getInvoiceByNumber(id.ToString()), ref iRet);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    invoice.InvoiceNum = int.Parse(dr[0].ToString());
                    invoice.InvoiceDate = DateTime.Parse(dr[1].ToString());
                    invoice.TotalCost = int.Parse(dr[2].ToString());
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }

            return invoice;
        }

        /// <summary>
        /// get all items
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public List<modItemDesc> getAllItems()
        {
            List<modItemDesc> ItemList = new List<modItemDesc>();

            try
            {
                db = new clsDataAccess();
                DataSet ds = new DataSet();
                int iRet = 0;
                ds = db.ExecuteSQLStatement(clsMainSQL.getAllItems(), ref iRet);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    modItemDesc item = new modItemDesc();
                    item.ItemCode = dr[0].ToString();
                    item.ItemDesc = dr[1].ToString();
                    item.ItemCost = int.Parse(dr[2].ToString());
                    ItemList.Add(item);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }

            return ItemList;

        }

        /// <summary>
        /// Get the invoice items for an invoice
        /// </summary>
        /// <param name="invoiceNumber"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public List<modItemDesc> getItemsInInvoice(int invoiceNumber)
        {
            List<modItemDesc> modItemDescs = new List<modItemDesc>();

            try
            {
                db = new clsDataAccess();
                DataSet ds = new DataSet();
                int iRet = 0;
                ds = db.ExecuteSQLStatement(clsMainSQL.getItemsByInvoice(invoiceNumber.ToString()), ref iRet);

                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    modItemDesc item = new modItemDesc();
                    item.ItemCode = dr[0].ToString();
                    item.ItemDesc = dr[1].ToString();
                    item.ItemCost = int.Parse(dr[2].ToString());
                    modItemDescs.Add(item);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }

            return modItemDescs;
        }

        /// <summary>
        /// Save items to invoice
        /// </summary>
        /// <param name="items"></param>
        /// <param name="invoiceNumber"></param>
        /// <exception cref="Exception"></exception>
        public void saveInvoice(List<modItemDesc> items, int invoiceNumber)
        {
            try
            {
                

                db = new clsDataAccess();
                int iRet = 0;
                db.ExecuteNonQuery(clsMainSQL.deleteAllInvoiceLineItems(invoiceNumber.ToString()));

                //add all line items to the invoice
                int counter = 1;
                foreach (modItemDesc item in items)
                {
                    db.ExecuteNonQuery(clsMainSQL.addLineItem(invoiceNumber.ToString(), counter.ToString(), item.ItemCode));
                    counter++;
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Create invoice
        /// </summary>
        /// <param name="invoiceDate"></param>
        /// <param name="totalCost"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public int createInvoice(DateTime invoiceDate, int totalCost)
        {
            modInvoice invoice = new modInvoice();
            try
            {
                db = new clsDataAccess();
                int iRet = 0;
                db.ExecuteNonQuery(clsMainSQL.addInvoice(invoiceDate, totalCost.ToString()));

                //get the invoice number
                DataSet ds = new DataSet();
                ds = db.ExecuteSQLStatement(clsMainSQL.getLatestInvoice(), ref iRet);

                foreach(DataRow dr in ds.Tables[0].Rows)
                {
                    invoice.InvoiceNum = int.Parse(dr[0].ToString());
                }
                
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }

            return invoice.InvoiceNum;
        }

        /// <summary>
        /// Delete invoice
        /// </summary>
        /// <param name="invoiceNumber"></param>
        /// <exception cref="Exception"></exception>
        public void deleteInvoice(int invoiceNumber)
        {
            try
            {
                //Delete all line items for the invoice
                db = new clsDataAccess();
                db.ExecuteNonQuery(clsMainSQL.deleteAllInvoiceLineItems(invoiceNumber.ToString()));
                db.ExecuteNonQuery(clsMainSQL.deleteInvoice(invoiceNumber.ToString()));
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);
            }
        }

        /// <summary>
        /// Update invoice
        /// </summary>
        /// <param name="newTotalCost"></param>
        /// <param name="newInvoiceNumber"></param>
        /// <exception cref="Exception"></exception>
        public void updateInvoice(int newTotalCost, int newInvoiceNumber)
        {
            try
            {
                db = new clsDataAccess();
                db.ExecuteNonQuery(clsMainSQL.UpdateInvoiceTotalCost(newTotalCost.ToString(), newInvoiceNumber.ToString()));
            }
            catch (Exception ex)
            {
                throw new Exception(MethodInfo.GetCurrentMethod().DeclaringType.Name + "." + MethodInfo.GetCurrentMethod().Name + " -> " + ex.Message);

            }

        }


        

        
        
    }
}
