using comixpaint.Services.Ai;
using comixpaint.Services.Drawing;
using comixpaint.Services.State;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace comixpaint.ViewModels
{
    public partial class AiImageGenerationViewModel : DialogViewModelBase
    {
        private readonly AiDrawingService _aiService;
        private readonly StateService _state;
        private readonly PaintSurfaceService _paintSurface;

        [ObservableProperty]
        private string _prompt = string.Empty;

        [ObservableProperty]
        private bool _useCurrentImage;

        [ObservableProperty]
        private string _statusText = string.Empty;

        [ObservableProperty]
        private bool _isBusy;

        public bool IsNotBusy => !IsBusy;

        public AiImageGenerationViewModel(AiDrawingService aiService, StateService state, PaintSurfaceService paintSurface)
        {
            _aiService = aiService;
            _state = state;
            _paintSurface = paintSurface;
        }

        partial void OnIsBusyChanged(bool value)
        {
            OnPropertyChanged(nameof(IsNotBusy));
        }

        [RelayCommand]
        private async Task GenerateAsync()
        {
            var prompt = (Prompt ?? string.Empty).Trim();

            if (string.IsNullOrEmpty(prompt))
            {
                MessageBox.Show("Bitte geben Sie eine Beschreibung ein", "Fehler", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                IsBusy = true;
                StatusText = "Generiere Bild...";

                var currentImage = _state.CurrentImage;
                var width = currentImage?.Width ?? 200;
                var height = currentImage?.Height ?? 200;
                var template = UseCurrentImage ? currentImage : null;

                var shaderShapeImage = await _aiService.CreateImageAsync(prompt, width, height, template);

                _state.CurrentImage = shaderShapeImage;
                _paintSurface.InitPaint();
                _paintSurface.Repaint(true);

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Fehler beim Generieren: {ex.Message}", "Fehler", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                IsBusy = false;
                StatusText = string.Empty;
            }
        }

        [RelayCommand]
        private void Cancel() => Close(false);
    }
}
