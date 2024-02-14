using SchoolBus_WPF.ViewModels.PageViewModels;
using System.Windows.Controls;

namespace SchoolBus_WPF.Views.Pages
{
    /// <summary>
    /// Interaction logic for CreateParentPage.xaml
    /// </summary>
    public partial class CreateParentPage : Page
    {
        public CreateParentPage()
        {
            InitializeComponent();
            DataContext=new CreateParentPageViewModel();
        }
    }
}
