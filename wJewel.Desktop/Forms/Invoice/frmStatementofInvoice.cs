using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Telerik.WinControls.UI;
using Telerik.WinControls;
using System.Windows.Forms;
using IshalInc.wJewel.Data.BusinessService;
using IshalInc.wJewel.Data.DataModel;
using IshalInc.wJewel.Desktop.Libraries;
using IshalInc.wJewel.Desktop.Properties;

namespace IshalInc.wJewel.Desktop.Forms
{
    public partial class frmStatementofInvoice : Telerik.WinControls.UI.RadForm
    {
        /// <summary>
        /// Interface of CustomerService
        /// </summary>
        private ICustomerService customerService;

        /// <summary>
        /// Interface of InvoiceItemSerrvice
        /// </summary>
        /// 
        private IInvoiceService invoiceService;

        private DataRow invoiceRow;

        private DataRow custRow;

        private DataView dvStatementOfInvoice;

        private string InvoiceNo;

        private string customerAcc;

        private string output_type = "Preview";
        public frmStatementofInvoice()
        {
            InitializeComponent();
            this.Icon = Helper.MakeIcon(IshalInc.wJewel.Desktop.Properties.Resources.soi, 24, true);
            this.invoiceService = new InvoiceService();
            this.dateFrom.Value = DateTime.Now;
            this.dateTo.Value = DateTime.Now;

            this.customerService = new CustomerService();
            DataTable data = this.invoiceService.GetStatementofInvoice();
            dvStatementOfInvoice = new DataView(data);
            dvStatementOfInvoice.RowFilter = "1=0";
            this.txtAmount2.Text = string.Empty;
            this.LoadDataGridView(dvStatementOfInvoice);

            this.btnEdit.ButtonElement.ForeColor = Color.Green;
            this.btnEdit.ButtonElement.ButtonFillElement.GradientStyle = GradientStyles.Gel;

            this.btnCancel.ButtonElement.ForeColor = Color.Red;
            this.btnCancel.ButtonElement.ButtonFillElement.GradientStyle = GradientStyles.Gel;
        }

        // <summary>
        /// Method to load data grid view
        /// </summary>
        /// <param name="data">data table</param>
        private void LoadDataGridView(DataView data)
        {
            // Data grid view column setting      

            
            radGridView1.DataSource = data;
            //radGridView1.DataMember = data.TableName;
            radGridView1.Columns[0].Width = 50;
            radGridView1.Columns[1].Width = 50;
            radGridView1.Columns[2].Width = 50;
            radGridView1.Columns[3].Width = 50;
            radGridView1.Columns[4].Width = 50;
            radGridView1.Columns[5].Width = 50;
            radGridView1.Columns[6].Width = 50;
            radGridView1.Columns[7].Width = 50;
            radGridView1.Columns[8].Width = 50;
            radGridView1.Columns[9].Width = 50;
            radGridView1.Columns[10].Width = 50;
            radGridView1.Columns[11].Width = 50;

            radGridView1.Columns[0].HeaderText = "Invoice #";
            radGridView1.Columns[1].HeaderText = "Bill Acc";
            radGridView1.Columns[2].HeaderText = "Date";
            radGridView1.Columns[2].FormatString = "{0:MM/dd/yyyy}";
            radGridView1.Columns[2].TextAlignment = ContentAlignment.MiddleCenter;
            radGridView1.Columns[3].HeaderText = "Invoice";
            radGridView1.Columns[3].FormatString = "{0:c}";
            radGridView1.Columns[4].HeaderText = "SFM";
            radGridView1.Columns[4].FormatString = "{0:c}";

            radGridView1.Columns[5].HeaderText = "Credits";
            radGridView1.Columns[5].FormatString = "{0:c}";
            radGridView1.Columns[6].HeaderText = "Balance";
            radGridView1.Columns[6].FormatString = "{0:c}";
            radGridView1.Columns[7].HeaderText = "RSFM";
            radGridView1.Columns[7].FormatString = "{0:c}";
            radGridView1.Columns[8].HeaderText = "Gr. Total";
            radGridView1.Columns[8].FormatString = "{0:c}";
            radGridView1.Columns[9].HeaderText = "Deduction";
            radGridView1.Columns[9].FormatString = "{0:c}";
            radGridView1.Columns[10].HeaderText = "Name";
            radGridView1.Columns[11].HeaderText = "Cust PO";

            radGridView1.Columns[12].IsVisible   = false;
            radGridView1.Columns[13].IsVisible = false;
            radGridView1.Columns[14].IsVisible = false;
            radGridView1.Columns[15].IsVisible = false;
            radGridView1.Columns[16].IsVisible = false;
            radGridView1.Columns[17].IsVisible = false;
            radGridView1.Columns[18].IsVisible = false;
            

        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radGridView1_SelectionChanged(object sender, EventArgs e)
        {
            RadGridView dgv = (RadGridView)sender;

            try
            {
                if (dgv.SelectedRows.Count > 0)
                {
                    
                }

            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
            }
        }

        /// <summary>
        /// Method to show general error message on any system level exception
        /// </summary>
        private void ShowErrorMessage(Exception ex)
        {
            MessageBox.Show(
                ex.Message,
                //Resources.System_Error_Message, 
                Resources.System_Error_Message_Title,
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
           
            if (dvStatementOfInvoice.Count > 0)
            {
               
                if (this.radGridView1.SortDescriptors.Count != 0)
                dvStatementOfInvoice.Sort = this.radGridView1.SortDescriptors.ToString();

                string custemail = string.Empty;
                
                string sRowFilter = string.Format("{0} and {1}", dvStatementOfInvoice.RowFilter, "rsfm = '0'");
                decimal tinv = dvStatementOfInvoice.Table.Compute("SUM(invoice)", sRowFilter) != DBNull.Value ? Convert.ToDecimal(dvStatementOfInvoice.Table.Compute("SUM(invoice)", sRowFilter)) : 0;
                decimal icrd = dvStatementOfInvoice.Table.Compute("SUM(credits)", sRowFilter) != DBNull.Value ? Convert.ToDecimal(dvStatementOfInvoice.Table.Compute("SUM(credits)", sRowFilter)) : 0;
                decimal ibal = dvStatementOfInvoice.Table.Compute("SUM(balance)", sRowFilter) != DBNull.Value ? Convert.ToDecimal(dvStatementOfInvoice.Table.Compute("SUM(balance)", sRowFilter)) : 0;
                decimal ided = dvStatementOfInvoice.Table.Compute("SUM(deductions)", sRowFilter) != DBNull.Value ? Convert.ToDecimal(dvStatementOfInvoice.Table.Compute("SUM(deductions)", sRowFilter)) : 0;

                sRowFilter = string.Format("{0} and {1}", dvStatementOfInvoice.RowFilter, "rsfm <> '0'");

                decimal tsfm = dvStatementOfInvoice.Table.Compute("SUM(sfm)", sRowFilter) != DBNull.Value ? Convert.ToDecimal(dvStatementOfInvoice.Table.Compute("SUM(sfm)", sRowFilter)) : 0;
                decimal scrd = dvStatementOfInvoice.Table.Compute("SUM(credits)", sRowFilter) != DBNull.Value ? Convert.ToDecimal(dvStatementOfInvoice.Table.Compute("SUM(credits)", sRowFilter)) : 0;
                decimal sbal = dvStatementOfInvoice.Table.Compute("SUM(balance)", sRowFilter) != DBNull.Value ? Convert.ToDecimal(dvStatementOfInvoice.Table.Compute("SUM(balance)", sRowFilter)) : 0;
                decimal sded = dvStatementOfInvoice.Table.Compute("SUM(deductions)", sRowFilter) != DBNull.Value ? Convert.ToDecimal(dvStatementOfInvoice.Table.Compute("SUM(deductions)", sRowFilter)) : 0;

               


                ReportPrinting objReportPrinting = new ReportPrinting();
                Microsoft.Reporting.WinForms.ReportDataSource[] reportDataSourceCollection = new Microsoft.Reporting.WinForms.ReportDataSource[1];

                Microsoft.Reporting.WinForms.ReportParameter[] reportParameterCollection;

                reportDataSourceCollection[0] = new Microsoft.Reporting.WinForms.ReportDataSource();
                reportDataSourceCollection[0].Name = "DataSet1";
                reportDataSourceCollection[0].Value = dvStatementOfInvoice;

                reportParameterCollection = new Microsoft.Reporting.WinForms.ReportParameter[8];

                reportParameterCollection[0] = new Microsoft.Reporting.WinForms.ReportParameter();
                reportParameterCollection[0].Name = "rptinv";
                reportParameterCollection[0].Values.Add(tinv.ToString());

                reportParameterCollection[1] = new Microsoft.Reporting.WinForms.ReportParameter();
                reportParameterCollection[1].Name = "rpicrd";
                reportParameterCollection[1].Values.Add(icrd.ToString());

                reportParameterCollection[2] = new Microsoft.Reporting.WinForms.ReportParameter();
                reportParameterCollection[2].Name = "rpibal";
                reportParameterCollection[2].Values.Add(ibal.ToString());

                reportParameterCollection[3] = new Microsoft.Reporting.WinForms.ReportParameter();
                reportParameterCollection[3].Name = "rpided";
                reportParameterCollection[3].Values.Add(ided.ToString());

                reportParameterCollection[4] = new Microsoft.Reporting.WinForms.ReportParameter();
                reportParameterCollection[4].Name = "rptsfm";
                reportParameterCollection[4].Values.Add(tsfm.ToString());

                reportParameterCollection[5] = new Microsoft.Reporting.WinForms.ReportParameter();
                reportParameterCollection[5].Name = "rpscrd";
                reportParameterCollection[5].Values.Add(scrd.ToString());

                reportParameterCollection[6] = new Microsoft.Reporting.WinForms.ReportParameter();
                reportParameterCollection[6].Name = "rpsbal";
                reportParameterCollection[6].Values.Add(sbal.ToString());

                reportParameterCollection[7] = new Microsoft.Reporting.WinForms.ReportParameter();
                reportParameterCollection[7].Name = "rpsded";
                reportParameterCollection[7].Values.Add(sded.ToString());


                Helper.PrintReport(objReportPrinting, "Invoice Statement By Customer Code", "IshalInc.wJewel.Desktop.Forms.Reports.rptStatementofInvoice.rdlc", this.output_type, reportDataSourceCollection, reportParameterCollection, custemail);

            }
            else
            {
                Helper.MsgBox("No Records Found.", Telerik.WinControls.RadMessageIcon.Info);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            this.txtAcc1.Text = string.Empty;
            this.txtAcc2.Text = string.Empty;

            this.dateFrom.Value = DateTime.Now;
            this.dateTo.Value = DateTime.Now;
            this.txtSalesman.Text = string.Empty;
            this.txtState.Text = string.Empty;
            this.txtCountry.Text = string.Empty;
            this.txtAmount1.Value = 0;
            this.txtAmount2.Value = 0;
            if(dvStatementOfInvoice != null)
            dvStatementOfInvoice.RowFilter = "1=0";

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            SearchRecords();
            
        }



        private void SearchRecords()
        {
            string sFilter = "1=1";
            string acc1 = !string.IsNullOrEmpty(this.txtAcc1.Text)?  this.txtAcc1.Text :"0";
            string acc2 = !string.IsNullOrEmpty(this.txtAcc1.Text) ? this.txtAcc2.Text : "ZZ";

            sFilter += string.Format(" AND (ACC >= '{0}' AND ACC <= '{1}')", acc1,acc2);


            

            DateTime? fromDate;
            if (!string.IsNullOrEmpty(dateFrom.Text.Trim()))
                fromDate = Convert.ToDateTime(dateFrom.Text);
            else
                fromDate = new DateTime(1900, 1, 1);

            DateTime? toDate;
            if (!string.IsNullOrEmpty(dateTo.Text.Trim()))
                toDate = Convert.ToDateTime(dateTo.Text);
            else
                toDate = new DateTime(2099, 12, 31); ;



            sFilter += string.Format(" And ({0} >= '{1:MM/dd/yyyy}' ", "date", fromDate);
            sFilter += string.Format(" And {0} <= '{1:MM/dd/yyyy}' )", "date", toDate);

            if (!string.IsNullOrEmpty(this.txtState.Text))
                sFilter += string.Format(" AND {0} LIKE '%{1}%'", "state1", this.txtState.Text);

            if (!string.IsNullOrEmpty(this.txtCountry.Text))
                sFilter += string.Format(" AND {0} LIKE '%{1}%'", "country", this.txtCountry.Text);

            if (!string.IsNullOrEmpty(this.txtSalesman.Text))
                sFilter += string.Format(" AND ({1} LIKE '%{0}%' OR {2} LIKE '%{0}%' OR {3} LIKE '%{0}%' OR {4} LIKE '%{0}%')", this.txtSalesman.Text, "Salesman1", "Salesman2", "Salesman3", "Salesman4");

            if (this.chkSpecifyAmount.Checked)
            {
                
                sFilter += string.Format(" AND (gr_total >= {0} AND gr_total <= {1})", string.Format("{0:0.00}",Convert.ToDecimal(this.txtAmount1.Value)), string.Format("{0:0.00}", Convert.ToDecimal(this.txtAmount2.Value)));
            }
            if(this.chkOpenInvoicesOnly.Checked)
                sFilter += string.Format(" AND {0} > {1}", "gr_total", "credits");

            dvStatementOfInvoice.RowFilter = sFilter;

           
        }
        private void radGridView1_CellDoubleClick(object sender, GridViewCellEventArgs e)
        {
           

           
        }

        private void txtInvoiceNo_TextChanged(object sender, EventArgs e)
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

      
        private void chkSpecifyAmount_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            this.txtAmount1.Enabled = this.chkSpecifyAmount.Checked;
            this.txtAmount2.Enabled = this.chkSpecifyAmount.Checked;
        }

        private void chkAllCustomers_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            this.txtAcc1.Enabled = !this.chkAllCustomers.Checked;
            this.txtAcc2.Enabled = !this.chkAllCustomers.Checked;
            if(this.chkAllCustomers.Checked)
            {
                this.txtAcc1.Text = "0";
                this.txtAcc2.Text = "ZZ";
            }
        }

        private void txtAcc1_Validated(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(this.txtAcc1.Text) && string.IsNullOrEmpty(this.txtAcc2.Text))
            {
                this.txtAcc2.Text = this.txtAcc1.Text;
            }
        }

        private void txtAmount1_Validated(object sender, EventArgs e)
        {
            if (Convert.ToDecimal(this.txtAmount1.Value) > 0 && Convert.ToDecimal(this.txtAmount2.Value) == 0)
                this.txtAmount2.Value = this.txtAmount1.Value;
        }

        private void radGridView1_RowsChanged(object sender, GridViewCollectionChangedEventArgs e)
        {
            this.btnEdit.Visible = this.radGridView1.RowCount > 0;
        }
    }
}
