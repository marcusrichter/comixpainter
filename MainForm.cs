using comixpaint.components;
using comixpaint.controllers;
using System;
using System.Windows.Forms;

namespace comixpaint
{
    /// <summary>
    /// Description of MainForm.
    /// </summary>
    public partial class MainForm : Form
    {
        public static MainForm mainForm = null;

        public MainForm()
        {
            //
            // The InitializeComponent() call is required for Windows Forms designer support.
            //
            InitializeComponent();

            //
            // TODO: Add constructor code after the InitializeComponent() call.
            //
            MainForm.mainForm = this;
            PictureBoxPaint.MouseWheel += PictureBoxMouseWheel;

            SystemController.I().Init();
        }

        public PictureBox PictureBoxPaint => pictureBoxPaint;

        public SaveFileDialog SaveFileDialog => saveFileDialog;
        public OpenFileDialog OpenFileDialog => openFileDialog;

        private void PictureBoxMouseWheel(object sender, MouseEventArgs e)
        {
            //you can do anything here
            var delta = e.Delta;

            if (delta > 0) 
            {
                TemplateComponent.I().Scale = Math.Max(TemplateComponent.I().Scale - 0.1f, 0.0f);
            }
            else if (delta < 0)
            {
                TemplateComponent.I().Scale = Math.Min(TemplateComponent.I().Scale + 0.1f, 5.0f);
            }

            TemplateComponent.I().LoadTemplate();
        }

        private void LadenToolStripMenuItemClick(object sender, EventArgs e)
        {
            MenuController.I().LoadCmx();
        }

        private void NeuToolStripMenuItemClick(object sender, System.EventArgs e)
        {
            MenuController.I().NewImage();
        }

        private void LastDeleteToolStripMenuItemClick(object sender, EventArgs e)
        {
            MenuController.I().LastShadeDelete();

        }

        private void LastNewShadeToolStripMenuItemClick(object sender, EventArgs e)
        {
            MenuController.I().LastShadeNewShade();
        }

        private void SpiegelnXAchseToolStripMenuItemClick(object sender, EventArgs e)
        {
            MenuController.I().MirrorX();
        }

        private void SpiegelnYAchseToolStripMenuItemClick(object sender, EventArgs e)
        {
            MenuController.I().MirrorY();
        }

        private void SpeicherncopToolStripMenuItemClick(object sender, EventArgs e)
        {
            MenuController.I().SaveCmx();
        }

        private void SpeichernjpgToolStripMenuItemClick(object sender, EventArgs e)
        {
            MenuController.I().SavePng();
        }

        private void AutoCutToolStripMenuItemClick(object sender, EventArgs e)
        {
            MenuController.I().AutoCut();
        }

        private void Zoom6ToolStripMenuItemClick(object sender, EventArgs e)
        {
            MenuController.I().Zoom(6);
        }

        private void Zoom8ToolStripMenuItem1Click(object sender, EventArgs e)
        {
            MenuController.I().Zoom(8);
        }

        private void ButtonDrawFreeLinesClick(object sender, EventArgs e)
        {
            highlightButtonTool(StateComponent.TOOL_BHAND_POINTS);
            ToolsController.I().DrawFreeLinesClick();
        }

        private void ButtonRecolorClick(object sender, EventArgs e)
        {
            highlightButtonTool(StateComponent.TOOL_RECOLOR);
            ToolsController.I().RecolorClick();
        }

        private void ButtonCombinateNoneClick(object sender, EventArgs e)
        {
            SettingsController.I().SetCombinate(StateComponent.COMBINATE_NONE);
        }

        private void ButtonCombinatePlusClick(object sender, EventArgs e)
        {
            SettingsController.I().SetCombinate(StateComponent.COMBINATE_ADD);
        }

        private void ButtonCombinateMinusClick(object sender, EventArgs e)
        {
            SettingsController.I().SetCombinate(StateComponent.COMBINATE_SUB);
        }

        private void ButtonSelectShapeClick(object sender, EventArgs e)
        {
            ToolsController.I().SelectShape();
        }

        private void VorlageLadenToolStripMenuItemClick(object sender, EventArgs e)
        {
            MenuController.I().LoadTemplate();
        }

        private void VorlagenEntfernenToolStripMenuItemClick(object sender, EventArgs e)
        {
            MenuController.I().RemoveTemplate();
        }

        private void VorlageTransparentToolStripMenuItemClick(object sender, EventArgs e)
        {
            MenuController.I().TransparentTemplate();
        }

        private void VorlageNichtTransparentToolStripMenuItemClick(object sender, EventArgs e)
        {
            MenuController.I().NotTransparentTemplate();
        }

        private void ButtonPickColorClick(object sender, EventArgs e)
        {
            ToolsController.I().PickColor();
        }

        private void RotateToolStripMenuItemClick(object sender, EventArgs e)
        {
            MenuController.I().Rotate();
        }

        private void buttonPalletteManager_Click(object sender, EventArgs e)
        {
            PaletteController.I().LoadPaletteManager();
        }

        private void buttonAddPalette_Click(object sender, EventArgs e)
        {
            PaletteController.I().AddColorToPalletteManagerDialog(false);
        }

        private void buttonAddPalletteBorderColor_Click(object sender, EventArgs e)
        {
            PaletteController.I().AddColorToPalletteManagerDialog(true);
        }

        private void buttonFavColor1_Click(object sender, EventArgs e)
        {

        }

        private void speicherncopPngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuController.I().SaveCmxAndPng();
        }

        private void landNoiseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TextureController.I().CreateLandNoise();
        }

        private void PictureBoxPaint_MouseHover(object sender, EventArgs e)
        {
            PictureBoxPaint.Focus();
        }

        private void UndoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuController.I().Undo();
        }

        private void ChangeSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MenuController.I().ChangeSize();
        }
    }
}
