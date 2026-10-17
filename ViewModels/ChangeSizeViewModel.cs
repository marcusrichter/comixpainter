using comixpaint.Services.Drawing;
using comixpaint.Services.State;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using mystical.Grafix.Data;
using System.Windows;

namespace comixpaint.ViewModels
{
    public partial class ChangeSizeViewModel : DialogViewModelBase
    {
        private readonly StateService _state;
        private readonly PaintSurfaceService _paintSurface;

        [ObservableProperty]
        private string _widthText;

        [ObservableProperty]
        private string _heightText;

        public ChangeSizeViewModel(StateService state, PaintSurfaceService paintSurface)
        {
            _state = state;
            _paintSurface = paintSurface;

            var image = _state.CurrentImage;
            WidthText = (image?.Width ?? 200).ToString();
            HeightText = (image?.Height ?? 200).ToString();
        }

        [RelayCommand]
        private void Ok()
        {
            int.TryParse(WidthText, out var width);
            int.TryParse(HeightText, out var height);
            if (width == 0 || height == 0)
            {
                MessageBox.Show("Ungültige Dimension", "Fehler", MessageBoxButton.OK);
                return;
            }

            _state.CurrentImage.Width = width;
            _state.CurrentImage.Height = height;
            _state.CurrentImage.Image = new FastBitmap(width, height);

            _paintSurface.InitPaint();
            _paintSurface.Repaint(true);
            Close();
        }

        [RelayCommand]
        private void Cancel() => Close(false);
    }
}
