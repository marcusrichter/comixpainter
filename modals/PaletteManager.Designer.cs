namespace comixpaint.modals
{
    partial class PaletteManager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelPallettes = new System.Windows.Forms.Panel();
            this.buttonLoadPalette = new System.Windows.Forms.Button();
            this.buttonPallettePush = new System.Windows.Forms.Button();
            this.labelPaletteFileName = new System.Windows.Forms.Label();
            this.checkBoxDeleteModus = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBoxRename = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelPallettes
            // 
            this.panelPallettes.AutoScroll = true;
            this.panelPallettes.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panelPallettes.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.panelPallettes.Location = new System.Drawing.Point(11, 16);
            this.panelPallettes.Name = "panelPallettes";
            this.panelPallettes.Size = new System.Drawing.Size(1128, 492);
            this.panelPallettes.TabIndex = 0;
            // 
            // buttonLoadPalette
            // 
            this.buttonLoadPalette.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLoadPalette.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonLoadPalette.Location = new System.Drawing.Point(21, 13);
            this.buttonLoadPalette.Name = "buttonLoadPalette";
            this.buttonLoadPalette.Size = new System.Drawing.Size(88, 23);
            this.buttonLoadPalette.TabIndex = 1;
            this.buttonLoadPalette.Text = "Palette laden";
            this.buttonLoadPalette.UseVisualStyleBackColor = true;
            this.buttonLoadPalette.Click += new System.EventHandler(this.buttonLoadPalette_Click);
            // 
            // buttonPallettePush
            // 
            this.buttonPallettePush.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPallettePush.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonPallettePush.Location = new System.Drawing.Point(115, 12);
            this.buttonPallettePush.Name = "buttonPallettePush";
            this.buttonPallettePush.Size = new System.Drawing.Size(103, 23);
            this.buttonPallettePush.TabIndex = 2;
            this.buttonPallettePush.Text = "Palette ablegen";
            this.buttonPallettePush.UseVisualStyleBackColor = true;
            this.buttonPallettePush.Click += new System.EventHandler(this.buttonPallettePush_Click);
            // 
            // labelPaletteFileName
            // 
            this.labelPaletteFileName.AutoSize = true;
            this.labelPaletteFileName.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.labelPaletteFileName.Location = new System.Drawing.Point(420, 18);
            this.labelPaletteFileName.Name = "labelPaletteFileName";
            this.labelPaletteFileName.Size = new System.Drawing.Size(94, 13);
            this.labelPaletteFileName.TabIndex = 3;
            this.labelPaletteFileName.Text = "Palette Dateiname";
            // 
            // checkBoxDeleteModus
            // 
            this.checkBoxDeleteModus.AutoSize = true;
            this.checkBoxDeleteModus.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxDeleteModus.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.checkBoxDeleteModus.Location = new System.Drawing.Point(224, 16);
            this.checkBoxDeleteModus.Name = "checkBoxDeleteModus";
            this.checkBoxDeleteModus.Size = new System.Drawing.Size(83, 17);
            this.checkBoxDeleteModus.TabIndex = 4;
            this.checkBoxDeleteModus.Text = "Löschmodus";
            this.checkBoxDeleteModus.UseVisualStyleBackColor = true;
            this.checkBoxDeleteModus.CheckedChanged += new System.EventHandler(this.checkBoxDeleteModus_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panelPallettes);
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox1.Location = new System.Drawing.Point(10, 46);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1152, 514);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Farben";
            // 
            // checkBoxRename
            // 
            this.checkBoxRename.AutoSize = true;
            this.checkBoxRename.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxRename.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.checkBoxRename.Location = new System.Drawing.Point(323, 16);
            this.checkBoxRename.Name = "checkBoxRename";
            this.checkBoxRename.Size = new System.Drawing.Size(87, 17);
            this.checkBoxRename.TabIndex = 6;
            this.checkBoxRename.Text = "Umbenennen";
            this.checkBoxRename.UseVisualStyleBackColor = true;
            this.checkBoxRename.CheckedChanged += new System.EventHandler(this.checkBoxRename_CheckedChanged);
            // 
            // PaletteManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(1172, 572);
            this.Controls.Add(this.checkBoxRename);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.checkBoxDeleteModus);
            this.Controls.Add(this.labelPaletteFileName);
            this.Controls.Add(this.buttonPallettePush);
            this.Controls.Add(this.buttonLoadPalette);
            this.Name = "PaletteManager";
            this.Text = "PaletteManager";
            this.Load += new System.EventHandler(this.PaletteManager_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelPallettes;
        private System.Windows.Forms.Button buttonLoadPalette;
        private System.Windows.Forms.Button buttonPallettePush;
        private System.Windows.Forms.Label labelPaletteFileName;
        private System.Windows.Forms.CheckBox checkBoxDeleteModus;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox checkBoxRename;
    }
}