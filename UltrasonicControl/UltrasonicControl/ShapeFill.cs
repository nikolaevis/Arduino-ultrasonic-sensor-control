using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltrasonicControl
{
    class ShapeFill : ContentBinding
    {
        private int DistanceOn { get; set; }
        public ShapeFill( int distanceOn, string colorOn, string colorOff = "#FFF4F4F5")
        {
            DistanceOn = distanceOn;
            On = colorOn;
            Off = colorOff;
        }
        public void SetFill(int distance)
        {
            if (distance < DistanceOn){ StatusOn = true; }
            else { StatusOn = false; }
        }
    }
}
