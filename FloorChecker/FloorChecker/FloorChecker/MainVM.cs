using FloorChecker.Sensors;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using Xamarin.Forms;

namespace FloorChecker
{
    public class MainVM : INotifyPropertyChanged
    {
        public ObservableCollection<Sensor> Sensors { get; set; }
        private BarometrCalculator _barometr;
        IPressureSensor _pressure;

        public MainVM()
        {
            Sensors = new ObservableCollection<Sensor>(DependencyService.Get<ISensor>().GetAvailableSensors());
            _pressure = DependencyService.Get<IPressureSensor>();
            _pressure.GetCurrentMeters += CurrentHeight;
            _barometr = new BarometrCalculator(_pressure.GetCurrentMeters);
            _barometr.HeightChanged += BarometrChanged;
        }

        public void BarometrChanged()
        {
            Debug.WriteLine($"измение высоты {Height}");
            OnPropertyChanged(nameof(Height));
        }

        private void CurrentHeight(double obj)
        {
            Debug.WriteLine($"Текущая высота пользователя = {obj}");
        }

        public double CoolHeight { get; set; }
        public double Height { get => _barometr.Height; set { } }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
