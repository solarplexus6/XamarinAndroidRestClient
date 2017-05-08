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

namespace RestClient.Core.ViewModels
{
    public class RequestViewModel : MvxViewModel
    {
        // TODO: as service
        private HttpClient _client = new HttpClient();
        private IHistoryService _historyService;

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

        public IMvxCommand SendRequestCommand
        {
            get
            {
                return new MvxCommand(() => SendRequest());
            }
        }

        private string _responseContent;
        public string ResponseContent
        {
            get => _responseContent;
            set => SetProperty(ref _responseContent, value);
        }

        public RequestViewModel()
        {
            _historyService = Mvx.Resolve<IHistoryService>();
        }

        async void SendRequest()
        {
            var method = new HttpMethod(SelectedMethod);
            var url = URL;
            var request = new HttpRequestMessage(method, url);
            try
            {
                // TODO: cancelation token
                var response = await _client.SendAsync(request);
                var content = await response.Content.ReadAsStringAsync();
                ResponseContent = content;
                _historyService.History.Add(new HistoryItem(url));
            }
            catch (Exception)
            {
                
            }
        }
    }
}
