using FF8Utilities.Common.Cards;
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
}