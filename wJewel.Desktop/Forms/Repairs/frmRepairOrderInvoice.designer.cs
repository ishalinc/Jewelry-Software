namespace IshalInc.wJewel.Desktop.Forms
{
    partial class frmRepairOrderInvoice
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
            this.radLabel10 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.repairordernumber = new Telerik.WinControls.UI.RadTextBox();
            this.btnOK = new Telerik.WinControls.UI.RadButton();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repairordernumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radLabel10
            // 
            this.radLabel10.AutoSize = false;
            this.radLabel10.BackColor = System.Drawing.Color.RoyalBlue;
            this.radLabel10.BorderVisible = true;
            this.radLabel10.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.radLabel10.ForeColor = System.Drawing.Color.White;
            this.radLabel10.Location = new System.Drawing.Point(3, 3);
            this.radLabel10.Name = "radLabel10";
            this.radLabel10.Size = new System.Drawing.Size(335, 18);
            this.radLabel10.TabIndex = 65;
            this.radLabel10.Text = "Enter Repair Order Number For Invoice";
            this.radLabel10.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(3, 45);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(59, 18);
            this.radLabel1.TabIndex = 66;
            this.radLabel1.Text = "Repair No.";
            // 
            // repairordernumber
            // 
            this.repairordernumber.Location = new System.Drawing.Point(68, 45);
            this.repairordernumber.MaxLength = 6;
            this.repairordernumber.Name = "repairordernumber";
            this.repairordernumber.Size = new System.Drawing.Size(123, 20);
            this.repairordernumber.TabIndex = 67;
            this.repairordernumber.TextChanged += new System.EventHandler(this.repairordernumber_TextChanged);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(219, 45);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(110, 24);
            this.btnOK.TabIndex = 68;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // radButton1
            // 
            this.radButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.radButton1.Location = new System.Drawing.Point(219, 87);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(110, 24);
            this.radButton1.TabIndex = 69;
            this.radButton1.Text = "Cancel";
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
            // 
            // frmRepairOrderInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.radButton1;
            this.ClientSize = new System.Drawing.Size(341, 123);
            this.Controls.Add(this.radButton1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.repairordernumber);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.radLabel10);
            this.Name = "frmRepairOrderInvoice";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Repair Order Invoice";
            ((System.ComponentModel.ISupportInitialize)(this.radLabel10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repairordernumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadLabel radLabel10;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadTextBox repairordernumber;
        private Telerik.WinControls.UI.RadButton btnOK;
        private Telerik.WinControls.UI.RadButton radButton1;
    }
}
