﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls;
using System.Windows.Forms;
using IshalInc.wJewel.Data.BusinessService;
using IshalInc.wJewel.Data.DataModel;
using IshalInc.wJewel.Desktop.Libraries;

namespace IshalInc.wJewel.Desktop.Forms
{
    public partial class frmStyleTrackingSlsInv : Telerik.WinControls.UI.RadForm
    {
        /// <summary>
        /// Interface of CustomerService
        /// </summary>
        private ISalesmenService salesmanService;
       

        private string output_type = "Preview";

        string retstyle, piece;
        bool isbar;

        public frmStyleTrackingSlsInv()
        {
          
            InitializeComponent();
            this.Icon = Helper.MakeIcon(IshalInc.wJewel.Desktop.Properties.Resources.element_add, 24, true);
            this.salesmanService = new SalesmenService();
            this.txtStyle.Focus();
            this.FormClosing += new FormClosingEventHandler(frmInvoice_FormClosing);

            this.btnOK.ButtonElement.ForeColor = Color.Green;
            this.btnOK.ButtonElement.ButtonFillElement.GradientStyle = GradientStyles.Gel;

            this.btnCancel.ButtonElement.ForeColor = Color.Red;
            this.btnCancel.ButtonElement.ButtonFillElement.GradientStyle = GradientStyles.Gel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtStyle.Text))
            {
                Helper.MsgBox("Please enter style.");
                this.txtStyle.Focus();
            }

            if (!Helper.CheckStyle(this.txtStyle.Text, out retstyle, out isbar, out piece))
            {
                Helper.MsgBox("Invalid Style.", RadMessageIcon.Info);
                this.txtStyle.Text = string.Empty;
                this.txtStyle.Focus();
                return;
            }

            if (!this.salesmanService.CheckSlsInvStyle(retstyle))
            {
                Helper.MsgBox("Style Is Not In Any Salesmen Inventory.", RadMessageIcon.Info);
                this.txtStyle.Text = string.Empty;
                this.txtStyle.Focus();
            }
            else
            {
               

                PrintReport();
            }
        }

        private void PrintReport()
        {
            DataTable dtStyleTrackingSlsInv = this.salesmanService.StyleTrackingSlsInv(retstyle);
            if (dtStyleTrackingSlsInv == null)
            {
                Helper.MsgBox("No Records Found");
                return;
            }

            if (dtStyleTrackingSlsInv.Rows.Count > 0)
            {

                string custemail = string.Empty;



                ReportPrinting objReportPrinting = new ReportPrinting();
                Microsoft.Reporting.WinForms.ReportDataSource[] reportDataSourceCollection = new Microsoft.Reporting.WinForms.ReportDataSource[1];

                Microsoft.Reporting.WinForms.ReportParameter[] reportParameterCollection;

                reportDataSourceCollection[0] = new Microsoft.Reporting.WinForms.ReportDataSource();
                reportDataSourceCollection[0].Name = "DataSet1";
                reportDataSourceCollection[0].Value = dtStyleTrackingSlsInv;

                reportParameterCollection = new Microsoft.Reporting.WinForms.ReportParameter[1];


                reportParameterCollection[0] = new Microsoft.Reporting.WinForms.ReportParameter();
                reportParameterCollection[0].Name = "rpTitle";
                reportParameterCollection[0].Values.Add(string.Format("Style Tracking by Salesman Inventory. Style: {0}", retstyle));


                Helper.PrintReport(objReportPrinting, "Style Tracking by Salesman Inventory", "IshalInc.wJewel.Desktop.Forms.Reports.rptStyleTrackingSlsInv.rdlc", this.output_type, reportDataSourceCollection, reportParameterCollection, custemail);


            }
            else
            {
                Helper.MsgBox("No Records Found.", Telerik.WinControls.RadMessageIcon.Info);
            }
        }


        private void frmInvoice_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
          
            this.Close();
        }
    }
}