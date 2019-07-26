using FloorChecker.iOS.Implement;
using FloorChecker.Sensors;
using System.Collections.Generic;
using UIKit;
using Xamarin.Forms;
using CoreMotion;
using CoreLocation;

[assembly: Dependency(typeof(IOSSensors))]
namespace FloorChecker.iOS.Implement
{
    class IOSSensors:ISensor
    {
        public List<Sensor> GetAvailableSensors()
        {
            var result = new List<Sensor>();
            {
                result.Add(new Sensor() { Name = "Proximity sensor", Type = SensorTypes.Unknown });
                result.Add(new Sensor() { Name = "Ambient light sensor", Type = SensorTypes.Unknown });
                result.Add(new Sensor() { Name = "Accelerometer", Type = SensorTypes.Accelerometr });
                result.Add(new Sensor() { Name = "Compass", Type = SensorTypes.Unknown });
                result.Add(new Sensor() { Name = "Barometer", Type = SensorTypes.Pressure });
                result.Add(new Sensor() { Name = "NFC for Apple Pay", Type = SensorTypes.Unknown });
                result.Add(new Sensor() { Name = "Touch ID fingerprint scanner", Type = SensorTypes.Unknown });
            }
            if (DeviceHardware.Model == "iPad Mini 1")
            {
                result.Add(new Sensor() { Name = "5MP Camera", Type = SensorTypes.Unknown });
                result.Add(new Sensor() { Name = "Ambient light sensor", Type = SensorTypes.Unknown });
                result.Add(new Sensor() { Name = "Gyroscope", Type = SensorTypes.Gyro });
                result.Add(new Sensor() { Name = "Accelerometr", Type = SensorTypes.Accelerometr });
                result.Add(new Sensor() { Name = "Compass", Type = SensorTypes.Unknown });
            }
            return result;
        }
    }
}