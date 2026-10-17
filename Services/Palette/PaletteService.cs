using comixpaint.common;
using comixpaint.modals;
using comixpaint.Services.State;
using comixpaint.ViewModels;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using DrawingColor = System.Drawing.Color;

namespace comixpaint.Services.Palette
{
    public class PaletteService
    {
        private readonly StateService _state;
        private readonly PaletteStorageService _paletteStorage;

        public PaletteService(StateService state, PaletteStorageService paletteStorage)
        {
            _state = state;
            _paletteStorage = paletteStorage;
        }

        public void LoadPaletteManager()
        {
            var viewModel = new PaletteManagerViewModel(this);
            var dialog = new PaletteManager(viewModel);
            dialog.ShowDialog();
        }

        public string GetPaletteFileName()
        {
            return _paletteStorage.GetPaletteFileName();
        }

        public List<PaletteColorItem> GetColors()
        {
            return _paletteStorage.Colors
                .OrderBy(kv => kv.Key)
                .Select(kv => new PaletteColorItem(kv.Key, kv.Value, false))
                .ToList();
        }

        public List<PaletteColorItem> GetBorderColors()
        {
            return _paletteStorage.BorderColors
                .OrderBy(kv => kv.Key)
                .Select(kv => new PaletteColorItem(kv.Key, kv.Value, true))
                .ToList();
        }

        public void SelectColor(string name, bool isBorder)
        {
            if (!isBorder)
            {
                var button = MainForm.mainForm.ButtonDrawingColor;

                _state.CurrentPaintcolor = _paletteStorage.Colors[name];
                button.BackColor = _state.CurrentPaintcolor;
                button.Text = name;

                var brightness = _state.CurrentPaintcolor.GetBrightness();
                button.ForeColor = brightness < 0.6f ? DrawingColor.White : DrawingColor.Black;
            }
            else
            {
                var button = MainForm.mainForm.ButtonBorderColor;

                _state.CurrentBordercolor = _paletteStorage.BorderColors[name];
                button.BackColor = _state.CurrentBordercolor;
                button.Text = name;

                var brightness = _state.CurrentBordercolor.GetBrightness();
                button.ForeColor = brightness < 0.6f ? DrawingColor.White : DrawingColor.Black;
            }
        }

        public void DeleteColor(string name, bool isBorder)
        {
            if (!isBorder)
            {
                _paletteStorage.Colors.Remove(name);
            }
            else
            {
                _paletteStorage.BorderColors.Remove(name);
            }

            _paletteStorage.SavePalette();
        }

        public void AddColorToPalletteManagerDialog(bool isBorder)
        {
            var viewModel = new AddToPaletteViewModel(this, isBorder);
            var dialog = new AddToPaletteForm(viewModel);
            dialog.ShowDialog();
        }

        public string AddColor(string name, bool isBorder)
        {
            var colorName = (name ?? string.Empty).Trim();
            if (colorName == string.Empty)
            {
                return "Name darf nicht leer sein";
            }

            if (!isBorder)
            {
                if (!_paletteStorage.Colors.ContainsKey(colorName))
                {
                    _paletteStorage.Colors[colorName] = _state.CurrentPaintcolor;
                    _paletteStorage.SavePalette();
                    return null;
                }

                return "Farbe mit dem Namen schon vorhanden";
            }

            if (!_paletteStorage.BorderColors.ContainsKey(colorName))
            {
                _paletteStorage.BorderColors[colorName] = _state.CurrentBordercolor;
                _paletteStorage.SavePalette();
                return null;
            }

            return "Randfarbe mit dem Namen schon vorhanden";
        }

        public void SavePath()
        {
            MainForm.mainForm.SaveFileDialog.DefaultExt = "pal";
            MainForm.mainForm.SaveFileDialog.Filter = "Palette (*.pal)|*.pal";
            if (ComixpaintSettings.Instance.PaletteDirectory != null && ComixpaintSettings.Instance.PaletteDirectory != string.Empty)
            {
                MainForm.mainForm.SaveFileDialog.InitialDirectory = ComixpaintSettings.Instance.PaletteDirectory;
            }

            var res = MainForm.mainForm.SaveFileDialog.ShowDialog();
            if (res == true)
            {
                var filepath = MainForm.mainForm.SaveFileDialog.FileName;
                var dirpath = Path.GetDirectoryName(filepath);
                ComixpaintSettings.Instance.PaletteDirectory = dirpath;
                ComixpaintSettings.Save();
                _paletteStorage.PalettePath = filepath;
                _paletteStorage.SavePalettePath();
                _paletteStorage.SavePalette();
                MessageBox.Show("Palette erfolgreich abeglegt", "Info", MessageBoxButton.OK);
            }
        }

        public void LoadPath()
        {
            MainForm.mainForm.OpenFileDialog.DefaultExt = "pal";
            MainForm.mainForm.OpenFileDialog.Filter = "Palette (*.pal)|*.pal";
            if (ComixpaintSettings.Instance.PaletteDirectory != null && ComixpaintSettings.Instance.PaletteDirectory != string.Empty)
            {
                MainForm.mainForm.OpenFileDialog.InitialDirectory = ComixpaintSettings.Instance.PaletteDirectory;
            }

            var res = MainForm.mainForm.OpenFileDialog.ShowDialog();
            if (res == true)
            {
                var filepath = MainForm.mainForm.OpenFileDialog.FileName;
                var dirpath = Path.GetDirectoryName(filepath);
                ComixpaintSettings.Instance.PaletteDirectory = dirpath;
                ComixpaintSettings.Save();
                _paletteStorage.PalettePath = filepath;
                _paletteStorage.SavePalettePath();
                _paletteStorage.LoadPalette();
                MessageBox.Show("Palette erfolgreich geladen", "Info", MessageBoxButton.OK);
            }
        }

        public bool ShowRenameDialog(string name, DrawingColor color, bool isBorder)
        {
            var viewModel = new PalettColorRenameViewModel(this, name, color, isBorder);
            var dialog = new PalettColorRenameForm(viewModel);
            dialog.ShowDialog();
            return viewModel.Renamed;
        }

        public void RenameColor(string oldName, string newName, DrawingColor color, bool isBorder)
        {
            if (!isBorder)
            {
                _paletteStorage.Colors.Remove(oldName);
                _paletteStorage.Colors[newName] = color;
            }
            else
            {
                _paletteStorage.BorderColors.Remove(oldName);
                _paletteStorage.BorderColors[newName] = color;
            }

            _paletteStorage.SavePalette();
        }
    }
}
