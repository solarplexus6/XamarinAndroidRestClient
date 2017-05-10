using System;

using Android.OS;
using Android.Views;
using Android.Widget;

using MvvmCross.Droid.Support.V4;
using MvvmCross.Binding.Droid.BindingContext;

using RestClient.Core.ViewModels;
using Android.Views.InputMethods;

namespace RestClient.Views
{
    public class RequestView : MvxFragment<RequestViewModel>
    {
        private EditText _editUrl;
        private EditText _editBody;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        private void ViewModel_HideKeyboard(object sender, EventArgs e)
        {
            InputMethodManager inputManager = (InputMethodManager)Activity.GetSystemService(Android.Content.Context.InputMethodService);

            var currentFocus = Activity.CurrentFocus;
            if (currentFocus != null)
            {
                inputManager.HideSoftInputFromWindow(currentFocus.WindowToken, HideSoftInputFlags.NotAlways);
            }
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            base.OnCreateView(inflater, container, savedInstanceState);
            var view = this.BindingInflate(Resource.Layout.RequestView, null);
            _editUrl = view.FindViewById<EditText>(Resource.Id.edit_url);
            _editBody = view.FindViewById<EditText>(Resource.Id.edit_body);

            ViewModel.HideKeyboard += ViewModel_HideKeyboard;
            return view;
        }
    }
}