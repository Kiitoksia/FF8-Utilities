using CardManipulation;
using FF8Utilities.MAUI.Controls;
using FF8Utilities.MAUI.Models;
using SkiaSharp;

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

        CardManipulationModel model = new CardManipulationModel(_manip, 0x65c6be07, "zellmama", DelayFrames, RNGModifier);
        model.RenderTimerTick += Model_RenderTimerTick;
        model.RecoveryPattern = "74441154176425316556";
        Model = model;        
    }

    private void Model_RenderTimerTick(object? sender, EventArgs e)
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

    

    private void SKCanvasView_PaintSurface(object sender, SkiaSharp.Views.Maui.SKPaintSurfaceEventArgs e)
    {
        var canvas = e.Surface.Canvas;
        var info = e.Info;

        canvas.Clear(SKColors.Transparent);

        if (Model is null || info.Width <= 0 || info.Height <= 0)
            return;

        // Compose single-line text and sanitize newlines
        var text = $"{Model.RareCardTimer} {Model.Snake}";

        canvas.Save();
        canvas.ClipRect(new SKRect(0, 0, info.Width, info.Height));

        var c = Model.TextColourMaui;
        _paint.Color = new SKColor(
            (byte)(c.Red * 255),
            (byte)(c.Green * 255),
            (byte)(c.Blue * 255),
            (byte)(c.Alpha * 255));

        var metrics = _font.Metrics; // SKFontMetrics
        var lineHeight = metrics.Descent - metrics.Ascent;
        var baseline = (info.Height - lineHeight) * 0.5f - metrics.Ascent;

        // Draw at left edge; alignment is controlled by x-coordinate
        canvas.DrawText(text, 0, baseline, _font, _paint);

        canvas.Restore();
    }
}