using comixpaint.components;
using mystical.Data;
using mystical.Grafix.ShaderShapes;
using System.Drawing;

namespace comixpaint.controllers
{
    public class PaintController
    {
        private static PaintController instance = null;        
        private IntPoint mousedragPoint = null;
        private IntPoint mousedragRightButtonPoint = null;

        public static PaintController I()
        {
            if (instance == null)
            {
                instance = new PaintController();
            }

            return instance;
        }

        public PaintController()
        {
        }

        public void PaintClick(int x, int y)
        {
            var mpoint = new IntPoint(x / StateComponent.I().Zoomlevel, y / StateComponent.I().Zoomlevel);
            mpoint = StateComponent.I().CurrentImage.GetClipRect().ClipPoint(mpoint);            
            mousedragPoint = mpoint;

            if (StateComponent.I().SkizShape == null)
            {
                var shapetype = -1;
                if (StateComponent.I().SelectedTool == StateComponent.TOOL_FHAND)
                {
                    shapetype = ShaderShape.SHAPETYPE_FREE;
                }
                else if (StateComponent.I().SelectedTool == StateComponent.TOOL_OVAL)
                {
                    shapetype = ShaderShape.SHAPETYPE_OVAL;
                }
                else if (StateComponent.I().SelectedTool == StateComponent.TOOL_RECT)
                {
                    shapetype = ShaderShape.SHAPETYPE_RECT;
                }
                else if (StateComponent.I().SelectedTool == StateComponent.TOOL_BHAND
                        || StateComponent.I().SelectedTool == StateComponent.TOOL_BHAND_POINTS)
                {
                    shapetype = ShaderShape.SHAPETYPE_FREEPIX;
                }

                if (shapetype != -1)
                {
                    var lw = StateComponent.I().CurrentLineWidth;
                    if (lw == 0)
                    {
                        lw = 1;
                    }

                    var shape = StateComponent.I().CurrentImage.CreateShape(shapetype,
                        lw,
                        StateComponent.I().CurrentShadeDirection,
                        StateComponent.I().CurrentShadesteps,
                        StateComponent.I().CurrentPaintcolor,
                        StateComponent.I().CurrentBordercolor
                        );
                    shape.SkizMode = true;
                    StateComponent.I().SkizShape = shape;
                }
            }

            if (StateComponent.I().SelectedTool == StateComponent.TOOL_FHAND || StateComponent.I().SelectedTool == StateComponent.TOOL_BHAND)
            {
                StateComponent.I().SkizShape.AddPoint(mpoint.X, mpoint.Y);
                PaintComponent.I().Repaint();
            }
            else if (StateComponent.I().SelectedTool == StateComponent.TOOL_OVAL || StateComponent.I().SelectedTool == StateComponent.TOOL_RECT)
            {
                StateComponent.I().SkizShape.Paint();
                StateComponent.I().SkizShape.AddOrUpdatePoint(mpoint.X, mpoint.Y, 2);
                PaintComponent.I().Repaint();
            }
            else if (StateComponent.I().SelectedTool == StateComponent.TOOL_MOVE)
            {
                StateComponent.I().SelectedShape = StateComponent.I().CurrentImage.GetTopShapeAtXY(mpoint.X, mpoint.Y);
            }
            else if (StateComponent.I().SelectedTool == StateComponent.TOOL_DELETE)
            {
                var shapeToDelete = StateComponent.I().CurrentImage.GetTopShapeAtXY(mpoint.X, mpoint.Y);
                if (shapeToDelete != null)
                {                    
                    HistoryComponent.I().PushCurrent();
                    StateComponent.I().CurrentImage.RemoveShape(shapeToDelete);
                    PaintComponent.I().Repaint(true);
                }
            }
            else if (StateComponent.I().SelectedTool == StateComponent.TOOL_MOVEINFRONT)
            {
                var shapeToMove = StateComponent.I().CurrentImage.GetTopShapeAtXY(mpoint.X, mpoint.Y);
                if (shapeToMove != null)
                {
                    HistoryComponent.I().PushCurrent();
                    StateComponent.I().CurrentImage.MoveShapeInFront(shapeToMove);
                    PaintComponent.I().Repaint(true);
                }
            }
            else if (StateComponent.I().SelectedTool == StateComponent.TOOL_MOVEINBACK)
            {
                var shapeToMove = StateComponent.I().CurrentImage.GetTopShapeAtXY(mpoint.X, mpoint.Y);
                if (shapeToMove != null)
                {
                    HistoryComponent.I().PushCurrent();
                    StateComponent.I().CurrentImage.MoveShapeInBack(shapeToMove);
                    PaintComponent.I().Repaint(true);
                }
            }
            else if (StateComponent.I().SelectedTool == StateComponent.TOOL_COPY)
            {
                var shapeToCopy = StateComponent.I().CurrentImage.GetTopShapeAtXY(mpoint.X, mpoint.Y);
                if (shapeToCopy != null)
                {
                    HistoryComponent.I().PushCurrent();
                    var cloneShape = (ShaderShape)shapeToCopy.Clone();
                    cloneShape.Clear();
                    cloneShape.Paint();

                    cloneShape.TranslateX += 4;
                    cloneShape.TranslateY += 4;
                    StateComponent.I().CurrentImage.Shapes.Add(cloneShape);
                    PaintComponent.I().Repaint(true);
                }
            }
            else if (StateComponent.I().SelectedTool == StateComponent.TOOL_RECOLOR)
            {
                //recolor shape element
                var shapeToRecolor = StateComponent.I().CurrentImage.GetTopShapeAtXY(mpoint.X, mpoint.Y);
                if (shapeToRecolor != null)
                {
                    HistoryComponent.I().PushCurrent();
                    shapeToRecolor.Paintcolor = StateComponent.I().CurrentPaintcolor;
                    shapeToRecolor.Bordercolor = StateComponent.I().CurrentBordercolor;
                    shapeToRecolor.Clear();

                    PaintComponent.I().Repaint();
                }
            }
        }

        public void PaintRightClick(int x, int y)
        {
            var mpoint = new IntPoint(x / StateComponent.I().Zoomlevel, y / StateComponent.I().Zoomlevel);
            mpoint = StateComponent.I().CurrentImage.GetClipRect().ClipPoint(mpoint);
            mousedragRightButtonPoint = mpoint;            
        }

        public void PaintDrag(int x, int y)
        {
            var clipRect = StateComponent.I().CurrentImage.GetClipRect();
            var mpoint = new IntPoint(x / StateComponent.I().Zoomlevel, y / StateComponent.I().Zoomlevel);
            mpoint = clipRect.ClipPoint(mpoint);
            var lastMousedragPoint = mousedragPoint;
            mousedragPoint = mpoint;

            if (StateComponent.I().SelectedTool == StateComponent.TOOL_MOVE && 
                StateComponent.I().SelectedShape != null)
            {
                var selectedShape = StateComponent.I().SelectedShape;
                var translatePoint = ((IntPoint)mpoint.Clone()).Subtract(lastMousedragPoint);
                selectedShape.TranslateX += translatePoint.X;
                selectedShape.TranslateY += translatePoint.Y;
                PaintComponent.I().Repaint(false);

                return;
            }

            var diffDragPoint = mpoint.Subtract(lastMousedragPoint);

            mousedragPoint = mpoint;

            if (StateComponent.I().SelectedTool == StateComponent.TOOL_FHAND || StateComponent.I().SelectedTool == StateComponent.TOOL_BHAND
               || StateComponent.I().SelectedTool == StateComponent.TOOL_BHAND_POINTS)
            {
                if (StateComponent.I().SkizShape != null)
                {
                    StateComponent.I().SkizShape.AddPoint(mpoint.X, mpoint.Y);
                    //StateComponent.I().CurrentImage.Current_shape.Skiz_image.Bitmap.Save("skiz_img.png");
                    PaintComponent.I().Repaint();
                }

                return;
            }
            if (StateComponent.I().SelectedTool == StateComponent.TOOL_OVAL || StateComponent.I().SelectedTool == StateComponent.TOOL_RECT)
            {
                StateComponent.I().SkizShape.AddOrUpdatePoint(mpoint.X, mpoint.Y, 2);
                PaintComponent.I().Repaint();

                return;
            }

            if (null == StateComponent.I().SelectedShape && TemplateComponent.I().Image != null)
            {
                TemplateComponent.I().TranslateX += diffDragPoint.X;
                TemplateComponent.I().TranslateY += diffDragPoint.Y;
                TemplateComponent.I().LoadTemplate();
            }
        }

        public void PaintRightDrag(int x, int y)
        {
            var clipRect = StateComponent.I().CurrentImage.GetClipRect();
            var mpoint = new IntPoint(x / StateComponent.I().Zoomlevel, y / StateComponent.I().Zoomlevel);
            mpoint = clipRect.ClipPoint(mpoint);
            var lastMousedragRightButtonPoint = mousedragRightButtonPoint;
            mousedragRightButtonPoint = mpoint;

            if (StateComponent.I().SelectedTool == StateComponent.TOOL_MOVE)
            { 
                //translate all shapes
                var translatePoint = ((IntPoint)mpoint.Clone()).Subtract(lastMousedragRightButtonPoint);
                foreach (var shape in StateComponent.I().CurrentImage.Shapes)
                {
                    shape.TranslateX += translatePoint.X;
                    shape.TranslateY += translatePoint.Y;
                }

                PaintComponent.I().Repaint(false);

                return;
            }
        }

        public void PaintMoveOver(int x, int y)
        {
            var mpoint = new IntPoint(x / StateComponent.I().Zoomlevel, y / StateComponent.I().Zoomlevel);
            mpoint = StateComponent.I().CurrentImage.GetClipRect().ClipPoint(mpoint);
        }

        public void PaintUnclick(int x, int y)
        {
            var mpoint = new IntPoint(x / StateComponent.I().Zoomlevel, y / StateComponent.I().Zoomlevel);
            mpoint = StateComponent.I().CurrentImage.GetClipRect().ClipPoint(mpoint);
            if (StateComponent.I().SelectedTool == StateComponent.TOOL_OVAL || StateComponent.I().SelectedTool == StateComponent.TOOL_RECT)
            {
                StateComponent.I().SkizShape.AddOrUpdatePoint(mpoint.X, mpoint.Y, 2);
                //PaintComponent.I().repaint();
                PaintComponent.I().FinishShape();
            }
            else if (StateComponent.I().SelectedTool == StateComponent.TOOL_SELECTSHAPE)
            {
                var selectedShape = StateComponent.I().CurrentImage.GetTopShapeAtXY(mpoint.X, mpoint.Y);
                StateComponent.I().SelectedShape = selectedShape;
                if (selectedShape != null)
                {
                    MainForm.mainForm.LabelSelectedShape.Text = "Shape:" + selectedShape.Id;
                }
                else
                {
                    MainForm.mainForm.LabelSelectedShape.Text = "Shape:";
                }
            }
            else if (StateComponent.I().SelectedTool == StateComponent.TOOL_PICKCOLOR)
            {
                var shapeColorPick = StateComponent.I().CurrentImage.GetTopShapeAtXY(mpoint.X, mpoint.Y);
                if (shapeColorPick != null)
                {
                    StateComponent.I().CurrentPaintcolor = shapeColorPick.Paintcolor;
                    MainForm.mainForm.ButtonDrawingColor.BackColor = shapeColorPick.Paintcolor;
                }
                else if (PaintComponent.I().TemplateImage != null)
                {
                    PaintComponent.I().Paintbitmap.LockBitmap();
                    var templateColorPick = PaintComponent.I().Paintbitmap.GetPixel(x, y);
                    if (templateColorPick.ToArgb() != Color.White.ToArgb())
                    {
                        StateComponent.I().CurrentPaintcolor = templateColorPick;
                        MainForm.mainForm.ButtonDrawingColor.BackColor = templateColorPick;
                    }
                    PaintComponent.I().Paintbitmap.UnlockBitmap();
                }
            }
            else if (StateComponent.I().SelectedTool == StateComponent.TOOL_MOVE)
            {
                if (StateComponent.I().SelectedShape != null)
                {
                    //StateComponent.I().SelectedShape.ApplyTranslate();
                    PaintComponent.I().Repaint();
                }
            }
        }

        public void PaintRightUnclick(int x, int y)
        {
            var mpoint = new IntPoint(x / StateComponent.I().Zoomlevel, y / StateComponent.I().Zoomlevel);

            var selectedTool = StateComponent.I().SelectedTool;
            var selectedShape = StateComponent.I().CurrentImage != null ? StateComponent.I().CurrentImage.GetTopShapeAtXY(mpoint.X, mpoint.Y) : null;

            if (selectedTool == StateComponent.TOOL_MOVEINFRONT)
            {
                StateComponent.I().CurrentImage.MoveShapeOneStepInFront(selectedShape);
                PaintComponent.I().Repaint(true);

                return;
            }

            if (selectedTool == StateComponent.TOOL_MOVEINBACK)
            {
                StateComponent.I().CurrentImage.MoveShapeOneStepInBack(selectedShape);
                PaintComponent.I().Repaint(true);

                return;
            }

            if (StateComponent.I().SkizShape != null && 
                (selectedTool == StateComponent.TOOL_FHAND
               || selectedTool == StateComponent.TOOL_BHAND
               || selectedTool == StateComponent.TOOL_BHAND_POINTS)
              )
            { 
                HistoryComponent.I().Push(StateComponent.I().CurrentImage);                
                var finishedShape = PaintComponent.I().FinishShape();
                if (finishedShape != null)
                {
                    StateComponent.I().SelectedShape = finishedShape;
                    MainForm.mainForm.LabelSelectedShape.Text = "Shape:" + finishedShape.Id;
                    finishedShape.Paintcolor = StateComponent.I().CurrentPaintcolor;
                    finishedShape.Bordercolor = StateComponent.I().CurrentBordercolor;
                    finishedShape.Linewidth = StateComponent.I().CurrentLineWidth;
                    finishedShape.Shadedir = StateComponent.I().CurrentShadeDirection;
                    finishedShape.Shadesteps = StateComponent.I().CurrentShadesteps;
                    finishedShape.Paint();
                    PaintComponent.I().Repaint();
                }

                return;
            }
        }
    }
}
