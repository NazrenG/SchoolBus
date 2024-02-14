using SchoolBus_Access.Repository.Concretes;
using SchoolBus_Model.Entities.Concretes;
using SchoolBus_WPF.Command;
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
    public class CreateRidePageViewModel : NotificationServices
    {
        //button for switch pages
        public ICommand Bus { get; set; }
        public ICommand Class { get; set; }
        public ICommand Parent { get; set; }
        public ICommand Drivers { get; set; }
        public ICommand Routes { get; set; }
        public ICommand Student { get; set; }
        public ICommand LogOut { get; set; }
        //create button
        public ICommand CreateRidePage { get; set; }
        //update button
        public ICommand Update { get; set; }
        //remove button
        public ICommand Remove { get; set; }

        public List<string> BusNameList { get => busNameList; set { busNameList = value; OnPropertyChanged(); } }
        public List<string> BusNumberList { get => busNumberList; set { busNumberList = value; OnPropertyChanged(); } }
        public string BusName { get => busName; set { busName = value; OnPropertyChanged(); } }
        public string BusNumber { get => busNumber; set { busNumber = value; OnPropertyChanged(); } }
        public Route Route { get => route; set { route = value; OnPropertyChanged(); } }

        public ObservableCollection<Student> StudentList { get => studentList; set { studentList = value; OnPropertyChanged(); } }
        private Student selectedItem;


        private List<string> busNameList;
        private List<string> busNumberList;
        private string busName;
        private string busNumber;
        private Route route;
        private ObservableCollection<Student> studentList;
        private string routeName;
        private List<string> routeNameList;


        public Student SelectedItem { get => selectedItem; set { selectedItem = value; OnPropertyChanged(); } }

        public string RouteName { get => routeName; set { routeName = value; OnPropertyChanged(); } }
        public List<string> RouteNameList { get => routeNameList; set{ routeNameList = value; OnPropertyChanged(); } }
         
        public BaseRepos<Route> baseRepos;
        public BusRepos busRepos;
        public StudentRepos studentRepos;
        public RouteRepos routeRepos;

        public CreateRidePageViewModel()
        {
            //pages
               Bus = new RelayCommand(SwitchBusPage, CanSwitchPage);
             Class = new RelayCommand(SwitchClassPage,CanSwitchPage);
            Parent = new RelayCommand(SwitchParentPage, CanSwitchPage);
           Drivers = new RelayCommand(SwitchDriversPage, CanSwitchPage);
            Routes = new RelayCommand(SwitchRoutesPage, CanSwitchPage);
           Student = new RelayCommand(SwitchStudentPage, CanSwitchPage);
            LogOut = new RelayCommand(SwitchLogOutPage, CanSwitchPage);
            //create button
            CreateRidePage = new RelayCommand(CreatePage, CanCreatePage);
            Update = new RelayCommand(UpdateData, CanUpdateData);
            Remove = new RelayCommand(RemoveData, CanRemoveData);


            baseRepos = new BaseRepos<Route>();
            busRepos = new BusRepos();
            routeRepos=new RouteRepos();
            Route= new Route(); 
            studentRepos = new StudentRepos();
            StudentList= new ObservableCollection<Student>(studentRepos.GetAll());   

            busNameList = busRepos.GetAllBusName();
            busNumberList = busRepos.GetAllBusNumber();
            routeNameList = routeRepos.GetAllRouteName();
            
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
            var od = SelectedItem.Id;
            try
            {
                studentRepos.Remove(SelectedItem);
                studentRepos.Save();
                if (obj is Page page)
                {
                    page.NavigationService.Navigate(new CreateRide());
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //update
        private bool CanUpdateData(object? obj)
        {
            if (SelectedItem != null)
                return true;
            return false;
        }

        private void UpdateData(object? obj)
        {

            var page = obj as Page;
            if (page != null)
            {
                var bus = new UpdateRoutePge();
                bus.DataContext = new UpdateRoutePageViewModel(SelectedItem);
                page.NavigationService.Navigate(bus);
            }
        }


        //create button
        private bool CanCreatePage(object? obj)
        {
            return true;
        }

        private void CreatePage(object? obj)
        {
            Route.BusId = busRepos.FindIdForNameAndNumber(BusName,BusNumber);
            
            if(Route.BusId == 0)
            {
                MessageBox.Show("This car was not found!","Warning",MessageBoxButton.OK,MessageBoxImage.Warning);
                if(obj is Page page)
                {
                    page.NavigationService.Navigate(new CreateRide());
                }
            }
            else
            {
                baseRepos.Add(Route);
                baseRepos.Save();
                MessageBox.Show("Route was added!");
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
        //Switch Class
        private void SwitchClassPage(object? obj)
        {
            var page = obj as Page;
            if (page != null)
            {
                var Class = new ClassPage();
                Class.DataContext = new ClassPageViewModel();
                page.NavigationService.Navigate(Class);
            }
        }

        //Switch Routes
        private void SwitchRoutesPage(object? obj)
        {
            var page = obj as Page;
            if (page != null)
            {
                var Routes = new RoutesPage();
                Routes.DataContext = new RoutesPageViewModel();
                page.NavigationService.Navigate(Routes);
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

