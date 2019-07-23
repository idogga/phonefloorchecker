using System;

namespace FloorChecker.Sensors
{
    class BarometrCalculator
    {
        public Action HeightChanged;
        public double Height { get; private set; }

        private double _lastHeightBySea = 0;

        public BarometrCalculator(Action<double> getCurrentMeters)
        {
            getCurrentMeters += OnCurrentMeters;
        }

        private void OnCurrentMeters(double obj)
        {
            if(_lastHeightBySea==0)
            {
                _lastHeightBySea = obj;
                return;
            }
            if(_lastHeightBySea -obj < 0.5)
            {
                _lastHeightBySea = obj;
                Height = Math.Abs(_lastHeightBySea - obj);
                HeightChanged?.Invoke();
            }
        }
    }
}
