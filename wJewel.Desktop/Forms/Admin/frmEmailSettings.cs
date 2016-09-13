using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using IshalInc.wJewel.Data.BusinessService;
using IshalInc.wJewel.Data.DataModel;
using IshalInc.wJewel.Desktop.Properties;
using IshalInc.wJewel.Desktop.Libraries;

namespace IshalInc.wJewel.Desktop.Forms
{
    public partial class frmEmailSettings : Telerik.WinControls.UI.RadForm
    {
        public frmEmailSettings()
        {
            InitializeComponent();
            this.Icon = Helper.MakeIcon(IshalInc.wJewel.Desktop.Properties.Resources.mail, 24, true);
            LoadData();
        }

        private void LoadData()
        {
            DataTable dtEmailSettings = Helper.GetEmailSettings();
            if (dtEmailSettings.Rows.Count == 0)
                dtEmailSettings.Rows.Add();
            this.txtEmail.Text = dtEmailSettings.Rows[0]["Email"].ToString();
            this.txtPassword.Text = dtEmailSettings.Rows[0]["Password"].ToString();
            this.txtPort.Value = dtEmailSettings.Rows[0]["SmtpPort"] == DBNull.Value ? 25 : Convert.ToInt32(dtEmailSettings.Rows[0]["SmtpPort"].ToString());
            this.txtSmtpServer.Text = dtEmailSettings.Rows[0]["SmtpServer"] ==  DBNull.Value ? "" : Convert.ToString(dtEmailSettings.Rows[0]["SmtpServer"].ToString());
            this.chkUseSsl.Checked = dtEmailSettings.Rows[0]["UseSsl"] == DBNull.Value ? false : (bool)dtEmailSettings.Rows[0]["UseSsl"];

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = RadMessageBox.Show("Are you sure you want to cancel the changes?", "Add / Edit Customer", MessageBoxButtons.YesNo, RadMessageIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Helper.UpdateEmailSettings(this.txtEmail.Text, this.txtPassword.Text, Convert.ToInt32(this.txtPort.Value), this.txtSmtpServer.Text, this.chkUseSsl.Checked))
            {
                Helper.MsgBox("Settings Saved Successfully.", RadMessageIcon.Info);
                this.Close();
            }
            
        }
    }
}
