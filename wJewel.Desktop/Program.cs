using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using IshalInc.wJewel.Desktop.Forms;
using System.Globalization;
using System.Reflection;
using System.Resources;
using System.Threading;
using System.Drawing;
using IshalInc.wJewel.Desktop.Libraries;
using System.Security.Permissions;
using System.Diagnostics;

namespace IshalInc.wJewel.Desktop
{
    static class Program
    {
       
        static Form mainForm;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// 
        [SecurityPermission(SecurityAction.Demand, Flags = SecurityPermissionFlag.ControlAppDomain)]
        static void Main()
        {

            string errorMsg = "An application error occurred. Please contact the adminstrator " +
                  "with the following information:\n\n";

            CultureInfo originalCulture = Thread.CurrentThread.CurrentCulture;

            try
            {
                CultureInfo newCulture = new CultureInfo("en-US");
                newCulture.Calendar.TwoDigitYearMax = 2099;
                Thread.CurrentThread.CurrentCulture = newCulture;
                Thread.CurrentThread.CurrentUICulture = newCulture;
              
            }
            catch (CultureNotFoundException e)
            {
                Console.WriteLine("Unable to instantiate culture {0}", e.InvalidCultureName);
            }
            finally
            {
                Thread.CurrentThread.CurrentCulture = originalCulture;
                Thread.CurrentThread.CurrentUICulture = originalCulture;
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Add the event handler for handling UI thread exceptions to the event.
            Application.ThreadException += new ThreadExceptionEventHandler(Form1_UIThreadException);

            // Set the unhandled exception mode to force all Windows Forms errors to go through
            // our handler.
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);

            // Add the event handler for handling non-UI thread exceptions to the event. 
            AppDomain.CurrentDomain.UnhandledException +=
                new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

          
            mainForm = new frmMain();
            mainForm.Load += new EventHandler(mainForm_Load);
            Application.Run(mainForm);
           
        }

        static void mainForm_Load(object sender, EventArgs e)
        {
           
        }


        private static void Form1_UIThreadException(object sender, ThreadExceptionEventArgs t)
        {
            DialogResult result = DialogResult.Cancel;
            try
            {
                result = ShowThreadExceptionDialog("Windows Forms Error", t.Exception);
            }
            catch
            {
                try
                {
                    MessageBox.Show("Fatal Windows Forms Error",
                        "Fatal Windows Forms Error", MessageBoxButtons.AbortRetryIgnore, MessageBoxIcon.Stop);
                }
                finally
                {
                    Application.Exit();
                }
            }

            // Exits the program when the user clicks Abort.
            if (result == DialogResult.Abort)
                Application.Exit();
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            try
            {
                Exception ex = (Exception)e.ExceptionObject;
                string errorMsg = "An application error occurred. Please contact the adminstrator " +
                    "with the following information:\n\n";

                Helper.AddError(errorMsg + ex.Message, "Stack Trace:\n" + ex.StackTrace);

            }
            catch (Exception exc)
            {
                try
                {
                    MessageBox.Show("Fatal Non-UI Error",
                        "Fatal Non-UI Error. Could not write the error to the event log. Reason: "
                        + exc.Message, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                finally
                {
                    Application.Exit();
                }
            }
        }

        // Creates the error message and displays it.
        private static DialogResult ShowThreadExceptionDialog(string title, Exception e)
        {
            string errorMsg = "An application error occurred. Please contact the adminstrator " +
                "with the following information:\n\n";
            Helper.AddError(errorMsg + e.Message, "Stack Trace:\n" + e.StackTrace);

            errorMsg = errorMsg + e.Message + "\n\nStack Trace:\n" + e.StackTrace;
            return MessageBox.Show(errorMsg, title, MessageBoxButtons.AbortRetryIgnore,
                MessageBoxIcon.Stop);
        }

    }
}
