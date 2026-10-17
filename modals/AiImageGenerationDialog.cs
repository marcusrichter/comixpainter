using comixpaint.ViewModels;
using System.Windows;

namespace comixpaint.modals
{
    public partial class AiImageGenerationDialog : Window
    {
        public AiImageGenerationDialog(AiImageGenerationViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
            viewModel.RequestClose += result =>
            {
                DialogResult = result;
                Close();
            };
        }
    }
}
