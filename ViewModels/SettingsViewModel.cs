using comixpaint.Services.Drawing;
using comixpaint.Services.State;
using CommunityToolkit.Mvvm.Input;
using mystical.Grafix.ShaderShapes;
using DrawingColor = System.Drawing.Color;

namespace comixpaint.ViewModels
{
    public partial class SettingsViewModel : ViewModelBase
    {
        private readonly SettingsService _settingsService;
        private readonly StateService _state;

        public DrawingColor PaintColor => _state.CurrentPaintcolor;

        public DrawingColor BorderColor => _state.CurrentBordercolor;

        public int CombinateMethod => _state.CombinateMethod;

        public int ShadeDirection
        {
            get => _state.CurrentShadeDirection;
            set
            {
                if (_state.CurrentShadeDirection == value)
                {
                    return;
                }

                _state.CurrentShadeDirection = value;
                OnPropertyChanged();
            }
        }

        public int LineWidthIndex
        {
            get => _state.CurrentLineWidth;
            set
            {
                if (_state.CurrentLineWidth == value)
                {
                    return;
                }

                _state.CurrentLineWidth = value;
                if (_state.CurrentImage != null && _state.SkizShape != null)
                {
                    _state.SkizShape.Linewidth = value;
                }
                OnPropertyChanged();
            }
        }

        public int ShadestepsIndex
        {
            get => _state.CurrentShadesteps - 1;
            set
            {
                var steps = value + 1;
                if (_state.CurrentShadesteps == steps)
                {
                    return;
                }

                _state.CurrentShadesteps = steps;
                if (_state.CurrentImage != null && _state.SkizShape != null)
                {
                    _state.SkizShape.Shadesteps = steps;
                }
                OnPropertyChanged();
            }
        }

        public bool AutoCutSave
        {
            get => _state.AutoCutSave;
            set
            {
                if (_state.AutoCutSave == value)
                {
                    return;
                }

                _state.AutoCutSave = value;
                OnPropertyChanged();
            }
        }

        public SettingsViewModel(SettingsService settingsService, StateService state)
        {
            _settingsService = settingsService;
            _state = state;
        }

        [RelayCommand]
        private void PickPaintColor()
        {
            using var dialog = new System.Windows.Forms.ColorDialog
            {
                Color = _state.CurrentPaintcolor,
                FullOpen = true
            };
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _state.CurrentPaintcolor = dialog.Color;
                _settingsService.PaintcolorChanged(dialog.Color);
                OnPropertyChanged(nameof(PaintColor));
            }
        }

        [RelayCommand]
        private void PickBorderColor()
        {
            using var dialog = new System.Windows.Forms.ColorDialog
            {
                Color = _state.CurrentBordercolor,
                FullOpen = true
            };
            if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _state.CurrentBordercolor = dialog.Color;
                _settingsService.BordercolorChanged(dialog.Color);
                OnPropertyChanged(nameof(BorderColor));
            }
        }

        [RelayCommand]
        private void SetCombinateNone() => SetCombinate(StateService.COMBINATE_NONE);

        [RelayCommand]
        private void SetCombinateAdd() => SetCombinate(StateService.COMBINATE_ADD);

        [RelayCommand]
        private void SetCombinateSub() => SetCombinate(StateService.COMBINATE_SUB);

        [RelayCommand]
        private void Shade(object parameter) => ShadeDirection = ParseDirection(parameter);

        private void SetCombinate(int method)
        {
            _settingsService.SetCombinate(method);
            OnPropertyChanged(nameof(CombinateMethod));
        }

        private static int ParseDirection(object parameter)
        {
            switch (parameter?.ToString())
            {
                case "topleft":
                    return ShaderShape.SHADEDIR_TOPLEFT;
                case "top":
                    return ShaderShape.SHADEDIR_TOP;
                case "topright":
                    return ShaderShape.SHADEDIR_TOPRIGHT;
                case "left":
                    return ShaderShape.SHADEDIR_LEFT;
                case "right":
                    return ShaderShape.SHADEDIR_RIGHT;
                case "bottomleft":
                    return ShaderShape.SHADEDIR_BOTTOMLEFT;
                case "bottom":
                    return ShaderShape.SHADEDIR_BOTTOM;
                case "bottomright":
                    return ShaderShape.SHADEDIR_BOTTOMRIGHT;
                default:
                    return ShaderShape.SHADEDIR_CENTER;
            }
        }
    }
}

