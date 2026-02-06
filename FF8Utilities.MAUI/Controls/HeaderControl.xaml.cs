using FF8Utilities.MAUI.Pages;
using System.Windows.Input;

namespace FF8Utilities.MAUI.Controls;

public partial class HeaderControl : ContentView
{

    public static readonly BindableProperty ShowBackButtonProperty = BindableProperty.Create(nameof(ShowBackButton), typeof(bool), typeof(HeaderControl), true, propertyChanged: ShowBackButtonChanged);

    public static readonly BindableProperty HeaderTextProperty = BindableProperty.Create(nameof(HeaderText), typeof(string), typeof(HeaderControl), null);

    public static readonly BindableProperty ShowSettingsProperty = BindableProperty.Create(nameof(ShowSettings), typeof(bool), typeof(HeaderControl), true, propertyChanged: ShowSettingsButtonChanged);

    public static readonly BindableProperty BackCommandProperty = BindableProperty.Create(nameof(BackCommand), typeof(ICommand), typeof(HeaderControl), null);

    public static readonly BindableProperty SettingsCommandProperty = BindableProperty.Create(nameof(SettingsCommand), typeof(ICommand), typeof(HeaderControl), null);

    public HeaderControl()
    {
        InitializeComponent();

        SettingsCommand = new AsyncCommand(async () =>
        {
            await MainThread.InvokeOnMainThreadAsync(async () =>
            {
                await Navigation.PushModalAsync(new SettingsPage());
            });

        });

        BackCommand = new AsyncCommand(async () =>
        {
            await MainThread.InvokeOnMainThreadAsync(async () =>
            {
                await Navigation.PopModalAsync();
            });
        });
    }    


    private static void ShowBackButtonChanged(BindableObject bindable, object oldValue, object newValue)
    {
        HeaderControl control = (HeaderControl)bindable;
        bool show = (bool)newValue;
        control.BackColumn.Width = new GridLength(show ? 50 : 0, GridUnitType.Absolute);
    }

    private static void ShowSettingsButtonChanged(BindableObject bindable, object oldValue, object newValue)
    {
        HeaderControl control = (HeaderControl)bindable;
        bool show = (bool)newValue;
        control.SettingsColumn.Width = new GridLength(show ? 50 : 0, GridUnitType.Absolute);
    }


    public ICommand BackCommand
    {
        get => (ICommand)GetValue(BackCommandProperty);
        set => SetValue(BackCommandProperty, value);
    }


    public string HeaderText
    {
        get => (string)GetValue(HeaderTextProperty);
        set => SetValue(HeaderTextProperty, value);
    }


    public ICommand SettingsCommand
    {
        get => (ICommand)GetValue(SettingsCommandProperty);
        set => SetValue(SettingsCommandProperty, value);
    }


    public bool ShowBackButton
    {
        get => (bool)GetValue(ShowBackButtonProperty);
        set => SetValue(ShowBackButtonProperty, value);
    }


    public bool ShowSettings
    {
        get => (bool)GetValue(ShowSettingsProperty);
        set => SetValue(ShowSettingsProperty, value);
    }
}