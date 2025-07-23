using FF8Utilities.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace FF8Utilities.Controls
{
    /// <summary>
    /// This is the fastest way to render a snake in WPF
    /// </summary>
    public class SnakeRenderer : FrameworkElement
    {
        private DrawingVisual _visual;
        private double? _pixelsPerDip;

        public SnakeRenderer()
        {
            _visual = new DrawingVisual();
            AddVisualChild(_visual);
            CompositionTarget.Rendering += OnRendering;
        }

        public CardManipulationModel Model
        {
            get => (CardManipulationModel)DataContext;
            set => DataContext = value;
        }


        protected override int VisualChildrenCount => 1;
        protected override Visual GetVisualChild(int index) => _visual;

        protected override Size MeasureOverride(Size availableSize)
        {
            double width = double.IsInfinity(availableSize.Width) ? 0 : availableSize.Width;
            double height = double.IsInfinity(availableSize.Height) ? 0 : availableSize.Height;
            return new Size(width, height);
        }

        protected override Size ArrangeOverride(Size finalSize)
        {
            // Accept the final layout size given
            return finalSize;
        }

        private void OnRendering(object sender, EventArgs e)
        {
            if (_pixelsPerDip == null)
            {
                _pixelsPerDip = VisualTreeHelper.GetDpi(this).PixelsPerDip;
            }

            using (var context = _visual.RenderOpen())
            {
                var text = new FormattedText(
                $"{Model.RareCardTimer} {Model.Snake}",
                CultureInfo.InvariantCulture,
                FlowDirection.LeftToRight,
                new Typeface("Consolas"),
                18,
                Model.TextColor,
                _pixelsPerDip.Value
                );

                context.DrawText(text, new Point(0,0));
            }
        }
    }
}
