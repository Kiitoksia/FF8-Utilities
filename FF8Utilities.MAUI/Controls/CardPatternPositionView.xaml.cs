using CommunityToolkit.Maui.Behaviors;
using FF8Utilities.Common.Cards;

namespace FF8Utilities.MAUI.Controls;

public partial class CardPatternPositionView : ContentView
{
	public CardPatternPositionView()
	{
		InitializeComponent();

		BindingContextChanged += (s, e) =>
		{
			if (BindingContext is CardPosition model)
			{
				if (!model.IsPlayerTurn)
				{
					CardImage.Opacity = 0.5;
				}
			}
		};
	}
}