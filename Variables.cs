using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Honeywell.Printer;

namespace Open_Food_Facts
{
    public static class Variables
    {
        public static Configuration configuration = new Configuration();
        public static UI.Canvas canvas = new UI.Canvas();
        public static UI.Canvas.Image backGround = new UI.Canvas.Image();
        public static UI.Canvas.Timer canvasTimer = new UI.Canvas.Timer();
        public static Color black = new Color(0, 0, 0);
        public static Color Bluehighlighter = new Color(33,101,187,55);
        public static UI.Canvas.Rectangle rectangle= new UI.Canvas.Rectangle(14, 67, 80, 115, Bluehighlighter);
        public static string currentMenu;
        public enum Key
        {
            Left = 13,
            Right = 14,
            Up = 15,
            Down = 16,
            ok=10,
            Menu = 8,
            exit = 9,
            feed = 11
        }
        public static string language;
        public static UI.Canvas.Text searchScreenText;
        public static UI.Keypad printerKeypad = new UI.Keypad();


        public static Dictionary<string, string> appDictionary = new Dictionary<string, string>() 
        {
            {"en_scan_barcode","Please scan a product barcode" },
            {"ar_scan_barcode","يرجى مسح الرمز الشريطي للمنتج" },
            {"ru_scan_barcode","Сканировать штрих-код продукта" }
        };
        


    }
}
