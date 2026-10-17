
using mystical.Model;
using System;
using System.Runtime.Serialization;

namespace comixpaint.common
{
    [Serializable]
    public class ComixpaintSettings : AbstractModel
    {
        public string CmxDirectory { get; set; }
        public string PngDirectory { get; set; }
        public string PaletteDirectory { get; set; }
        public string TemplateDirectory { get; set; }
        public int DefaultWidth { get; set; } = 200;
        public int DefaultHeight { get; set; } = 200;

        public static ComixpaintSettings Instance { get; set; }

        public ComixpaintSettings()
        {            
        }

        ~ComixpaintSettings()
        {
            Save();
        }

        public static void Load()
        {            
            var configFilePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/comixpaint.cfg";
            if (System.IO.File.Exists(configFilePath))
            {
                Instance = LoadObject<ComixpaintSettings>(configFilePath);
            }
            else
            {
                Instance = new ComixpaintSettings();
            }            
        }

        public static void Save()
        {
            var configFilePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/comixpaint.cfg";
            Instance.SaveToFile(configFilePath);
        }


        /// <summary>
        /// Deserialize function
        /// </summary>
        /// <param name="si"></param>
        /// <param name="s"></param>
        public ComixpaintSettings(SerializationInfo si, StreamingContext s)
        {            
            PngDirectory = si.GetString("pngDirectory");
            PaletteDirectory = si.GetString("paletteDirectory");
            try
            {
                CmxDirectory = si.GetString("cmxDirectory");
                DefaultWidth = si.GetInt32("defaultWidth");
                DefaultHeight = si.GetInt32("defaultHeight");
                TemplateDirectory = si.GetString("templateDirectory");
            }
            catch 
            {

            }                       
        }

        /// <summary>
        /// serializible interface
        /// </summary>
        /// <param name="si"></param>
        /// <param name="sc"></param>
        public virtual void GetObjectData(SerializationInfo si, StreamingContext sc)
        {
            si.AddValue("cmxDirectory", CmxDirectory);
            si.AddValue("pngDirectory", PngDirectory);
            si.AddValue("paletteDirectory", PaletteDirectory);
            si.AddValue("templateDirectory", TemplateDirectory);
            si.AddValue("defaultWidth", DefaultWidth);
            si.AddValue("defaultHeight", DefaultHeight);
        }
    }
}

