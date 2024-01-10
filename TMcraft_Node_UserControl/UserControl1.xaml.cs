using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TMcraft;
using TMcraft_Library;

namespace TMcraft_Node_UserControl
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl, ITMcraftNodeEntry
    {
        private TMcraftNodeAPI mTMcraftNodeAPI;
        private ScriptWriteProvider mScriptWriteProvider;
        private ITextDataService mTextService = new TextDataController();

        private string mTargetValue = "";

        public UserControl1()
        {
            InitializeComponent();

            mTextService.InitDataList();

            grid_value.AutoGenerateColumns = false;
            grid_value.ItemsSource = null;
            grid_value.ItemsSource = mTextService.ExchangeTextModel.VariableModelList;

            UpdateSelectValue();
        }

        public void InitializeNode(TMcraftNodeAPI NodeAPI)
        {
            mTMcraftNodeAPI = NodeAPI;
            string rtn_data = "";
            mTMcraftNodeAPI.DataStorageProvider.GetData("TargetValue", out rtn_data);

            if (rtn_data == "") { return; }
            tb_target.Text = rtn_data;
        }

        public void InscribeScript(ScriptWriteProvider WriteProvider)
        {
            mScriptWriteProvider = WriteProvider;
            Dictionary<string, string> save_data = new Dictionary<string, string>();
            save_data.Add("TargetValue", mTargetValue);
            mTMcraftNodeAPI?.DataStorageProvider.SaveData(save_data);
            mTMcraftNodeAPI?.Close();
        }

        private void btn_Cancel_Click(object sender, RoutedEventArgs e)
        {
            mTMcraftNodeAPI?.Close();
        }

        private void btn_OK_Click(object sender, RoutedEventArgs e)
        {
            int rtn_int = 0;
            if (false == int.TryParse(tb_target.Text, out rtn_int))
            {
                MessageBox.Show(string.Format("Target value invalid ({0})", tb_target.Text));

                mTMcraftNodeAPI?.Close();
            }
            mTargetValue = rtn_int.ToString();
            mTMcraftNodeAPI?.Close();
        }

        private void btn_copy_Click(object sender, RoutedEventArgs e)
        {
            UpdateSelectValue();
        }

        private void UpdateSelectValue()
        {
            if (grid_value.SelectedIndex == -1) { grid_value.SelectedIndex = 0; }
            if (grid_value.SelectedIndex >= mTextService.ExchangeTextModel.VariableModelList.Count) { return; }

            tb_target.Text = (mTextService.ExchangeTextModel.VariableModelList[grid_value.SelectedIndex].Value).ToString();
        }
    }
}