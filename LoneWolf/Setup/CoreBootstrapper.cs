using System;
using System.Linq;
using System.Reflection;
using Autofac;
using LoneWolf.Views.Welcome;
using PolyhydraGames.Core.Forms;
using PolyhydraGames.Core.Forms.Interfaces;
using PolyhydraGames.Core.Forms.Setup;
using PolyhydraGames.Core.Forms.Views;
using PolyhydraGames.Core.Interfaces;
using PolyhydraGames.Core.IOC;
using Xamarin.Forms;

namespace LoneWolf.Setup
{
    public abstract class CoreBootstrapper : FormsIOCBootstrapper
    {
        //private IList<Type> ExcludedPages()
        //{
        //    return new[]
        //    {
        //        typeof (VerbosePickerPage)
        //    };
        //}
        protected override void FollowupAction()
        {
        }

        private Assembly[] Assemblies()
        {
            var dataAssembly = typeof(CoreBootstrapper).GetTypeInfo().Assembly;
            var coreFormsAssembly = typeof(PolyhydraGamesCoreFormsBootstrapper).GetTypeInfo().Assembly;
          
            return new[] { dataAssembly, coreFormsAssembly };
        }
        protected override void ViewFactoryRegistration()
        {

            var pages = Pages(Assemblies()) ;
            var viewModels = ViewModels(Assemblies()).ToArray();
            PairMVVM(pages, viewModels);
            var vf = IOC.Get<IViewFactory>();
         
            vf.Register<IMainMenu, MenuPage>();
            vf.Register<IFirstPageViewModel, WelcomePage>();
            if (!vf.IsRegistered<IMainMenu>())
            {
                throw new Exception("IMainMenu is not registered!");
            };
            if (!vf.IsRegistered<IFirstPageViewModel>())
            {
                throw new Exception("IFirstPageViewModel is not registered!");
            };
        }

        protected override void BuildBaseServices(ContainerBuilder builder)
        {
            base.BuildBaseServices(builder);
            builder.Register(ctx => (IApp)Application.Current).As<IApp>().SingleInstance();
            // builder.Reg<Constants>();
            builder.RegisterModule<ServicesAutofacModule>(); 
           
            // builder.RegisterSingleton<DialogService,IDialogService>();    
        }

        protected override void BuildViewModels(ContainerBuilder builder)
        {
            builder.RegisterModule<ViewModelRegistrationModule>(); 
        }

        /// <summary>
        /// Registers a module that handles all page registration to the container.
        /// </summary>
        /// <param name="builder">Builder.</param>
        protected override void BuildPages(ContainerBuilder builder)
        {
            builder.RegisterModule<PagesRegistrationModule>();
        }
    }
}