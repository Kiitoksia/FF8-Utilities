using FF8Utilities.Common;
using FF8Utilities.Common.Cards;
using FF8Utilities.MAUI.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace FF8Utilities.MAUI.Pages;

public partial class MainPage : ContentPage
{
    private bool _loaded;
	public MainPage()
	{
		EarlyQuistisPatterns = new ObservableCollection<EarlyQuistisPattern>(EarlyQuistisPattern.OptionsExcludeLate);

		InitializeComponent();

        EarlyQuistisPattern = EarlyQuistisPattern.Frame1;
        CardTrackerCommand = new AsyncCommand(ShowQuistisPopup);
        LaunchCardTrackingCommand = new AsyncCommand(earlyQuistis => ShowCardTrackerOptions((bool)earlyQuistis));
        EarlyQuistisCardPatternPickedCommand = new AsyncCommand(async () => await LaunchTracker(true));
        SecondTryZellCommand = new AsyncCommand(() =>
        {
            EarlyQuistisStrategyPopup.IsOpen = false;
            CardTrackerModel model = new CardTrackerModel();
            model.LaunchZellPatterns(EarlyQuistisPattern.Result.ToString("x8"), null);            
        });

        CloseEarlyQuistisStrategyCommand = new AsyncCommand(() => EarlyQuistisStrategyPopup.IsOpen = false);
        UltimeciaCommand = new AsyncCommand(async () =>
        {
            UltimeciaPage page = new UltimeciaPage();
            await Navigation.PushModalAsync(page);
        });
        CarawayCommand = new AsyncCommand(async () =>
        {
            CarawayCodePage page = new CarawayCodePage();
            await Navigation.PushModalAsync(page);
        });
        SettingsCommand = new AsyncCommand(LaunchSettings);

        ShowLoadingBar = true;

        EarlyQuistisStrategy = new ObservableCollection<CardPosition>(CardPosition.EarlyQuistisFrame1);        

        Loaded += MainPage_Loaded;
    }

    private async Task<bool> DownloadRequiredFilesIfNeccessary()
    {
        bool neccessaryFilesDownloaded = true;
        foreach (string quistisFile in LateQuistis.RequiredFiles)
        {
            if (!File.Exists(Path.Combine(Const.PackagesFolder, quistisFile)))
            {
                neccessaryFilesDownloaded = false;
                break;
            }
        }        

        if (!neccessaryFilesDownloaded)
        {
            ShowLoadingBar = true;
            DownloadResult result = await App.DriveManager.DownloadLateQuistisCSRFiles();
            if (result == DownloadResult.Error)
            {
                await DisplayAlertAsync("Error", "Could not download required tracker files, cannot launch tracker", "OK");
                return false;
            }
        }

        return true;
    }

    private async void MainPage_Loaded(object sender, EventArgs e)
    {
        if (_loaded) return; // Ensure Loaded event isn't called multiple times
        _loaded = true;
        bool downloadedFiles = await DownloadRequiredFilesIfNeccessary();

        if (VersionTracking.IsFirstLaunchEver)
        {
            SettingsPage page = new SettingsPage();
            EventHandler handler = null;
            handler = (s, e) =>
            {
                page.Loaded -= handler;
                MainThread.BeginInvokeOnMainThread(async () =>
                {
                    await page.DisplayAlertAsync("Welcome", "First launch detected, please verify your settings before using utilities", "OK");
                });            
            };

            page.Loaded += handler;
            await MainThread.InvokeOnMainThreadAsync(async () => await Navigation.PushModalAsync(page));
        }

        ShowLoadingBar = false;
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

    public static readonly BindableProperty EarlyQuistisPatternProperty = BindableProperty.Create(nameof(EarlyQuistisPattern), typeof(EarlyQuistisPattern), typeof(MainPage), EarlyQuistisPattern.Frame1, propertyChanged: EarlyQuistisPatternChanged);

    public EarlyQuistisPattern EarlyQuistisPattern
    {
        get => (EarlyQuistisPattern)GetValue(EarlyQuistisPatternProperty);
        set => SetValue(EarlyQuistisPatternProperty, value);
    }

    public static readonly BindableProperty EarlyQuistisPatternsProperty = BindableProperty.Create(nameof(EarlyQuistisPatterns), typeof(ObservableCollection<EarlyQuistisPattern>), typeof(MainPage), null);

    public ObservableCollection<EarlyQuistisPattern> EarlyQuistisPatterns
    {
        get => (ObservableCollection<EarlyQuistisPattern>)GetValue(EarlyQuistisPatternsProperty);
        set => SetValue(EarlyQuistisPatternsProperty, value);
    }

    private static void EarlyQuistisPatternChanged(BindableObject bindable, object oldValue, object newValue)
    {
        MainPage page = (MainPage)bindable;

        page.EarlyQuistisStrategy.Clear();
        CardPosition[] strategy = null;
        if (newValue is EarlyQuistisPattern pattern)
        {
            if (pattern == EarlyQuistisPattern.Frame1) strategy = CardPosition.EarlyQuistisFrame1;
            else if (pattern == EarlyQuistisPattern.Frame2) strategy = CardPosition.EarlyQuistisFrame2;
            else if (pattern == EarlyQuistisPattern.Frame3) strategy = CardPosition.EarlyQuistisFrame3;
            else if (pattern == EarlyQuistisPattern.Frame4) strategy = CardPosition.EarlyQuistisFrame4;
            else if (pattern == EarlyQuistisPattern.Frame7) strategy = CardPosition.EarlyQuistisFrame7;
            else if (pattern == EarlyQuistisPattern.Frame9) strategy = CardPosition.EarlyQuistisFrame9;
            else if (pattern == EarlyQuistisPattern.Frame10) strategy = CardPosition.EarlyQuistisFrame10;
        }

        if (strategy != null)
        {
            foreach (CardPosition pos in strategy)
            {
                page.EarlyQuistisStrategy.Add(pos);
            }
        }
    }

    public static readonly BindableProperty EarlyQuistisStrategyProperty = BindableProperty.Create(nameof(EarlyQuistisStrategy), typeof(ObservableCollection<CardPosition>), typeof(MainPage), null);

    public ObservableCollection<CardPosition> EarlyQuistisStrategy
    {
        get => (ObservableCollection<CardPosition>)GetValue(EarlyQuistisStrategyProperty);
        set => SetValue(EarlyQuistisStrategyProperty, value);
    }

    public static readonly BindableProperty CloseEarlyQuistisStrategyCommandProperty = BindableProperty.Create(nameof(CloseEarlyQuistisStrategyCommand), typeof(ICommand), typeof(MainPage), null);

    public ICommand CloseEarlyQuistisStrategyCommand
    {
        get => (ICommand)GetValue(CloseEarlyQuistisStrategyCommandProperty);
        set => SetValue(CloseEarlyQuistisStrategyCommandProperty, value);
    }

    private async Task ShowCardTrackerOptions(bool earlyQuistis)
    {
        try
        {
            ShowLoadingBar = true;
            bool hasRequiredFiles = await DownloadRequiredFilesIfNeccessary();
            if (!hasRequiredFiles) return;            

            if (earlyQuistis)
            {
                await MainThread.InvokeOnMainThreadAsync(() =>
                {
                    EarlyQuistisStrategyPopup.IsOpen = true;
                });

                // The picker frame will handle the rest
            }
            else
            {
                QuistisPopup.IsOpen = false;
                await LaunchTracker(false);
            }
        }
        finally
        {
            QuistisPopup.IsOpen = false;
            ShowLoadingBar = false;
        }
    }

    private async Task LaunchTracker(bool earlyQuistis)
    {
        // Initialise once off items
        await Task.Run(() =>
        {
            _ = BaseZellCardTrackerModel.LateQuistisManip;
            _ = BaseZellCardTrackerModel.CardManip;
        });

        CardTrackerPage page = new CardTrackerPage(earlyQuistis);      
        page.Model.EarlyQuistisPattern = earlyQuistis ? EarlyQuistisPattern : EarlyQuistisPattern.LateQuistis;
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

    public static readonly BindableProperty SecondTryZellCommandProperty = BindableProperty.Create(nameof(SecondTryZellCommand), typeof(ICommand), typeof(MainPage), null);

    public ICommand SecondTryZellCommand
    {
        get => (ICommand)GetValue(SecondTryZellCommandProperty);
        set => SetValue(SecondTryZellCommandProperty, value);
    }
}