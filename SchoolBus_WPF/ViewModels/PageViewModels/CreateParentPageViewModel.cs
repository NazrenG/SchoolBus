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
    public class CreateParentPageViewModel : NotificationServices
    {
        public ParentRepos?  parentRepos;

        private Parent parent;


        public ICommand AddParent { get; set; }
        public ICommand ClosePage { get; set; }
        public Parent Parent { get => parent; set { parent = value; OnPropertyChanged(); } }

        public CreateParentPageViewModel()
        {
            AddParent = new RelayCommand(AddNewParent, CanCreate);
            ClosePage = new RelayCommand(ReturnBackPage, CanReturnBackPage);
            Parent = new Parent();
            parentRepos = new ParentRepos();
        }

        private bool CanReturnBackPage(object? obj) => true;

        private void ReturnBackPage(object? obj)
        {
            if (obj is Page page)
            {
                page.NavigationService.GoBack();
            }
        }

        private bool CanCreate(object? obj)
        {
            return true;
        }

        private void AddNewParent(object? obj)
        {

           
            parentRepos!.Add(Parent);
            MessageBox.Show("Parent was added!");

            parentRepos.Save();

            if (obj is Page page)
            {
                page.NavigationService.Navigate(new ParentPage());
            }
        }
    }
}
