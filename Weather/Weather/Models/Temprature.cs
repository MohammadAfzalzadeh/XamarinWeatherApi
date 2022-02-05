using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Weather.Models
{
    public class Temprature
    {
        private string _temprature { get; set; }
        public string temprature
        {
            get
            {
                return _temprature;
            }
            set
            {
                _temprature = value + (char)186;
            }
        }
        private decimal _temp { get; set; }
        public decimal temp
        {
            get { return _temp; }
            set { _temp = value - (decimal)273.23;
                temprature = ((int)_temp).ToString();
            }
        }
        public decimal temp_min { get; set; }
        public decimal temp_max { get; set; }

    }
}
