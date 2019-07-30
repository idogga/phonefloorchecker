using FloorChecker.Sensors;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Xamarin.Forms;

namespace FloorChecker
{
    public class SensorsVM : INotifyPropertyChanged
    {
        public ObservableCollection<Sensor> Sensors { get; set; }

        public SensorsVM()
        {
            Sensors = new ObservableCollection<Sensor>(DependencyService.Get<ISensor>().GetAvailableSensors());

        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
