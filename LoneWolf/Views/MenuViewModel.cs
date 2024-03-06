using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using PolyhydraGames.Core.Interfaces;
using PolyhydraGames.Core.IOC;
using PolyhydraGames.Core.Model;
using PolyhydraGames.Core.ViewModel;

namespace LoneWolf.Views
{
    public class MenuViewModel : MenuViewModelBase, ILoad, IMainMenu
    { 
        private readonly IWebsiteRequestor _websiteCaller; 

        public MenuViewModel( 
            IWebsiteRequestor websiteCaller,
            INavigator navigator ) : base(navigator)
        { 
            _websiteCaller = websiteCaller; 

        }
 

        public override string Title => "Main Menu";

        public override void Start()
        {
            RefreshMenu();

        }
 
        public void TestCallback(IList<string> items)
        {
            Debug.WriteLine(items.Count);

            IOC.Get<IDisplayService>().MsgBox(items[0]);
        }
        public void RefreshMenu()
        {
            IOC.Get<IMainThreadDispatcher>().InvokeOnMainThread(() =>
            {
                Items.Clear();
                Items.Add(new MenuItem("Start", typeof(MenuViewModel)));
            });

        }


        public void Load()
        {
            throw new System.NotImplementedException();
        }
    }
}