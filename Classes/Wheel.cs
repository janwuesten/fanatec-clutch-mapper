using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace fanatec_clutch_mapper.Classes {
    public class Wheel {

        public string WheelID;
        public string LeftPedalID;
        public string RightPedalID;
        public string DeviceName;
        public int MaxPedalValue;

        public Wheel() {

        }
        public Wheel(string wheelID, string deviceName, string leftPedalID, string rightPedalID, int maxPedalValue) {
            WheelID = wheelID;
            DeviceName = deviceName;
            LeftPedalID = leftPedalID;
            RightPedalID = rightPedalID;
            MaxPedalValue = maxPedalValue;
        }

    }
}
