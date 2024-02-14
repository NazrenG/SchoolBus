using SchoolBus_WPF.ViewModels.PageViewModels;
using System.Windows.Controls;

namespace SchoolBus_WPF.Views.Pages
{

    public partial class StartPage : Page
    {
        public StartPage()
        {

            InitializeComponent();
            DataContext = new StartPageViewModel();

        }
    }
}
