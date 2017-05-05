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

using RestClient.Adapters;

namespace RestClient.Views
{
    [Activity(Label = "MainView", MainLauncher = true, Theme = "@style/Theme.AppCompat")]
    public class MainView : AppCompatActivity
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

            var fragments = new Fragment[]
            {
                new RequestView(),
                new HistoryView(),
            };

            var titles = new[]
            {
                "Request",
                "History",
            };

            var viewPager = FindViewById<ViewPager>(Resource.Id.ViewPager);
            var adapter = new TabsAdapter(SupportFragmentManager, fragments, titles);
            viewPager.Adapter = adapter;

            var tabLayout = FindViewById<TabLayout>(Resource.Id.TabLayout);
            tabLayout.SetupWithViewPager(viewPager);
        }
    }
}