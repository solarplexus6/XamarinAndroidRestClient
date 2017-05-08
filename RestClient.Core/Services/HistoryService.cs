using System.Collections.ObjectModel;
using RestClient.Core.Models;

namespace RestClient.Core.Services
{
    public class HistoryService : IHistoryService
    {
        public HistoryService()
        {
            // TODO restore from a file
            History = new ObservableCollection<HistoryItem>();
        }

        public ObservableCollection<HistoryItem> History { get; private set; }
    }
}