using System;
using System.Collections.Generic;
using Caliburn.Micro;
using Foundation;
using Setup.iOS.ViewModel;
using UIKit;

namespace Setup.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the
    // User Interface of the application, as well as listening (and optionally responding) to application events from iOS.
    [Register ("AppDelegate")]
    public class AppDelegate : CaliburnApplicationDelegate
    {
        private SimpleContainer container;

        public override UIWindow Window
        {
            get;
            set;
        }

        protected override void Configure()
        {
            container = new SimpleContainer();

            container.PerRequest<MainViewModel>();
        }

        protected override void BuildUp(object instance)
        {
            container.BuildUp(instance);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return container.GetAllInstances(service);
        }

        protected override object GetInstance(Type service, string key)
        {
            return container.GetInstance(service, key);
        }

        public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
        {
            Initialize();

            return true;
        }
    }
}

