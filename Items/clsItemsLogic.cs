using DummyWPF.Main;
using GroupProject3280.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DummyWPF.Items
{
    public class clsItemsLogic
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
        /// Invoice model
        /// </summary>
        private modInvoice _InvoiceModel;

        /// <summary>
        /// Item Description model
        /// </summary>
        private modItemDesc _ItemDescModel;

        /// <summary>
        /// Line Items model
        /// </summary>
        private modLineItems _LineItems;
    }
}
