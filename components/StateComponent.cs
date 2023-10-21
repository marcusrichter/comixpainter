using mystical.Data;
using mystical.Grafix.Data;
using mystical.Grafix.ShaderShapes;
using System.Drawing;

namespace comixpaint.components
{
    public class StateComponent : AbstractComponent
    {
        private static StateComponent instance = null;

        private ShaderShapePalette palette = null;

        public const int TOOL_OVAL = 1;
        public const int TOOL_RECT = 2;
        public const int TOOL_FHAND = 3;
        public const int TOOL_MOVE = 4;
        public const int TOOL_DELETE = 7;
        public const int TOOL_MOVEINFRONT = 8;
        public const int TOOL_MOVEINBACK = 9;
        public const int TOOL_PENCIL = 10;
        public const int TOOL_PIPETTE = 11;
        public const int TOOL_COPY = 12;
        public const int TOOL_BHAND = 13;
        public const int TOOL_BHAND_POINTS = 14;
        public const int TOOL_RECOLOR = 15;
        public const int TOOL_SELECTSHAPE = 18;
        public const int TOOL_PICKCOLOR = 19;

        public const int COMBINATE_NONE = 0;
        public const int COMBINATE_ADD = 1;
        public const int COMBINATE_SUB = 2;

        public static StateComponent I()
        {
            if (instance == null)
            {
                instance = new StateComponent();
            }

            return instance;
        }

        public int CurrentLineWidth { get; set; } = 2;
        public Color CurrentBordercolor { get; set; } = Color.Black;
        public Color CurrentPaintcolor { get; set; } = Color.Blue;
        public int CurrentShadeDirection { get; set; } = ShaderShape.SHADEDIR_CENTER;

        public bool PaintMouseDown { get; set; }
        public bool PaintRightMouseDown { get; set; }
        public ShaderShapeImage CurrentImage { get; set; }
        public int SelectedTool { get; set; } = -1;
        public int CurrentShadesteps { get; set; } = 2;
        public ShaderShape SelectedShape { get; set; }
        public int Zoomlevel { get; set; } = 1;
        public ShaderShapePalette Palette { get; set; }
        public int? SelectedFavpc { get; set; }
        public int? SelectedFavbc { get; set; }
        public IntRect RectMarker { get; set; }
        public int CombinateMethod { get; set; }
        public ShaderShape SkizShape { get; set; }
        public bool TransparentTemplate { get; set; }

        public StateComponent()
        {
            //init palette
            palette = new ShaderShapePalette();
            var c = ColorFX.ParseColor("#404040");

            for (var i = 0; i < 8; i++)
            {
                palette.PaintColors.Add(c);
            }

            for (var i = 0; i < 4; i++)
            {
                palette.BorderColors.Add(c);
            }
        }
    }
}
