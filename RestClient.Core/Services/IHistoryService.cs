using System.Collections.ObjectModel;
using RestClient.Core.Models;

namespace RestClient.Core.Services
{
    public interface IHistoryService
    {
        // TODO Add, HistoryChanged
        ObservableCollection<HistoryItem> History { get; }
    }
}