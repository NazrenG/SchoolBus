using SchoolBus_WPF.Command;
using SchoolBus_Access.Context;
using SchoolBus_WPF.Services;
using SchoolBus_WPF.Views.Pages;
using System.Windows.Controls;
using System.Windows.Input;
using SchoolBus_Model.Entities.Concretes;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace SchoolBus_WPF.ViewModels.PageViewModels
{
    public class StartPageViewModel : NotificationServices
    {
        public ICommand CreateRidePage { get; set; }

        private Admin admin;
        private Admin _selectedItem;

        public Admin Admin { get => admin; set { admin = value; OnPropertyChanged(); } }
        public ObservableCollection<Admin> AdminList { get; set; }

        public Admin SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }


        public StartPageViewModel()
        {
            using (var context = new SchoolBus_Context())
            {
                AdminList = new ObservableCollection<Admin>(context.Admins.ToList());
            }
            admin = new Admin();
            CreateRidePage = new RelayCommand(SwitchPage, CanSwitchPage);
        }

        private bool CanSwitchPage(object? obj) => true;

        private void SwitchPage(object? obj)
        {
            bool check = true;
            var page = obj as Page;

            foreach (var item in AdminList)
            {
                if (item.Username == admin.Username && item.Password == admin.Password)
                {
                    check = false;
                    if (page != null)
                    {
                        var createRide = new CreateRide();
                        createRide.DataContext = new CreateRidePageViewModel();
                        page.NavigationService.Navigate(createRide);
                    }
                    break;

                }
            }
            if (check)
            {
                MessageBox.Show("Username or Password is wrong!");
            }
        }
    }
}
