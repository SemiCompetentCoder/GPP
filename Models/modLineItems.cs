using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject3280.Models
{
    /// <summary>
    /// Line Items Model Class
    /// </summary>
    public class modLineItems
    {
        /// <summary>
        /// Invoice Number
        /// </summary>
        public int InvoiceNum { get; set; }

        /// <summary>
        /// LineItemNumber
        /// </summary>
        public int LineItemNum { get; set; }

        /// <summary>
        /// Item Code
        /// </summary>
        public string ItemCode { get; set; }
    }
}
