using System.Drawing;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml.Style;
using System.IO;

namespace ExcelManager
{
    public static class ExcelWriter
    {
        private const int DefaultFontSize = 11;
        private const string DefaultOutputDirectory = "..\\..\\..\\..\\OutputFiles\\";

        private static ExcelWorksheet CreateSheet(ExcelPackage p, string sheetName)
        {
            p.Workbook.Worksheets.Add(sheetName);
            ExcelWorksheet ws = p.Workbook.Worksheets[1];
            ws.Name = sheetName;
            ws.Cells.Style.Font.Size = DefaultFontSize;
            ws.Cells.Style.Font.Name = "Calibri";

            return ws;
        }

        public static void CreateExcel2007PlusFile(List<Dictionary<string, string>> reports)
        {
            var outputDir = new DirectoryInfo(DefaultOutputDirectory);
            
            FileInfo newFile = CreateFile(outputDir, @"test.xlsx");
            
            using (ExcelPackage package = new ExcelPackage(newFile))
            {
                // add a new worksheet to the empty workbook
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Sales Report");
                //Add the headers
                worksheet.Cells[1, 1].Value = "Product Name";
                worksheet.Cells[1, 2].Value = "Category Name";
                worksheet.Cells[1, 3].Value = "From";
                worksheet.Cells[1, 4].Value = "To";
                worksheet.Cells[1, 5].Value = "Total Quantity Sold";
                worksheet.Cells[1, 6].Value = "Buying Price";
                worksheet.Cells[1, 7].Value = "Selling Price";

                for (int i = 0; i < reports.Count; i++)
                {
                    worksheet.Cells["A" + i + 2].Value = reports[i]["Product Name"];
                    worksheet.Cells["B" + i + 2].Value = reports[i]["Category Name"];
                    worksheet.Cells["C" + i + 2].Value = reports[i]["From"];
                    worksheet.Cells["D" + i + 2].Value = reports[i]["To"];
                    worksheet.Cells["E" + i + 2].Value = reports[i]["Total Quantity Sold"];
                    worksheet.Cells["F" + i + 2].Value = reports[i]["Buying Price"];
                    worksheet.Cells["G" + i + 2].Value = reports[i]["Selling Price"];
                }

               

                using (var range = worksheet.Cells[1, 1, 1, 5])
                {
                    range.Style.Font.Bold = true;
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(Color.DarkBlue);
                    range.Style.Font.Color.SetColor(Color.White);
                }

               //worksheet.Cells["A5:E5"].Style.Border.Top.Style = ExcelBorderStyle.Thin;
               //worksheet.Cells["A5:E5"].Style.Font.Bold = true;

                worksheet.Cells["A2:A4"].Style.Numberformat.Format = "@";   //Format as text
                worksheet.Cells.AutoFitColumns(0);  //Autofit columns for all cells

                // header text 
                worksheet.HeaderFooter.OddHeader.RightAlignedText = "&24&U&\"Arial,Regular Bold\" Sales Report";
                // add the page number to the footer plus the total number of pages
                worksheet.HeaderFooter.OddFooter.LeftAlignedText =
                    string.Format("Page {0} of {1}", ExcelHeaderFooter.PageNumber, ExcelHeaderFooter.NumberOfPages);
                // sheet name
                worksheet.HeaderFooter.OddFooter.CenteredText = ExcelHeaderFooter.SheetName;

                worksheet.PrinterSettings.RepeatRows = worksheet.Cells["1:2"];
                worksheet.PrinterSettings.RepeatColumns = worksheet.Cells["A:G"];

                // Change the sheet view to show it in page layout mode
                worksheet.View.PageLayoutView = true;

                package.Save();
            }
        }

        private static FileInfo CreateFile(DirectoryInfo outputDir, string fileName)
        {
            FileInfo newFile = new FileInfo(outputDir.FullName + fileName);

            if (newFile.Exists)
            {
                newFile.Delete();
                newFile = new FileInfo(outputDir.FullName + fileName);
            }

            return newFile;
        }
    }
}