using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaHelp.Models.Dashboard
{
    public class LstCountryData
    {
        public string Country { get; set; }
        public string Cases { get; set; }
        public string TodayCases { get; set; }
        public string Deaths { get; set; }
        public string TodayDeaths { get; set; }
        //public int Recovered { get; set; }
        //public int Critical { get; set; }
    }
}
