using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using IshalInc.wJewel.Desktop.Libraries;
using IshalInc.wJewel.Desktop.Properties;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Telerik.WinControls.UI.Localization;
using IshalInc.wJewel.Desktop.Libraries;

namespace IshalInc.wJewel.Desktop.Forms
{
    public partial class frmMain : RadForm
    {
        
      
        public frmMain()
        {
            InitializeComponent();
           

        
        }


        private void frmMain_Load(object sender, EventArgs e)
        {
            if (Environment.MachineName == "MANDEEP")
            Helper.SyncStroedProcRemoteDB("Data Source = 74.208.90.75; Initial Catalog = wjewel; User ID = sa; Password = Javid456#");
            // this.Icon = Helper.MakeIcon(Resources.mainicon, 24, true);
            RadMenu objMenuStrip = new RadMenu();
            this.Text = string.Format("{0} - {1}", "WJewel - Jewelry Manufacturing Software", "1.0") ;
            
          
            DynamicMenu objMenu = new DynamicMenu();
            string menuFile = Resources.Menu;
            byte[] myBytes = System.Text.Encoding.GetEncoding("UTF-8").GetBytes(menuFile);
            MemoryStream ms = new MemoryStream(myBytes);
            
            objMenu.XMLMenuFile = ms;
            objMenu.objForm = this;
            objMenuStrip = objMenu.LoadDynamicMenu();
            
            this.Controls.Add(objMenuStrip);

       
        }


        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
           
            DialogResult dialogResult = RadMessageBox.Show("Are you sure you want to close the application?", "Close Application", MessageBoxButtons.YesNo, RadMessageIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                Dispose(true);
                Application.Exit();
            }
            else
            {
                e.Cancel = true;
            }
        }
       
     

    }

    public class CustomLocalizationProvider : RadGridLocalizationProvider
    {
        public override string GetLocalizedString(string id)
        {
            switch (id)
            {
                case RadGridStringId.AddNewRowString: return string.Empty;
            }

            return base.GetLocalizedString(id);
        }
    }
   
    public class AddReceiptGridBehavior : BaseGridBehavior
    {
        public override bool ProcessKeyDown(KeyEventArgs keys)
        {
            if (this.GridControl.IsInEditMode)
            {
                if (keys.KeyData == Keys.Enter)
                {
                    this.GridControl.GridNavigator.SelectNextRow(1);
                    this.GridControl.GridNavigator.SelectLastColumn();
                }
                else if (keys.KeyData == Keys.Enter)
                {
                    this.GridControl.GridNavigator.SelectNextRow(1);
                    this.GridControl.GridNavigator.SelectFirstColumn();
                }
                else
                {

                }
            }
            
            return true;
        }
    }
}
