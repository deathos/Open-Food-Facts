using System.Drawing;
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
            Variables.canvas += new UI.Canvas.Image(0, 0, "/home/user/images/date.png");
           // Variables.canvas += new UI.Canvas.Text(55, 120, ConfigurationManager.AppSettings.Get("ar_date_title"), "Arial", 22,Variables.black);
            Variables.canvas += new UI.Canvas.Text(55, 88, Variables.configuration.GetParameter("System Settings,General,Date"), "Univers", 22, Variables.black);

        }
        public static void SetStartupLanguageMenu() 
        {
            Variables.currentMenu = "region";
            Variables.canvas.Clear();
            Variables.canvas += new UI.Canvas.Image(0, 0, "/home/user/images/languages.png");
            Variables.rectangle.Size = new Size(80, 115);
            Variables.rectangle.Point = new Point(14, 67);
            Variables.canvas += Variables.rectangle;
            Variables.rectangle.Layer = 2;

        }

        public static void SetSearchScreen()
        {
            Variables.currentMenu = "search";
            Variables.canvas.Clear();
            Variables.canvas += new UI.Canvas.Image(0, 0, "/home/user/images/search.png");

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
            Variables.canvas += new UI.Canvas.Image(0, 0, "/home/user/images/barcode_search.png");
            Variables.canvas += new UI.Canvas.Text(6, 84, Variables.appDictionary[Variables.language]+ "scan_barcode");
            Variables.inputText = new UI.Canvas.Text(98,140,"");
        }




        public static void AddKeypadEventHandler() 
        {
            Variables.printerKeypad.KeyDown += new UI.Keypad.KeyEventHandler(PrinterKeypadHandler.KeyHandler);

        }

        public static void DisplayProduct()
        {
            Variables.currentMenu = "product";
            Variables.canvas.Clear();
            Variables.canvas += new UI.Canvas.Image(0, 0, "/home/user/images/product_display.png");
            Variables.canvas += new UI.Canvas.Text(3, 0, "Nutella pate a tartiner noisettes-cacao t.750 pot de 750", "Arial", 20, Variables.black);
            Variables.canvas += new UI.Canvas.Text(170, 38, "400g", "Arial", 30, Variables.black);
            Variables.canvas += new UI.Canvas.Image(3, 32, "/home/user/images/front_en.327.200.png") {Layer = 1, Size = new Size(154,163)};
            Variables.canvas += new UI.Canvas.Image(160, 92, "/home/user/images/nutriscore-e.png") { Layer = 2, Size = new Size(145, 80) };
            Variables.canvas += new UI.Canvas.Image(270, 32, "/home/user/images/nova-group-4.png") { Layer = 3, Size = new Size(40,68)};
            Variables.canvas += new UI.Canvas.Text(165, 167, "3017620422003", "Arial", 20, Variables.black);
            Variables.canvas += new UI.Canvas.Text(12,206,"01/24","Arial",20,Variables.black);
        }
    }
}
