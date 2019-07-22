using System;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using Xamarin.Forms;

namespace FloorChecker
{
    public class EnumTypeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            switch ((Sensors.SensorTypes)value)
            {
                case Sensors.SensorTypes.Accelerometr:
                    return "Акселерометр";
                case Sensors.SensorTypes.Gyro:
                    return "Гироскоп";
                case Sensors.SensorTypes.HeartBeat:
                    return "Пульсометр";
                case Sensors.SensorTypes.Pressure:
                    return "Барометр";
                case Sensors.SensorTypes.Temperature:
                    return "Термометр";
                default:
                    return "Неизвестно";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (bool)value ? 1 : 0;
        }
    }
}