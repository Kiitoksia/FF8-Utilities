using FF8Utilities.MAUI.Models;

namespace FF8Utilities.MAUI.Controls;

public partial class CardTimerControl : ContentView
{
	public CardTimerControl()
	{
		InitializeComponent();
	}

	public CardManipulationModel Model
	{
		get => (CardManipulationModel)BindingContext;
		set => BindingContext = value;
    }
}