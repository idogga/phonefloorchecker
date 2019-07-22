using Android.Content;
using Android.Hardware;
using FloorChecker.Droid.Implement;
using FloorChecker.Sensors;
using System.Collections.Generic;
using Xamarin.Forms;
using Sensor = FloorChecker.Sensors.Sensor;

[assembly: Dependency(typeof(AndroidSensors))]
namespace FloorChecker.Droid.Implement
{
    class AndroidSensors : ISensor
    {
        public List<Sensor> GetAvailableSensors()
        {
            var result = new List<Sensor>();
            var sensorManager = (SensorManager)Android.App.Application.Context.GetSystemService(Context.SensorService);
            var sensors = sensorManager.GetSensorList(SensorType.All);
            foreach(var sensor in sensors)
            {
                result.Add(new Sensor() { Name = sensor.Name, Version=sensor.Version, Type = sensor.Type.GetSensorType() });
            }
            return result;
        }
    }
}