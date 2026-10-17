using comixpaint.common;
using comixpaint.Services.Drawing;
using comixpaint.Services.State;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using mystical.Grafix.ShaderShapes;
using System.Windows;

namespace comixpaint.ViewModels
{
    public partial class NewImgViewModel : DialogViewModelBase
    {
        private readonly StateService _state;
        private readonly PaintSurfaceService _paintSurface;

        [ObservableProperty]
        private string _widthText;

        [ObservableProperty]
        private string _heightText;

        public NewImgViewModel(StateService state, PaintSurfaceService paintSurface)
        {
            _state = state;
            _paintSurface = paintSurface;

            WidthText = (ComixpaintSettings.Instance?.DefaultWidth ?? 200).ToString();
            HeightText = (ComixpaintSettings.Instance?.DefaultHeight ?? 200).ToString();
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

            var comixImg = new ShaderShapeImage(width, height);
            ComixpaintSettings.Instance.DefaultWidth = width;
            ComixpaintSettings.Instance.DefaultHeight = height;

            _state.CurrentImage = comixImg;
            _paintSurface.InitPaint();
            Close();
        }

        [RelayCommand]
        private void Cancel() => Close(false);
    }
}
