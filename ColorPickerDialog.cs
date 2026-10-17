using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace comixpaint
{
    /// <summary>
    /// Minimaler WPF-Farbdialog als Ersatz für System.Windows.Forms.ColorDialog.
    /// </summary>
    public class ColorPickerDialog : Window
    {
        private readonly Slider _r;
        private readonly Slider _g;
        private readonly Slider _b;
        private readonly Border _preview;
        private readonly TextBlock _hexText;

        public System.Drawing.Color Color { get; private set; }

        public ColorPickerDialog(System.Drawing.Color initial)
        {
            Title = "Farbe wählen";
            Width = 380;
            SizeToContent = SizeToContent.Height;
            ResizeMode = ResizeMode.NoResize;
            WindowStartupLocation = WindowStartupLocation.CenterOwner;
            Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(64, 64, 64));

            var root = new StackPanel { Margin = new Thickness(16) };

            _preview = new Border
            {
                Height = 48,
                BorderBrush = Brushes.White,
                BorderThickness = new Thickness(1),
                Margin = new Thickness(0, 0, 0, 12)
            };
            root.Children.Add(_preview);

            _r = AddChannel(root, "Rot", initial.R);
            _g = AddChannel(root, "Grün", initial.G);
            _b = AddChannel(root, "Blau", initial.B);

            _hexText = new TextBlock
            {
                Foreground = Brushes.White,
                HorizontalAlignment = HorizontalAlignment.Center,
                Margin = new Thickness(0, 4, 0, 12)
            };
            root.Children.Add(_hexText);

            var buttons = new StackPanel
            {
                Orientation = Orientation.Horizontal,
                HorizontalAlignment = HorizontalAlignment.Right
            };
            var ok = new Button { Content = "OK", Width = 80, Margin = new Thickness(0, 0, 8, 0), IsDefault = true };
            ok.Click += (_, __) => DialogResult = true;
            var cancel = new Button { Content = "Abbrechen", Width = 80, IsCancel = true };
            buttons.Children.Add(ok);
            buttons.Children.Add(cancel);
            root.Children.Add(buttons);

            Content = root;

            UpdatePreview();
        }

        private Slider AddChannel(StackPanel root, string label, byte value)
        {
            var grid = new Grid { Margin = new Thickness(0, 4, 0, 4) };
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(50) });
            grid.ColumnDefinitions.Add(new ColumnDefinition());
            grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(36) });

            var name = new TextBlock
            {
                Text = label,
                Foreground = Brushes.White,
                VerticalAlignment = VerticalAlignment.Center
            };
            var slider = new Slider
            {
                Minimum = 0,
                Maximum = 255,
                Value = value,
                VerticalAlignment = VerticalAlignment.Center
            };
            var valueText = new TextBlock
            {
                Text = value.ToString(),
                Foreground = Brushes.White,
                VerticalAlignment = VerticalAlignment.Center,
                HorizontalAlignment = HorizontalAlignment.Right
            };

            slider.ValueChanged += (_, __) =>
            {
                valueText.Text = ((int)slider.Value).ToString();
                UpdatePreview();
            };

            Grid.SetColumn(name, 0);
            Grid.SetColumn(slider, 1);
            Grid.SetColumn(valueText, 2);
            grid.Children.Add(name);
            grid.Children.Add(slider);
            grid.Children.Add(valueText);
            root.Children.Add(grid);

            return slider;
        }

        private void UpdatePreview()
        {
            var color = System.Drawing.Color.FromArgb((int)_r.Value, (int)_g.Value, (int)_b.Value);
            Color = color;
            _preview.Background = new SolidColorBrush(System.Windows.Media.Color.FromRgb(color.R, color.G, color.B));
            _hexText.Text = $"#{color.R:X2}{color.G:X2}{color.B:X2}";
        }
    }
}
