using System;

namespace FloorChecker.Droid.Sensors
{
    internal class HeightCalculator
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
            this.currentTemperature = currentTemperature + To;
            this.obj = pressure * 750.062 / 1000;
        }

        public double Height
        {
            get
            {
                return -Math.Log(obj / Po) * R * currentTemperature / (n * g);
            }
        }
    }
}