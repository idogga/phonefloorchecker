using System.Collections.Generic;
using System.Linq;

namespace FloorChecker
{
    class AvarageNumberCalculator
    {
        List<double> _cash = new List<double>() { 0, 0, 0,0};

        public void Add(double value)
        {
            _cash.RemoveAt(0);
            _cash.Add(value);
        }

        public double Avg
        {
            get => _cash.Sum() / _cash.Where(x=>x!=0).Count();
        }
    }
}
