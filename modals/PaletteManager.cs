using comixpaint.ViewModels;
using System.Windows;

namespace comixpaint.modals
{
    public partial class PaletteManager : Window
    {
        public PaletteManager(PaletteManagerViewModel viewModel)
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
