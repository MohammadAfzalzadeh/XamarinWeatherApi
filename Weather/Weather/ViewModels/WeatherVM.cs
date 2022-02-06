using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using Weather.Models;
using Weather.Models.API;


namespace Weather.ViewModels
{
    public class WeatherVM : BaseVM
    {

        public WeatherVM()
        {
        }

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


        public async System.Threading.Tasks.Task setWeatherInfoAsync(string city)
        {
            WeatherInfo = await new WeatherApi().getWeatherOfCity(city);
        }

    }
}
