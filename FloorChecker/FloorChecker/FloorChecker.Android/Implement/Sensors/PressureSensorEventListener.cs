using Android.Hardware;
using Android.Runtime;
using System;

namespace FloorChecker.Droid.Sensors
{
    class PressureSensorEventListener : Java.Lang.Object, ISensorEventListener
    {
        private Action<double> _pressureChanged;
        private Action<double, double, double> _accelerationChanged;

        public PressureSensorEventListener(Action<double> PressureChanged)
        {
            _pressureChanged = PressureChanged;
        }

        public PressureSensorEventListener(Action<double, double, double> accelerationChanged)
        {
            _accelerationChanged = accelerationChanged;
        }

        public void OnAccuracyChanged(Sensor sensor, [GeneratedEnum] SensorStatus accuracy)
        {
        }

        public void OnSensorChanged(SensorEvent e)
        {
            if(_pressureChanged!=null)
            _pressureChanged?.Invoke(e.Values[0]);
            if (_accelerationChanged != null)
                _accelerationChanged?.Invoke(e.Values[0], e.Values[1], e.Values[2]);
        }
    }
}