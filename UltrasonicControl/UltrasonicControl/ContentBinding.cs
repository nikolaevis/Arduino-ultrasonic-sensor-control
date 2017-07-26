using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace UltrasonicControl
{
    public abstract class ContentBinding : INotifyPropertyChanged
    {
        /// <summary>
        /// content values for true/false Statuson
        /// </summary>
        protected virtual string On { get; set; }
        protected virtual string Off { get; set; }
        /// <summary>
        /// status of an element, also changes the content in the setter
        /// </summary>
        public bool Enabled { get; set; }
        protected bool statusOn = false;
        public virtual bool StatusOn
        {
            get{ return statusOn;}
            set
            {
                statusOn = value;
                if (statusOn) { Content = On; }
                else { Content = Off; }
            }
        }
        string content;
        /// <summary>
        /// content, displayed on an element
        /// </summary>
        public virtual string Content
        {
            get { return content; }
            set
            {
                content = value;
                NotifyPropertyChanged();//notification on the changed property
            }
        }
        /// <summary>
        /// Notification declaration
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
