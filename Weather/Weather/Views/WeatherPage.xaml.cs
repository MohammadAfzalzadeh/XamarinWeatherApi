using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Weather.ViewModels;
using Rg.Plugins.Popup.Extensions;

namespace Weather.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class WeatherPage : ContentPage
    {
        WeatherVM weather;
        public WeatherPage()
        {
            InitializeComponent();
            weather = new WeatherVM();
            BindingContext = weather;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {

            if (cityTxt.Text != null && cityTxt.Text != "")
                try
                {
                await  weather.setWeatherInfoAsync(cityTxt.Text);

                    switch (weather.WeatherInfo.weather[0].icon)
                    {
                        case "01d":
                            WeatherImg.Animation = "sun.json";
                            break;
                        case "01n":
                            WeatherImg.Animation = "moon.json";
                            break;
                        case "02n":
                            WeatherImg.Animation = "moonCld.json";
                            break;
                        case "02d":
                            WeatherImg.Animation = "sunCld.json";
                            break;
                        case "03n":
                        case "03d":
                        case "04n":
                        case "04d":
                            WeatherImg.Animation = "cld.json";
                            break;
                        case "09n":
                        case "09d":
                            WeatherImg.Animation = "rain.json";
                            break;
                        case "10n":
                            WeatherImg.Animation = "moonRain.json";
                            break;
                        case "10d":
                            WeatherImg.Animation = "sunRain.json";
                            break;
                        case "11n":
                        case "11d":
                            WeatherImg.Animation = "rad.json";
                            break;
                        case "13n":
                        case "13d":
                            WeatherImg.Animation = "sonw.json";
                            break;
                        case "50n":
                        case "50d":
                            WeatherImg.Animation = "mist.json";
                            break;

                        default:
                            WeatherImg.Animation =
                            "https://openweathermap.org/img/wn/" 
                            + weather.WeatherInfo.weather[0].icon + "@2x.png";
                            break;
                    }

                }
                catch (System.Net.Http.HttpRequestException ex)
                {
                    if (ex.ToString().Contains("404"))
                        await Navigation.PushPopupAsync(new Popup.ErrPopupPage("This City isn't Exist"));
                        
                    else
                        await Navigation.PushPopupAsync(new Popup.ErrPopupPage("Can not connect to internet"));
                        
                       

                }
            else
                 await Navigation.PushPopupAsync(new Popup.ErrPopupPage("Please Enter a city name"));

        }
    }
}