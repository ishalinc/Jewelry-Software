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

namespace IshalInc.wJewel.Desktop.Forms
{
    public partial class frmCustomerReport : RadForm
    {
        private ICustomerService customerService;

        private string output_type = "Preview";
        public frmCustomerReport()
        {
            InitializeComponent();
            this.btnOK.ButtonElement.ForeColor = Color.Green;
//            this.btnOK.ButtonElement.ButtonFillElement.GradientStyle = GradientStyles.Gel;

            this.btnCancel.ButtonElement.ForeColor = Color.Red;
//            this.btnCancel.ButtonElement.ButtonFillElement.GradientStyle = GradientStyles.Gel;

            this.Icon = Helper.MakeIcon(IshalInc.wJewel.Desktop.Properties.Resources.report, 24, true);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.customerService = new CustomerService();
            DataTable data = this.customerService.GetAllCustomers();

            DataView dvCustomer = new DataView(data);

            string sFilter = "1 = 1  ";
            //Bill Account Filter
            if (this.chkBillAccountOnly.Checked)
                sFilter = sFilter + string.Format(" AND ACC = BILL_ACC");
            //Customer Sent to Collection Filter
            if (this.chkCustSenttoCollection.Checked)
                sFilter = sFilter + string.Format(" AND COLCDATE is not Null");
            //Customer On Hold Filter
            if (this.chkCustomerOnHold.Checked)
                sFilter = sFilter + string.Format(" AND ISNULL(ON_HOLD,0) > 0");
            if (!string.IsNullOrEmpty(this.txtState.Text))
                sFilter = sFilter + string.Format(" AND (STATE1 = '{0}' OR STATE2 = '{0}')", this.txtState.Text);
            if (!string.IsNullOrEmpty(this.txtCountry.Text))
                sFilter = sFilter + string.Format(" AND (COUNTRY = '{0}' OR COUNTRY2 = '{0}')", this.txtCountry.Text);

            if (!string.IsNullOrEmpty(this.txtSalesman.Text))
                sFilter = sFilter + string.Format(" AND (SALESMAN1 = '{0}' OR SALESMAN2 = '{0}' OR SALESMAN3 = '{0}' OR SALESMAN4 = '{0}')", this.txtSalesman.Text);


            dvCustomer.RowFilter = sFilter;
            if (this.rdoSortCustomerCode.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
                dvCustomer.Sort = "ACC ASC";
            else
                dvCustomer.Sort = "NAME ASC";


            ReportPrinting objReportPrinting = new ReportPrinting();
            Microsoft.Reporting.WinForms.ReportDataSource[] reportDataSourceCollection = new Microsoft.Reporting.WinForms.ReportDataSource[1];

            Microsoft.Reporting.WinForms.ReportParameter[] reportParameterCollection;

            reportDataSourceCollection[0] = new Microsoft.Reporting.WinForms.ReportDataSource();
            reportDataSourceCollection[0].Name = "DataSet1";
            reportDataSourceCollection[0].Value = dvCustomer;



            reportParameterCollection = new Microsoft.Reporting.WinForms.ReportParameter[1];
            reportParameterCollection[0] = new Microsoft.Reporting.WinForms.ReportParameter();
            reportParameterCollection[0].Name = "rpShowNotes";
            reportParameterCollection[0].Values.Add(this.chkNotes.Checked ? "1" : "0");


            Helper.PrintReport(objReportPrinting, "Customer List", "IshalInc.wJewel.Desktop.Forms.Reports.rptCustomerList.rdlc", this.output_type, reportDataSourceCollection, reportParameterCollection, string.Empty);
        
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmCustomerReport_Load(object sender, EventArgs e)
        {

        }

        private void radRadioButton1_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            string result = null;
            foreach (Control control in this.radGroupBox2.Controls)
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
                    this.output_type = result;
                    break;
                case "Print":
                    this.output_type = result;
                    break;
                case "Email":
                    this.output_type = result;
                    break;
                default:
                    break;

            }
        }
    }
}
