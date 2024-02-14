using SchoolBus_Access.Repository.Concretes;
using SchoolBus_Model.Entities.Concretes;
using SchoolBus_WPF.Command;
using SchoolBus_WPF.DTOS;
using SchoolBus_WPF.Services;
using SchoolBus_WPF.Views.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SchoolBus_WPF.ViewModels.PageViewModels
{
    public class ClassPageViewModel : NotificationServices
    {
        //button for switch pages
        public ICommand Bus { get; set; }
        public ICommand Routes { get; set; }
        public ICommand Parent { get; set; }
        public ICommand Drivers { get; set; }
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


        private ObservableCollection<Class> classList;
        private Class selectedItem;

        public ClassRepos classRepos;
        public ObservableCollection<Class> ClassList { get => classList; set { classList = value; OnPropertyChanged(); } }
        public List<Class> classes;
        public Class SelectedItem { get => selectedItem; set { selectedItem = value; OnPropertyChanged(); } }


        public ClassPageViewModel()
        {
            classRepos = new ClassRepos();
           
            
            ClassList = new ObservableCollection<Class>(classRepos.GetAll());

            //pages
            Bus = new RelayCommand(SwitchBusPage, CanSwitchPage);
            Routes = new RelayCommand(SwitchRoutesPage, CanSwitchPage);
            Parent = new RelayCommand(SwitchParentPage, CanSwitchPage);
            Drivers = new RelayCommand(SwitchDriversPage, CanSwitchPage);
            CreateRide = new RelayCommand(SwitchCreateRidePage, CanSwitchPage);
            Student = new RelayCommand(SwitchStudentPage, CanSwitchPage);
            LogOut = new RelayCommand(SwitchLogOutPage, CanSwitchPage);
            //other button
            Update = new RelayCommand(UpdateData, CanUpdateData);
            Remove = new RelayCommand(RemoveData, CanRemoveData);
            Refresh = new RelayCommand(RefreshData, CanRefreshData);
            Create = new RelayCommand(CreateData, CanCreateData);

        }
      

        //Create
        private bool CanCreateData(object? obj) => true;

        private void CreateData(object? obj)
        {
            var page = obj as Page;
            if (page != null)
            {
                var create = new CreateClassPage();
                create.DataContext = new CreateClassPageViewModel();
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
                page.NavigationService.Navigate(new ClassPage());
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
                classRepos.Remove(SelectedItem);
                classRepos.Save();
                MessageBox.Show("Data was removed!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //update
        private bool CanUpdateData(object? obj) => true;

        private void UpdateData(object? obj)
        {
            try
            {
                classRepos.Save();
                MessageBox.Show("Update saved!");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        //logout
        private void SwitchLogOutPage(object? obj)
        {
            if (obj is Page page)
            {
                page.NavigationService.Navigate(new LoginPage());
            }
        }

        //Switch Bus
        private void SwitchBusPage(object? obj)
        {
            var page = obj as Page;
            if (page != null)
            {
                var bus = new BusPage();
                bus.DataContext = new BusPageViewModel();
                page.NavigationService.Navigate(bus);
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

        //Switch Drivers
        private void SwitchDriversPage(object? obj)
        {
            var page = obj as Page;
            if (page != null)
            {
                var Drivers = new DriversPage();
                Drivers.DataContext = new DriverPageViewModel();
                page.NavigationService.Navigate(Drivers);
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
