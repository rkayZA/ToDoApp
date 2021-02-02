using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using ToDoApp.Library.DataAccess;

namespace ToDoApp.WPFUI.Controls
{
    /// <summary>
    /// Interaction logic for AboutControl.xaml
    /// </summary>
    public partial class AboutControl : UserControl
    {
        private readonly ISQLiteData _db;

        //public string Version
        //{
        //    get { return System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString(); }
        //}

        public AboutControl(ISQLiteData db)
        {
            
            _db = db;
            InitializeComponent();
        }

        private void backToListBtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow._mainWindow.appContent.Content = new MainAppControl(_db);
        }
    }
}
