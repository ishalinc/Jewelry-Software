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
using Telerik.WinControls.UI.Localization;

namespace IshalInc.wJewel.Desktop.Forms
{
    
    public partial class frmInvoice : Telerik.WinControls.UI.RadForm
    {
        /// <summary>
        /// Interface of InvoiceSerrvice
        /// </summary>
        private IInvoiceService invoiceService;

        /// <summary>
        /// Interface of InvoiceItemSerrvice
        /// </summary>
        private IInvoiceItemsService invoiceItemsService;

        private DataView dvInvoiceItems;

        /// <summary>
        /// Variable to store error message
        /// </summary>
        private string errorMessage;



        /// <summary>
        /// Account Code
        /// </summary>
        private string acccode;


        /// <summary>
        ///Billing Account Code
        /// </summary>
        private string bill_acccode;

        private string shipvia = "N";
        private string shipviaLabel = "None";

        private string is_cod = "N";

        private string codtype = "A";

        private string early = "R";
        private string earlyLabel = "Regular";

        private string invoiceno = string.Empty;

        private bool is_update = false;

        private DataTable invoiceItems;

        private bool is_cancelled = true;
        public frmInvoice()
        {
            InitializeComponent();
            this.Icon = Helper.MakeIcon(IshalInc.wJewel.Desktop.Properties.Resources.dollar, 24, true);
            this.btnOK.ButtonElement.ForeColor = Color.Green;
            this.btnOK.ButtonElement.ButtonFillElement.GradientStyle = GradientStyles.Gel;

            this.btnCancel.ButtonElement.ForeColor = Color.Red;
            this.btnCancel.ButtonElement.ButtonFillElement.GradientStyle = GradientStyles.Gel;
        }

        public frmInvoice(string accountcode, string bacccode, DataRow custRow,DataRow billAcctRow, int custId, string invno)
        {
            InitializeComponent();
            //Helper.AddShippingType(radGroupBox5,3);
            this.Icon = Helper.MakeIcon(IshalInc.wJewel.Desktop.Properties.Resources.invoice_add, 24, true);
            this.txtBillingAccount.Text = accountcode;
            this.invoiceService = new InvoiceService();
            this.invoiceItemsService = new InvoiceItemsService();
            if (custRow != null)
            {
                LoadData(custRow, billAcctRow);
            }
            DataTable invoiceItems = this.invoiceItemsService.GetInvoiceItemsByInvNo("-1");
            this.acccode = accountcode;
            this.bill_acccode = bacccode;
            this.is_update = false;
            this.txtInvoiceDate.Value = DateTime.Now;
            this.txtInvoiceNo.Text = invno;
            this.txtWeight.Value = 1;
            this.invoiceno = invno;
            this.FormClosing += new FormClosingEventHandler(frmInvoice_FormClosing);
           
            RadGridLocalizationProvider.CurrentProvider = new CustomLocalizationProvider();
            this.LoadDataGridView(invoiceItems);

            this.btnOK.ButtonElement.ForeColor = Color.Green;
            this.btnOK.ButtonElement.ButtonFillElement.GradientStyle = GradientStyles.Gel;

            this.btnCancel.ButtonElement.ForeColor = Color.Red;
            this.btnCancel.ButtonElement.ButtonFillElement.GradientStyle = GradientStyles.Gel;

        }

        public frmInvoice(string accountcode, string bacccode, DataRow invoiceRow,DataRow custRow, int custId, string invno, bool isUpdate)
        {
            InitializeComponent();
           // Helper.AddShippingType(radGroupBox5,3);
            this.Icon = Helper.MakeIcon(IshalInc.wJewel.Desktop.Properties.Resources.invoice_edit, 24, true);
            this.txtBillingAccount.Text = accountcode;
            this.invoiceService = new InvoiceService();
            this.invoiceItemsService = new InvoiceItemsService();
            if (invoiceRow != null)
            {
                LoadInvoiceData(invoiceRow, custRow);
            }
            DataTable invoiceItems = this.invoiceItemsService.GetInvoiceItemsByInvNo(invno);
            this.acccode = accountcode;
            this.bill_acccode = bacccode;
            this.is_update = true;
            this.txtInvoiceDate.Value = DateTime.Now;
            this.txtInvoiceNo.Text = invno;
            this.txtWeight.Value = 1;
            this.invoiceno = invno;
            this.FormClosing += frmInvoice_FormClosing;
            RadGridLocalizationProvider.CurrentProvider = new CustomLocalizationProvider();
            this.LoadDataGridView(invoiceItems);
            this.FormClosing += new FormClosingEventHandler(frmInvoice_FormClosing);

            this.btnOK.ButtonElement.ForeColor = Color.Green;
            this.btnOK.ButtonElement.ButtonFillElement.GradientStyle = GradientStyles.Gel;

            this.btnCancel.ButtonElement.ForeColor = Color.Red;
            this.btnCancel.ButtonElement.ButtonFillElement.GradientStyle = GradientStyles.Gel;

        }


        // <summary>
        /// Method to load data grid view
        /// </summary>
        /// <param name="data">data table</param>
        private void LoadDataGridView(DataTable data)
        {
            // Data grid view column setting      

            dataGridView1.DataSource = data;
          
            dataGridView1.Columns[0].IsVisible = false;
            
            dataGridView1.Columns[1].HeaderText = "Description";
            dataGridView1.Columns[1].Width = 380;
            
            dataGridView1.Columns[2].HeaderText = "Amount";
            dataGridView1.Columns[2].DataType = typeof(double);
            dataGridView1.Columns[2].FormatString = "{0:c}";

        }


        private void LoadData(DataRow custAccountRow, DataRow billAcctRow)
        {
            this.txtName.Text = custAccountRow["name"].ToString().Trim();
            this.txtAddr1.Text = custAccountRow["addr1"].ToString().Trim();
            this.txtAddr12.Text = custAccountRow["addr12"].ToString().Trim();
            this.txtCity1.Text = custAccountRow["city1"].ToString().Trim();
            this.txtState1.Text = custAccountRow["state1"].ToString().Trim();
            this.txtZip1.Text = custAccountRow["zip1"].ToString().Trim();
            this.txtTel.Text = custAccountRow["tel"].ToString();
            this.txtCountry.Text = custAccountRow["country"].ToString().Trim();


            this.txtName2.Text = custAccountRow["name2"].ToString().Trim();
            this.txtAddr2.Text = custAccountRow["addr2"].ToString().Trim();
            this.txtAddr22.Text = custAccountRow["addr22"].ToString().Trim();
            this.txtCity2.Text = custAccountRow["city2"].ToString().Trim();
            this.txtState2.Text = custAccountRow["state2"].ToString().Trim();
            this.txtZip2.Text = custAccountRow["zip2"].ToString().Trim();
          
            this.txtCountry2.Text = custAccountRow["country2"].ToString().Trim();

            this.chkCOD.Checked = custAccountRow["is_cod"].ToString().Trim() == "Y" ? true : false;
            this.is_cod = custAccountRow["is_cod"].ToString().Trim() == "Y" ? "Y" : "N";
            this.codtype = this.is_cod == "Y" ? "B" : "A";

            switch (custAccountRow["ship_via"].ToString())
            {
                case "G":
                    this.rdoNone.IsChecked = true;
                    break;
                case "O":
                    this.rdoExpressSaver.IsChecked = true;
                    break;
                case "B":
                    this.rdo2Day.IsChecked = true;
                    break;
                case "R":
                    this.rdoNextDatStd.IsChecked = true;
                    break;
                case "E":
                    this.rdoNextDayPriority.IsChecked = true;
                    break;
                case "F":
                    this.rdoNextDayFirst.IsChecked = true;
                    break;
                case "L":
                    this.rdoNextDayLetter.IsChecked = true;
                    break;
                case "S":
                    this.rdoSaturday.IsChecked = true;
                    break;
                case "M":
                    this.rdoMail.IsChecked = true;
                    break;
                case "D":
                    this.rdoDelivery.IsChecked = true;
                    break;
                case "P":
                    this.rdoPickup.IsChecked = true;
                    break;
                case "N":
                    this.rdoNone.IsChecked = true;
                    break;
                default:
                    this.rdoNone.IsChecked = true;
                    break;
            }

            this.txtPayTerm1.Value = custAccountRow["term1"] == DBNull.Value ? 0 : Convert.ToDecimal(custAccountRow["term1"]);
            this.txtPayTerm2.Value = custAccountRow["term2"] == DBNull.Value ? 0 : Convert.ToDecimal(custAccountRow["term2"]);
            this.txtPayTerm3.Value = custAccountRow["term3"] == DBNull.Value ? 0 : Convert.ToDecimal(custAccountRow["term3"]);
            this.txtPayTerm4.Value = custAccountRow["term4"] == DBNull.Value ? 0 : Convert.ToDecimal(custAccountRow["term4"]);
            this.txtPayTerm5.Value = custAccountRow["term5"] == DBNull.Value ? 0 : Convert.ToDecimal(custAccountRow["term5"]);
            this.txtPayTerm6.Value = custAccountRow["term6"] == DBNull.Value ? 0 : Convert.ToDecimal(custAccountRow["term6"]);
            this.txtPayTerm7.Value = custAccountRow["term7"] == DBNull.Value ? 0 : Convert.ToDecimal(custAccountRow["term7"]);
            this.txtPayTerm8.Value = custAccountRow["term8"] == DBNull.Value ? 0 : Convert.ToDecimal(custAccountRow["term8"]);

            this.txtTermPercent1.Value = custAccountRow["term_pct1"] == DBNull.Value ? 0 : Convert.ToDecimal(custAccountRow["term_pct1"]);
            this.txtTermPercent2.Value = custAccountRow["term_pct2"] == DBNull.Value ? 0 : Convert.ToDecimal(custAccountRow["term_pct2"]);
            this.txtTermPercent3.Value = custAccountRow["term_pct3"] == DBNull.Value ? 0 : Convert.ToDecimal(custAccountRow["term_pct3"]);
            this.txtTermPercent4.Value = custAccountRow["term_pct4"] == DBNull.Value ? 0 : Convert.ToDecimal(custAccountRow["term_pct4"]);
            this.txtTermPercent5.Value = custAccountRow["term_pct5"] == DBNull.Value ? 0 : Convert.ToDecimal(custAccountRow["term_pct5"]);
            this.txtTermPercent6.Value = custAccountRow["term_pct6"] == DBNull.Value ? 0 : Convert.ToDecimal(custAccountRow["term_pct6"]);
            this.txtTermPercent7.Value = custAccountRow["term_pct7"] == DBNull.Value ? 0 : Convert.ToDecimal(custAccountRow["term_pct7"]);
            this.txtTermPercent8.Value = custAccountRow["term_pct8"] == DBNull.Value ? 0 : Convert.ToDecimal(custAccountRow["term_pct8"]);


        }


        private void LoadInvoiceData(DataRow invoiceRow, DataRow custRow)
        {
            this.txtName.Text = custRow["name"].ToString().Trim();
            this.txtAddr1.Text = custRow["addr1"].ToString().Trim();
            this.txtAddr12.Text = custRow["addr12"].ToString().Trim();
            this.txtCity1.Text = custRow["city1"].ToString().Trim();
            this.txtState1.Text = custRow["state1"].ToString().Trim();
            this.txtZip1.Text = custRow["zip1"].ToString().Trim();
            this.txtTel.Text = custRow["tel"].ToString();
            this.txtCountry.Text = custRow["country"].ToString().Trim();
          

            this.txtName2.Text = invoiceRow["name"].ToString().Trim();
            this.txtAddr2.Text = invoiceRow["addr1"].ToString().Trim();
            this.txtAddr22.Text = invoiceRow["addr2"].ToString().Trim();
            this.txtCity2.Text = invoiceRow["city"].ToString().Trim();
            this.txtState2.Text = invoiceRow["state"].ToString().Trim();
            this.txtZip2.Text = invoiceRow["zip"].ToString().Trim();
            
            this.txtCountry2.Text = invoiceRow["country"].ToString().Trim();
            this.txtShippingHandling.Value = Convert.ToDecimal(invoiceRow["snh"].ToString().Trim());
            this.txtOtherCharges.Value = Convert.ToDecimal(invoiceRow["add_cost"].ToString().Trim());

            this.chkCOD.Checked = invoiceRow["is_cod"].ToString().Trim() == "Y" ? true : false;
            this.is_cod = invoiceRow["is_cod"].ToString().Trim() == "Y" ? "Y" : "N";
            this.codtype = this.is_cod == "Y" ? "B" : "A";
            this.early = invoiceRow["early"].ToString().Trim();
            switch (this.early)
            {
                case "R":
                    this.rdoRegular.IsChecked = true;
                    break;
                case "E":
                    this.rdoEarlyAm.IsChecked = true;
                    break;
                case "S":
                    this.rdoUPSSaver.IsChecked = true;
                    break;
                default:
                    this.rdoRegular.IsChecked = true;
                    break;
            }

                    switch (invoiceRow["ship_by"].ToString().Trim())
            {
                case "G":
                    this.rdoNone.IsChecked = true;
                    break;
                case "O":
                    this.rdoExpressSaver.IsChecked = true;
                    break;
                case "B":
                    this.rdo2Day.IsChecked = true;
                    break;
                case "R":
                    this.rdoNextDatStd.IsChecked = true;
                    break;
                case "E":
                    this.rdoNextDayPriority.IsChecked = true;
                    break;
                case "F":
                    this.rdoNextDayFirst.IsChecked = true;
                    break;
                case "L":
                    this.rdoNextDayLetter.IsChecked = true;
                    break;
                case "S":
                    this.rdoSaturday.IsChecked = true;
                    break;
                case "M":
                    this.rdoMail.IsChecked = true;
                    break;
                case "D":
                    this.rdoDelivery.IsChecked = true;
                    break;
                case "P":
                    this.rdoPickup.IsChecked = true;
                    break;
                case "N":
                    this.rdoNone.IsChecked = true;
                    break;
                default:
                    this.rdoNone.IsChecked = true;
                    break;
            }

            this.txtPayTerm1.Value = invoiceRow["term1"] == DBNull.Value ? 0 : Convert.ToDecimal(invoiceRow["term1"]);
            this.txtPayTerm2.Value = invoiceRow["term2"] == DBNull.Value ? 0 : Convert.ToDecimal(invoiceRow["term2"]);
            this.txtPayTerm3.Value = invoiceRow["term3"] == DBNull.Value ? 0 : Convert.ToDecimal(invoiceRow["term3"]);
            this.txtPayTerm4.Value = invoiceRow["term4"] == DBNull.Value ? 0 : Convert.ToDecimal(invoiceRow["term4"]);
            this.txtPayTerm5.Value = invoiceRow["term5"] == DBNull.Value ? 0 : Convert.ToDecimal(invoiceRow["term5"]);
            this.txtPayTerm6.Value = invoiceRow["term6"] == DBNull.Value ? 0 : Convert.ToDecimal(invoiceRow["term6"]);
            this.txtPayTerm7.Value = invoiceRow["term7"] == DBNull.Value ? 0 : Convert.ToDecimal(invoiceRow["term7"]);
            this.txtPayTerm8.Value = invoiceRow["term8"] == DBNull.Value ? 0 : Convert.ToDecimal(invoiceRow["term8"]);

            this.txtTermPercent1.Value = invoiceRow["term_pct1"] == DBNull.Value ? 0 : Convert.ToDecimal(invoiceRow["term_pct1"]);
            this.txtTermPercent2.Value = invoiceRow["term_pct2"] == DBNull.Value ? 0 : Convert.ToDecimal(invoiceRow["term_pct2"]);
            this.txtTermPercent3.Value = invoiceRow["term_pct3"] == DBNull.Value ? 0 : Convert.ToDecimal(invoiceRow["term_pct3"]);
            this.txtTermPercent4.Value = invoiceRow["term_pct4"] == DBNull.Value ? 0 : Convert.ToDecimal(invoiceRow["term_pct4"]);
            this.txtTermPercent5.Value = invoiceRow["term_pct5"] == DBNull.Value ? 0 : Convert.ToDecimal(invoiceRow["term_pct5"]);
            this.txtTermPercent6.Value = invoiceRow["term_pct6"] == DBNull.Value ? 0 : Convert.ToDecimal(invoiceRow["term_pct6"]);
            this.txtTermPercent7.Value = invoiceRow["term_pct7"] == DBNull.Value ? 0 : Convert.ToDecimal(invoiceRow["term_pct7"]);
            this.txtTermPercent8.Value = invoiceRow["term_pct8"] == DBNull.Value ? 0 : Convert.ToDecimal(invoiceRow["term_pct8"]);


        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = RadMessageBox.Show("Are you sure you want to cancel the changes?", "Add / Edit Customer", MessageBoxButtons.YesNo, RadMessageIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                this.is_cancelled = true;
                this.Close();
            }
        }




        private void UpdateTotal()
        {
            double invoiceTotal = 0;
         
            if (dataGridView1.Rows.Count > 0)
            {
                foreach (GridViewDataRowInfo row in dataGridView1.Rows)
                {
                    invoiceTotal += Convert.ToDouble(string.IsNullOrEmpty(row.Cells[2].Value.ToString()) ? 0 : row.Cells[2].Value);
                }
                  
                this.txtSubTotal.Value = invoiceTotal;
            }
            

            
            this.txtTotal.Value = Convert.ToDouble(this.txtSubTotal.Value) + Convert.ToDouble(this.txtShippingHandling.Value) + Convert.ToDouble(this.txtOtherCharges.Value);
        }

        private void txtSubTotal_ValueChanged(object sender, EventArgs e)
        {

            this.txtTotal.Value = Convert.ToDouble(this.txtSubTotal.Value) + Convert.ToDouble(this.txtShippingHandling.Value) + Convert.ToDouble(this.txtOtherCharges.Value);
        }

        private void txtOtherCharges_ValueChanged(object sender, EventArgs e)
        {
            this.txtTotal.Value = Convert.ToDouble(this.txtSubTotal.Value) + Convert.ToDouble(this.txtShippingHandling.Value) + Convert.ToDouble(this.txtOtherCharges.Value);
        }

        private void txtShippingHandling_ValueChanged(object sender, EventArgs e)
        {
            this.txtTotal.Value = Convert.ToDouble(this.txtSubTotal.Value) + Convert.ToDouble(this.txtShippingHandling.Value) + Convert.ToDouble(this.txtOtherCharges.Value);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (InsertNewRecord())
            {
                is_cancelled = false;
                this.Hide();
              
                frmInvoiceReport objInvoicePrint = new frmInvoiceReport(this.invoiceno, this.acccode);
                objInvoicePrint.StartPosition = FormStartPosition.CenterScreen;
                objInvoicePrint.MdiParent = this.MdiParent;
                objInvoicePrint.Show();
                this.Close();
            }

        }

        /// <summary>
        /// Validates registration input
        /// </summary>
        /// <returns>true or false</returns>
        private bool ValidateInvoiceInsert()
        {
            this.errorMessage = string.Empty;

            if (txtName.Text.Trim() == string.Empty)
            {
                this.AddErrorMessage("Name is Required");
            }

            if (Convert.ToDecimal(this.txtTermPercent1.Value)  + Convert.ToDecimal(this.txtTermPercent2.Value) + Convert.ToDecimal(this.txtTermPercent3.Value)  + Convert.ToDecimal(this.txtTermPercent4.Value) + Convert.ToDecimal(this.txtTermPercent5.Value) + Convert.ToDecimal(this.txtTermPercent6.Value) + Convert.ToDecimal(this.txtTermPercent7.Value) + Convert.ToDecimal(this.txtTermPercent8.Value) != 100)
            {
                this.AddErrorMessage("Invalid Term Percentage");
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
                this.errorMessage = Resources.Error_Message_Header + "\n\n";
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
                Resources.System_Error_Message_Title,
                MessageBoxButtons.OK,
                RadMessageIcon.Error);
        }

        private bool InsertNewRecord()
        {
            bool success = true;
            try
            {
                // Check if the validation passes
                if (this.ValidateInvoiceInsert())
                {
                    DateTime? invoiceDate;
                    if (!string.IsNullOrEmpty(txtInvoiceDate.Text.Trim()))
                        invoiceDate = Convert.ToDateTime(txtInvoiceDate.Text);
                    else
                        invoiceDate = null;


                    // Assign the values to the model
                    InvoiceModel InvoiceModel = new InvoiceModel()
                    {

                        INV_NO = this.txtInvoiceNo.Text.Trim(),
                        ACC = this.acccode.Trim(),
                        BACC = this.bill_acccode.Trim(),
                        ADD_COST = Convert.ToDecimal(txtOtherCharges.Value.ToString().Trim()),
                        SNH = Convert.ToDecimal(txtShippingHandling.Value.ToString().Trim()),
                        DATE = invoiceDate,
                        PON = txtPONo.Text.Trim(),
                        MESSAGE = txtNote.Text.Trim(),
                        GR_TOTAL = Convert.ToDecimal(txtTotal.Value.ToString().Trim()),
                        NAME = txtName2.Text.Trim(),
                        ADDR1 = txtAddr2.Text.Trim(),
                        ADDR2 = txtAddr22.Text.Trim(),
                        CITY = txtCity2.Text.Trim(),
                        STATE = txtState2.Text.Trim(),
                        ZIP = txtZip2.Text.Trim(),
                        COUNTRY = txtCountry2.Text.Trim(),
                        SHIP_BY = this.shipvia,
                        VIA_UPS = this.chkViaFedex.Checked ? "Y" : "N",
                        IS_COD = this.is_cod == "N" ? "N" : "Y",
                        WEIGHT = Convert.ToDecimal(txtWeight.Value.ToString().Trim()),
                        COD_TYPE = this.codtype == "N" || this.codtype == "A" ? "A" : "B",
                        CUST_PON = txtPONo.Text.Trim(),
                        TERM1 = Convert.ToDecimal(txtPayTerm1.Value.ToString().Trim()),
                        TERM2 = Convert.ToDecimal(txtPayTerm2.Value.ToString().Trim()),
                        TERM3 = Convert.ToDecimal(txtPayTerm3.Value.ToString().Trim()),
                        TERM4 = Convert.ToDecimal(txtPayTerm4.Value.ToString().Trim()),
                        TERM5 = Convert.ToDecimal(txtPayTerm5.Value.ToString().Trim()),
                        TERM6 = Convert.ToDecimal(txtPayTerm6.Value.ToString().Trim()),
                        TERM7 = Convert.ToDecimal(txtPayTerm7.Value.ToString().Trim()),
                        TERM8 = Convert.ToDecimal(txtPayTerm8.Value.ToString().Trim()),
                        TERM_PCT1 = Convert.ToDecimal(txtTermPercent1.Value.ToString().Trim()),
                        TERM_PCT2 = Convert.ToDecimal(txtTermPercent2.Value.ToString().Trim()),
                        TERM_PCT3 = Convert.ToDecimal(txtTermPercent3.Value.ToString().Trim()),
                        TERM_PCT4 = Convert.ToDecimal(txtTermPercent4.Value.ToString().Trim()),
                        TERM_PCT5 = Convert.ToDecimal(txtTermPercent5.Value.ToString().Trim()),
                        TERM_PCT6 = Convert.ToDecimal(txtTermPercent6.Value.ToString().Trim()),
                        TERM_PCT7 = Convert.ToDecimal(txtTermPercent7.Value.ToString().Trim()),
                        TERM_PCT8 = Convert.ToDecimal(txtTermPercent8.Value.ToString().Trim()),
                        INSURED = Convert.ToDecimal(txtInsuredFor.Value.ToString().Trim()),
                        EARLY = this.early,
                        OPERATOR = Helper.LoggedUser,
                        MAN_SHIP = this.chkSHOverride.Checked ? true : false,
                        RESIDENT = this.chkResidentialAddress.Checked ? "Y" : "N",
                        IS_FDX = this.chkViaFedex.Checked ? true : false,
                        IS_DEB = true,
                        PERCENT = 0,

                      

                    };

                    // Call the service method and assign the return status to variable
                    var success1 = false;
                    if (!this.is_update)
                        success1 = this.invoiceService.InsertInvoice(InvoiceModel);
                    else
                        success1 = this.invoiceService.UpdateInvoice(InvoiceModel);

                    if (this.is_update)
                        this.invoiceItemsService.DeleteInvoiceItems(this.invoiceno);
                    var success2 = true;
                    if (success1 && success2)
                    {
                        if (dataGridView1.Rows.Count > 0)
                        {
                            for (int ctr = 0; ctr <= dataGridView1.Rows.Count - 1; ctr++)
                            {
                                InvoiceItemsModel InvItemModel = new InvoiceItemsModel()
                                {
                                    INV_NO = this.txtInvoiceNo.Text,
                                    DESC = dataGridView1.Rows[ctr].Cells[1].Value.ToString(),
                                    PRICE = Convert.ToDecimal(string.IsNullOrEmpty(dataGridView1.Rows[ctr].Cells[2].Value.ToString()) ? 0 : dataGridView1.Rows[ctr].Cells[2].Value),
                                    QTY = 1
                                };
                                success2 = this.invoiceItemsService.InsertInvoiceItem(InvItemModel);
                            }

                            if (!this.is_update)
                                Helper.AddKeepRec(string.Format("ADD INVOICE # {0}", this.txtInvoiceNo.Text));
                            else
                                Helper.AddKeepRec(string.Format("UPDATE INVOICE # {0}", this.txtInvoiceNo.Text));

                        }
                    }
                    else
                    {
                        Helper.MsgBox(
                            "Error Creating Invoice",
                            MessageBoxButtons.OK,
                            RadMessageIcon.Info);
                        success = false;
                    }

                    // if status of success variable is true then display a information else display the error message
                    if (success1 && success2)
                    {
                        // display the message box
                        string msg = this.is_update ? "Invoice Updated Successfully" : "Invoice Added Successfully";
                        //Helper.MsgBox(msg, MessageBoxButtons.OK,RadMessageIcon.Info);
                        success =  true;

                    }
                    else
                    {
                        // display the error messge
                        Helper.MsgBox(
                            "Error Creating Invoice",
                            MessageBoxButtons.OK,
                            RadMessageIcon.Error);
                        success = false;
                    }
                }
                else
                {
                    // Display the validation failed message
                    Helper.MsgBox(
                        this.errorMessage,
                        MessageBoxButtons.OK,
                        RadMessageIcon.Error);
                    success = false;
                }
            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
                success = false;
            }
            return success;
        }

        private void txtInsuredFor_Click(object sender, EventArgs e)
        {

        }

        private void rdoGround_ToggleStateChanged(object sender, Telerik.WinControls.UI.StateChangedEventArgs args)
        {
       
            string result = null;
            foreach (Control control in this.grpShipVia.Controls)
            {
                if (control is RadRadioButton)
                {
                    RadRadioButton radio = control as RadRadioButton;
                    if (radio.IsChecked)
                    {
                        this.shipviaLabel = radio.Text;
                    }
                }
            }

            switch (this.shipviaLabel)
            {
                case "Ground":
                    shipvia = "G";
                    break;
                case "Express Saver":
                    shipvia = "O";
                    break;
                case "2 Day":
                    shipvia = "B";
                    break;
                case "Next Day Std":
                    shipvia = "R";
                    break;
                case "Next Day Priority":
                    shipvia = "E";
                    break;
                case "Next Day First":
                    shipvia = "F";
                    break;
                case "Next Day Letter":
                    shipvia = "L";
                    break;
                case "Saturday":
                    shipvia = "S";
                    break;
                case "Mail":
                    shipvia = "M";
                    break;
                case "Delivery":
                    shipvia = "D";
                    break;
                case "Pickup":
                    shipvia = "P";
                    break;
                case "None":
                    shipvia = "N";
                    break;
                default:
                    shipvia = "N";
                    break;

            }

        
    }

        private void rdoRegular_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            string result = null;
            foreach (Control control in this.radGroupBox4.Controls)
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
            switch (result)
            {
                case "Regular":
                    early = "R";
                    break;
                case "Early Am":
                    early = "E";
                    break;
                case "UPS Saver":
                    early = "S";
                    break;
                default:
                    early = "R";
                    break;
            }

            }

        

        private void chkSHOverride_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            this.txtShippingHandling.Enabled = this.chkSHOverride.Checked;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            decimal sandh = Convert.ToDecimal(Helper.ShippingHandling(this.txtZip2.Text.Trim().ToString(), this.shipvia, this.early, this.txtState2.Text.Trim().ToString(), this.chkResidentialAddress.Checked,Convert.ToDecimal(this.txtSubTotal.Value), this.is_cod, Convert.ToInt32(this.txtWeight.Value)));
            this.txtShippingHandling.Value = sandh;
        }

        private void frmInvoice_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                if (this.ActiveControl != null )
                {

                    this.SelectNextControl(this.ActiveControl, true, true, true, true);
                    e.Handled = true;
                }


            }
        }

        
        private void dataGridView1_CreateRow(object sender, GridViewCreateRowEventArgs e)
        {
            UpdateTotal();  
        }

        private void dataGridView1_UserDeletedRow(object sender, GridViewRowEventArgs e)
        {
            UpdateTotal();
        }

        private void chkCOD_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            this.is_cod = this.chkCOD.Checked ? "Y" : "N";
            this.codtype = this.chkCOD.Checked ? "B" : "A";
        }

        private void frmInvoice_FormClosing(object sender, FormClosingEventArgs e)
        {
             if(!this.is_update || this.is_cancelled)
            {
                int t_invoicenr;
                if (int.TryParse(this.txtInvoiceNo.Text, out t_invoicenr))
                {
                    Helper.CheckInvoiceSequence(t_invoicenr);
                }
            }
        }
    }

   
}
