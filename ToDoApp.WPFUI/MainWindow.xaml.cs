using System;
using System.Collections.Generic;
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
using ToDoApp.WPFUI.Controls;

namespace ToDoApp.WPFUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        

        public MainWindow()
        {
            InitializeComponent();
            appContent.Content = new MainAppControl();
        }



        private void AboutMenuItem_Click(object sender, RoutedEventArgs e)
        {
            appContent.Content = new AboutControl();
        }

        private void GoToListMenuItem_Click(object sender, RoutedEventArgs e)
        {
            appContent.Content = new MainAppControl();
        }

        private void ExitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
