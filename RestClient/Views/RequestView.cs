using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

using MvvmCross.Droid.Support.V4;

using RestClient.Core.ViewModels;
using MvvmCross.Binding.Droid.BindingContext;

namespace RestClient.Views
{
    public class RequestView : MvxFragment<RequestViewModel>
    {
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            
            return this.BindingInflate(Resource.Layout.RequestView, null);
        }
    }
}