using FF8Utilities.Common;
using FF8Utilities.Dialogs;
using FF8Utilities.Models;
using LateQuistisManipulation;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using UltimeciaManip;
using UltimeciaManip.Entities;

namespace FF8Utilities
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        private Style _unselectedStyle;
        private Style _selectedStyle;

        public MainWindow()
        {
            InitializeComponent();

            _unselectedStyle = (Style)this.FindResource("MahApps.Styles.Button.MetroSquare");
            _selectedStyle = (Style)this.FindResource("MahApps.Styles.Button.Dialogs.Accent");

            ConfigureAttackButtons(FirstSquallButton, FirstSquallCrossButton, FirstQuistisButton, FirstQuistisCrossButton, FirstDamageRoll, 0);
            ConfigureAttackButtons(SecondSquallButton, SecondSquallCrossButton, SecondQuistisButton, SecondQuistisCrossButton, SecondDamageRoll, 1);
            ConfigureAttackButtons(ThirdSquallButton, ThirdSquallCrossButton, ThirdQuistisButton, ThirdQuistisCrossButton, ThirdDamageRoll, 2);
        }

        private MainModel Model => (MainModel)DataContext;

        private void NumericUpDown_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double?> e)
        {
            NumericUpDown input = (NumericUpDown)sender;
            if (e.NewValue == null) return;
            if (e.NewValue < 0)
            {
                input.Value = 15;
                e.Handled = true;
            }
            else if (e.NewValue > 15)
            {
                input.Value = 0;
                e.Handled = true;
            }
        }

        private void ResetFishFinManip()
        {
            Model.FishFinManipPattern = FilterGroup.IsEnabled ? new string(' ', 16) : string.Empty;
            SetButtonsStyle(ButtonStandard, ButtonBackAttack, ButtonStruckFirst);
        }


        private void ConfigureAttackButtons(Button squallButton, Button squallButtonCross, Button quistisButton, Button quistisButtonCross, NumericUpDown dmgRoll, int attack)
        {
            // This is absolutely hideous and awful...don't do this.  Each Attack group instead should be a model with sub controls and returning their own string.
            // 1st attack index = 2
            // 2nd attack index = 7
            // 3rd attack index = 12

            int baseIndex;
            switch (attack)
            {
                case 0: baseIndex = 2; break;
                case 1: baseIndex = 7; break;
                case 2: baseIndex = 12; break;
                default: throw new NotImplementedException();
            }

            //if (attack > 1) requiredLength++;
            if (Model.FishFinManipPattern == null) Model.FishFinManipPattern = string.Empty;
            squallButton.Click += (s, e) =>
            {                
                SetButtonsStyle(squallButton, squallButtonCross, quistisButton, quistisButtonCross);
                Model.FishFinManipPattern = Model.FishFinManipPattern.Remove(baseIndex, 2).Insert(baseIndex, "ss");
                dmgRoll.Focus();
            };
            squallButtonCross.Click += (s, e) =>
            {
                SetButtonsStyle(squallButtonCross, squallButton, quistisButton, quistisButtonCross);
                Model.FishFinManipPattern = Model.FishFinManipPattern.Remove(baseIndex, 2).Insert(baseIndex, "qs");
                dmgRoll.Focus();
            };
            quistisButton.Click += (s, e) =>
            {
                SetButtonsStyle(quistisButton, squallButtonCross, quistisButtonCross, squallButton);
                Model.FishFinManipPattern = Model.FishFinManipPattern.Remove(baseIndex, 2).Insert(baseIndex, "qq");
                dmgRoll.Focus();
            };
            quistisButtonCross.Click += (s, e) =>
            {
                SetButtonsStyle(quistisButtonCross, squallButtonCross, quistisButton, squallButton);
                Model.FishFinManipPattern = Model.FishFinManipPattern.Remove(baseIndex, 2).Insert(baseIndex, "sq");
                dmgRoll.Focus();
            };

            dmgRoll.ValueChanged += (s, e) =>
            {
                string value = dmgRoll.Value == 0 ? string.Empty : dmgRoll.Value.ToString();
                Model.FishFinManipPattern = Model.FishFinManipPattern.Remove(baseIndex + 2, 2).Insert(baseIndex + 2, value.PadLeft(2, ' '));
            };

            Reset.Click += (s, e) =>
            {
                SetButtonsStyle(null, quistisButtonCross, squallButtonCross, quistisButton, squallButton);
                dmgRoll.Value = null;
            };

        }



        
        

        private void ButtonStandard_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            SetButtonsStyle(ButtonStandard, ButtonBackAttack, ButtonStruckFirst);
            Model.FishFinManipPattern = Model.FishFinManipPattern.Remove(0, 1).Insert(0, " ");
        }

        private void ButtonBackAttack_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            SetButtonsStyle(ButtonBackAttack, ButtonStandard, ButtonStruckFirst);
            Model.FishFinManipPattern = Model.FishFinManipPattern.Remove(0, 1).Insert(0, "b");
        }

        private void ButtonStruckFirst_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            SetButtonsStyle(ButtonStruckFirst, ButtonStandard, ButtonBackAttack);
            Model.FishFinManipPattern = Model.FishFinManipPattern.Remove(0, 1).Insert(0, "s");
        }

        private void SetButtonsStyle(Button selectedButton, params Button[] unselectedButtons)
        {
            if (selectedButton != null) selectedButton.Style = _selectedStyle;
            foreach (Button button in unselectedButtons) button.Style = _unselectedStyle;
        }

        private void UnlockManualEntryBox_Click(object sender, RoutedEventArgs e)
        {
            FilterGroup.IsEnabled = !FilterGroup.IsEnabled;
            LockIcon.Icon = FilterGroup.IsEnabled ? FontAwesome.WPF.FontAwesomeIcon.Unlock : FontAwesome.WPF.FontAwesomeIcon.Lock;
            FishFinTextBox.IsEnabled = !FilterGroup.IsEnabled;
            ResetFishFinManip();
        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            ResetFishFinManip();            
        }
    }
}
