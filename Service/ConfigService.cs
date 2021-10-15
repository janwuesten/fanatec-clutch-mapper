using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using fanatec_clutch_mapper.Classes;

namespace fanatec_clutch_mapper.Service {
    class ConfigService {

        public Configuration Configuration { private set; get; }
        public Wheel Wheel;
        private string filename;

        public ConfigService(string filename) {
            this.filename = filename;
            Configuration = new Configuration();
            CreateDefaultWheels();
        }
        public void Save() {
            XmlSerializer ser = new XmlSerializer(typeof(Configuration));
            TextWriter writer = new StreamWriter(filename);
            ser.Serialize(writer, Configuration);
            writer.Close();
        }
        public void CreateDefaultWheels() {
            if (!Directory.Exists("wheels")) {
                Directory.CreateDirectory("wheels");
            }
            SaveWheel(new Wheel("fanatec.formula.apm", "fanatec", "RotationX", "RotationY", 65535));
        }
        private void SaveWheel(Wheel wheel) {
            XmlSerializer ser = new XmlSerializer(typeof(Wheel));
            TextWriter writer = new StreamWriter(Path.Combine("wheels", wheel.WheelID + ".xml"));
            ser.Serialize(writer, wheel);
            writer.Close();
        }
        public void Read() {
            XmlSerializer ser = new XmlSerializer(typeof(Configuration));
            TextReader reader = new StreamReader(filename);
            Configuration = (Configuration) ser.Deserialize(reader);
            reader.Close();

            ser = new XmlSerializer(typeof(Wheel));
            reader = new StreamReader(Path.Combine("wheels", Configuration.WheelID + ".xml"));
            Wheel = (Wheel)ser.Deserialize(reader);
            reader.Close();
        }
        public bool Exists() {
            return File.Exists(filename);
        }

    }
}
