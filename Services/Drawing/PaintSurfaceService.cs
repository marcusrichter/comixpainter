using comixpaint.Services.State;
using mystical.Data;
using mystical.Grafix.Data;
using mystical.Grafix.ShaderShapes;
using mysticalPlatform.imaging;
using System.Drawing;

namespace comixpaint.Services.Drawing
{
    public class PaintSurfaceService
    {
        private readonly StateService _state;

        public FastBitmap TemplateImage { get; set; }

        public FastBitmap Paintbitmap { get; set; }

        public PaintSurfaceService(StateService state)
        {
            _state = state;
        }

        /// <summary>
        /// creates an image on the paint panel
        /// </summary>
        public void InitPaint()
        {
            var imgsize = new Size(
                _state.CurrentImage.Width * _state.Zoomlevel,
                _state.CurrentImage.Height * _state.Zoomlevel
                );

            Paintbitmap = new FastBitmap(imgsize.Width, imgsize.Height);
            var paintimg = ((ConcreteDeviceBitmap)Paintbitmap.DeviceBitmap).WindowBitmap;
            Paintbitmap.FillWithColor(Color.White);

            MainForm.mainForm.SetPaintImage(paintimg);
        }

        public ShaderShape FinishShape()
        {
            if (_state.SkizShape != null)
            {
                _state.SkizShape.Linewidth = _state.CurrentLineWidth;
                if (_state.SkizShape.Points.Count <= 1)
                {
                    _state.SkizShape = null;
                }
                else
                {
                    var first_point = _state.SkizShape.Points[0];
                    var currentShape = _state.SkizShape;
                    if (currentShape.Shapetype == ShaderShape.SHAPETYPE_FREE)
                    {
                        currentShape.AddPoint(first_point.Point.X, first_point.Point.Y);
                    }

                    if (currentShape.Shapetype == ShaderShape.SHAPETYPE_FREE || currentShape.Shapetype == ShaderShape.SHAPETYPE_OVAL || currentShape.Shapetype == ShaderShape.SHAPETYPE_RECT)
                    {
                        if (_state.CombinateMethod == StateService.COMBINATE_ADD)
                        {
                            _state.CurrentImage.RemoveShape(currentShape);
                            if (_state.SelectedShape == null)
                            {
                                System.Windows.MessageBox.Show("Kein Shape ausgewählt", "Fehler");
                            }
                            else
                            {
                                _state.SelectedShape.AddShape(currentShape);
                            }
                            currentShape = _state.SelectedShape;
                            _state.SkizShape = null;
                        }
                        else if (_state.CombinateMethod == StateService.COMBINATE_SUB)
                        {
                            _state.CurrentImage.RemoveShape(currentShape);
                            if (_state.SelectedShape == null)
                            {
                                System.Windows.MessageBox.Show("Kein Shape ausgewählt", "Fehler");
                            }
                            else
                            {
                                _state.SelectedShape.SubShape(currentShape);
                            }
                            currentShape = _state.SelectedShape;
                            _state.SkizShape = null;
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
                    _state.SkizShape = null;

                    return currentShape;
                }
            }

            return null;
        }

        public void Repaint(bool invalidateAll = false)
        {
            var invalidateRect = _state.CurrentImage.Paint(invalidateAll);

            if (invalidateAll)
            {
                invalidateRect = new IntRect(
                    0,
                    0,
                    _state.CurrentImage.Width,
                    _state.CurrentImage.Height
                    );
            }

            if (invalidateRect != null)
            {
                ProjectPaint(invalidateRect.X, invalidateRect.Y, invalidateRect.Width, invalidateRect.Height);
            }

            MainForm.mainForm.InvalidatePaint();
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
                invwidth = _state.CurrentImage.Width - invx;
            }

            if (invheight == -1)
            {
                invheight = _state.CurrentImage.Height - invy;
            }

            Paintbitmap.LockBitmap();

            if (TemplateImage != null)
            {
                TemplateImage.LockBitmap();
            }

            var srcimage = _state.CurrentImage.Image;
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

                    for (var zoomed_iy = 0; zoomed_iy < _state.Zoomlevel; zoomed_iy++)
                    {
                        for (var zoomed_ix = 0; zoomed_ix < _state.Zoomlevel; zoomed_ix++)
                        {
                            var x = ix * _state.Zoomlevel + zoomed_ix;
                            var y = iy * _state.Zoomlevel + zoomed_iy;
                            if (x < Paintbitmap.Width && y < Paintbitmap.Height)
                            {
                                Paintbitmap.SetPixel(x, y, pixel);
                                if (!_state.TransparentTemplate && templatePixel != null && pixel.ToArgb() == Color.White.ToArgb())
                                {
                                    Paintbitmap.SetPixel(x, y, (Color)templatePixel);
                                }

                                if (_state.TransparentTemplate && templatePixel != null)
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
