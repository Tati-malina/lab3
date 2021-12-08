using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Xml.Serialization;

namespace lab3
{
    class Serializator
    {
        #region bin
        public void BinSerialisation(object obj)
        {
            var binFormatter = new BinaryFormatter();
            using (var file = new FileStream("data.bin", FileMode.OpenOrCreate))
            {
                binFormatter.Serialize(file, obj);
            }
        }
        public TheString[] BinDeSerialisation(TheString[] obj)
        {
            var binFormatter = new BinaryFormatter();
            using (var file = new FileStream("data.bin", FileMode.OpenOrCreate))
            {
                obj = binFormatter.Deserialize(file) as TheString[];
            }
            return obj;
        }
        #endregion

        #region xml
        public void XMLSerialisation(object obj)
        {
            var xmlFormatter = new XmlSerializer(typeof(TheString[]));
            using (var file = new FileStream("data.xml", FileMode.OpenOrCreate))
            {
                xmlFormatter.Serialize(file, obj);
            }
        }
        public TheString[] XMLDeSerialisation(TheString[] obj)
        {
            var xmlFormatter = new XmlSerializer(typeof(TheString[]));
            using (var file = new FileStream("data.xml", FileMode.OpenOrCreate))
            {
                obj = xmlFormatter.Deserialize(file) as TheString[];
            }
            return obj;
        }
        #endregion

        #region json
        public void JSONSerialisation(object obj)
        {
            var jsonFormatter = new DataContractJsonSerializer(typeof(TheString[]));
            using (var file = new FileStream("data.json", FileMode.OpenOrCreate))
            {
                jsonFormatter.WriteObject(file, obj);
            }
        }
        public TheString[] JSONDeSerialisation(TheString[] obj)
        {
            var jsonFormatter = new DataContractJsonSerializer(typeof(TheString[]));
            using (var file = new FileStream("data.json", FileMode.OpenOrCreate))
            {
                obj = jsonFormatter.ReadObject(file) as TheString[];
            }
            return obj;
        }

        #endregion

        #region custom
        public void CustomSerialisation(object obj)
        {
            var binFormatter = new BinaryFormatter();
            using (var file = new FileStream("data.myData", FileMode.OpenOrCreate))
            {
                binFormatter.Serialize(file, obj);
            }
        }
        public List<CustomString> CustomDeSerialisation(List<CustomString> obj)
        {
            var binFormatter = new BinaryFormatter();
            using (var file = new FileStream("data.myData", FileMode.OpenOrCreate))
            {
                obj = binFormatter.Deserialize(file) as List<CustomString>;
            }
            return obj;
        }
        #endregion
    }
}
