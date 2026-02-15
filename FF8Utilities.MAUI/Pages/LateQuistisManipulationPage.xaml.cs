using FF8Utilities.Common.Cards;
using FF8Utilities.MAUI.Converters;
using FF8Utilities.MAUI.Models;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Windows.Input;

namespace FF8Utilities.MAUI.Pages;

public partial class LateQuistisManipulationPage : ContentPage
{
	public static readonly BindableProperty StrategyItemHeightProperty =
		BindableProperty.Create(nameof(StrategyItemHeight), typeof(double), typeof(LateQuistisManipulationPage), 0d);

	public double StrategyItemHeight
	{
		get => (double)GetValue(StrategyItemHeightProperty);
		set => SetValue(StrategyItemHeightProperty, value);
	}

	private bool _initialised;
	public LateQuistisManipulationPage()
	{
		InitializeComponent();

        StrategiesView.SizeChanged += (_, __) =>
        {
            if (StrategiesView.Height > 0)
                StrategyItemHeight = Math.Max(0, StrategiesView.Height / 2 - 10);
        };

        Header.BackCommand = new AsyncCommand(async () =>
		{
            await MainThread.InvokeOnMainThreadAsync(async () =>
            {
                bool canContinue = await DisplayAlertAsync("Confim", "No quistis pattern selected, are you sure you want to return?", "OK", "Cancel");
                if (canContinue)
                {
                    SelectedStrategy = null;
                    await Navigation.PopModalAsync();
                }
            });            
        });       
    }

    public LateQuistisManipulationPage(LateQuistisPattern model, CardManipulationModel cardManipModel) : this()
	{
        CardControl.Model = cardManipModel;
        Model = model;

        OrderedStrategies = new ObservableCollection<LateQuistisStrategy>(model.Strategies.OrderBy(t => t.OpponentDeckOrderer));
        QuistisObtainedCommand = new AsyncCommand(QuistisCardObtained);

        // This will pre-load the images
        Task.Run(() =>
        {
            var converter = new CachedByteArrayToImageSourceConverter();
            foreach (var strategy in OrderedStrategies)
            {
                _ = converter.Convert(strategy.OpponentCards.ElementAtOrDefault(0), typeof(ImageSource), null, CultureInfo.InvariantCulture);
                _ = converter.Convert(strategy.OpponentCards.ElementAtOrDefault(1), typeof(ImageSource), null, CultureInfo.InvariantCulture);
            }
        });
        _initialised = true;
    }

    public static readonly BindableProperty OrderedStrategiesProperty = BindableProperty.Create(nameof(OrderedStrategies), typeof(ObservableCollection<LateQuistisStrategy>), typeof(LateQuistisManipulationPage), null);


    public ObservableCollection<LateQuistisStrategy> OrderedStrategies
    {
        get => (ObservableCollection<LateQuistisStrategy>)GetValue(OrderedStrategiesProperty);
        set => SetValue(OrderedStrategiesProperty, value);
    }


	public LateQuistisPattern Model
	{
		get => (LateQuistisPattern)BindingContext;
		set
		{
            BindingContext = value;
        }
    }

    protected override bool OnBackButtonPressed()
    {
		MainThread.BeginInvokeOnMainThread(async () =>
		{
            if (StrategyPopup.IsOpen)
            {
                // Popup open, assume this is what they want to close
                StrategyPopup.IsOpen = false;
                return;
            }

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
            await DisplayAlertAsync("Outcome saved", "Continue as normal for zell tracking", "OK");
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