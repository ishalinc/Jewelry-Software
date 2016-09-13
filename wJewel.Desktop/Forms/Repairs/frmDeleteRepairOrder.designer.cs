namespace IshalInc.wJewel.Desktop.Forms
{
    partial class frmDeleteRepairOrder
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
            this.radButton1 = new Telerik.WinControls.UI.RadButton();
            this.btnOK = new Telerik.WinControls.UI.RadButton();
            this.repairordernumber = new Telerik.WinControls.UI.RadTextBox();
            this.radLabel1 = new Telerik.WinControls.UI.RadLabel();
            this.radLabel10 = new Telerik.WinControls.UI.RadLabel();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repairordernumber)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radButton1
            // 
            this.radButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.radButton1.Location = new System.Drawing.Point(217, 87);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(110, 24);
            this.radButton1.TabIndex = 79;
            this.radButton1.Text = "Cancel";
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(217, 45);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(110, 24);
            this.btnOK.TabIndex = 78;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // repairordernumber
            // 
            this.repairordernumber.Location = new System.Drawing.Point(88, 45);
            this.repairordernumber.MaxLength = 6;
            this.repairordernumber.Name = "repairordernumber";
            this.repairordernumber.Size = new System.Drawing.Size(123, 20);
            this.repairordernumber.TabIndex = 77;
            // 
            // radLabel1
            // 
            this.radLabel1.Location = new System.Drawing.Point(1, 45);
            this.radLabel1.Name = "radLabel1";
            this.radLabel1.Size = new System.Drawing.Size(88, 18);
            this.radLabel1.TabIndex = 76;
            this.radLabel1.Text = "Repair Order No";
            // 
            // radLabel10
            // 
            this.radLabel10.AutoSize = false;
            this.radLabel10.BackColor = System.Drawing.Color.RoyalBlue;
            this.radLabel10.BorderVisible = true;
            this.radLabel10.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Bold);
            this.radLabel10.ForeColor = System.Drawing.Color.White;
            this.radLabel10.Location = new System.Drawing.Point(1, 3);
            this.radLabel10.Name = "radLabel10";
            this.radLabel10.Size = new System.Drawing.Size(335, 18);
            this.radLabel10.TabIndex = 75;
            this.radLabel10.Text = "Delete Repair Order";
            this.radLabel10.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // frmDeleteRepairOrder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.radButton1;
            this.ClientSize = new System.Drawing.Size(336, 119);
            this.Controls.Add(this.radButton1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.repairordernumber);
            this.Controls.Add(this.radLabel1);
            this.Controls.Add(this.radLabel10);
            this.Name = "frmDeleteRepairOrder";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frmDeleteRepairOrder";
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repairordernumber)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radLabel10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Telerik.WinControls.UI.RadButton radButton1;
        private Telerik.WinControls.UI.RadButton btnOK;
        private Telerik.WinControls.UI.RadTextBox repairordernumber;
        private Telerik.WinControls.UI.RadLabel radLabel1;
        private Telerik.WinControls.UI.RadLabel radLabel10;
    }
}
