using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TMcraft_Library
{
    [XmlRoot("GeneralVariableTable")]
    public class ExchangeTextData
    {
        [XmlElement("Version")]
        public string Version { get; set; } = "1.0";


        [XmlArray("Variables")]
        [XmlArrayItem("Variable")]
        public List<VariableData> VariableDataList { get; set; } = new List<VariableData>();
    }



    public class VariableData
    {
        [XmlAttribute("Name")]
        public string Name { get; set; } = "";

        [XmlAttribute("Value")]
        public int Value { get; set; } = 0;

    }
}
