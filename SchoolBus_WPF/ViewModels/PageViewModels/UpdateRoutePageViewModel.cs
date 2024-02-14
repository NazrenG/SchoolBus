using SchoolBus_Access.Repository.Concretes;
using SchoolBus_Model.Entities.Concretes;
using SchoolBus_WPF.Command;
using SchoolBus_WPF.Services;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace SchoolBus_WPF.ViewModels.PageViewModels
{
    public class UpdateRoutePageViewModel : NotificationServices
    {

        public ICommand CreateClass { get; set; }
        public ICommand ClosePage { get; set; }
        private string routeName;
        private List<string> routeNameList;

        public RouteRepos routeRepos;
        public StudentRepos studentRepos;
        public string RouteName { get => routeName; set { routeName = value; OnPropertyChanged(); } }
        public List<string> RouteNameList { get => routeNameList; set { routeNameList = value; OnPropertyChanged(); } }
        public Student Student;
        public int id;

        public UpdateRoutePageViewModel(Student student)
        {
            CreateClass = new RelayCommand(CreateDrive, CanCreateDrive);
            ClosePage = new RelayCommand(ReturnBackPage, CanReturnBackPage);
            routeRepos = new RouteRepos();
            studentRepos = new StudentRepos();
            RouteNameList = new List<string>(routeRepos.GetAllRouteName());
            Student = new Student();
            Student = student;
            id=Student.Id;
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
            return true;
        }

        private void CreateDrive(object? obj)
        {
            var routeId = routeRepos.GetRouteId(RouteName);
            var busId = routeRepos.GetBusId(routeId);
          
            Student.BusId = busId; 
            studentRepos.Save();

            MessageBox.Show("Updated successfully!");
            if (obj is Page page)
            {
                page.NavigationService.GoBack();
            }

        }


    }
}
