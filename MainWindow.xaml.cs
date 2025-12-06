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

namespace praktika13
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            string localPath = System.IO.Directory.GetCurrentDirectory(); // путь к папке с программой

            OpenPages(pages.main);
        }

        public enum pages
        {
            main
        }

        public void OpenPages(pages _pages)
        {
            if (_pages == pages.main) frame.Navigate(new Layouts.Main());
        }
    }
}
