using FF8Utilities.Common.Cards;
using FF8Utilities.MAUI.Models;
using System.Windows.Input;

namespace FF8Utilities.MAUI.Pages;

public partial class LateQuistisManipulationPage : ContentPage
{
	private bool _initialised;
	public LateQuistisManipulationPage()
	{
		InitializeComponent();
    }

    public LateQuistisManipulationPage(LateQuistisPattern model, CardManipulationModel cardManipModel) : this()
	{
        CardControl.Model = cardManipModel;
        Model = model;

        QuistisObtainedCommand = new AsyncCommand(QuistisCardObtained);
        _initialised = true;
    }

	public LateQuistisPattern Model
	{
		get => (LateQuistisPattern)BindingContext;
		set
		{
            BindingContext = value;
			SelectedStrategy = Model.Strategies.FirstOrDefault();			
        }
    }

    protected override bool OnBackButtonPressed()
    {
		MainThread.BeginInvokeOnMainThread(async () =>
		{
			bool canContinue = await DisplayAlertAsync("Confim", "No quistis pattern selected, are you sure you want to return?", "OK", "Cancel");
			if (canContinue)
			{
				SelectedStrategy = null;
                await Navigation.PopModalAsync();
            }
		});
		return true;        
    }

	public static readonly BindableProperty CardManipModelProperty = BindableProperty.Create(nameof(CardManipModel), typeof(CardManipulationModel), typeof(LateQuistisManipulationPage), null);

	public CardManipulationModel CardManipModel
	{
		get => (CardManipulationModel)GetValue(CardManipModelProperty);
		set => SetValue(CardManipModelProperty, value);
    }

	public static readonly BindableProperty SelectedStrategyProperty = BindableProperty.Create(nameof(SelectedStrategy), typeof(LateQuistisStrategy), typeof(LateQuistisManipulationPage), null, BindingMode.TwoWay);

    public LateQuistisStrategy SelectedStrategy
	{
		get => (LateQuistisStrategy)GetValue(SelectedStrategyProperty);
		set => SetValue(SelectedStrategyProperty, value);
    }

	public static readonly BindableProperty QuistisObtainedCommandProperty = BindableProperty.Create(nameof(QuistisObtainedCommand), typeof(ICommand), typeof(LateQuistisManipulationPage), null);

	public ICommand QuistisObtainedCommand
	{
		get => (ICommand)GetValue(QuistisObtainedCommandProperty);
		set => SetValue(QuistisObtainedCommandProperty, value);
    }

	private async Task QuistisCardObtained()
	{
		if (SelectedStrategy != null)
		{            
            await Navigation.PopModalAsync();
		}
	}

    private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
		if (!_initialised) return;
        await StrategyPopup.ShowAsync();
    }

    private void SfButton_Clicked(object sender, EventArgs e)
    {
        StrategyPopup.IsOpen = false;
    }
}