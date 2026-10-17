using comixpaint.Services.Drawing;
using comixpaint.Services.State;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows;

namespace comixpaint.ViewModels
{
    public partial class ScaleViewModel : DialogViewModelBase
    {
        private readonly StateService _state;
        private readonly PaintSurfaceService _paintSurface;

        [ObservableProperty]
        private string _currentWidthText;

        [ObservableProperty]
        private string _currentHeightText;

        [ObservableProperty]
        private string _widthText;

        [ObservableProperty]
        private string _heightText;

        public ScaleViewModel(StateService state, PaintSurfaceService paintSurface)
        {
            _state = state;
            _paintSurface = paintSurface;

            var image = _state.CurrentImage;
            var width = image?.Width ?? 200;
            var height = image?.Height ?? 200;

            CurrentWidthText = width.ToString();
            CurrentHeightText = height.ToString();
            WidthText = CurrentWidthText;
            HeightText = CurrentHeightText;
        }

        [RelayCommand]
        private void Ok()
        {
            if (_state.CurrentImage == null ||
                !int.TryParse(WidthText, out var width) ||
                !int.TryParse(HeightText, out var height) ||
                width <= 0 ||
                height <= 0)
            {
                MessageBox.Show("Ungültige Dimension", "Fehler", MessageBoxButton.OK);
                return;
            }

            var image = _state.CurrentImage;
            var scaleX = (float)width / image.Width;
            var scaleY = (float)height / image.Height;

            image.Scale(scaleX, scaleY);
            _paintSurface.InitPaint();
            _paintSurface.Repaint(true);
            Close();
        }

        [RelayCommand]
        private void Cancel() => Close(false);
    }
}
