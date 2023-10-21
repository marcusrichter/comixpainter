using comixpaint.controllers;
using System;
using System.Windows.Forms;

namespace comixpaint.modals
{
    public partial class PaletteManager : Form
    {
        public static PaletteManager Instance { get; set; }

        public Panel PanelPallettes => panelPallettes;

        public Label LabelPaletteFileName => labelPaletteFileName;

        public CheckBox CheckBoxDeleteModus => checkBoxDeleteModus;

        public CheckBox CheckBoxRename => checkBoxRename;

        public PaletteManager()
        {
            Instance = this;
            InitializeComponent();
        }

        private void PaletteManager_Load(object sender, EventArgs e)
        {
            PaletteController.I().FillPaletteManager();
        }

        private void buttonPallettePush_Click(object sender, EventArgs e)
        {
            PaletteController.I().SavePath();
        }

        private void buttonLoadPalette_Click(object sender, EventArgs e)
        {
            PaletteController.I().LoadPath();
        }

        private void checkBoxDeleteModus_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBoxDeleteModus.Checked)
            {
                checkBoxRename.Enabled = false;
            }
            else
            {
                checkBoxRename.Enabled = true;
            }
        }

        private void checkBoxRename_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxRename.Checked)
            {
                checkBoxDeleteModus.Enabled = false;
            }
            else
            {
                checkBoxDeleteModus.Enabled = true;
            }
        }
    }
}
