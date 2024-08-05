using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupProject3280.Models
{
    public class modItemDesc
    {
        //Item Code
        public string ItemCode { get; set; }

        //Item Description
        public string ItemDesc { get; set; }

        //Item Cost
        public decimal ItemCost { get; set; }

        //Override the toString()
        public override string ToString()
        {
            return ItemDesc.ToString() + " $" + ItemCost + ".00";
        }

        public string getCost()
        {
            return ItemCost.ToString();
        }

    }
}
