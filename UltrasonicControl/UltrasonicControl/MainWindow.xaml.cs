using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ArduinoCommunication;
using System.ComponentModel;

namespace UltrasonicControl
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// design elements content constructors
        /// </summary>
        // button content initialize on/off values
        ButtonContent SensorSwitchContext = new ButtonContent((string)App.Current.Resources["SensorSwitchOn"],
            (string)App.Current.Resources["SensorSwitchOff"],
            (BitmapImage)App.Current.Resources["GreenLed"],
            (BitmapImage)App.Current.Resources["RedLed"]);
        ButtonContent BoardInitializeContext = new ButtonContent((string)App.Current.Resources["BoardInitializeOn"],
            (string)App.Current.Resources["BoardInitializeOff"],
            (BitmapImage)App.Current.Resources["GreenLed"],
            (BitmapImage)App.Current.Resources["RedLed"]);
        ButtonContent StartStopReadContext = new ButtonContent((string)App.Current.Resources["StartStopReadOn"],
            (string)App.Current.Resources["StartStopReadOff"],
            (BitmapImage)App.Current.Resources["GreenLed"],
            (BitmapImage)App.Current.Resources["RedLed"]);
        TextFieldContent DistanceValue = new TextFieldContent();
        ShapeFill FarFill = new ShapeFill(200, "Green");
        ShapeFill MiddleFill = new ShapeFill(100, "Yellow");
        ShapeFill CloseFill = new ShapeFill(50, "Red");
        //button states
        public bool BoardState { get; set; }
        public bool SensorState { get; set; }
        public bool ReadData { get; set; }
        //sensor
        ArduinoUltrasonic sensor = new ArduinoUltrasonic();
        private BackgroundWorker backgroundWorker;
        public MainWindow()
        {
            BoardState = false;
            SensorState = false;
            ReadData = false;
            //Start window
            InitializeComponent();
            //bindings
            SensorSwitch.DataContext = SensorSwitchContext;
            BoardInitialize.DataContext = BoardInitializeContext;
            StartStopRead.DataContext = StartStopReadContext;
            Distance.DataContext = DistanceValue;
            Far.DataContext = FarFill;
            Middle.DataContext = MiddleFill;
            Close.DataContext = CloseFill;
        }
        #region Buttons
        /// <summary>
        /// on/off board
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BoardInitialize_Click(object sender, RoutedEventArgs e)
        {
            BoardInitializeContext.StatusOn = !BoardInitializeContext.StatusOn;
            BoardState = BoardInitializeContext.StatusOn;
            if (BoardState)
            {
                try
                {
                    sensor.OpenAuto();
                }
                catch
                {
                    throw new Exception("Some problem with device");
                }
            }
            else
            {
                sensor.Dispose();
            }
        }
        /// <summary>
        /// on/off sensor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SensorSwitch_Click(object sender, RoutedEventArgs e)
        {
            if (BoardState)
            {
                SensorSwitchContext.StatusOn = !SensorSwitchContext.StatusOn;
                SensorState = SensorSwitchContext.StatusOn;
                if (SensorState)
                {
                    sensor.TurnSensorOn();
                }
                else
                {
                    sensor.TurnSensorOff();
                }
            }
            else
            {
                MessageBox.Show("enable board first");
            }
        }
        /// <summary>
        /// start/stop data read
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StartStopRead_Click(object sender, RoutedEventArgs e)
        {
            if (BoardState & SensorState)
            {
                StartStopReadContext.StatusOn = !StartStopReadContext.StatusOn;
                ReadData = StartStopReadContext.StatusOn;
                if (ReadData)
                {
                    backgroundWorker = new BackgroundWorker();
                    backgroundWorker.DoWork += backgroundWorker_DoWork;
                    backgroundWorker.ProgressChanged += backgroundWorker_ProgressChanged;
                    backgroundWorker.RunWorkerCompleted += backgroundWorker_RunWorkerCompleted;
                    backgroundWorker.WorkerReportsProgress = true;
                    backgroundWorker.WorkerSupportsCancellation = true;
                    backgroundWorker.RunWorkerAsync();
                }
                else
                {
                    //backgroundWorker.RunWorkerCompleted += backgroundWorker_RunWorkerCompleted;
                    backgroundWorker.CancelAsync();
                }
            }
        }
        #endregion
        #region Window properties
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            sensor.BaudRate = 9600;
        }
        private void Window_Closed(object sender, EventArgs e)
        {
            if (sensor.SensorOn)
            {
                sensor.TurnSensorOff();
                sensor.Close();
                sensor.Dispose();
            }
        }
        #endregion
        #region Background worker stuff
        /// <summary>
        /// DoWork declaration
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker backgroundWorker = sender as BackgroundWorker;
            sensor.SensorRead();
            while (true)
            {
                backgroundWorker.ReportProgress(0, sensor.Distance.ToString());
                // Periodically check if a cancellation request is pending.
                // If the user clicks cancel the line
                // m_AsyncWorker.CancelAsync(); if ran above.  This
                // sets the CancellationPending to true.
                // You must check this flag in here and react to it.
                // We react to it by setting e.Cancel to true and leaving.
                if (backgroundWorker.CancellationPending)
                {
                    // Pause for a bit to demonstrate that there is time between
                    // "Cancelling..." and "Cancel ed".
                    System.Threading.Thread.Sleep(1200);
                    // Set the e.Cancel flag so that the WorkerCompleted event
                    // knows that the process was cancelled.
                    e.Cancel = true;
                    return;
                }
                System.Threading.Thread.Sleep(100);
            }
        }
        /// <summary>
        /// Progress Changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            DistanceValue.Content = e.UserState as String;
            FarFill.SetFill(DistanceValue.centimeters);
            MiddleFill.SetFill(DistanceValue.centimeters);
            CloseFill.SetFill(DistanceValue.centimeters);
        }
        /// <summary>
        /// RunWorkerCompleted - does nor work yet, will figure out later
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                MessageBox.Show(e.Error.Message);
                return;
            }
            // Check to see if the background process was cancelled.
            if (e.Cancelled)
            {
                DistanceValue.Content = "Cancelled...";
            }
            else
            {
                // Everything completed normally.
                // process the response using e.Result
                DistanceValue.Content = "Completed...";
            }
        }
        #endregion
    }
}
