using comixpaint.ViewModels;
using System.Windows;

namespace comixpaint.modals
{
    public partial class NewImgDialog : Window
    {
        public NewImgDialog(NewImgViewModel viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
            viewModel.RequestClose += _ => Close();
        }
    }
}
