/*
 * Created by SharpDevelop.
 * User: x
 * Date: 29.05.2014
 * Time: 13:03
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using comixpaint.controllers;
using comixpaint.components;
using System.Windows.Forms;
using System.Drawing;
using mystical.Grafix.ShaderShapes;

namespace comixpaint
{
    partial class MainForm
    {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Disposes resources used by the form.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// This method is required for Windows Forms designer support.
        /// Do not change the method contents inside the source code editor. The Forms designer might
        /// not be able to load this method if it was changed manually.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.neuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.speichernjpgToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.speicherncopToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.speicherncopPngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ladenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vorlageLadenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vorlagenEntfernenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vorlageTransparentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vorlageNichtTransparentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bearbeitenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lastDeleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lastNewShadeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoCutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gösseÄndernToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoom1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoom2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoom3ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoom8ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoom6ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoom8ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.effekteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spiegelnXAchseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spiegelnYAchseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rotateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.texturenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.landNoiseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LeftPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonDrawOval = new System.Windows.Forms.Button();
            this.buttonDrawRect = new System.Windows.Forms.Button();
            this.buttonDrawFree = new System.Windows.Forms.Button();
            this.buttonDrawLines = new System.Windows.Forms.Button();
            this.buttonDrawFreeLines = new System.Windows.Forms.Button();
            this.buttonMove = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonMoveInFront = new System.Windows.Forms.Button();
            this.buttonMoveInBack = new System.Windows.Forms.Button();
            this.buttonCopy = new System.Windows.Forms.Button();
            this.buttonRecolor = new System.Windows.Forms.Button();
            this.buttonSelectShape = new System.Windows.Forms.Button();
            this.buttonPickColor = new System.Windows.Forms.Button();
            this.RightPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonDrawingColor = new System.Windows.Forms.Button();
            this.buttonBorderColor = new System.Windows.Forms.Button();
            this.comboBoxLineWidth = new System.Windows.Forms.ComboBox();
            this.comboBoxColorSteps = new System.Windows.Forms.ComboBox();
            this.labelShading = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonShadeCenter = new System.Windows.Forms.Button();
            this.buttonShadingRightDown = new System.Windows.Forms.Button();
            this.buttonShadingDown = new System.Windows.Forms.Button();
            this.buttonShadingLeftDown = new System.Windows.Forms.Button();
            this.buttonShadingRight = new System.Windows.Forms.Button();
            this.buttonShadingLeft = new System.Windows.Forms.Button();
            this.buttonShadingRightUp = new System.Windows.Forms.Button();
            this.buttonShadingUp = new System.Windows.Forms.Button();
            this.buttonShadingLeftUp = new System.Windows.Forms.Button();
            this.textBoxColorDiff = new System.Windows.Forms.TextBox();
            this.labelColorDiff = new System.Windows.Forms.Label();
            this.checkBoxAutocatSave = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonCombinatePlus = new System.Windows.Forms.Button();
            this.buttonCombinateNone = new System.Windows.Forms.Button();
            this.buttonCombinateMinus = new System.Windows.Forms.Button();
            this.labelSelectedShape = new System.Windows.Forms.Label();
            this.BottomPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonPalletteManager = new System.Windows.Forms.Button();
            this.buttonAddPalette = new System.Windows.Forms.Button();
            this.buttonAddPalletteBorderColor = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBoxPaint = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.LeftPanel.SuspendLayout();
            this.RightPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.BottomPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPaint)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem,
            this.bearbeitenToolStripMenuItem,
            this.zoomToolStripMenuItem,
            this.effekteToolStripMenuItem,
            this.texturenToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(995, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // dateiToolStripMenuItem
            // 
            this.dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.neuToolStripMenuItem,
            this.speichernjpgToolStripMenuItem,
            this.speicherncopToolStripMenuItem,
            this.speicherncopPngToolStripMenuItem,
            this.ladenToolStripMenuItem,
            this.vorlageLadenToolStripMenuItem,
            this.vorlagenEntfernenToolStripMenuItem,
            this.vorlageTransparentToolStripMenuItem,
            this.vorlageNichtTransparentToolStripMenuItem});
            this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
            this.dateiToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.dateiToolStripMenuItem.Text = "Datei";
            // 
            // neuToolStripMenuItem
            // 
            this.neuToolStripMenuItem.Name = "neuToolStripMenuItem";
            this.neuToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.neuToolStripMenuItem.Text = "Neu";
            this.neuToolStripMenuItem.Click += new System.EventHandler(this.NeuToolStripMenuItemClick);
            // 
            // speichernjpgToolStripMenuItem
            // 
            this.speichernjpgToolStripMenuItem.Name = "speichernjpgToolStripMenuItem";
            this.speichernjpgToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.speichernjpgToolStripMenuItem.Text = "Speichern (png)";
            this.speichernjpgToolStripMenuItem.Click += new System.EventHandler(this.SpeichernjpgToolStripMenuItemClick);
            // 
            // speicherncopToolStripMenuItem
            // 
            this.speicherncopToolStripMenuItem.Name = "speicherncopToolStripMenuItem";
            this.speicherncopToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.speicherncopToolStripMenuItem.Text = "Speichern (cmx)";
            this.speicherncopToolStripMenuItem.Click += new System.EventHandler(this.SpeicherncopToolStripMenuItemClick);
            // 
            // speicherncopPngToolStripMenuItem
            // 
            this.speicherncopPngToolStripMenuItem.Name = "speicherncopPngToolStripMenuItem";
            this.speicherncopPngToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.speicherncopPngToolStripMenuItem.Text = "Speichern (cmx + png)";
            this.speicherncopPngToolStripMenuItem.Click += new System.EventHandler(this.speicherncopPngToolStripMenuItem_Click);
            // 
            // ladenToolStripMenuItem
            // 
            this.ladenToolStripMenuItem.Name = "ladenToolStripMenuItem";
            this.ladenToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.ladenToolStripMenuItem.Text = "Laden (cmx)";
            this.ladenToolStripMenuItem.Click += new System.EventHandler(this.LadenToolStripMenuItemClick);
            // 
            // vorlageLadenToolStripMenuItem
            // 
            this.vorlageLadenToolStripMenuItem.Name = "vorlageLadenToolStripMenuItem";
            this.vorlageLadenToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.vorlageLadenToolStripMenuItem.Text = "Vorlage laden";
            this.vorlageLadenToolStripMenuItem.Click += new System.EventHandler(this.VorlageLadenToolStripMenuItemClick);
            // 
            // vorlagenEntfernenToolStripMenuItem
            // 
            this.vorlagenEntfernenToolStripMenuItem.Name = "vorlagenEntfernenToolStripMenuItem";
            this.vorlagenEntfernenToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.vorlagenEntfernenToolStripMenuItem.Text = "Vorlagen entfernen";
            this.vorlagenEntfernenToolStripMenuItem.Click += new System.EventHandler(this.VorlagenEntfernenToolStripMenuItemClick);
            // 
            // vorlageTransparentToolStripMenuItem
            // 
            this.vorlageTransparentToolStripMenuItem.Name = "vorlageTransparentToolStripMenuItem";
            this.vorlageTransparentToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.vorlageTransparentToolStripMenuItem.Text = "Vorlage transparent";
            this.vorlageTransparentToolStripMenuItem.Click += new System.EventHandler(this.VorlageTransparentToolStripMenuItemClick);
            // 
            // vorlageNichtTransparentToolStripMenuItem
            // 
            this.vorlageNichtTransparentToolStripMenuItem.Name = "vorlageNichtTransparentToolStripMenuItem";
            this.vorlageNichtTransparentToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.vorlageNichtTransparentToolStripMenuItem.Text = "Vorlage nicht transparent";
            this.vorlageNichtTransparentToolStripMenuItem.Click += new System.EventHandler(this.VorlageNichtTransparentToolStripMenuItemClick);
            // 
            // bearbeitenToolStripMenuItem
            // 
            this.bearbeitenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lastDeleteToolStripMenuItem,
            this.lastNewShadeToolStripMenuItem,
            this.autoCutToolStripMenuItem,
            this.undoToolStripMenuItem,
            this.gösseÄndernToolStripMenuItem});
            this.bearbeitenToolStripMenuItem.Name = "bearbeitenToolStripMenuItem";
            this.bearbeitenToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.bearbeitenToolStripMenuItem.Text = "Bearbeiten";
            // 
            // lastDeleteToolStripMenuItem
            // 
            this.lastDeleteToolStripMenuItem.Name = "lastDeleteToolStripMenuItem";
            this.lastDeleteToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.lastDeleteToolStripMenuItem.Text = "Letztes Shade entfernen";
            this.lastDeleteToolStripMenuItem.Click += new System.EventHandler(this.LastDeleteToolStripMenuItemClick);
            // 
            // lastNewShadeToolStripMenuItem
            // 
            this.lastNewShadeToolStripMenuItem.Name = "lastNewShadeToolStripMenuItem";
            this.lastNewShadeToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.lastNewShadeToolStripMenuItem.Text = "Letztes Shade neu Shaden";
            this.lastNewShadeToolStripMenuItem.Click += new System.EventHandler(this.LastNewShadeToolStripMenuItemClick);
            // 
            // autoCutToolStripMenuItem
            // 
            this.autoCutToolStripMenuItem.Name = "autoCutToolStripMenuItem";
            this.autoCutToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.autoCutToolStripMenuItem.Text = "auto schneiden";
            this.autoCutToolStripMenuItem.Click += new System.EventHandler(this.AutoCutToolStripMenuItemClick);
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.undoToolStripMenuItem.Text = "Rückgängig";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.UndoToolStripMenuItem_Click);
            // 
            // gösseÄndernToolStripMenuItem
            // 
            this.gösseÄndernToolStripMenuItem.Name = "gösseÄndernToolStripMenuItem";
            this.gösseÄndernToolStripMenuItem.Size = new System.Drawing.Size(210, 22);
            this.gösseÄndernToolStripMenuItem.Text = "Grösse ändern";
            this.gösseÄndernToolStripMenuItem.Click += new System.EventHandler(this.ChangeSizeToolStripMenuItem_Click);
            // 
            // zoomToolStripMenuItem
            // 
            this.zoomToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zoom1ToolStripMenuItem,
            this.zoom2ToolStripMenuItem,
            this.zoom3ToolStripMenuItem,
            this.zoom8ToolStripMenuItem,
            this.zoom6ToolStripMenuItem,
            this.zoom8ToolStripMenuItem1});
            this.zoomToolStripMenuItem.Name = "zoomToolStripMenuItem";
            this.zoomToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.zoomToolStripMenuItem.Text = "Zoom";
            // 
            // zoom1ToolStripMenuItem
            // 
            this.zoom1ToolStripMenuItem.Name = "zoom1ToolStripMenuItem";
            this.zoom1ToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.zoom1ToolStripMenuItem.Text = "Zoom 1";
            this.zoom1ToolStripMenuItem.Click += new System.EventHandler(this.Zoom1ToolStripMenuItemClick);
            // 
            // zoom2ToolStripMenuItem
            // 
            this.zoom2ToolStripMenuItem.Name = "zoom2ToolStripMenuItem";
            this.zoom2ToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.zoom2ToolStripMenuItem.Text = "Zoom 2";
            this.zoom2ToolStripMenuItem.Click += new System.EventHandler(this.Zoom2ToolStripMenuItemClick);
            // 
            // zoom3ToolStripMenuItem
            // 
            this.zoom3ToolStripMenuItem.Name = "zoom3ToolStripMenuItem";
            this.zoom3ToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.zoom3ToolStripMenuItem.Text = "Zoom 3";
            this.zoom3ToolStripMenuItem.Click += new System.EventHandler(this.Zoom3ToolStripMenuItemClick);
            // 
            // zoom8ToolStripMenuItem
            // 
            this.zoom8ToolStripMenuItem.Name = "zoom8ToolStripMenuItem";
            this.zoom8ToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.zoom8ToolStripMenuItem.Text = "Zoom 4";
            this.zoom8ToolStripMenuItem.Click += new System.EventHandler(this.Zoom4ToolStripMenuItemClick);
            // 
            // zoom6ToolStripMenuItem
            // 
            this.zoom6ToolStripMenuItem.Name = "zoom6ToolStripMenuItem";
            this.zoom6ToolStripMenuItem.Size = new System.Drawing.Size(115, 22);
            this.zoom6ToolStripMenuItem.Text = "Zoom 6";
            this.zoom6ToolStripMenuItem.Click += new System.EventHandler(this.Zoom6ToolStripMenuItemClick);
            // 
            // zoom8ToolStripMenuItem1
            // 
            this.zoom8ToolStripMenuItem1.Name = "zoom8ToolStripMenuItem1";
            this.zoom8ToolStripMenuItem1.Size = new System.Drawing.Size(115, 22);
            this.zoom8ToolStripMenuItem1.Text = "Zoom 8";
            this.zoom8ToolStripMenuItem1.Click += new System.EventHandler(this.Zoom8ToolStripMenuItem1Click);
            // 
            // effekteToolStripMenuItem
            // 
            this.effekteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.spiegelnXAchseToolStripMenuItem,
            this.spiegelnYAchseToolStripMenuItem,
            this.rotateToolStripMenuItem});
            this.effekteToolStripMenuItem.Name = "effekteToolStripMenuItem";
            this.effekteToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.effekteToolStripMenuItem.Text = "Effekte";
            // 
            // spiegelnXAchseToolStripMenuItem
            // 
            this.spiegelnXAchseToolStripMenuItem.Name = "spiegelnXAchseToolStripMenuItem";
            this.spiegelnXAchseToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.spiegelnXAchseToolStripMenuItem.Text = "Spiegeln X Achse";
            this.spiegelnXAchseToolStripMenuItem.Click += new System.EventHandler(this.SpiegelnXAchseToolStripMenuItemClick);
            // 
            // spiegelnYAchseToolStripMenuItem
            // 
            this.spiegelnYAchseToolStripMenuItem.Name = "spiegelnYAchseToolStripMenuItem";
            this.spiegelnYAchseToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.spiegelnYAchseToolStripMenuItem.Text = "Spiegeln Y Achse";
            this.spiegelnYAchseToolStripMenuItem.Click += new System.EventHandler(this.SpiegelnYAchseToolStripMenuItemClick);
            // 
            // rotateToolStripMenuItem
            // 
            this.rotateToolStripMenuItem.Name = "rotateToolStripMenuItem";
            this.rotateToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.rotateToolStripMenuItem.Text = "Rotieren 90 Grad";
            this.rotateToolStripMenuItem.Click += new System.EventHandler(this.RotateToolStripMenuItemClick);
            // 
            // texturenToolStripMenuItem
            // 
            this.texturenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.landNoiseToolStripMenuItem});
            this.texturenToolStripMenuItem.Name = "texturenToolStripMenuItem";
            this.texturenToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.texturenToolStripMenuItem.Text = "Texturen";
            // 
            // landNoiseToolStripMenuItem
            // 
            this.landNoiseToolStripMenuItem.Name = "landNoiseToolStripMenuItem";
            this.landNoiseToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.landNoiseToolStripMenuItem.Text = "LandNoise";
            this.landNoiseToolStripMenuItem.Click += new System.EventHandler(this.landNoiseToolStripMenuItem_Click);
            // 
            // LeftPanel
            // 
            this.LeftPanel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.LeftPanel.Controls.Add(this.buttonDrawOval);
            this.LeftPanel.Controls.Add(this.buttonDrawRect);
            this.LeftPanel.Controls.Add(this.buttonDrawFree);
            this.LeftPanel.Controls.Add(this.buttonDrawLines);
            this.LeftPanel.Controls.Add(this.buttonDrawFreeLines);
            this.LeftPanel.Controls.Add(this.buttonMove);
            this.LeftPanel.Controls.Add(this.buttonDelete);
            this.LeftPanel.Controls.Add(this.buttonMoveInFront);
            this.LeftPanel.Controls.Add(this.buttonMoveInBack);
            this.LeftPanel.Controls.Add(this.buttonCopy);
            this.LeftPanel.Controls.Add(this.buttonRecolor);
            this.LeftPanel.Controls.Add(this.buttonSelectShape);
            this.LeftPanel.Controls.Add(this.buttonPickColor);
            this.LeftPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.LeftPanel.Location = new System.Drawing.Point(0, 24);
            this.LeftPanel.Name = "LeftPanel";
            this.LeftPanel.Size = new System.Drawing.Size(78, 574);
            this.LeftPanel.TabIndex = 1;
            // 
            // buttonDrawOval
            // 
            this.buttonDrawOval.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.buttonDrawOval.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonDrawOval.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDrawOval.Image = ((System.Drawing.Image)(resources.GetObject("buttonDrawOval.Image")));
            this.buttonDrawOval.Location = new System.Drawing.Point(3, 3);
            this.buttonDrawOval.Name = "buttonDrawOval";
            this.buttonDrawOval.Size = new System.Drawing.Size(69, 35);
            this.buttonDrawOval.TabIndex = 0;
            this.buttonDrawOval.UseVisualStyleBackColor = false;
            this.buttonDrawOval.Click += new System.EventHandler(this.ButtonDrawOvalClick);
            // 
            // buttonDrawRect
            // 
            this.buttonDrawRect.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.buttonDrawRect.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonDrawRect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDrawRect.Image = ((System.Drawing.Image)(resources.GetObject("buttonDrawRect.Image")));
            this.buttonDrawRect.Location = new System.Drawing.Point(3, 44);
            this.buttonDrawRect.Name = "buttonDrawRect";
            this.buttonDrawRect.Size = new System.Drawing.Size(69, 35);
            this.buttonDrawRect.TabIndex = 1;
            this.buttonDrawRect.UseVisualStyleBackColor = false;
            this.buttonDrawRect.Click += new System.EventHandler(this.ButtonDrawRectClick);
            // 
            // buttonDrawFree
            // 
            this.buttonDrawFree.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.buttonDrawFree.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonDrawFree.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDrawFree.Image = ((System.Drawing.Image)(resources.GetObject("buttonDrawFree.Image")));
            this.buttonDrawFree.Location = new System.Drawing.Point(3, 85);
            this.buttonDrawFree.Name = "buttonDrawFree";
            this.buttonDrawFree.Size = new System.Drawing.Size(69, 35);
            this.buttonDrawFree.TabIndex = 3;
            this.buttonDrawFree.UseVisualStyleBackColor = false;
            this.buttonDrawFree.Click += new System.EventHandler(this.ButtonDrawFreeClick);
            // 
            // buttonDrawLines
            // 
            this.buttonDrawLines.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.buttonDrawLines.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonDrawLines.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDrawLines.Image = ((System.Drawing.Image)(resources.GetObject("buttonDrawLines.Image")));
            this.buttonDrawLines.Location = new System.Drawing.Point(3, 126);
            this.buttonDrawLines.Name = "buttonDrawLines";
            this.buttonDrawLines.Size = new System.Drawing.Size(69, 35);
            this.buttonDrawLines.TabIndex = 4;
            this.buttonDrawLines.UseVisualStyleBackColor = false;
            this.buttonDrawLines.Click += new System.EventHandler(this.ButtonDrawLinesClick);
            // 
            // buttonDrawFreeLines
            // 
            this.buttonDrawFreeLines.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.buttonDrawFreeLines.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonDrawFreeLines.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDrawFreeLines.Image = ((System.Drawing.Image)(resources.GetObject("buttonDrawFreeLines.Image")));
            this.buttonDrawFreeLines.Location = new System.Drawing.Point(3, 167);
            this.buttonDrawFreeLines.Name = "buttonDrawFreeLines";
            this.buttonDrawFreeLines.Size = new System.Drawing.Size(69, 35);
            this.buttonDrawFreeLines.TabIndex = 12;
            this.buttonDrawFreeLines.UseVisualStyleBackColor = false;
            this.buttonDrawFreeLines.Click += new System.EventHandler(this.ButtonDrawFreeLinesClick);
            // 
            // buttonMove
            // 
            this.buttonMove.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.buttonMove.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonMove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMove.Image = ((System.Drawing.Image)(resources.GetObject("buttonMove.Image")));
            this.buttonMove.Location = new System.Drawing.Point(3, 208);
            this.buttonMove.Name = "buttonMove";
            this.buttonMove.Size = new System.Drawing.Size(69, 35);
            this.buttonMove.TabIndex = 5;
            this.buttonMove.UseVisualStyleBackColor = false;
            this.buttonMove.Click += new System.EventHandler(this.ButtonMoveClick);
            // 
            // buttonDelete
            // 
            this.buttonDelete.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.buttonDelete.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDelete.Image = ((System.Drawing.Image)(resources.GetObject("buttonDelete.Image")));
            this.buttonDelete.Location = new System.Drawing.Point(3, 249);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(69, 35);
            this.buttonDelete.TabIndex = 8;
            this.buttonDelete.UseVisualStyleBackColor = false;
            this.buttonDelete.Click += new System.EventHandler(this.ButtonDeleteClick);
            // 
            // buttonMoveInFront
            // 
            this.buttonMoveInFront.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.buttonMoveInFront.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonMoveInFront.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMoveInFront.Image = ((System.Drawing.Image)(resources.GetObject("buttonMoveInFront.Image")));
            this.buttonMoveInFront.Location = new System.Drawing.Point(3, 290);
            this.buttonMoveInFront.Name = "buttonMoveInFront";
            this.buttonMoveInFront.Size = new System.Drawing.Size(69, 35);
            this.buttonMoveInFront.TabIndex = 9;
            this.buttonMoveInFront.UseVisualStyleBackColor = false;
            this.buttonMoveInFront.Click += new System.EventHandler(this.ButtonMoveInFrontClick);
            // 
            // buttonMoveInBack
            // 
            this.buttonMoveInBack.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.buttonMoveInBack.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonMoveInBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonMoveInBack.Image = ((System.Drawing.Image)(resources.GetObject("buttonMoveInBack.Image")));
            this.buttonMoveInBack.Location = new System.Drawing.Point(3, 331);
            this.buttonMoveInBack.Name = "buttonMoveInBack";
            this.buttonMoveInBack.Size = new System.Drawing.Size(69, 35);
            this.buttonMoveInBack.TabIndex = 10;
            this.buttonMoveInBack.UseVisualStyleBackColor = false;
            this.buttonMoveInBack.Click += new System.EventHandler(this.ButtonMoveInBackClick);
            // 
            // buttonCopy
            // 
            this.buttonCopy.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.buttonCopy.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonCopy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCopy.Image = ((System.Drawing.Image)(resources.GetObject("buttonCopy.Image")));
            this.buttonCopy.Location = new System.Drawing.Point(3, 372);
            this.buttonCopy.Name = "buttonCopy";
            this.buttonCopy.Size = new System.Drawing.Size(69, 35);
            this.buttonCopy.TabIndex = 11;
            this.buttonCopy.UseVisualStyleBackColor = false;
            this.buttonCopy.Click += new System.EventHandler(this.ButtonCopyClick);
            // 
            // buttonRecolor
            // 
            this.buttonRecolor.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.buttonRecolor.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonRecolor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRecolor.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonRecolor.Location = new System.Drawing.Point(3, 413);
            this.buttonRecolor.Name = "buttonRecolor";
            this.buttonRecolor.Size = new System.Drawing.Size(69, 35);
            this.buttonRecolor.TabIndex = 13;
            this.buttonRecolor.Text = "Recolor";
            this.buttonRecolor.UseVisualStyleBackColor = false;
            this.buttonRecolor.Click += new System.EventHandler(this.ButtonRecolorClick);
            // 
            // buttonSelectShape
            // 
            this.buttonSelectShape.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.buttonSelectShape.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonSelectShape.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSelectShape.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonSelectShape.Location = new System.Drawing.Point(3, 454);
            this.buttonSelectShape.Name = "buttonSelectShape";
            this.buttonSelectShape.Size = new System.Drawing.Size(69, 35);
            this.buttonSelectShape.TabIndex = 17;
            this.buttonSelectShape.Text = "Select";
            this.buttonSelectShape.UseVisualStyleBackColor = false;
            this.buttonSelectShape.Click += new System.EventHandler(this.ButtonSelectShapeClick);
            // 
            // buttonPickColor
            // 
            this.buttonPickColor.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.buttonPickColor.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonPickColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPickColor.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonPickColor.Location = new System.Drawing.Point(3, 495);
            this.buttonPickColor.Name = "buttonPickColor";
            this.buttonPickColor.Size = new System.Drawing.Size(69, 35);
            this.buttonPickColor.TabIndex = 18;
            this.buttonPickColor.Text = "Pick Color";
            this.buttonPickColor.UseVisualStyleBackColor = false;
            this.buttonPickColor.Click += new System.EventHandler(this.ButtonPickColorClick);
            // 
            // RightPanel
            // 
            this.RightPanel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.RightPanel.Controls.Add(this.buttonDrawingColor);
            this.RightPanel.Controls.Add(this.buttonBorderColor);
            this.RightPanel.Controls.Add(this.comboBoxLineWidth);
            this.RightPanel.Controls.Add(this.comboBoxColorSteps);
            this.RightPanel.Controls.Add(this.labelShading);
            this.RightPanel.Controls.Add(this.tableLayoutPanel1);
            this.RightPanel.Controls.Add(this.textBoxColorDiff);
            this.RightPanel.Controls.Add(this.labelColorDiff);
            this.RightPanel.Controls.Add(this.checkBoxAutocatSave);
            this.RightPanel.Controls.Add(this.label1);
            this.RightPanel.Controls.Add(this.tableLayoutPanel2);
            this.RightPanel.Controls.Add(this.labelSelectedShape);
            this.RightPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.RightPanel.Location = new System.Drawing.Point(838, 24);
            this.RightPanel.Name = "RightPanel";
            this.RightPanel.Size = new System.Drawing.Size(157, 574);
            this.RightPanel.TabIndex = 2;
            // 
            // buttonDrawingColor
            // 
            this.buttonDrawingColor.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonDrawingColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonDrawingColor.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonDrawingColor.Location = new System.Drawing.Point(3, 3);
            this.buttonDrawingColor.Name = "buttonDrawingColor";
            this.buttonDrawingColor.Size = new System.Drawing.Size(150, 23);
            this.buttonDrawingColor.TabIndex = 0;
            this.buttonDrawingColor.Text = "Zeichenfarbe";
            this.buttonDrawingColor.UseVisualStyleBackColor = true;
            this.buttonDrawingColor.Click += new System.EventHandler(this.ButtonDrawingColorClick);
            // 
            // buttonBorderColor
            // 
            this.buttonBorderColor.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.buttonBorderColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBorderColor.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonBorderColor.Location = new System.Drawing.Point(3, 32);
            this.buttonBorderColor.Name = "buttonBorderColor";
            this.buttonBorderColor.Size = new System.Drawing.Size(150, 23);
            this.buttonBorderColor.TabIndex = 2;
            this.buttonBorderColor.Text = "Randfarbe";
            this.buttonBorderColor.UseVisualStyleBackColor = true;
            this.buttonBorderColor.Click += new System.EventHandler(this.ButtonBorderColorClick);
            // 
            // comboBoxLineWidth
            // 
            this.comboBoxLineWidth.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.comboBoxLineWidth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxLineWidth.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.comboBoxLineWidth.FormattingEnabled = true;
            this.comboBoxLineWidth.Items.AddRange(new object[] {
            "Liniendicke 0",
            "Liniendicke 1",
            "Liniendicke 2",
            "Liniendicke 3",
            "Liniendicke 4",
            "Liniendicke 5"});
            this.comboBoxLineWidth.Location = new System.Drawing.Point(3, 61);
            this.comboBoxLineWidth.Name = "comboBoxLineWidth";
            this.comboBoxLineWidth.Size = new System.Drawing.Size(150, 21);
            this.comboBoxLineWidth.TabIndex = 4;
            this.comboBoxLineWidth.SelectedIndexChanged += new System.EventHandler(this.ComboBoxLineWidthSelectedIndexChanged);
            // 
            // comboBoxColorSteps
            // 
            this.comboBoxColorSteps.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.comboBoxColorSteps.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxColorSteps.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.comboBoxColorSteps.FormattingEnabled = true;
            this.comboBoxColorSteps.Items.AddRange(new object[] {
            "1 Farbstufe",
            "2 Farbstufe",
            "3 Farbstufe",
            "4 Farbstufe",
            "5 Farbstufe"});
            this.comboBoxColorSteps.Location = new System.Drawing.Point(3, 88);
            this.comboBoxColorSteps.Name = "comboBoxColorSteps";
            this.comboBoxColorSteps.Size = new System.Drawing.Size(150, 21);
            this.comboBoxColorSteps.TabIndex = 5;
            this.comboBoxColorSteps.SelectedIndexChanged += new System.EventHandler(this.ComboBoxColorStepsSelectedIndexChanged);
            // 
            // labelShading
            // 
            this.labelShading.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelShading.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelShading.Location = new System.Drawing.Point(3, 112);
            this.labelShading.Name = "labelShading";
            this.labelShading.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.labelShading.Size = new System.Drawing.Size(100, 23);
            this.labelShading.TabIndex = 6;
            this.labelShading.Text = "Shading Richtung";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 46.73913F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 53.26087F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 107F));
            this.tableLayoutPanel1.Controls.Add(this.buttonShadeCenter, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonShadingRightDown, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.buttonShadingDown, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.buttonShadingLeftDown, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.buttonShadingRight, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonShadingLeft, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.buttonShadingRightUp, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonShadingUp, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.buttonShadingLeftUp, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 138);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50.60241F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.39759F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 45F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(180, 129);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // buttonShadeCenter
            // 
            this.buttonShadeCenter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonShadeCenter.Image = ((System.Drawing.Image)(resources.GetObject("buttonShadeCenter.Image")));
            this.buttonShadeCenter.Location = new System.Drawing.Point(37, 45);
            this.buttonShadeCenter.Name = "buttonShadeCenter";
            this.buttonShadeCenter.Size = new System.Drawing.Size(32, 35);
            this.buttonShadeCenter.TabIndex = 7;
            this.buttonShadeCenter.UseVisualStyleBackColor = true;
            this.buttonShadeCenter.Click += new System.EventHandler(this.ButtonShadeCenterClick);
            // 
            // buttonShadingRightDown
            // 
            this.buttonShadingRightDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonShadingRightDown.Image = ((System.Drawing.Image)(resources.GetObject("buttonShadingRightDown.Image")));
            this.buttonShadingRightDown.Location = new System.Drawing.Point(75, 86);
            this.buttonShadingRightDown.Name = "buttonShadingRightDown";
            this.buttonShadingRightDown.Size = new System.Drawing.Size(41, 36);
            this.buttonShadingRightDown.TabIndex = 8;
            this.buttonShadingRightDown.UseVisualStyleBackColor = true;
            this.buttonShadingRightDown.Click += new System.EventHandler(this.ButtonShadingRightDownClick);
            // 
            // buttonShadingDown
            // 
            this.buttonShadingDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonShadingDown.Image = ((System.Drawing.Image)(resources.GetObject("buttonShadingDown.Image")));
            this.buttonShadingDown.Location = new System.Drawing.Point(37, 86);
            this.buttonShadingDown.Name = "buttonShadingDown";
            this.buttonShadingDown.Size = new System.Drawing.Size(32, 36);
            this.buttonShadingDown.TabIndex = 7;
            this.buttonShadingDown.UseVisualStyleBackColor = true;
            this.buttonShadingDown.Click += new System.EventHandler(this.ButtonShadingDownClick);
            // 
            // buttonShadingLeftDown
            // 
            this.buttonShadingLeftDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonShadingLeftDown.Image = ((System.Drawing.Image)(resources.GetObject("buttonShadingLeftDown.Image")));
            this.buttonShadingLeftDown.Location = new System.Drawing.Point(3, 86);
            this.buttonShadingLeftDown.Name = "buttonShadingLeftDown";
            this.buttonShadingLeftDown.Size = new System.Drawing.Size(28, 36);
            this.buttonShadingLeftDown.TabIndex = 6;
            this.buttonShadingLeftDown.UseVisualStyleBackColor = true;
            this.buttonShadingLeftDown.Click += new System.EventHandler(this.ButtonShadingLeftDownClick);
            // 
            // buttonShadingRight
            // 
            this.buttonShadingRight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonShadingRight.Image = ((System.Drawing.Image)(resources.GetObject("buttonShadingRight.Image")));
            this.buttonShadingRight.Location = new System.Drawing.Point(75, 45);
            this.buttonShadingRight.Name = "buttonShadingRight";
            this.buttonShadingRight.Size = new System.Drawing.Size(41, 35);
            this.buttonShadingRight.TabIndex = 5;
            this.buttonShadingRight.UseVisualStyleBackColor = true;
            this.buttonShadingRight.Click += new System.EventHandler(this.ButtonShadingRightClick);
            // 
            // buttonShadingLeft
            // 
            this.buttonShadingLeft.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonShadingLeft.Image = ((System.Drawing.Image)(resources.GetObject("buttonShadingLeft.Image")));
            this.buttonShadingLeft.Location = new System.Drawing.Point(3, 45);
            this.buttonShadingLeft.Name = "buttonShadingLeft";
            this.buttonShadingLeft.Size = new System.Drawing.Size(28, 35);
            this.buttonShadingLeft.TabIndex = 3;
            this.buttonShadingLeft.UseVisualStyleBackColor = true;
            this.buttonShadingLeft.Click += new System.EventHandler(this.ButtonShadingLeftClick);
            // 
            // buttonShadingRightUp
            // 
            this.buttonShadingRightUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonShadingRightUp.Image = ((System.Drawing.Image)(resources.GetObject("buttonShadingRightUp.Image")));
            this.buttonShadingRightUp.Location = new System.Drawing.Point(75, 3);
            this.buttonShadingRightUp.Name = "buttonShadingRightUp";
            this.buttonShadingRightUp.Size = new System.Drawing.Size(41, 36);
            this.buttonShadingRightUp.TabIndex = 2;
            this.buttonShadingRightUp.UseVisualStyleBackColor = true;
            this.buttonShadingRightUp.Click += new System.EventHandler(this.ButtonShadingRightUpClick);
            // 
            // buttonShadingUp
            // 
            this.buttonShadingUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonShadingUp.Image = ((System.Drawing.Image)(resources.GetObject("buttonShadingUp.Image")));
            this.buttonShadingUp.Location = new System.Drawing.Point(37, 3);
            this.buttonShadingUp.Name = "buttonShadingUp";
            this.buttonShadingUp.Size = new System.Drawing.Size(32, 36);
            this.buttonShadingUp.TabIndex = 1;
            this.buttonShadingUp.UseVisualStyleBackColor = true;
            this.buttonShadingUp.Click += new System.EventHandler(this.ButtonShadingUpClick);
            // 
            // buttonShadingLeftUp
            // 
            this.buttonShadingLeftUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonShadingLeftUp.Image = ((System.Drawing.Image)(resources.GetObject("buttonShadingLeftUp.Image")));
            this.buttonShadingLeftUp.Location = new System.Drawing.Point(3, 3);
            this.buttonShadingLeftUp.Name = "buttonShadingLeftUp";
            this.buttonShadingLeftUp.Size = new System.Drawing.Size(28, 36);
            this.buttonShadingLeftUp.TabIndex = 0;
            this.buttonShadingLeftUp.UseVisualStyleBackColor = true;
            this.buttonShadingLeftUp.Click += new System.EventHandler(this.ButtonShadingLeftUpClick);
            // 
            // textBoxColorDiff
            // 
            this.textBoxColorDiff.Location = new System.Drawing.Point(3, 273);
            this.textBoxColorDiff.Name = "textBoxColorDiff";
            this.textBoxColorDiff.Size = new System.Drawing.Size(60, 20);
            this.textBoxColorDiff.TabIndex = 8;
            // 
            // labelColorDiff
            // 
            this.labelColorDiff.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelColorDiff.Location = new System.Drawing.Point(69, 270);
            this.labelColorDiff.Name = "labelColorDiff";
            this.labelColorDiff.Padding = new System.Windows.Forms.Padding(0, 6, 0, 0);
            this.labelColorDiff.Size = new System.Drawing.Size(78, 23);
            this.labelColorDiff.TabIndex = 9;
            this.labelColorDiff.Text = "Farbverlauf";
            // 
            // checkBoxAutocatSave
            // 
            this.checkBoxAutocatSave.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.checkBoxAutocatSave.Location = new System.Drawing.Point(3, 299);
            this.checkBoxAutocatSave.Name = "checkBoxAutocatSave";
            this.checkBoxAutocatSave.Size = new System.Drawing.Size(150, 24);
            this.checkBoxAutocatSave.TabIndex = 10;
            this.checkBoxAutocatSave.Text = "Autoschneiden speichern";
            this.checkBoxAutocatSave.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.label1.Location = new System.Drawing.Point(3, 326);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 23);
            this.label1.TabIndex = 12;
            this.label1.Text = "Kombinierung";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54.54546F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.45454F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 94F));
            this.tableLayoutPanel2.Controls.Add(this.buttonCombinatePlus, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonCombinateNone, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.buttonCombinateMinus, 2, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 352);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(185, 47);
            this.tableLayoutPanel2.TabIndex = 11;
            // 
            // buttonCombinatePlus
            // 
            this.buttonCombinatePlus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCombinatePlus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCombinatePlus.ForeColor = System.Drawing.Color.DarkGray;
            this.buttonCombinatePlus.Image = global::comixpaint.Properties.Resources.combine_add;
            this.buttonCombinatePlus.Location = new System.Drawing.Point(52, 3);
            this.buttonCombinatePlus.Name = "buttonCombinatePlus";
            this.buttonCombinatePlus.Size = new System.Drawing.Size(35, 41);
            this.buttonCombinatePlus.TabIndex = 11;
            this.buttonCombinatePlus.UseVisualStyleBackColor = true;
            this.buttonCombinatePlus.Click += new System.EventHandler(this.ButtonCombinatePlusClick);
            // 
            // buttonCombinateNone
            // 
            this.buttonCombinateNone.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCombinateNone.ForeColor = System.Drawing.Color.White;
            this.buttonCombinateNone.Image = global::comixpaint.Properties.Resources.combine_none;
            this.buttonCombinateNone.Location = new System.Drawing.Point(3, 3);
            this.buttonCombinateNone.Name = "buttonCombinateNone";
            this.buttonCombinateNone.Size = new System.Drawing.Size(43, 41);
            this.buttonCombinateNone.TabIndex = 8;
            this.buttonCombinateNone.UseVisualStyleBackColor = true;
            this.buttonCombinateNone.Click += new System.EventHandler(this.ButtonCombinateNoneClick);
            // 
            // buttonCombinateMinus
            // 
            this.buttonCombinateMinus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCombinateMinus.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCombinateMinus.ForeColor = System.Drawing.Color.DarkGray;
            this.buttonCombinateMinus.Image = global::comixpaint.Properties.Resources.combine_sub;
            this.buttonCombinateMinus.Location = new System.Drawing.Point(93, 3);
            this.buttonCombinateMinus.Name = "buttonCombinateMinus";
            this.buttonCombinateMinus.Size = new System.Drawing.Size(45, 41);
            this.buttonCombinateMinus.TabIndex = 10;
            this.buttonCombinateMinus.UseVisualStyleBackColor = true;
            this.buttonCombinateMinus.Click += new System.EventHandler(this.ButtonCombinateMinusClick);
            // 
            // labelSelectedShape
            // 
            this.labelSelectedShape.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.labelSelectedShape.Location = new System.Drawing.Point(3, 402);
            this.labelSelectedShape.Name = "labelSelectedShape";
            this.labelSelectedShape.Size = new System.Drawing.Size(100, 23);
            this.labelSelectedShape.TabIndex = 13;
            this.labelSelectedShape.Text = "Shape:";
            // 
            // BottomPanel
            // 
            this.BottomPanel.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.BottomPanel.Controls.Add(this.buttonPalletteManager);
            this.BottomPanel.Controls.Add(this.buttonAddPalette);
            this.BottomPanel.Controls.Add(this.buttonAddPalletteBorderColor);
            this.BottomPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BottomPanel.Location = new System.Drawing.Point(78, 561);
            this.BottomPanel.Name = "BottomPanel";
            this.BottomPanel.Size = new System.Drawing.Size(760, 37);
            this.BottomPanel.TabIndex = 3;
            // 
            // buttonPalletteManager
            // 
            this.buttonPalletteManager.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPalletteManager.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonPalletteManager.Location = new System.Drawing.Point(3, 3);
            this.buttonPalletteManager.Name = "buttonPalletteManager";
            this.buttonPalletteManager.Size = new System.Drawing.Size(75, 23);
            this.buttonPalletteManager.TabIndex = 20;
            this.buttonPalletteManager.Text = "Palette";
            this.buttonPalletteManager.UseVisualStyleBackColor = true;
            this.buttonPalletteManager.Click += new System.EventHandler(this.buttonPalletteManager_Click);
            // 
            // buttonAddPalette
            // 
            this.buttonAddPalette.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddPalette.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonAddPalette.Location = new System.Drawing.Point(84, 3);
            this.buttonAddPalette.Name = "buttonAddPalette";
            this.buttonAddPalette.Size = new System.Drawing.Size(75, 23);
            this.buttonAddPalette.TabIndex = 21;
            this.buttonAddPalette.Text = "Hinzufügen";
            this.buttonAddPalette.UseVisualStyleBackColor = true;
            this.buttonAddPalette.Click += new System.EventHandler(this.buttonAddPalette_Click);
            // 
            // buttonAddPalletteBorderColor
            // 
            this.buttonAddPalletteBorderColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAddPalletteBorderColor.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonAddPalletteBorderColor.Location = new System.Drawing.Point(165, 3);
            this.buttonAddPalletteBorderColor.Name = "buttonAddPalletteBorderColor";
            this.buttonAddPalletteBorderColor.Size = new System.Drawing.Size(110, 23);
            this.buttonAddPalletteBorderColor.TabIndex = 22;
            this.buttonAddPalletteBorderColor.Text = "Hinzufügen (Rand)";
            this.buttonAddPalletteBorderColor.UseVisualStyleBackColor = true;
            this.buttonAddPalletteBorderColor.Click += new System.EventHandler(this.buttonAddPalletteBorderColor_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.SystemColors.Control;
            this.button2.Location = new System.Drawing.Point(51, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(34, 35);
            this.button2.TabIndex = 9;
            this.button2.Text = "+";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // pictureBoxPaint
            // 
            this.pictureBoxPaint.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pictureBoxPaint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxPaint.Location = new System.Drawing.Point(78, 24);
            this.pictureBoxPaint.Name = "pictureBoxPaint";
            this.pictureBoxPaint.Size = new System.Drawing.Size(760, 537);
            this.pictureBoxPaint.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxPaint.TabIndex = 4;
            this.pictureBoxPaint.TabStop = false;
            this.pictureBoxPaint.Click += new System.EventHandler(this.PictureBoxPaintClick);
            this.pictureBoxPaint.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBoxPaintMouseDown);
            this.pictureBoxPaint.MouseHover += new System.EventHandler(this.PictureBoxPaint_MouseHover);
            this.pictureBoxPaint.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureBoxPaintMouseMove);
            this.pictureBoxPaint.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PictureBoxPaintMouseUp);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(995, 598);
            this.Controls.Add(this.pictureBoxPaint);
            this.Controls.Add(this.BottomPanel);
            this.Controls.Add(this.RightPanel);
            this.Controls.Add(this.LeftPanel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "comixpaint";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.LeftPanel.ResumeLayout(false);
            this.RightPanel.ResumeLayout(false);
            this.RightPanel.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.BottomPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPaint)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        private System.Windows.Forms.CheckBox checkBoxAutocatSave;
        private System.Windows.Forms.ToolStripMenuItem autoCutToolStripMenuItem;
        private System.Windows.Forms.Button buttonShadeCenter;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ToolStripMenuItem spiegelnYAchseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spiegelnXAchseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoom8ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoom3ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoom2ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoom1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lastNewShadeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lastDeleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem effekteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bearbeitenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ladenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem speicherncopToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem speichernjpgToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem neuToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem;
        private System.Windows.Forms.Label labelColorDiff;
        private System.Windows.Forms.TextBox textBoxColorDiff;
        private System.Windows.Forms.Button buttonShadingUp;
        private System.Windows.Forms.Button buttonShadingRightUp;
        private System.Windows.Forms.Button buttonShadingLeft;
        private System.Windows.Forms.Button buttonShadingRight;
        private System.Windows.Forms.Button buttonShadingLeftDown;
        private System.Windows.Forms.Button buttonShadingDown;
        private System.Windows.Forms.Button buttonShadingRightDown;
        private System.Windows.Forms.Button buttonShadingLeftUp;

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelShading;
        private System.Windows.Forms.ComboBox comboBoxColorSteps;
        private System.Windows.Forms.ComboBox comboBoxLineWidth;
        private System.Windows.Forms.Button buttonBorderColor;
        private System.Windows.Forms.Button buttonDrawingColor;
        private System.Windows.Forms.Button buttonCopy;
        private System.Windows.Forms.Button buttonMoveInBack;
        private System.Windows.Forms.Button buttonRecolor;
        private System.Windows.Forms.Button buttonMoveInFront;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonMove;
        private System.Windows.Forms.Button buttonDrawLines;
        private System.Windows.Forms.Button buttonDrawFree;
        private System.Windows.Forms.Button buttonDrawRect;
        private System.Windows.Forms.FlowLayoutPanel BottomPanel;
        private System.Windows.Forms.FlowLayoutPanel RightPanel;
        private System.Windows.Forms.Button buttonDrawOval;
        private System.Windows.Forms.FlowLayoutPanel LeftPanel;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem zoom6ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoom8ToolStripMenuItem1;
        private System.Windows.Forms.Button buttonDrawFreeLines;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonCombinatePlus;
        private System.Windows.Forms.Button buttonCombinateNone;
        private System.Windows.Forms.Button buttonCombinateMinus;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button buttonSelectShape;
        private System.Windows.Forms.Label labelSelectedShape;
        private System.Windows.Forms.ToolStripMenuItem vorlageLadenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vorlagenEntfernenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vorlageTransparentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vorlageNichtTransparentToolStripMenuItem;
        private System.Windows.Forms.Button buttonPickColor;
        private System.Windows.Forms.ToolStripMenuItem rotateToolStripMenuItem;


        public void highlightButtonShading(int dir)
        {
            var color = Color.Black;
            this.buttonShadingLeft.ForeColor = color;
            this.buttonShadingLeftDown.ForeColor = color;
            this.buttonShadingLeftUp.ForeColor = color;
            this.buttonShadingRight.ForeColor = color;
            this.ButtonShadingRightDown.ForeColor = color;
            this.ButtonShadingRightUp.ForeColor = color;
            this.ButtonShadingDown.ForeColor = color;
            this.buttonShadingUp.ForeColor = color;
            this.buttonShadeCenter.ForeColor = color;

            var sel_color = Color.White;
            if (dir == ShaderShape.SHADEDIR_BOTTOM)
                this.ButtonShadingDown.ForeColor = sel_color;
            else if (dir == ShaderShape.SHADEDIR_BOTTOMLEFT)
                this.buttonShadingLeftDown.ForeColor = sel_color;
            else if (dir == ShaderShape.SHADEDIR_BOTTOMRIGHT)
                this.buttonShadingRightDown.ForeColor = sel_color;
            else if (dir == ShaderShape.SHADEDIR_LEFT)
                this.buttonShadingLeft.ForeColor = sel_color;
            else if (dir == ShaderShape.SHADEDIR_RIGHT)
                this.buttonShadingRight.ForeColor = sel_color;
            else if (dir == ShaderShape.SHADEDIR_TOP)
                this.buttonShadingUp.ForeColor = sel_color;
            else if (dir == ShaderShape.SHADEDIR_TOPLEFT)
                this.buttonShadingLeftUp.ForeColor = sel_color;
            else if (dir == ShaderShape.SHADEDIR_TOPRIGHT)
                this.buttonShadingRightUp.ForeColor = sel_color;
            else if (dir == ShaderShape.SHADEDIR_CENTER)
                this.buttonShadeCenter.ForeColor = sel_color;

        }

        public void highlightButtonTool(int sel_tool)
        {
            var color = System.Drawing.SystemColors.ControlDarkDark;

            this.buttonDrawFree.BackColor = color;
            this.buttonDrawOval.BackColor = color;
            this.buttonDrawRect.BackColor = color;
            this.buttonMoveInBack.BackColor = color;
            this.buttonMoveInFront.BackColor = color;
            this.buttonDelete.BackColor = color;
            this.buttonMove.BackColor = color;
            this.buttonCopy.BackColor = color;
            this.buttonDrawLines.BackColor = color;
            this.buttonDrawFreeLines.BackColor = color;
            this.buttonRecolor.BackColor = color;

            var sel_color = Color.Blue;

            if (sel_tool == StateComponent.TOOL_FHAND)
                this.buttonDrawFree.BackColor = sel_color;
            if (sel_tool == StateComponent.TOOL_OVAL)
                this.buttonDrawOval.BackColor = sel_color;
            if (sel_tool == StateComponent.TOOL_RECT)
                this.buttonDrawRect.BackColor = sel_color;
            if (sel_tool == StateComponent.TOOL_MOVEINBACK)
                this.buttonMoveInBack.BackColor = sel_color;
            if (sel_tool == StateComponent.TOOL_MOVEINFRONT)
                this.buttonMoveInFront.BackColor = sel_color;
            if (sel_tool == StateComponent.TOOL_DELETE)
                this.buttonDelete.BackColor = sel_color;
            if (sel_tool == StateComponent.TOOL_MOVE)
                this.buttonMove.BackColor = sel_color;
            if (sel_tool == StateComponent.TOOL_COPY)
                this.buttonCopy.BackColor = sel_color;
            if (sel_tool == StateComponent.TOOL_BHAND)
                this.buttonDrawLines.BackColor = sel_color;
            if (sel_tool == StateComponent.TOOL_BHAND_POINTS)
                this.buttonDrawFreeLines.BackColor = sel_color;
            if (sel_tool == StateComponent.TOOL_RECOLOR)
                this.buttonRecolor.BackColor = sel_color;
        }


        void ButtonDrawOvalClick(object sender, System.EventArgs e)
        {
            this.highlightButtonTool(StateComponent.TOOL_OVAL);
            ToolsController.I().DrawOvalClick();
        }

        void ButtonDrawRectClick(object sender, System.EventArgs e)
        {
            this.highlightButtonTool(StateComponent.TOOL_RECT);
            ToolsController.I().DrawRectClick();
        }


        void ButtonDrawFreeClick(object sender, System.EventArgs e)
        {
            this.highlightButtonTool(StateComponent.TOOL_FHAND);
            ToolsController.I().DrawFreeClick();
        }

        void ButtonDrawLinesClick(object sender, System.EventArgs e)
        {
            this.highlightButtonTool(StateComponent.TOOL_BHAND);
            ToolsController.I().DrawLinesClick();
        }

        void ButtonMoveClick(object sender, System.EventArgs e)
        {
            this.highlightButtonTool(StateComponent.TOOL_MOVE);
            ToolsController.I().MoveClick();
        }

        void ButtonDeleteClick(object sender, System.EventArgs e)
        {
            this.highlightButtonTool(StateComponent.TOOL_DELETE);
            ToolsController.I().DeleteClick();
        }

        void ButtonMoveInFrontClick(object sender, System.EventArgs e)
        {
            this.highlightButtonTool(StateComponent.TOOL_MOVEINFRONT);
            ToolsController.I().MoveInFrontClick();
        }

        void ButtonMoveInBackClick(object sender, System.EventArgs e)
        {
            this.highlightButtonTool(StateComponent.TOOL_MOVEINBACK);
            ToolsController.I().MoveInBackClick();
        }

        void ButtonCopyClick(object sender, System.EventArgs e)
        {
            this.highlightButtonTool(StateComponent.TOOL_COPY);
            ToolsController.I().CopyClick();
        }

        void PictureBoxPaintClick(object sender, System.EventArgs e)
        {

            var me = (MouseEventArgs)e;

            //if(me.Button==System.Windows.Forms.MouseEventArgs.
            //StateComponent.I().Paint_mouse_down=true;
            //PaintController.I().paint_click(me.X,me.Y);			
        }

        void PictureBoxPaintMouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            var me = (MouseEventArgs)e;
            if (StateComponent.I().PaintMouseDown)
            {
                PaintController.I().PaintDrag(me.X, me.Y);
            }
            else if (StateComponent.I().PaintRightMouseDown)
            {
                PaintController.I().PaintRightDrag(me.X, me.Y);
            }
            else
            {
                PaintController.I().PaintMoveOver(me.X, me.Y);
            }                
        }

        void PictureBoxPaintMouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            var me = (MouseEventArgs)e;            
            
            if (me.Button == System.Windows.Forms.MouseButtons.Left)
            {
                PaintController.I().PaintUnclick(me.X, me.Y);
                StateComponent.I().PaintMouseDown = false;
                if (StateComponent.I().SelectedTool == StateComponent.TOOL_BHAND_POINTS)
                {
                    PaintController.I().PaintRightUnclick(me.X, me.Y);//finish scape
                }
                    
            }
            else if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                StateComponent.I().PaintRightMouseDown = false;
                PaintController.I().PaintRightUnclick(me.X, me.Y);//finish scape
            }
        }

        void PictureBoxPaintMouseDown(object sender, MouseEventArgs e)
        {
            var me = (MouseEventArgs)e;
            if (me.Button == System.Windows.Forms.MouseButtons.Left)
            {
                StateComponent.I().PaintMouseDown = true;
                PaintController.I().PaintClick(me.X, me.Y);
            }
            else if (me.Button == System.Windows.Forms.MouseButtons.Right)
            {
                StateComponent.I().PaintRightMouseDown = true;
                PaintController.I().PaintRightClick(me.X, me.Y);
            }
        }

        void ComboBoxLineWidthSelectedIndexChanged(object sender, System.EventArgs e)
        {
            SettingsController.I().LineWidthChanged();
        }

        public ComboBox ComboBoxLineWidth
        {
            get { return comboBoxLineWidth; }
        }
        public ComboBox ComboBoxColorSteps
        {
            get { return comboBoxColorSteps; }
        }
        public Button ButtonDrawingColor
        {
            get { return buttonDrawingColor; }
        }
        public Button ButtonBorderColor
        {
            get { return buttonBorderColor; }
        }
        public Button ButtonShadingUp
        {
            get { return buttonShadingUp; }
        }
        public Button ButtonShadingRightUp
        {
            get { return buttonShadingRightUp; }
        }
        public Button ButtonShadingLeft
        {
            get { return buttonShadingLeft; }
        }
        public Button ButtonShadingRight
        {
            get { return buttonShadingRight; }
        }
        public Button ButtonShadingLeftDown
        {
            get { return buttonShadingLeftDown; }
        }
        public Button ButtonShadingDown
        {
            get { return buttonShadingDown; }
        }
        public Button ButtonShadingRightDown
        {
            get { return buttonShadingRightDown; }
        }
        public Button ButtonShadingLeftUp
        {
            get { return buttonShadingLeftUp; }
        }
        public Button ButtonCombinateNone
        {
            get { return this.buttonCombinateNone; }
        }
        public Button ButtonCombinatePlus
        {
            get { return this.buttonCombinatePlus; }
        }
        public Button ButtonCombinateMinus
        {
            get { return this.buttonCombinateMinus; }
        }
        public Label LabelSelectedShape
        {
            get { return this.labelSelectedShape; }
        }

        void ComboBoxColorStepsSelectedIndexChanged(object sender, System.EventArgs e)
        {
            SettingsController.I().ShadestepsChanged();
        }

        void ButtonDrawingColorClick(object sender, System.EventArgs e)
        {
            colorDialog1.Color = StateComponent.I().CurrentPaintcolor;
            var res = colorDialog1.ShowDialog();
            if (res == DialogResult.OK)
            {
                StateComponent.I().CurrentPaintcolor = colorDialog1.Color;
                SettingsController.I().PaintcolorChanged(colorDialog1.Color);
            }
        }

        void ButtonBorderColorClick(object sender, System.EventArgs e)
        {
            colorDialog1.Color = StateComponent.I().CurrentBordercolor;
            var res = colorDialog1.ShowDialog();
            if (res == DialogResult.OK)
            {
                StateComponent.I().CurrentBordercolor = colorDialog1.Color;
                SettingsController.I().BordercolorChanged(colorDialog1.Color);
            }
        }

        void ButtonShadingLeftUpClick(object sender, System.EventArgs e)
        {
            this.highlightButtonShading(ShaderShape.SHADEDIR_TOPLEFT);
            StateComponent.I().CurrentShadeDirection = ShaderShape.SHADEDIR_TOPLEFT;
        }
        void ButtonShadingUpClick(object sender, System.EventArgs e)
        {
            this.highlightButtonShading(ShaderShape.SHADEDIR_TOP);
            StateComponent.I().CurrentShadeDirection = ShaderShape.SHADEDIR_TOP;
        }
        void ButtonShadingRightUpClick(object sender, System.EventArgs e)
        {
            this.highlightButtonShading(ShaderShape.SHADEDIR_TOPRIGHT);
            StateComponent.I().CurrentShadeDirection = ShaderShape.SHADEDIR_TOPRIGHT;
        }
        void ButtonShadingRightClick(object sender, System.EventArgs e)
        {
            this.highlightButtonShading(ShaderShape.SHADEDIR_RIGHT);
            StateComponent.I().CurrentShadeDirection = ShaderShape.SHADEDIR_RIGHT;
        }
        void ButtonShadingRightDownClick(object sender, System.EventArgs e)
        {
            this.highlightButtonShading(ShaderShape.SHADEDIR_BOTTOMRIGHT);
            StateComponent.I().CurrentShadeDirection = ShaderShape.SHADEDIR_BOTTOMRIGHT;
        }
        void ButtonShadingDownClick(object sender, System.EventArgs e)
        {
            this.highlightButtonShading(ShaderShape.SHADEDIR_BOTTOM);
            StateComponent.I().CurrentShadeDirection = ShaderShape.SHADEDIR_BOTTOM;
        }
        void ButtonShadingLeftDownClick(object sender, System.EventArgs e)
        {
            this.highlightButtonShading(ShaderShape.SHADEDIR_BOTTOMLEFT);
            StateComponent.I().CurrentShadeDirection = ShaderShape.SHADEDIR_BOTTOMLEFT;
        }
        void ButtonShadingLeftClick(object sender, System.EventArgs e)
        {
            this.highlightButtonShading(ShaderShape.SHADEDIR_LEFT);
            StateComponent.I().CurrentShadeDirection = ShaderShape.SHADEDIR_LEFT;
        }
        void ButtonShadeCenterClick(object sender, System.EventArgs e)
        {
            this.highlightButtonShading(ShaderShape.SHADEDIR_CENTER);
            StateComponent.I().CurrentShadeDirection = ShaderShape.SHADEDIR_CENTER;
        }

        void Zoom1ToolStripMenuItemClick(object sender, System.EventArgs e)
        {
            MenuController.I().Zoom(1);
        }
        void Zoom2ToolStripMenuItemClick(object sender, System.EventArgs e)
        {
            MenuController.I().Zoom(2);
        }
        void Zoom3ToolStripMenuItemClick(object sender, System.EventArgs e)
        {
            MenuController.I().Zoom(3);
        }
        void Zoom4ToolStripMenuItemClick(object sender, System.EventArgs e)
        {
            MenuController.I().Zoom(4);
        }

        public PictureBox pictureBoxPaint;
        private Button buttonPalletteManager;
        private Button buttonAddPalette;
        private Button buttonAddPalletteBorderColor;
        private ToolStripMenuItem speicherncopPngToolStripMenuItem;
        private ToolStripMenuItem texturenToolStripMenuItem;
        private ToolStripMenuItem landNoiseToolStripMenuItem;
        private ToolStripMenuItem undoToolStripMenuItem;
        private ToolStripMenuItem gösseÄndernToolStripMenuItem;

        public CheckBox CheckBoxAutocatSave
        {
            get { return checkBoxAutocatSave; }
        }
    }
}