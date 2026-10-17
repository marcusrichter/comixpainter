using comixpaint.common;
using System.IO;

namespace comixpaint.Services.App
{
    public class InitService
    {
        public void Init()
        {
            try
            {
                ComixpaintSettings.Load();
            }
            catch (FileNotFoundException)
            {
                ComixpaintSettings.Instance = new ComixpaintSettings();
            }
            catch (System.Runtime.Serialization.SerializationException)
            {
                ComixpaintSettings.Instance = new ComixpaintSettings();
            }
        }
    }
}
