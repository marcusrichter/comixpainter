using mystical.Data;
using mystical.Grafix.Data;
using mysticalPlatform.imaging;
using System;
using System.Drawing;

namespace comixpaint.components
{
    public class TemplateComponent : AbstractComponent
    {
        private static TemplateComponent instance = null;

        public Image Image { get; set; }

        public float Scale { get; set; } = 1.0f;

        public int TranslateX { get; set; } = 0;

        public int TranslateY { get; set; } = 0;

        public static TemplateComponent I()
        {
            if (instance == null)
            {
                instance = new TemplateComponent();
            }

            return instance;
        }

        public void LoadTemplate()
        {
            if (null == Image)
            {
                return;
            }

            PaintComponent.I().TemplateImage = new FastBitmap(StateComponent.I().CurrentImage.Width, StateComponent.I().CurrentImage.Height);

            var projectionRect = new IntRect();

            if (Image.Width > Image.Height)
            {
                projectionRect.X = 0;
                projectionRect.Width = PaintComponent.I().TemplateImage.Width;
                projectionRect.Height = (int)((float)Image.Height * (float)PaintComponent.I().TemplateImage.Width / (float)Image.Width);
                projectionRect.Height = Math.Min(PaintComponent.I().TemplateImage.Height, projectionRect.Height);
                projectionRect.Y = (PaintComponent.I().TemplateImage.Height - projectionRect.Height) / 2;
            }
            else
            {
                projectionRect.Y = 0;
                projectionRect.Height = PaintComponent.I().TemplateImage.Height;
                projectionRect.Width = (int)((float)Image.Width * (float)PaintComponent.I().TemplateImage.Height / (float)Image.Height);
                projectionRect.Width = Math.Min(PaintComponent.I().TemplateImage.Width, projectionRect.Width);
                projectionRect.X = (PaintComponent.I().TemplateImage.Width - projectionRect.Width) / 2;
            }

            projectionRect.X += TranslateX;
            projectionRect.Y += TranslateY;

            var g = Graphics.FromImage(((ConcreteDeviceBitmap)PaintComponent.I().TemplateImage.DeviceBitmap).WindowBitmap);
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

            PaintComponent.I().Repaint(true);
        }
    }
}
