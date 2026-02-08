using FF8Utilities.MAUI.Models;

namespace FF8Utilities.MAUI.Pages;

public partial class UltimeciaPage : ContentPage
{
	public UltimeciaPage()
	{
		BindingContext = new UltimeciaManipulationModel();
		InitializeComponent();				
	}
}