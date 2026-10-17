using comixpaint.Services.Palette;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Collections.ObjectModel;

namespace comixpaint.ViewModels
{
    public partial class PaletteManagerViewModel : DialogViewModelBase
    {
        private readonly PaletteService _paletteService;

        [ObservableProperty]
        private string _paletteFileName;

        [ObservableProperty]
        private bool _deleteMode;

        [ObservableProperty]
        private bool _renameMode;

        public ObservableCollection<PaletteColorItem> Colors { get; } = new ObservableCollection<PaletteColorItem>();

        public ObservableCollection<PaletteColorItem> BorderColors { get; } = new ObservableCollection<PaletteColorItem>();

        partial void OnDeleteModeChanged(bool value)
        {
            if (value)
            {
                RenameMode = false;
            }
        }

        partial void OnRenameModeChanged(bool value)
        {
            if (value)
            {
                DeleteMode = false;
            }
        }

        public PaletteManagerViewModel(PaletteService paletteService)
        {
            _paletteService = paletteService;
            Load();
        }

        [RelayCommand]
        private void LoadPalette()
        {
            _paletteService.LoadPath();
            Load();
        }

        [RelayCommand]
        private void SavePalette() => _paletteService.SavePath();

        [RelayCommand]
        private void ColorClick(object parameter)
        {
            if (!(parameter is PaletteColorItem item))
            {
                return;
            }

            if (RenameMode)
            {
                if (_paletteService.ShowRenameDialog(item.Name, item.Color, item.IsBorder))
                {
                    Load();
                }
            }
            else if (DeleteMode)
            {
                _paletteService.DeleteColor(item.Name, item.IsBorder);
                Load();
            }
            else
            {
                _paletteService.SelectColor(item.Name, item.IsBorder);
                Close();
            }
        }

        public void Load()
        {
            PaletteFileName = _paletteService.GetPaletteFileName();

            Colors.Clear();
            foreach (var item in _paletteService.GetColors())
            {
                Colors.Add(item);
            }

            BorderColors.Clear();
            foreach (var item in _paletteService.GetBorderColors())
            {
                BorderColors.Add(item);
            }
        }
    }
}
