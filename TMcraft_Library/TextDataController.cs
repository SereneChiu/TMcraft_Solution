namespace TMcraft_Library
{
    public class TextDataController : ITextDataService
    {
        private ExchangeTextModel mExchangeTextModel = new ExchangeTextModel();

        public ExchangeTextModel ExchangeTextModel { get { return mExchangeTextModel; } set { mExchangeTextModel = value; } }
    
        public void InitDataList()
        {
            TextDataFactory.GetFileData(this);
        }

        public void AddDataList(string DataName, int DataValue)
        {
            mExchangeTextModel.VariableModelList.Add(new VariableModel() { Name = DataName, Value = DataValue });
        }

        public void SaveDataList()
        {
            TextDataFactory.SaveDataToFile(this);
        }


    }
}