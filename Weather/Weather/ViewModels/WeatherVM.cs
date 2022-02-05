using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Weather.Models;
using Weather.Models.API;


namespace Weather.ViewModels
{
    public class WeatherVM : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public WeatherInfo WeatherInfo
        {
            get
            {
                return _weatherInfo;
            }
            private set
            {
                _weatherInfo = value;
                onPropertyChange(nameof(WeatherInfo));
            }
        }
        private WeatherInfo _weatherInfo { get; set; }

        public WeatherVM()
        {
        }

        void onPropertyChange(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


        public async System.Threading.Tasks.Task setWeatherInfoAsync(string city)
        {
            WeatherInfo = await new WeatherApi().getWeatherOfCity(city);
        }

    }
}
