using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using Honeywell.Printer;

namespace Open_Food_Facts
{
    public static class PrintingHandler
    {
        private static readonly int DrawingWidth = Variables.drawing.Width;
        private static readonly int DrawingHeight = Variables.drawing.Height;
        public static void PrintProduct(int index)
        {
            try
            {

                Variables.drawing.Clear();
                Variables.drawing += new Drawing.Image(2 , 0 , "/home/user/images/openfoodfacts/local/"+Variables.localDbProductsList[index].ImageSmallUrl+ "-1bit.png");
                Variables.drawing += new Drawing.Text(5, 240, "Arial", Variables.localDbProductsList[index].ProductName);
                Variables.drawing += new Drawing.Text(200, 80, "Arial", Variables.localDbProductsList[index].Quantity);
                Variables.drawing += new Drawing.Image(220, 120, "/home/user/images/openfoodfacts/1bit-nutriscore-" + Variables.localDbProductsList[index].NutriscoreGrade + ".png");
                Variables.drawing += new Drawing.Image(395, 0, "/home/user/images/openfoodfacts/1bit-nova-group-" + Variables.localDbProductsList[index].NovaGroup + ".png");
                String code = Variables.localDbProductsList[index].Code;
                Drawing.Barcode barc = new Drawing.Barcode(200,0,"");
                if (code.Length==13)
                {
                    barc.Data = code.Remove(code.Length - 1, 1);
                    barc.Type = "EAN13";
                    barc.Text.Enabled = true;
                    barc.Text.FontName = "Arial";
                    barc.Height = 50;
                    Variables.drawing += barc;
                }

                if (code.Length==8)
                {
                    barc.Data = code.Remove(code.Length - 1, 1);
                    barc.Type = "EAN8";
                    barc.Text.Enabled = true;
                    barc.Text.FontName = "Arial";
                    barc.Height = 50;
                    Variables.drawing += barc;
                }
                
                Variables.drawing.PartialRendering = true;
                Variables.printControl.PrintFeed(Variables.drawing, 1);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

        }
    }
}
