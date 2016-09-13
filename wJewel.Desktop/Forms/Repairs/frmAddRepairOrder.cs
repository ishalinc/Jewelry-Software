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
    public partial class frmAddrepairorder : Telerik.WinControls.UI.RadForm
    {
        private ICustomerService customerService;

        private DataView dvCustomerSearch;

        private IOrderRepairService orderrepairService;

        long tt = 0;
        public frmAddrepairorder()
        {
            this.orderrepairService = new OrderRepairService();
            InitializeComponent();
            this.orderentrydate.Value = DateTime.Now;
            this.ordercanceldate.Value = DateTime.Now;

        }
        public frmAddrepairorder(string customercode, DataRow custrow, string ordnumber)
        {
            InitializeComponent();
            this.orderentrydate.Value = DateTime.Now;
            this.ordercanceldate.Value = DateTime.Now;
            ordcustcode.Text = custrow["acc"].ToString().Trim();
            ordshipto.Text = custrow["name"].ToString().Trim();
            orderadd1.Text = custrow["addr1"].ToString().Trim();
            orderadd2.Text = custrow["addr12"].ToString().Trim();
            ordercity.Text = custrow["city1"].ToString().Trim();
            orderstate.Text = custrow["state1"].ToString().Trim();
            orderzip.Text = custrow["zip1"].ToString().Trim();
            ordercountry.Text = custrow["country"].ToString().Trim();
            orderrepairno.Text = ordnumber;
            RadGridLocalizationProvider.CurrentProvider = new CustomLocalizationProvider();
            LoadDataGridView(ordnumber);



        }
        private void LoadDataGridView(string ordnumber)
        {
            orderrepairService = new OrderRepairService();
            DataTable data = orderrepairService.GetRepairItems(ordnumber);
            radGridView1.DataSource = data;
            radGridView1.Columns[0].Width = 102;
            radGridView1.Columns[1].Width = 102;
            radGridView1.Columns[2].Width = 102;
            radGridView1.Columns[2].DataType = typeof(Int32);
            radGridView1.Columns[3].Width = 102;
            radGridView1.Columns[4].Width = 102;
            radGridView1.Columns[5].IsVisible = false;
            radGridView1.ShowGroupPanel = false;
            //radGridView1.AllowAddNewRow = false;

        }
        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void radTextBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            //string ordercustomercode = ordcustcode.Text;
            string ordershipto = ordshipto.Text;
            string orderentrydateval = orderentrydate.Text;
            string ordercanceldateval = ordercanceldate.Text;
            string customerrepairordernoval = customerrepairorderno.Text;
            string customerdebitmemonumberval = customerdebitmemonumber.Text;
            string shipbynoncodeval = shipbynoncode.Text;
            string shipbycodcashval =  shipbycodcash.Text;
            string shipbycodcheckval = shipbycodcheck.Text;
            string shipbygroundval = shipbyground.Text;
            string shipbysaturdayval = shipbysaturday.Text;
            string shipby3dayval = shipby3day.Text;
            string shipbyaaaval = shipbyaaa.Text;
            string shipby2dayval = shipby2day.Text;
            string shipbymailval = shipbymail.Text;
            string shipbynextdayval = shipbynextday.Text;
            string shipbypickupval = shipbypickup.Text;
            string shipbyredletterval = shipbyredletter.Text;
            string shipbydeliveryval = shipbydelivery.Text;
            string shipby2dayletterval = shipby2dayletter.Text;
            string shipbynoneval = shipbynone.Text;
            string shipbyregularval = shipbyregular.Text;
            string shipbyearlyamval = shipbyearlyam.Text;
            string shipbyupsserverval = shipbyupsserver.Text;
            string ordercreditrepairval = ordercreditrepair.Text;
            string orderresidentialval = orderresidential.Text;
            //string repairordernoteval = repairordernote.Text;
            int flag = 1;
            for (int rows = 0; rows < radGridView1.Rows.Count; rows++)
            {
                //if (radGridView1.Rows[rows].Cells[0].Value != "" && radGridView1.Rows[rows].Cells[1].Value != "" && radGridView1.Rows[rows].Cells[2].Value != "" && radGridView1.Rows[rows].Cells[3].Value != "" && radGridView1.Rows[rows].Cells[4].Value != "")
                if ((radGridView1.Rows[rows].Cells[0].Value == "" || radGridView1.Rows[rows].Cells[1].Value == "" || radGridView1.Rows[rows].Cells[2].Value == "" || radGridView1.Rows[rows].Cells[3].Value == "" || radGridView1.Rows[rows].Cells[4].Value == "") || (radGridView1.Rows[rows].Cells[0].Value == string.Empty || radGridView1.Rows[rows].Cells[1].Value == string.Empty || radGridView1.Rows[rows].Cells[2].Value == string.Empty || radGridView1.Rows[rows].Cells[3].Value == string.Empty || radGridView1.Rows[rows].Cells[4].Value == string.Empty))
                {
                    flag = 0;
                    MessageBox.Show("IN");
                }

            }
            if (flag == 0)
            {
                MessageBox.Show("Add Items To Continue");
               // return false;
            }
            else
            {
                for (int rows = 0; rows < radGridView1.Rows.Count; rows++)
                {
                    if (radGridView1.Rows[rows].Cells[0].Value != "" && radGridView1.Rows[rows].Cells[1].Value != "" && radGridView1.Rows[rows].Cells[2].Value != "" && radGridView1.Rows[rows].Cells[3].Value != "" && radGridView1.Rows[rows].Cells[4].Value != "")
                    {

                        string linenumber = (rows + 1).ToString();
                        string stylenumber = radGridView1.Rows[rows].Cells[0].Value.ToString();
                        string size = radGridView1.Rows[rows].Cells[1].Value.ToString();
                        string qty = radGridView1.Rows[rows].Cells[2].Value.ToString();
                        string description = radGridView1.Rows[rows].Cells[3].Value.ToString();
                        string refno = radGridView1.Rows[rows].Cells[4].Value.ToString();

                        additemstorepairitemtable(linenumber, stylenumber, size, qty, description, refno);
                    }

                }

                additemintorepairtable();
            }
        }

        private void additemintorepairtable()
        {
            string iscod = string.Empty;
            string codtype = string.Empty;
            string early = string.Empty;
            //bool resident = 0;

            if (shipbynoncode.IsChecked)
                iscod = "N";
            if (shipbycodcash.IsChecked)
                iscod = "A";
            if (shipbycodcheck.IsChecked)
                iscod = "B";

            if (shipbyground.IsChecked)
                codtype = "G";
            if (shipby3day.IsChecked)
                codtype = "O";
            if (shipby2day.IsChecked)
                codtype = "B";
            if (shipbynextday.IsChecked)
                codtype = "R";
            if (shipbyredletter.IsChecked)
                codtype = "E";
            if (shipby2dayletter.IsChecked)
                codtype = "F";
            if (shipbysaturday.IsChecked)
                codtype = "L";
            if (shipbyaaa.IsChecked)
                codtype = "S";
            if (shipbymail.IsChecked)
                codtype = "M";
            if (shipbypickup.IsChecked)
                codtype = "D";
            if (shipbydelivery.IsChecked)
                codtype = "P";
            if (shipbynone.IsChecked)
                codtype = "N";

            if (shipbyregular.IsChecked)
                early = "R";
            if (shipbyearlyam.IsChecked)
                early = "E";
            if (shipbyupsserver.IsChecked)
                early = "S";

            DateTime? cdate, rcvdate, candate;
           // cdate = null; rcvdate = null; candate = null;
            
            if (!string.IsNullOrEmpty(this.orderentrydate.Text.Trim()))
                rcvdate = Convert.ToDateTime(this.orderentrydate.Text);
            else
                rcvdate = null;
            if (!string.IsNullOrEmpty(this.ordercanceldate.Text.Trim()))
                candate = Convert.ToDateTime(this.ordercanceldate.Text);
            else
                candate = null;

            if (!string.IsNullOrEmpty(this.orderrecivedate.Text.Trim()))
                cdate = Convert.ToDateTime(this.orderrecivedate.Text);
            else
                cdate = rcvdate;

            string iscredited = "0";

            if(ordercreditrepair.IsChecked)
                iscredited = "1";

            RepairorderModel repairorderModel = new RepairorderModel()
            {
                REPAIR_NO = this.orderrepairno.Text.Trim(),
                ACC = this.ordcustcode.Text.Trim(),
                MESSAGE = this.repairordernote.Text,
                ADDR1 = this.orderadd1.Text,
                ADDR2 = this.orderadd2.Text,
                CITY = this.ordercity.Text,
                STATE = this.orderstate.Text,
                COUNTRY = this.ordercountry.Text,
                CUS_REP_NO = this.customerrepairorderno.Text,
                CUS_DEB_NO = this.customerdebitmemonumber.Text,
                DATE = cdate,
                RCV_DATE = rcvdate,
                CAN_DATE = candate,
                MESSAGE1 = this.repairordernote.Text,
                OPERATOR = "JAVID",
                ZIP = this.orderzip.Text,
                NAME = this.ordshipto.Text,
                IS_COD = iscod,
                COD_TYPE = codtype,
                EARLY = early,
                SHIPED = "",
                BARCODE = "",
                ISSUE_CRDT = iscredited
            };

            orderrepairService = new OrderRepairService();
            string success = orderrepairService.AddOrderRepairToRepairTable(repairorderModel);
            if(success == "1")
            {
                frmPrintOrderRepair objPrintRepairOrder = new frmPrintOrderRepair(orderrepairno.Text);
                objPrintRepairOrder.StartPosition = FormStartPosition.CenterScreen;

                objPrintRepairOrder.Show();
                this.Dispose();
            }
        }

        private void additemstorepairitemtable(string linenumber, string stylenumber, string size, string qty, string description, string refno)
        {
            string iscod = string.Empty;
            string codtype = string.Empty;
            string early = string.Empty;

            if (shipbynoncode.IsChecked)
                iscod = "N";
            if (shipbycodcash.IsChecked)
                iscod = "A";
            if (shipbycodcheck.IsChecked)
                iscod = "B";

            if (shipbyground.IsChecked)
                codtype = "G";
            if (shipby3day.IsChecked)
                codtype = "O";
            if (shipby2day.IsChecked)
                codtype = "B";
            if (shipbynextday.IsChecked)
                codtype = "R";
            if (shipbyredletter.IsChecked)
                codtype = "E";
            if (shipby2dayletter.IsChecked)
                codtype = "F";
            if (shipbysaturday.IsChecked)
                codtype = "L";
            if (shipbyaaa.IsChecked)
                codtype = "S";
            if (shipbymail.IsChecked)
                codtype = "M";
            if (shipbypickup.IsChecked)
                codtype = "D";
            if (shipbydelivery.IsChecked)
                codtype = "P";
            if (shipbynone.IsChecked)
                codtype = "N";

            if (shipbyregular.IsChecked)
                early = "R";
            if (shipbyearlyam.IsChecked)
                early = "E";
            if (shipbyupsserver.IsChecked)
                early = "S";
            DateTime? cdate,rcvdate, candate;
            cdate = null; rcvdate = null; candate = null;
            if (orderrecivedate.Value != null)
            {
                cdate = Convert.ToDateTime(orderrecivedate.Value);
            }
            if (orderentrydate.Value != null)
            {
                rcvdate = Convert.ToDateTime(orderentrydate.Value);
            }
            if (ordercanceldate.Value != null)
            {
                candate = Convert.ToDateTime(ordercanceldate.Value);
            }


            RepairorderModel repairorderModel = new RepairorderModel()
            {
                REPAIR_NO = orderrepairno.Text.Trim(),
                ACC = ordcustcode.Text.Trim(),
                MESSAGE = repairordernote.Text,
                ADDR1 = orderadd1.Text,
                ADDR2 = orderadd2.Text,
                CITY = ordercity.Text,
                STATE = orderstate.Text,
                COUNTRY = ordercountry.Text,
                CUS_REP_NO = customerrepairorderno.Text,
                CUS_DEB_NO = customerdebitmemonumber.Text,
                DATE = cdate,
                RCV_DATE = rcvdate,
                CAN_DATE = candate,
                MESSAGE1 = repairordernote.Text,
                OPERATOR = "JAVID",
                ZIP = orderzip.Text,
                NAME = "JAVID",
                IS_COD = iscod,
                COD_TYPE = codtype,
                EARLY = early,
                LINE = linenumber,
                ITEM = stylenumber,
                SIZE = size,
                QTY = qty,
                STAT = description,
                SHIPED = "",
                VENDOR = refno,
                BARCODE = ""
            };
            
            orderrepairService = new OrderRepairService();
            string success = orderrepairService.InsertOrderRepairdataInRepairItemsTable(repairorderModel);
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
                    ResetRepairOrderSequence();
                    break;
            }
        }
        private void ResetRepairOrderSequence()
        {
            this.orderrepairService = new OrderRepairService();
            RepairorderModel RepairorderModel = new RepairorderModel();
            int currentrepno = Convert.ToInt32(orderrepairno.Text);
            RepairorderModel repairorderModel = new RepairorderModel()
            {
                REPAIR_NO = Convert.ToString(currentrepno)
            };
            this.orderrepairService.ResetSequence(repairorderModel);

        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            ResetRepairOrderSequence();
            this.Dispose();
        }

        private void radButton1_Click_1(object sender, EventArgs e)
        {
            string ordershipto = ordshipto.Text;
            string orderentrydateval = orderentrydate.Text;
            string ordercanceldateval = ordercanceldate.Text;
            string customerrepairordernoval = customerrepairorderno.Text;
            string customerdebitmemonumberval = customerdebitmemonumber.Text;
            string shipbynoncodeval = shipbynoncode.Text;
            string shipbycodcashval = shipbycodcash.Text;
            string shipbycodcheckval = shipbycodcheck.Text;
            string shipbygroundval = shipbyground.Text;
            string shipbysaturdayval = shipbysaturday.Text;
            string shipby3dayval = shipby3day.Text;
            string shipbyaaaval = shipbyaaa.Text;
            string shipby2dayval = shipby2day.Text;
            string shipbymailval = shipbymail.Text;
            string shipbynextdayval = shipbynextday.Text;
            string shipbypickupval = shipbypickup.Text;
            string shipbyredletterval = shipbyredletter.Text;
            string shipbydeliveryval = shipbydelivery.Text;
            string shipby2dayletterval = shipby2dayletter.Text;
            string shipbynoneval = shipbynone.Text;
            string shipbyregularval = shipbyregular.Text;
            string shipbyearlyamval = shipbyearlyam.Text;
            string shipbyupsserverval = shipbyupsserver.Text;
            string ordercreditrepairval = ordercreditrepair.Text;
            string orderresidentialval = orderresidential.Text;
            //string repairordernoteval = repairordernote.Text;
            int flag = 1;
            for (int rows = 1; rows < radGridView1.Rows.Count; rows++)
            {
                if ((radGridView1.Rows[rows].Cells[0].Value == "" || radGridView1.Rows[rows].Cells[1].Value == "" || radGridView1.Rows[rows].Cells[2].Value == "" || radGridView1.Rows[rows].Cells[3].Value == "" || radGridView1.Rows[rows].Cells[4].Value == "") || (radGridView1.Rows[rows].Cells[0].Value == string.Empty || radGridView1.Rows[rows].Cells[1].Value == string.Empty || radGridView1.Rows[rows].Cells[2].Value == string.Empty || radGridView1.Rows[rows].Cells[3].Value == string.Empty || radGridView1.Rows[rows].Cells[4].Value == string.Empty))
                {
                    flag = 0;
                }
               /* else
                {
                    flag = 0;
                }*/

            }
            if (flag == 0)
            {
                MessageBox.Show("Add Items To Continue");
                // return false;
            }
            else
            {
                for (int rows = 0; rows < radGridView1.Rows.Count; rows++)
                {
                    if (radGridView1.Rows[rows].Cells[0].Value != "" && radGridView1.Rows[rows].Cells[1].Value != "" && radGridView1.Rows[rows].Cells[2].Value != "" && radGridView1.Rows[rows].Cells[3].Value != "" && radGridView1.Rows[rows].Cells[4].Value != "")
                    {

                        string linenumber = (rows + 1).ToString();
                        string stylenumber = radGridView1.Rows[rows].Cells[0].Value.ToString();
                        string size = radGridView1.Rows[rows].Cells[1].Value.ToString();
                        string qty = radGridView1.Rows[rows].Cells[2].Value.ToString();
                        string description = radGridView1.Rows[rows].Cells[3].Value.ToString();
                        string refno = radGridView1.Rows[rows].Cells[4].Value.ToString();

                        additemstorepairitemtable(linenumber, stylenumber, size, qty, description, refno);
                    }

                }

                additemintorepairtable();
            }
        }

        private void frmAddrepairorder_KeyDown(object sender, KeyEventArgs e)
        {
            ResetRepairOrderSequence();
            this.Dispose();
        }

        private void radButton2_Click_1(object sender, EventArgs e)
        {
            ResetRepairOrderSequence();
            this.Dispose();
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void radGridView1_SelectionChanging(object sender, GridViewSelectionCancelEventArgs e)
        {
            /*if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                int iColumn = radGridView1.CurrentCell.ColumnIndex;
                int iRow = radGridView1.CurrentCell.RowIndex;
                if (iColumn == radGridView1.Columns.Count - 1)
                    radGridView1.CurrentCell = radGridView1[0, iRow + 1];
                else
                    radGridView1.CurrentCell = radGridView1[iColumn + 1, iRow];

            }*/
        }

        private void updataetotalqty()
        {
            
            
            for (int rows = 0; rows < radGridView1.Rows.Count; rows++)
            {
                tt = Convert.ToInt64(radGridView1.Rows[rows].Cells[2].Value.ToString());
                MessageBox.Show(tt.ToString());
            }
            totalqty.Text = tt.ToString();
        }

        private void radGridView1_CellValueChanged(object sender, GridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 2 && e.Value != "")
            {
                tt = tt + Convert.ToInt64(e.Value.ToString());
                totalqty.Text = tt.ToString();
            }
            if (e.ColumnIndex == 0 && e.Value != "" && e.Value != string.Empty)
            {
                string style = e.Value.ToString();
                string status = "0";
                if(style != string.Empty)
                    status = checkstyle1(style);
               // MessageBox.Show(status);
                if(status == "0")
                {
                    MessageBox.Show("Item Not Exist");
                    this.radGridView1.CurrentCell.Value = "";
                    //radGridView1.CurrentCell = e.ColumnIndex;
                }
            }
        }

        private string checkstyle1(string style)
        {
            this.orderrepairService = new OrderRepairService();
            //string st = checkstyle(style);
            string data = orderrepairService.checkstyle(style);
            return data;
        }

    }
}
