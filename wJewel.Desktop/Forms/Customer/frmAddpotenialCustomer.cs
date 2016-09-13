using IshalInc.wJewel.Desktop.Libraries;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using System;
using System.Data;
using System.Windows.Forms;
using IshalInc.wJewel.Data.BusinessService;
using IshalInc.wJewel.Data.DataModel;
using IshalInc.wJewel.Desktop.Properties;

namespace IshalInc.wJewel.Desktop.Forms
{
    public partial class frmAddpotenialCustomer : RadForm
    {
       private IPotentialCustomerService potcustomerService;

        private string errorMessage;

        private string customerACC;
        public frmAddpotenialCustomer()
        {
            InitializeComponent();
            potcustomerService = new PotentialCustomerService();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(potentialcustomeremail.Text.Trim() != null)
            {
                System.Text.RegularExpressions.Regex rEmail = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");

                if (potentialcustomeremail.Text.Length > 0 && potentialcustomeremail.Text.Trim().Length != 0)
                {
                    if (!rEmail.IsMatch(potentialcustomeremail.Text.Trim()))
                    {
                        /* Helper.MsgBox(
                              Resources.Registration_Error_Message,
                              MessageBoxButtons.OK,
                              RadMessageIcon.Error);*/
                        MessageBox.Show("Valid Email Required");
                        return ;
                    }
                }
            }
            
            if (this.customerACC == null)
            {
                //MessageBox.Show("no acc");
                if (this.ValidateRegistration())
                {

                    DateTime? estdDateTime, lastintDatetime, collectionDatetime;
                    if (!string.IsNullOrEmpty(potentialcustomerest.Text.Trim()))
                        estdDateTime = Convert.ToDateTime(potentialcustomerest.Text);
                    else
                        estdDateTime = null;
                    float ss = 0;
                    if (potentialcustomernoofstores.Text.Trim() != null)
                    {
                        //ss =potentialcustomernoofstores.Text.Trim())
                    }
                        PotentialcustomerModel PotentialcustomerModel = new PotentialcustomerModel()
                    {




                        ACC = "1234",
                        NAME = potentialcustomername.Text.Trim(),
                        ADDR1 = potentialcustomeraddress1.Text.Trim(),
                        ADDR12 = potentialcustomeraddress2.Text.Trim(),
                        CITY1 = potentialcustomercity.Text.Trim(),
                        STATE1 = potentialcustomerstate.Text.Trim(),
                        ZIP1 = potentialcustomerzipcode.Text.Trim(),
                        COUNTRY = potentialcustomercountry.Text.Trim(),
                        BUYER = potentialcustomerwebsite.Text.Trim(),
                        WWW = potentialcustomerwebsite.Text.Trim(),
                        EMAIL = potentialcustomeremail.Text.Trim(),
                        NOTE1 = potentialcustomernote.Text.Trim(),
                        NOTE2 = potentialcustomernote1.Text.Trim(),
                        //TEL = Convert.ToDecimal("0"),
                        TEL = Convert.ToDecimal(!string.IsNullOrEmpty(potentialcustomertel.Value.ToString()) ? potentialcustomertel.Value.ToString() : "0"),
                        FAX = Convert.ToDecimal(!string.IsNullOrEmpty(potentialcustomerfax.Value.ToString()) ? potentialcustomerfax.Value.ToString() : "0"),

                        //FAX = Convert.ToDecimal("0"),
                        EST_DATE = estdDateTime,
                        JBT = potentialcustomerjbt.Text.Trim(),
                      
                        STORE = "0",
                        SOURCE = potentialcustomersource.Text.Trim(),
                        SALESMAN = potentialcustomersalesman.Text.Trim(),
                        DNB = ""
                        //CHANGED = Convert.ToBoolean("0")

                    };
                    bool success = potcustomerService.AddPotentialCustomer(PotentialcustomerModel);
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
            else
            {
                UpdateRecord();
            }
        }
        private void UpdateRecord()
        {
            if (this.ValidateRegistration())
            {

                DateTime? estdDateTime, lastintDatetime, collectionDatetime;
                if (!string.IsNullOrEmpty(potentialcustomerest.Text.Trim()))
                    estdDateTime = Convert.ToDateTime(potentialcustomerest.Text);
                else
                    estdDateTime = null;

                PotentialcustomerModel PotentialcustomerModel = new PotentialcustomerModel()
                {




                    ACC = "1234",
                    NAME = potentialcustomername.Text.Trim(),
                    ADDR1 = potentialcustomeraddress1.Text.Trim(),
                    ADDR12 = potentialcustomeraddress2.Text.Trim(),
                    CITY1 = potentialcustomercity.Text.Trim(),
                    STATE1 = potentialcustomerstate.Text.Trim(),
                    ZIP1 = potentialcustomerzipcode.Text.Trim(),
                    COUNTRY = potentialcustomercountry.Text.Trim(),
                    BUYER = potentialcustomerwebsite.Text.Trim(),
                    WWW = potentialcustomerwebsite.Text.Trim(),
                    EMAIL = potentialcustomeremail.Text.Trim(),
                    NOTE1 = potentialcustomernote.Text.Trim(),
                    NOTE2 = potentialcustomernote1.Text.Trim(),
                    //TEL = Convert.ToDecimal("0"),
                    TEL = Convert.ToDecimal(!string.IsNullOrEmpty(potentialcustomertel.Value.ToString()) ? potentialcustomertel.Value.ToString() : "0"),
                    FAX = Convert.ToDecimal(!string.IsNullOrEmpty(potentialcustomerfax.Value.ToString()) ? potentialcustomerfax.Value.ToString() : "0"),

                    //FAX = Convert.ToDecimal("0"),
                    EST_DATE = estdDateTime,
                    JBT = potentialcustomerjbt.Text.Trim(),
                    STORE = potentialcustomernoofstores.Text.Trim(),
                    SOURCE = potentialcustomersource.Text.Trim(),
                    SALESMAN = potentialcustomersalesman.Text.Trim(),
                    DNB = ""
                    //CHANGED = Convert.ToBoolean("0")

                };
                 bool success = potcustomerService.UpdatePotentialCustomer(PotentialcustomerModel);
                //bool success = true;
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
        private bool ValidateRegistration()
        {
            this.errorMessage = string.Empty;

            if (potentialcustomername.Text.Trim() == string.Empty)
            {
                this.AddErrorMessage(Resources.Registration_Name_Required_Text);
            }

           
            return this.errorMessage != string.Empty ? false : true;
        }
        private void AddErrorMessage(string error)
        {
            if (this.errorMessage == string.Empty)
            {
                this.errorMessage = Resources.Error_Message_Header + "\n\n";
            }

            this.errorMessage += error + "\n";
        }
        private void radPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
        public frmAddpotenialCustomer(string accountcode, DataRow custRow, string customerid)
        {

            this.InitializeComponent();
            this.Icon = Helper.MakeIcon(IshalInc.wJewel.Desktop.Properties.Resources.customernew, 24, true);
           // this.txtEstDate.Value = DateTime.Now;
           // this.txtIntChargedTo.SetToNullValue();
           // this.txtCollectionDate.SetToNullValue();
           // this.acccode = accountcode;
           // this.bill_acccode = bill_acccode;
            this.customerACC = customerid;
            this.potcustomerService = new PotentialCustomerService();
           // InitializeUpdate();
            if (custRow != null)
            {
                LoadData(custRow);
            }
           // this.tabControl1.SelectedPage = this.tabPage1;
           // this.txtName.Focus();

        }

        private void LoadData(DataRow dataRow)
        {

            this.potentialcustomername.Text = dataRow["name"].ToString().Trim();
            this.potentialcustomeraddress1.Text = dataRow["addr1"].ToString().Trim();
           // this.potentialcustomeraddress2.Text = dataRow["addr12"].ToString().Trim();
            this.radTextBox1.Text = dataRow["city1"].ToString().Trim();
            this.potentialcustomerstate.Text = dataRow["state1"].ToString().Trim();
            this.potentialcustomerzipcode.Text = dataRow["zip1"].ToString().Trim();
            this.potentialcustomercountry.Text = dataRow["country"].ToString().Trim();
            this.potentialcustomeremail.Text = dataRow["email"].ToString().Trim();
            this.potentialcustomerjbt.Text = dataRow["jbt"].ToString().Trim();
            this.potentialcustomernoofstores.Text = dataRow["stores"].ToString().Trim();
            this.potentialcustomersource.Text = dataRow["source"].ToString().Trim();
            this.potentialcustomersalesman.Text = dataRow["salesman"].ToString().Trim();
            this.potentialcustomerbuyer.Text = dataRow["buyer"].ToString().Trim();
            this.potentialcustomerwebsite.Text = dataRow["www"].ToString().Trim();
            this.potentialcustomernote.Text = dataRow["note1"].ToString().Trim();
            this.potentialcustomernote1.Text = dataRow["note2"].ToString().Trim();
            this.potentialcustomertel.Text = dataRow["tel"].ToString();
            this.potentialcustomerfax.Text = dataRow["fax"].ToString();
            if (dataRow["est_date"] == DBNull.Value)
            {
                this.potentialcustomerest.SetToNullValue();
            }
            else
            {
                this.potentialcustomerest.Value = Convert.ToDateTime(dataRow["est_date"]);
            }
            /* this.txtAddr1.Text = dataRow["addr1"].ToString().Trim();
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

             this.chkMailingList.Checked = (dataRow["on_mail"] == DBNull.Value ? false : dataRow["on_mail"].ToString().Trim() == "1" ? true : false);
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
             */

            /*   switch (dataRow["ship_via"].ToString())
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
               }*/
            /*

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
            */

            /*  this.txtCreditLimit.Value = Convert.ToDecimal(dataRow["credit"]);
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
              }*/



            /* this.txtCollectionReason.Text = dataRow["colcrsn"].ToString();
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
             }*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = RadMessageBox.Show("Are you sure you want to cancel the changes?", "Add / Edit Customer", MessageBoxButtons.YesNo, RadMessageIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void potentialcustomernoofstores_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmAddpotenialCustomer_Load(object sender, EventArgs e)
        {

        }
    }
}
