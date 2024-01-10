using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMcraft_Library
{
    public interface ITextDataService
    {
        ExchangeTextModel ExchangeTextModel { get; }
        void InitDataList();
        void AddDataList(string DataName, int DataValue);
        void SaveDataList();
    }
}
