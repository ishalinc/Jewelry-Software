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
    public partial class frmPotentialCustomerReport : Telerik.WinControls.UI.RadForm
    {
        IPotentialCustomerService potcustomerService;

        private string output_type = "Preview";

        public frmPotentialCustomerReport()
        {
            InitializeComponent();
            this.Icon = Helper.MakeIcon(IshalInc.wJewel.Desktop.Properties.Resources.report, 24, true);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            potcustomerService = new PotentialCustomerService();
            DataTable data = this.potcustomerService.GetAllCustomers();
            DataView dvCustomer = new DataView(data);
           // MessageBox.Show(this.txtState.Text);
            string sFilter = "1 = 1  ";
            //MessageBox.Show(this.txtState.Text);
            dvCustomer.RowFilter = sFilter;
            if (!string.IsNullOrEmpty(this.txtState.Text))
                sFilter = sFilter + string.Format(" AND (STATE1 = '{0}' OR STATE1 = '{0}')", this.txtState.Text);
            if (!string.IsNullOrEmpty(this.txtCountry.Text))
                sFilter = sFilter + string.Format(" AND (COUNTRY = '{0}' OR COUNTRY = '{0}')", this.txtCountry.Text);

            if (!string.IsNullOrEmpty(this.txtSalesman.Text))
                sFilter = sFilter + string.Format(" AND (SALESMAN1 = '{0}' OR SALESMAN1 = '{0}' )", this.txtSalesman.Text);

            dvCustomer.RowFilter = sFilter;

            ReportPrinting objReportPrinting = new ReportPrinting();
            Microsoft.Reporting.WinForms.ReportDataSource[] reportDataSourceCollection = new Microsoft.Reporting.WinForms.ReportDataSource[1];

            Microsoft.Reporting.WinForms.ReportParameter[] reportParameterCollection;

            reportDataSourceCollection[0] = new Microsoft.Reporting.WinForms.ReportDataSource();
            reportDataSourceCollection[0].Name = "DataSet1";
            reportDataSourceCollection[0].Value = dvCustomer;



            reportParameterCollection = new Microsoft.Reporting.WinForms.ReportParameter[1];
            reportParameterCollection[0] = new Microsoft.Reporting.WinForms.ReportParameter();
            reportParameterCollection[0].Name = "rpShowNotes";
           
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

            Helper.PrintReport(objReportPrinting, "Adj. Receipt Print", "IshalInc.wJewel.Desktop.Forms.Reports.rptPotentialCusomer.rdlc", result, reportDataSourceCollection, reportParameterCollection, string.Empty);

           
        }
    }
}
