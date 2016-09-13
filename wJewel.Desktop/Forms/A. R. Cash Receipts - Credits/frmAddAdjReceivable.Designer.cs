


namespace IshalInc.wJewel.Desktop.Forms
{
    partial class frmAddAdjReceivable
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
            this.txtAdjRcvableNo = new Telerik.WinControls.UI.RadTextBoxControl();
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
            this.btnAutoApply = new Telerik.WinControls.UI.RadButton();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.radLabel12 = new Telerik.WinControls.UI.RadLabel();
            this.chkShowMemo = new Telerik.WinControls.UI.RadCheckBox();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.txtBillingAcctNo = new Telerik.WinControls.UI.RadAutoCompleteBox();
            this.radGridView1 = new Telerik.WinControls.UI.RadGridView();
            this.radLabel13 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel14 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAdjRcvableNo)).BeginInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.btnAutoApply)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkShowMemo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBillingAcctNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnClose.Image = global::IshalInc.wJewel.Desktop.Properties.Resources.undo;
            this.btnClose.Location = new System.Drawing.Point(468, 557);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(73, 24);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtAdjRcvableNo
            // 
            this.txtAdjRcvableNo.Location = new System.Drawing.Point(135, 9);
            this.txtAdjRcvableNo.Name = "txtAdjRcvableNo";
            this.txtAdjRcvableNo.Size = new System.Drawing.Size(125, 21);
            this.txtAdjRcvableNo.TabIndex = 1;
            this.txtAdjRcvableNo.TextChanged += new System.EventHandler(this.txtReceiptNo_TextChanged);
            this.txtAdjRcvableNo.Validated += new System.EventHandler(this.txtReceiptNo_Validated);
            // 
            // radLabel9
            // 
            this.radLabel9.Location = new System.Drawing.Point(1, 529);
            this.radLabel9.Name = "radLabel9";
            this.radLabel9.Size = new System.Drawing.Size(44, 18);
            this.radLabel9.TabIndex = 3;
            this.radLabel9.Text = "Credits:";
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(19, 9);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(70, 18);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "Receipt No. :";
            // 
            // txtEntryDate
            // 
            this.txtEntryDate.CustomFormat = "\"\"";
            this.txtEntryDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtEntryDate.Location = new System.Drawing.Point(382, 8);
            this.txtEntryDate.Name = "txtEntryDate";
            this.txtEntryDate.Size = new System.Drawing.Size(126, 20);
            this.txtEntryDate.TabIndex = 11;
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
            this.radLabel10.TabIndex = 5;
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
            this.txtDebits.TabIndex = 6;
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
            this.txtCredits.TabIndex = 4;
            this.txtCredits.TabStop = false;
            this.txtCredits.Text = "$0.00";
            this.txtCredits.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtCredits.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtCredits.ThemeName = "TelerikMetroBlue";
            // 
            // radLabel6
            // 
            this.radLabel6.Location = new System.Drawing.Point(301, 9);
            this.radLabel6.Name = "radLabel6";
            this.radLabel6.Size = new System.Drawing.Size(61, 18);
            this.radLabel6.TabIndex = 10;
            this.radLabel6.Text = "Entry Date:";
            // 
            // radLabel11
            // 
            this.radLabel11.Location = new System.Drawing.Point(626, 529);
            this.radLabel11.Name = "radLabel11";
            this.radLabel11.Size = new System.Drawing.Size(60, 18);
            this.radLabel11.TabIndex = 7;
            this.radLabel11.Text = "Difference:";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(3, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(2, 2);
            this.label1.TabIndex = 32;
            // 
            // btnSave
            // 
            this.btnSave.EnableTheming = false;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnSave.ForeColor = System.Drawing.Color.Red;
            this.btnSave.Image = global::IshalInc.wJewel.Desktop.Properties.Resources.save;
            this.btnSave.Location = new System.Drawing.Point(271, 557);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(77, 24);
            this.btnSave.TabIndex = 9;
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
            this.txtDifference.TabIndex = 8;
            this.txtDifference.TabStop = false;
            this.txtDifference.Text = "$0.00";
            this.txtDifference.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtDifference.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.txtDifference.ThemeName = "TelerikMetroBlue";
            // 
            // btnAutoApply
            // 
            this.btnAutoApply.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnAutoApply.Image = global::IshalInc.wJewel.Desktop.Properties.Resources.auto_apply;
            this.btnAutoApply.Location = new System.Drawing.Point(360, 557);
            this.btnAutoApply.Name = "btnAutoApply";
            this.btnAutoApply.Size = new System.Drawing.Size(97, 24);
            this.btnAutoApply.TabIndex = 10;
            this.btnAutoApply.Text = "AutoApply";
            this.btnAutoApply.Click += new System.EventHandler(this.btnAutoApply_Click);
            // 
            // radLabel2
            // 
            this.radLabel2.Location = new System.Drawing.Point(19, 37);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(90, 18);
            this.radLabel2.TabIndex = 2;
            this.radLabel2.Text = "Billing Acct. No. :";
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.radLabel12);
            this.radGroupBox1.Controls.Add(this.chkShowMemo);
            this.radGroupBox1.Controls.Add(this.radButton1);
            this.radGroupBox1.Controls.Add(this.txtBillingAcctNo);
            this.radGroupBox1.Controls.Add(this.label1);
            this.radGroupBox1.Controls.Add(this.radLabel6);
            this.radGroupBox1.Controls.Add(this.radLabel2);
            this.radGroupBox1.Controls.Add(this.radLabel1);
            this.radGroupBox1.Controls.Add(this.txtEntryDate);
            this.radGroupBox1.Controls.Add(this.txtAdjRcvableNo);
            this.radGroupBox1.HeaderText = "";
            this.radGroupBox1.Location = new System.Drawing.Point(1, 18);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(791, 62);
            this.radGroupBox1.TabIndex = 1;
            // 
            // radLabel12
            // 
            this.radLabel12.Font = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Bold);
            this.radLabel12.ForeColor = System.Drawing.Color.Red;
            this.radLabel12.Location = new System.Drawing.Point(647, 35);
            this.radLabel12.Name = "radLabel12";
            this.radLabel12.Size = new System.Drawing.Size(136, 20);
            this.radLabel12.TabIndex = 7;
            this.radLabel12.Text = "Press F to pay in FULL";
            // 
            // chkShowMemo
            // 
            this.chkShowMemo.Location = new System.Drawing.Point(382, 38);
            this.chkShowMemo.Name = "chkShowMemo";
            this.chkShowMemo.Size = new System.Drawing.Size(83, 18);
            this.chkShowMemo.TabIndex = 0;
            this.chkShowMemo.Text = "Show Memo";
            this.chkShowMemo.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.chkShowMemo_ToggleStateChanged);
            // 
            // radButton1
            // 
            this.radButton1.Location = new System.Drawing.Point(266, 37);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(28, 19);
            this.radButton1.TabIndex = 33;
            this.radButton1.Text = ". . .";
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
            // 
            // txtBillingAcctNo
            // 
            this.txtBillingAcctNo.Location = new System.Drawing.Point(135, 36);
            this.txtBillingAcctNo.Name = "txtBillingAcctNo";
            this.txtBillingAcctNo.Size = new System.Drawing.Size(125, 20);
            this.txtBillingAcctNo.TabIndex = 3;
            this.txtBillingAcctNo.TextChanged += new System.EventHandler(this.txtBillingAcctNo_TextChanged);
            this.txtBillingAcctNo.Validated += new System.EventHandler(this.txtBillingAcctNo_Validated);
            // 
            // radGridView1
            // 
            this.radGridView1.EnterKeyMode = Telerik.WinControls.UI.RadGridViewEnterKeyMode.EnterMovesToNextCell;
            this.radGridView1.Location = new System.Drawing.Point(1, 106);
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
            this.radGridView1.Size = new System.Drawing.Size(791, 417);
            this.radGridView1.TabIndex = 2;
            this.radGridView1.Text = "radGridView2";
            this.radGridView1.CellBeginEdit += new Telerik.WinControls.UI.GridViewCellCancelEventHandler(this.radGridView1_CellBeginEdit);
            this.radGridView1.CurrentRowChanged += new Telerik.WinControls.UI.CurrentRowChangedEventHandler(this.radGridView1_CurrentRowChanged);
            this.radGridView1.Click += new System.EventHandler(this.radGridView1_Click);
            this.radGridView1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.radGridView1_KeyPress);
            // 
            // radLabel13
            // 
            this.radLabel13.AutoSize = false;
            this.radLabel13.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.radLabel13.BorderVisible = true;
            this.radLabel13.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.radLabel13.ForeColor = System.Drawing.Color.White;
            this.radLabel13.Location = new System.Drawing.Point(1, 0);
            this.radLabel13.Name = "radLabel13";
            this.radLabel13.Size = new System.Drawing.Size(791, 18);
            this.radLabel13.TabIndex = 34;
            this.radLabel13.Text = "Record Adj. Receivable";
            this.radLabel13.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // radLabel14
            // 
            this.radLabel14.AutoSize = false;
            this.radLabel14.BackColor = System.Drawing.SystemColors.HotTrack;
            this.radLabel14.BorderVisible = true;
            this.radLabel14.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.radLabel14.ForeColor = System.Drawing.Color.White;
            this.radLabel14.Location = new System.Drawing.Point(1, 86);
            this.radLabel14.Name = "radLabel14";
            this.radLabel14.Size = new System.Drawing.Size(791, 18);
            this.radLabel14.TabIndex = 35;
            this.radLabel14.Text = "Adj. Receivable Details";
            this.radLabel14.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmAddAdjReceivable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(796, 584);
            this.Controls.Add(this.radLabel14);
            this.Controls.Add(this.radLabel13);
            this.Controls.Add(this.radGridView1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.radLabel9);
            this.Controls.Add(this.radLabel10);
            this.Controls.Add(this.txtDebits);
            this.Controls.Add(this.txtCredits);
            this.Controls.Add(this.radLabel11);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtDifference);
            this.Controls.Add(this.btnAutoApply);
            this.Controls.Add(this.radGroupBox1);
            this.Name = "frmAddAdjReceivable";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Record Adj. Receivable";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAddCashReceipt_FormClosing);
            this.Load += new System.EventHandler(this.frmAddCashReceipt_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAdjRcvableNo)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.btnAutoApply)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkShowMemo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtBillingAcctNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1.MasterTemplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadButton btnClose;
        private Telerik.WinControls.UI.RadTextBoxControl txtAdjRcvableNo;
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
        private Telerik.WinControls.UI.RadButton btnAutoApply;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadAutoCompleteBox txtBillingAcctNo;
        private Telerik.WinControls.UI.RadGridView radGridView1;
        private Telerik.WinControls.UI.RadCheckBox chkShowMemo;
        private Telerik.WinControls.UI.RadButton radButton1;
        private Telerik.WinControls.UI.RadLabel radLabel12;
        private Telerik.WinControls.UI.RadLabel radLabel13;
        private Telerik.WinControls.UI.RadLabel radLabel14;
    }
}
