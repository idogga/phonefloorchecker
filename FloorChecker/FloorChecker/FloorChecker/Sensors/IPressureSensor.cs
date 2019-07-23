using System;

namespace FloorChecker.Sensors
{
    public interface IPressureSensor
    {
        Action<double> GetCurrentMeters { get; set; }

        bool IsAvailable();

        void Start();

        void Stop();
    }
}
