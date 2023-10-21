using comixpaint.common;
using comixpaint.components;
using mystical.Grafix.ShaderShapes;
using System;
using System.Windows.Forms;

namespace comixpaint.modals
{
    public partial class NewImgDialog : Form
    {
        public NewImgDialog()
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
                var comix_img = new ShaderShapeImage(width, height);
                ComixpaintSettings.Instance.DefaultWidth = width;
                ComixpaintSettings.Instance.DefaultHeight = height;

                StateComponent.I().CurrentImage = comix_img;
                PaintComponent.I().InitPaint();
                Close();
            }
        }

        private void ButtonCancelClick(object sender, EventArgs e)
        {
            Close();
        }
    }
}
