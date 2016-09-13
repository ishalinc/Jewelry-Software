


namespace IshalInc.wJewel.Desktop.Forms
{
    partial class frmEditAdjRcvable
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Telerik.WinControls.UI.TableViewDefinition tableViewDefinition1 = new Telerik.WinControls.UI.TableViewDefinition();
            this.btnClose = new Telerik.WinControls.UI.RadButton();
            this.txtReceiptNo = new Telerik.WinControls.UI.RadTextBoxControl();
            this.radLabel9 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.txtEntryDate = new Telerik.WinControls.UI.RadDateTimePicker();
            this.radLabel10 = new Telerik.WinControls.UI.RadLabel();
            this.txtDebits = new Telerik.WinControls.UI.RadMaskedEditBox();
            this.txtCredits = new Telerik.WinControls.UI.RadMaskedEditBox();
            this.radLabel6 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel11 = new Telerik.WinControls.UI.RadLabel();
            this.label1 = new Telerik.WinControls.UI.RadLabel();
            this.btnSave = new Telerik.WinControls.UI.RadButton();
            this.txtDifference = new Telerik.WinControls.UI.RadMaskedEditBox();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.lblCustomerName = new Telerik.WinControls.UI.RadLabel();
            this.txtBillingAcctNo = new Telerik.WinControls.UI.RadAutoCompleteBox();
            this.radGridView1 = new Telerik.WinControls.UI.RadGridView();
            this.radLabel14 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel13 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReceiptNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEntryDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDebits)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCredits)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDifference)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblCustomerName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBillingAcctNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnClose.Image = global::IshalInc.wJewel.Desktop.Properties.Resources.undo;
            this.btnClose.Location = new System.Drawing.Point(404, 557);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(87, 24);
            this.btnClose.TabIndex = 51;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtReceiptNo
            // 
            this.txtReceiptNo.Location = new System.Drawing.Point(135, 21);
            this.txtReceiptNo.Name = "txtReceiptNo";
            this.txtReceiptNo.Size = new System.Drawing.Size(125, 21);
            this.txtReceiptNo.TabIndex = 17;
            this.txtReceiptNo.TextChanged += new System.EventHandler(this.txtReceiptNo_TextChanged);
            this.txtReceiptNo.Validated += new System.EventHandler(this.txtReceiptNo_Validated);
            // 
            // radLabel9
            // 
            this.radLabel9.Location = new System.Drawing.Point(1, 529);
            this.radLabel9.Name = "radLabel9";
            this.radLabel9.Size = new System.Drawing.Size(44, 18);
            this.radLabel9.TabIndex = 55;
            this.radLabel9.Text = "Credits:";
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(19, 21);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(70, 18);
            this.radLabel1.TabIndex = 24;
            this.radLabel1.Text = "Receipt No. :";
            // 
            // txtEntryDate
            // 
            this.txtEntryDate.CustomFormat = "\"\"";
            this.txtEntryDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtEntryDate.Location = new System.Drawing.Point(382, 20);
            this.txtEntryDate.Name = "txtEntryDate";
            this.txtEntryDate.Size = new System.Drawing.Size(126, 20);
            this.txtEntryDate.TabIndex = 22;
            this.txtEntryDate.TabStop = false;
            this.txtEntryDate.Text = "4/14/2016";
            this.txtEntryDate.ThemeName = "TelerikMetroBlue";
            this.txtEntryDate.Value = new System.DateTime(2016, 4, 14, 13, 37, 1, 295);
            this.txtEntryDate.Validated += new System.EventHandler(this.txtEntryDate_Validated);
            // 
            // radLabel10
            // 
            this.radLabel10.Location = new System.Drawing.Point(323, 529);
            this.radLabel10.Name = "radLabel10";
            this.radLabel10.Size = new System.Drawing.Size(41, 18);
            this.radLabel10.TabIndex = 57;
            this.radLabel10.Text = "Debits:";
            // 
            // txtDebits
            // 
            this.txtDebits.Location = new System.Drawing.Point(374, 528);
            this.txtDebits.Mask = "c";
            this.txtDebits.MaskType = Telerik.WinControls.UI.MaskType.Numeric;
            this.txtDebits.Name = "txtDebits";
            this.txtDebits.ReadOnly = true;
            this.txtDebits.Size = new System.Drawing.Size(100, 20);
            this.txtDebits.TabIndex = 56;
            this.txtDebits.TabStop = false;
            this.txtDebits.Text = "$0.00";
            this.txtDebits.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDebits.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtDebits.ThemeName = "TelerikMetroBlue";
            // 
            // txtCredits
            // 
            this.txtCredits.Location = new System.Drawing.Point(52, 528);
            this.txtCredits.Mask = "c";
            this.txtCredits.MaskType = Telerik.WinControls.UI.MaskType.Numeric;
            this.txtCredits.Name = "txtCredits";
            this.txtCredits.ReadOnly = true;
            this.txtCredits.Size = new System.Drawing.Size(100, 20);
            this.txtCredits.TabIndex = 54;
            this.txtCredits.TabStop = false;
            this.txtCredits.Text = "$0.00";
            this.txtCredits.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCredits.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtCredits.ThemeName = "TelerikMetroBlue";
            // 
            // radLabel6
            // 
            this.radLabel6.Location = new System.Drawing.Point(301, 21);
            this.radLabel6.Name = "radLabel6";
            this.radLabel6.Size = new System.Drawing.Size(61, 18);
            this.radLabel6.TabIndex = 27;
            this.radLabel6.Text = "Entry Date:";
            // 
            // radLabel11
            // 
            this.radLabel11.Location = new System.Drawing.Point(626, 529);
            this.radLabel11.Name = "radLabel11";
            this.radLabel11.Size = new System.Drawing.Size(60, 18);
            this.radLabel11.TabIndex = 59;
            this.radLabel11.Text = "Difference:";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(2, 2);
            this.label1.TabIndex = 32;
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnSave.Image = global::IshalInc.wJewel.Desktop.Properties.Resources.save;
            this.btnSave.Location = new System.Drawing.Point(306, 557);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(87, 24);
            this.btnSave.TabIndex = 50;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtDifference
            // 
            this.txtDifference.Location = new System.Drawing.Point(690, 528);
            this.txtDifference.Mask = "c";
            this.txtDifference.MaskType = Telerik.WinControls.UI.MaskType.Numeric;
            this.txtDifference.Name = "txtDifference";
            this.txtDifference.ReadOnly = true;
            this.txtDifference.Size = new System.Drawing.Size(100, 20);
            this.txtDifference.TabIndex = 58;
            this.txtDifference.TabStop = false;
            this.txtDifference.Text = "$0.00";
            this.txtDifference.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDifference.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtDifference.ThemeName = "TelerikMetroBlue";
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(19, 49);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(90, 18);
            this.radLabel2.TabIndex = 31;
            this.radLabel2.Text = "Billing Acct. No. :";
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.lblCustomerName);
            this.radGroupBox1.Controls.Add(this.txtBillingAcctNo);
            this.radGroupBox1.Controls.Add(this.label1);
            this.radGroupBox1.Controls.Add(this.radLabel6);
            this.radGroupBox1.Controls.Add(this.radLabel2);
            this.radGroupBox1.Controls.Add(this.radLabel1);
            this.radGroupBox1.Controls.Add(this.txtEntryDate);
            this.radGroupBox1.Controls.Add(this.txtReceiptNo);
            this.radGroupBox1.HeaderText = "";
            this.radGroupBox1.Location = new System.Drawing.Point(1, 17);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(791, 78);
            this.radGroupBox1.TabIndex = 48;
            this.radGroupBox1.Click += new System.EventHandler(this.radGroupBox1_Click);
            // 
            // lblCustomerName
            // 
            this.lblCustomerName.AutoSize = false;
            this.lblCustomerName.Location = new System.Drawing.Point(266, 50);
            this.lblCustomerName.Name = "lblCustomerName";
            this.lblCustomerName.Size = new System.Drawing.Size(461, 18);
            this.lblCustomerName.TabIndex = 61;
            // 
            // txtBillingAcctNo
            // 
            this.txtBillingAcctNo.Enabled = false;
            this.txtBillingAcctNo.Location = new System.Drawing.Point(135, 48);
            this.txtBillingAcctNo.Name = "txtBillingAcctNo";
            this.txtBillingAcctNo.Size = new System.Drawing.Size(125, 20);
            this.txtBillingAcctNo.TabIndex = 33;
            this.txtBillingAcctNo.TextChanged += new System.EventHandler(this.txtBillingAcctNo_TextChanged);
            this.txtBillingAcctNo.Validated += new System.EventHandler(this.txtBillingAcctNo_Validated);
            // 
            // radGridView1
            // 
            this.radGridView1.EnterKeyMode = Telerik.WinControls.UI.RadGridViewEnterKeyMode.EnterMovesToNextCell;
            this.radGridView1.Location = new System.Drawing.Point(1, 115);
            // 
            // 
            // 
            this.radGridView1.MasterTemplate.AllowAddNewRow = false;
            this.radGridView1.MasterTemplate.AllowCellContextMenu = false;
            this.radGridView1.MasterTemplate.AllowColumnChooser = false;
            this.radGridView1.MasterTemplate.AllowColumnHeaderContextMenu = false;
            this.radGridView1.MasterTemplate.AllowDeleteRow = false;
            this.radGridView1.MasterTemplate.AllowRowResize = false;
            this.radGridView1.MasterTemplate.AutoSizeColumnsMode = Telerik.WinControls.UI.GridViewAutoSizeColumnsMode.Fill;
            this.radGridView1.MasterTemplate.EnableGrouping = false;
            this.radGridView1.MasterTemplate.EnableSorting = false;
            this.radGridView1.MasterTemplate.ViewDefinition = tableViewDefinition1;
            this.radGridView1.Name = "radGridView1";
            this.radGridView1.Size = new System.Drawing.Size(791, 407);
            this.radGridView1.TabIndex = 60;
            this.radGridView1.Text = "radGridView2";
            this.radGridView1.CellBeginEdit += new Telerik.WinControls.UI.GridViewCellCancelEventHandler(this.radGridView1_CellBeginEdit);
            this.radGridView1.CurrentRowChanged += new Telerik.WinControls.UI.CurrentRowChangedEventHandler(this.radGridView1_CurrentRowChanged);
            this.radGridView1.CellValueChanged += new Telerik.WinControls.UI.GridViewCellEventHandler(this.radGridView1_CellValueChanged);
            this.radGridView1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.radGridView1_KeyPress);
            // 
            // radLabel14
            // 
            this.radLabel14.AutoSize = false;
            this.radLabel14.BackColor = System.Drawing.SystemColors.HotTrack;
            this.radLabel14.BorderVisible = true;
            this.radLabel14.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.radLabel14.ForeColor = System.Drawing.Color.White;
            this.radLabel14.Location = new System.Drawing.Point(1, 98);
            this.radLabel14.Name = "radLabel14";
            this.radLabel14.Size = new System.Drawing.Size(791, 18);
            this.radLabel14.TabIndex = 37;
            this.radLabel14.Text = "Adj. Rcvable Details";
            this.radLabel14.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // radLabel13
            // 
            this.radLabel13.AutoSize = false;
            this.radLabel13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.radLabel13.BorderVisible = true;
            this.radLabel13.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.radLabel13.ForeColor = System.Drawing.Color.White;
            this.radLabel13.Location = new System.Drawing.Point(1, 2);
            this.radLabel13.Name = "radLabel13";
            this.radLabel13.Size = new System.Drawing.Size(791, 18);
            this.radLabel13.TabIndex = 36;
            this.radLabel13.Text = "Edit a Adj. Rcvable";
            this.radLabel13.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmEditAdjRcvable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(796, 584);
            this.Controls.Add(this.radLabel14);
            this.Controls.Add(this.radGridView1);
            this.Controls.Add(this.radLabel13);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.radLabel9);
            this.Controls.Add(this.radLabel10);
            this.Controls.Add(this.txtDebits);
            this.Controls.Add(this.txtCredits);
            this.Controls.Add(this.radLabel11);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtDifference);
            this.Controls.Add(this.radGroupBox1);
            this.Name = "frmEditAdjRcvable";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Edit a Adj. Rcvable";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAddCashReceipt_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtReceiptNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEntryDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDebits)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCredits)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSave)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDifference)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lblCustomerName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBillingAcctNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadButton btnClose;
        private Telerik.WinControls.UI.RadTextBoxControl txtReceiptNo;
        private Telerik.WinControls.UI.RadLabel radLabel9;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadDateTimePicker txtEntryDate;
        private Telerik.WinControls.UI.RadLabel radLabel10;
        private Telerik.WinControls.UI.RadMaskedEditBox txtDebits;
        private Telerik.WinControls.UI.RadMaskedEditBox txtCredits;
        private Telerik.WinControls.UI.RadLabel radLabel6;
        private Telerik.WinControls.UI.RadLabel radLabel11;
        private Telerik.WinControls.UI.RadLabel label1;
        private Telerik.WinControls.UI.RadButton btnSave;
        private Telerik.WinControls.UI.RadMaskedEditBox txtDifference;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadAutoCompleteBox txtBillingAcctNo;
        private Telerik.WinControls.UI.RadGridView radGridView1;
        private Telerik.WinControls.UI.RadLabel radLabel14;
        private Telerik.WinControls.UI.RadLabel radLabel13;
        private Telerik.WinControls.UI.RadLabel lblCustomerName;
    }
}
