﻿namespace IshalInc.wJewel.Desktop.Forms
{
    partial class frmDeleteCredit
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
            this.radLabel2 = new Telerik.WinControls.UI.RadLabel();
            this.txtCreditNo = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.btnPrint)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreditNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnPrint.Image = global::IshalInc.wJewel.Desktop.Properties.Resources.OK;
            this.btnPrint.Location = new System.Drawing.Point(127, 129);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(77, 24);
            this.btnPrint.TabIndex = 0;
            this.btnPrint.Text = "OK";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.btnCancel.Image = global::IshalInc.wJewel.Desktop.Properties.Resources.undo;
            this.btnCancel.Location = new System.Drawing.Point(213, 129);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(83, 24);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // radLabel2
            // 
            this.radLabel2.AutoSize = false;
            this.radLabel2.BackColor = System.Drawing.Color.Red;
            this.radLabel2.BorderVisible = true;
            this.radLabel2.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.radLabel2.ForeColor = System.Drawing.Color.White;
            this.radLabel2.Location = new System.Drawing.Point(0, 10);
            this.radLabel2.Name = "radLabel2";
            this.radLabel2.Size = new System.Drawing.Size(423, 18);
            this.radLabel2.TabIndex = 5;
            this.radLabel2.Text = "Delete Credit";
            this.radLabel2.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCreditNo
            // 
            this.txtCreditNo.Location = new System.Drawing.Point(178, 57);
            this.txtCreditNo.Name = "txtCreditNo";
            this.txtCreditNo.Size = new System.Drawing.Size(100, 20);
            this.txtCreditNo.TabIndex = 6;
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(105, 57);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(57, 18);
            this.radLabel1.TabIndex = 7;
            this.radLabel1.Text = "Credit No.";
            // 
            // frmDeleteCredit
            // 
            this.AcceptButton = this.btnPrint;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(422, 165);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.txtCreditNo);
            this.Controls.Add(this.radLabel2);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnPrint);
            this.Name = "frmDeleteCredit";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Delete Credit";
            this.Load += new System.EventHandler(this.frmDeleteReceipt_Load);
            ((System.ComponentModel.ISupportInitialize)(this.btnPrint)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreditNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadButton btnPrint;
        private Telerik.WinControls.UI.RadButton btnCancel;
        private Telerik.WinControls.UI.RadLabel radLabel2;
        private Telerik.WinControls.UI.RadTextBox txtCreditNo;
        private Telerik.WinControls.UI.RadLabel radLabel1;
    }
}
