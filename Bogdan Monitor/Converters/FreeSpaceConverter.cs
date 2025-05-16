using System;
using System.Windows.Data;
using System.Globalization;

namespace Bogdan_Monitor.Converters
{
    public class FreeSpaceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double free)
            {
                var diskInfo = parameter as dynamic;
                if (diskInfo != null && diskInfo.TotalGB > 0)
                {
                    return 100 - (free / diskInfo.TotalGB * 100);
                }
            }
            return 0;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
