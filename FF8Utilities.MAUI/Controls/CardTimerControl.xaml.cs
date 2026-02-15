using CommunityToolkit.Maui.Views;
using FF8Utilities.MAUI.Models;
using SkiaSharp;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace FF8Utilities.MAUI.Controls;

[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicProperties | DynamicallyAccessedMemberTypes.PublicMethods)]
public partial class CardTimerControl : ContentView
{
    private SKTypeface _typeface = SKTypeface.Default;
    private SKPaint _paint = new SKPaint { IsAntialias = true, IsStroke = false };
    private SKFont _font = new SKFont();

    private string _lastTimer = string.Empty;
    private string _lastSnake = string.Empty;
    private Color _lastRenderedColor = Colors.Transparent;
    private string _lastRenderedText = string.Empty;
    private bool _isUpdating = false;


    public CardTimerControl()
	{
		InitializeComponent();

        _font.Typeface = _typeface;
        _font.Size = 48;
        _font.Embolden = true;

        var timer = Application.Current.Dispatcher.CreateTimer();
        timer.Interval = TimeSpan.FromMilliseconds(16.67);
        timer.Tick += Timer_Tick;

        Loaded += (s, e) =>
        {
            timer.Start();
        };
        Unloaded += (s, e) =>
        {
            timer.Stop();
            timer.Tick -= Timer_Tick;
            timer = null;
        };
    }

    private void Timer_Tick(object sender, EventArgs e)
    {        
        if (_isUpdating) return;
        _isUpdating = true;
        try
        {
            Model.Refresh();
            string timer = Model.RareCardTimer;
            string snake = Model.Snake;
            Color currentColor = Model.TextColourMaui;

            if (timer != _lastTimer || snake != _lastSnake || currentColor != _lastRenderedColor)
            {
                _lastTimer = timer;
                _lastSnake = snake;
                _lastRenderedColor = currentColor;
                _lastRenderedText = $"{timer} {snake}";
                SnakeView.InvalidateSurface();
            }
        }
        finally
        {
            _isUpdating = false;
        }
           
    }

    public CardManipulationModel Model
	{
		get => (CardManipulationModel)BindingContext;
		set => BindingContext = value;
    }

    private void SKCanvasView_PaintSurface(object sender, SkiaSharp.Views.Maui.SKPaintSurfaceEventArgs e)
    {
        SKCanvas canvas = e.Surface.Canvas;
        SKImageInfo info = e.Info;

        canvas.Clear(SKColors.Transparent);

        if (Model is null || info.Width <= 0 || info.Height <= 0)
            return;

        _paint.Color = _lastRenderedColor.ToSKColor();
        float y = Math.Abs(_font.Metrics.Ascent);
        canvas.DrawText(_lastRenderedText, 0, y, _font, _paint);
    }
}