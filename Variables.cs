using System.Collections.Generic;
using Honeywell.Printer;

namespace Open_Food_Facts
{
    public static class Variables
    {
        public static Configuration configuration = new Configuration();
        public static UI.Canvas canvas = new UI.Canvas();
        public static UI.Canvas.Image backGround = new UI.Canvas.Image();
        public static UI.Canvas.Timer canvasTimer = new UI.Canvas.Timer();
        public static UI.Canvas.Text inputText;
        public static Communication.Autohunt autohunt;
        public static Color black = new Color(0, 0, 0);
        public static Color bluehighlighter = new Color(33,101,187,55);
        public static UI.Canvas.Rectangle rectangle= new UI.Canvas.Rectangle(14, 67, 80, 115, bluehighlighter);
        public static string currentMenu;
        public static List<Products> localDbProductsList = new List<Products>();
        public static PrintControl printControl = new PrintControl();
        public static Drawing drawing = new Drawing();
        public static int currentIndex = 0;

        public enum Key
        {
            Left = 13,
            Right = 14,
            Up = 15,
            Down = 16,
            Ok=10,
            Menu = 8,
            Exit = 9,
            Feed = 11
        }
        public static string language;
        public static UI.Canvas.Text searchScreenText;
        public static UI.Keypad printerKeypad = new UI.Keypad();


        public static Dictionary<string, string> appDictionary = new Dictionary<string, string>() 
        {
            //Search Screen
            {"en_search_barcode", "Barcode"},
            {"ar_search_barcode", "باركود"},
            {"ru_search_barcode", "Штрих-код"},
            {"en_search_product", "Product"},
            {"ar_search_product", "اسم المنتج"},
            {"ru_search_product", "Продукт"},
            {"en_search_offline", "Demo"},
            {"ar_search_offline", "تجريب"},
            {"ru_search_offline", "демо"},
            //Product name Search screen
            {"en_product_search", "Please enter a product name"},
            {"ar_product_search", "الرجاء إدخال اسم المنتج"},
            {"ru_product_search", "Пожалуйста, введите название продукта"},
            //Demo mode search screen
/*            {"en_db_search", "Please scan a product barcode"},
            {"ar_db_search", "يرجى مسح الرمز الشريطي للمنتج"},
            {"ru_db_search", "Сканировать штрих-код продукта"},*/
            //Barcode Search Screen
            {"en_scan_barcode", "Please scan a product barcode"},
            {"ar_scan_barcode", "يرجى مسح الرمز الشريطي للمنتج"},
            {"ru_scan_barcode", "Сканировать штрих-код продукта"},
        };
    }
}
