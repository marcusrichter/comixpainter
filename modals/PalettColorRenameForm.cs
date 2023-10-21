using comixpaint.controllers;
using System;
using System.Windows.Forms;

namespace comixpaint.modals
{
    public partial class PalettColorRenameForm : Form
    {
        public static PalettColorRenameForm Instance { get; set; }

        public bool IsBorder { get; set; }

        public Button PaletteButton { get; set; }

        public TextBox TextBoxName => textBoxName;

        public PalettColorRenameForm()
        {
            Instance = this;
            InitializeComponent();
        }

        private void PalettColorRenameForm_Load(object sender, EventArgs e)
        {

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            PaletteController.I().DoRenamePaletteColor();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
