using SchoolBus_Access.Context;
using SchoolBus_Access.Repository.Concretes;
using SchoolBus_Model.Entities.Concretes;
using SchoolBus_WPF.Command;
using SchoolBus_WPF.Services;
using SchoolBus_WPF.ViewModels.WindowViewModels;
using SchoolBus_WPF.Views.Pages;
using SchoolBus_WPF.Views.Windows;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SchoolBus_WPF.ViewModels.PageViewModels
{
    public class DriverPageViewModel : NotificationServices
    {
        //button for switch pages
        public ICommand Class { get; set; }
        public ICommand Routes { get; set; }
        public ICommand Parent { get; set; }
        public ICommand Bus { get; set; }
        public ICommand CreateRide { get; set; }
        public ICommand Student { get; set; }
        public ICommand LogOut { get; set; }

        //update button
        public ICommand Update { get; set; }
        //remove button
        public ICommand Remove { get; set; }
        //refresh button
        public ICommand Refresh { get; set; }
        //create button
        public ICommand Create { get; set; }

        public DriverRepos driverRepos;
        private ObservableCollection<Driver> _driverList;


        public ObservableCollection<Driver> DriverList
        {
            get { return _driverList; }
            set
            {
                _driverList = value;
                OnPropertyChanged();
            }
        }

        private Driver selectedItem;

        public Driver SelectedItem { get => selectedItem; set { selectedItem = value; OnPropertyChanged(); } }

        public DriverPageViewModel()
        {
            driverRepos = new DriverRepos();

            DriverList = new ObservableCollection<Driver>(driverRepos.GetAll());



            // button for pages
            Class = new RelayCommand(SwitchClassPage, CanSwitchPage);
            Routes = new RelayCommand(SwitchRoutesPage, CanSwitchPage);
            Parent = new RelayCommand(SwitchParentPage, CanSwitchPage);
            Bus = new RelayCommand(SwitchBusPage, CanSwitchPage);
            CreateRide = new RelayCommand(SwitchCreateRidePage, CanSwitchPage);
            Student = new RelayCommand(SwitchStudentPage, CanSwitchPage);
            LogOut = new RelayCommand(SwitchLogOutPage, CanSwitchPage);
            //other button
            Update = new RelayCommand(UpdateData, CanUpdateData);
            Remove = new RelayCommand(RemoveData, CanRemoveData);
            Refresh = new RelayCommand(RefreshData, CanRefreshData);
            Create = new RelayCommand(CreateData, CanCreateData);

        }
        //create
        private bool CanCreateData(object? obj)
        {
            return true;
        }

        private void CreateData(object? obj)
        {

            var page = obj as Page;
            if (page != null)
            {
                var create = new CreateDriverPage();
                create.DataContext = new CreateDriverPageViewModel();
                page.NavigationService.Navigate(create);
            }


        }

        //Refresh
        private bool CanRefreshData(object? obj)
        {
            return obj != null;
        }

        private void RefreshData(object? obj)
        {
            if (obj is Page page)
            {
                page.NavigationService.Navigate(new DriversPage());
            }
        }

        //remove
        private bool CanRemoveData(object? obj)
        {
            if (SelectedItem != null)
                return true;
            return false;
        }

        private void RemoveData(object? obj)
        {
            try
            {
                driverRepos.Remove(SelectedItem);
                driverRepos.Save();
                MessageBox.Show("Data was removed!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //update
        private bool CanUpdateData(object? obj)
        {
            return obj != null;
        }

        private void UpdateData(object? obj)
        {
            try
            {
                driverRepos.Save();
                MessageBox.Show("Update saved!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //---------  for switch page  ----------
        //logout
        private void SwitchLogOutPage(object? obj)
        {
            if (obj is Page page)
            {
                page.NavigationService.Navigate(new LoginPage());
            }
        }

        //Switch Class
        private void SwitchClassPage(object? obj)
        {
            var page = obj as Page;
            if (page != null)
            {
                var classPage = new ClassPage();
                classPage.DataContext = new ClassPageViewModel();
                page.NavigationService.Navigate(classPage);
            }
        }


        //Switch Parent
        private void SwitchParentPage(object? obj)
        {
            var page = obj as Page;
            if (page != null)
            {
                var Parent = new ParentPage();
                Parent.DataContext = new ParentPageViewModel();
                page.NavigationService.Navigate(Parent);
            }
        }
        //Switch Routes
        private void SwitchRoutesPage(object? obj)
        {
            var page = obj as Page;
            if (page != null)
            {
                var routes = new RoutesPage();
                routes.DataContext = new RoutesPageViewModel();
                page.NavigationService.Navigate(routes);
            }
        }

        //Switch CreateRide
        private void SwitchCreateRidePage(object? obj)
        {
            var page = obj as Page;
            if (page != null)
            {
                var CreateRide = new CreateRide();
                CreateRide.DataContext = new CreateRidePageViewModel();
                page.NavigationService.Navigate(CreateRide);
            }
        }

        //Switch Bus
        private void SwitchBusPage(object? obj)
        {
            var page = obj as Page;
            if (page != null)
            {
                var Bus = new BusPage();
                Bus.DataContext = new BusPageViewModel();
                page.NavigationService.Navigate(Bus);
            }
        }


        //Switch Student
        private void SwitchStudentPage(object? obj)
        {
            var page = obj as Page;
            if (page != null)
            {
                var student = new StudentsPage();
                student.DataContext = new StudentPageViewModel();
                page.NavigationService.Navigate(student);
            }
        }

        private bool CanSwitchPage(object? obj) => true;
    }
}

