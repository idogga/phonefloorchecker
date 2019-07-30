using System.ComponentModel;

namespace FloorChecker.Sensors
{
    public enum SensorTypes
    {
        [Description("Неизвестно")]
        Unknown,
        [Description("Акселерометр")]
        Accelerometr,
        [Description("Термометр")]
        Temperature,
        [Description("Гироскоп")]
        Gyro,
        [Description("Пульсометр")]
        HeartBeat,
        [Description("Барометр")]
        Pressure
    }
}
