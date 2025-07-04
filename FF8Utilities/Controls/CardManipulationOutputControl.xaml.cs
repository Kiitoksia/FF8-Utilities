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
    }
}
