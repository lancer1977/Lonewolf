using LoneWolf.Views.Welcome;
using PolyhydraGames.Core.Forms;
using PolyhydraGames.Core.Forms.Interfaces;
using PolyhydraGames.Core.Forms.Views;
using PolyhydraGames.Core.Interfaces;
using PolyhydraGames.Core.IOC;
using Xamarin.Forms;

namespace LoneWolf
{
    public class App : BaseApplication
    {
        public App()
        {

            //   InitializeComponent();
            // var page = IOC.Get<IViewFactory>().Resolve<DatabaseLoaderViewModel>();

            //IOC.Instance.RegisterSingleton(this);
            //  SettingsColorPalette();

        }

        protected override void OnStart()
        {
            IOC.Get<INavigator>().SetRoot<RootViewModel>(); 
 
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
