using FF8Utilities.Common;
using FF8Utilities.Common.Cards;
using Syncfusion.Maui.Buttons;
using System.Windows.Input;

namespace FF8Utilities.MAUI.Controls;

public partial class EncounterControl : ContentView
{
	public EncounterControl()
	{
		InitializeComponent();

        DesignCommand = new Command(() => DesignMode = !DesignMode);
	}

    private BaseEncounterModel Model
    {
        get => (BaseEncounterModel)BindingContext;
    }

    public static readonly BindableProperty DesignModeProperty = BindableProperty.Create(nameof(DesignMode), typeof(bool), typeof(EncounterControl), false);


    public bool DesignMode
    {
        get => (bool)GetValue(DesignModeProperty);
        set => SetValue(DesignModeProperty, value);
    }

    public static readonly BindableProperty DesignCommandProperty = BindableProperty.Create(nameof(DesignCommand), typeof(ICommand), typeof(EncounterControl), null);


    public ICommand DesignCommand
    {
        get => (ICommand)GetValue(DesignCommandProperty);
        set => SetValue(DesignCommandProperty, value);
    }

    private void SfRadioButton_StateChanged(object sender, Syncfusion.Maui.Buttons.StateChangedEventArgs e)
    {
        if (e.IsChecked ?? false)
        {
            SfRadioButton button = (SfRadioButton)sender;
            Model.Fanfare = (FanfareCamera)button.Value;
        }        
    }
}