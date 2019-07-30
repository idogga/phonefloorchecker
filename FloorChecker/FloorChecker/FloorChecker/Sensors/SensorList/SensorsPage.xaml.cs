using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FloorChecker.Sensors.SensorList
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SensorsPage : ContentPage
    {
        public ObservableCollection<string> Items { get; set; }

        public SensorsPage()
        {
            InitializeComponent();
        }
    }
}
