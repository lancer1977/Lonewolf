using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using PolyhydraGames.Core.Droid.Interface;
using PolyhydraGames.Core.IOC;

namespace LoneWolf.Droid
{
    [Activity(Label = "LoneWolf", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity, ICurrentActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle); 

           // Xamarin.Insights.Initialize(Constants.ApiKey, this); 
            DroidCraftBootstrapper.Run();
            IOC.Instance.RegisterSingleton<ICurrentActivity>(this);
           // IOC.Instance.RegisterSingleton<IVoiceRecognizerDevice>(this);
            LoadApplication(new App());
        }
    }
} 

