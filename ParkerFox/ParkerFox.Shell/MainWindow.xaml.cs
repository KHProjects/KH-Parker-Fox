using ParkerFox.Core.Entities.Ecommerce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
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

namespace ParkerFox.Shell
{
    public partial class MainWindow : Window
    {
        private IncomingOrderObserver incomingOrderObserver;

        public MainWindow()
        {
            InitializeComponent();
            incomingOrderObserver = new IncomingOrderObserver();

            incomingOrderObserver.NewOrder += async (sender, ojbect) =>
            {
                MessageBox.Show("YOUR MOM");
            };
        }

        public async void saveCommand_Click(object sender, RoutedEventArgs e)
        {
            //incomingOrderObserver.RaiseEvent();
            saveCommand.IsEnabled = false;
            //await Task.Delay(5000);
            var orders = await incomingOrderObserver.GetOrders();
            saveCommand.IsEnabled = true;

            DataContext = orders;
        }

        private async void test_Click_1(object sender, RoutedEventArgs e)
        {
            HttpClient httpClient = new HttpClient
                {
                    BaseAddress = new Uri("http://localhost:8181")
                };

            var response = await httpClient.GetAsync("api/product");
            
            //var products = await response.Content.ReadAsAsync<IEnumerable<Product>>

            string data = await new WebClient().DownloadStringTaskAsync("http://localhost:8181/api/product");
        }
    }

    public class IncomingOrderObserver
    {
        public EventHandler<Order> NewOrder;

        public void RaiseEvent()
        {
            NewOrder(this, new Order());
        }

        public async Task<IEnumerable<Order>> GetOrders()
        {
            //await Task.Delay(5000);
            return new List<Order> { new Order { Title = "order one" }, new Order { Title = "Order Two" } };
        }

        public async Task<Order> DoSumShit()
        {
            return new Order();
        }
    }
}
