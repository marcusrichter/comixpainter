using comixpaint.Services.State;
using mystical.Data;
using mystical.Grafix.ShaderShapes;
using System;
using System.Drawing;

namespace comixpaint.Services.Drawing
{
    public class PaintEditService
    {
        private readonly StateService _state;
        private readonly PaintSurfaceService _paintSurface;
        private object marker = null;

        public PaintEditService(StateService state, PaintSurfaceService paintSurface)
        {
            _state = state;
            _paintSurface = paintSurface;
        }

        /// <summary>
        /// pushes the border pixel of a shape by a rect
        /// </summary>
        public void pixelPush(IntRect pixelPushRect, ShaderShape shape)
        {
            var cpoint = pixelPushRect.CenterPoint();
            for (var iy = pixelPushRect.Y; iy <= pixelPushRect.EY; iy++)
            {
                for (var ix = pixelPushRect.X; ix <= pixelPushRect.EX; ix++)
                {
                    var difx = ix - cpoint.X;
                    var dify = iy - cpoint.Y;
                    if (Math.Abs(difx) >= Math.Abs(dify) && difx != 0)
                    {
                        if (difx < 0)
                        {
                            difx = pixelPushRect.X - cpoint.X - 1;
                            dify = 0;
                        }
                        else
                        {
                            difx = pixelPushRect.EX - cpoint.X + 1;
                            dify = 0;
                        }
                    }
                    else if (dify != 0)
                    {
                        if (dify < 0)
                        {
                            dify = pixelPushRect.Y - cpoint.Y - 1;
                            difx = 0;
                        }
                        else
                        {
                            dify = pixelPushRect.EY - cpoint.Y + 1;
                            difx = 0;
                        }
                    }

                    var points = shape.PointsWithinRect(new IntRect(ix, iy, 1, 1));
                    foreach (var point in points)
                    {
                        point.Point.X += difx;
                        point.Point.Y += dify;
                    }
                }
            }
        }

        public void DrawRectMarker(IntRect markerRect)
        {
            var paintbitmap = _paintSurface.Paintbitmap;
            paintbitmap.LockBitmap();
            for (var iy = markerRect.Y; iy <= markerRect.EY; iy++)
            {
                for (var ix = markerRect.X; ix <= markerRect.EX; ix++)
                {
                    if (ix >= 0 && ix < _state.CurrentImage.Width &&
                       iy >= 0 && iy < _state.CurrentImage.Height)
                    {
                        for (var my = 0; my < _state.Zoomlevel; my++)
                        {
                            for (var mx = 0; mx < _state.Zoomlevel; mx++)
                            {
                                var x = ix * _state.Zoomlevel + mx;
                                var y = iy * _state.Zoomlevel + my;
                                paintbitmap.SetPixel(x, y, Color.Red);
                            }
                        }
                    }
                }
            }

            marker = markerRect;

            paintbitmap.UnlockBitmap();
            MainForm.mainForm.InvalidatePaint();
        }

        public void RemoveMarker()
        {
            if (marker == null)
            {
                return;
            }

            if (marker.GetType().ToString().IndexOf("IntRect") >= 0)
            {
                var oldMarkerRect = (IntRect)marker;
            }

            marker = null;
            _paintSurface.Repaint();
        }
    }
}
