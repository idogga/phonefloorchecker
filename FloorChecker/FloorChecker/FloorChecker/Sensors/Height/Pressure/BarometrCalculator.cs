using System;

namespace FloorChecker
{
    class BarometrCalculator
    {
        public Action HeightChanged;
        public double Height { get; private set; }

        private double _lastHeightBySea = 0;
        private AvarageNumberCalculator _stack = new AvarageNumberCalculator();

        public void OnCurrentMeters(double obj)
        {
            if(_lastHeightBySea==0)
            {
                _lastHeightBySea = obj;
                return;
            }
            _stack.Add(obj);
            if (Math.Abs(_lastHeightBySea - _stack.Avg) > 1)
            {
                Height += Math.Abs(_lastHeightBySea - obj);
                HeightChanged?.Invoke();
                _lastHeightBySea = obj;
            }
        }
    }
}
