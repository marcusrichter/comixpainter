using comixpaint.common;
using comixpaint.components;
using mystical.Grafix.ShaderShapes;

namespace comixpaint.controllers
{
    public class SystemController
    {
        private static SystemController instance = null;

        public static SystemController I()
        {
            if (instance == null)
            {
                instance = new SystemController();
            }

            return instance;
        }

        public SystemController()
        {
        }

        public void Init()
        {
            var comixImage = new ShaderShapeImage(
                ComixpaintSettings.Instance.DefaultWidth, 
                ComixpaintSettings.Instance.DefaultHeight
                );
            StateComponent.I().CurrentImage = comixImage;
            PaintComponent.I().InitPaint();
            MainForm.mainForm.ButtonBorderColor.BackColor = StateComponent.I().CurrentBordercolor;
            MainForm.mainForm.ButtonDrawingColor.BackColor = StateComponent.I().CurrentPaintcolor;
            MainForm.mainForm.ComboBoxColorSteps.SelectedIndex = StateComponent.I().CurrentShadesteps - 1;
            MainForm.mainForm.ComboBoxLineWidth.SelectedIndex = StateComponent.I().CurrentLineWidth;
            MainForm.mainForm.highlightButtonShading(StateComponent.I().CurrentShadeDirection);
        }
    }
}
