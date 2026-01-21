using FF8Utilities.Common.Cards;
using System.Collections.ObjectModel;

namespace FF8Utilities.MAUI.Pages.CardManipulationSubPages;

public partial class CardFormationPage : ContentPage
{
	public CardFormationPage()
	{
		InitializeComponent();
        CreateCardPatterns();

		MomFirstStrongCardPositions.Add(new CardPosition(1, false, 1, CardImage.GetCardImage("z")));
        MomFirstStrongCardPositions.Add(new CardPosition(2, false, 0, CardImage.GetCardImage("empty"), "#", "2+", "#", "#"));
        MomFirstStrongCardPositions.Add(new CardPosition(3, true, 3, CardImage.GetCardImage("b")));
        MomFirstStrongCardPositions.Add(new CardPosition(4, false, 0, CardImage.GetCardImage("empty")));
        MomFirstStrongCardPositions.Add(new CardPosition(5, true, 4, CardImage.GetCardImage("q")));
        MomFirstStrongCardPositions.Add(new CardPosition(6, false, 0, CardImage.GetCardImage("empty")));
        MomFirstStrongCardPositions.Add(new CardPosition(7, false, 0, CardImage.GetCardImage("empty")));
        MomFirstStrongCardPositions.Add(new CardPosition(8, true, 2, CardImage.GetCardImage("i")));
        MomFirstStrongCardPositions.Add(new CardPosition(9, true, 1, CardImage.GetCardImage("g")));
    }

	public static readonly BindableProperty PlayerGoesFirstProperty = BindableProperty.Create(nameof(PlayerGoesFirst), typeof(bool), typeof(CardFormationPage), false, BindingMode.TwoWay, propertyChanged: OnPlayerGoesFirstChanged);

	public bool PlayerGoesFirst
	{
		get => (bool)GetValue(PlayerGoesFirstProperty);
		set => SetValue(PlayerGoesFirstProperty, value);
	}

	private static void OnPlayerGoesFirstChanged(BindableObject bindable, object oldValue, object newValue)
	{
		CardFormationPage page = (CardFormationPage)bindable;
		page.CreateCardPatterns();
	}

	public static readonly BindableProperty CardPositionsProperty = BindableProperty.Create(nameof(CardPositions), typeof(ObservableCollection<CardPosition>), typeof(CardFormationPage), new ObservableCollection<CardPosition>());

	public ObservableCollection<CardPosition> CardPositions
	{
		get => (ObservableCollection<CardPosition>)GetValue(CardPositionsProperty);
		set => SetValue(CardPositionsProperty, value);
	}

	public static readonly BindableProperty MomFirstStrongCardPositionsProperty = BindableProperty.Create(nameof(MomFirstStrongCardPositions), typeof(ObservableCollection<CardPosition>), typeof(CardFormationPage), new ObservableCollection<CardPosition>());

	public ObservableCollection<CardPosition> MomFirstStrongCardPositions
	{
		get => (ObservableCollection<CardPosition>)GetValue(MomFirstStrongCardPositionsProperty);
	}


    private void CreateCardPatterns()
	{
		CardPositions.Clear();
		if (PlayerGoesFirst)
		{
			CardPositions.Add(new CardPosition(1, false, 0, CardImage.GetCardImage("empty")));
			CardPositions.Add(new CardPosition(2, false, 0, CardImage.GetCardImage("empty")));
			CardPositions.Add(new CardPosition(3, true, 5, CardImage.GetCardImage("q")));
			CardPositions.Add(new CardPosition(4, true, 4, CardImage.GetCardImage("m")));
			CardPositions.Add(new CardPosition(5, false, 0, CardImage.GetCardImage("empty")));
			CardPositions.Add(new CardPosition(6, false, 1, CardImage.GetCardImage("z")));
			CardPositions.Add(new CardPosition(7, true, 3, CardImage.GetCardImage("i")));
			CardPositions.Add(new CardPosition(8, true, 2, CardImage.GetCardImage("g")));
			CardPositions.Add(new CardPosition(9, true, 1, CardImage.GetCardImage("b")));
		}
		else
		{
			CardPositions.Add(new CardPosition(1, false, 1, CardImage.GetCardImage("z")));
			CardPositions.Add(new CardPosition(2, false, 0, CardImage.GetCardImage("empty"), "#", "= 1", "#", "#"));
			CardPositions.Add(new CardPosition(3, true, 4, CardImage.GetCardImage("q")));
			CardPositions.Add(new CardPosition(4, true, 3, CardImage.GetCardImage("m")));
			CardPositions.Add(new CardPosition(5, false, 0, CardImage.GetCardImage("empty")));
			CardPositions.Add(new CardPosition(6, false, 0, CardImage.GetCardImage("empty")));
			CardPositions.Add(new CardPosition(7, false, 0, CardImage.GetCardImage("empty")));
			CardPositions.Add(new CardPosition(8, true, 2, CardImage.GetCardImage("i")));
			CardPositions.Add(new CardPosition(9, true, 1, CardImage.GetCardImage("g")));
		}
	}
}