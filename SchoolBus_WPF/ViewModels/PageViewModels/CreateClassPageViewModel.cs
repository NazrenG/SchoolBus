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
    public class CreateClassPageViewModel : NotificationServices
    {
        public BaseRepos<Class>? classRepos; 

        private Class class_;


        public ICommand CreateClass { get; set; }
        public ICommand ClosePage { get; set; }

      

        public Class Class
        {
            get => class_;
            set { class_ = value; OnPropertyChanged(); }
        }

    

        public CreateClassPageViewModel()
        {

            CreateClass = new RelayCommand(CreateDrive, CanCreateDrive);
            ClosePage = new RelayCommand(ReturnBackPage, CanReturnBackPage);

            classRepos = new BaseRepos<Class>();
            Class = new Class();
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
            return  !string.IsNullOrEmpty(Class.Name);
        }

        private void CreateDrive(object? obj)
        {

            classRepos!.Add(Class);
            MessageBox.Show("Class was added!");

            classRepos.Save();

            if (obj is Page page)
            {
                page.NavigationService.Navigate(new ClassPage());
            }
        }
    }

}
