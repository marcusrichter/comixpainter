using comixpaint.Services.State;
using mystical.Data;
using mystical.Grafix.ShaderShapes;
using System.Drawing;

namespace comixpaint.Services.Drawing
{
    public class PaintService
    {
        private readonly StateService _state;
        private readonly PaintSurfaceService _paintSurface;
        private readonly HistoryService _history;
        private readonly TemplateService _template;

        private IntPoint mousedragPoint = null;
        private IntPoint mousedragRightButtonPoint = null;

        public PaintService(StateService state, PaintSurfaceService paintSurface, HistoryService history, TemplateService template)
        {
            _state = state;
            _paintSurface = paintSurface;
            _history = history;
            _template = template;
        }

        public void PaintClick(int x, int y)
        {
            var mpoint = new IntPoint(x / _state.Zoomlevel, y / _state.Zoomlevel);
            mpoint = _state.CurrentImage.GetClipRect().ClipPoint(mpoint);
            mousedragPoint = mpoint;

            if (_state.SkizShape == null)
            {
                var shapetype = -1;
                if (_state.SelectedTool == StateService.TOOL_FHAND)
                {
                    shapetype = ShaderShape.SHAPETYPE_FREE;
                }
                else if (_state.SelectedTool == StateService.TOOL_OVAL)
                {
                    shapetype = ShaderShape.SHAPETYPE_OVAL;
                }
                else if (_state.SelectedTool == StateService.TOOL_RECT)
                {
                    shapetype = ShaderShape.SHAPETYPE_RECT;
                }
                else if (_state.SelectedTool == StateService.TOOL_BHAND
                        || _state.SelectedTool == StateService.TOOL_BHAND_POINTS)
                {
                    shapetype = ShaderShape.SHAPETYPE_FREEPIX;
                }

                if (shapetype != -1)
                {
                    var lw = _state.CurrentLineWidth;
                    if (lw == 0)
                    {
                        lw = 1;
                    }

                    var shape = _state.CurrentImage.CreateShape(shapetype,
                        lw,
                        _state.CurrentShadeDirection,
                        _state.CurrentShadesteps,
                        _state.CurrentPaintcolor,
                        _state.CurrentBordercolor
                        );
                    shape.SkizMode = true;
                    _state.SkizShape = shape;
                }
            }

            if (_state.SelectedTool == StateService.TOOL_FHAND || _state.SelectedTool == StateService.TOOL_BHAND)
            {
                _state.SkizShape.AddPoint(mpoint.X, mpoint.Y);
                _paintSurface.Repaint();
            }
            else if (_state.SelectedTool == StateService.TOOL_OVAL || _state.SelectedTool == StateService.TOOL_RECT)
            {
                _state.SkizShape.Paint();
                _state.SkizShape.AddOrUpdatePoint(mpoint.X, mpoint.Y, 2);
                _paintSurface.Repaint();
            }
            else if (_state.SelectedTool == StateService.TOOL_MOVE)
            {
                _state.SelectedShape = _state.CurrentImage.GetTopShapeAtXY(mpoint.X, mpoint.Y);
            }
            else if (_state.SelectedTool == StateService.TOOL_DELETE)
            {
                var shapeToDelete = _state.CurrentImage.GetTopShapeAtXY(mpoint.X, mpoint.Y);
                if (shapeToDelete != null)
                {
                    _history.PushCurrent();
                    _state.CurrentImage.RemoveShape(shapeToDelete);
                    _paintSurface.Repaint(true);
                }
            }
            else if (_state.SelectedTool == StateService.TOOL_MOVEINFRONT)
            {
                var shapeToMove = _state.CurrentImage.GetTopShapeAtXY(mpoint.X, mpoint.Y);
                if (shapeToMove != null)
                {
                    _history.PushCurrent();
                    _state.CurrentImage.MoveShapeInFront(shapeToMove);
                    _paintSurface.Repaint(true);
                }
            }
            else if (_state.SelectedTool == StateService.TOOL_MOVEINBACK)
            {
                var shapeToMove = _state.CurrentImage.GetTopShapeAtXY(mpoint.X, mpoint.Y);
                if (shapeToMove != null)
                {
                    _history.PushCurrent();
                    _state.CurrentImage.MoveShapeInBack(shapeToMove);
                    _paintSurface.Repaint(true);
                }
            }
            else if (_state.SelectedTool == StateService.TOOL_COPY)
            {
                var shapeToCopy = _state.CurrentImage.GetTopShapeAtXY(mpoint.X, mpoint.Y);
                if (shapeToCopy != null)
                {
                    _history.PushCurrent();
                    var cloneShape = (ShaderShape)shapeToCopy.Clone();
                    cloneShape.Clear();
                    cloneShape.Paint();

                    cloneShape.TranslateX += 4;
                    cloneShape.TranslateY += 4;
                    _state.CurrentImage.Shapes.Add(cloneShape);
                    _paintSurface.Repaint(true);
                }
            }
            else if (_state.SelectedTool == StateService.TOOL_RECOLOR)
            {
                var shapeToRecolor = _state.CurrentImage.GetTopShapeAtXY(mpoint.X, mpoint.Y);
                if (shapeToRecolor != null)
                {
                    _history.PushCurrent();
                    shapeToRecolor.Paintcolor = _state.CurrentPaintcolor;
                    shapeToRecolor.Bordercolor = _state.CurrentBordercolor;
                    shapeToRecolor.Clear();

                    _paintSurface.Repaint();
                }
            }
        }

        public void PaintRightClick(int x, int y)
        {
            var mpoint = new IntPoint(x / _state.Zoomlevel, y / _state.Zoomlevel);
            mpoint = _state.CurrentImage.GetClipRect().ClipPoint(mpoint);
            mousedragRightButtonPoint = mpoint;
        }

        public void PaintDrag(int x, int y)
        {
            var clipRect = _state.CurrentImage.GetClipRect();
            var mpoint = new IntPoint(x / _state.Zoomlevel, y / _state.Zoomlevel);
            mpoint = clipRect.ClipPoint(mpoint);
            var lastMousedragPoint = mousedragPoint;
            mousedragPoint = mpoint;

            if (_state.SelectedTool == StateService.TOOL_MOVE &&
                _state.SelectedShape != null)
            {
                var selectedShape = _state.SelectedShape;
                var translatePoint = ((IntPoint)mpoint.Clone()).Subtract(lastMousedragPoint);
                selectedShape.TranslateX += translatePoint.X;
                selectedShape.TranslateY += translatePoint.Y;
                _paintSurface.Repaint(false);

                return;
            }

            var diffDragPoint = mpoint.Subtract(lastMousedragPoint);

            mousedragPoint = mpoint;

            if (_state.SelectedTool == StateService.TOOL_FHAND || _state.SelectedTool == StateService.TOOL_BHAND
               || _state.SelectedTool == StateService.TOOL_BHAND_POINTS)
            {
                if (_state.SkizShape != null)
                {
                    _state.SkizShape.AddPoint(mpoint.X, mpoint.Y);
                    _paintSurface.Repaint();
                }

                return;
            }
            if (_state.SelectedTool == StateService.TOOL_OVAL || _state.SelectedTool == StateService.TOOL_RECT)
            {
                _state.SkizShape.AddOrUpdatePoint(mpoint.X, mpoint.Y, 2);
                _paintSurface.Repaint();

                return;
            }

            if (null == _state.SelectedShape && _template.Image != null)
            {
                _template.TranslateX += diffDragPoint.X;
                _template.TranslateY += diffDragPoint.Y;
                _template.LoadTemplate();
            }
        }

        public void PaintRightDrag(int x, int y)
        {
            var clipRect = _state.CurrentImage.GetClipRect();
            var mpoint = new IntPoint(x / _state.Zoomlevel, y / _state.Zoomlevel);
            mpoint = clipRect.ClipPoint(mpoint);
            var lastMousedragRightButtonPoint = mousedragRightButtonPoint;
            mousedragRightButtonPoint = mpoint;

            if (_state.SelectedTool == StateService.TOOL_MOVE)
            {
                var translatePoint = ((IntPoint)mpoint.Clone()).Subtract(lastMousedragRightButtonPoint);
                foreach (var shape in _state.CurrentImage.Shapes)
                {
                    shape.TranslateX += translatePoint.X;
                    shape.TranslateY += translatePoint.Y;
                }

                _paintSurface.Repaint(false);

                return;
            }
        }

        public void PaintMoveOver(int x, int y)
        {
            var mpoint = new IntPoint(x / _state.Zoomlevel, y / _state.Zoomlevel);
            mpoint = _state.CurrentImage.GetClipRect().ClipPoint(mpoint);
        }

        public void PaintUnclick(int x, int y)
        {
            var mpoint = new IntPoint(x / _state.Zoomlevel, y / _state.Zoomlevel);
            mpoint = _state.CurrentImage.GetClipRect().ClipPoint(mpoint);
            if (_state.SelectedTool == StateService.TOOL_OVAL || _state.SelectedTool == StateService.TOOL_RECT)
            {
                _state.SkizShape.AddOrUpdatePoint(mpoint.X, mpoint.Y, 2);
                _paintSurface.FinishShape();
            }
            else if (_state.SelectedTool == StateService.TOOL_SELECTSHAPE)
            {
                var selectedShape = _state.CurrentImage.GetTopShapeAtXY(mpoint.X, mpoint.Y);
                _state.SelectedShape = selectedShape;
            }
            else if (_state.SelectedTool == StateService.TOOL_PICKCOLOR)
            {
                var shapeColorPick = _state.CurrentImage.GetTopShapeAtXY(mpoint.X, mpoint.Y);
                if (shapeColorPick != null)
                {
                    _state.CurrentPaintcolor = shapeColorPick.Paintcolor;
                    MainForm.mainForm.ButtonDrawingColor.BackColor = shapeColorPick.Paintcolor;
                }
                else if (_paintSurface.TemplateImage != null)
                {
                    _paintSurface.Paintbitmap.LockBitmap();
                    var templateColorPick = _paintSurface.Paintbitmap.GetPixel(x, y);
                    if (templateColorPick.ToArgb() != Color.White.ToArgb())
                    {
                        _state.CurrentPaintcolor = templateColorPick;
                        MainForm.mainForm.ButtonDrawingColor.BackColor = templateColorPick;
                    }
                    _paintSurface.Paintbitmap.UnlockBitmap();
                }
            }
            else if (_state.SelectedTool == StateService.TOOL_MOVE)
            {
                if (_state.SelectedShape != null)
                {
                    _paintSurface.Repaint();
                }
            }
        }

        public void PaintRightUnclick(int x, int y)
        {
            var mpoint = new IntPoint(x / _state.Zoomlevel, y / _state.Zoomlevel);

            var selectedTool = _state.SelectedTool;
            var selectedShape = _state.CurrentImage != null ? _state.CurrentImage.GetTopShapeAtXY(mpoint.X, mpoint.Y) : null;

            if (selectedTool == StateService.TOOL_MOVEINFRONT)
            {
                _state.CurrentImage.MoveShapeOneStepInFront(selectedShape);
                _paintSurface.Repaint(true);

                return;
            }

            if (selectedTool == StateService.TOOL_MOVEINBACK)
            {
                _state.CurrentImage.MoveShapeOneStepInBack(selectedShape);
                _paintSurface.Repaint(true);

                return;
            }

            if (_state.SkizShape != null &&
                (selectedTool == StateService.TOOL_FHAND
               || selectedTool == StateService.TOOL_BHAND
               || selectedTool == StateService.TOOL_BHAND_POINTS)
              )
            {
                _history.Push(_state.CurrentImage);
                var finishedShape = _paintSurface.FinishShape();
                if (finishedShape != null)
                {
                    _state.SelectedShape = finishedShape;
                    finishedShape.Paintcolor = _state.CurrentPaintcolor;
                    finishedShape.Bordercolor = _state.CurrentBordercolor;
                    finishedShape.Linewidth = _state.CurrentLineWidth;
                    finishedShape.Shadedir = _state.CurrentShadeDirection;
                    finishedShape.Shadesteps = _state.CurrentShadesteps;
                    finishedShape.Paint();
                    _paintSurface.Repaint();
                }

                return;
            }
        }
    }
}
