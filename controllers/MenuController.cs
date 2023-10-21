using comixpaint.common;
using comixpaint.components;
using comixpaint.modals;
using mystical.Data.Functions;
using mystical.Grafix.Data;
using mystical.Grafix.ShaderShapes;
using mystical.Model;
using mysticalPlatform.imaging;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace comixpaint.controllers
{
    public class MenuController
    {
        private static MenuController instance = null;

        public static MenuController I()
        {
            if (instance == null)
            {
                instance = new MenuController();
            }

            return instance;
        }

        public MenuController()
        {
        }

        public void NewImage()
        {
            var newImgDialog = new NewImgDialog();
            newImgDialog.Show();
        }

        public void Zoom(int zoomlevel)
        {
            StateComponent.I().Zoomlevel = zoomlevel;
            PaintComponent.I().InitPaint();
            PaintComponent.I().Repaint(true);
        }

        public void LastShadeDelete()
        {
            if (StateComponent.I().CurrentImage != null && StateComponent.I().CurrentImage.Shapes.Count > 0)
            {
                var last_shade = StateComponent.I().CurrentImage.Shapes[StateComponent.I().CurrentImage.Shapes.Count - 1];
                StateComponent.I().CurrentImage.Shapes.Remove(last_shade);
                PaintComponent.I().Repaint(true);
            }
        }

        public void LastShadeNewShade()
        {
            if (StateComponent.I().CurrentImage != null && StateComponent.I().CurrentImage.Shapes.Count > 0)
            {
                var shape = StateComponent.I().CurrentImage.Shapes[StateComponent.I().CurrentImage.Shapes.Count - 1];
                shape.Paintcolor = StateComponent.I().CurrentPaintcolor;
                shape.Bordercolor = StateComponent.I().CurrentBordercolor;
                shape.Linewidth = StateComponent.I().CurrentLineWidth;
                shape.Shadedir = StateComponent.I().CurrentShadeDirection;
                shape.Shadesteps = StateComponent.I().CurrentShadesteps;
                shape.Clear();
            }
            PaintComponent.I().Repaint();
        }

        public void MirrorX()
        {
            if (StateComponent.I().CurrentImage != null && StateComponent.I().CurrentImage.Shapes.Count > 0)
            {
                StateComponent.I().CurrentImage.MirrorX();
                PaintComponent.I().Repaint(true);
            }
        }

        public void MirrorY()
        {
            if (StateComponent.I().CurrentImage != null && StateComponent.I().CurrentImage.Shapes.Count > 0)
            {
                StateComponent.I().CurrentImage.MirrorY();
                PaintComponent.I().Repaint(true);
            }
        }

        public void SaveCmx()
        {
            if (StateComponent.I().CurrentImage == null)
            {
                MessageBox.Show("Kein Bild", "Fehler", MessageBoxButtons.OK);
                return;
            }
            MainForm.mainForm.SaveFileDialog.DefaultExt = "cmx";
            MainForm.mainForm.SaveFileDialog.Filter = "Cmx Datei (*.cmx)|*.cmx";
            if (ComixpaintSettings.Instance.CmxDirectory != null && ComixpaintSettings.Instance.CmxDirectory != string.Empty)
            {
                MainForm.mainForm.SaveFileDialog.InitialDirectory = ComixpaintSettings.Instance.CmxDirectory;
            }

            var res = MainForm.mainForm.SaveFileDialog.ShowDialog();
            if (res == DialogResult.OK)
            {
                var filepath = MainForm.mainForm.SaveFileDialog.FileName;
                var dirpath = Path.GetDirectoryName(filepath);
                StateComponent.I().CurrentImage.RemoveSkizShapes();
                ComixpaintSettings.Instance.CmxDirectory = dirpath;
                ComixpaintSettings.Save();

                StateComponent.I().CurrentImage.SaveToFile(filepath);
                MessageBox.Show("Bild erfolgreich gespeichert", "Speicherung", MessageBoxButtons.OK);
            }
        }


        public void SaveCmxAndPng()
        {
            if (StateComponent.I().CurrentImage == null)
            {
                MessageBox.Show("Kein Bild", "Fehler", MessageBoxButtons.OK);
                return;
            }
            MainForm.mainForm.SaveFileDialog.DefaultExt = "cmx";
            MainForm.mainForm.SaveFileDialog.Filter = "Cmx Datei (*.cmx)|*.cmx";
            if (ComixpaintSettings.Instance.CmxDirectory != null && ComixpaintSettings.Instance.CmxDirectory != string.Empty)
            {
                MainForm.mainForm.SaveFileDialog.InitialDirectory = ComixpaintSettings.Instance.CmxDirectory;
            }

            var res = MainForm.mainForm.SaveFileDialog.ShowDialog();
            if (res == DialogResult.OK)
            {
                var filepath = MainForm.mainForm.SaveFileDialog.FileName;
                var dirpath = Path.GetDirectoryName(filepath);
                StateComponent.I().CurrentImage.RemoveSkizShapes();
                ComixpaintSettings.Instance.CmxDirectory = dirpath;
                ComixpaintSettings.Save();
                
                StateComponent.I().CurrentImage.SaveToFile(filepath);

                var filepathPng = filepath.Replace(".cmx", ".png");
                var img = StateComponent.I().CurrentImage.Image;
                img.MakeTransparent(Color.White);
                ((ConcreteDeviceBitmap)img.DeviceBitmap).WindowBitmap.Save(filepathPng, ImageFormat.Png);

                MessageBox.Show("Png und Cmx erfolgreich gespeichert", "Speicherung", MessageBoxButtons.OK);
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

            if (res == DialogResult.OK)
            {
                var filepath = MainForm.mainForm.OpenFileDialog.FileName;
                var dirpath = Path.GetDirectoryName(filepath);
                ComixpaintSettings.Instance.CmxDirectory = dirpath;
                ComixpaintSettings.Save();

                var comixImage = AbstractModel.LoadObject<ShaderShapeImage>(filepath.Replace(".png", ".cmx"));

                StateComponent.I().CurrentImage = comixImage;
                PaintComponent.I().InitPaint();
                PaintComponent.I().Repaint(true);
            }
        }

        public void SavePng()
        {
            if (StateComponent.I().CurrentImage == null)
            {
                MessageBox.Show("Kein Bild", "Fehler", MessageBoxButtons.OK);
                return;
            }

            MainForm.mainForm.SaveFileDialog.DefaultExt = "png";
            MainForm.mainForm.SaveFileDialog.Filter = "PNG Datei (*.png)|*.png";
            if (ComixpaintSettings.Instance.PngDirectory != null && ComixpaintSettings.Instance.PngDirectory != string.Empty)
            {
                MainForm.mainForm.SaveFileDialog.InitialDirectory = ComixpaintSettings.Instance.PngDirectory;
            }

            var res = MainForm.mainForm.SaveFileDialog.ShowDialog();
            if (res == DialogResult.OK)
            {
                var filepath = MainForm.mainForm.SaveFileDialog.FileName;
                var dirpath = Path.GetDirectoryName(filepath);
                ComixpaintSettings.Instance.PngDirectory = dirpath;
                ComixpaintSettings.Save();

                var img = StateComponent.I().CurrentImage.Image;
                if (MainForm.mainForm.CheckBoxAutocatSave.Checked)
                {
                    var autocut_rect = BitmapFunctions.GetBoundaries(img, Color.White);
                    var autocut_img = new FastBitmap((int)autocut_rect.Width, (int)autocut_rect.Height);
                    autocut_img.DrawBitmap(0, 0, img, (int)autocut_rect.X, (int)autocut_rect.Y, (int)autocut_rect.Width, (int)autocut_rect.Height);
                    img = autocut_img;
                }

                //var shaperect=shape.Image.Image.getBoundaries(System.Drawing.Color.White);
                img.MakeTransparent(Color.White);

                ((ConcreteDeviceBitmap)img.DeviceBitmap).WindowBitmap.Save(filepath, ImageFormat.Png);
                MessageBox.Show("PNG erfolgreich gespeichert", "Speicherung", MessageBoxButtons.OK);
            }
        }

        public void AutoCut()
        {
            if (StateComponent.I().CurrentImage == null)
            {
                MessageBox.Show("Kein Bild", "Fehler", MessageBoxButtons.OK);
                return;
            }

            long? minx = null;
            long? miny = null;
            long? maxx = null;
            long? maxy = null;

            foreach (var shape in StateComponent.I().CurrentImage.Shapes)
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

                if (maxx == null || maxx > StateComponent.I().CurrentImage.Width)
                {
                    maxx = StateComponent.I().CurrentImage.Width;
                }

                if (maxy == null || maxy > StateComponent.I().CurrentImage.Height)
                {
                    maxy = StateComponent.I().CurrentImage.Height;
                }
            }
            
            StateComponent.I().CurrentImage.Width = (int)maxx - (int)minx + 1;
            StateComponent.I().CurrentImage.Height = (int)maxy - (int)miny + 1;
            StateComponent.I().CurrentImage.Image = new FastBitmap(StateComponent.I().CurrentImage.Width, StateComponent.I().CurrentImage.Height);

            foreach (var shape in StateComponent.I().CurrentImage.Shapes)
            {
                shape.TranslateX -= (int)minx;
                shape.TranslateY -= (int)miny;
                //shape.Resize(StateComponent.I().CurrentImage.Width, StateComponent.I().CurrentImage.Height, (int)minx, (int)miny);
            }

            PaintComponent.I().InitPaint();
            PaintComponent.I().Repaint(true);
        }

        public void LoadTemplate()
        {
            if (ComixpaintSettings.Instance.TemplateDirectory != null && ComixpaintSettings.Instance.TemplateDirectory != string.Empty)
            {
                MainForm.mainForm.OpenFileDialog.InitialDirectory = ComixpaintSettings.Instance.TemplateDirectory;
            }
            var res = MainForm.mainForm.OpenFileDialog.ShowDialog();
  
            if (res == DialogResult.OK)
            {
                var filepath = MainForm.mainForm.OpenFileDialog.FileName;

                var dirpath = Path.GetDirectoryName(filepath);
                ComixpaintSettings.Instance.TemplateDirectory = dirpath;
                ComixpaintSettings.Save();

                var img = Image.FromFile(filepath);

                TemplateComponent.I().Scale = 1.0f;
                TemplateComponent.I().TranslateX = 0;
                TemplateComponent.I().TranslateY = 0;
                TemplateComponent.I().Image = img;
                TemplateComponent.I().LoadTemplate();
            }
        }

        public void RemoveTemplate()
        {
            PaintComponent.I().TemplateImage = null;
            PaintComponent.I().Repaint(true);
        }

        public void TransparentTemplate()
        {
            StateComponent.I().TransparentTemplate = true;
            PaintComponent.I().Repaint(true);
        }

        public void NotTransparentTemplate()
        {
            StateComponent.I().TransparentTemplate = false;
            PaintComponent.I().Repaint(true);
        }

        public void Rotate()
        {
            if (StateComponent.I().CurrentImage != null && StateComponent.I().CurrentImage.Shapes.Count > 0)
            {
                StateComponent.I().CurrentImage.Rotate();
                PaintComponent.I().Repaint(true);
            }
        }

        public void Undo()
        {
            var restoreImage = HistoryComponent.I().Pop();
            if (restoreImage != null)
            {
                StateComponent.I().CurrentImage = restoreImage;
                PaintComponent.I().Repaint(true);
            }
        }

        public void ChangeSize()
        {
            var changeSizeDialog = new ChangeSizeDialog();

            changeSizeDialog.ShowDialog();
        }
    }
}
