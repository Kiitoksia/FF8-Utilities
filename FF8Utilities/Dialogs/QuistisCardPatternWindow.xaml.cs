using FF8Utilities.Entities;
using LateQuistisManipulation.Models;
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
    /// Interaction logic for QuistisCardPatternWindow.xaml
    /// </summary>
    public partial class QuistisCardPatternWindow : MetroWindow
    {
        public QuistisCardPatternWindow(ZellCardCalculatorWindow window, LateQuistisPattern pattern)
        {
            InitializeComponent();
            DataContext = pattern;

            SubmitCommand = new Command<LateQuistisStrategy>(() => true, (s, e) =>
            {
                ResultHex = e.ResultHex;
                Close();
            });
        }

        public string ResultHex { get; private set; }

        public Command<LateQuistisStrategy> SubmitCommand { get; }
    }
}
