using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ArduinoCommunication
{
    public class ArduinoLed : Arduino
    {
        public ArduinoLed() : base() { }
        public string[] LedId { get; set; }
        public int NumberOfLeds { get
            {
                return LedId.Length;
            }
            protected set { }
        }
        public void LedOn(int ledId)
        {
            string command = "on" + LedId[ledId];
            Thread.Sleep(500);
            ArduinoPort.Write(command);
        }
        public void LedOff(int ledId)
        {
            string command = "off" + LedId[ledId];
            Thread.Sleep(500);
            ArduinoPort.Write(command);
        }

    }
}
