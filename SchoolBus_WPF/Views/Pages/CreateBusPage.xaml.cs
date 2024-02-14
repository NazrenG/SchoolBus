using SchoolBus_WPF.ViewModels.PageViewModels;
using System.Windows.Controls;

namespace SchoolBus_WPF.Views.Pages
{
    /// <summary>
    /// Interaction logic for CreateBusPage.xaml
    /// </summary>
    public partial class CreateBusPage : Page
    {
        public CreateBusPage()
        {
            InitializeComponent();
            DataContext =new CreateBusPageViewModel();
        }
    }
}
