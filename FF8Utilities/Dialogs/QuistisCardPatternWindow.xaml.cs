using CardManipulation;
using FF8Utilities.Common.Cards;
using FF8Utilities.Entities;
using FF8Utilities.Models;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace FF8Utilities.Dialogs
{
    /// <summary>
    /// Interaction logic for QuistisCardPatternWindow.xaml
    /// </summary>
    public partial class QuistisCardPatternWindow : MetroWindow
    {
        private List<LateQuistisStrategy> _strategies;

        private bool _didSubmit;

        public QuistisCardPatternWindow(ZellCardCalculatorWindow window, LateQuistisPattern pattern)
        {
            InitializeComponent();
            DataContext = pattern;

            CardManip manip = new CardManip();
            _manipModel = new CardManipulationModel(manip, 0, "fc01", SettingsModel.Instance.GetZellDelayFrame(), pattern.RNGIndex);

            CardManipControl.DataContext = _manipModel;
            CardManipControl.RecoveryTextBox.Focus();
            _strategies = pattern.Strategies;
            SubmitCommand = new Command<LateQuistisStrategy>(() => true, (s, e) =>
            {
                ResultHex = e.ResultHex;
                _didSubmit = true;
                this.Invoke(async () =>
                {
                    await this.ShowMessageAsync("Outcome saved", "Continue as normal for zell tracking\r\nOr close tracker entirely for 2nd try zell");
                    Close();
                });
            });
            
            ChangeOrderingCommand = new Command<QuistisPatternsOrderBy>(() => true, (s, e) =>
            {
                SettingsModel.Instance.QuistisPatternsOrderBy = e;
                SettingsModel.Instance.Save();
                OrderList();
            });

            OrderList();

            Closed += (s, e) =>
            {
                _manipModel.Dispose();
            };
        }

        private CardManipulationModel _manipModel;

        private void OrderList()
        {
            BindingList<LateQuistisStrategy> orderedStrategies = new BindingList<LateQuistisStrategy>();

            List<LateQuistisStrategy> orderedList = _strategies;

            RadioButtonAlphabetical.IsChecked = SettingsModel.Instance.QuistisPatternsOrderBy == QuistisPatternsOrderBy.Alphabetical;
            RadioButtonFrame.IsChecked = SettingsModel.Instance.QuistisPatternsOrderBy == QuistisPatternsOrderBy.Frame;
            switch (SettingsModel.Instance.QuistisPatternsOrderBy)
            {
                case QuistisPatternsOrderBy.Frame:
                    orderedList = orderedList.OrderBy(t => t.Frame).ToList();
                    break;
                case QuistisPatternsOrderBy.Alphabetical:
                    orderedList = orderedList.OrderBy(t => t.OpponentDeckOrderer).ToList();
                    break;
            }

            Tabs.ItemsSource = new BindingList<LateQuistisStrategy>(orderedList);
        }

        public string ResultHex { get; private set; }

        public Command<LateQuistisStrategy> SubmitCommand { get; }

        public Command<QuistisPatternsOrderBy> ChangeOrderingCommand { get; }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            if (!_didSubmit)
            {
                if (MessageBox.Show("No outcome was submitted, are you sure you want to close?", "Warning", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                {
                    e.Cancel = true;
                    return;
                }
            }
        }
    }
}
