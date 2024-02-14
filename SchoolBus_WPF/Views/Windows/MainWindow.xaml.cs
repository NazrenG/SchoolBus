using SchoolBus_WPF.ViewModels.WindowViewModels;
using System.Windows.Navigation;

namespace SchoolBus_WPF.Views.Windows
{

    public partial class MainWindow : NavigationWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
        }
    }
}
