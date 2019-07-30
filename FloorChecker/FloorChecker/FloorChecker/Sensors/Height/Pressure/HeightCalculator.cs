using System;

namespace FloorChecker
{
    class HeightCalculator
    {
        private double _pressure;

        public HeightCalculator(double pressure)
        {
            _pressure = pressure;
        }

        public double Height
        {
            get
            {
                return (_pressure * 7.500637554192 - 7600) * 1.2;
            }
        }
    }
}