namespace IshalInc.wJewel.Desktop.Forms
{
    partial class frmPrintOptions
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
            this.radGroupBox2 = new Telerik.WinControls.UI.RadGroupBox();
            this.preview = new Telerik.WinControls.UI.RadRadioButton();
            this.email = new Telerik.WinControls.UI.RadRadioButton();
            this.print = new Telerik.WinControls.UI.RadRadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).BeginInit();
            this.radGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.preview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.email)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.print)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // radButton2
            // 
            this.radButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.radButton2.Image = global::IshalInc.wJewel.Desktop.Properties.Resources.cancel;
            this.radButton2.Location = new System.Drawing.Point(380, 35);
            this.radButton2.Name = "radButton2";
            this.radButton2.Size = new System.Drawing.Size(87, 24);
            this.radButton2.TabIndex = 8;
            this.radButton2.Text = "Cancel";
            this.radButton2.Click += new System.EventHandler(this.radButton2_Click_1);
            // 
            // radButton1
            // 
            this.radButton1.Image = global::IshalInc.wJewel.Desktop.Properties.Resources.OK;
            this.radButton1.Location = new System.Drawing.Point(258, 35);
            this.radButton1.Name = "radButton1";
            this.radButton1.Size = new System.Drawing.Size(85, 24);
            this.radButton1.TabIndex = 7;
            this.radButton1.Text = "Ok";
            this.radButton1.Click += new System.EventHandler(this.radButton1_Click_2);
            // 
            // radGroupBox2
            // 
            this.radGroupBox2.AccessibleRole = System.Windows.Forms.AccessibleRole.Grouping;
            this.radGroupBox2.Controls.Add(this.preview);
            this.radGroupBox2.Controls.Add(this.email);
            this.radGroupBox2.Controls.Add(this.print);
            this.radGroupBox2.HeaderText = "";
            this.radGroupBox2.Location = new System.Drawing.Point(12, 27);
            this.radGroupBox2.Name = "radGroupBox2";
            this.radGroupBox2.Size = new System.Drawing.Size(240, 50);
            this.radGroupBox2.TabIndex = 6;
            // 
            // preview
            // 
            this.preview.Location = new System.Drawing.Point(15, 11);
            this.preview.Name = "preview";
            this.preview.Size = new System.Drawing.Size(59, 18);
            this.preview.TabIndex = 1;
            this.preview.Text = "Preview";
            // 
            // email
            // 
            this.email.Location = new System.Drawing.Point(96, 11);
            this.email.Name = "email";
            this.email.Size = new System.Drawing.Size(47, 18);
            this.email.TabIndex = 2;
            this.email.Text = "Email";
            // 
            // print
            // 
            this.print.Location = new System.Drawing.Point(170, 11);
            this.print.Name = "print";
            this.print.Size = new System.Drawing.Size(43, 18);
            this.print.TabIndex = 3;
            this.print.Text = "Print";
            // 
            // frmPrintOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.radButton2;
            this.ClientSize = new System.Drawing.Size(497, 87);
            this.Controls.Add(this.radButton2);
            this.Controls.Add(this.radButton1);
            this.Controls.Add(this.radGroupBox2);
            this.Name = "frmPrintOptions";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = "frmPrintOptions";
            ((System.ComponentModel.ISupportInitialize)(this.radButton2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.radGroupBox2)).EndInit();
            this.radGroupBox2.ResumeLayout(false);
            this.radGroupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.preview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.email)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.print)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Telerik.WinControls.UI.RadButton radButton2;
        private Telerik.WinControls.UI.RadButton radButton1;
        private Telerik.WinControls.UI.RadGroupBox radGroupBox2;
        private Telerik.WinControls.UI.RadRadioButton preview;
        private Telerik.WinControls.UI.RadRadioButton email;
        private Telerik.WinControls.UI.RadRadioButton print;
    }
}
