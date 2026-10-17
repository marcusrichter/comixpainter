using comixpaint.Services.State;
using mystical.Data.NoiseMaps;
using mystical.Grafix.Data;
using mysticalPlatform.imaging;
using System.Drawing;

namespace comixpaint.Services.Drawing
{
    public class TextureService
    {
        private readonly StateService _state;

        public TextureService(StateService state)
        {
            _state = state;
        }

        public void CreateLandNoise()
        {
            var colors = new Color[]
            {
                ColorFX.ParseColor("#999999"),
                ColorFX.ParseColor("#AAAAAA"),
                ColorFX.ParseColor("#BBBBBB"),
            };

            var noisemap = new SurfaceStains2(
                _state.CurrentImage.Width * 2,
                _state.CurrentImage.Height * 2,
                colors)
            {
                MaxDistort = 20
            };

            var texture = new FastBitmap(
                _state.CurrentImage.Width * 2,
                _state.CurrentImage.Height * 2);

            texture.LockBitmap();
            foreach (var p in texture.Points())
            {
                texture.SetPixel(p.X, p.Y, noisemap.GetVal(p.X, p.Y));
            }
            texture.UnlockBitmap();

            var paintimg = ((ConcreteDeviceBitmap)texture.DeviceBitmap).WindowBitmap;
            MainForm.mainForm.SetPaintImage(paintimg);
        }
    }
}
