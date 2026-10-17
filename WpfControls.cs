using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace comixpaint
{
    /// <summary>
    /// Konvertierungs-Hilfen zwischen GDI+ (System.Drawing) und WPF.
    /// </summary>
    public static class WpfImagingHelper
    {
        public static BitmapSource ToBitmapSource(this Bitmap bitmap)
        {
            if (bitmap == null)
            {
                return null;
            }

            var hBitmap = bitmap.GetHbitmap();
            try
            {
                return Imaging.CreateBitmapSourceFromHBitmap(
                    hBitmap,
                    IntPtr.Zero,
                    Int32Rect.Empty,
                    BitmapSizeOptions.FromEmptyOptions());
            }
            finally
            {
                DeleteObject(hBitmap);
            }
        }

        [DllImport("gdi32.dll")]
        private static extern bool DeleteObject(IntPtr hObject);

        public static System.Windows.Media.Color ToMediaColor(System.Drawing.Color color)
        {
            return System.Windows.Media.Color.FromArgb(color.A, color.R, color.G, color.B);
        }

        public static System.Drawing.Color ToDrawingColor(System.Windows.Media.Color color)
        {
            return System.Drawing.Color.FromArgb(color.A, color.R, color.G, color.B);
        }
    }

    /// <summary>
    /// WPF-Button mit WinForms-kompatibler Oberfläche (BackColor/ForeColor/Text).
    /// </summary>
    public class ColorButton : Button
    {
        public ColorButton()
        {
            BorderThickness = new Thickness(1);
            Padding = new Thickness(2);
            Template = CreateFlatTemplate();
        }

        public string Text
        {
            get => Content as string ?? string.Empty;
            set => Content = value;
        }

        public System.Drawing.Color BackColor
        {
            get => Background is SolidColorBrush b ? WpfImagingHelper.ToDrawingColor(b.Color) : System.Drawing.Color.Transparent;
            set => Background = new SolidColorBrush(WpfImagingHelper.ToMediaColor(value));
        }

        public System.Drawing.Color ForeColor
        {
            get => Foreground is SolidColorBrush b ? WpfImagingHelper.ToDrawingColor(b.Color) : System.Drawing.Color.Transparent;
            set => Foreground = new SolidColorBrush(WpfImagingHelper.ToMediaColor(value));
        }

        private static ControlTemplate CreateFlatTemplate()
        {
            var template = new ControlTemplate(typeof(ColorButton));

            var border = new FrameworkElementFactory(typeof(Border));
            border.SetValue(Border.BackgroundProperty, new TemplateBindingExtension(BackgroundProperty));
            border.SetValue(Border.BorderBrushProperty, new TemplateBindingExtension(BorderBrushProperty));
            border.SetValue(Border.BorderThicknessProperty, new TemplateBindingExtension(BorderThicknessProperty));
            border.SetValue(Border.PaddingProperty, new TemplateBindingExtension(PaddingProperty));

            var content = new FrameworkElementFactory(typeof(ContentPresenter));
            content.SetValue(ContentPresenter.HorizontalAlignmentProperty, HorizontalAlignment.Center);
            content.SetValue(ContentPresenter.VerticalAlignmentProperty, VerticalAlignment.Center);
            border.AppendChild(content);

            template.VisualTree = border;
            return template;
        }
    }

    /// <summary>
    /// WPF-TextBlock mit WinForms-kompatibler ForeColor-Eigenschaft.
    /// </summary>
    public class ColorTextBlock : TextBlock
    {
        public System.Drawing.Color ForeColor
        {
            get => Foreground is SolidColorBrush b ? WpfImagingHelper.ToDrawingColor(b.Color) : System.Drawing.Color.Transparent;
            set => Foreground = new SolidColorBrush(WpfImagingHelper.ToMediaColor(value));
        }
    }
}
