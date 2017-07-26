using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
//using System.IO.Ports;

namespace ArduinoCommunication
{
    public class ArduinoUltrasonic : Arduino
    {
        /// <summary>
        /// Constructor, all by default
        /// </summary>
        public ArduinoUltrasonic() : base() { }
        private bool _sensorOn = false; //Sensor starts on command described below. By default we concider that it is off. It may happen that it is really on on the board, but this does not matter.
        public bool SensorOn
        {
            get
            {
                return _sensorOn;
            }
            set
            {
                _sensorOn = value;
            }
        }
        public int Distance { get; protected set; }
        /// <summary>
        ///  on the sensor from the kit the function just starts/stops sending signal to the sensor. Later it will switch on/off 21v electronic key. The same command should be enough
        /// </summary>
        public void TurnSensorOn()
        {
            Thread.Sleep(400);
            ArduinoPort.Write("<OnUltrasonic>");//send command
            Thread.Sleep(400);// experimentally figured out the delay. Without it there is an error.
            SensorOn = true;
        }
        public void TurnSensorOff()
        {
            Thread.Sleep(400);
            ArduinoPort.Write("<OffUltrasonic>");//send command
            Thread.Sleep(400);// experimentally figured out the delay. Without it there is an error.
            SensorOn = false;
        }
        public void SensorRead()//Magic. I do not fully understand how it works, but it reads data ok.
        {
                ArduinoPort.DataReceived += new SerialDataReceivedEventHandler(DataReceivedHandler);
        }
        private void DataReceivedHandler(object sender, SerialDataReceivedEventArgs e)
        {
            if (SensorOn)
            {
                try
                {
                    SerialPort sp = (SerialPort)sender;
                    string indata = sp.ReadTo("\n");
                    if (indata.Contains("<cm>") && indata.Contains("</cm>"))//if serial data contains <cm> tag take process it.
                    {
                        Distance = Int32.Parse(Regex.Replace(indata, "<.*?>", String.Empty)); //trim out tags, convert to int
                    }
                }
                finally { }
                }
            else { Distance = 0; }//if serial port is off, return 0, but this does not work quite well (if above throws exception)
        }
        /// <summary>
        /// Dispose: turn off sensor, dispose variable. 
        /// </summary>
        public override void Dispose()
        {
            if (SensorOn)
            {
                TurnSensorOff();
            }
            base.Dispose();
        }
    }
}
