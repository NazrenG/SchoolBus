using SchoolBus_WPF.ViewModels.PageViewModels;
using System.Windows.Controls;

namespace SchoolBus_WPF.Views.Pages
{
    /// <summary>
    /// Interaction logic for CreateClassPage.xaml
    /// </summary>
    public partial class CreateClassPage : Page
    {
        public CreateClassPage()
        {
            InitializeComponent();
            DataContext = new CreateClassPageViewModel();
        }
    }
}
