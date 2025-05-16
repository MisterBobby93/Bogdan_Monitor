using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Bogdan_Monitor.Views
{
    public class LineChart : Control
    {
        private readonly List<double> _values = new List<double>();
        private const int MaxPoints = 60;
        private double _value;

        static LineChart()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(LineChart), 
                new FrameworkPropertyMetadata(typeof(LineChart)));
        }

        public double Value
        {
            get => _value;
            set
            {
                _value = value;
                _values.Add(value);
                if (_values.Count > MaxPoints)
                    _values.RemoveAt(0);
                InvalidateVisual();
            }
        }

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

            if (_values.Count < 2) return;

            var pen = new Pen(Brushes.LightBlue, 1);
            var width = ActualWidth;
            var height = ActualHeight;
            var stepX = width / (MaxPoints - 1);

            for (var i = 0; i < _values.Count - 1; i++)
            {
                var x1 = i * stepX;
                var x2 = (i + 1) * stepX;
                var y1 = height - (_values[i] * height / 100);
                var y2 = height - (_values[i + 1] * height / 100);

                drawingContext.DrawLine(pen, new Point(x1, y1), new Point(x2, y2));
            }
        }
    }
}
