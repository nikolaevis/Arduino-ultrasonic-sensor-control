using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UltrasonicControl
{
    class TextFieldContent : ContentBinding
    {
        /// <summary>
        /// Content here represents distance to the obstacle in meters if more then 1m and in centimeters if less then 1m
        /// if null, it will display a default value
        /// </summary>
        public new string Content
        {
            get
            {
                if (base.Content != null)
                {
                    try
                    {
                        centimeters = Int32.Parse(base.Content);//exception when cancelled!!!!
                        if (centimeters > 100)
                        {
                            meters = centimeters / 100;
                            return meters.ToString("0.00") + " m";
                        }
                        else { return base.Content + " cm"; }
                    }
                    catch { return null; }
                }
                else { return null; }
            }
            set { base.Content = value; }
        }
        public int centimeters;
        private float meters;
    }
}
