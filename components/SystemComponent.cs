using System;
using System.IO;

namespace comixpaint.components
{
    public class SystemComponent : AbstractComponent
    {
        public const string CONFIG_FOLDER = "comixpainter";

        private static SystemComponent instance = null;

        public static SystemComponent I()
        {
            if (instance == null)
            {
                instance = new SystemComponent();
            }

            return instance;
        }

        public string GetOrCreateAppDataFolder()
        {
            var configFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "/" + CONFIG_FOLDER;
            if (!Directory.Exists(configFolder))
            {
                Directory.CreateDirectory(configFolder);
            }

            return configFolder;
        }
    }
}
