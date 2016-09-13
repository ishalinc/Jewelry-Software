namespace IshalInc.wJewel.Desktop.Forms
{
    partial class frmCreditByCreditCode
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
            this.btnPrint = new Telerik.WinControls.UI.RadButton();
            this.btnCancel = new Telerik.WinControls.UI.RadButton();
            this.radGroupBox1 = new Telerik.WinControls.UI.RadGroupBox();
            this.radRadioButton3 = new Telerik.WinControls.UI.RadRadioButton();
            this.radRadioButton2 = new Telerik.WinControls.UI.RadRadioButton();
            this.radRadioButton1 = new Telerik.WinControls.UI.RadRadioButton();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.radListView1 = new Telerik.WinControls.UI.RadListView();
            this.radLabel4 = new Telerik.WinControls.UI.RadLabel();
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.chkAllSalesman = new Telerik.WinControls.UI.RadCheckBox();
            this.radLabel7 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel6 = new Telerik.WinControls.UI.RadLabel();
            this.dateTo = new Telerik.WinControls.UI.RadDateTimePicker();
            this.dateFrom = new Telerik.WinControls.UI.RadDateTimePicker();
            this.chkAllCustomers = new Telerik.WinControls.UI.RadCheckBox();
            this.txtToCustomerCode = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel5 = new Telerik.WinControls.UI.RadLabel();
            this.txtFromCustomerCode = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radRadioButton3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radRadioButton2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radRadioButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radListView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkAllSalesman)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFrom)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAllCustomers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtToCustomerCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFromCustomerCode)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnPrint.Image = global::IshalInc.wJewel.Desktop.Properties.Resources.printer;
            this.btnPrint.Location = new System.Drawing.Point(482, 223);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(82, 24);
            this.btnPrint.TabIndex = 0;
            this.btnPrint.Text = "Print";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnCancel.Image = global::IshalInc.wJewel.Desktop.Properties.Resources.undo;
            this.btnCancel.Location = new System.Drawing.Point(569, 223);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(88, 24);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.radRadioButton3);
            this.radGroupBox1.Controls.Add(this.radRadioButton2);
            this.radGroupBox1.Controls.Add(this.radRadioButton1);
            this.radGroupBox1.HeaderText = "";
            this.radGroupBox1.Location = new System.Drawing.Point(130, 223);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(324, 25);
            this.radGroupBox1.TabIndex = 2;
            // 
            // radRadioButton3
            // 
            this.radRadioButton3.Location = new System.Drawing.Point(122, 4);
            this.radRadioButton3.Name = "radRadioButton3";
            this.radRadioButton3.Size = new System.Drawing.Size(47, 18);
            this.radRadioButton3.TabIndex = 1;
            this.radRadioButton3.TabStop = false;
            this.radRadioButton3.Text = "Email";
            this.radRadioButton3.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.radRadioButton1_ToggleStateChanged);
            // 
            // radRadioButton2
            // 
            this.radRadioButton2.Location = new System.Drawing.Point(255, 4);
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
            this.radRadioButton1.Location = new System.Drawing.Point(22, 4);
            this.radRadioButton1.Name = "radRadioButton1";
            this.radRadioButton1.Size = new System.Drawing.Size(59, 18);
            this.radRadioButton1.TabIndex = 0;
            this.radRadioButton1.Text = "Preview";
            this.radRadioButton1.ToggleState = Telerik.WinControls.Enumerations.ToggleState.On;
            this.radRadioButton1.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.radRadioButton1_ToggleStateChanged);
            this.radRadioButton1.Click += new System.EventHandler(this.radRadioButton1_Click);
            // 
            // radLabel2
            // 
            this.radLabel2.AutoSize = false;
            this.radLabel2.BackColor = System.Drawing.SystemColors.HotTrack;
            this.radLabel2.BorderVisible = true;
            this.radLabel2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.radLabel2.ForeColor = System.Drawing.Color.White;
            this.radLabel2.Location = new System.Drawing.Point(0, 10);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(657, 18);
            this.radLabel2.TabIndex = 5;
            this.radLabel2.Text = "Credits By Credit Code";
            this.radLabel2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // radListView1
            // 
            this.radListView1.Location = new System.Drawing.Point(3, 54);
            this.radListView1.MultiSelect = true;
            this.radListView1.Name = "radListView1";
            this.radListView1.Size = new System.Drawing.Size(121, 196);
            this.radListView1.TabIndex = 40;
            this.radListView1.Text = "radListView1";
            this.radListView1.ItemMouseClick += new Telerik.WinControls.UI.ListViewItemEventHandler(this.radListView1_ItemMouseClick);
            // 
            // radLabel4
            // 
            this.radLabel4.Location = new System.Drawing.Point(3, 34);
            this.radLabel4.Name = "radLabel4";
            this.radLabel4.Size = new System.Drawing.Size(56, 18);
            this.radLabel4.TabIndex = 36;
            this.radLabel4.Text = "Salesman:";
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.Controls.Add(this.chkAllSalesman);
            this.radGroupBox2.Controls.Add(this.radLabel7);
            this.radGroupBox2.Controls.Add(this.radLabel6);
            this.radGroupBox2.Controls.Add(this.dateTo);
            this.radGroupBox2.Controls.Add(this.dateFrom);
            this.radGroupBox2.Controls.Add(this.chkAllCustomers);
            this.radGroupBox2.Controls.Add(this.txtToCustomerCode);
            this.radGroupBox2.Controls.Add(this.radLabel5);
            this.radGroupBox2.Controls.Add(this.txtFromCustomerCode);
            this.radGroupBox2.Controls.Add(this.radLabel1);
            this.radGroupBox2.HeaderText = "";
            this.radGroupBox2.Location = new System.Drawing.Point(130, 43);
            this.radGroupBox2.Name = "radGroupBox2";
            this.radGroupBox2.Size = new System.Drawing.Size(527, 119);
            this.radGroupBox2.TabIndex = 41;
            // 
            // chkAllSalesman
            // 
            this.chkAllSalesman.Location = new System.Drawing.Point(6, 93);
            this.chkAllSalesman.Name = "chkAllSalesman";
            this.chkAllSalesman.Size = new System.Drawing.Size(83, 18);
            this.chkAllSalesman.TabIndex = 53;
            this.chkAllSalesman.Text = "All Salesman";
            this.chkAllSalesman.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.chkAllSalesman_ToggleStateChanged);
            // 
            // radLabel7
            // 
            this.radLabel7.Location = new System.Drawing.Point(6, 61);
            this.radLabel7.Name = "radLabel7";
            this.radLabel7.Size = new System.Drawing.Size(48, 18);
            this.radLabel7.TabIndex = 44;
            this.radLabel7.Text = "To Date:";
            // 
            // radLabel6
            // 
            this.radLabel6.Location = new System.Drawing.Point(259, 61);
            this.radLabel6.Name = "radLabel6";
            this.radLabel6.Size = new System.Drawing.Size(61, 18);
            this.radLabel6.TabIndex = 47;
            this.radLabel6.Text = "From Date:";
            // 
            // dateTo
            // 
            this.dateTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTo.Location = new System.Drawing.Point(380, 60);
            this.dateTo.Name = "dateTo";
            this.dateTo.Size = new System.Drawing.Size(91, 20);
            this.dateTo.TabIndex = 52;
            this.dateTo.TabStop = false;
            this.dateTo.Text = "5/3/16";
            this.dateTo.Value = new System.DateTime(2016, 5, 3, 15, 14, 22, 154);
            // 
            // dateFrom
            // 
            this.dateFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateFrom.Location = new System.Drawing.Point(127, 60);
            this.dateFrom.Name = "dateFrom";
            this.dateFrom.Size = new System.Drawing.Size(91, 20);
            this.dateFrom.TabIndex = 51;
            this.dateFrom.TabStop = false;
            this.dateFrom.Text = "5/3/16";
            this.dateFrom.Value = new System.DateTime(2016, 5, 3, 15, 14, 22, 154);
            // 
            // chkAllCustomers
            // 
            this.chkAllCustomers.Location = new System.Drawing.Point(6, 7);
            this.chkAllCustomers.Name = "chkAllCustomers";
            this.chkAllCustomers.Size = new System.Drawing.Size(89, 18);
            this.chkAllCustomers.TabIndex = 49;
            this.chkAllCustomers.Text = "All Customers";
            this.chkAllCustomers.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.radCheckBox1_ToggleStateChanged);
            // 
            // txtToCustomerCode
            // 
            this.txtToCustomerCode.Location = new System.Drawing.Point(380, 30);
            this.txtToCustomerCode.Name = "txtToCustomerCode";
            this.txtToCustomerCode.Size = new System.Drawing.Size(91, 20);
            this.txtToCustomerCode.TabIndex = 47;
            // 
            // radLabel5
            // 
            this.radLabel5.Location = new System.Drawing.Point(258, 31);
            this.radLabel5.Name = "radLabel5";
            this.radLabel5.Size = new System.Drawing.Size(115, 18);
            this.radLabel5.TabIndex = 46;
            this.radLabel5.Text = "From Customer Code:";
            // 
            // txtFromCustomerCode
            // 
            this.txtFromCustomerCode.Location = new System.Drawing.Point(127, 30);
            this.txtFromCustomerCode.Name = "txtFromCustomerCode";
            this.txtFromCustomerCode.Size = new System.Drawing.Size(91, 20);
            this.txtFromCustomerCode.TabIndex = 44;
            this.txtFromCustomerCode.Validated += new System.EventHandler(this.txtFromCustomerCode_Validated);
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(6, 31);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(115, 18);
            this.radLabel1.TabIndex = 43;
            this.radLabel1.Text = "From Customer Code:";
            // 
            // frmCreditByCreditCode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(658, 279);
            this.Controls.Add(this.radGroupBox2);
            this.Controls.Add(this.radLabel4);
            this.Controls.Add(this.radListView1);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.radGroupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnPrint);
            this.Name = "frmCreditByCreditCode";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Credit By Credit Code";
            this.Load += new System.EventHandler(this.frmCreditByCreditCode_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radRadioButton3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radRadioButton2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radRadioButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radListView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            this.radGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkAllSalesman)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateTo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateFrom)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkAllCustomers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtToCustomerCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFromCustomerCode)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadButton btnPrint;
        private Telerik.WinControls.UI.RadButton btnCancel;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadRadioButton radRadioButton3;
        private Telerik.WinControls.UI.RadRadioButton radRadioButton2;
        private Telerik.WinControls.UI.RadRadioButton radRadioButton1;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadListView radListView1;
        private Telerik.WinControls.UI.RadLabel radLabel4;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
        private Telerik.WinControls.UI.RadCheckBox chkAllCustomers;
        private Telerik.WinControls.UI.RadTextBox txtToCustomerCode;
        private Telerik.WinControls.UI.RadLabel radLabel5;
        private Telerik.WinControls.UI.RadTextBox txtFromCustomerCode;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel7;
        private Telerik.WinControls.UI.RadLabel radLabel6;
        private Telerik.WinControls.UI.RadDateTimePicker dateTo;
        private Telerik.WinControls.UI.RadDateTimePicker dateFrom;
        private Telerik.WinControls.UI.RadCheckBox chkAllSalesman;
    }
}
