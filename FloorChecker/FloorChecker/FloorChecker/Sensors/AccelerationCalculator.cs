using System;

namespace FloorChecker.Sensors
{
    class AccelerationCalculator
    {
        public double Height { get; private set; }
        public Action HeightChanged;

        private DateTime _lastUpdate = DateTime.Now;


        public void OnCurrentMeters(double x, double y, double z)
        {
            if (-0.7 < z && z < 0.7)
                return;
            var now = DateTime.Now;
            Height += Math.Abs(z * Math.Pow(((now.Ticks - _lastUpdate.Ticks) / TimeSpan.TicksPerSecond), 2)) / 2;
            _lastUpdate= now;
            HeightChanged?.Invoke();
        }
    }
}
