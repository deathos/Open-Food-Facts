using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Honeywell.Printer;
using System.Collections.Specialized;

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
            Variables.canvas += Variables.rectangle;
            Variables.rectangle.Layer = 2;
        }

        public static void SetSearchScreen()
        {
            Variables.currentMenu = "search";
            Variables.canvas.Clear();
            Variables.canvas += new UI.Canvas.Image(0, 0, "/home/user/images/search.png");
            Variables.searchScreenText = new UI.Canvas.Text(10, 105,Variables.appDictionary[Variables.language+ "_scan_barcode"], "Arial", 20, Variables.black);
            switch (Variables.language)
            {
                case "ar":
                    Variables.searchScreenText.Point = new Point(30, 105);
                    Variables.searchScreenText.Height = 22;
                    break;
                case "en":
                    Variables.searchScreenText.Point = new Point(20, 105);
                    Variables.searchScreenText.Height = 20;
                    break;
                case "ru":
                    Variables.searchScreenText.Point = new Point(5, 105);
                    Variables.searchScreenText.Height = 20;
                    break;

                default:
                    break;
            }
            Variables.canvas += Variables.searchScreenText;
        }

        public static void AddKeypadEventHandler() 
        {
            Variables.printerKeypad.KeyDown += new UI.Keypad.KeyEventHandler(PrinterKeypadHandler.KeyHandler);

        }
    }
}
