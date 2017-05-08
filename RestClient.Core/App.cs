using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MvvmCross.Platform.IoC;

namespace RestClient.Core
{
    public class App : MvvmCross.Core.ViewModels.MvxApplication
    {
        public override void Initialize()
        {
            //CreatableTypes()
            //    .EndingWith("Service")
            //    .AsInterfaces()
            //    .RegisterAsLazySingleton();

            // RegisterAppStart<ViewModels.FirstViewModel>();
        }
    }
}
