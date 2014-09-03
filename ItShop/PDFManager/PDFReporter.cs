namespace PDFManager
{
    using iTextSharp.text;
    using iTextSharp.text.pdf;
    using ItShop.Data;
    using ItShop.Model;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class PDFReporter
    {
        private const int GRAY_COLOR = 160;
        private const int WHITE_COLOR = 255;
       
        public PDFReporter(ItShopDbContext db)
        {
            this.dataBase = db;
        }

        public ItShopDbContext dataBase { get; set; }

        public void GeneratePdfSalesReport(string documentName, DateTime[] dates)

        {
            var headerFontStyle = PDFTextStyleController.SetFontStyle("Arial", 14, Font.BOLD);
            var productNamesFontStyle = PDFTextStyleController.SetFontStyle("Arial", 10, Font.BOLD);
            var cellsFontStyle = PDFTextStyleController.SetFontStyle("Arial", 8, Font.NORMAL);

            var document = CreatePdfDocument(documentName);
            document.Open();

            var table = CreatePdfTable(5, new int[] { 4, 2, 3, 5, 2 });

            var documentHeader = CreatePdfCell("Aggregated Sales Report", headerFontStyle, PDFTextStyleController.Color(WHITE_COLOR, WHITE_COLOR, WHITE_COLOR), 5, 1);
            var productHeaderCell = CreatePdfCell("Product", productNamesFontStyle, PDFTextStyleController.Color(GRAY_COLOR, GRAY_COLOR, GRAY_COLOR));
            var qualtityHeaderCell = CreatePdfCell("Quantity", productNamesFontStyle, PDFTextStyleController.Color(GRAY_COLOR, GRAY_COLOR, GRAY_COLOR));
            var unitPriceHeaderCell = CreatePdfCell("Unit Price", productNamesFontStyle, PDFTextStyleController.Color(GRAY_COLOR, GRAY_COLOR, GRAY_COLOR));
            var addressLocationCell = CreatePdfCell("Location", productNamesFontStyle, PDFTextStyleController.Color(GRAY_COLOR, GRAY_COLOR, GRAY_COLOR));
            var sumCell = CreatePdfCell("Sum", productNamesFontStyle, PDFTextStyleController.Color(GRAY_COLOR, GRAY_COLOR, GRAY_COLOR));

            table.AddCell(documentHeader);

            for (int i = 0; i < dates.Length; i++)
            {
                var totalSumCellDateInfo = CreatePdfCell(String.Format("Total sum for {0:d}", dates[i]), productNamesFontStyle, PDFTextStyleController.Color(WHITE_COLOR, WHITE_COLOR, WHITE_COLOR), 4, 2);
                var allSaleDetails = this.SaleDetailsByDate(dates[i], this.dataBase);
                //adding cells to table

                table.AddCell(productHeaderCell);
                table.AddCell(qualtityHeaderCell);
                table.AddCell(unitPriceHeaderCell);
                table.AddCell(addressLocationCell);
                table.AddCell(sumCell);
                decimal totalSumOfSoldProducts = this.FillPdfTableWithData(allSaleDetails, table, cellsFontStyle);//extract in another method sum
                var totalSum = CreatePdfCell(totalSumOfSoldProducts.ToString(), productNamesFontStyle, PDFTextStyleController.Color(WHITE_COLOR, WHITE_COLOR, WHITE_COLOR));
                table.AddCell(totalSumCellDateInfo);
                table.AddCell(totalSum);

            }
           
            document.Add(table);
            document.Close();
        }

        private decimal FillPdfTableWithData(ICollection<SaleDetail> saleDetails, PdfPTable table, Font cellsFontStyle)
        {
            decimal productsSum = 0;

            foreach (var saleDetail in saleDetails)
            {
               

                string locationFromDataBase = ExtractStoreNameAndLocationFromSaleDetail(saleDetail);// mb to use sales

                string currentProduct = saleDetail.Product.ProductName;
                int productQuantity = saleDetail.Quantity;
                decimal unitPrice = saleDetail.SalePrice;
                string location = locationFromDataBase;
                decimal Sum = (decimal)productQuantity * unitPrice;

                productsSum += Sum;//extract in another method

                var currentProductCell = CreatePdfCell(currentProduct, cellsFontStyle, PDFTextStyleController.Color(WHITE_COLOR, WHITE_COLOR, WHITE_COLOR));
                var currentQuantityCell = CreatePdfCell(productQuantity.ToString(), cellsFontStyle, PDFTextStyleController.Color(WHITE_COLOR, WHITE_COLOR, WHITE_COLOR));
                var currentUnitPriceCell = CreatePdfCell(unitPrice.ToString(), cellsFontStyle, PDFTextStyleController.Color(WHITE_COLOR, WHITE_COLOR, WHITE_COLOR));
                var currentLocationCell = CreatePdfCell(location, cellsFontStyle, PDFTextStyleController.Color(WHITE_COLOR, WHITE_COLOR, WHITE_COLOR));
                var currentSumCell = CreatePdfCell(Sum.ToString(), cellsFontStyle, PDFTextStyleController.Color(WHITE_COLOR, WHITE_COLOR, WHITE_COLOR));

                table.AddCell(currentProductCell);
                table.AddCell(currentQuantityCell);
                table.AddCell(currentUnitPriceCell);
                table.AddCell(currentLocationCell);
                table.AddCell(currentSumCell);
            }

            return productsSum;
        }


        private string ExtractStoreNameAndLocationFromSaleDetail(SaleDetail saleDetail)
        {
            var saleToFindTheTown = dataBase.Sales.FirstOrDefault(sale => sale.SaleId == saleDetail.SaleId).StoreId;
            var addressId = dataBase.Stores.FirstOrDefault(shop => shop.StoreId == saleToFindTheTown).AddressId;
            var storeName = dataBase.Stores.FirstOrDefault(shop => shop.StoreId == saleToFindTheTown).StoreName;
            var address = dataBase.Addresses.FirstOrDefault(shop => shop.AddressId == addressId).AddressName;

            return storeName + "-" + address;  
        }


        private Document CreatePdfDocument(string documentName)
        {
            // Create a Document object
            var document = new Document(PageSize.A4, 50, 50, 25, 25);

            // Create a new PdfWriter object, specifying the output stream
            var output = new FileStream(documentName + ".pdf", FileMode.Create);
            var writer = PdfWriter.GetInstance(document, output);

            return document;
        }

        private PdfPTable CreatePdfTable(int tableCols, int[] parameters)
        {
            var infoTable = new PdfPTable(tableCols);

            infoTable.HorizontalAlignment = 1;
            infoTable.SpacingBefore = 10;
            infoTable.SpacingAfter = 10;
            infoTable.DefaultCell.Border = 1;
            infoTable.SetWidths(parameters);

            return infoTable;
        }

        private PdfPCell CreatePdfCell(string cellInfo, Font font, BaseColor backgroundColor, int colSpan = 0, int horizontalAligment = 0)
        {
            var cell = new PdfPCell(new Phrase(cellInfo, font));
            cell.BackgroundColor = backgroundColor;
            cell.Colspan = colSpan;
            cell.HorizontalAlignment = horizontalAligment;
            return cell;
        }

        //to extract in databaseSearch module
        private ICollection<SaleDetail> SaleDetailsByDate(DateTime date, ItShopDbContext dataBase)
        {
            IList<SaleDetail> sales = new List<SaleDetail>();
            var database = new ItShopDbContext();
            var salesFromDate = database.SaleDetails.Where(sale => sale.Sale.SaleDate == date);

            sales = salesFromDate.ToList();

            return sales;
        }

        private  ICollection<SaleDetail> SaleDetailsFromSales(Sale sale)
        {
            ICollection<SaleDetail> saleReports = sale.SaleDetails;

            return saleReports;
        }

        private Product GetProductThatMatchesWithSaleDetailId(SaleDetail saleDetail)
        {
            Product product = saleDetail.Product;
            return product;
        }

        private Address GetStoreAddressFromSaleDetail(Sale sale)
        {
            return sale.Store.Address;
        }
    }
}
