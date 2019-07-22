using FloorChecker.Sensors;

namespace FloorChecker.Droid.Implement
{
    static class SensorExtension
    {
        public static SensorTypes GetSensorType(this Android.Hardware.SensorType sensor)
        {
            switch(sensor)
            {
                case Android.Hardware.SensorType.Accelerometer:
                    return SensorTypes.Accelerometr;
                case Android.Hardware.SensorType.Gyroscope:
                    return SensorTypes.Gyro;
                    case Android.Hardware.SensorType.HeartBeat:
                    return SensorTypes.HeartBeat;
                case Android.Hardware.SensorType.Pressure:
                    return SensorTypes.Pressure;
                case Android.Hardware.SensorType.Temperature:
                    return SensorTypes.Temperature;
                default:
                    return SensorTypes.Unknown;
            }
        }
    }
}