using CardManipulation;
using FF8Utilities.Common;
using FF8Utilities.MAUI.Controls;
using FF8Utilities.MAUI.Models;
using SkiaSharp;
using System.Collections.ObjectModel;

namespace FF8Utilities.MAUI.Pages.CardManipulationSubPages;

public partial class TimingPage : ContentPage
{
    private CardManip _manip = new CardManip();
    private SKTypeface _typeface = SKTypeface.Default;
    private SKPaint _paint = new SKPaint { IsAntialias = true, IsStroke = false };
    private SKFont _font = new SKFont();


    public TimingPage()
	{
		InitializeComponent();

        foreach (QuistisPattern enumValue in Enum.GetValues(typeof(QuistisPattern)))
        {
            if (enumValue == QuistisPattern.LateQuistis) continue; // Currently unsupported
            QuistisCardPatterns.Add(new PickerItem(enumValue.GetDescription(), enumValue));
        }

        QuistisCardPattern = QuistisCardPatterns[3]; // 4th Frame, to change

        _font.Typeface = _typeface;
        _font.Size = 32;     
        CreateManip();
        
    }

    public CardManipulationModel Model
    {
        get => (CardManipulationModel)BindingContext;
        private set => BindingContext = value;
    }


    private void CreateManip()
    {
        if (Model != null)
        {
            Model.RenderTimerTick -= Model_RenderTimerTick;
            Model.Dispose();            
            Model = null;
        }

        QuistisPattern pattern = (QuistisPattern)QuistisCardPattern.Value;

        CardManipulationModel model = new CardManipulationModel(_manip, pattern.GetCardResult(), "zellmama", DelayFrames, RNGModifier);
        model.RenderTimerTick += Model_RenderTimerTick;
        model.RecoveryPattern = "74441154176425316556";
        Model = model;        
    }

    private void Model_RenderTimerTick(object sender, EventArgs e)
    {
        SnakeView.InvalidateSurface();
    }

    public int DelayFrames
    {
        get => Preferences.Get(nameof(DelayFrames), 9);
        set
        {
            if (value == DelayFrames) return;
            Preferences.Set(nameof(DelayFrames), value);
            CreateManip();
        }
    }

    public static readonly BindableProperty RNGModifierProperty = BindableProperty.Create(nameof(RNGModifier), typeof(int?), typeof(TimingPage), null);


    public int? RNGModifier
    {
        get => (int?)GetValue(RNGModifierProperty);
        set
        {
            if (value == RNGModifier) return;
            SetValue(RNGModifierProperty, value);
            CreateManip();
        }
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        Model?.SubmitCommand.Execute(null);
    }

    public static readonly BindableProperty QuistisCardPatternsProperty = BindableProperty.Create(nameof(QuistisCardPatterns), typeof(ObservableCollection<PickerItem>), typeof(TimingPage), new ObservableCollection<PickerItem>());


    public ObservableCollection<PickerItem> QuistisCardPatterns
    {
        get => (ObservableCollection<PickerItem>)GetValue(QuistisCardPatternsProperty);
        set => SetValue(QuistisCardPatternsProperty, value);
    }

    public static readonly BindableProperty QuistisCardPatternProperty = BindableProperty.Create(nameof(QuistisCardPattern), typeof(PickerItem), typeof(TimingPage), null);


    public PickerItem QuistisCardPattern
    {
        get => (PickerItem)GetValue(QuistisCardPatternProperty);
        set
        {
            if (value == QuistisCardPattern) return;
            SetValue(QuistisCardPatternProperty, value);
            if (Model != null) CreateManip();
        }
    }


    private void SKCanvasView_PaintSurface(object sender, SkiaSharp.Views.Maui.SKPaintSurfaceEventArgs e)
    {
        SKCanvas canvas = e.Surface.Canvas;
        SKImageInfo info = e.Info;

        canvas.Clear(SKColors.Transparent);

        if (Model is null || info.Width <= 0 || info.Height <= 0)
            return;

        // Compose single-line text and sanitize newlines
        string text = $"{Model.RareCardTimer} {Model.Snake}";

        canvas.Save();
        canvas.ClipRect(new SKRect(0, 0, info.Width, info.Height));

        _paint.Color = Model.TextColourMaui.ToSKColor();
        canvas.DrawText(text, 0, 0, _font, _paint);
        canvas.Restore();
    }
}