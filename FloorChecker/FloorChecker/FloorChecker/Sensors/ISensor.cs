using System.Collections.Generic;

namespace FloorChecker.Sensors
{
    public interface ISensor
    {
        List<Sensor> GetAvailableSensors();
    }
}
