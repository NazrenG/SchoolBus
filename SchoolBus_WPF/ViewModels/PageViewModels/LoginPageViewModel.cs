using SchoolBus_WPF.Command;
using SchoolBus_WPF.Services;
using SchoolBus_WPF.Views.Pages;
using System.Windows.Controls;
using System.Windows.Input;

namespace SchoolBus_WPF.ViewModels.PageViewModels
{
    public class LoginPageViewModel : NotificationServices
    {
        public ICommand StartPage { get; set; }


        public LoginPageViewModel()
        {
            StartPage = new RelayCommand(SwitchStartPage, CanSwitchStartPage);
        }

        private bool CanSwitchStartPage(object? obj) => true;

        private void SwitchStartPage(object? obj)
        {
            var page = obj as Page;

            if (page != null)
            {
                var startpage = new StartPage();
                startpage.DataContext = new StartPageViewModel();
                page.NavigationService.Navigate(startpage);


            }
        }
    }
}
