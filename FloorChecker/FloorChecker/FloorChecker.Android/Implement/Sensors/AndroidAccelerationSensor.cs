using Android.Content;
using Android.Hardware;
using FloorChecker.Droid.Sensors;
using Xamarin.Forms;
using FloorChecker.Sensors;
using Sensor = Android.Hardware.Sensor;
using System;

[assembly: Dependency(typeof(AndroidAccelerationSensor))]
namespace FloorChecker.Droid.Sensors
{
    class AndroidAccelerationSensor : IAccelerometr
    {
        Sensor accelerationSensor;
        private Action<double, double, double> OnAccelerationChecked { get; set; }

        public AndroidAccelerationSensor()
        {
            var sensorManager = (SensorManager)Android.App.Application.Context.GetSystemService(Context.SensorService);
            accelerationSensor = sensorManager.GetDefaultSensor(SensorType.LinearAcceleration);

            Start();
            if (accelerationSensor != null)
            {
                bool res = sensorManager.RegisterListener(new PressureSensorEventListener(OnAccelerationChecked), accelerationSensor, SensorDelay.Normal);
            }
        }


        public Action<double, double, double> GetCurrentAcceleration { get; set; }

        public bool IsAvailable() => accelerationSensor != null;

        public void Start()
        {
            OnAccelerationChecked += AccelerationChanged;
        }

        private void AccelerationChanged(double arg1, double arg2, double arg3)
        {
            GetCurrentAcceleration?.Invoke(arg1, arg2, arg3);
        }

        public void Stop()
        {
            OnAccelerationChecked -= AccelerationChanged;
        }
    }
}