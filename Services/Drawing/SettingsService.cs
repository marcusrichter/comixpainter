using comixpaint.Services.State;
using System.Drawing;

namespace comixpaint.Services.Drawing
{
    public class SettingsService
    {
        private readonly StateService _state;

        public SettingsService(StateService state)
        {
            _state = state;
        }

        public void LineWidthChanged()
        {
            var sel_item = (string)MainForm.mainForm.ComboBoxLineWidth.SelectedItem;
            if (sel_item != string.Empty)
            {
                var selected_linewidth = int.Parse(sel_item.Split(' ')[1]);
                if (_state.CurrentImage != null && _state.SkizShape != null)
                {
                    _state.SkizShape.Linewidth = selected_linewidth;
                }

                _state.CurrentLineWidth = selected_linewidth;
            }
        }

        public void ShadestepsChanged()
        {
            var sel_item = (string)MainForm.mainForm.ComboBoxColorSteps.SelectedItem;
            if (sel_item != string.Empty)
            {
                var selected_shadesteps = int.Parse(sel_item.Split(' ')[0]);
                if (_state.CurrentImage != null && _state.SkizShape != null)
                {
                    _state.SkizShape.Shadesteps = selected_shadesteps;
                }

                _state.CurrentShadesteps = selected_shadesteps;
            }
        }

        public void PaintcolorChanged(Color sel_color)
        {
            var button = MainForm.mainForm.ButtonDrawingColor;

            _state.CurrentPaintcolor = sel_color;
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

            _state.CurrentBordercolor = sel_color;
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
            _state.CombinateMethod = combinateMethod;

            MainForm.mainForm.ButtonCombinateNone.ForeColor = Color.DarkGray;
            MainForm.mainForm.ButtonCombinateMinus.ForeColor = Color.DarkGray;
            MainForm.mainForm.ButtonCombinatePlus.ForeColor = Color.DarkGray;

            if (combinateMethod == StateService.COMBINATE_NONE)
            {
                MainForm.mainForm.ButtonCombinateNone.ForeColor = System.Drawing.Color.White;
            }
            else if (combinateMethod == StateService.COMBINATE_ADD)
            {
                MainForm.mainForm.ButtonCombinatePlus.ForeColor = System.Drawing.Color.White;
            }
            else if (combinateMethod == StateService.COMBINATE_SUB)
            {
                MainForm.mainForm.ButtonCombinateMinus.ForeColor = System.Drawing.Color.White;
            }
        }
    }
}
