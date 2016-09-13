using System;
using System.Windows.Forms;
using System.Drawing;
using System.Xml;
using System.IO;
using System.Reflection;
using IshalInc.wJewel.Desktop.Properties;
using IshalInc.wJewel.Desktop.Forms;
using Telerik.WinControls.UI;

namespace IshalInc.wJewel.Desktop.Libraries
{
    class DynamicMenu
    {

       
        
        ///'''''''''''''''''''variable declarations begins''''''''''''''''''''''''''''
        //Create a main menu object.
        private RadMenu mainMenu = new RadMenu();
        //Object for loading XML File
        private XmlDocument objXML;
        // Create menu item objects.
        private RadMenuItem mItem = new RadMenuItem();

        //Menu handle that should be returned
        //private MenuStrip objMenu;
        //Path of the XML Menu Configuration File
        public MemoryStream XMLMenuFile;
        //Form Object in which Menu has to be build
        public object objForm;
        ///'''''''''''''''''''variable declarations ends '''''''''''''''''''''''''''''

        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        //This method will get invoked by a parent Form.
        //And it returns Menu Object.
        ///'''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''
        ///

        public DynamicMenu()
        {

        }
        public RadMenu LoadDynamicMenu()
        {

            System.Xml.XmlElement oXmlElement;

            objXML = new XmlDocument();
            //load the XML File
            objXML.Load(XMLMenuFile);
            //Get the documentelement of the XML file.
            oXmlElement = (XmlElement)objXML.DocumentElement;
            //loop through the each Top level nodes
            //For ex., File & Edit becomes Top Level nodes
            //And File -> Open , File ->Save will be treated as
            //child for the Top Level Nodes
            foreach (XmlNode node in objXML.FirstChild.ChildNodes)
            {
                string onClick = string.Empty;
                RadMenuItem menuItem = new RadMenuItem();

                menuItem.Name = node.Attributes["Name"].Value;
               
                menuItem.Text = node.Attributes["Text"].Value;
                //menuItem.Text = node.Attributes["Text"].Value;

                if ((node.Attributes["image"] != null) && (node.Attributes["image"].ToString() != string.Empty))
                    menuItem.Image = (Image)Resources.ResourceManager.GetObject(node.Attributes["image"].Value);

                if (node.Attributes["OnClick"] != null)
                {
                    menuItem.Tag = node.Attributes["OnClick"].Value;
                    menuItem.Click += new EventHandler(this.RunMenu);

                }

                mainMenu.Items.Add(menuItem);

                GenerateMenusFromXML(node, (RadMenuItem)mainMenu.Items[mainMenu.Items.Count - 1]);

            }

            return mainMenu;
        }

        private void GenerateMenusFromXML(XmlNode rootNode, RadMenuItem menuItem)
        {
            RadMenuItem item = null;
            RadMenuSeparatorItem separator = null;

            foreach (XmlNode node in rootNode.ChildNodes)
            {
                if (node.Attributes["Text"].Value == "-")
                {
                    menuItem.Items.Add(new RadMenuSeparatorItem());
                }
                else
                {
                    string onClick = string.Empty;
                    item = new RadMenuItem();
                    item.Name = node.Attributes["Name"].Value;
                    item.Text = node.Attributes["Text"].Value;
                    //item.Text = node.Attributes["Text"].Value;
                    if ((node.Attributes["image"] != null) && (node.Attributes["image"].ToString() != string.Empty))
                        item.Image = (Image)Resources.ResourceManager.GetObject(node.Attributes["image"].Value);

                    if (node.Attributes["OnClick"] != null)
                    {
                        item.Tag = node.Attributes["OnClick"].Value;
                        item.Click += new EventHandler(this.RunMenu);

                    }

                   
                    menuItem.Items.Add(item);
                    GenerateMenusFromXML(node, (RadMenuItem)menuItem.DropDown.Items[menuItem.DropDown.Items.Count - 1]);
                }
            }
        }
        // ----------
        // RunMenu
        // ----------
        private void RunMenu(object sender, System.EventArgs e)
        {
            RadMenuItem oTS = (RadMenuItem)sender;

            string cCommandName = oTS.Tag.ToString();
            try
            {
                switch (cCommandName.Substring(0, 1))
                {
                    case "F":
                        Form frmForm = DynamicallyLoadedObject(cCommandName.Substring(2));
                        frmForm.MdiParent = (Form)objForm;
                        frmForm.StartPosition = FormStartPosition.CenterScreen;
                        frmForm.Show();
                        break;
                    case "R":
                        break;
                    case "P":
                        MenuProcedure(cCommandName.Substring(2));
                        break;
                }
            }
            catch (Exception ex)
            {
                //MessageBox(ex.Message);
            }
        }
        // -----------------------------
        // DynamicallyLoadedObject
        // -----------------------------
        private Form DynamicallyLoadedObject(string objectName) // ERROR: Unsupported modifier : In, Optional object[] args)
        {
            object returnObj = null;
            Type Type = Assembly.GetExecutingAssembly().GetType("IshalInc.wJewel.Desktop.Forms." + objectName);
            if (Type != null)
            {
                returnObj = Activator.CreateInstance(Type, null);
            }
            return (Form)returnObj;
        }
        // -----------------------------
        // MenuProcedure
        // -----------------------------
        private void MenuProcedure(string cProcName)
        {
            frmMain frmMain = (frmMain)objForm;
            switch (cProcName)
            {
                case "CloseApp":
                    // Exit Application

                    Application.Exit();
                    break;
              
            }
        }


    }
}
