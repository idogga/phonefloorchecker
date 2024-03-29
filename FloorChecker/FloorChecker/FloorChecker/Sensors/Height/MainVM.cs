﻿using FloorChecker.Sensors;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace FloorChecker
{
    public class MainVM : INotifyPropertyChanged
    {

        private const int _metersPerFloor = 2;
        private BarometrCalculator _barometr;
        private AccelerationCalculator _acceleration;
        private GeoCalculator _geo;

        public ICommand SeeDevices { get; }


        public MainVM()
        {
            Barometer.ReadingChanged += Barometer_ReadingChanged;
            _barometr = new BarometrCalculator();
            _geo = new GeoCalculator();
            _barometr.HeightChanged += BarometrChanged;
            _geo.HeightChanged += GeoChanged;
            _acceleration = new AccelerationCalculator();
            _acceleration.HeightChanged += HeightChanged;
            OrientationSensor.ReadingChanged += OrientationChanged;
            Accelerometer.ReadingChanged += AccelerometerChanged;
            try
            {
                Accelerometer.Start(SensorSpeed.UI);
            }
            catch (Exception e)
            {
                SpeakException(e);
            }
            try
            {
                Barometer.Start(SensorSpeed.Default);
            }
            catch (Exception e)
            {
                SpeakException(e);
            }
            try
            {
                OrientationSensor.Start(SensorSpeed.Fastest);
            }
            catch (Exception e)
            {
                SpeakException(e);
            }
            Device.StartTimer(TimeSpan.FromMilliseconds(300), () => { UpdateLocation(); return true; });
            SeeDevices = new Command(() => App.Current.MainPage.Navigation.PushAsync(new Sensors.SensorList.SensorsPage()));
        }

        private void SpeakException(Exception e)
        {
            var settings = new SpeechOptions()
            {
                Volume = .75f,
                Pitch = 1.0f
            };

            TextToSpeech.SpeakAsync(e.Message, settings);
        }

        private void GeoChanged()
        {
            Debug.WriteLine($"измение высоты {AltitudeHeight}");
            Device.BeginInvokeOnMainThread(() => OnPropertyChanged(nameof(AltitudeHeight)));
        }

        private async void UpdateLocation()
        {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.Medium);
                var location = await Geolocation.GetLocationAsync(request);

                if (location != null)
                {
                    _geo.Calculate(location.Altitude);
                }
            }
            catch (Exception e)
            {
                SpeakException(e);
            }
        }

        private void OrientationChanged(object sender, OrientationSensorChangedEventArgs e)
        {
            _acceleration.OrientationChanged(e.Reading.Orientation);
        }

        private void AccelerometerChanged(object sender, AccelerometerChangedEventArgs e)
        {
            _acceleration.OnCurrentMeters(e.Reading.Acceleration.X, e.Reading.Acceleration.Y, e.Reading.Acceleration.Z);
        }

        private void Barometer_ReadingChanged(object sender, BarometerChangedEventArgs e)
        {
            _barometr.OnCurrentMeters(new HeightCalculator(e.Reading.PressureInHectopascals).Height);
        }

        private void HeightChanged()
        {
            Device.BeginInvokeOnMainThread(() => OnPropertyChanged(nameof(CoolHeight)));
        }

        public void BarometrChanged()
        {
            Debug.WriteLine($"измение высоты {Height}");
            Device.BeginInvokeOnMainThread(() => OnPropertyChanged(nameof(Height)));
        }

        public string CoolHeight { get => (_acceleration.Height / _metersPerFloor).ToString("0.##"); set { } }
        public string Height { get => (_barometr.Height / _metersPerFloor).ToString("0.##"); set { } }
        public string AltitudeHeight { get => (_geo.Height / _metersPerFloor).ToString("0.##"); set { } }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string property)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}
