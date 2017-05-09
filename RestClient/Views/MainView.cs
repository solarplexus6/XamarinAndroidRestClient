using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V4.Widget;
using Fragment = Android.Support.V4.App.Fragment;
using Android.Support.V7.App;
using Android.Support.V7.Widget;

using MvvmCross.Droid.Support.V4;
using MvvmCross.Droid.Platform;
using MvvmCross.Droid.Support.V7.AppCompat;

using RestClient.Adapters;
using RestClient.Core.ViewModels;

namespace RestClient.Views
{
    [Activity(Label = "MainView", MainLauncher = true, Theme = "@style/Theme.AppCompat.NoActionBar")]
    public class MainView : MvxCachingFragmentCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.MainView);

            // Init toolbar
            var toolbar = FindViewById<Toolbar>(Resource.Id.AppBar);
            SetSupportActionBar(toolbar);
            SupportActionBar.SetTitle(Resource.String.ApplicationName);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetDisplayShowHomeEnabled(true);

            var drawerLayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            var drawerToggle = new ActionBarDrawerToggle(this, drawerLayout, toolbar, Resource.String.OpenDrawer, Resource.String.CloseDrawer);
            drawerLayout.AddDrawerListener(drawerToggle);
            drawerToggle.SyncState();

            var fragments = new List<MvxCachingFragmentStatePagerAdapter.FragmentInfo>
            {
                new MvxCachingFragmentStatePagerAdapter.FragmentInfo("Request", typeof(RequestView), new RequestViewModel()),
                new MvxCachingFragmentStatePagerAdapter.FragmentInfo("History", typeof(HistoryView), new HistoryViewModel()),
            };

            var viewPager = FindViewById<ViewPager>(Resource.Id.ViewPager);
            // var adapter = new TabsAdapter(SupportFragmentManager, fragments, titles);
            var adapter = new MvxCachingFragmentStatePagerAdapter(this, SupportFragmentManager, fragments);
            viewPager.Adapter = adapter;
            viewPager.PageSelected += ViewPager_PageSelected;

            var tabLayout = FindViewById<TabLayout>(Resource.Id.TabLayout);
            tabLayout.SetupWithViewPager(viewPager);
        }

        private void ViewPager_PageSelected(object sender, ViewPager.PageSelectedEventArgs e)
        {
            var fab = FindViewById<FloatingActionButton>(Resource.Id.FloatingActionButton);
            if (e.Position == 0) {
                fab.Show();
            }
            else {
                fab.Hide();
            }
        }
    }
}