using comixpaint.components;

namespace comixpaint.controllers
{
    public class ToolsController
    {
        private static ToolsController instance = null;

        public static ToolsController I()
        {
            if (instance == null)
            {
                instance = new ToolsController();
            }

            return instance;
        }

        public ToolsController()
        {
        }

        public void DrawOvalClick()
        {
            if (StateComponent.I().SelectedTool != StateComponent.TOOL_OVAL)
            {
                PaintComponent.I().FinishShape();
                /*StateComponent.I().CurrentImage.create_shape(ShaderShape.SHAPETYPE_OVAL,StateComponent.I().Current_line_width,
					                                              StateComponent.I().CurrentShadeDirection,StateComponent.I().Current_shadesteps,
					                                              StateComponent.I().Current_paintcolor,StateComponent.I().Current_bordercolor);*/

                StateComponent.I().SelectedTool = StateComponent.TOOL_OVAL;
            }
        }

        public void DrawRectClick()
        {
            if (StateComponent.I().SelectedTool != StateComponent.TOOL_RECT)
            {
                PaintComponent.I().FinishShape();
                /*StateComponent.I().CurrentImage.create_shape(ShaderShape.SHAPETYPE_RECT,StateComponent.I().Current_line_width,
					                                              StateComponent.I().CurrentShadeDirection,StateComponent.I().Current_shadesteps,
					                                              StateComponent.I().Current_paintcolor,StateComponent.I().Current_bordercolor);*/
                StateComponent.I().SelectedTool = StateComponent.TOOL_RECT;
            }

        }

        public void DrawFreeClick()
        {
            if (StateComponent.I().SelectedTool != StateComponent.TOOL_FHAND)
            {
                PaintComponent.I().FinishShape();
                StateComponent.I().SelectedTool = StateComponent.TOOL_FHAND;
            }

        }

        public void DrawLinesClick()
        {
            if (StateComponent.I().SelectedTool != StateComponent.TOOL_BHAND)
            {
                PaintComponent.I().FinishShape();
                /*StateComponent.I().CurrentImage.create_shape(ShaderShape.SHAPETYPE_FREEPIX,StateComponent.I().Current_line_width,
					                                              StateComponent.I().CurrentShadeDirection,StateComponent.I().Current_shadesteps,
					                                              StateComponent.I().Current_paintcolor,StateComponent.I().Current_bordercolor);*/
                StateComponent.I().SelectedTool = StateComponent.TOOL_BHAND;
            }
        }


        public void DrawFreeLinesClick()
        {
            if (StateComponent.I().SelectedTool != StateComponent.TOOL_BHAND_POINTS)
            {
                PaintComponent.I().FinishShape();
                /*StateComponent.I().CurrentImage.create_shape(ShaderShape.SHAPETYPE_FREEPIX,StateComponent.I().Current_line_width,
					                                              StateComponent.I().CurrentShadeDirection,StateComponent.I().Current_shadesteps,
					                                              StateComponent.I().Current_paintcolor,StateComponent.I().Current_bordercolor);*/
                StateComponent.I().SelectedTool = StateComponent.TOOL_BHAND_POINTS;
            }
        }

        public void MoveClick()
        {
            StateComponent.I().SelectedTool = StateComponent.TOOL_MOVE;
            PaintComponent.I().FinishShape();
        }

        public void DeleteClick()
        {
            StateComponent.I().SelectedTool = StateComponent.TOOL_DELETE;
            PaintComponent.I().FinishShape();
        }

        public void MoveInFrontClick()
        {
            StateComponent.I().SelectedTool = StateComponent.TOOL_MOVEINFRONT;
            PaintComponent.I().FinishShape();
        }

        public void MoveInBackClick()
        {
            StateComponent.I().SelectedTool = StateComponent.TOOL_MOVEINBACK;
            PaintComponent.I().FinishShape();
        }

        public void CopyClick()
        {
            StateComponent.I().SelectedTool = StateComponent.TOOL_COPY;
            PaintComponent.I().FinishShape();
        }

        public void RecolorClick()
        {
            StateComponent.I().SelectedTool = StateComponent.TOOL_RECOLOR;
            PaintComponent.I().FinishShape();
        }

        public void SelectShape()
        {
            StateComponent.I().SelectedTool = StateComponent.TOOL_SELECTSHAPE;
            PaintComponent.I().FinishShape();
        }

        public void PickColor()
        {
            StateComponent.I().SelectedTool = StateComponent.TOOL_PICKCOLOR;
            PaintComponent.I().FinishShape();
        }
    }
}
