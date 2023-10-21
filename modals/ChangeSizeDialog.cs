using comixpaint.common;
using comixpaint.components;
using mystical.Grafix.Data;
using mystical.Grafix.ShaderShapes;
using System;
using System.Windows.Forms;

namespace comixpaint.modals
{
    public partial class ChangeSizeDialog : Form
    {
        public ChangeSizeDialog()
        {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();

            //
            // TODO: Add constructor code after the InitializeComponent() call.
            //
        }

        private void ButtonOKClick(object sender, EventArgs e)
        {
            int.TryParse(textBoxWidth.Text, out var width);
            int.TryParse(textBoxHeight.Text, out var height);
            if (width == 0 || height == 0)
            {
                MessageBox.Show("Ungültige Dimension", "Fehler", MessageBoxButtons.OK);
            }
            else
            {
                StateComponent.I().CurrentImage.Width = width;
                StateComponent.I().CurrentImage.Height = height;
                StateComponent.I().CurrentImage.Image = new FastBitmap(StateComponent.I().CurrentImage.Width, StateComponent.I().CurrentImage.Height);
  
                PaintComponent.I().InitPaint();
                PaintComponent.I().Repaint(true);
                Close();
            }
        }

        private void ButtonCancelClick(object sender, EventArgs e)
        {
            Close();
        }
    }
}
