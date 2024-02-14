using Microsoft.Data.SqlClient;
using SchoolBus_WPF.ViewModels.PageViewModels;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace SchoolBus_WPF.Views.Pages
{
    /// <summary>
    /// Interaction logic for ClassPage.xaml
    /// </summary>
    public partial class ClassPage : Page
    {
        

        public ClassPage()
        {
            InitializeComponent();
            DataContext = new ClassPageViewModel();
        }

       

     
    }
}
