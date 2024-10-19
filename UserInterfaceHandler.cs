using System;
using Honeywell.Printer;
using Point = Honeywell.Printer.Point;
using Size = Honeywell.Printer.Size;

namespace Open_Food_Facts
{
     class UserInterfaceHandler
    {
        /*
         * Add Images to canvas
         * Add text to canvas
         * Remove object from canvas
         * Timer handeling
         */

        public static void SetStartupDateMenu()
        {
            Variables.canvas += new UI.Canvas.Image(0, 0, "/home/user/images/openfoodfacts/date.png");
           // Variables.canvas += new UI.Canvas.Text(55, 120, ConfigurationManager.AppSettings.Get("ar_date_title"), "Arial", 22,Variables.black);
            Variables.canvas += new UI.Canvas.Text(55, 88, Variables.configuration.GetParameter("System Settings,General,Date"), "Univers", 22, Variables.black);

        }
        public static void SetStartupLanguageMenu() 
        {
            Variables.currentMenu = "region";
            Variables.canvas.Clear();
            Variables.canvas += new UI.Canvas.Image(0, 0, "/home/user/images/openfoodfacts/languages.png");
            Variables.rectangle.Size = new Size(80, 115);
            Variables.rectangle.Point = new Point(14, 67);
            Variables.canvas += Variables.rectangle;
            Variables.rectangle.Layer = 2;

        }

        public static void SetSearchScreen()
        {
            Variables.currentMenu = "search";
            Variables.canvas.Clear();
            Variables.canvas += new UI.Canvas.Image(0, 0, "/home/user/images/openfoodfacts/search.png");

            Variables.rectangle.Size = new Size(105, 115);
            Variables.rectangle.Point = new Point(6, 80);
            Variables.rectangle.Layer = 1;
            Variables.canvas += Variables.rectangle;
            //Variables.searchScreenText = new UI.Canvas.Text(10, 105,Variables.appDictionary[Variables.language+ "_scan_barcode"], "Arial", 20, Variables.black);


            switch (Variables.language)
            {
                case "ar":
                    Variables.canvas += new UI.Canvas.Text(24, 160, Variables.appDictionary[Variables.language + "_search_barcode"], "Arial", 22, Variables.black);
                    Variables.canvas += new UI.Canvas.Text(124, 160, Variables.appDictionary[Variables.language + "_search_product"], "Arial", 22, Variables.black);
                    Variables.canvas += new UI.Canvas.Text(244, 160, Variables.appDictionary[Variables.language + "_search_offline"], "Arial", 22, Variables.black);
                    break;
                case "en":
                    Variables.canvas += new UI.Canvas.Text(6, 160, Variables.appDictionary[Variables.language + "_search_barcode"], "Arial", 21, Variables.black);
                    Variables.canvas += new UI.Canvas.Text(125, 160, Variables.appDictionary[Variables.language + "_search_product"], "Arial", 21, Variables.black);
                    Variables.canvas += new UI.Canvas.Text(239, 160, Variables.appDictionary[Variables.language + "_search_offline"], "Arial", 21, Variables.black);
                    break;
                case "ru":
                    Variables.canvas += new UI.Canvas.Text(4, 160, Variables.appDictionary[Variables.language + "_search_barcode"], "Arial", 21, Variables.black);
                    Variables.canvas += new UI.Canvas.Text(122, 160, Variables.appDictionary[Variables.language + "_search_product"], "Arial", 21, Variables.black);
                    Variables.canvas += new UI.Canvas.Text(238, 160, Variables.appDictionary[Variables.language + "_search_offline"], "Arial", 21, Variables.black);
                    break;

                default:
                    break;
            }

            //switch (Variables.language)
            //{
            //    case "ar":
            //        Variables.searchScreenText.Point = new Point(30, 105);
            //        Variables.searchScreenText.Height = 22;
            //        break;
            //    case "en":
            //        Variables.searchScreenText.Point = new Point(20, 105);
            //        Variables.searchScreenText.Height = 20;
            //        break;
            //    case "ru":
            //        Variables.searchScreenText.Point = new Point(5, 105);
            //        Variables.searchScreenText.Height = 20;
            //        break;

            //    default:
            //        break;
            //}
            ////Variables.canvas += Variables.searchScreenText;
        }

        public static void SetBarcodeSearchScreen()
        {
            Variables.currentMenu = "barcodeSearch";
            Variables.canvas.Clear();
            Variables.canvas += new UI.Canvas.Image(0, 0, "/home/user/images/openfoodfacts/barcode_search.png");
            Variables.canvas += new UI.Canvas.Text(60, 100, Variables.appDictionary[Variables.language + "_scan_barcode"], "Arial", 18,Variables.black){Layer = 1};
            Variables.inputText = new UI.Canvas.Text(98,140,"Scan a barcode", "Arial", 22,Variables.black) { Layer = 1 };
            Variables.canvas += Variables.inputText;
/*            UsbCommunicationHandler.ConnectAutoHunt();
            Variables.canvasTimer.Stop();
            Variables.canvasTimer.Tick += new UI.Canvas.TimerEventHandler(UsbCommunicationHandler.GetStream);
            Variables.canvasTimer.Start();*/
        }


        public static void SetProductNameSearchScreen()
        {
            Variables.currentMenu = "ProductNameSearch";
            Variables.canvas.Clear();
            Variables.canvas += new UI.Canvas.Image(0, 0, "/home/user/images/openfoodfacts/product_search.png");
            Variables.canvas += new UI.Canvas.Text(6, 84, Variables.appDictionary[Variables.language] + "product_search");
            Variables.inputText = new UI.Canvas.Text(98, 140, "");
        }



        public static void AddKeypadEventHandler() 
        {
            Variables.printerKeypad.KeyDown += new UI.Keypad.KeyEventHandler(PrinterKeypadHandler.KeyHandler);

        }

        public static void DisplayProduct(Products product, int index)
        {
            Variables.currentMenu = "product";
            Variables.canvas.Clear();
            Variables.canvas += new UI.Canvas.Image(0, 0, "/home/user/images/openfoodfacts/product_display.png");
            Variables.canvas += new UI.Canvas.Text(3, 0, product.ProductName, "Arial", 20, Variables.black);
            Variables.canvas += new UI.Canvas.Text(170, 38, product.Quantity, "Arial", 30, Variables.black);
            Variables.canvas += new UI.Canvas.Image(3, 32, "/home/user/images/openfoodfacts/local/"+ product.ImageSmallUrl+".png") {Layer = 1, Size = new Size(154,163)};
            Variables.canvas += new UI.Canvas.Image(160, 92, "/home/user/images/openfoodfacts/nutriscore-"+ product.NutriscoreGrade+ ".png") { Layer = 2, Size = new Size(145, 80) };
            Variables.canvas += new UI.Canvas.Image(270, 32, "/home/user/images/openfoodfacts/nova-group-" + product.NovaGroup + ".png") { Layer = 3, Size = new Size(40,68)};
            Variables.canvas += new UI.Canvas.Text(165, 167, product.Code, "Arial", 20, Variables.black);
            Variables.canvas += new UI.Canvas.Text(12,206,index.ToString()+"/16","Arial",20,Variables.black);
        }
    }
}
