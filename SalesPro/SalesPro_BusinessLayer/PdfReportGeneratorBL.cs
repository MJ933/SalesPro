using System;
using System.Data;
using System.IO;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using SalesPro_BusinessLayer;


namespace SalesPro_BusinessLayer
{
    public class InvoiceGenerator
    {
        public static void GenerateInvoice(clsInstallmentPaymentsBL installmentPayment, string filePath,
                                    string fontPath = null, string fontName = null)
        {
            try
            {
                // Create a new A4 size document with right-to-left writing mode
                using (Document document = new Document(PageSize.A4, 36, 36, 36, 36)) // margins: left, right, top, bottom
                {
                    using (PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(filePath, FileMode.Create)))
                    {
                        document.Open();

                        // Use a proper Arabic font
                        BaseFont bf = BaseFont.CreateFont(@"E:\SalesPro\IBMPlexSansArabic-Medium.ttf", BaseFont.IDENTITY_H, BaseFont.EMBEDDED);

                        AddInvoiceHeader(document, installmentPayment, bf);
                        AddInvoiceDetailsTable(document, installmentPayment, bf);

                        document.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error generating invoice PDF: " + ex.Message);
            }
        }
        private static void AddInvoiceHeader(Document document, clsInstallmentPaymentsBL installmentPayment, BaseFont bf)
        {
            // Create a table for the header to ensure right alignment
            PdfPTable headerTable = new PdfPTable(1);
            headerTable.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
            headerTable.WidthPercentage = 100;

            // Add company name
            PdfPCell companyNameCell = new PdfPCell(new Phrase("اسم الشركة", new Font(bf, 16, Font.BOLD)));
            companyNameCell.HorizontalAlignment = Element.ALIGN_LEFT;
            companyNameCell.Border = Rectangle.NO_BORDER;
            headerTable.AddCell(companyNameCell);

            // Add company address
            PdfPCell addressCell = new PdfPCell(new Phrase("عنوان الشركة", new Font(bf, 12)));
            addressCell.HorizontalAlignment = Element.ALIGN_LEFT;
            addressCell.Border = Rectangle.NO_BORDER;
            headerTable.AddCell(addressCell);

            // Add customer information
            string customerName = installmentPayment.InstallmentsInfo.SalesInvoiceItemsInfo.salesInvoicesInfo.customersInfo.PersonInfo.PersonName;
            PdfPCell customerCell = new PdfPCell(new Phrase($"اسم العميل: {customerName}", new Font(bf, 12)));
            customerCell.HorizontalAlignment = Element.ALIGN_LEFT;
            customerCell.Border = Rectangle.NO_BORDER;
            headerTable.AddCell(customerCell);

            // Add invoice number and date
            PdfPCell invoiceInfoCell = new PdfPCell(new Phrase(
        $"رقم الفاتورة: {installmentPayment.InstallmentID} - التاريخ: {installmentPayment.PaymentDate:dd/MM/yyyy} - الوقت: {installmentPayment.PaymentDate:hh:mm tt}",
        new Font(bf, 12)));
            invoiceInfoCell.HorizontalAlignment = Element.ALIGN_LEFT;
            invoiceInfoCell.Border = Rectangle.NO_BORDER;
            headerTable.AddCell(invoiceInfoCell);

            document.Add(headerTable);

            // Add some spacing
            document.Add(new Paragraph(" "));
        }

        private static void AddInvoiceDetailsTable(Document document, clsInstallmentPaymentsBL installmentPayment, BaseFont bf)
        {
            // In your AddInvoiceDetailsTable method:

            // ... (other code) ...

            // Example usage: Create a table for installment details
            string[] headers1 = new string[] { "الوصف", "المنتج", "الكمية", "المبلغ المستلم" };
            string[] rowData1 = new string[] {
        "دفعة قسط",
        installmentPayment.InstallmentsInfo.SalesInvoiceItemsInfo.productsInfo.ProductName,
        installmentPayment.InstallmentsInfo.SalesInvoiceItemsInfo.Quantity.ToString("N2"),
        installmentPayment.PaymentAmount.ToString("N2")}; // ... (your data) ...
            float[] columnWidths1 = new float[] { 30f, 20f, 20f, 30f };
            PdfPTable table1 = CreateTable(4, columnWidths1, headers1, rowData1, bf);
            document.Add(table1);

            document.Add(new Paragraph(" "));
            document.Add(new Paragraph(" ")); // Add more empty paragraphs for larger spacing
            document.Add(new Paragraph(" "));
            // ... (other code) ...

            // Example usage: Create another table for other details (e.g., shipping)
            string[] headers2 = new string[] { "المتبقي", "المبلغ الكلي", "By" };
            string[] rowData2 = new string[3]; // Create an array with 3 elements

            rowData2[0] = clsInstallmentsBL.GetOutstandingBalanceByInvoiceID(installmentPayment.InstallmentsInfo.SalesInvoiceID).ToString();
            rowData2[1] = installmentPayment.InstallmentsInfo.SalesInvoiceItemsInfo.salesInvoicesInfo.SalesInvoiceTotalAfterDiscount.ToString("N2"); // Format as needed
            rowData2[2] = installmentPayment.UserInfo.PersonInfo.PersonName;
            // ... (your data) ...
            float[] columnWidths2 = new float[] { 30f, 30f, 40f };
            PdfPTable table2 = CreateTable(3, columnWidths2, headers2, rowData2, bf);
            document.Add(table2);

            // ... (rest of your code) ... 
        }


        private static PdfPTable CreateTable(int numColumns, float[] columnWidths, string[] headers, string[] rowData, BaseFont bf)
        {
            PdfPTable table = new PdfPTable(numColumns);
            table.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
            table.WidthPercentage = 100;

            // Set column widths
            table.SetWidths(columnWidths);

            // Add table headers
            foreach (string header in headers)
            {
                PdfPCell cell = new PdfPCell(new Phrase(header, new Font(bf, 12, Font.BOLD)));
                cell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.BackgroundColor = BaseColor.LIGHT_GRAY;
                cell.Padding = 8;
                table.AddCell(cell);
            }

            // Add row data (handle empty values)
            for (int i = 0; i < numColumns; i++)
            {
                string data = (i < rowData.Length) ? rowData[i] : ""; // Use empty string if data is missing
                PdfPCell cell = new PdfPCell(new Phrase(data, new Font(bf, 12)));
                cell.RunDirection = PdfWriter.RUN_DIRECTION_RTL;
                cell.HorizontalAlignment = Element.ALIGN_CENTER;
                cell.Padding = 8;
                table.AddCell(cell);
            }

            return table;
        }
    }
}
