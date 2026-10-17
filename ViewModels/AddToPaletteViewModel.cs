using comixpaint.Services.Palette;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace comixpaint.ViewModels
{
    public partial class AddToPaletteViewModel : DialogViewModelBase
    {
        private readonly PaletteService _paletteService;

        [ObservableProperty]
        private string _colorName = string.Empty;

        [ObservableProperty]
        private string _errorText = string.Empty;

        public bool IsBorder { get; }

        public AddToPaletteViewModel(PaletteService paletteService, bool isBorder)
        {
            _paletteService = paletteService;
            IsBorder = isBorder;
        }

        [RelayCommand]
        private void Confirm()
        {
            var error = _paletteService.AddColor(ColorName, IsBorder);
            if (error != null)
            {
                ErrorText = error;
                return;
            }

            Close();
        }

        [RelayCommand]
        private void Cancel() => Close(false);
    }
}
