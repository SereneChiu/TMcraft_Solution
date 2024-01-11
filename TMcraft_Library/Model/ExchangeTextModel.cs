using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TMcraft_Library
{
    public class ExchangeTextModel
    {
        public string Version { get; set; } = "1.0";

        public BindingList<VariableModel> VariableModelList { get; set; } = new BindingList<VariableModel>();
    }
}
