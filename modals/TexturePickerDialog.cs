using comixpaint.ViewModels;
using System.Windows;

namespace comixpaint.modals
{
    public partial class TexturePickerDialog : Window
    {
        public TexturePickerDialog(TexturePickerViewModel viewModel)
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
