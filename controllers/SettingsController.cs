using comixpaint.components;
using System.Drawing;

namespace comixpaint.controllers
{
    public class SettingsController
    {
        private static SettingsController instance = null;

        public static SettingsController I()
        {
            if (instance == null)
            {
                instance = new SettingsController();
            }

            return instance;
        }

        public void LineWidthChanged()
        {
            var sel_item = (string)MainForm.mainForm.ComboBoxLineWidth.SelectedItem;
            if (sel_item != string.Empty)
            {
                var selected_linewidth = int.Parse(sel_item.Split(' ')[1]);
                if (StateComponent.I().CurrentImage != null && StateComponent.I().SkizShape != null)
                {
                    StateComponent.I().SkizShape.Linewidth = selected_linewidth;
                }

                StateComponent.I().CurrentLineWidth = selected_linewidth;
            }
        }

        public void ShadestepsChanged()
        {
            var sel_item = (string)MainForm.mainForm.ComboBoxColorSteps.SelectedItem;
            if (sel_item != string.Empty)
            {
                var selected_shadesteps = int.Parse(sel_item.Split(' ')[0]);
                if (StateComponent.I().CurrentImage != null && StateComponent.I().SkizShape != null)
                {
                    StateComponent.I().SkizShape.Shadesteps = selected_shadesteps;
                }

                StateComponent.I().CurrentShadesteps = selected_shadesteps;
            }
        }

        public void PaintcolorChanged(Color sel_color)
        {
            var button = MainForm.mainForm.ButtonDrawingColor;

            StateComponent.I().CurrentPaintcolor = sel_color;
            button.BackColor = sel_color;

            var brightness = sel_color.GetBrightness();

            if (brightness < 0.6f)
            {
                button.ForeColor = Color.White;
            }
            else
            {
                button.ForeColor = Color.Black;
            }

            button.Text = "Zeichenfarbe";
        }

        public void BordercolorChanged(Color sel_color)
        {
            var button = MainForm.mainForm.ButtonBorderColor;

            StateComponent.I().CurrentBordercolor = sel_color;
            button.BackColor = sel_color;

            var brightness = sel_color.GetBrightness();

            if (brightness < 0.6f)
            {
                button.ForeColor = Color.White;
            }
            else
            {
                button.ForeColor = Color.Black;
            }

            button.Text = "Randfarbe";
        }

        public void SetCombinate(int combinateMethod)
        {
            StateComponent.I().CombinateMethod = combinateMethod;

            MainForm.mainForm.ButtonCombinateNone.ForeColor = Color.DarkGray;
            MainForm.mainForm.ButtonCombinateMinus.ForeColor = Color.DarkGray;
            MainForm.mainForm.ButtonCombinatePlus.ForeColor = Color.DarkGray;

            if (combinateMethod == StateComponent.COMBINATE_NONE)
            {
                MainForm.mainForm.ButtonCombinateNone.ForeColor = System.Drawing.Color.White;
            }
            else if (combinateMethod == StateComponent.COMBINATE_ADD)
            {
                MainForm.mainForm.ButtonCombinatePlus.ForeColor = System.Drawing.Color.White;
            }
            else if (combinateMethod == StateComponent.COMBINATE_SUB)
            {
                MainForm.mainForm.ButtonCombinateMinus.ForeColor = System.Drawing.Color.White;
            }
        }
    }
}
