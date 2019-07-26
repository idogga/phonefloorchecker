using System;

namespace FloorChecker
{
    class HeightCalculator
    {
        private double currentTemperature;
        private double obj;
        private const double g = 9.81;
        private const double n = 0.029;
        private const double R = 8.31;
        private const double Po = 760;
        private const double To = 273;

        public HeightCalculator(double currentTemperature, double pressure)
        {
            this.currentTemperature = currentTemperature;
            this.obj = pressure;
        }

        public double Height
        {
            get
            {
                return ((Math.Pow(1013.25 / obj, 1 / 5.257) - 1) * (currentTemperature + 273.15)) / 0.0065;
            }
        }
    }
}