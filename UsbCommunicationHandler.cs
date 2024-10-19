using System;
using System.IO;
using System.Threading;
using Honeywell.Printer;

namespace Open_Food_Facts
{
    public static class UsbCommunicationHandler
    {
        /*
         * Connect to USB
         * Return data from USB
         * Close connection and streams
         */

        // Initialize Autohunt
        

        public static void ConnectAutoHunt()
        {
            Variables.autohunt = new Communication.Autohunt();
            string[] usbPortNames = Communication.USBHost.GetPortNames();
            foreach (string usbPortName in usbPortNames)
            {
                Communication.USBHost usbHost = new Communication.USBHost(usbPortName);
                usbHost.Open();
                if (usbHost.IsOpen)
                {
                    Variables.autohunt.AddStream(usbHost.GetStream());
                    Console.WriteLine("Added: " + usbPortName);

                    FileStream fs = usbHost.GetStream();
                    fs.
                }
            }
        }

        public static void GetStream(object obj, UI.Canvas.TimerEventArgs eventArgs)
        {
                int i;

                    Byte[] bytes = new Byte[256];

                    if ((i = Variables.autohunt.Read(bytes, 0, bytes.Length)) > 0)
                    {
                        
                        string data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                        Console.WriteLine("echo {0} bytes: {1}", data.Length, data);
                        Variables.inputText.Data = data;
                        if (Variables.inputText.Data.Length == 12 || Variables.inputText.Data.Length == 7)
                        {
                            Console.WriteLine("startsearch");
                            //UserInterfaceHandler.SetSearchScreen();
                        }
                    }

        }

    }
}
