using comixpaint.common;
using comixpaint.modals;
using comixpaint.Services.State;
using comixpaint.ViewModels;
using mystical.Data.Functions;
using mystical.Grafix.Data;
using mystical.Grafix.ShaderShapes;
using mystical.Model;
using mysticalPlatform.imaging;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows;

namespace comixpaint.Services.Drawing
{
    public class MenuService
    {
        private readonly StateService _state;
        private readonly PaintSurfaceService _paintSurface;
        private readonly HistoryService _history;
        private readonly TemplateService _template;

        public MenuService(StateService state, PaintSurfaceService paintSurface, HistoryService history, TemplateService template)
        {
            _state = state;
            _paintSurface = paintSurface;
            _history = history;
            _template = template;
        }

        public void NewImage()
        {
            var viewModel = new NewImgViewModel(_state, _paintSurface);
            var dialog = new NewImgDialog(viewModel);
            dialog.Show();
        }

        public void Zoom(int zoomlevel)
        {
            _state.Zoomlevel = zoomlevel;
            _paintSurface.InitPaint();
            _paintSurface.Repaint(true);
        }

        public void LastShadeDelete()
        {
            if (_state.CurrentImage != null && _state.CurrentImage.Shapes.Count > 0)
            {
                var last_shade = _state.CurrentImage.Shapes[_state.CurrentImage.Shapes.Count - 1];
                _state.CurrentImage.Shapes.Remove(last_shade);
                _paintSurface.Repaint(true);
            }
        }

        public void LastShadeNewShade()
        {
            if (_state.CurrentImage != null && _state.CurrentImage.Shapes.Count > 0)
            {
                var shape = _state.CurrentImage.Shapes[_state.CurrentImage.Shapes.Count - 1];
                shape.Paintcolor = _state.CurrentPaintcolor;
                shape.Bordercolor = _state.CurrentBordercolor;
                shape.Linewidth = _state.CurrentLineWidth;
                shape.Shadedir = _state.CurrentShadeDirection;
                shape.Shadesteps = _state.CurrentShadesteps;
                shape.Clear();
            }
            _paintSurface.Repaint();
        }

        public void MirrorX()
        {
            if (_state.CurrentImage != null && _state.CurrentImage.Shapes.Count > 0)
            {
                _state.CurrentImage.MirrorX();
                _paintSurface.Repaint(true);
            }
        }

        public void MirrorY()
        {
            if (_state.CurrentImage != null && _state.CurrentImage.Shapes.Count > 0)
            {
                _state.CurrentImage.MirrorY();
                _paintSurface.Repaint(true);
            }
        }

        public void SaveCmx()
        {
            if (_state.CurrentImage == null)
            {
                MessageBox.Show("Kein Bild", "Fehler", MessageBoxButton.OK);
                return;
            }
            MainForm.mainForm.SaveFileDialog.DefaultExt = "cmx";
            MainForm.mainForm.SaveFileDialog.Filter = "Cmx Datei (*.cmx)|*.cmx";
            if (ComixpaintSettings.Instance.CmxDirectory != null && ComixpaintSettings.Instance.CmxDirectory != string.Empty)
            {
                MainForm.mainForm.SaveFileDialog.InitialDirectory = ComixpaintSettings.Instance.CmxDirectory;
            }

            var res = MainForm.mainForm.SaveFileDialog.ShowDialog();
            if (res == true)
            {
                var filepath = MainForm.mainForm.SaveFileDialog.FileName;
                var dirpath = Path.GetDirectoryName(filepath);
                _state.CurrentImage.RemoveSkizShapes();
                ComixpaintSettings.Instance.CmxDirectory = dirpath;
                ComixpaintSettings.Save();

                _state.CurrentImage.SaveToFile(filepath);
                MessageBox.Show("Bild erfolgreich gespeichert", "Speicherung", MessageBoxButton.OK);
            }
        }

        public void SaveCmxAndPng()
        {
            if (_state.CurrentImage == null)
            {
                MessageBox.Show("Kein Bild", "Fehler", MessageBoxButton.OK);
                return;
            }
            MainForm.mainForm.SaveFileDialog.DefaultExt = "cmx";
            MainForm.mainForm.SaveFileDialog.Filter = "Cmx Datei (*.cmx)|*.cmx";
            if (ComixpaintSettings.Instance.CmxDirectory != null && ComixpaintSettings.Instance.CmxDirectory != string.Empty)
            {
                MainForm.mainForm.SaveFileDialog.InitialDirectory = ComixpaintSettings.Instance.CmxDirectory;
            }

            var res = MainForm.mainForm.SaveFileDialog.ShowDialog();
            if (res == true)
            {
                var filepath = MainForm.mainForm.SaveFileDialog.FileName;
                var dirpath = Path.GetDirectoryName(filepath);
                _state.CurrentImage.RemoveSkizShapes();
                ComixpaintSettings.Instance.CmxDirectory = dirpath;
                ComixpaintSettings.Save();

                _state.CurrentImage.SaveToFile(filepath);

                var filepathPng = filepath.Replace(".cmx", ".png");
                var img = _state.CurrentImage.Image;
                img.MakeTransparent(Color.White);
                ((ConcreteDeviceBitmap)img.DeviceBitmap).WindowBitmap.Save(filepathPng, ImageFormat.Png);

                MessageBox.Show("Png und Cmx erfolgreich gespeichert", "Speicherung", MessageBoxButton.OK);
            }
        }

        public void LoadCmx()
        {
            MainForm.mainForm.SaveFileDialog.DefaultExt = "cmx";
            MainForm.mainForm.SaveFileDialog.Filter = "Cmx Datei (*.cmx)|*.cmx";
            if (ComixpaintSettings.Instance.CmxDirectory != null && ComixpaintSettings.Instance.CmxDirectory != string.Empty)
            {
                MainForm.mainForm.OpenFileDialog.InitialDirectory = ComixpaintSettings.Instance.CmxDirectory;
            }
            var res = MainForm.mainForm.OpenFileDialog.ShowDialog();

            if (res == true)
            {
                var filepath = MainForm.mainForm.OpenFileDialog.FileName;
                var dirpath = Path.GetDirectoryName(filepath);
                ComixpaintSettings.Instance.CmxDirectory = dirpath;
                ComixpaintSettings.Save();

                var comixImage = AbstractModel.LoadObject<ShaderShapeImage>(filepath.Replace(".png", ".cmx"));

                _state.CurrentImage = comixImage;
                _paintSurface.InitPaint();
                _paintSurface.Repaint(true);
            }
        }

        public void AddCmx()
        {
            if (_state.CurrentImage == null)
            {
                MessageBox.Show("Kein Bild", "Fehler", MessageBoxButton.OK);
                return;
            }

            MainForm.mainForm.SaveFileDialog.DefaultExt = "cmx";
            MainForm.mainForm.SaveFileDialog.Filter = "Cmx Datei (*.cmx)|*.cmx";
            if (ComixpaintSettings.Instance.CmxDirectory != null && ComixpaintSettings.Instance.CmxDirectory != string.Empty)
            {
                MainForm.mainForm.OpenFileDialog.InitialDirectory = ComixpaintSettings.Instance.CmxDirectory;
            }
            var res = MainForm.mainForm.OpenFileDialog.ShowDialog();

            if (res == true)
            {
                var filepath = MainForm.mainForm.OpenFileDialog.FileName;
                var dirpath = Path.GetDirectoryName(filepath);
                ComixpaintSettings.Instance.CmxDirectory = dirpath;
                ComixpaintSettings.Save();

                var imageToAdd = AbstractModel.LoadObject<ShaderShapeImage>(filepath.Replace(".png", ".cmx"));
                _state.CurrentImage.AddShaderShapeImage(imageToAdd);
                _paintSurface.Repaint(true);
            }
        }

        public void SavePng()
        {
            if (_state.CurrentImage == null)
            {
                MessageBox.Show("Kein Bild", "Fehler", MessageBoxButton.OK);
                return;
            }

            MainForm.mainForm.SaveFileDialog.DefaultExt = "png";
            MainForm.mainForm.SaveFileDialog.Filter = "PNG Datei (*.png)|*.png";
            if (ComixpaintSettings.Instance.PngDirectory != null && ComixpaintSettings.Instance.PngDirectory != string.Empty)
            {
                MainForm.mainForm.SaveFileDialog.InitialDirectory = ComixpaintSettings.Instance.PngDirectory;
            }

            var res = MainForm.mainForm.SaveFileDialog.ShowDialog();
            if (res == true)
            {
                var filepath = MainForm.mainForm.SaveFileDialog.FileName;
                var dirpath = Path.GetDirectoryName(filepath);
                ComixpaintSettings.Instance.PngDirectory = dirpath;
                ComixpaintSettings.Save();

                var img = _state.CurrentImage.Image;
                if (_state.AutoCutSave)
                {
                    var autocut_rect = BitmapFunctions.GetBoundaries(img, Color.White);
                    var autocut_img = new FastBitmap((int)autocut_rect.Width, (int)autocut_rect.Height);
                    autocut_img.DrawBitmap(0, 0, img, (int)autocut_rect.X, (int)autocut_rect.Y, (int)autocut_rect.Width, (int)autocut_rect.Height);
                    img = autocut_img;
                }

                img.MakeTransparent(Color.White);

                ((ConcreteDeviceBitmap)img.DeviceBitmap).WindowBitmap.Save(filepath, ImageFormat.Png);
                MessageBox.Show("PNG erfolgreich gespeichert", "Speicherung", MessageBoxButton.OK);
            }
        }

        public void AutoCut()
        {
            if (_state.CurrentImage == null)
            {
                MessageBox.Show("Kein Bild", "Fehler", MessageBoxButton.OK);
                return;
            }

            long? minx = null;
            long? miny = null;
            long? maxx = null;
            long? maxy = null;

            foreach (var shape in _state.CurrentImage.Shapes)
            {
                var shaperect = BitmapFunctions.GetBoundaries(shape.RenderImage, Color.White);

                if (shape.Linewidth == 0)
                {
                    shaperect.X--;
                    shaperect.Y--;
                }

                shaperect.X += shape.TranslateX;
                shaperect.Y += shape.TranslateY;

                if (minx == null || minx > shaperect.X)
                {
                    minx = shaperect.X;
                }

                if (miny == null || miny > shaperect.Y)
                {
                    miny = shaperect.Y;
                }

                if (maxx == null || maxx < shaperect.EX)
                {
                    maxx = shaperect.EX;
                }

                if (maxy == null || maxy < shaperect.EY)
                {
                    maxy = shaperect.EY;
                }

                if (minx == null || minx < 0)
                {
                    minx = 0;
                }

                if (miny == null || miny < 0)
                {
                    miny = 0;
                }

                if (maxx == null || maxx > _state.CurrentImage.Width)
                {
                    maxx = _state.CurrentImage.Width;
                }

                if (maxy == null || maxy > _state.CurrentImage.Height)
                {
                    maxy = _state.CurrentImage.Height;
                }
            }

            _state.CurrentImage.Width = (int)maxx - (int)minx + 1;
            _state.CurrentImage.Height = (int)maxy - (int)miny + 1;
            _state.CurrentImage.Image = new FastBitmap(_state.CurrentImage.Width, _state.CurrentImage.Height);

            foreach (var shape in _state.CurrentImage.Shapes)
            {
                shape.TranslateX -= (int)minx;
                shape.TranslateY -= (int)miny;
            }

            _paintSurface.InitPaint();
            _paintSurface.Repaint(true);
        }

        public void LoadTemplate()
        {
            if (ComixpaintSettings.Instance.TemplateDirectory != null && ComixpaintSettings.Instance.TemplateDirectory != string.Empty)
            {
                MainForm.mainForm.OpenFileDialog.InitialDirectory = ComixpaintSettings.Instance.TemplateDirectory;
            }
            var res = MainForm.mainForm.OpenFileDialog.ShowDialog();

            if (res == true)
            {
                var filepath = MainForm.mainForm.OpenFileDialog.FileName;

                var dirpath = Path.GetDirectoryName(filepath);
                ComixpaintSettings.Instance.TemplateDirectory = dirpath;
                ComixpaintSettings.Save();

                var img = Image.FromFile(filepath);

                _template.Scale = 1.0f;
                _template.TranslateX = 0;
                _template.TranslateY = 0;
                _template.Image = img;
                _template.LoadTemplate();
            }
        }

        public void RemoveTemplate()
        {
            _paintSurface.TemplateImage = null;
            _paintSurface.Repaint(true);
        }

        public void TransparentTemplate()
        {
            _state.TransparentTemplate = true;
            _paintSurface.Repaint(true);
        }

        public void NotTransparentTemplate()
        {
            _state.TransparentTemplate = false;
            _paintSurface.Repaint(true);
        }

        public void Rotate()
        {
            if (_state.CurrentImage != null && _state.CurrentImage.Shapes.Count > 0)
            {
                _state.CurrentImage.Rotate();
                _paintSurface.Repaint(true);
            }
        }

        public void Undo()
        {
            var restoreImage = _history.Pop();
            if (restoreImage != null)
            {
                _state.CurrentImage = restoreImage;
                _paintSurface.Repaint(true);
            }
        }

        public void ChangeSize()
        {
            var viewModel = new ChangeSizeViewModel(_state, _paintSurface);
            var dialog = new ChangeSizeDialog(viewModel);
            dialog.ShowDialog();
        }

        public void Scale()
        {
            if (_state.CurrentImage == null)
            {
                MessageBox.Show("Kein Bild", "Fehler", MessageBoxButton.OK);
                return;
            }

            var viewModel = new ScaleViewModel(_state, _paintSurface);
            var dialog = new ScaleDialog(viewModel);
            dialog.ShowDialog();
        }
    }
}
