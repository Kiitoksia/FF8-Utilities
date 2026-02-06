using FF8Utilities.Common;
using FF8Utilities.Common.Cards;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace FF8Utilities.MAUI.Pages;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();

        EarlyQuistisPattern = EarlyQuistisPattern.Frame1;
        CardTrackerCommand = new AsyncCommand(ShowQuistisPopup);
        LaunchCardTrackingCommand = new AsyncCommand(earlyQuistis => ShowCardTrackerOptions((bool)earlyQuistis));
        EarlyQuistisCardPatternPickedCommand = new AsyncCommand(async () => await LaunchTracker(true));
        SettingsCommand = new AsyncCommand(LaunchSettings);
    }

    private async Task ShowQuistisPopup()
    {
        await QuistisPopup.ShowAsync();
    }

    private async Task LaunchSettings()
    {
        SettingsPage page = new SettingsPage();
        await Navigation.PushModalAsync(page);
    }

    public static readonly BindableProperty EarlyQuistisPatternProperty = BindableProperty.Create(nameof(EarlyQuistisPattern), typeof(EarlyQuistisPattern), typeof(MainPage), EarlyQuistisPattern.Frame1);

    public EarlyQuistisPattern EarlyQuistisPattern
    {
        get => (EarlyQuistisPattern)GetValue(EarlyQuistisPatternProperty);
        set => SetValue(EarlyQuistisPatternProperty, value);
    }

    public static readonly BindableProperty EarlyQuistisPatternsProperty = BindableProperty.Create(nameof(EarlyQuistisPatterns), typeof(ObservableCollection<EarlyQuistisPattern>), typeof(MainPage), new ObservableCollection<EarlyQuistisPattern>(EarlyQuistisPattern.OptionsExcludeLate));

    public ObservableCollection<EarlyQuistisPattern> EarlyQuistisPatterns
    {
        get => (ObservableCollection<EarlyQuistisPattern>)GetValue(EarlyQuistisPatternsProperty);
        set => SetValue(EarlyQuistisPatternsProperty, value);
    }

    private async Task ShowCardTrackerOptions(bool earlyQuistis)
    {
        QuistisPopup.IsOpen = false;

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

        if (earlyQuistis)
        {
            await MainThread.InvokeOnMainThreadAsync(() =>
            {
                EarlyQuistisFramePicker.IsOpen = true;
            });
            
            // The picker frame will handle the rest
        }
        else
        {
            await LaunchTracker(false);
        }

    }

    private async Task LaunchTracker(bool earlyQuistis)
    {
        await MainThread.InvokeOnMainThreadAsync(() =>
        {
            ShowLoadingBar = true;
        });
        // Initialise once off items

        await Task.Run(() =>
        {
            _ = BaseZellCardTrackerModel.LateQuistisManip;
            _ = BaseZellCardTrackerModel.CardManip;
        });

        CardTrackerPage page = new CardTrackerPage(earlyQuistis);      
        page.Model.EarlyQuistisPattern = earlyQuistis ? EarlyQuistisPattern : Common.EarlyQuistisPattern.LateQuistis;
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

    public static readonly BindableProperty LaunchCardTrackingCommandProperty = BindableProperty.Create(nameof(LaunchCardTrackingCommand), typeof(ICommand), typeof(MainPage), null);

    public ICommand LaunchCardTrackingCommand
    {
        get => (ICommand)GetValue(LaunchCardTrackingCommandProperty);
        set => SetValue(LaunchCardTrackingCommandProperty, value);
    }

    public static readonly BindableProperty EarlyQuistisCardPatternPickedCommandProperty = BindableProperty.Create(nameof(EarlyQuistisCardPatternPickedCommand), typeof(ICommand), typeof(MainPage), null);

    public ICommand EarlyQuistisCardPatternPickedCommand
    {
        get => (ICommand)GetValue(EarlyQuistisCardPatternPickedCommandProperty);
        set => SetValue(EarlyQuistisCardPatternPickedCommandProperty, value);
    }

    public static readonly BindableProperty SettingsCommandProperty = BindableProperty.Create(nameof(SettingsCommand), typeof(ICommand), typeof(MainPage), null);


    public ICommand SettingsCommand
    {
        get => (ICommand)GetValue(SettingsCommandProperty);
        set => SetValue(SettingsCommandProperty, value);
    }
}