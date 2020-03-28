using System;
using System.Collections.Generic;
using System.Text;

namespace CoronaHelp.Models
{


    public class IndianData
    {
        public bool success { get; set; }
        public Data data { get; set; }
        public DateTime lastRefreshed { get; set; }
        public DateTime lastOriginUpdate { get; set; }
    }
    public class Summary
    {
        public int total { get; set; }
        public int confirmedCasesIndian { get; set; }
        public int confirmedCasesForeign { get; set; }
        public int discharged { get; set; }
        public int deaths { get; set; }
        public int confirmedButLocationUnidentified { get; set; }
    }

    public class Regional
    {
        public string loc { get; set; }
        public int confirmedCasesIndian { get; set; }
        public int confirmedCasesForeign { get; set; }
        public int discharged { get; set; }
        public int deaths { get; set; }
    }

    public class Data
    {
        public Summary summary { get; set; }
        public List<Regional> regional { get; set; }
    }


}
