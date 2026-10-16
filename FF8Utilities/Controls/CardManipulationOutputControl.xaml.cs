using FF8Utilities.Models;
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
using System.Windows.Threading;

namespace FF8Utilities.Controls
{
    /// <summary>
    /// Interaction logic for CardManipulationOutputControl.xaml
    /// </summary>
    public partial class CardManipulationOutputControl : UserControl
    {
        public CardManipulationOutputControl()
        {
            InitializeComponent();
            Loaded += CardManipulationOutputControl_Loaded;
            Unloaded += CardManipulationOutputControl_Unloaded;
        }

        private CardManipulationModel Model => (CardManipulationModel)DataContext;

        private IDisposable _globalHotkeySubscription;

        /// <summary>
        /// Refocuses the recovery box whenever the given tab control changes tab (e.g. switching starts/frames).
        /// Refocuses after the event as the clicked tab takes focus once the selection has changed.
        /// </summary>
        public void RefocusRecoveryBoxOnTabChange(TabControl tabControl)
        {
            tabControl.SelectionChanged += (s, e) =>
            {
                // SelectionChanged bubbles up from any selector inside the tabs, only react to the tab control itself
                if (e.OriginalSource != tabControl) return;

                Dispatcher.BeginInvoke(new Action(() => RecoveryTextBox.Focus()), DispatcherPriority.Input);
            };
        }

        private void CardManipulationOutputControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (SettingsModel.Instance.GlobalHotkeysEnabled && _globalHotkeySubscription == null)
            {
                _globalHotkeySubscription = GlobalKeyboardHook.Subscribe(OnGlobalKey);
            }
        }

        private void CardManipulationOutputControl_Unloaded(object sender, RoutedEventArgs e)
        {
            _globalHotkeySubscription?.Dispose();
            _globalHotkeySubscription = null;
        }

        /// <summary>
        /// Only raised whilst another application (i.e. FF8) has focus
        /// </summary>
        private void OnGlobalKey(GlobalKey key, char? digit)
        {
            if (!(DataContext is CardManipulationModel)) return;

            switch (key)
            {
                case GlobalKey.Digit:
                    if (RecoveryTextBox.IsEnabled && digit.HasValue) InsertDigit(RecoveryTextBox, digit.Value);
                    break;
                case GlobalKey.Backspace:
                    if (RecoveryTextBox.IsEnabled) DeleteDigit(RecoveryTextBox, forward: false);
                    break;
                case GlobalKey.Enter:
                    Model.SubmitCommand.Execute(null);
                    break;
            }
        }

        private void UserControl_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Model.SubmitCommand.Execute(null);
            }
        }

        private string GetDigitsOnly(string input)
        {
            return new string(input.Where(char.IsDigit).ToArray());
        }

        private string FormatOutput(string digits)
        {
            return string.Join("-", Enumerable.Range(0, digits.Length / 4 + 1)
                .Select(i => digits.Skip(i * 4).Take(4))
                .Where(g => g.Any())
                .Select(g => new string(g.ToArray())));
        }

        private int GetDigitInsertIndex(string formattedText, int caretIndex)
        {
            // Count how many digits are before the caret
            int count = 0;
            for (int i = 0; i < caretIndex && i < formattedText.Length; i++)
            {
                if (char.IsDigit(formattedText[i])) count++;
            }
            return count;
        }

        private int GetNextCaretIndex(string formattedText, int digitIndex)
        {
            // Find where the caret should be after inserting digitIndex digits
            int count = 0;
            for (int i = 0; i < formattedText.Length; i++)
            {
                if (char.IsDigit(formattedText[i])) count++;
                if (count == digitIndex) return i + 1;
            }
            return formattedText.Length;
        }


        private void RecoveryTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox == null)
                return;

            e.Handled = !char.IsDigit(e.Text, 0); // Only allow digits

            if (!e.Handled)
            {
                if (GetDigitsOnly(textBox.Text).Length >= 20) return;

                InsertDigit(textBox, e.Text[0]);
                e.Handled = true;
            }
        }

        private void RecoveryTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox == null) return;

            if (e.Key == Key.Back || e.Key == Key.Delete)
            {
                if (DeleteDigit(textBox, forward: e.Key == Key.Delete))
                {
                    e.Handled = true;
                }
            }
        }

        private void InsertDigit(TextBox textBox, char digit)
        {
            string unformatted = GetDigitsOnly(textBox.Text);
            if (unformatted.Length >= 20) return;

            // Insert the new character at the correct location
            int insertIndex = GetDigitInsertIndex(textBox.Text, textBox.CaretIndex);
            unformatted = unformatted.Insert(insertIndex, digit.ToString());

            textBox.Text = FormatOutput(unformatted);
            textBox.CaretIndex = GetNextCaretIndex(textBox.Text, insertIndex + 1);
        }

        /// <summary>
        /// Removes the digit before (backspace) or after (delete) the caret.  Returns false if there was nothing to remove.
        /// </summary>
        private bool DeleteDigit(TextBox textBox, bool forward)
        {
            string digits = GetDigitsOnly(textBox.Text);
            int digitIndex = GetDigitInsertIndex(textBox.Text, textBox.CaretIndex);

            if (digitIndex > 0 && !forward)
            {
                digits = digits.Remove(digitIndex - 1, 1);
                textBox.Text = FormatOutput(digits);
                textBox.CaretIndex = GetNextCaretIndex(textBox.Text, digitIndex - 1);
                return true;
            }
            else if (digitIndex < digits.Length && forward)
            {
                digits = digits.Remove(digitIndex, 1);
                textBox.Text = FormatOutput(digits);
                textBox.CaretIndex = GetNextCaretIndex(textBox.Text, digitIndex);
                return true;
            }

            return false;
        }
    }
}
