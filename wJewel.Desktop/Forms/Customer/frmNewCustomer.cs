// -----------------------------------------------------------------------
// <copyright file="Manage.cs" company="Ishal Inc.">
//  Jewelry Software ©2016
// </copyright>
// -----------------------------------------------------------------------
using IshalInc.wJewel.Desktop.Libraries;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using System;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using IshalInc.wJewel.Data.BusinessService;
using IshalInc.wJewel.Data.DataModel;
using IshalInc.wJewel.Desktop.Properties;

namespace IshalInc.wJewel.Desktop.Forms
{
    

    /// <summary>
    /// Manage screen - To view, search, print, export customers information
    /// </summary>
    public partial class frmNewCustomer : RadForm
    {
        
        /// <summary>
        /// Interface of CustomerService
        /// </summary>
        private ICustomerService customerService;

        /// <summary>
        /// Variable to store error message
        /// </summary>
        private string errorMessage;

        /// <summary>
        /// Customer id
        /// </summary>
        private int customerId;


        /// <summary>
        /// Account Code
        /// </summary>
        private string acccode;


        /// <summary>
        ///Billing Account Code
        /// </summary>
        private string bill_acccode;


        private string shipvia = "N";

        private string is_cod = "N";

        private string codtype = "A";
        /// <summary>
        /// Initializes a new instance of the Manage class
        /// </summary>
        /// 

        public frmNewCustomer()
        {
            
            this.InitializeComponent();
            this.Icon = Helper.MakeIcon(IshalInc.wJewel.Desktop.Properties.Resources.customernew, 24, true);
            this.txtEstDate.Value = DateTime.Now;
            this.txtIntChargedTo.SetToNullValue();
            this.txtCollectionDate.SetToNullValue();
            this.customerService = new CustomerService();
            InitializeUpdate();
            this.btnSave.ButtonElement.ForeColor = Color.Green;
            this.btnSave.ButtonElement.ButtonFillElement.GradientStyle = GradientStyles.Gel;

            this.btnCancel.ButtonElement.ForeColor = Color.Red;
            this.btnCancel.ButtonElement.ButtonFillElement.GradientStyle = GradientStyles.Gel;

            this.tabControl1.SelectedPage = this.tabPage1;

        }


        /// <summary>
        /// Initializes a new instance of the Manage class
        /// </summary>
        public frmNewCustomer(string accountcode, string bill_acccode, DataRow custRow)
        {
            
            this.InitializeComponent();
            this.Icon = Helper.MakeIcon(IshalInc.wJewel.Desktop.Properties.Resources.customernew, 24, true);
            this.txtEstDate.Value = DateTime.Now;
            this.txtIntChargedTo.SetToNullValue();
            this.txtCollectionDate.SetToNullValue();
            this.acccode = accountcode;
            this.bill_acccode = bill_acccode;
            this.customerId = 0;
            this.customerService = new CustomerService();
            InitializeUpdate();

            if (custRow != null)
            {
                LoadData(custRow);
            }
            this.tabControl1.SelectedPage = this.tabPage1;

        }

        /// <summary>
        /// Initializes a new instance of the Manage class
        /// </summary>
        public frmNewCustomer(string accountcode, string bill_acccode, DataRow custRow, int customerid)
        {

            this.InitializeComponent();
            this.Icon = Helper.MakeIcon(IshalInc.wJewel.Desktop.Properties.Resources.customernew, 24, true);
            this.txtEstDate.Value = DateTime.Now;
            this.txtIntChargedTo.SetToNullValue();
            this.txtCollectionDate.SetToNullValue();
            this.acccode = accountcode;
            this.bill_acccode = bill_acccode;
            this.customerId = customerid;
            this.customerService = new CustomerService();
            InitializeUpdate();
            if (custRow != null)
            {
                LoadData(custRow);
            }
            this.tabControl1.SelectedPage = this.tabPage1;
            this.txtName.Focus();

        }


        private void LoadData(DataRow dataRow)
        {
           
            this.txtName.Text = dataRow["name"].ToString().Trim();
            
            this.txtAddr1.Text = dataRow["addr1"].ToString().Trim();
            this.txtAddr12.Text = dataRow["addr12"].ToString().Trim();
            this.txtCity1.Text = dataRow["city1"].ToString().Trim();
            this.txtState1.Text = dataRow["state1"].ToString().Trim();
            this.txtZip1.Text = dataRow["zip1"].ToString().Trim();
            this.txtTel.Text = dataRow["tel"].ToString();
            this.txtCountry.Text = dataRow["country"].ToString().Trim();
            this.txtWebsite.Text = dataRow["www"].ToString().Trim();
            this.txtEmail.Text = dataRow["email"].ToString().Trim();
            this.txtTaxID.Text = dataRow["tax_id"].ToString().Trim();
            
            if (dataRow["est_date"] == DBNull.Value)
            {
                this.txtEstDate.SetToNullValue();
            }
            else
            {
                this.txtEstDate.Value = Convert.ToDateTime(dataRow["est_date"]);
            }
           
            this.txtPriceFile.SelectedValue = dataRow["price_file"].ToString().Trim();
            this.txtJbt.Text = dataRow["jbt"].ToString();

            this.chkMailingList.Checked = (dataRow["on_mail"] == DBNull.Value ? false : dataRow["on_mail"].ToString().Trim() == "1" ? true : false) ;
            this.chkResidentialAddress.Checked = (dataRow["resident"] == DBNull.Value ? false : dataRow["resident"].ToString().Trim() == "1" ? true : false);
            

            this.txtName2.Text = dataRow["name2"].ToString().Trim();
            this.txtAddr2.Text = dataRow["addr2"].ToString().Trim();
            this.txtAddr22.Text = dataRow["addr22"].ToString().Trim();
            this.txtCity2.Text = dataRow["city2"].ToString().Trim();
            this.txtState2.Text = dataRow["state2"].ToString().Trim();
            this.txtZip2.Text = dataRow["zip2"].ToString().Trim();
            this.txtFax.Text = dataRow["fax"].ToString().Trim();
            this.txtCountry2.Text = dataRow["country2"].ToString().Trim();
            this.txtBuyer.Text = dataRow["buyer"].ToString().Trim();

            this.chkCOD.Checked = dataRow["is_cod"].ToString().Trim() == "Y" ? true : false;
           

            switch (dataRow["ship_via"].ToString())
            {
                case "G":
                    this.rdoGround.IsChecked = true;
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


            this.txtNote.Text = dataRow["note"].ToString().Trim();

            this.txtMonthlyInterest.Value = Convert.ToDecimal(dataRow["interest"].ToString());
           
            if (dataRow["last_int"] == DBNull.Value)
            {
                this.txtIntChargedTo.SetToNullValue();
            }
            else
            {
                this.txtIntChargedTo.Value = Convert.ToDateTime(dataRow["last_int"]);
            }

            this.txtGracePeriod.Text = dataRow["grace"].ToString().Trim();
            this.txtSalesman1.SelectedValue = dataRow["salesman1"].ToString().Trim();
            this.txtSalesman2.SelectedValue = dataRow["salesman2"].ToString().Trim();
            this.txtSalesman3.SelectedValue = dataRow["salesman3"].ToString().Trim();
            this.txtSalesman4.SelectedValue = dataRow["salesman3"].ToString().Trim();
            this.txtPercent1.Value = Convert.ToDecimal(dataRow["percent1"]);
            this.txtPercent2.Value = Convert.ToDecimal(dataRow["percent2"]);
            this.txtPercent3.Value = Convert.ToDecimal(dataRow["percent3"]);
            this.txtPercent4.Value = Convert.ToDecimal(dataRow["percent4"]);

            this.txtPayTerm1.Value = dataRow["term1"] == DBNull.Value ? 0 : Convert.ToDecimal(dataRow["term1"]);
            this.txtPayTerm2.Value = dataRow["term2"] == DBNull.Value ? 0 : Convert.ToDecimal(dataRow["term2"]);
            this.txtPayTerm3.Value = dataRow["term3"] == DBNull.Value ? 0 : Convert.ToDecimal(dataRow["term3"]);
            this.txtPayTerm4.Value = dataRow["term4"] == DBNull.Value ? 0 : Convert.ToDecimal(dataRow["term4"]);
            this.txtPayTerm5.Value = dataRow["term5"] == DBNull.Value ? 0 : Convert.ToDecimal(dataRow["term5"]);
            this.txtPayTerm6.Value = dataRow["term6"] == DBNull.Value ? 0 : Convert.ToDecimal(dataRow["term6"]);
            this.txtPayTerm7.Value = dataRow["term7"] == DBNull.Value ? 0 : Convert.ToDecimal(dataRow["term7"]);
            this.txtPayTerm8.Value = dataRow["term8"] == DBNull.Value ? 0 : Convert.ToDecimal(dataRow["term8"]);


            this.txtTermPercent1.Value = dataRow["term_pct1"] == DBNull.Value ? 0 : Convert.ToDecimal(dataRow["term_pct1"]);
            this.txtTermPercent2.Value = dataRow["term_pct2"] == DBNull.Value ? 0 : Convert.ToDecimal(dataRow["term_pct2"]);
            this.txtTermPercent3.Value = dataRow["term_pct3"] == DBNull.Value ? 0 : Convert.ToDecimal(dataRow["term_pct3"]);
            this.txtTermPercent4.Value = dataRow["term_pct4"] == DBNull.Value ? 0 : Convert.ToDecimal(dataRow["term_pct4"]);
            this.txtTermPercent5.Value = dataRow["term_pct5"] == DBNull.Value ? 0 : Convert.ToDecimal(dataRow["term_pct5"]);
            this.txtTermPercent6.Value = dataRow["term_pct6"] == DBNull.Value ? 0 : Convert.ToDecimal(dataRow["term_pct6"]);
            this.txtTermPercent7.Value = dataRow["term_pct7"] == DBNull.Value ? 0 : Convert.ToDecimal(dataRow["term_pct7"]);
            this.txtTermPercent8.Value = dataRow["term_pct8"] == DBNull.Value ? 0 : Convert.ToDecimal(dataRow["term_pct8"]);


            this.txtCreditLimit.Value = Convert.ToDecimal(dataRow["credit"]);
            this.txtCreditUsed.Value = (dataRow["theyowe"] == DBNull.Value) ? 0 : (decimal)dataRow["theyowe"];
            this.txtDiscount.Value = Convert.ToDecimal(dataRow["percent"]);
            this.chkAccountOnHold.Checked = Convert.ToBoolean(dataRow["on_hold"]);
            this.txtAccountHoldReason.Text = dataRow["reason"].ToString();
            this.chkSentToCollection.Checked = Convert.ToBoolean(dataRow["colcsent"]);

            if (dataRow["colcdate"] == DBNull.Value)
            {
                this.txtCollectionDate.SetToNullValue();
            }
            else
            {
                this.txtCollectionDate.Value = Convert.ToDateTime(dataRow["colcdate"]);
            }


            
            this.txtCollectionReason.Text = dataRow["colcrsn"].ToString();
            if (this.acccode != this.bill_acccode)
            {
                this.txtName.Enabled = false;
                this.txtAddr1.Enabled = false;
                this.txtAddr12.Enabled = false;
                this.txtCity1.Enabled = false;
                this.txtState1.Enabled = false;
                this.txtZip1.Enabled = false;
                this.txtCountry.Enabled = false;
                this.txtGracePeriod.Enabled = false;
                this.txtSalesman1.Enabled = false;
                this.txtSalesman2.Enabled = false;
                this.txtSalesman3.Enabled = false;
                this.txtSalesman4.Enabled = false;
                this.txtPercent1.Enabled = false;
                this.txtPercent2.Enabled = false;
                this.txtPercent3.Enabled = false;
                this.txtPercent4.Enabled = false;
                this.txtPayTerm1.Enabled = false;
                this.txtPayTerm2.Enabled = false;
                this.txtPayTerm3.Enabled = false;
                this.txtPayTerm4.Enabled = false;
                this.txtPayTerm5.Enabled = false;
                this.txtPayTerm6.Enabled = false;
                this.txtPayTerm7.Enabled = false;
                this.txtPayTerm8.Enabled = false;
                this.txtTermPercent1.Enabled = false;
                this.txtTermPercent2.Enabled = false;
                this.txtTermPercent3.Enabled = false;
                this.txtTermPercent4.Enabled = false;
                this.txtTermPercent5.Enabled = false;
                this.txtTermPercent6.Enabled = false;
                this.txtTermPercent7.Enabled = false;
                this.txtTermPercent8.Enabled = false;
                this.txtCreditLimit.Enabled = false;
                this.txtCreditUsed.Enabled = false;
                this.txtDiscount.Enabled = false;
                this.chkAccountOnHold.Enabled = false;
                this.txtAccountHoldReason.Enabled = false;
                this.chkSentToCollection.Enabled = false;
                this.txtCollectionDate.Enabled = false;
                this.txtCollectionReason.Enabled = false;
                this.txtMonthlyInterest.Enabled = false;
            }
        }

        /// <summary>
        /// Initializes all dropdown controls in update section
        /// </summary>
        private void InitializeUpdate()
        {
            DataTable data = this.customerService.GetSalesmen();
            DataTable dataPriceFile  = this.customerService.GetPricefile();

            DataView dvSalesmen1 = new DataView(data);
            this.txtSalesman1.Items.Clear();
            this.txtSalesman1.SelectedIndex = -1;
            this.txtSalesman1.DataSource = dvSalesmen1;
            this.txtSalesman1.DisplayMember = "Code";
            this.txtSalesman1.ValueMember  = "Code";

            DataView dvSalesmen2 = new DataView(data);
            this.txtSalesman2.Items.Clear();
            this.txtSalesman2.SelectedIndex = -1;
            this.txtSalesman2.DataSource = dvSalesmen2;
            this.txtSalesman2.DisplayMember = "Code";
            this.txtSalesman2.ValueMember = "Code";

            DataView dvSalesmen3 = new DataView(data);
            this.txtSalesman3.Items.Clear();
            this.txtSalesman3.SelectedIndex = -1;
            this.txtSalesman3.DataSource = dvSalesmen3;
            this.txtSalesman3.DisplayMember = "Code";
            this.txtSalesman3.ValueMember = "Code";

            DataView dvSalesmen4 = new DataView(data);
            this.txtSalesman4.Items.Clear();
            this.txtSalesman4.SelectedIndex = -1;
            this.txtSalesman4.DataSource = dvSalesmen4;
            this.txtSalesman4.DisplayMember = "Code";
            this.txtSalesman4.ValueMember = "Code";


            DataView dvPriceFile = new DataView(dataPriceFile);
            this.txtPriceFile.Items.Clear();
            this.txtPriceFile.SelectedIndex = -1;
            this.txtPriceFile.DataSource = dvPriceFile;
            this.txtPriceFile.DisplayMember = "file_no";
            this.txtPriceFile.ValueMember = "file_no";
            this.txtPayTerm1.Text = "30";
            this.txtTermPercent1.Text = "100";

        }

       

        /// <summary>
        /// Validates registration input
        /// </summary>
        /// <returns>true or false</returns>
        private bool ValidateRegistration()
        {            
            this.errorMessage = string.Empty;

            if (txtName.Text.Trim() == string.Empty)
            {
                this.AddErrorMessage(Resources.Registration_Name_Required_Text);
            }

            if (Convert.ToDecimal(this.txtTermPercent1.Value)  + Convert.ToDecimal(this.txtTermPercent2.Value)   + Convert.ToDecimal(this.txtTermPercent3.Value)  + Convert.ToDecimal(this.txtTermPercent4.Value) + Convert.ToDecimal(this.txtTermPercent5.Value) + Convert.ToDecimal(this.txtTermPercent6.Value)  + Convert.ToDecimal(this.txtTermPercent7.Value) + Convert.ToDecimal(this.txtTermPercent8.Value) != 100)
            {
                this.AddErrorMessage("Invalid Term Percentage");
            }
            return this.errorMessage != string.Empty ? false : true;
        }

        /// <summary>
        /// Validates update data
        /// </summary>
        /// <returns>true or false</returns>
        private bool ValidateUpdate()
        {
            this.errorMessage = string.Empty;

           
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
            if (this.customerId == 0)
                InsertNewRecord();
            else
                UpdateRecord();
        }       


        private void InsertNewRecord()
        {
            try
            {
                // Check if the validation passes
                if (this.ValidateRegistration())
                {
                    DateTime? estdDateTime, lastintDatetime, collectionDatetime;
                    if (!string.IsNullOrEmpty(txtEstDate.Text.Trim()))
                        estdDateTime = Convert.ToDateTime(txtEstDate.Text);
                    else
                        estdDateTime = null;

                    if (!string.IsNullOrEmpty(txtIntChargedTo.Text.Trim()))
                        lastintDatetime = Convert.ToDateTime(txtIntChargedTo.Text.Trim());
                    else
                        lastintDatetime = null;

                    if (!string.IsNullOrEmpty(txtCollectionDate.Text.Trim()))
                        collectionDatetime = Convert.ToDateTime(txtCollectionDate.Text.Trim());
                    else
                        collectionDatetime = null;

                    // Assign the values to the model
                    CustomerModel CustomerModel = new CustomerModel()
                    {

                        ID = 0,
                        ACC = this.acccode,
                        NAME = txtName.Text.Trim(),
                        ADDR1 = txtAddr1.Text.Trim(),
                        ADDR12 = txtAddr12.Text.Trim(),
                        CITY1 = txtCity1.Text.Trim(),
                        STATE1 = txtState1.Text.Trim(),
                        ZIP1 = txtZip1.Text.Trim(),
                        TEL = Convert.ToDecimal(!string.IsNullOrEmpty(txtTel.Value.ToString()) ? txtTel.Value.ToString() : "0"),
                        COUNTRY = txtCountry.Text.Trim(),
                        WWW = txtWebsite.Text.Trim(),
                        EMAIL = txtEmail.Text.Trim(),
                        TAX_ID = txtTaxID.Text.Trim(),
                        EST_DATE = estdDateTime,
                        PRICE_FILE = txtPriceFile.SelectedValue.ToString().Trim(),
                        JBT = txtPriceFile.Text.Trim(),
                        NAME2 = txtName2.Text.Trim(),
                        BILL_ACC = this.bill_acccode,
                        ADDR2 = txtAddr2.Text.Trim(),
                        ADDR22 = txtAddr22.Text.Trim(),
                        CITY2 = txtCity2.Text.Trim(),
                        STATE2 = txtState2.Text.Trim(),
                        ZIP2 = txtZip2.Text.Trim(),
                        FAX = Convert.ToDecimal(!string.IsNullOrEmpty(txtFax.Value.ToString()) ? txtFax.Value.ToString() : "0"),
                        COUNTRY2 = txtCountry2.Text.Trim(),
                        BUYER = txtBuyer.Text.Trim(),
                        SHIP_VIA = this.shipvia,
                        IS_COD = this.is_cod == "N" ? "N" : "Y",
                        COD_TYPE = this.codtype == "N" || this.codtype == "A" ? "A" : "B",
                        ON_MAIL = this.chkMailingList.Checked ? "1" : "0",
                        RESIDENT = this.chkResidentialAddress.Checked ? "1" : "0",
                        NOTE = txtNote.Text.Trim(),
                        INTEREST = Convert.ToDecimal(txtMonthlyInterest.Value.ToString().Trim()),
                        LAST_INT = lastintDatetime,
                        GRACE = Convert.ToDecimal(txtGracePeriod.Value.ToString().Trim()),
                        SALESMAN1 = txtSalesman1.SelectedValue.ToString(),
                        SALESMAN2 = txtSalesman2.SelectedValue.ToString(),
                        SALESMAN3 = txtSalesman3.SelectedValue.ToString(),
                        SALESMAN4 = txtSalesman4.SelectedValue.ToString(),
                        PERCENT1 = Convert.ToDecimal(txtPercent1.Value.ToString().Trim()),
                        PERCENT2 = Convert.ToDecimal(txtPercent2.Value.ToString().Trim()),
                        PERCENT3 = Convert.ToDecimal(txtPercent3.Value.ToString().Trim()),
                        PERCENT4 = Convert.ToDecimal(txtPercent4.Value.ToString().Trim()),
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
                        CREDIT = Convert.ToDecimal(txtCreditLimit.Value.ToString().Trim()),
                        PERCENT = Convert.ToDecimal(txtDiscount.Value.ToString().Trim()),
                        ON_HOLD = chkAccountOnHold.Checked ? true : false,
                        REASON = txtAccountHoldReason.Text.Trim(),
                        COLCSENT = chkSentToCollection.Checked ? true : false,
                        COLCDATE = collectionDatetime,
                        COLCRSN = txtCollectionReason.Text.Trim()

                    };

                    // Call the service method and assign the return status to variable
                    var success = this.customerService.RegisterCustomer(CustomerModel);

                    // if status of success variable is true then display a information else display the error message
                    if (success)
                    {
                        // display the message box
                        Helper.MsgBox(
                            Resources.Registration_Successful_Message,
                            MessageBoxButtons.OK,
                            RadMessageIcon.Info);
                            this.Close();

                    }
                    else
                    {
                        // display the error messge
                        Helper.MsgBox(
                            Resources.Registration_Error_Message,
                            MessageBoxButtons.OK,
                            RadMessageIcon.Error);
                    }
                }
                else
                {
                    // Display the validation failed message
                    Helper.MsgBox(
                        this.errorMessage,
                        MessageBoxButtons.OK,
                        RadMessageIcon.Error);
                }
            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
            }
        }

        private void UpdateRecord()
        {
            try
            {
                // Check if the validation passes
                if (this.ValidateRegistration())
                {
                    DateTime? estdDateTime, lastintDatetime, collectionDatetime;
                    if (!string.IsNullOrEmpty(txtEstDate.Text.Trim()))
                        estdDateTime = Convert.ToDateTime(txtEstDate.Text);
                    else
                        estdDateTime = null;

                    if (!string.IsNullOrEmpty(txtIntChargedTo.Text.Trim()))
                        lastintDatetime = Convert.ToDateTime(txtIntChargedTo.Text.Trim());
                    else
                        lastintDatetime = null;

                    if (!string.IsNullOrEmpty(txtCollectionDate.Text.Trim()))
                        collectionDatetime = Convert.ToDateTime(txtCollectionDate.Text.Trim());
                    else
                        collectionDatetime = null;

                    // Assign the values to the model
                    CustomerModel CustomerModel = new CustomerModel()
                    {
                        ID = this.customerId,
                        ACC = this.acccode,
                        NAME = txtName.Text.Trim(),
                        ADDR1 = txtAddr1.Text.Trim(),
                        ADDR12 = txtAddr12.Text.Trim(),
                        CITY1 = txtCity1.Text.Trim(),
                        STATE1 = txtState1.Text.Trim(),
                        ZIP1 = txtZip1.Text.Trim(),
                        TEL = Convert.ToDecimal(!string.IsNullOrEmpty(txtTel.Value.ToString()) ? txtTel.Value.ToString() : "0"),
                        COUNTRY = txtCountry.Text.Trim(),
                        WWW = txtWebsite.Text.Trim(),
                        EMAIL = txtEmail.Text.Trim(),
                        TAX_ID = txtTaxID.Text.Trim(),
                        EST_DATE = estdDateTime,
                        PRICE_FILE = txtPriceFile.SelectedValue.ToString().Trim(),
                        JBT = txtPriceFile.Text.Trim(),
                        NAME2 = txtName2.Text.Trim(),
                        BILL_ACC = this.bill_acccode,
                        ADDR2 = txtAddr2.Text.Trim(),
                        ADDR22 = txtAddr22.Text.Trim(),
                        CITY2 = txtCity2.Text.Trim(),
                        STATE2 = txtState2.Text.Trim(),
                        ZIP2 = txtZip2.Text.Trim(),
                        FAX = Convert.ToDecimal(!string.IsNullOrEmpty(txtFax.Value.ToString()) ? txtFax.Value.ToString() : "0"),
                        COUNTRY2 = txtCountry2.Text.Trim(),
                        BUYER = txtBuyer.Text.Trim(),
                        SHIP_VIA = this.shipvia,
                        IS_COD = this.is_cod == "N" ? "N" : "Y",
                        COD_TYPE = this.codtype == "N"  || this.codtype == "A" ? "A" : "B",
                        ON_MAIL = this.chkMailingList.Checked ? "1" : "0",
                        RESIDENT = this.chkResidentialAddress.Checked ? "1" : "0",
                        NOTE = txtNote.Text.Trim(),
                        INTEREST = Convert.ToDecimal(txtMonthlyInterest.Value.ToString().Trim()),
                        LAST_INT = lastintDatetime,
                        GRACE = Convert.ToDecimal(txtGracePeriod.Value.ToString().Trim()),
                        SALESMAN1 = txtSalesman1.SelectedValue.ToString(),
                        SALESMAN2 = txtSalesman2.SelectedValue.ToString(),
                        SALESMAN3 = txtSalesman3.SelectedValue.ToString(),
                        SALESMAN4 = txtSalesman4.SelectedValue.ToString(),
                        PERCENT1 = Convert.ToDecimal(txtPercent1.Value.ToString().Trim()),
                        PERCENT2 = Convert.ToDecimal(txtPercent2.Value.ToString().Trim()),
                        PERCENT3 = Convert.ToDecimal(txtPercent3.Value.ToString().Trim()),
                        PERCENT4 = Convert.ToDecimal(txtPercent4.Value.ToString().Trim()),
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
                        CREDIT = Convert.ToDecimal(txtCreditLimit.Value.ToString().Trim()),
                        PERCENT = Convert.ToDecimal(txtDiscount.Value.ToString().Trim()),
                        ON_HOLD = chkAccountOnHold.Checked ? true : false,
                        REASON = txtAccountHoldReason.Text.Trim(),
                        COLCSENT = chkSentToCollection.Checked ? true : false,
                        COLCDATE = collectionDatetime,
                        COLCRSN = txtCollectionReason.Text.Trim()
                       
                    };



                    // Call the service method and assign the return status to variable
                    var success = this.customerService.UpdateCustomer(CustomerModel);

                    // if status of success variable is true then display a information else display the error message
                    if (success)
                    {
                        // display the message box
                        Helper.MsgBox(
                            Resources.Update_Successful_Message,
                            MessageBoxButtons.OK,
                            RadMessageIcon.Info);

                        this.Close();
                       
                    }
                    else
                    {
                        // display the error messge
                        Helper.MsgBox(
                            Resources.Registration_Error_Message,
                            MessageBoxButtons.OK,
                            RadMessageIcon.Error);
                    }
                }
                else
                {
                    // Display the validation failed message
                    Helper.MsgBox(
                        this.errorMessage,
                        MessageBoxButtons.OK,
                        RadMessageIcon.Error);
                }
            }
            catch (Exception ex)
            {
                this.ShowErrorMessage(ex);
            }
        }
      

        private void txtName2_Enter(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.txtName2.Text))
            {
                this.txtName2.Text = this.txtName.Text;
                this.txtAddr2.Text = this.txtAddr1.Text;
                this.txtAddr22.Text = this.txtAddr12.Text;
                this.txtZip2.Text = this.txtZip1.Text;
                this.txtCountry2.Text = this.txtCountry.Text;
                this.txtState2.Text = this.txtState1.Text;
                this.txtCity2.Text = this.txtCity1.Text;
            }
        }



        private void frmNewCustomer_KeyDown(object sender, KeyEventArgs e)
        {
           
            if (e.KeyValue == 13)
            {
                if (this.ActiveControl != null && this.ActiveControl.Name != "txtNote")
                {
                   
                    this.SelectNextControl(this.ActiveControl, true, true, true, true);
                    e.Handled = true;
                }
                
                
            }
        }


        private void rdoGround_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            string result = null;
            foreach (Control control in this.grpShipVia.Controls)
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

        private void chkAccountOnHold_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            this.txtAccountHoldReason.ReadOnly = !this.chkAccountOnHold.Checked;
        }

        private void chkSentToCollection_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            this.txtCollectionDate.Enabled = this.chkSentToCollection.Checked;
            this.txtCollectionReason.ReadOnly = !this.chkSentToCollection.Checked;
        }

        private void chkCOD_ToggleStateChanged(object sender, StateChangedEventArgs args)
        {
            this.is_cod = this.chkCOD.Checked ? "Y" : "N";
            this.codtype = this.chkCOD.Checked ? "B" : "A";
        }

        private void frmNewCustomer_Load(object sender, EventArgs e)
        {

        }
    }
}
