using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace TMcraft_Library
{
    public class VariableModel : INotifyPropertyChanged
    {
        private string mName = "";
        private int mValue = 0;

        public string Name { get { return mName; } set { mName = value; NotifyPropertyChanged("Name"); } }
        public int Value { get { return mValue; } set { mValue = value; NotifyPropertyChanged("Value"); } }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
