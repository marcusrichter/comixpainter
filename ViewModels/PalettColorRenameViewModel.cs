using comixpaint.Services.Palette;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DrawingColor = System.Drawing.Color;

namespace comixpaint.ViewModels
{
    public partial class PalettColorRenameViewModel : DialogViewModelBase
    {
        private readonly PaletteService _paletteService;

        [ObservableProperty]
        private string _name;

        public string OldName { get; }
        public DrawingColor Color { get; }
        public bool IsBorder { get; }
        public bool Renamed { get; private set; }

        public PalettColorRenameViewModel(PaletteService paletteService, string oldName, DrawingColor color, bool isBorder)
        {
            _paletteService = paletteService;
            OldName = oldName;
            Color = color;
            IsBorder = isBorder;
            Name = oldName;
        }

        [RelayCommand]
        private void Confirm()
        {
            var newName = (Name ?? string.Empty).Trim();
            if (newName != OldName)
            {
                _paletteService.RenameColor(OldName, newName, Color, IsBorder);
                Renamed = true;
            }

            Close();
        }

        [RelayCommand]
        private void Cancel() => Close(false);
    }
}
