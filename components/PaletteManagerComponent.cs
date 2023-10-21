using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace comixpaint.components
{
    public class PaletteManagerComponent
    {
        public const string CONFIG_FILE_PALLETTE = "comixpaint_palettepath.cfg";
        public const string FILE_PALLETTE_DEFAULT = "default.pal";
        public const string SEPERATOR_COLOR_TYPE = "#+#";
        public const string SEPERATOR_COLORS = "#;#";
        public const string SEPERATOR_COLOR_NAME = "#,#";

        private static PaletteManagerComponent instance = null;

        public Dictionary<string, Color> Colors { get; protected set; } = new Dictionary<string, Color>();
        public Dictionary<string, Color> BorderColors { get; protected set; } = new Dictionary<string, Color>();

        public string PalettePath { get; set; }

        public static PaletteManagerComponent I()
        {
            if (instance == null)
            {
                instance = new PaletteManagerComponent();
                instance.Init();
            }

            return instance;
        }

        public void Init()
        {
            if (LoadPalettePath())
            {
                if (File.Exists(PalettePath))
                {
                    LoadPalette();
                }
            }
        }

        public string GetPaletteFileName()
        {
            return PalettePath.Split('\\')[PalettePath.Split('\\').Length - 1];
        }

        public bool LoadPalettePath()
        {
            var configPaletteFilePath = SystemComponent.I().GetOrCreateAppDataFolder() + "\\" + CONFIG_FILE_PALLETTE;
            if (!File.Exists(configPaletteFilePath))
            {
                PalettePath = SystemComponent.I().GetOrCreateAppDataFolder() + "\\" + FILE_PALLETTE_DEFAULT;
                SavePalettePath();
                return false;
            }

            PalettePath = File.ReadAllText(configPaletteFilePath);
            return true;
        }

        public void SavePalettePath()
        {
            var configPaletteFilePath = SystemComponent.I().GetOrCreateAppDataFolder() + "\\" + CONFIG_FILE_PALLETTE;
            File.WriteAllText(configPaletteFilePath, PalettePath);
        }

        public void LoadPalette()
        {
            var serializedPalette = File.ReadAllText(PalettePath);
            var splitSerializedPalette = serializedPalette.Split(new string[] { SEPERATOR_COLOR_TYPE }, StringSplitOptions.None);
            for (var i = 0; i < 2; i++)
            {
                if (splitSerializedPalette[i] == string.Empty)
                {
                    continue;
                }

                var colorSplits = splitSerializedPalette[i].Split(new string[] { SEPERATOR_COLORS }, StringSplitOptions.None);
                var dic = new Dictionary<string, Color>();
                foreach (var colorSplit in colorSplits)
                {
                    var nameColor = colorSplit.Split(new string[] { SEPERATOR_COLOR_NAME }, StringSplitOptions.None);
                    dic[nameColor[0]] = Color.FromArgb(int.Parse(nameColor[1]));
                }

                if (i == 0)
                {
                    Colors = dic;
                }
                else
                {
                    BorderColors = dic;
                }
            }
        }

        public void SavePalette()
        {
            var serializedPaletteSb = new StringBuilder();

            for (var i = 0; i < 2; i++)
            {
                Dictionary<string, Color> dic = null;
                if (i == 0)
                {
                    dic = Colors;
                }
                else
                {
                    dic = BorderColors;
                }

                serializedPaletteSb.Append(
                    string.Join(SEPERATOR_COLORS, dic.Select(nc => nc.Key + SEPERATOR_COLOR_NAME + nc.Value.ToArgb()).ToList<string>())
                    );
                if (i == 0)
                {
                    serializedPaletteSb.Append(SEPERATOR_COLOR_TYPE);
                }
            }

            File.WriteAllText(PalettePath, serializedPaletteSb.ToString());
        }
    }
}
