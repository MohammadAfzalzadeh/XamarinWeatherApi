using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Weather.Models
{
    public class WeatherDescription
    {
        public string main { get; set; }
        public string description { get; set; }

        private string _icon { get; set; }
        public string icon {
            get {
                return _icon;
            }
            set {
                _icon = value;
                fullAddresIcon = "https://openweathermap.org/img/wn/"
                            + value + "@2x.png";
            }
        }

        public string fullAddresIcon { get; set; }

    }
}
