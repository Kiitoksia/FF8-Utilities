using FF8Utilities.Common;
using FF8Utilities.Common.Cards;
using FF8Utilities.MAUI.Controls;
using FF8Utilities.MAUI.Models;

namespace FF8Utilities.MAUI.Pages;

public partial class CardTrackerPage : ContentPage
{
	public CardTrackerPage()
	{
		InitializeComponent();
		Model = new CardTrackerModel();

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
		};

        CreatePostIfritEncounterContent();
        CreateAnacondaurEncounterContent();
    }

	private void CreatePostIfritEncounterContent()
	{
		BaseEncounterModel postIfritEncounter = null;
		switch (Model.IfritsCavernEncounterType)
		{
			case Common.IfritEncounterType.RedBat:
				postIfritEncounter = Model.SecondBatsEncounter;
				break;
			case Common.IfritEncounterType.Buel:
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
}