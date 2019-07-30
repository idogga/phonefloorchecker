using System;
using System.Diagnostics;
using System.Numerics;

namespace FloorChecker.Sensors
{
    class AccelerationCalculator
    {
        const double accelerationThreshold = 169;
        const double gravity = 9.81;
        public double Height { get; private set; }
        public Action HeightChanged;
        private Quaternion _orientation;

        private double _lastUpdate = DateTime.Now.TimeOfDay.TotalMilliseconds;


        public void OnCurrentMeters(double x, double y, double z)
        {
            if (_orientation == null)
                return;
            var now = DateTime.Now.TimeOfDay.TotalMilliseconds;

            // Расчет текущего ускорения к Земле. но чо то я зафэйлил
            // скорее всего то, что учитывается только ускорение по оси z, не учитывая остальные.
            var g = Math.Round(z, 3) * gravity *(1 - _orientation.Z) - gravity;
            Height += Math.Abs(g * Math.Pow(((now - _lastUpdate) / 1000), 2)) / 2;
            Debug.WriteLine($"высота : {Height} t : {(now - _lastUpdate) / 1000} g : {g} z : {Math.Round(z, 3)} orint : {(1 - _orientation.Z)}");
            HeightChanged?.Invoke();
            _lastUpdate = now;
        }

        double Square(double q) => q * q;

        internal void OrientationChanged(Quaternion orientation)
        {
            _orientation = orientation;
        }
    }
}
