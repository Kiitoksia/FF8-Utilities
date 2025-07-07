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
        }

        private CardManipulationModel Model => (CardManipulationModel)DataContext;

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
                int caretIndex = textBox.CaretIndex;
                string unformatted = GetDigitsOnly(textBox.Text);
                if (unformatted.Length >= 20) return;

                // Insert the new character at the correct location
                int insertIndex = GetDigitInsertIndex(textBox.Text, caretIndex);
                unformatted = unformatted.Insert(insertIndex, e.Text);

                textBox.Text = FormatOutput(unformatted);
                textBox.CaretIndex = GetNextCaretIndex(textBox.Text, insertIndex + 1);
                e.Handled = true;
            }
        }

        private void RecoveryTextBox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox == null) return;

            if (e.Key == Key.Back || e.Key == Key.Delete)
            {
                int caretIndex = textBox.CaretIndex;
                string digits = GetDigitsOnly(textBox.Text);
                int digitIndex = GetDigitInsertIndex(textBox.Text, caretIndex);

                if (digitIndex > 0 && e.Key == Key.Back)
                {
                    digits = digits.Remove(digitIndex - 1, 1);
                    textBox.Text = FormatOutput(digits);
                    textBox.CaretIndex = GetNextCaretIndex(textBox.Text, digitIndex - 1);
                    e.Handled = true;
                }
                else if (digitIndex < digits.Length && e.Key == Key.Delete)
                {
                    digits = digits.Remove(digitIndex, 1);
                    textBox.Text = FormatOutput(digits);
                    textBox.CaretIndex = GetNextCaretIndex(textBox.Text, digitIndex);
                    e.Handled = true;
                }
            }
        }
    }
}
