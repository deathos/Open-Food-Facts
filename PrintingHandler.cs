using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Honeywell.Printer;

namespace Open_Food_Facts
{
    public static class PrintingHandler
    {
        private static readonly int DrawingWidth = Variables.drawing.Width;
        private static readonly int DrawingHeight = Variables.drawing.Height;
        public static void PrintProduct()
        {
            try
            {

                Variables.drawing.Clear();
                Variables.drawing += new Drawing.Image(10 , 10 , "/home/user/images/Nutella.bmp");
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
