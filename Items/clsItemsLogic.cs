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

        // A list containing the IDs of modified line items will indicate if a line item has been modified
        // might be implemented like so
        // List<int> modifiedLineItems = new List<int>();
        
        public void getLineItems() {
            ; // get line items from the database and return them as a list
        }
        
        public void submitLineItem() 
        {
            ; // will check a line item with the specified code already exists, if it does, it will update it with new information
              // otherwise, it will simply insert a new one
        }
        
        public void removeLineItem() 
        {
            ; // remove the line item, if it exists, and add it to the modifiedLineItems list
        }
        
        public void getModifiedLineItems() 
        {
            ; // will get IDs from modifiedLineItems, and then clear the list
        }
    }
}
