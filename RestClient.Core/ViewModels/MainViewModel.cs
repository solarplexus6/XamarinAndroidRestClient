using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MvvmCross.Core.ViewModels;
using MvvmCross.Plugins.Messenger;
using RestClient.Core.Messages;

namespace RestClient.Core.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        private readonly IMvxMessenger _messenger;

        public IMvxCommand ClearFormCommand
        {
            get
            {
                return new MvxCommand(() => ClearForm());
            }
        }

        public MainViewModel(IMvxMessenger messenger)
        {
            _messenger = messenger;
        }

        private void ClearForm()
        {
            _messenger?.Publish(new ClearRequestFormMessage(this));
        }
    }
}
