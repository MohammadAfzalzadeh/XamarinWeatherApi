using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.Threading.Tasks;

namespace Weather.Models.API
{
    public class WeatherApi : BaseApi<WeatherInfo>
    {
        private const string appId = "0d8c64558b400891c2795bf8b2beb068";

        public WeatherApi() 
            : base("http://api.openweathermap.org/data/2.5/weather")
        {
            getParameters.Add("appid", appId);
        }

        public async Task<WeatherInfo> getWeatherOfCity(string city)
        {
            getParameters.Add("q", city);
            return await sendGetReqAndDeserialize();
        }

        
    }

}
