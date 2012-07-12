using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace BitsAndPieces
{
    public class Asynchrony
    {
        private GetPersonAsync _getPersonAsync;

        public void RunWithDelegates()
        {
            _getPersonAsync = new GetPersonAsync(GetPerson);
            _getPersonAsync.BeginInvoke(GetPersonCallBack, null);
            //or
            _getPersonAsync.BeginInvoke((result) =>
                {
                    var person = _getPersonAsync.EndInvoke(result);
                }, null);
        }
        internal void GetPersonCallBack(IAsyncResult asyncResult)
        {
            Person person = _getPersonAsync.EndInvoke(asyncResult);
        }

        public void RunWithThreadPool()
        {
            for(int i=0;i<5;i++)
            {
                ThreadPool.QueueUserWorkItem(x =>
                    {
                        Debug.WriteLine(x.ToString());
                    });
            }
        }

        public void RunWithEvents()
        {
            var webClient = new WebClient();
            webClient.DownloadStringCompleted += (sender, args) =>
                {
                    Debug.WriteLine(args.Result);
                };
            webClient.DownloadStringAsync(new Uri("http://www.google.com"));
        }

        public void RunWithTask()
        {
            var task = new Task(() =>
                {
                    Debug.WriteLine("task");
                });
            task.Start();
        }

        public async Task RunWithAsync()
        {
            string result = await new WebClient().DownloadStringTaskAsync(new Uri("http://www.google.com"));
            Debug.WriteLine(result.Substring(0, 500));
        }

        public async Task RunWithAsyncForAPM()
        {
            var request = WebRequest.Create("http://www.hotmail.com") as HttpWebRequest;
            request.Method = "HEAD";

            Task<WebResponse> getResponseTask = Task.Factory.FromAsync<WebResponse>(
                request.BeginGetResponse, request.EndGetResponse, null);

            var response = (HttpWebResponse) await getResponseTask;

            MessageBox.Show(String.Format("we got {0} headers", response.Headers.Count));
        }

        internal Person GetPerson()
        {
            return new Person();
        }

        public class Person
        {
            public string Name { get; set; }
        }

        internal delegate Person GetPersonAsync();
    }
}
