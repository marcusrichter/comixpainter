using comixpaint.ViewModels;
using System.Windows;

namespace comixpaint.modals
{
    public partial class PalettColorRenameForm : Window
    {
        public PalettColorRenameForm(PalettColorRenameViewModel viewModel)
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
