using SchoolBus_Access.Repository.Abstract;
using SchoolBus_Access.Repository.Concretes;
using SchoolBus_Model.Entities.Concretes;
using SchoolBus_WPF.Command;
using SchoolBus_WPF.Services;
using SchoolBus_WPF.Views.Pages;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SchoolBus_WPF.ViewModels.PageViewModels
{
    public class CreateBusPageViewModel:NotificationServices
    {
        public BaseRepos<Bus>? busRepos;

        private Bus bus;


        public ICommand CreateClass { get; set; }
        public ICommand ClosePage { get; set; }



        public Bus Bus
        {
            get => bus;
            set { bus = value; OnPropertyChanged(); }
        }

        public CreateBusPageViewModel()
        {
            CreateClass = new RelayCommand(CreateDrive, CanCreateDrive);
            ClosePage = new RelayCommand(ReturnBackPage, CanReturnBackPage);

            busRepos = new BaseRepos<Bus>();
            Bus = new Bus();
        }

        private bool CanReturnBackPage(object? obj) => true;

        private void ReturnBackPage(object? obj)
        {
            if (obj is Page page)
            {
                page.NavigationService.GoBack();
            }
        }

        private bool CanCreateDrive(object? obj)
        {
            return !string.IsNullOrEmpty(Bus.Name);
        }

        private void CreateDrive(object? obj)
        {

            busRepos!.Add(Bus);
            MessageBox.Show("Bus was added!");

            busRepos.Save();

            if (obj is Page page)
            {
                page.NavigationService.Navigate(new BusPage());
            }
        }

    }
}
