using comixpaint.common;
using comixpaint.Services.Drawing;
using comixpaint.Services.State;
using mystical.Grafix.ShaderShapes;

namespace comixpaint.Services.App
{
    public class SystemService
    {
        private readonly StateService _state;
        private readonly PaintSurfaceService _paintSurface;

        public SystemService(StateService state, PaintSurfaceService paintSurface)
        {
            _state = state;
            _paintSurface = paintSurface;
        }

        public void Init()
        {
            var comixImage = new ShaderShapeImage(
                ComixpaintSettings.Instance.DefaultWidth,
                ComixpaintSettings.Instance.DefaultHeight
                );

            _state.CurrentImage = comixImage;
            _paintSurface.InitPaint();
            MainForm.mainForm.ButtonBorderColor.BackColor = _state.CurrentBordercolor;
            MainForm.mainForm.ButtonDrawingColor.BackColor = _state.CurrentPaintcolor;
            MainForm.mainForm.ComboBoxColorSteps.SelectedIndex = _state.CurrentShadesteps - 1;
            MainForm.mainForm.ComboBoxLineWidth.SelectedIndex = _state.CurrentLineWidth;
            MainForm.mainForm.highlightButtonShading(_state.CurrentShadeDirection);
        }
    }
}
