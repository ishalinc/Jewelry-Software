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
using Telerik.WinControls.UI.Localization;

namespace IshalInc.wJewel.Desktop.Forms
{
    public partial class frmEditRepairOrderInvoiceBasedOnInvoceId : Telerik.WinControls.UI.RadForm
    {

        private ICustomerService customerService;

        private IOrderRepairService orderrepairService;

        private DataRow custRow;

        private DataRow orderRow;

        private DataView dvCustomerSearch;
        string invoicenumber = string.Empty;
        public frmEditRepairOrderInvoiceBasedOnInvoceId()
        {
            InitializeComponent();
        }

        public frmEditRepairOrderInvoiceBasedOnInvoceId(string inv_no)
        {
            InitializeComponent();
            invoicenumber = inv_no;
            invno.Text = inv_no;
            orderrepairService = new OrderRepairService();
            DataTable data = orderrepairService.GetInvoiceHeaderInformatioBasedOnInvoiceNumber(inv_no);
            if (data.Rows.Count > 0)
            {
               
                ordcustcode.Text = data.Rows[0].Field<string>("ACC");
                orderrepairno.Text = data.Rows[0].Field<string>("PON");
                ordshipto.Text = data.Rows[0].Field<string>("NAME");
                orderadd1.Text = data.Rows[0].Field<string>("ADDR1");
                orderadd2.Text = data.Rows[0].Field<string>("ADDR2");
                ordercity.Text = data.Rows[0].Field<string>("CITY");
                orderstate.Text = data.Rows[0].Field<string>("STATE");
                orderzip.Text = data.Rows[0].Field<string>("ZIP");
                ordercountry.Text = data.Rows[0].Field<string>("COUNTRY");
                billingaccount.Text = data.Rows[0].Field<string>("ACC");
                radTexbillingaddress.Text = data.Rows[0].Field<string>("ADDR1");
                billingaddress2.Text = data.Rows[0].Field<string>("ADDR2");
                billingcity.Text = data.Rows[0].Field<string>("CITY");
                billingstate.Text = data.Rows[0].Field<string>("STATE");
                billingzip.Text = data.Rows[0].Field<string>("ZIP");
                billingcountry.Text = data.Rows[0].Field<string>("COUNTRY");
                radTextBox12.Text = data.Rows[0].Field<decimal>("TERM1").ToString();
                radTextBox13.Text = data.Rows[0].Field<decimal>("TERM_PCT1").ToString();
                radTextBox15.Text = data.Rows[0].Field<decimal>("TERM2").ToString();
                radTextBox14.Text = data.Rows[0].Field<decimal>("TERM_PCT2").ToString();
                radTextBox17.Text = data.Rows[0].Field<decimal>("TERM3").ToString();
                radTextBox16.Text = data.Rows[0].Field<decimal>("TERM_PCT3").ToString();
                radTextBox19.Text = data.Rows[0].Field<decimal>("TERM4").ToString();
                radTextBox18.Text = data.Rows[0].Field<decimal>("TERM_PCT4").ToString();
                repairordernote.Text = data.Rows[0].Field<string>("MESSAGE").ToString();
                string repairordernumber = data.Rows[0].Field<string>("PON").ToString();
                if (data.Rows[0].Field<string>("IS_COD").ToString() == "N")
                    shipbynoncode.IsChecked = true;
                if (data.Rows[0].Field<string>("IS_COD").ToString() == "A")
                    shipbycodcash.IsChecked = true;
                if (data.Rows[0].Field<string>("IS_COD").ToString() == "B")
                    shipbycodcheck.IsChecked = true;

                if (data.Rows[0].Field<string>("VIA_UPS").ToString() == "G")
                    rdoGround.IsChecked = true;
                if (data.Rows[0].Field<string>("VIA_UPS").ToString() == "O")
                    rdoExpressSaver.IsChecked = true;
                if (data.Rows[0].Field<string>("VIA_UPS").ToString() == "B")
                    rdo2Day.IsChecked = true;
                if (data.Rows[0].Field<string>("VIA_UPS").ToString() == "R")
                    rdoNextDatStd.IsChecked = true;
                if (data.Rows[0].Field<string>("VIA_UPS").ToString() == "E")
                    rdoNextDayPriority.IsChecked = true;
                if (data.Rows[0].Field<string>("VIA_UPS").ToString() == "F")
                    rdoNextDayFirst.IsChecked = true;
                if (data.Rows[0].Field<string>("VIA_UPS").ToString() == "L")
                    rdoNextDayLetter.IsChecked = true;
                if (data.Rows[0].Field<string>("VIA_UPS").ToString() == "S")
                    rdoSaturday.IsChecked = true;
                if (data.Rows[0].Field<string>("VIA_UPS").ToString() == "M")
                    rdoMail.IsChecked = true;
                if (data.Rows[0].Field<string>("VIA_UPS").ToString() == "D")
                    rdoDelivery.IsChecked = true;
                if (data.Rows[0].Field<string>("VIA_UPS").ToString() == "P")
                    rdoPickup.IsChecked = true;
                if (data.Rows[0].Field<string>("VIA_UPS").ToString() == "N")
                    rdoNone.IsChecked = true;


                orderrepairService = new OrderRepairService();
                DataTable gridinfo = orderrepairService.GetInvoiceInformationForUpdateInvoice(repairordernumber, inv_no);
                radGridView1.DataSource = gridinfo;
                radGridView1.Columns[0].Width = 80;
                radGridView1.Columns[0].ReadOnly = true;
                radGridView1.Columns[1].Width = 80;
                radGridView1.Columns[1].ReadOnly = true;
                radGridView1.Columns[2].Width = 80;
                radGridView1.Columns[2].ReadOnly = true;
                radGridView1.Columns[3].Width = 80;
                radGridView1.Columns[3].ReadOnly = true;
                radGridView1.Columns[4].Width = 80;
                radGridView1.Columns[4].ReadOnly = true;
                radGridView1.Columns[5].Width = 80;
                radGridView1.Columns[5].ReadOnly = true;
                radGridView1.Columns[6].Width = 80;
                radGridView1.Columns[6].DataType = typeof(Int32);
                radGridView1.Columns[7].Width = 75;
                radGridView1.Columns[7].FormatString = "{0:c}";
                radGridView1.Columns[8].Width = 75;
                radGridView1.Columns[8].ReadOnly = true;
                radGridView1.Columns[9].IsVisible = false;
                radGridView1.ShowGroupPanel = false;
                RadGridLocalizationProvider.CurrentProvider = new CustomLocalizationProvider();

            }


            calculateinsurefor();
            calculatesubtotal();
            Calculatesnh();
            searchtotalwithoverridesnh();
        }
        private void searchtotalwithoverridesnh()
        {
            radTextBox11.Text = (Convert.ToDecimal(radTextBox10.Text) + Convert.ToDecimal(radTextBox8.Text) + Convert.ToDecimal(radTextBox9.Text)).ToString();
        }
        private void calculateinsurefor()
        {

            decimal insurefor = 0;
            decimal discount = 0;
            string cusname = ordcustcode.Text;
            int qty = 0;
            DataTable customerInformation = orderrepairService.GetCustomerInformationBasedOnAcc(cusname);
            if (cusname != string.Empty)
            {
                if (customerInformation.Rows[0].Field<decimal>("PERCENT") != 0)
                    discount = customerInformation.Rows[0].Field<decimal>("PERCENT");
            }
            for (int rows = 0; rows < radGridView1.Rows.Count; rows++)
            {

                string itemname = radGridView1.Rows[rows].Cells[0].Value.ToString();
                orderrepairService = new OrderRepairService();
                string styleprice = orderrepairService.GetStyleInformationForRepairOrderInvoice(itemname);
                decimal prince = decimal.Parse(styleprice);
                string selqty = radGridView1.Rows[rows].Cells[6].Value.ToString();

                if (selqty != string.Empty)
                    qty = int.Parse(selqty);

                insurefor = insurefor + (prince * (100 - discount) / 100) * qty;

            }

            radTextBox9.Text = insurefor.ToString();
            

        }

        private void calculatesubtotal()
        {
            decimal subtotal = 0;
            decimal qty = 0;
            decimal repairprice = 0;
            for (int rows = 0; rows < radGridView1.Rows.Count; rows++)
            {
                if (radGridView1.Rows[rows].Cells[7].Value.ToString() != null && radGridView1.Rows[rows].Cells[7].Value.ToString() != string.Empty)
                    repairprice = decimal.Parse(radGridView1.Rows[rows].Cells[7].Value.ToString());
                if (radGridView1.Rows[rows].Cells[6].Value.ToString() != null && radGridView1.Rows[rows].Cells[6].Value.ToString() != string.Empty)
                    qty = decimal.Parse(radGridView1.Rows[rows].Cells[6].Value.ToString());

                subtotal = subtotal + (repairprice * qty);
            }

            radTextBox8.Text = subtotal.ToString();
        }

        private void Calculatesnh()
        {
            string zip = string.Empty;
            string cviaups = string.Empty;
            string cearly = "R";
            string cstate = string.Empty;
            string is_cod = string.Empty;
            if (shipbynoncode.IsChecked)
                is_cod = "N";
            if (shipbycodcash.IsChecked)
                is_cod = "A";
            if (shipbycodcheck.IsChecked)
                is_cod = "B";

            if (orderzip.Text != String.Empty)
                zip = orderzip.Text;

            /* if (shipbyregular.IsChecked)
                 cearly = "R";
             if (shipbyearlyam.IsChecked)
                 cearly = "E";
             if (shipbyupsserver.IsChecked)
                 cearly = "S";*/

            if (rdoGround.IsChecked)
                cviaups = "G";
            if (rdoExpressSaver.IsChecked)
                cviaups = "O";
            if (rdo2Day.IsChecked)
                cviaups = "B";
            if (rdoNextDatStd.IsChecked)
                cviaups = "R";
            if (rdoNextDayPriority.IsChecked)
                cviaups = "E";
            if (rdoNextDayFirst.IsChecked)
                cviaups = "F";
            if (rdoNextDayLetter.IsChecked)
                cviaups = "L";
            if (rdoSaturday.IsChecked)
                cviaups = "S";
            if (rdoMail.IsChecked)
                cviaups = "M";
            if (rdoDelivery.IsChecked)
                cviaups = "D";
            if (rdoPickup.IsChecked)
                cviaups = "P";
            if (rdoNone.IsChecked)
                cviaups = "N";

            if (orderstate.Text != String.Empty)
                cstate = orderstate.Text;
            //orderresidential
            decimal sandh = Convert.ToDecimal(Helper.ShippingHandling(zip, cviaups, cearly, cstate, this.radCheckBox1.Checked, Convert.ToDecimal(this.radTextBox8.Text), is_cod, 1));
            radTextBox10.Text = sandh.ToString();
            radTextBox11.Text = (sandh + Convert.ToDecimal(radTextBox8.Text) + Convert.ToDecimal(radTextBox9.Text)).ToString();
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            int flag = 0;
            for (int rows = 0; rows < radGridView1.Rows.Count; rows++)
            {
                if (radGridView1.Rows[rows].Cells[7].Value != "")
                {
                    flag = 1;
                }

            }
            if (flag == 0)
            {
                MessageBox.Show("Nothing To do Invoice");
                return;
            }
            else
            {
                UpdateRepairOrderData();
            }
        }

        private void UpdateRepairOrderData()
        {

            string cviaups = string.Empty;
            string is_cod = string.Empty;
            if (shipbynoncode.IsChecked)
                is_cod = "N";
            if (shipbycodcash.IsChecked)
                is_cod = "A";
            if (shipbycodcheck.IsChecked)
                is_cod = "B";

            if (rdoGround.IsChecked)
                cviaups = "G";
            if (rdoExpressSaver.IsChecked)
                cviaups = "O";
            if (rdo2Day.IsChecked)
                cviaups = "B";
            if (rdoNextDatStd.IsChecked)
                cviaups = "R";
            if (rdoNextDayPriority.IsChecked)
                cviaups = "E";
            if (rdoNextDayFirst.IsChecked)
                cviaups = "F";
            if (rdoNextDayLetter.IsChecked)
                cviaups = "L";
            if (rdoSaturday.IsChecked)
                cviaups = "S";
            if (rdoMail.IsChecked)
                cviaups = "M";
            if (rdoDelivery.IsChecked)
                cviaups = "D";
            if (rdoPickup.IsChecked)
                cviaups = "P";
            if (rdoNone.IsChecked)
                cviaups = "N";
            decimal discount = 0;
            DataTable customerInformation = orderrepairService.GetCustomerInformationBasedOnAcc(ordcustcode.Text);
            if (ordcustcode.Text != string.Empty)
            {
                if (customerInformation.Rows[0].Field<decimal>("PERCENT") != 0)
                    discount = customerInformation.Rows[0].Field<decimal>("PERCENT");
            }
            string isresident = "N";
            //string invoicenumber = Helper.GetNextReceiptNo();
            //string invoicenumber = Helper.GetNextReceiptNo();
            string invoicenumber = invno.Text;
            if (radCheckBox1.Checked == true)
            {
                isresident = "Y";
            }

            RepairorderModel RepairorderModel = new RepairorderModel()
            {
                INV_NO = invoicenumber,
                ACC = ordcustcode.Text,
                BACC = ordcustcode.Text,
                ADD_COST = "0",
                NAME = ordshipto.Text,
                SNH = Convert.ToDecimal(radTextBox10.Text),
                DATE = DateTime.Now,
                PON = orderrepairno.Text,
                V_CTL_NO = "REPAIR",
                MESSAGE = repairordernote.Text,
                GR_TOTAL = radTextBox11.Text,
                ADDR1 = orderadd1.Text,
                ADDR2 = orderadd2.Text,
                CITY = ordercity.Text,
                STATE = orderstate.Text,
                ZIP = orderzip.Text,
                COUNTRY = ordercountry.Text,
                VIA_UPS = cviaups,
                IS_COD = is_cod,
                WEIGHT = 0,
                TERM1 = radTextBox12.Text,
                TERM_PCT1 = radTextBox13.Text,
                TERM2 = radTextBox15.Text,
                TERM_PCT2 = radTextBox14.Text,
                TERM3 = radTextBox17.Text,
                TERM_PCT3 = radTextBox16.Text,
                TERM4 = radTextBox19.Text,
                TERM_PCT4 = radTextBox18.Text,
                INSURED = radTextBox9.Text,
                EARLY = "R",
                PERCENT = discount,
                RESIDENT = isresident
            };
            orderrepairService = new OrderRepairService();
            string status = orderrepairService.UpdateRepairOrderInvoice(RepairorderModel);
            RepairorderModel = null;
            UpdateOrderInvoiceDataIntoInSpIt1(invoicenumber);
            UpdateRpairOrderItemsFromInvoice();
            UpdateOrderRepairDataInRepInv(invoicenumber);
            UpdateDataIntoOrderItemTable();
            //UpdateRpairOrderItemsFromInvoice();
            //SaveOrderRepairDataInRepInv(invoicenumber);
            // InsertDataIntoOrderItemTable();
            /*
              SaveOrderInvoiceDataIntoInSpIt(invoicenumber);
             UpdateRpairOrderItems();
             SaveOrderRepairDataInRepInv(invoicenumber);
             InsertDataIntoOrderItemTable();
              */
            Helper.MsgBox("Invoice Updated Successfully", Telerik.WinControls.RadMessageIcon.Info);
            frmPringRepairInvoice printinvoice = new frmPringRepairInvoice(invoicenumber);

            printinvoice.StartPosition = FormStartPosition.CenterScreen;

            printinvoice.Show();
            this.Dispose();
        }
        private void UpdateOrderRepairDataInRepInv(string invoicenumber)
        {
            for (int rows = 0; rows < radGridView1.Rows.Count; rows++)
            {
                RepairorderModel RepairorderModel = new RepairorderModel()
                {
                    REPAIR_NO = orderrepairno.Text,
                    LINE = (rows + 1).ToString(),
                    INV_NO = invoicenumber,
                    QTY = radGridView1.Rows[rows].Cells[5].Value.ToString()

                };
                string status = orderrepairService.UpdateDataIntoRepInvTable(RepairorderModel);
            }
        }
        private void UpdateOrderInvoiceDataIntoInSpIt1(string invoicenumber)
        {
            for (int rows = 0; rows < radGridView1.Rows.Count; rows++)
            {
                RepairorderModel RepairorderModel = new RepairorderModel()
                {
                    INV_NO = invoicenumber,
                    DESC = radGridView1.Rows[rows].Cells[0].Value.ToString(),
                    PRICE = (Convert.ToDecimal(radGridView1.Rows[rows].Cells[6].Value) * Convert.ToDecimal(radGridView1.Rows[rows].Cells[7].Value)).ToString(),
                    QTY = radGridView1.Rows[rows].Cells[6].Value.ToString()

                };
                string status = orderrepairService.UpdateOrderInvoiceDataIntoInSpItTable(RepairorderModel);
            }
        }
        private void UpdateRpairOrderItemsFromInvoice()
        { 
            for (int rows = 0; rows < radGridView1.Rows.Count; rows++)
            {
                RepairorderModel RepairorderModel = new RepairorderModel()
                {
                    STYLE = radGridView1.Rows[rows].Cells[0].Value.ToString(),
                    SHIPPED = radGridView1.Rows[rows].Cells[6].Value.ToString(),
                    PRICE = (Convert.ToDecimal(radGridView1.Rows[rows].Cells[6].Value) * Convert.ToDecimal(radGridView1.Rows[rows].Cells[7].Value)).ToString(),
                    QTY = radGridView1.Rows[rows].Cells[5].Value.ToString(),
                    PON = orderrepairno.Text,
                    OLD_QTY = radGridView1.Rows[rows].Cells[9].Value.ToString()

                    
                };
                string status = orderrepairService.UpdateRpairOrderItemsTableFromEditInvoice(RepairorderModel);
            }
        }
        private void radGridView1_CellValueChanged(object sender, GridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 7 && e.Value != "")
            {
                calculateinsurefor();
                calculatesubtotal();
                Calculatesnh();
            }
            if (e.ColumnIndex == 6 && e.Value != "")
            {
                checkgridquantity();


            }
        }
        private void SaveOrderRepairDataInRepInv(string invoicenumber)
        {
            for (int rows = 0; rows < radGridView1.Rows.Count; rows++)
            {
                RepairorderModel RepairorderModel = new RepairorderModel()
                {
                    REPAIR_NO = orderrepairno.Text,
                    LINE = (rows + 1).ToString(),
                    INV_NO = invoicenumber,
                    QTY = radGridView1.Rows[rows].Cells[5].Value.ToString()
                   
                };
                string status = orderrepairService.InsertDataIntoRepInvTable(RepairorderModel);
            }
        }



        private void UpdateDataIntoOrderItemTable()
        {
            for (int rows = 0; rows < radGridView1.Rows.Count; rows++)
            {
                MessageBox.Show(radGridView1.Rows[rows].Cells[9].Value.ToString());
                RepairorderModel RepairorderModel = new RepairorderModel()
                {
                    SHIPPED = radGridView1.Rows[rows].Cells[6].Value.ToString(),
                    STYLE = radGridView1.Rows[rows].Cells[0].Value.ToString(),
                    PRICE = (Convert.ToDecimal(radGridView1.Rows[rows].Cells[6].Value) * Convert.ToDecimal(radGridView1.Rows[rows].Cells[7].Value)).ToString(),
                    QTY = radGridView1.Rows[rows].Cells[5].Value.ToString(),
                    PON = orderrepairno.Text,
                    DUE_DATE = Convert.ToString(DateTime.Now),
                    BARCODE = radGridView1.Rows[rows].Cells[8].Value.ToString(),
                    OLD_QTY = radGridView1.Rows[rows].Cells[9].Value.ToString()

                };
                string status = orderrepairService.UpdateDataIntoOrderItemTable(RepairorderModel);
            }
        }
        private void checkgridquantity()
        {
            int flag = 0;
            for (int rows = 0; rows < radGridView1.Rows.Count; rows++)
            {

                if (!(radGridView1.Rows[rows].Cells[5].Value is DBNull) && !(radGridView1.Rows[rows].Cells[6].Value is DBNull))
                {
                    if (Convert.ToInt32(radGridView1.Rows[rows].Cells[5].Value) < Convert.ToInt32(radGridView1.Rows[rows].Cells[6].Value))
                    {
                        MessageBox.Show("Quantity cannot be more than " + radGridView1.Rows[rows].Cells[5].Value);
                        radGridView1.Rows[rows].Cells[6].Value = 0;
                        flag = 1;
                    }
                }

            }
            if (flag == 0)
            {
                calculateinsurefor();
                calculatesubtotal();
                Calculatesnh();
            }
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }
    }
}
