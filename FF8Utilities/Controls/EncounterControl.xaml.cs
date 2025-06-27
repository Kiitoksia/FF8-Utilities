using FF8Utilities.Entities;
using FF8Utilities.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Interaction logic for EncounterControl.xaml
    /// </summary>
    public partial class EncounterControl : UserControl
    {
        public EncounterControl()
        {
            InitializeComponent();

            SelectFanfareCommand = new Command<object>(() => true, (s, e) =>
            {
                BaseEncounterModel model = (BaseEncounterModel)DataContext;
                model.Fanfare = (Enum)e;
                foreach (var item in model.FanfareTypeList)
                {
                    if (item.Value == e) continue;
                    item.IsSelected = false;
                }
            });
        }

        public ICommand SelectFanfareCommand { get; }
        
    }
}
