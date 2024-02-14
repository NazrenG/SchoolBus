using SchoolBus_WPF.ViewModels.PageViewModels;
using System.Windows.Controls;

namespace SchoolBus_WPF.Views.Pages
{
    /// <summary>
    /// Interaction logic for CreateStudentPage.xaml
    /// </summary>
    public partial class CreateStudentPage : Page
    {
        public CreateStudentPage()
        {
            InitializeComponent();
            DataContext= new CreateClassPageViewModel();
        }
    }
}
