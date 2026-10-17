using comixpaint.Services.Drawing;
using CommunityToolkit.Mvvm.Input;

namespace comixpaint.ViewModels
{
    public partial class MenuViewModel : ViewModelBase
    {
        private readonly MenuService _menuService;

        public MenuViewModel(MenuService menuService)
        {
            _menuService = menuService;
        }

        [RelayCommand]
        private void NewImage() => _menuService.NewImage();

        [RelayCommand]
        private void SavePng() => _menuService.SavePng();

        [RelayCommand]
        private void SaveCmx() => _menuService.SaveCmx();

        [RelayCommand]
        private void SaveCmxAndPng() => _menuService.SaveCmxAndPng();

        [RelayCommand]
        private void LoadCmx() => _menuService.LoadCmx();

        [RelayCommand]
        private void AddCmx() => _menuService.AddCmx();

        [RelayCommand]
        private void LoadTemplate() => _menuService.LoadTemplate();

        [RelayCommand]
        private void RemoveTemplate() => _menuService.RemoveTemplate();

        [RelayCommand]
        private void TransparentTemplate() => _menuService.TransparentTemplate();

        [RelayCommand]
        private void NotTransparentTemplate() => _menuService.NotTransparentTemplate();

        [RelayCommand]
        private void LastShadeDelete() => _menuService.LastShadeDelete();

        [RelayCommand]
        private void LastShadeNewShade() => _menuService.LastShadeNewShade();

        [RelayCommand]
        private void AutoCut() => _menuService.AutoCut();

        [RelayCommand]
        private void Undo() => _menuService.Undo();

        [RelayCommand]
        private void ChangeSize() => _menuService.ChangeSize();

        [RelayCommand]
        private void MirrorX() => _menuService.MirrorX();

        [RelayCommand]
        private void MirrorY() => _menuService.MirrorY();

        [RelayCommand]
        private void Rotate() => _menuService.Rotate();

        [RelayCommand]
        private void Scale() => _menuService.Scale();

        [RelayCommand]
        private void Zoom(object parameter) => _menuService.Zoom(ParseZoom(parameter));

        private static int ParseZoom(object parameter)
        {
            if (parameter != null && int.TryParse(parameter.ToString(), out var value))
            {
                return value;
            }

            return 1;
        }
    }
}

