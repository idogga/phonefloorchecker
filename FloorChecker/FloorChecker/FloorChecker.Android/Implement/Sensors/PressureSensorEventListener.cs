using Android.Hardware;
using Android.Runtime;
using System;
using System.Diagnostics;

namespace FloorChecker.Droid.Sensors
{
    class PressureSensorEventListener : Java.Lang.Object, ISensorEventListener
    {
        private Action<double> _pressureChanged;

        public PressureSensorEventListener(Action<double> PressureChanged)
        {
            _pressureChanged = PressureChanged;
        }

        public void OnAccuracyChanged(Sensor sensor, [GeneratedEnum] SensorStatus accuracy)
        {
        }

        public void OnSensorChanged(SensorEvent e)
        {
            Debug.WriteLine("%.3f mbar", e.Values[0]);
            _pressureChanged?.Invoke(e.Values[0]);
        }
    }
}