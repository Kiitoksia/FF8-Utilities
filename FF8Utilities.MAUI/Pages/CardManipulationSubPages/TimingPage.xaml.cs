using FF8Utilities.MAUI.Models;
using CardManipulation;

namespace FF8Utilities.MAUI.Pages.CardManipulationSubPages;

public partial class TimingPage : ContentPage
{
    private CardManipulationModel _model;
    private CardManip _manip = new CardManip();

    public TimingPage()
	{
		InitializeComponent();
        CreateManip();
    }

    private void CreateManip()
    {
        if (_model != null)
        {
            _model.Dispose();            
            _model = null;
        }

        _model = new CardManipulationModel(_manip, 0x65c6be07, "zellmama", DelayFrames, RNGModifier);
        _model.RecoveryPattern = "74441154176425316556";

        BindingContext = _model;        
    }


    public int DelayFrames
    {
        get => Preferences.Get(nameof(DelayFrames), 9);
        set
        {
            if (value == DelayFrames) return;
            Preferences.Set(nameof(DelayFrames), value);
            CreateManip();
        }
    }

    public static readonly BindableProperty RNGModifierProperty = BindableProperty.Create(nameof(RNGModifier), typeof(int?), typeof(TimingPage), null);


    public int? RNGModifier
    {
        get => (int?)GetValue(RNGModifierProperty);
        set
        {
            if (value == RNGModifier) return;
            SetValue(RNGModifierProperty, value);
            CreateManip();
        }
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        _model?.SubmitCommand.Execute(null);
    }
}