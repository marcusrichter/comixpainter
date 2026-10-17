using System;
using System.IO;

namespace comixpaint.Services.App
{
    public class AppDataService
    {
        public const string CONFIG_FOLDER = "comixpainter";

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
