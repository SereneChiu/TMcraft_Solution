using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using TMcraft;
using TMcraft_Library;

namespace TMcraft_Toolbar_UserControl
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl, ITMcraftToolbarEntry
    {
        private TMcraftToolbarAPI mTMcraftToolbarAPI = null;
        private ITextDataService mTextService = new TextDataController();
        private VariableModel mVariable_Model = new VariableModel();

        public UserControl1()
        {
            InitializeComponent();

            mTextService.InitDataList();

            grid_value.AutoGenerateColumns = false;
            grid_value.ItemsSource = null;
            grid_value.ItemsSource = mTextService.ExchangeTextModel.VariableModelList;
     
            DataContext = mVariable_Model;

        }

        public void InitializeToolbar(TMcraftToolbarAPI Api)
        {
            mTMcraftToolbarAPI = Api;
        }

        private void btn_remove_Click(object sender, RoutedEventArgs e)
        {
            if (grid_value.SelectedIndex == -1) { return; }
            if (grid_value.SelectedIndex >= mTextService.ExchangeTextModel.VariableModelList.Count) { return; }

            mTextService.ExchangeTextModel.VariableModelList.RemoveAt(grid_value.SelectedIndex);
            mTextService.SaveDataList();
        }

        private void btn_add_value_Click(object sender, RoutedEventArgs e)
        {
            mTextService.AddDataList(mVariable_Model.Name, mVariable_Model.Value);
            mTextService.SaveDataList();
        }

    }
}