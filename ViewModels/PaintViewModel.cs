using comixpaint.Services.Drawing;
using comixpaint.Services.State;
using CommunityToolkit.Mvvm.ComponentModel;
using System;

namespace comixpaint.ViewModels
{
    public partial class PaintViewModel : ViewModelBase
    {
        private readonly PaintService _paintService;
        private readonly StateService _state;
        private readonly TemplateService _templateService;

        [ObservableProperty]
        private string _selectedShapeLabel = "Shape:";

        public PaintViewModel(PaintService paintService, StateService state, TemplateService templateService)
        {
            _paintService = paintService;
            _state = state;
            _templateService = templateService;
        }

        public void OnMouseDown(int x, int y, bool rightButton)
        {
            if (rightButton)
            {
                _state.PaintRightMouseDown = true;
                _paintService.PaintRightClick(x, y);
            }
            else
            {
                _state.PaintMouseDown = true;
                _paintService.PaintClick(x, y);
            }

            SyncSelectedShapeLabel();
        }

        public void OnMouseMove(int x, int y)
        {
            if (_state.PaintMouseDown)
            {
                _paintService.PaintDrag(x, y);
            }
            else if (_state.PaintRightMouseDown)
            {
                _paintService.PaintRightDrag(x, y);
            }
            else
            {
                _paintService.PaintMoveOver(x, y);
            }
        }

        public void OnMouseUp(int x, int y, bool rightButton)
        {
            if (rightButton)
            {
                _state.PaintRightMouseDown = false;
                _paintService.PaintRightUnclick(x, y);
            }
            else
            {
                _paintService.PaintUnclick(x, y);
                _state.PaintMouseDown = false;
                if (_state.SelectedTool == StateService.TOOL_BHAND_POINTS)
                {
                    _paintService.PaintRightUnclick(x, y);
                }
            }

            SyncSelectedShapeLabel();
        }

        public void OnMouseWheel(int delta)
        {
            if (delta > 0)
            {
                _templateService.Scale = Math.Max(_templateService.Scale - 0.1f, 0.0f);
            }
            else if (delta < 0)
            {
                _templateService.Scale = Math.Min(_templateService.Scale + 0.1f, 5.0f);
            }

            _templateService.LoadTemplate();
        }

        public void SyncSelectedShapeLabel()
        {
            var shape = _state.SelectedShape;
            SelectedShapeLabel = shape != null ? "Shape:" + shape.Id : "Shape:";
        }
    }
}
