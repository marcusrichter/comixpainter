
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace comixpaint.common
{
    [Serializable]
    public class ComixpaintSettings : ISerializable
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
            var formatter = new BinaryFormatter();
            var s = File.OpenRead(configFilePath);
#pragma warning disable SYSLIB0011
            Instance = (ComixpaintSettings)formatter.Deserialize(s);
            s.Close();
        }

        public static void Save()
        {
            var configFilePath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/comixpaint.cfg";
            var formatter = new BinaryFormatter();
            var s = File.Create(configFilePath);
#pragma warning disable SYSLIB0011
            formatter.Serialize(s, Instance);
            s.Close();
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

