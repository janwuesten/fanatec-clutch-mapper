using System;
using System.Threading;
using fanatec_clutch_mapper.Service;

namespace fanatec_clutch_mapper {
    class Program {
        static void Main(string[] args) {
            ConfigService config = new ConfigService("config.xml");
            if (!config.Exists()) {
                config.Save();
                Console.WriteLine("Created config.xml. You can edit it now.");
                Console.WriteLine("Press any key to continue ...");
                Console.ReadKey();
            }
            config.Read();
            FanatecGamepadService service = new FanatecGamepadService(config.Wheel);
            while (service.IsError) {
                service.Load();
                Console.WriteLine("No Fanatec device found. Retry to load in 5s.");
                Thread.Sleep(5000);
            }
            Console.WriteLine("Waiting for Fanatec Wheel buttons");
            while (true) {
                service.ReadState();
                service.GetLeftPedal();
                service.GetRightPedal();
                int leftPressed = service.GetLeftPressed();
                int rightPressed = service.GetRightPressed();

                if (leftPressed != 0) {
                    if (leftPressed > config.Wheel.MaxPedalValue * (config.Configuration.FullPressThreshold / 100)) {
                        System.Windows.Forms.SendKeys.SendWait(config.Configuration.LeftPressKey);
                        Console.WriteLine("LEFT PRESS");
                    } else {
                        System.Windows.Forms.SendKeys.SendWait(config.Configuration.LeftShortKey);
                        Console.WriteLine("LEFT SHORT PRESS");
                    }
                }
                if (rightPressed != 0) {
                    if (rightPressed > config.Wheel.MaxPedalValue * (config.Configuration.FullPressThreshold / 100)) {
                        System.Windows.Forms.SendKeys.SendWait(config.Configuration.RightPressKey);
                        Console.WriteLine("RIGHT PRESS");
                    } else {
                        System.Windows.Forms.SendKeys.SendWait(config.Configuration.RightShortKey);
                        Console.WriteLine("RIGHT SHORT PRESS");
                    }
                }
            }
        }
    }
}