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
        /// <summary>
        /// Class string
        /// </summary>
        public string sClass;
        /// <summary>
        /// Method string
        /// </summary>
        public string sMethod;
        /// <summary>
        /// Error message string
        /// </summary>
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

        /// <summary>
        /// Inline Version to display error
        /// </summary>
        /// <param name="sClass"></param>
        /// <param name="sMethod"></param>
        /// <param name="sMessage"></param>
        public void displayErrorMessage(string sClass, string sMethod, string sMessage)
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
