using Honeywell.Printer;
using System;
using Point = Honeywell.Printer.Point;

namespace Open_Food_Facts
{
    static class PrinterKeypadHandler
    {
        public static void KeyHandler(Object _1, UI.Keypad.KeyEventArgs eventArgs)
        {

            switch (Variables.currentMenu) {
                case "region":
                    switch (eventArgs.KeyChar)
                    {
                        case (char)Variables.Key.Menu:
                            try
                            {
                                Console.WriteLine(Variables.drawing.Width+ "--" + Variables.drawing.Height);
                                Console.WriteLine(Variables.printControl.PrintheadResolution+"---"+ Variables.printControl.PrintheadWidth);
/*                                Variables.drawing.Clear();
                                Variables.drawing += new Drawing.Image(10, 10, "/home/user/images/1bit-nutriscore-a.png");
                                Drawing.Barcode barcode = new Drawing.Barcode(280, 30, "EAN13", "301762042200");
                                barcode.Height = 30;
                                barcode.Text.Enabled = true;
                                barcode.Text.FontName = "Arial";
                                barcode.Text.Alignment = Drawing.Alignment.CenterBottom;


                                Drawing.Image image = new Drawing.Image(5, 5, "/home/user/images/nutella.bmp");

                                Variables.drawing += barcode;
                                Variables.printControl.PrintFeed(Variables.drawing, 1);*/
                                break;

                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e);
                                throw;
                            }
                            

                        case (char)Variables.Key.Left:
                            if (Variables.rectangle.Point.X > 14) 
                            {
                                Variables.rectangle.Point = new Point(Variables.rectangle.Point.X - 103, Variables.rectangle.Point.Y);
                            }
                            break;

                        case (char)Variables.Key.Right:

                            if (Variables.rectangle.Point.X < 220)
                            {
                                Variables.rectangle.Point = new Point(Variables.rectangle.Point.X + 103, Variables.rectangle.Point.Y);
                            }
                            break;
                        case (char)Variables.Key.Ok:
                            switch (Variables.rectangle.Point.X)
                            {
                                case 14:Variables.language = "en";
                                    UserInterfaceHandler.SetSearchScreen();
                                    break;
                                case 117:
                                    Variables.language = "ru";
                                    UserInterfaceHandler.SetSearchScreen();

                                    break;
                                case 220:
                                    Variables.language = "ar";
                                    UserInterfaceHandler.SetSearchScreen();
                                    break;
                            }

                            break;
                        case (char)Variables.Key.Down:

                            break;
                        case (char)Variables.Key.Feed:


                            break;
                        case (char)Variables.Key.Exit:
                            
                            break;
                    }
                    break;
                case "date":
                    break;
                case "search":
                    switch (eventArgs.KeyChar)
                    {
                        case (char)Variables.Key.Menu:

                            break;

                        case (char)Variables.Key.Left:
                            if (Variables.rectangle.Point.X > 0)
                            {
                                Variables.rectangle.Point = new Point(Variables.rectangle.Point.X - 100, Variables.rectangle.Point.Y);
                            }
                            break;

                        case (char)Variables.Key.Right:

                            if (Variables.rectangle.Point.X < 220)
                            {
                                Variables.rectangle.Point = new Point(Variables.rectangle.Point.X + 100, Variables.rectangle.Point.Y);
                            }
                            break;
                        case (char)Variables.Key.Ok:
                            switch (Variables.rectangle.Point.X)
                            {
                                case 6:
                                    //
                                    break;
                                case 106:
                                    //

                                    break;
                                case 206:
                                    UserInterfaceHandler.DisplayProduct();
                                    Console.WriteLine(Variables.drawing.Width + "-"+ Variables.drawing.Height);
                                    break;
                            }

                            break;
                        case (char)Variables.Key.Down:

                            break;
                        case (char)Variables.Key.Feed:


                            break;
                        case (char)Variables.Key.Exit:
                            UserInterfaceHandler.SetStartupLanguageMenu();
                            break;
                    }
                    break;
                case "product":
                    switch (eventArgs.KeyChar)
                    {
                        case (char)Variables.Key.Menu:

                            break;

                        case (char)Variables.Key.Left:

                            break;

                        case (char)Variables.Key.Right:

                            break;

                        case (char)Variables.Key.Up:

                            break;

                        case (char)Variables.Key.Down:

                            break;
                        case (char)Variables.Key.Feed:


                            break;
                        case (char)Variables.Key.Ok:
                            PrintingHandler.PrintProduct();

                            break;
                        case (char)Variables.Key.Exit:
                            UserInterfaceHandler.SetSearchScreen();

                            break;
                    }
                    break;
                case "general":
                    switch (eventArgs.KeyChar)
                    {
                        case (char)Variables.Key.Menu:

                            break;

                        case (char)Variables.Key.Left:

                            break;

                        case (char)Variables.Key.Right:

                            break;

                        case (char)Variables.Key.Up:

                            break;

                        case (char)Variables.Key.Down:

                            break;
                        case (char)Variables.Key.Feed:


                            break;
                        case (char)Variables.Key.Exit:
                            Console.WriteLine("Closing");
                            Variables.canvasTimer.Stop();
                            Variables.canvas.Exit();
                            break;
                    }
                    break;

            }
        }
    }
}
