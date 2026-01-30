using Android.Telecom;
using FF8Utilities.Common.Cards;
using FF8Utilities.MAUI.Models;

namespace FF8Utilities.MAUI.Pages;

public partial class LateQuistisManipulationPage : ContentPage
{
	public LateQuistisManipulationPage(LateQuistisPattern model, CardManipulationModel cardManipModel)
	{
		InitializeComponent();

		SelectStrategyCommand = new AsyncCommand(async strategy =>
		{
			SelectedStrategy = (LateQuistisStrategy)strategy;
			NavigationDrawer.ToggleDrawer();
        });

        CardControl.Model = cardManipModel;
        Model = model;        
    }

	public LateQuistisPattern Model
	{
		get => (LateQuistisPattern)BindingContext;
		private set
		{
            BindingContext = value;
			SelectedStrategy = Model.Strategies.FirstOrDefault();			
        }
    }	

	public static readonly BindableProperty CardManipModelProperty = BindableProperty.Create(nameof(CardManipModel), typeof(CardManipulationModel), typeof(LateQuistisManipulationPage), null);

	public CardManipulationModel CardManipModel
	{
		get => (CardManipulationModel)GetValue(CardManipModelProperty);
		private set => SetValue(CardManipModelProperty, value);
    }


    public static readonly BindableProperty SelectStrategyCommandProperty = BindableProperty.Create(nameof(SelectStrategyCommand), typeof(Command<LateQuistisPattern>), typeof(LateQuistisManipulationPage), null);

	public AsyncCommand SelectStrategyCommand
	{
		get => (AsyncCommand)GetValue(SelectStrategyCommandProperty);
		private set => SetValue(SelectStrategyCommandProperty, value);
    }

	public static readonly BindableProperty SelectedStrategyProperty = BindableProperty.Create(nameof(SelectedStrategy), typeof(LateQuistisStrategy), typeof(LateQuistisManipulationPage), null, BindingMode.TwoWay);

    public LateQuistisStrategy SelectedStrategy
	{
		get => (LateQuistisStrategy)GetValue(SelectedStrategyProperty);
		set => SetValue(SelectedStrategyProperty, value);
    }

    private void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
		//CollectionView view
    }
}