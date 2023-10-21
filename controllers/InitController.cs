using comixpaint.common;
using comixpaint.components;
using mystical.Grafix.ShaderShapes;
using mystical.Model;
using System.IO;

namespace comixpaint.controllers
{
    public class InitController
    {
        private static InitController instance = null;

        public static InitController I()
        {
            if (instance == null)
            {
                instance = new InitController();
            }

            return instance;
        }

        public void Init()
        {
            //convert
            /*var files = Directory.GetFiles("C:\\Users\\x\\Documents\\dev\\dotnet\\neverendry\\neverendry\\assets", "*.cop", SearchOption.AllDirectories);
            foreach (var file in files)
            {
                try
                {
                    var shaderShapeImage = ShaderShapeImage.Load(file);
                    var filepathCmx = file.Replace(".cop", ".cmx");
                    shaderShapeImage.SaveToFile(filepathCmx);
                }
                catch(System.Runtime.Serialization.SerializationException ex)
                {

                }               
            }*/


            try
            {
                ComixpaintSettings.Load();
            }
            catch (System.IO.FileNotFoundException)
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
