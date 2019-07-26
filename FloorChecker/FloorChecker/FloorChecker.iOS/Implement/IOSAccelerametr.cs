using FloorChecker.iOS.Implement;
using FloorChecker.Sensors;
using System;
using Xamarin.Forms;

[assembly: Dependency(typeof(IOSAccelerametr))]
namespace FloorChecker.iOS.Implement
{
    class IOSAccelerametr : IAccelerometr
    {
        public Action<double, double, double> GetCurrentAcceleration { get; set; }

        public bool IsAvailable()
        {
            return false;
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }
    }
}