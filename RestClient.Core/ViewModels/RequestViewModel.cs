using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MvvmCross.Core.ViewModels;
using System.Net.Http;
using MvvmCross.Platform;
using RestClient.Core.Models;
using RestClient.Core.Services;
using MvvmCross.Plugins.Messenger;
using RestClient.Core.Messages;

namespace RestClient.Core.ViewModels
{
    public class RequestViewModel : MvxViewModel
    {
        // TODO: as service
        private HttpClient _client = new HttpClient();
        private IHistoryService _historyService;
        private readonly MvxSubscriptionToken _token;

        private string _url = "https://postman-echo.com/get?test=123";
        public string URL
        {
            get => _url;
            set => SetProperty(ref _url, value);
        }

        public List<string> Methods
        {
            get
            {
                return new List<string>
                {
                    "GET",
                    "POST",
                    "PUT",
                    "DELETE",
                    "PATCH"
                };
            }
        }

        // TODO: use HttpMethod and value converter
        private string _selectedMethod;
        public string SelectedMethod
        {
            get => _selectedMethod;
            set => SetProperty(ref _selectedMethod, value);
        }

        private string _responseContent;
        public string ResponseContent
        {
            get => _responseContent;
            set => SetProperty(ref _responseContent, value);
        }

        private string _body;
        public string Body
        {
            get => _body;
            set => SetProperty(ref _body, value);
        }

        public IMvxCommand SendRequestCommand
        {
            get
            {
                return new MvxCommand(() => SendRequest());
            }
        }

        public RequestViewModel()
        {
            // TODO dependencies
            _historyService = Mvx.Resolve<IHistoryService>();

            var messenger = Mvx.Resolve<IMvxMessenger>();
            _token = messenger.Subscribe<ClearRequestFormMessage>(ClearRequestForm);
        }

        private void ClearRequestForm(ClearRequestFormMessage obj)
        {
            URL = "";
            ResponseContent = "";
            Body = "";
        }

        async void SendRequest()
        {
            // TODO progress
            var method = new HttpMethod(SelectedMethod);
            var url = URL;
            var request = new HttpRequestMessage(method, url);
            if (method != HttpMethod.Get) {
                request.Content = new StringContent(Body);
            }


            // TODO: cancelation token
            var response = await _client.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();
            ResponseContent = content;
            _historyService.History.Add(new HistoryItem(url));
        }


    }
}
