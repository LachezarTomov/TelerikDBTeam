using iTextSharp.text;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFManager
{
    public static class PDFTextStyleController
    {
        public static Font SetFontStyle(string fontFamily, int fontSize, int fontWeigth)
        {
            return FontFactory.GetFont(fontFamily, fontSize, fontWeigth);
        }

        public static BaseColor Color(int red, int green, int blue)
        {
            return new BaseColor(red, green, blue);
        }
    }
}
