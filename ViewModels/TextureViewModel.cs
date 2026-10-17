using comixpaint.Services.Drawing;
using CommunityToolkit.Mvvm.Input;

namespace comixpaint.ViewModels
{
    public partial class TextureViewModel : ViewModelBase
    {
        private readonly TextureService _textureService;

        public TextureViewModel(TextureService textureService)
        {
            _textureService = textureService;
        }

        [RelayCommand]
        private void CreateLandNoise() => _textureService.CreateLandNoise();
    }
}
