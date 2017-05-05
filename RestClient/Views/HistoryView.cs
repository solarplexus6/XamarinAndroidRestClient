using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.Widget;
using ListFragment = Android.Support.V4.App.ListFragment;

namespace RestClient.Views
{
    public class HistoryView : ListFragment
    {
        public override void OnStart()
        {
            base.OnStart();

            ListAdapter = new ArrayAdapter(
                Activity,
                Android.Resource.Layout.SimpleListItem1,
                new[] { "First", "Second", "Third", "Fourth" });
        }
    }
}