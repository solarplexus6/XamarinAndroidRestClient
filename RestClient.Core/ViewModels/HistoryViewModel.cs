using System.Collections.Specialized;
using System.Net.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MvvmCross.Core.ViewModels;
using MvvmCross.Platform;
using MvvmCross.Platform.Platform;

using RestClient.Core.Models;
using RestClient.Core.Services;

namespace RestClient.Core.ViewModels
{
    public class HistoryViewModel : MvxViewModel
    {
        // TODO: as service
        private HttpClient _client = new HttpClient();
        private IHistoryService _historyService;

        private readonly MvxObservableCollection<HistoryItemViewModel> _history = new MvxObservableCollection<HistoryItemViewModel>();
        public MvxObservableCollection<HistoryItemViewModel> History
        {
            get => _history;
        }

        public HistoryViewModel() : base()
        {
            // TODO inject with constructor parameter
            _historyService = Mvx.Resolve<IHistoryService>();
            _historyService.History.CollectionChanged += History_CollectionChanged;
        }

        private async void History_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems == null)
            {
                return;
            }
            var serializer = Mvx.Resolve<IMvxJsonConverter>();
            foreach (var url in e.NewItems.OfType<HistoryItem>().Select(item => new Uri(item.Url)))
            {
                var geoIpUrl = $"http://freegeoip.net/json/{url.Authority}";
                var geoResponse = await _client.GetAsync(geoIpUrl);
                var content = await geoResponse.Content.ReadAsStreamAsync();
                try
                {
                    var geoIpData = serializer.DeserializeObject<GeoIpData>(content);
                    _history.Add(new HistoryItemViewModel(url.OriginalString, $"https://flagpedia.net/data/flags/normal/{geoIpData.CountryCode.ToLower()}.png"));
                }
                catch
                {
                }
            }
            // _history.AddRange(e.NewItems.OfType<HistoryItem>().Select(item => new HistoryItemViewModel(item.Url, "https://flagpedia.net/data/flags/normal/fr.png")));
        }
    }
}
