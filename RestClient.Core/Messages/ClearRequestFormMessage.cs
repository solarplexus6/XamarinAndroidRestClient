using MvvmCross.Plugins.Messenger;

namespace RestClient.Core.Messages
{
    class ClearRequestFormMessage : MvxMessage
    {
        public ClearRequestFormMessage(object sender) : base(sender)
        {
        }
    }
}
