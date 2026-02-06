using FF8Utilities.Common;
using FF8Utilities.Common.Cards;
using FF8Utilities.MAUI.Controls;
using FF8Utilities.MAUI.Models;
using System.Windows.Input;

namespace FF8Utilities.MAUI.Pages;

public partial class CardTrackerPage : ContentPage
{
    /// <summary>
    /// Ensure you call Initialise() before using the page if using this constructor
    /// </summary>
    public CardTrackerPage()
	{
        InitializeComponent();

        SaveAsDefaultsCommand = new AsyncCommand(SaveAsDefault);
        RestoreDefaultsCommand = new AsyncCommand(RestoreDefaults);
    }


    private async Task SaveAsDefault()
    {
        Model.SaveEncounterDetails();
        await MainThread.InvokeOnMainThreadAsync(async () =>
        {
            await DisplayAlertAsync("Success", "Values have been saved and will be used next time the tracker is opened", "OK");
        });
    }
	
    private async Task RestoreDefaults()
    {
        await MainThread.InvokeOnMainThreadAsync(async () =>
        {
            bool proceed = await DisplayAlertAsync("Confirm", "Really delete settings? All tracking settings will be restored to default and the tracker closed.\r\nThis process cannot be reversed", "OK", "Cancel");
            if (proceed)
            {
                Model.RestoreDefaults();
                await DisplayAlertAsync("Success", "Default settings restored, tracker will now close", "OK");
                await Navigation.PopModalAsync();
            }
        });
    }

	public CardTrackerPage(bool earlyQuistisMode) : this()
	{
        Initialise();
        QuistisPatternRow.Height = new GridLength(earlyQuistisMode ? 0 : 80, GridUnitType.Absolute);
        QuistisPatternView.IsVisible = !earlyQuistisMode;
    }

	public void Initialise()
	{
        Model = new CardTrackerModel();
        CreatePostIfritEncounterContent();
        CreateAnacondaurEncounterContent();

        Model.PropertyChanged += (s, e) =>
        {
            if (e.PropertyName == nameof(CardTrackerModel.IfritsCavernEncounterType))
            {
                CreatePostIfritEncounterContent();
            }
            if (e.PropertyName == nameof(CardTrackerModel.DidGetSecondBridgeEncounter))
            {
                CreateAnacondaurEncounterContent();
            }

            if (e.PropertyName == nameof(CardTrackerModel.QuistisCardObtained))
            {
                if (Model.QuistisCardObtained && Model.QuistisCardResult != null)
                {
                    // They just obtained Quistis card, move the tab over to dollet
                    MainThread.BeginInvokeOnMainThread(() => TabView.SelectedIndex = 1);
                }
            }
        };        
    }

    protected override bool OnBackButtonPressed()
    {
		MainThread.BeginInvokeOnMainThread(async () =>
		{
			bool shouldContinue = await DisplayAlertAsync("Confirm", "Are you sure you want to go back? All tracking will be lost", "OK", "Cancel");
			if (shouldContinue) await Navigation.PopModalAsync();
		});

        return true;
    }

	private void CreatePostIfritEncounterContent()
	{
		BaseEncounterModel postIfritEncounter = null;
		switch (Model.IfritsCavernEncounterType)
		{
			case IfritEncounterType.RedBat:
				postIfritEncounter = Model.SecondBatsEncounter;
				break;
			case IfritEncounterType.Buel:
				postIfritEncounter = Model.BuelEncounter;
				break;
			default: throw new NotImplementedException();
		}
		MainThread.BeginInvokeOnMainThread(() =>
		{
			PostIfritTab.Header = Model.IfritsCavernEncounterType.GetDescription();
            PostIfritTab.Content = new EncounterControl { BindingContext = postIfritEncounter };
        });
	}

	private void CreateAnacondaurEncounterContent()
	{
		BaseEncounterModel secondEncounter, thirdEncounter;
		if (Model.DidGetSecondBridgeEncounter)
		{
			secondEncounter = Model.SecondBridgeEncounter;
			thirdEncounter = Model.AnacondaurEncounter;
		}
		else
		{
			secondEncounter = Model.AnacondaurEncounter;
			thirdEncounter = Model.PostAnacondaurEncounter;
		}

		MainThread.BeginInvokeOnMainThread(() =>
		{
			Anacondaur2ndEncounter.Content = new EncounterControl { BindingContext = secondEncounter };
			Anacondaur2ndEncounter.Header = secondEncounter.Description;
			Anacondaur3rdEncounter.Content = new EncounterControl { BindingContext = thirdEncounter };
            Anacondaur3rdEncounter.Header = thirdEncounter.Description;
        });
	}

	public CardTrackerModel Model
	{
		get => (CardTrackerModel)BindingContext;
		set => BindingContext = value;
	}

    public static readonly BindableProperty SaveAsDefaultsCommandProperty = BindableProperty.Create(nameof(SaveAsDefaultsCommand), typeof(ICommand), typeof(CardTrackerPage), null);


    public ICommand SaveAsDefaultsCommand
    {
        get => (ICommand)GetValue(SaveAsDefaultsCommandProperty);
        set => SetValue(SaveAsDefaultsCommandProperty, value);
    }

    public static readonly BindableProperty RestoreDefaultsCommandProperty = BindableProperty.Create(nameof(RestoreDefaultsCommand), typeof(ICommand), typeof(CardTrackerPage), null);


    public ICommand RestoreDefaultsCommand
    {
        get => (ICommand)GetValue(RestoreDefaultsCommandProperty);
        set => SetValue(RestoreDefaultsCommandProperty, value);
    }
}