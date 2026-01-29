using FF8Utilities.Common.Cards;
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
            List<LateQuistisPosition> playerPositions = new List<LateQuistisPosition>
            {
                new LateQuistisPosition(1, false, 0, GameScenario.GetCardImage("empty")),
                new LateQuistisPosition(2, false, 0, GameScenario.GetCardImage("empty")),
                new LateQuistisPosition(3, true, 5, GameScenario.GetCardImage("q")),
                new LateQuistisPosition(4, true, 4, GameScenario.GetCardImage("m")),
                new LateQuistisPosition(5, false, 0, GameScenario.GetCardImage("empty")),
                new LateQuistisPosition(6, false, 1, GameScenario.GetCardImage("z")),
                new LateQuistisPosition(7, true, 3, GameScenario.GetCardImage("i")),
                new LateQuistisPosition(8, true, 2, GameScenario.GetCardImage("g")),
                new LateQuistisPosition(9, true, 1, GameScenario.GetCardImage("b")),
            };
            PlayerFormation.ItemsSource = playerPositions;

            List<LateQuistisPosition> opponentPositions1 = new List<LateQuistisPosition>
            {
                new LateQuistisPosition(1, false, 1, GameScenario.GetCardImage("z")),
                new LateQuistisPosition(2, false, 0, GameScenario.GetCardImage("empty"), "#", "= 1", "#", "#"),
                new LateQuistisPosition(3, true, 4, GameScenario.GetCardImage("q")),
                new LateQuistisPosition(4, true, 3, GameScenario.GetCardImage("m")),
                new LateQuistisPosition(5, false, 0, GameScenario.GetCardImage("empty")),
                new LateQuistisPosition(6, false, 0, GameScenario.GetCardImage("empty")),
                new LateQuistisPosition(7, false, 0, GameScenario.GetCardImage("empty")),
                new LateQuistisPosition(8, true, 2, GameScenario.GetCardImage("i")),
                new LateQuistisPosition(9, true, 1, GameScenario.GetCardImage("g")),
            };
            MomFormation.ItemsSource = opponentPositions1;

            List<LateQuistisPosition> opponentPositions2 = new List<LateQuistisPosition>
            {
                new LateQuistisPosition(1, false, 1, GameScenario.GetCardImage("z")),
                new LateQuistisPosition(2, false, 0, GameScenario.GetCardImage("empty"), "#", "2+", "#", "#"),
                new LateQuistisPosition(3, true, 3, GameScenario.GetCardImage("b")),
                new LateQuistisPosition(4, false, 0, GameScenario.GetCardImage("empty")),
                new LateQuistisPosition(5, true, 4, GameScenario.GetCardImage("q")),
                new LateQuistisPosition(6, false, 0, GameScenario.GetCardImage("empty")),
                new LateQuistisPosition(7, false, 0, GameScenario.GetCardImage("empty")),
                new LateQuistisPosition(8, true, 2, GameScenario.GetCardImage("i")),
                new LateQuistisPosition(9, true, 1, GameScenario.GetCardImage("g")),
            };

            MomFormation2.ItemsSource = opponentPositions2;

        }
    }
}
