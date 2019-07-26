using CoreLocation;
using CoreMotion;
using FloorChecker.iOS.Implement;
using FloorChecker.Sensors;
using Foundation;
using System;
using System.Diagnostics;
using Xamarin.Forms;

[assembly: Dependency(typeof(IOSPressure))]
namespace FloorChecker.iOS.Implement
{
    class IOSPressure : IPressureSensor
    {
        public Action<double> GetCurrentMeters { get; set; }
        private CLLocationManager _manager = new CLLocationManager();
        public IOSPressure()
        {
            _manager.RequestWhenInUseAuthorization();
            _manager.LocationsUpdated += (s, e) =>
             {
                 CLLocation location = e.Locations[0] as CLLocation;
                 Debug.WriteLine($"Current Floor: {location.Floor?.Level}");
             };
            if (CMAltimeter.IsRelativeAltitudeAvailable)
            {
                var altim = new CMAltimeter();
                altim.StartRelativeAltitudeUpdates(NSOperationQueue.CurrentQueue, (s,e)=>
                {
                    Debug.WriteLine($"altitude is {s.RelativeAltitude} pressure is {s.Pressure} timestamp is {s.Timestamp}");
                    var h = ((Math.Pow(101.325 / (double)s.Pressure, 1 / 5.257) - 1) * (27 + 273.15)) / 0.0065;
                    Debug.WriteLine($"height = {s.RelativeAltitude}");
                });
            }
            Start();
        }


        public bool IsAvailable()
        {
            return _manager.AllowsBackgroundLocationUpdates;
        }

        public void Start()
        {
            _manager.StartUpdatingLocation();
        }

        public void Stop()
        {
            _manager.StopUpdatingLocation();
        }
    }
}
