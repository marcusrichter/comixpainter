using comixpaint.components;
using mystical.Data.NoiseMaps;
using mystical.Grafix.Data;
using mysticalPlatform.imaging;
using System.Drawing;

namespace comixpaint.controllers
{
    public class TextureController
    {
        private static TextureController instance = null;

        public static TextureController I()
        {
            if (instance == null)
            {
                instance = new TextureController();
            }

            return instance;
        }

        public void CreateLandNoise()
        {
            var colors = new Color[] {
                    ColorFX.ParseColor("#999999"),
                    ColorFX.ParseColor("#AAAAAA"),
                    ColorFX.ParseColor("#BBBBBB"),
                };

            //var noisemap = new PerlinSimplexNoiseMap();
            //noisemap.StretchX = 10;
            var noisemap = new SurfaceStains2(StateComponent.I().CurrentImage.Width * 2, StateComponent.I().CurrentImage.Height * 2, colors)
            {
                MaxDistort = 20,

            };
            var texture = new FastBitmap(StateComponent.I().CurrentImage.Width * 2, StateComponent.I().CurrentImage.Height * 2);
            texture.LockBitmap();
            foreach (var p in texture.Points())
            {
                //var cValue = (int)(noisemap.GetVal(p.X, p.Y) * 255.0f);
                //texture.SetPixel(p.X, p.Y, Color.FromArgb(255, cValue, cValue, cValue));
                texture.SetPixel(p.X, p.Y, noisemap.GetVal(p.X, p.Y));
            }
            texture.UnlockBitmap();

            var paintimg = ((ConcreteDeviceBitmap)texture.DeviceBitmap).WindowBitmap;
            //paintimg.Save("tex.png");
            MainForm.mainForm.PictureBoxPaint.Image = paintimg;
        }
    }
}
