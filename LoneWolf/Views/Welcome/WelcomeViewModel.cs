using PolyhydraGames.Core.Forms.Interfaces;
using PolyhydraGames.Core.ViewModel;
using ReactiveUI;

namespace LoneWolf.Views.Welcome
{
    public class WelcomeViewModel : ViewModelBase, IFirstPageViewModel
    {
        public override void OnAppearing()
        {
            base.OnAppearing();
           MainText = "Hi I am text";
        }

        private string _mainText;

        public string MainText
        {
            get { return _mainText; }
            set { this.RaiseAndSetIfChanged(ref _mainText, value); }
        }
    }
}