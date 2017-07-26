using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ArduinoCommunication;

namespace UltrasonicControl
{
    class Worker
    {
        public static int Distance(ArduinoUltrasonic sensor)
        {
            return Distance(sensor, null);
        }

        public static int Distance(ArduinoUltrasonic sensor, System.ComponentModel.BackgroundWorker backgroundWorker)
        {
            if (backgroundWorker != null && backgroundWorker.WorkerReportsProgress)
            {
                backgroundWorker.ReportProgress(100);
            }
            return sensor.Distance;
        }
    }
}
