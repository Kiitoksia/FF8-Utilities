using FF8Utilities.MAUI.Models;
using SkiaSharp;

namespace FF8Utilities.MAUI.Controls;

public partial class CardTimerControl : ContentView
{
    private SKTypeface _typeface = SKTypeface.Default;
    private SKPaint _paint = new SKPaint { IsAntialias = true, IsStroke = false };
    private SKFont _font = new SKFont();

    private string _lastRenderedText = string.Empty;
    private Color _lastRenderedColor = Colors.Transparent;

    public CardTimerControl()
	{
		InitializeComponent();

        _font.Typeface = _typeface;
        _font.Size = 48;
        _font.Embolden = true;

        Unloaded += (s, e) =>
        {
            if (Model != null)
            {
                Model.RenderTimerTick -= Value_RenderTimerTick;
            }
        };
    }



	public CardManipulationModel Model
	{
		get => (CardManipulationModel)BindingContext;
		set
        {
            if (Model != null)
            {
                //Cleanup
                Model.RenderTimerTick -= Value_RenderTimerTick;
            }

            BindingContext = value;
            value.RenderTimerTick += Value_RenderTimerTick;
        }
    }

    private void Value_RenderTimerTick(object sender, EventArgs e)
    {
        if (Model == null) return;
        
        // Only invalidate if display content changed
        string currentText = $"{Model.RareCardTimer} {Model.Snake}";
        Color currentColor = Model.TextColourMaui;
        
        if (currentText != _lastRenderedText || currentColor != _lastRenderedColor)
        {
            _lastRenderedText = currentText;
            _lastRenderedColor = currentColor;
            SnakeView.InvalidateSurface();
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

        _paint.Color = Model.TextColourMaui.ToSKColor();
        float y = Math.Abs(_font.Metrics.Ascent);
        canvas.DrawText(text, 0, y, _font, _paint);
    }
}