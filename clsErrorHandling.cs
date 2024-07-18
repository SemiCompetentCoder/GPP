using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace GroupProject3280
{
    public class clsErrorHandling
    {
        //Class string
        public string sClass;
        //Method string
        public string sMethod;
        //Error message string
        public string sMessage;

        /// <summary>
        /// Display the error message
        /// </summary>
        public void displayErrorMessage()
        {
            try
            {
                //Attempt a message box if it fails write to a file
                MessageBox.Show(sClass + "." + sMethod + " -> " + sMessage);
            }
            catch (Exception e)
            {
                System.IO.File.AppendAllText("C:\\" + System.AppDomain.CurrentDomain.FriendlyName + "Error.txt", Environment.NewLine + "HandleError Exception: " + e.Message);
            }
        }
    }
}
