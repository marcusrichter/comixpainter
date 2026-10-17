using comixpaint.ViewModels;
using System.Windows;

namespace comixpaint.modals
{
    public partial class ChangeSizeDialog : Window
    {
        public ChangeSizeDialog(ChangeSizeViewModel viewModel)
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
