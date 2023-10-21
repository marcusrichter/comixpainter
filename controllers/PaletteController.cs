using comixpaint.common;
using comixpaint.components;
using comixpaint.modals;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace comixpaint.controllers
{
    public class PaletteController
    {
        private static PaletteController instance = null;

        public static PaletteController I()
        {
            if (instance == null)
            {
                instance = new PaletteController();
            }

            return instance;
        }

        public void LoadPaletteManager()
        {
            var paletteManagerDialog = new PaletteManager();
            paletteManagerDialog.ShowDialog();
        }

        public void FillPaletteManager()
        {
            var paletteManager = PaletteManager.Instance;

            paletteManager.LabelPaletteFileName.Text = PaletteManagerComponent.I().GetPaletteFileName();

            var ix = 0;
            var iy = 0;

            var buttonWidth = 150;
            var buttonHeight = 30;

            for (var i = 0; i < 2; i++)
            {
                if (i == 1)
                {
                    if (ix != 0)
                    {
                        ix = 0;
                        iy++;
                    }
                    var location = new Point(ix * (buttonWidth + 5), iy * (buttonHeight + 20));
                    var labelBorders = new Label
                    {
                        Text = "Rahmenfarben:",
                        Location = location
                    };
                    paletteManager.PanelPallettes.Controls.Add(labelBorders);
                    iy++;
                }

                Dictionary<string, Color> dic = null;
                if (i == 0)
                {
                    dic = PaletteManagerComponent.I().Colors;
                }
                else
                {
                    dic = PaletteManagerComponent.I().BorderColors;
                }

                foreach (var colorKeyValue in dic.OrderBy(kv => kv.Key))
                {
                    var location = new Point(ix * (buttonWidth + 5), iy * (buttonHeight + 10));
                    if (location.X + buttonWidth + 30 > paletteManager.PanelPallettes.Width)
                    {
                        ix = 0;
                        iy++;
                        location.X = 0;
                        location.Y = iy * (buttonHeight + 10);
                    }

                    if (i == 1)
                    {
                        location.Y += 5;
                    }

                    var colorButton = new Button
                    {
                        BackColor = colorKeyValue.Value,
                        FlatStyle = FlatStyle.Flat,
                        Width = buttonWidth,
                        Height = buttonHeight
                    };

                    var brightness = colorKeyValue.Value.GetBrightness();

                    if (brightness < 0.6f)
                    {
                        colorButton.ForeColor = Color.White;
                    }
                    else
                    {
                        colorButton.ForeColor = Color.Black;
                    }

                    colorButton.Location = location;

                    colorButton.Text = colorKeyValue.Key;
                    if (i == 0)
                    {
                        colorButton.Click += (s, e) =>
                        {
                            if (PaletteManager.Instance.CheckBoxRename.Checked)
                            {
                                RenamePaletteColor(((Button)s));
                            }
                            else if (PaletteManager.Instance.CheckBoxDeleteModus.Checked)
                            {
                                DeletePaletteColor(((Button)s), ((Button)s).Text);
                            }
                            else
                            {
                                SelectPaletteColor(((Button)s).Text);
                            }
                        };
                    }
                    else
                    {
                        colorButton.Click += (s, e) =>
                        {

                            if (PaletteManager.Instance.CheckBoxRename.Checked)
                            {
                                RenamePaletteBorderColor(((Button)s));
                            }
                            else if (PaletteManager.Instance.CheckBoxDeleteModus.Checked)
                            {
                                DeletePaletteBorderColor(((Button)s), ((Button)s).Text);
                            }
                            else
                            {
                                SelectPaletteBorderColor(((Button)s).Text);
                            }
                        };
                    }

                    var toolTip = new ToolTip();
                    toolTip.SetToolTip(colorButton, colorKeyValue.Key);

                    paletteManager.PanelPallettes.Controls.Add(colorButton);

                    ix++;
                }
            }
        }

        public void SelectPaletteColor(string name)
        {
            var button = MainForm.mainForm.ButtonDrawingColor;

            StateComponent.I().CurrentPaintcolor = PaletteManagerComponent.I().Colors[name];
            button.BackColor = StateComponent.I().CurrentPaintcolor;
            button.Text = name;
            PaletteManager.Instance.Close();

            var brightness = StateComponent.I().CurrentPaintcolor.GetBrightness();

            if (brightness < 0.6f)
            {
                button.ForeColor = Color.White;
            }
            else
            {
                button.ForeColor = Color.Black;
            }
        }

        public void DeletePaletteColor(Button button, string name)
        {
            PaletteManagerComponent.I().Colors.Remove(name);
            PaletteManagerComponent.I().SavePalette();
            button.Parent.Controls.Remove(button);
        }

        public void SelectPaletteBorderColor(string name)
        {
            var button = MainForm.mainForm.ButtonBorderColor;

            StateComponent.I().CurrentBordercolor = PaletteManagerComponent.I().BorderColors[name];
            button.BackColor = StateComponent.I().CurrentBordercolor;
            button.Text = name;
            PaletteManager.Instance.Close();

            var brightness = StateComponent.I().CurrentBordercolor.GetBrightness();

            if (brightness < 0.6f)
            {
                button.ForeColor = Color.White;
            }
            else
            {
                button.ForeColor = Color.Black;
            }
        }

        public void DeletePaletteBorderColor(Button button, string name)
        {
            PaletteManagerComponent.I().BorderColors.Remove(name);
            PaletteManagerComponent.I().SavePalette();
            button.Parent.Controls.Remove(button);
        }

        public void AddColorToPalletteManagerDialog(bool isBorder)
        {
            var addToPaletterDialog = new AddToPaletteForm
            {
                IsBorder = isBorder
            };
            addToPaletterDialog.ShowDialog();
        }

        public void AddColorToPalletteManager()
        {
            var colorName = AddToPaletteForm.Instance.TextBoxName.Text;
            AddToPaletteForm.Instance.LabelError.ForeColor = Color.Red;
            AddToPaletteForm.Instance.LabelError.Text = string.Empty;

            if (colorName.Trim() == string.Empty)
            {
                AddToPaletteForm.Instance.LabelError.Text = "Name darf nicht leer sein";
                return;
            }

            if (!AddToPaletteForm.Instance.IsBorder)
            {
                if (!PaletteManagerComponent.I().Colors.ContainsKey(colorName))
                {
                    PaletteManagerComponent.I().Colors[colorName] = StateComponent.I().CurrentPaintcolor;
                    PaletteManagerComponent.I().SavePalette();
                    AddToPaletteForm.Instance.Close();
                    MessageBox.Show("Farbe hinzugefügt");
                }
                else
                {
                    AddToPaletteForm.Instance.LabelError.Text = "Farbe mit dem Namen schon vorhanden";
                }
            }
            else
            {
                if (!PaletteManagerComponent.I().BorderColors.ContainsKey(colorName))
                {
                    PaletteManagerComponent.I().BorderColors[colorName] = StateComponent.I().CurrentBordercolor;
                    PaletteManagerComponent.I().SavePalette();
                    AddToPaletteForm.Instance.Close();
                    MessageBox.Show("Farbe hinzugefügt");
                }
                else
                {
                    AddToPaletteForm.Instance.LabelError.Text = "Randfarbe mit dem Namen schon vorhanden";
                }
            }
        }

        public void SavePath()
        {
            MainForm.mainForm.SaveFileDialog.DefaultExt = "pal";
            MainForm.mainForm.SaveFileDialog.Filter = "Palette (*.pal)|*.pal";            
            if (ComixpaintSettings.Instance.PaletteDirectory != null && ComixpaintSettings.Instance.PaletteDirectory != string.Empty)
            {
                MainForm.mainForm.SaveFileDialog.InitialDirectory = ComixpaintSettings.Instance.PaletteDirectory;
            }

            //PaletteDirectory
            var res = MainForm.mainForm.SaveFileDialog.ShowDialog();
            if (res == DialogResult.OK)
            {
                var filepath = MainForm.mainForm.SaveFileDialog.FileName;
                var dirpath = Path.GetDirectoryName(filepath);
                ComixpaintSettings.Instance.PaletteDirectory = dirpath;
                ComixpaintSettings.Save();
                PaletteManagerComponent.I().PalettePath = filepath;
                PaletteManagerComponent.I().SavePalettePath();
                PaletteManagerComponent.I().SavePalette();
                MessageBox.Show("Palette erfolgreich abeglegt", "Info", MessageBoxButtons.OK);
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
            if (res == DialogResult.OK)
            {
                var filepath = MainForm.mainForm.OpenFileDialog.FileName;
                var dirpath = Path.GetDirectoryName(filepath);
                ComixpaintSettings.Instance.PaletteDirectory = dirpath;
                ComixpaintSettings.Save();
                PaletteManagerComponent.I().PalettePath = filepath;
                PaletteManagerComponent.I().SavePalettePath();
                PaletteManagerComponent.I().LoadPalette();
                MessageBox.Show("Palette erfolgreich geladen", "Info", MessageBoxButtons.OK);
                PaletteManager.Instance.Close();
            }
        }

        public void RenamePaletteColor(Button button)
        {
            var paletteColorRenameForm = new PalettColorRenameForm
            {
                PaletteButton = button
            };

            paletteColorRenameForm.TextBoxName.Text = button.Text;

            paletteColorRenameForm.ShowDialog();
        }

        public void RenamePaletteBorderColor(Button button)
        {
            var paletteColorRenameForm = new PalettColorRenameForm
            {
                PaletteButton = button,
                IsBorder = true,
            };

            paletteColorRenameForm.TextBoxName.Text = button.Text;

            paletteColorRenameForm.ShowDialog();
        }

        public void DoRenamePaletteColor()
        {
            var oldName = PalettColorRenameForm.Instance.PaletteButton.Text;
            var newName = PalettColorRenameForm.Instance.TextBoxName.Text.Trim();
            if (oldName != newName)
            {
                var color = PalettColorRenameForm.Instance.PaletteButton.BackColor;

                if (!PalettColorRenameForm.Instance.IsBorder)
                {
                    PaletteManagerComponent.I().Colors.Remove(oldName);
                    PaletteManagerComponent.I().Colors[newName] = color;
                }
                else
                {
                    PaletteManagerComponent.I().BorderColors.Remove(oldName);
                    PaletteManagerComponent.I().BorderColors[newName] = color;
                }

                PalettColorRenameForm.Instance.PaletteButton.Text = newName;

                PaletteManagerComponent.I().SavePalette();
            }

            PalettColorRenameForm.Instance.Close();
        }
    }
}
