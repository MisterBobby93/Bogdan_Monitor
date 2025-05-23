using System;
using System.Globalization;
using System.Windows.Data;
using Bogdan_Monitor.Views; 

namespace Bogdan_Monitor.Converters
{
    public class FreeSpaceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Добавлена проверка на null для value и parameter, а также для diskInfo
            if (value is double free && parameter is MainView.DiskInfo diskInfo && diskInfo != null && diskInfo.TotalGB > 0)
            {
                // Расчет использованного пространства в процентах
                double usedPercent = (diskInfo.UsedGB / diskInfo.TotalGB) * 100;
                return usedPercent;
            }
            return 0; // Возвращаем 0, если что-то пошло не так
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
