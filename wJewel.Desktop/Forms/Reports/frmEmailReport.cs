using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.IO;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Net.Mail;
using IshalInc.wJewel.Desktop.Libraries;

namespace IshalInc.wJewel.Desktop.Forms
{
    public partial class frmEmailReport : Telerik.WinControls.UI.RadForm
    {
        

        /// <summary>
        /// Variable to store error message
        /// </summary>
        private string errorMessage;

        private MemoryStream pattachment;
      

        public frmEmailReport()
        {
            InitializeComponent();
            this.Icon = Helper.MakeIcon(IshalInc.wJewel.Desktop.Properties.Resources.mail, 24, true);
        }

        public frmEmailReport(string Email, string Subject,MemoryStream attachment)
        {
            InitializeComponent();
            this.Icon = Helper.MakeIcon(IshalInc.wJewel.Desktop.Properties.Resources.mail, 24, true);
            this.txtEmail.Text = Email.Trim();
            this.txtSubject.Text = Subject.Trim();
            this.pattachment = attachment;

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (ValidateInput())
            {
                
                DataTable dtEmailSetting = Helper.GetEmailSettings();
                if (dtEmailSetting.Rows.Count > 0)
                {
                    
                    try
                    {
                        using (MailMessage mail = new MailMessage())
                        {
                            using (SmtpClient smtpServer = new SmtpClient((string)dtEmailSetting.Rows[0]["smtpserver"]))
                            {
                                smtpServer.SendCompleted += (s, ef) => smtpServer.Dispose();

                                mail.From = new MailAddress((string)dtEmailSetting.Rows[0]["email"]);
                                mail.To.Add(this.txtEmail.Text);
                                mail.Subject = this.txtSubject.Text;
                                mail.Body = this.txtMessage.Text;

                                Attachment repAttachemnt = new Attachment(this.pattachment, this.txtSubject.Text + ".pdf");
                                mail.Attachments.Add(repAttachemnt);
                                smtpServer.DeliveryMethod = SmtpDeliveryMethod.Network;
                                smtpServer.UseDefaultCredentials = false;
                                smtpServer.Port = Convert.ToInt32(dtEmailSetting.Rows[0]["smtpport"]);
                                smtpServer.Credentials = new System.Net.NetworkCredential((string)dtEmailSetting.Rows[0]["email"], (string)dtEmailSetting.Rows[0]["password"]);
                                smtpServer.EnableSsl = (bool)dtEmailSetting.Rows[0]["usessl"];

                                smtpServer.SendCompleted += new SendCompletedEventHandler(SendCompletedCallback);
                                smtpServer.Send(mail);
                                Helper.MsgBox("Report Sent Successfully");
                                this.DialogResult = DialogResult.OK;
                                this.Close();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Helper.MsgBox(ex.Message, RadMessageIcon.Error);
                        
                        this.DialogResult = DialogResult.Cancel;
                    }
                }
                else
                {
                    Helper.MsgBox("Email Settings not defined.", RadMessageIcon.Info);
                    this.DialogResult = DialogResult.Cancel;
                }



                
              


            }

        }

        private void SendCompletedCallback(object sender, AsyncCompletedEventArgs e)
        {
            
            
        }

        private bool ValidateInput()
        {
            this.errorMessage = string.Empty;

            if (txtEmail.Text.Trim() == string.Empty)
            {
                this.AddErrorMessage("Email Address Required.");
            }

            if (txtSubject.Text.Trim() == string.Empty)
            {
                this.AddErrorMessage("Email Subject Required.");
            }

            return this.errorMessage != string.Empty ? false : true;
        }
        /// <summary>
        /// To generate the error message
        /// </summary>
        /// <param name="error">error message</param>
        private void AddErrorMessage(string error)
        {
            if (this.errorMessage == string.Empty)
            {
                this.errorMessage = "Email Error:" + "\n\n";
            }

            this.errorMessage += error + "\n";
        }

        /// <summary>
        /// Method to show general error message on any system level exception
        /// </summary>
        private void ShowErrorMessage(Exception ex)
        {
            RadMessageBox.Show(
                ex.Message,
                //Resources.System_Error_Message, 
                "Email Report",
                MessageBoxButtons.OK,
                RadMessageIcon.Error);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
