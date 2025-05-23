using LiveCharts;
using System;
using System.Windows.Controls;
using System.ComponentModel;
using LiveCharts.Configurations;
using System.Windows.Threading;
using System.Diagnostics;
using System.Linq;
using Bogdan_Monitor; 

namespace Bogdan_Monitor.UserControls
{

    public partial class GpuLineChart : UserControl, INotifyPropertyChanged
    {
        private double _axisMax;
        private double _axisMin;

        public Counter CounterInstance { get; set; } = new Counter();

        public GpuLineChart()
        {
            InitializeComponent();

            var mapper = Mappers.Xy<MeasureModel>()
               .X(model => model.DateTime.Ticks)
               .Y(model => model.Value);

            Charting.For<MeasureModel>(mapper);

            ChartValues = new ChartValues<MeasureModel>();

            DateTimeFormatter = value => new DateTime((long)value).ToString("mm:ss");

            AxisStep = TimeSpan.FromSeconds(1).Ticks;
            AxisUnit = TimeSpan.TicksPerSecond;

            SetAxisLimits(DateTime.Now);

            IsReading = false;

            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(1);
            timer.Tick += timer_Tick;
            timer.Start();

            DataContext = this;
        }

        public double AxisMax
        {
            get { return _axisMax; }
            set
            {
                _axisMax = value;
                OnPropertyChanged("AxisMax");
            }
        }
        public double AxisMin
        {
            get { return _axisMin; }
            set
            {
                _axisMin = value;
                OnPropertyChanged("AxisMin");
            }
        }

        public bool IsReading { get; set; }

        public ChartValues<MeasureModel> ChartValues { get; set; }
        public Func<double, string> DateTimeFormatter { get; set; }
        public double AxisStep { get; set; }
        public double AxisUnit { get; set; }

        private void SetAxisLimits(DateTime now)
        {
            AxisMax = now.Ticks + TimeSpan.FromSeconds(1).Ticks;
            AxisMin = now.Ticks - TimeSpan.FromSeconds(30).Ticks;
        }

        void timer_Tick(object? sender, EventArgs e)
        {
            var now = DateTime.Now;
            double value = 0;

            // Получаем Video Encode из CounterInstance
            var encode = CounterInstance.GetGpuVideoEncode();
            if (encode.HasValue)
                value = encode.Value;

            ChartValues.Add(new MeasureModel
            {
                DateTime = now,
                Value = value
            });

            SetAxisLimits(now);

            if (ChartValues.Count > 150) ChartValues.RemoveAt(0);
        }

        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
        public class MeasureModel
        {
            public DateTime DateTime { get; set; }
            public double Value { get; set; }
        }
    }
}
