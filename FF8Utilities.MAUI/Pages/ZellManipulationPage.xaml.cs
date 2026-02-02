using FF8Utilities.MAUI.Models;

namespace FF8Utilities.MAUI.Pages;

public partial class ZellManipulationPage : ContentPage
{
	public ZellManipulationPage() 
	{
		InitializeComponent();
    }

    public ZellManipulationPage(CardManipulationModel model) : this()
	{
		CardControl.Model = model;
    }
}