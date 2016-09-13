using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using IshalInc.wJewel.Data.BusinessService;
using IshalInc.wJewel.Data.DataModel;
using IshalInc.wJewel.Desktop.Libraries;
using IshalInc.wJewel.Desktop.Properties;
using Telerik.WinControls.UI;
using System.Threading;
using Telerik.WinControls;
using Microsoft.Reporting.WinForms;

namespace IshalInc.wJewel.Desktop.Forms
{
    public partial class frmInvoiceReport : Telerik.WinControls.UI.RadForm
    {
        private IInvoiceService invoiceService;

        private static int startpoint =0;
        /// <summary>
        /// Interface of CustomerService
        /// </summary>
        private ICustomerService customerService;

        private string invno;
        private string customerAcc;
        private bool is_deb = true;
        private bool is_inv = true;
        private string output_type = "Preview";
        private DataTable dtSubReport = null;
        public frmInvoiceReport()
        {
          
            this.Icon = Helper.MakeIcon(IshalInc.wJewel.Desktop.Properties.Resources.invoicereport, 24, true);
            InitializeComponent();

            this.btnPrint.ButtonElement.ForeColor = Color.Green;
            this.btnPrint.ButtonElement.ButtonFillElement.GradientStyle = GradientStyles.Gel;

            this.btnCancel.ButtonElement.ForeColor = Color.Red;
            this.btnCancel.ButtonElement.ButtonFillElement.GradientStyle = GradientStyles.Gel;
        }

        public frmInvoiceReport(string pinvno, string acc,bool isdeb = true, bool isinv = true)
        {
           
            this.invno = pinvno;
            this.customerAcc = acc;
            this.is_deb = isdeb;
            this.is_inv = isinv;
            InitializeComponent();
            this.chkPrintImages.Visible = !this.is_deb;
            this.customerService = new CustomerService();
            this.Icon = Helper.MakeIcon(IshalInc.wJewel.Desktop.Properties.Resources.invoicereport, 24, true);
            this.txtNoofCopies.Value = 3;

            this.btnPrint.ButtonElement.ForeColor = Color.Green;
            this.btnPrint.ButtonElement.ButtonFillElement.GradientStyle = GradientStyles.Gel;

            this.btnCancel.ButtonElement.ForeColor = Color.Red;
            this.btnCancel.ButtonElement.ButtonFillElement.GradientStyle = GradientStyles.Gel;
        }

        
       

        private void PrintReport()
        {
            this.invoiceService = new InvoiceService();
            DataTable data;
            string reportName,sSubtotal;
            if (this.is_deb)
            {
                data = this.invoiceService.GetInvoiceMasterDetail(this.invno);
                reportName = "IshalInc.wJewel.Desktop.Forms.Reports.rptInvoice.rdlc";
            }
            else
            {
               
                data = this.invoiceService.GetInvoiceMasterDetailPO(this.invno);
                if (this.chkPrintImages.Checked)
                    reportName = "IshalInc.wJewel.Desktop.Forms.Reports.rptPOInvoiceImages.rdlc";
                else
                    reportName = "IshalInc.wJewel.Desktop.Forms.Reports.rptPOInvoice.rdlc";
            }
            string fmessage;
            if (!is_inv)
            {

                fmessage = @"Please Report within 5 days any discrepancies in contents, price or quality. All colored stones are treated as per AGTA/industry standards.
                          This agreement is a secured transaction under the U.C.C. The goods described and valued as above are delivered to you for EXAMINATION AND INSPECTION ONLY and are the property of {0}
                          The merchandise is subject to their order and shall be returned to them on demand.
                          Sales take effect and title will pass only if and when we shall have rendered a bill of sale therefore, it being
                          understood that such bill of sale will be rendered only at our option. This merchandise after being received by you, until receipted for by us, is at your
                          own risk against any loss or damage of any kind whatsoever, whether caused by your neligence or not. Any previous transaction with you has not established a precedent, this being a new and separate transaction.
                          All our diamonds are from legitimate sources not involved in funding conflict and in compliance with United Nations resoloutions.
                          We hereby guarantee that the diamonds are conflict free, based on personal knowledge and/or written guarantees.";

            }
            else
            {
                fmessage = @"All our diamonds are from legitimate sources not involved in funding conflict and in compliance with United Nations resoloutions. We hereby guarantee that the diamonds are conflict free, based on personal knowlege and/or written guarantees.";
            }

            DataView dvInvoice = new DataView(data);

            if (dvInvoice.Count > 0)
            {

               
                if (this.chkPrintImages.Checked)
                {
                    int ImagesPerRow = 8;
                    dtSubReport = new DataTable();
                    dtSubReport.TableName = "GetImage";
                    dtSubReport.Columns.Add("RowId", typeof(int));
                    dtSubReport.Columns.Add("ColId", typeof(int));
                    dtSubReport.Columns.Add("Imagename", typeof(string));
                    dtSubReport.Columns.Add("Style", typeof(string));
                    decimal rowctr = 1;
                    foreach (DataRowView rowView in dvInvoice)
                    {
                        DataRow row = rowView.Row;
                        dtSubReport.Rows.Add(Math.Ceiling(rowctr/ ImagesPerRow), rowctr % ImagesPerRow == 0 ? ImagesPerRow : rowctr % ImagesPerRow, Helper.GetImage(row["Style"].ToString()), row["Style"].ToString());
                        rowctr++;
                    }
                    

                }
                string custemail = this.customerService.GetEmail(this.customerAcc);
                ReportPrinting objReportPrinting = new ReportPrinting();
                Microsoft.Reporting.WinForms.ReportDataSource[] reportDataSourceCollection = new Microsoft.Reporting.WinForms.ReportDataSource[1];

                Microsoft.Reporting.WinForms.ReportParameter[] reportParameterCollection;

                reportDataSourceCollection[0] = new Microsoft.Reporting.WinForms.ReportDataSource();
                reportDataSourceCollection[0].Name = "DataSet1";
                reportDataSourceCollection[0].Value = dvInvoice;

              

                string billingLabel, shippingLabel;
                if (this.is_deb)
                    shippingLabel = string.Format("{0}\n{1}\n{2}\n{3} {4} {5} {6}", dvInvoice[0]["name"].ToString().Trim(), dvInvoice[0]["addr1"].ToString().Trim(), dvInvoice[0]["addr2"].ToString().Trim(), dvInvoice[0]["city"].ToString().Trim(), dvInvoice[0]["state"].ToString().Trim(), dvInvoice[0]["zip"].ToString().Trim(), dvInvoice[0]["country"].ToString().Trim()).Replace("\n\n", "\n");
                else
                    shippingLabel = string.Format("{0}\n{1}\n{2}\n{3} {4} {5} {6}\n{7}\n{8}", dvInvoice[0]["name"].ToString().Trim(), dvInvoice[0]["addr1"].ToString().Trim(), dvInvoice[0]["addr2"].ToString().Trim(), dvInvoice[0]["city"].ToString().Trim(), dvInvoice[0]["state"].ToString().Trim(), dvInvoice[0]["zip"].ToString().Trim(), dvInvoice[0]["country"].ToString().Trim(), !string.IsNullOrEmpty(dvInvoice[0]["buyer"].ToString().Trim()) ? "Attn:" + dvInvoice[0]["buyer"].ToString().Trim() : string.Empty, !string.IsNullOrEmpty(dvInvoice[0]["tel"].ToString().Trim()) ? "Tel:" + dvInvoice[0]["tel"].ToString().Trim() : string.Empty).Replace("\n\n", "\n");
                

                billingLabel = string.Format("{0}\n{1}\n{2}\n{3} {4} {5} {6}", dvInvoice[0]["cname"].ToString().Trim(), dvInvoice[0]["caddr1"].ToString().Trim(), dvInvoice[0]["caddr2"].ToString().Trim(), dvInvoice[0]["ccity"].ToString().Trim(), dvInvoice[0]["cstate"].ToString().Trim(), dvInvoice[0]["czip"].ToString().Trim(), dvInvoice[0]["ccountry"].ToString().Trim()).Replace("\n\n", "\n");

               

                string sOtherCharges = string.Format("{0:C}", Convert.ToDecimal(dvInvoice[0]["add_cost"]));
                string sShipAndHandling = string.Format("{0:C}", Convert.ToDecimal(dvInvoice[0]["snh"]));
                string sGrandTotal = string.Format("{0:C}", Convert.ToDecimal(dvInvoice[0]["gr_total"]));
                string sDeduction = string.Format("{0:C}", Convert.ToDecimal(dvInvoice[0]["deduction"]));
                string sShipBy = Helper.ShipBy(dvInvoice[0]["ship_by"].ToString().Trim());
                if (this.is_deb)
                    sSubtotal = string.Format("{0:C}", dvInvoice.Table.Compute("SUM(Price)", "1=1") == DBNull.Value ? 0 : dvInvoice.Table.Compute("SUM(Price)", "1=1"));
                else
                    sSubtotal = string.Format("{0:C}", dvInvoice.Table.Compute("SUM(Amount)", "1=1") == DBNull.Value ? 0 : dvInvoice.Table.Compute("SUM(Amount)", "1=1"));

                string sTerm = string.Empty;

                if (dvInvoice[0]["is_cod"].ToString().Trim() == "Y")
                    sTerm = "COD";
                else if (Convert.ToDecimal(dvInvoice[0]["term_pct1"]) == 100)
                    sTerm = "NET " + dvInvoice[0]["term1"].ToString().Trim() + " DAYS";
                else
                    for (int ctr = 1; ctr <= 8; ctr++)
                    {
                        if (Convert.ToDecimal(dvInvoice[0]["term_pct" + ctr.ToString()]) > 0)
                            sTerm += string.Format("{0},",dvInvoice[0]["term" + ctr.ToString()].ToString());
                    }

                sTerm = sTerm.Trim(new char[] { ',' });

                reportParameterCollection = new Microsoft.Reporting.WinForms.ReportParameter[14];
                reportParameterCollection[0] = new Microsoft.Reporting.WinForms.ReportParameter();
                reportParameterCollection[0].Name = "rpBillingLabel";
                reportParameterCollection[0].Values.Add(billingLabel);


                reportParameterCollection[1] = new Microsoft.Reporting.WinForms.ReportParameter();
                reportParameterCollection[1].Name = "rpShippingLabel";
                reportParameterCollection[1].Values.Add(shippingLabel);



                reportParameterCollection[2] = new Microsoft.Reporting.WinForms.ReportParameter();
                reportParameterCollection[2].Name = "rpOtherCharges";
                reportParameterCollection[2].Values.Add(sOtherCharges);

                reportParameterCollection[3] = new Microsoft.Reporting.WinForms.ReportParameter();
                reportParameterCollection[3].Name = "rpSANDH";
                reportParameterCollection[3].Values.Add(sShipAndHandling);

                reportParameterCollection[4] = new Microsoft.Reporting.WinForms.ReportParameter();
                reportParameterCollection[4].Name = "rpSubtotal";
                reportParameterCollection[4].Values.Add(sSubtotal);


                reportParameterCollection[5] = new Microsoft.Reporting.WinForms.ReportParameter();
                reportParameterCollection[5].Name = "rpGrandTotal";
                reportParameterCollection[5].Values.Add(sGrandTotal);

                reportParameterCollection[6] = new Microsoft.Reporting.WinForms.ReportParameter();
                reportParameterCollection[6].Name = "rpShipBy";
                reportParameterCollection[6].Values.Add(sShipBy);

                reportParameterCollection[7] = new Microsoft.Reporting.WinForms.ReportParameter();
                reportParameterCollection[7].Name = "rpTerms";
                reportParameterCollection[7].Values.Add(sTerm);

                reportParameterCollection[8] = new Microsoft.Reporting.WinForms.ReportParameter();
                reportParameterCollection[8].Name = "rpMyName";
                reportParameterCollection[8].Values.Add(Helper.CompanyName);

                reportParameterCollection[9] = new Microsoft.Reporting.WinForms.ReportParameter();
                reportParameterCollection[9].Name = "rpAddr1";
                reportParameterCollection[9].Values.Add(Helper.CompanyAddr1);

                reportParameterCollection[10] = new Microsoft.Reporting.WinForms.ReportParameter();
                reportParameterCollection[10].Name = "rpAddr2";
                reportParameterCollection[10].Values.Add(Helper.CompanyAddr2);

                reportParameterCollection[11] = new Microsoft.Reporting.WinForms.ReportParameter();
                reportParameterCollection[11].Name = "rpTel";
                reportParameterCollection[11].Values.Add(Helper.CompanyTel);

                reportParameterCollection[12] = new Microsoft.Reporting.WinForms.ReportParameter();
                reportParameterCollection[12].Name = "rpDeduction";
                reportParameterCollection[12].Values.Add(sDeduction);

                reportParameterCollection[13] = new Microsoft.Reporting.WinForms.ReportParameter();
                reportParameterCollection[13].Name = "rpMessage";
                reportParameterCollection[13].Values.Add(fmessage);

                string subReportname = "IshalInc.wJewel.Desktop.Forms.Reports.rptInvoicePOImageSR.rdlc";
                string subReportIdName = "rptInvoicePOImageSR";

                objReportPrinting.report.SubreportProcessing += new SubreportProcessingEventHandler(localReport_SubreportProcessing);
                objReportPrinting.reportViewer.LocalReport.SubreportProcessing += new SubreportProcessingEventHandler(localReport_SubreportProcessing);


                Helper.PrintReport(objReportPrinting, "Adj. Receipt Print", reportName, this.output_type, reportDataSourceCollection, reportParameterCollection, subReportname, subReportIdName, custemail);

               
                startpoint = 0;
            }
        }

        private void localReport_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
        {
            if (dtSubReport.Rows.Count > 0)
            { 
                foreach (ReportDataSource rptSrc in e.DataSources)
                {
                    e.DataSources.Remove(rptSrc);
                }
                var mainSource = ((LocalReport)sender).DataSources["Dataset1"];


                int count = Convert.ToInt32(e.Parameters["Dummy"].Values[0].ToString());

                DataTable dtRows = dtSubReport.AsEnumerable().Skip(startpoint).Take(count).CopyToDataTable();
                startpoint = startpoint + count;


                ReportDataSource subreportDataSourceCollection = new Microsoft.Reporting.WinForms.ReportDataSource();
                subreportDataSourceCollection.Name = "DataSet1";
                subreportDataSourceCollection.Value = dtRows;
                e.DataSources.Add(subreportDataSourceCollection);
            }
            else
            {
                ReportDataSource subreportDataSourceCollection = new Microsoft.Reporting.WinForms.ReportDataSource();
                subreportDataSourceCollection.Name = "DataSet1";
                subreportDataSourceCollection.Value = null;
                e.DataSources.Add(subreportDataSourceCollection);
            }

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintReport();

        }


        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radRadioButton1_Click(object sender, EventArgs e)
        {

        }

        private void radRadioButton1_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            string result = null;
            foreach (Control control in this.radGroupBox1.Controls)
            {
                if (control is RadRadioButton)
                {
                    RadRadioButton radio = control as RadRadioButton;
                    if (radio.IsChecked)
                    {
                        result = radio.Text;
                    }
                }
            }
            bool isvisible = false;
            switch (result)
            {
                case "Preview":
                    isvisible = false;
                    this.output_type = result;
                    break;
                case "Print":
                    isvisible = true;
                    this.output_type = result;
                    break;
                case "Email":
                    isvisible = false;
                    this.output_type = result;
                    break;
                default:
                    break;

            }
            this.txtNoofCopies.Visible = isvisible;
            this.lblCopies.Visible = isvisible;
        }
    }
}
