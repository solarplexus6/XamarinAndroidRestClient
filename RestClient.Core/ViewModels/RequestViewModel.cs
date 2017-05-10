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

        private bool _isInProgress;
        public bool IsInProgress
        {
            get => _isInProgress;
            set => SetProperty(ref _isInProgress, value);
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

        public IMvxCommand SendRequestCommand
        {
            get
            {
                return new MvxCommand(() => SendRequest());
            }
        }

        public event EventHandler HideKeyboard;

        protected virtual void OnHideKeyboard()
        {
            HideKeyboard?.Invoke(this, EventArgs.Empty);
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
            URL = string.Empty;
            ResponseContent = string.Empty;
            Body = string.Empty;
        }

        async void SendRequest()
        {
            if (URL == null || URL == string.Empty)
            {
                return;
            }
            ResponseContent = string.Empty;
            OnHideKeyboard();
            IsInProgress = true;

            var url = URL;
            var method = new HttpMethod(SelectedMethod);
            var request = new HttpRequestMessage(method, url);
            if (method != HttpMethod.Get) {
                request.Content = new StringContent(Body);
            }

            // TODO: exceptions
            // TODO: cancelation token
            var response = await _client.SendAsync(request);
            var content = await response.Content.ReadAsStringAsync();
            ResponseContent = content;
            _historyService.History.Add(new HistoryItem(url));

            IsInProgress = false;
        }


    }
}
