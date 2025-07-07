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
    /// Interaction logic for SettingsInputControl.xaml
    /// </summary>
    public partial class SettingsInputControl : UserControl
    {
        public SettingsInputControl()
        {
            InitializeComponent();
        }

        public object LabelContent
        {
            get { return GetValue(LabelContentProperty); }
            set { SetValue(LabelContentProperty, value); }
        }

        public static readonly DependencyProperty LabelContentProperty =
            DependencyProperty.Register(nameof(LabelContent), typeof(object), typeof(SettingsInputControl), new PropertyMetadata(null));

        public object InputContent
        {
            get { return GetValue(InputContentProperty); }
            set { SetValue(InputContentProperty, value); }
        }

        public static readonly DependencyProperty InputContentProperty =
            DependencyProperty.Register(nameof(InputContent), typeof(object), typeof(SettingsInputControl), new PropertyMetadata(null));
    }
}
