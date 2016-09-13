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
    public partial class frmEditRepairOrder : Telerik.WinControls.UI.RadForm
    {
        private ICustomerService customerService;

        private IOrderRepairService orderrepairService;

        private DataRow custRow;

        private DataRow orderRow;

        private DataView dvCustomerSearch;

        long tt = 0;
        public frmEditRepairOrder()
        {
            InitializeComponent();
            // MessageBox.Show(DateTime.Now.ToString());
            this.orderentrydate.Value = DateTime.Now;
            this.ordercanceldate.Value = DateTime.Now;
        }

        public frmEditRepairOrder(string repairordernumber)
        {
            InitializeComponent();
            this.orderentrydate.Value = DateTime.Now;
            this.ordercanceldate.Value = DateTime.Now;
            //MessageBox.Show(DateTime.Now.ToString());
            if (repairordernumber != "")
            {
                orderrepairService = new OrderRepairService();
                DataTable data = orderrepairService.GetRepairItems(repairordernumber);
                int ct = 0;
                foreach (DataRow row in data.Rows)
                {
                    ct = ct + 1; 
                    tt = tt + Convert.ToInt64(row["qty"]);
                }
                if (ct > 0)
                {
                    radGridView1.DataSource = data;
                    radGridView1.Columns[0].Width = 102;
                    radGridView1.Columns[1].Width = 102;
                    radGridView1.Columns[2].Width = 102;
                    radGridView1.Columns[2].DataType = typeof(Int32);
                    radGridView1.Columns[3].Width = 102;
                    radGridView1.Columns[4].Width = 100;
                    radGridView1.Columns[5].IsVisible = false;
                    radGridView1.ShowGroupPanel = false;
                    RadGridLocalizationProvider.CurrentProvider = new CustomLocalizationProvider();
                    DataTable details = orderrepairService.creatdatagridbasedonrepid(repairordernumber);
                    int i = 0;
                    totalqty.Text = tt.ToString();
                    foreach (DataRow row in details.Rows)
                    {
                        //string ID = row["name"].ToString();
                        if(i == 0)
                        {
                           
                            ordcustcode.Text = row["ACC"].ToString();
                            ordshipto.Text = row["name"].ToString();
                            orderadd1.Text = row["ADDR1"].ToString();
                            orderadd2.Text = row["ADDR2"].ToString();
                            ordercity.Text = row["CITY"].ToString();
                            orderstate.Text = row["STATE"].ToString();
                            ordercountry.Text = row["COUNTRY"].ToString();
                            orderzip.Text = row["ZIP"].ToString();
                            orderrepairno.Text = row["REPAIR_NO"].ToString();
                            orderentrydate.Text = row["DATE"].ToString();
                            ordercanceldate.Text = row["CAN_DATE"].ToString();
                            orderrecivedate.Text = row["RCV_DATE"].ToString();
                            customerrepairorderno.Text = row["CUS_REP_NO"].ToString();
                            customerdebitmemonumber.Text = row["CUS_DEB_NO"].ToString();
                           
                            repairordernote.Text = row["MESSAGE"].ToString();
                           // MessageBox.Show(row["cod_type"].ToString());
                            if (row["is_cod"].ToString() == "N")
                                shipbynoncode.IsChecked = true;
                            if (row["is_cod"].ToString() == "A")
                                shipbycodcash.IsChecked = true;
                            if (row["is_cod"].ToString() == "B")
                                shipbycodcheck.IsChecked = true;


                            if(row["cod_type"].ToString() == "G")
                                shipbyground.IsChecked = true;
                            if (row["cod_type"].ToString() == "O")
                                shipby3day.IsChecked = true;
                            if (row["cod_type"].ToString() == "B")
                                shipby2day.IsChecked = true;
                            if (row["cod_type"].ToString() == "R")
                                shipbynextday.IsChecked = true;
                            if (row["cod_type"].ToString() == "E")
                                shipbyredletter.IsChecked = true;
                            if (row["cod_type"].ToString() == "F")
                                shipby2dayletter.IsChecked = true;
                            if (row["cod_type"].ToString() == "L")
                                shipbysaturday.IsChecked = true;
                            if (row["cod_type"].ToString() == "S")
                                shipbyaaa.IsChecked = true;
                            if (row["cod_type"].ToString() == "M")
                                shipbymail.IsChecked = true;
                            if (row["cod_type"].ToString() == "D")
                                shipbypickup.IsChecked = true;
                            if (row["cod_type"].ToString() == "P")
                                shipbydelivery.IsChecked = true;
                            if (row["cod_type"].ToString() == "N")
                                shipbynone.IsChecked = true;

                            if (row["early"].ToString() == "R")
                                shipbyregular.IsChecked = true;
                            if (row["early"].ToString() == "E")
                                shipbyearlyam.IsChecked = true;
                            if (row["early"].ToString() == "S")
                                shipbyupsserver.IsChecked = true;
                          //  MessageBox.Show(row["ISSUE_CRDT"].ToString());
                             if(row["ISSUE_CRDT"].ToString() == "True")
                                ordercreditrepair.IsChecked = true;


                            i = i + 1;
                        }
                        break;
                    }
                }
                else
                {
                    MessageBox.Show("Invalid Repair Order Number");
                    return;
                }

            }
            else
            {
                MessageBox.Show("Enter Valid Repair Order Number");
                return;
            }
        }

        private void radButton1_Click(object sender, EventArgs e)
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
            string success = orderrepairService.DeleteRepairOrderItems(orderrepairno.Text);
            for (int rows = 0; rows <  radGridView1.Rows.Count; rows++)
            {
               // MessageBox.Show(radGridView1.Rows[rows].Cells[0].Value.ToString());
                if ((radGridView1.Rows[rows].Cells[0].Value == "" || radGridView1.Rows[rows].Cells[1].Value == "" || radGridView1.Rows[rows].Cells[2].Value == "" || radGridView1.Rows[rows].Cells[3].Value == "" || radGridView1.Rows[rows].Cells[4].Value == "") || (radGridView1.Rows[rows].Cells[0].Value == string.Empty || radGridView1.Rows[rows].Cells[1].Value == string.Empty || radGridView1.Rows[rows].Cells[2].Value == string.Empty || radGridView1.Rows[rows].Cells[3].Value == string.Empty || radGridView1.Rows[rows].Cells[4].Value == string.Empty))
                {

                    flag = 0;
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
                        string barcode = radGridView1.Rows[rows].Cells[5].Value.ToString();
                        updateitemstorepairitemtable(linenumber, stylenumber, size, qty, description, refno, barcode);
                    }

                }

                updateitemintorepairtable();
            }
        }

        private void updateitemintorepairtable()
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

            if (ordercreditrepair.IsChecked)
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
            string success = orderrepairService.UpdateOrderRepairToRepairTable(repairorderModel);
           if (success == "1")
            {
                frmPrintOrderRepair objPrintRepairOrder = new frmPrintOrderRepair(orderrepairno.Text);
                objPrintRepairOrder.StartPosition = FormStartPosition.CenterScreen;

                objPrintRepairOrder.Show();
                this.Dispose();
            }
        }

        private void updateitemstorepairitemtable(string linenumber, string stylenumber, string size, string qty, string description, string refno,string barcode)
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
            DateTime? cdate, rcvdate, candate;
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
                BARCODE = barcode
            };

            orderrepairService = new OrderRepairService();
           // string success = orderrepairService.InsertOrderRepairdataInRepairItemsTable(repairorderModel);
            string success = orderrepairService.InsertOrderRepairdataInRepairItemsTable(repairorderModel);
        }

        private void radGridView1_CellValidated(object sender, CellValidatedEventArgs e)
        {
           // if (e.ColumnIndex == 8)
            //{
               // MessageBox.Show("hemanth");
           // }
        }

        private void radButton2_Click(object sender, EventArgs e)
        {
            /*DialogResult dialogResult = MessageBox.Show("Are you sure you want to cancel the changes?", "Add / Edit Customer", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                this.Close();
            }*/
            this.Dispose();
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
                if (style != string.Empty)
                    status = checkstyle1(style);
                // MessageBox.Show(status);
                if (status == "0")
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
