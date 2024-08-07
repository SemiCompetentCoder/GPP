using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject3280.Models
{
    /// <summary>
    /// Invoice Model Class
    /// </summary>
    public class modInvoice
    {
        /// <summary>
        /// InvoiceNum
        /// </summary>
        public int InvoiceNum { get; set; }

        /// <summary>
        /// InvoiceDate
        /// </summary>
        public DateTime InvoiceDate { get; set; }

        /// <summary>
        /// TotalCost
        /// </summary>
        public decimal TotalCost { get; set; }


    }
}
