using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaHelp.Models.Dashboard
{
    public class CountryData
    {
        public string Country { get; set; }
        public int Cases { get; set; }
        public int TodayCases { get; set; }
        public int Deaths { get; set; }
        public int TodayDeaths { get; set; }
        public int Recovered { get; set; }
        public int Critical { get; set; }
    }
}
