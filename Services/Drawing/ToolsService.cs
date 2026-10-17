using comixpaint.Services.State;

namespace comixpaint.Services.Drawing
{
    public class ToolsService
    {
        private readonly StateService _state;
        private readonly PaintSurfaceService _paintSurface;

        public ToolsService(StateService state, PaintSurfaceService paintSurface)
        {
            _state = state;
            _paintSurface = paintSurface;
        }

        public void DrawOvalClick()
        {
            if (_state.SelectedTool != StateService.TOOL_OVAL)
            {
                _paintSurface.FinishShape();
                _state.SelectedTool = StateService.TOOL_OVAL;
            }
        }

        public void DrawRectClick()
        {
            if (_state.SelectedTool != StateService.TOOL_RECT)
            {
                _paintSurface.FinishShape();
                _state.SelectedTool = StateService.TOOL_RECT;
            }
        }

        public void DrawFreeClick()
        {
            if (_state.SelectedTool != StateService.TOOL_FHAND)
            {
                _paintSurface.FinishShape();
                _state.SelectedTool = StateService.TOOL_FHAND;
            }
        }

        public void DrawLinesClick()
        {
            if (_state.SelectedTool != StateService.TOOL_BHAND)
            {
                _paintSurface.FinishShape();
                _state.SelectedTool = StateService.TOOL_BHAND;
            }
        }

        public void DrawFreeLinesClick()
        {
            if (_state.SelectedTool != StateService.TOOL_BHAND_POINTS)
            {
                _paintSurface.FinishShape();
                _state.SelectedTool = StateService.TOOL_BHAND_POINTS;
            }
        }

        public void MoveClick()
        {
            _state.SelectedTool = StateService.TOOL_MOVE;
            _paintSurface.FinishShape();
        }

        public void DeleteClick()
        {
            _state.SelectedTool = StateService.TOOL_DELETE;
            _paintSurface.FinishShape();
        }

        public void MoveInFrontClick()
        {
            _state.SelectedTool = StateService.TOOL_MOVEINFRONT;
            _paintSurface.FinishShape();
        }

        public void MoveInBackClick()
        {
            _state.SelectedTool = StateService.TOOL_MOVEINBACK;
            _paintSurface.FinishShape();
        }

        public void CopyClick()
        {
            _state.SelectedTool = StateService.TOOL_COPY;
            _paintSurface.FinishShape();
        }

        public void RecolorClick()
        {
            _state.SelectedTool = StateService.TOOL_RECOLOR;
            _paintSurface.FinishShape();
        }

        public void SelectShape()
        {
            _state.SelectedTool = StateService.TOOL_SELECTSHAPE;
            _paintSurface.FinishShape();
        }

        public void PickColor()
        {
            _state.SelectedTool = StateService.TOOL_PICKCOLOR;
            _paintSurface.FinishShape();
        }
    }
}
