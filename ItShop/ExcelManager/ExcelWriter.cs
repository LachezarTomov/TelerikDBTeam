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
        private const string DefaultOutputDirectory = "..\\..\\..\\";

        private static ExcelWorksheet CreateSheet(ExcelPackage p, string sheetName)
        {
            p.Workbook.Worksheets.Add(sheetName);
            ExcelWorksheet ws = p.Workbook.Worksheets[1];
            ws.Name = sheetName;
            ws.Cells.Style.Font.Size = DefaultFontSize;
            ws.Cells.Style.Font.Name = "Calibri";

            return ws;
        }

        public static void CreateExcel2007PlusFile()
        {
            var outputDir = new DirectoryInfo(DefaultOutputDirectory);
            
            FileInfo newFile = CreateFile(outputDir, @"test.xlsx");
            
            using (ExcelPackage package = new ExcelPackage(newFile))
            {
                // add a new worksheet to the empty workbook
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Sales Report");
                //Add the headers
                worksheet.Cells[1, 1].Value = "Store Name";
                worksheet.Cells[1, 2].Value = "Total Sales";
                worksheet.Cells[1, 3].Value = "Marge";
                worksheet.Cells[1, 4].Value = "Best Selling Product";
                worksheet.Cells[1, 5].Value = "Most profitable Product";

                worksheet.Cells["A2"].Value = "Ninja";
                worksheet.Cells["B2"].Value = 12312;
                worksheet.Cells["C2"].Value = 123;
                worksheet.Cells["D2"].Value = "laptop";
                worksheet.Cells["D2"].Value = "high-end gaming desctop computer";

                using (var range = worksheet.Cells[1, 1, 1, 5])
                {
                    range.Style.Font.Bold = true;
                    range.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    range.Style.Fill.BackgroundColor.SetColor(Color.DarkBlue);
                    range.Style.Font.Color.SetColor(Color.White);
                }

                worksheet.Cells["A5:E5"].Style.Border.Top.Style = ExcelBorderStyle.Thin;
                worksheet.Cells["A5:E5"].Style.Font.Bold = true;

                worksheet.Cells["A2:A4"].Style.Numberformat.Format = "@";   //Format as text
                worksheet.Cells.AutoFitColumns(0);  //Autofit columns for all cells

                // header text 
                worksheet.HeaderFooter.OddHeader.CenteredText = "&24&U&\"Arial,Regular Bold\" Sales Report";
                // add the page number to the footer plus the total number of pages
                worksheet.HeaderFooter.OddFooter.RightAlignedText =
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