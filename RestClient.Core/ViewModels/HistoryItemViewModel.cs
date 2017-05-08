using MvvmCross.Core.ViewModels;

namespace RestClient.Core.ViewModels
{
    public class HistoryItemViewModel : MvxViewModel
    {
        private string _url;
        public string Url
        {
            get => _url;
            set => SetProperty(ref _url, value);
        }

        private string _flagUrl;
        public string FlagUrl
        {
            get => _flagUrl;
            set => SetProperty(ref _flagUrl, value);
        }

        public HistoryItemViewModel(string url, string flagUrl)
        {
            _flagUrl = flagUrl;
            _url = url;
        }
    }
}