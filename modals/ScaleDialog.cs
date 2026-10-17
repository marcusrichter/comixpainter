using comixpaint.ViewModels;
using System.Windows;

namespace comixpaint.modals
{
    public partial class ScaleDialog : Window
    {
        public ScaleDialog(ScaleViewModel viewModel)
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
