using System.ComponentModel;
using UltimeciaManip;

namespace FF8Utilities.MAUI;

public partial class UltimeciaManipPage : ContentPage
{
	public UltimeciaManipPage()
	{
		InitializeComponent();

        Directions = new BindingList<Direction>();
        SubmitDirectionCommand = new Command<Direction>(SubmitDirection);

    }

	private void SubmitDirection(Direction direction)
	{
        Directions.Add(direction);
	}

	public BindingList<Direction> Directions { get; set; }

	public Command SubmitDirectionCommand { get; }

    private void DeleteButton_Clicked(object sender, EventArgs e)
    {
		if (Directions.Count == 0) return;
		Directions.RemoveAt(Directions.Count - 1);
    }
}