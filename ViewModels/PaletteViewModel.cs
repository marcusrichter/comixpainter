using comixpaint.Services.Palette;
using CommunityToolkit.Mvvm.Input;

namespace comixpaint.ViewModels
{
    public partial class PaletteViewModel : ViewModelBase
    {
        private readonly PaletteService _paletteService;

        public PaletteViewModel(PaletteService paletteService)
        {
            _paletteService = paletteService;
        }

        [RelayCommand]
        private void OpenPaletteManager() => _paletteService.LoadPaletteManager();

        [RelayCommand]
        private void AddColor() => _paletteService.AddColorToPalletteManagerDialog(false);

        [RelayCommand]
        private void AddBorderColor() => _paletteService.AddColorToPalletteManagerDialog(true);
    }
}
