﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using MvvmCross.Droid.Platform;
using MvvmCross.Core.ViewModels;
using MvvmCross.Binding.Bindings.Target.Construction;
using MvvmCross.Platform.Platform;
using MvvmCross.Droid.Support.V7.AppCompat;

namespace RestClient
{
    class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
        }

        protected override IMvxApplication CreateApp()
        {
            return new RestClient.Core.App();
        }

        /// <summary>
		/// Fill the Binding Factory Registry with bindings from the support library.
		/// </summary>
		protected override void FillTargetFactories(IMvxTargetBindingFactoryRegistry registry)
        {
            MvxAppCompatSetupHelper.FillTargetFactories(registry);
            base.FillTargetFactories(registry);
        }

        protected override IMvxTrace CreateDebugTrace()
        {
            return new DebugTrace();
        }
    }
}