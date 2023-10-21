using mystical.Data;
using mystical.Grafix.Data;
using mystical.Grafix.ShaderShapes;
using mysticalPlatform.imaging;
using System.Collections.Generic;
using System.Drawing;

namespace comixpaint.components
{
    public class HistoryComponent
    {
        private static HistoryComponent instance = null;

        public static HistoryComponent I()
        {
            if (instance == null)
            {
                instance = new HistoryComponent();
            }

            return instance;
        }

        public Stack<ShaderShapeImage> History { get; set; }

        public Stack<ShaderShapeImage> RestoreHistory { get; set; }

        public FastBitmap Paintbitmap { get; set; }

        public HistoryComponent()
        {
            History = new Stack<ShaderShapeImage>();
            RestoreHistory = new Stack<ShaderShapeImage>();
        }

        public void PushCurrent()
        {
            var shaderShapeImage = StateComponent.I().CurrentImage;            
            var clonedShaderShapeImage = (ShaderShapeImage)shaderShapeImage.Clone();
            History.Push(clonedShaderShapeImage);
        }

        public void Push(ShaderShapeImage shaderShapeImage)
        {
            var clonedShaderShapeImage = (ShaderShapeImage)shaderShapeImage.Clone();
            History.Push(clonedShaderShapeImage);
            RestoreHistory.Clear();
        }

        public ShaderShapeImage Pop()
        {
            if (History.Count == 0)
            {
                return null;
            }

            var poppedEntry = History.Pop();
            RestoreHistory.Push(poppedEntry);

            return poppedEntry;
        }

        public ShaderShapeImage Restore()
        {
            return RestoreHistory.Pop();
        }
    }
}
