using System;

namespace FloorChecker
{
    internal class GeoCalculator
    {
        public Action HeightChanged { get; internal set; }
        public double Height { get; internal set; } = 0;

        private double _lastValue = 0;
        private AvarageNumberCalculator _stack = new AvarageNumberCalculator();

        internal void Calculate(double? altitude)
        {
            if (altitude == null)
                return;
            if (_lastValue == 0)
            {
                _lastValue = altitude.Value;
                return;
            }
            _stack.Add(altitude.Value);
            var delta = Math.Abs(_lastValue - _stack.Avg);
            if (delta > 0.5)
            {
                _lastValue = altitude.Value;
                   Height += delta;
                HeightChanged?.Invoke();
            }
        }
    }
}