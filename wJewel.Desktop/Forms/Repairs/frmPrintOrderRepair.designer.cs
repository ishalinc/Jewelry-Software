namespace IshalInc.wJewel.Desktop.Forms
{
    partial class frmPrintOrderRepair
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
            this.radButton2 = new Telerik.WinControls.UI.RadButton();
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.repairordernumber = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel10 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repairordernumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radButton2
            // 
            this.radButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.radButton2.Image = global::IshalInc.wJewel.Desktop.Properties.Resources.cancel;
            this.radButton2.Location = new System.Drawing.Point(219, 90);
            this.radButton2.Name = "radButton2";
            this.radButton2.Size = new System.Drawing.Size(110, 24);
            this.radButton2.TabIndex = 4;
            this.radButton2.Text = "Cancel";
            this.radButton2.Click += new System.EventHandler(this.radButton2_Click);
            // 
            // radButton1
            // 
            this.radButton1.Image = global::IshalInc.wJewel.Desktop.Properties.Resources.OK;
            this.radButton1.Location = new System.Drawing.Point(219, 47);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(110, 24);
            this.radButton1.TabIndex = 3;
            this.radButton1.Text = "Ok";
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
            // 
            // repairordernumber
            // 
            this.repairordernumber.Location = new System.Drawing.Point(87, 49);
            this.repairordernumber.Name = "repairordernumber";
            this.repairordernumber.ReadOnly = true;
            this.repairordernumber.Size = new System.Drawing.Size(121, 20);
            this.repairordernumber.TabIndex = 1;
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(12, 49);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(56, 18);
            this.radLabel1.TabIndex = 0;
            this.radLabel1.Text = "Repair No";
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
            this.radLabel10.TabIndex = 66;
            this.radLabel10.Text = "Repair Order Number For Print";
            this.radLabel10.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmPrintOrderRepair
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.radButton2;
            this.ClientSize = new System.Drawing.Size(341, 129);
            this.Controls.Add(this.radButton2);
            this.Controls.Add(this.radLabel10);
            this.Controls.Add(this.radButton1);
            this.Controls.Add(this.repairordernumber);
            this.Controls.Add(this.radLabel1);
            this.Name = "frmPrintOrderRepair";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "Print Repair Order";
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repairordernumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Telerik.WinControls.UI.RadTextBox repairordernumber;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadButton radButton2;
        private Telerik.WinControls.UI.RadButton radButton1;
        private Telerik.WinControls.UI.RadLabel radLabel10;
    }
}
