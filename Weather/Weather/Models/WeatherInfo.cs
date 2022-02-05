using System;
using System.Collections.Generic;
using System.Text;

namespace Weather.Models
{
    public class WeatherInfo
    {
        private List<WeatherDescription> _weatherDes { get; set; }
        public List<WeatherDescription> weather
        {
            get
            {
                return _weatherDes;
            }
            set
            {
                _weatherDes = value;
            }
        }
        public Temprature main { get; set; }
        
        public string name { get; set; }
        public Wind wind { get; set; }
        public Cloud clouds { get; set; }

        private Country _sys
        {
            get;
            set;
        }
        public Country Sys
        {
            get
            {
                return _sys;
            }
            set
            {
                _sys = value;
               
            }
        }
    }
}
