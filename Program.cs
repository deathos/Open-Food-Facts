using System;
using System.Threading;
using Honeywell.Printer;

namespace Open_Food_Facts
{
    class Program
    {

        static int Main()
        {
            UserInterfaceHandler.SetStartupLanguageMenu();
            UserInterfaceHandler.AddKeypadEventHandler();
            Variables.canvasTimer.Interval = 1000;
            Variables.canvasTimer.Tick += new UI.Canvas.TimerEventHandler(Update);
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
