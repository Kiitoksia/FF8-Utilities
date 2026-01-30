using FF8Utilities.Common;
using FF8Utilities.Common.Cards;
using System.Windows.Input;

namespace FF8Utilities.MAUI.Pages;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();

        
        CardTrackerCommand = new AsyncCommand(LaunchCardTracker);
	}

    private async Task LaunchCardTracker()
    {
        bool downloadQuistisFiles = false;
        foreach (string quistisFile in LateQuistis.RequiredFiles)
        {
            if (!File.Exists(Path.Combine(Const.PackagesFolder, quistisFile)))
            {
                downloadQuistisFiles = true;
                break;
            }
        }

        if (downloadQuistisFiles)
        {
            DownloadResult result = await App.DriveManager.DownloadLateQuistisCSRFiles();
            if (result == DownloadResult.Error)
            {
                await DisplayAlertAsync("Error", "Could not download quistis files, cannot launch tracker", "OK");
                return;
            }
        }

        await MainThread.InvokeOnMainThreadAsync(() =>
        {
            ShowLoadingBar = true;
        });
        // Initialise once off items

        await Task.WhenAll(
        Task.Run(async () => _ = BaseZellCardTrackerModel.LateQuistisManip),
        Task.Run(async () => _ = BaseZellCardTrackerModel.CardManip)
        );

        CardTrackerPage page = new CardTrackerPage();
        await MainThread.InvokeOnMainThreadAsync(async () =>
        {
            await Navigation.PushModalAsync(page);
            ShowLoadingBar = false;
        });
        

    }

    public static readonly BindableProperty ShowLoadingBarProperty = BindableProperty.Create(nameof(ShowLoadingBar), typeof(bool), typeof(MainPage), false);


    public bool ShowLoadingBar
    {
        get => (bool)GetValue(ShowLoadingBarProperty);
        set => SetValue(ShowLoadingBarProperty, value);
    }

    public static readonly BindableProperty CardTrackerCommandProperty = BindableProperty.Create(nameof(CardTrackerCommand), typeof(ICommand), typeof(MainPage), null);


    public ICommand CardTrackerCommand
    {
        get => (ICommand)GetValue(CardTrackerCommandProperty);
        set => SetValue(CardTrackerCommandProperty, value);
    }

    public static readonly BindableProperty FishFinCommandProperty = BindableProperty.Create(nameof(FishFinCommand), typeof(ICommand), typeof(MainPage), null);


    public ICommand FishFinCommand
    {
        get => (ICommand)GetValue(FishFinCommandProperty);
        set => SetValue(FishFinCommandProperty, value);
    }

    public static readonly BindableProperty CarawayCommandProperty = BindableProperty.Create(nameof(CarawayCommand), typeof(ICommand), typeof(MainPage), null);


    public ICommand CarawayCommand
    {
        get => (ICommand)GetValue(CarawayCommandProperty);
        set => SetValue(CarawayCommandProperty, value);
    }

    public static readonly BindableProperty UltimeciaCommandProperty = BindableProperty.Create(nameof(UltimeciaCommand), typeof(ICommand), typeof(MainPage), null);


    public ICommand UltimeciaCommand
    {
        get => (ICommand)GetValue(UltimeciaCommandProperty);
        set => SetValue(UltimeciaCommandProperty, value);
    }
}