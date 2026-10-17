using comixpaint.ViewModels;
using System.Windows;

namespace comixpaint.modals
{
    public partial class AddToPaletteForm : Window
    {
        public AddToPaletteForm(AddToPaletteViewModel viewModel)
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
