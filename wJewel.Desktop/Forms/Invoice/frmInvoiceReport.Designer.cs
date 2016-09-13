namespace IshalInc.wJewel.Desktop.Forms
{
    partial class frmInvoiceReport
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
            this.chkPrintImages = new Telerik.WinControls.UI.RadCheckBox();
            this.lblCopies = new Telerik.WinControls.UI.RadLabel();
            this.txtNoofCopies = new Telerik.WinControls.UI.RadMaskedEditBox();
            this.radRadioButton3 = new Telerik.WinControls.UI.RadRadioButton();
            this.radRadioButton2 = new Telerik.WinControls.UI.RadRadioButton();
            this.radRadioButton1 = new Telerik.WinControls.UI.RadRadioButton();
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).BeginInit();
            this.radGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkPrintImages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCopies)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNoofCopies)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radRadioButton3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radRadioButton2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radRadioButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnPrint.Image = global::IshalInc.wJewel.Desktop.Properties.Resources.OK;
            this.btnPrint.Location = new System.Drawing.Point(123, 129);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(84, 24);
            this.btnPrint.TabIndex = 0;
            this.btnPrint.Text = "OK";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnCancel.Image = global::IshalInc.wJewel.Desktop.Properties.Resources.undo;
            this.btnCancel.Location = new System.Drawing.Point(215, 129);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(84, 24);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // radGroupBox1
            // 
            this.radGroupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox1.Controls.Add(this.chkPrintImages);
            this.radGroupBox1.Controls.Add(this.lblCopies);
            this.radGroupBox1.Controls.Add(this.txtNoofCopies);
            this.radGroupBox1.Controls.Add(this.radRadioButton3);
            this.radGroupBox1.Controls.Add(this.radRadioButton2);
            this.radGroupBox1.Controls.Add(this.radRadioButton1);
            this.radGroupBox1.HeaderText = "";
            this.radGroupBox1.Location = new System.Drawing.Point(0, 26);
            this.radGroupBox1.Name = "radGroupBox1";
            this.radGroupBox1.Size = new System.Drawing.Size(423, 86);
            this.radGroupBox1.TabIndex = 2;
            // 
            // chkPrintImages
            // 
            this.chkPrintImages.Location = new System.Drawing.Point(12, 61);
            this.chkPrintImages.Name = "chkPrintImages";
            this.chkPrintImages.Size = new System.Drawing.Size(107, 18);
            this.chkPrintImages.TabIndex = 4;
            this.chkPrintImages.Text = "Print with Images";
            // 
            // lblCopies
            // 
            this.lblCopies.Location = new System.Drawing.Point(282, 62);
            this.lblCopies.Name = "lblCopies";
            this.lblCopies.Size = new System.Drawing.Size(74, 18);
            this.lblCopies.TabIndex = 3;
            this.lblCopies.Text = "No. of Copies";
            this.lblCopies.Visible = false;
            // 
            // txtNoofCopies
            // 
            this.txtNoofCopies.Location = new System.Drawing.Point(362, 61);
            this.txtNoofCopies.Mask = "N0";
            this.txtNoofCopies.MaskType = Telerik.WinControls.UI.MaskType.Numeric;
            this.txtNoofCopies.Name = "txtNoofCopies";
            this.txtNoofCopies.Size = new System.Drawing.Size(43, 20);
            this.txtNoofCopies.TabIndex = 2;
            this.txtNoofCopies.TabStop = false;
            this.txtNoofCopies.Text = "0";
            this.txtNoofCopies.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNoofCopies.Visible = false;
            // 
            // radRadioButton3
            // 
            this.radRadioButton3.Location = new System.Drawing.Point(162, 31);
            this.radRadioButton3.Name = "radRadioButton3";
            this.radRadioButton3.Size = new System.Drawing.Size(47, 18);
            this.radRadioButton3.TabIndex = 1;
            this.radRadioButton3.TabStop = false;
            this.radRadioButton3.Text = "Email";
            this.radRadioButton3.ToggleStateChanged += new Telerik.WinControls.UI.StateChangedEventHandler(this.radRadioButton1_ToggleStateChanged);
            // 
            // radRadioButton2
            // 
            this.radRadioButton2.Location = new System.Drawing.Point(329, 31);
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
            this.radRadioButton1.Location = new System.Drawing.Point(12, 31);
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
            this.radLabel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.radLabel2.BorderVisible = true;
            this.radLabel2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.radLabel2.ForeColor = System.Drawing.Color.White;
            this.radLabel2.Location = new System.Drawing.Point(0, 10);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(423, 18);
            this.radLabel2.TabIndex = 5;
            this.radLabel2.Text = "Print Invoice";
            this.radLabel2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmInvoiceReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 165);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.radGroupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnPrint);
            this.Name = "frmInvoiceReport";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Print Invoice Report";
            ((System.ComponentModel.ISupportInitialize)(this.btnPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox1)).EndInit();
            this.radGroupBox1.ResumeLayout(false);
            this.radGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkPrintImages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lblCopies)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtNoofCopies)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radRadioButton3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radRadioButton2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radRadioButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadButton btnPrint;
        private Telerik.WinControls.UI.RadButton btnCancel;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox1;
        private Telerik.WinControls.UI.RadLabel lblCopies;
        private Telerik.WinControls.UI.RadMaskedEditBox txtNoofCopies;
        private Telerik.WinControls.UI.RadRadioButton radRadioButton3;
        private Telerik.WinControls.UI.RadRadioButton radRadioButton2;
        private Telerik.WinControls.UI.RadRadioButton radRadioButton1;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadCheckBox chkPrintImages;
    }
}
