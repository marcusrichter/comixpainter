using comixpaint.Services.State;
using mystical.Data;
using mystical.Grafix.Data;
using mystical.Grafix.ShaderShapes;
using mysticalPlatform.imaging;
using System.Collections.Generic;
using System.Drawing;

namespace comixpaint.Services.Drawing
{
    public class HistoryService
    {
        private readonly StateService _state;

        public Stack<ShaderShapeImage> History { get; set; }

        public Stack<ShaderShapeImage> RestoreHistory { get; set; }

        public FastBitmap Paintbitmap { get; set; }

        public HistoryService(StateService state)
        {
            _state = state;
            History = new Stack<ShaderShapeImage>();
            RestoreHistory = new Stack<ShaderShapeImage>();
        }

        public void PushCurrent()
        {
            var shaderShapeImage = _state.CurrentImage;
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
