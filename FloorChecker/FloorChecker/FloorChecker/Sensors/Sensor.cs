using System.ComponentModel;

namespace FloorChecker.Sensors
{
    public class Sensor : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        #region Тип
        private SensorTypes _type;
        [TypeConverter(typeof(EnumTypeConverter))]
        public SensorTypes Type
        {
            get => _type;
            set
            {
                _type = value;
                OnPropertyChanged(nameof(Type));
            }
        }
        #endregion

        #region Название
        private string _name;
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        #endregion

        #region Версия
        private int _version;
        public int Version
        {
            get => _version;
            set
            {
                _version = value;
                OnPropertyChanged(nameof(Version));
            }
        }
        #endregion
    }
}
