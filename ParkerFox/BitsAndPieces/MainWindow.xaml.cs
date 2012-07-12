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

namespace BitsAndPieces
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void asyncDelegate_Click(object sender, RoutedEventArgs e)
        {
            new Asynchrony().RunWithDelegates();
        }

        private void asyncThreadPool_Click(object sender, RoutedEventArgs e)
        {
            new Asynchrony().RunWithThreadPool();
        }

        private void asyncEvents_Click(object sender, RoutedEventArgs e)
        {
            new Asynchrony().RunWithEvents();
        }

        private void asyncTask_Click(object sender, RoutedEventArgs e)
        {
            new Asynchrony().RunWithTask();
        }

        private void asyncAsync_Click(object sender, RoutedEventArgs e)
        {
            new Asynchrony().RunWithAsync();
        }

        private void asyncTaskWithAPM_Click(object sender, RoutedEventArgs e)
        {
            new Asynchrony().RunWithAsyncForAPM();
        }
    }
}
