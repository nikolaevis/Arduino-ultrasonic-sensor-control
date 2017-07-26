using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace UltrasonicControl
{
    class ButtonContent : ContentBinding
    {
        /// <summary>
        /// Overriden StatusOn. needed specifically for button, as the title should show "Off" value when the status is "On"
        /// </summary>
        public override bool StatusOn
        {
            get { return statusOn; }
            set
            {
                statusOn = value;
                if (statusOn)
                {
                    Content = Off;
                    CurrentLed = GreenLed;
                }
                else
                {
                    Content = On;
                    CurrentLed = RedLed;
                }
             }
        }
        //on/off icons
        public BitmapImage GreenLed { get; set; }//on(on content off)
        public BitmapImage RedLed  { get; set; }//off(on content on)
        private BitmapImage currentLed =null;//current led
        public BitmapImage CurrentLed { get
            {
                return currentLed;
            }
            set
            {
                currentLed = value;
                NotifyPropertyChanged();
            }
        }
        public ButtonContent(string buttonOn, string buttonOff, BitmapImage greenLed, BitmapImage redLed)
        {
            On = buttonOn;
            Off = buttonOff;
            GreenLed = greenLed;
            RedLed = redLed;
        }
    }
}
