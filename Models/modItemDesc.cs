using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject3280.Models
{
    /// <summary>
    /// Item Description Model Class
    /// </summary>
    public class modItemDesc
    {
        /// <summary>
        /// Item Code
        /// </summary>
        public string ItemCode { get; set; }

        /// <summary>
        /// Item Description
        /// </summary>
        public string ItemDesc { get; set; }

        /// <summary>
        /// Item Cost
        /// </summary>
        public decimal ItemCost { get; set; }

        /// <summary>
        /// Override the toString()
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            //Format String to show cost
            string newCost = String.Format("{0:C}", ItemCost);
            
            return ItemDesc.ToString() + " " + newCost;
        }

        /// <summary>
        /// Get the Item Code
        /// </summary>
        /// <returns></returns>
        public string getCost()
        {
            return ItemCost.ToString();
        }

    }
}
