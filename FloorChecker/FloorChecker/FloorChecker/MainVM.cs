using FloorChecker.Sensors;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace FloorChecker
{
    public class MainVM : INotifyPropertyChanged
    {
        public ObservableCollection<Sensor> Sensors { get; set; }
        private BarometrCalculator _barometr;
        IPressureSensor _pressure;
        IAccelerometr _accelerometr;
        private AccelerationCalculator _acceleration;

        public MainVM()
        {
            Sensors = new ObservableCollection<Sensor>(DependencyService.Get<ISensor>().GetAvailableSensors());
            _pressure = DependencyService.Get<IPressureSensor>();
            Barometer.ReadingChanged += Barometer_ReadingChanged;
            _pressure.GetCurrentMeters += CurrentHeight;
            _accelerometr = DependencyService.Get<IAccelerometr>();
            _accelerometr.GetCurrentAcceleration += AccelerationChanged;
            _barometr = new BarometrCalculator();
            _barometr.HeightChanged += BarometrChanged;
            _acceleration = new AccelerationCalculator();
            _acceleration.HeightChanged += HeightChanged;
            Barometer.Start(SensorSpeed.Fastest);
        }

        private void Barometer_ReadingChanged(object sender, BarometerChangedEventArgs e)
        {
            _barometr.OnCurrentMeters(new HeightCalculator(27, e.Reading.PressureInHectopascals).Height);
        }

        private void HeightChanged()
        {
            Debug.WriteLine($"{DateTime.Now.Ticks}\tизмение крутой высоты {CoolHeight}");
            Device.BeginInvokeOnMainThread(() => OnPropertyChanged(nameof(CoolHeight)));
        }

        private void AccelerationChanged(double x, double y, double z)
        {
            _acceleration.OnCurrentMeters(x, y, z);
        }

        public void BarometrChanged()
        {
            Debug.WriteLine($"измение высоты {Height}");
            Device.BeginInvokeOnMainThread(() => OnPropertyChanged(nameof(Height)));
        }

        private void CurrentHeight(double obj)
        {
            _barometr.OnCurrentMeters(obj);
        }

        public double CoolHeight { get=>_acceleration.Height; set { } }
        public double Height { get => _barometr.Height; set { } }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
