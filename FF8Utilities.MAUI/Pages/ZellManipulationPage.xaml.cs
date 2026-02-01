using FF8Utilities.MAUI.Models;

namespace FF8Utilities.MAUI.Pages;

public partial class ZellManipulationPage : ContentPage
{
	public ZellManipulationPage(CardManipulationModel model)
	{
		InitializeComponent();

		BindingContext = model;
    }
}