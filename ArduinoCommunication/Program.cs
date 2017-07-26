using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArduinoCommunication
{
    class Program
    {
        static void Main(string[] args)
        {
            //string[] id = new string[] { "1", "2", "3", "_all" }; 
            ArduinoUltrasonic test = new ArduinoUltrasonic();
            test.BaudRate = 9600;
            test.OpenAuto();
            test.TurnSensorOn();
            test.SensorRead();
            //  test.LedId = id;
            ////  System.Threading.Thread.Sleep(500);
            //  Console.WriteLine("red led on");
            // // Console.ReadLine();
            //  test.LedOn(0);
            //  Console.WriteLine("green led on");
            //  //Console.ReadLine();
            //  test.LedOn(2);
            ////  System.Threading.Thread.Sleep(5000);
            //  test.LedOff(3);
            //  Console.WriteLine("all leds off");
            Console.ReadLine();
            test.TurnSensorOff();
            Console.ReadLine();
            test.Close();
            test.Dispose();
        }
    }
}
