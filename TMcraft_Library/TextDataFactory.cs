using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;

namespace TMcraft_Library
{
    public static class TextDataFactory
    {
        public static string FileName_Xml = "TMcraft_Exchange_Data.xml";
        public static string FileName_Txt = "..\\..\\..\\TextFiles\\TMcraft_Exchange_Data.txt";
        public static string Target_Folder = "..\\..\\..\\TextFiles";

        private static void CheckTextFolder()
        {
            if (Directory.Exists(Target_Folder)) { return; }

            Directory.CreateDirectory(Target_Folder);
        }

        public static void GetFileData(ITextDataService DataService)
        {
            CheckTextFolder();

            if (File.Exists(FileName_Txt) == false)
            {
                using (var stream = File.Create(FileName_Txt))
                {
                    // Use stream
                }
            }

            File.Copy(FileName_Txt, FileName_Xml, true);

            if (File.Exists(FileName_Xml) == false) { return; }

            XmlSerializer serializer = new XmlSerializer(typeof(ExchangeTextData));
            XmlReader reader = XmlReader.Create(FileName_Xml);

            ExchangeTextData data = new ExchangeTextData();

            try
            {

                if (serializer.CanDeserialize(reader) == false)
                {
                    reader.Close();
                    return;
                }

                data = (ExchangeTextData)serializer.Deserialize(reader);
            }
            catch { }

            reader.Close();

            foreach (VariableData p in data.VariableDataList)
            {
                DataService.AddDataList(p.Name, p.Value);
            }
        }

        public static void SaveDataToFile(ITextDataService Data)
        {
            // Creates an instance of the XmlSerializer class;
            // specifies the type of object to serialize.
            XmlSerializer serializer = new XmlSerializer(typeof(ExchangeTextData));
            TextWriter writer = new StreamWriter(FileName_Xml);
            serializer.Serialize(writer, GenerateSerializeData(Data));
            writer.Close();

            if (File.Exists(FileName_Xml) == false) { File.Create(FileName_Xml); }
            File.Copy(FileName_Xml, FileName_Txt, true);
            File.Delete(FileName_Xml);
        }

        private static ExchangeTextData GenerateSerializeData(ITextDataService DataService)
        {
            ExchangeTextData serializeData = new ExchangeTextData();

            foreach (VariableModel dataModel in DataService.ExchangeTextModel.VariableModelList)
            {
                VariableData data = new VariableData()
                {
                    Name = dataModel.Name,
                    Value = dataModel.Value
                };
                serializeData.VariableDataList.Add(data);
            }
            return serializeData;
        }
    }

}
