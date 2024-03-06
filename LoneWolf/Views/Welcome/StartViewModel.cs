using PolyhydraGames.Core.Forms.Interfaces;
using PolyhydraGames.Core.Forms.Views;
using PolyhydraGames.Core.Interfaces;
using PolyhydraGames.Core.IOC;
using PolyhydraGames.Core.ViewModel;

namespace LoneWolf.Views.Welcome
{
    public class StartViewModel : ViewModelBase, IFirstPageViewModel
    {
        public override void OnAppearing()
        {
            base.OnAppearing();
            var vf = IOC.Get<IViewFactory>();
            var nav = IOC.Get<INavigator>();
            var vm = IOC.Get<RootViewModel>();
            var page = new RootPage(vf);
            //var page = IOC.Get<RootPage>();
           
        }
    }
}