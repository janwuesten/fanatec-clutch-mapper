using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fanatec_clutch_mapper.Classes {
    public class Configuration {

        public int ConfigurationVersion = 1;

        public string WheelID = "fanatec.formula.apm";

        public double FullPressThreshold = 85;

        public string LeftShortKey = "i";
        public string LeftPressKey = "k";

        public string RightShortKey = "o";
        public string RightPressKey = "l";

    }
}
