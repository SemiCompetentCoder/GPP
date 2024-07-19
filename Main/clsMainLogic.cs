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

        

        
        

    }
}
