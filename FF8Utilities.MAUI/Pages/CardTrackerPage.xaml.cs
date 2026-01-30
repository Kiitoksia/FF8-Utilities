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
		};

        CreatePostIfritEncounterContent();
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
		PostIfritTab.Content = new EncounterControl { BindingContext = postIfritEncounter };
	}

	public CardTrackerModel Model
	{
		get => (CardTrackerModel)BindingContext;
		set => BindingContext = value;
	}
}