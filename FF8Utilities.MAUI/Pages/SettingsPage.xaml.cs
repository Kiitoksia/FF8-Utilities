using System.Windows.Input;
using UltimeciaManip;

namespace FF8Utilities.MAUI.Pages;

public partial class SettingsPage : ContentPage
{

    public static readonly BindableProperty PlatformProperty = BindableProperty.Create(nameof(Platform), typeof(Common.Platform), typeof(SettingsPage), default(Common.Platform), BindingMode.TwoWay, propertyChanged: OnPlatformChanged);

    public static readonly BindableProperty GameLanguageProperty = BindableProperty.Create(nameof(GameLanguage), typeof(UltimeciaManipLanguage), typeof(SettingsPage), default(UltimeciaManipLanguage), propertyChanged: OnGameLanguageChanged);

    public static readonly BindableProperty CustomCardDelayFramesProperty = BindableProperty.Create(nameof(CustomCardDelayFrames), typeof(int?), typeof(SettingsPage), null, propertyChanged: OnCardDelayFramesChanged);

    public IEnumerable<Common.Platform> Platforms => Enum.GetValues<Common.Platform>();
    public IEnumerable<UltimeciaManipLanguage> GameLanguages => Enum.GetValues<UltimeciaManipLanguage>();


    public SettingsPage()
    {
        InitializeComponent();
        Platform = App.Platform;
        GameLanguage = App.GameLanguage;
        CustomCardDelayFrames = App.DelayFrames;
        ShowRinoaParties = App.ShowRinoaParties;
        CloseButtonCommand = new AsyncCommand(Navigation.PopModalAsync);
    }

    private static void OnGameLanguageChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (newValue is UltimeciaManipLanguage gameLanguage) App.GameLanguage = gameLanguage;
    }

    private static void OnPlatformChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (newValue is Common.Platform platform) App.Platform = platform;
    }

    private static void OnCardDelayFramesChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (newValue is int frames) App.DelayFrames = frames;
        else if (newValue is null) App.DelayFrames = null;
    }


    public int? CustomCardDelayFrames
    {
        get => (int?)GetValue(CustomCardDelayFramesProperty);
        set => SetValue(CustomCardDelayFramesProperty, value);
    }

    public UltimeciaManipLanguage GameLanguage
    {
        get => (UltimeciaManipLanguage)GetValue(GameLanguageProperty);
        set => SetValue(GameLanguageProperty, value);
    }

    public Common.Platform Platform
    {
        get => (Common.Platform)GetValue(PlatformProperty);
        set => SetValue(PlatformProperty, value);
    }

    public static readonly BindableProperty CloseButtonCommandProperty = BindableProperty.Create(nameof(CloseButtonCommand), typeof(ICommand), typeof(SettingsPage), null);


    public ICommand CloseButtonCommand
    {
        get => (ICommand)GetValue(CloseButtonCommandProperty);
        set => SetValue(CloseButtonCommandProperty, value);
    }

    public static readonly BindableProperty AppVersionProperty = BindableProperty.Create(nameof(AppVersion), typeof(string), typeof(SettingsPage), AppInfo.VersionString);


    public string AppVersion
    {
        get => (string)GetValue(AppVersionProperty);
        set => SetValue(AppVersionProperty, value);
    }

    public static readonly BindableProperty ShowRinoaPartiesProperty = BindableProperty.Create(nameof(ShowRinoaParties), typeof(bool), typeof(SettingsPage), false, propertyChanged: OnShowRinoaPartiesChanged);

    public bool ShowRinoaParties
    {
        get => (bool)GetValue(ShowRinoaPartiesProperty);
        set => SetValue(ShowRinoaPartiesProperty, value);
    }

    private static void OnShowRinoaPartiesChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if (newValue is bool showRinoaParties) App.ShowRinoaParties = showRinoaParties;
    }

}