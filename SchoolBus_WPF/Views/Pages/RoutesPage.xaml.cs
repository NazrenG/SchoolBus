using SchoolBus_WPF.ViewModels.PageViewModels;
using System.Windows.Controls;

namespace SchoolBus_WPF.Views.Pages
{
    /// <summary>
    /// Interaction logic for RoutesPage.xaml
    /// </summary>
    public partial class RoutesPage : Page
    {
        public RoutesPage()
        {

            InitializeComponent();
            DataContext = new RoutesPageViewModel();
        }
    }
}
