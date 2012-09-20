using ParkerFox.Core.Entities.Ecommerce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using ParkerFox.Shell.ApplicationServices;

namespace ParkerFox.Shell
{
    public partial class MainWindow : Window
    {
        private IncomingOrderObserver incomingOrderObserver;

        public MainWindow()
        {
            InitializeComponent();
            incomingOrderObserver = new IncomingOrderObserver();

            incomingOrderObserver.NewOrder += async (sender, orders) =>
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

        private async void getOrdersCommand_Click(object sender, RoutedEventArgs e)
        {
            var orders = await incomingOrderObserver.GetOrders();

            MessageBox.Show(String.Format("We have {0} orders", orders.Count()));
        }

        private void BindOrder(IEnumerable<Order> orders)
        {
            
        }
    }

    public class IncomingOrderObserver
    {
        private ApplicationServices.NewOrderProcessingServiceClient _newOrderProcessingServiceClient;
        private CancellationToken _cancellationToken;

        public EventHandler<IEnumerable<Order>> NewOrder;

        public IncomingOrderObserver()
        {
            _newOrderProcessingServiceClient = new NewOrderProcessingServiceClient();
            _cancellationToken = new CancellationToken();
        }

        public async Task<IEnumerable<Order>> GetOrders()
        {
            return await _newOrderProcessingServiceClient.GetOrdersAsync();
        }

        public void Start()
        {
            Run();
        }

        public void Stop()
        {
            
        }

        private async void Run()
        {
            while(true)
            {
                var orders = await _newOrderProcessingServiceClient.GetOrdersAsync();

                if (orders.Any())
                    RaiseEvent(orders);

                await Task.Delay(5000, _cancellationToken);
            }
        }

        private void RaiseEvent(IEnumerable<Order> orders)
        {
            NewOrder(this, orders);
        }
    }
}
