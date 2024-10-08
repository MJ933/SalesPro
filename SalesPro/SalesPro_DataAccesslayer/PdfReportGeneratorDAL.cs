using System;
using System.Data;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace SalesPro_DataAccesslayer
{
    public class PdfReportGeneratorDAL
    {
        public static void GeneratePdfReport(DataTable dataTable, string filePath,
                                            float marginLeft = 20, float marginRight = 20,
                                            float marginTop = 30, float marginBottom = 30,
                                            string backgroundImagePath = null,
                                            float clippingShapeX = 0, float clippingShapeY = 0,
                                            float clippingShapeWidth = 0, float clippingShapeHeight = 0,
                                            string fontPath = null, string fontName = null,
                                            bool addPageNumbers = false,
                                            string headerText = null, string footerText = null)
        {
            try
            {
                using (Document document = new Document())
                {
                    using (PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create)))
                    {
                        // Set page event handler for headers and footers
                        writer.PageEvent = new PdfPageEventHandler(headerText, footerText, addPageNumbers);

                        document.SetMargins(marginLeft, marginRight, marginTop, marginBottom);
                        document.Open();

                        AddBackgroundImage(document, backgroundImagePath);
                        ApplyClippingShape(writer, clippingShapeX, clippingShapeY, clippingShapeWidth, clippingShapeHeight);
                        SetCustomFont(document, fontPath, fontName);
                        AddTableToDocument(document, dataTable);

                        document.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error generating PDF report: " + ex.Message);
            }
        }

        private static void AddBackgroundImage(Document document, string backgroundImagePath)
        {
            if (!string.IsNullOrEmpty(backgroundImagePath) && File.Exists(backgroundImagePath))
            {
                Image background = Image.GetInstance(backgroundImagePath);
                background.SetAbsolutePosition(0, 0);
                document.Add(background);
            }
        }

        private static void ApplyClippingShape(PdfWriter writer, float clippingShapeX, float clippingShapeY, float clippingShapeWidth, float clippingShapeHeight)
        {
            if (clippingShapeWidth > 0 && clippingShapeHeight > 0)
            {
                PdfContentByte cb = writer.DirectContent;
                cb.Rectangle(clippingShapeX, clippingShapeY, clippingShapeWidth, clippingShapeHeight);
                cb.Clip();
                cb.NewPath();
            }
        }

        private static void SetCustomFont(Document document, string fontPath, string fontName)
        {
            if (!string.IsNullOrEmpty(fontPath) && !string.IsNullOrEmpty(fontName))
            {
                BaseFont bf = BaseFont.CreateFont(fontPath, BaseFont.IDENTITY_H, BaseFont.EMBEDDED);
                Font font = new Font(bf, 12);
                document.Add(new Paragraph("Custom Font Example", font));
            }
        }

        private static void AddTableToDocument(Document document, DataTable dataTable)
        {
            PdfPTable table = new PdfPTable(dataTable.Columns.Count);
            table.WidthPercentage = 100;

            AddHeaderRow(table, dataTable);
            AddDataRows(table, dataTable);

            document.Add(table);
        }

        private static void AddHeaderRow(PdfPTable table, DataTable dataTable)
        {
            foreach (DataColumn column in dataTable.Columns)
            {
                PdfPCell cell = new PdfPCell(new Phrase(column.ColumnName));
                cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                table.AddCell(cell);
            }
        }

        private static void AddDataRows(PdfPTable table, DataTable dataTable)
        {
            bool isAltRow = false;
            foreach (DataRow row in dataTable.Rows)
            {
                foreach (DataColumn column in dataTable.Columns)
                {
                    PdfPCell cell = new PdfPCell(new Phrase(row[column].ToString()));
                    cell.BackgroundColor = isAltRow ? BaseColor.WHITE : BaseColor.LIGHT_GRAY;
                    cell.HorizontalAlignment = Element.ALIGN_CENTER;
                    table.AddCell(cell);
                }
                isAltRow = !isAltRow;
            }
        }
    }

    public class PdfPageEventHandler : PdfPageEventHelper
    {
        private string _headerText;
        private string _footerText;
        private bool _addPageNumbers;

        public PdfPageEventHandler(string headerText, string footerText, bool addPageNumbers)
        {
            _headerText = headerText;
            _footerText = footerText;
            _addPageNumbers = addPageNumbers;
        }

        public override void OnEndPage(PdfWriter writer, Document document)
        {
            base.OnEndPage(writer, document);

            PdfContentByte cb = writer.DirectContent;

            AddHeader(cb, document);
            AddFooter(cb, document);
            AddPageNumbers(cb, document, writer);
        }

        private void AddHeader(PdfContentByte cb, Document document)
        {
            if (!string.IsNullOrEmpty(_headerText))
            {
                ColumnText.ShowTextAligned(cb, Element.ALIGN_CENTER, new Phrase(_headerText),
                                           (document.PageSize.Width / 2) + document.LeftMargin,
                                           document.PageSize.Height - 30, 0);
            }
        }

        private void AddFooter(PdfContentByte cb, Document document)
        {
            if (!string.IsNullOrEmpty(_footerText))
            {
                ColumnText.ShowTextAligned(cb, Element.ALIGN_CENTER, new Phrase(_footerText),
                                           (document.PageSize.Width / 2) + document.LeftMargin,
                                           document.BottomMargin, 0);
            }
        }

        private void AddPageNumbers(PdfContentByte cb, Document document, PdfWriter writer)
        {
            if (_addPageNumbers)
            {
                ColumnText.ShowTextAligned(cb, Element.ALIGN_CENTER, new Phrase("Page " + writer.PageNumber),
                                           (document.PageSize.Width / 2) + document.LeftMargin,
                                           document.BottomMargin + 10, 0);
            }
        }
    }
}