using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Telerik.WinControls.UI;
using System.Windows.Forms;
using IshalInc.wJewel.Data.BusinessService;
using IshalInc.wJewel.Data.DataModel;
using IshalInc.wJewel.Desktop.Libraries;
using IshalInc.wJewel.Desktop.Properties;

namespace IshalInc.wJewel.Desktop.Forms
{
    public partial class frmRepairOrdersReport : Telerik.WinControls.UI.RadForm
    {
        private IOrderRepairService orderrepairService;

        string repairno;

        private DataRow custRow;

        private DataView dvCustomerSearch;
        public frmRepairOrdersReport()
        {
            InitializeComponent();
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            orderrepairService = new OrderRepairService();


            DataTable data = orderrepairService.GetItemsFromBothTables();
            dvCustomerSearch = new DataView(data);
            dvCustomerSearch.RowFilter = "1=0";
            string sFilter = "1=1";
            if (!string.IsNullOrEmpty(this.repairnumber.Text))
            {
                sFilter += string.Format(" AND {0} = '{1}'", "REPAIR_NO", this.repairnumber.Text.Trim());
            }
            if(!string.IsNullOrEmpty(this.customercode.Text))
            {
                sFilter += string.Format(" AND {0} = '{1}'", "ACC", this.customercode.Text.Trim());
            }
            if (!string.IsNullOrEmpty(this.customerrepairnumber.Text))
            {
                sFilter += string.Format(" AND {0} = '{1}'", "CUS_REP_NO", this.customerrepairnumber.Text.Trim());
            }
            if (!string.IsNullOrEmpty(this.fromcustomercode.Text) || !string.IsNullOrEmpty(this.tocustomercode.Text))
            {
                sFilter += string.Format(" AND ({0} >= '{1}' AND {0} <= '{2}')", "ACC", this.fromcustomercode.Text.Trim(), this.tocustomercode.Text.Trim());
            }
            if (!string.IsNullOrEmpty(this.fromdate.Text) || !string.IsNullOrEmpty(this.todate.Text))
            {
                //Format(repair.DATE,'MM/dd/yyyy')
                sFilter += string.Format(" AND ({0} >= '{1}' AND {0} <= '{2}')", "DATE", Convert.ToDateTime(this.fromdate.Text.Trim()), Convert.ToDateTime(this.todate.Text.Trim()));
            }
            if (!string.IsNullOrEmpty(this.fromrepairorderno.Text) || !string.IsNullOrEmpty(this.torepairorderno.Text))
            {
                sFilter += string.Format(" AND ({0} >= {1} AND {0} <= {2})", "REPAIR_NO", this.fromrepairorderno.Text.Trim(), this.torepairorderno.Text.Trim());
            }
            if (this.openordersonly.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
                sFilter += string.Format(" AND {0} = '{1}'", "OPEN", "0");


            dvCustomerSearch.RowFilter = sFilter;
            if (this.sortbystyleno.ToggleState == Telerik.WinControls.Enumerations.ToggleState.On)
                dvCustomerSearch.Sort = "ITEM ASC";
            
            if(dvCustomerSearch.Count == 0)
            {
                MessageBox.Show("Items Not Found.");
                return;
            }
            string printoptheader = "RepairOrderList";
            string printoptfile = "rptListOfRepairOrders.rdlc";
            if (!string.IsNullOrEmpty(this.repairnumber.Text) || !string.IsNullOrEmpty(this.customercode.Text) || !string.IsNullOrEmpty(this.customerrepairnumber.Text))
            {
                printoptheader = "Repair Order List";
                printoptfile = "rptRepairOrder.rdlc";
            }

            ReportPrinting objReportPrinting = new ReportPrinting();
            Microsoft.Reporting.WinForms.ReportDataSource[] reportDataSourceCollection = new Microsoft.Reporting.WinForms.ReportDataSource[1];

            Microsoft.Reporting.WinForms.ReportParameter[] reportParameterCollection;

            reportDataSourceCollection[0] = new Microsoft.Reporting.WinForms.ReportDataSource();
            reportDataSourceCollection[0].Name = "DataSet1";
            reportDataSourceCollection[0].Value = dvCustomerSearch;



            reportParameterCollection = new Microsoft.Reporting.WinForms.ReportParameter[1];
            reportParameterCollection[0] = new Microsoft.Reporting.WinForms.ReportParameter();
            reportParameterCollection[0].Name = "rpShowNotes";

            if (preview.IsChecked)
            {
                objReportPrinting.PrintReport("Customer List", "IshalInc.wJewel.Desktop.Forms.Reports."+ printoptfile, reportParameterCollection, reportDataSourceCollection, printoptheader);

            }
            else if (print.IsChecked)
            {
                objReportPrinting.PrintReport("IshalInc.wJewel.Desktop.Forms.Reports." + printoptfile, reportParameterCollection, reportDataSourceCollection);

            }
            else if (email.IsChecked)
            {
                objReportPrinting.SendasEmail("IshalInc.wJewel.Desktop.Forms.Reports." + printoptfile, reportParameterCollection, reportDataSourceCollection, string.Empty, string.Format(printoptheader));

            }
            else
                MessageBox.Show("Select Option To View Output File");
        }

        private void fromcustomercode_TextChanged(object sender, EventArgs e)
        {
           // MessageBox.Show("hemanth");
        }

        private void fromcustomercode_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(this.fromcustomercode.Text))
                tocustomercode.Text = fromcustomercode.Text;

        }

        private void fromdate_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(this.fromdate.Text))
                todate.Text = fromdate.Text;
        }

        private void fromrepairorderno_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(this.fromrepairorderno.Text))
                torepairorderno.Text = fromrepairorderno.Text;
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
