using mystical.Data;
using mystical.Grafix.ShaderShapes;
using System;
using System.Drawing;

namespace comixpaint.components
{ 
    public class PainteditComponent
    {
        private static PainteditComponent instance = null;
        private object marker = null;

        public static PainteditComponent I()
        {
            if (instance == null)
            {
                instance = new PainteditComponent();
            }

            return instance;
        }

        public PainteditComponent()
        {
        }

        /// <summary>
        /// psuhes the border pixel of an shape by a rect
        /// </summary>
        /// <param name="pixelPushRect"></param>
        /// <param name="shape"></param>
        public void pixelPush(IntRect pixelPushRect, ShaderShape shape)
        {
            var cpoint = pixelPushRect.CenterPoint();
            for (var iy = pixelPushRect.Y; iy <= pixelPushRect.EY; iy++)
            {
                for (var ix = pixelPushRect.X; ix <= pixelPushRect.EX; ix++)
                {

                    //calculate push vectors
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
            var paintbitmap = PaintComponent.I().Paintbitmap;
            paintbitmap.LockBitmap();
            for (var iy = markerRect.Y; iy <= markerRect.EY; iy++)
            {
                for (var ix = markerRect.X; ix <= markerRect.EX; ix++)
                {
                    if (ix >= 0 && ix < StateComponent.I().CurrentImage.Width &&
                       iy >= 0 && iy < StateComponent.I().CurrentImage.Height)
                    {
                        for (var my = 0; my < StateComponent.I().Zoomlevel; my++)
                        {
                            for (var mx = 0; mx < StateComponent.I().Zoomlevel; mx++)
                            {
                                var x = ix * StateComponent.I().Zoomlevel + mx;
                                var y = iy * StateComponent.I().Zoomlevel + my;
                                paintbitmap.SetPixel(x, y, Color.Red);
                            }
                        }
                    }
                }
            }

            marker = markerRect;

            paintbitmap.UnlockBitmap();
            MainForm.mainForm.PictureBoxPaint.Invalidate();
        }

        public void RemoveMarker()
        {
            if (marker == null)
            {
                return;
            }

            IntRect invalidateRect = null;

            if (marker.GetType().ToString().IndexOf("IntRect") >= 0)
            {
                var oldMarkerRect = (IntRect)marker;
                //invalidateRect=new IntRect(oldMarkerRect.X*StateComponent.I().Zoomlevel,oldMarkerRect.Y*StateComponent.I().Zoomlevel,oldMarkerRect.Width*StateComponent.I().Zoomlevel+1,oldMarkerRect.Height*StateComponent.I().Zoomlevel+1);
                invalidateRect = new IntRect(oldMarkerRect.X, oldMarkerRect.Y, oldMarkerRect.Width + 1, oldMarkerRect.Height + 1);
            }
            marker = null;
            PaintComponent.I().Repaint();
        }

    }
}
