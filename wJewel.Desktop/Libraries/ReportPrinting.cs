using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using Telerik.WinControls;
using Telerik.WinControls.UI;
using Microsoft.Reporting.WinForms;
using System.Xml;
using System.Reflection;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Drawing;
using IshalInc.wJewel.Desktop.Forms;

namespace IshalInc.wJewel.Desktop.Libraries
{
    public class ReportPrinting : IDisposable
    {

        private int m_currentPageIndex;
        private IList<Stream> m_streams;

        IshalInc.wJewel.Desktop.Forms.frmReportViewer form = new IshalInc.wJewel.Desktop.Forms.frmReportViewer();
        public Microsoft.Reporting.WinForms.ReportViewer reportViewer = new Microsoft.Reporting.WinForms.ReportViewer();
        public LocalReport report;
        // Create a local report for Report.rdlc, load the data,
        //    export the report to an .emf file, and print it.

        public ReportPrinting()
        {
            report = new LocalReport();
           
        }

        public void PrintReport(Stream reportStream, string printerName, Microsoft.Reporting.WinForms.ReportParameter[] reportParameterCollection, Microsoft.Reporting.WinForms.ReportDataSource[] mainReportDataSource)
        {

          
            report.LoadReportDefinition(reportStream);
            report.EnableExternalImages = true;
            foreach (Microsoft.Reporting.WinForms.ReportDataSource rdSource in mainReportDataSource)
                report.DataSources.Add(rdSource);

            if (reportParameterCollection != null)
                report.SetParameters(reportParameterCollection);

            
            Export(report);
            m_currentPageIndex = 0;
            Print(printerName);
        }

        // Create a local report for Report.rdlc, load the data,
        //    export the report to an .emf file, and print it.
        public void PrintReport(string ReportName, Microsoft.Reporting.WinForms.ReportParameter[] reportParameterCollection, Microsoft.Reporting.WinForms.ReportDataSource[] mainReportDataSource)
        {
          
            report.EnableExternalImages = true;
            TextReader reportTextReader = GetCustomizedReportDefinition(ReportName);
            report.LoadReportDefinition(reportTextReader);

            foreach (Microsoft.Reporting.WinForms.ReportDataSource rdSource in mainReportDataSource)
                report.DataSources.Add(rdSource);

            if (reportParameterCollection != null)
                report.SetParameters(reportParameterCollection);

            

            Export(report);
            m_currentPageIndex = 0;
            Print();
        }



        public void PrintReport(string reportTitle, string ReportName, Microsoft.Reporting.WinForms.ReportParameter[] reportParameterCollection, Microsoft.Reporting.WinForms.ReportDataSource[] mainReportDataSource, string DisplayName)
        {
            try
            {
                report = reportViewer.LocalReport;
                form.Text = reportTitle;

                TextReader tr;
                tr = GetCustomizedReportDefinition(ReportName);
                //reportViewer.Load +=new EventHandler(reportViewer_Load);
                reportViewer.RenderingComplete += new Microsoft.Reporting.WinForms.RenderingCompleteEventHandler(reportViewer_RenderingComplete);
                report.LoadReportDefinition(tr); ;
                report.DataSources.Clear();
                report.DisplayName = DisplayName;
                report.EnableExternalImages = true;

            
                foreach (Microsoft.Reporting.WinForms.ReportDataSource rdSource in mainReportDataSource)
                    report.DataSources.Add(rdSource);

                if (reportParameterCollection != null)
                    report.SetParameters(reportParameterCollection);

               

                reportViewer.Width = form.Width - 10;
                reportViewer.Height = form.Height - 10;
                form.Visible = false;
                form.AutoScroll = true;
                form.Refresh();
                form.Controls.Clear();
                form.Controls.Add(reportViewer);
                reportViewer.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
                reportViewer.RefreshReport();
                form.ShowDialog();
                Application.DoEvents();
                form.Refresh();
            }
            catch (Exception exp)
            {
                Helper.MsgBox(exp.Message, RadMessageIcon.Error);
            }
        }

        public void PrintReport(string reportTitle, Stream reportStream, Microsoft.Reporting.WinForms.ReportParameter[] reportParameterCollection, Microsoft.Reporting.WinForms.ReportDataSource[] mainReportDataSource, string DisplayName)
        {
            try
            {

                report = reportViewer.LocalReport;
                form.Text = reportTitle;

                TextReader tr;
                tr = GetCustomizedReportDefinition(reportStream);
                //reportViewer.Load +=new EventHandler(reportViewer_Load);


                reportViewer.RenderingComplete += new Microsoft.Reporting.WinForms.RenderingCompleteEventHandler(reportViewer_RenderingComplete);
                report.LoadReportDefinition(tr);
                report.DataSources.Clear();
                report.DisplayName = DisplayName;
                report.EnableExternalImages = true;
                foreach (Microsoft.Reporting.WinForms.ReportDataSource rdSource in mainReportDataSource)
                    report.DataSources.Add(rdSource);

                if (reportParameterCollection != null)
                    report.SetParameters(reportParameterCollection);

               
                reportViewer.Width = form.Width - 10;
                reportViewer.Height = form.Height - 10;

                form.Visible = false;
                form.Refresh();
                form.Controls.Clear();
                form.Controls.Add(reportViewer);
                reportViewer.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;

                reportViewer.RefreshReport();
                form.ShowDialog();
                Application.DoEvents();
                form.Refresh();
            }
            catch (Exception exp)
            {
                Helper.MsgBox(exp.Message, RadMessageIcon.Error);
            }
        }

        // Create a local report for Report.rdlc, load the data,
        //    export the report to an .emf file, and print it.
        public bool SendasEmail(string ReportName, Microsoft.Reporting.WinForms.ReportParameter[] reportParameterCollection, Microsoft.Reporting.WinForms.ReportDataSource[] mainReportDataSource, string toEmail, string EmailTitle)
        {

           
            report.EnableExternalImages = true;
            TextReader reportTextReader = GetCustomizedReportDefinition(ReportName);
            report.LoadReportDefinition(reportTextReader);

            foreach (Microsoft.Reporting.WinForms.ReportDataSource rdSource in mainReportDataSource)
                report.DataSources.Add(rdSource);

            if (reportParameterCollection != null)
                report.SetParameters(reportParameterCollection);

          

            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string extension;

            byte[] bytes = report.Render("PDF", null, out mimeType,
                    out encoding, out extension, out streamids, out warnings);
            MemoryStream s = new MemoryStream(bytes);
            s.Seek(0, SeekOrigin.Begin);

            bool emailStatus = true;
            frmEmailReport objEmail = new frmEmailReport(toEmail, EmailTitle, s);
            objEmail.StartPosition = FormStartPosition.CenterScreen;
            // objEmail.MdiParent = calledFrom.MdiParent; ;
            objEmail.ShowDialog();
            return objEmail.DialogResult == DialogResult.OK;



        }

     
        public void PrintReport(Stream reportStream, string printerName, Microsoft.Reporting.WinForms.ReportParameter[] reportParameterCollection, Microsoft.Reporting.WinForms.ReportDataSource[] mainReportDataSource, string subReportName, string subReportIdName)
        {
           
           
            report.LoadReportDefinition(reportStream);
            report.EnableExternalImages = true;
            foreach (Microsoft.Reporting.WinForms.ReportDataSource rdSource in mainReportDataSource)
                report.DataSources.Add(rdSource);

            if (reportParameterCollection != null)
                report.SetParameters(reportParameterCollection);

          
            report.SubreportProcessing += new SubreportProcessingEventHandler(localReport_SubreportProcessing);


            Export(report);
            m_currentPageIndex = 0;
            Print(printerName);
        }

        // Create a local report for Report.rdlc, load the data,
        //    export the report to an .emf file, and print it.
        public void PrintReport(string ReportName, Microsoft.Reporting.WinForms.ReportParameter[] reportParameterCollection, Microsoft.Reporting.WinForms.ReportDataSource[] mainReportDataSource, string subReportName, string subReportIdName)
        {
            report = reportViewer.LocalReport;
            report.EnableExternalImages = true;
            TextReader reportTextReader = GetCustomizedReportDefinition(ReportName);
            report.LoadReportDefinition(reportTextReader);

            foreach (Microsoft.Reporting.WinForms.ReportDataSource rdSource in mainReportDataSource)
                report.DataSources.Add(rdSource);

            if (reportParameterCollection != null)
                report.SetParameters(reportParameterCollection);

            reportTextReader = GetCustomizedReportDefinition(subReportName);
            report.LoadSubreportDefinition(subReportIdName, reportTextReader);

            
            report.SubreportProcessing += new SubreportProcessingEventHandler(localReport_SubreportProcessing);

            Export(report);
            m_currentPageIndex = 0;
            Print();
        }

        

        public void PrintReport(string reportTitle, string ReportName, Microsoft.Reporting.WinForms.ReportParameter[] reportParameterCollection, Microsoft.Reporting.WinForms.ReportDataSource[] mainReportDataSource, string DisplayName, string subReportName, string subReportIdName)
        {
            try
            {
                report = reportViewer.LocalReport;
                form.Text = reportTitle;

                TextReader tr;
                tr = GetCustomizedReportDefinition(ReportName);
                //reportViewer.Load +=new EventHandler(reportViewer_Load);
                reportViewer.RenderingComplete += new Microsoft.Reporting.WinForms.RenderingCompleteEventHandler(reportViewer_RenderingComplete);
                report.LoadReportDefinition(tr);;
                report.DataSources.Clear();
                report.DisplayName = DisplayName;
                report.EnableExternalImages = true;

                tr = GetCustomizedReportDefinition(subReportName);
                report.LoadSubreportDefinition(subReportIdName,tr);

                foreach (Microsoft.Reporting.WinForms.ReportDataSource rdSource in mainReportDataSource)
                    report.DataSources.Add(rdSource);

              if (reportParameterCollection != null)
                    report.SetParameters(reportParameterCollection);

              
              
                report.SubreportProcessing += new SubreportProcessingEventHandler(localReport_SubreportProcessing);
                
                reportViewer.Width = form.Width - 10;
                reportViewer.Height = form.Height -10;
                form.Visible = false;
                form.AutoScroll = true;
                form.Refresh();
                form.Controls.Clear();
                form.Controls.Add(reportViewer);
                reportViewer.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;
                reportViewer.RefreshReport();
                form.ShowDialog();
                Application.DoEvents();
                form.Refresh();
            }
            catch (Exception exp)
            {
                Helper.MsgBox(exp.Message, RadMessageIcon.Error);
            }
        }

        public void PrintReport(string reportTitle, Stream reportStream, Microsoft.Reporting.WinForms.ReportParameter[] reportParameterCollection, Microsoft.Reporting.WinForms.ReportDataSource[] mainReportDataSource, string DisplayName, string subReportName, string subReportIdName, Microsoft.Reporting.WinForms.ReportDataSource[] subReportDataSource)
        {
            try
            {

                report = reportViewer.LocalReport;
                form.Text = reportTitle;

                TextReader tr;
                tr = GetCustomizedReportDefinition(reportStream);
                //reportViewer.Load +=new EventHandler(reportViewer_Load);


                reportViewer.RenderingComplete += new Microsoft.Reporting.WinForms.RenderingCompleteEventHandler(reportViewer_RenderingComplete);
                report.LoadReportDefinition(tr);
                report.DataSources.Clear();
                report.DisplayName = DisplayName;
                report.EnableExternalImages = true;
                foreach (Microsoft.Reporting.WinForms.ReportDataSource rdSource in mainReportDataSource)
                    report.DataSources.Add(rdSource);

                if (reportParameterCollection != null)
                    report.SetParameters(reportParameterCollection);

                tr = GetCustomizedReportDefinition(subReportName);
                report.LoadSubreportDefinition(subReportIdName, tr);

               
                report.SubreportProcessing += new SubreportProcessingEventHandler(localReport_SubreportProcessing);

                reportViewer.Width = form.Width - 10;
                reportViewer.Height = form.Height - 10;

                form.Visible = false;
                form.Refresh();
                form.Controls.Clear();
                form.Controls.Add(reportViewer);
                reportViewer.ProcessingMode = Microsoft.Reporting.WinForms.ProcessingMode.Local;

                reportViewer.RefreshReport();
                form.ShowDialog();
                Application.DoEvents();
                form.Refresh();
            }
            catch (Exception exp)
            {
                Helper.MsgBox(exp.Message, RadMessageIcon.Error);
            }
        }

        // Create a local report for Report.rdlc, load the data,
        //    export the report to an .emf file, and print it.
        public bool SendasEmail(string ReportName, Microsoft.Reporting.WinForms.ReportParameter[] reportParameterCollection, Microsoft.Reporting.WinForms.ReportDataSource[] mainReportDataSource, string toEmail, string EmailTitle, string subReportName, string subReportIdName)
        {

            
            report.EnableExternalImages = true;
            TextReader reportTextReader = GetCustomizedReportDefinition(ReportName);
            report.LoadReportDefinition(reportTextReader);

            foreach (Microsoft.Reporting.WinForms.ReportDataSource rdSource in mainReportDataSource)
                report.DataSources.Add(rdSource);

            if (reportParameterCollection != null)
                report.SetParameters(reportParameterCollection);

            reportTextReader = GetCustomizedReportDefinition(subReportName);
            report.LoadSubreportDefinition(subReportIdName, reportTextReader);

            report.SubreportProcessing += new SubreportProcessingEventHandler(localReport_SubreportProcessing);

          
            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string extension;

            byte[] bytes = report.Render("PDF", null, out mimeType,
                    out encoding, out extension, out streamids, out warnings);
            MemoryStream s = new MemoryStream(bytes);
            s.Seek(0, SeekOrigin.Begin);

            bool emailStatus = true;
            frmEmailReport objEmail = new frmEmailReport(toEmail, EmailTitle, s);
            objEmail.StartPosition = FormStartPosition.CenterScreen;
            // objEmail.MdiParent = calledFrom.MdiParent; ;
            objEmail.ShowDialog();
            return objEmail.DialogResult == DialogResult.OK;



        }


        private void localReport_SubreportProcessing(object sender, SubreportProcessingEventArgs e)
        {

            
        }

        private void reportViewer_RenderingComplete(object sender, RenderingCompleteEventArgs e)
        {
            //reportViewer.SetDisplayMode(DisplayMode.PrintLayout);
           //reportViewer.ZoomMode = ZoomMode.PageWidth;

        }


        // Routine to provide to the report renderer, in order to
        //    save an image for each page of the report.
        private Stream CreateStream(string name,
          string fileNameExtension, Encoding encoding,
          string mimeType, bool willSeek)
        {
            Stream stream = new MemoryStream();
            m_streams.Add(stream);
            return stream;

        }


        // Export the given report as an EMF (Enhanced Metafile) file.
        private void Export(LocalReport report)
        {
            string deviceInfo =
            @"<DeviceInfo>
                <OutputFormat>EMF</OutputFormat>
                <PageWidth>8.5in</PageWidth>
                <PageHeight>11in</PageHeight>
                <MarginTop>0.2in</MarginTop>
                <MarginLeft>0.3in</MarginLeft>
                <MarginRight>0.1in</MarginRight>
                <MarginBottom>0.2in</MarginBottom>
            </DeviceInfo>";
            Warning[] warnings;
            m_streams = new List<Stream>();
            report.Render("Image", deviceInfo, CreateStream,
               out warnings);
            foreach (Stream stream in m_streams)
                stream.Position = 0;

        }
        // Handler for PrintPageEvents
        private void PrintPage(object sender, PrintPageEventArgs ev)
        {
            Metafile pageImage = new
             Metafile(m_streams[m_currentPageIndex]);

            // Adjust rectangular area with printer margins.
            Rectangle adjustedRect = new Rectangle(
                ev.PageBounds.Left - (int)ev.PageSettings.HardMarginX,
                ev.PageBounds.Top - (int)ev.PageSettings.HardMarginY,
                ev.PageBounds.Width,
                ev.PageBounds.Height);

            // Draw a white background for the report
            ev.Graphics.FillRectangle(Brushes.White, adjustedRect);

            // Draw the report content
            ev.Graphics.DrawImage(pageImage, adjustedRect);

            // Prepare for the next page. Make sure we haven't hit the end.
            m_currentPageIndex++;
            ev.HasMorePages = (m_currentPageIndex < m_streams.Count);

        }

        private void Print(string printerName)
        {
            if (m_streams == null || m_streams.Count == 0)
                throw new Exception("Error: no stream to print.");
            PrintDocument printDoc = new PrintDocument();
            if (!printDoc.PrinterSettings.IsValid)
            {
                throw new Exception("Error: cannot find the default printer.");
            }
            else
            {
                printDoc.PrinterSettings.PrinterName = printerName;

                printDoc.PrintPage += new PrintPageEventHandler(PrintPage);
                m_currentPageIndex = 0;
                printDoc.Print();
            }

        }


        private void Print()
        {
            if (m_streams == null || m_streams.Count == 0)
                throw new Exception("Error: no stream to print.");
            PrintDocument printDoc = new PrintDocument();
            if (!printDoc.PrinterSettings.IsValid)
            {
                throw new Exception("Error: cannot find the default printer.");
            }
            else
            {
                //printDoc.PrinterSettings.PrinterName = printerName;
                PrintDialog pdi = new PrintDialog();
                pdi.Document = printDoc;
                DialogResult dgResult = pdi.ShowDialog();
                pdi.PrinterSettings.Copies = 3;
                if (dgResult == DialogResult.OK)
                {
                   
                    printDoc.Print();
                }
                else
                {
                    MessageBox.Show("Print Cancelled");
                }

              
            }

        }


        private TextReader GetCustomizedReportDefinition(string rdlc)
        {
            XmlDocument doc = new XmlDocument();
            Assembly assem = System.Reflection.Assembly.GetExecutingAssembly();

            Stream stream = assem.GetManifestResourceStream(rdlc);
            doc.Load(stream);
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
            nsmgr.AddNamespace("nm", "http://schemas.microsoft.com/sqlserver/reporting/2008/01/reportdefinition");
            nsmgr.AddNamespace("rd", "http://schemas.microsoft.com/SQLServer/reporting/reportdesigner");
            TextReader reader = new StringReader(doc.OuterXml);
            return reader;
        }

        private TextReader GetCustomizedReportDefinition(Stream stream)
        {
            XmlDocument doc = new XmlDocument();

            doc.Load(stream);
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
            nsmgr.AddNamespace("nm", "http://schemas.microsoft.com/sqlserver/reporting/2005/01/reportdefinition");
            nsmgr.AddNamespace("rd", "http://schemas.microsoft.com/SQLServer/reporting/reportdesigner");
            TextReader reader = new StringReader(doc.OuterXml);
            return reader;
        }

        private XmlDocument ChangeXmlEncoding(XmlDocument xmlDoc, string newEncoding)
        {
            if (xmlDoc.FirstChild.NodeType == XmlNodeType.XmlDeclaration)
            {
                XmlDeclaration xmlDeclaration = (XmlDeclaration)xmlDoc.FirstChild;
                xmlDeclaration.Encoding = newEncoding;
            }
            return xmlDoc;
        }

        public void Dispose()
        {
            if (m_streams != null)
            {
                foreach (Stream stream in m_streams)
                    stream.Close();
                m_streams = null;
            }

            if (form != null)
            {
                form = null;
                form.Dispose();
            }
            if (reportViewer != null)
            {
                reportViewer.Dispose();
                reportViewer.Dispose();
            }
        }


    }
}
