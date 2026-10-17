using comixpaint.Services.State;
using mystical.Data;
using mystical.Grafix.Data;
using mysticalPlatform.imaging;
using System;
using System.Drawing;

namespace comixpaint.Services.Drawing
{
    public class TemplateService
    {
        private readonly StateService _state;
        private readonly PaintSurfaceService _paintSurface;

        public Image Image { get; set; }

        public float Scale { get; set; } = 1.0f;

        public int TranslateX { get; set; } = 0;

        public int TranslateY { get; set; } = 0;

        public TemplateService(StateService state, PaintSurfaceService paintSurface)
        {
            _state = state;
            _paintSurface = paintSurface;
        }

        public void LoadTemplate()
        {
            if (null == Image)
            {
                return;
            }

            _paintSurface.TemplateImage = new FastBitmap(_state.CurrentImage.Width, _state.CurrentImage.Height);

            var projectionRect = new IntRect();

            if (Image.Width > Image.Height)
            {
                projectionRect.X = 0;
                projectionRect.Width = _paintSurface.TemplateImage.Width;
                projectionRect.Height = (int)((float)Image.Height * (float)_paintSurface.TemplateImage.Width / (float)Image.Width);
                projectionRect.Height = Math.Min(_paintSurface.TemplateImage.Height, projectionRect.Height);
                projectionRect.Y = (_paintSurface.TemplateImage.Height - projectionRect.Height) / 2;
            }
            else
            {
                projectionRect.Y = 0;
                projectionRect.Height = _paintSurface.TemplateImage.Height;
                projectionRect.Width = (int)((float)Image.Width * (float)_paintSurface.TemplateImage.Height / (float)Image.Height);
                projectionRect.Width = Math.Min(_paintSurface.TemplateImage.Width, projectionRect.Width);
                projectionRect.X = (_paintSurface.TemplateImage.Width - projectionRect.Width) / 2;
            }

            projectionRect.X += TranslateX;
            projectionRect.Y += TranslateY;

            var g = Graphics.FromImage(((ConcreteDeviceBitmap)_paintSurface.TemplateImage.DeviceBitmap).WindowBitmap);
            g.Clear(Color.White);

            var scaleCorrectedDstWidth = (int)((float)projectionRect.Width * Scale);
            var scaleCorrectedDstHeight = (int)((float)projectionRect.Height * Scale);

            var widthIncrease = projectionRect.Width - scaleCorrectedDstWidth;
            var heightIncrease = projectionRect.Height - scaleCorrectedDstHeight;

            var destRectangle = new Rectangle(
                projectionRect.X + widthIncrease / 2,
                projectionRect.Y + heightIncrease / 2,
                scaleCorrectedDstWidth,
                scaleCorrectedDstHeight
                );

            var srcRectangle = new Rectangle(
                0,
                0,
                Image.Width,
                Image.Height
                );

            g.DrawImage(Image, destRectangle, srcRectangle, GraphicsUnit.Pixel);

            _paintSurface.Repaint(true);
        }
    }
}
