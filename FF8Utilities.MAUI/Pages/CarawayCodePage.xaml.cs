using CarawayCode.Entities;
using FF8Utilities.Common;
using FF8Utilities.Common.Caraway;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace FF8Utilities.MAUI.Pages;

public partial class CarawayCodePage : ContentPage
{
	private bool _initialised;
	public CarawayCodePage()
	{
		ObservableCollection<ComboBoxItem> seriesOptions = new ObservableCollection<ComboBoxItem>();
        seriesOptions.Add(new ComboBoxItem("?", null));
		for (int i = 0; i < 16; i++)
		{
            seriesOptions.Add(new ComboBoxItem(i.ToString(), i));
		}

		SeriesOptions = seriesOptions;

        ObservableCollection<PoleModel> poles = new ObservableCollection<PoleModel>(PoleModel.Poles);
		Poles = poles;
		Output = new ObservableCollection<CarawayCodeOutput>();

        InitializeComponent();

        SubmitCommand = new AsyncCommand(Submit);

		Header.SettingsCommand = new AsyncCommand(OptionsPopup.ShowAsync);

        HideUnlikelyResults = Preferences.Get(nameof(HideUnlikelyResults), true);
        ShowNPCMovement = Preferences.Get(nameof(ShowNPCMovement), false);
        _initialised = true;
    }

	private async Task Submit()
	{
		if (Poles.All(t => t.Count == null))
		{
			await DisplayAlertAsync("Error", "Please enter at least one pole series", "OK");
			return;
		}

        CarawayCodeOutput[] results = CarawayCode.CarawayCode.CalculateCode(PoleModel.ConvertTo(Poles), HideUnlikelyResults);
		if (HideUnlikelyResults && results.Length == 0) results = CarawayCode.CarawayCode.CalculateCode(PoleModel.ConvertTo(Poles), false); // No results find, show all
        await MainThread.InvokeOnMainThreadAsync(() =>
		{
            Output.Clear();
            foreach (var item in results.Take(20)) // only show 20 results on MAUI as this is expensive
            {
                Output.Add(item);
            }
        });        
    }

	public static readonly BindableProperty SeriesOptionsProperty = BindableProperty.Create(nameof(SeriesOptions), typeof(ObservableCollection<ComboBoxItem>), typeof(CarawayCodePage), null);

	public ObservableCollection<ComboBoxItem> SeriesOptions
	{
		get => (ObservableCollection<ComboBoxItem>)GetValue(SeriesOptionsProperty);
		set => SetValue(SeriesOptionsProperty, value);
    }

	public static readonly BindableProperty SubmitCommandProperty = BindableProperty.Create(nameof(SubmitCommand), typeof(ICommand), typeof(CarawayCodePage), null);

	public ICommand SubmitCommand
	{
		get => (ICommand)GetValue(SubmitCommandProperty);
		set => SetValue(SubmitCommandProperty, value);
    }

	public static readonly BindableProperty PolesProperty = BindableProperty.Create(nameof(Poles), typeof(ObservableCollection<PoleModel>), typeof(CarawayCodePage), null);

	public ObservableCollection<PoleModel> Poles
	{
		get => (ObservableCollection<PoleModel>)GetValue(PolesProperty);
		set => SetValue(PolesProperty, value);
	}

	public static readonly BindableProperty OutputProperty = BindableProperty.Create(nameof(Output), typeof(ObservableCollection<CarawayCodeOutput>), typeof(CarawayCodePage), null);

	public ObservableCollection<CarawayCodeOutput> Output
	{
		get => (ObservableCollection<CarawayCodeOutput>)GetValue(OutputProperty);
		set => SetValue(OutputProperty, value);
	}

	public static readonly BindableProperty HideUnlikelyResultsProperty = BindableProperty.Create(nameof(HideUnlikelyResults), typeof(bool), typeof(CarawayCodePage), false, propertyChanged: OnHideUnlikelyResultsChanged);

	private static void OnHideUnlikelyResultsChanged(BindableObject bindable, object oldValue, object newValue)
	{
        CarawayCodePage page = (CarawayCodePage)bindable;
        if (!page._initialised) return;
        if (newValue is bool hideUnlikelyResults)
		{
            Preferences.Set(nameof(HideUnlikelyResults), hideUnlikelyResults);
        }
    }

	public bool HideUnlikelyResults
	{
		get => (bool)GetValue(HideUnlikelyResultsProperty);
		set => SetValue(HideUnlikelyResultsProperty, value);
	}

	public static readonly BindableProperty ShowNPCMovementProperty = BindableProperty.Create(nameof(ShowNPCMovement), typeof(bool), typeof(CarawayCodePage), false, propertyChanged: OnShowNPCMovementChanged);

	private static void OnShowNPCMovementChanged(BindableObject bindable, object oldValue, object newValue)
	{
		CarawayCodePage page = (CarawayCodePage)bindable;
		if (!page._initialised) return;
		if (newValue is bool showNPCMovement)
		{
			Preferences.Set(nameof(ShowNPCMovement), showNPCMovement);
		}
	}

	public bool ShowNPCMovement
	{
		get => (bool)GetValue(ShowNPCMovementProperty);
		set => SetValue(ShowNPCMovementProperty, value);
	}
}