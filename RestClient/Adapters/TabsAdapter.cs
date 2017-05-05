using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.Runtime;
using Android.Support.V4.App;
using Java.Lang;
using Fragment = Android.Support.V4.App.Fragment;

namespace RestClient.Adapters
{
    class TabsAdapter : FragmentPagerAdapter
    {
        private readonly Fragment[] fragments;
        private readonly ICharSequence[] titles;

        public override int Count => fragments.Length;

        public TabsAdapter(FragmentManager fm, Fragment[] fragments, string[] titles) : base(fm)
        {
            this.fragments = fragments;
            this.titles = CharSequence.ArrayFromStringArray(titles);
        }

        public override Fragment GetItem(int position)
        {
            return fragments[position];
        }

        public override ICharSequence GetPageTitleFormatted(int position)
        {
            return titles[position];
        }
    }
}