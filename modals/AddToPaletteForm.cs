using comixpaint.controllers;
using System;
using System.Windows.Forms;

namespace comixpaint.modals
{
    public partial class AddToPaletteForm : Form
    {
        public static AddToPaletteForm Instance { get; set; }

        public bool IsBorder { get; set; }

        public TextBox TextBoxName => textBoxName;

        public Label LabelError => labelError;

        public AddToPaletteForm()
        {
            Instance = this;
            InitializeComponent();
        }

        private void AddToPaletteForm_Load(object sender, EventArgs e)
        {
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            PaletteController.I().AddColorToPalletteManager();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            AddToPaletteForm.Instance.Close();
        }
    }
}
