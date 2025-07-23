using System.ComponentModel;
using UltimeciaManip;

namespace FF8Utilities.MAUI;

public partial class UltimeciaManipPage : ContentPage
{

    public UltimeciaManipPage()
	{
		InitializeComponent();

        Directions = new BindingList<Direction>();
		Directions.ListChanged += async (s, e) =>
		{
			if (Directions.Count >= 12)
			{
                await Calculate();
            }
		};


        SubmitDirectionCommand = new Command<Direction>(SubmitDirection);

    }	

	public BindingList<PartyFormation> Formations { get; set; }
	

	private Common.Platform Platform
	{
		get => Enum.Parse<Common.Platform>(Preferences.Get(nameof(Platform), Common.Platform.PS2.ToString()));
		set => Preferences.Set(nameof(Platform), value.ToString());
    }

	private UltimeciaManipLanguage Language
	{
		get => Enum.Parse<UltimeciaManipLanguage>(Preferences.Get(nameof(Language), UltimeciaManipLanguage.English.ToString()));
		set => Preferences.Set(nameof(Language), value.ToString());
    }

	private async Task Calculate()
	{
        UltimeciaManipLanguage[] languages = Manipulation.GetSupportedLanguages(Platform);
		if (!languages.Contains(Language))
		{
			await DisplayAlert("Unsupported Language", $"The selected language ({Language}) is not supported for the current platform ({Platform}).", "OK");
			return;
        }


        PartyFormation[] formations = Manipulation.GetUltimeciaFormations(Directions.ToArray(), Platform, Language);
        Formations = new BindingList<PartyFormation>(formations);
    }

	private void SubmitDirection(Direction direction)
	{
        Directions.Add(direction);
	}

	public BindingList<Direction> Directions { get; }

	public Command SubmitDirectionCommand { get; }

    private void DeleteButton_Clicked(object sender, EventArgs e)
    {
		if (Directions.Count == 0) return;
		Directions.RemoveAt(Directions.Count - 1);
    }
}