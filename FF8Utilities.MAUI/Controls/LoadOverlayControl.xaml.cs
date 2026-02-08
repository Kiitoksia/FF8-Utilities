namespace FF8Utilities.MAUI.Controls;

public partial class LoadOverlayControl : ContentView
{
	public LoadOverlayControl()
	{
		InitializeComponent();
	}

	public static readonly BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(LoadOverlayControl), "Loading...");

	public string Text
	{
		get => (string)GetValue(TextProperty);
		set => SetValue(TextProperty, value);
    }
}