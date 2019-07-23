using System;
using Android.Content;
using Android.Hardware;
using FloorChecker.Droid.Sensors;
using FloorChecker.Sensors;
using Xamarin.Forms;
using Sensor = Android.Hardware.Sensor;

[assembly: Dependency(typeof(AndroidPressureSensor))]
namespace FloorChecker.Droid.Sensors
{
    class AndroidPressureSensor : IPressureSensor
    {
        public Action<double> GetCurrentMeters { get; set; }
        private Action<double> OnBarometrChecked { get; set; }
        private Action<double> OnTemperatureChecked { get; set; }
        double currentTemperature = 27;
        Sensor pressureSensor;
        Sensor temperatureSensor;
        public AndroidPressureSensor()
        {
            var sensorManager = (SensorManager)Android.App.Application.Context.GetSystemService(Context.SensorService);
            pressureSensor = sensorManager.GetDefaultSensor(SensorType.Pressure);
            temperatureSensor = sensorManager.GetDefaultSensor(SensorType.Temperature);

            Start();
            if (pressureSensor != null)
            {
                bool res = sensorManager.RegisterListener(new PressureSensorEventListener(OnBarometrChecked), pressureSensor, SensorDelay.Fastest);
            }
            if(temperatureSensor!=null)
            {
                bool res = sensorManager.RegisterListener(new PressureSensorEventListener(OnTemperatureChecked), temperatureSensor, SensorDelay.Fastest);
            }
        }

        private void TemperatureChanged(double obj)
        {
            currentTemperature = obj;
        }

        public bool IsAvailable()
        {
            return pressureSensor != null;
        }

        public void Start()
        {
            OnTemperatureChecked += TemperatureChanged;
            OnBarometrChecked += PressureChanged;
        }

        private void PressureChanged(double obj)
        {
            var calculator = new HeightCalculator(currentTemperature, obj);
            GetCurrentMeters?.Invoke(calculator.Height);
        }

        public void Stop()
        {
            OnTemperatureChecked -= TemperatureChanged;
            OnBarometrChecked -= PressureChanged;
        }
    }
}