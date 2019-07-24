using System;

namespace FloorChecker.Sensors
{
    public interface IAccelerometr
    {
        Action<double, double, double> GetCurrentAcceleration { get; set; }

        bool IsAvailable();

        void Stop();
    }
}