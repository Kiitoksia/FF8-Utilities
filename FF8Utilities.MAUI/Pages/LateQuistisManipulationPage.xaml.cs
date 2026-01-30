using FF8Utilities.Common.Cards;

namespace FF8Utilities.MAUI.Pages;

public partial class LateQuistisManipulationPage : ContentPage
{
	public LateQuistisManipulationPage()
	{
		InitializeComponent();

		SelectStrategyCommand = new AsyncCommand(async strategy =>
		{
			SelectedStrategy = (LateQuistisStrategy)strategy;
			NavigationDrawer.ToggleDrawer();
        });
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