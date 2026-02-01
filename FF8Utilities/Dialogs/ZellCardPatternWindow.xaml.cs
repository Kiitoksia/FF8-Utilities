using FF8Utilities.Models;
using MahApps.Metro.Controls;
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
using System.Windows.Shapes;
using CardPattern = FF8Utilities.Common.Cards.CardPosition;
using FF8Utilities.Common.Cards;

namespace FF8Utilities.Dialogs
{
    /// <summary>
    /// Interaction logic for ZellCardPatternWindow.xaml
    /// </summary>
    public partial class ZellCardPatternWindow : MetroWindow
    {
        public ZellCardPatternWindow(CardManipulationModel manip)
        {
            InitializeComponent();
            string title = $"Zell Card Patterns (Quistis Outcome: {manip.State.ToString("X")}";
            if (manip.Count > 0) title += $" - RNG Index: {manip.Count}";
            title += ")";
            this.Title = title;
            CardControl.DataContext = manip;

            CardControl.RecoveryTextBox.Focus();

            // Hardcoded positions
            PlayerFormation.ItemsSource = CardPattern.ZellPlayerFirstPositions;
            MomFormation.ItemsSource = CardPattern.ZellMomFirstPositionsWeak;
            MomFormation2.ItemsSource = CardPattern.ZellMomFirstPositionsStrong;
        }
    }
}
