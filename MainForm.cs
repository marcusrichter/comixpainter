using comixpaint.modals;
using comixpaint.Services.Ai;
using comixpaint.Services.Drawing;
using comixpaint.Services.State;
using comixpaint.ViewModels;
using Microsoft.Win32;
using mystical.Grafix.ShaderShapes;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using DrawingColor = System.Drawing.Color;
using WpfImage = System.Windows.Controls.Image;

namespace comixpaint
{
    /// <summary>
    /// Code-Behind für MainForm.xaml. Die ViewModels übernehmen die Controller-Aufrufe.
    /// </summary>
    public partial class MainForm : Window
    {
        public static MainForm mainForm = null;

        private static readonly ComponentResourceManager IconResources = new(typeof(MainForm));

        private readonly MainViewModel _viewModel;
        private readonly AiDrawingService _aiService;
        private readonly StateService _state;
        private readonly PaintSurfaceService _paintSurface;

        public SaveFileDialog SaveFileDialog { get; private set; }
        public OpenFileDialog OpenFileDialog { get; private set; }

        private Bitmap currentPaintBitmap;

        public MainForm(MainViewModel viewModel, AiDrawingService aiService, StateService state, PaintSurfaceService paintSurface)
        {
            InitializeComponent();

            MainForm.mainForm = this;
            SaveFileDialog = new SaveFileDialog();
            OpenFileDialog = new OpenFileDialog();

            _viewModel = viewModel;
            _aiService = aiService;
            _state = state;
            _paintSurface = paintSurface;

            DataContext = _viewModel;

            LoadButtonIcons();
            SubscribeToStateChanges();

            _viewModel.System.Init();
        }

        public ComboBox ComboBoxLineWidth => comboBoxLineWidth;
        public ComboBox ComboBoxColorSteps => comboBoxColorSteps;
        public ColorButton ButtonDrawingColor => buttonDrawingColor;
        public ColorButton ButtonBorderColor => buttonBorderColor;
        public ColorButton ButtonCombinateNone => buttonCombinateNone;
        public ColorButton ButtonCombinatePlus => buttonCombinatePlus;
        public ColorButton ButtonCombinateMinus => buttonCombinateMinus;
        public TextBlock LabelSelectedShape => labelSelectedShape;
        public CheckBox CheckBoxAutocatSave => checkBoxAutocatSave;

        public void SetPaintImage(Bitmap bitmap)
        {
            currentPaintBitmap = bitmap;
            if (bitmap == null)
            {
                PaintImage.Source = null;
                return;
            }

            PaintImage.Source = bitmap.ToBitmapSource();
            PaintImage.Width = bitmap.Width;
            PaintImage.Height = bitmap.Height;
        }

        public void InvalidatePaint()
        {
            if (currentPaintBitmap != null)
            {
                PaintImage.Source = currentPaintBitmap.ToBitmapSource();
            }
        }

        public void highlightButtonShading(int dir)
        {
            var color = DrawingColor.Black;
            buttonShadingLeft.ForeColor = color;
            buttonShadingLeftDown.ForeColor = color;
            buttonShadingLeftUp.ForeColor = color;
            buttonShadingRight.ForeColor = color;
            buttonShadingRightDown.ForeColor = color;
            buttonShadingRightUp.ForeColor = color;
            buttonShadingDown.ForeColor = color;
            buttonShadingUp.ForeColor = color;
            buttonShadeCenter.ForeColor = color;

            var selColor = DrawingColor.White;
            if (dir == ShaderShape.SHADEDIR_BOTTOM)
                buttonShadingDown.ForeColor = selColor;
            else if (dir == ShaderShape.SHADEDIR_BOTTOMLEFT)
                buttonShadingLeftDown.ForeColor = selColor;
            else if (dir == ShaderShape.SHADEDIR_BOTTOMRIGHT)
                buttonShadingRightDown.ForeColor = selColor;
            else if (dir == ShaderShape.SHADEDIR_LEFT)
                buttonShadingLeft.ForeColor = selColor;
            else if (dir == ShaderShape.SHADEDIR_RIGHT)
                buttonShadingRight.ForeColor = selColor;
            else if (dir == ShaderShape.SHADEDIR_TOP)
                buttonShadingUp.ForeColor = selColor;
            else if (dir == ShaderShape.SHADEDIR_TOPLEFT)
                buttonShadingLeftUp.ForeColor = selColor;
            else if (dir == ShaderShape.SHADEDIR_TOPRIGHT)
                buttonShadingRightUp.ForeColor = selColor;
            else if (dir == ShaderShape.SHADEDIR_CENTER)
                buttonShadeCenter.ForeColor = selColor;
        }

        public void highlightButtonTool(int selTool)
        {
            var color = DrawingColor.DarkGray;

            buttonDrawFree.BackColor = color;
            buttonDrawOval.BackColor = color;
            buttonDrawRect.BackColor = color;
            buttonMoveInBack.BackColor = color;
            buttonMoveInFront.BackColor = color;
            buttonDelete.BackColor = color;
            buttonMove.BackColor = color;
            buttonCopy.BackColor = color;
            buttonDrawLines.BackColor = color;
            buttonDrawFreeLines.BackColor = color;
            buttonRecolor.BackColor = color;

            var selColor = DrawingColor.Blue;

            if (selTool == StateService.TOOL_FHAND)
                buttonDrawFree.BackColor = selColor;
            if (selTool == StateService.TOOL_OVAL)
                buttonDrawOval.BackColor = selColor;
            if (selTool == StateService.TOOL_RECT)
                buttonDrawRect.BackColor = selColor;
            if (selTool == StateService.TOOL_MOVEINBACK)
                buttonMoveInBack.BackColor = selColor;
            if (selTool == StateService.TOOL_MOVEINFRONT)
                buttonMoveInFront.BackColor = selColor;
            if (selTool == StateService.TOOL_DELETE)
                buttonDelete.BackColor = selColor;
            if (selTool == StateService.TOOL_MOVE)
                buttonMove.BackColor = selColor;
            if (selTool == StateService.TOOL_COPY)
                buttonCopy.BackColor = selColor;
            if (selTool == StateService.TOOL_BHAND)
                buttonDrawLines.BackColor = selColor;
            if (selTool == StateService.TOOL_BHAND_POINTS)
                buttonDrawFreeLines.BackColor = selColor;
            if (selTool == StateService.TOOL_RECOLOR)
                buttonRecolor.BackColor = selColor;
        }

        private void LoadButtonIcons()
        {
            SetIcon(buttonDrawOval, "buttonDrawOval.Image");
            SetIcon(buttonDrawRect, "buttonDrawRect.Image");
            SetIcon(buttonDrawFree, "buttonDrawFree.Image");
            SetIcon(buttonDrawLines, "buttonDrawLines.Image");
            SetIcon(buttonDrawFreeLines, "buttonDrawFreeLines.Image");
            SetIcon(buttonMove, "buttonMove.Image");
            SetIcon(buttonDelete, "buttonDelete.Image");
            SetIcon(buttonMoveInFront, "buttonMoveInFront.Image");
            SetIcon(buttonMoveInBack, "buttonMoveInBack.Image");
            SetIcon(buttonCopy, "buttonCopy.Image");

            SetIcon(buttonShadingLeftUp, "buttonShadingLeftUp.Image");
            SetIcon(buttonShadingUp, "buttonShadingUp.Image");
            SetIcon(buttonShadingRightUp, "buttonShadingRightUp.Image");
            SetIcon(buttonShadingLeft, "buttonShadingLeft.Image");
            SetIcon(buttonShadeCenter, "buttonShadeCenter.Image");
            SetIcon(buttonShadingRight, "buttonShadingRight.Image");
            SetIcon(buttonShadingLeftDown, "buttonShadingLeftDown.Image");
            SetIcon(buttonShadingDown, "buttonShadingDown.Image");
            SetIcon(buttonShadingRightDown, "buttonShadingRightDown.Image");

            SetIcon(buttonCombinateNone, Properties.Resources.combine_none);
            SetIcon(buttonCombinatePlus, Properties.Resources.combine_add);
            SetIcon(buttonCombinateMinus, Properties.Resources.combine_sub);

            buttonCombinateNone.ForeColor = DrawingColor.White;
            buttonCombinatePlus.ForeColor = DrawingColor.DarkGray;
            buttonCombinateMinus.ForeColor = DrawingColor.DarkGray;
        }

        private void SetIcon(ColorButton button, string resourceKey)
        {
            if (IconResources.GetObject(resourceKey) is Bitmap bmp)
            {
                SetIcon(button, bmp);
            }
        }

        private void SetIcon(ColorButton button, Bitmap bmp)
        {
            if (bmp == null)
            {
                return;
            }

            button.Content = new WpfImage { Source = bmp.ToBitmapSource(), Stretch = Stretch.None };
            button.Height = bmp.Height + 2;
        }

        private void SubscribeToStateChanges()
        {
            _viewModel.Tools.PropertyChanged += (_, e) =>
            {
                if (e.PropertyName == nameof(ToolsViewModel.SelectedTool))
                {
                    highlightButtonTool(_viewModel.Tools.SelectedTool);
                }
            };

            _viewModel.Settings.PropertyChanged += (_, e) =>
            {
                if (e.PropertyName == nameof(SettingsViewModel.ShadeDirection))
                {
                    highlightButtonShading(_viewModel.Settings.ShadeDirection);
                }
            };
        }

        private void PictureBoxPaintMouseDown(object sender, MouseButtonEventArgs e)
        {
            var pos = e.GetPosition(PaintImage);
            _viewModel.Paint.OnMouseDown((int)pos.X, (int)pos.Y, e.ChangedButton == MouseButton.Right);
        }

        private void PictureBoxPaintMouseMove(object sender, MouseEventArgs e)
        {
            var pos = e.GetPosition(PaintImage);
            _viewModel.Paint.OnMouseMove((int)pos.X, (int)pos.Y);
        }

        private void PictureBoxPaintMouseUp(object sender, MouseButtonEventArgs e)
        {
            var pos = e.GetPosition(PaintImage);
            _viewModel.Paint.OnMouseUp((int)pos.X, (int)pos.Y, e.ChangedButton == MouseButton.Right);
        }

        private void PictureBoxMouseWheel(object sender, MouseWheelEventArgs e)
        {
            _viewModel.Paint.OnMouseWheel(e.Delta);
        }

        private void PictureBoxPaint_MouseEnter(object sender, MouseEventArgs e)
        {
            PaintImage.Focus();
        }

        private void ButtonTextureClick(object sender, RoutedEventArgs e)
        {
            var shape = _state.SelectedShape;
            if (shape == null)
            {
                return;
            }

            var viewModel = new TexturePickerViewModel();
            var dlg = new TexturePickerDialog(viewModel) { Owner = this };
            if (dlg.ShowDialog() == true)
            {
                if (viewModel.Cleared)
                    shape.Texture = null;
                else if (viewModel.Result != null)
                    shape.Texture = viewModel.Result;

                shape.Clear();
                _paintSurface.Repaint();
            }
        }

        private void ButtonAiClick(object sender, RoutedEventArgs e)
        {
            var viewModel = new AiImageGenerationViewModel(_aiService, _state, _paintSurface);
            var dlg = new AiImageGenerationDialog(viewModel) { Owner = this };
            dlg.ShowDialog();
        }
    }
}
