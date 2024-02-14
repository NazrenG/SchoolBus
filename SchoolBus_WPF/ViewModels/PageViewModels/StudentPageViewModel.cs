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
    public class StudentPageViewModel : NotificationServices
    {


        //button for switch pages
        public ICommand Class { get; set; }
        public ICommand Routes { get; set; }
        public ICommand Parent { get; set; }
        public ICommand Drivers { get; set; }
        public ICommand CreateRide { get; set; }
        public ICommand Bus { get; set; }
        public ICommand LogOut { get; set; }

        //update button
        public ICommand Update { get; set; }
        //remove button
        public ICommand Remove { get; set; }
        //refresh button
        public ICommand Refresh { get; set; }
        //create button
        public ICommand Create { get; set; }


        private ObservableCollection<Student> studentList;
        private Student selectedItem;

        public StudentRepos studentRepos;
        public ParentRepos parentRepos;
        public ClassRepos classRepos;
        public ObservableCollection<Student> StudentList { get => studentList; set { studentList = value; OnPropertyChanged(); } } 
        public Student SelectedItem { get => selectedItem; set { selectedItem = value; OnPropertyChanged(); } }


        public StudentPageViewModel()
        {
            studentRepos = new StudentRepos();
            parentRepos = new ParentRepos();
            classRepos = new ClassRepos();
             

             
            StudentList = new ObservableCollection<Student>(studentRepos.GetAll());

            //pages
            Class = new RelayCommand(SwitchClassPage, CanSwitchPage);
            Routes = new RelayCommand(SwitchRoutesPage, CanSwitchPage);
            Parent = new RelayCommand(SwitchParentPage, CanSwitchPage);
            Drivers = new RelayCommand(SwitchDriversPage, CanSwitchPage);
            CreateRide = new RelayCommand(SwitchCreateRidePage, CanSwitchPage);
            Bus = new RelayCommand(SwitchBusPage, CanSwitchPage);
            LogOut = new RelayCommand(SwitchLogOutPage, CanSwitchPage);

            //other button
            Update = new RelayCommand(UpdateData, CanUpdateData);
            Remove = new RelayCommand(RemoveData, CanRemoveData);
            Refresh = new RelayCommand(RefreshData, CanRefreshData);
            Create = new RelayCommand(CreateData, CanCreateData);

        }
        //Create
        private bool CanCreateData(object? obj) => true;

        private void CreateData(object obj)
        {
            if (obj is Page page)
            {
                var create = new CreateStudentPage();
                create.DataContext = new CreateStudentPageViewModel();
                page.NavigationService?.Navigate(create);
            }

        }

        //Refresh
        private bool CanRefreshData(object? obj) => true;

        private void RefreshData(object? obj)
        {
            if (obj is Page page)
            {
                page.NavigationService.Navigate(new StudentsPage());
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
                studentRepos.Remove(SelectedItem);
                studentRepos.Save();
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
                studentRepos.Save();
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

        private bool CanSwitchPage(object? obj) => true;
    }
}

