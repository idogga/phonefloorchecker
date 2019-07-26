using System;

namespace FloorChecker.Sensors
{
    class BarometrCalculator
    {
        public Action HeightChanged;
        public double Height { get; private set; }

        private double _lastHeightBySea = 0;

        public void OnCurrentMeters(double obj)
        {
            if(_lastHeightBySea==0)
            {
                _lastHeightBySea = obj;
                return;
            }
            if(Math.Abs(_lastHeightBySea - obj) > 0.5)
            {
                Height = Math.Abs(_lastHeightBySea - obj);
                HeightChanged?.Invoke();
                _lastHeightBySea = obj;
            }
        }
    }
}
