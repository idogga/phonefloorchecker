using System.Collections.ObjectModel;
using System.ComponentModel;
using FloorChecker.Sensors;
using Xamarin.Forms;

namespace FloorChecker
{
    public class MainVM : INotifyPropertyChanged
    {
        public ObservableCollection<Sensor> Sensors { get; set; }

        public MainVM()
        {
            Sensors = new ObservableCollection<Sensor>(DependencyService.Get<ISensor>().GetAvailableSensors());
        }

        public double CoolHeight { get; set; }
        public double Height { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
