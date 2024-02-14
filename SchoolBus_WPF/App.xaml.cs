using SchoolBus_WPF.Views.Windows;
using System.Windows;

namespace SchoolBus_WPF
{

    public partial class App : Application
    {
        private void mainwindow(object sender, StartupEventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.ShowDialog();
        }
    }
}
