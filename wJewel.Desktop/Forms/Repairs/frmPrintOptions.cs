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
    public partial class frmPrintOptions : Telerik.WinControls.UI.RadForm
    {
        private IOrderRepairService orderrepairService;

        string repairno;
        public frmPrintOptions()
        {
            
            InitializeComponent();
        }

        public frmPrintOptions(string p_repairno)
        {
            InitializeComponent();
            this.repairno = p_repairno;


        }

        private void radButton1_Click(object sender, EventArgs e)
        {

        }

        private void radButton1_Click_1(object sender, EventArgs e)
        {
            orderrepairService = new OrderRepairService();
           

            DataTable details = orderrepairService.GetOrderRepairData(this.repairno);
            DataView dvCustomer = new DataView(details);
            string sFilter = "1 = 1  ";
            ReportPrinting objReportPrinting = new ReportPrinting();
            Microsoft.Reporting.WinForms.ReportDataSource[] reportDataSourceCollection = new Microsoft.Reporting.WinForms.ReportDataSource[1];

            Microsoft.Reporting.WinForms.ReportParameter[] reportParameterCollection;

            reportDataSourceCollection[0] = new Microsoft.Reporting.WinForms.ReportDataSource();
            reportDataSourceCollection[0].Name = "DataSet1";
            reportDataSourceCollection[0].Value = dvCustomer;



            reportParameterCollection = new Microsoft.Reporting.WinForms.ReportParameter[1];
            reportParameterCollection[0] = new Microsoft.Reporting.WinForms.ReportParameter();
            reportParameterCollection[0].Name = "rpShowNotes";
            //reportParameterCollection[0].Values.Add(this.chkNotes.Checked ? "1" : "0");

            if (preview.IsChecked)
            {
                objReportPrinting.PrintReport("Customer List", "IshalInc.wJewel.Desktop.Forms.Reports.rptRepairOrder.rdlc", reportParameterCollection, reportDataSourceCollection, "Repair Order List");

            }
            if (print.IsChecked)
            {
                objReportPrinting.PrintReport("IshalInc.wJewel.Desktop.Forms.Reports.rptRepairOrder.rdlc", reportParameterCollection, reportDataSourceCollection);

            }
            if (email.IsChecked)
            {
                objReportPrinting.SendasEmail("IshalInc.wJewel.Desktop.Forms.Reports.rptRepairOrder.rdlc", reportParameterCollection, reportDataSourceCollection, string.Empty, string.Format("Repair Order List"));

            }
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown) return;

            switch (MessageBox.Show(this, "Are you sure you want to close?", "Closing", MessageBoxButtons.YesNo))
            {
                case DialogResult.No:
                    e.Cancel = true;
                    break;
                default:
                    //resetorderrepairsequent();
                    break;
            }
        }
        private void resetorderrepairsequent()
        {
            this.orderrepairService = new OrderRepairService();
            RepairorderModel RepairorderModel = new RepairorderModel();
            int currentrepno = Convert.ToInt32(this.repairno);
            RepairorderModel repairorderModel = new RepairorderModel()
            {
                REPAIR_NO = Convert.ToString(currentrepno)
            };
            this.orderrepairService.ResetSequence(repairorderModel);

        }

        private void radButton2_Click(object sender, EventArgs e)
        {
         
            this.Dispose();
        }

        private void radButton1_Click_2(object sender, EventArgs e)
        {
            orderrepairService = new OrderRepairService();
            //RepairorderModel RepairorderModel = new RepairorderModel();
            string currentrepno = repairno;

            DataTable details = orderrepairService.creatdatagridbasedonrepid(currentrepno);
            DataView dvCustomer = new DataView(details);
            string sFilter = "1 = 1  ";
            ReportPrinting objReportPrinting = new ReportPrinting();
            Microsoft.Reporting.WinForms.ReportDataSource[] reportDataSourceCollection = new Microsoft.Reporting.WinForms.ReportDataSource[1];

            Microsoft.Reporting.WinForms.ReportParameter[] reportParameterCollection;

            reportDataSourceCollection[0] = new Microsoft.Reporting.WinForms.ReportDataSource();
            reportDataSourceCollection[0].Name = "DataSet1";
            reportDataSourceCollection[0].Value = dvCustomer;



            reportParameterCollection = new Microsoft.Reporting.WinForms.ReportParameter[1];
            reportParameterCollection[0] = new Microsoft.Reporting.WinForms.ReportParameter();
            reportParameterCollection[0].Name = "rpShowNotes";
            //reportParameterCollection[0].Values.Add(this.chkNotes.Checked ? "1" : "0");

            if (preview.IsChecked)
            {
                objReportPrinting.PrintReport("Customer List", "IshalInc.wJewel.Desktop.Forms.Reports.rptRepairOrder.rdlc", reportParameterCollection, reportDataSourceCollection, "Repair Order List");

            }
            if (print.IsChecked)
            {
                objReportPrinting.PrintReport("IshalInc.wJewel.Desktop.Forms.Reports.rptRepairOrder.rdlc", reportParameterCollection, reportDataSourceCollection);

            }
            if (email.IsChecked)
            {
                objReportPrinting.SendasEmail("IshalInc.wJewel.Desktop.Forms.Reports.rptRepairOrder.rdlc", reportParameterCollection, reportDataSourceCollection, string.Empty, string.Format("Repair Order List"));

            }
        }

        private void radButton2_Click_1(object sender, EventArgs e)
        {

            this.Dispose();

        }
    }
}
