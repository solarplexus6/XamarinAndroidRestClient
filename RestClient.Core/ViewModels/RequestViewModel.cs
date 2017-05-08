using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MvvmCross.Core.ViewModels;

namespace RestClient.Core.ViewModels
{
    public class RequestViewModel : MvxViewModel
    {
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

        async void SendRequest()
        {
            await Task.Delay(500);
            var method = SelectedMethod;
        }
    }
}
