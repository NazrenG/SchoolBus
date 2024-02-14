using SchoolBus_WPF.ViewModels.PageViewModels;
using System.Windows.Controls;

namespace SchoolBus_WPF.Views.Pages
{
    /// <summary>
    /// Interaction logic for BusPage.xaml
    /// </summary>
    public partial class BusPage : Page
    {
        public BusPage()
        {
            InitializeComponent();
            DataContext = new BusPageViewModel();
        }
    }
}
