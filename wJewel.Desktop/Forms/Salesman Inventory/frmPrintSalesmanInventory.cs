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
using Telerik.WinControls;
using Telerik.WinControls.UI;
using System.Threading;
using Microsoft.Reporting.WinForms;



namespace IshalInc.wJewel.Desktop.Forms
{
    public partial class frmPrintSalesmanInventory : Telerik.WinControls.UI.RadForm
    {
        private ISalesmenService salesmenService;

       
        private ICustomerService customerService;
        private string output_type = "Preview";
        private DataTable dtSubReport = null;
        List<ListViewDataItem> selectedItems = new List<ListViewDataItem>();
        public frmPrintSalesmanInventory()
        {
          
            this.Icon = Helper.MakeIcon(IshalInc.wJewel.Desktop.Properties.Resources.invoicereport, 24, true);
            InitializeComponent();
           
            customerService = new CustomerService();
            this.salesmenService = new SalesmenService();

            this.radListView1.Items.Add("WHO?");
            foreach (DataRow drSalesmen in salesmenService.GetSalesmenCodes().Rows)
            {
                this.radListView1.Items.Add(drSalesmen["code"].ToString());
            }

            this.btnPrint.ButtonElement.ForeColor = Color.Green;
            this.btnPrint.ButtonElement.ButtonFillElement.GradientStyle = GradientStyles.Gel;

            this.btnCancel.ButtonElement.ForeColor = Color.Red;
            this.btnCancel.ButtonElement.ButtonFillElement.GradientStyle = GradientStyles.Gel;
        }

             

        private void PrintReport()
        {

           if (string.IsNullOrEmpty(txtFromStyle.Text))
            {
                Helper.MsgBox("Please Enter Style");
            }
           else
            {
                if (string.IsNullOrEmpty(txtToStyle.Text))
                {
                    txtToStyle.Text = txtFromStyle.Text;
                }
            }

            string salesmen = string.Empty;
            foreach (ListViewDataItem item in this.radListView1.SelectedItems)
            {
                salesmen += item.Text + ",";
            }

            salesmen = salesmen.Trim(',');

            DataTable data = this.salesmenService.GetSalesmanInvByLineAndStyle(salesmen,this.txtFromStyle.Text,this.txtToStyle.Text,Convert.ToDecimal(txtAmount.Value));

            DataView dvSalesmanInv = new DataView(data);

            if (dvSalesmanInv.Count > 0)
            {

                string custemail = string.Empty;

                ReportPrinting objReportPrinting = new ReportPrinting();
                Microsoft.Reporting.WinForms.ReportDataSource[] reportDataSourceCollection = new Microsoft.Reporting.WinForms.ReportDataSource[1];

                Microsoft.Reporting.WinForms.ReportParameter[] reportParameterCollection;

                reportDataSourceCollection[0] = new Microsoft.Reporting.WinForms.ReportDataSource();
                reportDataSourceCollection[0].Name = "DataSet1";
                reportDataSourceCollection[0].Value = dvSalesmanInv;

                reportParameterCollection = new Microsoft.Reporting.WinForms.ReportParameter[1];
                reportParameterCollection[0] = new Microsoft.Reporting.WinForms.ReportParameter();
                reportParameterCollection[0].Name = "ShowPrice";
                reportParameterCollection[0].Values.Add(this.radShowPrice.IsChecked ? "1" :  "0");

                Helper.PrintReport(objReportPrinting, "Print Salesman Inventory", "IshalInc.wJewel.Desktop.Forms.Reports.rptSalesmanInvByLineAndStyle.rdlc", this.output_type, reportDataSourceCollection, reportParameterCollection, custemail);

            }
            else
            {
                Helper.MsgBox("No records found", Telerik.WinControls.RadMessageIcon.Info);
            }
        }


        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintReport();
            this.DialogResult = DialogResult.OK;
        }


        
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.OK;
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
           
        }

       

        private void txtBillingAcctNo_Validated(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtFromStyle.Text))
            {
                DataRow billAcctRow = this.customerService.CheckValidBillingAcct(this.txtFromStyle.Text);
                if (billAcctRow == null)
                {
                    Helper.MsgBox("Invalid Billing Account", Telerik.WinControls.RadMessageIcon.Info);
                    return;
                }
             
            }
        }

        private void frmCreditByCreditCode_Load(object sender, EventArgs e)
        {

        }

        private void radCheckBox1_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            this.txtFromStyle.Enabled = !this.chkAllStyles.Checked;
            this.txtToStyle.Enabled = !this.chkAllStyles.Checked;
            if (this.chkAllStyles.Checked)
            {
                this.txtFromStyle.Text = "0";
                this.txtToStyle.Text = "ZZ";
            }
        }

        private void txtFromCustomerCode_Validated(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtFromStyle.Text) && string.IsNullOrEmpty(this.txtToStyle.Text))
            {
                this.txtToStyle.Text = this.txtFromStyle.Text;
            }
        }

        private void chkAllSalesman_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            if (chkAllSalesman.Checked)
            {
                foreach (ListViewDataItem item in radListView1.Items)
                {
                    selectedItems.Add(item);
                }
                radListView1.Select(selectedItems.ToArray());
            }
            else
            {
                radListView1.SelectedItems.Clear();
            }
        }

        private void radListView1_ItemMouseClick(object sender, ListViewItemEventArgs e)
        {
            if (selectedItems.Contains(e.Item))
            {
                selectedItems.Remove(e.Item);
            }
            else
            {
                selectedItems.Add(e.Item);
            }
            radListView1.SelectedItems.Clear();
            radListView1.Select(selectedItems.ToArray());
        }
    }
}
