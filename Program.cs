using System;
using System.IO;
using System.Threading;
using Honeywell.Printer;

namespace Open_Food_Facts
{
    class Program
    {

        static int Main()
        {
            UserInterfaceHandler.SetStartupLanguageMenu();
            /*Thread thread = new Thread(SqLiteHandler.FetchData);
            thread.Start();*/
            UserInterfaceHandler.AddKeypadEventHandler();
            Directory.CreateDirectory("/home/user/images/openfoodfacts/tmp");
            Variables.canvasTimer.Interval = 1000;
            Variables.canvasTimer.Tick += new UI.Canvas.TimerEventHandler(Update);
            UsbCommunicationHandler.ConnectAutoHunt();
            Variables.canvasTimer.Tick += new UI.Canvas.TimerEventHandler(UsbCommunicationHandler.GetStream);

            Variables.canvasTimer.Start();
            Variables.canvas.Run();
            Console.WriteLine(Variables.configuration.GetParameter("System Settings,General,Date"));
            Variables.configuration.Dispose();
            Variables.canvas.Dispose();
            Thread.Sleep(1000);
            return 0;
        }

        public static void Update(object obj, UI.Canvas.TimerEventArgs eventArgs)
        {

        }


        }
}
