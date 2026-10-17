using System.Windows.Media;
using DrawingColor = System.Drawing.Color;

namespace comixpaint.Services.Palette
{
    public class PaletteColorItem
    {
        public string Name { get; }

        public DrawingColor Color { get; }

        public bool IsBorder { get; }

        public Brush Brush { get; }

        public Brush ForegroundBrush { get; }

        public PaletteColorItem(string name, DrawingColor color, bool isBorder)
        {
            Name = name;
            Color = color;
            IsBorder = isBorder;

            Brush = new SolidColorBrush(System.Windows.Media.Color.FromArgb(color.A, color.R, color.G, color.B));
            ForegroundBrush = color.GetBrightness() < 0.6f ? Brushes.White : Brushes.Black;
        }
    }
}
