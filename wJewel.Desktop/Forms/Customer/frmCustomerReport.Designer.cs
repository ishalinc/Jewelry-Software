using Telerik.WinControls.UI;
namespace IshalInc.wJewel.Desktop.Forms
{
    partial class frmCustomerReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCustomerReport));
            this.chkBillAccountOnly = new Telerik.WinControls.UI.RadCheckBox();
            this.groupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.rdoSortCustomerName = new Telerik.WinControls.UI.RadRadioButton();
            this.rdoSortCustomerCode = new Telerik.WinControls.UI.RadRadioButton();
            this.txtState = new Telerik.WinControls.UI.RadTextBox();
            this.txtCountry = new Telerik.WinControls.UI.RadTextBox();
            this.txtSalesman = new Telerik.WinControls.UI.RadTextBox();
            this.label1 = new Telerik.WinControls.UI.RadLabel();
            this.label2 = new Telerik.WinControls.UI.RadLabel();
            this.label3 = new Telerik.WinControls.UI.RadLabel();
            this.lblLeaveBlank1 = new Telerik.WinControls.UI.RadLabel();
            this.lblLeaveBlank2 = new Telerik.WinControls.UI.RadLabel();
            this.lblLeaveBlank3 = new Telerik.WinControls.UI.RadLabel();
            this.btnOK = new Telerik.WinControls.UI.RadButton();
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.chkCustomerOnHold = new Telerik.WinControls.UI.RadCheckBox();
            this.chkCustSenttoCollection = new Telerik.WinControls.UI.RadCheckBox();
            this.chkNotes = new Telerik.WinControls.UI.RadCheckBox();
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.radRadioButton3 = new Telerik.WinControls.UI.RadRadioButton();
            this.radRadioButton2 = new Telerik.WinControls.UI.RadRadioButton();
            this.radRadioButton1 = new Telerik.WinControls.UI.RadRadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.chkBillAccountOnly)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rdoSortCustomerName)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdoSortCustomerCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtState)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCountry)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSalesman)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.label3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLeaveBlank1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLeaveBlank2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLeaveBlank3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkCustomerOnHold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkCustSenttoCollection)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkNotes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radRadioButton3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radRadioButton2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radRadioButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // chkBillAccountOnly
            // 
            this.chkBillAccountOnly.Location = new System.Drawing.Point(25, 26);
            this.chkBillAccountOnly.Name = "chkBillAccountOnly";
            this.chkBillAccountOnly.Size = new System.Drawing.Size(121, 18);
            this.chkBillAccountOnly.TabIndex = 0;
            this.chkBillAccountOnly.Text = "Billing Account Only";
            // 
            // groupBox1
            // 
            this.groupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.groupBox1.Controls.Add(this.rdoSortCustomerName);
            this.groupBox1.Controls.Add(this.rdoSortCustomerCode);
            this.groupBox1.HeaderText = "";
            this.groupBox1.Location = new System.Drawing.Point(25, 67);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(560, 100);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            // 
            // rdoSortCustomerName
            // 
            this.rdoSortCustomerName.Location = new System.Drawing.Point(17, 59);
            this.rdoSortCustomerName.Name = "rdoSortCustomerName";
            this.rdoSortCustomerName.Size = new System.Drawing.Size(89, 18);
            this.rdoSortCustomerName.TabIndex = 3;
            this.rdoSortCustomerName.TabStop = false;
            this.rdoSortCustomerName.Text = "Sort By Name";
            // 
            // rdoSortCustomerCode
            // 
            this.rdoSortCustomerCode.CheckState = System.Windows.Forms.CheckState.Checked;
            this.rdoSortCustomerCode.Location = new System.Drawing.Point(17, 19);
            this.rdoSortCustomerCode.Name = "rdoSortCustomerCode";
            this.rdoSortCustomerCode.Size = new System.Drawing.Size(136, 18);
            this.rdoSortCustomerCode.TabIndex = 2;
            this.rdoSortCustomerCode.Text = "Sort By Customer Code";
            this.rdoSortCustomerCode.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            // 
            // txtState
            // 
            this.txtState.Location = new System.Drawing.Point(99, 9);
            this.txtState.Name = "txtState";
            this.txtState.Size = new System.Drawing.Size(196, 20);
            this.txtState.TabIndex = 2;
            // 
            // txtCountry
            // 
            this.txtCountry.Location = new System.Drawing.Point(99, 39);
            this.txtCountry.Name = "txtCountry";
            this.txtCountry.Size = new System.Drawing.Size(196, 20);
            this.txtCountry.TabIndex = 3;
            // 
            // txtSalesman
            // 
            this.txtSalesman.Location = new System.Drawing.Point(99, 68);
            this.txtSalesman.Name = "txtSalesman";
            this.txtSalesman.Size = new System.Drawing.Size(196, 20);
            this.txtSalesman.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 18);
            this.label1.TabIndex = 5;
            this.label1.Text = "State";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 18);
            this.label2.TabIndex = 6;
            this.label2.Text = "Country";
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 18);
            this.label3.TabIndex = 7;
            this.label3.Text = "Salesman";
            // 
            // lblLeaveBlank1
            // 
            this.lblLeaveBlank1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLeaveBlank1.Location = new System.Drawing.Point(303, 13);
            this.lblLeaveBlank1.Name = "lblLeaveBlank1";
            this.lblLeaveBlank1.Size = new System.Drawing.Size(108, 16);
            this.lblLeaveBlank1.TabIndex = 8;
            this.lblLeaveBlank1.Text = "Leave Blank For All";
            // 
            // lblLeaveBlank2
            // 
            this.lblLeaveBlank2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLeaveBlank2.Location = new System.Drawing.Point(303, 43);
            this.lblLeaveBlank2.Name = "lblLeaveBlank2";
            this.lblLeaveBlank2.Size = new System.Drawing.Size(108, 16);
            this.lblLeaveBlank2.TabIndex = 9;
            this.lblLeaveBlank2.Text = "Leave Blank For All";
            // 
            // lblLeaveBlank3
            // 
            this.lblLeaveBlank3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLeaveBlank3.Location = new System.Drawing.Point(303, 72);
            this.lblLeaveBlank3.Name = "lblLeaveBlank3";
            this.lblLeaveBlank3.Size = new System.Drawing.Size(108, 16);
            this.lblLeaveBlank3.TabIndex = 10;
            this.lblLeaveBlank3.Text = "Leave Blank For All";
            // 
            // btnOK
            // 
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.Location = new System.Drawing.Point(431, 294);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 23);
            this.btnOK.TabIndex = 11;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(512, 294);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 12;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // radLabel1
            // 
            this.radLabel1.AutoSize = false;
            this.radLabel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.radLabel1.BorderVisible = true;
            this.radLabel1.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.radLabel1.ForeColor = System.Drawing.Color.White;
            this.radLabel1.Location = new System.Drawing.Point(25, 50);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(560, 18);
            this.radLabel1.TabIndex = 32;
            this.radLabel1.Text = "Sort By";
            this.radLabel1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.label1);
            this.radGroupBox1.Controls.Add(this.txtState);
            this.radGroupBox1.Controls.Add(this.txtCountry);
            this.radGroupBox1.Controls.Add(this.lblLeaveBlank3);
            this.radGroupBox1.Controls.Add(this.txtSalesman);
            this.radGroupBox1.Controls.Add(this.lblLeaveBlank2);
            this.radGroupBox1.Controls.Add(this.label2);
            this.radGroupBox1.Controls.Add(this.lblLeaveBlank1);
            this.radGroupBox1.Controls.Add(this.label3);
            this.radGroupBox1.HeaderText = "";
            this.radGroupBox1.Location = new System.Drawing.Point(25, 183);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(560, 100);
            this.radGroupBox1.TabIndex = 4;
            this.radGroupBox1.TabStop = false;
            // 
            // radLabel2
            // 
            this.radLabel2.AutoSize = false;
            this.radLabel2.BackColor = System.Drawing.SystemColors.HotTrack;
            this.radLabel2.BorderVisible = true;
            this.radLabel2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.radLabel2.ForeColor = System.Drawing.Color.White;
            this.radLabel2.Location = new System.Drawing.Point(25, 166);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(560, 18);
            this.radLabel2.TabIndex = 33;
            this.radLabel2.Text = "Filter By";
            this.radLabel2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkCustomerOnHold
            // 
            this.chkCustomerOnHold.Location = new System.Drawing.Point(157, 26);
            this.chkCustomerOnHold.Name = "chkCustomerOnHold";
            this.chkCustomerOnHold.Size = new System.Drawing.Size(114, 18);
            this.chkCustomerOnHold.TabIndex = 34;
            this.chkCustomerOnHold.Text = "Customer On Hold";
            // 
            // chkCustSenttoCollection
            // 
            this.chkCustSenttoCollection.Location = new System.Drawing.Point(327, 26);
            this.chkCustSenttoCollection.Name = "chkCustSenttoCollection";
            this.chkCustSenttoCollection.Size = new System.Drawing.Size(160, 18);
            this.chkCustSenttoCollection.TabIndex = 1;
            this.chkCustSenttoCollection.Text = "Customer Sent to Collection";
            // 
            // chkNotes
            // 
            this.chkNotes.Location = new System.Drawing.Point(535, 26);
            this.chkNotes.Name = "chkNotes";
            this.chkNotes.Size = new System.Drawing.Size(50, 18);
            this.chkNotes.TabIndex = 2;
            this.chkNotes.Text = "Notes";
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.Controls.Add(this.radRadioButton3);
            this.radGroupBox2.Controls.Add(this.radRadioButton2);
            this.radGroupBox2.Controls.Add(this.radRadioButton1);
            this.radGroupBox2.HeaderText = "";
            this.radGroupBox2.Location = new System.Drawing.Point(25, 289);
            this.radGroupBox2.Name = "radGroupBox2";
            this.radGroupBox2.Size = new System.Drawing.Size(400, 35);
            this.radGroupBox2.TabIndex = 35;
            // 
            // radRadioButton3
            // 
            this.radRadioButton3.Location = new System.Drawing.Point(144, 8);
            this.radRadioButton3.Name = "radRadioButton3";
            this.radRadioButton3.Size = new System.Drawing.Size(47, 18);
            this.radRadioButton3.TabIndex = 1;
            this.radRadioButton3.TabStop = false;
            this.radRadioButton3.Text = "Email";
            this.radRadioButton3.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.radRadioButton1_ToggleStateChanged);
            // 
            // radRadioButton2
            // 
            this.radRadioButton2.Location = new System.Drawing.Point(283, 8);
            this.radRadioButton2.Name = "radRadioButton2";
            this.radRadioButton2.Size = new System.Drawing.Size(43, 18);
            this.radRadioButton2.TabIndex = 1;
            this.radRadioButton2.TabStop = false;
            this.radRadioButton2.Text = "Print";
            this.radRadioButton2.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.radRadioButton1_ToggleStateChanged);
            // 
            // radRadioButton1
            // 
            this.radRadioButton1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.radRadioButton1.Location = new System.Drawing.Point(21, 8);
            this.radRadioButton1.Name = "radRadioButton1";
            this.radRadioButton1.Size = new System.Drawing.Size(54, 18);
            this.radRadioButton1.TabIndex = 0;
            this.radRadioButton1.Text = "Preview";
            this.radRadioButton1.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            this.radRadioButton1.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.radRadioButton1_ToggleStateChanged);
            // 
            // frmCustomerReport
            // 
            this.ClientSize = new System.Drawing.Size(626, 329);
            this.Controls.Add(this.radGroupBox2);
            this.Controls.Add(this.chkNotes);
            this.Controls.Add(this.chkCustSenttoCollection);
            this.Controls.Add(this.chkCustomerOnHold);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.radGroupBox1);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.chkBillAccountOnly);
            this.Name = "frmCustomerReport";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Customer Report";
            this.Load += new System.EventHandler(this.frmCustomerReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chkBillAccountOnly)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rdoSortCustomerName)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdoSortCustomerCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtState)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCountry)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSalesman)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.label3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLeaveBlank1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLeaveBlank2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblLeaveBlank3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkCustomerOnHold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkCustSenttoCollection)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkNotes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            this.radGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radRadioButton3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radRadioButton2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radRadioButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RadCheckBox chkBillAccountOnly;
        private RadGroupBox groupBox1;
        private RadRadioButton rdoSortCustomerName;
        private RadRadioButton rdoSortCustomerCode;
        private RadTextBox txtState;
        private RadTextBox txtCountry;
        private RadTextBox txtSalesman;
        private RadLabel label1;
        private RadLabel label2;
        private RadLabel label3;
        private RadLabel lblLeaveBlank1;
        private RadLabel lblLeaveBlank2;
        private RadLabel lblLeaveBlank3;
        private RadButton btnOK;
        private RadButton btnCancel;
        private RadLabel radLabel1;
        private RadGroupBox radGroupBox1;
        private RadLabel radLabel2;
        private RadCheckBox chkCustomerOnHold;
        private RadCheckBox chkCustSenttoCollection;
        private RadCheckBox chkNotes;
        private RadGroupBox radGroupBox2;
        private RadRadioButton radRadioButton3;
        private RadRadioButton radRadioButton2;
        private RadRadioButton radRadioButton1;
    }
}