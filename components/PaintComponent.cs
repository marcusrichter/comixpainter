using mystical.Data;
using mystical.Grafix.Data;
using mystical.Grafix.ShaderShapes;
using mysticalPlatform.imaging;
using System.Drawing;

namespace comixpaint.components
{
    public class PaintComponent
    {
        private static PaintComponent instance = null;

        public static PaintComponent I()
        {
            if (instance == null)
            {
                instance = new PaintComponent();
            }

            return instance;
        }

        public FastBitmap TemplateImage { get; set; }

        public FastBitmap Paintbitmap { get; set; }

        public PaintComponent()
        {
        }

        /// <summary>
        /// creates an image on the paint panel
        /// </summary>
        public void InitPaint()
        {
            var imgsize = new Size(
                StateComponent.I().CurrentImage.Width * StateComponent.I().Zoomlevel,
                StateComponent.I().CurrentImage.Height * StateComponent.I().Zoomlevel
                );

            Paintbitmap = new FastBitmap(imgsize.Width, imgsize.Height);
            var paintimg = ((ConcreteDeviceBitmap)Paintbitmap.DeviceBitmap).WindowBitmap;
            Paintbitmap.FillWithColor(Color.White);

            MainForm.mainForm.PictureBoxPaint.Image = paintimg;

            MainForm.mainForm.PictureBoxPaint.Size = imgsize;

            MainForm.mainForm.PictureBoxPaint.Update();
            MainForm.mainForm.PictureBoxPaint.Show();
        }

        public ShaderShape FinishShape()
        {
            if (StateComponent.I().SkizShape != null)
            {
                StateComponent.I().SkizShape.Linewidth = StateComponent.I().CurrentLineWidth;
                if (StateComponent.I().SkizShape.Points.Count <= 1)
                {
                    StateComponent.I().SkizShape = null;
                }
                else
                {
                    var first_point = StateComponent.I().SkizShape.Points[0];
                    var currentShape = StateComponent.I().SkizShape;
                    if (currentShape.Shapetype == ShaderShape.SHAPETYPE_FREE)
                    {
                        currentShape.AddPoint(first_point.Point.X, first_point.Point.Y);
                    }

                    if (currentShape.Shapetype == ShaderShape.SHAPETYPE_FREE || currentShape.Shapetype == ShaderShape.SHAPETYPE_OVAL || currentShape.Shapetype == ShaderShape.SHAPETYPE_RECT)
                    {
                        if (StateComponent.I().CombinateMethod == StateComponent.COMBINATE_ADD)
                        {
                            StateComponent.I().CurrentImage.RemoveShape(currentShape);
                            //add shape to selected shape
                            if (StateComponent.I().SelectedShape == null)
                            {
                                System.Windows.Forms.MessageBox.Show("Kein Shape ausgewählt", "Fehler");
                            }
                            else
                            {
                                StateComponent.I().SelectedShape.AddShape(currentShape);
                            }
                            currentShape = StateComponent.I().SelectedShape;
                            StateComponent.I().SkizShape = null;
                        }
                        else if (StateComponent.I().CombinateMethod == StateComponent.COMBINATE_SUB)
                        {
                            StateComponent.I().CurrentImage.RemoveShape(currentShape);
                            //sub shape to selected shape
                            if (StateComponent.I().SelectedShape == null)
                            {
                                System.Windows.Forms.MessageBox.Show("Kein Shape ausgewählt", "Fehler");
                            }
                            else
                            {
                                StateComponent.I().SelectedShape.SubShape(currentShape);

                            }
                            currentShape = StateComponent.I().SelectedShape;
                            StateComponent.I().SkizShape = null;
                        }
                    }

                    Repaint();
                    if (currentShape != null)
                    {
                        currentShape.SkizMode = false;
                        currentShape.ClipAndTranslate();                        
                        currentShape.Paint();                        
                    }

                    Repaint(true);
                    StateComponent.I().SkizShape = null;

                    return currentShape;
                }
            }

            return null;
        }

        public void Repaint(bool invalidateAll = false)
        {
            var invalidateRect = StateComponent.I().CurrentImage.Paint(invalidateAll);

            if (invalidateAll)
            {
                invalidateRect = new IntRect(
                    0, 
                    0, 
                    StateComponent.I().CurrentImage.Width, 
                    StateComponent.I().CurrentImage.Height
                    );
            }

            if (invalidateRect != null)
            {
                ProjectPaint(invalidateRect.X, invalidateRect.Y, invalidateRect.Width, invalidateRect.Height);

                var region = new Region(new Rectangle(
                    invalidateRect.X * StateComponent.I().Zoomlevel,
                    invalidateRect.Y * StateComponent.I().Zoomlevel,
                    invalidateRect.Width * StateComponent.I().Zoomlevel,
                    invalidateRect.Height * StateComponent.I().Zoomlevel
                    ));

                MainForm.mainForm.PictureBoxPaint.Invalidate(region);
            }
            else
            {
                MainForm.mainForm.PictureBoxPaint.Invalidate();
            }
        }

        private void ProjectPaint(int invx = 0, int invy = 0, int invwidth = -1, int invheight = -1)
        {
            if (invx < 0)
            {
                invx = 0;
            }

            if (invy < 0)
            {
                invy = 0;
            }

            if (invwidth == -1)
            {
                invwidth = StateComponent.I().CurrentImage.Width - invx;
            }

            if (invheight == -1)
            {
                invheight = StateComponent.I().CurrentImage.Height - invy;
            }

            Paintbitmap.LockBitmap();

            if (TemplateImage != null)
            {
                TemplateImage.LockBitmap();
            }

            var srcimage = StateComponent.I().CurrentImage.Image;
            srcimage.LockBitmap();

            for (var iy = invy; iy < invy + invheight; iy++)
            {
                for (var ix = invx; ix < invx + invwidth; ix++)
                {
                    if (ix >= srcimage.Width || iy >= srcimage.Height)
                    {
                        continue;
                    }

                    var pixel = srcimage.GetPixel(ix, iy);
                    Color? templatePixel = null;
                    if (TemplateImage != null)
                    {
                        templatePixel = TemplateImage.GetPixel(ix, iy);
                    }

                    for (var zoomed_iy = 0; zoomed_iy < StateComponent.I().Zoomlevel; zoomed_iy++)
                    {
                        for (var zoomed_ix = 0; zoomed_ix < StateComponent.I().Zoomlevel; zoomed_ix++)
                        {
                            var x = ix * StateComponent.I().Zoomlevel + zoomed_ix;
                            var y = iy * StateComponent.I().Zoomlevel + zoomed_iy;
                            if (x < Paintbitmap.Width && y < Paintbitmap.Height)
                            {
                                Paintbitmap.SetPixel(x, y, pixel);
                                if (!StateComponent.I().TransparentTemplate && templatePixel != null && pixel.ToArgb() == Color.White.ToArgb())
                                {
                                    Paintbitmap.SetPixel(x, y, (Color)templatePixel);
                                }

                                if (StateComponent.I().TransparentTemplate && templatePixel != null)
                                {
                                    var mixedPixel = ColorFX.CombineColors(pixel, (Color)templatePixel);                                    
                                    Paintbitmap.SetPixel(x, y, mixedPixel);
                                }
                            }
                        }
                    }
                }
            }

            Paintbitmap.UnlockBitmap();
            srcimage.UnlockBitmap();
            if (TemplateImage != null)
            {
                TemplateImage.UnlockBitmap();
            }
        }
    }
}
