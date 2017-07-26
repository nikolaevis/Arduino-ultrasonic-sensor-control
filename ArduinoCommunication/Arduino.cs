using System;
using System.Threading;
using System.IO.Ports;
using System.IO;

namespace ArduinoCommunication
{
    /// <summary>
    /// base class for future arduino projects
    /// </summary>
    public abstract class Arduino : IDisposable
    {
        public int BaudRate { get; set; }
        public string PortName { get; set; }
        protected SerialPort ArduinoPort = new SerialPort();
        /// <summary>
        /// Automatically find port, assign properties and open it.
        /// </summary>
        public void OpenAuto()
        {
            FindPortName();
            Open();
        }

        /// <summary>
        /// Non-automatic open method
        /// </summary>
        public void Open()
        {
            ArduinoPort.BaudRate = BaudRate;
            ArduinoPort.PortName = PortName;
            ArduinoPort.WriteTimeout = 200;
            ArduinoPort.Open();
        }
        /// <summary>
        /// Close
        /// </summary>
        public void Close()
        {
            ArduinoPort.Close();
        }
        /// <summary>
        /// find port name looping through all avilable trying to make a handshake
        /// </summary>
        public void FindPortName()
        {
            foreach (string name in SerialPort.GetPortNames())
            {
                if (HandShake(name))
                {
                    PortName = name;
                    return;
                }
            }
            throw new NotImplementedException("No Arduino device found!");
        }
        /// <summary>
        /// Handshake function
        /// </summary>
        /// <param name="portName"></param>
        /// <returns>bool value, true if a properly configured Arduino is present on the port</returns>
        public bool HandShake(string portName)
        {
            bool success = false; //if handshake is successful 
            try
            {
                string answer;
                int i = 0;//counter of attempts
                //The below setting are for the Hello handshake
                SerialPort port = new SerialPort(portName);
                port.BaudRate = BaudRate;
                port.WriteTimeout = 100;
                port.ReadTimeout = 100;
                port.Open();
               // Thread.Sleep(500);
                port.Write("<Hello Arduino>");
                Thread.Sleep(500);
                try { answer = port.ReadTo("\n"); }
                catch { answer = "not found yet"; }
                
                int count = port.BytesToRead;
                while (!answer.Contains("<Hello there>"))
                {
                    i++;
                    Thread.Sleep(100);
                    //
                    if (i > 10) { return success = false; }                  
                }
                port.Close();
                success = true;
                return success;
            }
            catch
            {
                throw new Exception("Some problem with device");
            }
        }
        public virtual void Dispose()
        {
            if (ArduinoPort != null)
            {
                ArduinoPort.Dispose();
            }
        }
    }

}


